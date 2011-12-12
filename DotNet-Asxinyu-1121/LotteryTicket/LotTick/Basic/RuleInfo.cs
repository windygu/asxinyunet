using System;
using System.Reflection;
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
        public RuleInfo(string IndexName, string ruleName,LotTick.CompareParams conditions,int calculateRows = 100 ,int needRows = 0)
        {
            Assembly indexAssembe = Assembly.LoadFrom("LotTick.exe");
            Type t = indexAssembe.GetType("LotTick.Index_"+IndexName );
            this.IndexSelector = Activator.CreateInstance(t) as LotIndex;
            this.CompareRule = ruleName.ToEnum<ECompareType>();
            this.CondtionParams = conditions;
            this.NeedRows = needRows;
            this.CalcuteRows = calculateRows;
        }
        /// <summary>
        /// 比较参数
        /// </summary>
        public CompareParams CondtionParams { get; set; }

        /// <summary>
        /// 比例类型
        /// </summary>
        public ECompareType CompareRule { get; set; }

        /// <summary>
        /// 计算所需要的其他行数目
        /// </summary>
        public int NeedRows { get; set; }

        /// <summary>
        /// 计算指标对象
        /// </summary>
        public LotIndex IndexSelector { get; set; }

        /// <summary>
        /// 需要计算的数目
        /// </summary>
        public int CalcuteRows { get; set; }

        /// <summary>
        /// 指标当前的计算模式
        /// </summary>
        public EIndexMode CurrentIndexMode { get; set; }
    }
}
