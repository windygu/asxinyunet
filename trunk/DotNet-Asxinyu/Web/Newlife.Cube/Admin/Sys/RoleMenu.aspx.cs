﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using NewLife.Reflection;
using NewLife.Web;
using XCode;

public partial class Pages_RoleMenu : MyEntityList
{
    /// <summary>实体类型</summary>
    public override Type EntityType { get { return CommonManageProvider.Provider.RoleMenuType; } set { base.EntityType = value; } }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        ObjectDataSource1.DataObjectTypeName = ObjectDataSource1.TypeName = CommonManageProvider.Provider.MenuType.FullName;
        ObjectDataSource2.DataObjectTypeName = ObjectDataSource2.TypeName = CommonManageProvider.Provider.RoleType.FullName;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    DropDownList1.DataBind();
        //}
    }

    public Int32 RoleID
    {
        get
        {
            return String.IsNullOrEmpty(DropDownList1.SelectedValue) ? 0 : Convert.ToInt32(DropDownList1.SelectedValue);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row == null) return;

        IMenu entity = e.Row.DataItem as IMenu;
        if (entity == null) return;

        CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
        CheckBoxList cblist = e.Row.FindControl("CheckBoxList1") as CheckBoxList;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, entity.ID);
        cb.Checked = (rm != null);
        if (rm != null) cb.ToolTip = rm.PermissionFlag.ToString();
        //if (rm != null) cb.Text = rm.PermissionFlag.ToString();

        // 如果有子节点，则不显示
        if (entity.Childs != null && entity.Childs.Count > 0)
        {
            //cb.Visible = false;
            cblist.Visible = false;
            return;
        }

        // 检查权限
        Dictionary<PermissionFlags, String> flags = GetDescriptions();
        cblist.Items.Clear();
        foreach (PermissionFlags item in flags.Keys)
        {
            if (item == PermissionFlags.None) continue;

            ListItem li = new ListItem(flags[item], ((Int32)item).ToString());
            if (rm != null && (rm.PermissionFlag & item) == item) li.Selected = true;
            cblist.Items.Add(li);
        }
    }
    string formtitle = string.Empty;
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (RoleID < 1) return;

        CheckBox cb = sender as CheckBox;
        if (cb == null) return;

        GridViewRow row = cb.BindingContainer as GridViewRow;
        if (row == null) return;

        IMenu entity = CommonManageProvider.Provider.MenuRoot.AllChilds[row.DataItemIndex] as IMenu;
        if (entity == null) return;
        formtitle = entity.Name;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, entity.ID);
        if (cb.Checked)
        {
            // 没有权限，增加
            if (rm == null)
            {
                if (!Manager.Acquire(PermissionFlags.Insert))
                {
                    WebHelper.Alert("没有添加权限！");
                    return;
                }

                rm = TypeX.CreateInstance(EntityType) as IRoleMenu;
                rm.RoleID = RoleID;
                rm.MenuID = entity.ID;
                rm.PermissionFlag = PermissionFlags.All;
                (rm as IEntity).Save();
            }
        }
        else
        {
            // 如果有权限，删除
            if (rm != null)
            {
                if (!Manager.Acquire(PermissionFlags.Delete))
                {
                    WebHelper.Alert("没有删除权限！");
                    return;
                }

                (rm as IEntity).Delete();
            }
        }

        GridView1.DataBind();
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RoleID < 1) return;

        CheckBoxList cb = sender as CheckBoxList;

        //只需判断cb是否为空，该角色只有“查看”权限时cb.SelectedItem为空。
        //if (cb == null || cb.SelectedItem == null) return;
        if (cb == null) return;

        GridViewRow row = cb.BindingContainer as GridViewRow;
        if (row == null) return;

        IMenu entity = CommonManageProvider.Provider.MenuRoot.AllChilds[row.DataItemIndex] as IMenu;
        if (entity == null) return;
        formtitle = entity.Name;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, entity.ID);
        // 没有权限，增加
        if (rm == null)
        {
            if (!Manager.Acquire(PermissionFlags.Insert))
            {
                WebHelper.Alert("没有添加权限！");
                return;
            }

            rm = TypeX.CreateInstance(EntityType) as IRoleMenu;
            rm.RoleID = RoleID;
            rm.MenuID = entity.ID;
        }

        // 遍历权限项
        PermissionFlags flag = PermissionFlags.None;
        foreach (ListItem item in cb.Items)
        {
            if (item.Selected) flag |= (PermissionFlags)(Int32.Parse(item.Value));
        }

        if (rm.PermissionFlag != flag)
        {
            if (!Manager.Acquire(PermissionFlags.Update))
            {
                WebHelper.Alert("没有编辑权限！");
                return;
            }

            rm.PermissionFlag = flag;
            (rm as IEntity).Save();
        }

        GridView1.DataBind();
    }

    IRoleMenu FindByRoleAndMenu(Int32 roleID, Int32 menuID)
    {
        MethodInfoX mix = MethodInfoX.Create(EntityType, "FindByRoleAndMenu");
        if (mix == null) return null;
        return mix.Invoke(null, roleID, menuID) as IRoleMenu;
    }

    static Dictionary<PermissionFlags, String> flagCache;
    static Dictionary<PermissionFlags, String> GetDescriptions()
    {
        if (flagCache != null) return flagCache;

        flagCache = new Dictionary<PermissionFlags, string>();

        TypeX type = typeof(PermissionFlags);
        foreach (FieldInfo item in type.BaseType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (!item.IsStatic) continue;

            // 这里的快速访问方法会报错
            //FieldInfoX fix = FieldInfoX.Create(item);
            //PermissionFlags value = (PermissionFlags)fix.GetValue(null);
            PermissionFlags value = (PermissionFlags)item.GetValue(null);

            String des = item.Name;
            DescriptionAttribute att = AttributeX.GetCustomAttribute<DescriptionAttribute>(item, false);
            if (att != null && !String.IsNullOrEmpty(att.Description)) des = att.Description;
            flagCache.Add(value, des);
        }

        return flagCache;
    }

    ////重写权限验证方法，对网站配置文件加强控制
    //public override bool Acquire(PermissionFlags flag)
    //{
    //    if (!string.IsNullOrEmpty(formtitle) && (formtitle == "网站配置" || formtitle == "网站数据库" || formtitle == "网站日志"))
    //    {
    //        if ((CommonManageProvider.Provider.Current.Role.Menus.Find(RoleMenu._.MenuID, MyMenu.ID).PermissionFlag & PermissionFlags.Custom1) == 0) return false;
    //    }
    //    return base.Acquire(flag);
    //}
}