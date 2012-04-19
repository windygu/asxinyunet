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
/// WorkFlowActivityByTemplate
/// 审核流程，按模版设置流程
///
/// 修改记录
/// 
///		2012.03.22 版本：1.0 JiRiGaLa 创建。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012.03.22</date>
/// </author>
/// </remarks>
public partial class WorkFlowActivityByTemplate : BasePage
{
    /// <summary>
    /// 当前文件代码
    /// </summary>
    public string TemplateId
    {
        set
        {
            this.txtId.Value = value;
        }
        get
        {
            return this.txtId.Value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["Id"] != null)
        {
            this.TemplateId = Page.Request["Id"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 读取参数
            this.GetParamters();
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    /// <summary>
    /// 获取工作流列表
    /// </summary>
    private void GetWorkFlowList()
    {
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = templateManager.Search(string.Empty, string.Empty, string.Empty, null, false);
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.grdWorkFlow.DataSource = dataTable;
        this.grdWorkFlow.DataBind();
    }

    protected void grdWorkFlow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
        }
    }

    protected void grdWorkFlow_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        string workFlowId = this.grdWorkFlow.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        Page.Response.Redirect("WorkFlowActivityByTemplate.aspx?Id=" + workFlowId);
    }

    #region private void ShowEntry() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntry()
    {
        if (!string.IsNullOrEmpty(this.TemplateId))
        {
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            DataTable dtFile = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseFileEntity.FieldId, this.TemplateId));
            BaseNewsEntity newsEntity = templateManager.GetEntity(this.TemplateId);
            this.lblTitle.Text = newsEntity.Title;
            this.lblCategoryCode.Text = newsEntity.Code;
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
            this.SortExpression = BaseBusinessLogic.FieldSortCode;
            this.SortDire = "DESC";

            this.UserCenterDbHelper.Open();
            // 这里需要判断权限
            this.IsModuleAuthorized("WorkFlowAdmin");
            // 显示实体
            this.ShowEntry();
            this.GetWorkFlowList();
            this.GetWorkFlowActivityList();
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

