namespace DotNet.Core.Commons
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 文件处理类
    /// </summary>
    public class IOHelper
    {
        #region 复制文件夹
        /// <summary>
        /// 复制文件夹,默认覆盖
        /// </summary>
        /// <param name="strPathSrc">原始文件路径</param>
        /// <param name="strPathDest">目的路径</param>
        /// <param name="blnOverwrite">是否覆盖</param>
        /// <returns>是否成功</returns>
        public static bool CopyFolder(string strPathSrc, string strPathDest, bool blnOverwrite = true )
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
        #endregion

        #region 计算文件夹数
        /// <summary>
        /// 计算文件数目
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="filter">文件过滤，后缀名</param>
        /// <returns>返回文件夹包含制定文件的数目</returns>
        public static int CountFiles(string path, string filter = "")
        {
            if (!Directory.Exists(path))
            {
                return 0;
            }
            return Directory.GetFiles(path, filter).Length;
        }
        #endregion

        #region 计算文件的大小（KB）
        /// <summary>
        /// 计算文件的大小（KB）
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <returns>文件大小，单位KB</returns>
        public static int GetFileSizeKbytes(string strPath)
        {
            FileInfo info = new FileInfo(strPath);
            if (info.Exists)
            {
                return Convert.ToInt32((double) (((double) info.Length) / 1024.0));
            }
            return 0;
        }
        #endregion

        #region 计算文件夹的大小(MB)
        public static long GetFolderSizeMbytes(string strPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(strPath))
                return 0;
            long len = 0;
            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(strPath);
            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetFolderSizeMbytes(dis[i].FullName);
                }
            }
            return Convert.ToInt64 (len/1024/1024) ;
        }
        #endregion

        #region 读取数据
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <param name="objEncoding">编码</param>
        /// <returns>读取出来的字符串</returns>
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
        #endregion

        #region 验证路径是否合法
        /// <summary>
        /// 验证路径是否合法
        /// </summary>
        /// <param name="value">文件路径字符串</param>
        /// <returns>是否合法</returns>
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
        #endregion

        #region 验证物理路径是否合法
        /// <summary>
        /// 验证物理路径是否合法
        /// </summary>
        /// <param name="strPath">物理路径</param>
        /// <returns>是否合法</returns>
        public static bool ValidatePhysicalPath(string strPath)
        {
            if (!ValidatePath(strPath))
            {
                return false;
            }
            return ((strPath.IndexOf(Path.VolumeSeparatorChar) > 0) && ((strPath.IndexOf(Path.DirectorySeparatorChar) > 0) | (strPath.IndexOf(Path.AltDirectorySeparatorChar) > 0)));
        }
        #endregion

        #region 写文件
        /// <summary>
        /// 将字符串数据写入制定文件
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <param name="strValue">写入的字符串数据</param>
        /// <param name="objEncoding">编码</param>
        /// <param name="blnAppend">是否追加</param>
        /// <returns>是否成功</returns>
        public static bool WriteFile(string strPath, string strValue, Encoding objEncoding,bool blnAppend = false)
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
        #endregion
    }
}
