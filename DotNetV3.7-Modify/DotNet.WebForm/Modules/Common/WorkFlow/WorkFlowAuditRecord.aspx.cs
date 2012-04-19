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

/// <remarks>
/// WorkFlowAuditRecord
/// 已审核
///
///     2011.10.11 版本：1.3  JiRiGaLa 增加排序功能。
///     2011.09.17 版本：1.2  张广梁   增加查询，增加分页。
///     2011.09.17 版本：1.1  张广梁   修改gridView_EditCommand。
///     2011.09.02 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.3
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.10.11</date>
/// </author>
/// </remarks>
public partial class WorkFlowAuditRecord : BasePage
{
    string ticks = DateTime.Now.Ticks.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 设置默认的排序结果, 按审核日期倒序排序
            this.SortExpression = BaseWorkFlowCurrentEntity.FieldSendDate;
            this.SortDire = "DESC";
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetItemDetails();
            this.GetDataBaseParamter();
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
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsWorkFlowCategories");
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode + " DESC");
        this.cmbCategory.DataSource = dataTable;
        this.cmbCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbCategory.DataBind();
        this.cmbCategory.Items.Insert(0, new ListItem());

        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
        this.cmbBill.DataSource = dataTable;
        this.cmbBill.DataTextField = BaseNewsEntity.FieldTitle;
        this.cmbBill.DataValueField = BaseNewsEntity.FieldCategoryCode;
        this.cmbBill.DataBind();
        this.cmbBill.Items.Insert(0, new ListItem());
    }
    #endregion

    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = templateManager.Search(string.Empty, this.cmbCategory.SelectedValue, string.Empty, null, false);
        dataTable.DefaultView.Sort = BaseNewsEntity.FieldSortCode + " DESC";
        this.cmbBill.DataSource = dataTable;
        this.cmbBill.DataTextField = BaseNewsEntity.FieldTitle;
        this.cmbBill.DataValueField = BaseNewsEntity.FieldCode;
        this.cmbBill.DataBind();
        this.cmbBill.Items.Insert(0, new ListItem());
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

    #region private void DoSearch() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void DoSearch()
    {
        string searchValue = this.txtSearch.Text;
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = workFlowCurrentManager.GetAuditRecord(this.cmbCategory.SelectedValue, this.cmbBill.SelectedItem.Text, searchValue);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
        }
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        // this.gridView.DataSource = dataTable;
        // this.gridView.DataBind();
        // 绑定分页控件
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTAuditRecord = dataTable;
        this.SetControlState();
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.gridView.Rows.Count > 1;
        this.btnAuditReject.Enabled = this.gridView.Rows.Count > 0;
        this.btnAuditQuash.Enabled = this.gridView.Rows.Count > 0;
        this.btnSetWorked.Enabled = this.gridView.Rows.Count > 0;
        this.btnUnWorked.Enabled = this.gridView.Rows.Count > 0;
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

    protected void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

    // 这里读取每个列的状态，是否处理标志
    private BaseParameterManager manager = null;
    private BaseParameterManager parameterManager
    {
        get
        {
            if (manager == null)
            {
                manager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
            }
            return manager;
        }
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 这里需要处理单据的状态
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            if (dataRowView != null)
            {
                string id = dataRowView[BaseWorkFlowCurrentEntity.FieldId].ToString();
                string worked = parameterManager.GetParameter("User", id, this.UserInfo.Id);
                dataRowView.Row["Worked"] = worked == "1" ? 1 : 0;
            }
        }
    }

    protected void gridView_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            // 回车换行的功能
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string auditIdea = dataRowView[BaseWorkFlowCurrentEntity.FieldAuditIdea].ToString();
            e.Row.Cells[9].Text = auditIdea.Replace("\r\n", "<br>");

            if (e.Row.Cells[7].Text.Equals("待审"))
            {
                e.Row.Cells[7].BackColor = this.lblWaitForAudit.BackColor;
            }
            if (e.Row.Cells[7].Text.Equals("退回"))
            {
                e.Row.Cells[7].BackColor = this.lblAuditReject.BackColor;
            }
        }
    }

    #region private void ShowDetails(string currentId) 查看详情
    private void ShowDetails(string currentId)
    {
        if (!string.IsNullOrEmpty(currentId))
        {
            currentId = Server.HtmlEncode(currentId);
            // 若是单据,就显示单据
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowUserBill.aspx?Id=" + currentId + "&ReadOnly=True&ShowAuditList=True&ticks=" + ticks + "');</script>");
        
            /*
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(currentId);
            // 从模板表里有效状态区分,是否模板还是报表
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = templateManager.GetEntity(workFlowCurrentEntity.CategoryCode);
            string templateSource = "report";
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                templateSource = entity.Source;
            }
            if (templateSource.Equals("report"))
            {
                // 若是报表,就显示报表
                this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowReport.aspx?Id=" + currentId + "&ticks=" + ticks + "');</script>");
            }
            else
            {
            }
            */
        }
    }
    #endregion

    protected void gridView_EditCommand(object source, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        this.ShowDetails(id);
    }

    #region private int BatchAuditQuash(String id) 单条记录废弃
    /// <summary>
    /// 单条记录废弃
    /// </summary>
    /// <returns>影响的行数</returns>
    private int AuditQuash(String id)
    {
        int returnValue = 0;
        try
        {
            this.WorkFlowDbHelper.Open();
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = workFlowCurrentManager.AuditQuash(id, string.Empty);
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
            this.WorkFlowDbHelper.Close();
        }
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditQuashSucceed", "<script>alert('提示信息：废弃成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditQuashFailure", "<script>alert('提示信息：废弃失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    #region private void GetList(PageChangeEventArgs e)
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        this.myNavigator.BindData(this.gridView, this.DTAuditRecord, e);
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

    #region private int BatchAuditReject() 批量退回
    /// <summary>
    /// 批量退回
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchAuditReject()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            returnValue = workFlowCurrentManager.AuditReject(ids, string.Empty, null);
            // this.WorkFlowDbHelper.CommitTransaction();
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditRejectSucceed", "<script>alert('提示信息：退回成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditRejectFailure", "<script>alert('提示信息：退回失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnAuditReject_Click(object sender, EventArgs e)
    {
        // 批量退回
        this.BatchAuditReject();
    }

    #region private int BatchAuditQuash() 批量废弃
    /// <summary>
    /// 批量废弃
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchAuditQuash()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            // this.WorkFlowDbHelper.BeginTransaction();
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            returnValue = workFlowCurrentManager.AuditQuash(ids, string.Empty);
            // this.WorkFlowDbHelper.CommitTransaction();
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            // this.WorkFlowDbHelper.RollbackTransaction();
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditQuashSucceed", "<script>alert('提示信息：废弃成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditQuashFailure", "<script>alert('提示信息：废弃失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnAuditQuash_Click(object sender, EventArgs e)
    {
        // 批量废弃
        this.BatchAuditQuash();
    }

    /// <summary>
    /// 已审核流程表
    /// </summary>
    private DataTable DTAuditRecord
    {
        get
        {
            return Utilities.GetFromSession("_DTAuditRecord") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTAuditRecord", value);
        }
    }

    /// <summary>
    /// 设置单据的处理标志，每个人需要有每个人自己的标志，不能混在一起
    /// </summary>
    /// <param name="ids">单据主键</param>
    /// <param name="worked">处理标志</param>
    /// <returns>影响行数</returns>
    private int SetWorked(string[] ids, bool worked)
    {
        int returnValue = 0;
        string workedMark = worked ? "1" : string.Empty;
        BaseParameterManager manager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        for (int i=0; i<ids.Length; i++)
        {
            returnValue += manager.SetParameter("User", ids[i], this.UserInfo.Id, workedMark);
        }
        return returnValue;
    }

    protected void btnSetWorked_Click(object sender, EventArgs e)
    {
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.SetWorked(ids, true);
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
    }

    protected void btnUnWorked_Click(object sender, EventArgs e)
    {
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.SetWorked(ids, false); 
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
    }
}