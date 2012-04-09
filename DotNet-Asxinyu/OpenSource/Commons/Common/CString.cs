namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CString
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AcquireAssignString(string str, int num)
        {
            string str2 = str;
            return StringToHtml(GetLetter(str2, num, false));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AddBlankAtForefront(string str)
        {
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AddZero(int sheep, int length)
        {
            return AddZero(sheep.ToString(), length);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AddZero(string sheep, int length)
        {
            StringBuilder builder = new StringBuilder(sheep);
            for (int i = builder.Length; i < length; i++)
            {
                builder.Insert(0, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b76));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool CheckValidity(string s)
        {
            string str = s;
            if (((((str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4658)) > 0) || (str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x465e)) > 0)) || ((str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4664)) > 0) || (str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x466a)) > 0))) || ((str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4670)) > 0) || (str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4676)) > 0))) || (str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x467c)) > 0))
            {
                return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ClearTag(string sHtml)
        {
            if (sHtml == "")
            {
                return "";
            }
            string str = sHtml;
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4698), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.Replace(sHtml, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ClearTag(string sHtml, string sRegex)
        {
            string str = sHtml;
            Regex regex = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.Replace(sHtml, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ConvertToJS(string sHtml)
        {
            StringBuilder builder = new StringBuilder();
            string[] strArray = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4728), RegexOptions.IgnoreCase).Split(sHtml);
            foreach (string str in strArray)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4734) + str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x475c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4762)) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x476a));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DelHtmlString(string str)
        {
            string[] strArray = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4806), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x483e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x48f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4916), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4932), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x494c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4964), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x497c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x499a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x49ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x49d8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x49f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a16), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a2a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a34) };
            string[] strArray2 = new string[] { "", "", "", kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a48), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a4e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a54), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a5a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a60), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a66), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a6c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a72), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a78), "", kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a7e), "" };
            string input = str;
            for (int i = 0; i < strArray.Length; i++)
            {
                input = new Regex(strArray[i], RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, strArray2[i]);
            }
            input.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a86), "");
            input.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a8c), "");
            input.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a92), "");
            return input;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DelTag(string str, string tag, bool isContent)
        {
            if ((tag == null) || (tag == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4a9a)))
            {
                return str;
            }
            if (isContent)
            {
                return Regex.Replace(str, string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4aa0), tag), "", RegexOptions.IgnoreCase);
            }
            return Regex.Replace(str, string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4adc), tag), "", RegexOptions.IgnoreCase);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DelTagArray(string str, string tagA, bool isContent)
        {
            string[] strArray = tagA.Split(new char[] { ',' });
            foreach (string str2 in strArray)
            {
                str = DelTag(str, str2, isContent);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetAllLinkText(string html)
        {
            StringBuilder builder = new StringBuilder();
            Match match = Regex.Match(html.ToLower(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c1a));
            while (match.Success)
            {
                builder.AppendLine(match.Result(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c4e)));
                match.NextMatch();
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetAllURL(string html)
        {
            StringBuilder builder = new StringBuilder();
            Match match = Regex.Match(html.ToLower(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4be4));
            while (match.Success)
            {
                builder.AppendLine(match.Result(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c12)));
                match.NextMatch();
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCleanJsString(string str)
        {
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b7c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b82));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b88), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b8e));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b94), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b9a));
            str = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4ba2), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(str, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4bb6));
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCleanJsString2(string str)
        {
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4bbc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4bc2));
            str = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4bca), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(str, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4bde));
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDateString(DateTime dt)
        {
            return (dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0'));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLength(string str)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(str);
            int num = 0;
            for (int i = 0; i <= (bytes.Length - 1); i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num++;
                }
                num++;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLetter(string str, int iNum, bool bAddDot)
        {
            char[] chArray;
            if ((str == null) || (iNum <= 0))
            {
                return "";
            }
            if ((str.Length < iNum) && ((str.Length * 2) < iNum))
            {
                return str;
            }
            string str2 = str;
            int length = iNum;
            if (str2.Length >= length)
            {
                chArray = str.ToCharArray(0, length);
            }
            else
            {
                chArray = str.ToCharArray(0, str2.Length);
            }
            int num2 = 0;
            int num3 = 0;
            foreach (char ch in chArray)
            {
                num3++;
                int num4 = ch;
                if ((num4 > 0x7f) || (num4 < 0))
                {
                    num2 += 2;
                }
                else
                {
                    num2++;
                }
                if (num2 > length)
                {
                    num3--;
                    break;
                }
                if (num2 == length)
                {
                    break;
                }
            }
            if ((num3 < str.Length) && bAddDot)
            {
                str2 = str2.Substring(0, num3 - 3) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x468e);
            }
            else
            {
                str2 = str2.Substring(0, num3);
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetPreStrByLast(string sOrg, string sLast)
        {
            int length = sOrg.LastIndexOf(sLast);
            if (length > 0)
            {
                return sOrg.Substring(0, length);
            }
            return sOrg;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSQLFildList(string fldList)
        {
            if (fldList == null)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b24);
            }
            if (fldList.Trim() == "")
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b2a);
            }
            if (fldList.Trim() == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b30))
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b36);
            }
            string str = fldList;
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b3c), "").Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b42), "").Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b48), "");
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b4e) + str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b54)).Replace(0xff0c, ',').Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b5a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b60));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetStrByLast(string sOrg, string sLast)
        {
            int num = sOrg.LastIndexOf(sLast);
            if (num > 0)
            {
                return sOrg.Substring(num + 1);
            }
            return sOrg;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTimeDelay(DateTime dtStar, DateTime dtEnd)
        {
            long num = (dtEnd.Ticks - dtStar.Ticks) / 0x989680L;
            long num2 = num / 0xe10L;
            num2 = (num % 0xe10L) / 60L;
            num2 = (num % 0xe10L) % 60L;
            return (((num2.ToString().PadLeft(2, '0') + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b6a)) + num2.ToString().PadLeft(2, '0') + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b70)) + num2.ToString().PadLeft(2, '0'));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUniqueString()
        {
            Random random = new Random();
            int num = (int) (random.NextDouble() * 10000.0);
            return (num.ToString() + DateTime.Now.Ticks.ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsEmpty(string str)
        {
            return ((str == null) || (str == ""));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemoveEndWith(string sOrg, string sEnd)
        {
            if (sOrg.EndsWith(sEnd))
            {
                sOrg = sOrg.Remove(sOrg.IndexOf(sEnd), sEnd.Length);
            }
            return sOrg;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReplaceNbsp(string str)
        {
            string str2 = str;
            if (str2.Length > 0)
            {
                str2 = str2.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4778), "").Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x477e), "");
                str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x478e) + str2;
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SetVersionFormat(string sVersion)
        {
            if ((sVersion == null) || (sVersion == ""))
            {
                return "";
            }
            int num = 0;
            int length = 0;
            string str = "";
            while ((num < 4) && (length > -1))
            {
                length = sVersion.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4b1e), (int) (length + 1));
                num++;
            }
            if (length > 0)
            {
                str = sVersion.Substring(0, length);
            }
            else
            {
                str = sVersion;
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string StringToHtml(string str)
        {
            string str2 = str;
            if (str2.Length > 0)
            {
                char ch = '\r';
                str2 = str2.Replace(ch.ToString(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x47c2)).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x47ce), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x47d4)).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x47e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x47ea));
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string TransformPrice(double dPrice)
        {
            double num = dPrice;
            NumberFormatInfo provider = new NumberFormatInfo {
                NumberNegativePattern = 2
            };
            return num.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4682), provider);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string TranslateToHtmlString(string str, int num)
        {
            string str2 = str;
            return StringToHtml(GetLetter(str2, num, false));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string TransToStr(float f, int iNum)
        {
            float num = f;
            NumberFormatInfo provider = new NumberFormatInfo {
                NumberNegativePattern = iNum
            };
            return f.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4688), provider);
        }
    }
}

