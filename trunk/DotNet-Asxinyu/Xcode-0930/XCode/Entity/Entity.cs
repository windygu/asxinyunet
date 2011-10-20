using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Xml.Serialization;
using NewLife.IO;
using NewLife.Reflection;
using XCode.Common;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Exceptions;
using XCode.Model;
using System.Diagnostics;

namespace XCode
{
    /// <summary>
    /// ����ʵ������ࡣ��������ʵ���඼����̳и��ࡣ
    /// </summary>
    [Serializable]
    public partial class Entity<TEntity> : EntityBase where TEntity : Entity<TEntity>, new()
    {
        #region ���캯��
        /// <summary>��̬����</summary>
        static Entity()
        {
            DAL.WriteDebugLog("��ʼ��ʼ��ʵ����{0}", Meta.ThisType.Name);

            EntityFactory.Register(Meta.ThisType, new EntityOperate());

            // 1�����Գ�ʼ����ʵ�����͵Ĳ�������
            // 2��CreateOperate����ʵ����һ��TEntity���󣬴Ӷ�����TEntity�ľ�̬���캯����
            // ����ʵ��Ӧ���У�ֱ�ӵ���Entity�ľ�̬����ʱ��û������TEntity�ľ�̬���캯����
            TEntity entity = new TEntity();

            ////! ��ʯͷ 2011-03-14 ���¹��̸�Ϊ�첽����
            ////  ��ȷ�ϣ���ʵ���ྲ̬���캯����ʹ����EntityFactory.CreateOperate(Type)����ʱ�����ܳ���������
            ////  ��Ϊ���߶�������EntityFactory�е�op_cache����CreateOperate(Type)�õ�op_cache�󣬻���Ҫ�ȴ���ǰ��̬���캯��ִ����ɡ�
            ////  ��ȷ���������Ƿ��������֢
            //ThreadPool.QueueUserWorkItem(delegate
            //{
            //    EntityFactory.CreateOperate(Meta.ThisType, entity);
            //});

            DAL.WriteDebugLog("��ɳ�ʼ��ʵ����{0}", Meta.ThisType.Name);
        }

        /// <summary>
        /// ����ʵ�塣������д�ķ�����ʵ��ʵ������һЩ��ʼ��������
        /// </summary>
        /// <returns></returns>
        protected virtual TEntity CreateInstance()
        {
            //return new TEntity();
            // new TEntity�ᱻ����ΪActivator.CreateInstance<TEntity>()��������Activator.CreateInstance()��
            // Activator.CreateInstance()�л��湦�ܣ������͵��Ǹ�û��
            return Activator.CreateInstance(Meta.ThisType) as TEntity;
        }
        #endregion

        #region �������
        //private static IDataRowEntityAccessor dreAccessor = new DataRowEntityAccessor(Meta.ThisType);

        /// <summary>
        /// ���ؼ�¼����������ʱ���ؿռ��϶�����null��
        /// </summary>
        /// <param name="ds">��¼��</param>
        /// <returns>ʵ������</returns>
        public static EntityList<TEntity> LoadData(DataSet ds)
        {
            //if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return null;
            return LoadData(ds.Tables[0]);
        }

        /// <summary>
        /// �������ݱ�������ʱ���ؿռ��϶�����null��
        /// </summary>
        /// <param name="dt">���ݱ�</param>
        /// <returns>ʵ������</returns>
        public static EntityList<TEntity> LoadData(DataTable dt)
        {
            //if (dt == null || dt.Rows.Count < 1) return null;

            IEntityList list = dreAccessor.LoadData(dt);
            if (list is EntityList<TEntity>) return list as EntityList<TEntity>;

            return new EntityList<TEntity>(list);
        }

        /// <summary>
        /// ��һ�������ж���������ݡ������ع�������
        /// </summary>
        /// <param name="dr">������</param>
        public override void LoadData(DataRow dr)
        {
            if (dr == null) return;

            dreAccessor.LoadData(dr, this);
        }

        /// <summary>
        /// �������ݶ�д����������ʱ���ؿռ��϶�����null��
        /// </summary>
        /// <param name="dr">���ݶ�д��</param>
        /// <returns>ʵ������</returns>
        public static EntityList<TEntity> LoadData(IDataReader dr)
        {
            //if (dr == null) return null;

            IEntityList list = dreAccessor.LoadData(dr);
            if (list is EntityList<TEntity>) return list as EntityList<TEntity>;

            return new EntityList<TEntity>(list);
        }

        /// <summary>
        /// ��һ�������ж���������ݡ������ع�������
        /// </summary>
        /// <param name="dr">���ݶ�д��</param>
        public override void LoadDataReader(IDataReader dr)
        {
            if (dr == null) return;

            dreAccessor.LoadData(dr, this);
        }

        /// <summary>
        /// �����ݸ��Ƶ������ж����С�
        /// </summary>
        /// <param name="dr">������</param>
        public virtual DataRow ToData(ref DataRow dr)
        {
            if (dr == null) return null;

            return dreAccessor.ToData(this, ref dr);
        }

        private static IDataRowEntityAccessor dreAccessor { get { return XCodeService.Instance.CreateDataRowEntityAccessor(Meta.ThisType); } }
        #endregion

        #region ����
        /// <summary>
        /// �������ݣ�ͨ������OnInsertʵ�֣�����������������֤�����񱣻�֧�֣���������ʵ���¼�֧�֡�
        /// </summary>
        /// <returns></returns>
        public override Int32 Insert()
        {
            Valid(true);

            Meta.BeginTrans();
            try
            {
                Int32 rs = OnInsert();

                Meta.Commit();

                return rs;
            }
            catch { Meta.Rollback(); throw; }
        }

        /// <summary>
        /// �Ѹö���־û������ݿ⡣�÷����ṩԭ�������ݲ��������������أ���������Insert���档
        /// </summary>
        /// <returns></returns>
        protected virtual Int32 OnInsert()
        {
            String sql = SQL(this, DataObjectMethodType.Insert);
            if (String.IsNullOrEmpty(sql)) return 0;

            Int32 rs = 0;

            //����Ƿ��б�ʶ�У���ʶ����Ҫ���⴦��
            FieldItem field = Meta.Table.Identity;
            if (field != null && field.IsIdentity)
            {
                Int64 res = Meta.InsertAndGetIdentity(sql);
                if (res > 0) this[field.Name] = res;
                rs = res > 0 ? 1 : 0;
            }
            else
            {
                rs = Meta.Execute(sql);
            }

            //��������ݣ������������ε���Save����ظ��ύ
            if (Dirtys != null) Dirtys.Clear();

            return rs;
        }

