/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-8-31
 * Time: 19:40
 * 
 * 文件工具类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Collections;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using ResouceEntity;

namespace ResouceCollector
{
	#region 资源类别 ResouceType
	/// <summary>
	/// 资源类别
	/// </summary>
	public enum ResouceType
	{
		/// <summary>
		/// 电子书
		/// </summary>
		EBook ,
		/// <summary>
		/// 视频教程
		/// </summary>
		Video ,
		/// <summary>
		/// 音频
		/// </summary>
		Audio ,
		/// <summary>
		/// 源代码
		/// </summary>
		SouceCode ,
		/// <summary>
		/// 软件
		/// </summary>
		SoftWare ,
		/// <summary>
		/// 音乐
		/// </summary>
		Music ,
		/// <summary>
		/// 电影
		/// </summary>
		Film ,
		/// <summary>
		/// 素材
		/// </summary>
		Matter ,
		/// <summary>
		/// 综合的
		/// </summary>
		Comprehensive
	}
	
	/// <summary>
	/// 文件后缀名
	/// </summary>
	public enum FileExtension
	{
		txt,
		doc,
		docx,
		xls,
		xlsx,
		rar,
		zip,
		ps,
		pdf,
		exe,
		wav,
		mp3,
		mp4,
		rm,
		wmv,
		asf,
		mpg,
		mkv,
		flv,
		rmvb,
		avi,
		jpg,
		swf,
		psd,
		bmp,
		png,
		ico,
		wps,
		html,
		chm,
		epub
	}
	#endregion
		
	
	/// <summary>
	///资源工具帮助类
	/// </summary>
	public class ResouceHelper
	{
		#region 常规变量字段
		/// <summary>
		/// 默认搜索路径
		/// </summary>
		public static string DefaultSearchPath = string .Empty ;
		
		/// <summary>
		/// 搜索路径集合
		/// </summary>
		public static List<string >  SearchPathString = new List<string > () ;
		
		//文件类型的后缀名
		public static string FileExtension_EBook = "txt-doc-docx-wps-pdf-chm-html-epub" ;
		public static string FileExtension_Video = "mp4-rm-wmv-asf-mpg-mkv-flv-rmvb-avi-swf" ;
		public static string FileExtension_Audio = "wav-mp3" ;
		public static string FileExtension_Matter = "jpg-psd-bmp-ico-png" ;
		public static string FileExtension_Others = "zip-rar-exe" ;
		
		#endregion
		
		#region 根据文件后缀名获取文件的类型 GetResouceTypeByFileExtension
		/// <summary>
		/// 根据文件后缀名获取文件的类型
		/// </summary>
		/// <param name="fileExtension">后缀名</param>
		/// <returns>返回文件的类型</returns>
		public static ResouceType GetResouceTypeByFileExtension(string fileExtension)
		{
			if (FileExtension_EBook.Contains (fileExtension )) {
				return ResouceType.EBook ;
			}
			else if (FileExtension_Video.Contains (fileExtension )) {
				return ResouceType.Video ;
			}
			else if (FileExtension_Audio .Contains (fileExtension )) {
				return ResouceType.Audio ;
			}
			else if (FileExtension_Matter .Contains (fileExtension )) {
				return ResouceType.Matter ;
			}
			else
				return ResouceType.Comprehensive ;
		}
		#endregion
		
		#region 对指定的目录进行搜索,主要是进行初级自动分类 SearchDirectory
		public static void SearchDirectory(string seachPath)
		{
			//检索所有目录，对文件进行分类，对目录名称和文件名进行分词,作为自动分类依据
		}
		#endregion

        #region 扫描目录获取文件信息并更新到数据库
        public static void ScanFolder(string folderName)
        {
            //扫描指定目录下的所有文件,并添加到数据库
            ArrayList resArray = new ArrayList();
            string[] files = Directory.GetFiles(folderName, "*");
            //将当前文件信息添加到数据库
            foreach (var item in files)
            {
                if (File.Exists(item))
                    GetFileInfo(item);//添加到数据库
            }
            Console.WriteLine("文件夹扫描完成:{0}", folderName);
            string[] folders = Directory.GetDirectories(folderName);
            //遍历所有文件夹
            foreach (var item in folders) ScanFolder(item);
        }

        public static void GetFileInfo(string fileName)
        {
            tb_resourceinfo model = new tb_resourceinfo();
            model.Md5 = MD5Hash(fileName);
            if (tb_resourceinfo.FindAllByName(tb_resourceinfo._.Md5, model.Md5, "", 0, 0).Count < 1)
            {
                model.PublishingCompany = "暂无";
                FileInfo fi = new FileInfo(fileName);
                model.Keywords = fi.Name;
                model.Author = "暂无";
                model.BigCategory = "暂无分类";
                model.SmallCategory = "暂无分类";
                model.Source = "网络";
                model.ContentIntroduce = "暂无介绍";
                model.Format = fi.Extension.Replace(".", "");
                model.ISBN = string.Empty;
                model.PublishingDate = DateTime.Now;
                model.Remark = string.Empty;
                model.ResourceName = fi.Name;
                model.ResourceScore = 7;
                model.Size = (int)(fi.Length / 1024);//Kb
                model.StorageLocation = fileName.Substring(1, fileName.Length - 1);//只存储相对位置，把盘符去掉               
                model.Insert();
            }
        }

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>        
        public static string MD5Hash(string fileName)
        {
            if (!File.Exists(fileName)) return string.Empty;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                System.Security.Cryptography.HashAlgorithm md5 = System.Security.Cryptography.MD5.Create();
                return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
            }
        }
        #endregion
	}
	
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
//		private static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
//			".NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

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