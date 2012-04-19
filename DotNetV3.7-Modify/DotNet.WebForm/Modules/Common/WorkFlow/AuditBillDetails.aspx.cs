//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using DotNet.Business;
using DotNet.Utilities;

/// <summary>
/// UserBillDetails
/// 设置工作流
///   1: 每个用户可以在这个页面设置自己的工作流。
///
/// 修改纪录
///
///		2011-10-07 版本：1.1 JiRiGaLa 显示单据内容优化。
///		2011-09-03 版本：1.0 JiRiGaLa 创建主键。
///
/// 版本：1.1
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011-10-07</date>
/// </author>
/// </summary>
public partial class UserBillDetails : BasePage
{
    /// <summary>
    /// 当前工作流主键
    /// </summary>
    private string CurrentId
    {
        get
        {
            return this.txtCurrentId.Value;
        }
        set
        {
            this.txtCurrentId.Value = value;
        }
    }

    /// <summary>
    /// 当前实体主键
    /// </summary>
    private string ObjectId
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

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["Id"] != null)
        {
            this.CurrentId = Page.Request["Id"].ToString();
        }
        if (Page.Request["ObjectId"] != null)
        {
            this.ObjectId = Page.Request["ObjectId"].ToString();
        }
    }
    #endregion

    private string iframeUrl = string.Empty;
    public string IframeUrl
    {
        get
        {
            return iframeUrl;
        }
        set
        {
            iframeUrl = value;
        }
    }


    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        this.ShowDetails();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    private void ShowDetails()
    {
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager();
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            this.Title = workFlowCurrentEntity.ObjectFullName;
            // 从模板表里有效状态区分,是否模板还是报表
            this.ObjectId = workFlowCurrentEntity.ObjectId;
            // this.ucComment.ObjectId = workFlowCurrentEntity.ObjectId;
            // this.ucCommentList.ObjectId = workFlowCurrentEntity.ObjectId;
            string categoryCode = workFlowCurrentEntity.CategoryCode;

            BaseWorkFlowActivityEntity workFlowActivityEntity = null;
            this.CurrentId = Server.HtmlEncode(this.CurrentId);

            // 若是单据,就显示单据
            this.IframeUrl = "<iframe width='100%' height='100%' frameborder='0' scrolling='auto' src='ShowUserBill.aspx?Id=" + this.CurrentId + "&ReadOnly=True&'></iframe>>";
            this.btnEdit.Visible = false;
            // 检查是否允许编辑
            if (workFlowCurrentEntity.ActivityId != null)
            {
                BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
                workFlowActivityEntity = workFlowActivityManager.GetEntity(workFlowCurrentEntity.ActivityId.ToString());
                this.btnEdit.Visible = (workFlowActivityEntity.AllowEditDocuments == 1);
            }
            
            this.GetBackTo(workFlowCurrentEntity);
            // this.lblWorkFlowActivity.Text = this.GetWorkFlowActivity(workFlowCurrentEntity);
            this.ucAuditList.GetList(workFlowCurrentEntity.Id);
            this.SetControlState(workFlowCurrentEntity);

            /*
            workFlowActivityEntity = workFlowCurrentManager.GetNextWorkFlowActivity(workFlowCurrentEntity);
            if (workFlowActivityEntity != null)
            {
                if (!string.IsNullOrEmpty(workFlowActivityEntity.AuditUserId))
                {
                    if (workFlowActivityEntity.AuditUserId.Equals("Anyone"))
                    {
                        this.ShowToUser();
                        this.GetOrganizeTree();
                    }
                }
            }
            */
        }
    }

    /// <summary>
    /// 获取撤销到
    /// </summary>
    /// <param name="workFlowCurrentEntity">当前审批流程</param>
    private void GetBackTo(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        // 工作流的定义主键,若是被退回的,就没其他好可退回的余地了
        if (workFlowCurrentEntity.ActivityId != null)
        {
            BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
            DataTable backToDataTable = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity);
            this.cmbBackTo.DataSource = backToDataTable;
            this.cmbBackTo.DataTextField = BaseWorkFlowHistoryTable.FieldAuditUserRealName;
            this.cmbBackTo.DataValueField = BaseWorkFlowHistoryTable.FieldId;
            this.cmbBackTo.DataBind();
        }
        this.cmbBackTo.Visible = this.cmbBackTo.Items.Count > 1;
        this.lblBackTo.Visible = this.cmbBackTo.Items.Count > 1;
        this.btnAuditBack.Visible = this.cmbBackTo.Items.Count > 1;
    }

    /// <summary>
    /// 获取审批流程步骤
    /// </summary>
    /// <returns>审批流程</returns>
    private string GetWorkFlowActivity(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        string retuanValue = string.Empty;
        // 工作流的定义主键
        string workFlowId = string.Empty;
        string workFlowCode = workFlowCurrentEntity.CreateUserId + "_" + workFlowCurrentEntity.CategoryCode;
        BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager();
        workFlowId = workFlowProcessManager.GetIdByCode(workFlowCode);
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager();
        if (!string.IsNullOrEmpty(workFlowId))
        {
            retuanValue = workFlowActivityManager.GetWorkFlowActivity(workFlowId);
        }
        return retuanValue;
    }

    /// <summary>
    /// 获取已审核历史
    /// </summary>
    /// <returns>审批流程</returns>
    private string GetAuditRecord(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        BaseWorkFlowHistoryManager workFlowProcessManager = new BaseWorkFlowHistoryManager();
        return workFlowProcessManager.GetAuditRecord(workFlowCurrentEntity.Id);
    }

    #region private void SetControlState(BaseWorkFlowCurrentEntity workFlowCurrentEntity) 设置按钮状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditComplete) ||
            workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditQuash))
        {
            this.btnAuditPass.Enabled = false;
            this.btnAuditReject.Enabled = false;
            this.btnAuditQuash.Enabled = false;
            this.txtAuditIdea.Enabled = false;
            this.btnAuditBack.Enabled = false;
        }
    }
    #endregion

    #region private bool CheckInput()
    /// <summary>
    /// 检查输入的有效性
    /// </summary>
    /// <returns>有效</returns>
    private bool CheckInput()
    {
        bool returnValue = true;
        string checkInput = string.Empty;
        // 检查下一个审核人是否为空?
        if (this.cmbUser.Visible)
        {
            if (this.cmbUser.Text.Trim().Length == 0)
            {
                ScriptUtil.AlertAndRedirect("提示信息：请选择下一个审核人。", Page.Request.RawUrl);
                // checkInput = "<script>alert('提示信息：请选择下一个审核人。'); </script>";
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
                return false;
            }
        }
        return returnValue;
    }
    #endregion
    
    private bool AuditPass()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        // 这里是跳过审核的意思
        // if (this.cmbUser.Visible)
        //{
        //   return workFlowCurrentManager.AutoAuditPass(this.CurrentId, this.txtAuditIdea.Text, this.cmbUser.SelectedValue) > 0;
        //}
        return workFlowCurrentManager.AutoAuditPass(this.CurrentId, this.txtAuditIdea.Text) > 0;
    }

    protected void btnAuditPass_Click(object sender, EventArgs e)
    {
        if (this.CheckInput())
        {
            if (this.AuditPass())
            {
                Utilities.CloseWindow(true);
                // Page.Response.Redirect("WorkFlowWaitForAudit.aspx");
            }
        }
    }

    private bool AuditReject()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        return workFlowCurrentManager.AuditReject(this.CurrentId, this.txtAuditIdea.Text) > 0;
    }

    protected void btnAuditReject_Click(object sender, EventArgs e)
    {
        if (this.AuditReject())
        {
            Utilities.CloseWindow(true);
            // Page.Response.Redirect("WorkFlowWaitForAudit.aspx");
        }
    }

    private bool AuditQuash()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        workFlowCurrentManager.AuditQuash(this.CurrentId, this.txtAuditIdea.Text);
        return true;
    }

    protected void btnAuditQuash_Click(object sender, EventArgs e)
    {
        if (this.AuditQuash())
        {
            Utilities.CloseWindow(true);
            // Page.Response.Redirect("WorkFlowWaitForAudit.aspx");
        }
    }

    private bool AuditBack()
    {
        if (!string.IsNullOrEmpty(this.cmbBackTo.SelectedValue))
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            workFlowCurrentManager.AuditReject(this.CurrentId, this.txtAuditIdea.Text, int.Parse(this.cmbBackTo.SelectedValue));
            return true;
        }
        return false;
    }

    protected void btnAuditBack_Click(object sender, EventArgs e)
    {
        if (this.AuditBack())
        {
            Utilities.CloseWindow(true);
            // Page.Response.Redirect("WorkFlowWaitForAudit.aspx");
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // 导向编辑页面
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager();
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            string categoryCode = workFlowCurrentEntity.CategoryCode;
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            string editPage = templateManager.GetEditPage(categoryCode);
            editPage = editPage.Replace("{Id}", this.ObjectId);
            Page.Response.Redirect(editPage);
        }
    }

    protected void btnAttachment_Click(object sender, EventArgs e)
    {
        UserBillManager billManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
        BaseNewsEntity entity = billManager.GetEntity(this.ObjectId);
        string templateSource = "html";
        if (entity != null && !string.IsNullOrEmpty(entity.Id))
        {
            templateSource = entity.Source;
        }
        string url = "BillAttachment.aspx?Id=" + this.ObjectId + "&ReturnURL=" + Server.UrlEncode("AuditBillDetails.aspx?Id=" + this.CurrentId);
        if (templateSource.Equals("xls"))
        {
            url = "BillAttachment.aspx?Id=" + this.ObjectId + "&ReturnURL=" + Server.UrlEncode("AuditBillDetails.aspx?Id=" + this.CurrentId);
        }
        Page.Response.Redirect(url);
    }

    private void ShowToUser()
    {
        this.lblDepartment.Visible = true;
        this.cmbDepartment.Visible = true;
        this.lblUser.Visible = true;
        this.cmbUser.Visible = true;
    }

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

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.cmbUser.Items.Clear();
        if (!string.IsNullOrEmpty(this.cmbDepartment.SelectedValue))
        {
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            DataTable userTable = userManager.GetDataTableByDepartment(this.cmbDepartment.SelectedValue);
            this.cmbUser.DataValueField = BaseUserEntity.FieldId;
            this.cmbUser.DataTextField = BaseUserEntity.FieldRealName;
            this.cmbUser.DataSource = userTable;
            this.cmbUser.DataBind();
            this.cmbUser.Items.Insert(0, new ListItem());
        }
    }
}