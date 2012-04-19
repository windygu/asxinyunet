//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utilities.UserIsLogOn())
        {
            Page.Response.Redirect("Work.aspx");
        }
        else
        {
            Page.Response.Redirect("LogOn.aspx");
        }
    }
}