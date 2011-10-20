/*
 * Created by SharpDevelop.
 * User: asxinyu@qq.com
 * Date: 2011-8-19
 * Time: 15:10
 * 
 * 项目基本类型，接口，枚举类等
 */
using System;
using CustomerEntity;

namespace CustomerCollector
{
	/// <summary>
	/// 信息来源
	/// </summary>
	public enum InfoOriginE
	{
        /// <summary>
        /// 阿里巴巴中国站
        /// </summary>
		AlibabaChina ,
		/// <summary>
		/// 慧聪网
		/// </summary>
        Hc360  
	}

	/// <summary>
	/// 用户类型
	/// </summary>
	public enum UserTypeE
	{
		/// <summary>
		/// 阿里巴巴诚信通用户
		/// </summary>
		Alibaba_CXT ,
		
		/// <summary>
		/// 阿里巴巴普通账号
		/// </summary>
		Alibaba_Comm
	}
		
	/// <summary>
	/// 采集标志
	/// </summary>
    public enum CollectionMarkE
    {
         /// <summary>
        /// 未采集
        /// </summary>
        None ,
        /// <summary>
        /// 正在采集中
        /// </summary>
        Doing ,
        /// <summary>
        /// 采集完成
        /// </summary>
        Finish
    }
	public interface IGetList
	{
		//大行业是需要手动的添加的

		//获取子行业列表		
//		void GetSubIndustryList(tb_industrylist model) ;
		
		//获取子类目列表
//		void GetSubCategoryList(tb_subindustrylist model) ;
//		void GetSubCategoryList(string url) ;
		
		//获取页面列表
//		void GetPagesList(string webURL) ;
		
		//获取公司信息
//		void GetCompanyInfo(string webURL) ;
		
		//获取公司注册信息		
	//	void GetRegistInfo(string webURL) ;
		
		//开始采集
//		void StartCollection() ;
	}
}
