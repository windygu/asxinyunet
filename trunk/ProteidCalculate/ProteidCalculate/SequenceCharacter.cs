/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-1-11
 * Time: 22:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree;
using System.Data;

namespace ProteidCalculate
{
	/// <summary>
	/// 获取蛋白质序列的特征
	/// </summary>
	public partial class ProteidCharacter
    {		
		#region 获取一条蛋白质序列特征：public static double[] GetSequenceCharacter
		/// <summary>
		/// 获取一条蛋白质序列的特征
		/// </summary>
		/// <param name="seqData">蛋白质序列数据</param>
		/// <param name="waveName" >小波变换名称</param>
		/// <returns>特征向量</returns>
		public static double[] GetSequenceCharacter(string seqData,string waveName )
		{
			//先转换为大写字母
			//seqData = seqData.ToUpper();
			
			KdTreeDataPro  cwf = new KdTreeDataPro ();
			MWNumericArray nmarray = (MWNumericArray)cwf.CalcuteWave((MWArray)seqData, waveName);
			double[,] resultT = (double[,])nmarray.ToArray();
			double[] result =new double[20] ;
			for (int i = 0; i < 20 ; i++)
			{
				result [i ] = resultT [0,i ] ;
			}
			return result  ;
		}
		#endregion
    
		#region	获取多条蛋白质序列的特征:public static double[][] GetAllSeqCharacter
		/// <summary>
        /// 获取多条蛋白质序列的特征
        /// </summary>
        /// <param name="text">多条蛋白质的原始序列</param>
        /// <param name="waveName" >小波变换名称</param>
        /// <returns>特征向量数组,每一行为一条结果</returns>
        public static double[][] GetAllSeqCharacter(string text, string waveName)
        {
            string[] str = SplitStringsByEnter(text); //分块
            return GetSeqCharactersBySeqs(str, waveName);//计算结果
        }
        #endregion
        
        #region 获取多条蛋白质序列的特征 采用默认的小波变换
        /// <summary>
        /// 采用默认的小波变换 bior2.4进行运算
        /// </summary>
        /// <param name="text">>多条蛋白质的原始序列</param>
        /// <returns>特征向量数组,每一行为一条结果</returns>
        public static double[][] GetAllSeqCharacter(string text)
        {
        	return  GetAllSeqCharacter(text,"bior2.4") ;
        }
        #endregion
        
        #region 将字符串进行分割：按照换行确定
        /// <summary>
        /// 对文本块进行分割，按照换行符和>识别
        /// </summary>
        /// <param name="text">文本块</param>
        /// <returns>标志的字符串数组</returns>
        public static string[] SplitStringsByEnter(string text)
        {
            //分割方法：从头到尾检索，遇到>检索遇到\r\n(由<替换)则删掉           
            text = text.Replace ("\r\n","<").Replace ("\n","<") ;
            // 查找> < 分别出现的位置
            int[] firstLocation = IndexOfcharPosition(text, '>');//>出现的位置
            int[] secLocation = IndexOfcharPosition(text, '<');//换行符出现的位置
            for (int i = firstLocation.Length -1 ; i >=0 ; i-- )
            {
                //找出当前>符号后第一个换行符的位置，删除掉
                for (int j = firstLocation [i ] ; j < text.Length ; j++)
                {
                    if (text[j] == '<')
                    {
                        text = text.Remove(firstLocation[i]+1, j - firstLocation[i] );
                        break;
                    }               
                }
            }
            string[] subStr = text.Split('>');//字符串分割
            int count = 0;
            for (int i = 0; i < subStr.Length ; i++)
            {
                if (subStr [i ]!="")
                {
                    count++;//计算合法字符串个数
                }
            }
            string[] res = new string[count ] ;
            count = 0 ;
            for (int i = 0; i < subStr.Length ; i++)
            {
                if (subStr[i] != "")
                {
                    res[count++] = subStr[i].ToUpper ().Replace ("B","").Replace ("J","").Replace ("O","").Replace ("U","").Replace ("X","").Replace ("Z","").ToString ().Replace (" ","").Replace ("<","") ;                    
                }
            }
            //剔除不是字母的元素
            int temp;
            for (int i = 0; i < res.Length ; i++)
            {
                for (int j = 0; j < res [i ].Length ; j++)
                {
                    temp = Convert.ToInt32(res[i][j]);
                    if (temp <65 || temp >90 )
                    {
                        res[i] = res[i].Remove(j, 1) ; //删除
                    }
                }
            }
            return res;
        }
        #endregion
        
