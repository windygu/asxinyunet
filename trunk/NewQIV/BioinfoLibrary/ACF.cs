using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    /// <summary>
    /// 自相关特征提取算法
    /// </summary>
    public class ACF
    {
        #region 自相关特征提取算法-ACF
        /// <summary>
        /// 自相关特征提取算法获取一条序列的特征
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:自相关参数M值</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)
        {
            int M = (int)paramsVlue[0];
            double[] SeqenceValue = SequenceProcess.GetValuesOfSequence(strSequence);
            double[] res = new double[M];
            double temp;
            for (int i = 1; i <= M; i++)
            {
                temp = 0;
                for (int j = 1; j <= SeqenceValue.Length - i; j++)
                {
                    temp += SeqenceValue[j - 1] * SeqenceValue[j + i - 1];
                }
                res[i - 1] = temp / (SeqenceValue.Length - i);
            }
            return res;
        }
        #endregion
    }
}