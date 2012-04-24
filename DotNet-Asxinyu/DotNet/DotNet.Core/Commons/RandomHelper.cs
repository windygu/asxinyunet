using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Commons
{
	public class RandomHelper
    {
        #region 静态变量
        private static string RandomString = "ABCDEFGHIJKMLNPQRSTUVWXYZ123456789+-*/@#$%&";
		private static Random Random = new Random(DateTime.Now.Second);
        private static int MinYear = 1995;
        private static int MaxYear = 2012;
        #endregion

        #region 产生随机字符
        /// <summary>
		/// 产生随机字符
		/// </summary>
		/// <returns>字符串</returns>
        public static string GetRandomString(int RandomLength = 6)
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

        #region 产生指定范围的整数随机数
        /// <summary>
		/// 产生指定范围的整数随机数
		/// </summary>
		/// <param name="minimum">最小值</param>
		/// <param name="maximal">最大值</param>
		/// <returns>随机数</returns>
		public static int GetRandomInt(int minimum = 0,int maximal = 100)
		{   
			return Random.Next(minimum, maximal);
		}
		#endregion

        #region 获取指定范围内的双精度数字
        public static double GetRandomDouble(double min = 0 , double max = 1)
        {
            return Random.NextDouble() * (max - min);
        }
        #endregion

        #region 生成byte随机数
        public static byte GetRandomByte()
        {
            return (byte)Random.Next(0, 255);
        }
        #endregion

        #region 生成随机的布尔数
        public static bool GetRandomBool()
        {
            return Random.NextDouble() > 0.5 ? true : false;
        }
        #endregion

        #region 生成随机的日期数据
        public static DateTime GetRandomDateTime()
        {
            return new DateTime(Random.Next(MinYear, MaxYear), Random.Next(1, 12), Random.Next(1, 28),
                Random.Next(0, 23), Random.Next(0, 59), Random.Next(0, 59));
        }
        #endregion
    }
}
