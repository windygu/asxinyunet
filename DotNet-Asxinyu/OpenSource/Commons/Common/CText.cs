namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Xml;

    public class CText
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetBody(string sContent)
        {
            sContent = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d76), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase).Replace(sContent, "");
            sContent = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3da8), RegexOptions.RightToLeft | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase).Replace(sContent, "");
            return sContent;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetCreateDate(string sContent, string sRegex)
        {
            DateTime now = DateTime.Now;
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sContent);
            if (match.Success)
            {
                try
                {
                    int year = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ef6)].Value);
                    int month = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f02)].Value);
                    int day = int.Parse(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f10)].Value);
                    int hour = now.Hour;
                    int minute = now.Minute;
                    string s = match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f1a)].Value;
                    string str2 = match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f26)].Value;
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
        public static string GetDomainUrl(string sUrl)
        {
            try
            {
                Uri uri = new Uri(sUrl);
                return (uri.Scheme + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3e04) + uri.Authority);
            }
            catch
            {
                return sUrl;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetKeys(string sOri)
        {
            if (sOri.Trim().Length == 0)
            {
                return null;
            }
            string[] strArray = sOri.Split(new char[] { ',', '，', '\\', '/', '、' });
            List<string> list = new List<string>();
            foreach (string str in strArray)
            {
                if (str.Length != 0)
                {
                    list.Add(str);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLink(string sContent)
        {
            string str = "";
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x30a0), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Match match = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x314c), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sContent);
            if (match.Success)
            {
                return match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3230)].Value;
            }
            Match match2 = regex.Match(sContent);
            if (match2.Success)
            {
                str = RemoveByReg(HttpUtility.HtmlDecode(match2.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x323c)].Value), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3248));
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> GetLinks(string sContent, string sUrl)
        {
            Dictionary<string, string> lisDes = new Dictionary<string, string>();
            return GetLinks(sContent, sUrl, ref lisDes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> GetLinks(string sContent, string sUrl, ref Dictionary<string, string> lisDes)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            mUvqAX6rk(sContent, sUrl, ref dictionary);
            string str = CRegex.GetDomain(sUrl).ToLower();
            MatchCollection matchs = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3306), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sContent);
            for (int i = matchs.Count - 1; i >= 0; i--)
            {
                Match match = matchs[i];
                string url = CRegex.GetUrl(sUrl, match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x33ae)].Value);
                if (str.CompareTo(CRegex.GetDomain(url).ToLower()) == 0)
                {
                    string htmlByUrl = CSocket.GetHtmlByUrl(url);
                    if (htmlByUrl.Length != 0)
                    {
                        mUvqAX6rk(htmlByUrl, url, ref dictionary);
                    }
                }
            }
            if (dictionary.Count == 0)
            {
                return GetLinksFromRss(sContent, sUrl, ref lisDes);
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> GetLinksByKey(Dictionary<string, string> listA, List<string> listKey)
        {
            if (listKey == null)
            {
                return listA;
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string pattern = "";
            foreach (string str2 in listKey)
            {
                pattern = pattern + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36a2) + XPOfx7u7N(str2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36b6);
            }
            pattern = (pattern != "") ? pattern.Substring(0, pattern.Length - 1) : kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36cc);
            Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (KeyValuePair<string, string> pair in listA)
            {
                if (regex.Match(pair.Value).Success && !dictionary.ContainsKey(pair.Key))
                {
                    dictionary.Add(pair.Key, pair.Value);
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.NoInlining), Obsolete("已过时的方法。")]
        public static List<string> GetLinksByKey(string sContent, List<string> listKey)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            string pattern = "";
            MatchCollection matchs = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3988), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sContent);
            foreach (Match match in matchs)
            {
                if (RemoveByReg(GetLink(match.Value), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x39da)).Length > 0)
                {
                    list2.Add(match.Value);
                }
            }
            foreach (string str3 in listKey)
            {
                pattern = pattern + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x39f0) + str3 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3a04);
            }
            if (pattern != "")
            {
                pattern = pattern.Substring(0, pattern.Length - 1);
            }
            if (pattern == "")
            {
                pattern = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3a1a);
            }
            Regex regex2 = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3a2c), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (string str3 in list2)
            {
                Match match2 = regex.Match(str3);
                if (match2.Success)
                {
                    string str = RemoveByReg(CString.ClearTag(match2.Groups[1].Value.Trim()), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3a68));
                    if ((CString.GetLength(str) > 8) && regex2.Match(str).Success)
                    {
                        list.Add(str3);
                    }
                }
            }
            if (list.Count == 0)
            {
                return GetLinksByKeyFromRss(sContent, listKey);
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining), Obsolete("已过时的方法。")]
        public static List<string> GetLinksByKeyFromRss(string sContent, List<string> listKey)
        {
            XmlNodeList list2;
            int num;
            XmlNamespaceManager manager;
            List<string> list = new List<string>();
            string pattern = "";
            foreach (string str2 in listKey)
            {
                pattern = pattern + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ae0) + str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3af4);
            }
            if (pattern != "")
            {
                pattern = pattern.Substring(0, pattern.Length - 1);
            }
            if (pattern == "")
            {
                pattern = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b0a);
            }
            Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            XmlDocument document = new XmlDocument();
            try
            {
                document.LoadXml(sContent.Trim());
                list2 = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b1c));
                if (list2.Count > 0)
                {
                    for (num = 0; num < list2.Count; num++)
                    {
                        list.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b42) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b58)).InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b64) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b6c)).InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b7a));
                    }
                    return list;
                }
            }
            catch
            {
            }
            try
            {
                manager = new XmlNamespaceManager(document.NameTable);
                manager.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b86), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3b90));
                manager.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3bea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3bf4));
                list2 = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c28), manager);
                if (list2.Count > 0)
                {
                    for (num = 0; num < list2.Count; num++)
                    {
                        list.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c50) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c66), manager).InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c7a) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c82), manager).InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3c98));
                    }
                    return list;
                }
            }
            catch
            {
            }
            try
            {
                manager = new XmlNamespaceManager(document.NameTable);
                manager.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ca4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3cb0));
                list2 = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ce4), manager);
                if (list2.Count > 0)
                {
                    for (num = 0; num < list2.Count; num++)
                    {
                        list.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d12) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d28), manager).Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d3e)].InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d4a) + list2[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d52), manager).InnerText + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3d6a));
                    }
                    return list;
                }
            }
            catch
            {
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> GetLinksFromRss(string sContent, string sUrl)
        {
            Dictionary<string, string> lisDes = new Dictionary<string, string>();
            return GetLinksFromRss(sContent, sUrl, ref lisDes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> GetLinksFromRss(string sContent, string sUrl, ref Dictionary<string, string> lisDes)
        {
            Dictionary<string, string> dictionary2;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            XmlDocument document = new XmlDocument();
            try
            {
                int num;
                string urlByRelative;
                document.LoadXml(sContent.Trim());
                XmlNodeList list = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x372c));
                if (list.Count <= 0)
                {
                    try
                    {
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
                        nsmgr.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3786), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3790));
                        nsmgr.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x37ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x37f4));
                        list = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3828), nsmgr);
                        if (list.Count <= 0)
                        {
                            try
                            {
                                nsmgr = new XmlNamespaceManager(document.NameTable);
                                nsmgr.AddNamespace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x389c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x38a8));
                                list = document.SelectNodes(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x38dc), nsmgr);
                                if (list.Count <= 0)
                                {
                                    return dictionary;
                                }
                                for (num = list.Count - 1; num >= 0; num--)
                                {
                                    try
                                    {
                                        urlByRelative = GetUrlByRelative(sUrl, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x390a), nsmgr).Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3920)].InnerText);
                                        dictionary.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x392c), nsmgr).InnerText);
                                        lisDes.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3944), nsmgr).InnerText);
                                    }
                                    catch
                                    {
                                    }
                                }
                                dictionary2 = dictionary;
                            }
                            catch
                            {
                            }
                            return dictionary2;
                        }
                        for (num = list.Count - 1; num >= 0; num--)
                        {
                            try
                            {
                                urlByRelative = GetUrlByRelative(sUrl, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3850), nsmgr).InnerText);
                                dictionary.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3864), nsmgr).InnerText);
                                lisDes.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x387a), nsmgr).InnerText);
                            }
                            catch
                            {
                            }
                        }
                        dictionary2 = dictionary;
                    }
                    catch
                    {
                    }
                    return dictionary2;
                }
                for (num = list.Count - 1; num >= 0; num--)
                {
                    try
                    {
                        urlByRelative = GetUrlByRelative(sUrl, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3752)).InnerText);
                        dictionary.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x375e)).InnerText);
                        lisDes.Add(urlByRelative, list[num].SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x376c)).InnerText);
                    }
                    catch
                    {
                    }
                }
                dictionary2 = dictionary;
            }
            catch
            {
            }
            return dictionary2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetListByReg(string sContent, string sRegex)
        {
            List<string> list = new List<string>();
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sContent);
            foreach (Match match in matchs)
            {
                list.Add(match.Groups[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3df8)].Value);
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTextByLink(string sContent)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3276), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x32b6), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            if (!regex2.Match(sContent).Success)
            {
                Match match2 = regex.Match(sContent);
                if (match2.Success)
                {
                    return match2.Groups[1].Value;
                }
            }
            return "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTextByReg(string sContent, string sRegex)
        {
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sContent);
            string sOrg = "";
            if (match.Success)
            {
                sOrg = match.Groups[0].Value;
            }
            while (sOrg.EndsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3de6)))
            {
                sOrg = CString.RemoveEndWith(sOrg, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3de0));
            }
            return sOrg;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTextByReg(string sContent, string sRegex, string sGroupName)
        {
            Match match = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Match(sContent);
            string str = "";
            if (match.Success)
            {
                str = match.Groups[sGroupName].Value;
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTitleFromRss(string sContent)
        {
            string innerText = "";
            XmlDocument document = new XmlDocument();
            try
            {
                document.LoadXml(sContent.Trim());
                innerText = document.SelectSingleNode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3960)).InnerText;
            }
            catch
            {
            }
            return innerText;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTxtFromHtml(string sHtml)
        {
            string sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f36);
            string sContent = RemoveByReg(sHtml, sRegex);
            sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3f6e);
            sContent = RemoveByReg(sContent, sRegex);
            sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x40c2);
            sContent = RemoveByReg(sContent, sRegex);
            string str3 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x40ea);
            return RemoveByReg(RemoveByReg(ReplaceByReg(ReplaceByReg(sContent, "", str3), "", kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x426c)), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4286)), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x42be)).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x42d0), "").Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x42d6), "").Trim();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTxtFromHtml2(string sHtml)
        {
            string sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x42dc);
            string sContent = RemoveByReg(sHtml, sRegex);
            sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4314);
            sContent = RemoveByReg(sContent, sRegex);
            sRegex = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4468);
            sContent = RemoveByReg(sContent, sRegex);
            string str3 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x448c);
            return RemoveByReg(RemoveByReg(ReplaceByReg(sContent, "", str3), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x460e)), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4646)).Trim();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUrlByRelative(string sUrl, string sRUrl)
        {
            try
            {
                Uri baseUri = new Uri(sUrl);
                if (!sUrl.EndsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3dec)))
                {
                    int index = baseUri.Segments.Length - 1;
                    if (index > 0)
                    {
                        string str = baseUri.Segments[index];
                        if (str.IndexOf('.') < 1)
                        {
                            baseUri = new Uri(sUrl + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3df2));
                        }
                    }
                }
                Uri uri2 = new Uri(baseUri, sRUrl);
                return uri2.AbsoluteUri;
            }
            catch
            {
                return sUrl;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsExistsScriptLink(string sHtml)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x35fa), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.IsMatch(sHtml);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void mUvqAX6rk(string text1, string text2, ref Dictionary<string, string> dictionaryRef1)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x33b8), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x340a), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection matchs = regex.Matches(text1);
            for (int i = matchs.Count - 1; i >= 0; i--)
            {
                Match match = matchs[i];
                string sContent = GetLink(match.Value).Trim().Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3414), "").Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x341c), "");
                if (RemoveByReg(sContent, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3424)).Length >= 2)
                {
                    string str3 = CString.ClearTag(GetTextByLink(match.Value)).Trim();
                    if ((CString.GetLength(RemoveByReg(str3, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x343a))) >= 9) && !regex2.IsMatch(str3))
                    {
                        sContent = GetUrlByRelative(text2, sContent);
                        if (sContent.Length > 0x12)
                        {
                            int index = sContent.IndexOf('#');
                            if (index > -1)
                            {
                                sContent = sContent.Substring(0, index);
                            }
                            sContent = sContent.Trim(new char[] { '/', '\\' });
                            string domain = CRegex.GetDomain(sContent);
                            if (!sContent.Equals(domain, StringComparison.OrdinalIgnoreCase) && !(dictionaryRef1.ContainsKey(sContent) || dictionaryRef1.ContainsValue(str3)))
                            {
                                dictionaryRef1.Add(sContent, str3);
                            }
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemoveByReg(string sContent, string sRegex)
        {
            MatchCollection matchs = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Matches(sContent);
            foreach (Match match in matchs)
            {
                sContent = sContent.Replace(match.Value, "");
            }
            return sContent;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReplaceByReg(string sContent, string sReplace, string sRegex)
        {
            sContent = new Regex(sRegex, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(sContent, sReplace);
            return sContent;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Split(string sOri)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3e0e), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            string[] strArray = regex.Split(sOri);
            List<string> list = new List<string>();
            list.Clear();
            foreach (string str in strArray)
            {
                if (str.Length > 2)
                {
                    regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ec8), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                    MatchCollection matchs = regex.Matches(str);
                    string input = str;
                    foreach (Match match in matchs)
                    {
                        if (match.Value.ToString().Length > 2)
                        {
                            list.Add(match.Value.ToString());
                        }
                        input = input.Replace(match.Value.ToString(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ede));
                    }
                    regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ee4), RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                    matchs = regex.Matches(input);
                    foreach (string str3 in regex.Split(input))
                    {
                        if (str3.Trim().Length > 2)
                        {
                            list.Add(str3);
                        }
                    }
                }
            }
            string str4 = "";
            for (int i = 0; i < (list.Count - 1); i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        list[j] = "";
                    }
                }
            }
            foreach (string str5 in list)
            {
                if (str5.Length > 2)
                {
                    str4 = str4 + str5 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3ef0);
                }
            }
            if (str4.Length > 0)
            {
                return str4.Substring(0, str4.Length - 1);
            }
            return str4;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string XPOfx7u7N(string text1)
        {
            string[] strArray = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36de), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36f0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36f6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x36fc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3702), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3708), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x370e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3714), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x371a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3720) };
            string str = text1;
            foreach (string str2 in strArray)
            {
                str = str.Replace(str2, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x3726) + str2);
            }
            return str;
        }
    }
}

