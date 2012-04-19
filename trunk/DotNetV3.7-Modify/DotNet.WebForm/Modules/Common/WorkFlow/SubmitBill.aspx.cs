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

public partial class SubmitBill : BasePage
{
    /// <summary>
    /// 是否允许进行人员选择
    /// </summary>
    protected bool AllowSelect = false;

    public string ObjectId
    {
        get
        {
            return this.txtObjectId.Value;
        }
        set
        {
            this.txtObjectId.Value = value;
        }
    }

    public string ObjectFullName
    {
        get
        {
            return this.txtObjectFullName.Value;
        }
        set
        {
            this.txtObjectFullName.Value = value;
        }
    }

    public string CategoryCode
    {
        get
        {
            return this.txtCategoryCode.Value;
        }
        set
        {
            this.txtCategoryCode.Value = value;
        }
    }

    public string CategoryFullName
    {
        get
        {
            return this.txtCategoryFullName.Value;
        }
        set
        {
            this.txtCategoryFullName.Value = value;
        }
    }

    public string WorkFlowCode
    {
        get
        {
            return this.txtWorkFlowCode.Value;
        }
        set
        {
            this.txtWorkFlowCode.Value = value;
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

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["ObjectId"] != null)
        {
            this.ObjectId = Page.Request["ObjectId"].ToString();
        }
        if (Page.Request["ObjectFullName"] != null)
        {
            this.ObjectFullName = Page.Request["ObjectFullName"].ToString();
        }
        if (Page.Request["CategoryCode"] != null)
        {
            this.CategoryCode = Page.Request["CategoryCode"].ToString();
        }
        if (Page.Request["CategoryFullName"] != null)
        {
            this.CategoryFullName = Page.Request["CategoryFullName"].ToString();
        }
        if (Page.Request["WorkFlowCode"] != null)
        {
            this.WorkFlowCode = Page.Request["WorkFlowCode"].ToString();
        }
        if (Page.Request["UserId"] != null)
        {
            this.UserId = Page.Request["UserId"].ToString();
        }
    }
    #endregion

    private bool ShowAlert(int rowCount, string duty)
    {
        if (rowCount == 1)
        {
            return true;
        }
        string checkInput = string.Empty;
        if (rowCount == 0)
        {
            checkInput = "<script>alert('提示信息：" + duty + "岗位有误，未设置数据、请联系系统管理员。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
        }
        if (rowCount > 1)
        {
            checkInput = "<script>alert('提示信息：" + duty + "岗位有误、设置数据有重复、请联系系统管理员。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
        }
        this.btnAutoStatr.Enabled = false;
        return false;
    }

