using System;
using System.Collections.Generic;
using System.Linq;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree;
using System.Text;

namespace BioinfoLibrary
{
    /// <summary>
    /// SVM.NET测试
    /// </summary>
    public class SvmNetDetection
    {
        #region  老的SVM测试,混合编程实现
        /// <summary>
        /// SVM测试,错误率
        /// </summary>
        /// <param name="testFilePath">训练集路径，绝对路径</param>
        /// <param name="testDataArray">测试数据，也就是上一步的结果</param>
        /// <returns>错误率</returns>
        public static double SvmTest(string testFilePath, double[,] testDataArray, double v1, double v2)
        {
            KdTreeDataPro kd = new KdTreeDataPro();
            //21 -->testDataArray.GetLength (1) + 1
            double[,] oriData = new double[testDataArray.GetLength(0), testDataArray.GetLength(1) + 1];
            for (int i = 0; i < testDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < testDataArray.GetLength(1); j++)
                {
                    oriData[i, j] = testDataArray[i, j];
                }
                oriData[i, testDataArray.GetLength(1)] = 1;
            }
            MWNumericArray result = (MWNumericArray)kd.SvmTest(testFilePath, (MWNumericArray)oriData, (MWNumericArray)v1, (MWNumericArray)v2);
            double[,] temp = (double[,])result.ToArray();
            return temp[0, 0];
        }
        public static double SvmTestForcast(string testFilePath, double[,] testDataArray, double v1, double v2)
        {
            KdTreeDataPro kd = new KdTreeDataPro();
            MWNumericArray result = (MWNumericArray)kd.SvmTest(testFilePath, (MWNumericArray)testDataArray, (MWNumericArray)v1, (MWNumericArray)v2);
            double[,] temp = (double[,])result.ToArray();
            return temp[0, 0];
        }      
        public static double SvmTest(string testFilePath, double[][] testDataArray, double v1, double v2)
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
            return SvmTest(testFilePath, res, v1, v2);
        }
        public static double SvmTest(string testFilePath, double[][] testDataArray)
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
            return SvmTest(testFilePath, res, 10, 4);
        }

        public static double SvmTest(string testFilePath, string text, string waveName)
        {
            //double[][] res = FeatureExtraction.GetAllSeqCharacter(text, waveName);
            //return SvmTest(testFilePath, res, 10, 4);
            return 0 ; 
        }
        #endregion
    }
}
