using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Linq;
using XCode;
using ResouceEntity;

public partial class dotnetdemos_grid_treegrid_tree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["Action"] == "GetData")
        {          
            GetNewData();
            Response.End();
        }
        if (Request.Params["Action"] == "GetName")
        {
            string s = @"{ display: '编号', name: 'Id',type:'int', width: 70, align: 'left' }";
            Response.Write( new JavaScriptSerializer().Serialize(s ));
            Response.End();
        }
    }   
    void GetNewData()
    {
        string sortname = Request.Params["sortname"];
        string sortorder = Request.Params["sortorder"];
        int page = Convert.ToInt32(Request.Params["page"]);
        int pagesize = Convert.ToInt32(Request.Params["pagesize"]);        
        EntityList<tb_resoucepageslist> reslist = tb_resoucepageslist.FindAll("", "", null, pagesize*(page - 1), pagesize);        
        var griddata = new { Rows = reslist, Total = tb_resoucepageslist.FindCount() };
        string s = new JavaScriptSerializer().Serialize(griddata);
        Response.Write(s);
    }
}