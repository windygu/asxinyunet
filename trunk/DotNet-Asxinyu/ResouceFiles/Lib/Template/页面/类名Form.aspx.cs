﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Web;
using XControl;
using <#=Config.NameSpace#>;

public partial class Pages_<#=Table.Alias#>Form : EntityForm<Int32, <#=Table.Alias#>>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}