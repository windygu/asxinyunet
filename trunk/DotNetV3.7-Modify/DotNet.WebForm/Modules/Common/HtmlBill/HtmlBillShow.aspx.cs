//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class HtmlBillShow : BasePage
{
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
        if (Page.Request["Id"] != null)
        {
            this.ObjectId = Page.Request["Id"].ToString();
        }
        if (Page.Request["CurrentId"] != null)
        {
            this.CurrentId = Page.Request["CurrentId"].ToString();
        }
    }
    #endregion

    /// <summary>
    /// 显示单据内容
    /// </summary>
    public void ShowDetails(string objectId = null, bool allowDelete = false)
    {
        if (objectId != null)
        {
            this.ObjectId = objectId;
        }

        BaseWorkFlowCurrentEntity workFlowCurrentEntity = null;
        BaseWorkFlowCurrentManager workFlowCurrentManager = null;
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            // 从模板表里有效状态区分,是否模板还是报表
            this.ObjectId = workFlowCurrentEntity.ObjectId;
        }
        if (!string.IsNullOrEmpty(this.ObjectId))
        {
            UserBillManager userBillManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity newsEntity = userBillManager.GetEntity(this.ObjectId);
            if (newsEntity != null)
            {
                this.lblUserBill.Text = newsEntity.Contents;
                this.AttachmentHtmlBill.AllowDelete = allowDelete;
                this.trAttachment.Visible = this.AttachmentHtmlBill.GetAttachmentList("Attachment", newsEntity.Id) > 0;
            }
        }
    }

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