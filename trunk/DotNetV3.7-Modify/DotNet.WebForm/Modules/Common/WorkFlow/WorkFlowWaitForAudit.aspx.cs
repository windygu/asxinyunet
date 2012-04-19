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
/// WorkFlowWaitForAudit
/// 待审核
///
///     2011.10.06 版本：1.3  JiRiGaLa   改进排序功能。
///     2011.09.28 版本：1.2  JiRiGaLa   改进废除功能。
///     2011.09.18 版本：1.1  张广梁     修改界面，完善检索。
///     2011.09.02 版本：1.0  JiRiGaLa   创建代码。
///
/// 版本：1.3
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.10.06</date>
/// </author>
/// </remarks>
public partial class WorkFlowWaitForAudit : BasePage
{
    string ticks = DateTime.Now.Ticks.ToString();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 设置默认的排序结果, 按审核日期倒序排序
            this.SortExpression = BaseWorkFlowCurrentEntity.FieldAuditDate + " DESC, "
                + BaseWorkFlowCurrentEntity.FieldCreateOn;
            this.SortDire = string.Empty;
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    protected void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void cmbAuthorize_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 这里是设置委托人的
        this.UserInfo.TargetUserId = this.cmbAuthorize.SelectedItem.Value;
        this.Search();
    }

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        // 获取单据类别
        // BaseNewsEntity.FieldEnabled, 1 表示内部单据, 0 表示外部单据
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
        this.cmbBill.DataSource = dataTable;
        this.cmbBill.DataTextField = BaseNewsEntity.FieldTitle;
        this.cmbBill.DataValueField = BaseNewsEntity.FieldCode;
        this.cmbBill.DataBind();
        this.cmbBill.Items.Insert(0, new ListItem());

        // 获取受托人
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.UserInfo);
        dataTable = workFlowActivityManager.GetAuthorizeDT("WorkFlow.Authorize");
        this.cmbAuthorize.DataSource = dataTable;
        this.cmbAuthorize.DataTextField = BaseUserEntity.FieldRealName;
        this.cmbAuthorize.DataValueField = BaseUserEntity.FieldId;
        this.cmbAuthorize.DataBind();
        this.cmbAuthorize.Items.Insert(0, new ListItem());
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
            this.GetItemDetails();
            // 获取列表
            this.GetList();
            // 设置按钮状态
            this.SetControlState();
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

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.grdWorkFlowCurrent.Rows.Count > 1;
        this.btnAuditPass.Enabled = this.grdWorkFlowCurrent.Rows.Count > 0;
        this.btnAuditReject.Enabled = this.grdWorkFlowCurrent.Rows.Count > 0;
        this.btnAuditQuash.Enabled = this.grdWorkFlowCurrent.Rows.Count > 0;
        this.lblAuthorize.Visible = this.cmbAuthorize.Items.Count > 1;
        this.cmbAuthorize.Visible = this.cmbAuthorize.Items.Count > 1;
    }
    #endregion

    #region private void Search() 查询
    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        try
        {
            this.GetList();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
        }
        // 是否显示提示信息
        if ((Utilities.ShowInformation) && (this.grdWorkFlowCurrent.Rows.Count == 0))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "searchFailure", "<script>alert('提示信息： 未找到查询内容。');</script>");
        }
    }
    #endregion

    #region private void GetList() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = workFlowCurrentManager.GetWaitForAudit(this.cmbAuthorize.SelectedValue, this.cmbBill.SelectedItem.Text, this.txtSearch.Text);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
        }
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.grdWorkFlowCurrent.DataSource = dataTable;
        this.grdWorkFlowCurrent.DataBind();
        this.SetControlState();
    }
    #endregion

    protected void grdWorkFlowCurrent_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            // 回车换行的功能
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string auditIdea = dataRowView[BaseWorkFlowCurrentEntity.FieldAuditIdea].ToString();
            e.Row.Cells[8].Text = auditIdea.Replace("\r\n", "<br>");

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

    protected void grdWorkFlowCurrent_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)(e.Row.FindControl("lkbShow"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbAudit"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void grdWorkFlowCurrent_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sort")
        {
            return;
        }
        int index = int.Parse(e.CommandArgument.ToString());
        string currentId = this.grdWorkFlowCurrent.DataKeys[index].Value.ToString();
        currentId = Server.HtmlEncode(currentId);
        if (e.CommandName == "Show")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowUserBill.aspx?Id=" + currentId + "&ReadOnly=true&ticks=" + ticks + "');</script>");
        }
        else
        {
            // Page.Response.Redirect("AuditBillDetails.aspx?Id=" + currentId + "&ReturnURL=WorkFlowWaitForAudit.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "AuditBillDetails.aspx?Id=" + currentId + "&ticks=" + ticks + "');</script>");
        }
    }

    protected void grdWorkFlowCurrent_EditCommand(object source, GridViewEditEventArgs e)
    {
        // string id = this.grdWorkFlowCurrent.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        // Page.Response.Redirect("AuditBillDetails.aspx?Id=" + id);
        string id = this.grdWorkFlowCurrent.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        // 导向编辑页面
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "AuditBillDetails.aspx?Id=" + id + "&ticks=" + ticks + "');</script>");
    }

    #region private int BatchAuditPass() 批量通过
    /// <summary>
    /// 批量通过
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchAuditPass()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.grdWorkFlowCurrent);
        try
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            returnValue = workFlowCurrentManager.AutoAuditPass(ids, string.Empty);
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditPassSucceed", "<script>alert('提示信息：审核通过成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditPassFailure", "<script>alert('提示信息：审核通过失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnAuditPass_Click(object sender, EventArgs e)
    {
        // 批量通过
        this.BatchAuditPass();
    }

    #region private int BatchAuditReject() 批量退回
    /// <summary>
    /// 批量退回
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchAuditReject()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.grdWorkFlowCurrent);
        try
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            returnValue = workFlowCurrentManager.AuditReject(ids, string.Empty);
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditRejectSucceed", "<script>alert('提示信息：审核退回成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditRejectFailure", "<script>alert('提示信息：审核退回失败。');</script>");
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
        string[] ids = Utilities.GetSelecteIds(this.grdWorkFlowCurrent);
        try
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            returnValue = workFlowCurrentManager.AuditQuash(ids, string.Empty);
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
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

    protected void grdWorkFlowCurrent_Sorting(object sender, GridViewSortEventArgs e)
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
        this.GetList();
    }
}