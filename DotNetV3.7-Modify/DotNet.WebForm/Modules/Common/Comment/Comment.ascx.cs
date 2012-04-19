//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;
using DotNet.Business;
using DotNet.Utilities;

public partial class Comment : BaseUserControl
{
    private string categoryCode = String.Empty;
    public string CategoryCode
    {
        get
        {
            return this.txtCategoryCode.Value;
        }
        set
        {
            this.txtCategoryCode.Value = value;
        }
    }

    private string objectId = String.Empty;
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
            if (Page.Request["Id"] != null)
            {
                this.ObjectId = Page.Request["Id"].ToString();
            }
        }
    }
    #endregion

    // 可以写委托，发布评论后调用
    public event BaseBusinessLogic.OnCommnetEventHandler OnCommnet;

    protected void Page_Load(object sender, EventArgs e)
    {
        // <!-- OnClientClick="return confirm('你确认发表评论吗？');" -->
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        this.GetParamters();
        if ((!String.IsNullOrEmpty(this.CategoryCode)) && (!String.IsNullOrEmpty(this.ObjectId)) && (!String.IsNullOrEmpty(this.txtCommnet.Text)))
        {
            bool checkOnCommnet = true;
            try
            {
                this.DbHelper.Open();
                if (this.OnCommnet != null)
                {
                    checkOnCommnet = this.OnCommnet(this.CategoryCode, this.ObjectId);
                }
                // 若检查不通过，可以不发评论
                if (checkOnCommnet)
                {
                    BaseCommentManager commentManager = new BaseCommentManager(this.UserCenterDbHelper, this.UserInfo);
                    string commnets = this.txtCommnet.Text;
                    commentManager.Add(this.CategoryCode, this.ObjectId, commnets, this.UserInfo.IPAddress);
                    this.txtCommnet.Text = String.Empty;
                    Page.Response.Redirect(this.Request.Url.ToString());
                }
            }
            catch (Exception exception)
            {
                this.LogException(exception);
                throw exception;
            }
            finally
            {
                this.DbHelper.Close();
            }
        }
    }
}