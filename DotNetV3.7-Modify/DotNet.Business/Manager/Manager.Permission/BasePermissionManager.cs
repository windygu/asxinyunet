﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BasePermissionManager
    /// 资源权限管理，操作权限管理（这里喊了用户操作权限，角色的操作权限）
    /// 
    /// 修改纪录
    ///
    ///     2010.09.21 版本：2.0 JiRiGaLa 智能权限判断、后台自动增加权限，增加并发锁PermissionItemLock。
    ///     2009.09.22 版本：1.1 JiRiGaLa 前台判断的权限，后台都需要记录起来，防止后台缺失前台的判断权限。
    ///     2008.03.28 版本：1.0 JiRiGaLa 创建主键。
    ///     
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.03.28</date>
    /// </author>
    /// </summary>
    public partial class BasePermissionManager : BaseManager, IBaseManager
    {
        #region public bool PermissionExists(string permissionItemId, string resourceCategory, string resourceId) 检查是否存在
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>是否存在</returns>      
        public bool PermissionExists(string permissionItemId, string resourceCategory, string resourceId)
        {
            bool returnValue = true;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, resourceCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, resourceId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            // 检查是否存在
            if (!this.Exists(parameters))
            {
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public string AddPermission(BasePermissionEntity resourcePermissionEntity) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resourcePermissionEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string AddPermission(BasePermissionEntity resourcePermissionEntity)
        {
            string returnValue = string.Empty;
            // 检查记录是否重复
            if (!this.PermissionExists(resourcePermissionEntity.PermissionId.ToString(), resourcePermissionEntity.ResourceCategory, resourcePermissionEntity.ResourceId))
            {
                returnValue = this.AddEntity(resourcePermissionEntity);
            }
            return returnValue;
        }
        #endregion


        //
        // ResourcePermission 权限判断
        // 

        #region public bool CheckPermissionByUser(string userId, string permissionItemCode, string permissionItemName = null) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限</returns>
        public bool CheckPermissionByUser(string userId, string permissionItemCode, string permissionItemName = null)
        {
            // 若不存在就需要自动能增加一个操作权限项
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper, UserInfo);
            string permissionItemId = permissionItemManager.GetIdByAdd(permissionItemCode, permissionItemName);
            BasePermissionItemEntity permissionItemEntity = permissionItemManager.GetEntity(permissionItemId);
            
            // 先判断用户类别
            if (UserInfo.IsAdministrator)
            {
                return true;
            }
            
            // 没有找到相应的权限
            if (String.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }

            // 这里需要判断,是系统权限？
            bool returnValue = false;
            BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.DbHelper, this.UserInfo);
            if (!string.IsNullOrEmpty(permissionItemEntity.CategoryCode) && permissionItemEntity.CategoryCode.Equals("System"))
            {
                // 用户管理员
                returnValue = userRoleManager.UserIsInRoleByCode(userId, "UserAdmin");
                if (returnValue)
                {
                    return returnValue;
                }
            }

            // 这里需要判断,是业务权限？
            if (!string.IsNullOrEmpty(permissionItemEntity.CategoryCode) && permissionItemEntity.CategoryCode.Equals("Application"))
            {
                returnValue = userRoleManager.UserIsInRoleByCode(userId, "Admin");
                if (returnValue)
                {
                    return returnValue;
                }
            }

            // 判断用户权限
            if (this.CheckUserPermission(userId, permissionItemId))
            {
                return true;
            }
            // 判断用户角色权限
            if (this.CheckUserRolePermission(userId, permissionItemId))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private bool CheckUserPermission(string userId, string permissionItemId)
        /// <summary>
        /// 员工是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>是否有权限</returns>
        private bool CheckUserPermission(string userId, string permissionItemId)
        {
            return CheckResourcePermission(BaseUserEntity.TableName, userId, permissionItemId);
        }
        #endregion

        private bool CheckResourcePermission(string resourceCategory, string resourceId, string permissionItemId)
        {
            string sqlQuery = " SELECT COUNT(1) "
                             + "   FROM " + BasePermissionEntity.TableName
                             + "  WHERE (" + BasePermissionEntity.FieldResourceCategory + " = '" + resourceCategory + "') "
                             + "        AND (" + BasePermissionEntity.FieldEnabled + " = 1) "
                             + "        AND (" + BasePermissionEntity.FieldDeletionStateCode + " = 0) "
                             + "        AND (" + BasePermissionEntity.FieldResourceId + " = '" + resourceId + "') "
                             + "        AND (" + BasePermissionEntity.FieldPermissionItemId + " = '" + permissionItemId + "')";
            int rowCount = 0;
            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        #region private bool CheckUserRolePermission(string userId, string permissionItemId)
        /// <summary>
        /// 用户角色关系是否有模块权限
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>有角色权限</returns>
        private bool CheckUserRolePermission(string userId, string permissionItemId)
        {
            string sqlQuery = " SELECT COUNT(1) "
                            + "   FROM " + BasePermissionEntity.TableName
                            + "  WHERE " + "(" + BasePermissionEntity.FieldResourceCategory + " = '" + BaseRoleEntity.TableName + "') "
                            + "        AND (" + BasePermissionEntity.FieldEnabled + " = 1 "
                            + "        AND  " + BasePermissionEntity.FieldDeletionStateCode + " = 0) "
                            + "        AND (" + BasePermissionEntity.FieldResourceId + " IN ( "
                                                + " SELECT " + BaseUserRoleEntity.FieldRoleId
                                                + "   FROM " + BaseUserRoleEntity.TableName
                                                + "  WHERE " + BaseUserRoleEntity.FieldUserId + " = '" + userId + "' "
                                                + "        AND " + BaseUserRoleEntity.FieldEnabled + " = 1 "
                                                + "        AND " + BaseUserRoleEntity.FieldDeletionStateCode + " = 0 "
                                                + "  UNION ALL "
                                                + " SELECT " + BaseUserEntity.FieldRoleId
                                                + "   FROM " + BaseUserEntity.TableName
                                                + "  WHERE " + BaseUserEntity.FieldId + " = '" + userId + "'"
                                                + ") ) "
                            + "        AND (" + BasePermissionEntity.FieldPermissionItemId + " = '" + permissionItemId + "') ";
            int rowCount = 0;
            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }
        #endregion

        //
        // 从数据库获取权限
        //

        #region public DataTable GetPermission(BaseUserInfo userInfo)
        /// <summary>
        /// 获得一个员工的某一模块的权限
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name=userInfo>用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPermission(BaseUserInfo userInfo)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper, userInfo);
            if (userInfo.IsAdministrator)
            {
                return permissionItemManager.GetDataTable(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1), BasePermissionItemEntity.FieldSortCode);
            }
            return this.GetPermissionByUser(userInfo.Id);
        }
        #endregion

        public DataTable GetPermissionByUser(string userId)
        {
            string sqlQuery = " SELECT * "
                             + "   FROM " + BasePermissionItemEntity.TableName
                             + "  WHERE " + BasePermissionItemEntity.FieldEnabled + " = 1 "
                             + "        AND " + BasePermissionItemEntity.FieldId + " IN ( "

                             // 用户的权限
                             + " SELECT " + BasePermissionEntity.FieldPermissionItemId
                             + "   FROM " + BasePermissionEntity.TableName
                             + "  WHERE (" + BasePermissionEntity.FieldResourceCategory + " = '" + BaseUserEntity.TableName + "') "
                             + "        AND (" + BasePermissionEntity.FieldEnabled + " = 1) "
                             + "        AND (" + BasePermissionEntity.FieldResourceId + " = '" + userId + "')"

                            + " UNION "

                            // 角色的权限                            
                            + " SELECT " + BasePermissionEntity.FieldPermissionItemId
                            + "   FROM " + BasePermissionEntity.TableName
                            + "  WHERE " + "(" + BasePermissionEntity.FieldResourceCategory + " = '" + BaseRoleEntity.TableName + "') "
                            + "        AND (" + BasePermissionEntity.FieldEnabled + " = 1) "
                            + "        AND (" + BasePermissionEntity.FieldResourceId + " IN ( "
                                                + " SELECT " + BaseUserRoleEntity.FieldRoleId
                                                + "   FROM " + BaseUserRoleEntity.TableName
                                                + "  WHERE " + BaseUserRoleEntity.FieldUserId + " = '" + userId + "' "
                                                + "        AND " + BaseUserRoleEntity.FieldEnabled + " = 1"
                                                + "  UNION "
                                                + " SELECT " + BaseUserEntity.FieldRoleId
                                                + "   FROM " + BaseUserEntity.TableName
                                                + "  WHERE " + BaseUserEntity.FieldId + " = '" + userId + "'"
                                                + ")) "
                            + ") "
                            + " ORDER BY " + BasePermissionItemEntity.FieldSortCode;

            return DbHelper.Fill(sqlQuery);
        }

        #region private bool CheckPermissionByRole(string roleId, string permissionItemCode)
        /// <summary>
        /// 用户角色关系是否有模块权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>有角色权限</returns>
        public bool CheckPermissionByRole(string roleId, string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper, UserInfo);
            string permissionItemId = permissionItemManager.GetProperty(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode), BasePermissionItemEntity.FieldId);
            // 判断当前判断的权限是否存在，否则很容易出现前台设置了权限，后台没此项权限
            // 需要自动的能把前台判断过的权限，都记录到后台来
            #if (DEBUG)
                if (String.IsNullOrEmpty(permissionItemId))
                {
                    BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
                    permissionItemEntity.Code = permissionItemCode;
                    permissionItemEntity.FullName = permissionItemCode;
                    permissionItemEntity.ParentId = 0;
                    permissionItemEntity.IsScope = 0;
                    permissionItemEntity.AllowDelete = 1;
                    permissionItemEntity.AllowEdit = 1;
                    permissionItemEntity.DeletionStateCode = 0;
                    permissionItemEntity.Enabled = 1;
                    // 这里是防止主键重复？
                    // permissionEntity.ID = BaseBusinessLogic.NewGuid();
                    permissionItemManager.AddEntity(permissionItemEntity);
                }
                else
                {
                    // 更新最后一次访问日期，设置为当前服务器日期
                    SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
                    sqlBuilder.BeginUpdate(this.CurrentTableName);
                    sqlBuilder.SetDBNow(BasePermissionItemEntity.FieldLastCall);
                    sqlBuilder.SetWhere(BasePermissionItemEntity.FieldId, permissionItemId);
                    sqlBuilder.EndUpdate();
                }
            #endif

            if (string.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }
            string sqlQuery = " SELECT COUNT(*) "
                            + "   FROM " + BasePermissionEntity.TableName
                            + "  WHERE " + "(" + BasePermissionEntity.FieldResourceCategory + " = '" + BaseRoleEntity.TableName + "') "
                            + "        AND (" + BasePermissionEntity.FieldEnabled + " = 1) "
                            + "        AND (" + BasePermissionEntity.FieldResourceId + " = '" + roleId + "' ) "
                            + "        AND (" + BasePermissionEntity.FieldPermissionItemId + " = '" + permissionItemId + "') ";
            int rowCount = 0;
            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }
        #endregion
    }
}