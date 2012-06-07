/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-17 16:32:39
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Reflection;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Cube;
using NewLife.Cube.Entities;
using NewLife.Cube.Templating;
using NewLife.Log;
using NewLife.Web;
using System.Web.UI;
using System.Text;

public partial class Cube_ModelManage_StaticRenderForm : MyEntityForm<DataModel>
{
    private TemplateConfig _Config;
    /// <summary>模版配置</summary>
    public TemplateConfig Config
    {
        get
        {
            if (_Config == null)
            {
                _Config = TemplateConfig.LoadOrDefault(Entity.RenderConfig);
                String name = !String.IsNullOrEmpty(Entity.ConnNameEx) ? Entity.ConnNameEx : Entity.Name;
                if (String.IsNullOrEmpty(_Config.EntityConnName)) _Config.EntityConnName = name;
                // 配置为空，表示这是默认配置，设置一些默认值
                if (String.IsNullOrEmpty(Entity.RenderConfig))
                {
                    if (!String.IsNullOrEmpty(Entity.NameSpace)) _Config.NameSpace = Entity.NameSpace;
                    if (!String.IsNullOrEmpty(name))
                    {
                        _Config.NameSpace = String.Format("NewLife.{0}.Entities", name);
                        _Config.OutputPath = String.Format("../NewLife.{0}/Entities", name);
                        _Config.UseHeadTemplate = true;
                    }
                }
            }
            return _Config;
        }
        set { _Config = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 绑定模版
            cfgTemplateName.DataSource = TemplateHelper.GetStaticTemplates();
            cfgTemplateName.DataTextField = "Key";
            cfgTemplateName.DataValueField = "Key";
            cfgTemplateName.DataBind();

            SetConfig(Config);
        }
        else
        {
            GetConfig(Config);

            Entity.RenderConfig = Config.ToXml();
            Entity.Save();
        }
    }

    void SetConfig(TemplateConfig config)
    {
        foreach (PropertyInfo item in config.GetType().GetProperties())
        {
            Control control = ControlHelper.FindControlByField<Control>(Page, "cfg" + item.Name);
            if (control is ListControl)
            {
                ListControl lc = control as ListControl;
                if (lc != null) lc.SelectedValue = "" + item.GetValue(config, null);
            }
            else if (control is CheckBox)
            {
                CheckBox box = control as CheckBox;
                if (box != null) box.Checked = (Boolean)item.GetValue(config, null);
            }
            else
            {
                TextBox box = control as TextBox;
                if (box != null) box.Text = "" + item.GetValue(config, null);
            }
        }
    }

    void GetConfig(TemplateConfig config)
    {
        foreach (PropertyInfo item in config.GetType().GetProperties())
        {
            Control control = ControlHelper.FindControlByField<Control>(Page, "cfg" + item.Name);
            if (control is ListControl)
            {
                ListControl lc = control as ListControl;
                if (lc != null) item.SetValue(config, lc.SelectedValue, null);
            }
            else if (control is CheckBox)
            {
                CheckBox box = control as CheckBox;
                if (box != null) item.SetValue(config, box.Checked, null);
            }
            else
            {
                TextBox box = control as TextBox;
                if (box != null) item.SetValue(config, box.Text, null);
            }
        }
    }

    protected void btnRender_Click(object sender, EventArgs e)
    {
        #region 参数检查
        Int32[] ids = gvExt.SelectedIntValues;
        if (ids == null || ids.Length < 1)
        {
            WebHelper.Alert("请选择要生成的模型表！");
            return;
        }

        if (String.IsNullOrEmpty(Config.TemplateName))
        {
            WebHelper.Alert("请选择模版！");
            return;
        }

        if (String.IsNullOrEmpty(Config.NameSpace))
        {
            WebHelper.Alert("请设置命名空间！");
            return;
        }

        if (String.IsNullOrEmpty(Config.EntityConnName))
        {
            WebHelper.Alert("请设置连接名！");
            return;
        }

        if (String.IsNullOrEmpty(Config.OutputPath))
        {
            WebHelper.Alert("请设置输出目录！");
            return;
        }
        #endregion

        try
        {
            Engine engine = new Engine(Config);
            engine.Model = Entity;

            StringBuilder sb = new StringBuilder();
            foreach (Int32 item in ids)
            {
                ModelTable table = ModelTable.FindByID(item);
                if (table != null)
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.Append(table.DisplayName);

                    engine.Render(table);
                }
            }

            WebHelper.Alert("成功！" + sb);
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);

            WebHelper.Alert("失败！" + ex.Message);
        }
    }

    protected void btnReleaseEmbedTemplates_Click(object sender, EventArgs e)
    {
        try
        {
            TemplateHelper.ReleaseEmbedTemplates();

            WebHelper.Alert("成功！");
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);

            WebHelper.Alert("失败！" + ex.Message);
        }
    }
}