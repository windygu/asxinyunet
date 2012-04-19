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

public partial class UserEdit : BasePage
{
    /// <summary>
    /// 用户主键
    /// </summary>
    private string UserId
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

    /// <summary>
    /// 用户详细地址
    /// </summary>
    private string UserAddressID
    {
        get
        {
            return this.txtUserAddressID.Value;
        }
        set
        {
            this.txtUserAddressID.Value = value;
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
            this.UserId = Page.Request["ID"].ToString();
        }
        else
        {
            this.Page.Response.Redirect(Utilities.DefaultPage);
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
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
        if (this.txtUserName.Text.Length == 0)
        {
            checkInput = "<script>alert('提示信息:请输入用户名。'); document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        if (this.ddlUserRole.SelectedIndex < 1)
        {
            checkInput = "<script>alert('提示信息:请选择默认用户角色。');document.getElementById('" + this.ddlUserRole.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        return returnValue;
    }
    #endregion

    #region private void GetRoles() 获取角色列表
    /// <summary>
    /// 获取角色列表
    /// </summary>
    private void GetRoles()
    {
        // 绑定类型数据
        DotNetService dotNetService = new DotNetService();
        DataTable dataTable = dotNetService.RoleService.GetDataTable(this.UserInfo);
        DataRow dataRow = dataTable.NewRow();
        dataTable.Rows.InsertAt(dataRow, 0);
        this.ddlUserRole.DataTextField = BaseRoleEntity.FieldRealName;
        this.ddlUserRole.DataValueField = BaseRoleEntity.FieldId;
        this.ddlUserRole.DataSource = dataTable.DefaultView;
        this.ddlUserRole.DataBind();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    #region private void ShowEntity() 显示用户数据
    /// <summary>
    /// 显示用户数据
    /// </summary>
    private void ShowEntity()
    {
        // 读取类属性
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper);
        BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
        // 在页面上显示
        this.txtUserName.Text = userEntity.UserName;
        this.txtRealname.Text = userEntity.RealName;
        this.ddlUserRole.SelectedValue = userEntity.RoleId == null ? string.Empty : userEntity.RoleId.ToString();
        this.txtBirthday.Text = userEntity.Birthday;
        this.txtDescription.Text = userEntity.Description;
        this.txtEmail.Text = userEntity.Email;
        this.txtMobile.Text = userEntity.Mobile;
        this.txtQQ.Text = userEntity.OICQ;
        this.rdblGender.SelectedValue = userEntity.Gender;
        this.cnkSelect.Checked = userEntity.Enabled.Equals("1");
        this.ShowUserAddress(userEntity.UserAddressId);
        // 判断数据是否被其他人删除
        if (userEntity.Id != null)
        {
            this.lblPrompt.Text = AppMessage.MSG0005;
        }
    }
    #endregion

    private void ShowUserAddress(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            BaseUserAddressManager userAddressManager = new BaseUserAddressManager(this.UserCenterDbHelper);
            BaseUserAddressEntity userAddressEntity = userAddressManager.GetEntity(id);
            this.txtAddress.Text = userAddressEntity.Address;
            this.txtFax.Text = userAddressEntity.Fax;
            this.txtPostCode.Text = userAddressEntity.PostCode;
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        // 绑定下拉框
        this.GetRoles();
        // 显示内容
        this.UserCenterDbHelper.Open();
        this.ShowEntity();
        this.UserCenterDbHelper.Close();
        // 焦点
        this.txtUserName.Focus();
    }
    #endregion

    #region private bool SaveEntity() 保存
    /// <summary>
    /// 保存
    /// </summary>
    /// <returns>成功</returns>
    private void SaveEntity()
    {
        try
        {
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            string role = string.Empty;
            if (this.ddlUserRole.SelectedValue != null)
            {
                role = this.ddlUserRole.SelectedValue.ToString();
            }
            // 更新到数据库
            BaseUserEntity userEntity = new BaseUserEntity();
            // DotNetService.Instance.UserService.UpdateUser(this.UserInfo, this.UserId, this.txtUserName.Text, this.txtRealname.Text, string.Empty, role, string.Empty, this.cnkSelect.Checked, out statusCode, out statusMessage);
            DotNetService dotNetService = new DotNetService();
            dotNetService.UserService.UpdateUser(this.UserInfo, userEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 保存成功，进行提示
                    this.lblPrompt.Text = "提示信息：保存成功。";
                }
            }
            else
            {
                this.lblPrompt.Text = AppMessage.MSG0000;
                string checkInput = "<script>document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            }
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.CheckInput())
        {
            this.SaveEntity();
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}