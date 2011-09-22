/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-2
 * 时间: 15:16
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
	class Program
	{
		public static void Main(string[] args)
		{
			DeleteDataByKeyWords () ;	
//			TestAlibabaInfo.TestXpath () ;
//			Initial () ;
            //for (int i = 0; i <100; i++)
            //{
            //    Thread.Sleep (1000) ;
            //    ThreadStart threadStart=new ThreadStart(NextCaclulate );
            //    Thread thread=new Thread(threadStart);
            //    thread.Start();
            //}            
			Console.WriteLine ("OK") ;
			Console.ReadLine () ;
		}
		
		static void DeleteDataByKeyWords()
		{
			string name = tb_companyinfo._.MainProductAndService   ;
			while (true )
			{
				string[] str = Console.ReadLine ().Split (' ') ;
				for (int i = 0; i < str.Length ; i++) {
					string sql = name +" like '%" +str[i].Trim () +"%'" ;
					tb_companyinfo.Delete(sql );				
				}
				Console.WriteLine (tb_companyinfo.FindCount ().ToString ()) ;
				Console.WriteLine ("---------------OK-----------") ;	
			}
		}		
		static void Initial()
		{
			tb_subindustrylist subIndustryModel = new tb_subindustrylist () ;
			#region 工业润滑油
//			subIndustryModel.ID = 1 ;
//			subIndustryModel.IndustryName = "工业润滑油" ;
//			subIndustryModel.CollectionMark = 0 ;
//			subIndustryModel.FatherIndustryName = "精细化学品" ;
//			subIndustryModel.IndustryWebSite =@"http://search.china.alibaba.com/company/c-1033682_n-y.html";
//			subIndustryModel.InfoOrigin = InfoOriginE.AlibabaChina.ToString () ;
//			subIndustryModel.KeyWords = string.Empty ;
//			subIndustryModel.RootClassName = "原材料" ;
//			subIndustryModel.Remark = string.Empty ;
//			subIndustryModel.UpdateTime = DateTime.Now ;
//			subIndustryModel.Save () ;
			#endregion
			
			#region 车用润滑油
			subIndustryModel.IndustryName = "车用润滑油" ;
			subIndustryModel.CollectionMark = 0 ;
			subIndustryModel.FatherIndustryName = "精细化学品" ;
			subIndustryModel.IndustryWebSite =@"http://search.china.alibaba.com/company/c-1032190_n-y.html";
			subIndustryModel.InfoOrigin = InfoOriginE.AlibabaChina.ToString () ;
			subIndustryModel.KeyWords = string.Empty ;
			subIndustryModel.RootClassName = "原材料" ;
			subIndustryModel.Remark = string.Empty ;
			subIndustryModel.UpdateTime = DateTime.Now ;
			subIndustryModel.Save () ;
			#endregion
			AlibabaInfo.GetSubCategoryList(subIndustryModel) ;//子类目信息已经添加到数据库
			StartCollection.StartCollectionFromSubIndustry(subIndustryModel) ;//开始采集页面
//
//			subIndustryModel .CollectionMark =  Convert.ToInt32(CollectionMarkE.Doing );
//			subIndustryModel.Update () ;
//			//首先根据行业子类信息获取子类目
			AlibabaInfo.GetSubCategoryList(subIndustryModel) ;//子类目信息已经添加到数据库
//			string name = tb_subcategorylist._.CategoryName ;
//			string[] values = new string[] {"综合性公司","轴承和离合器油","能源产品代理加盟","压缩、分离设备",
//				"轴承","液压机械及部件","过滤器","表面活性剂","能源产品加工","压缩机","沥青","工业用清洗剂","其他助剂"} ;
//			for (int i = 0; i < values.Length ; i++) {
//				tb_subcategorylist.Delete (new string[]{name} ,new string[]{values [i ]})  ;
//			}
			
		}
		static void NextCaclulate()
		{
			StartCollection.StartCollectionFromPageList() ;
		}
	}
}