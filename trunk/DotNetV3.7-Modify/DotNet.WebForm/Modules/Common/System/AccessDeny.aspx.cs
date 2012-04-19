//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccessDeny : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Utilities.DefaultPage);
    }
}