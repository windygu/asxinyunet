//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

using Project;

/// <remarks>
/// ShowMaintain
/// 显示申请
///
///     2012.04.06 版本：1.2  zgl 规范代码
///     2012.04.06 版本：1.1  zgl 使用ViewState保存EntityId和ReturnURL
///     2012.03.31 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012.03.14</date>
/// </author>
/// </remarks>
public partial class ShowMaintain : BasePage
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

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (String.IsNullOrEmpty(this.ReturnURL))
        {
            this.btnReturn.Visible = false;
        }
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
            this.lblTelephone.Text = entity.Telephone;
            this.lblOfficeLocation.Text = entity.OfficeLocation;
            this.lblBugCategory.Text = entity.BugCategory;
            this.lblMalfunctionCause.Text = entity.MalfunctionCause;
            this.lblComputerUserName.Text = entity.ComputerUserName;
            this.lblComputerPassword.Text = entity.ComputerPassword;
            this.lblDescription.Text = entity.Description.Replace("\r\n", "<br>");
        }
        else
        {
            // 重新定向到内容没找到页面
            Page.Response.Redirect(Utilities.NotFindPage);
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
        // 显示实体
        this.ShowEntity();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 检查是否登录
        Utilities.CheckIsLogOn();
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
            // 设置控件状态
            this.SetControlState();
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}