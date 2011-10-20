/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2008-3-27
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System .Text ;

namespace zedDataProcess
{
	class BasicStaticTest
	{
		public  static int[] OneByteCount;
		public  static int[] TwoByteCount;
		public  static int[] PorkSeqCount;

		public static string BytesToBits(byte[] bytes) //byte数组转换为二进制序列方法
		{
			string str="";  //3636
			string strTemp;
			foreach (byte i in bytes)
			{
				strTemp =Convert .ToString (i ,2);
				int m=strTemp .Length ;
				if (m !=8 )
				{
					for (int k=0;k  <(8-m ) ;k  ++ )
					{
						strTemp ="0"+strTemp ; //不足补零，系统默认将前面的零去掉
					}
				}
				str+=strTemp;
			}
			return str ;
		}
		public static int[] FrequencyTest(string str , out double X1) //频率测试，即单比特测试，统计0，1出现的次数
		{
			int[] lengthArr={0,0};
			foreach (char i in str )
			{
				if (i .CompareTo ('1')==0)
					lengthArr [1]++;
				else if (i .CompareTo ('0')==0)
					lengthArr [0]++;
			}		
			X1 =Math .Pow ((lengthArr [0]-lengthArr [1]),2)/(str .Length);//统计量X1
			//可以检验，如果 lengthArr [0] +lengthArr [1] 是否等于 str.Length
			return lengthArr ;
		}
		public static void  FrequencyTest(string str,out int n0,out int n1) //重载频率测试方法
		{
			n0 =0;
			n1 =0;
			foreach (char i in str )
			{
				if (i .CompareTo ('1')==0)
					n0 ++;
				else if (i .CompareTo ('0')==0)
					n1 ++;
			}			
		}
		public static int[] TwoByteTest(string str , out double X2) //序列测试，即双比特测试
		{
			int[] lengthArr={0,0,0,0};//分别代表00,01,10,11出现的次数
			int n0,n1;
			FrequencyTest (str ,out  n0,out  n1 );
			for (int i=0;i <str .Length -1 ;i ++ )
			{
				string s=str [i ]+"";
				s +=str [i +1];
				switch (s ) 
				{
						case "00":lengthArr [0]++;
						           break;
				        case "01":lengthArr [1]++;
						           break ;
				        case "10":lengthArr [2]++;
						           break ;
					    case "11":lengthArr [3]++;
						           break ;
				}
			}
			double sum1=0,sum2=0;
			foreach (int k in lengthArr )
			{
				sum1 +=Math .Pow (k ,2);
			}
			sum2 =Math .Pow (n0 ,2)+Math .Pow (n1 ,2);
			X2 =4*sum1 /(str .Length -1)-2*sum2 /str .Length +1;
			return lengthArr ;
		}
		public static int[] PorkTest(string str,out double X3,out int mm)
		{
			int n=str .Length ;
			int k, m=1; //通过分析可知，对于标准测试n=20000时，m的最大值为8.
			string strTemp="";		
			byte byteTemp;			
			while ((int )Math .Floor ((double )n /m )>=(int )(5*Math .Pow (2,m ))) //找到合适的m
			{
				m ++;
			}
			m=m-1;
			if (m >4)
			{
				m=4;//为与FIPS测试统一，便于比较
			}
			//Console .WriteLine ("m={0}",m );
			double a=(double )n /m ;
			k =(int)Math .Floor (a );
			int len=(int )Math .Pow (2,m );
			int [] byteArr=new int[len ] ;//最多有2^m个子序列不一样
			for (int i=1;i <=k ;i++)
			{
				strTemp =str .Substring (m *(i-1),m  );
				strTemp =strTemp .TrimStart ('0');//删除前面的字符0，然后转换为byte型统计其值。
				if (strTemp .Length ==0)
				{
					
					
					byteArr [0]++ ;
				}
				else
				{
					byteTemp =Convert .ToByte (strTemp,2 );
					byteArr [byteTemp]++;
				}
			}
			double sumN=0;
			foreach (int i in byteArr )
			{
				sumN +=Math .Pow (i,2) ;
			}
			X3 =Math .Pow (2,m )*sumN /k -k ;
			mm =m ;
			return byteArr ;
		}
		public static void PorkTest(string str,int m, out double X3) //重载PorkTest方法，指定m
		{
			int n=str .Length ;
			string strTemp="";		
			byte byteTemp;
			double a=(double )n /m ;
			int k =(int)Math .Floor (a );
			int len=(int )Math .Pow (2,m );
			int [] byteArr=new int[len ] ;//最多有256个子序列不一样
			for (int i=1;i <=k ;i++)
			{
				strTemp =str .Substring (m *(i-1),m  );
				strTemp =strTemp .TrimStart ('0');//删除前面的字符0，然后转换为byte型统计其值。
				if (strTemp .Length ==0)
				{
					byteArr [0]++;
				}
				else
				{
					byteTemp =Convert .ToByte (strTemp,2 );
					byteArr [byteTemp]++;
				}
			}
			double sumN=0;
			foreach (int i in byteArr )
			{
				
				sumN +=Math .Pow (i,2) ;
			}
			X3 =Math .Pow (2,m )*sumN /k -k ;
			//return byteArr ;
		}
		
