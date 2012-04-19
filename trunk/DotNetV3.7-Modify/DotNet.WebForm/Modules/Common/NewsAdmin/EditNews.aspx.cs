using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

using DotNet.Business;
using DotNet.Utilities;

public partial class EditNews : BasePage
{
    /// <summary>
    /// 是否需要审核流程
    /// </summary>
    private bool NeedAudit = true;

    protected bool AllowUpload = true;
    /// <summary>
    /// 当前文件代码
    /// </summary>
    private string NewsId
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
    /// 当前文件代码
    /// </summary>
    private string FolderId
    {
        set
        {
            this.txtFolderId.Value = value;
        }
        get
        {
            return this.txtFolderId.Value;
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
            this.NewsId = Page.Request["Id"].ToString();
        }
        if (Page.Request["FolderId"] != null)
        {
            this.FolderId = Page.Request["FolderId"].ToString();
            // this.cmbBulletinCategory.SelectedValue = Page.Request["CategoryId"].ToString();
            // this.cmbNewsCategory.Visible = false;
        }
    }
    #endregion

    #region private void SetButtomState() 设置按钮状态
    /// <summary>
    /// 设置按钮状态
    /// </summary>
    private void SetButtomState()
    {
        if (String.IsNullOrEmpty(this.ReturnURL))
        {
            this.btnReturn.Visible = false;
        }
        if (!String.IsNullOrEmpty(this.FolderId))
        {
            Utilities.SetDropDownListValue(this.cmbNewsFolder, this.FolderId);
            this.cmbNewsFolder.Enabled = false;
        }
    }
    #endregion

