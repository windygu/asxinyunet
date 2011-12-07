﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    /// 彩票指标计算抽象类
    /// </summary>
    public abstract class ABSLotIndex
    {
        /// <summary>
        /// 计算指标所需要的邻近行的数目
        /// </summary>
        /// <remarks>一般只与当期相关的指标不需要邻近行,即为0</remarks>
        /// <value>0</value>
        public int NeedRows { get; set; }

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
        public abstract int[][] GetFilterResult();
    }

    /// <summary>
    /// 彩票指标计算抽象类
    /// </summary>
    public class LotIndex
    {
        /// <summary>
        /// 初始化,传入参数对象
        /// </summary>        
        public LotIndex(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
        }
        public LotIndex()
        {
        }
        /// <summary>
        /// 比较规则对象
        /// </summary>
        public RuleInfo RuleInfoParams { get; set; }

        /// <summary>
        /// 计算所有数据的指标结果
        /// </summary>
        /// <param name="data">数据</param>
        public virtual int[] GetAllValue(LotTick.LotTickData[] data)
        {
            throw new System.NotImplementedException();
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
        /// <param name="compCoditon">比较参数</param>
        /// <returns>满足规则的数据集</returns>
        public virtual LotTick.LotTickData[] GetFilterResult(LotTickData[] data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据该指标的规则,验证对历史数据的准确性
        /// </summary>
        /// <remarks>验证历史数据库中,最近的N期数据,数据按照时间升序排列</remarks>
        /// <param name="data">计算的原始数据</param>
        /// <returns>返回每一期的正确性</returns>
        public virtual bool[] GetValidateResult(LotTickData[] data)
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// 抽象彩票基类
    /// </summary>
    public class BasicLotTick
    {
        /// <summary>
        /// 号码数据列表
        /// </summary>
        public LotTick.LotTickData[] LotData { get; set; }

        /// <summary>
        /// 需要计算的数目
        /// </summary>
        public int CalcuteRows { get; set; }

        /// <summary>
        /// 指标计算所需的最大行数,结合CalcuteRows获取数据行
        /// </summary>
        public int MaxNeedRows { get; set; }

        /// <summary>
        /// 确定获奖等级
        /// </summary>
        /// <param name="prizeCount">中奖号码</param>
        /// <param name="testNo">检测号码</param>
        public virtual int GetPrizeGrade(int[] prizeNo, int[][] testNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 最终返回各个等级中奖号码的个数
        /// </summary>
        /// <param name="prizeCount">中奖号码</param>
        /// <param name="testNoes">检测号码</param>
        public virtual int[] GetPrizeGrades(int[] prizeNo, int[][] testNoes)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据中奖明细统计中奖金额
        /// </summary>
        /// <param name="prizeCount">相应的中奖号码个数</param>
        public virtual int GetAllPrizeReward(int[] prizeCount)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 验证规则列表,根据规则列表的信息进行验证,得到结果
        /// </summary>
        public virtual void ValidateRuleList()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据规则列表进行过滤
        /// </summary>
        public virtual void FilteByRuleList()
        {
            throw new System.NotImplementedException();
        }
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

    /// <summary>
    /// 彩票兑奖等级接口
    /// </summary>
    public interface IPrizeGrade
    {
    }

    /// <summary>
    /// 指标计算的模式
    /// </summary>
    public enum EIndexMode
    {
        /// <summary>
        /// 常规模式,即对普通号码操作
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 特殊模式,即对特殊号码操作
        /// </summary>
        Special = 1,
        /// <summary>
        /// 混合模式,同时操作所有数据
        /// </summary>
        Mix = 2,
    }

    #region 比较类型枚举
    /// <summary>
    /// 比较类型
    /// </summary>
    public enum CompareType
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
    /// 每期的彩票数据,重新封装一下
    /// </summary>
    public class LotTickData
    {
        /// <summary>
        /// 常规数据
        /// </summary>
        public int[] NormalData;
        /// <summary>
        /// 特殊数据
        /// </summary>
        public int SpecialData;
    }
}
