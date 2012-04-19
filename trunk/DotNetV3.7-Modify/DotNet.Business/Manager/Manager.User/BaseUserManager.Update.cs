﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.17 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        #region public int Update(BaseUserEntity userEntity, out string statusCode)
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseUserEntity userEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查用户名是否重复
            if (this.Exists(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, userEntity.UserName), new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, "0"), userEntity.Id))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorUserExist.ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(userEntity.Code) && userEntity.Code.Length > 0 && this.Exists(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, userEntity.Code), new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, "0"), userEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(userEntity);
                    if (returnValue == 0)
                    {
                        statusCode = StatusCode.ErrorDeleted.ToString();
                    }
                    else
                    {
                        statusCode = StatusCode.OKUpdate.ToString();
                    }
                }
            }
            return returnValue;
        }
        #endregion
    }
}