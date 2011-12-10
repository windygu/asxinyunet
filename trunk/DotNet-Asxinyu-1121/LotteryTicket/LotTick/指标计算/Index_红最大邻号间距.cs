using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 最大邻号间距
    /// </summary>
    public class Index_红最大邻号间距 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < data.NormalData.Length -1; i++)
            {
                res.Add(data.NormalData [i +1]-data.NormalData [i ]);
            }
            return res.Max();
        }
    }
}