        #region  KdTree类别测试
        /// <summary>
        /// KdTree类别测试
        /// </summary>
        /// <param name="testFilePath">训练集路径，绝对路径</param>
        /// <param name="testDataArray">测试数据，也就是上一步的结果</param>
        /// <returns>分类结果,第一个为第一类，第二个为第二类</returns>
        public static double[] KdTreeTest(string testFilePath, double[,] testDataArray)
        {
            KdTreeDataPro kd = new KdTreeDataPro();
            //MWNumericArray result = (MWNumericArray)kd.kdTree(testFilePath, (MWNumericArray)testDataArray);
            MWArray result = kd.kdTree( testFilePath, (MWNumericArray)testDataArray );
            double[,] temp = (double[,])result.ToArray() ;
            return new double[] {temp [0,0],temp [0,1]};
        }
        
        public static double[] KdTreeTest(string testFilePath, double[][] testDataArray)
        {
        	int row = testDataArray.Length ;
        	int col = testDataArray [0].Length ;
        	double[,] res = new double[row ,col ] ;
        	for (int i = 0 ; i <row ; i ++)
        	{
        		for (int j=0 ;j <col  ; j ++)
        		{
        			res [i,j ] = testDataArray [i ][j ] ;
        		}
        	}
        	return  KdTreeTest(testFilePath,res ) ;
        }
        
        public static double[] KdTreeTest(string testFilePath,string text,string waveName)
        {
        	double[][] res = GetAllSeqCharacter (text,waveName );
        	return KdTreeTest(testFilePath ,res ) ;
        }
           
        #endregion

        #region  SVM测试
        /// <summary>
        /// SVM测试,错误率
        /// </summary>
        /// <param name="testFilePath">训练集路径，绝对路径</param>
        /// <param name="testDataArray">测试数据，也就是上一步的结果</param>
        /// <returns>错误率</returns>
        public static double SvmTest(string testFilePath, double[,] testDataArray)
        {
            KdTreeDataPro kd = new KdTreeDataPro();
            double[,] oriData = new double [testDataArray.GetLength(0),21] ;
            for (int i = 0; i <testDataArray .GetLength (0) ; i++)
            {
                for (int j = 0; j < testDataArray.GetLength (1); j++)
                {
                    oriData[i, j] = testDataArray[i, j];
                }
                oriData[i, 20] = 1;
            }
            MWNumericArray result = (MWNumericArray)kd.SvmTest(testFilePath, (MWNumericArray )oriData);
            double[,] temp = (double[,])result.ToArray();
            return temp[0, 0];
        }
        public static double SvmTestForcast(string testFilePath, double[,] testDataArray)
        {
        	KdTreeDataPro kd = new KdTreeDataPro();
        	MWNumericArray result = (MWNumericArray)kd.SvmTest(testFilePath, (MWNumericArray )testDataArray);
        	double[,] temp = (double[,])result.ToArray();
        	return temp[0, 0];
        }
        public static double SvmTestForcast(string testFilePath, double[][] testDataArray)
        {
        	int row = testDataArray.Length ;
        	int col = testDataArray [0].Length ;
        	double[,] res = new double[row ,col ] ;
        	for (int i = 0 ; i <row ; i ++)
        	{
        		for (int j=0 ;j <col  ; j ++)
        		{
        			res [i,j ] = testDataArray [i ][j ] ;
        		}
        	}
        	return SvmTestForcast(testFilePath,res ) ;
        }
        public static double SvmTest(string testFilePath, double[][] testDataArray)
        {
        	int row = testDataArray.Length ;
        	int col = testDataArray [0].Length ;
        	double[,] res = new double[row ,col ] ;
        	for (int i = 0 ; i <row ; i ++)
        	{
        		for (int j=0 ;j <col  ; j ++)
        		{
        			res [i,j ] = testDataArray [i ][j ] ;
        		}
        	}
        	return SvmTest (testFilePath,res ) ;
        }
        public static double SvmTest(string testFilePath, string text,string waveName)
         {
        	double[][] res = GetAllSeqCharacter (text,waveName );
        	return SvmTest (testFilePath ,res ) ;
         }
        #endregion
	}
}