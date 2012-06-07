using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Web;
using XCode.DataAccessLayer;

public partial class Cube_ImportDataModel : MyEntityList
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataSource = DAL.ConnStrs.Keys;
            DropDownList1.DataBind();
        }
    }

    protected void btnXmlImport_Click(object sender, EventArgs e)
    {
        FileUpload fu = FileUpload1;
        if (!fu.HasFile) return;

        Byte[] bts = fu.FileBytes;
        if (bts == null || bts.Length < 1) return;

        String xml = Encoding.UTF8.GetString(bts);
        if (String.IsNullOrEmpty(xml)) return;

        String name = fu.FileName;
        name = Path.GetFileNameWithoutExtension(name);
        try
        {
            DataModel.Import(name, xml);

            WebHelper.Alert("导入成功！");
        }
        catch (Exception ex)
        {
            WebHelper.Alert(ex.Message);
        }
    }

    protected void btnZipImport_Click(object sender, EventArgs e)
    {
        FileUpload fu = FileUpload2;
        if (!fu.HasFile) return;

        Byte[] bts = fu.FileBytes;
        if (bts == null || bts.Length < 1) return;

        try
        {
            DataModel.Import(bts);

            WebHelper.Alert("导入成功！");
        }
        catch (Exception ex)
        {
            WebHelper.Alert(ex.Message);
        }
    }

    protected void btnDbImport_Click(object sender, EventArgs e)
    {
        if (!WebHelper.CheckEmptyAndFocus(txtConnStr, null)) return;
        if (!WebHelper.CheckEmptyAndFocus(txtProvider, null)) return;
        if (!WebHelper.CheckEmptyAndFocus(txtModelName, null)) return;

        //String key = Guid.NewGuid().ToString();
        String connStr = txtConnStr.Text;
        String provider = txtProvider.Text;
        String name = txtModelName.Text;

        //if (DAL.ConnStrs.ContainsKey(name))
        //{
        //    WebHelper.Alert("名为" + name + "的模型已存在！");
        //    return;
        //}

        if (!DAL.ConnStrs.ContainsKey(name)) DAL.AddConnStr(name, connStr, null, provider);
        try
        {
            DataModel dm = DataModel.Import(name, DAL.Create(name).Tables);
            dm.ConnName = name;
            dm.IsStatic = false;
            dm.Save();

            WebHelper.Alert("导入成功！");
        }
        catch (Exception ex)
        {
            WebHelper.Alert(ex.Message);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String name = DropDownList1.SelectedValue;
        if (String.IsNullOrEmpty(name) || !DAL.ConnStrs.ContainsKey(name)) return;

        ConnectionStringSettings set = DAL.ConnStrs[name];
        txtConnStr.Text = set.ConnectionString;
        txtProvider.Text = set.ProviderName;
        txtModelName.Text = name;
    }

    protected void btnImportEntity_Click(object sender, EventArgs e)
    {
        try
        {
            DataModel.ImportEntity();

            WebHelper.Alert("导入成功！");
        }
        catch (Exception ex)
        {
            WebHelper.Alert(ex.Message);
        }
    }
}