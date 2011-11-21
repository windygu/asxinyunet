using System;
using System .Collections ;

namespace zedDataProcess
{
	/// <summary>
	/// 数据处理
	/// </summary>
	public class DataProcess
	{
		/// <summary>
		/// 频数检测，检验每种数据出现的次数
		/// </summary>
		public static int[] FrequCount(byte[] arr)
		{
			int[] sum = new int[10 ] ;
			for (int i = 0 ;i <arr .Length ; i ++ ) 
			{
				sum [arr [i ]] ++ ;
			}
			return sum ;
		}
		/// <summary>
		/// 频率检测，检验每种数据出现的次数
		/// </summary>
		public static double [] Frequence(byte[] arr)
		{
			int[] sum = new int[10 ] ;
			double[] sumd = new double[10] ;
			for (int i = 0 ;i <arr .Length ; i ++ ) 
			{
				sum [arr [i ]] ++ ;
			}
			for (int i = 0;i <10 ;i ++ )
			{
				sumd [i ] = (double ) sum [i ] /10 ;
			}
			return sumd ;
		}
		/// <summary>
		/// 均值计算
		/// </summary>
		public static double[] MeanOfArray(byte[] arr )
		{
			int n =(int ) arr .Length /3 ;
			double[] mean =new double[n ] ;
			for (int i= 0; i <n  ; i ++)
			{
				mean [i ] = (double )(arr [i *3] +arr [i *3+1]+arr [i *3+2])/3 ;
			}
			return mean ;
		}
		/// <summary>
		/// 每组数字的和值
		/// </summary>		
		public static int[] SumOfArray(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] sum = new int[n ] ;
			for (int i= 0; i <n  ; i ++)
			{
				sum[i ] = arr [i *3] +arr [i *3+1]+arr [i *3+2] ;
			}
			return sum ;
		}
		/// <summary>
		/// 每组数字的线性复杂度，先转化为二进制数据
		/// </summary>
		public static int[] LinearComplex(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] complexity = new int[n ] ;
			for (int i= 0; i <n  ; i ++)
			{
				byte[] bytes = {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				complexity [i ] = B_Malgorithm .LinerComplex (bytes ) ;
			}
			return complexity ;
		}
		public static int FindOne(int i ,byte[] findValue ,byte[] arr)
		{
			int interval = 0 ;
			int locate = 0 ;
			for (int j = i *3-1 ; j >=0 ; j -- )
			{
				if (findValue [0]== arr [j ] || findValue [1]==arr [j ] || findValue [2]==arr [j ] )
				{
					//记录当前位置并相减，注意向下取整
					locate = (int )Math .Floor ((double )j /3) ;
					interval = i - locate ;
					break ;
				}
			}
			return interval ;
		}
		public static int FindTwo(int i ,byte[] findValue ,byte[] arr)
		{
			int interval = 0 ;				
			for (int j = i -1 ; j >=0 ; j -- )
			{
				int count = 0 ;
				byte[] temp = {arr [j *3] , arr [j*3+1] , arr [j *3+2]} ;
				for (byte k = 0 ;k<3 ;k ++ )
				{
					if (findValue [k]==temp [0])
					{					
						count ++ ;
						break ;
					}
				}
				for (byte k = 0 ;k<3 ;k ++ )
				{
					if (findValue [k]==temp [1] && temp [0]!=temp [1])
					{
						count ++ ;
						break ;
					}
				}
				if (count ==2 )
				{
					break ;
				}
				else 
				{
					for (byte k = 0 ;k<3 ;k ++ )
					{
						if (findValue [k]==temp [2] && temp [0]!=temp [2]&& temp [1]!=temp [2])
						{
							count ++ ;
							break ;
						}
					}
				}
				if (count ==2 )
				{
					interval = i - j ;
					break ;
				}
			}
			return interval ;
		}
		public static int FindThree(int i ,byte[] findValue ,byte[] arr)
		{
			int interval = 0 ;				
			for (int j = i -1 ; j >=0 ; j -- )
			{
				int count = 0 ;
				byte[] temp = {arr [j *3] , arr [j*3+1] , arr [j *3+2]} ;
				for (byte k = 0 ;k<3 ;k ++ )
				{
					if (findValue [k]== temp [0 ] )
					{					
						count ++ ;
						break ;
					}					
				}
				for (byte k = 0 ;k<3 ;k ++ )
				{
					if (findValue [k]== temp [1 ] && temp [0]!= temp [1])
					{
						count ++ ;
						break ;
					}
				}
				for (byte k = 0 ;k<3 ;k ++ )
				{
					if (findValue [k]== temp [2 ] && temp [0]!= temp [2]&& temp [1]!= temp [2])
					{
						count ++ ;
						break ;
					}
				}
				if(count == 3)
				{
					interval = i - j ;
						break ;
				}
			}
			return interval ;
		}
		/// <summary>
		/// 至少一个数字相同的周期：本次与前若干次至少一个数字相同的间隔 OneNumSameCycle
		/// </summary>
		public static int[] OneInterval(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] interval = new int[n ] ;
			for (int i= 0; i <n  ; i ++)
			{
				byte[] bytes = {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				interval [i ] = FindOne (i ,bytes ,arr ) ;
			}
			return interval ;
		}
		/// <summary>
		/// 至少2个不同的数字相同的周期：本次与前若干次至少二个数字相同的间隔 TwoNumSameCycle
		/// </summary>
		public static int[] TwoInterval(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] interval = new int[n ] ;
			for (int i= 0; i <n  ; i ++)
			{
				byte[] bytes = {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				interval [i ] = FindTwo (i ,bytes ,arr ) ;
			}
			return interval ;
		}
		/// <summary>
		/// 有3个数字相同
		/// </summary>`
		public static int[] ThreeInterval(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] interval = new int[n ] ;
			for (int  i= 0; i <n  ; i ++)
			{
				byte[] bytes = {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				interval [i ] = FindThree (i ,bytes ,arr ) ;
			}
			return interval ;
		}
		
