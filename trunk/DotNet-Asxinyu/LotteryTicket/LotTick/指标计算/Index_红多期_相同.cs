using System.Linq;
using System.Collections.Generic;

namespace LotTick
{
    #region 最近几期和值相同的个数
    /// <summary>
    /// 最近几期和值相同的个数
    /// </summary>
    public class Index_红多期相同_和值 : Index_红多期相同数基类 
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Sum();
        }
    }
    #endregion

    #region 最近几期红最大跨度相同的个数
    /// <summary>
    /// 红最大跨度 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_最大跨度 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Max() - data.NormalData.Min();
        }
    }
    #endregion

    #region 最近几期 红Ac值相同的个数
    /// <summary>
    /// 红Ac值 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_Ac值 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.GetAcValue();
        }
    }
    #endregion

    #region 最近几期 红最长连续数相同的个数
    /// <summary>
    ///最长连续数与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_最长连续数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.GetMaxContinuesCount();
        }
    }
    #endregion

    #region 最近几期 红质数个数相同的个数
    /// <summary>
    /// 红质数个数 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_质数个数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Index_S序列重复个数(LotTickHelper.PrimeNumbers );
        }
    }
    #endregion

    #region 最近几期 红偶数个数相同的个数
    /// <summary>
    /// 红偶数个数 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_偶数个数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Where(n => ((int)n) % 2 == 0).Count();
        }
    }
    #endregion      

    #region 最近几期 红大号个数相同的个数
    /// <summary>
    /// 红大号个数与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_大号个数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Where(k => k >= 17).Count();
        }
    }
    #endregion

    #region 最近几期 尾数和值相同的个数
    /// <summary>
    /// 红尾数和值 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_尾数和值 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Sum();
        }
    }
    #endregion

    #region 最近几期 奇号连续数相同的个数
    /// <summary>
    /// 红奇号连续数 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_奇号连续数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.GetContinuesOddCount();
        }
    }
    #endregion

    #region 最近几期 红偶号连续数相同的个数
    /// <summary>
    /// 红偶号连续数 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_偶号连续数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Where(n => ((int)n) % 2 == 0).Count();
        }
    }
    #endregion
}