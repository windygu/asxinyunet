//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class LeftMenu : BasePage
{
    // 1。需要读取参数，知道现在需要调用的是哪个模块
    // 2。当前模块的ID主键是什么？
    // 3。从当前用户的允许访问的模块里获取ParenID为模块ID的数据进行加载菜单
    // 4。需要修改文件名，修改为LeftMenu就可以了。
    // 5。将其他多余的菜单全部删除掉，文件数量少了，程序编译的速度也会快，需要维护的内容也会少一些。
    // 6。子菜单也需要进行一次整理，把多余的都删除掉，这样菜单用工具修改于前台就可以彻底同步了。

    private string ModuleCode = string.Empty;

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["ModuleCode"] != null)
        {
            this.ModuleCode = Page.Request["ModuleCode"].ToString();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.GetParamter();
        this.LoadMenu();
    }

    private void LoadMenu()
    {
        if (String.IsNullOrEmpty(this.ModuleCode))
        {
            return;
        }
        string parentId = BaseBusinessLogic.GetProperty(this.DTModule, BaseModuleEntity.FieldCode, this.ModuleCode, BaseModuleEntity.FieldId);
        this.LoadMenu(parentId);
    }

    private void LoadMenu(string parentId)
    {
        if (String.IsNullOrEmpty(parentId))
        {
            return;
        }
        // 删除的，不能出来了才可以
        DataRow[] dataRows = this.DTModule.Select(BaseModuleEntity.FieldParentId + "='" + parentId + "'", BaseModuleEntity.FieldSortCode);
        ydBar menu = new ydBar(this.tblMenu);
        MenuItem Item = null;
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        /*
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleEntity.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleEntity.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleEntity.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleEntity.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleEntity.FieldFullName].ToString();
            menu.Add(Item);
        }*/
        menu.Load();
    }
}