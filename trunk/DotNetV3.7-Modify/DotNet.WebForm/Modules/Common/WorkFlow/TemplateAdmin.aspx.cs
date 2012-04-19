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
/// TemplateAdmin
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
public partial class TemplateAdmin : BasePage
{
    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (this.gridView.Rows.Count == 0)
        {
            this.btnDelete.Enabled = false;
            this.btnAllow.Enabled = false;
            this.btnStop.Enabled = false;
            this.myNavigator.Visible = false;
        }
        else
        {
            this.btnAddHtml.Enabled = this.permissionAdd;
            this.btnAllow.Enabled = this.permissionEdit;
            this.btnStop.Enabled = this.permissionEdit;
            this.btnDelete.Enabled = this.permissionDelete;
        }
        this.gridView.Columns[this.gridView.Columns.Count - 1].Visible = this.permissionDelete;
        // 设置分页控件的显示状态
        this.myNavigator.Visible = this.gridView.Rows.Count > 0;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
            Utilities.CheckIsLogOn();
            this.UserCenterDbHelper.Open();
            // 新增模板
            this.IsModuleAuthorized("BillTemplateAdmin");
            this.GetItemDetails();
            this.GetDataBaseParamter();
            this.SortExpression = BaseBusinessLogic.FieldSortCode;
            // this.SortDire
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

