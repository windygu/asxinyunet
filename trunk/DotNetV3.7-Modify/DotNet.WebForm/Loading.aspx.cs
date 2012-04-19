//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loading : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected string GetRedirectUrl()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["RedirectUrl"]))
        {
            return Convert.ToString(Request.QueryString["RedirectUrl"]);
        }
        return string.Empty;
    }
}