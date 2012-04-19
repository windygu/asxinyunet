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
/// WorkFlowAdmin
/// 审核流程管理
///
/// 修改记录
///
///		2011.09.18 版本：1.1 张广梁 修正排序。
///		2009.11.27 版本：1.0 JiRiGaLa 创建。
///
/// 版本：1.1
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.11.27</date>
/// </author>
/// </remarks>
public partial class WorkFlowAdmin : BasePage
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
            // 这里需要判断权限
            this.IsModuleAuthorized("WorkFlowAdmin");
            this.GetDataBaseParamter();
            this.GetOrganizeTree();
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

    #region private void GetOrganizeTree() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetOrganizeTree()
    {
        BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable organizeTable = organizeManager.GetOrganizeTree();
        this.cmbDepartment.DataValueField = BaseOrganizeEntity.FieldId;
        this.cmbDepartment.DataTextField = BaseOrganizeEntity.FieldFullName;
        this.cmbDepartment.DataSource = organizeTable;
        this.cmbDepartment.DataBind();
        this.cmbDepartment.Items.Insert(0, new ListItem());
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
        this.btnSearch.Enabled = true;
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
        string organizeId = this.cmbDepartment.SelectedValue;
        string searchValue = this.txtSearch.Text.Trim();
        DataTable dataTable = userManager.SearchByDepartment(organizeId, searchValue);
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTUser = dataTable;
        this.SetControlState();
        this.txtSearch.Focus();
    }
    #endregion

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
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
        }
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)(e.Row.FindControl("lkbUserWorkFlow"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbWorkFlowAuthorize"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbReplaceUser"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        int index=0;
        string id = string.Empty;
        if (e.CommandName =="UserWorkFlow")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            Page.Response.Redirect("UserWorkFlow.aspx?Id=" + id + "&ReturnURL=WorkFlowAdmin.aspx");
        }
        if (e.CommandName=="WorkFlowAuthorize")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            Page.Response.Redirect("UserWorkFlowSetAuthorize.aspx?Id=" + id + "&ReturnURL=WorkFlowAdmin.aspx");
        }
        if (e.CommandName == "ReplaceUser")
        {
            index = int.Parse(e.CommandArgument.ToString());
            id = this.gridView.DataKeys[index].Value.ToString();
            Page.Response.Redirect("WorkFlowSetReplaceUser.aspx?Id=" + id + "&ReturnURL=WorkFlowAdmin.aspx");
        }
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
}