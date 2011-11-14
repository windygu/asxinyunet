using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LotteryTicket.Common
{
    /// <summary>
    /// 文本文件的规则解析
    /// </summary>
    public class TxtParse
    {
        //TODO:界面上动态添加规则，并更新到文本。最后还是通过文本的规则来解析，结果记录方便
        #region        
        /// <summary>
        /// 解析规则文本
        /// </summary>
        /// <param name="ruleFilePath">规则文件路径</param>
        /// <returns>规则列表</returns>
        public static List<string> GetRuleListFormFile(string ruleFilePath)
        {
            List<string> ruleList = new List<string>();//规则列表
            using (StreamReader sr = new StreamReader(ruleFilePath))
            {           
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("#") || (line.Length < 5))
                    {
                        continue;
                    }
                    ruleList.Add(line);//添加
                }
            }
            return ruleList;
        }

        /// <summary>
        /// 根据规则列表解析规则
        /// </summary>
        /// <param name="ruleList">规则数组列表</param>
        /// <returns>规则字符串数组</returns>
        public static string[][] ParseRuleList(List<string> ruleList)
        {
            string[][] res = new string[ruleList.Count][];
            //TODO:解析文本，增加一个特殊规则的处理，特殊规则的处理，到最底层处理
            //先：分割
            for (int i = 0; i <ruleList.Count ; i++)
            {
                List<string> strList = new List<string>();
                string[] temp = ruleList [i].Split (':') ;
                if (temp.Length==4) //只能有3个
                {
                    if (temp[3].Contains("#"))
                    {
                        res[i] = new string[6];
                        string[] t = temp[3].Split('#');//再次分割
                        res[i][0] = temp[0].Trim();
                        res[i][1] = temp[1].Trim();
                        res[i][2] = temp[2].Trim();
                        res[i][3] = t[0].Trim ();
                        res[i][4] = t[1].Trim();
                        res[i][5] = t[2].Trim();
                    }
                    else
                    {
                        res[i] = new string[4];                   
                        res[i][0] = temp[0].Trim();
                        res[i][1] = temp[1].Trim();
                        res[i][2] = temp[2].Trim();
                        res[i][3] = temp[3].Trim();
                    }
                }
            }
            return res;
        }

        //拼接字符串
        public static string CombStringArr(string[] str)
        {            
            if (str.Length == 4)
            {
                return str[0] + ":" + str[1] + ":" + str[2] + ":" + str[3];
            }
            else
            {
                return str[0] + ":" + str[1] + ":" + str[2] + ":" + str[3] +"#"+str [4]+"#"+str [5];
            }
        }
        #endregion
    }
}
