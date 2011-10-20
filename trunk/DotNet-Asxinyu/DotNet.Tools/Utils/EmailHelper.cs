namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary><para>　</para>
    /// 类名：常用工具类——邮件类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para></summary>
    public class EmailHelper
    {
        /// <summary>EmailSendHelper</summary>
        public class EmailSendHelper
        {
            /// <summary>SMTP方式发送邮件<para>　请先确认服务器上装了ＳＭＴＰ服务器</para></summary>
            /// <param name="SmtpEMail">SmtpEMail对象</param>
            /// <returns></returns>
            public static bool SmtpSendEMail(EmailHelper.SMTPEMailModel SmtpEMail)
            {
                bool flag = false;
                try
                {
                    int num;
                    int num2;
                    SmtpClient client;
                    MailMessage message = new MailMessage();
                    goto Label_019E;
                Label_000D:
                    client.Port = SmtpEMail.SmtpPort;
                    client.Send(message);
                    flag = true;
                    goto Label_0060;
                Label_0026:
                    message.Priority = SmtpEMail.MailPriority;
                    client = new SmtpClient();
                    client.Credentials = new NetworkCredential(SmtpEMail.SmtpUserName, SmtpEMail.SmtpPassword);
                    client.Host = SmtpEMail.SmtpHost;
                    goto Label_000D;
                Label_0060:
                    if (-2 != 0) goto Label_0099;
                Label_0067:
                    message.SubjectEncoding = SmtpEMail.SubjectEncode;
                    message.Body = SmtpEMail.Body;
                    message.BodyEncoding = SmtpEMail.BodyEncoding;
                    message.IsBodyHtml = SmtpEMail.IsBodyHtml;
                    goto Label_0026;
                Label_0099:
                    if (((uint) num) + ((uint) num) <= uint.MaxValue) return flag;
                    goto Label_0150;
                Label_00B9:
                    if (((uint) num2) + ((uint) num2) < 0) goto Label_0162;
                    message.Subject = SmtpEMail.Subject;
                    if (-1 != 0) goto Label_0067;
                    if ((((uint) flag) & 0) != 0) goto Label_0154;
                Label_00FE:
                    message.CC.Add(SmtpEMail.CCEMail[num2]);
                    num2++;
                Label_0119:
                    if (num2 < SmtpEMail.CCEMail.Count) goto Label_00FE;
                    message.From = new MailAddress(SmtpEMail.FromEMail, SmtpEMail.FromUserName, SmtpEMail.FromEMailEncode);
                    if (3 != 0) goto Label_00B9;
                    goto Label_0067;
                Label_0150:
                    num++;
                Label_0154:
                    if (num < SmtpEMail.ToEMail.Count) goto Label_016D;
                Label_0162:
                    num2 = 0;
                    goto Label_0119;
                Label_016D:
                    message.To.Add(SmtpEMail.ToEMail[num]);
                    if (((uint) flag) + ((uint) flag) >= 0) goto Label_0150;
                    return flag;
                Label_019E:
                    num = 0;
                }
                catch (Exception)
                {
                }
                goto Label_0154;
            }

            /// <summary>发邮件测试</summary>
            public static void SmtpSendTest()
            {
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                EmailHelper.SMTPEMailModel smtpEMail = new EmailHelper.SMTPEMailModel();
                smtpEMail.Body = "正文内容";
                smtpEMail.BodyEncoding = Encoding.UTF8;
                list.Add("ycmoon@qq.com");
                list.Add("ycmoon@vip.qq.com");
                goto Label_008E;
            Label_003E:
                do
                {
                    smtpEMail.SmtpPort = 0x19;
                    smtpEMail.SmtpUserName = "kenny@ecolor.com.cn";
                    smtpEMail.Subject = "这是邮件主题";
                    if (3 == 0) goto Label_00AE;
                    smtpEMail.SubjectEncode = Encoding.UTF8;
                }
                while (0 != 0);
                smtpEMail.ToEMail = list;
                SmtpSendEMail(smtpEMail);
                if (-2147483648 != 0) return;
                if (0 == 0) goto Label_008E;
            Label_0068:
                smtpEMail.FromUserName = "月亮  http://ycmoon.008.net ";
                smtpEMail.IsBodyHtml = true;
                smtpEMail.MailPriority = MailPriority.High;
                smtpEMail.SmtpHost = "mail.ecolor.com.cn";
                smtpEMail.SmtpPassword = "welcome2k";
                goto Label_003E;
            Label_008E:
                list2.Add("ycmoons@163.com");
                smtpEMail.CCEMail = list2;
                smtpEMail.FromEMail = "kenny@ecolor.com.cn";
                if (0 != 0) goto Label_003E;
            Label_00AE:
                smtpEMail.FromEMailEncode = Encoding.UTF8;
                goto Label_0068;
            }
        }

        /// <summary>SMTP发送邮件Model类</summary>
        public class SMTPEMailModel
        {
            private Encoding _x1fe42d32f4925bed = Encoding.UTF8;
            private Encoding _x295e5d1a937c0181 = Encoding.UTF8;
            private Encoding _x3bb6bdc76c9f1553 = Encoding.UTF8;
            private int _x8d81d99460ab3f67 = 0x19;
            private System.Net.Mail.MailPriority _x8f76d72cdcfec40d = System.Net.Mail.MailPriority.High;
            [CompilerGenerated]
            private string x1da99d7eb2bc66b0;
            [CompilerGenerated]
            private bool x22858b5c4cf0db6e;
            [CompilerGenerated]
            private string x3cb96530f1dcd66f;
            [CompilerGenerated]
            private string x8b68956bfed0e8eb;
            [CompilerGenerated]
            private IList<string> x9489a652f7b6d53f;
            [CompilerGenerated]
            private string xa76a1401145ffbce;
            [CompilerGenerated]
            private IList<string> xbb05a5a1b7015063;
            [CompilerGenerated]
            private string xc650a38ae5432428;
            [CompilerGenerated]
            private string xcfc12561af443ec8;
            [CompilerGenerated]
            private string xea1164d18601ead4;

            /// <summary>邮件内容</summary>
            public string Body { [CompilerGenerated]
            get { return this.x3cb96530f1dcd66f; } [CompilerGenerated]
            set { this.x3cb96530f1dcd66f = value; } }

            /// <summary>邮件内容编码，默认UTF8</summary>
            public Encoding BodyEncoding { get { return this._x1fe42d32f4925bed; } set { this._x1fe42d32f4925bed = value; } }

            /// <summary>抄送地址</summary>
            public IList<string> CCEMail { [CompilerGenerated]
            get { return this.x9489a652f7b6d53f; } [CompilerGenerated]
            set { this.x9489a652f7b6d53f = value; } }

            /// <summary>发件人邮件地址</summary>
            public string FromEMail { [CompilerGenerated]
            get { return this.xa76a1401145ffbce; } [CompilerGenerated]
            set { this.xa76a1401145ffbce = value; } }

            /// <summary>发件人邮件地址编码：默认UTF8</summary>
            public Encoding FromEMailEncode { get { return this._x3bb6bdc76c9f1553; } set { this._x3bb6bdc76c9f1553 = value; } }

            /// <summary>发件人姓名</summary>
            public string FromUserName { [CompilerGenerated]
            get { return this.xea1164d18601ead4; } [CompilerGenerated]
            set { this.xea1164d18601ead4 = value; } }

            /// <summary>邮件正文是否为HTML</summary>
            public bool IsBodyHtml { [CompilerGenerated]
            get { return this.x22858b5c4cf0db6e; } [CompilerGenerated]
            set { this.x22858b5c4cf0db6e = value; } }

            /// <summary>邮件发送优先级别：默认为 Hight</summary>
            public System.Net.Mail.MailPriority MailPriority { get { return this._x8f76d72cdcfec40d; } set { this._x8f76d72cdcfec40d = value; } }

            /// <summary>SMTP服务器主机</summary>
            public string SmtpHost { [CompilerGenerated]
            get { return this.xcfc12561af443ec8; } [CompilerGenerated]
            set { this.xcfc12561af443ec8 = value; } }

            /// <summary>SMTP用户密码</summary>
            public string SmtpPassword { [CompilerGenerated]
            get { return this.x1da99d7eb2bc66b0; } [CompilerGenerated]
            set { this.x1da99d7eb2bc66b0 = value; } }

            /// <summary>SMTP端口，默认25</summary>
            public int SmtpPort { get { return this._x8d81d99460ab3f67; } set { this._x8d81d99460ab3f67 = value; } }

            /// <summary>SMTP用户名</summary>
            public string SmtpUserName { [CompilerGenerated]
            get { return this.x8b68956bfed0e8eb; } [CompilerGenerated]
            set { this.x8b68956bfed0e8eb = value; } }

            /// <summary>邮件主题</summary>
            public string Subject { [CompilerGenerated]
            get { return this.xc650a38ae5432428; } [CompilerGenerated]
            set { this.xc650a38ae5432428 = value; } }

            /// <summary>邮件主题编码：默认UTF8</summary>
            public Encoding SubjectEncode { get { return this._x295e5d1a937c0181; } set { this._x295e5d1a937c0181 = value; } }

            /// <summary>收件人地址</summary>
            public IList<string> ToEMail { [CompilerGenerated]
            get { return this.xbb05a5a1b7015063; } [CompilerGenerated]
            set { this.xbb05a5a1b7015063 = value; } }
        }
    }
}
