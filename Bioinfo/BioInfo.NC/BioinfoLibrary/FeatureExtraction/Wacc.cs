using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    public class Wacc : BaseBioinfo
    {
        #region 位置权重特征提取算法-Wacc
        /// <summary>
        /// 位置权重特征提取算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:小波变换名称</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)
        {
            double[] res = new double[BioinfoHelper.NormalSeqence.Length];
            double temp;
            for (int i = 0; i < res.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < strSequence.Length; j++)
                {
                    temp += XIPCalculate(strSequence, i, j) * (j + 1);
                }
                res[i] = temp / (double )strSequence.Length;
            }
            return res;
        }

        /// <summary>
        /// 位置权重特征提取算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence)
        {
            return GetOneSequenceFeature(strSequence,null );
        }
        #endregion

        #region 辅助方法
        private static int XIPCalculate(string str, int i, int p)
        {            
            return str[p] == BioinfoHelper.NormalSeqence[i] ? 1 : 0;
        }
        #endregion
    }
}
