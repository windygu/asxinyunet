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

using DotNet.Utilities;
using DotNet.Business;

/// <remarks>
/// UserStatistics
/// 用户统计
///
/// 修改记录
///
///     2009.11.24 版本：1.0  JiRiGaLa 创建。
///		
/// 版本：2.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2007.11.30</date>
/// </author> 
/// </remarks>
public partial class UserStatistics : BasePage
{
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
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetUserCount();
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

    private void GetUserCount()
    {
        this.lblTongJiRiQi.Text = DateTime.Now.ToString(BaseSystemInfo.DateFormat);

        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        this.lblZaiXian.Text = userManager.GetOnLineCount();
        this.lblJinTianDengLu.Text = userManager.GetLogOnCount(1);
        this.lblYiZhouNeiDengLu.Text = userManager.GetLogOnCount(7);
        this.lblYiGeYueNeiDengLu.Text = userManager.GetLogOnCount(30);
        this.lblBanNianNeiDengLu.Text = userManager.GetLogOnCount(180);
        this.lblYiNianNeiDengLu.Text = userManager.GetLogOnCount(365);

        this.lblZhuCeYongHuShu.Text = userManager.GetCount();
        this.lblJinTianZhuCe.Text = userManager.GetRegistrationCount(1);
        this.lblYiZhouNeiZhuCe.Text = userManager.GetRegistrationCount(7);
        this.lblYiGeYueNeiZhuCe.Text = userManager.GetRegistrationCount(30);
        this.lblBanNianNeiZhuCe.Text = userManager.GetRegistrationCount(180);
        this.lblYiNaiNeiZhuCe.Text = userManager.GetRegistrationCount(365);
    }
}