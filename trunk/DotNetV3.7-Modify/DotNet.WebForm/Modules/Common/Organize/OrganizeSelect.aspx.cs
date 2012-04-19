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
/// OrganizeSelect
/// 选择用户
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
public partial class OrganizeSelect : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            DoPageLoad();
        }
        myNavigator.PageChange += myNavigator_PageChange;
    }

    #region private void GetList(PageChangeEventArgs e)

    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        myNavigator.BindData(gridView, DTOrganize, e);
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

    #region public string GetOrganizeName(string id) 站点名称
    public string GetOrganizeName(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return null;
        }
        var baseOrganizeManager = new BaseOrganizeManager(this.UserInfo);
        return baseOrganizeManager.GetProperty(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldId, id),
                                               BaseOrganizeEntity.FieldFullName);
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

    #region private void Search() 查询

    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        gridView.PageIndex = 0;
        try
        {
            UserCenterDbHelper.Open();
            SaveDataBaseParamter();
            this.DoSearch();
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
        var organizeManager = new BaseOrganizeManager(UserCenterDbHelper, UserInfo);
        string organizeId = cmbOrganize.SelectedValue;
        string searchValue = txtSearch.Text.Trim();
        DataTable dataTable = organizeManager.Search(searchValue, organizeId);
        myNavigator.BindData(gridView, dataTable);
        DTOrganize = dataTable;
        SetControlState();
        txtSearch.Focus();
    }

    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作

    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        try
        {
            UserCenterDbHelper.Open();
            GetDataBaseParamter();
            GetOrganizeTree();
            GetParamter();
            // 获取用户列表
            DoSearch();
            txtSearch.Focus();
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

    #region private void GetOrganizeTree() 绑定下拉筐数据

    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetOrganizeTree()
    {
        var organizeManager = new BaseOrganizeManager(UserCenterDbHelper, UserInfo);
        DataTable organizeTable = organizeManager.GetOrganizeTree();
        cmbOrganize.DataValueField = BaseOrganizeEntity.FieldId;
        cmbOrganize.DataTextField = BaseOrganizeEntity.FieldFullName;
        cmbOrganize.DataSource = organizeTable;
        cmbOrganize.DataBind();
        cmbOrganize.Items.Insert(0, new ListItem());
    }

    #endregion

    private void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    protected void cmbOrganize_SelectedIndexChanged(object sender, EventArgs e)
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
        DTOrganize.DefaultView.Sort = SortExpression + " " + SortDire;
        gridView.EditIndex = -1;
        myNavigator.BindData(gridView, DTOrganize);
        SetControlState();
    }

    private DataTable DTOrganize
    {
        get { return Utilities.GetFromSession("_DTUser") as DataTable; }
        set { Utilities.AddSession("_DTUser", value); }
    }
}