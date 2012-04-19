//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// RoleAdmin
/// 角色管理
///
///     2009.08.13 版本：1.0  JiRiGaLa      创建代码。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.08.13</date>
/// </author>
/// </remarks>
public partial class RoleAdmin : BasePage
{
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
        try
        {
            this.UserCenterDbHelper.Open();
            // 获取列表
            this.GetList();
            // 设置按钮状态
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
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        this.btnCheckAll.Enabled = this.grdRole.Rows.Count > 1;
        this.btnDelete.Enabled = this.grdRole.Rows.Count > 0;
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
    /// <returns>数据权限</returns>
    private DataTable GetList(int index)
    {
        // 动态标题
        BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable dataTable = roleManager.GetDataTable(BaseRoleEntity.FieldSortCode);
        if (index > -1)
        {
            this.grdRole.EditIndex = index;
        }
        else
        {
            // 增加一行
            dataTable.Rows.Add(dataTable.NewRow());
            this.grdRole.EditIndex = dataTable.Rows.Count - 1;
        }
        this.grdRole.DataSource = dataTable;
        this.grdRole.DataBind();
        return dataTable;
    }
    #endregion

    protected void grdRole_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)(e.Row.FindControl("lkbSetTop"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetUp"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetDown"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
            btn = (LinkButton)(e.Row.FindControl("lkbSetBottom"));
            btn.CommandArgument = e.Row.RowIndex.ToString();
        }
    }


