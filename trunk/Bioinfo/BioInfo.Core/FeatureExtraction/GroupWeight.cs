using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioInfo.Core
{
    /// <summary>
    /// 分组重量编码
    /// </summary>
    public class GroupWeight : BaseBioinfo
    {
        #region 分组重量编码特征提取算法-Wacc
        /// <summary>
        /// 分组重量编码特征提取
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">第一个参数为:分组参数长度</param>
        /// <returns>当前序列的特征值</returns>
        public override double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue)
        {
            int length = (int)paramsVlue[0];
            string[] restr = GetGroupCodeString(strSequence);
            double[] res = new double[3 * length];
            for (int i = 0; i < restr.Length; i++)
            {
                double[] t1 = GetGroupWeightCodeOfCharcter(restr[i], length);
                Array.Copy(t1, 0, res, i * length, t1.Length);
            }
            return res;
        }       
        #endregion

        #region 辅助方法-分组编码特征
        //特征分类 分别为C1 C2 C3 C4
        static int[] groupValue = {1,0,2,3,3,1,1,  //A-G
                                   4,1,0,4,1,1,2,  //H-N
                                   0,1,2,4,2,2,0,1,1,0,2,0};//O-Z
        static char firFlag = '1';
        static char secFlag = '0';

        /// <summary>
        /// 获取一条序列的分组特征编码,三条,注意输入前要剔除不合法字符
        /// </summary>
        /// <param name="seqData">输入序列</param>
        /// <returns>特征编码</returns>
        static string[] GetGroupCodeString(string seqData)
        {
            seqData = seqData.ToUpper().Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString(); ;
            string[] restr = new string[3];
            restr[0] = "";
            restr[1] = "";
            restr[2] = "";
            int temp;
            for (int i = 0; i < seqData.Length; i++)
            {
                temp = groupValue[Convert.ToInt32(seqData[i]) - 65];
                restr[0] += ((temp <= 2) ? firFlag : secFlag);
                restr[1] += (((temp % 2) == 1) ? firFlag : secFlag);
                restr[2] += (((temp == 1) || (temp == 4)) ? firFlag : secFlag);
            }
            return restr;
        }
        //获取一条序列的正规重量
        static double GetWeigthOfString(string seqData)
        {
            int sum = 0;
            for (int i = 0; i < seqData.Length; i++)
            {
                if (seqData[i] == firFlag)
                {
                    sum++;
                }
            }
            return (double)((double)sum / seqData.Length);
        }

        /// <summary>
        /// 获取一条特征序列的分组重量编码
        /// </summary>
        /// <param name="seqData">序列</param>
        /// <param name="length">划分长度</param>
        /// <returns>分组重量编码</returns>
        static double[] GetGroupWeightCodeOfCharcter(string seqData, int length)
        {
            string tempStr = "";
            double[] res = new double[length];
            int L;
            for (int i = 0; i < length; i++)
            {
                L = (int)Math.Round(((double)((i + 1) * (double)seqData.Length / (double)length)), 0);
                tempStr = seqData.Substring(0, L);
                res[i] = GetWeigthOfString(tempStr); //正规重量
            }
            return res;
        }
        #endregion
    }
}