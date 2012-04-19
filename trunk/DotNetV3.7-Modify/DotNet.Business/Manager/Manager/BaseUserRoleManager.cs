//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserRoleManager
    /// 用户-角色 关系
    /// 
    /// 修改纪录
    ///
    ///     2008.05.24 版本：1.0 JiRiGaLa 创建主键。
    ///     
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.16</date>
    /// </author>
    /// </summary>
    public partial class BaseUserRoleManager : BaseManager //, IBaseUserRoleManager
    {
        public int ClearRoleUser(string roleId)
        {
            int returnValue = 0;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            returnValue = userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));

            returnValue += this.Delete(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldRoleId, roleId));
            return returnValue;
        }

        public int ClearUserRole(string userId)
        {
            int returnValue = 0;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            returnValue += userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userId), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));

            returnValue += this.Delete(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldUserId, userId));
            return returnValue;
        }

        #region public string GetUserFullName(string id) 获取员工名称
        /// <summary>
        /// 获取员工名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>主键</returns>
        public string GetUserFullName(string id)
        {
            string userId = this.GetProperty(id, BaseUserRoleEntity.FieldUserId);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseStaffEntity.FieldId, userId));
            return DbLogic.GetProperty(DbHelper, BaseStaffEntity.TableName, parameters, BaseStaffEntity.FieldRealName);
        }
        #endregion

        #region public string GetRoleName(string id) 获取角色名称
        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>主键</returns>
        public string GetRoleName(string id)
        {
            string roleId = this.GetProperty(id, BaseUserRoleEntity.FieldRoleId);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, roleId));
            return DbLogic.GetProperty(DbHelper, BaseRoleEntity.TableName, parameters, BaseRoleEntity.FieldRealName);
        }
        #endregion

        // public bool UserIsInRole(string userId, string realName)

        public bool UserIsInRoleByCode(string userId, string roleCode)
        {
            bool returnValue = false;
            if (string.IsNullOrEmpty(roleCode))
            {
                return false;
            }
            BaseRoleManager roleManager = new BaseRoleManager(this.DbHelper, this.UserInfo);
            string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, roleCode));
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            } 
            string[] roleIds = GetAllRoleIds(userId);
            returnValue = StringUtil.Exists(roleIds, roleId);
            return returnValue;
        }

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string userId)
        {
            // 被删除的角色不应该显示出来
            string sqlQuery = " SELECT RoleId  " 
                            + "   FROM BaseUserRole " 
                            + "  WHERE (UserId = " + userId + ") " 
                            + "    AND (RoleId IN (SELECT Id FROM BaseRole WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldRoleId);
        }
        #endregion

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetAllRoleIds(string userId)
        {
            // 被删除的角色不应该显示出来
            string sqlQuery = " SELECT RoleId " 
                            + "   FROM BaseUser "
                            + "  WHERE (DeletionStateCode = 0) AND (Enabled = 1) AND (Id = " + userId + ") "
                            + "  UNION " 
                            + " SELECT RoleId " 
                            + "   FROM BaseUserRole "
                            + "  WHERE (DeletionStateCode = 0) AND (Enabled = 1) AND (UserId = " + userId + ") AND (RoleId IN (SELECT Id FROM BaseRole WHERE (DeletionStateCode = 0))) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldRoleId);
        }
        #endregion

        #region public string[] GetUserIds(string roleId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string roleId)
        {
            // 需要显示未被删除的用户
            string sqlQuery = " SELECT Id AS USERID FROM BaseUser WHERE (RoleId = " + roleId + ") AND (DeletionStateCode = 0) AND (Enabled = 1) "
                            + " UNION SELECT UserId FROM BaseUserRole WHERE (RoleId = " + roleId + ") AND (UserId IN (SELECT Id FROM BaseUser WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldUserId);
        }
        #endregion

        public string[] GetUserIds(string[] roleIds)
        {
            string[] userIds = null;
            if (roleIds != null && roleIds.Length > 0)
            {
                // 需要显示未被删除的用户
                string sqlQuery = " SELECT Id AS USERID FROM BaseUser WHERE (RoleId IN ( " + StringUtil.ArrayToList(roleIds) + ")) AND (DeletionStateCode = 0) AND (Enabled = 1) "
                                + " UNION SELECT UserId FROM BaseUserRole WHERE (RoleId IN (" + StringUtil.ArrayToList(roleIds) + ")) AND (UserId IN (SELECT Id FROM BaseUser WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
                DataTable dataTable = DbHelper.Fill(sqlQuery);
                userIds = BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldUserId);
            }
            return userIds;
        }


        //
        // 加入到角色
        //

        #region public string AddToRole(string userId, string roleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键</returns>
        public string AddToRole(string userId, string roleId)
        {
            string returnValue = string.Empty;
            BaseUserRoleEntity userRoleEntity = new BaseUserRoleEntity();
            userRoleEntity.UserId = int.Parse(userId);
            userRoleEntity.RoleId = int.Parse(roleId);
            userRoleEntity.Enabled = 1;
            userRoleEntity.DeletionStateCode = 0;
            return this.Add(userRoleEntity);
        }
        #endregion

        public int AddToRole(string userId, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.AddToRole(userId, roleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string roleId)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                this.AddToRole(userIds[i], roleId);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < roleIds.Length; j++)
                {
                    this.AddToRole(userIds[i], roleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  从角色中删除员工
        //

        #region public int RemoveFormRole(string userId, string roleId) 撤销角色权限
        /// <summary>
        /// 从角色中删除员工
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RemoveFormRole(string userId, string roleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldUserId, userId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldRoleId, roleId));
            return this.Delete(parameters);
        }
        #endregion

        public int RemoveFormRole(string userId, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < roleIds.Length; i++)
            {
                returnValue += this.RemoveFormRole(userId, roleIds[i]);
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string roleId)
        {
            int returnValue = 0;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                // 删除用户角色
                returnValue += this.RemoveFormRole(userIds[i], roleId);
                // 如果该角色是用户默认角色，将用户默认角色置空
                userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userIds[i]), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < roleIds.Length; j++)
                {
                    returnValue += this.RemoveFormRole(userIds[i], roleIds[j]);
                }
            }
            return returnValue;
        }
    }
}