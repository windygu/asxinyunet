﻿using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 尾数和值
    /// </summary>
    public class Index_红尾数和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Sum();
        }
    }

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