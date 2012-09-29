﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Log;
using NewLife.Web;
using Bioinfo.Entites;

public partial class Common_WebSettingForm : MyEntityForm<Setting>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBind();
            frmCategoryId.Items.Clear();
            frmCategoryId.Items.Add(new ListItem("|-选择设置类别", "0"));
            frmCategoryId.Items.AddRange(EntityHelper.GetCategoryList(2).ToArray());
            frmCategoryId.SelectedValue = Entity.CategoryId.ToString();     
        }
    }
}