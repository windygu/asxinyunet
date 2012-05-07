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

    #region 上期的邻号出现个数（红球）
    /// <summary>
    /// 上期的邻号出现个数（红球）
    /// </summary>
    public class Index_红邻号出现数 : Index_红多期基类
    {
        //根据需要计算的行数来循环计算,输入数据已经考虑了所需行
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = data[i + 1].NormalData.Index_S邻号出现个数(data[i].NormalData);
            }
            return res;
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {  //LotTickData lastData = NeedData[0 ];去需要的第一个个数据来进行对比计算
            return data.Where(n => (n.NormalData.Index_S邻号出现个数(NeedData[0].NormalData)).
                GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion

    #region 红奇偶序列  需要比较参数
    /// <summary>
    /// 红奇偶序列 最近几期相同的个数,只需要重载一个方法即可
    /// </summary>
    public class Index_红奇偶序列 : Index_红多期序列基类
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.ParitySequence();
        }
    }
    #endregion

    #region 红素合序列  需要比较参数
    /// <summary>
    /// 红素合序列 与前几期相同的个数
    /// </summary>
    public class Index_红素合序列 : Index_红多期序列基类
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.PrimesSequence();
        }
    }
    #endregion

    #region 红奇偶素合序列,需要比较参数
    /// <summary>
    /// 红奇偶素合序列 最近几期 相同的个数
    /// </summary>
    public class Index_红奇偶素合序列 : Index_红多期序列基类
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.ParitySequence() + data.NormalData.PrimesSequence();
        }
    }
    #endregion
}