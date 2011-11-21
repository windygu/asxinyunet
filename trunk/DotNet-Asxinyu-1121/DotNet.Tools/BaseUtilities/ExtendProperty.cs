/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using NPOI.HSSF.Record.Formula.Functions;

namespace DotNet.Tools
{
	/// <summary>
	/// 扩展属性类
	/// </summary>
	public static class ExtendProperty
	{	
		#region 将字符串转换为数组		
		/// <summary>
		/// 将以固定分隔符分割的规则字符串进行转换为数组
		/// </summary>
		/// <param name="strNumber">需要转换的字符串</param>
		/// <param name="spliteChar">分隔符</param>
		/// <returns>数组</returns>
		public static double[] ConvertStrToDoubleList(this string strNumber,char spliteChar)
		{
			ArrayList ar = new ArrayList () ;
			string[] strList = strNumber.Split (spliteChar );//分割
			double temp ;
			foreach (string s in strList )
			{
				if ((s!=null)&&(double.TryParse (s,out temp)))
				{					
					ar.Add(temp) ;
				}
			}
			return (double[])ar.ToArray (typeof (double)) ;
		}
		
		public static int[] ConvertStrToIntList(this string strNumber,char spliteChar)
		{
			ArrayList ar = new ArrayList () ;
			string[] strList = strNumber.Split (spliteChar );//分割
			int temp ;
			foreach (string s in strList )
			{
				if ((s!=null)&&(int.TryParse (s,out temp)))
				{					
					ar.Add(temp) ;
				}
			}
			return (int[])ar.ToArray (typeof (int)) ;
		}
		#endregion
		
		#region 获取字符串拼音及首字母
		/// <summary>
		/// 获取字符串的拼音,首字母大写
		/// </summary>
		public static string GetPingYinSpell(this string s)
		{
			return Convertor.ConvertCharactersToSpell (s ) ;
		}
		/// <summary>
		/// 获取字符串的拼音首字母,即简写
		/// </summary>
		public static string GetFirstPingYinSpell(this string s)
		{
			return Convertor.ConvertStringsToShortSpell (s ) ;
		}
		#endregion
		
		#region 汉字全角半角转换
		//// <summary>
		/// 转换为全角字符串(SBC case)
		/// </summary>
		public static string ToSBC(this string input)
		{
			char[] c = input.ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (c[i] == 32)
				{
					c[i] = (char)12288;
					continue;
				}
				if (c[i] < 127)
					c[i] = (char)(c[i] + 65248);
			}
			return new string(c);
		}
        //// <summary>
        /// 转换为半角字符串(DBC case)
        /// </summary>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
		#endregion		
	}
}
