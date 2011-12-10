using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 红跨度和值
    /// </summary>
    public class Index_红跨度和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Last() - data.NormalData.First();
        }        
    }
}