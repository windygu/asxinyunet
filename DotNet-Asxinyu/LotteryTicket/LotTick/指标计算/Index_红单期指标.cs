using System.Collections;
using System.Linq;

namespace LotTick
{
    #region 红和值
    /// <summary>
    /// 红和值
    /// </summary>
    public class Index_红和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Sum();
        }
    }
    #endregion

    #region 大号个数，>=17
    /// <summary>
    /// 大号个数，>=17
    /// </summary>
    public class Index_红大号个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Where(k => k >= 17).Count();
        }
    }
    #endregion

    #region 红跨度和值
    /// <summary>
    /// 红跨度和值
    /// </summary>
    public class Index_红跨度和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Last() - data.NormalData.First();
        }
    }
    #endregion

    #region 红连号个数
    /// <summary>
    ///连号个数-修改完成
    /// </summary>
    public class Index_红连号个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.ContinuesNoCount();
        }
    }
    #endregion

    #region 红求余覆盖数
    /// <summary>
    /// Index_红求余覆盖数
    /// </summary>
    public class Index_红求余覆盖数 : LotIndex
    {
        int L;

        /// <summary>
        /// 需要自定义的长度L
        /// </summary>        
        public Index_红求余覆盖数(RuleInfo ruleInfo, bool isDeleteMode = false)
        {
            this.RuleInfoParams = ruleInfo;
            IsDeleteNumberMode = isDeleteMode;
            if (ruleInfo.CondtionParams.ParamsValue != null)
            {
                L = Convert.ToInt32(ruleInfo.CondtionParams.ParamsValue);
            }
            else
            {
                L = 17;
            }
        }
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => ((int)n) % L).Distinct().Count();
        }
    }
    #endregion

    #region 偶号连续数
    /// <summary>
    /// 偶号连续数,修改完成
    /// </summary>
    public class Index_红偶号连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            bool[] res = data.NormalData.Select(n => n % 2 == 0).ToArray();
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }
    }
    #endregion

    #region 红偶数个数
    /// <summary>
    /// Index_红偶数个数，修改完成
    /// </summary>
    public class Index_红偶数个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Where(n => ((int)n) % 2 == 0).Count();
        }
    }
    #endregion

    #region 红奇号连续数
    /// <summary>
    /// Index_红奇号连续数
    /// </summary>
    public class Index_红奇号连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.GetContinuesOddCount ();
        }        
    }
    #endregion

    #region 红最大跨度
    /// <summary>
    /// 红最大跨度
    /// </summary>
    public class Index_红最大跨度 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Last() - data.NormalData.First();
        }
    }
    #endregion

    #region 红质数个数
    /// <summary>
    /// Index_红质数个数
    /// </summary>
    public class Index_红质数个数 : LotIndex
    {
        public static readonly int[] PrimeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Index_S序列重复个数(PrimeNumbers);
        }
    }
    #endregion

    #region 红Ac值
    /// <summary>
    /// Index_红Ac值,修过完成
    /// </summary>
    public class Index_红Ac值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.GetAcValue();
        }
    }
    #endregion

    #region 尾数和值
    /// <summary>
    /// 尾数和值
    /// </summary>
    public class Index_红尾数和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Sum();
        }
    }
    #endregion

    #region 尾数组数
    /// <summary>
    /// 尾数组数
    /// </summary>
    public class Index_红尾数组数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Distinct().Count();
        }
    }
    #endregion

    #region 最大邻号间距
    /// <summary>
    /// 最大邻号间距
    /// </summary>
    public class Index_红最大邻号间距 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.GetMaxSpan();
        }
    }
    #endregion

    #region 最小邻号间距
    /// <summary>
    /// 最小邻号间距
    /// </summary>
    public class Index_红最小邻号间距 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.GetMinSpan();
        }
    }
    #endregion

    #region 红最长连续数
    /// <summary>
    /// Index_红最长连续数,
    /// </summary>
    public class Index_红最长连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.GetMaxContinuesCount();
        }
    }
    #endregion
}