using System;
using System .Collections ;

namespace zedDataProcess
{
	/// <summary>
	/// ���ݴ���
	/// </summary>
	public class DataProcess
	{
		/// <summary>
		/// Ƶ����⣬����ÿ�����ݳ��ֵĴ���
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
		/// Ƶ�ʼ�⣬����ÿ�����ݳ��ֵĴ���
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
		/// ��ֵ����
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
		/// ÿ�����ֵĺ�ֵ
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
		/// ÿ�����ֵ����Ը��Ӷȣ���ת��Ϊ����������
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
					//��¼��ǰλ�ò������ע������ȡ��
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
		/// ����һ��������ͬ�����ڣ�������ǰ���ɴ�����һ��������ͬ�ļ�� OneNumSameCycle
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
		/// ����2����ͬ��������ͬ�����ڣ�������ǰ���ɴ����ٶ���������ͬ�ļ�� TwoNumSameCycle
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
		/// ��3��������ͬ
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
		///  ÿ����2��������ͬ�ĳ��ּ��
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
					tempArr.Add (i ) ; //��¼����2����ͬ���ֵ�λ��
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
		/// �������ֳ��ֵ�����
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
		/// ����������ת��Ϊ�ַ��������������Ա���ͼ������ʾ
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
		/// ���K�ε�����ȺͲ����Ƴ̶ȡ��������в���ͬ�������ж���
		/// k >= 2
		/// </summary>
		public static int[] SimilerInRecent(byte[] arr,byte k)
		{
			int n =(int ) arr .Length /3 ;
			int[] result = new int[n ] ;
			for (int i = k -1 ;i <n ; i ++)
			{
				ArrayList tempArr = new ArrayList () ;
				int j = i *3 + 2 ;//��ʼλ����ǰ��ȡ
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
		/// ģʽƥ����,�̶��˺�ѡģʽ
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static int[] PatternDetect(byte[] arr)
		{
			//0·��0��3��6��9����1·��1��4��7����2·��2��5��8����3·
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
		/// ��ÿ�����ӳ���
		/// </summary>
		/// <param name="arr">��������</param>
		/// <param name="max">�������Ŀ��</param>
		/// <param name="min">������С�Ŀ��</param>
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
		/// ��ȼ�⣬��������Ŀ��,type=trueʱ�������ȣ�type=falseʱ�����С���
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
		/// ��ֵ������
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
		/// ������⣺�͵�β��
		/// </summary>
		public static int[] SumOfLast(byte[] arr)
		{
			int[] sum= SumDetect (arr ) ;
			//�����ֵ���������
			for (int i=0;i <sum .Length ;i ++ )
			{
				sum [i ] -= (int )(Math .Floor ((double )sum[i ] /10))*10 ;
			}
			return sum ;
		}
		/// <summary>
		/// ģʽת��
		/// </summary>
		/// <param name="arr">Ҫת��������</param>
		/// <param name="patternList">ת����ģʽ,�ɸ�����ͬ��ģʽ,�����Сģʽ����3ģʽ</param>
		public static int[] ConverPattern(byte[] arr , ArrayList[] patternList)
		{
			int[] newArr = new int[arr .Length ] ;
			for (int i=0;i <arr .Length ; i ++ )
			{
				for (int j=0;j <patternList .Length ;i ++ )
				{
					if (patternList [j ].Contains (arr [i ]))//������ǰֵ��ƥ��
					{
						newArr [i ] = j ;
						break ;
					}
				}
			}
			return newArr ;
		}
		/// <summary>
		/// �����Ƿ�һ���򼸸����Ƿ���ָ���������
		/// </summary>
		/// <param name="setValue"></param>
		/// <param name="compArr">ָ������</param>
		/// <returns>���رȽϽ��</returns>
		public static bool Contains(byte setValue , byte[] compArr)//Ϊһ��ֵʱ
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
		/// ���ط������Ƚϼ��������Ƿ���ָ�������ڳ���
		/// </summary>
		/// <returns >������ͬ�ĸ���</returns>
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
		/// ���ط������Ƚϼ��������Ƿ���ָ�������ڳ���
		/// </summary>
		/// <returns >���رȽϽ��</returns>
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