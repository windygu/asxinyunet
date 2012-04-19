//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// ChangePassword
/// 修改密码
///
/// 修改记录
///
///     2009.11.19 版本：2.1  JiRiGaLa 函数名称、返回值进行优化处理。
///     2007.11.30 版本：2.0  JiRiGaLa 重新整理代码。
///     2007.01.18 版本：1.2  JiRiGaLa 重新整理代码。
///     2006.12.19 版本：1.1  JiRiGaLa
///		2006.12.18 版本：1.0  JiRiGaLa
///		
/// 版本：2.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2007.11.30</date>
/// </author> 
/// </remarks>
public partial class ChangePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            // 获取操作员信息
            this.GetUserInfo();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    #region private void GetUserInfo() 获取操作员信息
    /// <summary>
    /// 获取操作员信息
    /// </summary>
    private void GetUserInfo()
    {
        this.lblUserName.Text = this.UserInfo.UserName;
        this.lblFullName.Text = this.UserInfo.RealName;
        this.lblDepartmentName.Text = this.UserInfo.DepartmentName;
    }
    #endregion

    #region private void SetAttributes() 绑定客户端的代码
    /// <summary>
    /// 绑定客户端的代码
    /// </summary>
    private void SetAttributes()
    {
        this.btnConfirm.Attributes.Add("OnClick", "return CheckInput(" + BaseSystemInfo.CheckPasswordStrength.ToString().ToLower() + ");");
    }
    #endregion

    #region private bool CheckInput(string oldPassword, string newPassword, string confirmPassword) 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <param name="oldPassword">原始密码</param>
    /// <param name="newPassword">新密码</param>
    /// <param name="confirmPassword">确认密码</param>
    /// <returns>是否成功</returns>
    private bool CheckInput(string oldPassword, string newPassword, string confirmPassword)
    {
        string checkInput = string.Empty;
        // 密码验证
        if (!BaseSystemInfo.CheckPasswordStrength)
        {
            if (oldPassword.Length == 0)
            {
                checkInput = "<script>alert('提示信息：原始密码不能为空。');document.all['txtOldPassword'].focus();</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
                return false;
            }
            if (newPassword.Length == 0)
            {
                checkInput = "<script>alert('提示信息：新密码不能为空。');document.all['txtNewPassword'].focus();</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
                return false;
            }
            if (confirmPassword.Length == 0)
            {
                checkInput = "<script>alert('提示信息：确认密码不能为空。');document.all['txtConfirmPassword'].focus();</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
                return false;
            }
        }
        if (newPassword != confirmPassword)
        {
            checkInput = "<script>alert('提示信息：新密码跟确认密码不同。');document.all['txtNewPassword'].focus();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
            return false;
        }
        return true;
    }
    #endregion

    #region private void UserChangePassword() 更改密码
    /// <summary>
    /// 更改密码
    /// </summary>
    private void UserChangePassword()
    {
        int returnValue = 0;
        // 赋值
        string oldPassword = this.txtOldPassword.Text;
        string newPassword = this.txtNewPassword.Text;
        string confirmPassword = this.txtConfirmPassword.Text;
        // 密码验证
        if (!this.CheckInput(oldPassword, newPassword, confirmPassword))
        {
            return;
        }
        // 更新数据
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            string statusCode = string.Empty;
            returnValue = userManager.ChangePassword(oldPassword, newPassword, out statusCode);
            string statusMessage = userManager.GetStateMessage(statusCode);
            // 判断操作结果
            Page.ClientScript.RegisterStartupScript(this.GetType(), "retutnInformation", "<script>alert('" + statusMessage + "');</script>");
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        // 更改密码
        this.UserChangePassword();
    }

    protected void btnUserInfo_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("UserInfo.aspx");
    }
}