using System;
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
        public override int GetOneResult(LotTickData data)
        {
            bool[] res = data.NormalData.Select(n => n % 2 == 1).ToArray();//是否是奇数
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }       
    }
}