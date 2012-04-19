//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

using Project;

public partial class ProjectAdd : BasePage
{
    public string ProjectId
    {
        get
        {
            return this.txtId.Value;
        }
        set
        {
            this.txtId.Value = value;
        }
    }

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

    #region  private void GetParamter() 获取页面间所传入的参数值
    private new void GetParamter()
    {
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"];
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
        this.GetParamter();
        // 判断新闻发布权限
        // this.Authorized("News.Add");
        // 按钮状态
        this.SetControlState();
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
        if (this.txtKeHuMingCheng.Text.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入客户名称。'); document.all['txtKeHuMingCheng'].focus();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", checkInput);
            return false;
        }
        return returnValue;
    }
    #endregion

    private ProjectEntity GetEntity()
    {
        ProjectEntity projectEntity = new ProjectEntity();
        if (!string.IsNullOrEmpty(this.txtLiXiangRiQi.Text))
        {
            projectEntity.LiXiangRiQi = DateTime.Parse(this.txtLiXiangRiQi.Text);
        }
        projectEntity.KeHuMingCheng = this.txtKeHuMingCheng.Text;
        projectEntity.KeHuXiangMuMingCheng = this.txtKeHuXiangMuMingCheng.Text;
        projectEntity.XingHao = this.txtXingHao.Text;

        // PET测试结果
        if (this.rbPETCheShiJieGuoNG.Checked)
        {
            projectEntity.PETCeShiJieGuo = -1;
        }
        if (this.rbPETCheShiJieGuoOK.Checked)
        {
            projectEntity.PETCeShiJieGuo = 1;
        }

        return projectEntity;
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
        // 检查页面的输入
        if (!this.CheckInput())
        {
            return;
        }
        try
        {
            this.DbHelper.Open();
            ProjectEntity projectEntity = this.GetEntity();
            ProjectManager projectManager = new ProjectManager(this.DbHelper, this.UserInfo);
            this.ProjectId = projectManager.Add(projectEntity);
            // 处理上传文件
            if (this.fuKeHuZiLiao.PostedFile != null && this.fuKeHuZiLiao.PostedFile.ContentLength > 0)
            {
                string imageUrl = this.SaveFile(this.fuKeHuZiLiao.PostedFile, "Project", this.ProjectId + "_KeHuZiLiao");
                projectManager.SetProperty(this.ProjectId, new KeyValuePair<string, object>(ProjectTable.FieldKeHuZiLiao, 1));
                // 这里是获取图片路径
                // projectManager.SetProperty(this.ProjectId, ProjectTable.FieldKeHuZiLiao, imageUrl);
            }
            if (this.fuQuRenTuZhi.PostedFile != null && this.fuQuRenTuZhi.PostedFile.ContentLength > 0)
            {
                string imageUrl = this.SaveFile(this.fuQuRenTuZhi.PostedFile, "Project", this.ProjectId + "_QuRenTuZhi");
                projectManager.SetProperty(this.ProjectId, new KeyValuePair<string, object>(ProjectTable.FieldQuRenTuZhi, 1));
                // 这里是获取图片路径
                // projectManager.SetProperty(this.ProjectId, ProjectTable.FieldQuRenTuZhi, imageUrl);
            }
            if (this.fuQuRenJieGuo.PostedFile != null && this.fuQuRenJieGuo.PostedFile.ContentLength > 0)
            {
                string imageUrl = this.SaveFile(this.fuQuRenJieGuo.PostedFile, "Project", this.ProjectId + "_QuRenJieGuo");
                projectManager.SetProperty(this.ProjectId, new KeyValuePair<string, object>(ProjectTable.FieldQuRenJieGuo, 1));
                // 这里是获取图片路径
                // projectManager.SetProperty(this.ProjectId, ProjectTable.FieldQuRenJieGuo, imageUrl);
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
            if (!string.IsNullOrEmpty(this.ReturnURL))
            {
                Page.Response.Redirect(this.ReturnURL);
            }
            // Utilities.CloseWindow();
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