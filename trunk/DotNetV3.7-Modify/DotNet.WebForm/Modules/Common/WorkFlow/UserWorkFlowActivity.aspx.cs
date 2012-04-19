//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;

/// <summary>
/// UserWorkFlowActivity
/// 设置用作流审核步骤
///   1: 用户信息显示，指定用户的工号、姓名、所在部门？
///   2：工作流类别名称显示、要制定哪个类别的工作流？
///   3：若没存在此工作流，就应该新增一个这样的工作流，然后才可以设定工作流
///   3：工作流的步骤显示，可以排序，删除步骤，删除时需要提示。
///   4：可以增加审核步骤？
///   5：可以快速定义其他类型的工作流的步骤。 
///   6：可以方便添加到常用联系人列表里。
///   7：若没传递用户参数，就是设置自己的工作流程。
///
/// 修改纪录
///
///		2011-09-05 版本：1.0 JiRiGaLa 创建主键。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011-09-05</date>
/// </author>
/// </summary>
public partial class UserWorkFlowActivity : BasePage
{
    /// <summary>
    /// 用户主键 
    /// + 工作流编号
    /// </summary>
    private string UserWorkFlowId
    {
        get
        {
            return this.txtUserWorkFlowId.Value;
        }
        set
        {
            this.txtUserWorkFlowId.Value = value;
        }
    }

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
        if (Page.Request["UserWorkFlowId"] != null)
        {
            this.UserWorkFlowId = Page.Request["UserWorkFlowId"].ToString();
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

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetItemDetails();
        string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
        this.GetWorkFlowList();
        this.GetWorkFlowActivityList(workFlowId);
        this.GetUserInfo();
        this.SetControlState();
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (this.grdWorkFlowActivity.Rows.Count > 0)
        {
            this.ibtnCopy.Visible = true;
        }
        else
        {
            this.ibtnCopy.Visible = false;
        }
        if (Session[BaseWorkFlowActivityEntity.TableName] != null)
        {
            this.ibtnPast.Visible = true;
        }
        else
        {
            this.ibtnPast.Visible = false;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.GetParamter();
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    private void GetUserInfo()
    {
        BaseUserManager userManager = new BaseUserManager();
        BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
        this.lblCode.Text = userEntity.Code;
        this.lblRealName.Text = userEntity.RealName;
        this.lblOrganizeName.Text = userEntity.DepartmentName;
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
        DataTable dataTable = templateManager.Search(string.Empty, this.cmbCategory.SelectedValue, string.Empty, null, false);
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
        string userWorkFlowId = this.UserId + "_" + this.grdWorkFlow.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        Page.Response.Redirect("UserWorkFlowActivity.aspx?UserWorkFlowId=" + userWorkFlowId);
    }

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
            string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
            this.GetWorkFlowActivityList(workFlowId);
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
            string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
            this.GetWorkFlowActivityList(workFlowId);
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

    protected void grdWorkFlowActivity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.grdWorkFlowActivity.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
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

    /// <summary>
    /// 获取工作流的主键
    /// </summary>
    /// <param name="userWorkFlowId">工作流编号</param>
    /// <returns>主键</returns>
    private string GetWorkFlowId(string userWorkFlowId)
    {
        // 参数有消化，去掉多余的空格
        userWorkFlowId = userWorkFlowId.Trim();
        // 工作流主键
        string id = string.Empty;
        string workFlowId = string.Empty;
        // 检查输入参数的有效性
        if (string.IsNullOrEmpty(userWorkFlowId))
        {
            return id;
        }
        else
        {
            string[] workFlows = userWorkFlowId.Split('_');
            // 检查参数的有效性
            if (workFlows.Length == 2)
            {
                this.UserId = workFlows[0];
                workFlowId = workFlows[1];
            }
            else
            {
                return id;
            }
        }
        // 获取工作流主键
        BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.WorkFlowDbHelper, this.UserInfo);
        id = workFlowProcessManager.GetId(
            new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldBillTemplateId, workFlowId)
            , new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldUserId, this.UserId)
            , new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));
        // 若工作流不存在，自动添加一个工作流程
        if (!string.IsNullOrEmpty(id))
        {
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = templateManager.GetEntity(workFlowId);
            this.lblWorkFlowActivity.Text = entity.Introduction;
            this.lblWorkFlow.Text = entity.Title;
        }
        else
        {
            // 计算工作流类别、用户信息等
            string userId = string.Empty;
            workFlowId = string.Empty;
            string[] workFlows = userWorkFlowId.Split('_');
            // 检查参数的有效性
            if (workFlows.Length != 2)
            {
                return id;
            }
            this.UserId = workFlows[0];
            userId = workFlows[0];
            workFlowId = workFlows[1];
            // 检查参数的有效性
            if (string.IsNullOrEmpty(userId))
            {
                return id;
            }
            // 检查参数的有效性
            if (string.IsNullOrEmpty(workFlowId))
            {
                return id;
            }
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
            // 获取工作流的信息
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity fileEntity = templateManager.GetEntity(workFlowId);
            // 显示标准工作流
            this.lblWorkFlowActivity.Text = fileEntity.Introduction;
            this.lblWorkFlow.Text = fileEntity.Title;
            // 添加工作流主表
            BaseWorkFlowProcessEntity entity = new BaseWorkFlowProcessEntity();
            entity.BillTemplateId = workFlowId;
            // entity.OrganizeId = userEntity.DepartmentId;
            entity.UserId = userEntity.Id;
            entity.Code = fileEntity.Code;
            entity.CategoryCode = fileEntity.CategoryCode;
            entity.FullName = userEntity.RealName + "." + fileEntity.Title + " 审核流程定义";
            entity.AuditCategoryCode = "ByUser";
            entity.Description = "ByUserByTemplate 按用户的单据进行审核";
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
        if (string.IsNullOrEmpty(userCode) && string.IsNullOrEmpty(roleId) && string.IsNullOrEmpty(organizeId))
        {
            return;
        }
        if (string.IsNullOrEmpty(workFlowId))
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
        workFlowActivityEntity.AllowPrint = allowPrint ? 1:0;
        workFlowActivityEntity.AllowEditDocuments = allowEditDocuments ? 1 : 0;
        // 无效表示共享
        workFlowActivityEntity.Enabled = share ? 0 : 1;
        workFlowActivityEntity.DeletionStateCode = 0;
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
        workFlowActivityManager.AddEntity(workFlowActivityEntity);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.UserWorkFlowId))
        {
            return;
        }
        string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
        if (string.IsNullOrEmpty(workFlowId))
        {
            return;
        }

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
        string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
        Session[BaseWorkFlowActivityEntity.TableName] = this.GetWorkFlowActivityList(workFlowId);
        this.SetControlState();
    }

    protected void ibtnPast_Click(object sender, ImageClickEventArgs e)
    {
        string workFlowId = this.GetWorkFlowId(this.UserWorkFlowId);
        if (Session[BaseWorkFlowActivityEntity.TableName] != null)
        {
            BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseSequenceManager sequenceManager = new BaseSequenceManager(this.UserCenterDbHelper, this.UserInfo);
            DataTable dt = (DataTable)Session[BaseWorkFlowActivityEntity.TableName];
            BaseWorkFlowActivityEntity workFlowActivityEntity = new BaseWorkFlowActivityEntity();
            foreach (DataRow dataRow in dt.Rows)
            {
                workFlowActivityEntity = new BaseWorkFlowActivityEntity(dataRow);
                workFlowActivityEntity.WorkFlowId = int.Parse(workFlowId);
                workFlowActivityEntity.SortCode = int.Parse(sequenceManager.GetSequence(BaseWorkFlowActivityEntity.TableName));
                workFlowActivityManager.AddEntity(workFlowActivityEntity);
            }
        }
        this.GetWorkFlowActivityList(workFlowId);
    }
}