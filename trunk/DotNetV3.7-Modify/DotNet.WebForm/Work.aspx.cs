//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Configuration;
using System.Web.UI;

using DotNet.Business;

public partial class Work : BasePage
{
    // private string defaultPage = "Modules/Project/ProjectAdmin/ProjectAdmin.aspx";
    private string defaultPage = "Modules/Common/WorkFlow/WorkFlowWaitForAudit.aspx";
    private string defaultModuleCode = "WorkFlow";

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    new private void GetParamter()
    {
        string customerCompanyName = ConfigurationManager.AppSettings["SoftFullName"];
        string softFullName = ConfigurationManager.AppSettings["CustomerCompanyName"];
        this.Header.Title = customerCompanyName + " - " + softFullName;

        if (Page.Request["Page"] != null)
        {
            this.defaultPage = Page.Request["Page"];
        }
        if (Page.Request["ModuleCode"] != null)
        {
            this.defaultModuleCode = Page.Request["ModuleCode"];
        }
        if (Page.Request["ContactId"] != null)
        {
            this.defaultPage += "&ContactId=" + Page.Request["ContactId"];
        }
        if (Page.Request["ReturnURL"] != null)
        {
            this.defaultPage += "&ReturnURL=" + Page.Request["ReturnURL"];
        }
        if (Page.Request["Category"] != null)
        {
            this.defaultPage += "?Category=" + Page.Request["Category"];
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        this.GetParamter();        
        // 这里是设置默认加载的菜单 //  + BaseSystemInfo.RootMenuCode
        string leftPage = "LeftMenu.aspx?ModuleCode=WorkFlow";
        if (Page.Request["Left"] != null)
        {
            leftPage = Page.Request["Left"];
        }
        string requestQuery = Page.Request.Url.Query;
        this.SetDefaultPage(this.parentfram, leftPage, this.defaultPage, requestQuery);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 检查用户是否登录
            Utilities.CheckIsLogOn();
            this.DoPageLoad();
        }
    }

    /// <summary>
    /// 获取default.aspx页面的显示代码
    /// </summary>
    /// <param name="parentfram">frameset,框架名称</param>
    /// <param name="myLeftUrl">默认指向的左框架页面地址</param>
    /// <param name="myMainUrl">默认指向的main框架页面地址</param>
    /// <param name="myQuery">左框架附带的信息</param>
    public void SetDefaultPage(System.Web.UI.HtmlControls.HtmlGenericControl parentFrame, string leftPage, string mainPage, string requestQuery)
    {
        //定义上框架、左框架打开与关闭的大小
        string frameHtml = "";

        //根据上框架开关决定显示的高度
        if ((new FrameInfo()).ShowTopFrame)
        {
            //如果上框架是展开的
            parentFrame.Attributes.Add("rows", (new FrameInfo()).TopExpandHeight + ",*");
        }
        else
        {
            //如果上框架是收缩的
            parentFrame.Attributes.Add("rows", (new FrameInfo()).TopShrinkHeight + ",*");
        }
        frameHtml = "<frame id=\"topFrame\" src=\"CommonHeader.aspx" + requestQuery + "\" name=\"topFrame\" scrolling=\"NO\" noresize >";

        //根据左框架开关决定是否显示左框架
        if ((new FrameInfo()).ShowLeftFrame)
        {
            //如果左框架是展开的
            frameHtml += "<frameset id = myframeset cols=\"" + (new FrameInfo()).LeftWidth + ",*\" framespacing=\"1\" frameborder=\"yes\" border=\"1\" bordercolor=\"#6699CC\">";
        }
        else
        {
            //如果左框架是收缩的
            frameHtml += "<frameset id = myframeset cols=\"0,*\" framespacing=\"1\" frameborder=\"yes\" border=\"1\" bordercolor=\"#6699CC\">";
        }

        frameHtml += "<frame id=leftfram src=\"" + leftPage + requestQuery + "\" name=\"leftFrame\" scrolling=\"auto\" marginwidth=0>";
        frameHtml += "<frame id=fraContent src=\"" + mainPage + "\" name=\"fraContent\" scrolling=\"auto\">";
        frameHtml += "</frameset>";

        parentFrame.InnerHtml = frameHtml;
    }
}

