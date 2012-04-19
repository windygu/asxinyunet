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
/// WorkFlowSuperAudit
/// 待审核
///
///		2011.09.18 版本：1.1 张广梁       完善查询。
///     2011.09.02 版本：1.0 JiRiGaLa     创建代码。
///
/// 版本：1.1
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.09.02</date>
/// </author>
/// </remarks>
public partial class WorkFlowSuperAudit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
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
        DataTable dataTable = workFlowCurrentManager.GetSuperAudit(this.cmbCategory.SelectedItem.Text, this.txtSearch.Text);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
        }
        dataTable.DefaultView.Sort = BaseWorkFlowCurrentEntity.FieldSortCode;
        this.grdWorkFlowCurrent.DataSource = dataTable;
        this.grdWorkFlowCurrent.DataBind();
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

    protected void grdWorkFlowCurrent_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            if (!e.Row.Cells[5].Text.Equals("待审核"))
            {
                e.Row.Cells[this.grdWorkFlowCurrent.Columns.Count - 1].Text = "&nbsp;";
            }
            else
            {
                LinkButton btnLinkDelete = null;
                if (e.Row.Cells[this.grdWorkFlowCurrent.Columns.Count - 1].Controls.Count > 0)
                {
                    btnLinkDelete = (LinkButton)e.Row.Cells[this.grdWorkFlowCurrent.Columns.Count - 1].Controls[0];
                }
                if (btnLinkDelete != null)
                {
                    string strScript = "return confirm('您确定要删除此数据行吗？');";
                    btnLinkDelete.Attributes.Add("onclick", strScript);
                }
            }
        }
    }

    protected void grdWorkFlowCurrent_ItemCommand(object source, GridViewCommandEventArgs e)
    {

    }

    #region private void ShowDetails(string currentId) 查看详情
    private void ShowDetails(string currentId)
    {
        if (!string.IsNullOrEmpty(currentId))
        {
            currentId = Server.HtmlEncode(currentId);
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowReport.aspx?Id=" + currentId + "');</script>");
            }
            else
            {
                // 若是单据,就显示单据
                this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowUserBill.aspx?Id=" + currentId + "&ReadOnly=True&ShowAuditList=True');</script>");
            }
        }
    }
    #endregion

    protected void grdWorkFlowCurrent_EditCommand(object source, GridViewEditEventArgs e)
    {
        string id = this.grdWorkFlowCurrent.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        this.ShowDetails(id);
    }

    #region private void Delete(String id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">代码</param>
    private void Delete(String id)
    {
        int returnValue = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            // 删除数据
            BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = roleManager.Delete(id);
            // 获取列表
            this.GetList();
            this.grdWorkFlowCurrent.SelectedIndex = -1;
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
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                // 提示删除成功
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                // 提示删除失败
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdWorkFlowCurrent_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.grdWorkFlowCurrent.DataKeys[e.RowIndex].Value.ToString();
        // 删除数据
        this.Delete(id);
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
            this.WorkFlowDbHelper.Open();
            // this.WorkFlowDbHelper.BeginTransaction();
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = workFlowCurrentManager.AutoAuditPass(ids, string.Empty);
            // this.WorkFlowDbHelper.CommitTransaction();
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
        }
        catch (Exception exception)
        {
            // this.WorkFlowDbHelper.RollbackTransaction();
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditPassSucceed", "<script>alert('提示信息：通过成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "auditPassFailure", "<script>alert('提示信息：通过失败。');</script>");
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
            this.WorkFlowDbHelper.Open();
            // this.WorkFlowDbHelper.BeginTransaction();
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = workFlowCurrentManager.AuditReject(ids, string.Empty);
            // this.WorkFlowDbHelper.CommitTransaction();
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
        }
        catch (Exception exception)
        {
            // this.WorkFlowDbHelper.RollbackTransaction();
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
        string[] ids = Utilities.GetSelecteIds(this.grdWorkFlowCurrent);
        try
        {
            this.WorkFlowDbHelper.Open();
            // this.WorkFlowDbHelper.BeginTransaction();
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = workFlowCurrentManager.AuditQuash(ids, string.Empty);
            // this.WorkFlowDbHelper.CommitTransaction();
            this.grdWorkFlowCurrent.EditIndex = -1;
            this.GetList();
            this.SetControlState();
        }
        catch (Exception exception)
        {
            // this.WorkFlowDbHelper.RollbackTransaction();
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

    protected void btnAuditQuash_Click(object sender, EventArgs e)
    {
        // 批量废弃
        this.BatchAuditQuash();
    }
}