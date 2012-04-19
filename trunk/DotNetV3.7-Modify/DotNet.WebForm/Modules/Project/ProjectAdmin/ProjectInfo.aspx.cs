//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Drawing;

using DotNet.Business;
using DotNet.Utilities;

using Project;

public partial class ProjectInfo : BasePage
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
        if (Page.Request["Id"] != null)
        {
            this.ProjectId = Page.Request["Id"];
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
        // this.Authorized("Project.Add");
        // 按钮状态
        this.SetControlState();
        this.ShowEntity();
    }
    #endregion

    private void ShowEntity()
    {
        if (string.IsNullOrEmpty(this.ProjectId))
        {
            return;
        }
        ProjectManager projectManager = new ProjectManager(this.DbHelper, this.UserInfo);
        ProjectEntity projectEntity = projectManager.GetEntity(this.ProjectId);
        this.ShowEntity(projectEntity);
    }

    private void ShowEntity(ProjectEntity projectEntity)
    {
        if (projectEntity.LiXiangRiQi != null)
        {
            this.lblLiXiangRiQi.Text = ((DateTime)projectEntity.LiXiangRiQi).ToString(BaseSystemInfo.DateFormat);
        }
        this.lblKeHuMingCheng.Text = projectEntity.KeHuMingCheng;
        this.lblKeHuXiangMuMingCheng.Text = projectEntity.KeHuXiangMuMingCheng;
        this.lblXingHao.Text = projectEntity.XingHao.Replace("\n", "<br>");
        this.AttachmentKeHuZiLiao.GetAttachmentList("Project", projectEntity.Id.ToString() + "_KeHuZiLiao");
        this.AttachmentQuRenTuZhi.GetAttachmentList("Project", projectEntity.Id.ToString() + "_QuRenTuZhi");
        this.AttachmentQuRenJieGuo.GetAttachmentList("Project", projectEntity.Id.ToString() + "_QuRenJieGuo");

        if (projectEntity.PETCeShiJieGuo == 1)
        {
            this.lblPETCheShiJieGuo.Text = "OK";
        }
        if (projectEntity.PETCeShiJieGuo == -1)
        {
            this.lblPETCheShiJieGuo.Text = "NG";
            this.lblPETCheShiJieGuo.ForeColor = Color.Red;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // 编辑项目
        Page.Response.Redirect("ProjectEdit.aspx?Id=" + this.ProjectId);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // 返回主页
        Page.Response.Redirect(this.ReturnURL);
    }
}