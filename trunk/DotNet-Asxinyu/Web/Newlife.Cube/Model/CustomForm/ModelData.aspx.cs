using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Web;
using XCode;
using XCode.DataAccessLayer;
using XControl;

public partial class Model_CustomForm_ModelData : MyEntityList
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
        if (table != null)
        {
            IEntityOperate eop = table.CreateOperate();
            if (eop != null)
            {
                // 初始化数据列
                table.MakeGridView(gv);

                LinkBoxField lbf = gv.Columns[gv.Columns.Count - 2] as LinkBoxField;
                lbf.DataNavigateUrlFormatString += "&ModelTableID=" + TableID;

                BindData();
            }
        }
    }

    void BindData()
    {
        Int32 pageSize = gv.PageSize;
        if (pageSize < 1) pageSize = 20;

        Int32 pageIndex = WebHelper.RequestInt("page");
        Int32 start = pageIndex < 1 ? 0 : (pageIndex - 1) * pageSize;

        IEntityOperate eop = Table.CreateOperate();
        if (eop == null) return;
        gv.DataSource = eop.FindAll(null, null, null, start, pageSize);
        gv.DataBind();
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Int32 id = (Int32)gv.DataKeys[e.RowIndex].Value;
        if (id < 1) return;

        IEntityOperate eop = Table.CreateOperate();
        if (eop == null) return;

        try
        {
            IEntity entity = eop.FindByKey(id);
            if (entity == null) return;

            entity.Delete();
            BindData();

            WebHelper.Alert("成功！");
        }
        catch (Exception ex)
        {
            WebHelper.Alert("失败！" + ex.Message);
        }
    }
}
