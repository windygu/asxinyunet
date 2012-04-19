//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// Leave
/// 编辑
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
public partial class LeaveEdit : BasePage
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

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
		// 绑定下拉框数据
        this.GetItemDetails();
		// 获取参数
        this.GetParamter();
		// 显示实体
        this.ShowEntity();
		// 设置空间状态
		this.SetControlState();
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉框数据
    /// <summary>
    /// 绑定下拉框数据
    /// </summary>
    private void GetItemDetails()
    {
		BaseItemDetailsManager managerItemsLeaveCategory = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsLeaveCategory");        DataTable dataTableItemsLeaveCategory = managerItemsLeaveCategory.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldEnabled, 1), BaseItemDetailsEntity.FieldSortCode);
        this.cmbItemsLeaveCategory.DataSource = dataTableItemsLeaveCategory; 
        this.cmbItemsLeaveCategory.DataTextField = BaseItemDetailsEntity.FieldItemName; 
        this.cmbItemsLeaveCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue; 
        this.cmbItemsLeaveCategory.DataBind(); 
        this.cmbItemsLeaveCategory.Items.Insert(0, new ListItem());

    }
    #endregion

	#region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        // 是否采用了提交功能
        if (!string.IsNullOrEmpty(this.EntityId))
        {
            this.btnAdd.Visible = false;
            this.btnUpdate.Visible = true;
        }
        else
        {
            this.btnAdd.Visible = true;
            this.btnUpdate.Visible = false;
        }
		this.btnSend.Visible = this.UseWorkFlow;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
		// 判断是否登录
        Utilities.CheckIsLogOn("../../../" + Utilities.UserNotLogOn);
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void ShowEntity()
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntity()
    {
		if (!string.IsNullOrEmpty(this.EntityId))
        {
            LeaveEntity entity = new LeaveManager(this.UserInfo).GetEntity(this.EntityId);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                this.hdUserId.Value = entity.UserId;
                this.lblUserName.Text = entity.UserName;
                this.hdOrganizeId.Value = entity.DepartmentId;
                this.lblOrganizeName.Text = entity.DepartmentName;
				
                Utilities.SetDropDownListValue(this.cmbItemsLeaveCategory, entity.ItemsLeaveCategory);
                if (entity.StartTime != null)
                {
                    this.txtStartTime.Text = ((DateTime)entity.StartTime).ToString(BaseSystemInfo.DateFormat).Replace("\r\n", "<br>"); 
                }

                if (entity.EndTime != null)
                {
                    this.txtEndTime.Text = ((DateTime)entity.EndTime).ToString(BaseSystemInfo.DateFormat).Replace("\r\n", "<br>"); 
                }

	    	    this.txtTransferInstructions.Text = entity.TransferInstructions;
	    	    this.txtDescription.Text = entity.Description;
				
				// 已经提交的不可以更新
                bool allowEdit = true;
                if (entity.Enabled == 1)
                {
                    // 已经生效的， 不可以编辑
                    allowEdit = false;
                }
                else
                {
                    if (this.UseWorkFlow)
                    {
                        // 已经进入审批流程的，不可以修改
                        if (entity.AuditStatus.Equals(AuditStatus.StartAudit.ToString())
                            || entity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
                            || entity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString()))
                        {
                            allowEdit = false;
                        }
                    }
                }
                // 是系统管理员可以编辑
                if (this.UserInfo.IsAdministrator)
                {
                    allowEdit = true;
                }
                // 限制提交按钮，更新按钮
                if (this.UseWorkFlow)
                {
                    // 采用审批流程的，才可以提交
                    this.btnSend.Visible = !allowEdit;
                }
                this.btnUpdate.Visible = !allowEdit;
            }
            else
            {
                // 重新定向到内容没找到页面
                Page.Response.Redirect("../../../" + Utilities.NotFindPage);
            }
        }
        else
        {
            // 默认新增状态的优化
            this.hdUserId.Value = this.UserInfo.Id;
            this.lblUserName.Text = this.UserInfo.RealName;
            this.hdOrganizeId.Value = this.UserInfo.DepartmentId;
            this.lblOrganizeName.Text = this.UserInfo.DepartmentName;
            // 重新定向到内容没找到页面
            // Page.Response.Redirect("../../../" + Utilities.NotFindPage);
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
		Regex integerRegex = new Regex(RegexCollection.PositiveInteger);
		Regex floatRegex = new Regex(RegexCollection.Float);
        
        if(string.IsNullOrEmpty(this.txtDay.Text.Trim()))
        {
            MessageBox.ShowAlert("请假天数,不能为空。");
            this.txtDay.Focus();
            return false;
        }

        if (!integerRegex.IsMatch(this.txtDay.Text))
        {
            MessageBox.ShowAlert("请假天数,格式不正确。");
            this.txtDay.Focus();
            return false;
        }

        return returnValue;
    }
    #endregion

    private LeaveEntity GetEntity()
    {
        // 这里需要防止更新错数据，或者丢失数据，所以需要从数据库里读取一下整个类，比较安全
		LeaveEntity entity = new LeaveManager(this.UserInfo).GetEntity(this.EntityId);
		        entity.TransferOfPeople = this.txtTransferOfPeople.Text;
        entity.Telephone = this.txtTelephone.Text;
        entity.Reason = this.txtReason.Text;

        if (!string.IsNullOrEmpty(this.txtDay.Text)) 
        { 
            entity.Day = int.Parse(this.txtDay.Text); 
        }

		entity.ItemsLeaveCategory = this.cmbItemsLeaveCategory.SelectedValue;
        if (string.IsNullOrEmpty(this.txtStartTime.Text)) 
        {
            entity.StartTime = null; 
        } 
        else 
        { 
            entity.StartTime = DateTime.Parse(this.txtStartTime.Text); 
        }

        if (string.IsNullOrEmpty(this.txtEndTime.Text)) 
        {
            entity.EndTime = null; 
        } 
        else 
        { 
            entity.EndTime = DateTime.Parse(this.txtEndTime.Text); 
        }
        entity.TransferInstructions = this.txtTransferInstructions.Text;
        entity.Description = this.txtDescription.Text;

		entity.UserId = this.hdUserId.Value;
        entity.UserName = new BaseUserManager().GetEntity(entity.UserId).RealName;
        entity.DepartmentId = this.hdOrganizeId.Value;
        entity.DepartmentName = new BaseOrganizeManager().GetEntity(entity.DepartmentId).FullName;
        return entity;
    }

    /// <summary>
    /// 添加实体
    /// </summary>
    /// <returns>主键</returns>
    private string Add()
    {
        LeaveEntity entity = this.GetEntity();
		if (this.UseWorkFlow)
        {
            entity.Enabled = 0;
        }
        else
        {
            entity.Enabled = 1;
        }
        entity.DeletionStateCode = 0;
		this.EntityId = new LeaveManager(this.UserInfo).Add(entity);
        
        return this.EntityId;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
		// 检查页面的输入
        if (!this.CheckInput())
        {
            return;
        }
		// 添加
        this.SaveEntity();
        if (string.IsNullOrEmpty(this.ReturnURL))
        {
            Utilities.CloseWindow(true);
        }
        else
        {
            Page.Response.Redirect(this.ReturnURL);
        }
    }

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <returns>影响行数</returns>
    private int Update()
    {
		
        LeaveEntity entity = this.GetEntity();
        return new LeaveManager(this.UserInfo).Update(entity);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
		// 检查页面的输入
        if (!this.CheckInput())
        {
            return;
        }
        this.SaveEntity();
        if (string.IsNullOrEmpty(this.ReturnURL))
        {
            Utilities.CloseWindow(true);
        }
        else
        {
            Page.Response.Redirect(this.ReturnURL);
        }
    }

	private string SaveEntity()
    {
        if (string.IsNullOrEmpty(this.EntityId))
        {
            this.EntityId = this.Add();
        }
        else
        {
            this.Update();
        }
        return this.EntityId;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
		// 检查页面的输入
        if (!this.CheckInput())
        {
            return;
        }
		this.SaveEntity();
        string url = "../../Common/WorkFlow/SubmitBill.aspx?ObjectId=" + this.EntityId + "&ObjectFullName=请假单&CategoryCode=Leave&CategoryFullName=请假单";
        Page.Response.Redirect(url);
    }
}
