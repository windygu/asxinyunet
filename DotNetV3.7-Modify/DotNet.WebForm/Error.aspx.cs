//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtErrorMsg.Text = Application["error"].ToString();
        lblStackInfo.Text = Application["errorStack"].ToString();
    }
}
