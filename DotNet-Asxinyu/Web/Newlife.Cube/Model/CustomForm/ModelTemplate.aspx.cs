using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Web;

public partial class Model_CustomForm_ModelTemplate : MyEntityList
{
    public Int32 TableID { get { return WebHelper.RequestInt("ID"); } }

    private ModelTable _Table;
    /// <summary>模型表</summary>
    public ModelTable Table
    {
        get
        {
            if (_Table == null && TableID > 0) _Table = ModelTable.FindByID(TableID);
            return _Table;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ModelTable table = Table;
            if (table != null)
            {
                txtContent.Text = table.Template;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ModelTable table = Table;
        if (table != null)
        {
            try
            {
                table.Template = txtContent.Text;
                table.Save();

                WebHelper.Alert("保存成功！");
            }
            catch (Exception ex)
            {
                WebHelper.Alert("保存失败！" + ex.Message);
            }
        }
    }
}