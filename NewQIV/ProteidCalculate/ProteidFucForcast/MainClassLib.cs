/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-28
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO ;
using System.Collections ;
using System.Collections.Generic ;
using ProteidCalculate ;
using DotNet.Tools ;

namespace ProteidFucForcast
{
	/// <summary>
	/// Description of MainClassLib.
	/// </summary>
	public class MainClassLib
	{
		
		/*要点：读取功能分类时，一定要将前面的注释信息去掉
		 * 
		 * */
		
		#region	氨基酸组成特征提取方法
		/// <summary>
		/// 氨基酸组成特征提取方法
		/// </summary>
		/// <param name="seqData">输入序列</param>
		public static double[] AAC(string seqData)
		{
			 //检测是否包含其他非规定字符：B、J、O、U、X,Z,并剔除
            string strSeqence = seqData.ToUpper().Replace("B", "").Replace("J", "")
            	.Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace ("*","");
            //键值转换数组,不包含的字符也赋值，但不影响最终结果
            int[] cValue = new int[26] ;
            for (int i = 0; i < strSeqence.Length; i++)
            {
                cValue[Convert.ToInt32(strSeqence[i]) - 65] ++ ;
            }
            double[] res = new double[20] ;
            double temp ;
            int count = 0 ;
            for (int i = 0; i <cValue.Length ; i ++)
            {
            	bool flag = ((i==1)||(i ==9)||(i ==14)||(i ==20)||(i ==23)||(i ==25));
            	if (!flag )
            	{
            		temp = ((double )cValue [i ])/((double)seqData.Length ) ;
            		res [count ++] = temp ;
            	}
            }
            return res;
		}
		
		/// <summary>
		/// 提取所有序列的特征,采用氨基酸组成特征提取方法
		/// </summary>
		/// <param name="seqData"></param>
		/// <returns></returns>
		public static double[][] GetAllAAC(string seqData)
		{
			string[] str = ProteidCharacter.SplitStringsByEnter(seqData ) ;
			double[][] res = new double[str.Length ][] ;
			for (int i = 0 ; i <str.Length ; i ++)
			{
				res [i ] = AAC (str[i] ) ; 
			}
			return res ;
		}
		#endregion
		
		#region	对类别文本进行初步预处理,以方便后续的测试
		public static void PrepareTypeData(string filePath )
		{
			StreamReader sr = new StreamReader (filePath) ;
			FileStream fsFile = new FileStream(filePath.Substring(0,filePath.Length -4)+"_Pro.txt" , FileMode.Create ) ;
			StreamWriter sw = new StreamWriter (fsFile) ;
			string line = null ;
			string[]  str ;
			int result ;
			try 
			{
				while ( (line = sr.ReadLine())!=null )
				{
					str = line.Split (' ') ;//以空格为风格符号
					//然后选取前2个字符进行转换
					if (str.Length >2)
					{
						if (Int32.TryParse(str [0],out result)) //能够转换为数字,说明是数据
						{
							sw.WriteLine (str[1].Trim ()) ;//写入数据
						}
					}
				}
			}
			finally 
			{
				sr.Close () ;
				sw .Close () ;
				fsFile.Close () ;
			}
		}
		
