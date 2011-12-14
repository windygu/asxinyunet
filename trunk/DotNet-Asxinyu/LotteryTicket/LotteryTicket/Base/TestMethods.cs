using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryTicket
{
    #region 常规参数类
    /// <summary>
    /// 常规计算参数类：封装常用的计算参数
    /// 主要用作公式杀号
    /// </summary>
    public class CommCalculateParams
    {
        public int Add { get; set; }
        public int Sub { get; set; }
        public int Multi { get; set; }
        public int Divisor { get; set; }        
        public Dictionary<string, int> Dic { get; set; }
        public CommCalculateParams(int add = 0, int sub = 0, int multi = 0, int divisor = 16)
        {
            this.Add = add;
            this.Sub = sub;
            this.Multi = multi;
            this.Divisor = divisor;
        }
    }
    #endregion

    /// <summary>
    /// 测试杀号方法
    /// </summary>
    public static class TestMethods
    {
        #region 根据尾数，杀下期红号---失败
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
        #endregion

        #region 期数、红球计算求余杀蓝号--可行，进一步搜索最大的组合
        public static void Test02()
        {
            List<tb_Ssq> list =tb_Ssq.FindAll("select * from tb_Ssq order by 期号 asc");
            //List<double> res = new List<double>();
            List<CommCalculateParams> listParmas = new List<CommCalculateParams>();
            for (int i = 1; i <= 5 ; i++)//乘数
            {
                for (int j = 1; j <=6; j++)//红球id
                {
                    for (int k = 1; k < 15; k++)//加数
                    {
                        double temp = GetTestResult(list,i,j,k , 16);
                        if (temp > 0.954)
                        {
                            listParmas.Add(new CommCalculateParams(k, j , i, 16));
                            //res.Add(temp); Console.WriteLine("{0}-{1}-{2}:{3}", i, j, k, temp);
                        }
                    }
                }
            }
            Console.WriteLine("总共方法数：{0},结果{1}",listParmas.Count ,GetMultiResult(listParmas, list ));
            //res = res.OrderBy(n => n).ToList ();
            //foreach (var item in res )
            //{
            //    Console.Write("{0},", item );
            //}

            //while (true)
            //{
            //    Console.Write("输入参数，乘数：");
            //    int multi = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("输入红球编号：");
            //    int redid = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("输入加数：");
            //    int add = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine(GetTestResult(list, multi , redid ,add , 16).ToString("F4"));
            //}
        }

        //同时计算多条规则的成功率
        static double GetMultiResult(List<CommCalculateParams> list, List<tb_Ssq> data)
        {
            int count = 0;
            for (int i = 0; i < data.Count - 1; i++)
            {
                bool flag = true ;
                for (int j = 0; j < list.Count ; j++)
                {
                    int temp = ((int)data[i].期号 * list[j].Multi + list[j].Add +
                    (int)tb_Ssq.GetValue(data[i], "号码" + list[j].Sub.ToString())) % list[j].Divisor;
                    Console.Write("{0},",temp );
                    //余数是否为下期的蓝号
                    if (temp == data[i + 1].蓝球)//只要一次不满足就跳出
                    {
                        flag = false;
                        break;
                    }
                }
                Console.WriteLine();
                if (flag) count++;//都满足才加1
            }
            return ((double)count) / ((double)data.Count);
        }

        //计算该条件下的成功率
        static double GetTestResult(List<tb_Ssq > data, int multiplicator,int RedNumberId, int addend, int divisor)
        {
            int count = 0;
            for (int i = 0; i < data.Count -1; i++)
            {
                int temp = (int)data[i].期号 * multiplicator+addend +
                    (int)tb_Ssq.GetValue(data[i], "号码" + RedNumberId.ToString());               
                //余数是否为下期的蓝号
                if ((temp %divisor )!=data [i +1].蓝球 )
                {
                    count++;
                }
            }          
            return ((double)count) / ((double)data.Count);
        }
        #endregion

        #region 不同区间模式出现的概率个数
        public static void Test03()
        {

        }
        /// <summary>
        /// 将当期数据与分段模式进行比较，得到比较结果
        /// </summary>
        /// <param name="data">当期数据</param>
        /// <param name="sections">分段模式</param>
        /// <returns>匹配结果,对应位置模式出现的次数</returns>
        public static int[] SectionCompare(this int[] data, int[][] sections)
        {
            int[] res = new int[sections.Length];
            foreach (int item in data )
            {
                for (int i = 0; i < sections.GetLength (0); i++)
                {
                    if (sections[i].Contains(item))
                    {
                        res[i]++;
                        break;
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// 获取随机的分段模式
        /// </summary>
        /// <param name="numberCount">所有数字个数</param>
        /// <param name="sectionCount">分段数</param>
        /// <returns>分段模式</returns>
        public static int[][] GetRandomSections(int numberCount, int sectionCount)
        {
            Random rand = new Random();
            int[] numbers = new int[numberCount];
            for (int i = 0; i < numberCount; i++) numbers[i] = i + 1;            
            for (int i = 0; i <5; i++)
            {
                for (int j = 0; j < numberCount ; j++)
                {
                    int r = rand.Next(0, numberCount - 1);
                    int temp = numbers[j];
                    numbers[j] = numbers[r];
                    numbers[r] = temp;
                }
            }         
            //然后填充到list中去
            List<int>[] list = new List<int>[sectionCount];
            int PerCount =(int )(((double)numberCount) /(double ) sectionCount);
            int count = 0 ;
            for (int i = 0; i < sectionCount -1 ; i++)
            {
                for (int j = 0; j < PerCount ; j++)
                {
                    list[i].Add(numbers[count++]);
                }
            }
            for (int i = count ; i <numberCount ; i++)
            {
                list[sectionCount - 1].Add(numbers[count++]);
            }
            return list.Select(n => n.ToArray()).ToArray();
        }
        #endregion

        #region 统计那些组合同时出现的频率最高
        public static void Test04()
        {
            int[][] data = TwoColorBall.GetRedBallData(-1);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (int[] item in data )
            {
                for (int i = 0; i < item.Length -1; i++)
                {
                    for (int j = i +1; j <item.Length ; j++)
                    {
                        string s = item[i].ToString() + "-" + item[j].ToString();
                        if (dic.ContainsKey(s))//组合出现的次数
                            dic[s]++;
                        else
                            dic.Add(s, 1);
                    }
                }
            }
            var res = dic.OrderBy(n => n.Value).ToArray();//排序
            Console.WriteLine("总数{0}", res.Count());
            //foreach (var item in res )
            //{
            //    Console.WriteLine(item.Key + ":" + item.Value.ToString());
            //}
        }
        #endregion

        #region 上期和值与尾数和%10杀下期蓝号
        public static void Test05()
        {
            int[][] data = TwoColorBall.GetRedBallData(-1);
            int[] blue = TwoColorBall.GetBlueBallData ();
            int sum = 0;
            for (int i = 0; i < data.GetLength (0)-1; i++)
            {
                int temp = (int)(data[i].Sum() / 10);
                if (temp != blue[i]) sum++;
            }
            double res = ((double)sum) / ((double)blue.Length);
            Console.WriteLine("和值/10杀蓝准确率：{0}", res);
        }
        public static void Test06()
        {
            int[][] data = TwoColorBall.GetRedBallData(-1);
            int[] blue = TwoColorBall.GetBlueBallData();
            int sum = 0;
            for (int i = 0; i < data.GetLength(0) - 1; i++)
            {
                int temp = (int)(data[i].Select(n=>n %10).Sum () / 10);
                if (temp != blue[i]) sum++;
            }
            double res = ((double)sum) / ((double)blue.Length);
            Console.WriteLine("尾数和值/10杀蓝准确率：{0}", res);
        }
        #endregion

        #region 倍数概率
        #endregion
    }
}