using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using XCode;
using XCode.Configuration;

namespace DotNet.CommonEntity
{
    /// <summary>日志信息</summary>
    public partial class Log<TEntity> 
    {
        #region ILog接口
        //TODO:完善写日志接口的处理，做到尽量简单，是否重新设计表结构
        #endregion
    }
    public partial interface ILog
    {

        /// <summary>写日志</summary>
        /// <param name="type">类型</param>
        /// <param name="action">操作</param>
        /// <param name="remark">备注</param>
        //void WriteLog(int systemDbId, String userId, String category,string action);
    }
}
