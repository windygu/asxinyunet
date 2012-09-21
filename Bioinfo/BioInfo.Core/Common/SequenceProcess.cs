using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioInfo.Core
{
    
    /// <summary>
    /// 序列处理类,对输入序列进行处理和截取
    /// 算法说明：字符串分割时，最后进行字符串过滤并全部大写
    /// 然后在所有后续的转换中，就不用考虑这些了。以优化速度，避免重复操作。
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
            //删除前面的空行
            while (text[0] == '<') { text = text.Remove(0, 1); };
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
                    res[count++] = subStr[i].ToUpper().Replace ("O","").Replace("B", "").Replace("J", "").Replace("U", "").Replace("X", "").Replace("Z", "").Replace(" ", "").Replace("<", ""); 
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
            //删除前面的空行
            while (text[0] == '<') { text = text.Remove(0, 1); };
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
                    res[count++] = subStr[i].ToUpper().Replace ("O","").Replace("B", "").Replace("J", "").Replace("U", "").Replace("X", "").Replace("Z", "").Replace(" ", "").Replace("<", "");
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

        public static List<SequenceInfo> SplitBlockStringsByEnter(string text)
        {
            string[] names ;
            string[] temp = SplitStringsByEnter(text,out names);
            List<SequenceInfo> list = new List<SequenceInfo>();
            for (int i = 0; i < temp.Length ; i++)
			{
                list.Add(new SequenceInfo(names[i], temp[i]));
			}
            return list ;
        }
        #endregion

        #region 指定中心元素截取

        #region 废弃版本
        /// <summary>
        /// 获取以指定元素为中心，指定长度的字符序列，不足补O
        /// 该方法将逐步淘汰，下个版本不再使用
        /// </summary>
        /// <param name="seqData">输入序列</param>
        /// <param name="strLength">指定的截取长度</param>
        /// <param name="desChar">指定元素</param>
        /// <returns>以指定元素为中心的左右序列</returns>
        static string[] GetCentrlString(string seqData, int AllLength, char desChar)
        {
            //首先进行转换
            //seqData = seqData.ToUpper();
            int strLength = Convert.ToInt32((AllLength - 1) * 0.5);//单边的截取长度
            //检测是否包含其他非规定字符：B、J、O、U、X,并剔除
            //seqData = seqData.Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace("\r\n", "");
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
        /// 获取以指定元素为中心，指定长度的字符序列，不足补O,暂时废弃
        /// </summary>
        /// <param name="seqData">输入序列</param>
        /// <param name="strLength">指定的截取长度</param>
        /// <param name="desChar">指定元素</param>
        /// <param name="pos">指定元素出现的位置</param>
        /// <returns></returns>
        static string[] GetCentrlString(string seqData, int AllLength, char desChar, out int[] pos)
        {
            //首先进行转换
            //seqData = seqData.Replace(" ", "").Replace(".", "");
            int strLength = Convert.ToInt32((AllLength - 1) * 0.5);//单边的截取长度
            //检测是否包含其他非规定字符：B、J、O、U、X,并剔除
            //seqData = seqData.Replace("B", "").Replace("J", "").Replace("O", "").Replace("U", "").Replace("X", "").Replace("Z", "").ToString().Replace("\r\n", "");
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
                ///有一边小于10，舍去，不要
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
        #endregion

        #region 新的版本 有一边小于单边长度，舍去
        public static List<SequenceInfo> GetCentrlString(SequenceInfo seqData, int totalLength, char desChar)
        {
            List<SequenceInfo> list = new List<SequenceInfo>();
            //有一边小于单边长度，舍去，不要
            int strLength = Convert.ToInt32((totalLength - 1) * 0.5);//单边的截取长度
            int[] pos = IndexOfcharPosition(seqData.Text, desChar);//寻找符号出现的位置
            string[] result = new string[pos.Length];//输出结果
            for (int i = 0; i < pos.Length; i++)
            {
                string temp = "";
                if ((pos[i] >= strLength)&&(pos[i] + strLength) <= (seqData.Text.Length - 1)) //2边都要大于strLength
                {
                    temp = seqData.Text.Substring(pos[i] - strLength, strLength);
                    temp += desChar;
                    temp += seqData.Text.Substring(pos[i] + 1, strLength);
                    //都满足才添加
                    list.Add(new SequenceInfo(){ Name = seqData.Name,Text = temp,Position = pos [i ] +1 });                   
                } 
            }
            return list;
        }
        /// <summary>
        /// 依次对seq序列集合中的序列进行分割
        /// </summary>
        /// <param name="seq">序列集合</param>
        /// <param name="totalLength">截取总长度</param>
        /// <param name="desChar">目标氨基酸</param>
        /// <returns>截取后的序列集合</returns>
        public static List<SequenceInfo> GetCentrlString(List<SequenceInfo> seq, int totalLength, char desChar)
        {
            List<SequenceInfo> list = new List<SequenceInfo>();
            foreach (var item in seq )
            {
                list.AddRange(GetCentrlString(item,totalLength,desChar));
            }
            return list;
        }
        #endregion

        #region 辅助方法
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

        #endregion
    }
}
