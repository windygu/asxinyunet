namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class HttpHelper
    {
        private string k1mUM9ocK;
        private int m7HRrMhfC;
        private string MnvNdaLNh;
        private int nBCwVbEfB;
        private System.Net.CookieContainer qCpqRb2bV;
        private string r4vfcKJvu;
        private int snJo0QVxt;
        private System.Text.Encoding yT4VNh4qe;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpHelper()
        {
            this.r4vfcKJvu = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd832);
            this.MnvNdaLNh = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd878);
            this.k1mUM9ocK = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdb10);
            this.yT4VNh4qe = System.Text.Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdbf8));
            this.snJo0QVxt = 0x3e8;
            this.nBCwVbEfB = 3;
            this.m7HRrMhfC = 0;
            this.qCpqRb2bV = new System.Net.CookieContainer();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpHelper(System.Net.CookieContainer cc)
        {
            this.r4vfcKJvu = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdc06);
            this.MnvNdaLNh = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdc4c);
            this.k1mUM9ocK = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdee4);
            this.yT4VNh4qe = System.Text.Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdfcc));
            this.snJo0QVxt = 0x3e8;
            this.nBCwVbEfB = 3;
            this.m7HRrMhfC = 0;
            this.qCpqRb2bV = cc;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpHelper(string contentType, string accept, string userAgent)
        {
            this.r4vfcKJvu = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdfda);
            this.MnvNdaLNh = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe020);
            this.k1mUM9ocK = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe2b8);
            this.yT4VNh4qe = System.Text.Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe3a0));
            this.snJo0QVxt = 0x3e8;
            this.nBCwVbEfB = 3;
            this.m7HRrMhfC = 0;
            this.r4vfcKJvu = contentType;
            this.MnvNdaLNh = accept;
            this.k1mUM9ocK = userAgent;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpHelper(System.Net.CookieContainer cc, string contentType, string accept, string userAgent)
        {
            this.r4vfcKJvu = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe3ae);
            this.MnvNdaLNh = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe3f4);
            this.k1mUM9ocK = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe68c);
            this.yT4VNh4qe = System.Text.Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe774));
            this.snJo0QVxt = 0x3e8;
            this.nBCwVbEfB = 3;
            this.m7HRrMhfC = 0;
            this.qCpqRb2bV = cc;
            this.r4vfcKJvu = contentType;
            this.MnvNdaLNh = accept;
            this.k1mUM9ocK = userAgent;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public CookieCollection GetCookieCollection(string cookieString)
        {
            CookieCollection cookies = new CookieCollection();
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe7ac), RegexOptions.IgnoreCase);
            foreach (Match match in regex.Matches(cookieString))
            {
                Cookie cookie = new Cookie(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[3].Value);
                cookies.Add(cookie);
            }
            return cookies;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetEncoding(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest) WebRequest.Create(url);
                request.Timeout = 0x4e20;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse) request.GetResponse();
                if ((response.StatusCode == HttpStatusCode.OK) && (response.ContentLength < 0x100000L))
                {
                    if ((response.ContentEncoding != null) && response.ContentEncoding.Equals(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe8a2), StringComparison.InvariantCultureIgnoreCase))
                    {
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress));
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                    }
                    string input = reader.ReadToEnd();
                    Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe8ae));
                    if (regex.IsMatch(input))
                    {
                        return regex.Match(input).Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe8f4)].Value;
                    }
                    if (response.CharacterSet != string.Empty)
                    {
                        return response.CharacterSet;
                    }
                    return System.Text.Encoding.Default.BodyName;
                }
            }
            catch
            {
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (request != null)
                {
                    request = null;
                }
            }
            return System.Text.Encoding.Default.BodyName;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHiddenKeyValue(string html, string key)
        {
            string str = "";
            Match match = new Regex(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe80e), key), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(html);
            if (match.Success)
            {
                str = match.Groups[1].Value;
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url)
        {
            return this.GetHtml(url, this.qCpqRb2bV, url);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url, string reference)
        {
            return this.GetHtml(url, this.qCpqRb2bV, reference);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url, System.Net.CookieContainer cookieContainer, string reference)
        {
            this.m7HRrMhfC++;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.CookieContainer = cookieContainer;
                request.ContentType = this.r4vfcKJvu;
                request.Referer = reference;
                request.Accept = this.MnvNdaLNh;
                request.UserAgent = this.k1mUM9ocK;
                request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe798);
                Stream responseStream = ((HttpWebResponse) request.GetResponse()).GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, this.yT4VNh4qe);
                string str = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                this.m7HRrMhfC = 0;
                return str;
            }
            catch (Exception)
            {
                if (this.m7HRrMhfC <= this.nBCwVbEfB)
                {
                    this.GetHtml(url, cookieContainer, reference);
                }
                this.m7HRrMhfC = 0;
                return string.Empty;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url, string postData, bool isPost)
        {
            string referer = "";
            return this.GetHtml(url, this.qCpqRb2bV, postData, isPost, referer);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url, System.Net.CookieContainer cookieContainer, string postData, bool isPost)
        {
            return this.GetHtml(url, cookieContainer, postData, isPost, url);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetHtml(string url, System.Net.CookieContainer cookieContainer, string postData, bool isPost, string referer)
        {
            if (string.IsNullOrEmpty(postData))
            {
                CookieCollection cookies = new CookieCollection();
                return this.GetHtml(url, cookieContainer, referer);
            }
            this.m7HRrMhfC++;
            try
            {
                HttpWebResponse response;
                byte[] bytes = System.Text.Encoding.Default.GetBytes(postData);
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.CookieContainer = cookieContainer;
                request.ContentType = this.r4vfcKJvu;
                request.Referer = referer;
                request.Accept = this.MnvNdaLNh;
                request.UserAgent = this.k1mUM9ocK;
                request.Method = isPost ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe78c) : kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe782);
                request.ContentLength = bytes.Length;
                request.AllowAutoRedirect = false;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                try
                {
                    response = (HttpWebResponse) request.GetResponse();
                }
                catch (WebException exception)
                {
                    response = (HttpWebResponse) exception.Response;
                }
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, this.yT4VNh4qe);
                string str = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                this.m7HRrMhfC = 0;
                return str;
            }
            catch (Exception)
            {
                if (this.m7HRrMhfC <= this.nBCwVbEfB)
                {
                    this.GetHtml(url, cookieContainer, postData, isPost);
                }
                this.m7HRrMhfC = 0;
                return string.Empty;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Stream GetStream(string url, System.Net.CookieContainer cookieContainer)
        {
            return this.GetStream(url, cookieContainer, url);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Stream GetStream(string url, System.Net.CookieContainer cookieContainer, string reference)
        {
            this.m7HRrMhfC++;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.CookieContainer = cookieContainer;
                request.ContentType = this.r4vfcKJvu;
                request.Referer = reference;
                request.Accept = this.MnvNdaLNh;
                request.UserAgent = this.k1mUM9ocK;
                request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe7a2);
                Stream responseStream = ((HttpWebResponse) request.GetResponse()).GetResponseStream();
                this.m7HRrMhfC = 0;
                return responseStream;
            }
            catch (Exception)
            {
                if (this.m7HRrMhfC <= this.nBCwVbEfB)
                {
                    CookieCollection cookies = new CookieCollection();
                    this.GetHtml(url, cookieContainer, url);
                }
                this.m7HRrMhfC = 0;
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetUrlError(string url)
        {
            int num = 200;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(new Uri(url));
                ServicePointManager.Expect100Continue = false;
                ((HttpWebResponse) request.GetResponse()).Close();
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    return num;
                }
                if (exception.Message.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe906)) > 0)
                {
                    return 500;
                }
                if (exception.Message.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe912)) > 0)
                {
                    return 0x191;
                }
                if (exception.Message.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe91e)) > 0)
                {
                    num = 0x194;
                }
            }
            catch
            {
                num = 0x191;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string RemoveHtml(string content)
        {
            string pattern = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe928);
            return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        public string Accept
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.MnvNdaLNh;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.MnvNdaLNh = value;
            }
        }

        public string ContentType
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.r4vfcKJvu;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.r4vfcKJvu = value;
            }
        }

        public System.Net.CookieContainer CookieContainer
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.qCpqRb2bV;
            }
        }

        public System.Text.Encoding Encoding
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.yT4VNh4qe;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.yT4VNh4qe = value;
            }
        }

        public int MaxTry
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.nBCwVbEfB;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.nBCwVbEfB = value;
            }
        }

        public int NetworkDelay
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                Random random = new Random();
                return (random.Next(this.snJo0QVxt / 0x3e8, (this.snJo0QVxt / 0x3e8) * 2) * 0x3e8);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.snJo0QVxt = value;
            }
        }

        public string UserAgent
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.k1mUM9ocK;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.k1mUM9ocK = value;
            }
        }
    }
}

