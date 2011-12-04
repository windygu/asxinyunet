using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 序列和值
    /// </summary>
    public class Index_和值 : LotIndex
    {
        public Index_和值(int calculateRows, int needRows = 0)
        {
            this.ResultType = EIndexResultType.Single;
            this.NeedRows = needRows;            
            this.CalcuteRows = calculateRows;
        }
        public override int[] GetAllValue(int[][] data)
        {
            //只计算所需要的行
            if (data.GetLength(0) < CalcuteRows)
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), CalcuteRows));
            return data.Select(n => n.Sum()).ToArray ();
        }
        public override int GetOneResult(int[] data)
        {
            return data.Sum();
        }
        public override int[][] GetFilterResult(int[][] data, CompareParams compCoditon)
        {
           
        }
    }
}
