//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using DotNet.Utilities;

/// <remarks>
/// Attachment
/// 附件管理
///
/// 修改记录
///
///		2009.09.29 版本：2.1 JiRiGaLa 上传日期改进。
///		2009.04.08 版本：2.0 JiRiGaLa 重新整理代码。
///		2007.11.12 版本：1.0 JiRiGaLa 整理代码。
///
/// 版本：2.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.04.08</date>
/// </author> 
/// </remarks>
public partial class Attachment : System.Web.UI.UserControl
{
    private bool showFileUpload = false;
    /// <summary>
    /// 是否显示上传附件
    /// </summary>
    public bool ShowFileUpload
    {
        get
        {
            return this.showFileUpload;
        }
        set
        {
            this.showFileUpload = value;
            this.ShowUpFiles();
        }
    }

    private int showFileUploadCount = 2;
    /// <summary>
    /// 是否显示上传附件
    /// </summary>
    public int ShowFileUploadCount
    {
        get
        {
            return this.showFileUploadCount;
        }
        set
        {
            this.showFileUploadCount = value;
            this.ShowUpFiles();
        }
    }

    private void ShowUpFiles()
    {
        fupAttachment01.Visible = showFileUpload && ShowFileUploadCount > 0;
        fupAttachment02.Visible = showFileUpload && ShowFileUploadCount > 1;
        fupAttachment03.Visible = showFileUpload && ShowFileUploadCount > 2;
        fupAttachment04.Visible = showFileUpload && ShowFileUploadCount > 3;
    }

    private string uploadFiles = "UploadFiles";
    /// <summary>
    /// 文件上传目录
    /// </summary>
    public string UploadFiles
    {
        get
        {
            return this.uploadFiles;
        }
        set
        {
            this.uploadFiles = value;
        }
    }

    private bool allowDelete = true;
    /// <summary>
    /// 是否允许删除
    /// </summary>
    public bool AllowDelete
    {
        get
        {
            return this.allowDelete;
        }
        set
        {
            this.allowDelete = value;
        }
    }


    private string UpLoadFilePath
    {
        get
        {
            if (ViewState["UpLoadFilePath"] == null)
            {
                ViewState["UpLoadFilePath"] = string.Empty;
            }
            return ViewState["UpLoadFilePath"].ToString();
        }
        set
        {
            ViewState["UpLoadFilePath"] = value;
        }
    }

    private bool allowShowHeader = false;
    /// <summary>
    /// 是否允许显示标题行by朱潇波
    /// </summary>
    public bool AllowShowHeader
    {
        get
        {
            return this.allowShowHeader;
        }
        set
        {
            this.allowShowHeader = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int GetAttachmentList(string upLoadFilePath)
    {
        //允许显示标题行by朱潇波
        this.grdAttachment.ShowHeader = allowShowHeader;
        this.UpLoadFilePath = upLoadFilePath;
        string rootPath = Page.Server.MapPath("~/") + UploadFiles + "\\";
        string upLoadDirectory = rootPath + this.UpLoadFilePath;
        return this.GetFileList(upLoadDirectory);
    }

    public int GetAttachmentList(string categoryId, string objectId)
    {
        string directory = categoryId + "\\" + objectId;
        return this.GetAttachmentList(directory);
    }

    public int GetFileList(string directory)
    {
        DataTable dataTable = new DataTable("Attachment");
        dataTable.Columns.Add("FileName");
        dataTable.Columns.Add("FileUrl");
        dataTable.Columns.Add("FileSize");
        dataTable.Columns.Add("CreationTime");
        if (Directory.Exists(directory))
        {
            string[] filenames = Directory.GetFiles(directory);
            for (int i = 0; i < filenames.Length; i++)
            {
                string fileName = Server.HtmlEncode(Path.GetFileName(filenames[i]));
                DataRow dataRow = dataTable.NewRow();
                dataRow["FileName"] = fileName;
                dataRow["FileUrl"] = this.UploadFiles + "\\" + this.UpLoadFilePath + "\\" + fileName;
                dataRow["CreationTime"] = System.IO.File.GetLastWriteTime(filenames[i]).ToString(BaseSystemInfo.DateFormat);
                dataTable.Rows.Add(dataRow);
            }
        }
        // 删除列的隐藏控制
        this.grdAttachment.Columns[this.grdAttachment.Columns.Count - 1].Visible = this.AllowDelete;
        dataTable.DefaultView.Sort = "CreationTime DESC ";
        this.grdAttachment.DataSource = dataTable.DefaultView;
        this.grdAttachment.DataBind();
        this.grdAttachment.Visible = this.grdAttachment.Rows.Count > 0;
        return this.grdAttachment.Rows.Count;
    }

    protected void grdAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            TableCell tableCell = e.Row.Cells[this.grdAttachment.Columns.Count - 1];
            if (this.AllowDelete)
            {
                LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
                if (btnLinkDelete != null)
                {
                    string strScript = "return confirm('您确定要删除吗？');";
                    btnLinkDelete.Attributes.Add("onclick", strScript);
                }
            }
        }
    }

    protected void grdAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (this.AllowDelete)
        {
            string fileUrl = this.grdAttachment.DataKeys[e.RowIndex].Value.ToString();
            string fileName = Page.Server.MapPath("~/") + fileUrl;
            File.Delete(fileName);
            string directory = Directory.GetParent(fileName).FullName;
            this.GetFileList(directory);
        }
    }

    /// <summary>
    /// 保存上传文件
    /// </summary>
    /// <returns>文件数</returns>
    public int SaveFiles(string categoryId, string objectId)
    {
        int returnValue = 0;
        if (this.fupAttachment01.Visible && this.fupAttachment01.PostedFile.ContentLength > 0)
        {
            this.SaveFile(this.fupAttachment01.PostedFile, categoryId, objectId);
            returnValue ++;
        }
        if (this.fupAttachment02.Visible && this.fupAttachment02.PostedFile.ContentLength > 0)
        {
            this.SaveFile(this.fupAttachment02.PostedFile, categoryId, objectId);
            returnValue ++;
        }
        if (this.fupAttachment03.Visible && this.fupAttachment03.PostedFile.ContentLength > 0)
        {
            this.SaveFile(this.fupAttachment03.PostedFile, categoryId, objectId);
            returnValue++;
        }
        if (this.fupAttachment04.Visible && this.fupAttachment04.PostedFile.ContentLength > 0)
        {
            this.SaveFile(this.fupAttachment04.PostedFile, categoryId, objectId);
            returnValue ++;
        }
        return returnValue;
    }

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
        string fileUrl = "/" + categoryId + "/" + objectId + "/" + fileName;
        // 文件复制到相应的路径下
        string copyToFile = makeDirectory + "\\" + fileName;
        httpPostedFile.SaveAs(copyToFile);
        return fileUrl;
    }
}