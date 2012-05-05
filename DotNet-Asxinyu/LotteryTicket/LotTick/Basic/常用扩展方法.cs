using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace LotTick
{
    #region 常规的扩展方法类
    public static class ExtendsExpress
    {
        #region 扩展方法
        /// <summary>
        /// 根据字符串获取指定类型的枚举值
        /// </summary>
        public static T ToEnum<T>(this string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        public static bool IsNullEmpty(this IEnumerable source)
        {
            if (source == null) return true;
            foreach (var item in source)
                return false;
            return true;
        }
        /// <summary>
        /// 将对象转换为DataTable
        /// </summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            colType = colType.GetGenericArguments()[0];
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        #endregion

        #region 将int数组转换为字符串
        /// <summary>
        /// 将int数组转换为字符串
        /// </summary>        
        public static string ListToString(this int[] source)
        {
            string res = source [0].ToString () ;
            for (int i = 1; i < source.Length ; i++)
            {
                res += ("-" + source[i].ToString());
            }
            return res;
        }
        #endregion

        #region 比较2个序列是否相等
        public static bool IsEqual<T>(this IEnumerable<T> source, IEnumerable<T> compList) where T : IComparable
        {
            if (source.Count() != compList.Count()) return false;
            else
            {
                T[] s1 = source.ToArray();
                T[] s2 = source.ToArray();
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i].CompareTo(s2[i]) != 0) return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 将数组转换为字符串序列,通过逗号拼接
        /// </summary>
        public static string ListToString<T>(this IEnumerable<T> source)
        {
            string res = "";
            T[] s = source.ToArray();
            for (int i = 0; i < s.Length - 1; i++)
            {
                res += (s[i].ToString() + ",");
            }
            res += s[s.Length - 1].ToString();
            return res;
        }
        #endregion

        #region 获取邻号出现的个数
        /// <summary>
        /// 获取上期的邻号在当前期出现的个数
        /// </summary>
        /// <param name="source">本期数据</param>
        /// <param name="LastSouce">上期数据或者指定期数据</param>
        /// <returns>上期邻号在本期出现的个数</returns>
        public static int Index_S邻号出现个数(this IEnumerable<int> source, IEnumerable<int> LastSouce)
        {
            int count = 0;
            double temp = 0;
            foreach (int item in source)
            {
                foreach (int cur in LastSouce)
                {
                    temp = Math.Abs(item - cur);
                    if (temp == 1 || temp == 32) count++;
                }
            }
            return count;
        }
        #endregion

        #region 获取2个序列的重复号码个数
        /// <summary>
        /// 获取2个序列的重复号码个数
        /// </summary>
        /// <returns>返回重复号码的个数</returns>
        public static int Index_S序列重复个数(this IEnumerable<int> source, IEnumerable<int> compareSouce)
        {
            int count = 0;
            foreach (int item in source)
            {
                if (compareSouce.Contains(item)) count++;
            }
            return count;
        }
        #endregion

        #region 统计次数与频率-多对多
        /// <summary>
        /// 计算在所有当前数据中，号码出现的频率(百分比)
        /// </summary>
        public static double[] Index_S号码频率(this IEnumerable<int[]> source, int maxNumber = 33)
        {
            //先从最后一列找出最大值,确定出现的最大数字
            int[] numbers = new int[maxNumber];
            foreach (var item in source)
            {
                foreach (var s in item)
                {
                    numbers[s + 1]++;
                }
            }
            int allNumbers = numbers.Sum();
            return numbers.Select(n => ((double)n) / ((double)allNumbers)).ToArray();
        }
        #endregion

        #region 跨度列表
        /// <summary>
        /// 计算跨度列表
        /// </summary>
        public static int[] Index_SP跨度列表(this int[] source)
        {
            int[] res = new int[source.Length];
            for (int i = 0; i < source.Length - 1; i++)
            {
                res[i] = source[i + 1] - source[i];
            }
            return res;
        }
        #endregion

        #region 比较2个序列是不是一样的
        /// <summary>
        /// 比较2个序列是不是一样的
        /// </summary>        
        public static bool Index_SP比较序列(this int[] source,int[] compareList)
        {
            if (source.Length != compareList.Length) return false;
            for (int i = 0; i < source.Length ; i++)
            {
                if (source[i] != compareList[i]) return false;
            }
            return true;
        }
        #endregion
    }
    #endregion
}
