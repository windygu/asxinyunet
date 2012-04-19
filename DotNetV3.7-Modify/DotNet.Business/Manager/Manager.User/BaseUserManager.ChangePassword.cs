//-----------------------------------------------------------------
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
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public virtual int ChangePassword(string oldPassword, string newPassword, out string statusCode)
        {
            #if (DEBUG)
                int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (String.IsNullOrEmpty(newPassword))
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            // 加密密码
            if (BaseSystemInfo.ServerEncryptPassword)
            {
                oldPassword = this.EncryptUserPassword(oldPassword);
                newPassword = this.EncryptUserPassword(newPassword);
            }
            // 判断输入原始密码是否正确
            BaseUserEntity userEntity = new BaseUserEntity();
            userEntity.GetSingle(this.GetDataTableById(UserInfo.Id));
            if (userEntity.UserPassword == null)
            {
                userEntity.UserPassword = string.Empty;
            }
            // 密码错误
            if (!userEntity.UserPassword.Equals(oldPassword))
            {
                statusCode = StatusCode.OldPasswordError.ToString();
                return returnValue;
            }
            // 更改密码，同时修改密码的修改日期
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldUserPassword, newPassword));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldChangePasswordDate, System.DateTime.Now));
            returnValue = this.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, UserInfo.Id), parameters);
            if (returnValue == 1)
            {
                statusCode = StatusCode.ChangePasswordOK.ToString();
            }
            else
            {
                // 数据可能被删除
                statusCode = StatusCode.ErrorDeleted.ToString();
            }
            
            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.ChangePassword(" + userEntity.Id + ")");
            #endif

            return returnValue;
        }
    }
}