/// <summary>
/// 获取当前模块的展开情况
/// </summary>
public class FrameInfo
{
    /// <summary>
    /// 左侧框架是否展开,默认为是
    /// </summary>
    private bool _LeftFrameIsOpen = true;
    /// <summary>
    /// 左侧框架是否展开,默认为是
    /// </summary>
    public bool ShowLeftFrame
    {
        get { return (this._LeftFrameIsOpen); }
        set { this._LeftFrameIsOpen = value; }
    }

    /// <summary>
    /// 顶部框架是否展开,默认为是
    /// </summary>
    private bool _TopFrameIsOpen = true;
    /// <summary>
    /// 顶部框架是否展开,默认为是
    /// </summary>
    public bool ShowTopFrame
    {
        get { return (this._TopFrameIsOpen); }
        set { this._TopFrameIsOpen = value; }
    }

    /// <summary>
    /// 左框架展开宽度
    /// </summary>
    private int _LeftWidth = 160;
    /// <summary>
    /// 顶部框架是否展开,默认为160
    /// </summary>
    public int LeftWidth
    {
        get { return (this._LeftWidth); }
        set { this._LeftWidth = value; }
    }

    /// <summary>
    /// 上框架展开高度
    /// </summary>
    private int _TopExpandHeight = 100;
    /// <summary>
    /// 上框架展开高度,默认100
    /// </summary>
    public int TopExpandHeight
    {
        get { return (this._TopExpandHeight); }
        set { this._TopExpandHeight = value; }
    }

    /// <summary>
    /// 上框架收缩高度
    /// </summary>
    private int _TopShrinkHeight = 50;
    /// <summary>
    /// 上框架收缩高度,默认50
    /// </summary>
    public int TopShrinkHeight
    {
        get { return (this._TopShrinkHeight); }
        set { this._TopShrinkHeight = value; }
    }

    /// <summary>
    /// 构造器
    /// </summary>
    public FrameInfo()
    {
        this._LeftWidth = int.Parse(ConfigurationManager.AppSettings["sysLeftWidth"].ToString());
        this._TopExpandHeight = int.Parse(ConfigurationManager.AppSettings["sysTopOpenHeight"].ToString());
        this._TopShrinkHeight = int.Parse(ConfigurationManager.AppSettings["sysTopOffHeight"].ToString());

        Page page = (Page)System.Web.HttpContext.Current.Handler;
        if (page.Session["ShowTopFrame"] == null)
        {
            if (Utilities.UserIsLogOn())
            {
                BaseParameterManager parameterManager = new BaseParameterManager();
                string showTopFrame = parameterManager.GetParameter("User", Utilities.UserInfo.Id, "ShowTopFrame");
                string showLeftFrame = parameterManager.GetParameter("User", Utilities.UserInfo.Id, "ShowLeftFrame");
                if (!string.IsNullOrEmpty(showTopFrame))
                {
                    page.Session["ShowTopFrame"] = showTopFrame.EndsWith(true.ToString());
                }
                else
                {
                    page.Session["ShowTopFrame"] = true;
                }
                if (!string.IsNullOrEmpty(showLeftFrame))
                {
                    page.Session["ShowLeftFrame"] = showLeftFrame.EndsWith(true.ToString());
                }
                else
                {
                    page.Session["ShowLeftFrame"] = true;
                }
            }
            else
            {
                page.Session["ShowTopFrame"] = true;
            }
        }

        if (page.Session["ShowLeftFrame"] == null)
        {
            page.Session["ShowLeftFrame"] = true;
        }

        this._LeftFrameIsOpen = (bool)page.Session["ShowLeftFrame"];
        this._TopFrameIsOpen = (bool)page.Session["ShowTopFrame"];
    }
}