/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-6-12
 * Time: 10:01
 * 
 *主要用于CS程序模拟Web请求服务
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web ;

namespace DotNet.Tools.Web
{
         
	public static class Request
	{    
           public static CookieContainer cookie = new CookieContainer();
           public static string contentType = "application/x-www-form-urlencoded";
           public static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg," +
              " application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, " +
                "application/vnd.ms-powerpoint, application/msword, application/x-ms-application, " +
                "application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
            public static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
                ".NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

            /// <summary>
            /// 根据网址和编码获取源代码，源代码来自http://www.cnblogs.com/nuke/archive/2010/08/22/1805626.html
            /// </summary>
            /// <param name="url">网址</param>
            /// <param name="encoding">编码</param>
            /// <returns>源文件</returns>
            public static string GetHtmlEx(string url, Encoding encoding)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = userAgent;
                request.ContentType = contentType;
                request.CookieContainer = cookie;
                request.Accept = accept;
                request.Method = "get";

                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, encoding);
                String html = reader.ReadToEnd();
                response.Close();
                return html;
            }        

		#region 通过HttpWebRequest 发送请求(表单)		
		/// <summary>
		/// 通过HttpWebRequest 发送请求(表单)
		/// </summary>
		/// <param name="url">请求地址</param>
		/// <param name="requestParameter">请求参数para1=value1&para2=value2</param>
		/// <param name="method">post get</param>
		/// <param name="encoding">GB2312 UTF-8...</param>
		/// <returns>响应回返字符串</returns>
		public static string SubmitRequest(string url, string requestParameter, string requestMethod, Encoding encoding)
		{
			string result = String.Empty;
			#region Request部分
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);//新建一个HttpWebRequest
			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
			myHttpWebRequest.ContentLength = requestParameter.Length;
			myHttpWebRequest.Method = requestMethod;
			Stream myRequestStream = myHttpWebRequest.GetRequestStream();//获取Request流
			StreamWriter myStreamWriter = new StreamWriter(myRequestStream,encoding);
			myStreamWriter.Write(requestParameter);  //把参数写入HttpWebRequest的Request流
			myStreamWriter.Close();
			myRequestStream.Close();  //关闭打开对象
			#endregion
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); //提交获得响应
			#region Response部分
			Stream myResponseStream = myHttpWebResponse.GetResponseStream();//获取Response流
			StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
			result = myStreamReader.ReadToEnd();//把数据从HttpWebResponse的Response流中读出
			myStreamReader.Close();
			myResponseStream.Close();
			#endregion
			return result;			
		}
		#endregion

		#region 请求并获得cookie(表单)		
		/// <summary>
		/// 请求并获得cookie(表单)
		/// </summary>
		/// <param name="url">请求地址</param>
		/// <param name="requestParameter">请求参数para1=value1&para2=value2</param>
		/// <param name="requestMethod">post get</param>
		/// <param name="encoding">GB2312 UTF-8...</param>
		/// <param name="response">响应回返字符串</param>
		/// <returns>CookieContainer</returns>
		public static CookieContainer SubmitRequest(string url, string requestParameter, string requestMethod, Encoding encoding,out string response)
		{

			CookieContainer cookie = new CookieContainer(); //新建一个CookieContainer来存放Cookie集合
			#region Request部分
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);//新建一个HttpWebRequest
			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
			myHttpWebRequest.ContentLength = requestParameter.Length;
			myHttpWebRequest.Method = requestMethod;
			myHttpWebRequest.CookieContainer = cookie; //设置HttpWebRequest的CookieContainer///////
			Stream myRequestStream = myHttpWebRequest.GetRequestStream();//获取Request流
			StreamWriter myStreamWriter = new StreamWriter(myRequestStream, encoding);
			myStreamWriter.Write(requestParameter);  //把参数写入HttpWebRequest的Request流
			myStreamWriter.Close();
			myRequestStream.Close();  //关闭打开对象
			#endregion
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); //提交获得响应
			#region Response部分
			Stream myResponseStream = myHttpWebResponse.GetResponseStream();//获取Response流
			StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
			response = myStreamReader.ReadToEnd();//把数据从HttpWebResponse的Response流中读出
			myStreamReader.Close();
			myResponseStream.Close();
			#endregion
			return cookie;
		}
		#endregion
		
		#region 判断当前页面是否接收到了Post请求
		/// <summary>
		/// 判断当前页面是否接收到了Post请求
		/// </summary>
		/// <returns>是否接收到了Post请求</returns>
		public static bool IsPost()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("POST");
		}
		#endregion
		
		#region 判断当前页面是否接收到了Get请求
		/// <summary>
		/// 判断当前页面是否接收到了Get请求
		/// </summary>
		/// <returns>是否接收到了Get请求</returns>
		public static bool IsGet()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("GET");
		}
		#endregion

		#region  返回指定的服务器变量信息
		/// <summary>
		/// 返回指定的服务器变量信息
		/// </summary>
		/// <param name="strName">服务器变量名</param>
		/// <returns>服务器变量信息</returns>
		public static string GetServerString(string strName)
		{
			//
			if (HttpContext.Current.Request.ServerVariables[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.ServerVariables[strName].ToString();
		}
		#endregion
		
		#region 返回上一个页面的地址
		/// <summary>
		/// 返回上一个页面的地址
		/// </summary>
		/// <returns>上一个页面的地址</returns>
		public static string GetUrlReferrer()
		{
			string retVal = null;
			try
			{
				retVal = HttpContext.Current.Request.UrlReferrer.ToString();
			}
			catch { }
			if (retVal == null)
				return "";
			return retVal;
		}
		#endregion

		#region 得到当前完整主机头
		/// <summary>
		/// 得到当前完整主机头
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentFullHost()
		{
			HttpRequest request = System.Web.HttpContext.Current.Request;
			if (!request.Url.IsDefaultPort)
			{
				return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
			}
			return request.Url.Host;
		}
		#endregion

		#region  得到主机头
		/// <summary>
		/// 得到主机头
		/// </summary>
		/// <returns></returns>
		public static string GetHost()
		{
			return HttpContext.Current.Request.Url.Host;
		}
		#endregion

		#region 获取当前请求的原始 URL
		/// <summary>
		/// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
		/// </summary>
		/// <returns>原始 URL</returns>
		public static string GetRawUrl()
		{
			return HttpContext.Current.Request.RawUrl;
		}
		#endregion

		#region  判断当前访问是否来自浏览器软件
		/// <summary>
		/// 判断当前访问是否来自浏览器软件
		/// </summary>
		/// <returns>当前访问是否来自浏览器软件</returns>
		public static bool IsBrowserGet()
		{
			string[] BrowserName = { "ie", "opera", "netscape", "mozilla" };
			string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
			for (int i = 0; i < BrowserName.Length; i++)
			{
				if (curBrowser.IndexOf(BrowserName[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		#region 判断是否来自搜索引擎链接
		/// <summary>
		/// 判断是否来自搜索引擎链接
		/// </summary>
		/// <returns>是否来自搜索引擎链接</returns>
		public static bool IsSearchEnginesGet()
		{
			string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
			string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
			for (int i = 0; i < SearchEngine.Length; i++)
			{
				if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		#region 获得当前完整Url地址
		/// <summary>
		/// 获得当前完整Url地址
		/// </summary>
		/// <returns>当前完整Url地址</returns>
		public static string GetUrl()
		{
			return HttpContext.Current.Request.Url.ToString();
		}
		#endregion

		#region 获得指定Url参数的值
		/// <summary>
		/// 获得指定Url参数的值
		/// </summary>
		/// <param name="strName">Url参数</param>
		/// <returns>Url参数的值</returns>
		public static string GetQueryString(string strName)
		{
			if (HttpContext.Current.Request.QueryString[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.QueryString[strName];
		}
		#endregion
		
		#region 获得当前页面的名称
		/// <summary>
		/// 获得当前页面的名称
		/// </summary>
		/// <returns>当前页面的名称</returns>
		public static string GetPageName()
		{
			string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
			return urlArr[urlArr.Length - 1].ToLower();
		}
		#endregion

		#region 返回表单或Url参数的总个数
		/// <summary>
		/// 返回表单或Url参数的总个数
		/// </summary>
		/// <returns></returns>
		public static int GetParamCount()
		{
			return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
		}
		#endregion

		#region 获得指定表单参数的值
		/// <summary>
		/// 获得指定表单参数的值
		/// </summary>
		/// <param name="strName">表单参数</param>
		/// <returns>表单参数的值</returns>
		public static string GetFormString(string strName)
		{
			if (HttpContext.Current.Request.Form[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.Form[strName];
		}
		#endregion
		
		#region 获得Url或表单参数的值
		/// <summary>
		/// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
		/// </summary>
		/// <param name="strName">参数</param>
		/// <returns>Url或表单参数的值</returns>
		public static string GetString(string strName)
		{
			if ("".Equals(GetQueryString(strName)))
			{
				return GetFormString(strName);
			}
			else
			{
				return GetQueryString(strName);
			}
		}
		#endregion

		#region 获得当前页面客户端的IP
		/// <summary>
		/// 获得当前页面客户端的IP
		/// </summary>
		/// <returns>当前页面客户端的IP</returns>
		public static string GetIP()
		{
			string result = String.Empty;

			result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (null == result || result == String.Empty)
			{
				result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}

			if (null == result || result == String.Empty)
			{
				result = HttpContext.Current.Request.UserHostAddress;
			}

			if (null == result || result == String.Empty)
			{
				return "0.0.0.0";
			}
			return result;
		}
		#endregion

		#region 保存用户上传的文件
		/// <summary>
		/// 保存用户上传的文件
		/// </summary>
		/// <param name="path">保存路径</param>
		public static void SaveRequestFile(string path)
		{
			if (HttpContext.Current.Request.Files.Count > 0)
			{
				HttpContext.Current.Request.Files[0].SaveAs(path);
			}
		}
		#endregion
		
	}
}
