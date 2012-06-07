/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-09 10:35:15
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;
using NewLife.Web;
using NewLife.Log;

public partial class Cube_CustomForm_ModelColumnForm : MyEntityForm<ModelColumn>
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        EntityForm.OnGetEntity += new EventHandler<EntityFormEventArgs>(EntityForm_OnGetEntity);
    }

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
        if (Entity.Identity) WebHelper.AlertAndClose("禁止修改默认字段！");

        EntityForm.OnSaveSuccess += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaveSuccess);
        frmName.Enabled = EntityForm.IsNew;
    }

    void EntityForm_OnGetEntity(object sender, EntityFormEventArgs e)
    {
        if (EntityForm.IsNew)
        {
            Entity.ModelTableID = WebHelper.RequestInt("ModelTableID");
            Entity.InitDefault();
        }
    }

    void EntityForm_OnSaveSuccess(object sender, EntityFormEventArgs e)
    {
        // 重新生成模版
        try
        {
            Entity.ModelTable.RenderTempate();
            Entity.ModelTable.DataModel.RebuildAssembly();
            Entity.ModelTable.DataModel.RebuildTables();
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);
        }

        WebHelper.WriteScript("parent.location=parent.location");
    }
}