        /// <summary>
        /// �������ݣ�ͨ������OnUpdateʵ�֣�����������������֤�����񱣻�֧�֣���������ʵ���¼�֧�֡�
        /// </summary>
        /// <returns></returns>
        public override Int32 Update()
        {
            Valid(false);

            Meta.BeginTrans();
            try
            {
                Int32 rs = OnUpdate();

                Meta.Commit();

                return rs;
            }
            catch { Meta.Rollback(); throw; }
        }

        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <returns></returns>
        protected virtual Int32 OnUpdate()
        {
            //û�������ݣ�����Ҫ����
            if (Dirtys == null || Dirtys.Count <= 0) return 0;

            String sql = SQL(this, DataObjectMethodType.Update);
            if (String.IsNullOrEmpty(sql)) return 0;

            Int32 rs = Meta.Execute(sql);

            //��������ݣ������ظ��ύ
            if (Dirtys != null) Dirtys.Clear();

            return rs;
        }

        /// <summary>
        /// ɾ�����ݣ�ͨ������OnDeleteʵ�֣�����������������֤�����񱣻�֧�֣���������ʵ���¼�֧�֡�
        /// </summary>
        /// <returns></returns>
        public override Int32 Delete()
        {
            Meta.BeginTrans();
            try
            {
                Int32 rs = OnDelete();

                Meta.Commit();

                return rs;
            }
            catch { Meta.Rollback(); throw; }
        }

        /// <summary>
        /// �����ݿ���ɾ���ö���
        /// </summary>
        /// <returns></returns>
        protected virtual Int32 OnDelete()
        {
            return Meta.Execute(SQL(this, DataObjectMethodType.Delete));
        }

        /// <summary>
        /// ���档��������������ݿ����Ƿ��Ѵ��ڸö����پ�������Insert��Update
        /// </summary>
        /// <returns></returns>
        public override Int32 Save()
        {
            //����ʹ�������ֶ��ж�
            FieldItem fi = Meta.Table.Identity;
            if (fi != null) return Convert.ToInt64(this[fi.Name]) > 0 ? Update() : Insert();

            fi = Meta.Unique;
            if (fi != null) return Helper.IsNullKey(this[fi.Name]) ? Insert() : Update();

            return FindCount(DefaultCondition(this), null, null, 0, 0) > 0 ? Update() : Insert();
        }

        /// <summary>
        /// ��֤���ݣ�ͨ���׳��쳣�ķ�ʽ��ʾ��֤ʧ�ܡ�������д�ߵ��û����ʵ�֣���Ϊ�������ܸ��������ֶε����Խ���������֤��
        /// </summary>
        /// <param name="isNew">�Ƿ�������</param>
        public virtual void Valid(Boolean isNew)
        {
            // �����������ж�Ψһ��
            IDataTable table = Meta.Table.DataTable;
            if (table.Indexes != null && table.Indexes.Count > 0)
            {
                // ������������
                foreach (IDataIndex item in table.Indexes)
                {
                    // ֻ����Ψһ����
                    if (!item.Unique) continue;

                    // ��ҪתΪ������Ҳ�����ֶ���
                    IDataColumn[] columns = table.GetColumns(item.Columns);
                    if (columns == null || columns.Length < 1) continue;

                    List<String> list = new List<string>();
                    foreach (IDataColumn dc in columns)
                    {
                        if (!list.Contains(dc.Alias)) list.Add(dc.Alias);
                    }

                    // ��¼�ֶ��Ƿ��и���
                    Boolean changed = false;
                    if (!isNew)
                    {
                        foreach (IDataColumn dc in columns)
                        {
                            // �����ֶ��ǲ�����0�ģ�������Ϊ����1��ʼ������Ϊ1����ˣ�Ϊ�յ������ֶΣ�Ҳ��Ҫ���
                            if (dc.Identity && Helper.IsNullKey(this[dc.Alias]))
                            {
                                changed = false;
                                break;
                            }

                            if (Dirtys[dc.Alias]) changed = true;
                        }
                    }

                    // ���ڼ��
                    if (isNew || changed) CheckExist(list.ToArray());
                }
            }
        }

        /// <summary>
        /// ����ָ������������Ƿ��Ѵ��ڣ��������ڣ��׳�ArgumentOutOfRangeException�쳣
        /// </summary>
        /// <param name="names"></param>
        public virtual void CheckExist(params String[] names)
        {
            if (Exist(names))
            {
                StringBuilder sb = new StringBuilder();
                String name = null;
                for (int i = 0; i < names.Length; i++)
                {
                    if (sb.Length > 0) sb.Append("��");

                    FieldItem field = Meta.Table.FindByName(names[i]);
                    if (field != null) name = field.Description;
                    if (String.IsNullOrEmpty(name)) name = names[i];

                    sb.AppendFormat("{0}={1}", name, this[names[i]]);
                }

                name = Meta.Table.Description;
                if (String.IsNullOrEmpty(name)) name = Meta.ThisType.Name;
                sb.AppendFormat(" ��{0}�Ѵ��ڣ�", name);

                throw new ArgumentOutOfRangeException(String.Join(",", names), this[names[0]], sb.ToString());
            }
        }

        /// <summary>
        /// ����ָ����������ݣ����������Ƿ��Ѵ���
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public virtual Boolean Exist(params String[] names)
        {
            // ����ָ�����������з��ϵ����ݣ�Ȼ��ȶԡ�
            // ��Ȼ��Ҳ����ͨ��ָ������������ϣ��ҵ�ӵ��ָ���������ǲ��ǵ�ǰ���������ݣ�ֻ���¼����
            Object[] values = new Object[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                values[i] = this[names[i]];
            }

            FieldItem field = Meta.Unique;
            // ����ǿ������������ֱ���жϼ�¼���ķ�ʽ���Լӿ��ٶ�
            if (Helper.IsNullKey(this[field.Name])) return FindCount(names, values) > 0;

            EntityList<TEntity> list = FindAll(names, values);
            if (list == null) return false;
            if (list.Count > 1) return true;

            return !Object.Equals(this[field.Name], list[0][field.Name]);
        }

        //public event EventHandler<CancelEventArgs> Inserting;
        //public event EventHandler<EventArgs<Int32>> Inserted;
        #endregion

        #region ���ҵ���ʵ��
        /// <summary>
        /// ���������Լ���Ӧ��ֵ�����ҵ���ʵ��
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        [WebMethod(Description = "���������Լ���Ӧ��ֵ�����ҵ���ʵ��")]
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity Find(String name, Object value)
        {
            return Find(new String[] { name }, new Object[] { value });
        }

