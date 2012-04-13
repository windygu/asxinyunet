using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using NewLife.Reflection;
using NewLife.Threading;
using XCode.Code;
using XCode.Exceptions;

namespace XCode.DataAccessLayer
{
    /// <summary>���ݷ��ʲ�</summary>
    /// <remarks>
    /// ��Ҫ����ѡ��ͬ�����ݿ⣬��ͬ�����ݿ�Ĳ����������
    /// ÿһ�����ݿ������ַ�������ӦΨһ��һ��DALʵ����
    /// ���ݿ������ַ�������д�������ļ��У�Ȼ����Createʱָ�����֣�
    /// Ҳ����ֱ�Ӱ������ַ�����ΪAddConnStr�Ĳ������롣
    /// ÿһ�����ݿ����������ָ�����������ڹ����棬�ձ�����*��ƥ�����л���
    /// </remarks>
    public partial class DAL
    {
        #region ��������
        /// <summary>���캯��</summary>
        /// <param name="connName">������</param>
        private DAL(String connName)
        {
            _ConnName = connName;

            if (!ConnStrs.ContainsKey(connName)) throw new XCodeException("����ʹ�����ݿ�ǰ����[" + connName + "]�����ַ���");

            ConnStr = ConnStrs[connName].ConnectionString;
            if (String.IsNullOrEmpty(ConnStr)) throw new XCodeException("����ʹ�����ݿ�ǰ����[" + connName + "]�����ַ���");

            // �������ݿ���ʶ����ʱ�򣬾Ϳ�ʼ������ݿ�ܹ�
            // ����������ռ�ô���ʱ�䣬�������������ֻ�����ڰ�װ�����ʱ��
            // Ҫ�����ܵļ��ٷǰ�װ�׶ε�ʱ��ռ��
            try
            {
                //DatabaseSchema.Check(Db);
                SetTables();
            }
            catch (Exception ex)
            {
                if (Debug) WriteLog(ex.ToString());
            }
        }

        private static Dictionary<String, DAL> _dals = new Dictionary<String, DAL>(StringComparer.OrdinalIgnoreCase);
        /// <summary>����һ�����ݷ��ʲ����</summary>
        /// <param name="connName">���������������ַ���</param>
        /// <returns>��Ӧ��ָ�����ӵ�ȫ��Ψһ�����ݷ��ʲ����</returns>
        public static DAL Create(String connName)
        {
            if (String.IsNullOrEmpty(connName)) throw new ArgumentNullException("connName");

            DAL dal = null;
            if (_dals.TryGetValue(connName, out dal)) return dal;
            lock (_dals)
            {
                if (_dals.TryGetValue(connName, out dal)) return dal;

                ////������ݿ������������Ȩ��
                //if (License.DbConnectCount != _dals.Count + 1)
                //    License.DbConnectCount = _dals.Count + 1;

                dal = new DAL(connName);
                // ����connName����Ϊ�����ڴ����������Զ�ʶ����ConnName
                _dals.Add(dal.ConnName, dal);
            }

            return dal;
        }

        private static Object _connStrs_lock = new Object();
        private static Dictionary<String, ConnectionStringSettings> _connStrs;
        private static Dictionary<String, Type> _connTypes = new Dictionary<String, Type>(StringComparer.OrdinalIgnoreCase);
        /// <summary>�����ַ�������</summary>
        public static Dictionary<String, ConnectionStringSettings> ConnStrs
        {
            get
            {
                if (_connStrs != null) return _connStrs;
                lock (_connStrs_lock)
                {
                    if (_connStrs != null) return _connStrs;
                    Dictionary<String, ConnectionStringSettings> cs = new Dictionary<String, ConnectionStringSettings>(StringComparer.OrdinalIgnoreCase);

                    // ��ȡ�����ļ�
                    ConnectionStringSettingsCollection css = ConfigurationManager.ConnectionStrings;
                    if (css != null && css.Count > 0)
                    {
                        foreach (ConnectionStringSettings set in css)
                        {
                            if (set.Name == "LocalSqlServer") continue;
                            if (set.Name == "LocalMySqlServer") continue;
                            if (String.IsNullOrEmpty(set.ConnectionString)) continue;
                            if (String.IsNullOrEmpty(set.ConnectionString.Trim())) continue;

                            Type type = DbFactory.GetProviderType(set.ConnectionString, set.ProviderName);
                            if (type == null) throw new XCodeException("�޷�ʶ����ṩ��" + set.ProviderName + "��");

                            cs.Add(set.Name, set);
                            _connTypes.Add(set.Name, type);
                        }
                    }
                    _connStrs = cs;
                }
                return _connStrs;
            }
        }

