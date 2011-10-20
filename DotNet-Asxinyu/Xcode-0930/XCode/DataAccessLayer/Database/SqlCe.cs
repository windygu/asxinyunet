﻿using System;
using System.Data.Common;
using System.Data.SqlTypes;

namespace XCode.DataAccessLayer
{
    class SqlCe : FileDbBase
    {
        #region 属性
        /// <summary>
        /// 返回数据库类型。外部DAL数据库类请使用Other
        /// </summary>
        public override DatabaseType DbType
        {
            get { return DatabaseType.SqlCe; }
        }

        private static DbProviderFactory _dbProviderFactory;
        /// <summary>
        /// 提供者工厂
        /// </summary>
        static DbProviderFactory dbProviderFactory
        {
            get
            {
                if (_dbProviderFactory == null)
                {
                    lock (typeof(SqlCe))
                    {
                        if (_dbProviderFactory == null) _dbProviderFactory = GetProviderFactory("System.Data.SqlServerCe.dll", "System.Data.SqlServerCe.SqlCeFactory");
                    }
                }

                return _dbProviderFactory;
            }
        }

        /// <summary>工厂</summary>
        public override DbProviderFactory Factory
        {
            get { return dbProviderFactory; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 创建数据库会话
        /// </summary>
        /// <returns></returns>
        protected override IDbSession OnCreateSession()
        {
            return new SqlCeSession();
        }

        /// <summary>
        /// 创建元数据对象
        /// </summary>
        /// <returns></returns>
        protected override IMetaData OnCreateMetaData()
        {
            return new SqlCeMetaData();
        }
        #endregion

        #region 数据库特性
        /// <summary>
        /// 当前时间函数
        /// </summary>
        public override String DateTimeNow { get { return "getdate()"; } }

        /// <summary>
        /// 最小时间
        /// </summary>
        public override DateTime DateTimeMin { get { return SqlDateTime.MinValue.Value; } }

        /// <summary>
        /// 格式化时间为SQL字符串
        /// </summary>
        /// <param name="dateTime">时间值</param>
        /// <returns></returns>
        public override String FormatDateTime(DateTime dateTime)
        {
            return String.Format("'{0:yyyy-MM-dd HH:mm:ss}'", dateTime);
        }

        /// <summary>
        /// 格式化关键字
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public override String FormatKeyWord(String keyWord)
        {
            //if (String.IsNullOrEmpty(keyWord)) throw new ArgumentNullException("keyWord");
            if (String.IsNullOrEmpty(keyWord)) return keyWord;

            if (keyWord.StartsWith("[") && keyWord.EndsWith("]")) return keyWord;

            return String.Format("[{0}]", keyWord);
        }
        #endregion

        #region 分页
        public override string PageSplit(SelectBuilder builder, int startRowIndex, int maximumRows, string keyColumn)
        {
            //if (String.IsNullOrEmpty(builder.GroupBy) && startRowIndex <= 0 && maximumRows > 0) return PageSplit(builder, maximumRows);

            if (String.IsNullOrEmpty(builder.GroupBy) || startRowIndex <= 0) return SqlServer.PageSplitTopNotIn(builder, startRowIndex, maximumRows, keyColumn);

            return base.PageSplit(builder, startRowIndex, maximumRows, keyColumn);
        }

        //String PageSplit(SelectBuilder builder, Int32 maximumRows)
        //{
        //    SelectBuilder sb = builder.Clone();
        //    if (String.IsNullOrEmpty(builder.Column)) builder.Column = "*";
        //    builder.Column = String.Format("Top {0} {1}", maximumRows, builder.Column);
        //    return builder.ToString();
        //}
        #endregion
    }

    /// <summary>
    /// SqlCe会话
    /// </summary>
    class SqlCeSession : FileDbSession
    {
        /// <summary>
        /// 执行插入语句并返回新增行的自动编号
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>新增行的自动编号</returns>
        public override Int64 InsertAndGetIdentity(string sql)
        {
            //SQLServer写法
            sql = "SET NOCOUNT ON;" + sql + ";Select SCOPE_IDENTITY()";

            return ExecuteScalar<Int64>(sql);
        }
    }

    /// <summary>
    /// SqlCe元数据
    /// </summary>
    class SqlCeMetaData : FileDbMetaData
    {

    }
}