		public static void PrepareAllType(string folder)
		{
			//将所有类别进行处理,只需要处理一次即可
			for (int i =1 ; i <19; i ++)
			{
				PrepareTypeData(folder +@"\"+i.ToString ()+".txt");
			}
		}
		#endregion
		
		#region 读取预处理后的数据
		public static ArrayList ReadFunClassData(string filePath)
		{
			ArrayList resArr = new ArrayList () ;			
			StreamReader sr = new StreamReader (filePath) ;		
			string line = null ;
			try 
			{
				while ( (line = sr.ReadLine())!=null )
				{
					resArr.Add (line.Trim ()) ;
				}
				return resArr ;
			}
			finally 
			{
				sr.Close () ;
			}
		}
		#endregion
		
		#region 对原始序列数据进行处理,添加进入HashTable
		public static Hashtable GetAllSeqData(string text)
		{
			//TODO:不仅仅是分割出序列,还要找到对应的标记符
			Hashtable resTab = new Hashtable () ;			
			//分割方法：\r\n(由<替换)则删掉           
			text = text.Replace ("\r\n","<").Replace ("\n","<") ;
            int curLocate = 0 ;
            int curLocate2 = 0 ;
            bool flag = false ;   //是否开始标记">"
            bool seqFlag = false ;//是否已经取得序列的标记符
            string temp = "" ;
            string seqStr = "" ;
            for (int i = 0 ; i <text.Length ; i ++)
            {
            	if (text [i ]=='>')
            	{
            		//开始记下位置
            		
            		if (!flag)
            		{
            			//和前一个<的位置之间的为上一个的字符串
            			if (seqFlag ) 
            			{
            				seqStr = text.Substring (curLocate2 +1,i -curLocate2-1).Replace ("<","").Replace ("*","");
            				resTab .Add (temp ,seqStr ) ;
            				seqFlag = false ;
            			}
            			flag = true ;//标记一个序列的开始            		
            		}            	
            		curLocate = i ;
            	}
            	if (text [i ]=='<')
            	{
            		//遇到换行符,找到第一个换行符即可
            		if (flag)
            		{
            			//处理
            			temp = text.Substring (curLocate+1,i -curLocate ) ;//> <符号不取
            			temp = temp.Split(' ')[0].Trim () ;//分割后的第一个            			
            			flag = false ;  //停止
            			seqFlag = true ;
            			curLocate2 = i ;//序列开始的前一个
            		}            		
            	}
            }            
            //最后再添加一次
            seqStr = text .Substring (curLocate2 +1).Replace ("<","").Replace ("*","");
            resTab.Add (temp,seqStr ) ;
            
            return resTab ;
		}	
		
		public static Hashtable GetAllSeqDataByFile(string filePath)
		{
			Hashtable ht = null ;
			using (StreamReader sw = new StreamReader (filePath ))
			{
				string str = sw.ReadToEnd ();
				
				ht = GetAllSeqData (str);
			}
			return ht ;
		}
		#endregion
		
		#region 测试某一个功能函数
		/// <summary>
		/// 测试某一个功能函数
		/// </summary>
		/// <param name="typeNo">功能类别编号</param>
		/// <param name="dataFolder">功能类别数据目录</param>
		/// <param name="htData">测试数据表</param> 
		public static double  TestOneFunction(int typeNo,string dataFolder,Hashtable htData)
		{
			//先根据测试类型和测试数据来构建测试集和训练集
			ArrayList keyList = ReadFunClassData (dataFolder +@"\"+typeNo.ToString ()+"_Pro.txt");
			ArrayList TestData = new ArrayList () ;//测试集数据
			ArrayList TrainData = new ArrayList () ;//训练集数据
			//依次对htData每个元素，若属于keyList,则添加至测试集					
			foreach(DictionaryEntry de in htData )
			{
				//先计算特征值
				double[] temp;
				double[] chaValue = new double[21 ] ;
				temp = AAC (de.Value.ToString ()) ;
				Array.Copy(temp,0,chaValue,0,20) ;
				if (keyList.Contains(de.Key))
				{
					chaValue [20 ] = 1  ;
					TestData .Add (chaValue ) ;
					TrainData .Add (chaValue ) ;
				}
				else 
				{
					chaValue [20 ] = -1 ;
					TrainData .Add (chaValue ) ;
				}
			}
			//对结果进行转换,并存入到Excel中
			object[] testDataArr = TestData.ToArray () ;
			object[] trainDataArr = TrainData.ToArray () ;		
			double[][] test = new double[testDataArr.Length ][] ;
			double[][] train = new double[trainDataArr.Length ][] ;
			int count = 0 ;
			foreach(object e in testDataArr )
				test [count ++] = (double[])e ;
			count = 0 ;
			foreach(object e in trainDataArr )
				train [count ++ ] = (double[])e ;
			
			//ConverterAlgorithm.ConvertToExcel<double>(test ,dataFolder +@"\test.xls","测试集");
			ConverterAlgorithm.ConvertToExcel<double>(train,dataFolder +@"\train.xls","训练集");
			double result =100- ProteidCharacter.SvmTestForcast(dataFolder +@"\train.xls",test) ;
			return result ;
		}
		#endregion
		
		#region 数据预测
		public static double PredictFunction(int typeNo,string dataFolder,
		                                     Hashtable htData,string testSeqence)
		{
			double[] testValue = new double[21] ;
			double[] testTemp = AAC (testSeqence ) ;
			Array.Copy(testTemp,0,testValue,0,20) ;
			testValue [20] = 1 ;
			//先根据测试类型和测试数据来构建测试集和训练集
			ArrayList keyList = ReadFunClassData (dataFolder +@"\"+typeNo.ToString ()+"_Pro.txt");
			ArrayList TestData = new ArrayList () ;//测试集数据
			ArrayList TrainData = new ArrayList () ;//训练集数据
			//依次对htData每个元素，若属于keyList,则添加至测试集					
			foreach(DictionaryEntry de in htData )
			{
				//先计算特征值
				double[] temp;
				double[] chaValue = new double[21 ] ;
				temp = AAC (de.Value.ToString ()) ;
				Array.Copy(temp,0,chaValue,0,20) ;
				if (keyList.Contains(de.Key))
				{
					chaValue [20 ] = 1  ;
					TestData .Add (chaValue ) ;
					TrainData .Add (chaValue ) ;
				}
				else 
				{
					chaValue [20 ] = -1 ;
					TrainData .Add (chaValue ) ;
				}
			}
			//对结果进行转换,并存入到Excel中
			object[] testDataArr = TestData.ToArray () ;
			object[] trainDataArr = TrainData.ToArray () ;		
			double[][] test = new double[testDataArr.Length ][] ;
			double[][] train = new double[trainDataArr.Length +1 ][] ;
			int count = 0 ;
			foreach(object e in testDataArr )
				test [count ++] = (double[])e ;
			count = 0 ;
			foreach(object e in trainDataArr )
				train [count ++ ] = (double[])e ;
			train [train.Length -1] = testValue ;
			//ConverterAlgorithm.ConvertToExcel<double>(test ,dataFolder +@"\test.xls","测试集");
			ConverterAlgorithm.ConvertToExcel<double>(train,dataFolder +@"\train.xls","训练集");
			double result =100- ProteidCharacter.SvmTestForcast(dataFolder +@"\train.xls",test) ;
			return result ;
		}
		#endregion
		
		#region 对测试数据源进行处理,由于计算速度,只选择其中一部分
		public static Hashtable SelectTestData(int needCount,string folder,string filePath)
		{
			Hashtable allData = GetAllSeqDataByFile (filePath ) ;
			Hashtable resHt = new Hashtable() ;//返回数据
			//遍历allData,	如果相应的类别数目已达到,则不添加
//			int[] count = new int[18] ;
			for (int i = 1 ; i <= 18 ; i ++)
			{		
				int count = 0 ;
				ArrayList keyList = ReadFunClassData (folder+@"\"+ i.ToString()+"_Pro.txt");
				foreach(object e in keyList )
				{
					if (count <needCount )
					{
						if (allData.ContainsKey (e )&&(!resHt .ContainsKey (e )))
						{
							resHt.Add (e,allData[e ]) ;//添加
							count ++ ;
						}
					}
				}
			}
			return resHt ;
		}
		#endregion
	}
}