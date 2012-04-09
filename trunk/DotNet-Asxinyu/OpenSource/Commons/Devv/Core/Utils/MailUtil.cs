namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class MailUtil
    {
        private MailUtil()
        {
        }

        public static string DecodeSubject(string input)
        {
            string str;
            try
            {
                IEnumerator enumerator;
                if ((input == "") || (input == null))
                {
                    return "";
                }
                MatchCollection matchs = new Regex(@"=\?(?<Encoding>[^\?]+)\?(?<Method>[^\?]+)\?(?<Text>[^\?]+)\?=").Matches(input);
                string str2 = input;
                if (matchs.Count > 1)
                {
                    str2 = str2.Replace("?= =?", "?==?");
                }
                try
                {
                    enumerator = matchs.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        string str3;
                        Match current = (Match) enumerator.Current;
                        string name = current.Groups["Encoding"].Value;
                        switch (name.ToLower())
                        {
                            case "utf8":
                                name = "UTF-8";
                                break;

                            case "utf7":
                                name = "UTF-7";
                                break;
                        }
                        string str5 = current.Groups["Method"].Value;
                        string s = current.Groups["Text"].Value;
                        if (str5 == "B")
                        {
                            byte[] bytes = Convert.FromBase64String(s);
                            str3 = Encoding.GetEncoding(name).GetString(bytes);
                        }
                        else
                        {
                            str3 = DecodeSubject(s, Encoding.GetEncoding(name));
                        }
                        str2 = str2.Replace(current.Groups[0].Value, str3);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                str = str2;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                str = string.Empty;
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public static string DecodeSubject(string input, Encoding enc)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            char[] chArray = input.ToCharArray();
            byte[] bytes = new byte[(chArray.Length - 1) + 1];
            int index = 0;
            int num = 0;
            while (num < chArray.Length)
            {
                if (chArray[num] == '=')
                {
                    num++;
                    if ((chArray.Length >= (num + 2)) && byte.TryParse(new string(chArray, num, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out bytes[index]))
                    {
                        num++;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (chArray[num] == '_')
                {
                    bytes[index] = 0x20;
                }
                else
                {
                    bytes[index] = (byte) chArray[num];
                }
                num++;
                index++;
            }
            return new string(enc.GetChars(bytes, 0, index));
        }

        public static void Send(MailMessage msg)
        {
            Send(msg, false);
        }

        public static void Send(MailMessage msg, bool async)
        {
            SmtpClient smtp = new SmtpClient();
            string config = ConfigUtil.GetConfig("Smtp.Host", string.Empty);
            int num = ConfigUtil.GetConfig("Smtp.Port", 0);
            string userName = ConfigUtil.GetConfig("Smtp.User", string.Empty);
            string password = ConfigUtil.GetConfig("Smtp.Password", string.Empty);
            bool flag = ConfigUtil.GetConfig("Smtp.EnableSsl", false);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = flag;
            if (!string.IsNullOrEmpty(config))
            {
                smtp.Host = config;
            }
            if (num > 0)
            {
                smtp.Port = num;
            }
            if ((userName.Length > 0) & (password.Length > 0))
            {
                smtp.Credentials = new NetworkCredential(userName, password);
            }
            Send(msg, false, smtp);
        }

        public static void Send(MailMessage msg, bool async, SmtpClient smtp)
        {
            int intDefault = 0x7d0;
            string config = ConfigUtil.GetConfig("Smtp.OverrideEmailTo", string.Empty);
            if (config.Contains("@"))
            {
                if (msg.To.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    int num5 = msg.To.Count - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        builder.Append(msg.To[i].Address + ",");
                    }
                    msg.To.Clear();
                    msg.Headers.Add("Original-To", builder.ToString());
                }
                if (msg.CC.Count > 0)
                {
                    StringBuilder builder2 = new StringBuilder();
                    int num6 = msg.CC.Count - 1;
                    for (int j = 0; j <= num6; j++)
                    {
                        builder2.Append(msg.CC[j].Address + ",");
                    }
                    msg.CC.Clear();
                    msg.Headers.Add("Original-Cc", builder2.ToString());
                }
                if (msg.Bcc.Count > 0)
                {
                    StringBuilder builder3 = new StringBuilder();
                    int num7 = msg.Bcc.Count - 1;
                    for (int k = 0; k <= num7; k++)
                    {
                        builder3.Append(msg.Bcc[k].Address + ",");
                    }
                    msg.Bcc.Clear();
                    msg.Headers.Add("Original-Bcc", builder3.ToString());
                }
                msg.To.Add(new MailAddress(config));
            }
            try
            {
                if (async)
                {
                    smtp.SendAsync(msg, null);
                }
                else
                {
                    smtp.Send(msg);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Thread.Sleep(ConfigUtil.GetConfig("Smtp.RetryInterval", intDefault));
                smtp.Send(msg);
                ProjectData.ClearProjectError();
            }
        }
    }
}