        /// <summary>��������ַ���</summary>
        /// <param name="connName">������</param>
        /// <param name="connStr">�����ַ���</param>
        /// <param name="type">ʵ����IDatabase�ӿڵ����ݿ�����</param>
        /// <param name="provider">���ݿ��ṩ�ߣ����û��ָ�����ݿ����ͣ������ṩ���ж�ʹ����һ����������</param>
        public static void AddConnStr(String connName, String connStr, Type type, String provider)
        {
            if (String.IsNullOrEmpty(connName)) throw new ArgumentNullException("connName");

            if (type == null) type = DbFactory.GetProviderType(connStr, provider);
            if (type == null) throw new XCodeException("�޷�ʶ����ṩ��" + provider + "��");

            // ��������߸���ǰ�����ù��˵�
            ConnectionStringSettings set = new ConnectionStringSettings(connName, connStr, provider);
            ConnStrs[connName] = set;
            _connTypes[connName] = type;
        }

        /// <summary>��ȡ������ע���������</summary>
        /// <returns></returns>
        public static IEnumerable<String> GetNames() { return ConnStrs.Keys; }
        #endregion

        #region ����
        private String _ConnName;
        /// <summary>������</summary>
        public String ConnName { get { return _ConnName; } }

        private Type _ProviderType;
        /// <summary>ʵ����IDatabase�ӿڵ����ݿ�����</summary>
        private Type ProviderType
        {
            get
            {
                if (_ProviderType == null && _connTypes.ContainsKey(ConnName)) _ProviderType = _connTypes[ConnName];
                return _ProviderType;
            }
        }

        /// <summary>���ݿ�����</summary>
        public DatabaseType DbType
        {
            get
            {
                var db = DbFactory.GetDefault(ProviderType);
                if (db == null) return DatabaseType.Other;
                return db.DbType;
            }
        }
        //public DatabaseType DbType { get { return Db.DbType; } }

        private String _ConnStr;
        /// <summary>�����ַ���</summary>
        public String ConnStr
        {
            get { return _ConnStr; }
            set
            {
                if (_ConnStr != value)
                {
                    _ConnStr = value;
                    _Db = null;
                }
            }
        }

        private IDatabase _Db;
        /// <summary>���ݿ⡣�������ݿ�����ڴ�ͳһ����ǿ�ҽ��鲻Ҫֱ��ʹ�ø����ԣ��ڲ�ͬ�汾��IDatabase�����нϴ�ı�</summary>
        public IDatabase Db
        {
            get
            {
                if (_Db != null) return _Db;

                Type type = ProviderType;
                if (type != null)
                {
                    //_Db = TypeX.CreateInstance(type) as IDatabase;
                    // ʹ��Ѽ�����ͣ�������ӿڰ汾����������޷�ʹ��
                    _Db = TypeX.ChangeType<IDatabase>(TypeX.CreateInstance(type));
                    // ��Ϊ�ղ����������ַ�������Ϊ�������ڲ���װ
                    if (!String.IsNullOrEmpty(ConnName)) _Db.ConnName = ConnName;
                    if (!String.IsNullOrEmpty(ConnStr)) _Db.ConnectionString = DecodeConnStr(ConnStr);
                }

                return _Db;
            }
        }

        /// <summary>���ݿ�Ự</summary>
        public IDbSession Session { get { return Db.CreateSession(); } }
        #endregion

