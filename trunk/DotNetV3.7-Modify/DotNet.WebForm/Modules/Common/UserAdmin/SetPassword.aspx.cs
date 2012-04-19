//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// SetPassword
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
public partial class SetPassword : BasePage
{
    /// <summary>
    /// 用户ID
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
        this.GetParamter();
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

    #region private bool CheckInput(string paramNewPassword, string paramConfirmPassword) 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <param name="paramNewPassword">新密码</param>
    /// <param name="paramConfirmPassword">确认密码</param>
    /// <returns>是否成功</returns>
    private bool CheckInput(string newPassword, string confirmPassword)
    {
        string checkInput = string.Empty;
        // 密码验证
        if (!BaseSystemInfo.CheckPasswordStrength)
        {
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

    #region private void BatchSetPassword() 设置密码
    /// <summary>
    /// 设置密码
    /// </summary>
    private void BatchSetPassword()
    {
        int returnValue = 0;
        // 赋值
        string newPassword = this.txtNewPassword.Text;
        string confirmPassword = this.txtConfirmPassword.Text;
        // 密码验证
        if (!this.CheckInput(newPassword, confirmPassword))
        {
            return;
        }
        // 更新数据
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            string statusCode = string.Empty;
            string[] ids = this.UserId.Split(',');
            returnValue = userManager.BatchSetPassword(ids, newPassword);
            statusCode = userManager.ReturnStatusCode;
            string statusMessage = userManager.GetStateMessage(statusCode);
            // 判断操作结果
            Page.ClientScript.RegisterStartupScript(this.GetType(), "setPassword", "<script>alert('" + statusMessage + "');</script>");
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
        // 设置密码
        this.BatchSetPassword();
    }

    protected void btnUserInfo_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("UserInfo.aspx");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}