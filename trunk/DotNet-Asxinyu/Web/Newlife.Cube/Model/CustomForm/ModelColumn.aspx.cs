/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-09 17:07:38
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;

public partial class Cube_CustomForm_ModelColumn : MyEntityList
{
    /// <summary>实体类型</summary>
    public override Type EntityType { get { return typeof(ModelColumn); } set { base.EntityType = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            ModelColumn entity = ModelColumn.FindByID(Convert.ToInt32(e.CommandArgument));
            if (entity != null)
            {
                entity.Up();
                gv.DataBind();

                // 如果不出错，重新生成模版
                entity.ModelTable.RenderTempate();
            }
        }
        else if (e.CommandName == "Down")
        {
            ModelColumn entity = ModelColumn.FindByID(Convert.ToInt32(e.CommandArgument));
            if (entity != null)
            {
                entity.Down();
                gv.DataBind();

                // 如果不出错，重新生成模版
                entity.ModelTable.RenderTempate();
            }
        }
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ModelColumn mc = e.Row.DataItem as ModelColumn;
            // 自增列，隐藏最后的编辑和删除
            if (mc != null && mc.Identity)
            {
                e.Row.Cells[e.Row.Cells.Count - 2].Visible = false;
                e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
            }
        }
    }
}