        #region �����ַ����������
        /// <summary>�����ַ�������</summary>
        /// <remarks>����=>UTF8�ֽ�=>Base64</remarks>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public static String EncodeConnStr(String connstr)
        {
            if (String.IsNullOrEmpty(connstr)) return connstr;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(connstr));
        }

        /// <summary>�����ַ�������</summary>
        /// <remarks>Base64=>UTF8�ֽ�=>����</remarks>
        /// <param name="connstr"></param>
        /// <returns></returns>
        static String DecodeConnStr(String connstr)
        {
            if (String.IsNullOrEmpty(connstr)) return connstr;

            // ��������κη�Base64�����ַ���ֱ�ӷ���
            foreach (Char c in connstr)
            {
                if (!(c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z' ||
                    c >= '0' && c <= '9' ||
                    c == '+' || c == '/' || c == '=')) return connstr;
            }
            //if (!connstr.Any(c => !(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9' || c == '+' || c == '\\' || c == '='))) return connstr;

            Byte[] bts = null;
            try
            {
                // ����Base64���룬�������ʧ�ܣ����ƾ��������ַ�����ֱ�ӷ���
                bts = Convert.FromBase64String(connstr);
            }
            catch { return connstr; }

            return Encoding.UTF8.GetString(bts);
        }
        #endregion

        #region ���򹤳�
        private List<IDataTable> _Tables;
        /// <summary>ȡ�����б����ͼ�Ĺ�����Ϣ��Ϊ��������ܣ��õ���ֻ��׼ʵʱ��Ϣ�����ܻ���1�뵽3����ӳ�</summary>
        /// <remarks>��������ڻ��棬���ȡ�󷵻أ�����ʹ���̳߳��̻߳�ȡ�������̷߳��ػ���</remarks>
        /// <returns></returns>
        public List<IDataTable> Tables
        {
            get
            {
                // ��������ڻ��棬���ȡ�󷵻أ�����ʹ���̳߳��̻߳�ȡ�������̷߳��ػ���
                if (_Tables == null)
                    _Tables = GetTables();
                else
                    ThreadPool.QueueUserWorkItem(delegate(Object state) { _Tables = GetTables(); });

                return _Tables;
            }
        }

        private List<IDataTable> GetTables() { return Db.CreateMetaData().GetTables(); }

        /// <summary>����ģ��</summary>
        /// <returns></returns>
        public String Export()
        {
            List<IDataTable> list = Tables;

            if (list == null || list.Count < 1) return null;

            //XmlWriterX writer = new XmlWriterX();
            //writer.Settings.WriteType = false;
            //writer.Settings.UseObjRef = false;
            //writer.Settings.IgnoreDefault = true;
            //writer.Settings.MemberAsAttribute = true;
            //writer.RootName = "Tables";
            //writer.WriteObject(list);
            //return writer.ToString();

            return Export(list);
        }

