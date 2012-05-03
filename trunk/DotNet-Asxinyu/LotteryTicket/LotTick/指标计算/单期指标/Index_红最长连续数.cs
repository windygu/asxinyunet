using System;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// Index_红最长连续数,
    /// </summary>
    public class Index_红最长连续数 : LotIndex
    {
        //测试通过
        public override int GetOneResult(LotTickData data)
        {
            int[] spanList = new int[data.NormalData.Length -1 ];
            for (int i = 0; i < spanList.Length ; i++)
            {
                spanList[i] = data.NormalData[i + 1] - data.NormalData[i];
            }
            bool[] res = spanList.Select(n => n == 1).ToArray();
            //寻找连续的True的个数           
            int max = 0;
            int count = 0;
            foreach (var item in res )
            {   //为True，说明2个相连,个数相加
                if (item)  count++;
                else //说明不连,重置个数
                {
                    max = count > max ? count : max;                   
                    count = 0;
                }
            }
            return (count >max ? count :max) +1 ;//可能最后一次最大，但没有计算进去
        }
    }
}