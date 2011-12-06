using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 规则信息类
    /// </summary>
    public class RuleInfo
    {
        /// <param name="IndexName">指标名称</param>
        /// <param name="ruleName">比较类型名称</param>
        /// <param name="conditions">比较参数</param>
        public RuleInfo(string IndexName, string ruleName, LotTick.CompareParams conditions)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 比较参数
        /// </summary>
        public CompareParams CondtionParams
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
        /// 比例类型
        /// </summary>
        public ECompareType CompareRule
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
        /// 计算所需要的其他行数目
        /// </summary>
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
        /// 计算指标对象
        /// </summary>
        public LotIndex IndexSelector
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
    }
}
