using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// NewsAdmin
/// 新闻管理查询
///
/// 查询记录
/// 
///		2009.11.09 版本：2.0 JiRiGaLa   没有权限的人来管理，不能把所有的数据都能管理了。
///		2009.03.11 版本：1.0 YuanHuaLin 创建程序。
///
/// 版本：1.0
///
/// <author>
///		<name>YuanHuaLin</name>
///		<date>2009.03.11 </date>
/// </author>
/// </remarks>
public partial class NewsAdmin : BasePage
{
    protected string ShoppingURL = ConfigurationManager.AppSettings["ShoppingURL"];

    string FolderId = string.Empty;

    #region private void SetButtomState() 设置按钮状态
    /// <summary>
    /// 设置按钮状态
    /// </summary>
    private void SetButtomState()
    {
        if (this.gridView.Rows.Count == 0)
        {
            this.btnDelete.Enabled = false;
            this.btnAllow.Enabled = false;
            this.btnStop.Enabled = false;
            this.myNavigator.Visible = false;
        }
        else
        {
            this.btnAdd.Enabled = this.permissionAdd;
            this.btnAllow.Enabled = this.permissionEdit;
            this.btnStop.Enabled = this.permissionEdit;
            this.btnDelete.Enabled = this.permissionDelete;
        }
        this.gridView.Columns[this.gridView.Columns.Count - 1].Visible = this.permissionDelete;
        // 设置分页控件的显示状态
        this.myNavigator.Visible = this.gridView.Rows.Count > 0;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
        this.myNavigator.PageChange += new PageChangeHandler(this.myNavigator_PageChange);
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["FolderId"] != null)
        {
            this.FolderId = Page.Request["FolderId"].ToString();
        }
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
            Utilities.CheckIsLogOn();
            this.GetParamters();
            this.UserCenterDbHelper.Open();
            // 判断新闻发布权限
            this.Authorized("News.Add");
            this.GetItemDetails();
            this.GetDataBaseParamter();
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
    }
    #endregion

    #region private void GetDataBaseParamter() 从数据库读取参数
    /// <summary>
    /// 从数据库读取参数
    /// </summary>
    private void GetDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "ListNews.PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }

        if (!string.IsNullOrEmpty(this.FolderId))
        {
            Utilities.SetDropDownListValue(this.cmbNewsFolder, this.FolderId);
            this.cmbNewsFolder.Enabled = false;
        }
        else
        {
            string category = parameterManager.GetParameter("User", this.UserInfo.Id, "ListNews.Category");
            if (category.Length > 0)
            {
                Utilities.SetDropDownListValue(this.cmbNewsFolder, category);
            }
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉框数据
    /// <summary>
    /// 绑定下拉框数据
    /// </summary>
    private void GetItemDetails()
    {
        // 数据绑定下拉框
        DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
        BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsNewsCategory");
        //if (this.UserInfo.IsAdministrator)
        //{
        dataTable = itemDetailsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldEnabled, 1), BaseItemDetailsEntity.FieldSortCode);
        //}
        //else
        //{
        //    dataTable = itemDetailsManager.GetDataTableByPermission(this.UserInfo.Id, "NewsCategory", "News.Add");
        //}
        // 用过滤器进行过滤，只显示有效的数据。
        // BaseBusinessLogic.SetFilter(dataTable, BaseItemDetailsEntity.FieldEnabled, "1");
        this.cmbNewsFolder.DataSource = dataTable;
        this.cmbNewsFolder.DataValueField = BaseItemDetailsEntity.FieldId;
        // this.cmbNewsFolder.DataValueField = BaseItemDetailsEntity.FieldItemCode;
        this.cmbNewsFolder.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbNewsFolder.DataBind();
        if (this.UserInfo.IsAdministrator)
        {
            this.cmbNewsFolder.Items.Insert(0, new ListItem());
        }

        // 若都没数据获得，就应该跳转到没权限的页面了
        //if (this.cmbNewsCategory.Items.Count == 0)
        //{
        //    Page.Response.Redirect(AccessDenyPage);
        //}
    }
    #endregion

    #region private void GetPermission() 获得页面的权限
    /// <summary>
    /// 获得页面的权限
    /// </summary>
    private void GetPermission()
    {
        this.permissionAdd = true;
        this.permissionSearch = true;
        this.permissionExport = true;

        // this.PermissionAccess = this.IsAuthorized("Send.Access");
        this.permissionAdd = this.IsAuthorized("News.Add");
        this.permissionEdit = this.IsAuthorized("News.Edit");
        this.permissionDelete = this.IsAuthorized("News.Delete");
        //this.PermissionSearch = this.IsAuthorized("Send.Search");
        //this.PermissionExport = this.IsAuthorized("Send.Export");
    }
    #endregion

    protected void cmbNewsFolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

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
        this.myNavigator.BindData(this.gridView, this.DTNews, e);
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

    #region private void SaveDataBaseParamter() 保存参数
    /// <summary>
    /// 保存参数
    /// </summary>
    private void SaveDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "ListNews.PageSize", this.myNavigator.PageSize.ToString());
        parameterManager.SetParameter("User", this.UserInfo.Id, "ListNews.Category", this.cmbNewsFolder.SelectedItem.Value);
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
            this.GetPermission();
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
        // 获取权限
        this.GetPermission();
        string folderId = this.cmbNewsFolder.SelectedValue;
        string search = this.txtSearch.Text;
        BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
        DataTable dataTable = newsManager.Search(folderId, search);
        // 用过滤器进行过滤，只显示没有删除的数据。
        // BaseBusinessLogic.SetFilter(dataTable, BaseNewsEntity.FieldDeleteMark, "1");
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTNews = dataTable;
        this.SetButtomState();
    }
    #endregion

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)(e.Row.Controls[0].FindControl("lkbSetTop"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.Controls[0].FindControl("lkbSetUp"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.Controls[0].FindControl("lkbSetDown"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.Controls[0].FindControl("lkbSetBottom"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    private string GetAuditStatus(string auditStatus)
    {
        string returnValue = string.Empty;
        if (AuditStatus.WaitForAudit.ToString().Equals(auditStatus))
        {
            returnValue = "待审核";
        }
        else
        {
            if (AuditStatus.AuditReject.ToString().Equals(auditStatus))
            {
                returnValue = "被驳回";
            }
            else
            {
                if (AuditStatus.AuditComplete.ToString().Equals(auditStatus))
                {
                    returnValue = "通过";
                }
            }
        }
        return returnValue;
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                //按钮
                LinkButton btnSetTop = (LinkButton)e.Row.Controls[0].FindControl("lkbSetTop");
                LinkButton btnSetUp = (LinkButton)e.Row.Controls[0].FindControl("lkbSetUp");
                LinkButton btnSetDown = (LinkButton)e.Row.Controls[0].FindControl("lkbSetDown");
                LinkButton btnSetBottom = (LinkButton)e.Row.Controls[0].FindControl("lkbSetBottom");
                // 按钮不显示
                if (btnSetTop != null)
                {
                    btnSetTop.Visible = false;
                }
                if (btnSetUp != null)
                {
                    btnSetUp.Visible = false;
                }
                if (btnSetDown != null)
                {
                    btnSetDown.Visible = false;
                }
                if (btnSetBottom != null)
                {
                    btnSetBottom.Visible = false;
                }
            }
            // 审核状态
            e.Row.Cells[4].Text = this.GetAuditStatus(e.Row.Cells[4].Text);
            if (this.permissionDelete)
            {
                TableCell tableCell = e.Row.Cells[this.gridView.Columns.Count - 1];
                LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
                if (btnLinkDelete != null)
                {
                    string strScript = "return confirm('您确认要删除吗？');";
                    btnLinkDelete.Attributes.Add("onclick", strScript);
                }
            }
        }
    }

    #region private void SetSort(string function, int index) 设置排序顺序
    /// <summary>
    /// 设置排序顺序
    /// </summary>
    /// <param name="function">排序动作</param>
    /// <param name="index">索引</param>
    private void SetSort(string function, int index)
    {
        string id = this.gridView.DataKeys[index].Value.ToString();
        string targetId = string.Empty;
        try
        {
            this.DbHelper.Open();
            // 判断编辑权限
            // this.CheckPermission(this.CategoryId, OperationCode.Edit);
            switch (function)
            {
                case BaseDbSortLogic.CommandSetTop:
                    if (index > 0)
                    {
                        BaseDbSortLogic.SetTop(this.DbHelper, BaseNewsEntity.TableName, id);
                        this.gridView.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetId = this.gridView.DataKeys[index - 1].Value.ToString();
                        this.gridView.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.DbHelper, BaseNewsEntity.TableName, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 2) < this.gridView.Rows.Count)
                    {
                        targetId = this.gridView.DataKeys[index + 1].Value.ToString();
                        this.gridView.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.DbHelper, BaseNewsEntity.TableName, id, targetId);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 2) < this.gridView.Rows.Count)
                    {
                        BaseDbSortLogic.SetBottom(this.DbHelper, BaseNewsEntity.TableName, id);
                        this.gridView.SelectedIndex = this.gridView.Rows.Count - 2;
                    }
                    break;
            }
            // 获取列表
            this.DoSearch();
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
    }
    #endregion

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == BaseDbSortLogic.CommandSetTop
            || e.CommandName == BaseDbSortLogic.CommandSetUp
            || e.CommandName == BaseDbSortLogic.CommandSetDown
            || e.CommandName == BaseDbSortLogic.CommandSetBottom)
        {
            // 设置排序顺序
            this.SetSort(e.CommandName, Convert.ToInt32(e.CommandArgument));
        }
    }

    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        this.ShoppingURL = ConfigurationManager.AppSettings["ShoppingURL"];
        // 导向编辑页面
        // Page.Response.Redirect(this.ShoppingURL + "/Modules/Common/NewsAdmin/EditNews.aspx?ID=" + id + "&OpenId=" + this.UserInfo.OpenId);
        // Page.Response.Redirect("GoodsEdit.aspx?ID=" + id + "&OpenId=" + this.UserInfo.OpenId);
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + this.ShoppingURL + "/Modules/Common/NewsAdmin/EditNews.aspx?ID=" + id + "&OpenId=" + this.UserInfo.OpenId + "');</script>");
    }

    #region private void DeleteMark(string id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="paramID">代码</param>
    private void DeleteMark(string id)
    {
        int returnValue = 0;
        try
        {
            this.DbHelper.Open();
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            returnValue = newsManager.SetDeleted(id);
            this.DoSearch();
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

    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.gridView.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
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
            this.DbHelper.Open();
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            returnValue = newsManager.SetDeleted(ids);
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
            this.Search();
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
        this.DTNews.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
        PageChangeEventArgs pageChangeEventArgs = new PageChangeEventArgs(this.gridView, "Sorting");
        this.myNavigator.BindData(this.gridView, this.DTNews, pageChangeEventArgs);
        this.GetPermission();
        this.SetButtomState();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.ShoppingURL = ConfigurationManager.AppSettings["ShoppingURL"];
        // string url = this.ShoppingURL + "\\Modules\\Common\\News\\EditNews.aspx?ReturnURL=NewsAdmin.aspx?OpenId=" + this.UserInfo.OpenId;
        string url = this.ShoppingURL + "/Modules/Common/NewsAdmin/EditNews.aspx?OpenId=" + this.UserInfo.OpenId + "&FolderId=" + this.cmbNewsFolder.SelectedValue;
        this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + url + "');</script>");
    }

    protected int BatchStop()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.DbHelper.Open();
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            returnValue = newsManager.SetProperty(ids, new KeyValuePair<string, object>(BaseNewsEntity.FieldEnabled, 0));
            this.DoSearch();
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopSucceed", "<script>alert('提示信息：停止发布成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "batchStopFailure", "<script>alert('提示信息：停止发布失败。');</script>");
            }
        }
        return returnValue;
    }

    protected void btnStop_Click(object sender, EventArgs e)
    {
        this.BatchStop();
    }

    protected int BatchAllow()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.DbHelper.Open();
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            returnValue = newsManager.SetProperty(ids, new KeyValuePair<string, object>(BaseNewsEntity.FieldEnabled, 1));
            this.DoSearch();
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathAllowSucceed", "<script>alert('提示信息：允许发布成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "bathAllowFailure", "<script>alert('提示信息：允许发布失败。');</script>");
            }
        }
        return returnValue;
    }

    protected void btnAllow_Click(object sender, EventArgs e)
    {
        this.BatchAllow();
    }

    private DataTable DTNews
    {
        get
        {
            return Utilities.GetFromSession("_DTNews") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTNews", value);
        }
    }
}