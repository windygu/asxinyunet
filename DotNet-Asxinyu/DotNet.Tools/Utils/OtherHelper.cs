namespace Utils
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary><para>　</para>
    /// 类名：常用工具类——其它杂项
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-------------------------------------------------</para><para>　CreateBar39：生成39码条形码,请生成的条码文件置于静态控件中：Literal[ +2重载 ]</para><para>　CreateBarEAN13：生成EAN-13码条形码,请生成的条码文件置于静态控件中：Literal</para><para>　AsynWebUrl：通过WebRequest异步访问地址并返回值</para></summary>
    public class OtherHelper
    {
        /// <summary>
        /// 通过WebRequest异步访问地址并返回值
        /// <para>　注意：如果WebUrl中带有中文字符，并须先进行编码再传入：</para><para>　HttpUtility.UrlEncode(CONTENT, Encoding.GetEncoding("gb2312"));</para></summary>
        /// <param name="WebUrl">访问地址</param>
        /// <returns></returns>
        public static string AsynWebUrl(string WebUrl)
        {
            string str = string.Empty;
            try
            {
                WebResponse response;
                WebRequest request = WebRequest.Create(WebUrl);
                goto Label_0021;
            Label_000F:
                response.Close();
                do
                {
                    StreamReader reader;
                    reader.Close();
                }
                while (0 != 0);
                return str;
            Label_0021:
                response = request.GetResponse();
                str = new StreamReader(response.GetResponseStream(), Encoding.Default).ReadToEnd();
            }
            catch (Exception)
            {
            }
            goto Label_000F;
        }

        /// <summary>生成39码条形码,请生成的条码文件置于静态控件中：Literal</summary>
        /// <param name="CodeText">条码文字</param>
        /// <param name="CodeLineWidth">线条宽度：０为默认值：2</param>
        /// <param name="CodeLineHeight">线条高度：0为默认值：60</param>
        /// <param name="CodeTextColor">条码底部文字颜色[Color颜色：Color.red]，为空或null默认为黑色</param>
        /// <param name="CodeLineColor">条码线条颜色[Color颜色：Color.red],为空或null为默认黑色</param>
        /// <returns></returns>
        public static string CreateBar39(string CodeText, int CodeLineWidth, int CodeLineHeight, Color CodeTextColor, Color CodeLineColor) { return CreateBar39(CodeText, CodeLineWidth, CodeLineHeight, CodeTextColor.Name, CodeLineColor.Name); }

        /// <summary>生成39码条形码,请生成的条码文件置于静态控件中：Literal</summary>
        /// <param name="CodeText">和码文字</param>
        /// <param name="CodeLineWidth">线条宽度：０为默认值：2</param>
        /// <param name="CodeLineHeight">线条高度：0为默认值：60</param>
        /// <param name="CodeTextColor">条码底部文字颜色[字符串颜色：#000000]，为空或null默认为黑色</param>
        /// <param name="CodeLineColor">条码线条颜色[字符串颜色：#000000],为空或null为默认黑色</param>
        /// <returns></returns>
        public static string CreateBar39(string CodeText, int CodeLineWidth, int CodeLineHeight, string CodeTextColor, string CodeLineColor)
        {
            // Translated Error! 未将对象引用设置到对象的实例。
        }

        /// <summary>生成EAN-13码条形码,请生成的条码文件置于静态控件中：Literal</summary>
        /// <param name="CodeText">条码文字</param>
        /// <param name="CodeLineWidth">条码线条宽度：0为默认值：２</param>
        /// <param name="CodeLineHeight">条码线条高度：０为默认值：100</param>
        /// <param name="CodeTextColor">条码文字颜色[字符串颜色：#000000]：为空或null为默认黑色</param>
        /// <param name="CodeLineColor">条码线条颜色[字符串颜色：#000000]：为空或null为默认黑色</param>
        /// <returns></returns>
        public static string CreateBarEAN13(string CodeText, int CodeLineWidth, int CodeLineHeight, Color CodeTextColor, Color CodeLineColor) { return CreateBarEAN13(CodeText, CodeLineWidth, CodeLineHeight, CodeTextColor.Name, CodeLineColor.Name); }

        /// <summary>生成EAN-13码条形码,请生成的条码文件置于静态控件中：Literal</summary>
        /// <param name="CodeText">条码文字</param>
        /// <param name="CodeLineWidth">条码线条宽度：0为默认值：２</param>
        /// <param name="CodeLineHeight">条码线条高度：０为默认值：100</param>
        /// <param name="CodeTextColor">条码文字颜色[字符串颜色：#000000]：为空或null为默认黑色</param>
        /// <param name="CodeLineColor">条码线条颜色[字符串颜色：#000000]：为空或null为默认黑色</param>
        /// <returns></returns>
        public static string CreateBarEAN13(string CodeText, int CodeLineWidth, int CodeLineHeight, string CodeTextColor, string CodeLineColor)
        {
            int num2;
            int num6;
            int num8;
            bool flag;
            char ch;
            int num9;
            int num10;
            char ch2;
            char ch3;
            char ch4;
            string str8;
            object[] objArray;
            object obj4;
            object[] objArray4;
            object obj6;
            object[] objArray5;
            object obj7;
            object[] objArray6;
            object[] objArray7;
            object obj11;
            object[] objArray10;
            object[] objArray11;
            object obj13;
            object[] objArray12;
            object obj16;
            object[] objArray15;
            object[] objArray17;
            int num = -1;
            if ((((uint) CodeLineHeight) | 0x7fffffff) != 0) goto Label_116C;
            CodeLineHeight = CodeLineHeight;
            if (CodeLineWidth != 0) goto Label_1174;
            CodeLineWidth = 100;
        Label_10CF:;
            if (!Regex.IsMatch(CodeText, @"^\d{12}$")) goto Label_1150;
            if ((((uint) num8) & 0) == 0) goto Label_1105;
        Label_10F3:
            if (((uint) num2) > uint.MaxValue) goto Label_10CF;
        Label_1105:
            num2 = 0;
            int num3 = 0;
            int num4 = 0;
            if (((uint) num8) < 0) goto Label_101B;
        Label_107E:;
            if (num4 < 12)
            {
                if (num4 % 2 == 0) goto Label_1098;
                goto Label_1062;
            }
            int num5 = (10 - (num2 * 3 + num3) % 10) % 10;
        Label_101B:
            if (num <= 0) goto Label_1000;
        Label_0FFB:
            if (num != num5) return "输入的校验码错误！";
        Label_1000:
            CodeText = CodeText + num5;
            string str = "";
            if ((((uint) num9) & 0) != 0) goto Label_107E;
            str = str + "000000000101";
            string str2 = x81aa5d3861d55fc4(CodeText[0]);
            if (((uint) num5) - ((uint) CodeLineWidth) > uint.MaxValue) goto Label_1062;
            if (((uint) num6) < 0)
            {
            }
        Label_0F66:
            num6 = 1;
        Label_0F4E:
            if (num6 < 7) goto Label_0F6B;
            str = str + "01010";
            int num7 = 7;
            if (num7 < 13)
            {
                str = str + x4fe4f3d6dd336681(CodeText[num7], 'C');
                num7++;
                goto Label_0F6B;
            }
            if (((uint) num) - ((uint) num3) > uint.MaxValue) goto Label_0085;
            str = str + "101000000000";
            string str3 = "";
            string str4 = "";
            if (string.IsNullOrEmpty(CodeLineColor)) goto Label_0E96;
            string str5 = CodeLineColor;
        Label_0E72:;
            if (string.IsNullOrEmpty(CodeTextColor)) goto Label_0E7B;
            string str6 = CodeTextColor;
        Label_0E7D:
            num8 = CodeLineWidth * 5;
            string str7 = "OCR-B-10 BT";
            if (((uint) num8) - ((uint) num7) >= 0) goto Label_0E6D;
        Label_0EB9:;
            FontFamily[] families = FontFamily.Families;
            int index = 0;
            if (index >= families.Length)
            {
                if (!flag)
                {
                    str7 = "楷体";
                    if ((((uint) num6) | uint.MaxValue) == 0) goto Label_0884;
                }
                str8 = str;
                if (((uint) CodeLineHeight) <= uint.MaxValue) goto Label_0D7B;
            }
            FontFamily family = families[index];
            if (((uint) flag) - ((uint) num7) >= 0 && family.Name != str7) goto Label_0E6D;
            flag = true;
            if ((((uint) num4) | uint.MaxValue) == 0) goto Label_0F6B;
            index++;
        Label_0D7B:;
            int num12 = 0;
        Label_0C38:
            if (num12 < str8.Length) goto Label_0D83;
            str3 = str3 + "<div style=\"clear:both\"></div>";
            object obj3 = str3;
            object[] objArray2 = new object[8];
            if (((uint) num2) + ((uint) num9) <= uint.MaxValue) goto Label_0BCB;
        Label_0AE7:;
            object[] objArray3 = new object[8];
            objArray3[0] = obj4;
            objArray3[1] = "<div style=\"float:left;width:";
            objArray3[2] = CodeLineWidth;
        Label_0A71:
            objArray3[3] = "px;height:";
            objArray3[4] = num8;
            objArray3[5] = "px;background:";
            objArray3[6] = str5;
            objArray3[7] = ";\"></div>";
            str3 = string.Concat(objArray3);
            if (((uint) num12) - ((uint) CodeLineHeight) > uint.MaxValue)
            {
            }
            if (((uint) CodeLineWidth) - ((uint) num5) >= 0)
            {
                object obj5 = str3;
                objArray4 = new object[6];
                objArray4[0] = obj5;
            }
            if ((((uint) num12) | 0x7fffffff) != 0)
            {
                objArray4[1] = "<div style=\"float:left;width:";
                objArray4[2] = CodeLineWidth;
                objArray4[3] = "px;height:";
                objArray4[4] = num8;
                objArray4[5] = "px;background:#FFFFFF;\"></div>";
                goto Label_09E3;
            }
        Label_0B1B:
            objArray5[6] = str5;
            objArray5[7] = ";\"></div>";
            str3 = string.Concat(objArray5);
            num9 = 1;
            if (num9 < 7)
            {
                obj7 = str3;
                objArray6 = new object[8];
                if (((uint) num7) + ((uint) num7) <= uint.MaxValue) goto Label_08FA;
                goto Label_0AE7;
            }
            object obj8 = str3;
        Label_0884:
            objArray7 = new object[6];
            objArray7[0] = obj8;
            if (((uint) num9) + ((uint) CodeLineWidth) <= uint.MaxValue) goto Label_0854;
        Label_08AA:
            objArray7[3] = "px;height:";
            objArray7[4] = num8;
            objArray7[5] = "px;background:#FFFFFF;\"></div>";
            str3 = string.Concat(objArray7);
            object obj9 = str3;
            object[] objArray8 = new object[8];
            objArray8[0] = obj9;
            objArray8[1] = "<div style=\"float:left;width:";
        Label_0781:
            objArray8[2] = CodeLineWidth;
            objArray8[3] = "px;height:";
            objArray8[4] = num8;
            objArray8[5] = "px;background:";
            if ((((uint) num6) | 0xfffffffe) != 0) goto Label_0716;
            if (((uint) CodeLineWidth) + ((uint) index) >= 0) goto Label_0AE7;
            if (((uint) CodeLineWidth) - ((uint) num) <= uint.MaxValue) goto Label_08FA;
            if ((((uint) CodeLineHeight) & 0) == 0) goto Label_0869;
        Label_0854:
            objArray7[1] = "<div style=\"float:left;width:";
        Label_085D:
            objArray7[2] = CodeLineWidth;
            goto Label_08AA;
        Label_0869:;
            str3 = string.Concat(objArray6);
            num9++;
        Label_08FA:
            if ((((uint) num7) & 0) != 0) goto Label_05D8;
            objArray6[0] = obj7;
            objArray6[1] = "<div style=\"float:left;width:";
        Label_0920:
            objArray6[2] = CodeLineWidth * 7;
            objArray6[3] = "px;color:";
            if (((uint) index) > uint.MaxValue) goto Label_0A71;
            objArray6[4] = str6;
            objArray6[5] = ";text-align:center;\">";
            objArray6[6] = CodeText[num9];
            objArray6[7] = "</div>";
            goto Label_0869;
        Label_09E3:
            obj6 = string.Concat(objArray4);
            objArray5 = new object[8];
        Label_09F8:
            objArray5[0] = obj6;
            objArray5[1] = "<div style=\"float:left;width:";
            if (((uint) num7) <= uint.MaxValue)
            {
                objArray5[2] = CodeLineWidth;
                objArray5[3] = "px;height:";
                objArray5[4] = num8;
                if (((uint) num8) + ((uint) num4) < 0) goto Label_0188;
                objArray5[5] = "px;background:";
                if ((((uint) num8) | 8) == 0) goto Label_09E3;
            }
            goto Label_0B1B;
        Label_0716:
            objArray8[6] = str5;
            objArray8[7] = ";\"></div>";
            object obj10 = string.Concat(objArray8);
            object[] objArray9 = new object[6];
            objArray9[0] = obj10;
        Label_06F5:
            objArray9[1] = "<div style=\"float:left;width:";
            objArray9[2] = CodeLineWidth;
            if (((uint) num8) > uint.MaxValue) goto Label_09F8;
            objArray9[3] = "px;height:";
            objArray9[4] = num8;
            objArray9[5] = "px;background:#FFFFFF;\"></div>";
            str3 = string.Concat(objArray9);
            if (2 != 0)
            {
                if (((uint) num4) + ((uint) index) < 0)
                {
                    if (((uint) num8) - ((uint) num5) >= 0) goto Label_101B;
                    goto Label_1000;
                }
                if ((((uint) num6) | 0xff) == 0) goto Label_009B;
                if (((uint) num2) + ((uint) num4) < 0) goto Label_085D;
                if (((uint) num7) < 0) goto Label_06F5;
            }
            if (((uint) CodeLineWidth) + ((uint) CodeLineWidth) <= uint.MaxValue)
            {
                obj11 = str3;
                objArray10 = new object[8];
            }
            objArray10[0] = obj11;
            objArray10[1] = "<div style=\"float:left;width:";
            if (((uint) num5) - ((uint) num5) > uint.MaxValue) goto Label_0FFB;
            objArray10[2] = CodeLineWidth;
            if (((uint) index) + ((uint) num3) > uint.MaxValue) goto Label_0716;
            if (0 == 0)
            {
                objArray10[3] = "px;height:";
                goto Label_05CD;
            }
        Label_0768:
            if ((((uint) CodeLineWidth) | 4) == 0) goto Label_0F66;
            if (((uint) num12) - ((uint) num5) < 0) goto Label_0E6D;
            objArray11[3] = "px;height:";
            objArray11[4] = num8;
            if (((uint) num8) - ((uint) num3) > uint.MaxValue) goto Label_0024;
            objArray11[5] = "px;background:#FFFFFF;\"></div>";
            str3 = string.Concat(objArray11);
            if (((uint) num6) - ((uint) num10) < 0) goto Label_039B;
        Label_04B2:
            num10 = 7;
            if ((((uint) flag) | 15) == 0) goto Label_0E96;
            if (num10 < 13)
            {
                obj13 = str3;
                objArray12 = new object[8];
                goto Label_0464;
            }
        Label_039B:;
            object obj14 = str3;
            object[] objArray13 = new object[8];
            if ((((uint) num4) | 1) != 0) goto Label_0351;
        Label_0411:
            objArray12[1] = "<div style=\"float:left;width:";
            objArray12[2] = CodeLineWidth * 7;
            if (0 != 0) goto Label_0D05;
            objArray12[3] = "px;color:";
        Label_03E6:
            objArray12[4] = str6;
            objArray12[5] = ";text-align:center;\">";
            objArray12[6] = CodeText[num10];
            objArray12[7] = "</div>";
            str3 = string.Concat(objArray12);
            num10++;
        Label_0351:
            if (((uint) num6) + ((uint) CodeLineWidth) < 0) goto Label_0E7D;
            objArray13[0] = obj14;
            objArray13[1] = "<div style=\"float:left;width:";
            if ((((uint) num3) | 0x7fffffff) == 0) goto Label_0BCB;
            if (((uint) CodeLineWidth) + ((uint) index) < 0) goto Label_0716;
            objArray13[2] = CodeLineWidth;
            objArray13[3] = "px;height:";
            objArray13[4] = num8;
            objArray13[5] = "px;background:";
            if (((uint) num2) - ((uint) num) > uint.MaxValue) goto Label_0E72;
            objArray13[6] = str5;
            if (((uint) num6) - ((uint) num) > uint.MaxValue) goto Label_0781;
            objArray13[7] = ";\"></div>";
            str3 = string.Concat(objArray13);
            if ((((uint) num4) & 0) != 0)
            {
                if (((uint) num3) - ((uint) num6) < 0) goto Label_101B;
                goto Label_0FFB;
            }
            object obj15 = str3;
            object[] objArray14 = new object[6];
            if ((((uint) CodeLineWidth) | 1) == 0)
            {
            }
            objArray14[0] = obj15;
            objArray14[1] = "<div style=\"float:left;width:";
            objArray14[2] = CodeLineWidth;
            objArray14[3] = "px;height:";
            objArray14[4] = num8;
            objArray14[5] = "px;background:#FFFFFF;\"></div>";
            if (0 == 0)
            {
                if (((uint) index) > uint.MaxValue) goto Label_03E6;
                str3 = string.Concat(objArray14);
                obj16 = str3;
            }
            if (((uint) CodeLineHeight) >= 0) goto Label_01DD;
        Label_0B44:
            if (((uint) num8) - ((uint) index) < 0) goto Label_0E96;
        Label_11AE:
            return string.Concat(objArray17);
        Label_0007:
            objArray17[4] = "';\">";
            objArray17[5] = str3;
            objArray17[6] = "</div>";
            if (((uint) num7) - ((uint) CodeLineWidth) <= uint.MaxValue) goto Label_0B44;
            if (((uint) num10) <= uint.MaxValue) goto Label_0AE7;
            goto Label_0716;
        Label_0C62:
            if (((uint) num10) + ((uint) num10) < 0) goto Label_0CAB;
            str3 = string.Concat(objArray);
        Label_0C83:
            num12++;
            goto Label_0C38;
        Label_0CAB:
            objArray[4] = CodeLineHeight;
            if ((((uint) flag) & 0) != 0) goto Label_0BE0;
            objArray[5] = "px;float:left;background:";
            if (((uint) CodeLineHeight) > uint.MaxValue) goto Label_107A;
            objArray[6] = str4;
            objArray[7] = ";\"></div>";
            goto Label_0C62;
        Label_0D05:
            objArray[3] = "px;height:";
            if (((uint) num2) - ((uint) num2) < 0) goto Label_1150;
            if ((((uint) num3) & 0) == 0) goto Label_0CAB;
        Label_0D4A:
            if (ch == '0') goto Label_0D54;
            str4 = str5;
            object obj2 = str3;
            objArray = new object[8];
            objArray[0] = obj2;
            objArray[1] = "<div style=\"width:";
            if (((uint) flag) - ((uint) num9) >= 0)
            {
                if (((uint) index) - ((uint) flag) <= uint.MaxValue)
                {
                    objArray[2] = CodeLineWidth;
                    goto Label_0D05;
                }
                goto Label_11AE;
            }
            goto Label_0E96;
        Label_0F6B:
            str = str + x4fe4f3d6dd336681(CodeText[num6], str2[num6 - 1]);
            num6++;
            goto Label_0F4E;
        Label_1062:
            ch4 = CodeText[num4];
            num2 += int.Parse(ch4.ToString());
        Label_107A:
            num4++;
        Label_1098:
            ch3 = CodeText[num4];
            num3 += int.Parse(ch3.ToString());
            goto Label_107A;
        Label_110D:
            ch2 = CodeText[12];
            num = int.Parse(ch2.ToString());
            CodeText = CodeText.Substring(0, 12);
            goto Label_10F3;
        Label_1150:
            if (!Regex.IsMatch(CodeText, @"^\d{13}$")) return "存在不允许的字符！";
            goto Label_110D;
        Label_0024:
            str3 = str3 + "<div style=\"clear:both\"></div>";
            objArray17 = new object[7];
            objArray17[0] = "<div style=\"background:#FFFFFF;padding:0px;font-size:";
            objArray17[1] = CodeLineWidth * 10;
            objArray17[2] = "px;font-family:'";
            objArray17[3] = str7;
            if (((uint) num7) + ((uint) num3) >= 0) goto Label_0007;
        Label_00DC:
            objArray15[7] = ";\"></div>";
            str3 = string.Concat(objArray15);
            object obj17 = str3;
            object[] objArray16 = new object[4];
            objArray16[0] = obj17;
            if (((uint) num5) + ((uint) num12) <= uint.MaxValue)
            {
                objArray16[1] = "<div style=\"float:left;color:#000000;width:";
                goto Label_0085;
            }
        Label_011B:
            if (((uint) num4) + ((uint) CodeLineHeight) <= uint.MaxValue) goto Label_0024;
            goto Label_0007;
        Label_0085:
            objArray16[2] = CodeLineWidth * 9;
            objArray16[3] = "px;\"></div>";
        Label_009B:
            str3 = string.Concat(objArray16);
            if ((((uint) index) | 0x7fffffff) == 0) goto Label_0920;
            if (((uint) num5) - ((uint) num) < 0) goto Label_0E7B;
            goto Label_011B;
        Label_0188:
            objArray15[6] = str5;
            goto Label_00DC;
        Label_01DD:
            objArray15 = new object[8];
            objArray15[0] = obj16;
            if (((uint) index) - ((uint) num7) < 0) goto Label_0FFB;
            objArray15[1] = "<div style=\"float:left;width:";
            if ((((uint) num7) & 0) == 0)
            {
                objArray15[2] = CodeLineWidth;
                if (((uint) num) - ((uint) num8) < 0)
                {
                    if (((uint) num9) + ((uint) num7) >= 0) goto Label_110D;
                    goto Label_1150;
                }
                objArray15[3] = "px;height:";
                if (((uint) num7) < 0) goto Label_05CD;
                objArray15[4] = num8;
                objArray15[5] = "px;background:";
                goto Label_0188;
            }
        Label_0464:
            objArray12[0] = obj13;
            if (((uint) num10) - ((uint) index) > uint.MaxValue) goto Label_0C83;
            if (((uint) num) > uint.MaxValue)
            {
            }
            goto Label_0411;
        Label_0D54:
            ch = str8[num12];
            goto Label_0D4A;
        Label_0E6D:
            flag = false;
            goto Label_0EB9;
        Label_05CD:
            objArray10[4] = num8;
        Label_05D8:
            objArray10[5] = "px;background:";
            objArray10[6] = str5;
            while (true)
            {
                if (((uint) num6) > uint.MaxValue) goto Label_04B2;
                objArray10[7] = ";\"></div>";
                str3 = string.Concat(objArray10);
                object obj12 = str3;
                objArray11 = new object[6];
                objArray11[0] = obj12;
                objArray11[1] = "<div style=\"float:left;width:";
                objArray11[2] = CodeLineWidth;
                if ((((uint) num3) & 0) == 0) goto Label_0768;
            }
        Label_0BCB:
            if (((uint) num4) < 0) goto Label_01DD;
        Label_0BE0:
            objArray2[0] = obj3;
            objArray2[1] = "<div style=\"float:left;color:";
            if (((uint) CodeLineWidth) > uint.MaxValue) goto Label_009B;
            objArray2[2] = str6;
            if (((uint) num12) < 0) goto Label_0F4E;
            objArray2[3] = ";width:";
            objArray2[4] = CodeLineWidth * 9;
            objArray2[5] = "px;text-align:center;\">";
            objArray2[6] = CodeText[0];
            if (((uint) num) - ((uint) num7) <= uint.MaxValue)
            {
                objArray2[7] = "</div>";
                str3 = string.Concat(objArray2);
                obj4 = str3;
                if (((uint) num6) <= uint.MaxValue) goto Label_0AE7;
                goto Label_0C62;
            }
            goto Label_0D54;
        Label_116C:;
        }

        private static string x4fe4f3d6dd336681(char x3c4da2980d043c95, char x43163d22e8cd5a71)
        {
            switch (x43163d22e8cd5a71)
            {
                case 'A':
                    switch (x3c4da2980d043c95)
                    {
                        case '0':
                            return "0001101";

                        case '1':
                            return "0011001";

                        case '2':
                            return "0010011";

                        case '3':
                            return "0111101";

                        case '4':
                            return "0100011";

                        case '5':
                            goto Label_0125;

                        case '6':
                            return "0101111";

                        case '7':
                            goto Label_00F9;

                        case '8':
                            return "0110111";

                        case '9':
                            return "0001011";
                    }
                    return "Error!";

                case 'B':
                    switch (x3c4da2980d043c95)
                    {
                        case '0':
                            return "0100111";

                        case '1':
                            return "0110011";

                        case '2':
                            break;

                        case '3':
                            return "0100001";

                        case '4':
                            return "0011101";

                        case '5':
                            return "0111001";

                        case '6':
                            return "0000101";

                        case '7':
                            return "0010001";

                        case '8':
                            return "0001001";

                        case '9':
                            return "0010111";

                        default:
                            if (0 == 0)
                            {
                                if (0 == 0) return "Error!";
                                break;
                            }
                            if (0 != 0) goto Label_0125;
                            goto Label_00F9;
                    }
                    goto Label_0125;

                case 'C':
                    switch (x3c4da2980d043c95)
                    {
                        case '0':
                            return "1110010";

                        case '1':
                            return "1100110";

                        case '2':
                            return "1101100";

                        case '3':
                            return "1000010";

                        case '4':
                            return "1011100";

                        case '5':
                            return "1001110";

                        case '6':
                            return "1010000";

                        case '7':
                            return "1000100";

                        case '8':
                            return "1001000";

                        case '9':
                            return "1110100";
                    }
                    return "Error!";

                default:
                    return "Error!";
            }
            return "0011011";
        Label_00F9:
            return "0111011";
        Label_0125:
            return "0110001";
        }

        private static string x81aa5d3861d55fc4(char x3c4da2980d043c95)
        {
            switch (x3c4da2980d043c95)
            {
                case '0':
                    return "AAAAAA";

                case '1':
                    return "AABABB";

                case '2':
                    return "AABBAB";

                case '3':
                    return "AABBBA";

                case '4':
                    return "ABAABB";

                case '5':
                    return "ABBAAB";

                case '6':
                    return "ABBBAA";

                case '7':
                    return "ABABAB";

                case '8':
                    return "ABABBA";

                case '9':
                    return "ABBABA";
            }
            return "Error!";
        }
    }
}
