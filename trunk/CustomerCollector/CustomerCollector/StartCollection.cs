/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-2
 * 时间: 15:15
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
	/// 采集序列
	/// </summary>
	public class StartCollection
	{
		/// <summary>
		/// 从行业子类开始采集
		/// </summary>
		public static void StartCollectionFromSubIndustry(tb_subindustrylist subIndustryModel)
		{
			//首先确定子类目数据库中所有的采集任务都完成,即采集标志都是2
//			if (tb_subcategorylist.FindCount (tb_subcategorylist._.CollectionMark ,0)>0)
//			{
//				StartCollectionFromSubCategoryList () ;//打开子类目采集任务
//			}
			//更新采集状态
			StartCollectionFromSubCategoryList () ;//打开子类目采集任务
			subIndustryModel.CollectionMark = Convert.ToInt32(CollectionMarkE.Finish );
			subIndustryModel.Update () ;
		}
		//从子类目列表开始采集任务
		public static void StartCollectionFromSubCategoryList()
		{
//			if (tb_pagelist.FindCount ()>0) {
//				//存在未完成的任务,任务完成需要删除页面的
//				StartCollectionFromPageList () ;
//			}
			int count = 0 ;
			while (tb_subcategorylist.FindCount (tb_subcategorylist._.CollectionMark ,0)>0)//存在未开始的任务
			{//循环完成所有子类目的采集
				//获取一条未采集的记录
				try
				{
					tb_subcategorylist subCategoryModel = tb_subcategorylist.
						FindAllByName(tb_subcategorylist._.CollectionMark ,0,"id asc",0,1)[0] ;
					AlibabaInfo.GetPagesList (subCategoryModel ) ;//获取页面列表
					count ++ ;
					Console.WriteLine (subCategoryModel.CategoryName +":采集完成"+count .ToString ()) ;
//					StartCollectionFromPageList () ;//从页面采集数据
                    
				}
				catch (Exception err)
				{
					continue ;
				}
			}
		}
		
		/// <summary>
		/// 从页面列表开始采集数据
		/// </summary>
		public static void StartCollectionFromPageList()
		{
			//去掉用户表，直接从页面生成用户列表
			while(tb_pagelist.FindCount ()>0)
			{
				try
				{
					tb_pagelist pageModel = tb_pagelist.FindAll (tb_pagelist._.CollectionMark ,0,0,1)[0] ;
					pageModel.CollectionMark = 1 ;
					pageModel.Update () ;
					List <tb_userinfo > userList = AlibabaInfo.GetPageBasicInfo (pageModel ) ;
					int count = 0 ;
					for (int i = 0; i < userList.Count ; i++) {
						if (tb_companyinfo.FindCountByName(tb_companyinfo._.CompanyName ,userList[i].CompanyName ,"",0,10)<1)
						{							
							AlibabaInfo .GetCompanyInfo (userList [i ]) ;//获取公司信息
							count ++ ;
						}
					}
					Console.WriteLine (pageModel.CategoryName + ":更新"+count.ToString ()+"条") ;
				}
				catch (Exception err)
				{
					continue ;
				}
			}
		}
	}
}
