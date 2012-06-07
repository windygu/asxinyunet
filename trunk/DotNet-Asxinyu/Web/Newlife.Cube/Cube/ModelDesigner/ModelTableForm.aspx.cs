/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-17 16:32:42
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using XCode.DataAccessLayer;
using NewLife.Web;

public partial class Cube_ModelTableForm : MyEntityForm
{
    /// <summary>实体类型</summary>
    public override Type EntityType { get { return typeof(ModelTable); } set { base.EntityType = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        tag.Visible = WebHelper.RequestInt("ModelTableID") > 0;
    }

    protected override void OnPreLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            frmDbType.DataSource = EnumHelper.GetDescriptions(typeof(DatabaseType));
            frmDbType.DataValueField = "key";
            frmDbType.DataTextField = "value";
            frmDbType.DataBind();
        }

        base.OnPreLoad(e);
    }
}