        /// <summary>
        /// ���������б��Լ���Ӧ��ֵ�б����ҵ���ʵ��
        /// </summary>
        /// <param name="names">�������Ƽ���</param>
        /// <param name="values">����ֵ����</param>
        /// <returns></returns>
        public static TEntity Find(String[] names, Object[] values)
        {
            // �ж�����������
            if (names.Length == 1)
            {
                FieldItem field = Meta.Table.FindByName(names[0]);
                if (field != null && (field.IsIdentity || field.PrimaryKey))
                {
                    // Ψһ��Ϊ�����Ҳ���С�ڵ���0ʱ�����ؿ�
                    if (Helper.IsNullKey(values[0])) return null;

                    // ��������������ѯ����¼���϶���Ψһ�ģ�����Ҫָ����¼��������
                    //SelectBuilder builder = new SelectBuilder();
                    //builder.Table = Meta.FormatName(Meta.TableName);
                    //builder.Where = MakeCondition(field, values[0], "=");
                    //IList<TEntity> list = FindAll(builder.ToString());
                    //if (list == null || list.Count < 1)
                    //    return null;
                    //else
                    //    return list[0];

                    return FindUnique(MakeCondition(field, values[0], "="));
                }
            }

            // �ж�Ψһ������Ψһ����Ҳ����Ҫ��ҳ
            IDataIndex di = Meta.Table.DataTable.GetIndex(names);
            if (di != null && di.Unique) return FindUnique(MakeCondition(names, values, "And"));

            return Find(MakeCondition(names, values, "And"));
        }

        /// <summary>
        /// ������������Ψһ�ĵ���ʵ�壬��Ϊ��Ψһ�ģ����Բ���Ҫ��ҳ������
        /// �����ȷ���Ƿ�Ψһ��һ����Ҫ���ø÷���������᷵�ش��������ݡ�
        /// </summary>
        /// <param name="whereClause">��ѯ����</param>
        /// <returns></returns>
        static TEntity FindUnique(String whereClause)
        {
            SelectBuilder builder = new SelectBuilder();
            builder.Table = Meta.FormatName(Meta.TableName);
            // ���ǣ�ĳЩ��Ŀ�п�����where��ʹ����GroupBy���ڷ�ҳʱ���ܱ���
            builder.Where = whereClause;
            IList<TEntity> list = LoadData(Meta.Query(builder.ToString()));
            if (list == null || list.Count < 1) return null;

            if (list.Count > 1 && DAL.Debug)
            {
                DAL.WriteDebugLog("����FindUnique(\"{0}\")������ֻ�з���Ψһ��¼�Ĳ�ѯ������������ã�", whereClause);
                NewLife.Log.XTrace.DebugStack(5);
            }
            return list[0];
        }

        /// <summary>
        /// �����������ҵ���ʵ��
        /// </summary>
        /// <param name="whereClause">��ѯ����</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity Find(String whereClause)
        {
            IList<TEntity> list = FindAll(whereClause, null, null, 0, 1);
            if (list == null || list.Count < 1)
                return null;
            else
                return list[0];
        }

        /// <summary>
        /// �����������ҵ���ʵ��
        /// </summary>
        /// <param name="key">Ψһ������ֵ</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByKey(Object key)
        {
            FieldItem field = Meta.Unique;
            if (field == null) throw new ArgumentNullException("Meta.Unique", "FindByKey����Ҫ��ñ���Ψһ������");

            // Ψһ��Ϊ�����Ҳ���С�ڵ���0ʱ�����ؿ�
            if (Helper.IsNullKey(key)) return null;

            return Find(field.Name, key);
        }

        /// <summary>
        /// ����������ѯһ��ʵ��������ڱ��༭
        /// </summary>
        /// <param name="key">Ψһ������ֵ</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByKeyForEdit(Object key)
        {
            FieldItem field = Meta.Unique;
            if (field == null) throw new ArgumentNullException("Meta.Unique", "FindByKeyForEdit����Ҫ��ñ���Ψһ������");

            // ����Ϊ��ʱ��������ʵ��
            if (key == null)
            {
                //IEntityOperate factory = EntityFactory.CreateOperate(Meta.ThisType);
                return Meta.Factory.Create() as TEntity;
            }

            Type type = field.Type;

            // Ψһ��Ϊ�����Ҳ���С�ڵ���0ʱ��������ʵ��
            if (Helper.IsNullKey(key))
            {
                if (Helper.IsIntType(type) && !field.IsIdentity && DAL.Debug) DAL.WriteLog("{0}��{1}�ֶ����������������Ƿ�����������������", Meta.TableName, field.ColumnName);

                return Meta.Factory.Create() as TEntity;
            }

            // ���⣬һ�ɷ��� ����ֵ����ʹ�����ǿա������������Ҳ������ݵ�����¸������ؿգ���Ϊ�������Ҳ������ݶ��ѣ���������ʵ���ᵼ��ǰ����Ϊ��������������
            TEntity entity = Find(field.Name, key);

            // �ж�ʵ��
            if (entity == null)
            {
                String msg = null;
                if (Helper.IsNullKey(key))
                    msg = String.Format("���������޷�ȡ�ñ��Ϊ{0}��{1}������δ��������������", key, Meta.Table.Description);
                else
                    msg = String.Format("���������޷�ȡ�ñ��Ϊ{0}��{1}��", key, Meta.Table.Description);

                throw new XCodeException(msg);
            }

            return entity;
        }
        #endregion

        #region ��̬��ѯ
        /// <summary>
        /// ��ȡ����ʵ����󡣻�ȡ��������ʱ��ǳ���������
        /// </summary>
        /// <returns>ʵ������</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAll()
        {
            return FindAll(SQL(null, DataObjectMethodType.Fill));
        }