		/// <summary>
		/// 游程测试
		/// </summary>
		/// <param name="B">块的个数 1的子序列</param>
		/// <param name="G">沟的个数 0的子序列</param>
		/// <param name="X4"></param>
		public static int RunTest(string str,out int[] B , out int[] G,out double X4) //游程测试,连续的0或1出现的长度及出现的次数
		{
			//首先测试长度最长的游程，确定数组的长度
			char charFlag=str [0];
			int charLength=0,maxLength=0;
			#region 测试长度最长的游程
			for (int i=0;i <str .Length  ;i ++ )
			{
				if (charFlag ==str [i ])
				{
					charLength ++;
				}
				else
				{					
					if (charLength >maxLength )
					{
						maxLength =charLength ;						
					}
					charFlag =str [i ]; 
					charLength =1;
				}
			}
			if (charLength >maxLength ) //对最后一次的游程进行统计
			{
				maxLength =charLength ;
			}
			#endregion
			B =new int[maxLength+1 ] ;
			G =new int[maxLength+1 ] ;
			charFlag =str [0];
			charLength =0;
			#region 统计游程
			for (int i=0;i <str .Length  ;i ++ )
			{
				if (charFlag ==str [i]) 
				{
					charLength ++;
				}
				else
				{
					if (charFlag =='0')
					{
						G [charLength ]++;
					}
					else 
					{
						B [charLength ]++;
					}
					charFlag =str [i ];	
					charLength =1; 
				}
			}
			if (charFlag =='0') //注意对最后一个游程的统计，需要单独处理
				
			{
				G [charLength ]++;				
			}
			else 
			{
				B [charLength ]++;
			}
			#endregion 
			double [] e=new double[maxLength +1] ;
			int k=0;
			for (int i=1;i <=maxLength ;i ++ )
			{
				e [i]=(double )(str .Length -i +3)/Math.Pow (2,i +2);
				k =e [i]>=5? i : k ;
			}
			double sumBe=0,sumGe=0;
			for (int i=1;i <=k  ;i ++ )
			{
				sumBe += Math .Pow (B [i ]-e [i],2)/e[i];
				sumGe += Math .Pow (G [i ]-e [i ],2)/e [i];
			}			
			X4 =sumGe +sumBe ;
			return k ;
		}			
		public static void  AutocCorrelationTest(string str,int d,out double X5)
		{
			int Ad=0;
			int n=str .Length ;
			for (int i=0;i <=n-d -1 ;i ++ ) //注意d在1-n/2之间
			{
				Ad += Convert .ToByte ( str [i])^Convert .ToByte (str [i +d ]);
			}
			X5 =2*(Ad -(n -d )/2)/Math .Sqrt (n-d );
		}
		public static void  AutocCorrelationTest(string str,out double X5)
		{
			int d=(int )str .Length /6;
			int Ad=0;
			int n=str .Length ;
			for (int i=0;i <=n-d -1 ;i ++ ) //注意d在1-n/2之间
			{
				Ad += Convert .ToByte ( str [i])^Convert .ToByte (str [i +d ]);
			}
			X5 =2*(Ad -(n -d )/2)/Math .Sqrt (n-d );
		}
		public static bool[] AllTestInOne(byte[] bytes,out double[] testResult,double testlever)
		{
			string str=BytesToBits (bytes );
			int m=4;
			testResult =new double[5] ;//5个统计量的值
			OneByteCount =FrequencyTest (str ,out testResult [0]);
			TwoByteCount =TwoByteTest (str ,out testResult [1]);
			PorkTest (str ,m,out testResult [2]);//out m
			int [] B;
			int [] G;
			int k=RunTest (str ,out B ,out  G ,out testResult [3]);
			AutocCorrelationTest (str ,out testResult [4]);
			double testLever=testlever ;
			int[] freePoint={1,2,(int )Math .Pow (2,m )-1,2*k -2};
			double[] gamaValue={testResult[0], testResult[1],testResult[2],testResult[3]};
			bool[] res=GetThresholdValue .CompareGamaDistribValue (freePoint ,gamaValue ,testLever );
			bool NorResult=GetThresholdValue .CompareStandNorDisValue (testResult [4],testLever ,2);
			bool[] result={res[0],res[1],res[2],res[3],NorResult };
			return result ;
		}
		public static bool[] AllTestInOne(string str,out double[] testResult,double testlever)
		{
			int m;
			testResult =new double[5] ;//5个统计量的值
			OneByteCount =FrequencyTest (str ,out testResult [0]);
			TwoByteCount =TwoByteTest (str ,out testResult [1]);
			PorkSeqCount =PorkTest (str ,out testResult [2],out m );
			int [] B;
			int [] G;
			int k=RunTest (str ,out B ,out  G ,out testResult [3]);
			AutocCorrelationTest (str ,8,out testResult [4]); //8为 指定的d值
			double testLever=testlever;
			int[] freePoint={1,2,(int )Math .Pow (2,m )-1,2*k -2};
			double[] gamaValue={testResult[0], testResult[1],testResult[2],testResult[3]};
			bool[] res=GetThresholdValue .CompareGamaDistribValue (freePoint ,gamaValue ,testLever );
			bool NorResult=GetThresholdValue .CompareStandNorDisValue (testResult [4],testLever ,2);
			bool[] result={res[0],res[1],res[2],res[3],NorResult };
			return result ;
		}
	}
	
