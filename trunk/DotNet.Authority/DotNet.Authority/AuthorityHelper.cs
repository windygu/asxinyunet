/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-9-21
 * 时间: 21:09
 * 
 * 权限帮助类
 */
using System;

namespace DotNet.Authority
{
	/// <summary>
	/// 权限帮助类
	/// </summary>
	public class AuthorityHelper
	{
		#region 权限类别枚举类
		public enum AuthorityType
		{
			/// <summary>
			/// 窗体
			/// </summary>
			Form ,
			/// <summary>
			/// 菜单
			/// </summary>
			Menu ,
			/// <summary>
			/// 功能按钮
			/// </summary>
			Function ,
			/// <summary>
			/// 资源数据
			/// </summary>
			Resouce
		}
		#endregion
		
		#region 增加权限
		public static void AddAuthority(string authorityID,string authorityName,string intro ="")
		{
			tb_authoritylist model = new tb_authoritylist () ;
			model.AuthorityID = authorityID ;
			model.AuthorityName = authorityName ;
			model.AuthorityIntro = intro ;
			model.Save () ;
		}
		
		/// <summary>
		/// 判断用户是否具有某个权限
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="authorityID">权限编号</param>
		/// <returns>是否具有该权限</returns>
		public static bool IsHaveAuthority(string userName,string authorityID)
		{
			//首先到普通权限表查找
			
			//再到组权限表查找
			
			//有2者之一即可
			return true ;
		}
		//给用户增加一个普通权限
		public static void AddUserAuthority(string userName,string authorityID)
		{
			
		}
		//删除用户的普通权限
		public static void DeleteUserAuthority(string userName,string authorityID)
		{
			
		}
		//增加组用户
		public static void AddGroupUser(string userName,string authorityID)
		{
			
		}
		//删除组用户
		public static void DeleteGroupUser(string userName,string authorityID)
		{
			
		}
		//增加组权限
		public static void AddGroupAuthority(string userName,string authorityID)
		{
			
		}
		//删除组权限
		public static void DeleteGroupAuthority(string userName,string authorityID)
		{
			
		}
		#endregion
	}
}