/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:00
 * 
 *
 */
using System;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq;
using System.IO;

namespace LotteryTicket
{
    /// <summary>
	/// 指标计算:单个指标和所有指标,采用扩展方法实现
	/// </summary>
    public static class IndexCalculate
    {
        #region 常量
        /// <summary>
		/// 质数集合
		/// </summary>
		public static readonly int[] PrimeNumbers =new int[] {2,3,5,7,11,13,17,19,23,29,31};
        #endregion
    
		#region 和值与数据密度
		/// <summary>
		/// 计算和值
		/// </summary>
        public static int Index_Sum(this IEnumerable<int > source)
		{
            return source.Sum();
		}
        #endregion

        #region 跨度
        /// <summary>
		/// 计算最大跨度
		/// </summary>
        public static int Index_MaxSpan(this IEnumerable<int> source)
		{
            return source.Last() - source.First();            
		}
		
		/// <summary>
		/// 计算跨度列表
		/// </summary>
        public static int[] Index_SpanList(this IEnumerable<int> source)
		{
            int[] list = source.ToArray();
            int[] res = new int[list.Length];
            for (int i = 0; i < list.Length ; i++)
            {
                res[i] = list[i + 1] - list[i];
            }
			return res ;
		}
		
		/// <summary>
		/// 最小跨度
		/// </summary>
        public static int Index_MinSpan(this IEnumerable<int> source)
		{
            int[] res = Index_SpanList(source);
            return res.Min();//返回最小值
		}
		
		/// <summary>
		/// 跨度和值
		/// </summary>
        public static int Index_SpanSum(this IEnumerable<int> source)
		{
            int[] res = Index_SpanList(source);
            return res.Sum();
		}
		#endregion
		
		#region AC值
		/// <summary>
		/// Ac值=差值个数-(6-1)
		/// </summary>
		public static int Index_AcValue(this IEnumerable<int > source)
        {
            int[] data = source.ToArray();
			ArrayList list = new ArrayList () ;
			int temp ;
			for (int i = 0 ; i <data.Length -1 ; i ++)
			{
				for (int j = i +1 ; j <data.Length ; j ++)
				{
					temp = data [j ] - data [i ] ;
					if (!list.Contains (temp ))
					{
						list.Add (temp ) ;
					}
				}
			}
			return list.Count -(data.Length -1) ;
		}
		#endregion
		
