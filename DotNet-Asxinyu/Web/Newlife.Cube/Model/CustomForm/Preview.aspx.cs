using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Web;
using XCode.Accessors;
using XCode;

public partial class Model_CustomForm_Preview : MyEntityList
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
        ModelTable table = Table;
        if (table != null && !String.IsNullOrEmpty(table.Template))
        {
            Control control = ParseControl(table.Template);
            if (control != null) PlaceHolder1.Controls.Add(control);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        // 这里处理回发，因为Load阶段加载控件，那时候拿不到返回值
        if (IsPostBack)
        {
            ModelTable table = Table;
            if (table != null)
            {
                try
                {
                    table.SaveForm(this);

                    WebHelper.Alert("成功！");
                }
                catch (Exception ex)
                {
                    WebHelper.Alert("失败！" + ex.Message);
                }
            }
        }

        base.OnPreRender(e);
    }
}