/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-22
 * Time: 14:01
 * 
 *获取阿里巴巴网站信息
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
	/// 阿里巴巴信息类
	/// </summary>
	public class AlibabaInfo:IGetList
	{
		//阿里巴巴公司黄页网址:http://page.china.alibaba.com/cp/cp1.html
		//行业大类
		
		#region 阿里巴巴网站常规变量
		//前缀
		public static string PreURL = @"http://" ;
		public static string SueURL = @".html" ;
		public static string MainSuURL = @".cn.alibaba.com/" ;//诚信通主后缀
		public static string MainSuURL_2 =@".cn.alibaba.com/athena/" ;//诚信通主后缀
		public static string ComMainSu = @"http://china.alibaba.com/company/detail/" ;//普通主后缀
		public static int DefaultCollectorNumbers = 30 ;//默认的最小采集单数数目
		/// <summary>
		/// 该网站的网页编码格式
		/// </summary>
		public static Encoding HtmlPageEncoding = Encoding.GetEncoding("GB2312") ;
		public static string prURL_Industry = @"http://china.alibaba.com/company/trade/" ;
		public static string suURL_Industry = ".html";
		
		//获取子行业的xPath路径
		public static string xPath_SubIndustry_1 = @"/html[1]/body[1]/center[1]/div[5]/center[1]/table[1]/tbody[1]/tr[1]/td[1]/table[3]/tbody[1]/tr[1]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/table[1]/tr[1]/td[1]/table" ;
		public static string xPath_SubIndustry_2 = @"/html[1]/body[1]/center[1]/div[5]/center[1]/table[1]/tbody[1]/tr[1]/td[1]/table[3]/tbody[1]/tr[1]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/table[1]/tr[1]/td[2]/table";
		public static string xPath_SubIndustry_Q = @"tr[1]/td[2]/span[1]/a[1]" ;//查询路径
		
		//获取子类目的xPath路径
		//                                      @"/html[1]/body[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/ul[1]/li";
		public static string xPath_SubCategory =@"/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/ul[1]/li";
		public static string xPath_SubCategory_Q = @"div[1]/ul[1]/li" ;
		
		//获取页面信息的xPath路径                      @"/html[1]/body[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[7]/div[3]/div[1]/div[1]/span[1]/b[1]"
		public static string xPath_PageListCount = @"/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[7]/div[3]/div[1]/div[1]/span[1]/b[1]";//页面总数
		public static string xPath_PageInfo      = @"/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[6]/ul" ;
		//@"/html[1]/body[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[6]/ul" ;
		//获取公司联系人信息的xPath路径
		public static string xPath_CompLinkPerName = @"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[3]/div[1]/dl[1]/dd[1]/a[1]" ;
		public static string xPath_ComLinkPerAllName = @"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[3]/div[1]/dl[1]/dd[1]" ;
		public static string xPath_CompLinkInfo =@"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[3]/ul[1]/li" ;
		//公司介绍信息
		public static string xPath_CompanyIntro = @"/html[1]/head[1]/meta[2]";//公司基本介绍信息
		public static string xPath_CompanyInfo  = @"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[6]/table[1]/tr";
		
		//普通
		public static string xPath_CommCompanyIntro = @"/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[2]/table[1]/tr" ;
		public static string xPath_CommCompanyInfo  = @"/html[1]/body[1]/div[6]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]" ;
		public static string xPath_CommCompanyInfo2 = @"/html[1]/body[1]/div[6]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]" ;
		#endregion
		
		#region 获取大类行业列表，手动添加条目,分析
		//获取大类行业,只获取所有大类行业，其他的信息到系统中编辑,因为列表中不好区分
		public static void GetIndustryList(string IndustryList)
		{
			string[] str = IndustryList.Replace("\r\n", "").Replace("\t", "").Trim().Split(
				new string[] { "n>" }, StringSplitOptions.None);
			int a, b;
			int a1, b1;
			for (int i = 0; i < str.Length ; i++)
			{
				if (str [i ]!="")
				{
					tb_industrylist model = new tb_industrylist();
					
					a = str[i].IndexOf("\"");
					b = str[i].LastIndexOf("\"");
					model.WebSite = prURL_Industry + str[i].Substring(a + 1, b - a - 1) + prURL_Industry ;
					a1 = str[i].IndexOf(">");
					b1 = str[i].LastIndexOf("<");
					model.IndustryName = str[i].Substring(a1 + 1, b1 - a1 - 1);
					model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
					model.RootClassName = CustomerHelper.RootClassName[0];
					model.KeyWords = model.IndustryName;
					model.InfoOrigin = InfoOriginE.AlibabaChina.ToString();
					model.UpdateTime = DateTime.Now;
					model.Remark = string.Empty ;
					model.Save();
//					Console.WriteLine (model.IndustryName + ":"+model.WebSite ) ;
				}
			}
		}
		#endregion
		
		#region 获取子行业列表
		/// <summary>
		/// 获取子行业列表 tb_industrylist IndustryModel
		/// </summary>
		/// <param name="model">行业对象</param>
		public static void GetSubIndustryList(tb_industrylist IndustryModel)
		{
			//先查询该行业的信息
			IndustryModel.CollectionMark = Convert.ToInt32 (CollectionMarkE.Doing ) ;
			IndustryModel.Update () ;
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (IndustryModel.WebSite ,HtmlPageEncoding ) ;
			HtmlNode temp ;
			HtmlNodeCollection[] hc = new HtmlNodeCollection [2] ;//有2列需要解析，形成2个集合列表
			hc [0] = doc.DocumentNode.SelectNodes(xPath_SubIndustry_1 ) ;
			hc [1] = doc.DocumentNode.SelectNodes(xPath_SubIndustry_2 ) ;
			for (int i = 0; i < hc.Length ; i++)
			{
				for (int j  = 0 ; j <hc[i].Count ; j ++)
				{
					tb_subindustrylist model = new tb_subindustrylist () ;
					try
					{
						temp = hc[i ][j].SelectSingleNode(xPath_SubIndustry_Q );
						model.IndustryName = temp.InnerText.Trim () ;//子行业名称
						model.IndustryWebSite = temp.Attributes["href"].Value.Trim () ;//网址
						model.RootClassName = IndustryModel.RootClassName ;//拷贝父类的相关信息
						model.KeyWords = IndustryModel.KeyWords +";"+model.IndustryName ;
						model.InfoOrigin = IndustryModel.InfoOrigin ;
						model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
						model.UpdateTime = DateTime.Now ;
						model.Remark = string.Empty ;
						model.Save();//自动判断是否存在
//						Console.WriteLine (model.IndustryName +":"+model.IndustryWebSite ) ;
					}
					catch (Exception err)
					{
						continue ;
					}
				}
			}
			IndustryModel.CollectionMark = Convert.ToInt32 (CollectionMarkE.Finish ) ;
			IndustryModel.Update () ;
		}
		#endregion
		
		#region 获取子类目列表
		///获取子类目列表 tb_subindustrylist subIndustryModel
		public static void GetSubCategoryList(tb_subindustrylist subIndustryModel)
		{
			HtmlDocument doc = CaptureWebSite.GetHtmlDocument (subIndustryModel.IndustryWebSite ,HtmlPageEncoding ) ;
			HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(xPath_SubCategory) ;
			if (hc == null )//还有一种情况,就是如果没有子类目，则hc为null,直接添加到数据库
			{
				tb_subcategorylist model = new tb_subcategorylist () ;
				model.CategoryName    = subIndustryModel .IndustryName ;//子类目名称，去掉括号
				model.CategoryWebSite = subIndustryModel.IndustryWebSite ;//网址
				model.SubIndustryName = subIndustryModel.IndustryName ;
				model.IndustryName    = subIndustryModel.FatherIndustryName ;
				model.RootClassName   = subIndustryModel.RootClassName ;//拷贝父类的相关信息
				model.KeyWords        = subIndustryModel.KeyWords ;
				model.InfoOrigin      = subIndustryModel.InfoOrigin ;
				model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
				model.UpdateTime = DateTime.Now ; //缺少UpdateTime方法
				model.Remark = string.Empty ;
				model.Save();//自动判断是否存在
			}
			else //有一种情况是，子类目中含有多个类别
			{
				for (int i = 0; i < hc.Count -1 ; i++) //最后一个项目去掉
				{
					#region	主体方法
					tb_subcategorylist model = new tb_subcategorylist () ;
					try
					{
						model.CategoryName    = hc[i ].SelectSingleNode (@"a").InnerText .Trim () ;//子类目名称，去掉括号
						model.CategoryWebSite = hc[i ].SelectSingleNode (@"a").Attributes ["href"].Value.Trim ();//网址
						model.SubIndustryName = subIndustryModel.IndustryName ;
						model.IndustryName    = subIndustryModel.FatherIndustryName ;
						model.RootClassName   = subIndustryModel.RootClassName ;//拷贝父类的相关信息
						model.KeyWords        = subIndustryModel.KeyWords +";"+model.SubIndustryName ;
						model.InfoOrigin      = subIndustryModel.InfoOrigin ;
						model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
						model.UpdateTime = DateTime.Now ; //缺少UpdateTime方法
						model.Remark = "" ;
						model.Save();//自动判断是否存在
//						Console.WriteLine (model.CategoryName +":"+model.CategoryWebSite ) ;
					}
					catch (Exception err)
					{
						continue ;
					}
					#endregion
				}
			}
		}
		#endregion
		
		#region 根据子类目获取页面列表
		/// <summary>
		/// 根据子类目获取页面列表
		/// </summary>
		public static void GetPagesList(tb_subcategorylist subCategoryModel )
		{
			subCategoryModel.CollectionMark = Convert.ToInt32(CollectionMarkE.Doing ) ;
			subCategoryModel.Update () ;
			try
			{
				HtmlDocument doc = CaptureWebSite.GetHtmlDocument (subCategoryModel.CategoryWebSite ,HtmlPageEncoding ) ;
				int totalPage = Convert.ToInt32 (doc.DocumentNode.SelectSingleNode(xPath_PageListCount ).InnerText .Trim ()) ;//总页数
				string[] prSU = subCategoryModel.CategoryWebSite.Split ('_') ;
				//开始生成页面网址列表
				for (int i = 1; i <= totalPage ; i++)
				{
					tb_pagelist model = new tb_pagelist () ;
					model.PageURL        = prSU [0]+"_p-"+i.ToString () + "_"+prSU [1] ;
					model.CategoryName   = subCategoryModel.CategoryName ;
					model.SubIndustryName= subCategoryModel.SubIndustryName ;
					model.IndustryName   = subCategoryModel.IndustryName ;
					model.RootClassName  = subCategoryModel.RootClassName ;
					model.UpdateTime     = DateTime.Now ;
					model.InfoOrigin = subCategoryModel.InfoOrigin ;
					model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
					model.Remark         = string.Empty ;
					model.Save() ;
				}
			}
			catch (Exception err)
			{
				return ;
			}
			finally
			{
				subCategoryModel.CollectionMark = Convert.ToInt32(CollectionMarkE.Finish )  ;
				subCategoryModel.Update () ;
			}
		}
		
		#endregion
		
		#region 根据页面获取公司用户名等基本信息,防止网址更新带来的滞后  //tb_pagelist PageListMode
		public static  List<tb_userinfo > GetPageBasicInfo(tb_pagelist PageListMode)
		{
			List<tb_userinfo > userList = new List<tb_userinfo> () ;//用户列表
			try
			{
				HtmlDocument doc = CaptureWebSite.GetHtmlDocument (PageListMode.PageURL ,HtmlPageEncoding ) ;
				HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(xPath_PageInfo ) ;
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
							model.CompanyName = node.InnerText.Replace (@"\","").Replace (@"/","").Trim () ;//公司名称
							model.CategoryName = PageListMode.CategoryName ;
							model.SubIndustryName = PageListMode.SubIndustryName ;
							model.IndustryName = PageListMode.IndustryName ;
							model.RootClassName = PageListMode.RootClassName ;
							model.InfoOrigin = PageListMode.InfoOrigin ;
							model.UpdateTime = DateTime.Now ;
							model.CollectionMark = Convert.ToInt32(CollectionMarkE.None);
							model.Remark = string.Empty ;
//							Console.WriteLine (model.UserName +":"+model.CompanyName ) ;
							userList.Add (model ) ;//添加到列表
						}
					}
					#endregion
				}
				return userList ;
			}
			
			catch (Exception err)
			{
				//记录错误和页面位置
				return userList ;
			}
			finally
			{
				PageListMode.Delete () ;//删除当前页面
			}
			
		}
		#endregion
		
		#region 获取公司信息
		///获取公司信息
		public static void GetCompanyInfo(tb_userinfo userModel)
		{
			try 
			{
				if (userModel.UserType==UserTypeE.Alibaba_Comm .ToString ()) {
					GetCompanyInfoForCommonUSer (userModel ) ;
				}
				else if (userModel.UserType ==UserTypeE.Alibaba_CXT .ToString ()) {
					GetCompanyInfoForCXTUser (userModel );
				}
				else
				{
					
				}
			}
			catch (Exception err)
			{
				return ;
			}
		}
		
		public static void GetCompanyInfoForCXTUser(tb_userinfo userModel)
		{
			tb_companyinfo model = new tb_companyinfo () ;
			try
			{
				//首先根据用户名和类型,生成采集网址
				string LinkInfoURL = CompanyUserModel.GetLinkPageURL (userModel.UserName ,
				                                                      (InfoOriginE )Enum .Parse (typeof (InfoOriginE ),userModel.InfoOrigin ,false ),
				                                                      (UserTypeE )Enum.Parse (typeof (UserTypeE ),userModel.UserType,false )) ;
				string CompIntroURL = CompanyUserModel.GetCompanyIntroPageURL (userModel.UserName ,
				                                                               (InfoOriginE )Enum .Parse (typeof (InfoOriginE ),userModel.InfoOrigin ,false ),
				                                                               (UserTypeE )Enum.Parse (typeof (UserTypeE ),userModel.UserType,false )) ;
				
				#region 获取联系人信息
				HtmlDocument doc = CaptureWebSite.GetHtmlDocument (LinkInfoURL ,AlibabaInfo.HtmlPageEncoding ) ;
				string name = doc.DocumentNode.SelectSingleNode (xPath_CompLinkPerName ).InnerText.Trim() ;
				string allName = doc.DocumentNode.SelectSingleNode (xPath_ComLinkPerAllName ).InnerText.Trim () ;
				string[] a = allName.Substring (0,allName.IndexOf ('）')+1).Split (new string[]{"&nbsp;"},StringSplitOptions.None ) ;
				int index = a [1].IndexOf  ('（') ;
				
				model.LinkMan = a [0] ;
				model.CallName = a [1].Substring (0,index ) ;
				model.Position = a [1].Substring (index ).Replace ("（","").Replace ("）","").Trim () ;
//				Console.WriteLine (model.LinkMan +":"+model.CallName +":"+model.Position ) ;
				HtmlNodeCollection hc = doc.DocumentNode .SelectNodes(xPath_CompLinkInfo ) ;
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
//					Console.WriteLine (model.CompanyName +":"+model.LinkMan ) ;
				}
				#endregion
				
				#region 获取公司信息
				HtmlDocument doc2 = CaptureWebSite.GetHtmlDocument (CompIntroURL,AlibabaInfo.HtmlPageEncoding ) ;
				HtmlNodeCollection hc2 = doc2.DocumentNode.SelectNodes(@"/html[1]/body[1]/center[1]/div[2]/div[1]/div[3]/div[1]/div[6]/table[1]/tr") ;
				//doc2.DocumentNode.SelectSingleNode (xPath_CompanyIntro).Attributes["content"].Value .Trim ()//公司介绍
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
				#endregion				
			}
			catch (Exception err)
			{
				//记录错误
			}
			finally
			{
				model.Email = string.Empty ;
				model.UpdateTime = DateTime.Now ;
				model.InfoOrigin = userModel.InfoOrigin ;
				model.UserName = userModel.UserName ;
				model.UserType = userModel.UserType ;
				model.CompanyName = userModel.CompanyName ;
				model.Industry = userModel.IndustryName ;
				model.SubCategory =userModel.CategoryName ;
				model.SubIndustry = userModel.SubIndustryName ;
				model.RootClass = userModel.RootClassName ;				
				model.Save () ;				
//				userModel.Delete () ;//删除当前用户记录
			}
		}
		//普通用户的信息获取
		public static void GetCompanyInfoForCommonUSer(tb_userinfo userModel)
		{
			tb_companyinfo model = new tb_companyinfo () ;
			try
			{
				//首先根据用户名和类型,生成采集网址
				string LinkInfoURL = CompanyUserModel.GetLinkPageURL (userModel.UserName ,
				                                                      (InfoOriginE )Enum .Parse (typeof (InfoOriginE ),userModel.InfoOrigin ,false ),
				                                                      (UserTypeE )Enum.Parse (typeof (UserTypeE ),userModel.UserType,false )) ;
				string CompIntroURL = CompanyUserModel.GetCompanyIntroPageURL (userModel.UserName ,
				                                                               (InfoOriginE )Enum .Parse (typeof (InfoOriginE ),userModel.InfoOrigin ,false ),
				                                                               (UserTypeE )Enum.Parse (typeof (UserTypeE ),userModel.UserType,false )) ;
				
				#region 先获取公司信息
				HtmlDocument doc = CaptureWebSite.GetHtmlDocument (CompIntroURL ,AlibabaInfo.HtmlPageEncoding ) ;
				HtmlNodeCollection hc = doc.DocumentNode.SelectNodes (xPath_CommCompanyIntro );
				
				if (hc!=null && hc[1].SelectSingleNode (@"td[1]")!=null && hc[3].SelectSingleNode (@"td[1]")!=null ) {
					HtmlNode mainProduct = hc[1].SelectSingleNode (@"td[1]") ;
					HtmlNode businessMode= hc[3].SelectSingleNode (@"td[1]") ;
					if (mainProduct !=null ) {
						model.MainProductAndService = mainProduct.InnerText.Trim () ;
					}
					if (businessMode !=null ) {
						model.BusinessModel = businessMode.InnerText.Trim () ;
					}
				}
				
				#endregion
				
				#region 获取联系信息
				HtmlDocument doc2 = CaptureWebSite.GetHtmlDocument (LinkInfoURL  ,AlibabaInfo.HtmlPageEncoding ) ;
				HtmlNodeCollection hc2 = doc2.DocumentNode.SelectSingleNode (xPath_CommCompanyInfo ).SelectNodes (@"p");
				for (int i = 0; i < hc2.Count ; i++) {
					string temp = hc2[i].InnerText.Trim().Replace ("&nbsp;","").Replace("\n","").Replace ("—","").Trim () ;
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
					else
					{
					}
				}
				string website = doc2.DocumentNode.SelectSingleNode (xPath_CommCompanyInfo2 ).InnerText.Replace ("&nbsp;","").Replace("\n","").Trim () ;
				if (website.Contains("公司主页")) {
					model.WebSite = website .Split ('：')[1].Replace ("—","").Trim () ;
				}
				#endregion
			}
			catch (Exception err)
			{
				
			}
			finally
			{
				model.Email = string.Empty ;
				model.UpdateTime = DateTime.Now ;
				model.InfoOrigin = userModel.InfoOrigin ;
				model.UserName = userModel.UserName ;
				model.UserType = userModel.UserType ;
				model.CompanyName = userModel.CompanyName ;
				model.Industry = userModel.IndustryName ;
				model.SubCategory =userModel.CategoryName ;
				model.SubIndustry = userModel.SubIndustryName ;
				model.RootClass = userModel.RootClassName ;
				model.Save () ;
			}
		}
		#endregion
		
		///获取公司注册信息
		public static void GetRegistInfo(string webURL)
		{
			
		}
	}
}