    #region private void GetItemDetails() 绑定下拉框数据
    /// <summary>
    /// 绑定下拉框数据
    /// </summary>
    private void GetItemDetails()
    {
        // 数据绑定下拉框
        DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
        BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsNewsCategory");
        //if (this.UserInfo.IsAdministrator)
        //{
        dataTable = itemDetailsManager.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldEnabled, 1), BaseItemDetailsEntity.FieldSortCode);
        //}
        //else
        //{
        //    dataTable = itemDetailsManager.GetDataTableByPermission(this.UserInfo.Id, "NewsCategory", "News.Add");
        //}
        // 用过滤器进行过滤，只显示有效的数据。
        // BaseBusinessLogic.SetFilter(dataTable, BaseItemDetailsEntity.FieldEnabled, "1");
        this.cmbNewsFolder.DataSource = dataTable;
        this.cmbNewsFolder.DataValueField = BaseItemDetailsEntity.FieldId;
        this.cmbNewsFolder.DataTextField = BaseItemDetailsEntity.FieldItemName;
        this.cmbNewsFolder.DataBind();
        // this.cmbNewsCategory.Items.Insert(0, new ListItem());

        // 若都没数据获得，就应该跳转到没权限的页面了
        //if (this.cmbNewsCategory.Items.Count == 0)
        //{
        //    Page.Response.Redirect(AccessDenyPage);
        //}
    }
    #endregion

    #region private void ShowEntry() 显示实体
    /// <summary>
    /// 显示实体
    /// </summary>
    private void ShowEntry()
    {
        if (!string.IsNullOrEmpty(this.NewsId))
        {
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            DataTable dtFile = newsManager.GetDataTable(new KeyValuePair<string, object>(BaseFileEntity.FieldId, this.NewsId));
            BaseNewsEntity newEntity = newsManager.GetEntity(this.NewsId);
            this.txtTitle.Text = newEntity.Title;
            Utilities.SetDropDownListValue(this.cmbNewsFolder, newEntity.FolderId);
            this.txtIntroduction.Text = newEntity.Introduction;
            if (!string.IsNullOrEmpty(newEntity.Contents))
            {
                this.txtContent.Text = newEntity.Contents;
            }
            this.chkHomPage.Checked = (newEntity.HomePage == 1);
            this.chkSubPage.Checked = (newEntity.SubPage == 1);
            this.ShowAttachment(newEntity);
        }
    }
    #endregion

    #region private void ShowAttachment(BaseNewsEntity newsEntity) 显示附件内容
    //// <summary>
    /// 显示附件内容
    /// </summary>
    /// <param name="contactEntity"></param>
    private void ShowAttachment(BaseNewsEntity newsEntity)
    {
        this.Attachment.GetAttachmentList("News", newsEntity.Id);
        this.Attachment.AllowDelete = this.UserInfo.Id.Equals(newsEntity.CreateUserId);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 读取参数
            this.GetParamters();
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
        this.GetParamter();
        try
        {
            this.UserCenterDbHelper.Open();
            // 判断新闻发布权限
            // this.Authorized("News.Add");
            // 绑定下拉框数据
            this.GetItemDetails();
            // 显示实体
            this.ShowEntry();
            // 按钮状态
            this.SetButtomState();
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
        if (this.cmbNewsFolder.SelectedItem.Value.Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入分类。'); document.all['cmbNewsCategory'].focus();</script>";
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

    #region  private void GetParamter() 获取页面间所传入的参数值
    private new void GetParamter()
    {
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"];
        }
    }
    #endregion

    private BaseNewsEntity GetNews(BaseNewsEntity newsEntity)
    {
        newsEntity.Id = this.NewsId;
        newsEntity.Title = this.txtTitle.Text;
        // 算是按目录分类，主要是为了以后的维护方便，用户什么都可以自定义的，而不是由管理员维护的。
        newsEntity.FolderId = this.cmbNewsFolder.SelectedItem.Value;
        if (!string.IsNullOrEmpty(this.cmbNewsFolder.SelectedItem.Value))
        {
            int id = int.Parse(this.cmbNewsFolder.SelectedItem.Value);
            BaseItemDetailsManager itemDetailsManager = new BaseItemDetailsManager(this.UserCenterDbHelper, this.UserInfo, "ItemsNewsCategory");
            BaseItemDetailsEntity itemDetailsEntity = itemDetailsManager.GetEntity(id);
            newsEntity.CategoryCode = itemDetailsEntity.ItemCode;
        }
        newsEntity.Introduction = this.txtIntroduction.Text;
        newsEntity.Contents = this.txtContent.Text;
        newsEntity.HomePage = this.chkHomPage.Checked ? 1 : 0;
        newsEntity.SubPage = this.chkSubPage.Checked ? 1 : 0;
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
            BaseNewsManager newsManager = new BaseNewsManager(this.DbHelper, this.UserInfo);
            if (!string.IsNullOrEmpty(this.NewsId))
            {
                newsEntity = newsManager.GetEntity(this.NewsId);
            }
            this.GetNews(newsEntity);
            if (String.IsNullOrEmpty(newsEntity.Id))
            {
                newsEntity.Id = BaseBusinessLogic.NewGuid();
                newsManager.Add(newsEntity, out statusCode);
                this.NewsId = newsEntity.Id;
            }
            else
            {
                returnValue = newsManager.Update(newsEntity, out statusCode);
            }
            // 处理新闻图片
            if (this.FileUpload1.PostedFile.ContentLength > 0)
            {
                string imageUrl = this.SaveFile(this.FileUpload1.PostedFile, "News", this.NewsId, newsEntity.ImageUrl);
                newsManager.SetProperty(this.NewsId, new KeyValuePair<string, object>(BaseNewsEntity.FieldImageUrl, imageUrl));
            }
            statusMessage = newsManager.GetStateMessage(statusCode);

            // 上传附件，保存附件
            Utilities.UpLoadFiles("News", this.NewsId, string.Empty);

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
            // Page.Response.Redirect("EditNews.aspx");
            Utilities.CloseWindow();
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

    private string SaveFile(System.Web.HttpPostedFile httpPostedFile, string categoryId, string objectId, string oldUrl)
    {
        #region 删除原有图片
        if (!string.IsNullOrEmpty(oldUrl))
        {
            var oldPath = Page.Server.MapPath(oldUrl);
            var fi = new FileInfo(oldPath);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
        #endregion

        string rootPath = Page.Server.MapPath("~/");
        string loadDirectory = ImagesURL.Trim('/') + "\\" + categoryId + "\\" + objectId;
        // 需要创建的目录，图片放在这里，为了保存历史纪录，使用了当前日期做为目录
        string makeDirectory = rootPath + loadDirectory;
        Directory.CreateDirectory(makeDirectory);
        // 获得文件名
        string fileName = Server.HtmlEncode(Path.GetFileName(httpPostedFile.FileName));
        if (fileName.Length > 30)
        {
            fileName = fileName.Substring(fileName.Length - 30);
        }
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
        // 保存新闻
        this.DoSave(true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(this.ReturnURL);
    }
}