        /// <summary>
        /// ��ѯ������ʵ����󼯺ϡ�
        /// �����Լ������ֶ�������ʹ�������Լ��ֶζ�Ӧ����������������ת��Ϊ����������
        /// </summary>
        /// <param name="whereClause">����������Where</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="selects">��ѯ��</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>ʵ�弯</returns>
        [WebMethod(Description = "��ѯ������ʵ����󼯺�")]
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAll(String whereClause, String orderClause, String selects, Int32 startRowIndex, Int32 maximumRows)
        {
            #region �������ݲ�ѯ�Ż�
            // ��������βҳ��ѯ�Ż�
            // �ں������ݷ�ҳ�У�ȡԽ�Ǻ���ҳ������Խ�������Կ��ǵ���ķ�ʽ
            // ֻ���ڰ������ݣ��ҿ�ʼ�д�����ʮ��ʱ��ʹ��
            //Int32 count = Meta.Count;
            //if (startRowIndex > 500000 && count > 1000000)

            // �����Ż���������ÿ�ζ�����Meta.Count�������γ�һ�β�ѯ����Ȼ��β�ѯʱ����Ĳ���
            // ���Ǿ��������ѯ��������Ҫ�������Ƶĺ��������Ż�����Ȼ�����startRowIndex���ᵲס99%���ϵ��˷�
            Int64 count = 0;
            if (startRowIndex > 500000 && (count = Meta.LongCount) > 1000000)
            {
                // ���㱾�β�ѯ�Ľ������
                if (!String.IsNullOrEmpty(whereClause)) count = FindCount(whereClause, orderClause, selects, startRowIndex, maximumRows);
                // �α����м�ƫ��
                if (startRowIndex * 2 > count)
                {
                    String order = orderClause;
                    Boolean bk = false; // �Ƿ�����

                    #region ������
                    // Ĭ���������ֶεĽ���
                    FieldItem fi = Meta.Unique;
                    if (String.IsNullOrEmpty(order) && fi != null && fi.IsIdentity) order = fi.Name + " Desc";

                    if (!String.IsNullOrEmpty(order))
                    {
                        String[] ss = order.Split(',');
                        StringBuilder sb = new StringBuilder();
                        foreach (String item in ss)
                        {
                            String fn = item;
                            String od = "asc";

                            Int32 p = fn.LastIndexOf(" ");
                            if (p > 0)
                            {
                                od = item.Substring(p).Trim().ToLower();
                                fn = item.Substring(0, p).Trim();
                            }

                            switch (od)
                            {
                                case "asc":
                                    od = "desc";
                                    break;
                                case "desc":
                                    //od = "asc";
                                    od = null;
                                    break;
                                default:
                                    bk = true;
                                    break;
                            }
                            if (bk) break;

                            if (sb.Length > 0) sb.Append(", ");
                            sb.AppendFormat("{0} {1}", fn, od);
                        }

                        order = sb.ToString();
                    }
                    #endregion

                    // û�������ʵ�ڲ��ʺ����ְ취����Ϊû�취����
                    if (!String.IsNullOrEmpty(order))
                    {
                        // ������������Ϊʵ������������
                        Int32 max = (Int32)Math.Min(maximumRows, count - startRowIndex);
                        if (max <= 0) return null;
                        Int32 start = (Int32)(count - (startRowIndex + maximumRows));

                        String sql2 = PageSplitSQL(whereClause, order, selects, start, max);
                        EntityList<TEntity> list = LoadData(Meta.Query(sql2));
                        if (list == null || list.Count < 1) return list;
                        // ��Ϊ����ȡ�õ������ǵ������ģ�����������Ҫ�ٵ�һ��
                        list.Reverse();
                        return list;
                    }
                }
            }
            #endregion

            String sql = PageSplitSQL(whereClause, orderClause, selects, startRowIndex, maximumRows);
            return LoadData(Meta.Query(sql));
        }

        /// <summary>
        /// ���������б��Լ���Ӧ��ֵ�б���ȡ����ʵ�����
        /// </summary>
        /// <param name="names">�����б�</param>
        /// <param name="values">ֵ�б�</param>
        /// <returns>ʵ������</returns>
        public static EntityList<TEntity> FindAll(String[] names, Object[] values)
        {
            return FindAll(MakeCondition(names, values, "And"), null, null, 0, 0);
        }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ����ȡ����ʵ�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <returns>ʵ������</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAll(String name, Object value)
        {
            return FindAll(new String[] { name }, new Object[] { value });
        }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ����ȡ����ʵ�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>ʵ������</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAll(String name, Object value, Int32 startRowIndex, Int32 maximumRows)
        {
            return FindAllByName(name, value, null, startRowIndex, maximumRows);
        }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ����ȡ����ʵ�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>ʵ������</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<TEntity> FindAllByName(String name, Object value, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        {
            if (String.IsNullOrEmpty(name)) return FindAll(null, orderClause, null, startRowIndex, maximumRows);

            FieldItem field = Meta.Table.FindByName(name);
            if (field != null && (field.IsIdentity || field.PrimaryKey))
            {
                // Ψһ��Ϊ�����Ҳ���С�ڵ���0ʱ�����ؿ�
                if (Helper.IsNullKey(value)) return new EntityList<TEntity>();

                // ��������������ѯ����¼���϶���Ψһ�ģ�����Ҫָ����¼��������
                //return FindAll(MakeCondition(field, value, "="), null, null, 0, 0);
                SelectBuilder builder = new SelectBuilder();
                builder.Table = Meta.FormatName(Meta.TableName);
                builder.Where = MakeCondition(field, value, "=");
                return FindAll(builder.ToString());
            }

            return FindAll(MakeCondition(new String[] { name }, new Object[] { value }, "And"), orderClause, null, startRowIndex, maximumRows);
        }

        /// <summary>
        /// ��ѯSQL������ʵ��������顣
        /// Select������ֱ��ʹ�ò���ָ���Ĳ�ѯ�����в�ѯ���������κ�ת����
        /// </summary>
        /// <param name="sql">��ѯ���</param>
        /// <returns>ʵ������</returns>
        public static EntityList<TEntity> FindAll(String sql)
        {
            return LoadData(Meta.Query(sql));
        }
        #endregion

        #region �߼���ѯ
        /// <summary>
        /// ��ѯ���������ļ�¼������ҳ������
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>ʵ�弯</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<TEntity> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        {
            return FindAll(SearchWhereByKeys(key, null), orderClause, null, startRowIndex, maximumRows);
        }

        /// <summary>
        /// ��ѯ���������ļ�¼��������ҳ��������Ч������������ΪObjectDataSourceҪ������Searchͳһ
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>��¼��</returns>
        public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        {
            return FindCount(SearchWhereByKeys(key, null), null, null, 0, 0);
        }

        /// <summary>
        /// �����ؼ��ֲ�ѯ����
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="keys"></param>
        public static void SearchWhereByKeys(StringBuilder sb, String keys)
        {
            SearchWhereByKeys(sb, keys, null);
        }

        /// <summary>
        /// �����ؼ��ֲ�ѯ����
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="keys"></param>
        /// <param name="func"></param>
        public static void SearchWhereByKeys(StringBuilder sb, String keys, Func<String, String> func)
        {
            if (String.IsNullOrEmpty(keys)) return;

            String str = SearchWhereByKeys(keys, func);
            if (String.IsNullOrEmpty(str)) return;

            if (sb.Length > 0) sb.Append(" And ");
            if (str.Contains("Or") || str.ToLower().Contains("or"))
                sb.AppendFormat("({0})", str);
            else
                sb.Append(str);
        }

        /// <summary>
        /// �����ؼ��ֲ�ѯ����
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static String SearchWhereByKeys(String keys, Func<String, String> func)
        {
            if (String.IsNullOrEmpty(keys)) return null;

            if (func == null) func = SearchWhereByKey;

            String[] ks = keys.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ks.Length; i++)
            {
                if (sb.Length > 0) sb.Append(" And ");

                String str = func(ks[i]);
                if (String.IsNullOrEmpty(str)) continue;

                //sb.AppendFormat("({0})", str);
                if (str.Contains("Or") || str.ToLower().Contains("or"))
                    sb.AppendFormat("({0})", str);
                else
                    sb.Append(str);
            }

            return sb.Length <= 0 ? null : sb.ToString();
        }

