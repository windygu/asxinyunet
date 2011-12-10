using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 连号组数，修改完成
    /// </summary>
    public class Index_红连号组数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            int count = 0;
            bool flag = false;
            for (int i = 0; i < data.NormalData .Length - 1; i++)
            {
                if (data.NormalData[i + 1] - data.NormalData [i] == 1)
                {
                    if (flag)//只第一次加
                    {
                        count++;
                        flag = true;
                    }
                }
                else { flag = false; }
            }
            return count;
        }      
    }
}