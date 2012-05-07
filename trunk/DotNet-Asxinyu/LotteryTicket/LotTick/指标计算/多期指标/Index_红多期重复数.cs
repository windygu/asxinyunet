using System.Linq;
using System.Collections.Generic;
namespace LotTick
{
    #region Index_红多期重复数
    /// <summary>
    /// 前几期的号码 在本期中出现的个数
    /// </summary>
    public class Index_红多期重复数 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {               
            int[] res = new int[data.Length  - this.RuleInfoParams.NeedRows];             
            for (int i = 0; i < res.Length ; i++)
            {
                List<int> temp = new List<int>();
                for (int j = i ; j < i + this.RuleInfoParams.NeedRows ; j++)
                {
                    temp.AddRange(data[j ].NormalData);//多期的号码添加到一起后再计算比较
                }
                res[i] = data[i + this.RuleInfoParams.NeedRows ].NormalData.Index_S序列重复个数(temp);
            }
            return res;
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < this.RuleInfoParams.NeedRows ; i++)
            {
                temp.AddRange(NeedData[i].NormalData );
            }
            return data.Where(n => (n.NormalData.Index_S序列重复个数(temp )).
                GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion    
}