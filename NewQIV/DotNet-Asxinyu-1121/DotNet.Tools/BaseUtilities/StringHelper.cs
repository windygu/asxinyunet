using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Tools
{
	public class StringHelper
	{
		private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
		
		#region 字符串编码转换
		/// <summary>
		/// 将 GB2312 值转换为 UTF8 字符串(如：测试 -> 娴嬭瘯 )
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		
		public static string ConvertGBToUTF8(string source)
		{
			return Encoding.GetEncoding("GB2312").GetString(Encoding.UTF8.GetBytes(source));
		}

		/// <summary>
		/// 将 UTF8 值转换为 GB2312 字符串 (如：娴嬭瘯 -> 测试)
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ConvertUTF8ToGB(string source)
		{
			return Encoding.UTF8.GetString(Encoding.GetEncoding("GB2312").GetBytes(source));
		}


		/// <summary>
		/// 由16进制转为汉字字符串（如：B2E2 -> 测 ）
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		
		public static string ConvertHexToString(string source)
		{
			byte[] oribyte = new byte[source.Length/2];
			for(int i=0;i<source.Length;i+=2)
			{
				string str = Convert.ToInt32(source.Substring(i,2),16).ToString();
				oribyte[i/2] = Convert.ToByte(source.Substring(i,2),16);
			}
			return System.Text.Encoding.Default.GetString(oribyte);
		}
		
		///<summary>
		/// 字符串转为16进制字符串（如：测 -> B2E2 ）
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>

		public static string ConvertToHex(string source)
		{
			int i = source.Length;
			string temp;
			string end="";
			byte[] array = new byte[2];
			int i1 ,i2;
			for(int j=0;j<i;j++)
			{
				temp = source.Substring(j, 1);
				array = System.Text.Encoding.Default.GetBytes(temp);
				if(array.Length.ToString()=="1")
				{
					i1=Convert.ToInt32(array[0]);
					end+=Convert.ToString(i1,16);
				}
				else
				{
					i1=Convert.ToInt32(array[0]);
					i2=Convert.ToInt32(array[1]);
					end+=Convert.ToString(i1,16);
					end+=Convert.ToString(i2,16);
				}
			}
			return end.ToUpper();
		}

		
		///<summary>
		/// 字符串转为unicode字符串（如：测试 -> &#27979;&#35797;）
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		
		public static string ConvertToUnicode(string source)
		{
			StringBuilder sa = new StringBuilder();//Unicode
			string s1;
			string s2;
			for(int i=0;i<source.Length;i++)
			{
				byte[] bt = System.Text.Encoding.Unicode.GetBytes(source.Substring(i,1));
				if(bt.Length>1)//判断是否汉字
				{
					s1=Convert.ToString((short)(bt[1] - '\0'),16);//转化为16进制字符串
					s2=Convert.ToString((short)(bt[0] - '\0'),16);//转化为16进制字符串
					s1=(s1.Length==1?"0":"")+s1;//不足位补0
					s2=(s2.Length==1?"0":"")+s2;//不足位补0
					sa.Append("&#"+Convert.ToInt32(s1+s2,16) +";");
				}
			}

			return sa.ToString();
		}

		
		
		///<summary>
		/// 字符串转为UTF8字符串（如：测试 -> \u6d4b\u8bd5）
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ConvertToUTF8(string source)
		{
			StringBuilder sb = new StringBuilder();//UTF8
			string s1;
			string s2;
			for(int i=0;i<source.Length;i++)
			{
				byte[] bt = System.Text.Encoding.Unicode.GetBytes(source.Substring(i,1));
				if(bt.Length>1)//判断是否汉字
				{
					s1=Convert.ToString((short)(bt[1] - '\0'),16);//转化为16进制字符串
					s2=Convert.ToString((short)(bt[0] - '\0'),16);//转化为16进制字符串
					s1=(s1.Length==1?"0":"")+s1;//不足位补0
					s2=(s2.Length==1?"0":"")+s2;//不足位补0
					sb.Append("\\u"+s1+s2);
				}
			}
			return sb.ToString();
		}
		
		/// <summary>
		/// 转化为ASC码方法
		/// </summary>
		/// <param name="txt">字符</param>
		/// <returns>Ascii码</returns>
		public string ConvertToAsc(string source)
		{
			string newtxt="";
			foreach (char c in source)
			{
				newtxt+=Convert.ToString((int)c);
			}
			return newtxt;
		}
		#endregion
		
		#region 获得某个字符串在另个字符串中出现的次数
		/// <summary>
		///  获得某个字符串在另个字符串中出现的次数
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strSymbol">符号</param>
		/// <returns>返回值</returns>
		public static int GetStrCount(string strOriginal, string strSymbol)
		{
			int count = 0;
			for (int i = 0; i < (strOriginal.Length - strSymbol.Length + 1); i++)
			{
				if (strOriginal.Substring(i, strSymbol.Length) == strSymbol)
				{
					count = count + 1;
				}
			}
			return count;
		}
		#endregion
		
		#region  获得某个字符串在另个字符串第一次出现时前面所有字符
		/// <summary>
		/// 获得某个字符串在另个字符串第一次出现时前面所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strSymbol">符号</param>
		/// <returns>返回值</returns>
		public static string GetFirstStr(string strOriginal, string strSymbol)
		{
			int strPlace = strOriginal.IndexOf(strSymbol);
			if (strPlace != -1)
				strOriginal = strOriginal.Substring(0, strPlace);
			return strOriginal;
		}
		#endregion

		#region 获得某个字符串在另个字符串最后一次出现时后面所有字符
		/// <summary>
		/// 获得某个字符串在另个字符串最后一次出现时后面所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strSymbol">符号</param>
		/// <returns>返回值</returns>
		public static string GetLastStr(string strOriginal, string strSymbol)
		{
			int strPlace = strOriginal.LastIndexOf(strSymbol) + strSymbol.Length;
			strOriginal = strOriginal.Substring(strPlace);
			return strOriginal;
		}
		#endregion
		
		#region 获得两个字符之间第一次出现时前面所有字符
		/// <summary>
		/// 获得两个字符之间第一次出现时前面所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strFirst">最前哪个字符</param>
		/// <param name="strLast">最后哪个字符</param>
		/// <returns>返回值</returns>
		public static string GetTwoMiddleFirstStr(string strOriginal, string strFirst, string strLast)
		{
			strOriginal = GetFirstStr(strOriginal, strLast);
			strOriginal = GetLastStr(strOriginal, strFirst);
			return strOriginal;
		}
		#endregion

		#region 获得两个字符之间最后一次出现时的所有字符
		/// <summary>
		///  获得两个字符之间最后一次出现时的所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strFirst">最前哪个字符</param>
		/// <param name="strLast">最后哪个字符</param>
		/// <returns>返回值</returns>
		public static string GetTwoMiddleLastStr(string strOriginal, string strFirst, string strLast)
		{
			strOriginal = GetLastStr(strOriginal, strFirst);
			strOriginal = GetFirstStr(strOriginal, strLast);
			return strOriginal;
		}
		#endregion
		
		#region 从数据库表读记录时,能正常显示
		/// <summary>
		/// 从数据库表读记录时,能正常显示
		/// </summary>
		/// <param name="strContent">要处理的字符</param>
		/// <returns>返回正常值</returns>
		public static string GetHtmlFormat(string strContent)
		{
			strContent = strContent.Trim();

			if (strContent == null)
			{
				return "";
			}
			strContent = strContent.Replace("<", "<");
			strContent = strContent.Replace(">", ">");
			strContent = strContent.Replace("\n", "<br />");
			return (strContent);
		}
		#endregion
		
		#region 检查相等之后，获得字符串
		/// <summary>
		/// 检查相等之后，获得字符串
		/// </summary>
		/// <param name="str"></param>
		/// <param name="checkStr"></param>
		/// <param name="reStr"></param>
		/// <returns></returns>
		public static string GetCheckStr<T>(T str, T checkStr, string reStr)
		{
			if (str.Equals(checkStr))
			{
				return reStr;
			}
			return "";
		}
		#endregion
				
		#region 高亮显示字符串
		/// <summary>
		/// 高亮显示
		/// </summary>
		/// <param name="str">原字符串</param>
		/// <param name="findstr">查找字符串</param>
		/// <param name="cssclass">Style</param>
		/// <returns>string</returns>
		public static string OutHighlightText(string str, string findstr, string cssclass)
		{
			if (findstr != "")
			{
				string text1 = "<span class=\"" + cssclass + "\">%s</span>";
				str = str.Replace(findstr, text1.Replace("%s", findstr));
			}
			return str;
		}
		#endregion

		#region 移除字符串首尾某些字符

		/// <summary>
		/// 移除字符串首尾某些字符
		/// </summary>
		/// <param name="strOriginal">要操作的字符串</param>
		/// <param name="startStr">要在字符串首部移除的字符串</param>
		/// <param name="endStr">要在字符串尾部移除的字符串</param>
		/// <returns>string</returns>
		public static string RemoveStartOrEndStr(string strOriginal, string startStr, string endStr)
		{
			char[] start = startStr.ToCharArray();
			char[] end = endStr.ToCharArray();
			return strOriginal.TrimStart(start).TrimEnd(end);
		}
		#endregion

		#region 删除指定位置指定长度字符串
		/// <summary>
		/// 删除指定位置指定长度字符串
		/// </summary>
		/// <param name="strOriginal">要操作的字符串</param>
		/// <param name="startIndex">开始删除字符的位置</param>
		/// <param name="count">要删除的字符数</param>
		/// <returns>string</returns>
		public static string RemoveStr(string strOriginal, int startIndex, int count)
		{
			return strOriginal.Remove(startIndex, count);
		}
		#endregion

		#region 从左边填充字符串

		/// <summary>
		/// 从左边填充字符串
		/// </summary>
		/// <param name="strOriginal">要操作的字符串</param>
		/// <param name="totalWidth">结果字符串中的字符数</param>
		/// <param name="paddingChar">填充的字符</param>
		/// <returns>string</returns>
		public static string LeftPadStr(string strOriginal, int totalWidth, char paddingChar)
		{
			if (strOriginal.Length < totalWidth)
				return strOriginal.PadLeft(totalWidth, paddingChar);
			return strOriginal;
		}
		#endregion

		#region  从右边填充字符串
		/// <summary>
		/// 从右边填充字符串
		/// </summary>
		/// <param name="strOriginal">要操作的字符串</param>
		/// <param name="totalWidth">结果字符串中的字符数</param>
		/// <param name="paddingChar">填充的字符</param>
		/// <returns>string</returns>
		public static string RightPadStr(string strOriginal, int totalWidth, char paddingChar)
		{
			if (strOriginal.Length < totalWidth)
				return strOriginal.PadRight(totalWidth, paddingChar);
			return strOriginal;
		}
		#endregion		
			
		#region 返回字符串真实长度, 1个汉字长度为2
		
		/// <summary>
		/// 返回字符串真实长度, 1个汉字长度为2
		/// </summary>
		/// <returns></returns>
		public static int GetStringLength(string str)
		{
			return Encoding.Default.GetBytes(str).Length;
		}
		#endregion
		
		#region 判断指定字符串在指定字符串数组中的位置
		
		/// <summary>
		/// 判断指定字符串在指定字符串数组中的位置
		/// </summary>
		/// <param name="strSearch">字符串</param>
		/// <param name="stringArray">字符串数组</param>
		/// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
		/// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
		public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
		{
			for (int i = 0; i < stringArray.Length; i++)
			{
				if (caseInsensetive)
				{
					if (strSearch.ToLower() == stringArray[i].ToLower())
					{
						return i;
					}
				}
				else
				{
					if (strSearch == stringArray[i])
					{
						return i;
					}
				}

			}
			return -1;
		}
		#endregion

		#region 删除字符串尾部的回车/换行/空格
		/// <summary>
		/// 删除字符串尾部的回车/换行/空格
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string RTrim(string str)
		{
			for (int i = str.Length; i >= 0; i--)
			{
				if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
				{
					str.Remove(i, 1);
				}
			}
			return str;
		}
		#endregion
		
		#region 清除给定字符串中的回车及换行符
		/// <summary>
		/// 清除给定字符串中的回车及换行符
		/// </summary>
		/// <param name="str">要清除的字符串</param>
		/// <returns>清除后返回的字符串</returns>
		public static string ClearBR(string str)
		{
			Match m = null;
			for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
			{
				str = str.Replace(m.Groups[0].ToString(), "");
			}
			return str;
		}
		#endregion

		#region 字符串如果操过指定长度则将超出的部分用指定字符串代替
		/// <summary>
		/// 字符串如果操过指定长度则将超出的部分用指定字符串代替
		/// </summary>
		/// <param name="p_SrcString">要检查的字符串</param>
		/// <param name="p_Length">指定长度</param>
		/// <param name="p_TailString">用于替换的字符串</param>
		/// <returns>截取后的字符串</returns>
		public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
		{
			return GetSubString(p_SrcString, 0, p_Length, p_TailString);
		}
		#endregion

		#region 取指定长度的字符串
		/// <summary>
		/// 取指定长度的字符串
		/// </summary>
		/// <param name="p_SrcString">要检查的字符串</param>
		/// <param name="p_StartIndex">起始位置</param>
		/// <param name="p_Length">指定长度</param>
		/// <param name="p_TailString">用于替换的字符串</param>
		/// <returns>截取后的字符串</returns>
		public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
		{


			string myResult = p_SrcString;

			//当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
			if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") ||
			    System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
			{
				//当截取的起始位置超出字段串长度时
				if (p_StartIndex >= p_SrcString.Length)
				{
					return "";
				}
				else
				{
					return p_SrcString.Substring(p_StartIndex,
					                             ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
				}
			}


			if (p_Length >= 0)
			{
				byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

				//当字符串长度大于起始位置
				if (bsSrcString.Length > p_StartIndex)
				{
					int p_EndIndex = bsSrcString.Length;

					//当要截取的长度在字符串的有效长度范围内
					if (bsSrcString.Length > (p_StartIndex + p_Length))
					{
						p_EndIndex = p_Length + p_StartIndex;
					}
					else
					{   //当不在有效范围内时,只取到字符串的结尾

						p_Length = bsSrcString.Length - p_StartIndex;
						p_TailString = "";
					}



					int nRealLength = p_Length;
					int[] anResultFlag = new int[p_Length];
					byte[] bsResult = null;

					int nFlag = 0;
					for (int i = p_StartIndex; i < p_EndIndex; i++)
					{

						if (bsSrcString[i] > 127)
						{
							nFlag++;
							if (nFlag == 3)
							{
								nFlag = 1;
							}
						}
						else
						{
							nFlag = 0;
						}

						anResultFlag[i] = nFlag;
					}

					if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
					{
						nRealLength = p_Length + 1;
					}

					bsResult = new byte[nRealLength];

					Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

					myResult = Encoding.Default.GetString(bsResult);

					myResult = myResult + p_TailString;
				}
			}

			return myResult;
		}
		#endregion

		#region 自定义的替换字符串函数
		/// <summary>
		/// 自定义的替换字符串函数
		/// </summary>
		public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
		{
			return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
		}
		#endregion
		
		#region 分割字符串
		/// <summary>
		/// 分割字符串
		/// </summary>
		public static string[] SplitString(string strContent, string strSplit)
		{
			if (strContent.IndexOf(strSplit) < 0)
			{
				string[] tmp = { strContent };
				return tmp;
			}
			return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// 分割字符串
		/// </summary>
		/// <param name="strContent">待分割字符串</param>
		/// <param name="strSplit">分隔符</param>
		/// <param name="p_3">指定分割数组大小</param>
		/// <returns>string[]</returns>
		public static string[] SplitString(string strContent, string strSplit, int p_3)
		{
			string[] result = new string[p_3];

			string[] splited = SplitString(strContent, strSplit);

			for (int i = 0; i < p_3; i++)
			{
				if (i < splited.Length)
					result[i] = splited[i];
				else
					result[i] = string.Empty;
			}

			return result;
		}
		#endregion		
		
	}
}
