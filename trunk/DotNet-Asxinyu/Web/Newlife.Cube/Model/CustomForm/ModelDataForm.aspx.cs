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
using XCode;
using XCode.Accessors;
using System.Web.UI;

public partial class Cube_CustomForm_ModelDataForm : MyEntityForm
{
    private ModelTable _Table;
    /// <summary>模型表</summary>
    public ModelTable Table
    {
        get
        {
            if (_Table == null)
            {
                Int32 id = WebHelper.RequestInt("ModelTableID");
                if (id > 0) _Table = ModelTable.FindByID(id);
            }
            return _Table;
        }
    }

    public override Type EntityType
    {
        get { return Table.CreateOperate().Default.GetType(); }
        set { base.EntityType = value; }
    }

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        EntityForm.OnSaving += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaving);
    }

    void EntityForm_OnSaving(object sender, EntityFormEventArgs e)
    {
        //throw new NotImplementedException();
    }

    protected override void OnPreLoad(EventArgs e)
    {
        // 在实体表单处理之前必须完成表单的控件初始化
        ModelTable table = Table;
        if (table != null && !String.IsNullOrEmpty(table.Template))
        {
            Control control = ParseControl(table.Template);
            if (control != null) PlaceHolder1.Controls.Add(control);
        }

        base.OnPreLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //protected override void OnPreRender(EventArgs e)
    //{
    //    // 这里处理回发，因为Load阶段加载控件，那时候拿不到返回值
    //    if (IsPostBack)
    //    {
    //        ModelTable table = Table;
    //        if (table != null)
    //        {
    //            try
    //            {
    //                IEntityOperate eop = table.CreateOperate();
    //                IEntityAccessor ea = EntityAccessorFactory.Create(EntityAccessorTypes.WebForm);
    //                ea.SetConfig(EntityAccessorOptions.Container, this);
    //                IEntity entity = eop.Create(false);
    //                ea.Read(entity, eop);
    //                entity.Insert();

    //                WebHelper.Alert("成功！");
    //            }
    //            catch (Exception ex)
    //            {
    //                WebHelper.Alert("失败！" + ex.Message);
    //            }
    //        }
    //    }

    //    base.OnPreRender(e);
    //}
}