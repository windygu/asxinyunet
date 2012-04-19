//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// Leave
/// 显示
///
/// 2012-04-13 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.0
///
/// <author>
///	<name>JiRiGaLa</name>
///	<date>2012-04-13</date>
/// </author>
/// </remarks>
public partial class LeaveShow : BasePage
{
	/// <summary>
    /// 是否按工作流方式运行
    /// </summary>
    bool UseWorkFlow = true;

    /// <summary>
    /// 主键
    /// </summary>
    private string EntityId
    {
        get
        {
            return this.txtId.Value;
        }
        set
        {
            this.txtId.Value = value;
        }
    }

    /// <summary>
    /// 返回页面
    /// </summary>
    public string ReturnURL
    {
        get
        {
            return this.txtReturnURL.Value;
        }
        set
        {
            this.txtReturnURL.Value = value;
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
            this.EntityId = Page.Request["Id"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

     #region private void ShowEntity()
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntity()
    {
        LeaveEntity entity = new LeaveManager(this.UserInfo).GetEntity(this.EntityId);
		if (entity.UserName != null)
		{
		    this.lblUserName.Text = entity.UserName.Replace("\r\n", "<br>");
		}
		if (entity.DepartmentName != null)
		{
		    this.lblDepartmentName.Text = entity.DepartmentName.Replace("\r\n", "<br>");
		}
		if (entity.Code != null)
		{
		    this.lblCode.Text = entity.Code.Replace("\r\n", "<br>");
		}
		if (entity.TransferOfPeople != null)
		{
		    this.lblTransferOfPeople.Text = entity.TransferOfPeople.Replace("\r\n", "<br>");
		}
		if (entity.Telephone != null)
		{
		    this.lblTelephone.Text = entity.Telephone.Replace("\r\n", "<br>");
		}
		if (entity.Reason != null)
		{
		    this.lblReason.Text = entity.Reason.Replace("\r\n", "<br>");
		}
		if (entity.Day != null)
		{
		    this.lblDay.Text = entity.Day.ToString().Replace("\r\n", "<br>");
		}
		if (entity.ItemsLeaveCategory != null)
		{
		    this.lblItemsLeaveCategory.Text = entity.ItemsLeaveCategory.Replace("\r\n", "<br>");
		}
		if (entity.StartTime != null)
		{
		    this.lblStartTime.Text = ((DateTime)entity.StartTime).ToString(BaseSystemInfo.DateFormat).Replace("\r\n", "<br>"); 
		}
		if (entity.EndTime != null)
		{
		    this.lblEndTime.Text = ((DateTime)entity.EndTime).ToString(BaseSystemInfo.DateFormat).Replace("\r\n", "<br>"); 
		}
		if (entity.TransferInstructions != null)
		{
		    this.lblTransferInstructions.Text = entity.TransferInstructions.Replace("\r\n", "<br>");
		}
		if (entity.Description != null)
		{
		    this.lblDescription.Text = entity.Description.Replace("\r\n", "<br>");
		}
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (String.IsNullOrEmpty(this.ReturnURL))
        {
			// 这里显示关闭其实也不错
            // this.btnReturn.Text = "关闭";
            // this.btnReturn.OnClientClick = "window.close();";
            this.btnReturn.Visible = false;
        }
		else
		{
			this.btnReturn.Visible = true;
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
        this.GetParamter();
		if (string.IsNullOrEmpty(this.EntityId))
        {
            // 重新定向到内容没找到页面
            Page.Response.Redirect("../../../" + Utilities.NotFindPage);
        }
        else
        {
			// 显示实体
			this.ShowEntity();
		}
        // 设置控件状态
        this.SetControlState();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 检查是否登录
        Utilities.CheckIsLogOn("../../../" + Utilities.UserNotLogOn);
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}
