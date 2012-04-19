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
/// ItemsManager
/// 编码管理
///
///     2009.03.12 版本：4.1  LiuEnXiang    导出CVS时，将TargetTable列删除。
///     2009.02.18 版本：4.0  JiRiGaLa      重新整理改进，可以按表进行维护。
///     2007.11.28 版本：3.2  JiRiGaLa      数据库连接采用基类的数据库连接，当前操作员信息读取进行改进。
///     2007.02.06 版本：3.1  JiLeiLei      修改权限验证。
///     2007.01.15 版本：3.0  JiLeiLei      重新整理代码。
///     2006.12.10 版本：2.0  JiRiGaLa      重新整理一次代码。
///     2006.12.10 版本：1.0  JiRiGaLa      修改代码，添加全选删除。
///
/// 版本：4.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.02.18</date>
/// </author>
/// </remarks>
public partial class ItemsManager : BasePage
{
    private string DownloadFileName = "编码管理";

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

    protected string ItemCode
    {
        set
        {
            this.txtItemCode.Value = value;
        }
        get
        {
            return this.txtItemCode.Value;
        }
    }

    protected string CategoryId
    {
        set
        {
            this.txtCategoryId.Value = value;
        }
        get
        {
            return this.txtCategoryId.Value;
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
            if (this.CategoryId.Length == 0)
            {
                // this.CategoryId = itemsManager.GetProperty(BaseItemsEntity.FieldId, this.ItemCode, BaseItemsEntity.FieldItemCode);
            }
            else
            {
                //BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper);
                //this.TableName = itemsManager.GetProperty(BaseItemsEntity.FieldCode, this.ItemCode, BaseItemsEntity.FieldTargetTable);
            }
            if (this.ItemCode.Length == 0)
            {
                if (this.CategoryId.Length > 0)
                {
                    this.ItemCode = this.CategoryId;
                }
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

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        //if (Page.Request["TableName"] != null)
        //{
        //    this.TableName = Page.Request["TableName"].ToString();
        //}
        //if (Page.Request["ItemCode"] != null)
        //{
        //    this.ItemCode = Page.Request["ItemCode"].ToString();
        //}
        //if (Page.Request["CategoryId"] != null)
        //{
        //    this.CategoryId = Page.Request["CategoryId"].ToString();
        //}
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
        this.lblTitle.Text = "编码表";
        this.grdItems_.Columns[3].HeaderText = "编码类型";
        // 绑定表格数据
        BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
        DataTable dataTable = itemsManager.GetDataTable(BaseItemsEntity.FieldSortCode);
        if (index > -1)
        {
            this.grdItems_.EditIndex = index;
        }
        else
        {
            // 增加一行
            dataTable.Rows.Add(dataTable.NewRow());
            this.grdItems_.EditIndex = dataTable.Rows.Count - 1;
        }
        this.grdItems_.DataSource = dataTable;
        this.grdItems_.DataBind();
        return dataTable;
    }
    #endregion

    protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
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
            btn = (LinkButton)(e.Row.Controls[0].FindControl("lkbItemDetails"));
            if (btn != null)
            {
                btn.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }

    protected void grdItems_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            // JiLeiLei, 2006.12.10, 添加支持分页功能
            e.Row.Cells[0].Text = (this.grdItems_.PageIndex * this.grdItems_.PageSize + e.Row.RowIndex + 1).ToString();
            //LinkButton btnLinkDelete = (LinkButton)e.Row.Cells[12].Controls[0];
            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[e.Row.Cells.Count - 1].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要删除此数据行吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            // JiLeiLei, 2006.12.10, 添加按钮状态显示
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string paramID = dataRowView[BaseItemsEntity.FieldId].ToString();
            string paramEnabled = dataRowView[BaseItemsEntity.FieldEnabled].ToString();
            string paramCanEdit = dataRowView[BaseItemsEntity.FieldAllowEdit].ToString();
            string paramCanDelete = dataRowView[BaseItemsEntity.FieldAllowDelete].ToString();
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                // 编辑是复选框不显示
                CheckBox checkBox = (CheckBox)e.Row.Cells[1].FindControl("chkSelected");
                checkBox.Visible = false;
                checkBox.Enabled = false;
                // 添加时值默认值为真
                if (paramID.Length == 0)
                {
                    checkBox = (CheckBox)e.Row.Cells[8].FindControl("chkUseItemValue");
                    checkBox.Checked = true;
                }
                // 添加时有效默认值为真
                if (paramID.Length == 0)
                {
                    checkBox = (CheckBox)e.Row.Cells[10].FindControl("chkEnabled");
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
                if (!paramCanEdit.Equals("1"))
                {
                    if (e.Row.Cells[e.Row.Cells.Count - 2].Controls.Count > 0)
                    {
                        LinkButton linkButton = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0];
                        if (linkButton != null)
                        {
                            linkButton.Visible = false;
                        }
                    }
                }
                // 是否可以删除
                if (!paramCanDelete.Equals("1"))
                {
                    if (e.Row.Cells[e.Row.Cells.Count - 1].Controls.Count > 0)
                    {
                        LinkButton linkButton = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
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
        string id = this.grdItems_.DataKeys[index].Value.ToString();
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
                        BaseDbSortLogic.SetTop(this.UserCenterDbHelper, this.TableName, id, BaseItemsEntity.TableName);
                        this.grdItems_.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetID = this.grdItems_.DataKeys[index - 1].Value.ToString();
                        this.grdItems_.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, this.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 2) < this.grdItems_.Rows.Count)
                    {
                        targetID = this.grdItems_.DataKeys[index + 1].Value.ToString();
                        this.grdItems_.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, this.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 2) < this.grdItems_.Rows.Count)
                    {
                        BaseDbSortLogic.SetBottom(this.UserCenterDbHelper, this.TableName, id, BaseItemsEntity.TableName);
                        this.grdItems_.SelectedIndex = this.grdItems_.Rows.Count - 2;
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

    protected void grdItems_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == BaseDbSortLogic.CommandSetTop
            || e.CommandName == BaseDbSortLogic.CommandSetUp
            || e.CommandName == BaseDbSortLogic.CommandSetDown
            || e.CommandName == BaseDbSortLogic.CommandSetBottom)
        {
            // 设置排序顺序
            this.SetSort(e.CommandName, Convert.ToInt32(e.CommandArgument));
        }

        if (e.CommandName == "ItemDetails")
        {
            Page.Response.Redirect("ItemDetailsManager.aspx"
                + "?ItemCode=" + this.grdItems_.DataKeys[Convert.ToInt32(e.CommandArgument)]["Code"].ToString()
                );
        }
    }

