using System;
using System .Collections ;

namespace zedDataProcess
{
	/// <summary>
	/// һЩ��֤����
	/// </summary>
	public class someValidate
	{
		/// <summary>
		/// ������ת��Ϊ����
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
		/// �����ڳ�3.14ȡǰ3/2/1λ������k�γ��ֵĸ��� k>=1
		/// </summary>
		/// <returns>��Ϊn�����飬��ֵ�����ڴ�����k�ڳ��ֵĸ���</returns>
		public static int[] LastNumMult314(byte[] arr , int k)
		{
			int n = (int ) arr.Length / 3 ;
			int[] recurNum = new int[n ] ; //���ֵĴ���
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
//				Console .WriteLine ("����룺{0} ,���ں���: {1} ",ss ,strTemp ); 
			}	
			return recurNum ;
		}
		/// <summary>
		/// �����ڳ���32��ȡС����ǰ2λ������k�γ��ֵĸ��� k>=1
		/// </summary>
		/// <returns>��Ϊn�����飬��ֵ�����ڴ�����k�ڳ��ֵĸ���</returns>
		public static int[] LastNumDiv32(byte[] arr,int k)
		{
			int n = (int ) arr.Length / 3 ;
			int[] recurNum = new int[n ] ; //���ֵĴ���
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
//				Console .WriteLine ("����룺{0} ,���ں���: {1} ",ss ,strTemp ); 
			}	
			return recurNum ;
		}
		#region ��ϵ���� �ݲ�����
		/// <summary>
		/// ���θ�λ���������´γ������ֵĹ�ϵ
		/// </summary>
		/// <param name="bitLocate">λ�ã�2Ϊ��λ��1Ϊʮλ��0Ϊ��λ</param>
		/// <returns>���ֵ����ֵĶ�ά���飺�кű�ʾ���֣��кű�ʾ��Ӧ���ֳ��ֵĴ��� </returns>
		public static int[,] BitsRecur(int bitLocate , byte[] arr)
		{
			int[,] numCount = new int[10,10] ;
			int n = (int) arr.Length /3 ;
			for(int i=0 ; i<n-1 ; i ++)
			{
				byte temp = arr[3*i + bitLocate] ; //��ǰ����
				for(int j = 3*(i+1) ; j<= 3*(i+1)+2 ;j++) //��һ������
				{
					numCount[temp,j] ++ ;					
				}
			}
			return numCount ;
		}
		/// <summary>
		/// ��С�������򣬲���¼ԭ���еĴ�С˳��
		/// </summary>
		/// <param name="arr">��������</param>
		/// <param name="seqArr">�����С˳��</param>
		/// <returns>����ԭ˳��Ĵ�С��¼</returns>
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
				compare .Remove (locate [compare .Count -1]) ;//ɾ������
			}
			for (int j = 0 ; j <seqArr .Length ; j ++)
			{
				seqArr [j ] = arr [locate [j ]];
			}
			return locate ;
		}
//		public static void BitsRecurAnalysis(int bitLocate ,byte[] arr)
//		{
//			//���������ݵķ���
//			int[,] bits = BitsRecur(bitLocate , arr) ; 
//			// �ȴ�С��������
//			int[] seqArr ;
//			for (int i=0 ; i < 10 ; i ++ )
//			{
//				int[] res = CompareAnalysis (bits [i ],out seqArr ) ;
//				
//			}			
//		}
		#endregion
	    
		/// <summary>
		/// Ϊ��������ںţ�������һ����ͳ�Ʒ���
		/// </summary>
		/// <param name="length">��ӵ���Ŀ������</param>
		/// <param name="startNo">��ʼ����</param>
		/// <returns>�ں���������</returns>
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
		/// �����ںŹ�ϵȷ���´��Ƿ������ͬ���ֵ����
		/// </summary>
		/// <returns>���ִ����Ĺ�ϵ����:0,��ʾ�����֣�1��ʾ���һλ���֣�2��ʾ�����ڶ�λ����
		/// ��3����ʾ�����λ����</returns>
		public static int[] NoExclude(byte[] arr , int startNo)
		{
			//�����Ӧ���ں�
			int n = (int )arr.Length /3 ;
			int[] recurCount = new int[n ] ;
			int[] noSeq = NumAddNoSeq (n ,startNo ) ;
			for (int i = 0 ;i <n ; i ++ )
			{
				byte[] tempArr ={arr[3*i ],arr [3*i +1],arr [3*i +2]} ;
				string str = noSeq [i ] .ToString () ;
				byte temp1 = Convert .ToByte (str [str .Length -1].ToString ()) ; //��λ
				byte temp2 = Convert .ToByte (str [str .Length -2].ToString ()) ; //ʮλ
				bool btemp1 = DataProcess .Contains (temp1 ,tempArr ) ;
				bool btemp2 = DataProcess .Contains (temp2 ,tempArr ) ;
				if (btemp1 )
				{
					if (btemp2 )
					{
						recurCount [ i ] =3 ; //��λ��ʮλͬʱ����
					}
					else 
						recurCount [i ] = 1 ; //ֻ���ָ�λ
				}
				else 
				{
					if (btemp2 )
					{
						recurCount [i ] =2 ; //ֻ����ʮλ
					}
					else
						recurCount [i ] = 0 ;
				}
			}
			return recurCount ; 
		}
		
	}
}