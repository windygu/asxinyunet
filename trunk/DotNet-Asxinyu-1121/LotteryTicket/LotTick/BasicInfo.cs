using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
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
        public int NeedRows
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
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
    public abstract class LotIndex
    {
        /// <summary>
        /// 计算指标所需要的邻近行的数目
        /// </summary>
        /// <remarks>一般只与当期相关的指标不需要邻近行,即为0</remarks>
        /// <value>0</value>
        public int NeedRows
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 需要计算的数目
        /// </summary>
        public int CalcuteRows
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 单期计算结果类型
        /// </summary>
        public EIndexResultType ResultType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 比较条件参数
        /// </summary>
        public CompareParams CompareCondition
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 计算所有数据的指标结果
        /// </summary>
        public int[] GetAllValue()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 计算一组数据的指标结果
        /// </summary>
        public int GetOneResult()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据该规则,对数据集进行过滤,只保留满足规则的书籍
        /// </summary>
        /// <returns>满足规则的数据集</returns>
        public virtual int[][] GetFilterResult()
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// 根据该指标的规则,验证对历史数据的准确性
        /// </summary>
        /// <remarks>验证历史数据库中,最近的N期数据,数据按照时间升序排列</remarks>
        /// <returns>返回每一期的正确性</returns>
        public virtual bool[] GetValidateResult()
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
        /// 常规号码列表
        /// </summary>
        public int[][] NormalData { get; set; }

        /// <summary>
        /// 特殊号码
        /// </summary>
        public int SpecialData { get; set; }

        /// <summary>
        /// 是否特殊模式,即是否存在特殊号码
        /// </summary>
        public bool IsSpecailMode { get; set; }

        /// <summary>
        /// 需要计算的数目
        /// </summary>
        public int CalcuteRows
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 所有号码列表,常规号码+特殊列表
        /// </summary>
        public int[] AllData
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// 指标计算所需的最大行数,结合CalcuteRows获取数据行
        /// </summary>
        public int MaxNeedRows
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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
    /// 指标计算结果的类型
    /// </summary>
    public enum EIndexResultType
    {
        /// <summary>
        /// 单个值
        /// </summary>
        Single = 0,
        /// <summary>
        /// 多个值
        /// </summary>
        List = 1,
        /// <summary>
        /// 键值对
        /// </summary>
        Dickeys = 2,
    }
}
