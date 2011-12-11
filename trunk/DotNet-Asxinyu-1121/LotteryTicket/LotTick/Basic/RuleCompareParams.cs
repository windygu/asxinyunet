using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 比较参数类
    /// </summary>
    public class CompareParams
    {
        /// <summary>
        /// 参数类构造函数
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
                this.CompList = str[2].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
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