    protected void grdWorkFlowActivity_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void grdWorkFlowActivity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                // 按钮
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
                TableCell tableCell = e.Row.Cells[this.grdWorkFlowActivity.Columns.Count - 1];
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
        string id = this.grdWorkFlowActivity.DataKeys[index].Value.ToString();
        string targetId = string.Empty;
        try
        {
            this.DbHelper.Open();
            switch (function)
            {
                case BaseDbSortLogic.CommandSetTop:
                    if (index > 0)
                    {
                        BaseDbSortLogic.SetTop(this.WorkFlowDbHelper, BaseWorkFlowActivityEntity.TableName, id);
                        this.grdWorkFlowActivity.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetId = this.grdWorkFlowActivity.DataKeys[index - 1].Value.ToString();
                        this.grdWorkFlowActivity.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.WorkFlowDbHelper, BaseWorkFlowActivityEntity.TableName, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 1) < this.grdWorkFlowActivity.Rows.Count)
                    {
                        targetId = this.grdWorkFlowActivity.DataKeys[index + 1].Value.ToString();
                        this.grdWorkFlowActivity.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.WorkFlowDbHelper, BaseWorkFlowActivityEntity.TableName, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 1) < this.grdWorkFlowActivity.Rows.Count)
                    {
                        BaseDbSortLogic.SetBottom(this.WorkFlowDbHelper, BaseWorkFlowActivityEntity.TableName, id);
                        this.grdWorkFlowActivity.SelectedIndex = this.grdWorkFlowActivity.Rows.Count - 1;
                    }
                    break;
            }
            // 获取列表
            this.GetWorkFlowActivityList();
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

    protected void grdWorkFlowActivity_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == BaseDbSortLogic.CommandSetTop
            || e.CommandName == BaseDbSortLogic.CommandSetUp
            || e.CommandName == BaseDbSortLogic.CommandSetDown
            || e.CommandName == BaseDbSortLogic.CommandSetBottom)
        {
            // 设置排序顺序
            this.SetSort(e.CommandName, Convert.ToInt32(e.CommandArgument));
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
            BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            returnValue = workFlowActivityManager.SetDeleted(id);

            this.GetWorkFlowActivityList();
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

    private DataTable GetWorkFlowActivityList()
    {
        string workFlowId = this.GetWorkFlowId();
        return this.GetWorkFlowActivityList(workFlowId);
    }
    
    /// <summary>
    /// 获取工作流审核流程列表
    /// </summary>
    /// <param name="workFlowId">工作流主键</param>
    private DataTable GetWorkFlowActivityList(string workFlowId)
    {
        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
        parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldWorkFlowId, workFlowId));
        parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldDeletionStateCode, 0));
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager();
        DataTable dt = workFlowActivityManager.GetDataTable(parameters, BaseWorkFlowActivityEntity.FieldSortCode);
        this.grdWorkFlowActivity.DataSource = dt;
        this.grdWorkFlowActivity.DataBind();
        return dt;
    }

    protected void grdWorkFlowActivity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.grdWorkFlowActivity.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
    }

    /// <summary>
    /// 获取工作流的主键
    /// </summary>
    /// <returns>主键</returns>
    private string GetWorkFlowId()
    {
        string id = string.Empty;
        BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.WorkFlowDbHelper, this.UserInfo);
        id = workFlowProcessManager.GetId(
            new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldBillTemplateId, this.TemplateId)
            , new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));
        // 若没定义的审批流程，自动增加一个审批流程
        if (string.IsNullOrEmpty(id))
        {
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity fileEntity = templateManager.GetEntity(this.TemplateId);
            BaseWorkFlowProcessEntity entity = new BaseWorkFlowProcessEntity();
            // 这里确定单据的编号是否可以修改，模版单据的编号修改了，一切就乱了。
            // entity.OrganizeId = this.UserInfo.DepartmentId;
            // entity.UserId = this.UserInfo.Id;
            entity.BillTemplateId = this.TemplateId;
            entity.Code = fileEntity.Code;
            entity.FullName = fileEntity.Title;
            entity.CategoryCode = fileEntity.CategoryCode;
            // 回调的类，用户可以自己定义回调的类
            entity.CallBackClass = "DotNet.Business.UserBillManager";
            // 回写的表，默认就是跟单据编号是一样的
            entity.CallBackTable = fileEntity.Code;
            entity.AuditCategoryCode = "ByTemplate";
            // entity.Contents = fileEntity.Contents;
            entity.Description = "ByTemplate 按单据进行审核";
            entity.Enabled = 1;
            entity.DeletionStateCode = 0;
            id = workFlowProcessManager.Add(entity);
        }
        return id;
    }

    /// <summary>
    /// 添加工作流审核流程
    /// </summary>
    /// <param name="workFlowId">主工作流主键</param>
    /// <param name="userCode">用户编号</param>
    /// <param name="roleId">角色主键</param>
    /// <param name="organizeId">部门主键</param>
    /// <param name="allowPrint">允许打印</param>
    /// <param name="allowEditDocuments">允许编辑</param>
    /// <param name="share">允许共享</param>
    private void AddActivity(string workFlowId, string userCode, string roleId, string organizeId, bool allowPrint, bool allowEditDocuments, bool share)
    {
        // 检查参数的有效性
        if (string.IsNullOrEmpty(workFlowId))
        {
            return;
        }
        if (string.IsNullOrEmpty(userCode) && string.IsNullOrEmpty(roleId) && string.IsNullOrEmpty(organizeId))
        {
            return;
        }
        // 添加审核流程步骤
        BaseWorkFlowActivityEntity workFlowActivityEntity = new BaseWorkFlowActivityEntity();
        workFlowActivityEntity.WorkFlowId = int.Parse(workFlowId);
        // 按用户审批
        if (!string.IsNullOrEmpty(userCode))
        {
            workFlowActivityEntity.ActivityType = "ByUser";
            if (userCode.Equals("Anyone"))
            {
                workFlowActivityEntity.AuditUserId = "Anyone";
                workFlowActivityEntity.AuditUserCode = "Anyone";
                workFlowActivityEntity.AuditUserRealName = "Anyone";
            }
            else
            {
                BaseUserManager userManager = new BaseUserManager();
                BaseUserEntity userEntity = userManager.GetEntityByCode(userCode);
                // 检查参数的有效性
                if (userEntity == null)
                {
                    return;
                }
                workFlowActivityEntity.AuditUserId = userEntity.Id.ToString();
                workFlowActivityEntity.AuditUserCode = userEntity.Code;
                workFlowActivityEntity.AuditUserRealName = userEntity.RealName;
                workFlowActivityEntity.AuditDepartmentId = userEntity.DepartmentId;
                workFlowActivityEntity.AuditDepartmentName = userEntity.DepartmentName;
            }
        }
        // 按部门审批
        if (!string.IsNullOrEmpty(organizeId))
        {
            workFlowActivityEntity.ActivityType = "ByOrganize";
            workFlowActivityEntity.AuditDepartmentId = organizeId;
            BaseOrganizeManager organizeManager = new DotNet.Business.BaseOrganizeManager();
            workFlowActivityEntity.AuditDepartmentName = organizeManager.GetEntity(organizeId).FullName;
        }
        // 按角色审批
        if (!string.IsNullOrEmpty(roleId))
        {
            workFlowActivityEntity.ActivityType = "ByRole";
            workFlowActivityEntity.AuditRoleId = roleId;
            BaseRoleManager roleManager = new DotNet.Business.BaseRoleManager();
            workFlowActivityEntity.AuditRoleRealName = roleManager.GetEntity(roleId).RealName;
        }
        workFlowActivityEntity.AllowPrint = allowPrint ? 1 : 0;
        workFlowActivityEntity.AllowEditDocuments = allowEditDocuments ? 1 : 0;
        // 无效表示共享
        workFlowActivityEntity.Enabled = share ? 0 : 1;
        workFlowActivityEntity.DeletionStateCode = 0;
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
        workFlowActivityManager.AddEntity(workFlowActivityEntity);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.TemplateId))
        {
            return;
        }

        string workFlowId = this.GetWorkFlowId();

        this.AddActivity(workFlowId, this.txtUserCode01.Text.Trim(), this.txtRole01.Value.Trim(), this.txtOrganize01.Value.Trim(), this.chkAllowPrint01.Checked, this.chkAllowEditDocuments01.Checked, this.chkShare01.Checked);
        this.AddActivity(workFlowId, this.txtUserCode02.Text.Trim(), this.txtRole02.Value.Trim(), this.txtOrganize02.Value.Trim(), this.chkAllowPrint02.Checked, this.chkAllowEditDocuments02.Checked, this.chkShare02.Checked);
        this.AddActivity(workFlowId, this.txtUserCode03.Text.Trim(), this.txtRole03.Value.Trim(), this.txtOrganize03.Value.Trim(), this.chkAllowPrint03.Checked, this.chkAllowEditDocuments03.Checked, this.chkShare03.Checked);
        this.AddActivity(workFlowId, this.txtUserCode04.Text.Trim(), this.txtRole04.Value.Trim(), this.txtOrganize04.Value.Trim(), this.chkAllowPrint04.Checked, this.chkAllowEditDocuments04.Checked, this.chkShare04.Checked);
        this.AddActivity(workFlowId, this.txtUserCode05.Text.Trim(), this.txtRole05.Value.Trim(), this.txtOrganize05.Value.Trim(), this.chkAllowPrint05.Checked, this.chkAllowEditDocuments05.Checked, this.chkShare05.Checked);
        this.AddActivity(workFlowId, this.txtUserCode06.Text.Trim(), this.txtRole06.Value.Trim(), this.txtOrganize06.Value.Trim(), this.chkAllowPrint06.Checked, this.chkAllowEditDocuments06.Checked, this.chkShare06.Checked);
        this.AddActivity(workFlowId, this.txtUserCode07.Text.Trim(), this.txtRole07.Value.Trim(), this.txtOrganize07.Value.Trim(), this.chkAllowPrint07.Checked, this.chkAllowEditDocuments07.Checked, this.chkShare07.Checked);
        this.AddActivity(workFlowId, this.txtUserCode08.Text.Trim(), this.txtRole08.Value.Trim(), this.txtOrganize08.Value.Trim(), this.chkAllowPrint08.Checked, this.chkAllowEditDocuments08.Checked, this.chkShare08.Checked);

        this.txtUserCode01.Text = string.Empty;
        this.txtRole01.Value = string.Empty;
        this.lblRole01.Text = string.Empty;
        this.txtOrganize01.Value = string.Empty;
        this.lblOrganize01.Text = string.Empty;

        this.txtUserCode02.Text = string.Empty;
        this.txtRole02.Value = string.Empty;
        this.lblRole02.Text = string.Empty;
        this.txtOrganize02.Value = string.Empty;
        this.lblOrganize02.Text = string.Empty;

        this.txtUserCode03.Text = string.Empty;
        this.txtRole03.Value = string.Empty;
        this.lblRole03.Text = string.Empty;
        this.txtOrganize03.Value = string.Empty;
        this.lblOrganize03.Text = string.Empty;

        this.txtUserCode04.Text = string.Empty;
        this.txtRole04.Value = string.Empty;
        this.lblRole04.Text = string.Empty;
        this.txtOrganize04.Value = string.Empty;
        this.lblOrganize04.Text = string.Empty;

        this.txtUserCode05.Text = string.Empty;
        this.txtRole05.Value = string.Empty;
        this.lblRole05.Text = string.Empty;
        this.txtOrganize05.Value = string.Empty;
        this.lblOrganize05.Text = string.Empty;

        this.txtUserCode06.Text = string.Empty;
        this.txtRole06.Value = string.Empty;
        this.lblRole06.Text = string.Empty;
        this.txtOrganize06.Value = string.Empty;
        this.lblOrganize06.Text = string.Empty;

        this.txtUserCode07.Text = string.Empty;
        this.txtRole07.Value = string.Empty;
        this.lblRole07.Text = string.Empty;
        this.txtOrganize07.Value = string.Empty;
        this.lblOrganize07.Text = string.Empty;

        this.txtUserCode08.Text = string.Empty;
        this.txtRole08.Value = string.Empty;
        this.lblRole08.Text = string.Empty;
        this.txtOrganize08.Value = string.Empty;
        this.lblOrganize08.Text = string.Empty;

        this.GetWorkFlowActivityList(workFlowId);
    }

    protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void ibtnPast_Click(object sender, ImageClickEventArgs e)
    {
    }
}