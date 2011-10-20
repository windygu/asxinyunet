using System;
using System.Text;
using System.Text.RegularExpressions;


namespace XCode.DataAccessLayer
{
    /// <summary>
    /// SQL��ѯ���������
    /// </summary>
    /// <remarks>��ѯ���ĸ����ԣ�ʹ�ö���ط�ʹ��������Ϊ�����档
    /// Ӧ���Ա�����Ϊ��ѯ����ֱ�Ӵ����ϲ����뵽���²�</remarks>
    public class SelectBuilder
    {
        #region ����
        private DatabaseType _DbType = DatabaseType.Access;
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public DatabaseType DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }

        //private Boolean _IsLock;
        ///// <summary>�Ƿ���������ֹ�޸�</summary>
        //public Boolean IsLock
        //{
        //    get { return _IsLock; }
        //    private set { _IsLock = value; }
        //}
        #endregion

        #region SQL��ѯ����������
        private String _Column;
        /// <summary>
        /// ѡ����
        /// </summary>
        public String Column
        {
            get { return _Column; }
            set { OnChange("Column", value); _Column = value; }
        }

        private String _Table;
        /// <summary>
        /// ���ݱ�
        /// </summary>
        public String Table
        {
            get { return _Table; }
            set { OnChange("Table", value); _Table = value; }
        }

        private String _Where;
        /// <summary>
        /// ����
        /// </summary>
        public String Where
        {
            get { return _Where; }
            set
            {
                OnChange("Where", value);
                _Where = value;

                if (!String.IsNullOrEmpty(_Where))
                {
                    Match match = reg_gb.Match(_Where);
                    if (match != null && match.Success)
                    {
                        String gb = _Where.Substring(match.Index + match.Length).Trim();
                        if (String.IsNullOrEmpty(GroupBy))
                            GroupBy = gb;
                        else
                            GroupBy += ", " + gb;

                        _Where = _Where.Substring(0, match.Index).Trim();
                    }
                }

                if (_Where == "1=1") _Where = null;
            }
        }

        private String _GroupBy;
        /// <summary>
        /// ����
        /// </summary>
        public String GroupBy
        {
            get { return _GroupBy; }
            set { OnChange("GroupBy", value); _GroupBy = value; }
        }

        private String _Having;
        /// <summary>
        /// ��������
        /// </summary>
        public String Having
        {
            get { return _Having; }
            set { OnChange("Having", value); _Having = value; }
        }

        private String _OrderBy;
        /// <summary>
        /// ����
        /// </summary>
        public String OrderBy
        {
            get { return _OrderBy; }
            set { OnChange("OrderBy", value); _OrderBy = value; }
        }
        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public SelectBuilder()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dbType"></param>
        public SelectBuilder(DatabaseType dbType)
        {
            DbType = dbType;
        }

        //TODO ʹ������ƽ�������sql
        //TODO ʹ�þ�̬���������Ż�����Ĵ���

        ///// <summary>
        ///// ͨ������һ��SQL�������ʼ��һ��ʵ��
        ///// </summary>
        ///// <param name="dbType">���ݿ�����</param>
        ///// <param name="sql">Ҫ������SQL���</param>
        ///// <param name="isLock">�Ƿ�����</param>
        //public SqlBuilder(DatabaseType dbType, String sql, Boolean isLock)
        //{
        //    DbType = dbType;
        //    Parse(sql);
        //    IsLock = isLock;
        //}

        //private static Dictionary<String, SqlBuilder> _SqlBuilderCache = new Dictionary<string, SqlBuilder>();
        ///// <summary>
        ///// ͨ������һ��SQL�������ʼ��һ��ʵ��
        ///// </summary>
        ///// <param name="dbType"></param>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //public static SqlBuilder Create(DatabaseType dbType, String sql)
        //{
        //    String Key = String.Format("{0}_{1}", dbType, sql);
        //    if (_SqlBuilderCache.ContainsKey(Key)) return _SqlBuilderCache[Key];
        //    lock (_SqlBuilderCache)
        //    {
        //        if (_SqlBuilderCache.ContainsKey(Key)) return _SqlBuilderCache[Key];
        //        SqlBuilder sb = new SqlBuilder(dbType, sql, true);
        //        _SqlBuilderCache.Add(Key, sb);
        //        return sb;
        //    }
        //}
        #endregion

