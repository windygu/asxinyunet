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
/// WorkFlowSearch
/// 流程监控
///
/// 查询记录
/// 
///		2009.11.09 版本：2.0 JiRiGaLa 没有权限的人来管理，不能把所有的数据都能管理了。
///		2009.03.11 版本：1.0 JiRiGaLa 创建程序。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.09.04 </date>
/// </author>
/// </remarks>
public partial class WorkFlowSearch : BasePage
{
    string CategoryCode = string.Empty;

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (this.gridView.Rows.Count == 0)
        {
            this.btnBatchAuditQuash.Enabled = false;
            this.btnDelete.Enabled = false;
            this.myNavigator.Visible = false;
        }
        else
        {
            this.btnBatchAuditQuash.Enabled = this.permissionEdit;
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

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["CategoryCode"] != null)
        {
            this.CategoryCode = Page.Request["CategoryCode"].ToString();
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        WorkFlowBillTemplateManager manager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
        this.cmbCategory.DataSource = dataTable;
        this.cmbCategory.DataTextField = BaseNewsEntity.FieldTitle;
        this.cmbCategory.DataValueField = BaseNewsEntity.FieldId;
        this.cmbCategory.DataBind();
        this.cmbCategory.Items.Insert(0, new ListItem());
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
            Utilities.CheckIsLogOn();
            // 这里需要判断权限
            this.IsModuleAuthorized("WorkFlowSearch");
            this.GetItemDetails();
            this.GetParamters();
            this.UserCenterDbHelper.Open();
            this.GetDataBaseParamter();
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
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize");
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
        // 每个人都可以管理自己的页面，不需要判断权限
        /*
        this.permissionDelete = this.IsAuthorized("BillTemplateAdmin.Delete");
        */
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
        this.myNavigator.BindData(this.gridView, this.DTUserBill, e);
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
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize", this.myNavigator.PageSize.ToString());
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
        UserBillManager newsManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
        // 所有的流程都可以查找
        DataTable dataTable = newsManager.Search(string.Empty, this.cmbCategory.SelectedValue, search);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow[BaseNewsEntity.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseNewsEntity.FieldAuditStatus].ToString());
        }
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTUserBill = dataTable;
        this.SetControlState();
    }
    #endregion

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 这里需要处理单据的状态
        }
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            if (e.Row.Cells[6].Text != "&nbsp;" && !e.Row.Cells[6].Text.Equals("草稿"))
            {
                e.Row.Cells[this.gridView.Columns.Count - 1].Text = "&nbsp;";
                e.Row.Cells[this.gridView.Columns.Count - 2].Text = "&nbsp;";
            }
            else
            {
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
    }

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {

    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        // 导向编辑页面
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "UserHtmlBillEdit.aspx?ID=" + id + "');</script>");
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
            UserBillManager newsManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = newsManager.SetDeleted(id);
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
        this.DTUserBill.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
        PageChangeEventArgs pageChangeEventArgs = new PageChangeEventArgs(this.gridView, "Sorting");
        this.myNavigator.BindData(this.gridView, this.DTUserBill, pageChangeEventArgs);
        this.GetPermission();
        this.SetControlState();
    }


    protected int BatchAuditQuash()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.DbHelper.Open();
            UserBillManager newsManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = newsManager.AuditQuash(ids, string.Empty);
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopSucceed", "<script>alert('提示信息：废弃单据成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopFailure", "<script>alert('提示信息：废弃单据失败。');</script>");
            }
        }
        return returnValue;
    }

    protected void btnBatchAuditQuash_Click(object sender, EventArgs e)
    {
        this.BatchAuditQuash();
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
            string auditStatus = string.Empty;
            UserBillManager newsManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            for (int i = 0; i < ids.Length; i++)
            {
                // 状态为空的或者是草稿状态的可以删除掉
                auditStatus = newsManager.GetEntity(ids[i]).AuditStatus;
                if (string.IsNullOrEmpty(auditStatus) || auditStatus.Equals(AuditStatus.Draft.ToString()))
                {
                    returnValue += newsManager.SetDeleted(ids[i]);
                }
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

    private DataTable DTUserBill
    {
        get
        {
            return Utilities.GetFromSession("_DTUserBill") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTUserBill", value);
        }
    }
}