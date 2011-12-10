﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// Index_红奇号连续数
    /// </summary>
    public class Index_红奇号连续数 : LotIndex
    {       
        public override int[] GetAllValue(LotTickData[] data)
        {
            return data.Select(n => n.NormalData.Sum()).ToArray();
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return data.Where(n => (n.NormalData.Sum()).GetCompareResult(this.RuleInfoParams)).ToArray();
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
    }
}