//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

public partial class Report : BaseUserControl
{
    private string categoryCode = String.Empty;
    public string CategoryCode
    {
        get
        {
            return this.categoryCode;
        }
        set
        {
            this.categoryCode = value;
        }
    }

    private string objectId = String.Empty;
    public string ObjectId
    {
        get
        {
            return this.objectId;
        }
        set
        {
            this.objectId = value;
        }
    }

    private string currentId = String.Empty;
    public string CurrentId
    {
        get
        {
            return this.currentId;
        }
        set
        {
            this.currentId = value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (String.IsNullOrEmpty(this.CategoryCode))
        {
            if (Page.Request["CategoryCode"] != null)
            {
                this.CategoryCode = Page.Request["CategoryCode"].ToString();
            }
        }
        if (String.IsNullOrEmpty(this.ObjectId))
        {
            if (Page.Request["ObjectId"] != null)
            {
                this.ObjectId = Page.Request["ObjectId"].ToString();
            }
        }
        if (String.IsNullOrEmpty(this.CurrentId))
        {
            if (Page.Request["Id"] != null)
            {
                this.CurrentId = Page.Request["Id"].ToString();
            }
        }
    }
    #endregion

    public void ShowDetails()
    {

    }
}