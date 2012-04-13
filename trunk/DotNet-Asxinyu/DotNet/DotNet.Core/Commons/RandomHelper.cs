using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Commons
{
	public class RandomHelper
	{
		static readonly char[] Pattern = new char[] { 'A', 'B',
			'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
			'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
		public static int Minimum = 100000;
		public static int Maximal = 999999;
		public static int RandomLength = 6;

		private static string RandomString = "123456789ABCDEFGHIJKMLNPQRSTUVWXYZ";
		private static Random Random = new Random(DateTime.Now.Second);

		#region public static string GetRandomString() 产生随机字符
		/// <summary>
		/// 产生随机字符
		/// </summary>
		/// <returns>字符串</returns>
		public static string GetRandomString()
		{
			string returnValue = string.Empty;
			for (int i = 0; i < RandomLength; i++)
			{
				int r = Random.Next(0, RandomString.Length - 1);
				returnValue += RandomString[r];
			}
			return returnValue;
		}
		#endregion

		#region public static int GetRandom()
		/// <summary>
		/// 产生随机数
		/// </summary>
		/// <returns>随机数</returns>
		public static int GetRandom()
		{
			return Random.Next(Minimum, Maximal);
		}
		#endregion

		#region public static int GetRandom(int minimum, int maximal)
		/// <summary>
		/// 产生随机数
		/// </summary>
		/// <param name="minimum">最小值</param>
		/// <param name="maximal">最大值</param>
		/// <returns>随机数</returns>
		public static int GetRandom(int minimum, int maximal)
		{
			return Random.Next(minimum, maximal);
		}
		#endregion
		
		#region 获得随机数字
		
		/// <summary>
		/// 获得随机数字
		/// </summary>
		/// <param name="Length">随机数字的长度</param>
		/// <returns>返回长度为 Length 的　<see cref="System.Int32"/> 类型的随机数</returns>
		/// <example>
		/// Length 不能大于9,以下为示例演示了如何调用 GetRandomNext：<br />
		/// <code>
		///  int le = GetRandomNext(8);
		/// </code>
		/// </example>
		public static int GetRandomNext(int Length)
		{
			if (Length > 9)
				throw new System.IndexOutOfRangeException("Length的长度不能大于10");
			Guid gu = Guid.NewGuid();
			string str = "";
			for (int i = 0; i < gu.ToString().Length; i++)
			{
				if (Validator.IsNumber(gu.ToString()[i].ToString ()))
				{
					str += ((gu.ToString()[i]));
				}
			}
			int guid = int.Parse(str.Replace("-", "").Substring(0, Length));
			if (!guid.ToString().Length.Equals(Length))
				guid = GetRandomNext(Length);
			return guid;
		}
		#endregion
		
		#region 生成随机数字
		/// <summary>
		/// 生成随机数字
		/// </summary>
		/// <param name="length">生成长度</param>
		/// <returns></returns>
		public static string Number(int Length)
		{
			return Number(Length, false);
		}

		/// <summary>
		/// 生成随机数字
		/// </summary>
		/// <param name="Length">生成长度</param>
		/// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
		/// <returns></returns>
		public static string Number(int Length, bool Sleep)
		{
			if (Sleep)
				System.Threading.Thread.Sleep(3);
			string result = "";
			System.Random random = new Random();
			for (int i = 0; i < Length; i++)
			{
				result += random.Next(10).ToString();
			}
			return result;
		}
		#endregion

		#region 生成随机字母与数字
		/// <summary>
		/// 生成随机字母与数字
		/// </summary>
		/// <param name="IntStr">生成长度</param>
		/// <returns></returns>
		public static string Str(int Length)
		{
			return Str(Length, false);
		}
		/// <summary>
		/// 生成随机字母与数字
		/// </summary>
		/// <param name="Length">生成长度</param>
		/// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
		/// <returns></returns>
		public static string Str(int Length, bool Sleep)
		{
			if (Sleep)
				System.Threading.Thread.Sleep(3);
			string result = "";
			int n = Pattern.Length;
			System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
			for (int i = 0; i < Length; i++)
			{
				int rnd = random.Next(0, n);
				result += Pattern[rnd];
			}
			return result;
		}
		#endregion

		#region 生成随机纯字母随机数
		/// <summary>
		/// 生成随机纯字母随机数
		/// </summary>
		/// <param name="IntStr">生成长度</param>
		/// <returns></returns>
		public static string Str_char(int Length)
		{
			return Str_char(Length, false);
		}

		/// <summary>
		/// 生成随机纯字母随机数
		/// </summary>
		/// <param name="Length">生成长度</param>
		/// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
		/// <returns></returns>
		public static string Str_char(int Length, bool Sleep)
		{
			if (Sleep)
				System.Threading.Thread.Sleep(3);
			string result = "";
			int n = Pattern.Length;
			System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
			for (int i = 0; i < Length; i++)
			{
				int rnd = random.Next(0, n);
				result += Pattern[rnd];
			}
			return result;
		}
		#endregion
	}
}
