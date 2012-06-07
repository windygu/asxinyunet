/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-17 16:32:39
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;
using NewLife.Web;

public partial class Cube_CustomForm_DataModelForm : MyEntityForm<DataModel>
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        EntityForm.OnGetEntity += new EventHandler<EntityFormEventArgs>(EntityForm_OnGetEntity);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        EntityForm.OnSaving += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaving);
        EntityForm.OnSaveSuccess += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaveSuccess);
        frmName.Enabled = EntityForm.IsNew;
    }

    void EntityForm_OnSaving(object sender, EntityFormEventArgs e)
    {
        if (EntityForm.IsNew)
        {
            // 自定义表单添加的模型，使用表前缀
            Entity.TablePrefix = Entity.Name + "_";
        }
    }

    void EntityForm_OnGetEntity(object sender, EntityFormEventArgs e)
    {
        if (EntityForm.IsNew)
        {
            Int32 n = 0;
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                if (DataModel.FindCount(DataModel._.Name, "Model" + i) < 1)
                {
                    n = i;
                    break;
                }
            }
            Entity.Name = "Model" + n;
            Entity.Description = "模型" + n;
        }
    }

    void EntityForm_OnSaveSuccess(object sender, EntityFormEventArgs e)
    {
        WebHelper.WriteScript("parent.location=parent.location");
    }
}