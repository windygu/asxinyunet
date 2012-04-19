//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Utilities;
using DotNet.Business;

/// <summary>
/// WorkFlowSetReplaceUser
/// 流程委托授权
///   1: 。
///
/// 修改纪录
///
///		2011-09-05 版本：1.0 JiRiGaLa 创建主键。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011-09-05</date>
/// </author>
/// </summary>
public partial class WorkFlowSetReplaceUser : BasePage
{
   
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

    /// <summary>
    /// 返回URL
    /// </summary>
    private string ReturnUrl
    {
        get { return this.txtReturnUrl.Value; }
        set { this.txtReturnUrl.Value = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
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
            this.UserId = Page.Request["Id"].ToString();
        }
        else
        {
            this.UserId =string.Empty;
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnUrl = Page.Request["ReturnURL"].ToString();
        }
        else
        {
            this.ReturnUrl = string.Empty;
        }
    }
    #endregion

    private void GetUserInfo()
    {
        BaseUserManager userManager = new BaseUserManager();
        BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
        this.lblCode.Text = string.IsNullOrEmpty(userEntity.Code) ? "&nbsp;" : userEntity.Code;
        this.lblRealName.Text = string.IsNullOrEmpty(userEntity.RealName) ? "&nbsp;" : userEntity.RealName;
        this.lblDepartmentName.Text = string.IsNullOrEmpty(userEntity.DepartmentName) ? "&nbsp;" : userEntity.DepartmentName;
        this.hdUserId.Value = this.UserId;

        // 受委托的人 comment by zgl 感觉没有用所以暂时注释掉
        //if (!string.IsNullOrEmpty(this.AuthorizeUserId))
        //{
        //    userEntity = userManager.GetEntity(this.AuthorizeUserId);
        //    this.txtUserCode.Text = userEntity.Code;
        //}
    }

    private void SetControlState()
    {
       
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        if (!string.IsNullOrEmpty(this.UserId))
        {
            this.GetUserInfo();
        }
        this.SetControlState();
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
        // 用户id不能为空
        if (String.IsNullOrEmpty(this.hdUserId.Value.Trim()))
        {
            MessageBox.ShowAlert("请选择用户。");
            return false;
        }
        // 替换用户id不能为空
        if (String.IsNullOrEmpty(this.hdToUserId.Value.Trim()))
        {
            MessageBox.ShowAlert("请选择替换用户。");
            return false;
        }
        // 替换用户的用户不能一样
        if (this.hdUserId.Value.Equals(this.hdToUserId.Value))
        {
            MessageBox.ShowAlert("请重新选择替换用户。");
            return false;
        }
        // 如果用户无需替换给出提示
        BaseWorkFlowActivityManager manager=new BaseWorkFlowActivityManager(this.WorkFlowDbHelper,this.UserInfo);
        if (!manager.Exists(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldAuditUserId, this.hdUserId.Value)))
        {
            MessageBox.ShowAlert("该用户未在流程中定义，请选择其他用户。");
            this.ClearForm();
            this.SetControlState();
            return false;
        }
        return returnValue;
    }
    #endregion

    #region private void ClearForm() 检查输入的有效性
    /// <summary>
    /// 检查输入的有效性
    /// </summary>
    /// <returns>有效</returns>
    private void ClearForm()
    {
        // 清除屏幕数据
        this.lblCode.Text = "请选择用户";
        this.lblRealName.Text = "&nbsp;";
        this.hdUserId.Value = string.Empty;
        this.lblDepartmentName.Text = "&nbsp;";
        this.lblToCode.Text = "请选择替换用户";
        this.lblToRealName.Text = "&nbsp;";
        this.hdToUserId.Value = String.Empty;
        this.lblToDepartmentName.Text = "&nbsp;";
    }
    #endregion

    #region private int ChangeUser() 替换用户
    /// <summary>
    /// 替换用户
    /// </summary>
    /// <returns></returns>
    private int ReplaceUser()
    {
        int returnValue = 0;
        string oldUserId = this.hdUserId.Value;
        string newUserId = this.hdToUserId.Value;
        
        // 替换流程定义中的人员
        BaseWorkFlowActivityManager activityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
        returnValue = activityManager.ReplaceUser(oldUserId, newUserId);
        // 替换当前步骤中的人员
        BaseWorkFlowCurrentManager currentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        currentManager.ReplaceUser(oldUserId, newUserId);
        // 替换当前步骤中的人员
        BaseWorkFlowStepManager stepManager = new BaseWorkFlowStepManager(this.WorkFlowDbHelper, this.UserInfo);
        stepManager.ReplaceUser(oldUserId, newUserId);

        if (returnValue > 0)
        {
            if (!string.IsNullOrEmpty(this.ReturnUrl))
            {
                MessageBox.ShowAlert("人员替换成功。", this.ReturnUrl, true);
            }
            else
            {
                MessageBox.ShowAlert("人员替换成功。", this.ReturnUrl, false);
            }
        }  
        return returnValue;
    }
    #endregion

    protected void btnReplaceUser_Click(object sender, EventArgs e)
    {
        if (!this.CheckInput())
        {
            return;
        }
        else
        {
            int result = this.ReplaceUser();
            if (result > 0)
            {
                this.ClearForm();
                this.SetControlState();
            }
        }
    }
}