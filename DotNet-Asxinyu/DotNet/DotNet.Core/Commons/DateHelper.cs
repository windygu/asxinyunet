using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Core.Commons
{
	/// <summary>
	/// 日期时间类
	/// </summary>
	public  class DateHelper
	{
		#region 取每月的第一/最末一天
		/// <summary>
		/// 取每月的第一/最末一天
		/// </summary>
		/// <param name="time">传入时间</param>
		/// <param name="firstDay">第一天还是最末一天</param>
		/// <returns></returns>
		public static DateTime DayOfMonth(DateTime time, bool firstDay)
		{
			DateTime time1 = new DateTime(time.Year, time.Month, 1);
			if (firstDay) return time1;
			else return time1.AddMonths(1).AddDays(-1);
		}
		#endregion
		
		#region 取每季度的第一/最末一天
		/// <summary>
		/// 取每季度的第一/最末一天
		/// </summary>
		/// <param name="time">传入时间</param>
		/// <param name="firstDay">第一天还是最末一天</param>
		/// <returns></returns>
		public static DateTime DayOfQuarter(DateTime time, bool firstDay)
		{
			int m = 0;
			switch (time.Month)
			{
				case 1:
				case 2:
				case 3:
					m = 1; break;
				case 4:
				case 5:
				case 6:
					m = 4; break;
				case 7:
				case 8:
				case 9:
					m = 7; break;
				case 10:
				case 11:
				case 12:
					m = 11; break;
			}

			DateTime time1 = new DateTime(time.Year, m, 1);
			if (firstDay) return time1;
			else return time1.AddMonths(3).AddDays(-1);
		}
		#endregion
		
		#region  取每年的第一/最末一天
		/// <summary>
		/// 取每年的第一/最末一天
		/// </summary>
		/// <param name="time">传入时间</param>
		/// <param name="firstDay">第一天还是最末一天</param>
		/// <returns></returns>
		public static DateTime DayOfYear(DateTime time, bool firstDay)
		{
			if (firstDay) return new DateTime(time.Year, 1, 1);
			else return new DateTime(time.Year, 12, 31);
		}
		#endregion
		
		#region 返回标准日期格式string(yyyy-MM-dd)
		/// <summary>
		/// 返回标准日期格式string(yyyy-MM-dd)
		/// </summary>
		public static string GetDate()
		{
			return DateTime.Now.ToString("yyyy-MM-dd");
		}
		#endregion
		
		#region 返回指定日期格式
		/// <summary>
		/// 返回指定日期格式
		/// </summary>
		public static string GetDate(string datetimestr, string replacestr)
		{
			if (datetimestr == null)
			{
				return replacestr;
			}

			if (datetimestr.Equals(""))
			{
				return replacestr;
			}

			try
			{
				datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
			}
			catch
			{
				return replacestr;
			}
			return datetimestr;

		}

		#endregion
		
		#region 返回标准时间格式string
		/// <summary>
		/// 返回标准时间格式string
		/// </summary>
		public static string GetTime()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}
		#endregion
		
		#region 返回标准时间格式string
		/// <summary>
		/// 返回标准时间格式string
		/// </summary>
		public static string GetDateTime()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
		#endregion
		
		#region 返回相对于当前时间的相对天数
		/// <summary>
		/// 返回相对于当前时间的相对天数
		/// </summary>
		public static string GetDateTime(int relativeday)
		{
			return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
		}
		#endregion

		#region 返回标准时间格式string
		/// <summary>
		/// 返回标准时间格式string
		/// </summary>
		public static string GetDateTimeF()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
		}

		#endregion
		
		#region 返回标准时间
		/// <summary>
		/// 返回标准时间
		/// </sumary>
		public static string GetStandardDateTime(string fDateTime, string formatStr)
		{
			if (fDateTime == "0000-0-0 0:00:00")
			{

				return fDateTime;
			}
			DateTime s = Convert.ToDateTime(fDateTime);
			return s.ToString(formatStr);
		}
		#endregion
		
		#region  返回标准时间 yyyy-MM-dd HH:mm:ss
		/// <summary>
		/// 返回标准时间 yyyy-MM-dd HH:mm:ss
		/// </sumary>
		public static string GetStandardDateTime(string fDateTime)
		{
			return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
		}
		#endregion
		
		#region 返回相差的秒数
		/// <summary>
		/// 返回相差的秒数
		/// </summary>
		/// <param name="Time"></param>
		/// <param name="Sec"></param>
		/// <returns></returns>
		public static int StrDateDiffSeconds(string Time, int Sec)
		{
			TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
			if (ts.TotalSeconds > int.MaxValue)
			{
				return int.MaxValue;
			}
			else if (ts.TotalSeconds < int.MinValue)
			{
				return int.MinValue;
			}
			return (int)ts.TotalSeconds;
		}
		#endregion
		
		#region 返回相差的分钟数
		/// <summary>
		/// 返回相差的分钟数
		/// </summary>
		/// <param name="time"></param>
		/// <param name="minutes"></param>
		/// <returns></returns>
		public static int StrDateDiffMinutes(string time, int minutes)
		{
			if (time == "" || time == null)
				return 1;
			TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
			if (ts.TotalMinutes > int.MaxValue)
			{
				return int.MaxValue;
			}
			else if (ts.TotalMinutes < int.MinValue)
			{
				return int.MinValue;
			}
			return (int)ts.TotalMinutes;
		}
		#endregion

		#region 返回相差的小时数
		/// <summary>
		/// 返回相差的小时数
		/// </summary>
		/// <param name="time"></param>
		/// <param name="hours"></param>
		/// <returns></returns>
		public static int StrDateDiffHours(string time, int hours)
		{
			if (time == "" || time == null)
				return 1;
			TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
			if (ts.TotalHours > int.MaxValue)
			{
				return int.MaxValue;
			}
			else if (ts.TotalHours < int.MinValue)
			{
				return int.MinValue;
			}
			return (int)ts.TotalHours;
		}
		#endregion		
				
		#region 返回本年有多少天
		/// <summary>返回本年有多少天</summary>
		/// <param name="iYear">年份</param>
		/// <returns>本年的天数</returns>
		public static int GetDaysOfYear(int iYear)
		{
			return IsRuYear(iYear) ? 366 : 365;
		}


		/// <summary>本年有多少天</summary>
		/// <param name="dt">日期</param>
		/// <returns>本天在当年的天数</returns>
		public static int GetDaysOfYear(DateTime dt)
		{
			return IsRuYear(dt.Year) ? 366 : 365;
		}
		#endregion

		#region 本月有多少天
		/// <summary>本月有多少天</summary>
		/// <param name="iYear">年</param>
		/// <param name="Month">月</param>
		/// <returns>天数</returns>
		public static int GetDaysOfMonth(int iYear, int Month)
		{
			var days = 0;
			switch (Month)
			{
				case 1:
					days = 31;
					break;
				case 2:
					days = IsRuYear(iYear) ? 29 : 28;
					break;
				case 3:
					days = 31;
					break;
				case 4:
					days = 30;
					break;
				case 5:
					days = 31;
					break;
				case 6:
					days = 30;
					break;
				case 7:
					days = 31;
					break;
				case 8:
					days = 31;
					break;
				case 9:
					days = 30;
					break;
				case 10:
					days = 31;
					break;
				case 11:
					days = 30;
					break;
				case 12:
					days = 31;
					break;
			}

			return days;
		}


		/// <summary>本月有多少天</summary>
		/// <param name="dt">日期</param>
		/// <returns>天数</returns>
		public static int GetDaysOfMonth(DateTime dt)
		{
			//--------------------------------//
			//--从dt中取得当前的年，月信息  --//
			//--------------------------------//
			int days = 0;
			int year = dt.Year;
			int month = dt.Month;

			//--利用年月信息，得到当前月的天数信息。
			switch (month)
			{
				case 1:
					days = 31;
					break;
				case 2:
					days = IsRuYear(year) ? 29 : 28;
					break;
				case 3:
					days = 31;
					break;
				case 4:
					days = 30;
					break;
				case 5:
					days = 31;
					break;
				case 6:
					days = 30;
					break;
				case 7:
					days = 31;
					break;
				case 8:
					days = 31;
					break;
				case 9:
					days = 30;
					break;
				case 10:
					days = 31;
					break;
				case 11:
					days = 30;
					break;
				case 12:
					days = 31;
					break;
			}
			return days;
		}
		#endregion

		#region 返回当前日期的星期名称
		/// <summary>返回当前日期的星期名称</summary>
		/// <param name="dt">日期</param>
		/// <returns>星期名称</returns>
		public static string GetWeekNameOfDay(DateTime dt)
		{
			string week = string.Empty;
			switch (dt.DayOfWeek)
			{
				case DayOfWeek.Monday:
					week = "星期一";
					break;
				case DayOfWeek.Tuesday:
					week = "星期二";
					break;
				case DayOfWeek.Wednesday:
					week = "星期三";
					break;
				case DayOfWeek.Thursday:
					week = "星期四";
					break;
				case DayOfWeek.Friday:
					week = "星期五";
					break;
				case DayOfWeek.Saturday:
					week = "星期六";
					break;
				case DayOfWeek.Sunday:
					week = "星期日";
					break;
			}
			return week;
		}
		#endregion

		#region 返回当前日期的星期编号
		/// <summary>返回当前日期的星期编号</summary>
		/// <param name="dt">日期</param>
		/// <returns>星期数字编号</returns>
		public static int GetWeekNumberOfDay(DateTime dt)
		{
			int week = 0;
			switch (dt.DayOfWeek)
			{
				case DayOfWeek.Monday:
					week = 1;
					break;
				case DayOfWeek.Tuesday:
					week = 2;
					break;
				case DayOfWeek.Wednesday:
					week = 3;
					break;
				case DayOfWeek.Thursday:
					week = 4;
					break;
				case DayOfWeek.Friday:
					week = 5;
					break;
				case DayOfWeek.Saturday:
					week = 6;
					break;
				case DayOfWeek.Sunday:
					week = 7;
					break;
			}
			return week;
		}
		#endregion

		#region 根据某年的第几周获取这周的起止日期
		/// <summary>
		/// 根据某年的第几周获取这周的起止日期
		/// </summary>
		/// <param name="year"></param>
		/// <param name="weekOrder"></param>
		/// <param name="firstDate"></param>
		/// <param name="lastDate"></param>
		/// <returns></returns>
		public static void WeekRange(int year, int weekOrder, ref DateTime firstDate, ref DateTime lastDate)
		{
			//当年的第一天
			var firstDay = new DateTime(year, 1, 1);

			//当年的第一天是星期几
			int firstOfWeek = Convert.ToInt32(firstDay.DayOfWeek);

			//计算当年第一周的起止日期，可能跨年
			int dayDiff = (-1)*firstOfWeek + 1;
			int dayAdd = 7 - firstOfWeek;

			firstDate = firstDay.AddDays(dayDiff).Date;
			lastDate = firstDay.AddDays(dayAdd).Date;

			//如果不是要求计算第一周
			if (weekOrder != 1)
			{
				int addDays = (weekOrder - 1)*7;
				firstDate = firstDate.AddDays(addDays);
				lastDate = lastDate.AddDays(addDays);
			}
		}
		#endregion

		#region 返回两个日期之间相差的天数
		/// <summary>
		/// 返回两个日期之间相差的天数
		/// </summary>
		/// <param name="dtfrm">两个日期参数</param>
		/// <param name="dtto">两个日期参数</param>
		/// <returns>天数</returns>
		public static int DiffDays(DateTime dtfrm, DateTime dtto)
		{
			TimeSpan tsDiffer = dtto.Date - dtfrm.Date;
			return tsDiffer.Days;
		}
		#endregion

		#region 判断当前年份是否是闰年
		/// <summary>判断当前年份是否是闰年，私有函数</summary>
		/// <param name="iYear">年份</param>
		/// <returns>是闰年：True ，不是闰年：False</returns>
		public static bool IsRuYear(int iYear)
		{
			//形式参数为年份
			//例如：2003
			int n = iYear;
			return (n%400 == 0) || (n%4 == 0 && n%100 != 0);
		}
		#endregion
	}
}
