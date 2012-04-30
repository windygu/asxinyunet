using System;
using System.Linq;

namespace LotTick
{
    #region 比较类型枚举
    /// <summary>
    /// 比较类型
    /// </summary>
    public enum ECompareType
    {
        /// <summary>
        /// 相等匹配
        /// </summary>
        Equal,

        /// <summary>
        /// 一定范围内,上下限:[a,b]
        /// </summary>
        RangeLimite,

        /// <summary>
        /// 小于或等于
        /// </summary>
        LessThanLimite,

        /// <summary>
        /// 大于或等于
        /// </summary>
        GreaterThanLimite,

        /// <summary>
        /// 包含在列表中
        /// </summary>
        InList,
        /// <summary>
        /// 不包含在列表中
        /// </summary>
        NotInList
    }
    #endregion

    /// <summary>
    /// 比较参数类
    /// </summary>
    public class CompareParams
    {
        /// <summary>
        /// 参数类构造函数，下限-上限- 数字1，数字2，数字3-其他参数
        /// </summary>
        /// <param name="IndexName">条件字符串形式,格式：2-2-1,2,3-2,3-2</param>
        public CompareParams(string conditions)
        {
            string[] str = conditions.Split("-");
            if (str.Length == 1) this.FloorLimit = Convert.ToInt32(str[0]);
            else if (str.Length == 2)
            {
                this.FloorLimit = Convert.ToInt32(str[0]);
                this.CeilLimit = Convert.ToInt32(str[1]);                
            }
            else if (str.Length ==3)
            {
                this.FloorLimit = Convert.ToInt32(str[0]);
                this.CeilLimit = Convert.ToInt32(str[1]);
                this.CompList = str[2].Split(',').Select(n =>Convert.ToInt32(n)).ToArray();
            }
            else if (str.Length >=4)
            {
                this.FloorLimit = Convert.ToInt32(str[0]);
                this.CeilLimit = Convert.ToInt32(str[1]);
                this.CompList = str[2].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                this.ParamsValue = str[3];
            }
        }
        /// <summary>
        /// 范围上限
        /// </summary>
        public int CeilLimit { get; set; }

        /// <summary>
        /// 范围下限
        /// </summary>
        public int FloorLimit { get; set; }

        /// <summary>
        /// 对比列表
        /// </summary>
        public int[] CompList { get; set; }

        /// <summary>
        /// 其他参数
        /// </summary>
        public string ParamsValue { get; set; }
    }
}
