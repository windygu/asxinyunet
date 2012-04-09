namespace Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary><para>　</para>
    /// 类名：常用工具类——金额转换类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：20010-01-08</para><para>--------------------------------------------------------------</para><para>　CmycurD：转换人民币小写金额为大写</para><para>　CmycurD：一个重载，将字符串先转换成数字在调用CmycurD(decimal num)</para></summary>
    public class RMBHelper
    {
        /// <summary>转换人民币大小金额</summary>
        /// <param name="LowerMoney">金额</param>
        /// <returns>返回大写形式</returns>
        public static string CmycurD(decimal LowerMoney) { return CmycurD(LowerMoney.ToString()); }

        /// <summary>转换人民币大小金额</summary>
        /// <param name="LowerMoney">金额</param>
        /// <returns>返回大写形式</returns>
        public static string CmycurD(string LowerMoney)
        {
            Dictionary<string, int> dictionary1;
            string str = null;
            bool flag;
            string str2;
            string str3;
            string str4;
            int num;
            double num2;
            string str5;
            int num3;
            int num4;
            goto Label_0957;
        Label_0007:
            str = str4;
            if (!flag) return str;
            return ("负" + str);
        Label_0040:
            while (str4.Substring(0, 1) == "整")
            {
                str4 = "零圆整";
                break;
            }
            goto Label_0007;
        Label_0057:
            if (str4.Substring(0, 1) == "角") goto Label_0117;
        Label_0083:
            if (!(str4.Substring(0, 1) == "分")) goto Label_0040;
            if ((((uint) num2) & 0) != 0) goto Label_063B;
            if ((((uint) num4) | 8) != 0)
            {
                if (0 != 0)
                {
                    if (((uint) num) < 0) goto Label_0007;
                    goto Label_0672;
                }
                str4 = str4.Substring(1, str4.Length - 1);
                goto Label_0040;
            }
            goto Label_0007;
        Label_00CF:
            str4 = str4.Substring(1, str4.Length - 1);
            goto Label_0057;
        Label_00E7:
            if (str4.Substring(0, 1) == "零") goto Label_00CF;
            if (((uint) num4) - ((uint) num3) >= 0) goto Label_0057;
        Label_0117:
            str4 = str4.Substring(1, str4.Length - 1);
            if (((uint) num4) > uint.MaxValue) goto Label_0057;
            goto Label_0083;
        Label_0177:
            if (-2 == 0) goto Label_03A6;
            str4 = str4.Replace("零万", "万").Replace("零圆", "圆");
            if ((((uint) flag) | 3) == 0) goto Label_063B;
            str4 = str4.Replace("零零", "零");
            if (!(str4.Substring(0, 1) == "圆")) goto Label_09A3;
            str4 = str4.Substring(1, str4.Length - 1);
            goto Label_00E7;
        Label_0334:
            do
            {
                if (num <= str2.Length)
                {
                    str5 = str2.Substring(str2.Length - num, 1);
                    if (str5 != null) goto Label_07DA;
                    if (((uint) num2) < 0) goto Label_03A6;
                    goto Label_063B;
                }
                str4 = str4.Replace("零拾", "零").Replace("零佰", "零");
            }
            while (0x7fffffff == 0);
            if (((uint) flag) - ((uint) num4) < 0) goto Label_0957;
            if (((uint) num) <= uint.MaxValue)
            {
                if (((uint) flag) + ((uint) num) <= uint.MaxValue)
                {
                Label_02DF:
                    str4 = str4.Replace("零仟", "零");
                    if (-2 == 0) goto Label_08E4;
                    str4 = str4.Replace("零零零", "零");
                    if (((uint) num4) >= 0)
                    {
                        str4 = str4.Replace("零零", "零");
                        if (((uint) num2) - ((uint) num2) < 0) goto Label_063B;
                        str4 = str4.Replace("零角零分", "整");
                        str4 = str4.Replace("零分", "整").Replace("零角", "零");
                        if (((uint) num4) - ((uint) num3) > uint.MaxValue) goto Label_0947;
                        str4 = str4.Replace("零亿零万零圆", "亿圆").Replace("亿零万零圆", "亿圆");
                        if (((uint) num) - ((uint) num3) > uint.MaxValue) goto Label_02DF;
                    }
                    str4 = str4.Replace("零亿零万", "亿").Replace("零万零圆", "万圆").Replace("零亿", "亿");
                    goto Label_0177;
                }
                goto Label_09A3;
            }
        Label_039B:;
            str3 = str3 ?? "";
        Label_03A6:
            str4 = str3 + str4;
            if ((((uint) num3) & 0) != 0) goto Label_08B2;
            num++;
            goto Label_0334;
        Label_0400:
            str3 = str3 + "仟";
            if (((uint) num4) - ((uint) flag) <= uint.MaxValue)
            {
                if (-2 == 0) goto Label_08AF;
                goto Label_03A6;
            }
        Label_04AB:
            if (((uint) num3) + ((uint) num4) > uint.MaxValue) goto Label_0611;
            goto Label_03A6;
        Label_04E6:
            str3 = str3 + "仟";
            goto Label_03A6;
        Label_0611:
            if (<PrivateImplementationDetails>{39776D4E-BD2B-4869-B1BF-55ECE1518985}.$$method0x6000133-1.TryGetValue(str5, out num3))
            {
                switch (num3)
                {
                    case 0:
                        str3 = "圆";
                        goto Label_063B;

                    case 1:
                        goto Label_071F;

                    case 2:
                        str3 = "壹";
                        if (((uint) num3) - ((uint) num4) >= 0) goto Label_063B;
                        goto Label_092E;

                    case 3:
                        str3 = "贰";
                        goto Label_063B;

                    case 4:
                        str3 = "叁";
                        goto Label_063B;

                    case 5:
                        str3 = "肆";
                        goto Label_063B;

                    case 6:
                        goto Label_0672;

                    case 7:
                        str3 = "陆";
                        goto Label_063B;

                    case 8:
                        str3 = "柒";
                        goto Label_063B;

                    case 9:
                        goto Label_0657;

                    case 10:
                        str3 = "玖";
                        goto Label_063B;
                }
            }
            else if (((uint) num2) > uint.MaxValue) goto Label_04E6;
        Label_063B:
            num4 = num;
            switch (num4)
            {
                case 1:
                    str3 = str3 + "分";
                    if (((uint) num) - ((uint) num4) >= 0) goto Label_03A6;
                    goto Label_04AB;

                case 2:
                    str3 = str3 + "角";
                    goto Label_03A6;

                case 3:
                    if (str3 != null) goto Label_053F;
                    str3 = "";
                    goto Label_03A6;

                case 4:
                    str3 = str3 ?? "";
                    if ((((uint) num) & 0) != 0) goto Label_04E6;
                    goto Label_03A6;

                case 5:
                    str3 = str3 + "拾";
                    goto Label_03A6;

                case 6:
                    str3 = str3 + "佰";
                    goto Label_03A6;

                case 7:
                    goto Label_04E6;

                case 8:
                    str3 = str3 + "万";
                    goto Label_04AB;

                case 9:
                    str3 = str3 + "拾";
                    goto Label_03A6;

                case 10:
                    str3 = str3 + "佰";
                    goto Label_03A6;

                case 11:
                    str3 = str3 + "仟";
                    goto Label_03A6;

                case 12:
                    str3 = str3 + "亿";
                    goto Label_03A6;

                case 13:
                    str3 = str3 + "拾";
                    goto Label_03A6;

                case 14:
                    str3 = str3 + "佰";
                    if (0 != 0) goto Label_07DA;
                    if (((uint) num) - ((uint) num4) <= uint.MaxValue) goto Label_03A6;
                    goto Label_0400;

                case 15:
                    goto Label_0400;

                case 0x10:
                    str3 = str3 + "万";
                    if (((uint) num4) > uint.MaxValue)
                    {
                    }
                    goto Label_03A6;

                default:
                    if (3 != 0 && 0 == 0) goto Label_039B;
                    goto Label_063B;
            }
        Label_0657:
            str3 = "捌";
            goto Label_063B;
        Label_0672:
            str3 = "伍";
            goto Label_063B;
        Label_071F:
            str3 = "零";
            if (4 != 0)
            {
                if (((uint) num3) - ((uint) num4) <= uint.MaxValue) goto Label_063B;
                goto Label_086E;
            }
        Label_072F:
            dictionary1 = new Dictionary<string, int>(11);
            dictionary1.Add(".", 0);
            dictionary1.Add("0", 1);
            dictionary1.Add("1", 2);
            dictionary1.Add("2", 3);
            dictionary1.Add("3", 4);
            dictionary1.Add("4", 5);
            dictionary1.Add("5", 6);
            dictionary1.Add("6", 7);
            dictionary1.Add("7", 8);
            dictionary1.Add("8", 9);
            dictionary1.Add("9", 10);
            <PrivateImplementationDetails>{39776D4E-BD2B-4869-B1BF-55ECE1518985}.$$method0x6000133-1 = dictionary1;
            if ((((uint) num) & 0) == 0) goto Label_0611;
        Label_07DA:
            if (<PrivateImplementationDetails>{39776D4E-BD2B-4869-B1BF-55ECE1518985}.$$method0x6000133-1 == null) goto Label_072F;
            goto Label_0611;
        Label_0825:
            str2 = LowerMoney;
            num = 1;
            str4 = "";
            goto Label_0334;
        Label_086E:
            if (LowerMoney.IndexOf(".") != LowerMoney.Length - 2) goto Label_0825;
            if ((((uint) num) & 0) == 0)
            {
                LowerMoney = LowerMoney + "0";
                goto Label_0825;
            }
            goto Label_063B;
        Label_08AF:
            num = 0;
        Label_08B2:
            num2 = Math.Round(double.Parse(LowerMoney), 2);
            if (((uint) num) - ((uint) num3) > uint.MaxValue) goto Label_0657;
            LowerMoney = num2.ToString();
        Label_08E4:
            if (((uint) num4) < 0) goto Label_00E7;
            if (LowerMoney.IndexOf(".") <= 0)
            {
                LowerMoney = LowerMoney + ".00";
                goto Label_0825;
            }
            if (((uint) num) - ((uint) flag) >= 0) goto Label_086E;
        Label_0913:
            str3 = null;
            if ((((uint) flag) & 0) == 0)
            {
                str4 = null;
                goto Label_08AF;
            }
            goto Label_086E;
        Label_092E:
            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {
                LowerMoney = LowerMoney.Trim().Remove(0, 1);
                flag = true;
                if (((uint) num2) > uint.MaxValue)
                {
                    if ((((uint) num4) | uint.MaxValue) == 0) goto Label_0177;
                    goto Label_071F;
                }
            }
        Label_0947:
            str2 = null;
            goto Label_0913;
        Label_0957:
            flag = false;
            goto Label_092E;
        Label_09A3:
            if (((uint) num3) >= 0)
            {
                if ((((uint) num2) & 0) == 0) goto Label_00E7;
                goto Label_00CF;
            }
            return str;
        }
    }
}
