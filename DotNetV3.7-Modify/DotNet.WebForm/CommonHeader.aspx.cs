//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CommonHeader : BasePage
{
    new protected void Page_Load(object sender, EventArgs e)
    {
        // 加载控件
        this.TopStyle.DoLoad();

        // 取登录用户信息
        this.GetUserInfo();

        this.LoadSubModule();

        // 设定隐藏(显示)头部图标事件
        this.SetTop();

        // 设定隐藏(显示)左侧图标事件
        this.SetLeft();
    }

    /// <summary>
    /// 根据模块名称求取该列占用的宽度
    /// </summary>
    /// <param name="mdl_name"></param>
    /// <returns></returns>
    private int GetTdWidth(string mdl_name)
    {
        return mdl_name.Length * 5 + 40;
    }

    /// <summary>
    /// 获得下面的菜单
    /// </summary>
    /// <param name="moduleName"></param>
    /// <param name="moduleCode"></param>
    /// <param name="moduleUrl"></param>
    /// <returns></returns>
    private string GetMenu(string moduleName, string moduleCode, string moduleUrl)
    {
        StringBuilder menuItem = new StringBuilder();
        string style = this.GetCurrentMenuStyle(moduleCode);
        menuItem.Append("<td height=\"20\" align=center" + style + " width=\"" + this.GetTdWidth(moduleName) + "\" nowrap onMouseOver=\"changeMenu(this);\" onMouseOut=\"OutMenu(this);\">");
        menuItem.Append("<a href=\"" + moduleUrl + "\" target=_top>" + moduleName + "</a>");
        menuItem.Append("</td><td width=4 align=center>|</td>");
        return menuItem.ToString();
    }

    private string GetCurrentMenuStyle(string moduleCode)
    {
        string style = " class=\"menuclass\"";
        if (Page.Request["ModuleCode"] != null)
        {
            if (Page.Request["ModuleCode"].Equals(moduleCode))
            {
                style = " class=\"menuclick\"";
            }
        }
        return style;
    }
    protected string JsFloat {
        get {
            string jspath = "http://" + Request.Url.Authority + Request.ApplicationPath + "/JavaScript/jfloat.js";
            return jspath;
        }
    }
    /// <summary>
    /// 生成次级模块
    /// </summary>
    private void LoadSubModule()
    {
        StringBuilder moduleHtml = new StringBuilder();
        moduleHtml.Append("<table border=0>");

        if (this.DTModule != null)
        {
            /*
            这里是底部菜单
            if (this.IsModuleAuthorized("CSb01"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb01");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
            if (this.IsModuleAuthorized("CSb02"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb02");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
            if (this.IsModuleAuthorized("CSb03"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb03");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
            if (this.IsModuleAuthorized("CSb04"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb04");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
            if (this.IsModuleAuthorized("CSb05"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb05");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }

            if (this.IsModuleAuthorized("CSb06"))
            {
                DataRow dataRow = BaseBusinessLogic.GetDataRow(this.DTModule, BaseModuleEntity.FieldCode, "CSb06");
                if (dataRow != null)
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
            */
        }

        moduleHtml.Append("</table>");
        this.Module_SunTitle.Text = moduleHtml.ToString();
    }

    /// <summary>
    /// 设定隐藏(显示)头部图标事件
    /// </summary>
    private void SetTop()
    {
        //取上框架展开与收缩高度
        this.showTop.Attributes.Add("onmouseover", "img_mouseover(this);");
        this.showTop.Attributes.Add("onmouseout", "img_mouseout(this);");

        HtmlGenericControl bannel = (HtmlGenericControl)this.TopStyle.FindControl("bannel1");
        this.showTop.Attributes.Add("onclick", "toggleBanner(this," + (new FrameInfo()).TopExpandHeight + "," + (new FrameInfo()).TopShrinkHeight + ",'" + bannel.ClientID + "');");
        this.showTop.Style.Add("cursor", "hand");
        this.showTop.ImageAlign = ImageAlign.AbsMiddle;

        //根据当前隐藏或显示决定图标
        if ((new FrameInfo()).ShowTopFrame)
        {
            //如果当前是展开的,则显示收缩图片
            this.showTop.ImageUrl = this.ResolveUrl("Themes/Blue/Images/Home/but_updown_01.gif");
            this.showTop.ToolTip = "点击隐藏顶部页面";
        }
        else
        {
            this.showTop.ImageUrl = this.ResolveUrl("Themes/Blue/Images/Home/but_updown_02.gif");
            this.showTop.ToolTip = "点击显示顶部页面";
        }
    }


    /// <summary>
    /// 设定隐藏(显示)左侧图标事件
    /// </summary>
    private void SetLeft()
    {
        //this.showLeft.Attributes.Add("onmouseover", "img_mouseover(this);");
        //this.showLeft.Attributes.Add("onmouseout", "img_mouseout(this);");
        this.showLeft.Attributes.Add("onclick", "toggleTree(this," + (new FrameInfo()).LeftWidth + ");");
        this.showLeft.Style.Add("cursor", "hand");
        this.showLeft.ImageAlign = ImageAlign.AbsMiddle;

        //根据当前隐藏或显示决定图标
        if ((new FrameInfo()).ShowLeftFrame)
        {
            //如果当前是展开的,则显示收缩图片
            this.showLeft.ImageUrl = this.ResolveUrl("Themes/Blue/Images/Home/but_yc_01.gif");
            this.showLeft.ToolTip = "点击隐藏左侧框架";
        }
        else
        {
            this.showLeft.ImageUrl = this.ResolveUrl("~/Themes/Blue/Images/Home/but_yc_02.gif");
            this.showLeft.ToolTip = "点击显示左侧框架";
        }
    }

    /// <summary>
    /// 点击退出登录信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //yd.Core.LogOn LogOn = new yd.Core.LogOn();
        //LogOn.LogOnOut();

        //this.Response.Write("<script>top.window.location.href='" + this.ResolveUrl("~/Default.aspx") + "';</script>");
    }

    /// <summary>
    /// 取登录用户信息
    /// </summary>
    private void GetUserInfo()
    {
        // string str = string.Empty;
        // Label LogOnInfo = (Label)this.TopStyle.FindControl("LogOnInfo");
        //if (LogOnUser.IsLoad == false)
        //{
        //    //未登录
        //    str = "document.all('" + LogOnInfo.ClientID + "').innerHTML = \"\";";
        //}
        //else
        //{ 
        //    //已登录 
        // str = "document.all('" + LogOnInfo.ClientID + "').innerHTML = \"" + this.UserInfo.UserName + " 欢迎您使用本系统\";";
        //}
        // this.Response.Write(str);
        // this.Response.End();
    }
}