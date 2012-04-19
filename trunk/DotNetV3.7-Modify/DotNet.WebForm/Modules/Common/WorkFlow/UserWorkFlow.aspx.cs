//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <summary>
/// UserWorkFlow
/// 设置工作流
///   1: 每个用户可以在这个页面设置自己的工作流。
///   2：也可以管理员通过这个页面设置用户的某个工作流。
///   3：系统里有几种工作流单据需要列出来。
///   4：哪些流程已经设置好了，要有创建时间，若没创建时间表明还没设置好。
///   5：点击某个编辑按钮可以进入到 UserWorkFlowEdit.aspx 页面。
///   6：若没传递用户参数，就是设置自己的工作流程。
///
/// 修改纪录
///
///		2011-09-02 版本：1.0 JiRiGaLa 创建主键。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011-09-02</date>
/// </author>
/// </summary>
public partial class UserWorkFlow : BasePage
{
    /// <summary>
    /// 用户主键
    /// </summary>
    private string UserId
    {
        get
        {
            return this.txtUserId.Value;
        }
        set
        {
            this.txtUserId.Value = value;
        }
    }

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["Id"] != null)
        {
            this.UserId = Page.Request["Id"].ToString();
        }
        else
        {
            this.UserId = this.UserInfo.Id;
        }
    }
    #endregion

    #region private void SetControlState() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void SetControlState()
    {
        if (!this.UserInfo.IsAdministrator)
        {
            this.grdWorkFlow.Columns[this.grdWorkFlow.Columns.Count - 1].Visible = false;
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {

        this.GetParamter();
        this.GetItemDetails();
        this.GetWorkFlowList();
        this.SetControlState();
        this.GetUserInfo();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

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

    private void GetUserInfo()
    {
        BaseUserManager userManager = new BaseUserManager();
        BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
        this.lblCode.Text = userEntity.Code;
        this.lblRealName.Text = userEntity.RealName;
        this.lblDepartmentName.Text = userEntity.DepartmentName;
    }

    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetWorkFlowList();
    }

    /// <summary>
    /// 获取工作流列表
    /// </summary>
    private void GetWorkFlowList()
    {
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = null;
        if (string.IsNullOrEmpty(this.cmbCategory.SelectedValue))
        {
            dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
        }
        else
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseNewsEntity.FieldCategoryCode, this.cmbCategory.SelectedValue));
            parameters.Add(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0));
            dataTable = templateManager.GetDataTable(parameters, BaseNewsEntity.FieldSortCode + " DESC");
        }
        this.grdWorkFlow.DataSource = dataTable;
        this.grdWorkFlow.DataBind();
    }

    BaseWorkFlowActivityManager workFlowActivityManager = null;
    
    protected void grdWorkFlow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[this.grdWorkFlow.Columns.Count - 1].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[this.grdWorkFlow.Columns.Count - 1].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要清除流程设置数据吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            string workFlowCode = this.UserId + "_" + ((DataRowView)e.Row.DataItem)["Id"].ToString();
            if (workFlowActivityManager == null)
            {
                workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            }
            string workFlowActivity = workFlowActivityManager.GetWorkFlowActivityByCode(workFlowCode);
            e.Row.Cells[3].Text = workFlowActivity;
        }
    }

    protected void grdWorkFlow_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        // Page.Response.Redirect("UserWorkFlowActivity.aspx?workFlowCode=" + workFlowCode);
        string userWorkFlowId = this.UserId + "_" + this.grdWorkFlow.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        // 导向编辑页面
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "UserWorkFlowActivity.aspx?UserWorkFlowId=" + userWorkFlowId + "');</script>");
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
            this.WorkFlowDbHelper.Open();
            // 删除数据
            BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.WorkFlowDbHelper, this.UserInfo);
            string processCode = this.UserId + "_" + id;
            returnValue = workFlowProcessManager.SetDeleted(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, processCode));
            // 获取列表
            this.GetWorkFlowList();
            this.grdWorkFlow.SelectedIndex = -1;
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
                // 提示删除成功
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：清除审批流程成功。');</script>");
            }
            else
            {
                // 提示删除失败
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：清除审批流失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdWorkFlow_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.grdWorkFlow.DataKeys[e.RowIndex].Value.ToString();
        // 删除数据
        this.Delete(id);
    }
}