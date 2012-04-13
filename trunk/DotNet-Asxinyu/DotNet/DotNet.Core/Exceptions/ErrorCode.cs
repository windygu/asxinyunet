using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Exceptions
{
    /// <summary>
    /// 错误代码,本项目的异常处理基类来自NewLfe.Core,本项目只负责提供错误代码
    /// </summary>
    public class ErrorCode
    {
        #region 文件类型错误
        /// <summary>
        /// 指定路径的文件不存在,传入参数文件名
        /// </summary>
        public static string File_NotExist = "指定文件:{0}不存在";
        #endregion

        #region 数据库操作
        public static string Db_DeleteError = "删除数据出错:{0}";
        #endregion

        #region 序列化错误
        /// <summary>
        /// 序列化转换失败
        /// </summary>
        public static string Serializ_ConvertFailed = "转换失败";
        #endregion

        #region 其他不明错误
        public static string OtherError = "错误不明";
        #endregion
    }
}
