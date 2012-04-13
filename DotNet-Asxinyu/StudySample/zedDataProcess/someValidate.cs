using System;
using System .Collections ;

namespace zedDataProcess
{
	/// <summary>
	/// 一些验证程序
	/// </summary>
	public class someValidate
	{
		/// <summary>
		/// 将号码转化为数字
		/// </summary>
		public static int ConvetToNum(byte[] arr)
		{
			if (arr [0] !=0)
			{
				return Convert .ToInt32 (arr [0].ToString ()+arr[1].ToString ()+arr[2].ToString ()) ;
			}
			else 
			{
				if (arr[1] !=0)
				{
					return Convert .ToInt32 (arr[1].ToString ()+arr[2].ToString ()) ;
				}
				else 
				{
					return Convert .ToInt32 (arr [2].ToString ());
				}
			}
		}
		/// <summary>
		/// 将上期乘3.14取前3/2/1位，在下k次出现的个数 k>=1
		/// </summary>
		/// <returns>长为n的数组，其值代表当期处理后第k期出现的个数</returns>
		public static int[] LastNumMult314(byte[] arr , int k)
		{
			int n = (int ) arr.Length / 3 ;
			int[] recurNum = new int[n ] ; //出现的次数
			for (int i=0;i <n -k;i ++ )
			{
				byte[] tempArr ={arr[3*i ],arr [3*i +1],arr [3*i +2]} ;
				byte[] nextArr ={arr[3*(i +k)],arr[3*(i +k )+1],arr [3*(i +k )+2]} ;
				double temp = 3.14 *(double ) ConvetToNum (tempArr )  ;
				string[] str1 = (temp .ToString ()).Split ('.') ;
				string str ="" ;
				foreach (string s in str1 )
				{
					str += s ;
				}				
				if (str.Length >= 3)
				{
					str = str .Substring (0,3) ;
				}			
				byte[] newArr = new byte[str .Length ] ;
				for ( int j = 0 ; j < str .Length ; j ++ ) 
				{
					newArr [j ] = Convert .ToByte (str [j ].ToString ()) ;				
				}
				recurNum [i ] = DataProcess .ContainsArr (newArr ,nextArr ) ;
//				string strTemp="";
//				foreach (byte k in nextArr )
//					strTemp += k .ToString () ;
//				string ss = "" ;
//				foreach (byte m in newArr )
//					ss += m .ToString () ;
//				Console .WriteLine ("算出码：{0} ,下期号码: {1} ",ss ,strTemp ); 
			}	
			return recurNum ;
		}
		/// <summary>
		/// 将上期除以32，取小数点前2位。在下k次出现的个数 k>=1
		/// </summary>
		/// <returns>长为n的数组，其值代表当期处理后第k期出现的个数</returns>
		public static int[] LastNumDiv32(byte[] arr,int k)
		{
			int n = (int ) arr.Length / 3 ;
			int[] recurNum = new int[n ] ; //出现的次数
			for (int i=0;i <n -k;i ++ )
			{
				byte[] tempArr ={arr[3*i ],arr [3*i +1],arr [3*i +2]} ;
				byte[] nextArr ={arr[3*(i +k)],arr[3*(i +k )+1],arr [3*(i +k )+2]} ;
				double temp = (double ) ConvetToNum (tempArr )/32.0 ;
				string[] str1 = (temp .ToString ()).Split ('.') ;
				string str = str1 [0];
				if (str.Length >=2 )
				{
					str = str .Substring (0,2) ;
				}
				byte[] newArr = new byte[str .Length ] ;
				for ( int j = 0 ; j < str .Length ; j ++ ) 
				{
					newArr [j ] = Convert .ToByte (str [j ].ToString ()) ;				
				}
				recurNum [i ] = DataProcess .ContainsArr (newArr ,nextArr ) ;
//				string strTemp="";
//				foreach (byte k in nextArr )
//					strTemp += k .ToString () ;
//				string ss = "" ;
//				foreach (byte m in newArr )
//					ss += m .ToString () ;
//				Console .WriteLine ("算出码：{0} ,下期号码: {1} ",ss ,strTemp ); 
			}	
			return recurNum ;
		}
		#region 关系复杂 暂不考虑
		/// <summary>
		/// 本次各位的数字与下次出现数字的关系
		/// </summary>
		/// <param name="bitLocate">位置：2为个位，1为十位，0为百位</param>
		/// <returns>出现的数字的二维数组：行号表示数字，列号表示对应数字出现的次数 </returns>
		public static int[,] BitsRecur(int bitLocate , byte[] arr)
		{
			int[,] numCount = new int[10,10] ;
			int n = (int) arr.Length /3 ;
			for(int i=0 ; i<n-1 ; i ++)
			{
				byte temp = arr[3*i + bitLocate] ; //当前数字
				for(int j = 3*(i+1) ; j<= 3*(i+1)+2 ;j++) //下一期数字
				{
					numCount[temp,j] ++ ;					
				}
			}
			return numCount ;
		}
		/// <summary>
		/// 从小到大排序，并记录原序列的大小顺序
		/// </summary>
		/// <param name="arr">输入数组</param>
		/// <param name="seqArr">输出大小顺序</param>
		/// <returns>返回原顺序的大小记录</returns>
		public static int[] CompareAnalysis(int[] arr ,out int[] seqArr)
		{
			Hashtable compare = new Hashtable () ;
			int[] locate = new int[10 ] ;
			seqArr = new int[10 ] ; 
			for	(int i=0 ; i< arr.Length ; i++ )
			{
				compare .Add (i,arr [i ] ) ;
			}
			while (compare .Count > 0 ) 
			{
				int temp = -1 ;
				foreach(DictionaryEntry k in compare )
				{
					int t =Convert .ToInt32 ( k .Value ) ;
					if ( t >temp ) 
					{
						temp = t ;
						locate [compare .Count -1] =Convert .ToInt32 (k .Key );
					}
				}
				compare .Remove (locate [compare .Count -1]) ;//删除最大的
			}
			for (int j = 0 ; j <seqArr .Length ; j ++)
			{
				seqArr [j ] = arr [locate [j ]];
			}
			return locate ;
		}
//		public static void BitsRecurAnalysis(int bitLocate ,byte[] arr)
//		{
//			//对整体数据的分析
//			int[,] bits = BitsRecur(bitLocate , arr) ; 
//			// 先从小到大排序
//			int[] seqArr ;
//			for (int i=0 ; i < 10 ; i ++ )
//			{
//				int[] res = CompareAnalysis (bits [i ],out seqArr ) ;
//				
//			}			
//		}
		#endregion
	    
