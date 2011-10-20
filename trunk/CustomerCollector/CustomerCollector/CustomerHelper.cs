using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace CustomerCollector
{
	/// <summary>
	/// 采集工具方法类，一些默认的字段，数组等
	/// </summary>
	class CustomerHelper
	{
		public static string[] RootClassName = {"工业品","消费品","原材料","服务商" };
			
		#region 根据URL地址获得用户名和用户类型
		/// <summary>
		/// 根据URL地址获得用户名和用户类型
		/// </summary>
		/// <param name="webURL">公司主页网址</param>
		/// <returns>字符串数组,第一个为用户名,第二个为类型</returns>
		public static string[] GetUserNameAndType(string webURL)
		{
			//http://daoreyoulu.cn.alibaba.com/
			//http://china.alibaba.com/company/detail/dlzcjx.html
			string[] res = new System.String [2] ;
			if (webURL.Contains (".cn.alibaba.com"))
			{
				//诚信通用户
				res [0] = webURL.Trim ().Split ('.')[0].Replace (@"http://","").Trim () ;
				res [1] = UserTypeE.Alibaba_CXT.ToString () ;
			}
			else if (webURL.Contains (@"china.alibaba.com/company"))
			{
				res [0] = webURL.Substring (webURL.Trim ().LastIndexOf ('/')+1).Replace (".html","").Trim ();
				res [1] = UserTypeE.Alibaba_Comm .ToString () ;
			}
			else //其他类型
			{
			}
			return res ;
		}
		#endregion		
			
	}
	
	#region 根据用户名和用户类型,获取采集网址(根据规则生成)
	public class CompanyUserModel
	{
		#region 字段名称
		string _userName ;
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName {
			get { return _userName; }
			set { _userName = value; }
		}
		InfoOriginE _origin ;
		/// <summary>
		/// 信息来源
		/// </summary>
		public InfoOriginE Origin {
			get { return _origin; }
			set { _origin = value; }
		}
		UserTypeE _userType ;
		/// <summary>
		/// 用户类型
		/// </summary>
		public UserTypeE UserType {
			get { return _userType; }
			set { _userType = value; }
		}
		string _mainPage ;
		/// <summary>
		/// 主页
		/// </summary>
		public string MainPage {
			get { return _mainPage; }
			set { _mainPage = value; }
		}
		string _companyIntroPage ;
		/// <summary>
		/// 公司介绍主页
		/// </summary>
		public string CompanyIntroPage {
			get { return _companyIntroPage; }
			set { _companyIntroPage = value; }
		}
		string _providerPage ;
		/// <summary>
		/// 供应产品主页
		/// </summary>
		public string ProviderPage {
			get { return _providerPage; }
			set { _providerPage = value; }
		}
		string _linkPage ;
		/// <summary>
		/// 联系方式主页
		/// </summary>
		public string LinkPage {
			get { return _linkPage; }
			set { _linkPage = value; }
		}
		string _registerPage ;
		/// <summary>
		/// 诚信档案主页
		/// </summary>
		public string RegisterPage {
			get { return _registerPage; }
			set { _registerPage = value; }
		}
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="infoOrigin">来源</param>
		/// <param name="userType">用户类型</param>
		public CompanyUserModel (string userName,InfoOriginE infoOrigin,UserTypeE userType)
		{
			this._userName = userName ;
			this._origin = infoOrigin ;
			this._userType = userType ;
		}
		#endregion
		
		#region 阿里巴巴2种类型的主要网址结构
		//http://china.alibaba.com/company/detail/pengluyu.html
		//http://china.alibaba.com/company/detail/intro/pengluyu.html
		//http://china.alibaba.com/company/offerlist/pengluyu.html
		//http://china.alibaba.com/company/detail/contact/pengluyu.html
		
		//http://dgjinming.cn.alibaba.com/
		//http://dgjinming.cn.alibaba.com/athena/offerlist/dgjinming-sale.html
		//http://dgjinming.cn.alibaba.com/athena/companyprofile/dgjinming.html
		//http://dgjinming.cn.alibaba.com/athena/contact/dgjinming.html
		//http://dgjinming.cn.alibaba.com/athena/bizreflist/dgjinming.html
		#endregion
		
		#region 根据用户名和类型获取主页面网址
		/// <summary>
		/// 根据用户名和类型获取主页面网址
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="infoOrigin">信息来源</param>
		/// <param name="userType">用户类型</param>
		/// <returns>主页面网址</returns>
		public static string GetMainPageURL(string userName,InfoOriginE infoOrigin,UserTypeE userType)
		{
			if (infoOrigin == InfoOriginE.AlibabaChina )
			{				
				if (userType ==UserTypeE.Alibaba_CXT )//阿里巴巴诚信通用户
				{
					return AlibabaInfo.PreURL + userName +AlibabaInfo.MainSuURL ;
				}
				else if (userType ==UserTypeE.Alibaba_Comm )//阿里巴巴普通用户
				{
					return AlibabaInfo.ComMainSu + userName + AlibabaInfo.SueURL ;
				}
				else
					return string.Empty ;
			}
			else if (infoOrigin== InfoOriginE.Hc360 )
			{
				return string.Empty ;
			}
			else 
			{
				return string.Empty ;
			}			
		}
		#endregion
		
		#region 根据用户名和类型获取公司介绍页面网址
		/// <summary>
		/// 根据用户名和类型获取公司介绍页面网址
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="infoOrigin">信息来源</param>
		/// <param name="userType">用户类型</param>
		/// <returns>公司介绍页面网址</returns>
		public static string GetCompanyIntroPageURL(string userName,InfoOriginE infoOrigin,UserTypeE userType)
		{
			if (infoOrigin == InfoOriginE.AlibabaChina )
			{				
				if (userType ==UserTypeE.Alibaba_CXT )//阿里巴巴诚信通用户
				{
					return AlibabaInfo.PreURL + userName +AlibabaInfo.MainSuURL_2 +
						@"companyprofile/"+userName +AlibabaInfo.SueURL ;
				}
				else if (userType ==UserTypeE.Alibaba_Comm )//阿里巴巴普通用户
				{
					return AlibabaInfo.ComMainSu + @"intro/"+ userName + AlibabaInfo.SueURL ;
				}
				else
					return string.Empty ;
			}
			else if (infoOrigin== InfoOriginE.Hc360 )
			{
				return string.Empty ;
			}
			else 
			{
				return string.Empty ;
			}			
		}
		#endregion
		
		#region 根据用户名和类型获取公司联系信息页面网址
		/// <summary>
		/// 根据用户名和类型获取公司联系信息页面网址
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="infoOrigin">信息来源</param>
		/// <param name="userType">用户类型</param>
		/// <returns>公司联系信息页面网址</returns>
		public static string GetLinkPageURL(string userName,InfoOriginE infoOrigin,UserTypeE userType)
		{
			if (infoOrigin == InfoOriginE.AlibabaChina )
			{				
				if (userType ==UserTypeE.Alibaba_CXT )//阿里巴巴诚信通用户
				{
					return AlibabaInfo.PreURL + userName +AlibabaInfo.MainSuURL_2 +
						@"contact/"+userName +AlibabaInfo.SueURL ;
				}
				else if (userType ==UserTypeE.Alibaba_Comm )//阿里巴巴普通用户
				{
					return AlibabaInfo.ComMainSu + @"contact/"+ userName + AlibabaInfo.SueURL ;
				}
				else
					return string.Empty ;
			}
			else if (infoOrigin== InfoOriginE.Hc360 )
			{
				return string.Empty ;
			}
			else 
			{
				return string.Empty ;
			}			
		}
		#endregion
		
		#region 根据用户名和类型获取诚信档案页面网址
		/// <summary>
		/// 根据用户名和类型获取诚信档案页面网址
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="infoOrigin">信息来源</param>
		/// <param name="userType">用户类型</param>
		/// <returns>诚信档案页面网址</returns>
		public static string GetRegisterPageURL(string userName,InfoOriginE infoOrigin,UserTypeE userType)
		{
			if (infoOrigin == InfoOriginE.AlibabaChina )
			{				
				if (userType ==UserTypeE.Alibaba_CXT )//阿里巴巴诚信通用户
				{
					return AlibabaInfo.PreURL + userName +AlibabaInfo.MainSuURL_2 +
						@"bizreflist/"+userName +AlibabaInfo.SueURL ;
				}				
				else
					return string.Empty ;
			}
			else if (infoOrigin== InfoOriginE.Hc360 )
			{
				return string.Empty ;
			}
			else 
			{
				return string.Empty ;
			}			
		}
		#endregion
	}
	#endregion
	
	#region 获取网页源代码
	/// <summary>
	/// 获取网页源代码
	/// </summary>
	public class CaptureWebSite
	{
		private static CookieContainer cookie = new CookieContainer();
		private static string contentType = "application/x-www-form-urlencoded";
		private static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg," +
			" application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, " +
			"application/vnd.ms-powerpoint, application/msword, application/x-ms-application, " +
			"application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
		private static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
			".NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

		/// <summary>
		/// 获取网址的源代码
		/// </summary>
		/// <param name="url">网址</param>
		/// <returns>该网址的源代码 html格式</returns>
		public static string GetHtmlInfoFromURL(string url)
		{
			System.Net.WebClient aWebClient = new System.Net.WebClient();
			aWebClient.Encoding = System.Text.Encoding.Default;
			return aWebClient.DownloadString(url);
		}

		/// <summary>
		/// 根据网址和编码获取源代码，源代码来自http://www.cnblogs.com/nuke/archive/2010/08/22/1805626.html
		/// </summary>
		/// <param name="url">网址</param>
		/// <param name="encoding">编码</param>
		/// <returns>源文件</returns>
		public static string GetHtmlEx(string url, Encoding encoding)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.UserAgent = "Googlebot/2.1 (+http://www.google.com/bot.html)" ;
			request.ContentType = contentType;
			request.CookieContainer = cookie;
			request.Accept = accept;
			request.Method = "get";
//			WebProxy proxy = new WebProxy();                                     
//			proxy.Address = new Uri("60.171.159.167:4340");             //網關服務器:端口
//			proxy.Credentials = new NetworkCredential("ipfreetest", "loveeb");     //用戶名,密碼
//			hwr.UseDefaultCredentials = true;                                     //啟用網關認証
//			request.Proxy = proxy ;

			WebResponse response = request.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream, encoding);
			String html = reader.ReadToEnd();
			response.Close();
			return html;
		}
		/// <summary>
		/// 根据网址和编码获取网页源代码
		/// </summary>
		public static HtmlDocument GetHtmlDocument(string URL,Encoding textEncoding)
		{
			HtmlWeb web = new HtmlWeb();
			string htmlText = CaptureWebSite.GetHtmlEx (URL ,textEncoding ) ;
			HtmlDocument doc = new HtmlDocument () ;
			doc.LoadHtml (htmlText ) ;
			return doc ;
		}
	}
	#endregion
}