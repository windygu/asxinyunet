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

		public static string BytesToBits(byte[] bytes) //byte����ת��Ϊ���������з���
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
						strTemp ="0"+strTemp ; //���㲹�㣬ϵͳĬ�Ͻ�ǰ�����ȥ��
					}
				}
				str+=strTemp;
			}
			return str ;
		}
		public static int[] FrequencyTest(string str , out double X1) //Ƶ�ʲ��ԣ��������ز��ԣ�ͳ��0��1���ֵĴ���
		{
			int[] lengthArr={0,0};
			foreach (char i in str )
			{
				if (i .CompareTo ('1')==0)
					lengthArr [1]++;
				else if (i .CompareTo ('0')==0)
					lengthArr [0]++;
			}		
			X1 =Math .Pow ((lengthArr [0]-lengthArr [1]),2)/(str .Length);//ͳ����X1
			//���Լ��飬��� lengthArr [0] +lengthArr [1] �Ƿ���� str.Length
			return lengthArr ;
		}
		public static void  FrequencyTest(string str,out int n0,out int n1) //����Ƶ�ʲ��Է���
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
		public static int[] TwoByteTest(string str , out double X2) //���в��ԣ���˫���ز���
		{
			int[] lengthArr={0,0,0,0};//�ֱ����00,01,10,11���ֵĴ���
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
			int k, m=1; //ͨ��������֪�����ڱ�׼����n=20000ʱ��m�����ֵΪ8.
			string strTemp="";		
			byte byteTemp;			
			while ((int )Math .Floor ((double )n /m )>=(int )(5*Math .Pow (2,m ))) //�ҵ����ʵ�m
			{
				m ++;
			}
			m=m-1;
			if (m >4)
			{
				m=4;//Ϊ��FIPS����ͳһ�����ڱȽ�
			}
			//Console .WriteLine ("m={0}",m );
			double a=(double )n /m ;
			k =(int)Math .Floor (a );
			int len=(int )Math .Pow (2,m );
			int [] byteArr=new int[len ] ;//�����2^m�������в�һ��
			for (int i=1;i <=k ;i++)
			{
				strTemp =str .Substring (m *(i-1),m  );
				strTemp =strTemp .TrimStart ('0');//ɾ��ǰ����ַ�0��Ȼ��ת��Ϊbyte��ͳ����ֵ��
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
		public static void PorkTest(string str,int m, out double X3) //����PorkTest������ָ��m
		{
			int n=str .Length ;
			string strTemp="";		
			byte byteTemp;
			double a=(double )n /m ;
			int k =(int)Math .Floor (a );
			int len=(int )Math .Pow (2,m );
			int [] byteArr=new int[len ] ;//�����256�������в�һ��
			for (int i=1;i <=k ;i++)
			{
				strTemp =str .Substring (m *(i-1),m  );
				strTemp =strTemp .TrimStart ('0');//ɾ��ǰ����ַ�0��Ȼ��ת��Ϊbyte��ͳ����ֵ��
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
		/// �γ̲���
		/// </summary>
		/// <param name="B">��ĸ��� 1��������</param>
		/// <param name="G">���ĸ��� 0��������</param>
		/// <param name="X4"></param>
		public static int RunTest(string str,out int[] B , out int[] G,out double X4) //�γ̲���,������0��1���ֵĳ��ȼ����ֵĴ���
		{
			//���Ȳ��Գ�������γ̣�ȷ������ĳ���
			char charFlag=str [0];
			int charLength=0,maxLength=0;
			#region ���Գ�������γ�
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
			if (charLength >maxLength ) //�����һ�ε��γ̽���ͳ��
			{
				maxLength =charLength ;
			}
			#endregion
			B =new int[maxLength+1 ] ;
			G =new int[maxLength+1 ] ;
			charFlag =str [0];
			charLength =0;
			#region ͳ���γ�
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
			if (charFlag =='0') //ע������һ���γ̵�ͳ�ƣ���Ҫ��������
				
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
			for (int i=0;i <=n-d -1 ;i ++ ) //ע��d��1-n/2֮��
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
			for (int i=0;i <=n-d -1 ;i ++ ) //ע��d��1-n/2֮��
			{
				Ad += Convert .ToByte ( str [i])^Convert .ToByte (str [i +d ]);
			}
			X5 =2*(Ad -(n -d )/2)/Math .Sqrt (n-d );
		}
		public static bool[] AllTestInOne(byte[] bytes,out double[] testResult,double testlever)
		{
			string str=BytesToBits (bytes );
			int m=4;
			testResult =new double[5] ;//5��ͳ������ֵ
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
			testResult =new double[5] ;//5��ͳ������ֵ
			OneByteCount =FrequencyTest (str ,out testResult [0]);
			TwoByteCount =TwoByteTest (str ,out testResult [1]);
			PorkSeqCount =PorkTest (str ,out testResult [2],out m );
			int [] B;
			int [] G;
			int k=RunTest (str ,out B ,out  G ,out testResult [3]);
			AutocCorrelationTest (str ,8,out testResult [4]); //8Ϊ ָ����dֵ
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
	/// FIPS140_1�����ͳ�Ʋ���
	/// </summary>	
	class FIPS140_1StaticTest  //�涨���Գ���Ϊ20000
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
		public static bool RunTest(string str) //�γ̲���,������0��1���ֵĳ��ȼ����ֵĴ���
		{			
			char charFlag=str [0];
			int charLength=0;
			int[] B =new int[6 ] ;//1
			int[] G =new int[6 ] ;//0
			charFlag =str [0];
			#region ͳ���γ���
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
							G[5]++;//���ȴ���6���γ̾���6����
					}					
					else 
					{
						if (charLength <6) 
						{
							B [charLength-1 ]++;
						}
						else 
							B[5]++;//���ȴ���6���γ̾���6����
					}
					charFlag =str [i ];	
					charLength =1; 
				}
			}
			if (charLength <6) //���һ�ε�ͳ��
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
	/// ��ͳ�Ʊ��еõ��ٽ�ֵ
	/// </summary>
	class GetThresholdValue
	{
		#region Gama�ֲ���
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
		public static double GetGamaDistribVule(int v,double a) //vΪ���ɶȣ�aΪ������ˮƽ
		{   //a ֻ��ȡ����ֵ��0.1��0.05��0.025��0.01��0.005
			//v ֻ��ȥ1-31֮�������ֵ63,127,255,511,1023
			int m,n;//mΪ�б꣬nΪ�б�
			#region ȷ��ȡֵ���б���б�
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
//				return true ; //С����ͨ�����ԣ�������
//			}
//			else
//				return false ;
//		}
		#endregion
		public static bool[] CompareGamaDistribValue(int[] freePoint,double[] gamaValue ,double testLever)
		{  //ͬʱ����4����Ŀ�����ز��Խ��Ϊbool���飬
			bool[] testResult=new bool[freePoint .Length ] ;
			for (int i=0;i<freePoint .Length  ;i ++ )
			{
				if (GetGamaDistribVule (freePoint [i ],testLever )>gamaValue [i ])
				{
					testResult [i]=true ;//ͨ������
				}
				else 
				{
					testResult [i ] =false ;//δͨ������
				}
			}
			return testResult ;
		}
		public static double GetStandaNorDistbValue(double a,byte checkClass)
		{   //checkClassָ�ǵ��߲��Ի���˫�߲���:1 ָ���߲��ԣ�2ָ˫�߲���
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
					//���򱨴�
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
					//���򱨴�
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