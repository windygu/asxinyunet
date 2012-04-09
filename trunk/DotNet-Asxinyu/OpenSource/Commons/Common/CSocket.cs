namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class CSocket
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] DealWithFrame(string url, string content)
        {
            return OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5cd0), url, content);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] DealWithIFrame(string url, string content)
        {
            return OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5d7a), url, content);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHtmlByUrl(string sUrl)
        {
            return GetHtmlByUrl(sUrl, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a92));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHtmlByUrl(string sUrl, string sCoding)
        {
            return GetHtmlByUrl(ref sUrl, sCoding);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHtmlByUrl(ref string sUrl, string sCoding)
        {
            string input = "";
            try
            {
                HttpWebResponse response = mi5qIK3te(sUrl);
                if (response == null)
                {
                    return input;
                }
                sUrl = response.ResponseUri.AbsoluteUri;
                Stream responseStream = response.GetResponseStream();
                byte[] bytes = lWvfFeZUE(responseStream);
                responseStream.Close();
                responseStream.Dispose();
                string name = "";
                if (((sCoding == null) || (sCoding == "")) || (sCoding.ToLower() == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a9e)))
                {
                    string responseHeader = response.GetResponseHeader(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5aaa));
                    response.Close();
                    Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5ac6), RegexOptions.IgnoreCase);
                    Match match = regex.Match(responseHeader);
                    name = (match.Captures.Count != 0) ? match.Result(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5b0a)) : "";
                    if (name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5b22))
                    {
                        name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5b2a);
                    }
                    if (name == "")
                    {
                        input = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5b38)).GetString(bytes);
                        match = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5b48), RegexOptions.IgnoreCase).Match(input);
                        if (match.Captures.Count == 0)
                        {
                            return input;
                        }
                        name = match.Result(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5c18));
                    }
                }
                else
                {
                    response.Close();
                    name = sCoding.ToLower();
                }
                try
                {
                    input = Encoding.GetEncoding(name).GetString(bytes);
                }
                catch (ArgumentException)
                {
                    input = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5c30)).GetString(bytes);
                }
            }
            catch
            {
                input = "";
            }
            return input;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<KeyValuePair<int, string>> GetHtmlByUrlList(List<KeyValuePair<int, string>> listUrl, string sCoding)
        {
            Exception exception;
            string str3;
            int num = int.Parse(ConfigurationManager.AppSettings[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e4e)]);
            StringBuilder builder = new StringBuilder();
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            int offset = 0;
            Socket socket = null;
            IPHostEntry hostEntry = null;
            try
            {
                KeyValuePair<int, string> pair2 = listUrl[0];
                Uri uri = new Uri(pair2.Value.ToString());
                try
                {
                    hostEntry = Dns.GetHostEntry(uri.Host);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw exception;
                }
                IPAddress address = hostEntry.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(address, uri.Port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) {
                    SendTimeout = num,
                    ReceiveTimeout = num
                };
                try
                {
                    socket.Connect(remoteEP);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw exception;
                }
                foreach (KeyValuePair<int, string> pair in listUrl)
                {
                    uri = new Uri(pair.Value);
                    string s = string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e6c), HttpUtility.UrlDecode(uri.PathAndQuery), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e78), uri.Host, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x605e), '\0' });
                    byte[] bytes = Encoding.GetEncoding(sCoding).GetBytes(s);
                    offset = socket.Send(bytes);
                    if (offset == 0)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        return list;
                    }
                    byte[] buffer = new byte[0x800];
                    byte num3 = Convert.ToByte('\x007f');
                    do
                    {
                        int num4 = 0;
                        try
                        {
                            offset = socket.Receive(buffer, buffer.Length - 1, SocketFlags.None);
                        }
                        catch (Exception exception3)
                        {
                            exception = exception3;
                            string message = exception.Message;
                            offset = -1;
                        }
                        if (offset <= 0)
                        {
                            break;
                        }
                        if (buffer[offset - 1] > num3)
                        {
                            for (int i = offset - 1; i >= 0; i--)
                            {
                                if (buffer[i] <= num3)
                                {
                                    break;
                                }
                                num4++;
                            }
                            if ((num4 % 2) == 1)
                            {
                                num4 = socket.Receive(buffer, offset, 1, SocketFlags.None);
                                if (num4 < 0)
                                {
                                    break;
                                }
                                offset += num4;
                            }
                        }
                        else
                        {
                            buffer[offset] = 0;
                        }
                        str3 = Encoding.GetEncoding(sCoding).GetString(buffer, 0, offset);
                        builder.Append(str3);
                    }
                    while (offset > 0);
                    list.Add(new KeyValuePair<int, string>(pair.Key, builder.ToString()));
                    builder = null;
                    builder = new StringBuilder();
                }
            }
            catch (Exception exception4)
            {
                exception = exception4;
                str3 = exception.Message;
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch
                {
                }
            }
            finally
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch
                {
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHttpHead(string sUrl)
        {
            string str = "";
            Uri requestUri = new Uri(sUrl);
            try
            {
                WebHeaderCollection headers = WebRequest.Create(requestUri).GetResponse().Headers;
                string[] allKeys = headers.AllKeys;
                foreach (string str2 in allKeys)
                {
                    string str4 = str;
                    str = str4 + str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5cc2) + headers[str2] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5cc8);
                }
            }
            catch
            {
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static PageType GetPageType(string sUrl, ref string sHtml)
        {
            PageType hTML = PageType.HTML;
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x606a), RegexOptions.IgnoreCase);
            Match match = regex.Match(sHtml);
            if (match.Captures.Count != 0)
            {
                match = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x610a), RegexOptions.IgnoreCase).Match(match.Captures[0].Value);
                if (match.Captures.Count > 0)
                {
                    string url = CRegex.GetUrl(sUrl, match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x618a)].Value);
                    sHtml = GetHtmlByUrl(url);
                    hTML = PageType.RSS;
                }
                return hTML;
            }
            regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6196), RegexOptions.IgnoreCase);
            if (regex.Match(sHtml).Captures.Count > 0)
            {
                hTML = PageType.RSS;
            }
            return hTML;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static byte[] lWvfFeZUE(Stream stream1)
        {
            ArrayList list = new ArrayList();
            try
            {
                byte[] buffer = new byte[0x1000];
                for (int i = stream1.Read(buffer, 0, 0x1000); i > 0; i = stream1.Read(buffer, 0, 0x1000))
                {
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(buffer[j]);
                    }
                }
            }
            catch
            {
            }
            return (byte[]) list.ToArray(Type.GetType(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5ca8)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HttpWebResponse mi5qIK3te(string text1)
        {
            int num = 0x2710;
            bool flag = false;
            bool flag2 = false;
            Uri requestUri = new Uri(text1);
        Label_0019:;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUri);
                request.MaximumResponseHeadersLength = -1;
                request.ReadWriteTimeout = 0x1d4c0;
                request.Timeout = num;
                request.MaximumAutomaticRedirections = 50;
                request.MaximumResponseHeadersLength = 5;
                request.AllowAutoRedirect = true;
                if (flag)
                {
                    request.CookieContainer = new CookieContainer();
                }
                request.UserAgent = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5c40);
                return (HttpWebResponse) request.GetResponse();
            }
            catch (WebException)
            {
                if (!flag2)
                {
                    flag2 = true;
                    flag = true;
                    goto Label_0019;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string[] OBHMaLtRG(string text1, string text3, string text2)
        {
            ArrayList list = new ArrayList();
            Regex regex = new Regex(text1, RegexOptions.IgnoreCase);
            for (Match match = regex.Match(text2); match.Success; match = match.NextMatch())
            {
                list.Add(CRegex.GetUrl(text3, match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e26)].Value));
            }
            return (string[]) list.ToArray(Type.GetType(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e30)));
        }

        public enum PageType
        {
            HTML,
            RSS
        }
    }
}

