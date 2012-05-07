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

    #region 最近几期 红最大跨度最长连续数相同的个数
    /// <summary>
    ///最长连续数与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_最长连续数 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Max() - data.NormalData.Min();
        }
    }
    #endregion

    #region 最近几期 红最大跨度相同的个数
    /// <summary>
    /// 红素合序列 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_最大跨度 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Max() - data.NormalData.Min();
        }
    }
    #endregion

    #region 最近几期 红最大跨度相同的个数
    /// <summary>
    /// 红素合序列 与前几期相同的个数
    /// </summary>
    public class Index_红多期相同_最大跨度 : Index_红多期相同数基类
    {
        public override int GetValue(LotTickData data)
        {
            return data.NormalData.Max() - data.NormalData.Min();
        }
    }
    #endregion

}