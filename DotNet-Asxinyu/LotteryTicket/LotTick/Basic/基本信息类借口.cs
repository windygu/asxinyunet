﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

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

    #region 彩票指标计算抽象类
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
    #endregion

    #region 彩票指标计算抽象类
    /// <summary>
    /// 彩票指标计算抽象类
    /// </summary>
    public class LotIndex
    {
        /// <summary>
        /// 初始化,传入参数对象
        /// 设置一个
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
        public virtual LotTick.LotTickData[] GetFilterResult(LotTickData[] data, LotTick.LotTickData[] NeedData = null )
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

    #region 抽象彩票基类
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
        /// 确定获奖等级
        /// </summary>
        /// <param name="prizeCount">中奖号码</param>
        /// <param name="prizeNo">中奖号码</param>
        /// <param name="testNo">检测号码</param>
        public virtual int GetPrizeGrade(LotTick.LotTickData prizeNo, LotTick.LotTickData testNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 最终返回各个等级中奖号码的个数
        /// </summary>
        /// <param name="prizeCount">中奖号码</param>
        /// <param name="prizeNo">中奖号码</param>
        /// <param name="testNoes">检测号码</param>
        public virtual int[] GetAllPrizeGradesCount(LotTick.LotTickData prizeNo, LotTick.LotTickData[] testNoes)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据中奖明细统计中奖金额
        /// </summary>
        /// <param name="prizeNo">中奖号码</param>
        /// <param name="testNoes">检测号码</param>
        public virtual int GetAllPrizeReward(LotTick.LotTickData prizeNo, LotTick.LotTickData[] testNoes)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 验证规则列表,根据规则列表的信息进行验证,得到结果
        /// </summary>
        /// <param name="ruleList">规则列表</param>
        public virtual bool[][] ValidateRuleList(LotTick.RuleInfo[] ruleList)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据规则列表进行过滤
        /// </summary>
        /// <param name="ruleList">规则列表</param>
        /// <param name="filterInfos">过滤信息</param>
        /// <param name="fileName">需要加载的初始数据文件名称</param>
        //public virtual LotTick.LotTickData[] FilteByRuleList(LotTick.RuleInfo[] ruleList,
        //    out Dictionary<int, string> filterInfos, string fileName = null )
        //{
        //    throw new System.NotImplementedException();
        //}
    }
    #endregion

    #region 获取历史开奖数据接口和兑奖接口
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
    #endregion

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

    #region 双色球彩票数据结构
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

        public LotTickData(){}
        public LotTickData(int[] normalData)
        {
            this.NormalData = normalData;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        public SSQ_temp GetEntity()
        {
            SSQ_temp t = new SSQ_temp();
            t.号码1 = NormalData[0];
            t.号码2 = NormalData[1];
            t.号码3 = NormalData[2];
            t.号码4 = NormalData[3];
            t.号码5 = NormalData[4];
            t.号码6 = NormalData[5];
            t.蓝球 = SpecialData;
            return t;
        }
    }
    public class SSQ_temp
    {      
        private Int32 _号码1;      
        public Int32 号码1 {get ;set ;}
       
        private Int32 _号码2;      
        public virtual Int32 号码2 {get ;set ;}

        private Int32 _号码3;
        public virtual Int32 号码3 {get ;set ;}

        private Int32 _号码4;       
        public virtual Int32 号码4 {get ;set ;}

        private Int32 _号码5;      
        public virtual Int32 号码5 {get ;set ;}

        private Int32 _号码6;       
        public virtual Int32 号码6 {get ;set ;}

        private Int32 _蓝球;      
        public virtual Int32 蓝球 {get ;set ;}       
    }   
    #endregion
}