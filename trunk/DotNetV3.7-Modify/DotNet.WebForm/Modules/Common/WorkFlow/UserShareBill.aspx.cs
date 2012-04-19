//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// UserShareBill
/// 共享单据
///
/// 查询记录
/// 
///     2012.01.14 版本：1.2 JiRiGaLa 处理标志。
///     2011.09.18 版本：1.1 张广梁   完善检索。
///		2011.09.08 版本：1.0 JiRiGaLa 创建程序。
///
/// 版本：1.1
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2011.09.08</date>
/// </author>
/// </remarks>
public partial class UserShareBill : BasePage
{
    string CategoryCode = string.Empty;

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        // 设置分页控件的显示状态
        this.myNavigator.Visible = this.gridView.Rows.Count > 0;
        this.btnCheckAll.Enabled = this.gridView.Rows.Count > 1;
        this.btnSetWorked.Enabled = this.gridView.Rows.Count > 0;
        this.btnUnWorked.Enabled = this.gridView.Rows.Count > 0;
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
        if (Page.Request["CategoryCode"] != null)
        {
            this.CategoryCode = Page.Request["CategoryCode"].ToString();
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = templateManager.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0), BaseNewsEntity.FieldSortCode + " DESC");
        this.cmbBill.DataSource = dataTable;
        this.cmbBill.DataTextField = BaseNewsEntity.FieldTitle;
        this.cmbBill.DataValueField = BaseNewsEntity.FieldCode;
        this.cmbBill.DataBind();
        this.cmbBill.Items.Insert(0, new ListItem());
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
            // 设置默认的排序顺序
            this.SortExpression = "CREATEON";
            this.SortDire = "DESC";
            // 获取数据
            this.GetItemDetails();
            this.GetParamters();
            this.UserCenterDbHelper.Open();
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
        BaseParameterManager parameterManager = new BaseParameterManager(this.WorkFlowDbHelper, this.UserInfo);
        string pageSize = parameterManager.GetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize");
        if (pageSize.Length > 0)
        {
            this.myNavigator.PageSize = int.Parse(pageSize);
        }
    }
    #endregion

    #region private void GetPermission() 获得页面的权限
    /// <summary>
    /// 获得页面的权限
    /// </summary>
    private void GetPermission()
    {
    }
    #endregion

    protected void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
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
        this.myNavigator.BindData(this.gridView, this.DTUserBill, e);
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
        BaseParameterManager parameterManager = new BaseParameterManager(this.WorkFlowDbHelper, this.UserInfo);
        parameterManager.SetParameter("User", this.UserInfo.Id, "UserBillAdmin.PageSize", this.myNavigator.PageSize.ToString());
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
        string search = this.txtSearch.Text;
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
        DataTable dataTable = workFlowCurrentManager.GetShareBillDT(this.cmbBill.SelectedItem.Value, search);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow[BaseNewsEntity.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseNewsEntity.FieldAuditStatus].ToString());
        }
        dataTable.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.myNavigator.BindData(this.gridView, dataTable);
        this.DTUserBill = dataTable;
        this.SetControlState();
    }
    #endregion

    // 这里读取每个列的状态，是否处理标志
    private BaseParameterManager manager = null;
    private BaseParameterManager parameterManager
    {
        get
        {
            if (manager == null)
            {
                manager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
            }
            return manager;
        }
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 这里需要处理单据的状态
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            if (dataRowView != null)
            {
                string id = dataRowView[BaseWorkFlowCurrentEntity.FieldId].ToString();
                string worked = parameterManager.GetParameter("User", id, this.UserInfo.Id);
                dataRowView.Row["Worked"] = worked == "1" ? 1 : 0;
            }
        }
    }

    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
        }
    }

    protected void gridView_ItemCommand(object source, GridViewCommandEventArgs e)
    {

    }

    #region private void ShowDetails(string currentId) 查看详情
    private void ShowDetails(string currentId)
    {
        if (!string.IsNullOrEmpty(currentId))
        {
            currentId = Server.HtmlEncode(currentId);
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(currentId);
            // 从模板表里有效状态区分,是否模板还是报表
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity entity = templateManager.GetEntity(workFlowCurrentEntity.CategoryCode);
            string templateSource = "report";
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                templateSource = entity.Source;
            }
            if (templateSource.Equals("report"))
            {
                // 若是报表,就显示报表
                this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowReport.aspx?Id=" + currentId + "');</script>");
            }
            else
            {
                // 若是单据,就显示单据
                this.ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", "<script>window.open('" + "ShowUserBill.aspx?Id=" + currentId + "&ReadOnly=True&ShowAuditList=True');</script>");
            }
        }
    }
    #endregion

    protected void gridView_RowEditing(object source, GridViewEditEventArgs e)
    {
        string id = this.gridView.DataKeys[e.NewEditIndex].Values["Id"].ToString();
        e.NewEditIndex = -1;
        this.ShowDetails(id);
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
        this.DTUserBill.DefaultView.Sort = this.SortExpression + " " + this.SortDire;
        this.gridView.EditIndex = -1;
        PageChangeEventArgs pageChangeEventArgs = new PageChangeEventArgs(this.gridView, "Sorting");
        this.myNavigator.BindData(this.gridView, this.DTUserBill, pageChangeEventArgs);
        this.GetPermission();
        this.SetControlState();
    }

    private DataTable DTUserBill
    {
        get
        {
            return Utilities.GetFromSession("_DTUserBill") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTUserBill", value);
        }
    }

    /// <summary>
    /// 设置单据的处理标志，每个人需要有每个人自己的标志，不能混在一起
    /// </summary>
    /// <param name="ids">单据主键</param>
    /// <param name="worked">处理标志</param>
    /// <returns>影响行数</returns>
    private int SetWorked(string[] ids, bool worked)
    {
        int returnValue = 0;
        string workedMark = worked ? "1" : string.Empty;
        BaseParameterManager manager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        for (int i = 0; i < ids.Length; i++)
        {
            returnValue += manager.SetParameter("User", ids[i], this.UserInfo.Id, workedMark);
        }
        return returnValue;
    }

    protected void btnSetWorked_Click(object sender, EventArgs e)
    {
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.SetWorked(ids, true);
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
    }

    protected void btnUnWorked_Click(object sender, EventArgs e)
    {
        string[] ids = Utilities.GetSelecteIds(this.gridView);
        try
        {
            this.SetWorked(ids, false);
            this.gridView.EditIndex = -1;
            this.Search();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
        }
    }
}