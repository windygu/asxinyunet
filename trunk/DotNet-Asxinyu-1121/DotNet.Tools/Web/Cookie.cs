﻿/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-6-12
 * Time: 13:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web ;

namespace DotNet.Tools.Web
{
	/// <summary>
	/// Description of Cookie.
	/// </summary>
	public static class Cookie
	{
		#region 写cookie值
		/// <summary>
		/// 写cookie值
		/// </summary>
		/// <param name="strName">名称</param>
		/// <param name="strValue">值</param>
		public static void WriteCookie(string strName, string strValue)
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
			if (cookie == null)
			{
				cookie = new HttpCookie(strName);
			}
			cookie.Value = strValue;
			HttpContext.Current.Response.AppendCookie(cookie);

		}
		#endregion
		
		#region  写cookie值,指定过期时间
		/// <summary>
		/// 写cookie值
		/// </summary>
		/// <param name="strName">名称</param>
		/// <param name="strValue">值</param>
		/// <param name="strValue">过期时间(分钟)</param>
		public static void WriteCookie(string strName, string strValue, int expires)
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
			if (cookie == null)
			{
				cookie = new HttpCookie(strName);
			}
			cookie.Value = strValue;
			cookie.Expires = DateTime.Now.AddMinutes(expires);
			HttpContext.Current.Response.AppendCookie(cookie);
		}
		#endregion
		
		#region 读cookie值
		/// <summary>
		/// 读cookie值
		/// </summary>
		/// <param name="strName">名称</param>
		/// <returns>cookie值</returns>
		public static string GetCookie(string strName)
		{
			if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
			{
				return HttpContext.Current.Request.Cookies[strName].Value.ToString();
			}

			return "";
		}
		#endregion
	}
}