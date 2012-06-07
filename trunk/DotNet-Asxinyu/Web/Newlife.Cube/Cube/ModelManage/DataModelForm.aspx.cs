/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-17 16:32:39
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Log;
using NewLife.Web;
using NewLife.Cube.Templating;

public partial class Cube_DataModelForm : MyEntityForm<DataModel>
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        Boolean hasMyTemplate = !String.IsNullOrEmpty(Entity.TemplatePath);
        btnCopy.Visible = !hasMyTemplate;

        ////Boolean hasDb = DbTemplateProvider.Instance.Exists(Entity.TemplatePathEx);
        //Boolean hasFile = FileTemplateProvider.Instance.Exists(Entity.TemplatePathEx);
        ////btnExport.Visible = hasDb;
        //btnImport.Visible = hasFile;

        //btnExport.OnClientClick = hasFile ? "return confirm(\"目标模板文件存在，导出将覆盖目标模板！\\n确定导出吗？\")" : null;
        ////btnImport.OnClientClick = hasDb ? "return confirm(\"目标数据库模板存在，导入将覆盖目标模板！\\n确定导入吗？\")" : null;
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        try
        {
            Entity.CopyTemplate();

            frmTemplatePath.Text = Entity.TemplatePath;
            btnCopy.Visible = false;

            WebHelper.Alert("操作成功！");
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);

            WebHelper.Alert("复制模版失败！" + ex.Message);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Entity.ExportTemplate();

            WebHelper.Alert("操作成功！");
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);

            WebHelper.Alert("导出模版失败！" + ex.Message);
        }
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            Entity.ImportTemplate();

            WebHelper.Alert("操作成功！");
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);

            WebHelper.Alert("导入模版失败！" + ex.Message);
        }
    }
}