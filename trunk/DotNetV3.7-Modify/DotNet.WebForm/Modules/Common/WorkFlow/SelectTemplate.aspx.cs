//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Utilities;
using DotNet.Business;

/// <remarks>
/// SelectTemplate
/// 单据模板设置
///
/// 查询记录
/// 
///		2011.09.18 版本：2.1 张广梁 修正排序bug。
///		2009.11.09 版本：2.0 JiRiGaLa   没有权限的人来管理，不能把所有的数据都能管理了。
///		2009.03.11 版本：1.0 JiRiGaLa 创建程序。
///
/// 版本：2.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.09.03 </date>
/// </author>
/// </remarks>
public partial class SelectTemplate : BasePage
{
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
            this.SortExpression = BaseNewsEntity.FieldSortCode;
            this.UserCenterDbHelper.Open();
            this.GetItemDetails();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsWorkFlowCategories");
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode + " DESC");
        this.cmbCategory.DataSource = dataTable;
        this.cmbCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbCategory.DataBind();
        this.cmbCategory.Items.Insert(0, new ListItem());
    }
    #endregion

    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

    #region private void Search() 查询
    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        this.gridView.PageIndex = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if ((Utilities.ShowInformation) && (this.gridView.Rows.Count == 0))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "searchFailure", "<script>alert('提示信息： 未找到查询内容。');</script>");
        }
    }
    #endregion

    #region private void DoSearch() 查询
    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        string search = this.txtSearch.Text;
        WorkFlowBillTemplateManager newsManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = newsManager.Search(string.Empty, this.cmbCategory.SelectedValue, search, true, false);
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.DataSource = dataTable.DefaultView;
        this.gridView.DataBind();
        this.DTBillTemplate = dataTable;
    }
    #endregion

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
        }
    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        // 导向编辑页面
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        string addPage = templateManager.GetAddPage(id);
        addPage = addPage.Replace("{Id}", id);
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + addPage + "');</script>");
    }

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (this.SortDire == "ASC")
        {
            this.SortDire = "DESC";
        }
        else
        {
            this.SortDire = "ASC";
        }
        this.SortExpression = e.SortExpression;
        this.DTBillTemplate.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
    }

    private DataTable DTBillTemplate
    {
        get
        {
            return Utilities.GetFromSession("_DTBillTemplate") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTBillTemplate", value);
        }
    }
}