    protected void grdItems_EditCommand(object source, GridViewEditEventArgs e)
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetList(e.NewEditIndex);
            this.grdItems_.SelectedIndex = -1;
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

    protected void grdItems_CancelCommand(object source, GridViewCancelEditEventArgs e)
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

    #region private bool CheckInput(string code, string itemName, string description) 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <param name="code">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="description">备注</param>
    /// <returns>是否输入正确</returns>
    private bool CheckInput(string code, string itemName, string description)
    {
        int MaxCodeLength = 30;    // 允许输入的最大编号长度
        int MaxFullNameLength = 30;    // 允许输入的最大名称长度
        int MaxDescriptionLength = 100;   // 允许输入的最大名称长度
        string strCheckInput = string.Empty;
        // 检查编号
        if (code.Length == 0)
        {
            strCheckInput = "<script>alert('提示信息：请输入编号。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        // 检查编号长度
        if (code.Length > MaxCodeLength)
        {
            strCheckInput = "<script>alert('提示信息：编号长度已超过" + MaxCodeLength + "个字符。'');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        // 检查名称
        if (itemName.Length == 0)
        {
            strCheckInput = "<script>alert('提示信息：请输入名称。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        // 检查名称长度
        if (itemName.Length > MaxFullNameLength)
        {
            strCheckInput = "<script>alert('提示信息：名称长度已超过" + MaxFullNameLength + "个字符。'');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
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

    #region private bool CheckDataBase(string code, string itemName, string id)
    /// <summary>
    /// 数据库检查输入的有效性
    /// </summary>
    /// <param name="code">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="id">代码</param>
    /// <returns>是否输入正确</returns>
    private bool CheckDataBase(string code, string itemName, string id)
    {
        BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
        string strCheckInput = string.Empty;
        // 检查编号是否存在
        if (itemsManager.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, code), id))
        {
            strCheckInput = "<script>alert('提示信息：编号已重复，请重新输入。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        // 检查名称是否存在
        if (itemsManager.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldFullName, itemName), id))
        {
            strCheckInput = "<script>alert('提示信息：名称已重复，请重新输入。');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", strCheckInput);
            return false;
        }
        return true;
    }
    #endregion

    #region private void DoAdd(string code, string fullName,String targetTable, string description, bool isTree, bool useItemCode, bool useItemName, bool useItemValue, bool enabled) 添加
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="code">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="itemValue">值</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoAdd(string code, string fullName, string targetTable, string description, bool isTree, string useItemCode, string useItemName, string useItemValue, bool enabled)
    {
        string returnValue = string.Empty;
        // 检查页面上的输入
        if (!this.CheckInput(code, fullName, description))
        {
            return;
        }
        BaseItemsEntity itemsEntity = new BaseItemsEntity();
        // itemsEntity.ParentID = this.ParentID;
        // itemsEntity.CategoryId = this.CategoryId;
        itemsEntity.Code = code;
        itemsEntity.FullName = fullName;
        itemsEntity.TargetTable = targetTable;
        itemsEntity.IsTree = isTree ? 1 : 0;
        itemsEntity.UseItemCode = useItemCode;
        itemsEntity.UseItemName = useItemName;
        itemsEntity.UseItemValue = useItemValue;
        itemsEntity.Enabled = enabled ? 1 : 0;
        itemsEntity.Description = description;
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(code, fullName, string.Empty))
            {
                return;
            }
            else
            {
                // 添加实体
                BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
                returnValue = itemsManager.AddEntity(itemsEntity);
                // 获取列表
                this.GetList();
                this.grdItems_.SelectedIndex = -1;
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
            if (returnValue.Length > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "AddSucceed", "<script>alert('提示信息：添加成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "AddFailure", "<script>alert('提示信息：添加失败。');</script>");
            }
        }
    }
    #endregion