    protected void grdRole_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowState == DataControlRowState.Normal && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            //LinkButton btnLinkDelete = (LinkButton)e.Row.Cells[12].Controls[0];
            LinkButton btnLinkDelete = null;
            if (e.Row.Cells[this.grdRole.Columns.Count - 1].Controls.Count > 0)
            {
                btnLinkDelete = (LinkButton)e.Row.Cells[this.grdRole.Columns.Count - 1].Controls[0];
            }
            if (btnLinkDelete != null)
            {
                string strScript = "return confirm('您确定要删除此数据行吗？');";
                btnLinkDelete.Attributes.Add("onclick", strScript);
            }
            // JiLeiLei, 2006.12.10, 添加按钮状态显示
            // 编辑时状态
            if (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Edit)
                || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                DataRowView dataRowView = (DataRowView)e.Row.DataItem;
                string id = dataRowView[BaseRoleEntity.FieldId].ToString();
                string paramEnabled = dataRowView[BaseRoleEntity.FieldEnabled].ToString();
                // 编辑是复选框不显示
                CheckBox checkBox = (CheckBox)e.Row.FindControl("chkSelected");
                checkBox.Visible = false;
                checkBox.Enabled = false;
                // 添加时有效默认值为真
                if (!string.IsNullOrEmpty(id))
                {
                    checkBox = (CheckBox)e.Row.Cells[7].FindControl("chkEnabled");
                    checkBox.Checked = true;
                }
                e.Row.Cells[4].Text = String.Empty;
                e.Row.Cells[5].Text = String.Empty;
                e.Row.Cells[6].Text = String.Empty;
                // 按钮
                LinkButton btnSetTop = (LinkButton)e.Row.FindControl("lkbSetTop");
                LinkButton btnSetUp = (LinkButton)e.Row.FindControl("lkbSetUp");
                LinkButton btnSetDown = (LinkButton)e.Row.FindControl("lkbSetDown");
                LinkButton btnSetBottom = (LinkButton)e.Row.FindControl("lkbSetBottom");
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
        }
    }

    #region private void SetSort(String function, int index) 设置排序顺序
    /// <summary>
    /// 设置排序顺序
    /// </summary>
    /// <param name="function">排序动作</param>
    /// <param name="index">索引</param>
    private void SetSort(String function, int index)
    {
        string id = this.grdRole.DataKeys[index].Value.ToString();
        string targetID = String.Empty;
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
                        BaseDbSortLogic.SetTop(this.UserCenterDbHelper, BaseRoleEntity.TableName, id, BaseItemDetailsEntity.TableName);
                        this.grdRole.SelectedIndex = 0;
                    }
                    break;
                case BaseDbSortLogic.CommandSetUp:
                    if (index > 0)
                    {
                        targetID = this.grdRole.DataKeys[index - 1].Value.ToString();
                        this.grdRole.SelectedIndex = index - 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, BaseRoleEntity.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetDown:
                    if ((index + 2) < this.grdRole.Rows.Count)
                    {
                        targetID = this.grdRole.DataKeys[index + 1].Value.ToString();
                        this.grdRole.SelectedIndex = index + 1;
                        BaseDbSortLogic.Swap(this.UserCenterDbHelper, BaseRoleEntity.TableName, id, targetID);
                    }
                    break;
                case BaseDbSortLogic.CommandSetBottom:
                    if ((index + 2) < this.grdRole.Rows.Count)
                    {
                        BaseDbSortLogic.SetBottom(this.UserCenterDbHelper, BaseRoleEntity.TableName, id, BaseItemDetailsEntity.TableName);
                        this.grdRole.SelectedIndex = this.grdRole.Rows.Count - 2;
                    }
                    break;
            }
            // 获取列表
            this.GetList();
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

    protected void grdRole_ItemCommand(object source, GridViewCommandEventArgs e)
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

    protected void grdRole_EditCommand(object source, GridViewEditEventArgs e)
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetList(e.NewEditIndex);
            this.grdRole.SelectedIndex = -1;
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

    protected void grdRole_CancelCommand(object source, GridViewCancelEditEventArgs e)
    {
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetList();
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

    #region private bool CheckInput(String realname, string description) 检查页面上的输入
    /// <summary>
    /// 检查页面上的输入
    /// </summary>
    /// <param name="realname">名称</param>
    /// <param name="description">备注</param>
    /// <returns>是否输入正确</returns>
    private bool CheckInput(String realname, string description)
    {
        int MaxCodeLength = 30;    // 允许输入的最大编号长度
        int MaxFullNameLength = 30;    // 允许输入的最大名称长度
        int MaxDescriptionLength = 100;   // 允许输入的最大名称长度
        string strCheckInput = String.Empty;
        // 检查名称
        if (realname.Length == 0)
        {
            strCheckInput = "<script>alert('提示信息：请输入名称。');</script>";
            Page.RegisterStartupScript("CheckInput", strCheckInput);
            return false;
        }
        // 检查名称长度
        if (realname.Length > MaxFullNameLength)
        {
            strCheckInput = "<script>alert('提示信息：名称长度已超过" + MaxFullNameLength + "个字符。'');</script>";
            Page.RegisterStartupScript("CheckInput", strCheckInput);
            return false;
        }
        // 检查备注长度
        if (description.Length > MaxDescriptionLength)
        {
            strCheckInput = "<script>alert('提示信息：备注长度已超过" + MaxFullNameLength + "个字符。'');</script>";
            Page.RegisterStartupScript("CheckInput", strCheckInput);
            return false;
        }
        return true;
    }
    #endregion

    #region private bool CheckDataBase(String id, string itemCode, string itemName, string itemValue)
    /// <summary>
    /// 数据库检查输入的有效性
    /// </summary>
    /// <param name="id">代码</param>
    /// <param name="itemCode">编号</param>
    /// <param name="itemName">名称</param>
    /// <param name="itemValue">值</param>
    /// <returns>是否输入正确</returns>
    private bool CheckDataBase(String id, string roleName)
    {
        BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
        string strCheckInput = String.Empty;
        if (!String.IsNullOrEmpty(roleName))
        {
            // 检查名称是否存在
            if (roleManager.Exists(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleName), id))
            {
                strCheckInput = "<script>alert('提示信息：名称已重复，请重新输入。');</script>";
                Page.RegisterStartupScript("CheckInput", strCheckInput);
                return false;
            }
        }
        return true;
    }
    #endregion

    #region private void DoAdd(String realname, string description, bool enabled) 添加
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="realname">名称</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoAdd(String realname, string description, bool enabled)
    {
        string returnValue = String.Empty;
        // 检查页面上的输入
        if (!this.CheckInput(realname, description))
        {
            return;
        }
        BaseRoleEntity roleEntity = new BaseRoleEntity();
        roleEntity.RealName = realname;
        roleEntity.Enabled = enabled ? 1:0;
        roleEntity.Description = description;
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(String.Empty, realname))
            {
                return;
            }
            else
            {
                // 添加实体
                BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
                returnValue = roleManager.AddEntity(roleEntity);
                // 获取列表
                this.GetList();
                this.grdRole.SelectedIndex = -1;
            }
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
        if (BaseSystemInfo.ShowInformation)
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

    #region  private void DoUpdate(String id, string realname, string description, bool enabled) 更新
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">代码</param>
    /// <param name="realname">名称</param>
    /// <param name="description">备注</param>
    /// <param name="enabled">有效</param>
    private void DoUpdate(String id, string realname, string description, bool enabled)
    {
        int returnValue = 0;
        // 检查页面上的输入
        if (!this.CheckInput(realname, description))
        {
            return;
        }
        try
        {
            this.UserCenterDbHelper.Open();
            // 数据库检查输入的有效性
            if (!this.CheckDataBase(id, realname))
            {
                return;
            }
            else
            {
                BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
                BaseRoleEntity roleEntity = roleManager.GetEntity(id);
                roleEntity.RealName = realname;
                roleEntity.Description = description;
                roleEntity.Enabled = enabled ? 1:0;
                // 更新数据
                returnValue = roleManager.UpdateEntity(roleEntity);
                // 获取列表
                this.GetList();
                this.grdRole.SelectedIndex = -1;
            }
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
        if (BaseSystemInfo.ShowInformation)
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

    protected void grdRole_UpdateCommand(object source, GridViewUpdateEventArgs e)
    {
        // 变量定义部分
        string realname = String.Empty;
        string description = String.Empty;
        bool enabled = true;

        // 读取变量部分
        string id = this.grdRole.DataKeys[e.RowIndex].Value.ToString();
        TextBox txtRealname = (TextBox)grdRole.Rows[e.RowIndex].FindControl("txtRealname");
        realname = txtRealname.Text.Trim();
        TextBox txtDescription = (TextBox)grdRole.Rows[e.RowIndex].FindControl("txtDescription");
        CheckBox chkEnabled = (CheckBox)grdRole.Rows[e.RowIndex].FindControl("chkEnabled");
        description = txtDescription.Text.Trim();
        enabled = chkEnabled.Checked;

        // 更新部分
        if (id.Length == 0)
        {
            // 添加
            this.DoAdd(realname, description, enabled);
        }
        else
        {
            // 更新
            this.DoUpdate(id, realname, description, enabled);
        }
    }

    #region private void Delete(String id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">代码</param>
    private void Delete(String id)
    {
        int returnValue = 0;
        try
        {
            this.UserCenterDbHelper.Open();
            // 删除数据
            BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = roleManager.Delete(id);
            // 获取列表
            this.GetList();
            this.grdRole.SelectedIndex = -1;
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
                // 提示删除成功
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                // 提示删除失败
                this.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdRole_DeleteCommand(object source, GridViewDeleteEventArgs e)
    {
        string id = this.grdRole.DataKeys[e.RowIndex].Value.ToString();
        // 删除数据
        this.Delete(id);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // 添加角色
        Page.Response.Redirect("RoleAdd.aspx");
    }

    #region private int BatchDelete() 批量删除
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <returns>影响的行数</returns>
    private int BatchDelete()
    {
        int returnValue = 0;
        string[] ids = Utilities.GetSelecteIds(this.grdRole);
        try
        {
            this.UserCenterDbHelper.Open();
            BaseRoleManager roleManager = new BaseRoleManager(this.UserCenterDbHelper, this.UserInfo);
            returnValue = roleManager.BatchDelete(ids);
            this.grdRole.EditIndex = -1;
            this.GetList();
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
        this.BatchDelete();
    }
}