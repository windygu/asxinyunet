using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace LotTick
{
    #region 抽象彩票基类
    /// <summary>
    /// 抽象彩票基类
    /// </summary>
    public class BasicLotTick
    {
        /// <summary>
        /// 所有历史开奖号码数据列表
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
}