        /// <summary>����ģ��</summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public static String Export(List<IDataTable> tables)
        {
            MemoryStream ms = new MemoryStream();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(ms, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Tables");
            foreach (IDataTable item in tables)
            {
                writer.WriteStartElement("Table");
                (item as IXmlSerializable).WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>����ģ��</summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static List<IDataTable> Import(String xml)
        {
            if (String.IsNullOrEmpty(xml)) return null;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(xml)), settings);
            while (reader.NodeType != XmlNodeType.Element) { if (!reader.Read())return null; }
            reader.ReadStartElement();

            List<IDataTable> list = new List<IDataTable>();
            while (reader.IsStartElement())
            {
                IDataTable table = CreateTable();
                list.Add(table);

                //reader.ReadStartElement();
                (table as IXmlSerializable).ReadXml(reader);
                //if (reader.NodeType == XmlNodeType.EndElement) reader.ReadEndElement();
            }
            return list;

            //XmlReaderX reader = new XmlReaderX(xml);
            ////XmlSerializer serial = new XmlSerializer(typeof(List<XTable>));
            ////List<XTable> ts = serial.Deserialize(reader.Stream) as List<XTable>;

            //reader.Settings.MemberAsAttribute = true;
            //List<XTable> list = reader.ReadObject(typeof(List<XTable>)) as List<XTable>;
            //if (list == null || list.Count < 1) return null;

            //List<IDataTable> dts = new List<IDataTable>();
            //// �����ֶ��е�Table����
            //foreach (XTable item in list)
            //{
            //    if (item.Columns == null || item.Columns.Count < 1) continue;

            //    List<IDataColumn> fs = new List<IDataColumn>();
            //    foreach (IDataColumn field in item.Columns)
            //    {
            //        //fs.Add(field.Clone(item));
            //        item.Columns.Add(field.Clone(item));
            //    }
            //    //item.Columns = fs.ToArray();

            //    dts.Add(item);
            //}

            //return dts;
        }
        #endregion

        #region ���򹤳�
        /// <summary>���򹤳�</summary>
        private void SetTables()
        {
            if (!NegativeEnable || NegativeExclude.Contains(ConnName)) return;

            // NegativeCheckOnly����Ϊtrueʱ��ʹ���첽��ʽ��飬��Ϊ�ϼ�����˼�ǲ���������ݿ�ܹ�
            if (!NegativeCheckOnly)
                CheckTables();
            else
                ThreadPoolX.QueueUserWorkItem(CheckTables);
        }

        internal List<String> HasCheckTables = new List<String>();

        /// <summary>������ݱ�ܹ������ܷ��򹤳����ÿ�������</summary>
        public void CheckTables()
        {
            WriteLog("��ʼ�������[{0}/{1}]�����ݿ�ܹ�����", ConnName, DbType);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                List<IDataTable> list = EntityFactory.GetTables(ConnName);
                if (list != null && list.Count > 0)
                {
                    // ȫ����Ϊ�ѳ�ʼ����
                    foreach (IDataTable item in list)
                    {
                        if (!HasCheckTables.Contains(item.Name)) HasCheckTables.Add(item.Name);
                    }

                    // ���˵����ų��ı���
                    if (NegativeExclude.Count > 0)
                    {
                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            if (NegativeExclude.Contains(list[i].Name)) list.RemoveAt(i);
                        }
                    }
                    // ���˵���ͼ
                    list.RemoveAll(dt => dt.IsView);
                    if (list != null && list.Count > 0)
                    {
                        WriteLog(ConnName + "������ܹ���ʵ�������" + list.Count);

                        Db.CreateMetaData().SetTables(list.ToArray());
                    }
                }
            }
            finally
            {
                sw.Stop();

                WriteLog("�������[{0}/{1}]�����ݿ�ܹ���ʱ{2}", ConnName, DbType, sw.Elapsed);
            }
        }
        #endregion

        #region �������ݲ���ʵ��
        private Assembly _Assembly;
        /// <summary>��������ģ�Ͷ�̬�����ĳ��򼯡������棬���Ҫ���£��������<see cref="EntityAssembly.Create(string, string, System.Collections.Generic.List&lt;XCode.DataAccessLayer.IDataTable&gt;)"/></summary>
        public Assembly Assembly
        {
            get
            {
                return _Assembly ?? (_Assembly = EntityAssembly.CreateWithCache(ConnName, Tables));
            }
            set { _Assembly = value; }
        }

        /// <summary>����ʵ������ӿ�</summary>
        /// <remarks>��Ϊֻ������ʵ�����������ֻ��Ҫһ��ʵ������</remarks>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IEntityOperate CreateOperate(String tableName)
        {
            //var asm = EntityAssembly.Create(ConnName, Tables);
            var asm = Assembly;
            if (asm == null) return null;
            //Type type = TypeX.GetType(asm, tableName);
            var type = AssemblyX.Create(asm).GetType(tableName);
            if (type == null) return null;

            return EntityFactory.CreateOperate(type);
        }
        #endregion
    }
}