using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// ItemDetailsManager
/// 编码管理
///
///     2009.06.24 版本：5.0  JiRiGaLa      可编辑列的显示与否。
///     2009.03.12 版本：4.1  LiuEnXiang    导出CVS时，将TargetTable列删除。
///     2009.02.18 版本：4.0  JiRiGaLa      重新整理改进，可以按表进行维护。
///     2007.11.28 版本：3.2  JiRiGaLa      数据库连接采用基类的数据库连接，当前操作员信息读取进行改进。
///     2007.02.06 版本：3.1  JiLeiLei      修改权限验证。
///     2007.01.15 版本：3.0  JiLeiLei      重新整理代码。
///     2006.12.10 版本：2.0  JiRiGaLa      重新整理一次代码。
///     2006.12.10 版本：1.0  JiRiGaLa      修改代码，添加全选删除。
///
/// 版本：5.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.06.24</date>
/// </author>
/// </remarks>
public partial class ItemDetailsManager : BasePage
{
    private string DownloadFileName = "编码管理";

    protected string ReturnURL
    {
        set
        {
            this.txtReturnURL.Value = value;
        }
        get
        {
            return this.txtReturnURL.Value;
        }
    }

    protected string UseItemCode
    {
        set
        {
            this.txtUseItemCode.Value = value;
        }
        get
        {
            return this.txtUseItemCode.Value;
        }
    }

    protected string UseItemName
    {
        set
        {
            this.txtUseItemName.Value = value;
        }
        get
        {
            return this.txtUseItemName.Value;
        }
    }

    protected string UseItemValue
    {
        set
        {
            this.txtUseItemValue.Value = value;
        }
        get
        {
            return this.txtUseItemValue.Value;
        }
    }

    protected string ItemCode
    {
        set
        {
            this.txtCode.Value = value;
        }
        get
        {
            return this.txtCode.Value;
        }
    }

