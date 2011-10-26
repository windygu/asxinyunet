using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    /// <summary>
    /// 改进位置权重
    /// </summary>
    public class ImproveWacc : BaseBioinfo
    {
        #region 改进位置权重特征提取算法-ImproveWacc
        /// <summary>
        /// 改进位置权重特征提取算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:长度L</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)
        {
            int L = (int)paramsVlue[0];
            double[] res = new double[BioinfoHelper.NormalSeqence.Length];
            for (int i = 0; i < res.Length; i++)
            {
                double temp = 0;
                for (int j = -L; j <= L; j++)
                {
                    if (BioinfoHelper.NormalSeqence[i] == strSequence[j + L])
                    {
                        temp += (j + Math.Abs(j) / (double)L);
                    }
                }
                res[i] = temp / (double)(L * (L + 1));
            }
            return res;
        }
        #endregion
    }
}