        /// <summary>
        /// �����ؼ��ֲ�ѯ����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String SearchWhereByKey(String key)
        {
            StringBuilder sb = new StringBuilder();
            foreach (FieldItem item in Meta.Fields)
            {
                if (item.Type != typeof(String)) continue;

                if (sb.Length > 0) sb.Append(" Or ");
                sb.AppendFormat("{0} like '%{1}%'", Meta.FormatName(item.Name), key);
            }

            return sb.Length <= 0 ? null : sb.ToString();
        }
        #endregion

        #region �����ѯ
        /// <summary>
        /// ���������Լ���Ӧ��ֵ���ڻ����в��ҵ���ʵ��
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindWithCache(String name, Object value) { return Meta.Cache.Entities.Find(name, value); }

        /// <summary>
        /// �������л���
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllWithCache() { return Meta.Cache.Entities; }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ���ڻ����л�ȡ����ʵ�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <returns>ʵ������</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllWithCache(String name, Object value) { return Meta.Cache.Entities.FindAll(name, value); }
        #endregion

        #region ȡ�ܼ�¼��
        /// <summary>
        /// �����ܼ�¼��
        /// </summary>
        /// <returns></returns>
        public static Int32 FindCount() { return FindCount(null, null, null, 0, 0); }

        /// <summary>
        /// �����ܼ�¼��
        /// </summary>
        /// <param name="whereClause">����������Where</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="selects">��ѯ��</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>������</returns>
        [WebMethod(Description = "��ѯ�������ܼ�¼��")]
        public static Int32 FindCount(String whereClause, String orderClause, String selects, Int32 startRowIndex, Int32 maximumRows)
        {
            SelectBuilder sb = new SelectBuilder(Meta.DbType);
            sb.Table = Meta.FormatName(Meta.TableName);
            sb.Where = whereClause;

            return Meta.QueryCount(sb);
        }

        /// <summary>
        /// ���������б��Լ���Ӧ��ֵ�б������ܼ�¼��
        /// </summary>
        /// <param name="names">�����б�</param>
        /// <param name="values">ֵ�б�</param>
        /// <returns>������</returns>
        public static Int32 FindCount(String[] names, Object[] values)
        {
            return FindCount(MakeCondition(names, values, "And"), null, null, 0, 0);
        }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ�������ܼ�¼��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <returns>������</returns>
        public static Int32 FindCount(String name, Object value) { return FindCount(name, value, 0, 0); }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ�������ܼ�¼��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>������</returns>
        public static Int32 FindCount(String name, Object value, Int32 startRowIndex, Int32 maximumRows)
        {
            return FindCountByName(name, value, null, startRowIndex, maximumRows);
        }

        /// <summary>
        /// ���������Լ���Ӧ��ֵ�������ܼ�¼��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>������</returns>
        public static Int32 FindCountByName(String name, Object value, String orderClause, int startRowIndex, int maximumRows)
        {
            if (String.IsNullOrEmpty(name))
                return FindCount(null, null, null, 0, 0);
            else
                return FindCount(MakeCondition(name, value, "="), null, null, 0, 0);
        }
        #endregion

        #region ��̬����
        /// <summary>
        /// ��һ��ʵ�����־û������ݿ�
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>������Ӱ�������</returns>
        [DisplayName("����")]
        [WebMethod(Description = "����")]
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(TEntity obj)
        {
            return obj.Insert();
        }

        /// <summary>
        /// ��һ��ʵ�����־û������ݿ�
        /// </summary>
        /// <param name="names">���������б�</param>
        /// <param name="values">����ֵ�б�</param>
        /// <returns>������Ӱ�������</returns>
        public static Int32 Insert(String[] names, Object[] values)
        {
            if (names == null) throw new ArgumentNullException("names", "�����б��ֵ�б���Ϊ��");
            if (values == null) throw new ArgumentNullException("values", "�����б��ֵ�б���Ϊ��");

            if (names.Length != values.Length) throw new ArgumentException("�����б�����ֵ�б�һһ��Ӧ");
            //FieldItem[] fis = Meta.Fields;
            Dictionary<String, FieldItem> fs = new Dictionary<String, FieldItem>(StringComparer.OrdinalIgnoreCase);
            foreach (FieldItem fi in Meta.Fields)
                fs.Add(fi.Name, fi);
            StringBuilder sbn = new StringBuilder();
            StringBuilder sbv = new StringBuilder();
            for (Int32 i = 0; i < names.Length; i++)
            {
                if (!fs.ContainsKey(names[i])) throw new ArgumentException("��[" + Meta.ThisType.FullName + "]�в�����[" + names[i] + "]����");
                // ͬʱ����SQL��䡣names�������б�����ת���ɶ�Ӧ���ֶ��б�
                if (i > 0)
                {
                    sbn.Append(", ");
                    sbv.Append(", ");
                }
                sbn.Append(Meta.FormatName(fs[names[i]].Name));
                //sbv.Append(SqlDataFormat(values[i], fs[names[i]]));
                sbv.Append(Meta.FormatValue(names[i], values[i]));
            }
            return Meta.Execute(String.Format("Insert Into {2}({0}) values({1})", sbn.ToString(), sbv.ToString(), Meta.FormatName(Meta.TableName)));
        }

        /// <summary>
        /// ��һ��ʵ�������µ����ݿ�
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>������Ӱ�������</returns>
        [DisplayName("����")]
        [WebMethod(Description = "����")]
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(TEntity obj)
        {
            return obj.Update();
        }

        /// <summary>
        /// ����һ��ʵ������
        /// </summary>
        /// <param name="setClause">Ҫ���µ��������</param>
        /// <param name="whereClause">ָ��Ҫ���µ�ʵ��</param>
        /// <returns></returns>
        public static Int32 Update(String setClause, String whereClause)
        {
            if (String.IsNullOrEmpty(setClause) || !setClause.Contains("=")) throw new ArgumentException("�Ƿ�����");
            String sql = String.Format("Update {0} Set {1}", Meta.FormatName(Meta.TableName), setClause);
            if (!String.IsNullOrEmpty(whereClause)) sql += " Where " + whereClause;
            return Meta.Execute(sql);
        }

        /// <summary>
        /// ����һ��ʵ������
        /// </summary>
        /// <param name="setNames">���������б�</param>
        /// <param name="setValues">����ֵ�б�</param>
        /// <param name="whereNames">���������б�</param>
        /// <param name="whereValues">����ֵ�б�</param>
        /// <returns>������Ӱ�������</returns>
        public static Int32 Update(String[] setNames, Object[] setValues, String[] whereNames, Object[] whereValues)
        {
            String sc = MakeCondition(setNames, setValues, ", ");
            String wc = MakeCondition(whereNames, whereValues, " And ");
            return Update(sc, wc);
        }

