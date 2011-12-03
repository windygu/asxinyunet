using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 彩票指标计算抽象类
    /// </summary>
    public abstract class LotIndex
    {
        /// <summary>
        /// 根据该指标的规则,验证对历史数据的准确性
        /// </summary>
        /// <remarks>验证历史数据库中,最近的N期数据,数据按照时间升序排列</remarks>
        /// <returns>返回每一期的正确性</returns>
        public abstract bool[] GetValidateResult();

        /// <summary>
        /// 根据该规则,对数据集进行过滤,只保留满足规则的书籍
        /// </summary>
        /// <returns>满足规则的数据集</returns>
        public abstract bool[] GetFilterResult();       
    }

    /// <summary>
    /// 抽象彩票基类
    /// </summary>
    public abstract class BasicLotTick
    {
        /// <summary>
        /// 常规号码列表
        /// </summary>
        public int[] NormalData { get; set; }

        /// <summary>
        /// 特殊号码
        /// </summary>
        public int SpecialData { get; set; }

        /// <summary>
        /// 是否特殊模式,即是否存在特殊号码
        /// </summary>
        public bool IsSpecailMode { get; set; }
    }

    /// <summary>
    /// 获取历史开奖数据接口
    /// </summary>
    public interface IGetHistoryData
    {
        /// <summary>
        /// 获取所有历史数据,自动计算所有页面
        /// </summary>
        void UpdateAll();

        /// <summary>
        /// 更新最近的开奖数据,自动到数据库匹配
        /// </summary>
        void UpdateRecent();
    }
}
