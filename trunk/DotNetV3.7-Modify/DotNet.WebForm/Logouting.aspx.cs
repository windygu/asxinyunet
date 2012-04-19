//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.Security;
using System.Web.UI;

public partial class LogOuting : System.Web.UI.Page
{
    // 提示框标题
    protected string Mtitle = "提示信息";

    // 提示框内容
    protected string Mbody = "安全退出本次登录。";

    // 提示框内容
    protected string MessageType = "MessageOk";

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["MessageType"] != null)
        {
            MessageType = Page.Request["MessageType"].ToString();
        }
        if (Page.Request["Mtitle"] != null)
        {
            Mtitle = Page.Request["Mtitle"].ToString();
        }
        if (Page.Request["Mbody"] != null)
        {
            Mbody = Page.Request["Mbody"].ToString();
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
            // 读取参数
            this.GetParamter();
            if (MessageType.Equals("MessageError"))
            {
                this.imgMassage.ImageUrl = "Themes/Blue/Images/MessageIcon/MessageError.gif";
            }
            else if (MessageType.Equals("MessageAlert"))
            {
                this.imgMassage.ImageUrl = "Themes/Blue/Images/MessageIcon/MessageAlert.gif";
            }
            else
            {
                this.imgMassage.ImageUrl = "Themes/Blue/Images/MessageIcon/MessageOk.gif";
            }
            // 退出登录
            Utilities.Logout();
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtReturnURL.Value))
        {
            // 跳转页面
            Page.Response.Redirect(this.txtReturnURL.Value);
        }
    }
}