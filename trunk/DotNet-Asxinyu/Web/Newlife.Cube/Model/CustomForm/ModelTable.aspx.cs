/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-09 17:07:38
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;

public partial class Cube_CustomForm_ModelTable : MyEntityList<ModelTable>
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            ModelTable entity = ModelTable.FindByID(Convert.ToInt32(e.CommandArgument));
            if (entity != null)
            {
                entity.Up();
                gv.DataBind();
            }
        }
        else if (e.CommandName == "Down")
        {
            ModelTable entity = ModelTable.FindByID(Convert.ToInt32(e.CommandArgument));
            if (entity != null)
            {
                entity.Down();
                gv.DataBind();
            }
        }
    }
}