        /// <summary>
        /// �����ݿ���ɾ��ָ��ʵ�����
        /// ʵ����Ӧ��ʵ�ָ÷�������һ����������Ψһ����������Ϊ����
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>������Ӱ����������������жϱ�ɾ���˶����У��Ӷ�֪�������Ƿ�ɹ�</returns>
        [WebMethod(Description = "ɾ��")]
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static Int32 Delete(TEntity obj)
        {
            return obj.Delete();
        }

        /// <summary>
        /// �����ݿ���ɾ��ָ��������ʵ�����
        /// </summary>
        /// <param name="whereClause">��������</param>
        /// <returns></returns>
        public static Int32 Delete(String whereClause)
        {
            String sql = String.Format("Delete From {0}", Meta.FormatName(Meta.TableName));
            if (!String.IsNullOrEmpty(whereClause)) sql += " Where " + whereClause;
            return Meta.Execute(sql);
        }

        /// <summary>
        /// �����ݿ���ɾ��ָ�������б��ֵ�б����޶���ʵ�����
        /// </summary>
        /// <param name="names">�����б�</param>
        /// <param name="values">ֵ�б�</param>
        /// <returns></returns>
        public static Int32 Delete(String[] names, Object[] values)
        {
            return Delete(MakeCondition(names, values, "And"));
        }

        /// <summary>
        /// ��һ��ʵ�������µ����ݿ�
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>������Ӱ�������</returns>
        [WebMethod(Description = "����")]
        //[DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Save(TEntity obj)
        {
            return obj.Save();
        }
        #endregion

        #region ����SQL���
        /// <summary>
        /// ��SQLģ���ʽ��ΪSQL���
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <param name="methodType"></param>
        /// <returns>SQL�ַ���</returns>
        public static String SQL(Entity<TEntity> obj, DataObjectMethodType methodType)
        {
            String sql;
            StringBuilder sbNames;
            StringBuilder sbValues;
            Boolean isFirst = true;
            switch (methodType)
            {
                case DataObjectMethodType.Fill:
                    //return String.Format("Select {0} From {1}", Meta.Selects, Meta.TableName);
                    return String.Format("Select * From {0}", Meta.FormatName(Meta.TableName));
                case DataObjectMethodType.Select:
                    sql = DefaultCondition(obj);
                    // û�б�ʶ�к�����������ȡ�������ݵ����
                    if (String.IsNullOrEmpty(sql)) throw new Exception("ʵ����ȱ��������");
                    return String.Format("Select * From {0} Where {1}", Meta.FormatName(Meta.TableName), sql);
                case DataObjectMethodType.Insert:
                    sbNames = new StringBuilder();
                    sbValues = new StringBuilder();
                    // ֻ����û�в������
                    foreach (FieldItem fi in Meta.Fields)
                    {
                        // ��ʶ�в���Ҫ���룬������Ͷ���Ҫ
                        String idv = null;
                        if (fi.IsIdentity)
                        {
                            idv = Meta.DBO.Db.FormatIdentity(fi.Field, obj[fi.Name]);
                            //if (String.IsNullOrEmpty(idv)) continue;
                            // ������String.Empty��Ϊ�����
                            if (idv == null) continue;
                        }

                        // ��Ĭ��ֵ������û������ֵʱ��������������
                        if (!String.IsNullOrEmpty(fi.DefaultValue) && !obj.Dirtys[fi.Name]) continue;

                        if (!isFirst) sbNames.Append(", "); // �Ӷ���
                        sbNames.Append(Meta.FormatName(fi.ColumnName));
                        if (!isFirst)
                            sbValues.Append(", "); // �Ӷ���
                        else
                            isFirst = false;

                        //// �ɿ����Ͳ����
                        //if (!obj.Dirtys[fi.Name] && fi.DataObjectField.IsNullable)
                        //    sbValues.Append("null");
                        //else
                        //sbValues.Append(SqlDataFormat(obj[fi.Name], fi)); // ����

                        if (!fi.IsIdentity)
                            sbValues.Append(Meta.FormatValue(fi, obj[fi.Name])); // ����
                        else
                            sbValues.Append(idv);
                    }
                    return String.Format("Insert Into {0}({1}) Values({2})", Meta.FormatName(Meta.TableName), sbNames.ToString(), sbValues.ToString());
                case DataObjectMethodType.Update:
                    sbNames = new StringBuilder();
                    // ֻ����û�и��²���
                    foreach (FieldItem fi in Meta.Fields)
                    {
                        if (fi.IsIdentity) continue;

                        //�������ж�
                        if (!obj.Dirtys[fi.Name]) continue;

                        if (!isFirst)
                            sbNames.Append(", "); // �Ӷ���
                        else
                            isFirst = false;
                        sbNames.Append(Meta.FormatName(fi.ColumnName));
                        sbNames.Append("=");
                        //sbNames.Append(SqlDataFormat(obj[fi.Name], fi)); // ����
                        sbNames.Append(Meta.FormatValue(fi, obj[fi.Name])); // ����
                    }

                    if (sbNames.Length <= 0) return null;

                    sql = DefaultCondition(obj);
                    if (String.IsNullOrEmpty(sql)) return null;
                    return String.Format("Update {0} Set {1} Where {2}", Meta.FormatName(Meta.TableName), sbNames.ToString(), sql);
                case DataObjectMethodType.Delete:
                    // ��ʶ����Ϊɾ���ؼ���
                    sql = DefaultCondition(obj);
                    if (String.IsNullOrEmpty(sql))
                        return null;
                    return String.Format("Delete From {0} Where {1}", Meta.FormatName(Meta.TableName), sql);
            }
            return null;
        }

