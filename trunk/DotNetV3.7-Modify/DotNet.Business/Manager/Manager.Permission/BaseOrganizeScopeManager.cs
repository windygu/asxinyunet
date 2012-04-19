//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeScopeManager
    /// 组织机构权限域
    /// 
    /// 修改纪录
    ///
    ///     2008.05.24 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.24</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizeScopeManager : BaseManager, IBaseManager
    {
        public BaseOrganizeScopeManager()
        {
            base.CurrentTableName = BasePermissionScopeEntity.TableName;
        }

        public BaseOrganizeScopeManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        public BaseOrganizeScopeManager(BaseUserInfo organizeInfo)
            : this()
        {
            UserInfo = organizeInfo;
        }

        public BaseOrganizeScopeManager(IDbHelper dbHelper, BaseUserInfo organizeInfo)
            : this(dbHelper)
        {
            UserInfo = organizeInfo;
        }

        public string GetIdByCode(string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            // 这里应该是若不存在就自动加一个操作权限
            return permissionItemManager.GetIdByAdd(permissionItemCode);
        }

        public int ClearOrganizePermissionScope(string organizeId, string permissionItemCode)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, organizeId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return permissionScopeManager.Delete(parameters);
        }

        public int RevokeAll(string organizeId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, organizeId));
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return permissionScopeManager.Delete(parameters);
        }
    }
}