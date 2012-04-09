namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Text;

    public class IOUtil
    {
        private IOUtil()
        {
        }

        public static bool CopyFolder(string strPathSrc, string strPathDest)
        {
            return CopyFolder(strPathSrc, strPathDest, true);
        }

        public static bool CopyFolder(string strPathSrc, string strPathDest, bool blnOverwrite)
        {
            bool flag = true;
            DirectoryInfo info2 = new DirectoryInfo(strPathSrc);
            DirectoryInfo info = new DirectoryInfo(strPathDest);
            try
            {
                if (!info.Exists)
                {
                    info.Create();
                }
                foreach (FileInfo info4 in info2.GetFiles())
                {
                    info4.CopyTo(Path.Combine(info.FullName, info4.Name), blnOverwrite);
                }
                foreach (DirectoryInfo info3 in info2.GetDirectories())
                {
                    flag &= CopyFolder(info3.FullName, Path.Combine(info.FullName, info3.Name), blnOverwrite);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public static int CountFiles(string path)
        {
            return CountFiles(path, string.Empty);
        }

        public static int CountFiles(string path, string filter)
        {
            if (!Directory.Exists(path))
            {
                return 0;
            }
            return Directory.GetFiles(path, filter).Length;
        }

        public static int GetFileSizeKbytes(string strPath)
        {
            FileInfo info = new FileInfo(strPath);
            if (info.Exists)
            {
                return Convert.ToInt32((double) (((double) info.Length) / 1024.0));
            }
            return 0;
        }

        public static string GetSizeString(byte intKBytes)
        {
            return (Conversions.ToString(intKBytes) + " KB");
        }

        public static string GetSizeString(int intKBytes)
        {
            return GetSizeString(Convert.ToInt64(intKBytes));
        }

        public static string GetSizeString(long intKBytes)
        {
            double num;
            if (intKBytes < 0x400L)
            {
                return (Conversions.ToString(intKBytes) + " KB");
            }
            if (intKBytes < 0xfa000L)
            {
                num = ((double) intKBytes) / 1024.0;
                return (num.ToString("0.00") + " MB");
            }
            num = ((double) intKBytes) / 1024000.0;
            return (num.ToString("0.00") + " GB");
        }

        public static string GetSizeString(FileInfo objFile)
        {
            if (objFile.Exists)
            {
                return GetSizeString((long) (objFile.Length / 0x400L));
            }
            return "??? KB";
        }

        public static string ReadFile(string strPath)
        {
            return ReadFile(strPath, Encoding.UTF8);
        }

        public static string ReadFile(string strPath, Encoding objEncoding)
        {
            string str2 = string.Empty;
            if (File.Exists(strPath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(strPath, objEncoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    ProjectData.ClearProjectError();
                }
            }
            return str2;
        }

        public static bool ValidatePath(string value)
        {
            if (value == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(value.Trim()))
            {
                return false;
            }
            foreach (char ch in Path.GetInvalidPathChars())
            {
                if (value.IndexOf(ch) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidatePhysicalPath(string strPath)
        {
            if (!ValidatePath(strPath))
            {
                return false;
            }
            return ((strPath.IndexOf(Path.VolumeSeparatorChar) > 0) && ((strPath.IndexOf(Path.DirectorySeparatorChar) > 0) | (strPath.IndexOf(Path.AltDirectorySeparatorChar) > 0)));
        }

        public static bool WriteFile(string strPath, string strValue)
        {
            return WriteFile(strPath, strValue, false, Encoding.UTF8);
        }

        public static bool WriteFile(string strPath, string strValue, bool blnAppend)
        {
            return WriteFile(strPath, strValue, blnAppend, Encoding.UTF8);
        }

        public static bool WriteFile(string strPath, string strValue, bool blnAppend, Encoding objEncoding)
        {
            bool flag;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(strPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(strPath));
                }
                using (StreamWriter writer = new StreamWriter(strPath, blnAppend, objEncoding))
                {
                    writer.Write(strValue);
                }
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
    }
}
