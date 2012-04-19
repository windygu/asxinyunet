//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web;
using System.Web.UI;

using DotNet.Business;

/// <remarks>
/// UserOnLine
/// 用户在线
///
/// 修改记录
///
///		2009.07.29 版本：1.0  JiRiGaLa
///		
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2009.07.29</date>
/// </author> 
/// </remarks>
public partial class UserOnLine : BasePage
{
    #region public void GetParamter() 获取传入参数
    /// <summary>
    /// 获取传入参数
    /// </summary>
    private new void GetParamter()
    {
        BaseParameterManager parameterManager = new BaseParameterManager(this.UserCenterDbHelper, this.UserInfo);
        // 上面的框架是否打开
        if (Page.Request.QueryString["ShowTopFrame"] != null)
        {
            this.Session["ShowTopFrame"] = Page.Request.QueryString["ShowTopFrame"].ToUpper().Equals(true.ToString().ToUpper());
            parameterManager.SetParameter("User", this.UserInfo.Id, "ShowTopFrame", ((bool)this.Session["ShowTopFrame"]).ToString());
        }
        // 左边的框架是否打开
        if (Page.Request.QueryString["ShowLeftFrame"] != null)
        {
            this.Session["ShowLeftFrame"] = Page.Request.QueryString["ShowLeftFrame"].ToUpper().Equals(true.ToString().ToUpper());
            parameterManager.SetParameter("User", this.UserInfo.Id, "ShowLeftFrame", ((bool)this.Session["ShowLeftFrame"]).ToString());
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 页面初次加载时的动作
        this.DoPageLoad();
    }

    /// <summary>
    /// 当前用户在线上
    /// </summary>
    private void CurrentUserOnLine()
    {
        string userId = string.Empty;
        if (Page.Request.QueryString["Id"] != null)
        {
            userId = Page.Request.QueryString["Id"];
        }
        else
        {
            userId = this.UserInfo.Id;
        }
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        // 设置当前用户为在线
        userManager.OnLine(userId);
        // 检查在线用户状态
        userManager.CheckOnLine();
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.UserCenterDbHelper.Open();
            // 获取传入参数
            this.GetParamter();
            // 当前用户在线上
            this.CurrentUserOnLine();
            this.Response.Clear();
            this.Response.Write("欢迎您 " + this.UserInfo.UserName + " （" + this.UserInfo.DepartmentName + "）");
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            //this.Response.End();
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
}