using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryTicket
{
    /// <summary>
    /// 测试杀号方法
    /// </summary>
    public static class TestMethods
    {
        //凡是上期出1尾，下期则不出：06 10
        //凡是上期出2尾，下期则不出：03 07 08 09
        //凡是上期出3尾，下期则不出：03
        //凡是上期出4尾，下期则不出：05 07 09
        //凡是上期出5尾，下期则不出：02 04 10 16
        //凡是上期出6尾，下期则不出：05 08 10 12 16
        //凡是上期出7尾，下期则不出：09 12 15
        //凡是上期出8尾，下期则不出：04 05 06 07 08 10 12 14 16
        //凡是上期出9尾，下期则不出：01 03 05 08 10 11 12 14 16
        //凡是上期出0尾，下期则不出：01 02 03 04 08 09 10 12 13 16 
        //结果：总体失败，每一个尾数，后面所有的号都出来过
        public static void Test01()
        {
            
            int[][] data = TwoColorBall.GetRedBallData(-1);
            for (int i = 0; i < 10; i++)
            {
                List<int> list = GetDistictNumbers(data, i);
                Console.WriteLine("尾数为{0}时，出现的数字:", i);
                foreach (var item in list )
                {
                    Console.Write(item.ToString()+",");
                }
                Console.WriteLine();
            }
        }
        static List <int > GetDistictNumbers(int[][] data,int N)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < data.GetLength(0) - 1; i++)
            {
                if (data[i ].Select (n=>n%10).Contains (N ))
                {
                    list.AddRange(data[i + 1]);
                }
            }
            list = list.Distinct().OrderBy (n=>n).ToList ();
            return list;
        }
    }
}
