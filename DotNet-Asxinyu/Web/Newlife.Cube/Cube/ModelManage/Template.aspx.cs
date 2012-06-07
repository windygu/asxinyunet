using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Web;
using System.IO;
using NewLife.Cube;

public partial class Cube_ModelManage_Template : MyEntityList
{
    /// <summary>模版名</summary>
    public String Name { get { return Request["Template"]; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Name)) Response.Redirect("Template.aspx?Template=Default");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (!WebHelper.CheckEmptyAndFocus(txtName, null)) return;

        String name = txtName.Text;
        String fname = Path.Combine(TemplateHelper.GetFullPath(Name), name);
        if (File.Exists(fname))
        {
            WebHelper.Alert("文件" + name + "已存在！");
            return;
        }

        try
        {
            String dir = Path.GetDirectoryName(fname);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(fname, "");

            //WebHelper.Alert("成功！");
            WebHelper.AlertAndRedirect("成功！", "TemplateItem.aspx?Template=" + Name + "&Item=" + name);
        }
        catch (Exception ex)
        {
            WebHelper.Alert("失败！" + ex.Message);
        }
    }
}