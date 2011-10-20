/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-2
 * 时间: 15:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net.Sockets;
using System.Threading ;
using System.Collections.Generic ;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HtmlAgilityPack;
using NewLife;
using XCode;
using NewLife.Reflection;
using XCode.DataAccessLayer;
using CustomerEntity;

namespace CustomerCollector
{
	/// <summary>
	/// 分析阿里巴巴页面信息,测试用
	/// </summary>
	public class TestAlibabaInfo
	{
		//公司介绍网址
		static string companyIntroURL = @"http://joycecao0907.cn.alibaba.com/athena/companyprofile/joycecao0907.html";
		//公司联系人信息网址
		static string companyInfoURL  = @"http://joycecao0907.cn.alibaba.com/athena/contact/joycecao0907.html" ;
		//用于获取子类目的子行业网址 http://search.china.alibaba.com/company/c-1033682_n-y.html
		static string subIndustryURL = @"http://search.china.alibaba.com/company/c-1033682_n-y.html" ;
		//子类目网址,用户获取页面列表和总页数
		static string subCateoryURL = @"http://search.china.alibaba.com/company/c-1036758_n-y.html" ;
		public static void TestXpath()
		{
			//首先测试获取子类目是否正常
			TestSubCategory (subIndustryURL ) ;
			//然后测试获取总页数和页面列表是否正常
			TestPageList (subCateoryURL ) ;
			//再测试获取公司介绍信息和联系信息是否正常
			TestBasicPageInfo (subCateoryURL ) ;
			TestCompanyIntroInfo (companyIntroURL ) ;
			TestCompanyLinkInfo (companyInfoURL ) ;
		}
		
		public static void TestSubCategory(string URL)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (URL ,AlibabaInfo.HtmlPageEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(AlibabaInfo.xPath_SubCategory) ;
			if (hc == null )//还有一种情况,就是如果没有子类目，则hc为null,直接添加到数据库
			{
				Console.WriteLine("没有子类目,直接添加到数据库");
			}
			else //有一种情况是，子类目中含有多个类别
			{
				for (int i = 0; i < hc.Count -1 ; i++) //最后一个项目去掉
				{
					tb_subcategorylist model = new tb_subcategorylist () ;
					model.CategoryName    = hc[i ].SelectSingleNode (@"a").InnerText .Trim () ;//子类目名称，去掉括号
					model.CategoryWebSite = hc[i ].SelectSingleNode (@"a").Attributes ["href"].Value.Trim ();//网址
					Console.WriteLine (model.CategoryName +":"+model.CategoryWebSite ) ;
				}
			}
		}
		
		public static void TestPageList(string URL)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (URL ,AlibabaInfo.HtmlPageEncoding ) ;
			int totalPage = Convert.ToInt32 (doc.DocumentNode.SelectSingleNode(AlibabaInfo.xPath_PageListCount ).InnerText .Trim ()) ;//总页数
			Console.WriteLine (totalPage.ToString ()) ;
		}
		
		public static void TestBasicPageInfo(string URL)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (URL ,AlibabaInfo.HtmlPageEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(AlibabaInfo.xPath_PageInfo ) ;
			for (int i = 0; i < hc.Count ; i++)
			{
				#region                      //@"div[1]/div[2]/div[1]/span[1]/a[1]"
				HtmlNodeCollection hc2 = hc [i].SelectNodes (@"li") ;
				for (int j = 0; j < hc2.Count ; j++) {
					HtmlNode node = hc2[j ].SelectSingleNode (@"h3[1]/a[1]");
					if (node != null )
					{
						tb_userinfo model = new tb_userinfo () ;
						//公司主页,根据此类型来判定公司的账号类别
						string[] res = CustomerHelper.GetUserNameAndType (node.Attributes ["href"].Value .Trim ()) ;
						model.UserName = res[0] ;   //用户名
						model.UserType = res[1] ;   //用户类型
						model.CompanyName = node.InnerText.Trim () ;//公司名称
						Console.WriteLine (model.UserName +":"+model.CompanyName ) ;
					}
				}
				#endregion
			}
		}
		
