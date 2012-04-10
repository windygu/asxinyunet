/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-4-26
 * Time: 8:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net ;
using System.Text ;
using System.IO ;

namespace DotNet.Core.Web
{
	/// <summary>
	///  基本的web操作类库
	/// </summary>
	public class WebBasic
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
	}
}