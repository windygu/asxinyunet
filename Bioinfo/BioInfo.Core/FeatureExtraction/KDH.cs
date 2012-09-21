using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioInfo.Core
{
    public class KDH : BaseBioinfo
    {
        #region 
        /// <summary>
        /// Kyte & Doolittle hydrophobicity scales
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:自相关参数M值</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)
        {            
           return GetValuesOfSequence(strSequence);            
        }
        #endregion

        #region 根据序列得到对应的数字序列
        /// <summary>
        /// 根据序列得到对应的数字序列
        /// </summary>
        /// <param name="strSeqence">序列</param>
        /// <returns>对应的数字序列</returns>
        public static double[] GetValuesOfSequence(string strSeqence)
        {            
            double[] changArray = new double[] { 1.8, 2.1, 2.5, -3.5, -3.5, 2.8, -0.4, -3.2, 4.5, 10.1, -3.9, 3.8, 1.9,
                -3.5, 15, -1.6, -3.5, -4.5, -0.8, -0.7, 21, 4.2, -0.9, 24, -1.3, 26.1 };           
            return strSeqence.Select(n => changArray[Convert.ToInt32(n) - 65]).ToArray();          
        }
        #endregion
    }
}
