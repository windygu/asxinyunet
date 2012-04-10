namespace WHC.Pager.WinControl
{
    using System;
    using System.IO;

    public class MyConstants
    {
        private static string string_0 = "";
        private static string string_1 = "";

        public static string ConfigFile
        {
            get
            {
                if (string.IsNullOrEmpty(string_0))
                {
                    string searchPattern = "*.exe.config";
                    foreach (string str2 in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, searchPattern, SearchOption.TopDirectoryOnly))
                    {
                        if (!str2.Contains(".vshost"))
                        {
                            string_0 = str2;
                            break;
                        }
                    }
                }
                return string_0;
            }
            set
            {
                string_0 = value;
            }
        }

        public static string License
        {
            get
            {
                if (string.IsNullOrEmpty(string_1))
                {
                    AppConfig config = new AppConfig(ConfigFile);
                    return config.AppConfigGet("PagerLicense");
                }
                return string_1;
            }
            set
            {
                string_1 = value;
            }
        }
    }
}