    protected string TableName
    {
        set
        {
            this.txtTableName.Value = value;
        }
        get
        {
            return this.txtTableName.Value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        this.GetParamter();
        try
        {
            this.UserCenterDbHelper.Open();
            BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper);
            DataTable dataTable = itemsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, this.ItemCode));
            BaseItemsEntity itemsEntity = new BaseItemsEntity(dataTable);
            this.UseItemCode = itemsEntity.UseItemCode;
            this.UseItemName = itemsEntity.UseItemName;
            this.UseItemValue = itemsEntity.UseItemValue;
            this.TableName = itemsEntity.TargetTable;
            // itemsManager.GetProperty(BaseItemsEntity.FieldCode, this.ItemCode, BaseItemsEntity.FieldTargetTable);
            // 设置按钮状态
            this.SetButtonState();
            // 获取列表
            this.GetList();
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
        if (Page.Request["TableName"] != null)
        {
            this.TableName = Page.Request["TableName"].ToString();
        }
        if (Page.Request["ItemCode"] != null)
        {
            this.ItemCode = Page.Request["ItemCode"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    #region private void SetButtonState() 设置按钮状态
    /// <summary>
    /// 设置按钮状态
    /// </summary>
    private void SetButtonState()
    {
        this.grdItemDetails.Columns[4].HeaderText = this.UseItemValue;
        this.grdItemDetails.Columns[4].Visible = !string.IsNullOrEmpty(this.UseItemValue);

        this.grdItemDetails.Columns[3].HeaderText = this.UseItemName;
        this.grdItemDetails.Columns[3].Visible = !string.IsNullOrEmpty(this.UseItemName);

        this.grdItemDetails.Columns[2].HeaderText = this.UseItemCode;
        this.grdItemDetails.Columns[2].Visible = !string.IsNullOrEmpty(this.UseItemCode);

        // 设置返回按钮显示状态
        if (ReturnURL.Length == 0)
        {
            this.btnReturn.Visible = false;
        }
        else
        {
            this.btnReturn.Visible = true;
        }
    }
    #endregion

    #region private void GetList() 获取列表
    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        // 获取列表
        this.GetList(-1);
    }
    #endregion

    #region private DataTable GetList(int id)
    /// <summary>
    /// 数据绑定
    /// </summary>
    /// <param name="id">索引</param>
    /// <returns>数据集</returns>
    private DataTable GetList(int index)
    {
        // 动态标题
        BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo);
        this.lblTitle.Text = itemsManager.GetProperty(new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, this.ItemCode), BaseItemsEntity.FieldFullName);
        // 绑定表格数据
        //this.DbHelper.Open();
        BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
        DataTable dataTable = itemDetailsManager.GetDataTable(BaseItemDetailsEntity.FieldSortCode);
        //DataTable dataTable = itemDetailsManager.GetDataTable(BaseItemDetailsEntity.FieldEnabled, "1", BaseItemDetailsEntity.FieldSortCode);
        if (index > -1)
        {
            this.grdItemDetails.EditIndex = index;
        }
        else
        {
            // 增加一行
            dataTable.Rows.Add(dataTable.NewRow());
            this.grdItemDetails.EditIndex = dataTable.Rows.Count - 1;
        }
        this.grdItemDetails.DataSource = dataTable;
        this.grdItemDetails.DataBind();
        return dataTable;
    }
    #endregion

    protected void grdItemDetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void grdItemDetails_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // JiLeiLei, 2006.12.10, 添加支持分页功能
            // e.Row.Cells[0].Text = (this.grdItemDetails.PageIndex * this.grdItemDetails.PageSize + e.Row.RowIndex + 1).ToString();
            //LinkButton btnLinkDelete = (LinkButton)e.Row.Cells[12].Controls[0];
            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[9].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[9].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要删除此数据行吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            // JiLeiLei, 2006.12.10, 添加按钮状态显示
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string id = dataRowView[BaseItemDetailsEntity.FieldId].ToString();
            string enabled = dataRowView[BaseItemDetailsEntity.FieldEnabled].ToString();
            string canEdit = dataRowView[BaseItemDetailsEntity.FieldAllowEdit].ToString();
            string canDelete = dataRowView[BaseItemDetailsEntity.FieldAllowDelete].ToString();
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                // 编辑是复选框不显示
                CheckBox checkBox = (CheckBox)e.Row.Cells[1].FindControl("chkSelected");
                checkBox.Visible = false;
                checkBox.Enabled = false;
                // 添加时有效默认值为真
                if (id.Length == 0)
                {
                    checkBox = (CheckBox)e.Row.Cells[6].FindControl("chkEnabled");
                    checkBox.Checked = true;
                }
                //按钮
                LinkButton btnSetTop = (LinkButton)e.Row.Controls[0].FindControl("lkbSetTop");
                LinkButton btnSetUp = (LinkButton)e.Row.Controls[0].FindControl("lkbSetUp");
                LinkButton btnSetDown = (LinkButton)e.Row.Controls[0].FindControl("lkbSetDown");
                LinkButton btnSetBottom = (LinkButton)e.Row.Controls[0].FindControl("lkbSetBottom");
                // 按钮不显示
                if (btnLinkDelete != null)
                {
                    btnLinkDelete.Visible = false;
                }
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
            if (!(e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                // 是否可以编辑
                if (!canEdit.Equals("1"))
                {
                    if (e.Row.Cells[8].Controls.Count > 0)
                    {
                        LinkButton linkButton = (LinkButton)e.Row.Cells[8].Controls[0];
                        if (linkButton != null)
                        {
                            linkButton.Visible = false;
                        }
                    }
                }
                // 是否可以删除
                if (!canDelete.Equals("1"))
                {
                    if (e.Row.Cells[9].Controls.Count > 0)
                    {
                        LinkButton linkButton = (LinkButton)e.Row.Cells[9].Controls[0];
                        if (linkButton != null)
                        {
                            linkButton.Visible = false;
                        }
                    }
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
        string id = this.grdItemDetails.DataKeys[index].Value.ToString();
        string targetID = string.Empty;
        try
        {
            this.UserCenterDbHelper.Open();
            // 判断编辑权限
            // this.CheckPermission(this.CategoryId, OperationCode.Edit);
            switch (function)
            {
                case BaseDbSortLogic.CommandSetTop:
                    if (index > 0)
                    {
                        BaseDbSortLogic.SetTop(this.UserCenterDbHelper, this.TableName, id, BaseItemDetailsEntity.TableName);
                        this.grdItemDetails.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetID = this.grdItemDetails.DataKeys[index - 1].Value.ToString();
                        this.grdItemDetails.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, this.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 2) < this.grdItemDetails.Rows.Count)
                    {
                        targetID = this.grdItemDetails.DataKeys[index + 1].Value.ToString();
                        this.grdItemDetails.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, this.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 2) < this.grdItemDetails.Rows.Count)
                    {
                        BaseDbSortLogic.SetBottom(this.UserCenterDbHelper, this.TableName, id, BaseItemDetailsEntity.TableName);
                        this.grdItemDetails.SelectedIndex = this.grdItemDetails.Rows.Count - 2;
                    }
                    break;
            }
            // 获取列表
            this.GetList();
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

    protected void grdItemDetails_ItemCommand(object source, GridViewCommandEventArgs e)
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

    protected void grdItemDetails_EditCommand(object source, GridViewEditEventArgs e)
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetList(e.NewEditIndex);
            this.grdItemDetails.SelectedIndex = -1;
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

    protected void grdItemDetails_CancelCommand(object source, GridViewCancelEditEventArgs e)
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetList();
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

    #region private bool CheckInput(string itemCode, string itemName, string itemValue, string description) 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <param name="itemCode">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="itemValue">值</param>
    /// <param name="description">备注</param>
    /// <returns>是否输入正确</returns>
    private bool CheckInput(string itemCode, string itemName, string itemValue, string description)
    {
        int MaxCodeLength = 30;    // 允许输入的最大编号长度
        int MaxFullNameLength = 30;    // 允许输入的最大名称长度
        int MaxDescriptionLength = 100;   // 允许输入的最大名称长度
        string strCheckInput = string.Empty;
        if (!string.IsNullOrEmpty(this.UseItemCode))
        {
            // 检查编号
            if (itemCode.Length == 0)
            {
                strCheckInput = "<script>alert('提示信息：请输入" + this.UseItemCode + "。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
            // 检查编号长度
            if (itemCode.Length > MaxCodeLength)
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemCode + "长度已超过" + MaxCodeLength + "个字符。'');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        if (!string.IsNullOrEmpty(this.UseItemName))
        {
            // 检查名称
            if (itemName.Length == 0)
            {
                strCheckInput = "<script>alert('提示信息：请输入" + this.UseItemName + "。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
            // 检查名称长度
            if (itemName.Length > MaxFullNameLength)
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemName + "长度已超过" + MaxFullNameLength + "个字符。'');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        if (!string.IsNullOrEmpty(this.UseItemValue))
        {
            // 检查名称
            if (itemValue.Length == 0)
            {
                strCheckInput = "<script>alert('提示信息：请输入" + this.UseItemValue + "。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
            // 检查名称长度
            if (itemValue.Length > MaxFullNameLength)
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemValue + "长度已超过" + MaxFullNameLength + "个字符。'');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        // 检查备注长度
        if (description.Length > MaxDescriptionLength)
        {
            strCheckInput = "<script>alert('提示信息：备注长度已超过" + MaxFullNameLength + "个字符。'');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        return true;
    }
    #endregion

    #region private bool CheckDataBase(string id, string itemCode, string itemName, string itemValue)
    /// <summary>
    /// 数据库检查输入的有效性
    /// </summary>
    /// <param name="id">代码</param>
    /// <param name="itemCode">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="itemValue">值</param>
    /// <returns>是否输入正确</returns>
    private bool CheckDataBase(string id, string itemCode, string itemName, string itemValue)
    {
        BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
        string strCheckInput = string.Empty;
        if (!String.IsNullOrEmpty(itemCode))
        {
            // 检查编号是否存在
            if (itemDetailsManager.Exists(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemCode, itemCode), id))
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemCode + "已重复，请重新输入。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        if (!String.IsNullOrEmpty(itemName))
        {
            // 检查名称是否存在
            if (itemDetailsManager.Exists(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemName, itemName), id))
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemName + "已重复，请重新输入。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        if (!String.IsNullOrEmpty(itemValue))
        {
            // 检查名称是否存在
            if (itemDetailsManager.Exists(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemValue, itemValue), id))
            {
                strCheckInput = "<script>alert('提示信息：" + this.UseItemValue + "已重复，请重新输入。');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
                return false;
            }
        }
        return true;
    }
    #endregion

    #region private void DoAdd(string itemCode, string itemName,String itemValue, string description, bool enabled) 添加
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="itemCode">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="itemValue">值</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoAdd(string itemCode, string itemName, string itemValue, string description, bool enabled)
    {
        string returnValue = string.Empty;
        // 检查页面上的输入
        if (!this.CheckInput(itemCode, itemName, itemValue, description))
        {
            return;
        }
        BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity();
        // itemDetailsEntity.ParentID = this.ParentID;
        // itemDetailsEntity.CategoryId = this.CategoryId;
        itemDetailsEntity.ItemCode = itemCode;
        itemDetailsEntity.ItemName = itemName;
        itemDetailsEntity.ItemValue = itemValue;
        itemDetailsEntity.Enabled = 1;
        itemDetailsEntity.Description = description;
        itemDetailsEntity.IsPublic = 1;
        itemDetailsEntity.DeletionStateCode = 0;
        itemDetailsEntity.AllowDelete = 1;
        itemDetailsEntity.AllowEdit = 1;
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(string.Empty, itemCode, itemName, itemValue))
            {
                return;
            }
            else
            {
                // 添加实体
                BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
                returnValue = itemDetailsManager.AddEntity(itemDetailsEntity);
                // 获取列表
                this.GetList();
                this.grdItemDetails.SelectedIndex = -1;
            }
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
        if (Utilities.ShowInformation)
        {
            /*
            if (returnValue.Length > 0)
            {
                string url = "../../Common/System/Messages.aspx"
                    + "?MessageType=MessageOk"
                    + "&Mtitle=保存成功"
                    + "&Mbody=保存成功！"
                    + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
            else
            {
                string url = "../../Common/System/Messages.aspx"
                    + "?MessageType=MessageError"
                    + "&Mtitle=保存失败"
                    + "&Mbody=保存失败！"
                    + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
            */
        }
    }
    #endregion

    #region  private void DoUpdate(string id, string code, string itemName, string itemValue, string description, bool enabled) 更新
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">代码</param>
    /// <param name="code">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoUpdate(string id, string itemCode, string itemName, string itemValue, string description, bool enabled)
    {
        int returnValue = 0;
        // 检查页面上的输入
        if (!this.CheckInput(itemCode, itemName, itemValue, description))
        {
            return;
        }
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(id, itemCode, itemName, itemValue))
            {
                return;
            }
            else
            {
                BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
                DataTable dataTable = itemDetailsManager.GetDataTableById(id);
                BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity(dataTable.Rows[0]);
                itemDetailsEntity.ItemCode = itemCode;
                itemDetailsEntity.ItemName = itemName;
                itemDetailsEntity.ItemValue = itemValue;
                itemDetailsEntity.Description = description;
                itemDetailsEntity.Enabled = 1;
                // 判断编辑权限
                // this.CheckPermission("ItemDetailsManager", OperationCode.Edit);
                // 更新数据
                returnValue = itemDetailsManager.UpdateEntity(itemDetailsEntity);
                // 获取列表
                this.GetList();
                this.grdItemDetails.SelectedIndex = -1;
            }
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
        if (Utilities.ShowInformation)
        {
            /*
            if (returnValue > 0)
            {
                string url = "../../Common/System/Messages.aspx"
                    + "?MessageType=MessageOk"
                    + "&Mtitle=更新成功"
                    + "&Mbody=更新成功。"
                    + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
            else
            {
                string url = "../../Common/System/Messages.aspx"
                   + "?MessageType=MessageError"
                   + "&Mtitle=更新失败"
                   + "&Mbody=更新失败。"
                   + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
            */
        }
    }
    #endregion

    protected void grdItemDetails_UpdateCommand(object source, GridViewUpdateEventArgs e)
    {
        // 变量定义部分
        string itemCode = string.Empty;
        string itemName = string.Empty;
        string itemValue = string.Empty;
        string description = string.Empty;
        bool enabled = true;

        // 读取变量部分
        string id = this.grdItemDetails.DataKeys[e.RowIndex].Value.ToString();
        if (!string.IsNullOrEmpty(this.UseItemCode))
        {
            TextBox txtItemCode = (TextBox)grdItemDetails.Rows[e.RowIndex].FindControl("txtItemCode");
            itemCode = txtItemCode.Text.Trim();
        }
        if (!string.IsNullOrEmpty(this.UseItemName))
        {
            TextBox txtItemName = (TextBox)grdItemDetails.Rows[e.RowIndex].FindControl("txtItemName");
            itemName = txtItemName.Text.Trim();
        }
        if (!string.IsNullOrEmpty(this.UseItemValue))
        {
            TextBox txtItemValue = (TextBox)grdItemDetails.Rows[e.RowIndex].FindControl("txtItemValue");
            itemValue = txtItemValue.Text.Trim();
        }
        TextBox txtDescription = (TextBox)grdItemDetails.Rows[e.RowIndex].FindControl("txtDescription");
        CheckBox chkEnabled = (CheckBox)grdItemDetails.Rows[e.RowIndex].FindControl("chkEnabled");
        description = txtDescription.Text.Trim();
        enabled = chkEnabled.Checked;

        // 更新部分
        if (id.Length == 0)
        {
            // 添加
            this.DoAdd(itemCode, itemName, itemValue, description, enabled);
        }
        else
        {
            // 更新
            this.DoUpdate(id, itemCode, itemName, itemValue, description, enabled);
        }
    }

    #region private void Delete(string id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">代码</param>
    private void Delete(string id)
    {
        int returnValue = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            // 删除数据
            BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            returnValue = itemDetailsManager.Delete(id);
            // 获取列表
            this.GetList();
            this.grdItemDetails.SelectedIndex = -1;
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
                // 提示删除成功
                string url = "../../Common/System/Messages.aspx"
                  + "?MessageType=MessageOk"
                  + "&Mtitle=删除成功"
                  + "&Mbody=删除成功！"
                  + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
            else
            {
                // 提示删除失败
                string url = "../../Common/System/Messages.aspx"
                    + "?MessageType=MessageError"
                    + "&Mtitle=删除失败"
                    + "&Mbody=删除失败！"
                    + "&MbuttonUrl=../../Common/ItemDetails/ItemDetailsManager.aspx?ItemCode=" + this.ItemCode;
                Page.Response.Redirect(url);
            }
        }
    }
    #endregion

    protected void grdItemDetails_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.grdItemDetails.DataKeys[e.RowIndex].Value.ToString();
        // 删除数据
        this.Delete(id);
    }

    #region private int BatchDelete() 批量删除
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchDelete()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.grdItemDetails);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            returnValue = itemDetailsManager.Delete(ids);
            this.grdItemDetails.EditIndex = -1;
            this.GetList();
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
        return returnValue;
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // 批量删除
        this.BatchDelete();
    }

    #region private void FormatData(DataTable dataTable) 格式化数据
    /// <summary>
    /// 格式化数据
    /// </summary>
    /// <param name="myDataSet">数据集</param>
    private void FormatData(DataTable dataTable)
    {
        string[] removeColumns = { 
                                       BaseItemDetailsEntity.FieldAllowDelete
                                      , BaseItemDetailsEntity.FieldAllowEdit
                                      , BaseItemDetailsEntity.FieldCreateOn
                                      , BaseItemDetailsEntity.FieldCreateUserId
                                      , BaseItemDetailsEntity.FieldEnabled
                                      , BaseItemDetailsEntity.FieldId
                                      , BaseItemDetailsEntity.FieldModifiedOn
                                      , BaseItemDetailsEntity.FieldModifiedBy
                                      , BaseItemDetailsEntity.FieldParentId
                                      , BaseItemDetailsEntity.FieldSortCode
                                      , BaseItemDetailsEntity.FieldItemCode
                                      , BaseItemDetailsEntity.FieldItemName
                                    };
        for (int i = 0; i < removeColumns.Length; i++)
        {
            if (dataTable.Columns.Contains(removeColumns[i]))
            {
                dataTable.Columns.Remove(dataTable.Columns[removeColumns[i]]);
            }
        }
        string[][] columnsName = new string[][]
            {
                new string[] { BaseItemDetailsEntity.FieldItemValue, "值" },
                new string[] { BaseItemDetailsEntity.FieldDescription, "备注" }
            };
        for (int i = 0; i < columnsName.Length; i++)
        {
            dataTable.Columns[columnsName[i][0]].ColumnName = columnsName[i][1];
        }
    }
    #endregion

    #region private void ExportCSV() 导出CSV
    /// <summary>
    /// 导出CSV
    /// </summary>
    private void ExportCSV()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            DataTable dataTable = itemDetailsManager.GetDataTable();
            // 格式化数据
            this.FormatData(dataTable);
            this.DownloadFileName = Server.UrlEncode(this.DownloadFileName);
            BaseExportCSV.GetResponseCSV(dataTable, this.DownloadFileName + ".csv");
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

    protected void btnExportCSV_Click(object sender, EventArgs e)
    {
        // 导出CSV
        this.ExportCSV();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modules/" + ReturnURL + ".aspx");
    }
}