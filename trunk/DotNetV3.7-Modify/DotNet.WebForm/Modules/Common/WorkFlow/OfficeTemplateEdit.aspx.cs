﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Utilities;
using DotNet.Business;

public partial class OfficeTemplateEdit : BasePage
{
    /// <summary>
    /// 是否需要审核流程
    /// </summary>
    private bool NeedAudit = true;

    /// <summary>
    /// 当前文件代码
    /// </summary>
    public string TemplateId
    {
        set
        {
            this.txtId.Value = value;
        }
        get
        {
            return this.txtId.Value;
        }
    }

    /// <summary>
    /// 当前模板分类
    /// </summary>
    private string CategoryCode
    {
        set
        {
            this.txtCode.Text = value;
        }
        get
        {
            return this.txtCode.Text;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["Id"] != null)
        {
            this.TemplateId = Page.Request["Id"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
        if (Page.Request["CategoryCode"] != null)
        {
            this.CategoryCode = Page.Request["CategoryCode"].ToString();
        }
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
        if (String.IsNullOrEmpty(this.ReturnURL))
        {
            this.btnReturn.Visible = false;
        }
        if (!String.IsNullOrEmpty(this.CategoryCode))
        {
            this.txtCode.Text = this.CategoryCode;
        }
    }
    #endregion

    #region private void ShowEntry() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntry()
    {
        if (!string.IsNullOrEmpty(this.TemplateId))
        {
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseNewsEntity newsEntity = templateManager.GetEntity(this.TemplateId);
            this.CategoryCode = newsEntity.CategoryCode;
            this.txtTitle.Text = newsEntity.Title;
            this.txtCode.Text = newsEntity.Code;
            this.txtIntroduction.Text = newsEntity.Introduction;
            Utilities.SetDropDownListValue(this.cmbCategory, newsEntity.CategoryCode);

            string rootPath = HttpContext.Current.Server.MapPath("~/") + Utilities.UploadFiles + "\\";
            string file = rootPath + "OfficeTemplate\\" + newsEntity.Id + "\\" + newsEntity.Id + ".xls";
            if (!File.Exists(file))
            {
                this.Session["FileURL"] = string.Empty;
            }
            else
            {
                #if (DEBUG)
                    this.Session["FileURL"] = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/DotNet.WebForm/UploadFiles/OfficeTemplate/" + newsEntity.Id + "/" + newsEntity.Id + ".xls";
                #else
                    this.Session["FileURL"] = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/UploadFiles/OfficeTemplate/" + newsEntity.Id + "/" + newsEntity.Id + ".xls";
                #endif
            }
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetItemDetails()
    {
        BaseItemDetailsManager manager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsWorkFlowCategories");
        DataTable dataTable = manager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0), BaseItemDetailsEntity.FieldSortCode + " DESC");
        this.cmbCategory.DataSource = dataTable;
        this.cmbCategory.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbCategory.DataValueField = BaseItemDetailsEntity.FieldItemValue;
        this.cmbCategory.DataBind();
        this.cmbCategory.Items.Insert(0, new ListItem());
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Session["FileURL"] = string.Empty;
            // 读取参数
            this.GetParamters();

            string url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + Request.ServerVariables["PATH_INFO"].ToString();  //获得URL的值
            int i = url.LastIndexOf("/");
            url = url.Substring(0, i);
            this.Session["PostURL"] = url; //定义Sesssion变量

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
        this.GetParamters();
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetItemDetails();
            // 显示实体
            this.ShowEntry();
            // 按钮状态
            this.SetControlState();
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

    #region private bool CheckInput()
    /// <summary>
    /// 检查输入的有效性
    /// </summary>
    /// <returns>有效</returns>
    private bool CheckInput()
    {
        bool returnValue = true;
        string checkInput = string.Empty;
        // 检查标题是否为空
        if (this.txtTitle.Text.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入标题。'); document.all['txtTitle'].focus();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
            return false;
        }
        // 检查分类是否为空
        if (this.txtCode.Text.Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入分类。'); document.all['txtCategoryCode'].focus();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", checkInput);
            return false;
        }
        return returnValue;
    }
    #endregion

    #region public string ReturnURL 目的跳转页面
    public string ReturnURL
    {
        get
        {
            return this.txtReturnURL.Value;
        }
        set
        {
            this.txtReturnURL.Value = value;
        }
    }
    #endregion

    private BaseNewsEntity GetEntity(BaseNewsEntity newsEntity)
    {
        newsEntity.Id = this.TemplateId;
        // 是按用户进行工作流审核
        newsEntity.FolderId = "ByUser";
        newsEntity.Title = this.txtTitle.Text;
        // 算是按目录分类，主要是为了以后的维护方便，用户什么都可以自定义的，而不是由管理员维护的。
        newsEntity.Code = this.txtCode.Text;
        newsEntity.CategoryCode = this.cmbCategory.SelectedValue;
        newsEntity.Introduction = this.txtIntroduction.Text;
        // fileEntity.Contents = this.txtContent.Text;
        newsEntity.DeletionStateCode = 0;
        // 若是需要审核的，那就需要走审核流程，不能直接生效
        newsEntity.Enabled = this.NeedAudit ? 0 : 1;
        return newsEntity;
    }

    #region private void DoSave(bool clearForm)保存新闻信息
    /// <summary>
    /// 保存新闻
    /// </summary>
    /// <param name="clearForm">清除屏幕</param>
    /// <returns>新闻代码</returns>
    private void DoSave(bool clearForm)
    {
        string statusCode = string.Empty;
        string statusMessage = string.Empty;
        int returnValue = 0;
        // 检查页面的输入
        if (!this.CheckInput())
        {
            return;
        }
        try
        {
            this.DbHelper.Open();
            BaseNewsEntity newsEntity = new BaseNewsEntity();
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            if (!string.IsNullOrEmpty(this.TemplateId))
            {
                newsEntity = templateManager.GetEntity(this.TemplateId);
            }
            this.GetEntity(newsEntity);
            if (String.IsNullOrEmpty(newsEntity.Id))
            {
                newsEntity.Id = BaseBusinessLogic.NewGuid();
                templateManager.Add(newsEntity, out statusCode);
                this.TemplateId = newsEntity.Id;
                SQLBuilder sqlBuilder = new SQLBuilder(this.WorkFlowDbHelper);
                sqlBuilder.BeginUpdate(templateManager.CurrentTableName);
                sqlBuilder.SetValue("AddPage", "../OfficeBill/OfficeBillEdit.aspx?TemplateId={Id}");
                sqlBuilder.SetValue("EditPage", "../OfficeBill/OfficeBillEdit.aspx?Id={Id}");
                sqlBuilder.SetValue("ShowPage", "../OfficeBill/OfficeBillShow.aspx?Id={Id}");
                sqlBuilder.SetWhere("Id", this.TemplateId);
                sqlBuilder.EndUpdate();
            }
            else
            {
                returnValue = templateManager.Update(newsEntity, out statusCode);
            }
            statusMessage = templateManager.GetStateMessage(statusCode);

            // 上传附件，保存附件
            // Utilities.UpLoadFiles("BillTemplate", this.TemplateId, string.Empty);

            // 显示提示信息
            if (Utilities.ShowInformation)
            {
                //if (returnValue > 0)
                //{
                //    // 跳转设置信息
                //    string url = "../../Common/System/Messages.aspx"
                //        + "?MessageType=MessageOk"
                //        + "&Mtitle=保存成功"
                //        + "&Mbody=保存成功。"
                //        + "&MbuttonUrl=../../Common/FileAdmin/FileAdmin.aspx";
                //    Page.Response.Redirect(url);
                //}
                //else
                //{
                //    // 提示添加失败
                //    string url = "../../Common/System/Messages.aspx"
                //        + "?MessageType=MessageError"
                //        + "&Mtitle=保存失败"
                //        + "&Mbody=保存失败。"
                //    + "&MbuttonUrl=return";
                //    Page.Response.Redirect(url);
                //}
            }
            // Page.Response.Redirect("EditFile.aspx");
            Utilities.CloseWindow(true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.DbHelper.Close();
        }
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // 保存模板
        this.DoSave(true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}