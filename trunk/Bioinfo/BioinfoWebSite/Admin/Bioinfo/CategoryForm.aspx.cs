﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Log;
using NewLife.Web;
using Bioinfo.Entites;

public partial class Common_CategoryForm : MyEntityForm<Category>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            frmParentId.Items.Clear();
            frmParentId.Items.Add(new ListItem("|-根类别", "0"));
            frmParentId.Items.AddRange(EntityHelper.GetCategoryList(0).ToArray());
            frmParentId.SelectedValue = Entity.ParentId.ToString();
        }
    }
}