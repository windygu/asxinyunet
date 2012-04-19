//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web;
using System.Web.UI;

using DotNet.Utilities;

/// <summary>
/// LogOn
/// 登录系统
///
/// 修改纪录
///
///		2012-01-29 版本：1.0 JiRiGaLa 整理实现多系统的统一登录功能。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012-01-29</date>
/// </author>
/// </summary>
public partial class LogOn : Page
{
    #region public string ReturnURL 目的跳转页面
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
    #endregion

    #region public void GetParameters() 获得页面参数
    /// <summary>
    /// 获得页面参数
    /// </summary>
    public void GetParameter()
    {
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"];
        }
        else
        {
            if (Request.UrlReferrer != null)
            {
                // 不是本页面时
                if (!(Request.UrlReferrer.ToString().ToUpper().IndexOf("LOGON.ASPX") > 0)
                    && !(Request.UrlReferrer.ToString().ToUpper().IndexOf("LOGOUT.ASPX") > 0)
                    && !(Request.UrlReferrer.ToString().ToUpper().IndexOf("LOGOUTING.ASPX") > 0))
                {
                    this.ReturnURL = Request.UrlReferrer.ToString();
                }
            }
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 设置为保存密码，默认是不保存密码
        Utilities.GetConfiguration();
        this.GetParameter();
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            this.txtUserName.Value = Request.QueryString["UserName"];
        }
        else
        {
            BaseUserInfo userInfo = Utilities.CheckCookie();
            if (userInfo != null)
            {
                // 其实这里表明已经成功登录了，现在是允许重复登录才好一些，这样系统出错的概率会少很多
            }
        }
        // 焦点是停留在哪里的设置
        if (string.IsNullOrEmpty(this.txtUserName.Value))
        {
            this.txtUserName.Focus();
        }
        else
        {
            this.txtPassword.Focus();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 设置为保存密码，默认是不保存密码
        // this.cbRemember.Checked = BaseSystemInfo.SavePassword;
        if (!Page.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    private void UserLogOn()
    {
        string userName = this.txtUserName.Value;
        string password = this.txtPassword.Value;
        this.UserLogOn(userName, password);
    }

    /// <summary>
    /// 用户的登录操作
    /// </summary>
    private void UserLogOn(string userName, string password)
    {
        string checkInput = string.Empty;
        try
        {
            string returnStatusCode = string.Empty;
            string returnStatusMessage = string.Empty;

            // 有什么权限的人才可以登录到系统
            string permissionItemCode = string.Empty;
            // permissionItemCode = "Project.Admin.Access";

            // 登录验证
            Utilities.LogOn(userName, password, permissionItemCode, this.chkPersistCookie.Checked, false, out returnStatusCode, out returnStatusMessage);
            
            // txtVerifyCode.Text = string.Empty;
            // 登录结果
            if (returnStatusCode.Equals(StatusCode.OK.ToString()))
            {
                // this.AfterLogOn();
                // 登录成功,重新定向到跳转的页面
                //异常:{由于代码已经过优化或者本机框架位于调用堆栈之上，无法计算表达式的值。}_
                //Page.Response.Redirect(this.ReturnURL);
                Response.Redirect(this.ReturnURL, false);
            }
            else
            {
                checkInput = "<script>alert('提示信息：" + returnStatusMessage + "');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
                this.txtUserName.Focus();
            }
        }
        catch (System.Exception exception)
        {
            checkInput = "<script>alert('提示信息：登录失败，请检查你的用户名和密码是否输入有误。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
            this.txtUserName.Focus();
        }
    }

    protected void btnLogOn_Click(object sender, EventArgs e)
    {
        // 用户的登录操作
        /*为了登录方便暂时屏蔽
         * if (string.IsNullOrEmpty(this.txtUserName.Value.Trim()) || string.IsNullOrEmpty(this.txtPassword.Value.Trim()))
        {
            ScriptUtil.Alert("用户名和密码不能为空。");
            return;
        }*/

        /*
        string verifyCode = this.txtVerifyCode.Text;
        if (String.Compare(Session["VerifyCode"].ToString(), verifyCode, true) != 0)
        {
            txtVerifyCode.Text = "";
            txtPassword.Focus();
            ScriptUtil.Alert("验证码错误，请输入正确的验证码。");
            return;
        }
        */
        this.UserLogOn();
    }
}