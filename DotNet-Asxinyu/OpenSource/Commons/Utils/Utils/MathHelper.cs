namespace Utils
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary><para>　</para>
    /// 类名：常用工具类——验证类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------</para><para>　IsEmail：检测是否符合email格式</para><para>　IsURL：检测是否是正确的Url</para><para>　CheckSql：检测是否有Sql危险字符</para><para>　IsIP：是否为ip</para><para>　IsNumber：判断是否是数字</para><para>　IsNumberSign：是否数字字符串 可带正负号</para><para>　IsDecimal：是否是浮点数</para><para>　IsDecimalSign：是否是浮点数 可带正负号</para><para>　IsPhone：检查字符串是否为手机号</para><para>　IsHasCHZN：检测是否有中文字符</para><para>　IsBoolen字符串能否转为Boolen类型</para></summary>
    public class MathHelper
    {
        private static Regex x0290a0e2216ccdac;
        private static Regex x0400a63d65baba68;
        private static Regex x15ccf58320dd03b1;
        private static Regex x57dc31c02f910ad1;
        private static Regex x9c2254b4b19754f3 = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        private static Regex x9dd19311dce587e1;
        private static Regex xf22e48756559cc09;

        static MathHelper()
        {
            if (0xff != 0)
            {
                do
                {
                    x9dd19311dce587e1 = new Regex("^[0-9]+$");
                    x57dc31c02f910ad1 = new Regex("^[+-]?[0-9]+$");
                    x15ccf58320dd03b1 = new Regex("^[0-9]+[.]?[0-9]+$");
                    x0290a0e2216ccdac = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
                    xf22e48756559cc09 = new Regex(@"^[\w-]+@[\w-]+\.(com|net|org|edu|mil|tv|biz|info)$");
                }
                while (0 != 0);
                if (8 == 0) return;
            }
            x0400a63d65baba68 = new Regex("[一-龥]");
        }

        /// <summary>检测是否有Sql危险字符,,需引用：using System.Text.RegularExpressions;</summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool CheckSql(string str)
        {
            if (!Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']") && !Regex.IsMatch(str, "select|insert|delete|from|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|\"|or|and")) return false;
            return true;
        }

        /// <summary>字符串能否转为Boolen类型</summary>
        /// <param name="Str">字符串,一般为True或False</param>
        /// <returns></returns>
        public static bool IsBoolen(string Str)
        {
            bool flag = false;
            try
            {
                Convert.ToBoolean(Str);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>是否是浮点数</summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData) { return x15ccf58320dd03b1.Match(inputData).Success; }

        /// <summary>是否是浮点数 可带正负号</summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData) { return x0290a0e2216ccdac.Match(inputData).Success; }

        /// <summary>检测是否符合email格式,需引用：using System.Text.RegularExpressions;</summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsEmail(string strEmail) { return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); }

        /// <summary>检测是否有中文字符</summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData) { return x0400a63d65baba68.Match(inputData).Success; }

        /// <summary>是否为ip</summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip) { return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"); }

        /// <summary>判断是否是数字</summary>
        /// <param name="inputData">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            bool flag = false;
            try
            {
                Convert.ToInt32(inputData);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>是否数字字符串 可带正负号</summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData) { return x57dc31c02f910ad1.Match(inputData).Success; }

        /// <summary>检查字符串是否为手机号</summary>
        /// <param name="inputData">字符串</param>
        /// <returns>是否为手机号</returns>
        public static bool IsPhone(string inputData) { return x9c2254b4b19754f3.Match(inputData).Success; }

        /// <summary>检测是否是正确的Url,需引用：using System.Text.RegularExpressions;</summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl) { return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$"); }
    }
}
