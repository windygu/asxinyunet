//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using DotNet.Business;
using DotNet.Utilities;

public partial class RoleModuleAdmin : BasePage
{
    /// <summary>
    /// 模块菜单表
    /// </summary>
    private DataTable DTModule = new DataTable(BaseModuleEntity.TableName);
    private string[] moduleIds = null;

    /// <summary>
    /// 角色主键
    /// </summary>
    private string RoleId
    {
        get
        {
            return this.txtId.Value;
        }
        set
        {
            this.txtId.Value = value;
        }
    }

    public string ReturnURL
    {
        get
        {
            return this.txtReturnURL.Value;
        }
        set
        {
            this.txtReturnURL.Value = value;
        }
    }

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["ID"] != null)
        {
            this.RoleId = Page.Request["ID"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        if (!string.IsNullOrEmpty(this.RoleId))
        {
            this.ShowRole();
            this.LoadTree();
        }
    }
    #endregion

    /// <summary>
    /// 显示角色
    /// </summary>
    private void ShowRole()
    {
        this.UserCenterDbHelper.Open();
        BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
        BaseRoleEntity roleEntity = roleManager.GetEntity(this.RoleId);
        this.UserCenterDbHelper.Close();
        this.ShowRole(roleEntity);
    }

    /// <summary>
    /// 显示角色数据
    /// </summary>
    /// <param name="roleEntity">角色实体</param>
    private void ShowRole(BaseRoleEntity roleEntity)
    {
        if (roleEntity.Id != null)
        {
            this.RoleId = roleEntity.Id.ToString();
        }
        // this.txtCode.Text = roleEntity.Code;
        // this.txtRealname.Text = roleEntity.RealName;
    }

    /// <summary>
    /// 读取屏幕数据
    /// </summary>
    /// <returns>角色实体</returns>
    private BaseRoleEntity GetEntity()
    {
        BaseRoleEntity roleEntity = new BaseRoleEntity();
        if (!string.IsNullOrEmpty(this.RoleId))
        {
            this.UserCenterDbHelper.Open();
            BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
            roleEntity = roleManager.GetEntity(this.RoleId);
            this.UserCenterDbHelper.Close();
        }
        else
        {
            roleEntity.Enabled = 1;
            roleEntity.AllowDelete = 1;
            roleEntity.AllowEdit = 1;
            roleEntity.DeletionStateCode = 0;
        }
        // roleEntity.RealName = this.txtRealname.Text;
        // roleEntity.Code = this.txtCode.Text;
        return roleEntity;
    }

 



    #region private void LoadTree() 加载权限树的代码
    /// <summary>
    /// 加载权限树的代码
    /// </summary>
    private void LoadTree()
    {
        // 获得角色的权限代码数组
        DotNetService dotNetService = new DotNetService();
        this.moduleIds = dotNetService.PermissionService.GetRoleScopeModuleIds(this.UserInfo, this.RoleId, "Resource.AccessPermission");
        this.DTModule = dotNetService.ModuleService.GetDataTable(this.UserInfo);
        // 开始更新控件，屏幕不刷新，提高效率。
        this.tvModule.Nodes.Clear();
        TreeNode treeNode = new TreeNode();
        this.LoadTree(treeNode);
        this.tvModule.Attributes.Add("onclick", "CheckEvent()");
    }
    #endregion

    #region private void LoadTree(TreeNode treeNode)
    /// <summary>
    /// 加载权限构树的代码
    /// </summary>
    /// <param name="treeNode">当前节点</param>
    private void LoadTree(TreeNode treeNode)
    {
        DataRow[] dataRows = null;
        if (string.IsNullOrEmpty(treeNode.Value))
        {
            dataRows = this.DTModule.Select(BaseModuleEntity.FieldParentId + " IS NULL OR " + BaseModuleEntity.FieldParentId + " = 0", BaseModuleEntity.FieldSortCode);
        }
        else
        {
            dataRows = this.DTModule.Select(BaseModuleEntity.FieldParentId + "=" + treeNode.Value + "", BaseModuleEntity.FieldSortCode);
        }
        foreach (DataRow dataRow in dataRows)
        {
            BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
            // 判断不为空的当前节点的子节点
            if ((treeNode.Value != null) && (treeNode.Value.ToString().Length > 0) && (!(treeNode.Value.Equals(moduleEntity.ParentId.ToString()))))
            {
                continue;
            }
            // 当前节点的子节点, 加载根节点
            if ((moduleEntity.ParentId == null) || ((treeNode.Value != null) && (treeNode.Value.Equals(moduleEntity.ParentId.ToString()))))
            {
                TreeNode newTreeNode = new TreeNode();
                newTreeNode.Text = moduleEntity.FullName;
                newTreeNode.Value = moduleEntity.Id.ToString();
                // 是否已经有这个权限
                newTreeNode.Checked = Array.IndexOf(this.moduleIds, moduleEntity.Id.ToString()) >= 0;
                if ((treeNode.Value == null) || (treeNode.Value.ToString().Length == 0))
                {
                    // 树的根节点加载
                    this.tvModule.Nodes.Add(newTreeNode);
                    newTreeNode.Expanded = false;
                }
                else
                {
                    // 节点的子节点加载
                    treeNode.ChildNodes.Add(newTreeNode);
                    newTreeNode.Expanded = true;
                }
                // 递归调用本函数
                this.LoadTree(newTreeNode);
            }
        }
    }
    #endregion

    /// <summary>
    /// 授权的权限
    /// </summary>
    string GrantPermissions = string.Empty;

    /// <summary>
    /// 撤销的权限
    /// </summary>
    string RevokePermissions = string.Empty;

    private void EntityToArray(TreeNode treeNode)
    {
        if (treeNode.Value != null)
        {
            // 提高运行速度
            string permissionId = treeNode.Value;
            if (treeNode.Checked)
            {
                // 这里是授权的权限
                if (Array.IndexOf(this.moduleIds, permissionId) < 0)
                {
                    this.GrantPermissions += permissionId + ";";
                }
            }
            else
            {
                // 这里是撤销的权限
                if (Array.IndexOf(this.moduleIds, permissionId) >= 0)
                {
                    this.RevokePermissions += permissionId + ";";
                }
            }
        }
        for (int i = 0; i < treeNode.ChildNodes.Count; i++)
        {
            // 这里进行递规操作
            this.EntityToArray(treeNode.ChildNodes[i]);
        }
    }

    #region private bool BatchSavePermission() 批量保存权限设置
    /// <summary>
    /// 批量保存权限设置
    /// </summary>
    private bool BatchSavePermission()
    {
        DotNetService dotNetService = new DotNetService();
        this.moduleIds = dotNetService.PermissionService.GetRoleScopeModuleIds(this.UserInfo, this.RoleId, "Resource.AccessPermission");
        bool returnValue = true;
        for (int i = 0; i < this.tvModule.Nodes.Count; i++)
        {
            this.EntityToArray(this.tvModule.Nodes[i]);
        }
        string[] grantPermissionIds = null;
        string[] revokePermissionIds = null;
        if (this.GrantPermissions.Length > 0)
        {
            this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
            grantPermissionIds = this.GrantPermissions.Split(';');
        }
        if (this.RevokePermissions.Length > 0)
        {
            this.RevokePermissions = this.RevokePermissions.Substring(0, this.RevokePermissions.Length - 1);
            revokePermissionIds = this.RevokePermissions.Split(';');
        }
        this.GrantPermissions = string.Empty;
        this.RevokePermissions = string.Empty;
        dotNetService.PermissionService.GrantRolePermissions(this.UserInfo, new string[] { this.RoleId }, grantPermissionIds);
        dotNetService.PermissionService.RevokeRolePermissions(this.UserInfo, new string[] { this.RoleId }, revokePermissionIds);
        return returnValue;
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // 批量保存权限设置
        this.BatchSavePermission();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}