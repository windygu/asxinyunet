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
/// WorkFlowActivityByUser
/// 审核流程，按用户设置流程
///
/// 修改记录
/// 
///		2012.03.22 版本：2.1 吉日嘎拉 修改文件名。
///		2011.10.06 版本：2.0 吉日嘎拉 按模板进行流程设置。
///		2011.09.18 版本：1.1 张广梁 修正排序。
///		2009.11.27 版本：1.0 JiRiGaLa 创建。
///
/// 版本：2.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.10.06</date>
/// </author>
/// </remarks>
public partial class WorkFlowActivityByUser : BasePage
{
    /// <summary>
    /// 当前文件代码
    /// </summary>
    public string WorkFlowId
    {
        set
        {
            this.txtWorkFlowId.Value = value;
        }
        get
        {
            return this.txtWorkFlowId.Value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["WorkFlowId"] != null)
        {
            this.WorkFlowId = Page.Request["WorkFlowId"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
        if (Page.Request["Search"] != null)
        {
            this.txtSearch.Text = Page.Request["Search"].ToString();
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
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    #region private void ShowEntry() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntry()
    {
        if (!string.IsNullOrEmpty(this.WorkFlowId))
        {
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity newsEntity = templateManager.GetEntity(this.WorkFlowId);
            this.lblTitle.Text = newsEntity.Title;
            this.lblCategoryCode.Text = newsEntity.CategoryCode;
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        try
        {
            // 读取参数
            this.GetParamters();
            this.UserCenterDbHelper.Open();
            // 这里需要判断权限
            this.IsModuleAuthorized("WorkFlowAdmin");
            this.GetDataBaseParamter();
            this.GetOrganizeTree();
            // 显示实体
            this.ShowEntry();
            // 获取用户列表
            this.DoSearch();
            this.txtSearch.Focus();
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
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "UserAdmin.PageSize");
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
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserAdmin.PageSize", this.myNavigator.PageSize.ToString());
    }
    #endregion

    #region private void GetOrganizeTree() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetOrganizeTree()
    {
        BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable organizeTable = organizeManager.GetOrganizeTree();
        this.cmbDepartment.DataValueField = BaseOrganizeEntity.FieldId;
        this.cmbDepartment.DataTextField = BaseOrganizeEntity.FieldFullName;
        this.cmbDepartment.DataSource = organizeTable;
        this.cmbDepartment.DataBind();
        this.cmbDepartment.Items.Insert(0, new ListItem());
    }
    #endregion

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
        this.myNavigator.BindData(this.gridView, this.DTUser, e);
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

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnSearch.Enabled = true;
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
        string search = this.txtSearch.Text;
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        string organizeId = this.cmbDepartment.SelectedValue;
        string searchValue = this.txtSearch.Text.Trim();
        DataTable dataTable = userManager.SearchByDepartment(organizeId, searchValue);
        ShowWorkFlowActivity(dataTable);
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTUser = dataTable;
        this.SetControlState();
        this.txtSearch.Focus();
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
            if (workFlowActivityManager == null)
            {
                workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            }
            workFlowActivity = workFlowActivityManager.GetWorkFlowActivity(dataRow["Id"].ToString(), this.WorkFlowId);
            dataRow["审核流程"] = workFlowActivity;
        }
    }

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // 进行查询
        this.Search();
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[this.gridView.Columns.Count - 2].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[this.gridView.Columns.Count - 2].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要清除流程设置数据吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            /*
            string workFlowCode = ((DataRowView)e.Row.DataItem)["Id"].ToString() + "_" + this.TemplateId;
            if (workFlowActivityManager == null)
            {
                workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            }
            string workFlowActivity = workFlowActivityManager.GetWorkFlowActivityByCode(workFlowCode);
            e.Row.Cells[4].Text = workFlowActivity;
            */
        }
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = null;
            // btn = (LinkButton)(e.Row.FindControl("lkbUserWorkFlow"));
            // btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbWorkFlowAuthorize"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbReplaceUser"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        int index=0;
        string id = string.Empty;
        if (e.CommandName =="UserWorkFlow")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            // 导向编辑页面
            this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "UserWorkFlow.aspx?ID=" + id + "');</script>");
        }
        if (e.CommandName=="WorkFlowAuthorize")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            Page.Response.Redirect("UserWorkFlowSetAuthorize.aspx?Id=" + id + "&ReturnURL=WorkFlowAdmin.aspx");
        }
        if (e.CommandName == "ReplaceUser")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            Page.Response.Redirect("WorkFlowSetReplaceUser.aspx?Id=" + id + "&ReturnURL=WorkFlowAdmin.aspx");
        }
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
        this.DTUser.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
        this.myNavigator.BindData(this.gridView, this.DTUser);
        this.SetControlState();
    }

    protected void gridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        string workFlowCode = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString() + "_" + this.WorkFlowId;
        e.NewEditIndex = -1;
        // 导向编辑页面
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "UserWorkFlowActivity.aspx?WorkFlowCode=" + workFlowCode + "');</script>");
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
            returnValue = workFlowProcessManager.SetDeleted(
                new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldBillTemplateId, this.WorkFlowId)
                , new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldUserId, id));
            // 获取列表
            this.DoSearch();
            this.gridView.SelectedIndex = -1;
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

    protected void gridView_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.gridView.DataKeys[e.RowIndex].Value.ToString();
        // 删除数据
        this.Delete(id);
    }

    private DataTable DTUser
    {
        get
        {
            return Utilities.GetFromSession("_DTUser") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTUser", value);
        }
    }
}