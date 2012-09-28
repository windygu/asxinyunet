﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Log;
using NewLife.Web;
using Bioinfo.Entites;
using XCode.DataAccessLayer ;
using XCode;
using NewLife.CommonEntity.Web ;
using NewLife.CommonEntity;

public partial class Common_NewsForm : MyEntityForm<News>
{

    /// <summary>编号</summary>
    public Int32 EntityID { get { return WebHelper.RequestInt("ID"); } }

    private Bioinfo.Entites.Category _Entity;
    /// <summary>客户</summary>
    public Bioinfo.Entites.Category Entity
    {
        get { return _Entity ?? (_Entity = Bioinfo.Entites.Category.FindByKeyForEdit(EntityID)); }
        set { _Entity = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCategoryIdData();
            frmAddDateTime.Value = DateTime.Now;
        }
    }
    /// <summary>
    /// 加载新闻类别信息
    /// </summary>
    private void LoadCategoryIdData()
    {
        DataBind();
        frmCategoryId.Items.Clear();
        frmCategoryId.Items.Add(new ListItem("|-选择新闻类型", "0"));
        List<Bioinfo.Entites.Category> list = Bioinfo.Entites.Category.FindAllByParent(1);
        if (list != null && list.Count > 0)
        {
            foreach (Bioinfo.Entites.Category item in list)
            {
                String spaces = new String('　', item.Deepth);
                frmCategoryId.Items.Add(new ListItem(spaces + "|- " + item.Name, item.Id.ToString()));
            }
        }
        if (Entity != null) frmCategoryId.SelectedValue = Entity.Id.ToString();
    }
    /// <summary>
    /// 加载作者名称信息
    /// </summary>
    //private void LoadAdminNameData()
    //{
    //    frmAuthor.Items.Clear();
    //    List<Administrator> list = Administrator.FindAll();
    //    if (list != null && list.Count > 0)
    //    {
    //        foreach (var item in list)
    //        {
    //            String spaces = " ";
    //            frmCategoryId.Items.Add(new ListItem(spaces + "|- " + item.Name, item.ID.ToString()));
    //        }
    //    }
    //}

    //protected override void OnInitComplete(EventArgs e)
    //{
    //    base.OnInitComplete(e);
    //    //ods.DataObjectTypeName = "Bioinfo.Entites.Category";     
        
    //}

}