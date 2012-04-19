//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

public partial class pws : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnPwdReset_Click(object sender, EventArgs e)
    {
        // 重新定位到登录页面
        Page.Response.Redirect("LogOn.aspx");
    }
}