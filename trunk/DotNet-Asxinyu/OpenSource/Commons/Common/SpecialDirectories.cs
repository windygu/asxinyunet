namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Windows.Forms;

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
    public class SpecialDirectories
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool 3xodQsKC6(string text1)
        {
            if (!Path.IsPathRooted(text1))
            {
                return false;
            }
            text1 = text1.TrimEnd(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            return (string.Compare(text1, Path.GetPathRoot(text1), StringComparison.OrdinalIgnoreCase) == 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string eMSUYugy4(string text1)
        {
            if (Path.IsPathRooted(text1) && text1.Equals(Path.GetPathRoot(text1), StringComparison.OrdinalIgnoreCase))
            {
                return text1;
            }
            return text1.TrimEnd(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string EPgfA8o8U(string text1)
        {
            try
            {
                if (!3xodQsKC6(text1))
                {
                    DirectoryInfo info = new DirectoryInfo(hudMECjTG(text1));
                    if (File.Exists(text1))
                    {
                        return info.GetFiles(Path.GetFileName(text1))[0].FullName;
                    }
                    if (Directory.Exists(text1))
                    {
                        return info.GetDirectories(Path.GetFileName(text1))[0].FullName;
                    }
                }
                return text1;
            }
            catch (Exception exception)
            {
                if ((((!(exception is ArgumentException) && !(exception is ArgumentNullException)) && (!(exception is PathTooLongException) && !(exception is NotSupportedException))) && !(exception is DirectoryNotFoundException)) && (!(exception is SecurityException) && !(exception is UnauthorizedAccessException)))
                {
                    throw;
                }
                return text1;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string hudMECjTG(string text1)
        {
            Path.GetFullPath(text1);
            if (3xodQsKC6(text1))
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd348), string.Format(CultureInfo.InvariantCulture, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd354), new string[] { text1 }));
            }
            return Path.GetDirectoryName(text1.TrimEnd(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Um5wSC5ZO(string text1, params object[] args)
        {
            if (string.IsNullOrEmpty(text1))
            {
                return string.Empty;
            }
            if (args == null)
            {
                return text1;
            }
            return string.Format(CultureInfo.CurrentCulture, text1, args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string XxQqQ66mW(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1))
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd2c8), new object[] { text2 }));
            }
            return EPgfA8o8U(eMSUYugy4(Path.GetFullPath(text1)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string y3vHWmTuH(string text1)
        {
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd3ec);
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd406);
            string companyName = Application.CompanyName;
            string productName = Application.ProductName;
            string productVersion = Application.ProductVersion;
            if (companyName.Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd41a)))
            {
                return (text1 + str2);
            }
            string path = Um5wSC5ZO(str, new object[] { text1, productName, productVersion });
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(productVersion);
            }
            return path;
        }

        public string AllUsersApplicationData
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return y3vHWmTuH(XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd194)));
            }
        }

        public string CurrentUserApplicationData
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return y3vHWmTuH(XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd1ce)));
            }
        }

        public string Desktop
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd210));
            }
        }

        public string MyDocuments
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.Personal), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd222));
            }
        }

        public string MyMusic
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd23e));
            }
        }

        public string MyPictures
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd252));
            }
        }

        public string ProgramFiles
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd26c));
            }
        }

        public string Programs
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Environment.GetFolderPath(Environment.SpecialFolder.Programs), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd28a));
            }
        }

        public string Temp
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return XxQqQ66mW(Path.GetTempPath(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd29e));
            }
        }
    }
}

