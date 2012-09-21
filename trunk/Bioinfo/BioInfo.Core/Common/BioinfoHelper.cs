using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioInfo.Core
{
    /// <summary>
    /// 生物信息学常规帮助类,一些变量，规则等
    /// 另外网页结果显示、序列颜色设定等
    /// </summary>
    public class WebHelper
    {
        #region 辅助代码 对序列着色突出显示,多个颜色，指定显示某个字母的颜色
        //红色 #33300 蓝色 #000099  K用#009933，指定字母的颜色用#CC3333
        /// <summary>
        /// 对指定字符串中 指定位置的字母、中间字母进行着色区分
        /// </summary>
        /// <param name="str">字符串序列</param>
        /// <param name="colorChar">指定字母的颜色代码</param>
        /// <param name="colorPoint">中间字母的颜色代码</param>
        /// <param name="comColor">常规字母的颜色代码</param>
        /// <param name="arrList">指定字母的位置序列</param>
        /// <returns>着色处理后的Html代码</returns>
        public static string GetHtmlCodeByString(string str, string colorChar, string colorPoint, string comColor, int[] arrList)
        {
            bool[] conditon = new bool[str.Length]; //需要指定颜色的位置      
            for (int i = 0; i < arrList.Length; i++) { conditon[arrList[i] - 1] = true ; }
            string[] res = new string[conditon.Length];
            for (int i = 0; i < conditon.Length; i++)
            {
                if (conditon[i]) { res[i] = "<font color='#" + colorChar + "'><b>" + str[i] + "</b></font>"; }
                else { res[i] = "<font color='#" + comColor + "'><b>" + str[i] + "</b></font>";}
            }
            int a = (int)((str.Length - 1) * 0.5);
            string linkStr = "";
            for (int i = 0; i < a; i++)  {linkStr += res[i];}
            linkStr = linkStr + "-" + "<font color='#" + colorPoint + "'><b>" + str[a] + "</b></font>" + "-";
            for (int i = a + 1; i < str.Length; i++) { linkStr += res[i]; }
            return linkStr;
        }

        /// <summary>
        /// 对字符串进行着色,中间字母突出显示：常规
        /// </summary>
        /// <param name="str">字符串序列</param>
        /// <param name="color">中间字母的颜色</param>
        /// <returns>着色处理后的Html代码</returns>
        public static string GetHtmlCodeByString(string str, string color)
        {
            int a = Convert.ToInt32((str.Length - 1) * 0.5);
            string res = str.Substring(0, a) + "-";
            res += "<font color='#" + color + "'><b>" + str[a] + "</b></font>";
            res += ("-" + str.Substring(a + 1, a));
            return res;
        }
        #endregion

        #region 根据结果来构造Html结果显示的代码
        /// <summary>
        /// 默认表格样式(结果显示的表格)
        /// </summary>
        private static string DefaultTableStyle = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
        /// <summary>
        /// 默认的结果中,每一行的Html样式
        /// </summary>
        private static string DefaultTdStyle = "<td width='200' align='center' style=\"border:1px solid #333;\">";
        /// <summary>
        /// 特别的每行的样式，采用等宽字体(宋体)
        /// </summary>
        private static string SpecialTdStyle = "<td width='200' align='center' style=\"border:1px solid #333;font-family:'宋体';\">";
        /// <summary>
        /// 默认颜色
        /// </summary>
        private static string DefaultColor = "";
        /// <summary>
        /// 特殊颜色
        /// </summary>
        private static string SpecialColor = "";
        
        /// <summary>
        /// 根据结果来构造每行的Html代码:采用特殊行样式
        /// </summary>
        /// <param name="columnsValue">行单元格的值集合(颜色值需要用GetHtmlCodeByString来获取)</param>
        /// <returns>每一行的Html代码</returns>
        public static string GetHtmlResultDisplayCode(string[] columnsValue)
        {
            string output = "<tr>";//行开始
            for (int i = 0; i < columnsValue.Length ; i++)
            {
                output += (SpecialTdStyle + columnsValue[i] + "</td>") ;//循环添加
            }
            return output + "</tr>" ;//行结束
        }      
     
        /// <summary>
        /// 获取Table头部的Html代码
        /// </summary>
        /// <param name="displayColumnsNames">列的显示名称</param>
        /// <returns>Table头部包含列名称的Html代码</returns>    
        public static string GetTableHeader(string[] displayColumnsNames)
        {
            string output = DefaultTableStyle +"<tr>";//Table开始
            for (int i = 0; i < displayColumnsNames.Length ; i++)
            {
                output += (SpecialTdStyle + displayColumnsNames[i] + "</td>") ;//循环添加
            }
            return output + "</tr>" ;//行结束
        }        
        /// <summary>
        /// 获取Table尾部的Html代码
        /// </summary>     
        public static string GetTableTail()
        {
            return "</table><br/>";
        }
        #endregion
    }
}