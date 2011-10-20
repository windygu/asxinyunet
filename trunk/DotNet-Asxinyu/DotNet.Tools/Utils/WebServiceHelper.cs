namespace Utils
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Web;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary><para>　</para>
    /// 类名：常用工具类——WebService类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2010-01-15</para><para>---------------------------------------------------------------------------------------------------------</para><para>　QueryGetWebService：通过SOAP协议调用WebService【重点使用】</para><para>　QueryPostWebService：采用Post方式调用WebService</para><para>　QueryGetWebService：采用Get方式调用WebService</para><para>　＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝====================================</para><para>　使用方法：</para><para>　【WebService返回如果是表格则需要用DataSet转为XML:DataTableToXml()返回XML】</para><para>　1、定义WebService信息：Utils.WebServiceHelper.WebServiceInfo Info = new Utils.WebServiceHelper.WebServiceInfo();</para><para>　2、定义WebService服务地址： Info.WebServiceUrl = "http://127.0.0.1/service";【结尾不用带/】</para><para>　3、定义WebService服务文件名称：Info.WebServiceName = "Kenny";【不用带.asmx】</para><para>　4、定义参数希哈表： HashTable[] Para = new HashTable[];</para><para>　5、将参数添加到希哈表中[注意参数名要与webservice中定义的行参名相同]：HashTable["UserId"] =UserId ;HashTable["Password"] =Password ;</para><para>　6、调用WebService中方法，XmlDocument doc = Utils.WebServiceHelper.QuerySoapWebService(Info, "HelloWorldSoap", HT);</para><para>　7、获取XML的值：doc.InnerXml;</para><para>　8、将XML值可转为DataTable:DataTable DT = Utils.ConvertHelper.XmlToDataTable(doc.InnerXml);</para></summary>
    public class WebServiceHelper
    {
        private static Hashtable _xee3558ea90d9abf8 = new Hashtable();

        /// <summary>采用Get方式调用WebService</summary>
        /// <param name="WebServiceInfos">WebService服务信息</param>
        /// <param name="MethodName">方法名</param>
        /// <param name="Para">参数希哈表:参数顺序和名称必须和方法中参数一致</param>
        /// <returns></returns>
        public static XmlDocument QueryGetWebService(WebServiceInfo WebServiceInfos, string MethodName, Hashtable Para)
        {
            string[] strArray = new string[] { WebServiceInfos.WebServiceUrl, "/", WebServiceInfos.WebServiceName, ".asmx/", MethodName, "?", xdbaaa863ec41d9d4(Para) };
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Concat(strArray));
            do
            {
                request.Method = "GET";
                if (0 != 0) goto Label_0086;
            }
            while (0x7fffffff == 0);
            request.ContentType = "application/x-www-form-urlencoded";
            x860f9d20048bb598(request);
        Label_0086:
            return x3b6667526cb8c924(request.GetResponse());
        }

        /// <summary>采用Post方式调用WebService</summary>
        /// <param name="WebServiceInfos">WebService服务信息</param>
        /// <param name="MethodName">方法名</param>
        /// <param name="Para">参数希哈表:参数顺序和名称必须和方法中参数一致</param>
        /// <returns></returns>
        public static XmlDocument QueryPostWebService(WebServiceInfo WebServiceInfos, string MethodName, Hashtable Para)
        {
            string[] strArray = new string[5];
            strArray[0] = WebServiceInfos.WebServiceUrl;
            if (3 != 0)
            {
                strArray[1] = "/";
                strArray[2] = WebServiceInfos.WebServiceName;
                strArray[3] = ".asmx/";
                if (0xff == 0) goto Label_008E;
            }
        Label_002F:
            strArray[4] = MethodName;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Concat(strArray));
            if (15 != 0)
            {
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                x860f9d20048bb598(request);
                byte[] buffer = xbf98a24df1a5313a(Para);
                x31d80aa653591515(request, buffer);
                if (15 == 0) goto Label_002F;
            }
        Label_008E:
            return x3b6667526cb8c924(request.GetResponse());
        }

        /// <summary>通过SOAP协议调用WebService【重点使用】</summary>
        /// <param name="WebServiceInfos">WebService服务信息</param>
        /// <param name="MethodName">方法名</param>
        /// <param name="Para">参数希哈表:参数顺序和名称必须和方法中参数一致</param>
        /// <returns></returns>
        public static XmlDocument QuerySoapWebService(WebServiceInfo WebServiceInfos, string MethodName, Hashtable Para)
        {
            if (_xee3558ea90d9abf8.ContainsKey(WebServiceInfos.WebServiceUrl + "/" + WebServiceInfos.WebServiceName + ".asmx")) return x9bb1b6ae65c70487(WebServiceInfos, MethodName, Para, _xee3558ea90d9abf8[WebServiceInfos.WebServiceUrl + "/" + WebServiceInfos.WebServiceName + ".asmx"].ToString());
            return x9bb1b6ae65c70487(WebServiceInfos, MethodName, Para, x5a52c0bff6f4a9c4(WebServiceInfos.WebServiceUrl + "/" + WebServiceInfos.WebServiceName + ".asmx"));
        }

        private static string x2f50d7d5fe9ce2dc(object xde5a5bc74acf4615)
        {
            XmlDocument document;
            XmlSerializer serializer = new XmlSerializer(xde5a5bc74acf4615.GetType());
            MemoryStream stream = new MemoryStream();
        Label_004E:
            serializer.Serialize((Stream) stream, xde5a5bc74acf4615);
        Label_001D:
            document = new XmlDocument();
            document.LoadXml(Encoding.UTF8.GetString(stream.ToArray()));
            if (document.DocumentElement != null) return document.DocumentElement.InnerXml;
            if (0xff != 0)
            {
                if (0x7fffffff != 0) return xde5a5bc74acf4615.ToString();
            }
            else
                goto Label_001D;
            goto Label_004E;
        }

        private static void x31d80aa653591515(HttpWebRequest x6a4d36d60e4f5261, byte[] x4a3f0a05c02f235f)
        {
            x6a4d36d60e4f5261.ContentLength = x4a3f0a05c02f235f.Length;
            Stream requestStream = x6a4d36d60e4f5261.GetRequestStream();
            requestStream.Write(x4a3f0a05c02f235f, 0, x4a3f0a05c02f235f.Length);
            requestStream.Close();
        }

        private static XmlDocument x3b6667526cb8c924(WebResponse xe464d907306ccb86)
        {
            StreamReader reader = new StreamReader(xe464d907306ccb86.GetResponseStream(), Encoding.UTF8);
            string xml = reader.ReadToEnd();
            reader.Close();
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return document;
        }

        private static byte[] x3d26f9c9ae976df0(Hashtable x12ee810c7612046c, string xf0aa16e66df95699, string x36d12ad1eed49cd3)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"></soap:Envelope>");
            xa264dc3e55e69436(document);
            XmlElement newChild = document.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlElement element2 = document.CreateElement(x36d12ad1eed49cd3);
            element2.SetAttribute("xmlns", xf0aa16e66df95699);
        Label_004A:
            foreach (string str in x12ee810c7612046c.Keys)
            {
                XmlElement element3 = document.CreateElement(str);
                element3.InnerXml = x2f50d7d5fe9ce2dc(x12ee810c7612046c[str]);
                do
                {
                    element2.AppendChild(element3);
                }
                while (0 != 0);
            }
            newChild.AppendChild(element2);
            if (0 == 0)
            {
                if (0 != 0) goto Label_004A;
                document.DocumentElement.AppendChild(newChild);
            }
            return Encoding.UTF8.GetBytes(document.OuterXml);
        }

        private static string x5a52c0bff6f4a9c4(string x1748aa94a2144ad8)
        {
            XmlDocument document;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(x1748aa94a2144ad8 + "?WSDL");
            x860f9d20048bb598(request);
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            if (0 == 0)
            {
                if (0 == 0) document = new XmlDocument();
                document.LoadXml(reader.ReadToEnd());
                reader.Close();
            }
            return document.SelectSingleNode("//@targetNamespace").Value;
        }

        private static void x860f9d20048bb598(HttpWebRequest x6a4d36d60e4f5261)
        {
            x6a4d36d60e4f5261.Credentials = CredentialCache.DefaultCredentials;
            x6a4d36d60e4f5261.Timeout = 0x2710;
        }

        private static XmlDocument x9bb1b6ae65c70487(WebServiceInfo xc4cef3944c93681e, string x36d12ad1eed49cd3, Hashtable xb0d0149484e84c46, string xf0aa16e66df95699)
        {
            HttpWebRequest request;
            XmlDocument document;
            _xee3558ea90d9abf8[xc4cef3944c93681e.WebServiceUrl + "/" + xc4cef3944c93681e.WebServiceName] = xf0aa16e66df95699;
            if (0 == 0) goto Label_0135;
        Label_00AD:
            request.Method = "POST";
            if (0 == 0)
            {
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers.Add("SOAPAction", "\"" + xf0aa16e66df95699 + (xf0aa16e66df95699.EndsWith("/") ? "" : "/") + x36d12ad1eed49cd3 + "\"");
                x860f9d20048bb598(request);
                if (0 != 0) goto Label_0135;
                byte[] buffer = x3d26f9c9ae976df0(xb0d0149484e84c46, xf0aa16e66df95699, x36d12ad1eed49cd3);
                x31d80aa653591515(request, buffer);
                document = new XmlDocument();
            }
            XmlDocument document2 = new XmlDocument();
            document = x3b6667526cb8c924(request.GetResponse());
            if (0 == 0)
            {
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
                nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                document2.LoadXml("<root>" + document.SelectSingleNode("//soap:Body/*/*", nsmgr).InnerXml + "</root>");
                xa264dc3e55e69436(document2);
            }
            if (0 == 0) return document2;
        Label_0135:
            request = (HttpWebRequest) WebRequest.Create(xc4cef3944c93681e.WebServiceUrl + "/" + xc4cef3944c93681e.WebServiceName + ".asmx");
            if (-2 != 0) goto Label_00AD;
            return document2;
        }

        private static void xa264dc3e55e69436(XmlDocument x6beba47238e0ade6)
        {
            XmlDeclaration newChild = x6beba47238e0ade6.CreateXmlDeclaration("1.0", "utf-8", null);
            x6beba47238e0ade6.InsertBefore(newChild, x6beba47238e0ade6.DocumentElement);
        }

        private static byte[] xbf98a24df1a5313a(Hashtable x12ee810c7612046c) { return Encoding.UTF8.GetBytes(xdbaaa863ec41d9d4(x12ee810c7612046c)); }

        private static string xdbaaa863ec41d9d4(Hashtable x12ee810c7612046c)
        {
            StringBuilder builder = new StringBuilder();
            IEnumerator enumerator = x12ee810c7612046c.Keys.GetEnumerator();
            try
            {
                string str;
                goto Label_003F;
            Label_0014:
                if (0 != 0) goto Label_006B;
            Label_0017:
                builder.Append(HttpUtility.UrlEncode(str) + "=" + HttpUtility.UrlEncode(x12ee810c7612046c[str].ToString()));
            Label_003F:
                if (enumerator.MoveNext()) goto Label_006B;
                goto Label_0095;
            Label_0049:
                if (-2 != 0) goto Label_005E;
            Label_0050:
                builder.Append("&");
                goto Label_0017;
            Label_005E:
                if (builder.Length > 0) goto Label_0050;
                goto Label_0014;
            Label_006B:
                str = (string) enumerator.Current;
                goto Label_0049;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (2 != 0) goto Label_0091;
            Label_0089:
                disposable.Dispose();
                goto Label_0094;
            Label_0091:
                if (disposable != null) goto Label_0089;
            Label_0094:;
            }
        Label_0095:
            return builder.ToString();
        }

        /// <summary>WebService代理服务的服务器名及方法名</summary>
        public class WebServiceInfo
        {
            private string _xe637dbc361b14e59 = "http://127.0.0.1";
            [CompilerGenerated]
            private string x181184453c24942a;

            /// <summary>WebService服务名，如：UserService【结尾不用带.asmx】</summary>
            public string WebServiceName { [CompilerGenerated]
            get { return this.x181184453c24942a; } [CompilerGenerated]
            set { this.x181184453c24942a = value; } }

            /// <summary>WebService的服务器地址：默认：http://127.0.0.1【结尾不用带/】</summary>
            public string WebServiceUrl { get { return this._xe637dbc361b14e59; } set { this._xe637dbc361b14e59 = value; } }
        }
    }
}
