//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// UserAdmin
/// 用户管理
///
/// 修改记录
///
///		2009.11.27 版本：1.0 JiRiGaLa 创建。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.11.27</date>
/// </author>
/// </remarks>
public partial class UserAdmin : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetDataBaseParamter();
            this.GetItemDetails();
            this.GetParamter();
            // 获取用户列表
            this.DoSearch();
            this.txtSearch.Focus();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["Search"] != null)
        {
            this.txtSearch.Text = Page.Request["Search"].ToString();
        }
        if (Page.Request["Role"] != null)
        {
            this.cmbRole.SelectedValue = Page.Request["Role"].ToString();
            this.cmbRole.Enabled = false;
        }
    }
    #endregion

    #region private void GetDataBaseParamter() 从数据库读取参数
    /// <summary>
    /// 从数据库读取参数
    /// </summary>
    private void GetDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        string enabled = parameterManager.GetParameter("User", this.UserInfo.Id, "UserAdmin.Enabled");
        if (enabled.Length > 0 && enabled.Equals("0"))
        {
            this.ckbEnabled.Checked = false;
        }
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "UserAdmin.PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }
    }
    #endregion

    #region private void SaveDataBaseParamter() 保存参数
    /// <summary>
    /// 保存参数
    /// </summary>
    private void SaveDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserAdmin.Enabled", this.ckbEnabled.Checked ? "1" : "0");
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserAdmin.PageSize", this.myNavigator.PageSize.ToString());
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        // 绑定角色
        DotNetService dotNetService = new DotNetService();
        DataTable dataTable = dotNetService.RoleService.GetDataTable(this.UserInfo);
        this.cmbRole.DataSource = dataTable;
        this.cmbRole.DataTextField = BaseRoleEntity.FieldRealName;
        this.cmbRole.DataValueField = BaseRoleEntity.FieldId;
        this.cmbRole.DataBind();
        this.cmbRole.Items.Insert(0, new ListItem());
    }
    #endregion

    private void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    #region private void GetList(PageChangeEventArgs e)
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        this.myNavigator.BindData(this.gridView, this.DTUser, e);
        if (e.Action == "PageSizeChanged")
        {
            try
            {
                this.UserCenterDbHelper.Open();
                // 保存分页参数
                this.SaveDataBaseParamter();
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw ex;
            }
            finally
            {
                this.UserCenterDbHelper.Close();
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
        if (this.gridView.Rows.Count == 0)
        {
            this.btnCheckAll.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPass.Enabled = false;
            this.btnLock.Enabled = false;
            this.btnSetPassword.Enabled = false;
        }
        else
        {
            this.btnCheckAll.Enabled = true;
            this.btnSetPassword.Enabled = true;
            this.btnPass.Enabled = true;
            this.btnLock.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnSearch.Enabled = true;
        }
        //this.grdLieBiao.Columns[this.grdLieBiao.Columns.Count - 1].Visible = this.PermissionDelete;
    }
    #endregion

    #region private void Search() 查询
    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        this.gridView.PageIndex = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            this.SaveDataBaseParamter();
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if ((Utilities.ShowInformation) && (this.gridView.Rows.Count == 0))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "searchFailure", "<script>alert('提示信息： 未找到查询内容。');</script>");
        }
    }
    #endregion

    #region private void DoSearch() 查询
    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        string search = this.txtSearch.Text;
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        string auditStates = string.Empty;
        string[] roleIDs = null;
        if (!string.IsNullOrEmpty(this.cmbRole.SelectedValue))
        {
            roleIDs = new string[] { this.cmbRole.SelectedValue };
        }
        DataTable dataTable = userManager.Search(search, roleIDs, null, auditStates);
        // 把已删除的过滤掉
        BaseBusinessLogic.SetFilter(dataTable, BaseUserEntity.FieldDeletionStateCode, "0");
        // 过滤有效无效
        if (this.ckbEnabled.Checked)
        {
            BaseBusinessLogic.SetFilter(dataTable, BaseUserEntity.FieldEnabled, "1");
        }
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTUser = dataTable;
        this.SetControlState();
        this.txtSearch.Focus();
    }
    #endregion

    protected void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // 进行查询
        this.Search();
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            //if (this.PermissionDelete)
            //{
            TableCell tableCell = e.Row.Cells[this.gridView.Columns.Count - 1];
            LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确认要删除吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            //}
        }
    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["ID"].ToString();
        Page.Response.Redirect("UserEdit.aspx?ID=" + id + "&ReturnURL=UserAdmin.aspx");
    }

    #region private void DeleteMark(string id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">代码</param>
    private void DeleteMark(string id)
    {
        int returnValue = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = userManager.SetDeleted(id);
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.gridView.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
    }

    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Registration.aspx?Role=" + this.cmbRole.SelectedValue);
    }

    protected void btnSetPassword_Click(object sender, EventArgs e)
    {
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        string idList = StringUtil.ArrayToList(ids);
        Page.Response.Redirect("SetPassword.aspx?ID=" + idList + "&ReturnURL=UserAdmin.aspx");
    }

    #region private int BathDelete() 批量删除
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BathDelete()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = userManager.SetDeleted(ids);
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
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
        return returnValue;
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // 批量删除
        this.BathDelete();
    }

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (this.SortDire == "ASC")
        {
            this.SortDire = "DESC";
        }
        else
        {
            this.SortDire = "ASC";
        }
        this.SortExpression = e.SortExpression;
        this.DTUser.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
        this.myNavigator.BindData(this.gridView, this.DTUser);
        this.SetControlState();
    }

    private DataTable DTUser
    {
        get
        {
            return Utilities.GetFromSession("_DTUser") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTUser", value);
        }
    }

    #region private int Pass() 批量解锁
    /// <summary>
    /// 批量解锁
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BathPass()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = userManager.SetProperty(BaseBusinessLogic.FieldId, ids, new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathPassSucceed", "<script>alert('提示信息：解锁成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathPassFailure", "<script>alert('提示信息：解锁失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnPass_Click(object sender, EventArgs e)
    {
        // 批量设置已处理
        this.BathPass();
    }

    #region private int BathLock() 批量锁定
    /// <summary>
    /// 批量锁定
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BathLock()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = userManager.SetProperty(BaseBusinessLogic.FieldId, ids, new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 0));
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathLockSucceed", "<script>alert('提示信息：锁定成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathLockFailure", "<script>alert('提示信息：锁定失败。');</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void btnLock_Click(object sender, EventArgs e)
    {
        // 批量设置未处理
        this.BathLock();
    }
}