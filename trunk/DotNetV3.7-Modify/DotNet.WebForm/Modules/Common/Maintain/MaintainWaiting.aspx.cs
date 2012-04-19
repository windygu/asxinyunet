//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

using Project;

/// <remarks>
/// MaintainWaiting
/// 待维修
///
///     2012.04.06 版本：1.2  zgl 规范代码
///     2012.03.31 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012.03.31</date>
/// </author>
/// </remarks>
public partial class MaintainWaiting : BasePage
{
    string ticks = DateTime.Now.Ticks.ToString();

    #region private void GetPermission() 获得页面的权限
    /// <summary>
    /// 获得页面的权限
    /// </summary>
    private void GetPermission()
    {
        // 每个人都可以管理自己的页面，不需要判断权限
        /*
        this.permissionDelete = this.IsAuthorized("BillTemplateAdmin.Delete");
        */
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsBugCategory");
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode);
        this.cmbBugCategory.DataSource = dataTable;
        this.cmbBugCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbBugCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbBugCategory.DataBind();
        this.cmbBugCategory.Items.Insert(0, new ListItem());
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.gridView.Rows.Count > 0;
        this.btnSetProcessing.Enabled = this.gridView.Rows.Count > 0;
        this.btnSetProcessed.Enabled = this.gridView.Rows.Count > 0;
        this.myNavigator.Visible = this.gridView.Rows.Count > 0;
    }
    #endregion

    #region private void GetDataBaseParamter() 从数据库读取参数
    /// <summary>
    /// 从数据库读取参数
    /// </summary>
    private void GetDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }
    }
    #endregion

    #region private void SaveDataBaseParamter() 保存参数
    /// <summary>
    /// 保存参数
    /// </summary>
    private void SaveDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize", this.myNavigator.PageSize.ToString());
    }
    #endregion

    #region private void DoSearch() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void DoSearch()
    {
        string searchValue = this.txtSearch.Text;
        // 总记录数量
        int recordCount = 0;
        MaintainManager maintainManager = new MaintainManager(this.UserCenterDbHelper, this.UserInfo);
        // DataTable dataTable = maintainManager.GetDataTableByPage(string.Empty, "已提交", searchValue, out recordCount, this.myNavigator.PageIndex + 1, this.myNavigator.PageSize, this.SortExpression, this.SortDire);
        DataTable dataTable = maintainManager.GetDataTableByPage(string.Empty, this.cmbBugCategory.SelectedValue, MaintainStatus.Submitted.ToDescription(), searchValue, out recordCount, this.myNavigator.PageIndex + 1, this.myNavigator.PageSize, this.SortExpression, this.SortDire);
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        // 绑定分页控件
        this.myNavigator.RowCount = recordCount;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.SetControlState();
    }
    #endregion

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
            this.GetPermission();
            this.SaveDataBaseParamter();
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

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetDataBaseParamter();
            this.GetItemDetails();
            // 获取列表
            this.DoSearch();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 设置默认的排序结果, 按审核日期倒序排序
            // this.SortExpression = MaintainEntity.FieldCreateOn;
            // this.SortDire = "DESC";
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    protected void cmbBugCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void gridView_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string description = dataRowView[MaintainEntity.FieldDescription].ToString();
            e.Row.Cells[6].Text = description.Replace("\r\n", "<br>");
        }
    }

    #region private void ShowDetails(string currentId) 查看详情
    private void ShowDetails(string currentId)
    {
        if (!string.IsNullOrEmpty(currentId))
        {
            currentId = Server.HtmlEncode(currentId);
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowMaintain.aspx?Id=" + currentId + "&ticks=" + ticks + "');</script>");
        }
    }
    #endregion

    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            this.ShowDetails(e.CommandArgument.ToString());
        }
    }

    #region private void EidtDetails(string currentId) 编辑详情
    private void EidtDetails(string currentId)
    {
        if (!string.IsNullOrEmpty(currentId))
        {
            currentId = Server.HtmlEncode(currentId);
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "EditMaintain.aspx?Id=" + currentId + "&ticks=" + ticks + "');</script>");
        }
    }
    #endregion

    protected void gridView_EditCommand(object source, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        this.EidtDetails(id);
    }

    #region private void GetList(PageChangeEventArgs e)
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        // this.myNavigator.BindData(this.grdWorkFlowCurrent, this.DTMaintain, e);
        this.DoSearch();
        if (e.Action == "PageSizeChanged")
        {
            try
            {
                this.UserCenterDbHelper.Open();
                // 保存分页参数
                this.SaveDataBaseParamter();
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
    }
    #endregion

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
        this.DoSearch();
    }

    private void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    #region private int BatchSetProcessing() 批量处理中
    /// <summary>
    /// 批量处理中
    /// </summary>
    /// <returns>影响的行数</returns>
    private int SetProcessing()
    {
        int returnValue = 0;
        this.DbHelper.Open();
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        MaintainManager manager = new MaintainManager(this.UserInfo);
        returnValue = manager.SetProcessing(ids);
        this.Search();
        this.DbHelper.Close();
        return returnValue;
    }
    #endregion

    protected void btnSetProcessing_Click(object sender, EventArgs e)
    {
        // 批量已处理
        this.SetProcessing();
    }

    #region private int BatchSetProcessed() 批量已处理
    /// <summary>
    /// 批量已处理
    /// </summary>
    /// <returns>影响的行数</returns>
    private int SetProcessed()
    {
        int returnValue = 0;
        this.DbHelper.Open();
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        MaintainManager manager = new MaintainManager(this.UserInfo);
        returnValue = manager.SetProcessed(ids);
        this.Search();
        this.DbHelper.Close();
        return returnValue;
    }
    #endregion

    protected void btnSetProcessed_Click(object sender, EventArgs e)
    {
        // 批量已处理
        this.SetProcessed();
    }
}