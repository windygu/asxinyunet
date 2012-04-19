//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Text;
using System.Web.UI;

/// <remarks>
/// Register2
/// 注册
///		
/// 修改记录
///
///		2008.12.21 版本：1.0 JiRiGaLa 建立代码。 
///		
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2008.12.21</date>
/// </author> 
/// </remarks>
public partial class Register2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Email"] != null)
            {
                this.account.InnerHtml = Session["Email"].ToString();
            }
            else
            {
                Page.Response.Redirect("register.aspx");
            }
        }
    }

    /// <summary>
    /// 获取邮件内容
    /// </summary>
    /// <returns>邮件主体内容</returns>
    private string GetBody()
    {
        StringBuilder htmlBody = new StringBuilder();
        htmlBody.Append("<body style=\"font-size:10pt\">");
        htmlBody.Append("<div style=\"font-size:10pt; font-weight:bold\">尊敬的用户：</div>");
        htmlBody.Append("<div style=\"font-size:10pt; font-weight:bold\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 您好！</div>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 你的登录名是：<font size=\"3\" color=\"#6699cc\">" + "recipientName" + "</font>，您刚刚注册了烟户用户，请点击以下链接完成注册：</div>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href=" + "activationURL" + " target=\"_blank\" swaped=\"true\"><font color=\"#4e5d80\">" + "activationURL" + "</font></a></div>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;我们承诺为广大烟户提供便捷、友好的服务。如有任何疑问，欢迎致电烟草服务中心客服热线：0571-88888888，我们将热情为您解答。</div>");
        htmlBody.Append("<div style=\"text-align:center\">烟草销售检测数字化平台 用户服务中心</div>");
        htmlBody.Append("<div style=\"text-align:center\">" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日</div></body>");
        return htmlBody.ToString();
    }

    public void Send()
    {
        if (Session["Email"] != null)
        {
            string email = Session["Email"].ToString();
            string checkInput = string.Empty;
            if (!String.IsNullOrEmpty(email))
            {
                try
                {
                    this.Send(email);
                }
                catch
                {
                    checkInput = "<script>alert('提示信息：邮件发送失败，请点击重新发送。');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
                }
                checkInput = "<script>alert('提示信息：邮件发送成功。');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            }
        }
    }

    /// <summary>
    /// 发送给谁
    /// </summary>
    /// <param name="to">邮件地址</param>
    public void Send(string to)
    {
        using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage())
        {
            // 接收人邮箱地址
            message.To.Add(new System.Net.Mail.MailAddress(to));
            message.Body = this.GetBody();

            message.From = new System.Net.Mail.MailAddress("JiRiGaLa_Bao@Hotmail.com", "烟草销售检测数字化平台");
            message.BodyEncoding = Encoding.GetEncoding("GB2312");
            message.Subject = "烟草销售检测数字化平台 新用户注册激活";
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient("smtp.live.com", 25);
            smtpclient.Credentials = new System.Net.NetworkCredential("JiRiGaLa_Bao@Hotmail.com", "19780519jirigala");
            smtpclient.EnableSsl = true;
            smtpclient.Send(message);
        }
    }

    protected void lnkSendEmail_Click(object sender, EventArgs e)
    {
        this.Send();
    }
}