	/// <summary>
	/// FIPS140_1随机性统计测试
	/// </summary>	
	class FIPS140_1StaticTest  //规定测试长度为20000
	{	
		public static bool RangeJudge(int testValue,int n1,int n2)
		{
			if (testValue >=n1 && testValue <=n2 ) 
			{
				return true ;
			}
			else return false ;
		}
		public static bool OneBitsTest(string str)
		{
			int[] n=new int[2] ;
			BasicStaticTest .FrequencyTest (str ,out n [0],out n[1]);
			if (RangeJudge (n [1], 9645,10346))
				return true ;
			else return false ;
		}
		public static bool PorkTest(string str)
		{
			double X;
			BasicStaticTest .PorkTest (str ,4,out X);
			if (X >1.03&&X <57.4) 
				return true ;
			else return false ;
		}		
		public static bool RunTest(string str) //游程测试,连续的0或1出现的长度及出现的次数
		{			
			char charFlag=str [0];
			int charLength=0;
			int[] B =new int[6 ] ;//1
			int[] G =new int[6 ] ;//0
			charFlag =str [0];
			#region 统计游程数
			for (int i=0;i <str .Length  ;i ++ )
			{
				if (charFlag ==str [i]) 
				{
					charLength ++;
				}
				else
				{
					if (charFlag =='0') 
					{
						if (charLength <6) 
						{
							G [charLength-1 ]++;
						}
						else 
							G[5]++;//长度大于6的游程均按6处理
					}					
					else 
					{
						if (charLength <6) 
						{
							B [charLength-1 ]++;
						}
						else 
							B[5]++;//长度大于6的游程均按6处理
					}
					charFlag =str [i ];	
					charLength =1; 
				}
			}
			if (charLength <6) //最后一次的统计
			{
				if (charFlag =='0') 
				{
					G [charLength-1 ]++;
				}
				else 
					B [charLength-1 ]++;
				
			}
			else
			{
				if (charFlag =='0') 
				{
					G [5]++;
				}
				else 
					B [5]++;
				
			}
			#endregion 
			bool[] result1=new bool[6] ;
			bool[] result2=new bool[6] ;
			int[] n1={2267,1079,502,223,90,90};
			int[] n2={2733,1421,748,402,223,223};
			for (int i=0;i<6 ;i++ )
			{
				result1 [i]=RangeJudge (B [i],n1 [i],n2 [i ]);
				result2 [i]=RangeJudge (G [i],n1 [i],n2 [i ]);
			}
			bool lastResult=true;
			for (int j=0;j <6 ;j ++ )
			{
				if (result1 [j ]==false ) 
				{
					lastResult =false ;	
					break ;
				}
				if (result2 [j ]==false ) 
				{
					lastResult =false ;	
					break ;
				}
			}
			return lastResult ;
		}
		public static bool LongRunTest(string str)
		{
		 	char charFlag=str [0];
			int charLength=0,maxLength=0;
			for (int i=0;i <str .Length  ;i ++ )
			{
				if (charFlag ==str [i ])
				{
					charLength ++;
				}
				else
				{					
					if (charLength >maxLength )
					{
						maxLength =charLength ;						
					}
					charFlag =str [i ];
					charLength =1;
				}
			}
			if (maxLength <=34)
				return true ;
			else return false ;
		}
		public static bool[] AllTestInOne(string str)
		{
			bool[] result=new bool[4] ;
			result [0]=OneBitsTest (str );
			result [1]=PorkTest (str );
			result [2]=RunTest (str );
			result [3]=LongRunTest (str);
			return result ;
		}
		public static bool[] AllTestInOne(byte[] arr)
		{
			string str=BasicStaticTest .BytesToBits (arr );
			bool[] result=new bool[4] ;
			result [0]=OneBitsTest (str );
			result [1]=PorkTest (str );
			result [2]=RunTest (str );
			result [3]=LongRunTest (str);
			return result ;
		}
	}
	
