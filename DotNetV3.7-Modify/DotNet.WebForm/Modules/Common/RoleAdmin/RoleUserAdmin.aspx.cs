//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class RoleUserAdmin : BasePage
{
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
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
        if (Page.Request["Id"] != null)
        {
            this.txtId.Value = Page.Request["Id"].ToString();
        }
        if (Page.Request["Code"] != null)
        {
            string code = Page.Request["Code"].ToString();
            BaseRoleManager manager = new BaseRoleManager(this.UserInfo);
            this.txtId.Value = manager.GetIdByCode(code);
        }
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.gridView.Rows.Count > 1;
        this.btnRemove.Enabled = this.gridView.Rows.Count > 0;
        this.btnReturn.Visible = !string.IsNullOrEmpty(this.ReturnURL);
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
            BaseRoleEntity entity = new BaseRoleManager(this.UserInfo).GetEntity(this.EntityId);
            this.lblCode.Text = entity.Code;
            this.lblRealname.Text = entity.RealName;
            this.lblDescription.Text = entity.Description;
        }
        else
        {
            // 重新定向到内容没找到页面
            Page.Response.Redirect(Utilities.NotFindPage);
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 加载窗体
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParamter();
        this.ShowEntity();
        this.GetList();
        this.SetControlState();
    }
    #endregion

    #region private void GetList() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable dataTable = userManager.GetDataTableByRole(this.EntityId);
        this.gridView.DataSource = dataTable;
        this.gridView.DataBind();
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
    }

    #region private int BatchRemove() 批量移除
    /// <summary>
    /// 批量移除
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchRemove()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserRoleManager manager = new BaseUserRoleManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = manager.RemoveFormRole(ids, this.EntityId);
            this.gridView.EditIndex = -1;
            this.GetList();
            this.SetControlState();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：移除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：移除失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        this.BatchRemove();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }

    protected void txtUserIds_TextChanged(object sender, EventArgs e)
    {
        // 加载用户到角色中
        string id = this.txtUserIds.Text;
        if (!string.IsNullOrEmpty(id))
        {
            string[] ids = id.Split(',');
            BaseUserRoleManager manager = new BaseUserRoleManager(this.UserCenterDbHelper, this.UserInfo);
            manager.AddToRole(ids, this.EntityId);
            this.GetList();
            this.SetControlState();
        }
    }
}
