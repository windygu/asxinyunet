//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web;
using System.Data;
using System.Web.Security;

using DotNet.Business;
using DotNet.Utilities;

/// <summary>
/// Download
/// 下载文件
///
/// 修改纪录
///
///		2012-02-16 版本：1.0 JiRiGaLa 文件下载功能。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012-02-16</date>
/// </author>
/// </summary>
public partial class Download : BasePage
{
    /// <summary>
    /// 当前文件夹
    /// </summary>
    private string FileId = string.Empty;

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["Id"] != null)
        {
            this.FileId = Page.Request["Id"].ToString();
        }
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
        this.GetParamter();
        if (!string.IsNullOrEmpty(this.FileId))
        {
            // 从数据库下载文件
            this.DownloadFile(this.FileId);
        }
    }
    #endregion

    private void DownloadFile(string id)
    {
        // 先判断文件是否有效
        FileService fileService = new DotNet.Business.FileService();
        BaseFileEntity fileEntity = fileService.GetEntity(this.UserInfo, id);
        if ((fileEntity == null) 
            || String.IsNullOrEmpty(fileEntity.FileName) 
            || (fileEntity.Enabled == null) 
            || (fileEntity.Enabled == 0))
        {
            return;
        }
        // 在输出文件内容
        string fileName = HttpUtility.UrlEncode(fileEntity.FileName);
        byte[] fileContents = fileService.Download(this.UserInfo, id);
        Page.EnableViewState = false;
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "utf-8";
        // 把 attachment 改为 online 则在线打开
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        // Response.ContentType = "application/ms-excel";
        Response.BinaryWrite(fileContents);
        Response.Flush();
        Response.End();
    }
}