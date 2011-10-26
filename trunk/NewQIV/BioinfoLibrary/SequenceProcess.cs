using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    /// <summary>
    /// 序列处理类,对输入序列进行处理和截取
    /// </summary>
    public class SequenceProcess
    {
        #region 将字符串进行分割：按照换行确定
        /// <summary>
        /// 对文本块进行分割，按照换行符和>进行识别 
        /// </summary>
        /// <param name="text">文本块:由序列名和序列组成</param>
        /// <returns>分割后的字符串数组</returns>
        public static string[] SplitStringsByEnter(string text)
        {
            //分割方法：从头到尾检索，遇到>检索遇到\r\n(由<替换)则删掉           
            text = text.Replace("\r\n", "<").Replace("\n", "<");//暂时不过滤掉空格小数点等非法字符
            // 查找> < 分别出现的位置
            int[] firstLocation = IndexOfcharPosition(text, '>');//>出现的位置
            int[] secLocation = IndexOfcharPosition(text, '<');//换行符出现的位置
            for (int i = firstLocation.Length - 1; i >= 0; i--)
            {
                //找出当前>符号后第一个换行符的位置，删除掉
                for (int j = firstLocation[i]; j < text.Length; j++)
                {
                    if (text[j] == '<')
                    {
                        text = text.Remove(firstLocation[i] + 1, j - firstLocation[i]);
                        break;
                    }
                }
            }
            string[] subStr = text.Split('>');//字符串分割
            int count = 0;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i] != "")
                {
                    count++;//计算合法字符串个数
                }
            }
            string[] res = new string[count];
            count = 0;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i] != "")
                {
                    res[count++] = subStr[i].ToUpper().Replace("B", "").Replace("J", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace(" ", "").Replace("<", ""); //.Replace ("O","") 解除限制o
                }
            }
            //剔除不是字母的元素
            int temp;
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    temp = Convert.ToInt32(res[i][j]);
                    if (temp < 65 || temp > 90)
                    {
                        res[i] = res[i].Remove(j, 1); //删除
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 对文本块进行分割，按照换行符和>进行识别 ,并返回对应的序列名称
        /// </summary>
        /// <param name="text">文本块:由序列名和序列组成</param>
        /// <param name="strNames">返回分割后每条序列对应的名称</param>
        /// <returns>分割后的字符串数组</returns>
        public static string[] SplitStringsByEnter(string text, out string[] strNames)
        {
            //分割方法：从头到尾检索，遇到>检索遇到\r\n(由<替换)则删掉           
            text = text.Replace("\r\n", "<").Replace("\n", "<").Replace(" ", "").Replace(".", "");
            // 查找> < 分别出现的位置
            int[] firstLocation = IndexOfcharPosition(text, '>');//>出现的位置
            int[] secLocation = IndexOfcharPosition(text, '<');//换行符出现的位置

            //Queue<string > qu = new Queue<string>() ;
            Stack<string> qu = new Stack<string>();
            for (int i = firstLocation.Length - 1; i >= 0; i--)
            {
                //找出当前>符号后第一个换行符的位置，删除掉
                for (int j = firstLocation[i]; j < text.Length; j++)
                {
                    if (text[j] == '<')
                    {
                        qu.Push(text.Substring(firstLocation[i] + 1, j - firstLocation[i]).Replace("<", "").Replace(">", "").Trim());//j - firstLocation[i]-1
                        text = text.Remove(firstLocation[i] + 1, j - firstLocation[i]);
                        break;
                    }
                }
            }
            string[] subStr = text.Split('>');//字符串分割
            int count = 0;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i] != "")
                {
                    count++;//计算合法字符串个数
                }
            }
            string[] res = new string[count];
            count = 0;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i] != "")
                {
                    res[count++] = subStr[i].ToUpper().Replace("B", "").Replace("J", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace(" ", "").Replace("<", "");//.Replace ("O","")                   
                }
            }
            //剔除不是字母的元素
            int temp;
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    temp = Convert.ToInt32(res[i][j]);
                    if (temp < 65 || temp > 90)
                    {
                        res[i] = res[i].Remove(j, 1); //删除
                    }
                }
            }
            strNames = new string[qu.Count];
            for (int i = 0; i < strNames.Length; i++)
            {
                strNames[i] = qu.Pop();//出队列
            }
            return res;
        }
        #endregion

        #region 指定中心元素截取
        /// <summary>
        /// 获取以指定元素为中心，指定长度的字符序列，不足补O
        /// </summary>
        /// <param name="seqData">输入序列</param>
        /// <param name="strLength">指定的截取长度</param>
        /// <param name="desChar">指定元素</param>
        /// <returns>以指定元素为中心的左右序列</returns>
        public static string[] GetCentrlString(string seqData, int AllLength, char desChar)
        {
            //首先进行转换
            seqData = seqData.ToUpper();
            int strLength = Convert.ToInt32((AllLength - 1) * 0.5);//单边的截取长度
            //检测是否包含其他非规定字符：B、J、O、U、X,并剔除
            seqData = seqData.Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace("\r\n", "");
            int[] pos = IndexOfcharPosition(seqData, desChar);//寻找C符号出现的位置
            string[] result = new string[pos.Length];//输出结果
            for (int i = 0; i < pos.Length; i++)
            {
                result[i] = "";
                if (pos[i] >= strLength) //左边界判断 ,不需要补齐
                {
                    result[i] = seqData.Substring(pos[i] - strLength, strLength);
                }
                else  //左边界判断 ,需要补O 
                {
                    result[i] = seqData.Substring(0, pos[i]).PadLeft(strLength, 'O');
                }
                result[i] += desChar;
                if ((pos[i] + strLength) <= (seqData.Length - 1)) //右边界判断 ,不需要补齐
                {
                    result[i] += seqData.Substring(pos[i] + 1, strLength);
                }
                else  //右边界判断 ,需要补O 
                {
                    result[i] += seqData.Substring(pos[i] + 1, seqData.Length - pos[i] - 1).PadRight(strLength, 'O');
                }
            }
            return result;
        }

        /// <summary>
        /// 获取以指定元素为中心，指定长度的字符序列，不足补O
        /// </summary>
        /// <param name="seqData">输入序列</param>
        /// <param name="strLength">指定的截取长度</param>
        /// <param name="desChar">指定元素</param>
        /// <param name="pos">指定元素出现的位置</param>
        /// <returns></returns>
        public static string[] GetCentrlString(string seqData, int AllLength, char desChar, out int[] pos)
        {
            //首先进行转换
            seqData = seqData.ToUpper().Replace(" ", "").Replace(".", "");
            int strLength = Convert.ToInt32((AllLength - 1) * 0.5);//单边的截取长度
            //检测是否包含其他非规定字符：B、J、O、U、X,并剔除
            seqData = seqData.Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace("\r\n", "");
            pos = IndexOfcharPosition(seqData, desChar);//寻找符号出现的位置
            string[] result = new string[pos.Length];//输出结果
            for (int i = 0; i < pos.Length; i++)
            {
                result[i] = "";
                if (pos[i] >= strLength) //左边界判断 ,不需要补齐
                {
                    result[i] = seqData.Substring(pos[i] - strLength, strLength);
                }
                else  //左边界判断 ,需要补O 
                {
                    result[i] = seqData.Substring(0, pos[i]).PadLeft(strLength, 'O');
                }
                result[i] += desChar;
                if ((pos[i] + strLength) <= (seqData.Length - 1)) //右边界判断 ,不需要补齐
                {
                    result[i] += seqData.Substring(pos[i] + 1, strLength);
                }
                else  //右边界判断 ,需要补O 
                {
                    result[i] += seqData.Substring(pos[i] + 1, seqData.Length - pos[i] - 1).PadRight(strLength, 'O');
                }
            }
            //修改pos的位置，因为程序中是从0开始的
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = pos[i] + 1;
            }
            return result;
        }

        /// <summary>
        /// 检索字符串中指定字符出现的位置
        /// </summary>
        /// <param name="str"></param>
        /// <param name="objChar"></param>
        /// <returns></returns>
        private static int[] IndexOfcharPosition(string str, char objChar)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == objChar)
                {
                    sum++;
                }
            }
            int[] res = new int[sum];
            sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == objChar)
                {
                    res[sum++] = i;
                }
            }
            return res;
        }
        //计算某一字符的个数
        private static int SumOfChar(string str, char objChar)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == objChar)
                {
                    sum++;
                }
            }
            return sum;
        }
        private static int SumOfStrings(string[] str, char objChar)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                count += SumOfChar(str[i], objChar);
            }
            return count;
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
        #endregion
    }
}
