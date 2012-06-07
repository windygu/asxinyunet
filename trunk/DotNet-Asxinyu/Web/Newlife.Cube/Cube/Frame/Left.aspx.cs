using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Cube.Entities;
using NewLife.Web;

public partial class Cube_Left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            menu.DataSource = CommonManageProvider.Provider.GetMySubMenus(WebHelper.RequestInt("ID"));
            menu.DataBind();

            //menu.DataSource = DataModel.FindAllWithCache(DataModel._.IsEnable, true);
            menu2.DataSource = DataModel.FindAllByName(DataModel._.IsEnable, true, DataModel._.LastModify, 0, 0);
            menu2.DataBind();
        }
    }

    protected void menu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item == null || e.Item.DataItem == null) return;
        IMenu m = e.Item.DataItem as IMenu;
        if (m == null) return;

        Repeater rp = e.Item.FindControl("menuItem") as Repeater;
        if (rp == null) return;

        rp.DataSource = CommonManageProvider.Provider.GetMySubMenus(m.ID);
        rp.DataBind();
    }

    protected void menu2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item == null || e.Item.DataItem == null) return;
        DataModel m = e.Item.DataItem as DataModel;
        if (m == null) return;

        Repeater rp = e.Item.FindControl("menuItem") as Repeater;
        if (rp == null) return;

        //rp.DataSource = m.ModelTables;
        rp.DataSource = ModelTable.FindAllByDataModelID(m.ID);
        rp.DataBind();
    }
}