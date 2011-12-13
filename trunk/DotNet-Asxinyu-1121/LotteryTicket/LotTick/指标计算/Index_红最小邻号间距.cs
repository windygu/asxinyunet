using System.Collections.Generic;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 最小邻号间距
    /// </summary>
    public class Index_红最小邻号间距 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < data.NormalData.Length - 1; i++)
            {
                res.Add(data.NormalData[i + 1] - data.NormalData[i]);
            }
            return res.Min();
        }
    }
}