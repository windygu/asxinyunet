//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// RoleSelect
/// 选择角色
///
/// 修改记录
///
///		2012.03.22 版本：1.0 张广梁   创建。
///
/// 版本：1.0
///
/// <author>
///		<name>张广梁</name>
///		<date>2012.03.22</date>
/// </author>
/// </remarks>
public partial class RoleSelect : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            DoPageLoad();
        }
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    #region private void BindItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void BindItemDetails()
    {
        // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
        if (this.ddlRoleCategory.Items.Count == 0)
        {
            BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsRoleCategory");
            DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.ddlRoleCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
            this.ddlRoleCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
            this.ddlRoleCategory.DataSource = dataTable.DefaultView;
            this.ddlRoleCategory.DataBind();
        }
    }
    #endregion

    #region private void SetControlState() 设置控件状态

    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (gridView.Rows.Count == 0)
        {
            btnCheckAll.Attributes["disabled"] = "disabled";
            btnConfirm.Attributes["disabled"] = "disabled";
        }
        else
        {
            btnSearch.Enabled = true;
            btnCheckAll.Attributes.Remove("disabled");
            btnConfirm.Attributes.Remove("disabled");
        }
    }

    #endregion

    #region private void GetList(PageChangeEventArgs e)

    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        myNavigator.BindData(gridView, this.DTRole, e);
        if (e.Action == "PageSizeChanged")
        {
            try
            {
                UserCenterDbHelper.Open();
                // 保存分页参数
                SaveDataBaseParamter();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
            finally
            {
                UserCenterDbHelper.Close();
            }
        }
    }

    #endregion

    #region private void GetParamter() 读取参数

    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        // 备用
        if (Page.Request["Search"] != null)
        {
            txtSearch.Text = Page.Request["Search"];
        }
    }

    #endregion

    #region private void GetDataBaseParamter() 从数据库读取参数

    /// <summary>
    /// 从数据库读取参数
    /// </summary>
    private void GetDataBaseParamter()
    {
        var parameterManager = new BaseParameterManager(UserCenterDbHelper, UserInfo);
        string pageSize = parameterManager.GetParameter("User", UserInfo.Id, "UserAdmin.PageSize");
        if (pageSize.Length > 0)
        {
            myNavigator.PageSize = int.Parse(pageSize);
        }
    }

    #endregion

    #region private void SaveDataBaseParamter() 保存参数

    /// <summary>
    /// 保存参数
    /// </summary>
    private void SaveDataBaseParamter()
    {
        var parameterManager = new BaseParameterManager(UserCenterDbHelper, UserInfo);
        parameterManager.SetParameter("User", UserInfo.Id, "UserAdmin.PageSize", myNavigator.PageSize.ToString());
    }

    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作

    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            //打开用户中心数据库
            this.UserCenterDbHelper.Open();
            // 检查是否登录
            //Utilities.CheckIsLogOn();
            //检查权限
            //this.CheckPermission();
            // 获取相应参数
            // GetParamter();
            this.GetDataBaseParamter();
            // 绑定下拉列表数据
            this.BindItemDetails();
            //打开业务逻辑数据库
            this.DbHelper.Open();
            //处理业务逻辑
            this.Search();
        }
        catch (Exception ex)
        {
            //this.LogException(ex);
            throw ex;
        }
        finally
        {
            // 记录日志
            //BaseLogManager.Instance.AddWebLog(Request.UrlReferrer.AbsoluteUri,this.UserInfo.Id, Request.Url.ToString());
            // 关闭用户中心数据库
            this.UserCenterDbHelper.Close();
            // 关闭业务数据库
            this.DbHelper.Close();
        }
    }
    #endregion

    #region public string GetRoleCategory(string itemValue) 审核标志
    public string GetRoleCategory(string itemValue)
    {
        if (string.IsNullOrEmpty(itemValue))
            return null;
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsRoleCategory");
        return manager.GetProperty(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemValue, itemValue),  BaseItemDetailsEntity.FieldItemName);
    }
    #endregion

    #region private void Search() 查询

    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        gridView.PageIndex = 0;
        try
        {
            DoSearch();
            // 设置控件状态
            SetControlState();
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
        // 是否显示提示信息
        if ((Utilities.ShowInformation) && (gridView.Rows.Count == 0))
        {
            ClientScript.RegisterStartupScript(GetType(), "searchFailure", "<script>alert('提示信息： 未找到查询内容。');</script>");
        }
    }

    #endregion

    #region private void DoSearch() 查询

    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        string search = txtSearch.Text;
        var roleManager = new BaseRoleManager(UserCenterDbHelper, UserInfo);
        string categoryCode = string.Empty;
        if (ddlRoleCategory.SelectedItem != null)
        {
            categoryCode = ddlRoleCategory.SelectedItem.Value;
        }
        string searchValue = txtSearch.Text.Trim();
        DataTable dataTable = roleManager.Search(null, searchValue, categoryCode);
        myNavigator.BindData(gridView, dataTable);
        this.DTRole = dataTable;
        txtSearch.Focus();
    }

    #endregion

    protected void ddlRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // 查询
        this.Search();
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover",
                                 "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
        }
    }

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (SortDire == "ASC")
        {
            SortDire = "DESC";
        }
        else
        {
            SortDire = "ASC";
        }
        SortExpression = e.SortExpression;
        this.DTRole.DefaultView.Sort = SortExpression + " " + SortDire;
        gridView.EditIndex = -1;
        myNavigator.BindData(gridView, this.DTRole);
        SetControlState();
    }

    private void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    private DataTable DTRole
    {
        get { return ViewState["_DTRole"] as DataTable; }
        set { ViewState["_DTRole"] = value; }
    }
}