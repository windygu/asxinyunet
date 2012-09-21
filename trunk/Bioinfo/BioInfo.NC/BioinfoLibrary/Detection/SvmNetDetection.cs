using System;
using System.Collections.Generic;
using System.Linq;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree;
using System.Text;
using SVM;

namespace BioinfoLibrary
{
    /// <summary>
    /// SVM.NET测试
    /// </summary>
    public class SvmNetDetection
    {
        #region  老的SVM测试,混合编程实现-为了保持兼容性,暂时保留
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

        #region SVM.NET类库的使用及整理
        /// <summary>
        /// Svm.NET计算序列预测结果，直接根据模型来计算
        /// </summary>
        /// <param name="C">C值</param>
        /// <param name="Gamma">G值</param>
        /// <param name="Probability">概率值</param>
        /// <returns>预测值</returns>
        public static double GetSvmPredictResult(Model trainModel, string testDataFileName, out double[] Probability)
        {
            Problem test = Problem.Read(testDataFileName);
            return Prediction.Predict(test, trainModel, out Probability);
        }
        //直接输入数据格式
        public static double GetSvmPredictResult(Model trainModel, double[][] testData, out double[] Probability)
        {
            Problem test = Problem.ReadForTestData(testData);
            return Prediction.Predict(test, trainModel, out Probability);
        }

        /// <summary>
        /// 根据训练集的文件路径来计算预测结果
        /// </summary>
        /// <param name="trainDataFileName"></param>
        /// <param name="testDataFileName"></param>
        /// <param name="C"></param>
        /// <param name="Gamma"></param>
        /// <param name="Probability"></param>
        /// <returns></returns>
        public static double GetSvmPredictResult(string trainDataFileName, string testDataFileName, double C, double Gamma, out double[] Probability)
        {
            Model trainModel = GetTrainingModel(trainDataFileName, C, Gamma);
            Problem test = Problem.Read(testDataFileName);
            return Prediction.Predict(test, trainModel, out Probability);
        }
        /// <summary>
        /// 根据训练集，得到训练的模型，固定起来，便于加快计算速度
        /// </summary>
        /// <returns></returns>
        public static Model GetTrainingModel(string trainDataFileName, double C, double Gamma)
        {
            Problem train = Problem.Read(trainDataFileName);
            Parameter parameters = new Parameter();
            parameters.C = C;
            parameters.Gamma = Gamma;
            parameters.Probability = true;//设置输出概率值
            return Training.Train(train, parameters);
        }
        /// <summary>
        /// 默认去掉0
        /// </summary>
        /// <param name="trainDataFileName"></param>
        /// <param name="testDataFileName"></param>
        /// <param name="C"></param>
        /// <param name="Gamma"></param>
        /// <param name="Probability"></param>
        /// <returns></returns>
        public static double TestMode(string trainDataFileName, string testDataFileName, double C, double Gamma, out double[] Probability)
        {
            Problem test = Problem.ReadForSpecial(testDataFileName);
            Problem train = Problem.ReadForSpecial(trainDataFileName);
            Parameter parameters = new Parameter();
            parameters.C = C;
            parameters.Gamma = Gamma;
            parameters.Probability = true;//设置输出概率值	
            Model trainModel = Training.Train(train, parameters);
            return Prediction.Predict(test, trainModel, out Probability);
        }
        #endregion
    }
}