		#region 多期号码
        /// <summary>
        /// 多期号码中，号码所有出现的个数，去掉重复的
        /// </summary>        
		public static object B_ManyNoCounts(object args)
		{
			double[][] data = (double[][])args ;//多期数据
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.Length ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
					if (!al.Contains(data[i][j]))
					{
						al.Add (data[i][j]);
					}
				}
			}
			return (double )al.Count ;
		}
		/// <summary>
        /// 多期数据中,出现重复号码的个数
		/// </summary>		
		public static object B_ManyNoOfNewCount(object args)
		{
			double[][] data = (double[][])args ;//多期数据
            int count = 0;
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.GetLength (0) ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
                    if (!al.Contains(data[i][j])) { al.Add(data[i][j]); }
                    else { count++; }
				}
			}
			return (double )count ;
		}
		/// <summary>
        /// 多期相同的数据列表？？？
		/// </summary>	
		public static object D_ManyNosList(object args)
		{
			double[][] data = (double[][])args ;//多期数据
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.Length -1 ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
					if (!al.Contains (data[i][j]))
					{
						al.Add (data[i][j]);
					}
				}
			}
			ArrayList resList = new ArrayList () ;
			for (int i = 0; i < data[0].Length ; i++)
			{
				if (al.Contains (data[data.Length -1][i ]))
				{
					resList .Add (data[data.Length -1][i ]) ;
				}
			}
			double[] d = (double[])resList.ToArray(typeof (double )) ;
			return d ;
		}
		#endregion
		
		#region 统计次数与频率 FrequCount FrequPrecent
		/// <summary>
		/// 计算在当前期内出现的次数
		/// </summary>
		public static object FrequCount(int[][] args)
		{
			//先从最后一列找出最大值,确定出现的最大数字
			int max = args [0][args[0].Length-1] ;
			for (int i = 0 ; i <args.Length ; i ++ )
			{
				if (args [i ][args [0].Length -1]>max )
				{
					max = args [i ][args [0].Length -1] ;
				}
			}
			int[] count = new int[max ] ;
			for (int i = 0 ; i <args.Length ; i ++ )
			{
				for (int j = 0 ; j <args[0].Length ; j ++)
				{
					count[args [i ][j ]-1] ++ ;
				}
			}
			return count ;
		}
		
		/// <summary>
		/// 计算百分比频率
		/// </summary>
		public static object FrequPrecent(int[][] args)
		{
			int[] count = (int[])FrequCount (args ) ;
			double[] res = new double[count .Length ] ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = ((double )count [i ])/((double )args .Length);
			}
			return res ;
		}
		#endregion		
					
		#region 每期最长的连续号码个数,2个2连续算3
		/// <summary>
		/// 每期最长的连续号码个数,2个2连续算3
		/// </summary>	
		public static double A_ContinuousCount(double[] args)
		{
			double[] res = (double[])C_SpanList (args ) ;//计算跨度
            int count = res.Where(n => n == 1).Count();//计算==1的个数			
			return (double)(count +1) ;
		}
		#endregion
		
		#region 质数个数计算
		/// <summary>
		/// 每期质数的个数
		/// </summary>		
		public static int A_PrimeCount(double[] args)
		{
			return IndexCalculate.GetRepeatNumbers (PrimeNumbers,args ) ;
		}
		#endregion
		
		#region 偶数个数计算
		/// <summary>
		/// 计算每期的偶数的个数
		/// </summary>
		public static int A_EvenNumber(double[] args)
		{
			return args.Where (n=>((int )n )%2 ==0).Count ();
		}
		#endregion

        #region 求余来计算覆盖的范围的个数
        /// <summary>
        ///  求余来计算覆盖的范围的个数,0到L-1出现的个数
        /// </summary>
        /// <param name="args">数据</param>
        /// <param name="L">求余参数</param>
        /// <returns>出现的个数</returns>
        public static int A_CoverCount(double[] args, int L)
        {
            return args.Select(n => ((int)n) % L).Distinct().Count();
        }
        #endregion

        #region 根据类型名称和数据计算指标(单期指标)
        /// <summary>
        /// 根据类型名称和输入数据计算相应数据,需要进行的数据在外部传入
        /// </summary>
        /// <param name="data">数据(单期)</param>
        /// <param name="typeName">指标名称:根据名称来判断数据类别</param>
        /// <returns>该数据集合在指定的指标下计算的结果</returns>
        public static object CalculateIndex(object data, IndexNameType typeName)
        {
            //TODO:分别针对ABCD不同类型，输入数据可能不一样进行处理
            Type t = typeof(PerNoIndexCalculate);
            MethodInfo mi = t.GetMethod(typeName.ToString());
            //invoke,传入数组参数
            return mi.Invoke(null, new object[] { data });
        }
        #endregion

        #region	计算所有数据集指标的值(多期指标)
        /// <summary>
        /// 计算多期数据的指标，需要指标名称以及每计算一期所需要的行数,默认1行
        /// </summary>
        /// <param name="data">多期数据:可能为一维数组或者2维交错数组</param>
        /// <param name="typeName">指标名称:根据名称来判断数据类别</param>
        /// <param name="needRows">计算一次所需要的行数(需依赖的期数),默认为1</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
        public static object CalculateAllData(object data, IndexNameType typeName, int needRows = 1)
        {
            string name = typeName.ToString();
            char ct = name[0];
            if ((ct == 'B') || (ct == 'D'))
            {
                return CalculateAllDataBD(data, typeName, needRows);
            }
            else if ((ct == 'A') || (ct == 'C'))
            {
                return CalculateAllDataAC(data, typeName);
            }
            return null;
        }

        /// <summary>
        /// 计算多期BD类型的指标,需要输入所需的行
        /// </summary>
        /// <param name="data">多期数据</param>
        /// <param name="typeName">指标名称(BD类):根据名称来判断数据类别</param>
        /// <param name="needRows">计算一次所需要的行数(需依赖的期数),默认为1</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
        public static object CalculateAllDataBD(object data, IndexNameType typeName, int needRows = 1)
        {
            Type t = typeof(PerNoIndexCalculate);
            string name = typeName.ToString();
            MethodInfo mi = t.GetMethod(name);
            char ct = name[0];
            double[][] args = (double[][])data;
            int min = 0;
            int max = args.Length - needRows;//确认？
            if (ct == 'B')
            {
                double[] res = new double[args.Length - needRows + 1];
                //invoke,传入数组参数
                for (int i = min; i <= max; i++)
                {
                    double[][] sn = new double[needRows][];
                    for (int j = 0; j < needRows; j++)
                    {
                        sn[j] = args[i + j];//构造数据列表
                    }
                    res[i] = (double)mi.Invoke(null, new object[] { sn });
                }
                return res;
            }
            else if (ct == 'D')
            {
                double[][] res = new double[args.Length - needRows + 1][];
                //invoke,传入数组参数
                for (int i = min; i < max; i++)
                {
                    double[][] sn = new double[needRows][];
                    for (int j = 0; j < sn.Length; j++)
                    {
                        sn[j] = args[i + j];
                    }
                    res[i] = (double[])mi.Invoke(null, new object[] { sn });
                }
                return res;
            }
            else
                return null;
        }

        /// <summary>
        /// 计算多期AC类型的指标,需要输入所需的行
        /// </summary>
        /// <param name="data">多期数据</param>
        /// <param name="typeName">指标名称(AC类):根据名称来判断数据类别</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
        public static object CalculateAllDataAC(object data, IndexNameType typeName)
        {
            Type t = typeof(PerNoIndexCalculate);
            string name = typeName.ToString();
            MethodInfo mi = t.GetMethod(name);
            char ct = name[0];
            double[][] args = (double[][])data;
            if (ct == 'A') //[] -- 1
            {
                double[] res = new double[args.Length];
                //invoke,传入数组参数
                for (int i = 0; i < args.Length; i++)
                {
                    res[i] = (double)mi.Invoke(null, new object[] { args[i] });
                }
                return res;
            }
            else if (ct == 'C')	  //[] --- []
            {
                double[][] res = new double[args.Length][];
                for (int i = 0; i < args.Length; i++)
                {
                    //invoke,传入数组参数
                    res[i] = (double[])mi.Invoke(null, new object[] { args[i] });
                }
                return res;
            }
            else
                return null;
        }
        #endregion

        #region 获取2个序列的重复号码个数
        /// <summary>
        /// 获取2个序列的重复号码个数
        /// </summary>
        /// <returns>返回重复号码的个数</returns>
        public static int GetRepeatNumbers(double[] data1, double[] data2)
        {
            int count = 0;
            double temp;
            for (int i = 0; i < data1.Length; i++)
            {
                for (int j = 0; j < data2.Length; j++)
                {
                    temp = data1[i] - data2[j];
                    if (Math.Abs(temp) < 0.01) { count++; break; }
                    if (temp < -0.01) { break; }//后面的已经比其越来越大了
                }
            }
            return count;
        }
        #endregion

        #region 获取邻号出现的个数
        /// <summary>
        /// 获取上期的邻号在当前期出现的个数
        /// </summary>
        /// <param name="LastNumber">上期号码</param>
        /// <param name="CurNumber">当期号码</param>
        /// <returns>出现的个数</returns>
        public static int NeighbourNumberCount(double[] LastNumber, double[] CurNumber)
        {
            int count = 0;
            double temp = 0;
            foreach (double item in LastNumber)
            {
                foreach (double cur in CurNumber)
                {
                    temp = Math.Abs(item - cur);
                    if (temp == 1 || temp == 32) count++;
                }
            }
            return count;
        }
        #endregion
             
        #region 文本解释规则进行验证
        /// <summary>
        /// 根据文本规则进行方法验证,并将结果输入到文本中
        /// </summary>
        /// <param name="ruleFilePath">规则文件路径</param>
        public static void ValidateRuleFile(string ruleFilePath)
        {
            List<string> ruleList = TxtParse.GetRuleListFormFile(ruleFilePath);//原始规则
            string[][] ruleStr = TxtParse.ParseRuleList(ruleList);//解析后的规则字符串,每行一个规则,没列为参数列表
            using (StreamWriter sw = new StreamWriter(DateTime.Now.ToShortDateString(), false))
            {
                //调用方法进行计算
                for (int i = 0; i < ruleStr.Length; i++)
                {
                    //基本参数的转化,类型不同

                    //依次计算,并写入结果
                    sw.WriteLine(TxtParse.CombStringArr(ruleStr[i]));
                    //结果
                    sw.WriteLine();
                }
            }
        }
        #endregion
    }
}