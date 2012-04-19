//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

/// <summary>
/// RoleEdit
/// 编辑角色
///
/// 修改纪录
///
///		2011-04-25 版本：1.0 JiRiGaLa 创建主键。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011-04-25</date>
/// </author>
/// </summary>
public partial class RoleEdit : BasePage
{
    /// <summary>
    /// 主键
    /// </summary>
    private string EntityId
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
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 每次都判断是否登录，防止登录过期了，若有判断权限了，自然就判断是否登录了
        // Utilities.CheckIsLogOn();
        // 判断是否有添加角色权限
        this.Authorized("RoleAdmin.Edit");
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
    }
    #endregion

    /// <summary>
    /// 读取屏幕数据
    /// </summary>
    /// <returns>角色实体</returns>
    private BaseRoleEntity GetEntity()
    {
        BaseRoleEntity roleEntity = new BaseRoleEntity();
        roleEntity.RealName = this.txtRealname.Text;
        roleEntity.Code = this.txtCode.Text;
        roleEntity.Description = this.txtDescription.Text;
        roleEntity.Enabled = 1;
        roleEntity.AllowDelete = 1;
        roleEntity.AllowEdit = 1;
        roleEntity.DeletionStateCode = 0;
        return roleEntity;
    }

    #region private bool CheckInput() 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <returns>是否输入正确</returns>
    private bool CheckInput()
    {
        string checkInput = String.Empty;
        // 检查角色编号
        if (string.IsNullOrEmpty(this.txtCode.Text))
        {
            checkInput = "<script>alert('提示信息：请输入角色编号。');document.all['" + this.txtCode.ClientID + "'].focus();</script>";
            Page.RegisterStartupScript("checkInput", checkInput);
            return false;
        }
        // 检查角色名称
        if (string.IsNullOrEmpty(this.txtRealname.Text))
        {
            checkInput = "<script>alert('提示信息：请输入角色名称。');document.all['" + this.txtRealname.ClientID + "'].focus();</script>";
            Page.RegisterStartupScript("checkInput", checkInput);
            return false;
        }
        return true;
    }
    #endregion

    /// <summary>
    /// 添加角色
    /// </summary>
    private void AddEntity()
    {
        if (this.CheckInput())
        {
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BaseRoleEntity roleEntity = this.GetEntity();
            DotNetService dotNetService = new DotNetService();
            dotNetService.RoleService.Add(this.UserInfo, roleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    ScriptUtil.AlertAndRedirect(statusMessage, this.ReturnURL);
                }
            }
            else
            {
                string checkInput = string.Empty;
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    ScriptUtil.Alert(statusMessage);
                    checkInput = "<script>document.all['" + this.txtCode.ClientID + "'].focus();document.all['" + this.txtCode.ClientID + "'].select();</script>";
                    Page.RegisterStartupScript("checkInput", checkInput);

                }
                else if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    ScriptUtil.Alert(statusMessage);
                    checkInput = "<script>document.all['" + this.txtRealname.ClientID + "'].focus();document.all['" + this.txtRealname.ClientID + "'].select();</script>";
                    Page.RegisterStartupScript("checkInput", checkInput);
                }
                else
                {
                    ScriptUtil.Alert(statusMessage);
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.AddEntity();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}