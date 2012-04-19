//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class AuditList : BaseUserControl
{
    public string CurrentFlowId
    {
        get
        {
            return this.txtCurrentFlowId.Value;
        }
        set
        {
            this.txtCurrentFlowId.Value = value;
        }
    }

    public bool AutoFill
    {
        set
        {
            if (!value)
            {
                // this.grdAudit.Style.Remove("Width");
                this.grdAudit.Width = Unit.Pixel(400);
            }
            else
            {
                // this.grdAudit.Width = Unit.Pixel(100);
                this.grdAudit.Width = Unit.Percentage(100);
            }
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (String.IsNullOrEmpty(this.CurrentFlowId))
        {
            if (Page.Request["CurrentFlowId"] != null)
            {
                this.CurrentFlowId = Page.Request["CurrentFlowId"].ToString();
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
        // 审核时间是否显示?
        // this.grdAudit.Columns[this.grdAudit.Columns.Count - 1].Visible = this.UserInfo.IsAdministrator;
        // 审核状态是否显示?
        // this.grdAudit.Columns[this.grdAudit.Columns.Count - 2].Visible = this.UserInfo.IsAdministrator;
    }
    #endregion

    public int GetList(String currentFlowId)
    {
        int returnValue = 0;
        this.CurrentFlowId = currentFlowId;
        returnValue = this.GetList();
        this.SetControlState();
        return returnValue;
    }

    public int GetList()
    {
        // 读取参数
        // this.GetParamters();
        BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(this.UserInfo);
        string commandText = @" SELECT *
                                  FROM BaseWorkFlowHistory
                                 WHERE CurrentFlowId = '" + this.CurrentFlowId + @"'
                              ORDER BY SendDate";
        DataTable dataTable = workFlowHistoryManager.Fill(commandText);
        // 空的审核意见是否显示?
        BaseBusinessLogic.SetFilter(dataTable, BaseWorkFlowCurrentEntity.FieldAuditIdea, null, true);
        this.grdAudit.DataSource = dataTable;
        this.grdAudit.DataBind();
        return dataTable.Rows.Count;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        // if (!Page.IsPostBack)
        //{
        //    this.GetList();
        // }
    }

    protected void grdAudit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // 回车换行的功能
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string commentContent = dataRowView[BaseWorkFlowHistoryTable.FieldAuditIdea].ToString();
            e.Row.Cells[1].Text = commentContent.Replace("\r\n", "<br>");
            // e.Row.Cells[2].Text = BaseBusinessLogic.GetAuditStatus(dataRowView[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
        }
    }
}