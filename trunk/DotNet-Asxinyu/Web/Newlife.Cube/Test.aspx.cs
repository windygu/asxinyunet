using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using NewLife.Log;
using System.Threading;
using NewLife.Configuration;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 n = Config.GetMutilConfig<Int32>(-2, "XCode.Cache.Expiration", "XCacheExpiration");
        Response.Write(n);
    }
}