        #region ����SQL
        private const String SelectRegex = @"(?isx-m)
^
\bSelect\s+(?<ѡ����>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!)))
\s+From\s+(?<���ݱ�>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!)))
(?:\s+Where\s+(?<����>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!))))?
(?:\s+Group\s+By\s+(?<����>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!))))?
(?:\s+Having\s+(?<��������>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!))))?
(?:\s+Order\s+By\s+(?<����>(?>[^()]+?|\((?<Open>)|\)(?<-Open>))*?(?(Open)(?!))))?
$";
        static Regex regexSelect = new Regex(SelectRegex, RegexOptions.Compiled);

        /// <summary>
        /// ����һ��SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Boolean Parse(String sql)
        {
            Regex reg = new Regex(SelectRegex, RegexOptions.IgnoreCase);
            MatchCollection ms = reg.Matches(sql);
            if (ms != null && ms.Count > 0 && ms[0].Success)
            {
                Match m = ms[0];
                Column = m.Groups["ѡ����"].Value;
                Table = m.Groups["���ݱ�"].Value;
                Where = m.Groups["����"].Value;
                GroupBy = m.Groups["����"].Value;
                Having = m.Groups["��������"].Value;
                OrderBy = m.Groups["����"].Value;

                if (Where == "1=1") Where = null;

                return true;
            }

            return false;

            //return Regex.IsMatch(sql, SelectRegex, RegexOptions.IgnoreCase);
        }
        #endregion

        #region ����SQL
        private static Regex reg_gb = new Regex(@"\bgroup\b\s*\bby\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //private String _out;
        /// <summary>
        /// ����д����ȡ��Builder��������SQL���
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            //if (IsLock && !String.IsNullOrEmpty(_out)) return _out;

            //if (!String.IsNullOrEmpty(Where) && reg_gb.IsMatch(Where)) throw new Exception("�벻Ҫ��Where��ʹ��GroupBy��");

            StringBuilder sb = new StringBuilder();
            sb.Append("Select ");
            sb.Append(String.IsNullOrEmpty(Column) ? "*" : Column);
            sb.Append(" From ");
            sb.Append(Table);
            if (!String.IsNullOrEmpty(Where)) sb.Append(" Where " + Where);
            if (!String.IsNullOrEmpty(GroupBy)) sb.Append(" Group By " + GroupBy);
            if (!String.IsNullOrEmpty(Having)) sb.Append(" Having " + Having);
            if (!String.IsNullOrEmpty(OrderBy)) sb.Append(" Order By " + OrderBy);
            //_out = RevTranSql(sb.ToString());
            //return _out;
            return sb.ToString();
        }

        /// <summary>
        /// ��ȡ��¼�������
        /// </summary>
        /// <returns></returns>
        public virtual SelectBuilder SelectCount()
        {
            SelectBuilder sb = this.Clone();
            sb.OrderBy = null;
            // ����GroupByʱ����Ϊ�Ӳ�ѯ
            if (!String.IsNullOrEmpty(GroupBy)) sb.Table = String.Format("({0}) as SqlBuilder_T0", sb.ToString());
            sb.Column = "Count(*)";
            return sb;
        }
        #endregion

        #region ��������
        ///// <summary>
        ///// SQLת���б�
        ///// </summary>
        //private Dictionary<Int32, String> SqlTranList = new Dictionary<Int32, String>();

        ///// <summary>
        ///// ��ת���б�
        ///// </summary>
        //private Dictionary<String, String> RevCache = new Dictionary<String, String>();

        ///// <summary>
        ///// SQLת�塣ȥ�������Ӳ�ѯ�������� �Լ� ˫����
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //private String TranSql(String sql)
        //{
        //    SqlTranList.Clear();
        //    sql = TranSql(sql, @"\(", @"\)");
        //    sql = TranSql(sql, "'", "'");
        //    sql = TranSql(sql, "\"", "\"");
        //    return sql;
        //}

        ///// <summary>
        ///// ת��
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="start"></param>
        ///// <param name="end"></param>
        ///// <returns></returns>
        //private String TranSql(String sql, String start, String end)
        //{
        //    Regex reg = new Regex(String.Format("{0}.*?{1}", start, end), RegexOptions.IgnoreCase | RegexOptions.Compiled);
        //    MatchCollection ms = reg.Matches(sql);
        //    if (ms.Count < 1) return sql;
        //    foreach (Match m in ms)
        //    {
        //        if (!String.IsNullOrEmpty(m.Groups[0].Value))
        //        {
        //            sql = sql.Replace(m.Groups[0].Value, String.Format("#{0}#", SqlTranList.Count));
        //            SqlTranList.Add(SqlTranList.Count, m.Groups[0].Value);
        //        }
        //    }
        //    // �Ѿ��������һ���ת�壬����ݹ���������ת��
        //    return TranSql(sql, start, end);
        //}

        ///// <summary>
        ///// ��ת��SQL
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //private String RevTranSql(String sql)
        //{
        //    Regex reg = new Regex(@"#\d+#");
        //    if (!reg.IsMatch(sql)) return sql;
        //    foreach (Int32 k in SqlTranList.Keys)
        //    {
        //        sql = sql.Replace(String.Format("#{0}#", k), SqlTranList[k]);
        //    }
        //    return RevTranSql(sql);
        //}

        ///// <summary>
        ///// ��ת��һ�㡣ʵ�����⵽��չ������
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //public String RevTranTop(String str)
        //{
        //    if (RevCache.ContainsKey(str)) return RevCache[str];
        //    lock (this)
        //    {
        //        if (RevCache.ContainsKey(str)) return RevCache[str];
        //        String tem = str;
        //        foreach (Int32 k in SqlTranList.Keys)
        //        {
        //            tem = tem.Replace(String.Format("#{0}#", k), SqlTranList[k]);
        //        }
        //        RevCache.Add(str, tem);
        //        return tem;
        //    }
        //}
        #endregion

        #region ����
        /// <summary>
        /// ��¡
        /// </summary>
        /// <returns></returns>
        public SelectBuilder Clone()
        {
            SelectBuilder sb = new SelectBuilder(DbType);
            sb.Column = this.Column;
            sb.Table = this.Table;
            sb.Where = this.Where;
            sb.OrderBy = this.OrderBy;
            sb.GroupBy = this.GroupBy;
            sb.Having = this.Having;
            return sb;
        }

        private void OnChange(String name, String value)
        {
            //if (IsLock) throw new InvalidOperationException("�������ѱ���������ֹ�޸ģ���ʹ��Clone��ȡ�������޸ġ�");
        }
        #endregion
    }
}