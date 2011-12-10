using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 红最大跨度
    /// </summary>
    public class Index_红最大跨度 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Last() - data.NormalData.First();
        }        
    }
}