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
    /// 蛋白质序列特征类
    /// </summary>
    public partial class ProteidCharacter
    {
        private static double[][] GetSeqCharactersBySeqs(string[] texts, string waveName)
        {
            double[][] res = new double[texts.Length][];
            double[] temp = new double[20];
            for (int i = 0; i < texts.Length; i++)
            {
                temp = GetSequenceCharacter(texts[i], waveName);//单独调用程序进行计算                
                res[i] = temp;          
            }
            return res;
        }

        private static double[][] GetSeqCharactersBySeqs(string[] texts)
        {
            return GetSeqCharactersBySeqs(texts, "bior2.4");
        }
        private static int XIPCalculate(string str, int i, int p)
        {
            if (str[p] == NormalSeqence[i])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据序列得到对应的数字序列
        /// </summary>
        /// <param name="strSeqence">序列</param>
        /// <returns>对应的数字序列</returns>
        private static double[] GetValuesOfSequence(string strSeqence)
        {
            //检测是否包含其他非规定字符：B、J、O、U、X,Z,并剔除
            strSeqence = strSeqence.ToUpper().Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString();
            //键值转换数组,不包含的字符也赋值，但不影响最终结果
            double[] changArray = new double[] { 1.8, 2.1, 2.5, -3.5, -3.5, 2.8, -0.4, -3.2, 4.5, 10.1, -3.9, 3.8, 1.9,
                -3.5, 15, -1.6, -3.5, -4.5, -0.8, -0.7, 21, 4.2, -0.9, 24, -1.3, 26.1 };
            double[] cValue = new double[strSeqence.Length];
            for (int i = 0; i < strSeqence.Length; i++)
            {
                cValue[i] = changArray[Convert.ToInt32(strSeqence[i]) - 65];//进行键值转换
            }
            return cValue;
        }
    }
}
