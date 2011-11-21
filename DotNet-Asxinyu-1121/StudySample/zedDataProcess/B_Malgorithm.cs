/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2008-5-17
 * Time: 22:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System .Collections ;

namespace zedDataProcess
{
	/// <summary>
	/// B-M算法：计算序列的线性复杂性
	/// </summary>
	
	public class B_Malgorithm 
	{
		public static string BytesToBits(byte[] bytes) //byte数组转换为二进制序列方法
		{
			string str="";
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
		public static int LinerComplex(string str)
		{
			Hashtable T = new Hashtable () ;
			Hashtable B = new Hashtable () ;
			Hashtable C = new Hashtable () ;
			C .Add (0,1) ;
			B .Add (0,1) ;
			int m = -1 , N = 0 , L = 0 ; //上述步骤完成初始化
			while (N < str.Length )
			{ //计算离差
				int d = str [N ] == '0' ? 0 : 1 ;
				int i = 1 ;
				#region
				while (i <= L ) 
				{					
					if (C .ContainsKey (i ))
					{
						if (str [N-i ] == '1') 
							d += 1 ;  //则ci = 1 
					}
				    i++ ;
				}
				d = d % 2;
				if ( d ==1 ) 
				{
					T = (Hashtable )C.Clone() ;
					foreach (DictionaryEntry k in B )
					{
						if ((int )k .Value == 1)
						{
							int temp = (int )k .Key + N - m ;
							if (C .ContainsKey (temp ))
							{
								C .Remove (temp ) ;
							}
							else
							{
								C .Add (temp ,1 ) ;
							}
						}
					}
					if (L <= (int )Math .Floor (N *0.5) )
					{
						L = N +1 -L ;
						m = N ;
						B =(Hashtable ) T.Clone() ;
					}				
				}
				#endregion
//			    Console.Write("L = {0}  ;", L);
//                foreach (DictionaryEntry j in C )
//                {
//                    Console.Write( j.Key  +" ;");
//                }
//			    Console.WriteLine();
				N ++ ;
			}
			return L ;
		}
		public static int LinerComplex(byte[] bytes)
		{
			string str = BytesToBits (bytes ) ;
			return LinerComplex (str ) ;
		}
	}
}
