namespace Devv.Core.Utils
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RegexUtil
    {
        public const string Email = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";
        public const string FilePictures = @"^.+\.([jJ][pP][gG]|[gG][iI][fF]|[pP][nN][gG]|[bB][mM][pP])$";
        public const string Host = @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        public const string IP = @"^(([0-2]*[0-9]+[0-9]+)\.([0-2]*[0-9]+[0-9]+)\.([0-2]*[0-9]+[0-9]+)\.([0-2]*[0-9]+[0-9]+))$";
        public const string NoSpecialCharacters = @"^[a-zA-Z0-9_\-\.]{2,9999}$";
        public const string Password = "^.{4,20}$";
        public const string Url = @"(([\w]+:)?//)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?";

        private RegexUtil()
        {
        }

        public static string CreateLinksInHtml(string value)
        {
            return CreateLinksInHtml(value, "_self");
        }

        public static string CreateLinksInHtml(string value, string target)
        {
            MatchCollection matchs = new Regex(@"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", RegexOptions.IgnoreCase).Matches(value);
            int num2 = matchs.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                string oldValue = matchs[i].Value;
                string str3 = oldValue;
                if (!str3.Substring(0, 7).ToLower().Equals("http://"))
                {
                    str3 = "http://" + str3;
                }
                value = value.Replace(oldValue, "<a href=\"" + str3 + "\" target=\"" + target + "\">" + oldValue + "</a>");
            }
            return value;
        }

        public static string GetTextFromHtml(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = Regex.Replace(value, "<[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                value = Regex.Replace(value, "[<]", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                value = Regex.Replace(value, "[>]", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            }
            return value;
        }

        public static string GetTitleFromHtml(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int length = value.Length;
                int startIndex = value.IndexOf("<title>", StringComparison.InvariantCultureIgnoreCase) + 7;
                int index = value.IndexOf("</title", StringComparison.InvariantCultureIgnoreCase);
                value = value.Substring(startIndex, length - startIndex);
                value = value.Substring(0, index - startIndex);
            }
            return value;
        }

        public static string RemoveAccents(string value)
        {
            string str2 = value.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            int num2 = str2.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                char ch = Convert.ToChar(str2.Substring(i, 1));
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        public static string RemoveSpecialCharacters(string value)
        {
            return RemoveSpecialCharacters(value, false);
        }

        public static string RemoveSpecialCharacters(string value, bool preserveSpaces)
        {
            if (preserveSpaces)
            {
                value = Regex.Replace(value, @"[^ \w\.-]", "");
                return value;
            }
            value = Regex.Replace(value, @"[^\w\.-]", "");
            while (value.Contains(" "))
            {
                value = value.Replace(" ", "");
            }
            return value;
        }

        public static bool Test(string strInput, string pattern)
        {
            return Regex.IsMatch(strInput, pattern);
        }
    }
}
