/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2012-5-16
 * 时间: 21:04
 * 
 * Efs布局：分为5个部分
 */
using System;
using System.Text ;
using System.Collections.Generic ;

namespace DotNet.ExtJSLibaray
{	
	
	/// <summary>
	/// Efs布局：分为5个部分，根据位置(region)分为north，south，west，east，center
	/// </summary>
	public class Layout
	{
		
		/// <summary>
		/// 注意，位置position,从上部开始0，顺时针,右边1，下部2，左边3，中间4
		/// 优化：1 布局规则上下宽度无效
		///      2 值为空，或者默认则不书写
		/// </summary>
		/// <param name="position">位置</param>
		/// <param name="title">标题</param>
		/// <param name="text">值</param>
		/// <param name="heigth">高度</param>
		/// <param name="width">宽度</param>
		/// <returns>该布局位置的div代码</returns>
		public static string GetOneLayout(int position,string title = "",string text = "",
		                                  int heigth = 120,int width = -1,
		                                  bool split = false ,bool collapsible =false)
		{
			StringBuilder sb = new StringBuilder ();
			List <string > strList = new List<string> ();
			strList.Add (Helper.GetRegion (position ));
			strList.Add (Helper.GetTitle (title ));
			strList.Add (Helper.GetHeigth (heigth ));
			strList.Add (Helper.GetWidth (width ));
			strList.Add (Helper.GetSplite(split ));
			strList.Add (Helper.GetCollapsible (collapsible));
			sb.Append ("<div ");
			foreach (var element in strList )
			{
				if (element !="") sb.Append(element);
			}
			sb.Append (">");
			if(text !="") sb.Append (text);
			sb.Append ("</div>");
			return sb.ToString ();
		}		
	}
}