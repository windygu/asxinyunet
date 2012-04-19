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

/// <remarks>
/// Register
/// 注册
///		
/// 修改记录
///
///		2008.12.19 版本：1.0 JiRiGaLa 建立代码。 
///		
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2008.12.19</date>
/// </author> 
/// </remarks>
public partial class Registration : BasePage
{
    /// <summary>
    /// 注册用户需要审核
    /// </summary>
    private bool CheckRegisterUser = false;

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
        if (Page.Request["Role"] != null)
        {
            this.cmbRole.SelectedValue = Page.Request["Role"].ToString();
        }
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnReturn.Visible = !string.IsNullOrEmpty(this.ReturnURL);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DoPageLoad();
            this.txtUserName.Focus();
        }
    }

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        // 添加一项提示项
        ListItem listItem = new ListItem("请选择用户角色");
        // this.cmbRole.Items.Add(new ListItem() { Text = "请选择用户角色" });
        this.cmbRole.Items.Add(listItem);
        this.cmbRole.AppendDataBoundItems = true;
        DotNetService dotNetService = new DotNetService();
        DataTable dataTable = dotNetService.RoleService.GetDataTable(this.UserInfo);
        // 绑定角色
        this.cmbRole.DataSource = dataTable;
        this.cmbRole.DataTextField = BaseRoleEntity.FieldRealName;
        this.cmbRole.DataValueField = BaseRoleEntity.FieldId;
        this.cmbRole.DataBind();
    }
    #endregion

    #region private bool CheckInput() 检查页面输入
    /// <summary>
    /// 检查页面输入
    /// </summary>
    /// <returns>是否正确</returns>
    private bool CheckInput()
    {
        bool returnValue = true;
        string checkInput = string.Empty;
        if (this.txtUserName.Text.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息:请输入用户名。'); document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        if (this.txtPassword.Text.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息:请输入密码。'); document.getElementById('" + this.txtPassword.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        if (!this.txtPassword.Text.Trim().Equals(this.txtConfirmPassword.Text.Trim()))
        {
            checkInput = "<script>alert('提示信息:确认密码不正确，请重新输入。'); document.getElementById('" + this.txtConfirmPassword.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        if (this.txtEmail.Text.Trim().Length > 0)
        {
            if (!ValidateUtil.IsEmail(this.txtEmail.Text.Trim()))
            {
                checkInput = "<script>alert('提示信息：E_mail 格式不正确，请重新输入。'); document.getElementById('" + this.txtEmail.ClientID + "').focus();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
                return false;
            }
        }
        if (this.cmbRole.SelectedIndex < 1)
        {
            checkInput = "<script>alert('提示信息：请选择默认用户角色。');document.getElementById('" + this.cmbRole.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        return returnValue;
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        this.GetItemDetails();
        this.GetParamter();
        this.SetControlState();
    }
    #endregion

    #region private BaseUserEntity GetUserEntity() 获取用户注册信息
    /// <summary>
    /// 获取用户注册信息
    /// </summary>
    /// <returns>用户实体</returns>
    private BaseUserEntity GetUserEntity()
    {
        BaseUserEntity userEntity = new BaseUserEntity();
        userEntity.UserName = this.txtUserName.Text;
        userEntity.UserPassword = this.txtPassword.Text;
        userEntity.RealName = this.txtRealName.Text;
        userEntity.RoleId = this.cmbRole.SelectedValue;
        userEntity.Email = this.txtEmail.Text;
        userEntity.Description = this.txtDescription.Text;
        userEntity.Enabled = CheckRegisterUser ? 0 : 1;
        if (CheckRegisterUser)
        {
            userEntity.AuditStatus = AuditStatus.WaitForAudit.ToString();
        }
        return userEntity;
    }
    #endregion

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        this.lblPrompt.Text = string.Empty;
        if (this.CheckInput())
        {
            try
            {
                string returnStatusCode = string.Empty;
                string returnStatusMessage = string.Empty;
                // 默认是需要审核
                BaseUserEntity userEntity = this.GetUserEntity();
                DotNetService dotNetService = new DotNetService();
                dotNetService.UserService.AddUser(this.UserInfo, userEntity, out returnStatusCode, out returnStatusMessage);
                // 注册结果
                if (returnStatusCode.Equals(StatusCode.OKAdd.ToString()))
                {
                    this.lblPrompt.Text = returnStatusMessage;
                    ScriptUtil.AlertAndRedirect(returnStatusMessage, this.ReturnURL);
                }
                else
                {
                    this.lblPrompt.Text = returnStatusMessage;
                    string checkInput = "<script>document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
                }
            }
            catch (Exception ex)
            {
                this.lblPrompt.Text = ex.Message;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("LossOfAccount.aspx");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}