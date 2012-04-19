//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class OfficeBillShow : BasePage
{
    public string ObjectId
    {
        get
        {
            return this.txtObjectId.Value;
        }
        set
        {
            this.txtObjectId.Value = value;
        }
    }

    public string CurrentId
    {
        get
        {
            return this.txtCurrentId.Value;
        }
        set
        {
            this.txtCurrentId.Value = value;
        }
    }

    private bool allowPrint = true;
    /// <summary>
    /// 允许打印
    /// </summary>
    public bool AllowPrint
    {
        get
        {
            return this.allowPrint;
        }
        set
        {
            this.allowPrint = value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["ObjectId"] != null)
        {
            this.ObjectId = Page.Request["ObjectId"].ToString();
        }
        if (Page.Request["Id"] != null)
        {
            this.CurrentId = Page.Request["Id"].ToString();
        }
        if (Page.Request["CurrentId"] != null)
        {
            this.CurrentId = Page.Request["CurrentId"].ToString();
        }
    }
    #endregion

    /// <summary>
    /// 显示单据内h容
    /// </summary>
    public void ShowDetails(string objectId)
    {
        this.Session["FileURL"] = string.Empty;
        this.ObjectId = objectId;

        BaseWorkFlowCurrentEntity workFlowCurrentEntity = null;
        BaseWorkFlowCurrentManager workFlowCurrentManager = null;
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            // 从模板表里有效状态区分,是否模板还是报表
            this.ObjectId = workFlowCurrentEntity.ObjectId;
        }
        if (!string.IsNullOrEmpty(this.ObjectId))
        {
            UserBillManager userBillManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity newsEntity = userBillManager.GetEntity(this.ObjectId);
            if (newsEntity != null)
            {
                string rootPath = HttpContext.Current.Server.MapPath("~/") + Utilities.UploadFiles + "\\";
                string file = rootPath + "User_" + newsEntity.CreateUserId + "\\" + newsEntity.Id + "\\" + newsEntity.Id + ".xls";
                if (!File.Exists(file))
                {
                    this.Session["FileURL"] = string.Empty;
                }
                else
                {
                    #if (DEBUG)
                        this.Session["FileURL"] = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/DotNet.WebForm/UploadFiles/User_" + newsEntity.CreateUserId + "/" + newsEntity.Id + "/" + newsEntity.Id + ".xls";
                    #else
                        this.Session["FileURL"] = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/UploadFiles/User_" + newsEntity.CreateUserId + "/" + newsEntity.Id + "/" + newsEntity.Id + ".xls";
                    #endif
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        if (!Page.IsPostBack)
        {
            // this.GetParamters();
            // this.ShowDetails();            
        }
    }
}