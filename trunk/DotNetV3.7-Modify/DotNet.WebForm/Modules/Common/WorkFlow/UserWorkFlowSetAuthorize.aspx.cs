//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;

/// <summary>
/// UserWorkFlowSetAuthorize
/// 流程委托授权
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
public partial class UserWorkFlowSetAuthorize : BasePage
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
    /// 委托用户主键
    /// </summary>
    private string AuthorizeUserId
    {
        get
        {
            return this.txtAuthorizeUserId.Value;
        }
        set
        {
            this.txtAuthorizeUserId.Value = value;
        }
    }

    BaseUserManager userManager = null;

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
            this.UserId = this.UserInfo.Id;
        }
        if (Page.Request["UserId"] != null)
        {
            this.AuthorizeUserId = Page.Request["UserId"].ToString();
        }
    }
    #endregion

    private void GetUserInfo()
    {
        BaseUserManager userManager = new BaseUserManager();
        BaseUserEntity userEntity = userManager.GetEntity(this.UserId);
        this.lblCode.Text = string.IsNullOrEmpty(userEntity.Code)?"&nbsp;" : userEntity.Code;
        this.lblRealName.Text = string.IsNullOrEmpty(userEntity.RealName) ? "&nbsp;" : userEntity.RealName;
        this.lblDepartmentName.Text = string.IsNullOrEmpty(userEntity.DepartmentName) ? "&nbsp;" : userEntity.DepartmentName;
        // 受委托的人
        if (!string.IsNullOrEmpty(this.AuthorizeUserId))
        {
            userEntity = userManager.GetEntity(this.AuthorizeUserId);
            this.hdToCode.Value = string.IsNullOrEmpty(userEntity.Code) ? "" : userEntity.Code;
            this.lblToCode.Text = string.IsNullOrEmpty(userEntity.Code) ? "1" : userEntity.Code;
            this.lblToRealName.Text = string.IsNullOrEmpty(userEntity.RealName) ? "1" : userEntity.RealName;
            this.lblToDepartmentName.Text = string.IsNullOrEmpty(userEntity.DepartmentName) ? "1" : userEntity.DepartmentName;
        }
    }

    #region private void GetList() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable dt = permissionScopeManager.Search(this.UserId, BaseUserEntity.TableName, BaseUserEntity.TableName);
        this.grdWorkFlowAuthorize.DataSource = dt;
        this.grdWorkFlowAuthorize.DataBind();
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        this.GetUserInfo();
        this.GetList();
    }
    #endregion

    #region private bool HasAuthorized() 一个人同一时间里让多个人委托了,就提醒一下,但是还是允许进行委托
    /// <summary>
    /// 一个人同一时间里让多个人委托了,就提醒一下,但是还是允许进行委托
    /// </summary>
    private bool HasAuthorized()
    {
        bool returnValue = false;
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        string authorizeUserId = userManager.GetIdByCode(this.hdToCode.Value);
        if (!string.IsNullOrEmpty(authorizeUserId))
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, this.UserId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, authorizeUserId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldDeletionStateCode, 0));

            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = permissionScopeManager.HasAuthorized(parameters, this.txtStartDate.Text, this.txtEndDate.Text);
        }
        return returnValue;
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
        // 委托人必须要有工号
        if (String.IsNullOrEmpty(this.hdToCode.Value.Trim()))
        {
            MessageBox.ShowAlert("请选择委托人。");
            // MessageBox.ShowAlert("您选择的委托人没有工号，请先分配工号");
            return false; 
        }
        if (this.lblCode.Text.Equals(this.hdToCode.Value.Trim()))
        {
            MessageBox.ShowAlert("自己不用授权给自己进行委托。");
            return false;
        }
        if (this.HasAuthorized())
        {
            MessageBox.ShowAlert("该用户已经设置委托。");
            return false;
        }        
        return returnValue;
    }
    #endregion

    #region private void ClearForm()
    /// <summary>
    /// 检查输入的有效性
    /// </summary>
    /// <returns>有效</returns>
    private void ClearForm()
    {
        // 清除委托人
        this.lblToCode.Text = "请选择委托人";
        this.lblToRealName.Text = "&nbsp;";
        this.hdToCode.Value = string.Empty;
        this.lblToDepartmentName.Text="&nbsp;";
        this.txtStartDate.Text = String.Empty;
        this.txtEndDate.Text = String.Empty;
    }
    #endregion

    #region private int AddAuthorize() 添加委托
    /// <summary>
    /// 添加委托
    /// </summary>
    /// <returns></returns>
    private int AddAuthorize()
    {
        int returnValue = 0;
        DateTime? startDateTime = null;
        DateTime? endDateTime = null;
        if (!string.IsNullOrEmpty(this.txtStartDate.Text))
        {
            startDateTime = DateTime.Parse(this.txtStartDate.Text);
        }
        if (!string.IsNullOrEmpty(this.txtEndDate.Text))
        {
            endDateTime = DateTime.Parse(this.txtEndDate.Text);
        }
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        string authorizeUserId = userManager.GetIdByCode(this.hdToCode.Value);
        if (!string.IsNullOrEmpty(authorizeUserId))
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(this.UserCenterDbHelper, this.UserInfo);
            string permissionItemId = permissionItemManager.GetIdByAdd("WorkFlow.Authorize");
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = permissionScopeManager.GrantResourcePermissionScopeTarget(BaseUserEntity.TableName, this.UserId, BaseUserEntity.TableName, new string[] { authorizeUserId }, permissionItemId, startDateTime, endDateTime);
        }
        return returnValue;
    }
    #endregion

    protected void grdWorkFlowAuthorize_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");

            string userId = ((DataRowView)e.Row.DataItem)["ResourceId"].ToString();
            if (userManager == null)
            {
                userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            }
            BaseUserEntity userEntity = userManager.GetEntity(userId);
            e.Row.Cells[1].Text = userEntity.RealName;
            e.Row.Cells[2].Text = userEntity.Code;
            userId = ((DataRowView)e.Row.DataItem)["TargetId"].ToString();
            userEntity = userManager.GetEntity(userId);
            e.Row.Cells[5].Text = userEntity.DepartmentName;
            e.Row.Cells[6].Text = userEntity.RealName;
            e.Row.Cells[7].Text = userEntity.Code;
            if (this.permissionDelete)
            {
                TableCell tableCell = e.Row.Cells[this.grdWorkFlowAuthorize.Columns.Count - 1];
                LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
                if (btnLinkDelete != null)
                {
                    string strScript = "return confirm('您确认要删除吗？');";
                    btnLinkDelete.Attributes.Add("onclick", strScript);
                }
            }
        }
    }

    #region private void DeleteMark(string id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">主键</param>
    private void DeleteMark(string id)
    {
        int returnValue = 0;
        try
        {
            this.DbHelper.Open();
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(this.UserInfo);
            returnValue = permissionScopeManager.SetDeleted(id);
            this.GetList();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdWorkFlowAuthorize_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.grdWorkFlowAuthorize.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!this.CheckInput())
        {
            return;
        }
        else
        {
            int result = this.AddAuthorize();
            if (result > 0)
            {
                MessageBox.ShowAlert("设置委托成功。");
                this.ClearForm();
            }
            this.GetList();
        }
    }
}