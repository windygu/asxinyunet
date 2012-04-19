//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// DbHelperService
    /// 执行传入的SQL语句
    /// 
    /// 修改纪录
    /// 
    ///		2011.05.07 版本：2.3 JiRiGaLa 改进为虚类。
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.07.10 版本：1.0 JiRiGaLa 数据库访问类。
    ///		
    /// 版本：2.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.07</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public abstract class DbHelperService : System.MarshalByRefObject, IDbHelperService
    {
        public string ServiceDbConnection = BaseSystemInfo.BusinessDbConnection;
        public CurrentDbType ServiceDbType = BaseSystemInfo.BusinessDbType;

        public DbHelperService()
        {
        }

        public DbHelperService(string dbConnection)
        {
            ServiceDbConnection = dbConnection;
        }

        #region 执行sql  public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText)
       /// <summary>
       /// 执行sql
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteNonQuery(commandText);
        }
        #endregion

        #region  执行sql 带参数 public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        /// <summary>
       /// 执行sql 带参数
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public int ExecuteNonQuery(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteNonQuery(commandText, dbParameters);
        }
        #endregion

        #region  执行sql public object ExecuteScalar(BaseUserInfo userInfo, string commandText)
        /// <summary>
       /// 执行sql
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public object ExecuteScalar(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteScalar(commandText);
        }
        #endregion

        #region 执行sql 带参数 public object ExecuteScalar(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
       /// <summary>
       /// 执行sql 带参数
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public object ExecuteScalar(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.ExecuteScalar(commandText, dbParameters);
        }
        #endregion

        #region  执行Sql 返回DataTable public DataTable Fill(BaseUserInfo userInfo, string commandText)
        /// <summary>
       /// 执行Sql 返回DataTable
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <returns></returns>
        public DataTable Fill(BaseUserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.Fill(commandText);
        }
        #endregion

        #region 执行Sql 返回DataTable public DataTable Fill(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        /// <summary>
        /// 执行Sql 返回DataTable
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="commandText"></param>
       /// <param name="dbParameters"></param>
       /// <returns></returns>
        public DataTable Fill(BaseUserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbHelper dbHelper = DbHelperFactory.GetHelper(ServiceDbType, ServiceDbConnection);
            return dbHelper.Fill(commandText, dbParameters);
        }
        #endregion 
    }
}