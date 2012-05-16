/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2012-5-16
 * 时间: 21:10
 * 
 * 
 */
using System;
using System.Text ;

namespace DotNet.ExtJSLibaray
{
	/// <summary>
	/// 常规字段，名称等，常量,属性生成，如果为空，最后拼接的时候则排除
	/// 利用工具生成常量：
	/// region,height,title,width,border,split,collapsible,
	/// </summary>
	public class Helper
	{
		/// <summary>
		/// 
		/// <summary>
		public const string Region = "region" ;
		public static string[] RegionCode = {"north","east","south","west","center"};
		public static string GetRegion(int position)
		{
			return string.Format ("{0}=\"{1}\" ",Region,RegionCode[position]);
		}
		/// <summary>
		/// 
		/// <summary>
		public const string Height = "height" ;
		public static string GetHeigth(int heigth)
		{
			if (heigth <0) return "" ;
			else return string.Format ("{0}=\"{1}\" ",Height,heigth );
		}
		/// <summary>
		/// 
		/// <summary>
		public const string Title = "title" ;
		public static string GetTitle(string title)
		{
			if(title =="") return title ;
			else return string.Format ("{0}=\"{1}\" ",Title ,title );
		}
		
		/// <summary>
		/// 
		/// <summary>
		public const string Width = "width" ;
		public static string GetWidth(int width)
		{
			if(width <0) return "" ;
			else return string.Format ("{0}=\"{1}\" ",Width ,width);
		}
		/// <summary>
		/// 
		/// <summary>
		public const string Border = "border" ;
		 
		/// <summary>
		/// 
		/// <summary>
		public const string Split = "split" ;
		public static string GetSplite(bool split)
		{
			//分割默认是false，因此如果为false,则返回空
			if(split ) return string.Format ("{0}=\"{1}\" ",split ,split );
			else return "" ;
		}
		/// <summary>
		/// 
		/// <summary>
		public const string Collapsible = "collapsible" ;
		public static string GetCollapsible(bool collapsible)
		{
			//折叠默认是false，因此如果为false,则返回空
			if (collapsible ) return string.Format ("{0}=\"{1}\" ",Collapsible ,collapsible);
			else return "" ;
		}
	}
}
