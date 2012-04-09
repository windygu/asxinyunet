namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class HttpWebRequestHelper
    {
        private CookieContainer mi5qIK3te;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpWebRequestHelper()
        {
            this.mi5qIK3te = new CookieContainer();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HttpWebRequestHelper(CookieContainer cookie)
        {
            this.mi5qIK3te = cookie;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Get(string uri)
        {
            return this.Get(uri, uri, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b42));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Get(string uri, string refererUri)
        {
            return this.Get(uri, refererUri, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b52));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Get(string uri, string refererUri, string encodingName)
        {
            return this.Get(uri, refererUri, encodingName, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Get(string uri, string refererUri, string encodingName, WebProxy webproxy)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.ContentType = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b62) + encodingName;
            request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b8a);
            request.CookieContainer = this.mi5qIK3te;
            if (null != webproxy)
            {
                request.Proxy = webproxy;
                if (null != webproxy.Credentials)
                {
                    request.UseDefaultCredentials = true;
                }
            }
            if (!string.IsNullOrEmpty(refererUri))
            {
                request.Referer = refererUri;
            }
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(encodingName)))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] GetBytes(string uri)
        {
            return this.GetBytes(uri, uri);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] GetBytes(string uri, string refererUri)
        {
            return this.GetBytes(uri, refererUri, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] GetBytes(string uri, string refererUri, WebProxy webproxy)
        {
            byte[] buffer2;
            byte[] buffer = new byte[0x400];
            using (Stream stream = this.GetStream(uri, refererUri, webproxy))
            {
                using (MemoryStream stream2 = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, buffer.Length);
                        stream2.Write(buffer, 0, count);
                    }
                    while (count != 0);
                    buffer2 = stream2.ToArray();
                }
            }
            return buffer2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Stream GetStream(string uri)
        {
            return this.GetStream(uri, uri);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Stream GetStream(string uri, string refererUri)
        {
            return this.GetStream(uri, refererUri, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Stream GetStream(string uri, string refererUri, WebProxy webproxy)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b94);
            request.CookieContainer = this.mi5qIK3te;
            if (null != webproxy)
            {
                request.Proxy = webproxy;
                if (null != webproxy.Credentials)
                {
                    request.UseDefaultCredentials = true;
                }
            }
            if (!string.IsNullOrEmpty(refererUri))
            {
                request.Referer = refererUri;
            }
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                return response.GetResponseStream();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Post(string uri, string postData)
        {
            return this.Post(uri, uri, postData, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b9e));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Post(string uri, string refererUri, string postData)
        {
            return this.Post(uri, refererUri, postData, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6bae));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Post(string uri, string refererUri, string postData, string encodingName)
        {
            return this.Post(uri, refererUri, postData, encodingName, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Post(string uri, string refererUri, string postData, string encodingName, WebProxy webproxy)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.Accept = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6bbe);
            request.Headers.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6bc8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6bea));
            request.ContentType = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6bf8);
            request.Headers.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6c3e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6c4e));
            request.Headers.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6c58), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6c7a));
            request.UserAgent = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6c98);
            request.Headers.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6d7c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6d9a));
            request.CookieContainer = this.mi5qIK3te;
            request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6dae);
            if (!string.IsNullOrEmpty(refererUri))
            {
                request.Referer = refererUri;
            }
            if (null != webproxy)
            {
                request.Proxy = webproxy;
                if (null != webproxy.Credentials)
                {
                    request.UseDefaultCredentials = true;
                }
            }
            Encoding encoding = Encoding.GetEncoding(encodingName);
            byte[] bytes = encoding.GetBytes(postData);
            request.ContentLength = bytes.Length;
            StringBuilder builder = new StringBuilder();
            if (this.mi5qIK3te != null)
            {
                CookieCollection cookies = this.mi5qIK3te.GetCookies(request.RequestUri);
                foreach (Cookie cookie in cookies)
                {
                    builder.Append(cookie + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6dba));
                }
            }
            if (builder.Length > 0)
            {
                DateTime time = new DateTime(0x7b2, 1, 1);
                long num = DateTime.UtcNow.Ticks - time.Ticks;
                num /= 0x2710L;
                request.Headers.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6dc0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6dd0) + num.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6dfa) + builder.ToString());
            }
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                using (Stream stream2 = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream2, encoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}

