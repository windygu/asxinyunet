using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 尾数组数
    /// </summary>
    public class Index_红尾数组数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Distinct().Count();
        }
    }
}