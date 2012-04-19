//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;
using Project;

/// <remarks>
/// AddMaintain
/// 提交申请
///     
///     2012.04.06 版本：1.2  zgl 规范代码
///     2012.04.06 版本：1.1  zgl 使用ViewState保存EntityId和ReturnURL
///     2012.03.14 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012.03.14</date>
/// </author>
/// </remarks>
public partial class AddMaintain : BasePage
{
    /// <summary>
    /// 主键
    /// </summary>
    private string EntityId
    {
        get
        {
            return ViewState["EntityId"] as string;
        }
        set
        {
            ViewState["EntityId"] = value;
        }
    }

    /// <summary>
    /// 返回页面
    /// </summary>
    public string ReturnURL
    {
        get
        {
            return ViewState["ReturnURL"] as string;
        }
        set
        {
            ViewState["ReturnURL"] = value;
        }
    }

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["ID"] != null)
        {
            this.EntityId = Page.Request["ID"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsBugCategory");
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode);
        this.cmbBugCategory.DataSource = dataTable;
        this.cmbBugCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbBugCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbBugCategory.DataBind();
        this.cmbBugCategory.Items.Insert(0, new ListItem());
    }
    #endregion

    #region private void ShowEntity() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntity()
    {
        if (!string.IsNullOrEmpty(this.EntityId))
        {
            MaintainEntity entity = new MaintainManager(this.UserInfo).GetEntity(this.EntityId);
            this.UserInfo.RealName = entity.CreateBy;
            this.UserInfo.Code = entity.UserCode;
            this.UserInfo.DepartmentName = entity.DepartmentName;
            this.txtTelephone.Text = entity.Telephone;
            this.txtOfficeLocation.Text = entity.OfficeLocation;
            this.cmbBugCategory.SelectedValue = entity.BugCategory;
            this.txtIP.Text = entity.IP;
            this.txtMalfunctionCause.Text = entity.MalfunctionCause;
            this.txtComputerUserName.Text = entity.ComputerUserName;
            this.txtComputerPassword.Text = entity.ComputerPassword;
            this.txtDescription.Text = entity.Description;
        }
        else
        {
            this.lblRealName.Text = this.UserInfo.RealName;
            this.lblUserCode.Text = this.UserInfo.Code;
            this.lblDepartmentName.Text = this.UserInfo.DepartmentName;
            this.lblReportingTime.Text = DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat);
            this.txtIP.Text = this.UserInfo.IPAddress;
            BaseUserEntity userEntity = new BaseUserManager().GetEntity(this.UserInfo.Id);
            if (userEntity != null)
            {
                this.txtTelephone.Text = userEntity.Telephone;
            }
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 检查是否登录
        Utilities.CheckIsLogOn();
        // 下拉框数据
        this.GetItemDetails();
        // 显示实体
        this.ShowEntity();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private MaintainEntity GetEntity() 获取实体
    /// <summary>
    /// 获取实体
    /// </summary>
    /// <returns>实体</returns>
    private MaintainEntity GetEntity()
    {
        MaintainEntity entity = null;
        if (string.IsNullOrEmpty(this.EntityId))
        {
            entity = new MaintainEntity();
        }
        else
        {
            entity = new MaintainManager(this.UserInfo).GetEntity(this.EntityId);
        }
        entity.CreateBy = this.UserInfo.RealName;
        entity.UserCode = this.UserInfo.Code;
        entity.DepartmentName = this.UserInfo.DepartmentName;
        entity.DepartmentId = this.UserInfo.DepartmentId;
        entity.Telephone = this.txtTelephone.Text;
        entity.OfficeLocation = this.txtOfficeLocation.Text;
        entity.ReportingTime = DateTime.Now;
        entity.BugCategory = this.cmbBugCategory.SelectedValue;
        entity.MalfunctionCause = this.txtMalfunctionCause.Text;
        entity.IP = this.txtIP.Text;
        entity.ComputerUserName = this.txtComputerUserName.Text;
        entity.ComputerPassword = this.txtComputerPassword.Text;
        entity.Description = this.txtDescription.Text;
        entity.Enabled = 0;
        entity.DeletionStateCode = 0;
        return entity;
    }
    #endregion

    #region private string Add(bool submit = true, bool workFlowSend = false) 新增
    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="submit">提交</param>
    /// <param name="workFlowSend">流程化提交</param>
    /// <returns>主键</returns>
    private string Add(bool submit = true, bool workFlowSend = false)
    {
        string returnValue = string.Empty;
        MaintainEntity entity = this.GetEntity();
        // 默认是草稿状态
        entity.ServiceState = MaintainStatus.Draft.ToDescription();
        if (string.IsNullOrEmpty(this.EntityId))
        {
            // 进行添加处理
            this.EntityId = new MaintainManager(this.UserInfo).Add(entity);
        }
        else
        {
            // 进行更新处理
            new MaintainManager(this.UserInfo).Update(entity);
        }
        if (submit)
        {
            // 是否流程化提交
            if (workFlowSend)
            {
                // 1: 先需要有流程定义才对，按审批流程的编号进行唯一定位。
                // 2: 需要有当前对象的唯一主键。
                // 3: 需要能自动启动审批流程，审批流程里应该都是很明确的人比较好。
                // 4: 也可以考虑出来审批流程界面的方法。
                // 5: 提示信息也需要弄好，界面也需要友善比较好。
                string categoryCode = "Maintain";
                WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
                categoryCode = templateManager.GetIdByCode(categoryCode);
                Page.Response.Redirect("../WorkFlow/SubmitBill.aspx?CategoryCode=" + categoryCode + "&ObjectId=" + this.EntityId);

                // 这里是直接提交的方法
                // IWorkFlowManager userReportManager = new UserReportManager(this.UserInfo);
                // BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
                // returnValue = workFlowCurrentManager.AutoStatr(userReportManager, this.CategoryCode, categoryFullName, this.ObjectId, objectFullName, workFlowCode, auditIdea);
            }
            else
            {
                MaintainManager maintainManager = new MaintainManager(this.UserInfo);
                maintainManager.SetSend(new string[] { returnValue });
                Page.Response.Redirect("SubmittedMaintain.aspx");
            }
        }
        else
        {
            Page.Response.Redirect("SubmitMaintain.aspx");
        }
        return returnValue;
    }
    #endregion

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        // 服务器端第二次验证，在客户端JS关闭时有用
        MaintainValidate();
        // 保存为草稿
        this.Add(false);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        // 服务器端第二次验证，在客户端JS关闭时有用
        MaintainValidate();
        // 保存并提交
        this.Add(true);
    }

    protected void btnWorkFlowSend_Click(object sender, EventArgs e)
    {
        // 服务器端第二次验证，在客户端JS关闭时有用
        MaintainValidate();
        // 保存并流程化提交
        this.Add(true, true);
    }

    #region private void Reset() 重置
    /// <summary>
    /// 重置
    /// </summary>
    private void Reset()
    {
        this.cmbBugCategory.SelectedValue = null;
        this.txtMalfunctionCause.Text = string.Empty;
        this.txtComputerUserName.Text = string.Empty;
        this.txtComputerPassword.Text = string.Empty;
        this.txtDescription.Text = string.Empty;
    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {
        // 重置
        this.Reset();
    }

    protected void MaintainValidate()
    {
        // 用户的登录操作
        /*为了登录方便暂时屏蔽*/
        if (string.IsNullOrEmpty(this.txtMalfunctionCause.Text.Trim()) || string.IsNullOrEmpty(this.txtDescription.Text.Trim()))
        {
            ScriptUtil.Alert("故障原因和问题描述不能为空。");
            return;
        }
    }
}