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
    /// 特征提取类
    /// </summary>
    public class FeatureExtraction
    {
        #region 小波变换获取蛋白质序列特征-Wavelet
        /// <summary>
        /// 获取一条蛋白质序列的特征
        /// </summary>
        /// <param name="seqData">蛋白质序列数据</param>
        /// <param name="waveName" >小波变换名称</param>
        /// <returns>特征向量</returns>
        public static double[] GetSequenceCharacter(string seqData, string waveName)
        {          
            KdTreeDataPro cwf = new KdTreeDataPro();
            MWNumericArray nmarray = (MWNumericArray)cwf.CalcuteWave((MWArray)seqData, waveName);
            double[,] resultT = (double[,])nmarray.ToArray();
            double[] result = new double[20];
            for (int i = 0; i < 20; i++)
            {
                result[i] = resultT[0, i];
            }
            return result;
        }
        #endregion

        #region	获取多条蛋白质序列的特征:public static double[][] GetAllSeqCharacter
        /// <summary>
        /// 小波变换获取多条蛋白质序列的特征
        /// </summary>
        /// <param name="text">多条蛋白质的原始序列</param>
        /// <param name="waveName" >小波变换名称</param>
        /// <returns>特征向量数组,每一行为一条结果</returns>
        public static double[][] GetAllSeqCharacter(string text, string waveName)
        {
            string[] str = SplitStringsByEnter(text); //分块
            return GetSeqCharactersBySeqs(str, waveName);//计算结果
        }
        #endregion

        #region 获取多条蛋白质序列的特征 采用默认的小波变换
        /// <summary>
        /// 采用默认的小波变换 bior2.4进行运算
        /// </summary>
        /// <param name="text">>多条蛋白质的原始序列</param>
        /// <returns>特征向量数组,每一行为一条结果</returns>
        public static double[][] GetAllSeqCharacter(string text)
        {
            return GetAllSeqCharacter(text, "bior2.4");
        }
        #endregion

        #region WaccAndACF 2011-10-21修改版
        public static double[][] NewGetAllWaccAndACFvalue(string text, int strLength, char desChar, int M, out string[] subText, out int[] Pos)
        {
            subText = GetCentrlString(text, strLength, desChar, out Pos);
            double[][] res = new double[subText.Length][];
            for (int i = 0; i < subText.Length; i++)
            {
                res[i] = GetOneWaccAndACFvalue(subText[i], M);
            }
            return res;
        }
        #endregion

        #region WACC与自相关 GetAllWaccAndACFvalue
        /// <summary>
        /// 提取所有输入序列的wacc特征值及自相关值
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度，自相关参数小1</param>
        /// <param name="desChar">中心字符串</param>
        /// <returns>特征序列及自相关值</returns>
        public static double[][] GetAllWaccAndACFvalue(string text, int strLength, char desChar)
        {
            string[] allTextStr = SplitStringsByEnter(text);//分割
            int charNumber = SumOfStrings(allTextStr, desChar);//SumOfChar(text, desChar);//目标字符串个数
            double[][] res = new double[charNumber][];//结果 ,NormalSeqence.Length +2*strLength +1
            int count = 0;
            string[] tempStr;
            double[] tempDouble;
            for (int i = 0; i < allTextStr.Length; i++)
            {
                tempStr = GetCentrlString(allTextStr[i], strLength, desChar);//当前序列的截取集合
                //对截取序列进行计算，WACC 与自相关值
                for (int j = 0; j < tempStr.Length; j++)
                {
                    //计算联合特征值：前20列为Wacc权重特征值,后面的列为自相关特征
                    tempDouble = GetOneWaccAndACFvalue(tempStr[j], strLength - 1);
                    res[count++] = tempDouble;
                }
            }
            return res;
        }

        //获取一条序列的Wacc权重值和自相关值
        public static double[] GetOneWaccAndACFvalue(string strSeqence, int M)
        {
            double[] wacc = WACC_OneSeqence(strSeqence);
            double[] acf = AutoCorrFunction(strSeqence, M);
            double[] res = new double[wacc.Length + acf.Length];
            Array.Copy(wacc, 0, res, 0, wacc.Length);
            Array.Copy(acf, 0, res, wacc.Length, acf.Length);
            return res;
        }

        /// <summary>
        /// 计算一条序列的WACC特征值
        /// </summary>
        /// <param name="strSeqence">氨基酸序列</param>
        /// <returns>特征值</returns>
        public static double[] WACC_OneSeqence(string strSeqence)
        {
            double[] res = new double[NormalSeqence.Length];
            double temp;
            for (int i = 0; i < res.Length; i++)
            {
                temp = 0;
                for (int j = 0; j < strSeqence.Length; j++)
                {
                    temp += XIPCalculate(strSeqence, i, j) * (j + 1);
                }
                res[i] = temp / strSeqence.Length;
            }
            return res;
        }

        /// <summary>
        /// 计算一条输入序列计算其自相关函数
        /// </summary>
        /// <param name="strSeqence">输入序列</param>
        /// <param name="M">待定整数</param>
        /// <returns>自相关向量</returns>
        public static double[] AutoCorrFunction(string StrSeqence, int M)
        {
            double[] SeqenceValue = GetValuesOfSequence(StrSeqence);
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

        #region 分组编码特征
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

        /// <summary>
        /// 获取一条蛋白质序列的分组重量编码
        /// </summary>
        /// <param name="seqData"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double[] GetOneProteinSeqCode(string seqData, int length)
        {
            string[] restr = GetGroupCodeString(seqData);
            double[] res = new double[3 * length];
            for (int i = 0; i < restr.Length; i++)
            {
                double[] t1 = GetGroupWeightCodeOfCharcter(restr[i], length);
                Array.Copy(t1, 0, res, i * length, t1.Length);
            }
            return res;
        }
        #endregion

        #region 使用的特征提取是自相关函数和分组重量和氨基酸位置权重 Ace_Pred
        /// <summary>
        /// 自相关函数和分组重量和氨基酸位置权重
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度，自相关的参数比截取长度小1</param>
        /// <param name="desChar">中心字符串</param>
        /// <param name="length">分组重量编码的划分长度</param>
        /// <returns>交错数组，存储顺序:位置权重(20列)-自相关函数-分组重量</returns>
        public static double[][] Ace_Pred(string text, int strLength, char desChar, int length)
        {
            string[] allText = SplitStringsByEnter(text);//输入分割
            string[][] subText = new string[allText.Length][];
            int sum = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
                sum += subText[i].Length;
            }
            double[][] res = new double[sum][];
            int count = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    //计算结果
                    double[] temp1 = new double[20 + strLength - 1 + length * 3];
                    double[] temp2, temp3;
                    temp2 = GetOneWaccAndACFvalue(subText[i][j], strLength - 1);
                    temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }

        public static double[][] GetOneAce_Pred(string strSeqence, int strLength, int length)
        {
            double[][] res = new double[1][];
            //计算结果
            double[] temp1 = new double[20 + strLength - 1 + length * 3];
            double[] temp2, temp3;
            temp2 = GetOneWaccAndACFvalue(strSeqence, strLength - 1);
            temp3 = GetOneProteinSeqCode(strSeqence, length);
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            res[0] = temp1;
            return res;
        }
        #endregion

        #region Ace-Pred修改 -2011-10-15
        /// <summary>
        /// 计算一条长序列分割后的AcePred特征值，直接进行字符串分割提取
        /// </summary>
        /// <param name="text"></param>
        /// <param name="strLength"></param>
        /// <param name="desChar"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double[][] NewAcePred(string text, int strLength, char desChar, int length, out string[] subText, out int[] Pos)
        {
            subText = GetCentrlString(text, strLength, desChar, out Pos);//截取序列
            double[][] res = new double[subText.Length][];
            int count = 0;
            for (int j = 0; j < subText.Length; j++)
            {
                //计算结果
                double[] temp1 = new double[20 + length * 3];
                double[] temp2, temp3;
                temp2 = WACC_OneSeqence(subText[j]);
                temp3 = GetOneProteinSeqCode(subText[j], length);
                Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                res[count++] = temp1;
            }
            return res;
            #region 废弃代码
            //string[] allText = SplitStringsByEnter(text);//输入分割
            //string[][] subText = new string[allText.Length][];
            //int sum = 0;
            //for (int i = 0; i < allText.Length; i++)
            //{
            //    subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
            //    sum += subText[i].Length;
            //}
            //double[][] res = new double[sum][];
            //int count = 0;
            //for (int i = 0; i < allText.Length; i++)
            //{
            //    for (int j = 0; j < subText[i].Length; j++)
            //    {
            //        //计算结果
            //        double[] temp1 = new double[20 + length * 3];
            //        double[] temp2, temp3;
            //        temp2 = WACC_OneSeqence(subText[i][j]);
            //        temp3 = GetOneProteinSeqCode(subText[i][j], length);
            //        Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            //        Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            //        res[count++] = temp1;
            //    }
            //}
            //return res;
            //string[] subText = GetCentrlString(text, strLength, desChar);//截取序列
            //        double[][] res = new double[subText.Length ][];
            //        int count = 0;            
            //            for (int j = 0; j < subText.Length; j++)
            //            {
            //                //计算结果
            //                double[] temp1 = new double[20 + length * 3];
            //                double[] temp2, temp3;
            //                temp2 = WACC_OneSeqence(subText[j]);
            //                temp3 = GetOneProteinSeqCode(subText[j], length);
            //                Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            //                Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            //                res[count++] = temp1;
            //            }           
            //        return res;
            #endregion
        }

        public static double[][] NewGetOneAcePred(string strSeqence, int length)
        { //位置权重（WAAC）-分组重量（GWS）
            double[][] res = new double[1][];
            //计算结果
            double[] temp1 = new double[20 + length * 3];
            double[] temp2, temp3;
            double[] wacc = WACC_OneSeqence(strSeqence);
            temp2 = WACC_OneSeqence(strSeqence);
            temp3 = GetOneProteinSeqCode(strSeqence, length);
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            res[0] = temp1;
            return res;
        }
        #endregion

        #region 分组属性编码 GetGroupAttributeCode
        /// <summary>
        /// 氨基酸属性分组编码和位置权重
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度</param>
        /// <param name="desChar">中心字符串</param>
        /// <returns>交错数组，存储顺序:氨基酸属性分组编码-位置权重</returns>
        public static double[][] GetGroupAttributeCode(string text, int strLength, char desChar)
        {
            string[] allText = SplitStringsByEnter(text);//输入分割
            string[][] subText = new string[allText.Length][];
            int sum = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
                sum += subText[i].Length;
            }
            double[][] res = new double[sum][];
            int count = 0;

            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    //计算 结果        			
                    double[] temp2, temp3;
                    temp2 = GetAttributeCode(subText[i][j]);//氨基酸属性分组编码
                    temp3 = WACC_OneSeqence(subText[i][j]);//位置权重        			
                    double[] temp1 = new double[temp2.Length + temp3.Length];
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }
        //2011-10-18新增修改算法，每次获取一条完整序列截取字符串后的特征值
        public static double[][] NewGetGroupAttributeCode(string text, int strLength, char desChar, out string[] subText, out int[] Pos)
        {
            subText = GetCentrlString(text, strLength, desChar, out Pos);//截取序列          
            double[][] res = new double[subText.Length][];
            int count = 0;
            int L = (int)((strLength - 1) * 0.5);
            for (int j = 0; j < subText.Length; j++)
            {
                //计算 结果        			
                double[] temp2, temp3;
                temp2 = GetAttributeCode(subText[j]);//氨基酸属性分组编码
                temp3 = NewWacc_OneSeqence(subText[j], L);//位置权重        			
                double[] temp1 = new double[temp2.Length + temp3.Length];
                Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                res[count++] = temp1;
            }
            return res;
        }
        public static double[][] GetOneGroupAttribute(string strSeqence, int strLength)
        {
            double[][] res = new double[1][];
            //计算 结果
            double[] temp2, temp3;
            temp2 = GetAttributeCode(strSeqence);//氨基酸属性分组编码
            temp3 = WACC_OneSeqence(strSeqence);//位置权重
            double[] temp1 = new double[temp2.Length + temp3.Length];
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            res[0] = temp1;
            return res;
        }
        //属性分组编码
        static double[] GetAttributeCode(string seqStr)
        {
            seqStr = seqStr.ToUpper();
            double[] res = new double[seqStr.Length * 4];
            for (int i = 0; i < seqStr.Length; i++)
            {
                int temp = groupValue[Convert.ToInt32(seqStr[i]) - 65];
                if (temp == 1)
                {
                    res[i * 4] = 1;
                    res[i * 4 + 1] = 0;
                    res[i * 4 + 2] = 0;
                    res[i * 4 + 3] = 0;
                }
                else if (temp == 2)
                {
                    res[i * 4] = 0;
                    res[i * 4 + 1] = 1;
                    res[i * 4 + 2] = 0;
                    res[i * 4 + 3] = 0;
                }
                else if (temp == 3)
                {
                    res[i * 4] = 0;
                    res[i * 4 + 1] = 0;
                    res[i * 4 + 2] = 1;
                    res[i * 4 + 3] = 0;
                }
                else if (temp == 4)
                {
                    res[i * 4] = 0;
                    res[i * 4 + 1] = 0;
                    res[i * 4 + 2] = 0;
                    res[i * 4 + 3] = 1;
                }
                else
                {
                    res[i * 4] = 0;
                    res[i * 4 + 1] = 0;
                    res[i * 4 + 2] = 0;
                    res[i * 4 + 3] = 0;
                }
            }
            return res;
        }
        #endregion

        #region 2011-10-19 改进位置权重算法
        public static double[] NewGetOneGroupAttribute(string strSeqence, int L)
        {
            //计算 结果
            double[] temp2, temp3;
            temp2 = GetAttributeCode(strSeqence);//氨基酸属性分组编码
            temp3 = NewWacc_OneSeqence(strSeqence, L);//位置权重
            double[] temp1 = new double[temp2.Length + temp3.Length];
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            return temp1;
        }

        public static double[] NewWacc_OneSeqence(string strSeqence, int L)
        {
            double[] res = new double[NormalSeqence.Length];
            for (int i = 0; i < res.Length; i++)
            {
                double temp = 0;
                for (int j = -L; j <= L; j++)
                {
                    if (NormalSeqence[i] == strSeqence[j + L])
                    {
                        temp += (j + Math.Abs(j) / (double)L);
                    }
                }
                res[i] = temp / (double)(L * (L + 1));
            }
            return res;
        }
        #endregion

        #region 位置权重和分组重量编码 DLMLA
        /// <summary>
        /// 位置权重和分组重量编码
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度</param>
        /// <param name="desChar">中心字符串</param>
        /// <param name="length">分组重量编码的划分长度</param>
        /// <returns>位置权重和分组重量编码</returns>
        public static double[][] DLMLA(string text, int strLength, char desChar, int length)
        {
            string[] allText = SplitStringsByEnter(text);//输入分割
            string[][] subText = new string[allText.Length][];
            int sum = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
                sum += subText[i].Length;
            }
            double[][] res = new double[sum][];
            int count = 0;

            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    //计算 结果
                    double[] temp1 = new double[20 + length * 3];
                    double[] temp2, temp3;
                    temp2 = WACC_OneSeqence(subText[i][j]);
                    temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }
        //获取一条序列的DLMLA特征值
        public static double[][] GetOneDLMLA(string strSeqence, int strLength, int length)
        {
            double[][] res = new double[1][];
            //计算 结果
            double[] temp1 = new double[20 + length * 3];
            double[] temp2, temp3;
            temp2 = WACC_OneSeqence(strSeqence);
            temp3 = GetOneProteinSeqCode(strSeqence, length);
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            res[0] = temp1;
            return res;
        }
        //获取一条序列截取后的子字符串DLMLA序列值
        public static double[][] NewDLMLA(string text, int strLength, char desChar, int length, out string[] subText, out int[] Pos)
        {
            subText = GetCentrlString(text, strLength, desChar, out Pos);//截取序列    
            double[][] res = new double[subText.Length][];
            for (int i = 0; i < subText.Length; i++)
            {
                //计算 结果
                double[] temp1 = new double[20 + length * 3];
                double[] temp2, temp3;
                temp2 = WACC_OneSeqence(subText[i]);
                temp3 = GetOneProteinSeqCode(subText[i], length);
                Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                res[i] = temp1;
            }
            return res;
        }
        #endregion

        #region 自相关函数和分组重量编码  PredSulSite
        /// <summary>
        /// 自相关函数和分组重量编码
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度,自相关的参数比截取长度小1</param>
        /// <param name="desChar">中心字符串</param>
        /// <param name="length">分组重量编码的划分长度</param>
        /// <returns>交错数组，存储顺序:自相关函数-分组重量编码</returns>
        public static double[][] PredSulSite(string text, int strLength, char desChar, int length)
        {
            string[] allText = SplitStringsByEnter(text);//输入分割
            string[][] subText = new string[allText.Length][];
            int sum = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
                sum += subText[i].Length;
            }
            double[][] res = new double[sum][];
            int count = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    //计算结果
                    double[] temp1 = new double[strLength - 1 + length * 3];//2*strLength +1+length*3
                    double[] temp2, temp3;
                    temp2 = AutoCorrFunction(subText[i][j], strLength - 1);
                    temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }

        public static double[][] GetOnePredSulsite(string strSeqence, int strLength, int length)
        {
            double[][] res = new double[1][];
            //计算结果
            double[] temp1 = new double[strLength - 1 + length * 3];//2*strLength +1+length*3
            double[] temp2, temp3;
            temp2 = AutoCorrFunction(strSeqence, strLength - 1);
            temp3 = GetOneProteinSeqCode(strSeqence, length);
            Array.Copy(temp2, 0, temp1, 0, temp2.Length);
            Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
            res[0] = temp1;
            return res;
        }
        /// <summary>
        /// 自相关函数和分组重量编码
        /// </summary>
        /// <param name="text">所有输入的文本块</param>
        /// <param name="strLength">截取长度</param>
        /// <param name="desChar">中心字符串</param>
        /// <param name="length">分组重量编码的划分长度</param>
        /// <returns>交错数组，存储顺序:自相关函数-分组重量编码</returns>
        public static double[][] PredSulSiteTest(string[] allText, int strLength, char desChar, int length)
        {
            //string[] allText = SplitStringsByEnter (text ) ;//输入分割
            string[][] subText = new string[allText.Length][];
            int sum = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
                sum += subText[i].Length;
            }
            double[][] res = new double[sum][];
            int count = 0;
            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    //计算结果
                    double[] temp1 = new double[strLength + length * 3];//2*strLength +1+length*3
                    double[] temp2, temp3;
                    temp2 = AutoCorrFunction(subText[i][j], strLength);
                    temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }
        #endregion

        #region PredSulSite 2011-10-18 修改
        /// <summary>
        /// 计算一条序列分割后提取的子序列的特征值
        /// </summary>
        /// <returns></returns>
        public static double[][] NewPredSulSiteForOneSeq(string text, int strLength, char desChar, int length, out string[] subText, out int[] Pos)
        {
            subText = GetCentrlString(text, strLength, desChar, out Pos);//截取序列             
            double[][] res = new double[subText.Length][];
            int count = 0;
            for (int j = 0; j < subText.Length; j++)
            {
                //计算结果
                double[] temp1 = new double[strLength - 1 + length * 3];
                double[] temp2, temp3;
                temp2 = AutoCorrFunction(subText[j], strLength - 1);
                temp3 = GetOneProteinSeqCode(subText[j], length);
                Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                res[count++] = temp1;
            }
            return res;
        }
        #endregion

        #region 公共函数
        static double[][] ZhYH(string text, int strLength, char desChar, int length, int classtype)
        {
            string[] allText = SplitStringsByEnter(text);//输入分割
            string[][] subText = new string[allText.Length][];
            for (int i = 0; i < allText.Length; i++)
            {
                subText[i] = GetCentrlString(allText[i], strLength, desChar);//截取序列
            }
            double[][] res = new double[subText.Length][];
            int count = 0;
            int allLength;
            if (classtype == 2)
            {
                allLength = 20 + 2 * strLength + 1 + length * 3;//3个
            }
            else if (classtype == 4)
            {
                allLength = 20 + length * 3;
            }
            else if (classtype == 5)
            {
                allLength = 2 * strLength + 1 + length * 3;
            }
            else
            {
                return null;
            }
            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < subText[i].Length; j++)
                {
                    double[] temp1 = new double[allLength];
                    double[] temp2, temp3;
                    //计算结果
                    if (classtype == 2)
                    {
                        temp2 = GetOneWaccAndACFvalue(subText[i][j], 2 * strLength + 1);
                        temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    }
                    else if (classtype == 4)
                    {
                        temp2 = WACC_OneSeqence(subText[i][j]);
                        temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    }
                    else if (classtype == 5)
                    {
                        temp2 = AutoCorrFunction(subText[i][j], 2 * strLength + 1);
                        temp3 = GetOneProteinSeqCode(subText[i][j], length);
                    }
                    else
                    {
                        return null;
                    }
                    Array.Copy(temp2, 0, temp1, 0, temp2.Length);
                    Array.Copy(temp3, 0, temp1, temp2.Length, temp3.Length);
                    res[count++] = temp1;
                }
            }
            return res;
        }

        public static string GetHtmlCodeByString(string str, string color)
        {
            int a = Convert.ToInt32((str.Length - 1) * 0.5);
            string res = str.Substring(0, a) + "-";
            res += "<font color='#" + color + "'><b>" + str[a] + "</b></font>";
            res += ("-" + str.Substring(a + 1, a));
            return res;
        }
        #endregion
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

        /// <summary>
        /// 根据输入文本块得到自相关数组
        /// </summary>
        /// <param name="text">文本块</param>
        /// <returns>自相关数组</returns>
        //public static double[,] GetTextACFValue(string text,int M)
        //{
        //    string[] strArray = SplitStringsByEnter(text);
        //    double[,] res = new double [strArray.GetLength (0),M ] ;
        //    double[] temp,temp1;
        //    for (int i = 0; i < strArray.Length ; i++)
        //    {
        //        temp = GetValuesOfSequence(strArray[i]);//量化序列
        //        temp1 = AutoCorrFunction(temp, M);//计算自相关
        //        for (int j = 0; j < temp1.Length ; j++)
        //        {
        //            res[i, j] = temp1[j];
        //        }
        //    }
        //    return res ;
        //}

        /// <summary>
        /// 计算多条序列的特征值,从文本框获取的原始数据  位置权重氨基酸组分计算-
        /// </summary>
        /// <param name="text">多条序列,输入格式固定</param>
        /// <returns>特征值数组</returns>
        //public static double[,] WACC_AllSeqence(string text)
        //{            
        //    string[] str = SplitStringsByEnter(text);//分割
        //    double[,] res = new double[str.Length, NormalSeqence.Length];
        //    double[] temp ;
        //    for (int i = 0; i < str.Length ; i++)
        //    {
        //        temp = WACC_OneSeqence(str[i]);
        //        for (int j = 0; j <temp.Length ; j++)
        //        {
        //            res[i, j] = temp[j];
        //        }
        //    }
        //    return res ;
        //}

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