	/// <summary>
	/// 从统计表中得到临界值
	/// </summary>
	class GetThresholdValue
	{
		#region Gama分布表
		private static double[,] standardNormalTable={{0.1,0.05,0.025,0.01,0.005,0.0025,0.001,0.0005},
			{1.2816,1.6449,1.96,2.3263,2.5758,2.807,3.0902,3.2905}};
		private static double[,] gamaTable={{2.706,3.841,5.024,6.635,7.879},
			{4.605,	5.991,	7.378,	9.21,	10.597},
			{6.251,	7.815,	9.348,	11.345,	12.838},
			{7.779,	9.488,	11.143,	13.277,	14.86},
			{9.236,	11.071,	12.833,	15.086,	16.75},
			{10.645,12.592,	14.449,	16.812,	18.548},
			{12.017,14.067,	16.013,	18.475,	20.278},
			{13.362,15.507,	17.535,	20.09,	21.955},
			{14.684,16.919,	19.023,	21.666,	23.589},
			{15.987,18.307,	20.483,	23.209,	25.188},
			{17.275,19.675,	21.92,	24.725,	26.757},
			{18.549,21.026,	23.337,	26.217,	28.299},
			{19.812,22.362,	24.736,	27.688,	29.819},
			{21.064,23.685,	26.119,	29.141,	31.319},
			{22.307,24.996,	27.488,	30.578,	32.801},
			{23.542,26.296,	28.845,	32.0,	34.267},
			{24.769,27.587,	30.191,	33.409,	35.718},
			{25.989,28.869,	31.526,	34.805,	37.156},
			{27.204,30.144,	32.852,	36.191,	38.582},
			{28.412,31.41,	34.17,	37.566,	39.997},
			{29.615,32.671,	35.479,	38.932,	41.401},
			{30.813,33.924,	36.781,	40.289,	42.796},
			{32.007,35.172,	38.076,	41.638,	44.181},
			{33.196,36.415,	39.364,	42.98,	45.559},
			{34.382,37.652,	40.646,	44.314,	46.928},
			{35.563,38.885,	41.923,	45.642,	48.29},
			{36.741,40.113,	43.194,	46.963,	49.645},
			{37.916,41.337,	44.461,	48.278,	50.993},
			{39.087,42.557,	45.722,	49.588,	52.336},
			{40.256,43.773,	46.979,	50.892,	53.672},
			{41.422,44.985,	48.232,	52.191,	55.003},
			{77.7454,82.529,86.83,	92.01,	95.65},
			{147.81,154.302,160.086,166.987,171.796},
			{284.34,293.25,	301.13,	310.46,	316.92},
			{552.374,564.69,575.53,	588.298,597.098},
			{1081.379,1098.521,1113.533,1131.159,1143.27}};
		#endregion
		public static double GetGamaDistribVule(int v,double a) //v为自由度，a为显著性水平
		{   //a 只能取下列值：0.1，0.05，0.025，0.01，0.005
			//v 只能去1-31之间和下列值63,127,255,511,1023
			int m,n;//m为行标，n为列标
			#region 确定取值的行标和列标
			if(a ==0.1)
				n =0;
			else if (a ==0.05)
				n =1;
			else if (a ==0.025)
				n =2;
			else if (a ==0.01)
				n =3;
			else if (a ==0.005)
				n =4;
			else
				n=-2;
			
			if (v ==63)
				m =31;
			else if (v==127)
				m =32;
			else if (v ==255)
				m =33;
			else if (v ==511)
				m =34;
			else if (v ==1023)
				m =35;
			else
				m =v -1;
			#endregion
			return gamaTable [m ,n];
		}
		#region
//		public static bool CompareGamaDistribValue(int v ,double a,double gamaValue)
//		{
//			double thresholdValue=GetGamaDistribVule (v ,a );
//			if (gamaValue <thresholdValue )
//			{
//				return true ; //小于则通过测试，返回真
//			}
//			else
//				return false ;
//		}
		#endregion
		public static bool[] CompareGamaDistribValue(int[] freePoint,double[] gamaValue ,double testLever)
		{  //同时测试4个项目，返回测试结果为bool数组，
			bool[] testResult=new bool[freePoint .Length ] ;
			for (int i=0;i<freePoint .Length  ;i ++ )
			{
				if (GetGamaDistribVule (freePoint [i ],testLever )>gamaValue [i ])
				{
					testResult [i]=true ;//通过测试
				}
				else 
				{
					testResult [i ] =false ;//未通过测试
				}
			}
			return testResult ;
		}
		public static double GetStandaNorDistbValue(double a,byte checkClass)
		{   //checkClass指是单边测试还是双边测试:1 指单边测试，2指双边测试
			double returnValue=0;
			if (checkClass ==1)
			{
				for (int i=0;i <standardNormalTable .Length ;i ++ )
				{
					if (standardNormalTable [0,i ]==a )
					{
						returnValue = standardNormalTable [1,i ];
						break ;
					}
					//否则报错
				}
			}
			else
			{
				for (int i=0;i <standardNormalTable .Length ;i ++ )
				{
					if (standardNormalTable [0,i ]==a/2 )
					{
						returnValue = standardNormalTable [1,i ];
						break ;
					}
					//否则报错
				}
			}
			return returnValue ;
		}
		public static bool CompareStandNorDisValue(double testValue,double testLever,byte checkClass)
		{
			if (testValue <GetStandaNorDistbValue (testLever ,checkClass ))
			{
				return true ;
			}
			else return false ;
		}
	}
}