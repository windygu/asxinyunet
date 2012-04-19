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
using Project;

/// <remarks>
/// EditMaintain
/// 编辑申请
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
public partial class EditMaintain : BasePage
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

    #region private void GetItemDetails() 绑定下拉框数据
    /// <summary>
    /// 绑定下拉框数据
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

        manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsBugLevel");
        dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode);
        this.cmbBugLevel.DataSource = dataTable;
        this.cmbBugLevel.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbBugLevel.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbBugLevel.DataBind();
        this.cmbBugLevel.Items.Insert(0, new ListItem());
    }
    #endregion

    #region private void ShowEntity()
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntity()
    {
        if (!string.IsNullOrEmpty(this.EntityId))
        {
            MaintainEntity entity = new MaintainManager(this.UserInfo).GetEntity(this.EntityId);
            this.lblRealName.Text = entity.CreateBy;
            this.lblUserCode.Text = entity.Code;
            this.lblDepartmentName.Text = entity.DepartmentName;
            if (entity.ReportingTime != null)
            {
                this.lblReportingTime.Text = string.Empty;
            }
            else
            {
                this.lblReportingTime.Text = ((DateTime)entity.ReportingTime).ToString(BaseSystemInfo.DateTimeFormat);
            }
            this.txtTelephone.Text = entity.Telephone;
            this.txtTelephone.Text = entity.Telephone;
            this.txtOfficeLocation.Text = entity.OfficeLocation;
            this.cmbBugCategory.SelectedValue = entity.BugCategory;
            this.txtMalfunctionCause.Text = entity.MalfunctionCause;
            this.lblServiceState.Text = entity.ServiceState;
            this.txtIP.Text = entity.IP;
            this.txtComputerUserName.Text = entity.ComputerUserName;
            this.txtComputerPassword.Text = entity.ComputerPassword;
            this.txtDescription.Text = entity.Description;
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
        // 检查是否登录
        Utilities.CheckIsLogOn();
        // 下拉框数据
        this.GetItemDetails();
        // 读取参数
        this.GetParamter();
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
    /// <returns></returns>
    private MaintainEntity GetEntity()
    {
        // 这里需要防止更新错数据，或者丢失数据，所以需要从数据库里读取一下整个类，比较安全
        MaintainEntity entity = new MaintainManager(this.UserInfo).GetEntity(this.EntityId);
        entity.CreateBy = this.UserInfo.RealName;
        entity.UserCode = this.UserInfo.Code;
        entity.DepartmentName = this.UserInfo.DepartmentName;
        entity.DepartmentId = this.UserInfo.DepartmentId;
        entity.OfficeLocation = this.txtOfficeLocation.Text;
        entity.ReportingTime = DateTime.Now;
        entity.BugCategory = this.cmbBugCategory.SelectedValue;
        entity.MalfunctionCause = this.txtMalfunctionCause.Text;
        entity.IP = this.txtIP.Text;
        entity.ComputerUserName = this.txtComputerUserName.Text;
        entity.ComputerPassword = this.txtComputerPassword.Text;
        entity.Description = this.txtDescription.Text;
        return entity;
    }
    #endregion

    private int Update()
    {
        MaintainEntity entity = this.GetEntity();
        return new MaintainManager(this.UserInfo).Update(entity); 
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        this.Update();
        if (string.IsNullOrEmpty(this.ReturnURL))
        {
            Utilities.CloseWindow(true);
        }
        else
        {
            Page.Response.Redirect(this.ReturnURL);
        }
    }
}