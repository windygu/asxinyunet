//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class ChangeLog : BasePage
{
    public string ProjectId
    {
        get
        {
            return this.txtId.Value;
        }
        set
        {
            this.txtId.Value = value;
        }
    }

   
    #region  private void GetParamter() 获取页面间所传入的参数值
    private new void GetParamter()
    {
        if (Page.Request["Id"] != null)
        {
            this.ProjectId = Page.Request["Id"];
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            Utilities.CheckIsLogOn();
            this.GetParamter();
            this.DbHelper.Open();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
        }
    }
    #endregion

    #region private void DoSearch() 查询
    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        // BaseCommentManager commentManager = new BaseCommentManager(this.DbHelper, this.UserInfo);
        // DataTable dataTable = commentManager.GetDataTable(BaseCommentEntity.FieldObjectId, this.ProjectId, BaseCommentEntity.FieldCreateOn);
        // this.gridView.DataSource = dataTable;
        // this.gridView.DataBind();
    }
    #endregion

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "Color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = Color;");
        }
    }        
}