//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

using DotNet.Utilities;
using DotNet.Business;

public partial class BillAttachment : BasePage
{
    /// <summary>
    /// 当前文件主键
    /// </summary>
    private string UserBillId
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
    }
    #endregion

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["Id"] != null)
        {
            this.UserBillId = Page.Request["Id"].ToString();
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.txtReturnURL.Value = Page.Request["ReturnURL"].ToString();
        }
    }
    #endregion

    #region private BaseNewsEntity ShowEntry() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private BaseNewsEntity ShowEntry()
    {
        BaseNewsEntity newsEntity = null;
        if (!string.IsNullOrEmpty(this.UserBillId))
        {
            UserBillManager manager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            newsEntity = manager.GetEntity(this.UserBillId);
            this.AttachmentHtmlBill.GetAttachmentList("Attachment", newsEntity.Id);
            // 只有草稿状态、退回状态的，才可以修改。
            this.btnSave.Enabled = string.IsNullOrEmpty(newsEntity.AuditStatus)
                || newsEntity.AuditStatus.Equals(AuditStatus.Draft.ToString())
                || newsEntity.AuditStatus.Equals(AuditStatus.AuditReject.ToString());
            
            if (!string.IsNullOrEmpty(this.ReturnURL))
            {
                this.btnSave.Enabled = true;
            }
        }
        return newsEntity;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
        // 读取参数
        this.GetParamters();
        BaseNewsEntity newsEntity = null;
        try
        {
            this.UserCenterDbHelper.Open();
            if (!string.IsNullOrEmpty(this.UserBillId))
            {
                this.ShowEntry();
            }
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

    #region private stirng DoSave(bool clearForm)保存新闻信息
    /// <summary>
    /// 保存新闻
    /// </summary>
    /// <param name="clearForm">清除屏幕</param>
    /// <returns>新闻代码</returns>
    private void DoSave(bool clearForm, bool send = false)
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
            UserBillManager newsManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            if (!string.IsNullOrEmpty(this.UserBillId))
            {
                newsEntity = newsManager.GetEntity(this.UserBillId);
            }
            if (String.IsNullOrEmpty(newsEntity.Id))
            {
                newsEntity.Id = BaseBusinessLogic.NewGuid();
                newsEntity.AuditStatus = AuditStatus.Draft.ToString();
                newsManager.AddEntity(newsEntity);
                this.UserBillId = newsEntity.Id;
            }
            else
            {
                returnValue = newsManager.Update(newsEntity, out statusCode);
            }
            statusMessage = newsManager.GetStateMessage(statusCode);

            // 上传附件，保存附件
            if (this.Attachment01.PostedFile.ContentLength > 0)
            {
                this.SaveFile(this.Attachment01.PostedFile, "Attachment", newsEntity.Id);
            }
            if (this.Attachment02.PostedFile.ContentLength > 0)
            {
                this.SaveFile(this.Attachment02.PostedFile, "Attachment", newsEntity.Id);
            }
            if (this.Attachment03.PostedFile.ContentLength > 0)
            {
                this.SaveFile(this.Attachment03.PostedFile, "Attachment", newsEntity.Id);
            }
            if (this.Attachment04.PostedFile.ContentLength > 0)
            {
                this.SaveFile(this.Attachment04.PostedFile, "Attachment", newsEntity.Id);
            }
            if (this.Attachment05.PostedFile.ContentLength > 0)
            {
                this.SaveFile(this.Attachment05.PostedFile, "Attachment", newsEntity.Id);
            }

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
                //        + "&MbuttonUrl=../../Common/NewsAdmin/NewsAdmin.aspx";
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

            if (send)
            {
                if (!string.IsNullOrEmpty(this.UserBillId))
                {
                    /*
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
                    string workFlowCode = this.UserInfo.Id + "_" + this.CategoryCode;
                    BaseWorkFlowActivityEntity workFlowActivityEntity = workFlowCurrentManager.GetFirstActivityEntity(workFlowCode);
                    if (workFlowActivityEntity != null)
                    {
                        if (workFlowActivityEntity.AuditUserId.Equals("Anyone"))
                        {
                            // 重新定位到选人发送的界面
                            Page.Response.Redirect("ShowUserBill.aspx?ObjectId=" + this.UserBillId);
                            return;
                        }
                    }
                    // 提交表单,这里需要知道第一步是否自由选择
                    newsManager.AutoStatr(this.UserBillId, string.Empty);
                    */

                    // 重新定位到选人发送的界面
                    Page.Response.Redirect("SubmitBill.aspx?ObjectId=" + this.UserBillId);
                }
            }

            if (string.IsNullOrEmpty(this.ReturnURL))
            {
                Utilities.CloseWindow(true);
            }
            else
            {
                Page.Response.Redirect(this.ReturnURL);
            }
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

    private string SaveFile(System.Web.HttpPostedFile httpPostedFile, string categoryId, string objectId)
    {
        string rootPath = HttpContext.Current.Server.MapPath("~/") + Utilities.UploadFiles + "\\";
        string loadDirectory = categoryId + "\\" + objectId;
        // 需要创建的目录，图片放在这里，为了保存历史纪录，使用了当前日期做为目录
        string makeDirectory = rootPath + loadDirectory;
        Directory.CreateDirectory(makeDirectory);
        // 获得文件名
        string fileName = Server.HtmlEncode(Path.GetFileName(httpPostedFile.FileName));
        // 图片重新指定，虚拟的路径
        // 这里还需要更新学生的最新照片
        string fileUrl = "/" + ImagesURL.Trim('/') + "/" + categoryId + "/" + objectId + "/" + fileName;
        // 文件复制到相应的路径下
        string copyToFile = makeDirectory + "\\" + fileName;
        httpPostedFile.SaveAs(copyToFile);
        return fileUrl;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // 保存单据
        this.DoSave(true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}