//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;
using Project;

/// <remarks>
/// SubmitMaintain
/// 提交
///
///     2012.04.06 版本：1.2  zgl 规范代码
///     2012.03.31 版本：1.0  JiRiGaLa 创建代码。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012.03.14</date>
/// </author>
/// </remarks>
public partial class SubmitMaintain : BasePage
{

    #region private void GetPermission() 获得页面的权限
    /// <summary>
    /// 获得页面的权限
    /// </summary>
    private void GetPermission()
    {
        // 每个人都可以管理自己的页面，不需要判断权限
        /*
        this.permissionDelete = this.IsAuthorized("Maintain.Delete");
        */
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.gridView.Rows.Count > 0;
        this.btnSetSend.Enabled = this.gridView.Rows.Count > 0;
        this.btnDelete.Enabled = this.gridView.Rows.Count > 0;
        this.myNavigator.Visible = this.gridView.Rows.Count > 0;
    }
    #endregion

    #region private void GetDataBaseParamter() 从数据库读取参数
    /// <summary>
    /// 从数据库读取参数，每页显示几条
    /// </summary>
    private void GetDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "Submit..PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }
    }
    #endregion

    #region private void SaveDataBaseParamter() 参数保存到数据库，每页显示几条
    /// <summary>
    /// 参数保存到数据库，每页显示几条
    /// </summary>
    private void SaveDataBaseParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "Submit..PageSize", this.myNavigator.PageSize.ToString());
    }
    #endregion

    #region private void DoSearch() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void DoSearch()
    {
        string searchValue = this.txtSearch.Text;
        // 总记录数量
        int recordCount = 0;
        MaintainManager maintainManager = new MaintainManager(this.UserCenterDbHelper, this.UserInfo);
        // DataTable dataTable = maintainManager.GetDataTableByPage(this.UserInfo.Id, "草稿", searchValue, out recordCount, this.myNavigator.PageIndex + 1, this.myNavigator.PageSize, this.SortExpression, this.SortDire);
        DataTable dataTable = maintainManager.GetDataTableByPage(this.UserInfo.Id, string.Empty, MaintainStatus.Draft.ToDescription(), searchValue, out recordCount, this.myNavigator.PageIndex + 1, this.myNavigator.PageSize, this.SortExpression, this.SortDire);
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        // 绑定分页控件
        this.myNavigator.RowCount = recordCount;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.SetControlState();
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

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            // 从数据库读取参数，每页显示几条
            this.GetDataBaseParamter();
            // 获得页面的权限
            this.GetPermission();
            // 获取列表
            this.DoSearch();
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
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 判断是否登录
        Utilities.CheckIsLogOn();
        if (!Page.IsPostBack)
        {
            this.DoPageLoad();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void gridView_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string description = dataRowView[MaintainEntity.FieldDescription].ToString();
            e.Row.Cells[6].Text = description.Replace("\r\n", "<br>");
            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[4].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[4].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要删除此数据行吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
        }
    }

    #region private void GetList(PageChangeEventArgs e)
    /// <summary>
    /// 绑定信息
    /// </summary>
    /// <param name="e">事件</param>
    private void GetList(PageChangeEventArgs e)
    {
        this.DoSearch();
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
        this.DoSearch();
    }

    #region private void EditDetails(string id) 编辑信息
    /// <summary>
    /// 编辑信息
    /// </summary>
    /// <param name="id">主键</param>
    private void EditDetails(string id)
    {
        // 这个是为了防止网页缓存用的
        string ticks = DateTime.Now.Ticks.ToString();
        if (!string.IsNullOrEmpty(id))
        {
            Page.Response.Redirect("EditMaintain.aspx?Id=" + id + "&ReturnURL=SubmitMaintain.aspx&ticks=" + ticks);
        }
    }
    #endregion

    protected void gridView_EditCommand(object source, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        this.EditDetails(id);
    }

    #region private void ShowDetail(string id) 显示明细
    /// <summary>
    /// 显示明细
    /// </summary>
    /// <param name="id">主键</param>
    private void ShowDetail(string id)
    {
        // 这个是为了防止网页缓存用的
        string ticks = DateTime.Now.Ticks.ToString();
        if (!string.IsNullOrEmpty(id))
        {
            Page.Response.Redirect("ShowMaintain.aspx?Id=" + id + "&ticks=" + ticks);
        }
    }
    #endregion

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetail")
        {
            string id = e.CommandArgument.ToString();
            this.ShowDetail(id);
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
            MaintainManager manager = new MaintainManager(this.DbHelper, this.UserInfo);
            returnValue = manager.SetDeleted(id);
            if (this.gridView.Rows.Count - 1 == 0 && this.myNavigator.PageIndex >= 1)
                this.myNavigator.PageIndex--;
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

    protected void myNavigator_PageChange(object sender, PageChangeEventArgs e)
    {
        this.GetList(e);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("AddMaintain.aspx");
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
            // this.DbHelper.BeginTransaction();
            MaintainManager manager = new MaintainManager(this.DbHelper, this.UserInfo);
            returnValue = manager.SetDeleted(ids);
            if (this.gridView.Rows.Count - ids.Length == 0 && this.myNavigator.PageIndex>=1)
                this.myNavigator.PageIndex--;
            // this.DbHelper.CommitTransaction();
        }
        catch (Exception ex)
        {
            // this.DbHelper.RollbackTransaction();
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
            this.DoSearch();
        }
        // 是否显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：批量删除成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：批量删除失败。');</script>");
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

    #region private int SetSend() 批量提交
    /// <summary>
    /// 批量提交
    /// </summary>
    /// <returns>影响的行数</returns>
    private int SetSend()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        MaintainManager manager = new MaintainManager(this.DbHelper, this.UserInfo);
        returnValue = manager.SetSend(ids);
        this.DoSearch();
        return returnValue;
    }
    #endregion

    protected void btnSetSend_Click(object sender, EventArgs e)
    {
        // 批量提交
        this.SetSend();
    }

    protected void btnWorkFlowSend_Click(object sender, EventArgs e)
    {

    }
}