		/// <summary>
		/// 为数组添加期号，以作进一步的统计分析
		/// </summary>
		/// <param name="length">添加的数目即期数</param>
		/// <param name="startNo">起始号码</param>
		/// <returns>期号连续数组</returns>
		public static int[] NumAddNoSeq(int length , int startNo)
		{
			int[] arr = new int[length ] ;
			int locate = startNo ;
			for (int i=0 ;i <length ;i ++ )
			{
				arr [i ] = startNo ++ ;
			}
			return arr ;
		}
		/// <summary>
		/// 利用期号关系确定下次是否出现相同数字的情况
		/// </summary>
		/// <returns>出现次数的关系数组:0,表示不出现，1表示最后一位出现，2表示倒数第二位出现
		/// ，3，表示最后两位出现</returns>
		public static int[] NoExclude(byte[] arr , int startNo)
		{
			//先求对应的期号
			int n = (int )arr.Length /3 ;
			int[] recurCount = new int[n ] ;
			int[] noSeq = NumAddNoSeq (n ,startNo ) ;
			for (int i = 0 ;i <n ; i ++ )
			{
				byte[] tempArr ={arr[3*i ],arr [3*i +1],arr [3*i +2]} ;
				string str = noSeq [i ] .ToString () ;
				byte temp1 = Convert .ToByte (str [str .Length -1].ToString ()) ; //个位
				byte temp2 = Convert .ToByte (str [str .Length -2].ToString ()) ; //十位
				bool btemp1 = DataProcess .Contains (temp1 ,tempArr ) ;
				bool btemp2 = DataProcess .Contains (temp2 ,tempArr ) ;
				if (btemp1 )
				{
					if (btemp2 )
					{
						recurCount [ i ] =3 ; //个位、十位同时出现
					}
					else 
						recurCount [i ] = 1 ; //只出现个位
				}
				else 
				{
					if (btemp2 )
					{
						recurCount [i ] =2 ; //只出现十位
					}
					else
						recurCount [i ] = 0 ;
				}
			}
			return recurCount ; 
		}
		
	}
}