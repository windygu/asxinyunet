/*
 * Created by SharpDevelop.
 * User: asxinyu
 * Date: 2011-9-1
 * Time: 21:23
 * 
 * Verycd.com资源网
 */
using System;
using System.Web ;
using System.Text ;
using HtmlAgilityPack ;
using ResouceEntity ;
using System.Collections;
using System.Collections.Generic ;

namespace ResouceCollector
{
	/// <summary>
	/// Verycd.com 资源网工具类
	/// </summary>
	public class VeryCdResouce
	{
		public static void Test()
		{
			string url = @"http://www.verycd.com/topics/2900979/";
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (url ,VerycdEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes ("//@ed2k" ) ;
			for (int i = 0; i < hc.Count ; i++) {
				Console.WriteLine (hc[i ].InnerText.Trim ()) ;
			}
		}
		
		#region 静态变量
		public static string xPath_TypePageList = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[2]/dl[1]/dd" ;
		public static string xPath_ResouceList  = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[2]/div[2]/ol[1]/li";
		public static string xPath_ResouceInfo  = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[1]/div[6]/div[1]/div[2]/table[1]/tr";
		public static string verycdWebSite =@"http://www.verycd.com" ;
		public static Encoding VerycdEncoding = Encoding.UTF8 ;
		
		#endregion

        #region 采集页面的所有ed2k链接
        public static void GetAllEd2kLink(string url)
        {
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(url , VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes("//@ed2k");
            foreach (var item in hc )
            {
                //分析链接，没有重复，则加入数据库
                //Console.Write(item.InnerText);
                //Console.WriteLine(":"+item.Attributes["ed2k"].Value.ToString ());
            }
        }
        #endregion

        #region 根据大类资源网址获取资源集合列表网址
        //根据大类资源网址获取资源集合列表网址
		public static void GetTypePageList(string URL,string FirName,string SubClassName,ResouceType resType)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (URL ,VerycdEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes (xPath_TypePageList ) ;
			for (int i = 0; i < hc.Count ; i++) {
				try
				{
					tb_fistclasslist model = new tb_fistclasslist () ;
					model.WebURL = (verycdWebSite + hc[i].SelectSingleNode (@"a[1]").Attributes["href"].Value.Trim ()) ;
					model.ClassName = FirName ;
					model.SubClassName = SubClassName ;
					model.CollectionMark = 0 ;
					model.InfoOrigin = "VeryCd" ;
					model.Remark = string.Empty ;
					model.ResouceType = resType.ToString () ;
					model.UpdateTime = DateTime.Now ;
					model.Save () ;
				}
				catch (Exception err)
				{
					continue ;
				}
			}
		}
		#endregion

		#region 根据资源集合列表网址获取单独资源的列表
		//根据资源集合列表网址获取单独资源的列表
		public static void GetPageResouceList(tb_fistclasslist firClassListModel)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (firClassListModel.WebURL ,VerycdEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes (xPath_ResouceList ) ;
			firClassListModel.CollectionMark = 1 ;
			firClassListModel.Update () ;
			for (int i = 0; i < hc.Count ; i++) {
				try
				{
					tb_resoucepageslist model = new tb_resoucepageslist () ;
					model.PageURL =(verycdWebSite + hc[i].SelectSingleNode (@"a[1]").Attributes["href"].Value.Trim ()) ;
					model.PageTitle = hc[i].InnerText.Trim () ;
					model.ClassName = firClassListModel.ClassName ;
					model.SubClassName = firClassListModel.SubClassName ;
					model.CollectionMark  = 0 ;
					model.InfoOrigin = "VeryCd" ;
					model.Remark = string.Empty ;
					model.ResouceType = firClassListModel.ResouceType ;
					model.UpdateTime = DateTime.Now ;
					model.Save () ;
					
				}
				catch (Exception err)
				{
					continue ;
				}
				finally
				{
					firClassListModel.CollectionMark = 2 ;
					firClassListModel.Update () ;
				}
			}
		}
		#endregion
		
		#region 根据页面链接获取页面的资源
		//根据页面链接获取页面的资源下的信息 详细信息，即名称和下载链接,介绍等
		public static void GetResoucePageInfo(tb_resoucepageslist respageListModel)
		{
            //string xpath =@"td[1]/a[1] "; //属性 ed2k
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (respageListModel.PageURL ,VerycdEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes ("//@ed2k") ;
			respageListModel.CollectionMark = 1 ;
			respageListModel.Update () ;
			for (int i = 0; i <hc.Count ; i++) {
				try
				{
					tb_resoucelink model = new tb_resoucelink () ;
					string name = hc[i ].Attributes["ed2k"].Value.Trim ();
					string urlLink = HttpUtility.UrlDecode (name,Encoding.UTF8 ) ;
					model.ResouceMD5 = urlLink.Split('|')[4] ;
					model.ResouceName = urlLink.Split('|')[2] ;
					model.ResouceLink = urlLink ;
					model.FromURL  = respageListModel.PageURL ;
					model.ClassName = respageListModel .ClassName ;
					model.SubClassName = respageListModel .SubClassName ;
					model.InfoOrigin = "VeryCd" ;
					model.Remark = string.Empty ;
					model.ResouceType = respageListModel.ResouceType ;
					model.UpdateTime = DateTime.Now ;
					model.Save () ;
				}
				catch (Exception err)
				{
					continue ;
				}
			}
			respageListModel.CollectionMark = 2 ;
			respageListModel.Update () ;
			Console.WriteLine (respageListModel.PageURL ) ;
		}
		#endregion
		
		#region 开始获取资源页面列表
		//根据大类资源集合网址来提取资源页面集合
		public static void StartCollectResouceList()
		{
			string firClassName = "图书" ;
			ResouceType resType = ResouceType.EBook ;
			Hashtable ht = new Hashtable () ;
			ht.Add ("http://www.verycd.com/archives/book/novels/","小说");
			ht.Add ("http://www.verycd.com/archives/book/literature/","文学");
			ht.Add ("http://www.verycd.com/archives/book/social/","人文社科");
			ht.Add ("http://www.verycd.com/archives/book/eco/","经济管理");
			ht.Add ("http://www.verycd.com/archives/book/computer/","计算机与网络");
			ht.Add ("http://www.verycd.com/archives/book/life/","生活");
			ht.Add ("http://www.verycd.com/archives/book/edu/","教育科技");
			ht.Add ("http://www.verycd.com/archives/book/children/","少儿");
			ht.Add ("http://www.verycd.com/archives/book/others/","其它图书");
			foreach (DictionaryEntry element in ht) {
//				GetTypePageList( element.Key.ToString().Trim (),firClassName,element.Value.ToString (),resType) ;
                Console.WriteLine("完成:" + element.Value.ToString());
				tb_typelist model = new tb_typelist () ;
				model.URL = element.Key.ToString ().Trim () ;                
				model.Remark = string.Empty ;
				model.SubClassName = element.Value.ToString().Trim () ;
				model.TypeName = firClassName ;
				model.UpdateTime = DateTime.Now ;
				model.ResType = resType.ToString () ;
				model.Save () ;
			}
		}
		#endregion
		
		#region 开始逐一对资源集合进行分析,提取单独资源页面
		//对资源集合数据库中的资源逐一获取下载链接
		public static void StartCollectResoucePages()
		{
			while (tb_fistclasslist.FindCount(tb_fistclasslist._.CollectionMark,0)>0)//还有未采集的
			{
				try
				{
					tb_fistclasslist pageModel = tb_fistclasslist.Find (tb_fistclasslist._.CollectionMark,0) ;
					GetPageResouceList(pageModel ) ;//采集此列表
					Console.WriteLine ("完成:"+pageModel.WebURL) ;
				}
				catch (Exception err)
				{
					continue ;
				}
			}
		}
		#endregion
		
		#region 开始采集每个页面的链接信息
		public static void StartCollectResouceDownLoadLink()
		{
			while (tb_resoucepageslist.FindCount(tb_resoucepageslist._.CollectionMark,0)>0)//还有未采集的
			{
				try
				{
					tb_resoucepageslist pageModel = tb_resoucepageslist.Find (tb_resoucepageslist._.CollectionMark,0) ;
					GetResoucePageInfo(pageModel ) ;//采集此列表
				}
				catch (Exception err)
				{
					continue ;
				}
			}
		}
		#endregion
	}
}