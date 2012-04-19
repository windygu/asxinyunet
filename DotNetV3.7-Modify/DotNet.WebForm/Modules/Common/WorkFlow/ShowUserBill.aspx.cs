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

public partial class ShowUserBill : BasePage
{
    private bool showAuditList = false;
    /// <summary>
    /// 是否显示批示
    /// </summary>
    public bool ShowAuditList
    {
        get
        {
            return this.showAuditList;
        }
        set
        {
            this.showAuditList = value;
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

    public string CurrentId
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
        if (Page.Request["ObjectId"] != null)
        {
            this.ObjectId = Page.Request["ObjectId"].ToString();
        }
        if (Page.Request["Id"] != null)
        {
            this.CurrentId = Page.Request["Id"].ToString();
        }
        if (Page.Request["CurrentId"] != null)
        {
            this.CurrentId = Page.Request["CurrentId"].ToString();
        }
        if (Page.Request["ShowAuditList"] != null)
        {
            this.ShowAuditList = Page.Request["ShowAuditList"].ToString().Equals(true.ToString());
        }
    }
    #endregion

    /// <summary>
    /// 显示单据内容
    /// </summary>
    public void ShowDetails()
    {
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
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            string showPage = templateManager.GetShowPage(this.CategoryCode);
            this.IframeUrl = showPage.Replace("{Id}", this.ObjectId);
            // this.IframeUrl = "<iframe width='100%' height='100%' frameborder='0' scrolling='auto' src='HtmlBill.aspx?ObjectId=" + this.ObjectId + "&ReadOnly=True&'></iframe>";
            // this.IframeUrl = "<!-- #INCLUDE FILE=\"HtmlBill.aspx?ObjectId=" + this.ObjectId + "\" -->";
            // this.IframeUrl = "<!-- #INCLUDE FILE='" + showPage + "' -->";
        }
        bool readOnly = false;
        if (Page.Request["ReadOnly"] != null)
        {
            readOnly = true;
        }
        if (this.ShowAuditList)
        {
            this.ucAuditList.GetList(this.CurrentId);
        }
        if (readOnly)
        {
            this.GetReportSignature();
        }
    }


    private DataTable GetReportSignatureDate(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        DataTable signatureDateDT = null;
        if (!string.IsNullOrEmpty(workFlowCurrentEntity.Id))
        {
            BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(this.UserInfo);
            signatureDateDT = workFlowHistoryManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowHistoryTable.FieldCurrentFlowId, workFlowCurrentEntity.Id), BaseWorkFlowHistoryTable.FieldCreateOn + " DESC");
        }
        return signatureDateDT;
    }

    private string GetReportSignatureDate(DataTable signatureDateDT, string activityId, out string userId)
    {
        userId = string.Empty;
        string returnValue = string.Empty;
        if (signatureDateDT != null)
        {
            foreach (DataRow dataRow in signatureDateDT.Rows)
            {
                if (dataRow[BaseWorkFlowHistoryTable.FieldActivityId].ToString().Equals(activityId))
                {
                    if (dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.AuditPass.ToString())
                        || dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.AuditComplete.ToString())
                        || dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.WaitForAudit.ToString())
                        )
                    {
                        userId = dataRow[BaseWorkFlowHistoryTable.FieldAuditUserId].ToString();
                        returnValue = dataRow[BaseWorkFlowHistoryTable.FieldAuditDate].ToString();
                        break;
                    }
                }
            }
        }
        return returnValue;
    }

    public string UserSignatureDate1 = string.Empty;
    public string UserSignatureDate2 = string.Empty;
    public string UserSignatureDate3 = string.Empty;
    public string UserSignatureDate4 = string.Empty;
    public string UserSignatureDate5 = string.Empty;
    public string UserSignatureDate6 = string.Empty;
    public string UserSignatureDate7 = string.Empty;
    public string UserSignatureDate8 = string.Empty;

    #region private void GetReportSignature()
    /// <summary>
    /// 获取报表签名
    /// </summary>
    private void GetReportSignature()
    {
        if (string.IsNullOrEmpty(this.CurrentId))
        {
            return;
        }
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
        BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
        // 通过当前的工作流主键,获得当前的审批流程主键
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.UserInfo);
        // 通过审批步骤,获取当前的用户
        // 再看当前用户,有审批通过否?再能确认是否审核通过
        // 当前是审核到了第几步了.是否有被退回情况等,需要确认.
        DataTable dt = null;
        string userId = string.Empty;
        if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
            || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity);
        }
        else if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditComplete.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity.Id, workFlowCurrentEntity.WorkFlowId.ToString());
        }
        if (dt != null)
        {
            dt.Columns.Remove("Id");
            dt.Columns["ActivityId"].ColumnName = "Id";
            BaseBusinessLogic.SetFilter(dt, "Id", null, true);
        }
        if (dt != null)
        {
            DataTable signatureDateDT = GetReportSignatureDate(workFlowCurrentEntity);
            int userSignature = 0;
            string activityId = string.Empty;
            string userSignatureDate = string.Empty;
            userSignature = 1;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate1 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 2;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate2 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 3;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate3 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 4;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate4 = DateTime.Parse(userSignatureDate).ToString("yy-MM-dd");
                }
            }
            userSignature = 5;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate5 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 6;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate6 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 7;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate7 = DateTime.Parse(userSignatureDate).ToString("MM-dd HH:mm");
                }
            }
            userSignature = 8;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userSignatureDate))
                {
                    UserSignatureDate8 = DateTime.Parse(userSignatureDate).ToString("yy-MM-dd");
                }
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        if (!Page.IsPostBack)
        {
            this.GetParamters();
            this.ShowDetails();
        }
    }
}