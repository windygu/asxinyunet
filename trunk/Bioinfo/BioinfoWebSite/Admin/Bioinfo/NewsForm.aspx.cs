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
using NewLife.YWS.Entities;

public partial class Common_NewsForm : MyEntityForm<News>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCategoryIdData();
            LoadAdminNameData();
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
        frmCategoryId.Items.AddRange(EntityHelper.GetCategoryList(1).ToArray());
        frmCategoryId.SelectedValue = Entity.CategoryId.ToString();     
        //List<Bioinfo.Entites.Category> list = Bioinfo.Entites.Category.FindAllChildsNoParent (1);
        //if (list != null && list.Count > 0)
        //{
        //    foreach (Bioinfo.Entites.Category item in list)
        //    {                
        //        String spaces = new String('　', item.Deepth);
        //        frmCategoryId.Items.Add(new ListItem(spaces + "|- " + item.Name, item.Id.ToString()));
                             
        //    }
        //}
          
    }
    /// <summary>
    /// 加载作者名称信息
    /// </summary>
    private void LoadAdminNameData()
    {
        frmAuthor.Items.Clear();
        List<Admin> list = Admin.FindAll();
        if (list != null && list.Count > 0)
        {
            foreach (var item in list)
            {
                String spaces = " ";
                frmAuthor.Items.Add(new ListItem(spaces + item.Name, item.Name.ToString()));
            }
        }
        frmAuthor.SelectedValue = Entity.Author;          
    }
}