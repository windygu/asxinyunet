using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree;

namespace BioinfoLibrary
{
    public class WaveLet : BaseBioinfo
    {
        #region 小波变换获取蛋白质序列特征-Wavelet waveName
        /// <summary>
        /// 小波变换算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:小波变换名称</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)       
        {
            KdTreeDataPro cwf = new KdTreeDataPro();
            MWNumericArray nmarray = (MWNumericArray)cwf.CalcuteWave((MWArray)strSequence, (string)paramsVlue[0]);
            double[,] resultT = (double[,])nmarray.ToArray();
            double[] result = new double[20];
            for (int i = 0; i < 20; i++)
            {
                result[i] = resultT[0, i];
            }
            return result;
        }

        /// <summary>
        /// 小波变换算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence)
        {
            return GetOneSequenceFeature(strSequence, new object[] { "bior2.4" });                        
        }
        #endregion
    }
}
