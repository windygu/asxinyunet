namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    public class CRegex
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string 01FqmBarm(string text1)
        {
            string str = text1.Trim().ToLower();
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c2a);
            if (str.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c3c)) != -1)
            {
                str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c50);
                str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c64), "");
            }
            else
            {
                str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c78), "");
            }
            int startIndex = str.LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c8a));
            if (startIndex == -1)
            {
                str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c90);
            }
            else if (startIndex != (str.Length - 1))
            {
                if (str.Substring(startIndex).IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c96)) != -1)
                {
                    str = str.Substring(0, startIndex + 1);
                }
                else
                {
                    str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c9c);
                }
            }
            return (str2 + str);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string dT3f0t4t3(string text1, string text3, string text2, string text4)
        {
            MatchCollection matchs = new Regex(text1, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(text2);
            string oldValue = "";
            string str2 = "";
            string newValue = "";
            foreach (Match match in matchs)
            {
                oldValue = match.Value;
                str2 = match.Groups[text3].Value;
                newValue = oldValue.Replace(str2, GetUrl(text4, str2));
                text2 = text2.Replace(oldValue, newValue);
            }
            return text2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetAuthor(string sInput, string sRegex)
        {
            string str = CString.ClearTag(GetText(sInput, sRegex, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9bc6)));
            if (str.Length > 0x63)
            {
                str = str.Substring(0, 0x63);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetBody(string sInput)
        {
            return GetText(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9b4e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9b9e));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetBody(string sInput, string sRegex)
        {
            return GetText(sInput, sRegex, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9baa));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetContent(string sOriContent, string sOtherRemoveReg, string sPageUrl, DataTable dtAntiLink)
        {
            string input = sOriContent;
            input = Regex.Replace(Regex.Replace(input, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d60), "", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d94), "", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9dd4), RegexOptions.IgnoreCase).Replace(input, "");
            string[] strArray = sOtherRemoveReg.Split(new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9ef4) }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str2 in strArray)
            {
                input = Replace(input, str2, "", 0);
            }
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9efc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fa4), input, sPageUrl);
            DataRow[] rowArray = dtAntiLink.Select(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fae) + GetDomain(sPageUrl) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fc2));
            if (rowArray.Length > 0)
            {
                foreach (DataRow row in rowArray)
                {
                    if (Convert.ToInt32(row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fc8)]) == 1)
                    {
                        input = input.Replace(row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fd4)].ToString(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fe4));
                    }
                    else
                    {
                        input = input.Replace(row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa026)].ToString(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa036) + row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa078)].ToString());
                    }
                }
            }
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa088), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa12e), input, sPageUrl);
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa13a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa1e6), input, sPageUrl);
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa1f2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa27e), input, sPageUrl);
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa288), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa2f6), input, sPageUrl);
            input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa300), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa38c), input, sPageUrl);
            if (IsXml(input))
            {
                input = dT3f0t4t3(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa39a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa458), input, sPageUrl);
            }
            return input;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetCreateDate(string sInput, string sRegex)
        {
            DateTime now = DateTime.Now;
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sInput);
            if (match.Success)
            {
                try
                {
                    int year = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d20)].Value);
                    int month = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d2c)].Value);
                    int day = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d3a)].Value);
                    int hour = now.Hour;
                    int minute = now.Minute;
                    string s = match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d44)].Value;
                    string str2 = match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d50)].Value;
                    if (s != "")
                    {
                        hour = int.Parse(s);
                    }
                    if (str2 != "")
                    {
                        minute = int.Parse(str2);
                    }
                    now = new DateTime(year, month, day, hour, minute, 0);
                }
                catch
                {
                }
            }
            return now;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDomain(string sInput)
        {
            return GetText(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9a6e), 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHtml(string sInput)
        {
            return Replace(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9b20), "", kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9b42));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetImgSrc(string sInput)
        {
            return GetText(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x99c8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9a64));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetImgTag(string sInput)
        {
            return GetList(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x992c), "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetKeyWord(string sInput)
        {
            List<string> list = Split(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9ca2), 2);
            List<string> list2 = new List<string>();
            foreach (string str in list)
            {
                Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9cf2), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                MatchCollection matchs = regex.Matches(str);
                string input = str;
                foreach (Match match in matchs)
                {
                    if (match.Value.ToString().Length > 2)
                    {
                        list2.Add(match.Value.ToString());
                    }
                    input = input.Replace(match.Value.ToString(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d08));
                }
                regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d0e), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                matchs = regex.Matches(input);
                foreach (string str3 in regex.Split(input))
                {
                    if (str3.Trim().Length > 2)
                    {
                        list2.Add(str3);
                    }
                }
            }
            string str4 = "";
            for (int i = 0; i < (list2.Count - 1); i++)
            {
                for (int j = i + 1; j < list2.Count; j++)
                {
                    if (list2[i] == list2[j])
                    {
                        list2[j] = "";
                    }
                }
            }
            foreach (string str in list2)
            {
                if (str.Length > 2)
                {
                    str4 = str4 + str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9d1a);
                }
            }
            if (str4.Length > 0)
            {
                str4 = str4.Substring(0, str4.Length - 1);
            }
            else
            {
                str4 = sInput;
            }
            if (str4.Length > 0x63)
            {
                str4 = str4.Substring(0, 0x63);
            }
            return str4;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLink(string sInput)
        {
            return GetText(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9880), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9920));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetLinks(string sInput)
        {
            return GetList(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x97d4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9874));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetList(string sInput, string sRegex, int iGroupIndex)
        {
            List<string> list = new List<string>();
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sInput);
            foreach (Match match in matchs)
            {
                if (iGroupIndex > 0)
                {
                    list.Add(match.Groups[iGroupIndex].Value);
                }
                else
                {
                    list.Add(match.Value);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetList(string sInput, string sRegex, string sGroupName)
        {
            List<string> list = new List<string>();
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sInput);
            foreach (Match match in matchs)
            {
                if (sGroupName != "")
                {
                    list.Add(match.Groups[sGroupName].Value);
                }
                else
                {
                    list.Add(match.Value);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetPageLinks(string sInput, string sRegex)
        {
            return GetList(sInput, sRegex, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9bd6));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSource(string sInput, string sRegex)
        {
            string str = CString.ClearTag(GetText(sInput, sRegex, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9bb6)));
            if (str.Length > 0x63)
            {
                str = str.Substring(0, 0x63);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetText(string sInput, string sRegex, int iGroupIndex)
        {
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sInput);
            string str = "";
            if (!match.Success)
            {
                return str;
            }
            if (iGroupIndex > 0)
            {
                return match.Groups[iGroupIndex].Value;
            }
            return match.Value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetText(string sInput, string sRegex, string sGroupName)
        {
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sInput);
            string str = "";
            if (!match.Success)
            {
                return str;
            }
            if (sGroupName != "")
            {
                return match.Groups[sGroupName].Value;
            }
            return match.Value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTitle(string sInput)
        {
            return GetText(sInput, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9abc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9b12));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTitle(string sInput, string sRegex)
        {
            string str = CString.ClearTag(GetText(sInput, sRegex, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9aae)));
            if (str.Length > 0x63)
            {
                str = str.Substring(0, 0x63);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUrl(string sInput, string sRelativeUrl)
        {
            string sOrg = 01FqmBarm(sInput);
            if (sRelativeUrl.ToLower().StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9be2)) || sRelativeUrl.ToLower().StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9bee)))
            {
                return sRelativeUrl.Trim();
            }
            if (sRelativeUrl.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9bfc)))
            {
                return (GetDomain(sInput) + sRelativeUrl);
            }
            if (sRelativeUrl.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c02)))
            {
                sOrg = sOrg.Substring(0, sOrg.Length - 1);
                while (sRelativeUrl.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c12)) >= 0)
                {
                    string preStrByLast = CString.GetPreStrByLast(sOrg, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c0c));
                    if (preStrByLast.Length > 6)
                    {
                        sOrg = preStrByLast;
                    }
                    sRelativeUrl = sRelativeUrl.Substring(3);
                }
                return (sOrg + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c1c) + sRelativeUrl.Trim());
            }
            if (sRelativeUrl.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c22)))
            {
                return (sOrg + sRelativeUrl.Trim().Substring(2));
            }
            if (sRelativeUrl.Trim() != "")
            {
                return (sOrg + sRelativeUrl.Trim());
            }
            sRelativeUrl = sOrg;
            return "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsMatch(string sInput, string sRegex)
        {
            if (sRegex == "")
            {
                return true;
            }
            Regex regex = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.Match(sInput).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsXml(string sFormartted)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa464), RegexOptions.IgnoreCase);
            return (regex.Matches(sFormartted).Count > 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Replace(string sInput, string sRegex, string sReplace, int iGroupIndex)
        {
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sInput);
            foreach (Match match in matchs)
            {
                if (iGroupIndex > 0)
                {
                    sInput = sInput.Replace(match.Groups[iGroupIndex].Value, sReplace);
                }
                else
                {
                    sInput = sInput.Replace(match.Value, sReplace);
                }
            }
            return sInput;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Replace(string sInput, string sRegex, string sReplace, string sGroupName)
        {
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sInput);
            foreach (Match match in matchs)
            {
                if (sGroupName != "")
                {
                    sInput = sInput.Replace(match.Groups[sGroupName].Value, sReplace);
                }
                else
                {
                    sInput = sInput.Replace(match.Value, sReplace);
                }
            }
            return sInput;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> Split(string sInput, string sRegex, int iStrLen)
        {
            string[] strArray = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Split(sInput);
            List<string> list = new List<string>();
            list.Clear();
            foreach (string str in strArray)
            {
                if (str.Trim().Length >= iStrLen)
                {
                    list.Add(str.Trim());
                }
            }
            return list;
        }
    }
}

