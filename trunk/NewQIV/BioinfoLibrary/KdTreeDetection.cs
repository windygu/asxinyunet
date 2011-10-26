using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree;

namespace BioinfoLibrary
{
    /// <summary>
    /// KdTree检测
    /// </summary>
    public class KdTreeDetection
    {
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
            MWArray result = kd.kdTree(testFilePath, (MWNumericArray)testDataArray);
            double[,] temp = (double[,])result.ToArray();
            return new double[] { temp[0, 0], temp[0, 1] };
        }

        /// <summary>
        /// KdTree类别测试
        /// </summary>
        /// <param name="testFilePath">训练集路径，绝对路径</param>
        /// <param name="testDataArray">测试数据，也就是上一步的结果</param>
        /// <returns>分类结果,第一个为第一类，第二个为第二类</returns>
        public static double[] KdTreeTest(string testFilePath, double[][] testDataArray)
        {
            int row = testDataArray.Length;
            int col = testDataArray[0].Length;
            double[,] res = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    res[i, j] = testDataArray[i][j];
                }
            }
            return KdTreeTest(testFilePath, res);
        }
        /// <summary>
        /// KdTree类别测试,指定小波名称
        /// </summary>
        /// <param name="testFilePath">训练集路径，绝对路径</param>
        /// <param name="text">序列</param>
        /// <param name="waveName">小波名称</param>
        /// <returns>分类结果,第一个为第一类，第二个为第二类</returns>
        public static double[] KdTreeTest(string testFilePath, string text, string waveName)
        {
            //double[][] res = FeatureExtraction.GetAllSeqCharacter(text, waveName);
            //return KdTreeTest(testFilePath, res);
            return null; 
        }
        #endregion
    }
}