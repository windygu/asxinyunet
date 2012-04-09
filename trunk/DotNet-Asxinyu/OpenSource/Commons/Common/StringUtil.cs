namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class StringUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private StringUtil()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ArrayList ExtractInnerContent(string content, string start, string end)
        {
            int startIndex = -1;
            int index = -1;
            int num3 = -1;
            int length = 0;
            ArrayList list = new ArrayList();
            startIndex = content.IndexOf(start);
            num3 = startIndex + start.Length;
            index = content.IndexOf(end, num3);
            length = index - num3;
            if ((startIndex >= 0) && (index > startIndex))
            {
                list.Add(content.Substring(num3, length));
            }
            while ((startIndex >= 0) && (index > 0))
            {
                startIndex = content.IndexOf(start, index);
                if (startIndex > 0)
                {
                    index = content.IndexOf(end, startIndex);
                    num3 = startIndex + start.Length;
                    length = index - num3;
                    if ((num3 > 0) && (index > 0))
                    {
                        list.Add(content.Substring(num3, length));
                    }
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ArrayList ExtractOuterContent(string content, string start, string end)
        {
            int startIndex = -1;
            int index = -1;
            ArrayList list = new ArrayList();
            startIndex = content.IndexOf(start);
            index = content.IndexOf(end);
            if ((startIndex >= 0) && (index > startIndex))
            {
                list.Add(content.Substring(startIndex, (index + end.Length) - startIndex));
            }
            while ((startIndex >= 0) && (index > 0))
            {
                startIndex = content.IndexOf(start, index);
                if (startIndex > 0)
                {
                    index = content.IndexOf(end, startIndex);
                    if ((startIndex > 0) && (index > 0))
                    {
                        list.Add(content.Substring(startIndex, (index + end.Length) - startIndex));
                    }
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemoveFinalChar(string s)
        {
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemoveFinalComma(string s)
        {
            if (s.Trim().Length > 0)
            {
                int num = s.LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x29e6));
                if (num > 0)
                {
                    s = s.Substring(0, s.Length - (s.Length - num));
                }
            }
            return s;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemovePrefix(string content, string prefixString)
        {
            if (string.IsNullOrEmpty(prefixString) || (prefixString.Trim() == string.Empty))
            {
                return content;
            }
            char[] trimChars = new char[] { ',', ';', ' ' };
            string str = content;
            prefixString = prefixString.Trim(trimChars);
            string[] strArray = prefixString.Split(trimChars);
            foreach (string str2 in strArray)
            {
                if (str.IndexOf(str2, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return str.Substring(str2.Length);
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RemoveSpaces(string s)
        {
            s = s.Trim();
            s = s.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x29ec), "");
            return s;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ToCamel(string name)
        {
            string str = RemoveSpaces(ToProperCase(name.TrimStart(new char[] { '_' })));
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x29d6), char.ToLower(str[0]), str.Substring(1, str.Length - 1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ToCapit(string name)
        {
            return RemoveSpaces(ToProperCase(name.TrimStart(new char[] { '_' })));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ToProperCase(string s)
        {
            string str = "";
            if (s.Length <= 0)
            {
                return str;
            }
            if (s.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x29f2)) > 0)
            {
                return Strings.StrConv(s, VbStrConv.ProperCase, 0x409);
            }
            return (s.Substring(0, 1).ToUpper(new CultureInfo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x29f8))) + s.Substring(1, s.Length - 1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ToString(object o)
        {
            StringBuilder builder = new StringBuilder();
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a06) + o.GetType().Name + Environment.NewLine);
            foreach (PropertyInfo info in properties)
            {
                try
                {
                    builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a2a) + info.Name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a30) + info.PropertyType.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a36));
                    if (null != info.GetValue(o, null))
                    {
                        builder.Append(info.GetValue(o, null).ToString());
                    }
                }
                catch
                {
                }
                builder.Append(Environment.NewLine);
            }
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo info2 in fields)
            {
                try
                {
                    builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a40) + info2.Name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a46) + info2.FieldType.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a4c));
                    if (null != info2.GetValue(o))
                    {
                        builder.Append(info2.GetValue(o).ToString());
                    }
                }
                catch
                {
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ToTrimmedProperCase(string s)
        {
            return RemoveSpaces(ToProperCase(s));
        }
    }
}

