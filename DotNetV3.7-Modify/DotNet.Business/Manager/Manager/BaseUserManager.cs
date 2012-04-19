//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 系统用户表
    ///
    /// 修改纪录
    ///
    ///		2011-11-18 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011-11-18</date>
    /// </author>
    /// </summary>
    public partial class BaseUserManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userCode">用户编号</param>
        public BaseUserEntity GetEntityByCode(string userCode)
        {
            BaseUserEntity userEntity = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, userCode));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
            DataTable dt = this.GetDataTable(parameters);
            if (dt.Rows.Count > 0)
            {
                userEntity = new BaseUserEntity(dt);
            }
            return userEntity;
        }
    }
}