        /// <summary>
        /// ���������б��ֵ�б������ѯ������
        /// ���繹����������Ʋ�ѯ������
        /// </summary>
        /// <param name="names">�����б�</param>
        /// <param name="values">ֵ�б�</param>
        /// <param name="action">���Ϸ�ʽ</param>
        /// <returns>�����Ӵ�</returns>
        [WebMethod(Description = "�����ѯ����")]
        public static String MakeCondition(String[] names, Object[] values, String action)
        {
            if (names == null) throw new ArgumentNullException("names", "�����б��ֵ�б���Ϊ��");
            if (values == null) throw new ArgumentNullException("values", "�����б��ֵ�б���Ϊ��");
            if (names.Length != values.Length) throw new ArgumentException("�����б�����ֵ�б�һһ��Ӧ");

            StringBuilder sb = new StringBuilder();
            for (Int32 i = 0; i < names.Length; i++)
            {
                FieldItem fi = Meta.Table.FindByName(names[i]);
                if (fi == null) throw new ArgumentException("��[" + Meta.ThisType.FullName + "]�в�����[" + names[i] + "]����");

                // ͬʱ����SQL��䡣names�������б�����ת���ɶ�Ӧ���ֶ��б�
                if (i > 0) sb.AppendFormat(" {0} ", action.Trim());
                //sb.AppendFormat("{0}={1}", Meta.FormatName(fi.ColumnName), Meta.FormatValue(fi, values[i]));
                sb.Append(MakeCondition(fi, values[i], "="));
            }
            return sb.ToString();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="action">����С�ڵȷ���</param>
        /// <returns></returns>
        public static String MakeCondition(String name, Object value, String action)
        {
            FieldItem field = Meta.Table.FindByName(name);
            if (field == null) return String.Format("{0}{1}{2}", Meta.FormatName(name), action, Meta.FormatValue(name, value));

            return MakeCondition(field, value, action);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="field">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="action">����С�ڵȷ���</param>
        /// <returns></returns>
        public static String MakeCondition(FieldItem field, Object value, String action)
        {
            if (!String.IsNullOrEmpty(action) && action.Contains("{0}"))
            {
                if (action.Contains("%"))
                    return Meta.FormatName(field.ColumnName) + " Like " + Meta.FormatValue(field, String.Format(action, value));
                else
                    return Meta.FormatName(field.ColumnName) + String.Format(action, Meta.FormatValue(field, value));
            }
            else
                return String.Format("{0}{1}{2}", Meta.FormatName(field.ColumnName), action, Meta.FormatValue(field, value));
        }

        /// <summary>
        /// Ĭ��������
        /// ���б�ʶ�У���ʹ��һ����ʶ����Ϊ������
        /// ������������ʹ��ȫ��������Ϊ������
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>����</returns>
        protected static String DefaultCondition(Entity<TEntity> obj)
        {
            // ��ʶ����Ϊ��ѯ�ؼ���
            FieldItem fi = Meta.Table.Identity;
            if (fi != null) return MakeCondition(fi, obj[fi.Name], "=");

            // ������Ϊ��ѯ�ؼ���
            FieldItem[] ps = Meta.Table.PrimaryKeys;
            // û�б�ʶ�к�����������ȡ�������ݵ����
            if (ps == null || ps.Length < 1) return null;

            StringBuilder sb = new StringBuilder();
            foreach (FieldItem item in ps)
            {
                if (sb.Length > 0) sb.Append(" And ");
                sb.Append(Meta.FormatName(item.ColumnName));
                sb.Append("=");
                sb.Append(Meta.FormatValue(item, obj[item.Name]));
            }
            return sb.ToString();
        }

        /// <summary>
        /// ȡ��ָ��ʵ�����͵ķ�ҳSQL
        /// </summary>
        /// <param name="whereClause">����������Where</param>
        /// <param name="orderClause">���򣬲���Order By</param>
        /// <param name="selects">��ѯ��</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>��ҳSQL</returns>
        protected static String PageSplitSQL(String whereClause, String orderClause, String selects, Int32 startRowIndex, Int32 maximumRows)
        {
            SelectBuilder builder = new SelectBuilder();
            builder.Column = selects;
            builder.Table = Meta.FormatName(Meta.TableName);
            builder.OrderBy = orderClause;
            // ���ǣ�ĳЩ��Ŀ�п�����where��ʹ����GroupBy���ڷ�ҳʱ���ܱ���
            builder.Where = whereClause;

            // �������м�¼
            if (startRowIndex <= 0 && maximumRows <= 0) return builder.ToString();

            return PageSplitSQL(builder, startRowIndex, maximumRows);
        }

        /// <summary>
        /// ȡ��ָ��ʵ�����͵ķ�ҳSQL
        /// </summary>
        /// <param name="builder">��ѯ������</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <returns>��ҳSQL</returns>
        protected static String PageSplitSQL(SelectBuilder builder, Int32 startRowIndex, Int32 maximumRows)
        {
            FieldItem fi = Meta.Unique;
            String keyColumn = null;
            if (fi != null)
            {
                keyColumn = fi.ColumnName;
                // ����Desc��ǣ���ʹ��MaxMin��ҳ�㷨����ʶ�У���һ������Ϊ��������
                if (fi.IsIdentity && Helper.IsIntType(fi.Type))
                {
                    keyColumn += " Desc";

                    // Ĭ�ϻ�ȡ����ʱ��������Ҫָ����װ�����ֶν��򣬷���ʹ��ϰ��
                    // ��GroupByҲ���ܼ�����
                    if (String.IsNullOrEmpty(builder.OrderBy) && String.IsNullOrEmpty(builder.GroupBy)) builder.OrderBy = keyColumn;
                }
                //if (fi.IsIdentity || IsInt(fi.Type)) keyColumn += " Unknown";

                //if (String.IsNullOrEmpty(builder.OrderBy)) builder.OrderBy = keyColumn;
            }
            return Meta.PageSplit(builder, startRowIndex, maximumRows, keyColumn);
        }
        #endregion

        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ȡ/���� �ֶ�ֵ��
        /// һ������������ʵ�֡�
        /// ����ʵ�������д���������Ա��ⷢ�������������ġ�
        /// �����Ѿ�ʵ����ͨ�õĿ��ٷ��ʣ�����������Ȼ��д�������ӿ��ƣ�
        /// �����ֶ�����������ǰ�����_������Ҫ����ʵ���ֶβ������������ʣ�����һ�ɰ����Դ���
        /// </summary>
        /// <param name="name">�ֶ���</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                //ƥ���ֶ�
                if (Meta.FieldNames.Contains(name))
                {
                    FieldInfoX field = FieldInfoX.Create(this.GetType(), "_" + name);
                    if (field != null) return field.GetValue(this);
                }

                //����ƥ������
                PropertyInfoX property = PropertyInfoX.Create(this.GetType(), name);
                if (property != null) return property.GetValue(this);

                Object obj = null;
                if (Extends.TryGetValue(name, out obj)) return obj;

                //throw new ArgumentException("��[" + this.GetType().FullName + "]�в�����[" + name + "]����");

                return null;
            }
            set
            {
                //ƥ���ֶ�
                if (Meta.FieldNames.Contains(name))
                {
                    FieldInfoX field = FieldInfoX.Create(this.GetType(), "_" + name);
                    if (field != null)
                    {
                        field.SetValue(this, value);
                        return;
                    }
                }

                //����ƥ������
                PropertyInfoX property = PropertyInfoX.Create(this.GetType(), name);
                if (property != null)
                {
                    property.SetValue(this, value);
                    return;
                }

                //foreach (FieldItem fi in Meta.AllFields)
                //    if (fi.Name == name) { fi.Property.SetValue(this, value, null); return; }

                if (Extends.ContainsKey(name))
                    Extends[name] = value;
                else
                    Extends.Add(name, value);

                //throw new ArgumentException("��[" + this.GetType().FullName + "]�в�����[" + name + "]����");
            }
        }
        #endregion

