/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-17 16:32:42
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;
using NewLife.Web;

public partial class Cube_CustomForm_ModelTableForm : MyEntityForm<ModelTable>
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        EntityForm.OnGetEntity += new EventHandler<EntityFormEventArgs>(EntityForm_OnGetEntity);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        tag.Visible = btnRenderTempate.Visible = !EntityForm.IsNew;
        //frmName.ReadOnly = !EntityForm.IsNew;
        frmName.Enabled = EntityForm.IsNew;

        EntityForm.OnSaving += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaving);
        EntityForm.OnSaveSuccess += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaveSuccess);
    }

    void EntityForm_OnGetEntity(object sender, EntityFormEventArgs e)
    {
        if (EntityForm.IsNew)
        {
            Int32 n = 0;
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                if (ModelTable.FindCount(ModelTable._.DataModelID == WebHelper.RequestInt("DataModelID") & ModelTable._.Name == "Form" + i, null, null, 0, 0) < 1)
                {
                    n = i;
                    break;
                }
            }
            Entity.Name = "Form" + n;
            Entity.Description = "表单" + n;
        }
    }

    void EntityForm_OnSaving(object sender, EntityFormEventArgs e)
    {
        // 新增表单的时候，增加一个默认的自增ID字段
        if (EntityForm.IsNew)
        {
            Entity.Save();

            ModelColumn mc = ModelColumn.CreateIdentity();
            mc.ModelTableID = Entity.ID;
            mc.Save();

            e.Cancel = true;
        }
    }

    void EntityForm_OnSaveSuccess(object sender, EntityFormEventArgs e)
    {
        WebHelper.WriteScript("parent.location=parent.location");
    }

    protected void btnRenderTempate_Click(object sender, EventArgs e)
    {
        ModelTable table = Entity;
        if (table != null)
        {
            try
            {
                table.RenderTempate();

                WebHelper.Alert("成功！");
            }
            catch (Exception ex)
            {
                WebHelper.Alert("失败！" + ex.Message);
            }
        }
    }
}