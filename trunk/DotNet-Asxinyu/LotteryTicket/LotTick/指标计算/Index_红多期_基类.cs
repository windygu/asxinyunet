using System.Linq;
using System.Collections.Generic;
namespace LotTick
{
    #region 杀号基类
    /// <summary>
    /// 杀号基类:杀号直接进行过滤和验证操作，不需要进行单个的计算
    /// 1.计算要杀的号码列表
    /// 2.杀号和过滤
    /// </summary>
    public class Index_Base杀号 : LotIndex
    {
        public Index_Base杀号(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
            this.IsDeleteNumberMode = true;//默认为杀号模式
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //验证杀号是否准确
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return base.GetFilterResult(data, NeedData);
        }
    }
    #endregion

    #region Index_红多期_相同数基类
    /// <summary> 
    /// 前几期的号码 在本期中出现的个数
    /// </summary>
    public class Index_红多期相同数基类 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            int[] str = data.Select(n => GetValue(n)).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                List<int> temp = new List<int>();
                for (int j = i; j < i + this.RuleInfoParams.NeedRows; j++)
                {
                    temp.Add(str[j]);//添加到一起后再计算比较
                }
                res[i] = temp.FindAll(n => n == str[i + this.RuleInfoParams.NeedRows]).Count();
            }
            return res;
        }
        /// <summary>
        /// 获取指标的值，需要在子类重写
        /// </summary>        
        public virtual int GetValue(LotTickData data)
        {
            return -1;
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<int> cur = new List<int>();
            foreach (var item in NeedData)
            {
                cur.Add(GetValue(item));
            }
            return data.Where(n => cur.FindAll(k => k == GetValue(n))
                .Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion

    #region 红多期基类
    /// <summary>
    /// 红多期基类
    /// </summary>
    public class Index_红多期基类 : LotIndex
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            return base.GetAllValue(data);
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return base.GetFilterResult(data, NeedData);
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).Select(n => n.GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion

    #region 多期出现的次数，专门针对 序列类型的指标，最近几期相同的个数
    public class Index_红多期序列基类 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            string[] str = data.Select(n => GetSequence(n)).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                List<string> temp = new List<string>();
                for (int j = i; j < i + this.RuleInfoParams.NeedRows; j++)
                {
                    temp.Add(str[j]);//多期的号码添加到一起后再计算比较
                }
                res[i] = temp.FindAll(n => n == str[i + this.RuleInfoParams.NeedRows]).Count();
            }
            return res;
        }
        //获取序列的方法,需要在子类中重载才行
        public virtual string GetSequence(LotTickData data)
        {
            return data.NormalData.ToString();
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<string> cur = new List<string>();
            foreach (var item in NeedData)
            {
                cur.Add(GetSequence(item));
            }
            return data.Where(n => cur.FindAll(k => k == GetSequence(n))
                .Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion
}