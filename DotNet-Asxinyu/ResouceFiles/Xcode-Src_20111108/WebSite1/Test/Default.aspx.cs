using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XCode.Web;
using NewLife.Configuration;

public partial class Test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbRunTimeModule.IsWriteRunTime = true;

        Response.Write(Config.GetConfig<Boolean>("NewLife.Debug").ToString());
    }
}