        #region ���뵼��XML
        /// <summary>
        /// ����Xml���л���
        /// </summary>
        /// <returns></returns>
        protected override XmlSerializer CreateXmlSerializer()
        {
            // ��ÿһ���������Լ���XmlĬ��ֵ���ԣ���Xml���л�ʱ�ܿ�������Ĭ��ֵ��ͬ���������ԣ�����Xml��С
            XmlAttributeOverrides ovs = new XmlAttributeOverrides();
            TEntity entity = new TEntity();
            foreach (FieldItem item in Meta.Fields)
            {
                XmlAttributes atts = new XmlAttributes();
                atts.XmlAttribute = new XmlAttributeAttribute();
                atts.XmlDefaultValue = entity[item.Name];
                ovs.Add(item.DeclaringType, item.Name, atts);
            }
            return new XmlSerializer(this.GetType(), ovs);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static TEntity FromXml(String xml)
        {
            if (!String.IsNullOrEmpty(xml)) xml = xml.Trim();

            StopExtend = true;
            try
            {
                //IEntityOperate factory = EntityFactory.CreateOperate(typeof(TEntity));
                XmlSerializer serial = ((TEntity)Meta.Factory).CreateXmlSerializer();
                using (StringReader reader = new StringReader(xml))
                {
                    return serial.Deserialize(reader) as TEntity;
                }
            }
            finally { StopExtend = false; }
        }
        #endregion

        #region ���뵼��Json
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static TEntity FromJson(String json)
        {
            return new Json().Deserialize<TEntity>(json);
        }
        #endregion

        #region ��¡
        /// <summary>
        /// ������ǰ����Ŀ�¡���󣬽����������ֶ�
        /// </summary>
        /// <returns></returns>
        public override Object Clone()
        {
            return CloneEntity();
        }

        /// <summary>
        /// ��¡ʵ�塣������ǰ����Ŀ�¡���󣬽����������ֶ�
        /// </summary>
        /// <returns></returns>
        public virtual TEntity CloneEntity()
        {
            //TEntity obj = new TEntity();
            TEntity obj = CreateInstance();
            foreach (FieldItem fi in Meta.Fields)
            {
                obj[fi.Name] = this[fi.Name];
            }
            if (Extends != null && Extends.Count > 0)
            {
                foreach (String item in Extends.Keys)
                {
                    obj.Extends[item] = Extends[item];
                }
            }
            return obj;
        }
        #endregion

        #region ����
        /// <summary>
        /// �����ء�
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // ���Ȳ���ҵ��������Ҳ����Ψһ����
            IDataTable table = Meta.Table.DataTable;
            if (table.Indexes != null && table.Indexes.Count > 0)
            {
                foreach (IDataIndex item in table.Indexes)
                {
                    if (!item.Unique) continue;

                    IDataColumn[] columns = table.GetColumns(item.Columns);
                    if (columns == null || columns.Length < 1) continue;

                    // [v1,v2,...vn]
                    StringBuilder sb = new StringBuilder();
                    foreach (IDataColumn dc in columns)
                    {
                        if (sb.Length > 0) sb.Append(",");
                        if (Meta.FieldNames.Contains(dc.Alias)) sb.Append(this[dc.Alias]);
                    }
                    if (columns.Length > 1)
                        return String.Format("[{0}]", sb.ToString());
                    else
                        return sb.ToString();
                }
            }

            if (Meta.FieldNames.Contains("Name"))
                return this["Name"] == null ? null : this["Name"].ToString();
            else if (Meta.FieldNames.Contains("ID"))
                return this["ID"] == null ? null : this["ID"].ToString();
            else
                return "ʵ��" + Meta.ThisType.Name;
        }
        #endregion

        #region ������
        /// <summary>
        /// �����������ݵ�������
        /// </summary>
        /// <param name="isDirty">�ı������Ե����Ը���</param>
        /// <returns></returns>
        protected override Int32 SetDirty(Boolean isDirty)
        {
            Int32 count = 0;
            foreach (String item in Meta.FieldNames)
            {
                Boolean b = false;
                if (isDirty)
                {
                    if (!Dirtys.TryGetValue(item, out b) || !b)
                    {
                        Dirtys[item] = true;
                        count++;
                    }
                }
                else
                {
                    if (Dirtys == null || Dirtys.Count < 1) break;
                    if (Dirtys.TryGetValue(item, out b) && b)
                    {
                        Dirtys[item] = false;
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// ����ֶδ���Ĭ��ֵ������Ҫ���������ݣ���Ϊ��Ȼ�û������ø��ֶΣ������ǲ������ݿ��Ĭ��ֵ
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected override bool OnPropertyChanging(string fieldName, object newValue)
        {
            // �������true����ʾ����ͬ�������Ѿ�������������
            if (base.OnPropertyChanging(fieldName, newValue)) return true;

            // ������ֶδ��ڣ��Ҵ���Ĭ��ֵ������Ҫ���������ݣ���Ϊ��Ȼ�û������ø��ֶΣ������ǲ������ݿ��Ĭ��ֵ
            FieldItem fi = Meta.Table.FindByName(fieldName);
            if (fi != null && !String.IsNullOrEmpty(fi.DefaultValue))
            {
                Dirtys[fieldName] = true;
                return true;
            }

            return false;
        }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��ȡ�����ڵ�ǰʵ�������չ����
        /// </summary>
        /// <typeparam name="TResult">��������</typeparam>
        /// <param name="key">��</param>
        /// <param name="func">�ص�</param>
        /// <returns></returns>
        protected TResult GetExtend<TResult>(String key, Func<String, Object> func)
        {
            return GetExtend<TEntity, TResult>(key, func);
        }

        /// <summary>
        /// ��ȡ�����ڵ�ǰʵ�������չ����
        /// </summary>
        /// <typeparam name="TResult">��������</typeparam>
        /// <param name="key">��</param>
        /// <param name="func">�ص�</param>
        /// <param name="cacheDefault">�Ƿ񻺴�Ĭ��ֵ����ѡ������Ĭ�ϻ���</param>
        /// <returns></returns>
        protected TResult GetExtend<TResult>(String key, Func<String, Object> func, Boolean cacheDefault)
        {
            return GetExtend<TEntity, TResult>(key, func);
        }

        /// <summary>
        /// ���������ڵ�ǰʵ�������չ����
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="value">ֵ</param>
        protected void SetExtend(String key, Object value)
        {
            SetExtend<TEntity>(key, value);
        }
        #endregion
    }
}