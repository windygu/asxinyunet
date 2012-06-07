/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-09 10:35:15
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;

public partial class Cube_ModelColumnForm : MyEntityForm<ModelColumn>
{
    protected override void OnPreLoad(EventArgs e)
    {
        // 必须在预加载之前绑定，否则没有数据
        if (!IsPostBack)
        {
            frmControl.DataSource = EnumHelper.GetDescriptions<ControlTypes>();
            frmControl.DataBind();
        }

        base.OnPreLoad(e);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}