		public static void TestCompanyIntroInfo(string URL)
		{
			#region 获取公司信息
			HtmlDocument doc2 = CaptureWebSite.GetHtmlDocument (URL ,AlibabaInfo.HtmlPageEncoding ) ;
			HtmlNodeCollection hc2 = doc2.DocumentNode.SelectNodes(@"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[6]/table[1]/tr") ;
			tb_companyinfo model = new tb_companyinfo () ;
			for (int i = 0; i < hc2.Count ; i++) {
				if (hc2[i].HasChildNodes ) {
					HtmlNodeCollection hc3 = hc2[i].SelectNodes (@"td") ;
					if (hc3!=null ) {
						for (int j = 0; j < (int )(hc3.Count*0.5) ; j++) {
							if (hc3[2*j ].InnerText.Trim ().Contains ("主营产品或服务")) {
								model.MainProductAndService = hc3[2*j +1].InnerText.Replace("&nbsp;","").Trim ();
							}
							else if (hc3[2*j ].InnerText.Trim ().Contains ("经营模式")) {
								model.BusinessModel = hc3[2*j +1].InnerText.Replace("&nbsp;","").Trim ();
							}
							else {}
						}
					}
				}
			}
			Console.WriteLine ("主营产品:"+model.MainProductAndService );
			Console.WriteLine ("经营模式:"+model.BusinessModel ) ;
			#endregion
		}
		public static void TestCompanyLinkInfo(string URL)
		{
			#region 获取联系人信息
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (URL ,AlibabaInfo.HtmlPageEncoding ) ;
			string name = doc.DocumentNode.SelectSingleNode (AlibabaInfo.xPath_CompLinkPerName ).InnerText.Trim() ;
			string allName = doc.DocumentNode.SelectSingleNode (AlibabaInfo.xPath_ComLinkPerAllName ).InnerText.Trim () ;
			string[] a = allName.Substring (0,allName.IndexOf ('）')+1).Split (new string[]{"&nbsp;"},StringSplitOptions.None ) ;
			int index = a [1].IndexOf  ('（') ;
			tb_companyinfo model = new tb_companyinfo () ;
			model.LinkMan = a [0] ;
			model.CallName = a [1].Substring (0,index ) ;
			model.Position = a [1].Substring (index ).Replace ("（","").Replace ("）","").Trim () ;
			Console.WriteLine (model.LinkMan +":"+model.CallName +":"+model.Position ) ;
			HtmlNodeCollection hc = doc.DocumentNode .SelectNodes(AlibabaInfo.xPath_CompLinkInfo ) ;
			for (int i = 0; i < hc.Count ; i++)
			{
				string temp = hc[i].InnerText.Trim().Replace ("&nbsp;","").Replace("\n","").Trim () ;
				string[] str = temp.Split ('：') ;
				
				if (str [0].Trim ()=="电话") {
					model.Tel = str [1].Trim () ;
				}
				else if (str [0].Contains("移动电话")) {
					model.Mobile = str [1].Trim () ;
				}
				else if (str [0].Contains("传真")) {
					model.Fax = str [1].Trim () ;
				}
				else if (str [0].Contains("地址")) {
					model.Address = str [1].Trim () ;
				}
				else if (str [0].Contains("邮编")) {
					model.PostalCode = str [1].Trim () ;
				}
				else if (str [0].Contains("公司主页")) {
					model.WebSite = "" ;
					string[] webStr = str [1].Split (new string []{"http"},StringSplitOptions.None ) ;
					for (int j = 0; j < webStr.Length ; j ++) {
						if (webStr [j ].Trim()!="" ) {
							model.WebSite += ("http"+webStr [j ].Trim ()+";") ;
						}
					}
				}
				else
				{
				}
			}
			Console.WriteLine (model.LinkMan+":"+model.Tel + ":"+model.Address ) ;
			#endregion
		}
	}
}
