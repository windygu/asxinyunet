using System;
using System.IO;
using NewLife.Cube;
using NewLife.Web;

public partial class Cube_ModelManage_TemplateItem : MyEntityList
{
    /// <summary>模版名</summary>
    public String Name { get { return Request["Template"]; } }

    String GetTemplateItem()
    {
        String item = Request["Item"];
        if (!String.IsNullOrEmpty(item))
        {
            String path = TemplateHelper.GetFullPath(Name);
            return Path.Combine(path, item);
        }

        return null;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Name)) Response.Redirect("Template.aspx");

        //Template tp = TemplateHelper.GetTemplateEngine(Name);
        //if (tp == null) WebHelper.AlertAndEnd("模版[" + Name + "]不存在！");
        if (!Directory.Exists(TemplateHelper.GetFullPath(Name))) WebHelper.AlertAndEnd("模版[" + Name + "]不存在！");

        if (!IsPostBack)
        {
            String ti = GetTemplateItem();
            if (!String.IsNullOrEmpty(ti))
            {
                if (File.Exists(ti)) txtContent.Text = File.ReadAllText(ti);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        String ti = GetTemplateItem();
        if (!String.IsNullOrEmpty(ti))
        {
            try
            {
                File.WriteAllText(ti, txtContent.Text);

                WebHelper.Alert("保存成功！");
            }
            catch (Exception ex)
            {
                WebHelper.Alert("保存失败！" + ex.Message);
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        String ti = GetTemplateItem();
        if (!String.IsNullOrEmpty(ti))
        {
            if (File.Exists(ti))
            {
                try
                {
                    File.Delete(ti);

                    WebHelper.AlertAndRedirect("成功！", "Template.aspx?Template=" + Name);
                }
                catch (Exception ex)
                {
                    WebHelper.Alert("失败！" + ex.Message);
                }
            }
        }
    }
}