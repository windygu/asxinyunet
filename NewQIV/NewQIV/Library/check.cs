﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// check 的摘要说明
/// </summary>
public class check
{
    public check()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static void checkUser(object s)
    {
        if (s == null)
            cn.buddy.FuncCommon.TopGoToURL("../index.htm");
    }
    public static void checkAdmin(object s)
    {
        if (s == null)
            cn.buddy.FuncCommon.TopGoToURL("../index.htm");
    }
}