    /// <summary>
    /// 转换流程设置(把系统内置角色喜欢为相应的岗位角色)
    /// </summary>
    /// <param name="dtWorkFlowActivity">工作审批流程</param>
    private bool TransformActivity(DataTable dtWorkFlowActivity)
    {
        bool returnValue = true;
        BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
        BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
        foreach (DataRow dataRow in dtWorkFlowActivity.Rows)
        {
            BaseWorkFlowActivityEntity activityEntity = new BaseWorkFlowActivityEntity(dataRow);
            if (!string.IsNullOrEmpty(activityEntity.AuditRoleId))
            {
                BaseRoleEntity roleEntity = roleManager.GetEntity(activityEntity.AuditRoleId);
                if (roleEntity.CategoryCode.Equals("SystemRole"))
                {
                    // 1: 计算部门负责人
                    if (roleEntity.Code.Equals("Manager"))
                    {
                        DataTable dt = roleManager.GetDataTable(
                            new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "Duty")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, "Manager")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldOrganizeId, this.UserInfo.DepartmentId)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));

                        returnValue = ShowAlert(dt.Rows.Count, "部门负责人");
                        if (!returnValue)
                        {
                            return returnValue;
                        }
                        roleEntity = new BaseRoleEntity(dt);
                    }
                    // 2: 公司分管领导
                    if (roleEntity.Code.Equals("AssistantLeadership"))
                    {
                        DataTable dt = roleManager.GetDataTable(
                            new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "Duty")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, "AssistantLeadership")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldOrganizeId, this.UserInfo.DepartmentId)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));

                        returnValue = ShowAlert(dt.Rows.Count, "部门分管领导");
                        if (!returnValue)
                        {
                            return returnValue;
                        }
                        roleEntity = new BaseRoleEntity(dt);
                    }
                    // 3: 公司领导
                    if (roleEntity.Code.Equals("Leadership"))
                    {
                        DataTable dt = roleManager.GetDataTable(
                            new KeyValuePair<string, object>(BaseRoleEntity.FieldCategoryCode, "Duty")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, "Leadership")
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldOrganizeId, this.UserInfo.CompanyId)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0)
                            , new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));

                        returnValue = ShowAlert(dt.Rows.Count, "公司领导");
                        if (!returnValue)
                        {
                            return returnValue;
                        }
                        roleEntity = new BaseRoleEntity(dt);
                    }
                    dataRow[BaseWorkFlowActivityEntity.FieldAuditRoleId] = roleEntity.Id;
                    dataRow[BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = roleEntity.RealName;
                }
                // 获取里面的用户
                DataTable dtUser = userManager.GetDataTableByRole(roleEntity.Id.ToString());
                dataRow[BaseWorkFlowActivityEntity.FieldAuditUserRealName] = BaseBusinessLogic.FieldToList(dtUser, BaseUserEntity.FieldRealName).Replace("'", "");
            }
            dtWorkFlowActivity.AcceptChanges();
        }
        return returnValue;
    }

    /// <summary>
    /// 显示单据内容
    /// 这里需要考虑外部单据的特殊情况比较好，不能只考虑内部单据。
    /// </summary>
    public void ShowDetails()
    {
        /*
        BaseWorkFlowCurrentEntity workFlowCurrentEntity = null;
        BaseWorkFlowCurrentManager workFlowCurrentManager = null;
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            // 从模板表里有效状态区分,是否模板还是报表
            this.ObjectId = workFlowCurrentEntity.ObjectId;
            this.CategoryCode = workFlowCurrentEntity.CategoryCode;
        }
        if (!string.IsNullOrEmpty(this.ObjectId))
        {
            // 这里检查一下内部单据的情况
            UserBillManager userBillManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = userBillManager.GetEntity(this.ObjectId);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                this.CategoryCode = entity.CategoryCode;
                this.ObjectId = entity.Id;
                workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
                this.CurrentId = workFlowCurrentManager.GetCurrentId(this.CategoryCode, this.ObjectId);
                if (entity.CreateUserId.Equals(this.UserInfo.Id))
                {
                    if (!(string.IsNullOrEmpty(entity.AuditStatus)
                        || entity.AuditStatus.Equals(AuditStatus.Draft.ToString())
                        || entity.AuditStatus.Equals(AuditStatus.AuditReject.ToString())))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo); 
            BaseWorkFlowActivityEntity workFlowActivityEntity = workFlowCurrentManager.GetFirstActivityEntity(workFlowCode);
            if (workFlowActivityEntity != null)
            {
                if (workFlowActivityEntity.AuditUserId.Equals("Anyone"))
                {
                    this.ShowToUser();
                    this.GetOrganizeTree();
                }
            }
        }
        */
        if (string.IsNullOrEmpty(this.WorkFlowCode))
        {
            this.WorkFlowCode = this.CategoryCode;
        }
        if (string.IsNullOrEmpty(this.WorkFlowCode))
        {
            ScriptUtil.AlertMessage("提示信息：传递参数有误，无法正确提交单据。");
        }
        if (string.IsNullOrEmpty(this.ObjectId) || string.IsNullOrEmpty(this.CategoryCode))
        {
            ScriptUtil.AlertMessage("提示信息：传递参数有误，无法正确提交单据。");
        }
        else
        {
            // 这里需要获取第一步审核的审核步骤信息
            // 这里控制，现实几个审核记录的功能才对。
            BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.WorkFlowDbHelper, this.UserInfo);
            string workFlowId = workFlowProcessManager.GetProcessId(this.UserInfo.Id, this.CategoryCode);
            if (!string.IsNullOrEmpty(workFlowId))
            {
                BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
                DataTable dtWorkFlowActivity = workFlowActivityManager.GetActivityDTById(workFlowId);
                this.TransformActivity(dtWorkFlowActivity);
                this.ShowWorkFlowActivity(dtWorkFlowActivity);

                this.tbUser.Visible = true;
                this.btnAutoStatr.Visible = true;
            }
            else
            {
                ScriptUtil.AlertMessage("提示信息：单据流程未设置，请联系系统管理员。");
            }
        }
    }

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.chkEnabled01.Enabled = this.AllowSelect;
        this.chkEnabled02.Enabled = this.AllowSelect;
        this.chkEnabled03.Enabled = this.AllowSelect;
        this.chkEnabled04.Enabled = this.AllowSelect;
        this.chkEnabled05.Enabled = this.AllowSelect;
        this.chkEnabled06.Enabled = this.AllowSelect;
        this.chkEnabled07.Enabled = this.AllowSelect;
        this.chkEnabled08.Enabled = this.AllowSelect;
        this.chkEnabled09.Enabled = this.AllowSelect;
        this.chkEnabled10.Enabled = this.AllowSelect;

        this.hlkSelectUser01.Enabled = this.AllowSelect;
        this.hlkSelectUser02.Enabled = this.AllowSelect;
        this.hlkSelectUser03.Enabled = this.AllowSelect;
        this.hlkSelectUser04.Enabled = this.AllowSelect;
        this.hlkSelectUser05.Enabled = this.AllowSelect;
        this.hlkSelectUser06.Enabled = this.AllowSelect;
        this.hlkSelectUser07.Enabled = this.AllowSelect;
        this.hlkSelectUser08.Enabled = this.AllowSelect;
        this.hlkSelectUser09.Enabled = this.AllowSelect;
        this.hlkSelectUser10.Enabled = this.AllowSelect;

        this.txtUserCode01.Enabled = this.AllowSelect;
        this.txtUserCode02.Enabled = this.AllowSelect;
        this.txtUserCode03.Enabled = this.AllowSelect;
        this.txtUserCode04.Enabled = this.AllowSelect;
        this.txtUserCode05.Enabled = this.AllowSelect;
        this.txtUserCode06.Enabled = this.AllowSelect;
        this.txtUserCode07.Enabled = this.AllowSelect;
        this.txtUserCode08.Enabled = this.AllowSelect;
        this.txtUserCode09.Enabled = this.AllowSelect;
        this.txtUserCode10.Enabled = this.AllowSelect;

    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        if (!Page.IsPostBack)
        {
            this.GetParamters();
            this.SetControlState();
            this.ShowDetails();
        }
    }

    /*
    private void ShowToUser()
    {
        this.lblOrganize.Visible = true;
        this.cmbDepartment01.Visible = true;
        this.lblUser.Visible = true;
        this.cmbUser01.Visible = true;
    }
    */

    #region private bool CheckInput()
    /// <summary>
    /// 检查输入的有效性
    /// </summary>
    /// <returns>有效</returns>
    private bool CheckInput()
    {
        bool returnValue = false;
        // 任何一个审核人都没的，需要提示一下
        if (this.chkEnabled01.Checked
            || this.chkEnabled02.Checked
            || this.chkEnabled03.Checked
            || this.chkEnabled04.Checked
            || this.chkEnabled05.Checked
            || this.chkEnabled06.Checked
            || this.chkEnabled07.Checked
            || this.chkEnabled08.Checked
            || this.chkEnabled09.Checked
            || this.chkEnabled10.Checked)
        {
            returnValue = true;
        }
        if (!returnValue)
        {
            string checkInput = "<script>alert('提示信息：请选择至少一个审核人。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            // ScriptUtil.AlertMessage("。");
            return returnValue;
        }

        // 检查下一个审核人是否为空?
        if (!this.CheckInput(this.chkEnabled01, this.txtUserCode01, this.txtOrganize01, this.txtRole01))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled02, this.txtUserCode02, this.txtOrganize02, this.txtRole02))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled03, this.txtUserCode03, this.txtOrganize03, this.txtRole03))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled04, this.txtUserCode04, this.txtOrganize04, this.txtRole04))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled05, this.txtUserCode05, this.txtOrganize05, this.txtRole05))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled06, this.txtUserCode06, this.txtOrganize06, this.txtRole06))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled07, this.txtUserCode07, this.txtOrganize07, this.txtRole07))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled08, this.txtUserCode08, this.txtOrganize08, this.txtRole08))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled09, this.txtUserCode09, this.txtOrganize09, this.txtRole09))
        {
            return false;
        }
        if (!this.CheckInput(this.chkEnabled10, this.txtUserCode10, this.txtOrganize10, this.txtRole10))
        {
            return false;
        }
        return returnValue;
    }
    #endregion

    #region private bool CheckInput(TextBox txtUserCode)
    /// <summary>
    /// 检查输入情况
    /// </summary>
    /// <param name="txtUserCode">人员</param>
    /// <returns>是否正确</returns>
    private bool CheckInput(CheckBox chkEnabled, TextBox txtUserCode, HiddenField txtOrganize, HiddenField txtRole)
    {
        bool returnValue = true;
        if (chkEnabled.Checked)
        {
            // 检查下一个审核人是否为空?
            if (txtUserCode.Enabled && txtUserCode.Visible)
            {
                txtUserCode.Text = txtUserCode.Text.Trim();
                if (txtUserCode.Text.Trim().Length == 0 && txtOrganize.Value.Trim().Length == 0 && txtRole.Value.Trim().Length == 0)
                {
                    ScriptUtil.AlertMessage("提示信息：请选择审核人,审核部门，审核角色之一。");
                    return false;
                }
                if (txtUserCode.Text.Trim().Equals("Anyone"))
                {
                    ScriptUtil.AlertMessage("提示信息：请选择审核人。");
                    return false;
                }
                if (!string.IsNullOrEmpty(txtUserCode.Text))
                {
                    BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>(3);
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, txtUserCode.Text));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                    parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                    if (!userManager.Exists(parameters))
                    {
                        ScriptUtil.AlertAndRedirect("提示信息：请选择审核人," + txtUserCode.Text + "工号不存在。", Page.Request.RawUrl);
                        return false;
                    }
                }
            }
        }
        return returnValue;
    }
    #endregion

    protected string AutoStatr()
    {
        string returnValue = string.Empty;
        try
        {
            this.WorkFlowDbHelper.Open();
            // 这里控制，现实几个审核记录的功能才对。
            BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.WorkFlowDbHelper, this.UserInfo);
            string workFlowId = workFlowProcessManager.GetProcessId(this.UserInfo.Id, this.CategoryCode);
            if (!string.IsNullOrEmpty(workFlowId))
            {
                BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
                DataTable dtWorkFlowActivity = workFlowActivityManager.GetActivityDTById(workFlowId);
                this.GetWorkFlowActivity(dtWorkFlowActivity);
                // IWorkFlowManager workFlowManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
                BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
                IWorkFlowManager workFlowManager = workFlowProcessManager.GetWorkFlowManager(workFlowId);
                returnValue = workFlowCurrentManager.AutoStatr(workFlowManager, this.ObjectId, this.ObjectFullName, this.CategoryCode, this.CategoryFullName, this.WorkFlowCode, string.Empty, dtWorkFlowActivity);
            }
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
            if (!string.IsNullOrEmpty(returnValue))
            {
                ScriptUtil.AlertAndCloseWindow("提示信息：单据提交成功。", true);
                // ScriptUtil.AlertAndRedirect("提示信息：单据提交成功。", "UserDraftAdmin.aspx");
            }
            else
            {
                ScriptUtil.AlertMessage("提示信息：单据提交失败。");
            }
        }
        return returnValue;
    }

    protected void btnAutoStatr_Click(object sender, EventArgs e)
    {
        if (this.CheckInput())
        {
            this.AutoStatr();
        }
    }

    #region private DataTable GetWorkFlowActivity(DataTable dtWorkFlowActivity)
    /// <summary>
    /// 获取审核流程
    /// </summary>
    /// <param name="dtWorkFlowActivity">审核流程定义</param>
    /// <returns>用户选择的流程</returns>
    private DataTable GetWorkFlowActivity(DataTable dtWorkFlowActivity)
    {
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        BaseUserEntity userEntity = null;
        if (this.chkEnabled01.Checked && this.rowStep01.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode01.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode01.Text);
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize01.Value))
            {
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize01.Value;
                dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize01.Text;
            }
            dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole01.Value;
            dtWorkFlowActivity.Rows[0][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole01.Text;
        }
        if (this.chkEnabled02.Checked && this.rowStep02.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode02.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode02.Text);
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize02.Value))
            {
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize02.Value;
                dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize02.Text;
            }
            dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole02.Value;
            dtWorkFlowActivity.Rows[1][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole02.Text;
        }
        if (this.chkEnabled03.Checked && this.rowStep03.Visible)
        {
            userEntity = userManager.GetEntityByCode(this.txtUserCode03.Text);
            if (!string.IsNullOrEmpty(this.txtUserCode03.Text))
            {
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize03.Value))
            {
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize03.Value;
                dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize03.Text;
            }
            dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole03.Value;
            dtWorkFlowActivity.Rows[2][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole03.Text;
        }
        if (this.chkEnabled04.Checked && this.rowStep04.Visible)
        {
            userEntity = userManager.GetEntityByCode(this.txtUserCode04.Text);
            if (!string.IsNullOrEmpty(this.txtUserCode04.Text))
            {
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize04.Value))
            {
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize04.Value;
                dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize04.Text;
            }
            dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole04.Value;
            dtWorkFlowActivity.Rows[3][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole04.Text;
        }
        if (this.chkEnabled05.Checked && this.rowStep05.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode05.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode05.Text);
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize05.Value))
            {
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize05.Value;
                dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize05.Text;
            }
            dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole05.Value;
            dtWorkFlowActivity.Rows[4][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole05.Text;
        }
        if (this.chkEnabled06.Checked && this.rowStep06.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode06.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode06.Text);
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize06.Value))
            {
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize06.Value;
                dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize06.Text;
            }
            dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole06.Value;
            dtWorkFlowActivity.Rows[5][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole06.Text;
        }
        if (this.chkEnabled07.Checked && this.rowStep07.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode07.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode07.Text);
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize07.Value))
            {
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize07.Value;
                dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize07.Text;
            }
            dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole07.Value;
            dtWorkFlowActivity.Rows[6][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole07.Text;
        }
        if (this.chkEnabled08.Checked && this.rowStep08.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode08.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode08.Text);
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize08.Value))
            {
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize08.Value;
                dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize08.Text;
            }
            dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole08.Value;
            dtWorkFlowActivity.Rows[7][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole08.Text;
        }
        if (this.chkEnabled09.Checked && this.rowStep09.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode09.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode09.Text);
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize09.Value))
            {
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize09.Value;
                dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize09.Text;
            }
            dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole09.Value;
            dtWorkFlowActivity.Rows[8][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole09.Text;
        }
        if (this.chkEnabled10.Checked && this.rowStep10.Visible)
        {
            if (!string.IsNullOrEmpty(this.txtUserCode10.Text))
            {
                userEntity = userManager.GetEntityByCode(this.txtUserCode10.Text);
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditUserId] = userEntity.Id;
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditUserCode] = userEntity.Code;
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditUserRealName] = userEntity.RealName;
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = userEntity.DepartmentId;
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = userEntity.DepartmentName;
            }
            if (!string.IsNullOrEmpty(this.txtOrganize10.Value))
            {
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditDepartmentId] = this.txtOrganize10.Value;
                dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditDepartmentName] = this.lblOrganize10.Text;
            }
            dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditRoleId] = this.txtRole10.Value;
            dtWorkFlowActivity.Rows[9][BaseWorkFlowActivityEntity.FieldAuditRoleRealName] = this.lblRole10.Text;
        }
        if (this.chkEnabled10.Enabled && !this.chkEnabled10.Checked)
        {
            dtWorkFlowActivity.Rows[9].Delete();
        }
        if (this.chkEnabled09.Enabled && !this.chkEnabled09.Checked)
        {
            dtWorkFlowActivity.Rows[8].Delete();
        }
        if (this.chkEnabled08.Enabled && !this.chkEnabled08.Checked)
        {
            dtWorkFlowActivity.Rows[7].Delete();
        }
        if (this.chkEnabled07.Enabled && !this.chkEnabled07.Checked)
        {
            dtWorkFlowActivity.Rows[6].Delete();
        }
        if (this.chkEnabled06.Enabled && !this.chkEnabled06.Checked)
        {
            dtWorkFlowActivity.Rows[5].Delete();
        }
        if (this.chkEnabled05.Enabled && !this.chkEnabled05.Checked)
        {
            dtWorkFlowActivity.Rows[4].Delete();
        }
        if (this.chkEnabled04.Enabled && !this.chkEnabled04.Checked)
        {
            dtWorkFlowActivity.Rows[3].Delete();
        }
        if (this.chkEnabled03.Enabled && !this.chkEnabled03.Checked)
        {
            dtWorkFlowActivity.Rows[2].Delete();
        }
        if (this.chkEnabled02.Enabled && !this.chkEnabled02.Checked)
        {
            dtWorkFlowActivity.Rows[1].Delete();
        }
        if (this.chkEnabled01.Enabled && !this.chkEnabled01.Checked)
        {
            dtWorkFlowActivity.Rows[0].Delete();
        }
        dtWorkFlowActivity.AcceptChanges();
        return dtWorkFlowActivity;
    }
    #endregion

    #region private void ShowWorkFlowActivity(DataTable dtWorkFlowActivity)
    /// <summary>
    /// 显示工作流程
    /// </summary>
    /// <param name="dtWorkFlowActivity">审核步骤</param>
    private void ShowWorkFlowActivity(DataTable dtWorkFlowActivity)
    {
        if (dtWorkFlowActivity == null)
        {
            this.btnAutoStatr.Enabled = false;
            return;
        }
        if (dtWorkFlowActivity.Rows.Count > 0)
        {
            // this.btnAutoStatr.Enabled = true;
        }
        this.ShowStep(dtWorkFlowActivity.Rows.Count);

        BaseWorkFlowActivityEntity workFlowActivityEntity = null;
        if (dtWorkFlowActivity.Rows.Count > 0)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[0]);
            SetStepValue(workFlowActivityEntity, "01");
        }
        if (dtWorkFlowActivity.Rows.Count > 1)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[1]);
            SetStepValue(workFlowActivityEntity, "02");
        }
        if (dtWorkFlowActivity.Rows.Count > 2)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[2]);
            SetStepValue(workFlowActivityEntity, "03");
        }
        if (dtWorkFlowActivity.Rows.Count > 3)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[3]);
            SetStepValue(workFlowActivityEntity, "04");
        }
        if (dtWorkFlowActivity.Rows.Count > 4)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[4]);
            SetStepValue(workFlowActivityEntity, "05");
        }
        if (dtWorkFlowActivity.Rows.Count > 5)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[5]);
            SetStepValue(workFlowActivityEntity, "06");
        }
        if (dtWorkFlowActivity.Rows.Count > 6)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[6]);
            SetStepValue(workFlowActivityEntity, "07");
        }
        if (dtWorkFlowActivity.Rows.Count > 7)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[7]);
            SetStepValue(workFlowActivityEntity, "08");
        }
        if (dtWorkFlowActivity.Rows.Count > 8)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[8]);
            SetStepValue(workFlowActivityEntity, "09");
        }
        if (dtWorkFlowActivity.Rows.Count > 9)
        {
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dtWorkFlowActivity.Rows[9]);
            SetStepValue(workFlowActivityEntity, "10");
        }
    }
    #endregion

    private void SetStepValue(BaseWorkFlowActivityEntity workFlowActivityEntity, string stepCode)
    {
        Label lblOrganize = (Label)this.FindControl("lblOrganize" + stepCode);
        lblOrganize.Text = workFlowActivityEntity.AuditDepartmentName;
        HiddenField txtOrganize = (HiddenField)this.FindControl("txtOrganize" + stepCode);
        txtOrganize.Value = workFlowActivityEntity.AuditDepartmentId;

        Label lblRole = (Label)this.FindControl("lblRole" + stepCode);
        lblRole.Text = workFlowActivityEntity.AuditRoleRealName;
        HiddenField txtRole = (HiddenField)this.FindControl("txtRole" + stepCode);
        txtRole.Value = workFlowActivityEntity.AuditRoleId;

        Label lblRealName = (Label)this.FindControl("lblRealName" + stepCode);
        lblRealName.Text = workFlowActivityEntity.AuditUserRealName;

        TextBox txtUserCode = (TextBox)this.FindControl("txtUserCode" + stepCode);
        HyperLink hlkSelectUser = (HyperLink)this.FindControl("hlkSelectUser" + stepCode);
        if (string.IsNullOrEmpty(workFlowActivityEntity.AuditUserRealName) || workFlowActivityEntity.AuditUserRealName.Equals("Anyone"))
        {
            txtUserCode.Enabled = true;
            hlkSelectUser.Enabled = true;
        }
        else
        {
            txtUserCode.Text = workFlowActivityEntity.AuditUserCode;
            txtUserCode.Enabled = false;
            hlkSelectUser.Visible = false;
            hlkSelectUser.Enabled = false;
        }
        if (workFlowActivityEntity.Enabled.HasValue && workFlowActivityEntity.Enabled == 0)
        {
            lblOrganize.Text = lblOrganize.Text + "(共享)";
        }
    }

    /*
    #region private void SetStepValue(BaseWorkFlowActivityEntity workFlowActivityEntity, Label lblOrganize, Label lblRealName, TextBox txtUserCode)
    /// <summary>
    /// 绑定显示部门、用户、工号信息
    /// </summary>
    /// <param name="workFlowActivityEntity">审批步骤</param>
    /// <param name="lblOrganize">部门名称</param>
    /// <param name="lblRealName">用户名称</param>
    /// <param name="txtUserCode">用户工号</param>
    /// <param name="hlkSelectUser">选择审核人</param>
    private void SetStepValue(BaseWorkFlowActivityEntity workFlowActivityEntity, Label lblOrganize, Label lblRealName, TextBox txtUserCode, HyperLink hlkSelectUser)
    {
        if (!string.IsNullOrEmpty(workFlowActivityEntity.AuditDepartmentName) && !workFlowActivityEntity.AuditDepartmentName.Equals("Anyone"))
        {
            lblOrganize.Text = workFlowActivityEntity.AuditDepartmentName;
        }
        if (string.IsNullOrEmpty(workFlowActivityEntity.AuditUserRealName) || workFlowActivityEntity.AuditUserRealName.Equals("Anyone"))
        {
            txtUserCode.Enabled = true;
            hlkSelectUser.Enabled = true;
        }
        else
        {
            txtUserCode.Text = workFlowActivityEntity.AuditUserCode;
            txtUserCode.Enabled = false;
            hlkSelectUser.Visible = false;
            hlkSelectUser.Enabled = false;
        }
        lblRealName.Text = workFlowActivityEntity.AuditUserRealName;
        if (workFlowActivityEntity.Enabled.HasValue && workFlowActivityEntity.Enabled == 0)
        {
            lblOrganize.Text = lblOrganize.Text + "(共享)";
        }
    }
    #endregion
    */

    #region private void ShowStep(int topN)
    /// <summary>
    /// 显示前几个审核步骤
    /// </summary>
    /// <param name="topN">个数</param>
    private void ShowStep(int topN)
    {
        if (topN > 0)
        {
            this.rowStep01.Visible = true;
        }
        if (topN > 1)
        {
            this.rowStep02.Visible = true;
        }
        if (topN > 2)
        {
            this.rowStep03.Visible = true;
        }
        if (topN > 3)
        {
            this.rowStep04.Visible = true;
        }
        if (topN > 4)
        {
            this.rowStep05.Visible = true;
        }
        if (topN > 5)
        {
            this.rowStep06.Visible = true;
        }
        if (topN > 6)
        {
            this.rowStep07.Visible = true;
        }
        if (topN > 7)
        {
            this.rowStep08.Visible = true;
        }
        if (topN > 8)
        {
            this.rowStep09.Visible = true;
        }
        if (topN > 9)
        {
            this.rowStep10.Visible = true;
        }
    }
    #endregion
}