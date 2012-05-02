using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace LotTick
{
    #region 彩票指标计算抽象类
    /// <summary>
    /// 彩票指标计算抽象类
    /// </summary>
    public class LotIndex
    {
        /// <summary>
        /// 初始化,传入参数对象
        /// TODO:传入一个实际的彩票类型对象（包括了需要计算的数据和参数），指标根据参数计算得到需要计算的数据
        /// </summary>        
        public LotIndex(RuleInfo ruleInfo,bool isDeleteMode = false)
        {
            this.RuleInfoParams = ruleInfo;
            IsDeleteNumberMode = isDeleteMode;
        }
        public LotIndex()
        {
            IsDeleteNumberMode = false;//默认不是杀号模式
        }
        /// <summary>
        /// 比较规则对象
        /// </summary>
        public RuleInfo RuleInfoParams { get; set; }

        /// <summary>
        /// 是否是杀号模式,默认不是
        /// </summary>
        public bool IsDeleteNumberMode { get; set; }

        /// <summary>
        /// 计算所有数据的指标结果
        /// </summary>
        /// <param name="data">数据</param>
        public virtual int[] GetAllValue(LotTick.LotTickData[] data)
        {
            return data.Select(n => GetOneResult(n)).ToArray();
        }

        /// <summary>
        /// 计算一组数据的指标结果
        /// </summary>
        /// <param name="data">一组数据</param>
        public virtual int GetOneResult(LotTickData data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据该规则,对数据集进行过滤,只保留满足规则的书籍
        /// </summary>
        /// <param name="data">所有需要过滤的数据</param>
        /// <param name="NeedData">需要的历史数据,数目为所需要的行数</param>
        /// <param name="compCoditon">比较参数</param>
        /// <returns>满足规则的数据集</returns>
        public virtual LotTick.LotTickData[] GetFilterResult(LotTickData[] data, LotTick.LotTickData[] NeedData = null)
        {
            return data.Where(n => (GetOneResult(n)).GetCompareResult(this.RuleInfoParams)).ToArray();
        }

        /// <summary>
        /// 根据该指标的规则,验证对历史数据的准确性
        /// </summary>`
        /// <remarks>验证历史数据库中,最近的N期数据,数据按照时间升序排列</remarks>
        /// <param name="data">计算的原始数据</param>
        /// <returns>返回每一期的正确性</returns>
        public virtual bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }

        /// <summary>
        /// 最高优先级,杀号处理，根据计算，返回需要去除的数字列表
        /// </summary>        
        /// <param name="data">辅助的历史数据</param>
        public virtual List<Int32> DeleteNumbers(LotTickData[] data)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion
}