    #region  private void DoUpdate(string id, string code, string fullName, string itemValue, string description, bool isTree, bool useItemCode, bool useItemName, bool useItemValue, bool enabled) 更新
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">代码</param>
    /// <param name="code">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoUpdate(string id, string code, string fullName, string targetTable, string description, bool isTree, string useItemCode, string useItemName, string useItemValue, bool enabled)
    {
        int returnValue = 0;
        // 检查页面上的输入
        if (!this.CheckInput(code, fullName, targetTable))
        {
            return;
        }
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(code, fullName, id))
            {
                return;
            }
            else
            {
                BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
                DataTable dataTable = itemsManager.GetDataTableById(id);
                BaseItemsEntity itemsEntity = new BaseItemsEntity(dataTable.Rows[0]);
                itemsEntity.Code = code;
                itemsEntity.FullName = fullName;
                itemsEntity.TargetTable = targetTable;
                itemsEntity.IsTree = isTree ? 1 : 0;
                itemsEntity.UseItemCode = useItemCode;
                itemsEntity.UseItemName = useItemName;
                itemsEntity.UseItemValue = useItemValue;
                itemsEntity.Enabled = enabled ? 1 : 0;
                itemsEntity.Description = description;
                // 判断编辑权限
                // this.CheckPermission("ItemsManager", OperationCode.Edit);
                // 更新数据
                returnValue = itemsManager.UpdateEntity(itemsEntity);
                // 获取列表
                this.GetList();
                this.grdItems_.SelectedIndex = -1;
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
            if (returnValue > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "UpdateSucceed", "<script>alert('提示信息：更新成功。');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "UpdateFailure", "<script>alert('提示信息：更新失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdItems_UpdateCommand(object source, GridViewUpdateEventArgs e)
    {
        string id = this.grdItems_.DataKeys[e.RowIndex].Value.ToString();
        TextBox txtCode = (TextBox)grdItems_.Rows[e.RowIndex].Cells[2].FindControl("txtCode");
        TextBox txtItemName = (TextBox)grdItems_.Rows[e.RowIndex].Cells[3].FindControl("txtItemName");
        TextBox txtItemValue = (TextBox)grdItems_.Rows[e.RowIndex].Cells[4].FindControl("txtItemValue");
        TextBox txtDescription = (TextBox)grdItems_.Rows[e.RowIndex].Cells[5].FindControl("txtDescription");
        CheckBox chkUseItemCode = (CheckBox)grdItems_.Rows[e.RowIndex].Cells[6].FindControl("chkUseItemCode");
        CheckBox chkUseItemName = (CheckBox)grdItems_.Rows[e.RowIndex].Cells[7].FindControl("chkUseItemName");
        CheckBox chkUseItemValue = (CheckBox)grdItems_.Rows[e.RowIndex].Cells[8].FindControl("chkUseItemValue");
        CheckBox chkIsTree = (CheckBox)grdItems_.Rows[e.RowIndex].Cells[9].FindControl("chkIsTree");
        CheckBox chkEnabled = (CheckBox)grdItems_.Rows[e.RowIndex].Cells[10].FindControl("chkEnabled");
        string code = txtCode.Text.Trim();
        string itemName = txtItemName.Text.Trim();
        string itemValue = txtItemValue.Text.Trim();
        string description = txtDescription.Text.Trim();
        bool isTree = chkIsTree.Checked;
        string useItemCode = chkUseItemCode.Checked ? "编号" : "";
        string useItemName = chkUseItemName.Checked ? "名称" : "";
        string useItemValue = chkUseItemName.Checked ? "值" : "";
        bool enabled = chkEnabled.Checked;
        if (id.Length == 0)
        {
            // 添加
            this.DoAdd(code, itemName, itemValue, description, isTree, useItemCode, useItemName, useItemValue, enabled);
        }
        else
        {
            // 更新
            this.DoUpdate(id, code, itemName, itemValue, description, isTree, useItemCode, useItemName, useItemValue, enabled);
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
            BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            returnValue = itemsManager.Delete(id);
            // 获取列表
            this.GetList();
            this.grdItems_.SelectedIndex = -1;
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                // 提示删除失败
                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdItems_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.grdItems_.DataKeys[e.RowIndex].Value.ToString();
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
        string[] ids = Utilities.GetSelecteIds(this.grdItems_);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            returnValue = itemsManager.Delete(ids);
            this.grdItems_.EditIndex = -1;
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
                                        "ID"
                                      , "ParentID"
                                      , "AllowEdit"
                                      , "AllowDelete" 
                                      , "SortCode"
                                      , "CreateUserId"
                                      , "CreateDate"
                                      , "ModifyUserId"
                                      , "ModifyDate" 
                                    };
        for (int i = 0; i < removeColumns.Length; i++)
        {
            dataTable.Columns.Remove(dataTable.Columns[removeColumns[i]]);
        }
        string[][] columnsName = new string[][]
            {
                new string[] { "Code", "编号" },
                new string[] { "FullName", "名称" },
                new string[] { "TargetTable", "值" },
                new string[] { "Description", "备注" },
                new string[] { "UseItemCode", "用编号" },
                new string[] { "UseItemName", "用名称" },
                new string[] { "UseItemValue", "用值" },
                new string[] { "IsTree", "树" },
                new string[] { "Enabled", "有效" }
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
            BaseItemsManager itemsManager = new BaseItemsManager(this.UserCenterDbHelper, this.UserInfo, this.TableName);
            DataTable dataTable = itemsManager.GetDataTable();
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
}