		/// <summary>
		///  每组有2个数字相同的出现间隔
		/// </summary>
		public static int[] TwoSameInOne(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			ArrayList tempArr = new ArrayList () ;
			for (int  i= 0; i <n  ; i ++)
			{
				byte[] temp= {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				if (temp[0]==temp [1]||temp [0]==temp [2]||temp [1]==temp [2])
				{
					tempArr.Add (i ) ; //记录下有2个相同数字的位置
				}
			}
			int[] interval =new int[tempArr.Count ] ;
			int[] temp1 =new int[tempArr.Count ] ;
			for (int i=0;i <tempArr .Count ;i ++ )
			{
				temp1 [i ] =Convert .ToInt32 ( tempArr [i ].ToString ()) ;				
			}		
			for (int i = 1; i <tempArr .Count ;i ++ )
			{
				interval [i] =temp1 [i ] - temp1 [i -1] ;
			}
			return interval ;
		}
		
		/// <summary>
		/// 单个数字出现的周期
		/// </summary>
		public static int[] SingleCycle(byte[] arr , byte m )
		{
			int n =(int ) arr .Length /3 ;
			ArrayList tempArr = new ArrayList () ;
			for (int i= 0; i <n  ; i ++)
			{
				byte[] temp= {arr [i *3] , arr [i *3+1] , arr [i *3+2]} ;
				if (temp[0]==m || temp [1]==m || temp [2]==m )
				{
					tempArr .Add (i ) ; 
				}
			}
			int[] interval =new int[tempArr.Count ] ;
			int[] temp1 =new int[tempArr.Count ] ;
			for (int i=0;i <tempArr .Count ;i ++ )
			{
				temp1[i ] = Convert .ToInt32 ( tempArr [i ].ToString ()) ;
				Console .WriteLine (temp1 [i ]) ;
			}
			Console .WriteLine ();
			for (int i = 1; i <tempArr .Count ;i ++ )
			{
				interval [i] =temp1[i ] - temp1[i -1] ;
			}
			return interval ;
		}
		public static int[][] AllSingleCycle(byte[] arr)
		{
			int[][] number = new int[10][] ;
			for (byte i = 0 ; i <10 ;i ++ )
			{
				number [i ] = SingleCycle (arr ,i ) ;
			}			
			return number ;
		}
		
		/// <summary>
		/// 将整数数组转化为字符串并加入间隔，以便在图形上显示
		/// </summary>	
		public static string NumberToString(int[] arr ,int length)
		{
			string str = "\n" ;
			int count = 0 ;
			for (int i=0;i <arr .Length ;i ++ ) 
			{
				string temp = arr [i ] .ToString () ;
				if ((count +temp .Length )>length ) 
				{
					str += "\n" ;
					count = 0 ;
				}
				str += temp ;
				count = temp .Length ;
			}
			return str ;
		}

		/// <summary>
		/// 最近K次的冗余度和不相似程度。看集合中不相同的数字有多少
		/// k >= 2
		/// </summary>
		public static int[] SimilerInRecent(byte[] arr,byte k)
		{
			int n =(int ) arr .Length /3 ;
			int[] result = new int[n ] ;
			for (int i = k -1 ;i <n ; i ++)
			{
				ArrayList tempArr = new ArrayList () ;
				int j = i *3 + 2 ;//起始位置往前读取
				int lever = 3*(i +1-k ) ;
				while (j >= lever )
				{
					if (tempArr .Contains (arr [j ]) == false )
					{
						tempArr .Add (arr [j ]) ;
					}
					j -- ;
				}
				result [i ] =tempArr .Count ;
			}
			return result ;
		}
		/// <summary>
		/// 模式匹配检测,固定了候选模式
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static int[] PatternDetect(byte[] arr)
		{
			//0路（0、3、6、9），1路（1、4、7），2路（2、5、8）共3路
			ArrayList[] style = new ArrayList[3] ;
			int n =(int ) arr .Length /3 ;
			int[] patternCount = new int[n ] ;
			style [0] = new ArrayList {0,1,2,3};
			style [1] = new ArrayList {4,5,6};
			style [2] = new ArrayList {7,8,9};
//			style [0] = new ArrayList {0,3,6,9};
//			style [1] = new ArrayList {1,4,7};
//			style [2] = new ArrayList {2,5,8};
			
			for (int i=0;i <n ;i ++)
			{
				int[] tempArr = {arr [3*i ],arr [3*i +1],arr [3*i +2]} ;
				ArrayList tempList = new ArrayList () ;
				for (int j =0 ;j <3 ;j ++ )
				{
					for (int k=0;k <3;k ++ )
					{
						if (style [k ] .Contains (tempArr [ j ]))
						{
							if (!tempList .Contains (k ))
							{
								tempList .Add (k ) ;
							}
						}
					}
				}
				patternCount [i ] =tempList .Count ;
			}
			return patternCount ;
		}
		
		/// <summary>
		/// 求每组跨度子程序
		/// </summary>
		/// <param name="arr">输入数组</param>
		/// <param name="max">返回最大的跨度</param>
		/// <param name="min">返回最小的跨度</param>
		public static void Span(byte[] arr,out int max , out int min)
		{
			max = (int )Math .Abs (arr [0 ] - arr [1] ) ;
			min = (int ) Math .Abs (arr [0] - arr [2] ) ;
			if (max <min )
			{
				int temp = min ;
				min = max ;
				max = temp ;
			}
			int temp1 = (int )Math.Abs (arr [1] -arr [2]) ;
			if (temp1 >max )
			{
				max = temp1 ;
			}
			else
			{
				if (temp1 <min )
				{
					min = temp1 ;
				}
			}
		}
		/// <summary>
		/// 跨度检测，求所有组的跨度,type=true时输出最大跨度，type=false时输出最小跨度
		/// </summary>
		public static int[] SpanDetect(byte[] arr , bool type )
		{
			int n =(int ) arr .Length /3 ;
			int[] MaxSpanCount = new int[n ] ;
			int[] MinSpanCount = new int[n ] ;
			for (int i=0;i <n ;i ++ )
			{
				byte[] tempArr = {arr [3*i ],arr [3*i +1],arr [3*i +2]} ;
				Span (tempArr ,out MaxSpanCount [i ] ,out MinSpanCount [i ] );
			}
			if (type )
				return MaxSpanCount ;
			else 
				return MinSpanCount ;
		}
		/// <summary>
		/// 和值检测程序
		/// </summary>
		public static int[] SumDetect(byte[] arr)
		{
			int n =(int ) arr .Length /3 ;
			int[] sum = new int[n ] ;
			for (int i=0;i <n ;i ++ )
			{
				sum[i ] = arr [3*i ]+arr [3*i +1]+arr [3*i +2] ;
			}
			return sum ;
		}
		/// <summary>
		/// 合数检测：和的尾数
		/// </summary>
		public static int[] SumOfLast(byte[] arr)
		{
			int[] sum= SumDetect (arr ) ;
			//先求和值，再求合数
			for (int i=0;i <sum .Length ;i ++ )
			{
				sum [i ] -= (int )(Math .Floor ((double )sum[i ] /10))*10 ;
			}
			return sum ;
		}
		/// <summary>
		/// 模式转换
		/// </summary>
		/// <param name="arr">要转换的数组</param>
		/// <param name="patternList">转换的模式,可更换不同的模式,如大中小模式或余3模式</param>
		public static int[] ConverPattern(byte[] arr , ArrayList[] patternList)
		{
			int[] newArr = new int[arr .Length ] ;
			for (int i=0;i <arr .Length ; i ++ )
			{
				for (int j=0;j <patternList .Length ;i ++ )
				{
					if (patternList [j ].Contains (arr [i ]))//包括当前值则匹配
					{
						newArr [i ] = j ;
						break ;
					}
				}
			}
			return newArr ;
		}
		/// <summary>
		/// 测试是否一个或几个数是否在指定数组出现
		/// </summary>
		/// <param name="setValue"></param>
		/// <param name="compArr">指定数组</param>
		/// <returns>返回比较结果</returns>
		public static bool Contains(byte setValue , byte[] compArr)//为一个值时
		{
			bool result = false ;
			for (int i=0 ;i <compArr .Length ;i ++ )
			{
				if (compArr [i ] == setValue )
				{
					result = true ;
					break ;
				}
			}
			return result ;
		}
		/// <summary>
		/// 重载方法：比较几个数字是否在指定数组内出现
		/// </summary>
		/// <returns >返回相同的个数</returns>
		public static int ContainsArr(byte[] setValue , byte[] compArr)
		{
			int count = 0 ;
			for (int i=0 ; i < setValue .Length ; i ++ )
			{
				if (Contains (setValue [i ] ,compArr ))
				{
					count ++ ;
				}
			}
			return count ;
		}
		/// <summary>
		/// 重载方法：比较几个数字是否在指定数组内出现
		/// </summary>
		/// <returns >返回比较结果</returns>
		public static bool Contains(byte[] setValue , byte[] compArr)
		{
			if (ContainsArr(setValue ,compArr )==0 )
			{
				return false ;
			}
			else
				return true ;
		}
	}
}