    #region private void GetDataBaseParamter() 从数据库读取参数
    /// <summary>
    /// 从数据库读取参数
    /// </summary>
    private void GetDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.WorkFlowDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "BillTemplateAdmin.PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }
    }
    #endregion

    #region private void GetPermission() 获得页面的权限
    /// <summary>
    /// 获得页面的权限
    /// </summary>
    private void GetPermission()
    {
        this.permissionAccess = true;
        this.permissionSearch = true;
        this.permissionExport = true;

        this.permissionAdd = true;
        this.permissionEdit = true;
        this.permissionDelete = true;
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

    private void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    #region private void GetList(PageChangeEventArgs e)
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        this.myNavigator.BindData(this.gridView, this.DTBillTemplate, e);
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

    #region private void SaveDataBaseParamter() 保存参数
    /// <summary>
    /// 保存参数
    /// </summary>
    private void SaveDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.WorkFlowDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "BillTemplateAdmin.PageSize", this.myNavigator.PageSize.ToString());
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

    #region private void DoSearch() 查询
    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        // 获取权限
        this.GetPermission();
        string search = this.txtSearch.Text;
        WorkFlowBillTemplateManager newsManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = newsManager.Search(string.Empty, this.cmbCategory.SelectedValue, search, null, false);
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.ShowWorkFlowActivity(dataTable);
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTBillTemplate = dataTable;
        this.SetControlState();
    }
    #endregion

    BaseWorkFlowActivityManager workFlowActivityManager = null;

    private void ShowWorkFlowActivity(DataTable dt)
    {
        string workFlowActivity = "";
        if (dt.Columns.Contains("审核流程") == false)
        {
            dt.Columns.Add("审核流程");
        }
        foreach (DataRow dataRow in dt.Rows)
        {
            string workFlowCode = dataRow[BaseWorkFlowProcessEntity.FieldCode].ToString();
            if (workFlowActivityManager == null)
            {
                workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            }
            workFlowActivity = workFlowActivityManager.GetWorkFlowActivityByCode(workFlowCode);
            dataRow["审核流程"] = workFlowActivity;
        }
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)(e.Row.FindControl("lkbSetTop"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetUp"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetDown"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetBottom"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
}

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                //按钮
                LinkButton btnSetTop = (LinkButton)e.Row.FindControl("lkbSetTop");
                LinkButton btnSetUp = (LinkButton)e.Row.FindControl("lkbSetUp");
                LinkButton btnSetDown = (LinkButton)e.Row.FindControl("lkbSetDown");
                LinkButton btnSetBottom = (LinkButton)e.Row.FindControl("lkbSetBottom");
                // 按钮不显示
                if (btnSetTop != null)
                {
                    btnSetTop.Visible = false;
                }
                if (btnSetUp != null)
                {
                    btnSetUp.Visible = false;
                }
                if (btnSetDown != null)
                {
                    btnSetDown.Visible = false;
                }
                if (btnSetBottom != null)
                {
                    btnSetBottom.Visible = false;
                }
            }
            if (this.permissionDelete)
            {
                TableCell tableCell = e.Row.Cells[this.gridView.Columns.Count - 1];
                LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
                if (btnLinkDelete != null)
                {
                    string strScript = "return confirm('您确认要删除吗？');";
                    btnLinkDelete.Attributes.Add("onclick", strScript);
                }
            }
        }
    }

    #region private void SetSort(string function, int index) 设置排序顺序
    /// <summary>
    /// 设置排序顺序
    /// </summary>
    /// <param name="function">排序动作</param>
    /// <param name="index">索引</param>
    private void SetSort(string function, int index)
    {
        string id = this.gridView.DataKeys[index].Value.ToString();
        string targetId = string.Empty;
        try
        {
            this.DbHelper.Open();
            switch (function)
            {
                case BaseDbSortLogic.CommandSetTop:
                    if (index > 0)
                    {
                        BaseDbSortLogic.SetBottom(this.WorkFlowDbHelper, WorkFlowBillTemplateManager.TemplateTable, id);
                        this.gridView.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetId = this.gridView.DataKeys[index - 1].Value.ToString();
                        this.gridView.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.WorkFlowDbHelper, WorkFlowBillTemplateManager.TemplateTable, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 1) < this.gridView.Rows.Count)
                    {
                        targetId = this.gridView.DataKeys[index + 1].Value.ToString();
                        this.gridView.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.WorkFlowDbHelper, WorkFlowBillTemplateManager.TemplateTable, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 1) < this.gridView.Rows.Count)
                    {
                        BaseDbSortLogic.SetTop(this.WorkFlowDbHelper, WorkFlowBillTemplateManager.TemplateTable, id);
                        this.gridView.SelectedIndex = this.gridView.Rows.Count - 1;
                    }
                    break;
            }
            // 获取列表
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

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == BaseDbSortLogic.CommandSetTop
            || e.CommandName == BaseDbSortLogic.CommandSetUp
            || e.CommandName == BaseDbSortLogic.CommandSetDown
            || e.CommandName == BaseDbSortLogic.CommandSetBottom)
        {
            // 设置排序顺序
            this.SetSort(e.CommandName, int.Parse(e.CommandArgument.ToString()));
        }
    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        // 导向编辑页面
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        BaseNewsEntity newsEntity = templateManager.GetEntity(id);
        if (newsEntity.Source.Equals("xls"))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "OfficeTemplateEdit.aspx?ID=" + id + "');</script>");
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "HtmlTemplateEdit.aspx?ID=" + id + "');</script>");
        }
    }

    #region private void DeleteMark(string id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">主键</param>
    private void DeleteMark(string id)
    {
        int returnValue = 0;
        try
        {
            this.DbHelper.Open();
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = templateManager.SetDeleted(id);
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
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.gridView.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
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
        PageChangeEventArgs pageChangeEventArgs = new PageChangeEventArgs(this.gridView, "Sorting");
        this.myNavigator.BindData(this.gridView, this.DTBillTemplate, pageChangeEventArgs);
        this.GetPermission();
        this.SetControlState();
    }

    protected void btnAddExcel_Click(object sender, EventArgs e)
    {
        string url = "OfficeTemplateEdit.aspx";
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + url + "');</script>");
    }

    protected void btnAddHtml_Click(object sender, EventArgs e)
    {
        string url = "HtmlTemplateEdit.aspx";
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + url + "');</script>");
    }

    /// <summary>
    /// 批量允许发布模板
    /// </summary>
    /// <returns>影响行数</returns>
    protected int BatchAllow()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        this.WorkFlowDbHelper.Open();
        try
        {
            // this.WorkFlowDbHelper.BeginTransaction();
            WorkFlowBillTemplateManager manager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = null;
            for (int i = 0; i < ids.Length; i++)
            {
                entity = manager.GetEntity(ids[i]);
                entity.Enabled = 1;
                returnValue = manager.UpdateEntity(entity);
            }
            // this.WorkFlowDbHelper.CommitTransaction();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            // this.WorkFlowDbHelper.RollbackTransaction();
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.WorkFlowDbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathAllowSucceed", "<script>alert('提示信息：发布模板成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathAllowFailure", "<script>alert('提示信息：发布模板失败。');</script>");
            }
        }
        return returnValue;
    }

    protected void btnAllow_Click(object sender, EventArgs e)
    {
        this.BatchAllow();
    }

    /// <summary>
    /// 批量停止发布模板
    /// </summary>
    /// <returns>影响行数</returns>
    protected int BatchStop()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        this.WorkFlowDbHelper.Open();
        try
        {
            this.WorkFlowDbHelper.BeginTransaction();
            WorkFlowBillTemplateManager manager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = null;
            for (int i = 0; i < ids.Length; i++)
            {
                entity = manager.GetEntity(ids[i]);
                entity.Enabled = 0;
                returnValue = manager.UpdateEntity(entity);
            }
            this.WorkFlowDbHelper.CommitTransaction();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.WorkFlowDbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopSucceed", "<script>alert('提示信息：停止发布模板成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopFailure", "<script>alert('提示信息：停止发布模板失败。');</script>");
            }
        }
        return returnValue;
    }

    protected void btnStop_Click(object sender, EventArgs e)
    {
        this.BatchStop();
    }

    #region private int BathDelete() 批量删除
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BathDelete()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.DbHelper.Open();
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            for(int i=0;i<ids.Length;i++)
            {
                returnValue += templateManager.SetDeleted(ids[i]);
            }
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
            this.Search();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // 批量删除
        this.BathDelete();
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