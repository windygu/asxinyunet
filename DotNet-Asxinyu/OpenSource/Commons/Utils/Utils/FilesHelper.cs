namespace Utils
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    /// <summary><para>　</para>
    /// 类名：常用工具类——文件操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>---------------------------------------------------------------------------------------</para><para>　FilesUpload：工具方法：ASP.NET上传文件的方法</para><para>　FileExists：返回文件是否存在</para><para>　IsImgFilename：判断文件名是否为浏览器可以直接显示的图片文件名</para><para>　CopyFiles：复制指定目录的所有文件</para><para>　MoveFiles：移动指定目录的所有文件</para><para>　DeleteDirectoryFiles：删除指定目录的所有文件和子目录</para><para>　DeleteFiles：删除指定目录下的指定文件</para><para>　CreateDirectory：创建指定目录</para><para>　CreateDirectory：建立子目录</para><para>　ReNameFloder：重命名文件夹</para><para>　DeleteDirectory：删除指定目录</para><para>　DirectoryIsExists：检测目录是否存在[+2方法重载]</para><para>　DeleteSubDirectory：删除指定目录的所有子目录,不包括对当前目录文件的删除</para><para>　GetFileWriteTime：获取文件最后修改时间</para><para>　GetFileExtension：返回指定路径的文件的扩展名</para><para>　IsHiddenFile：判断是否是隐藏文件</para><para>　ReadTxtFile：以只读方式读取文本文件</para><para>　WriteStrToTxtFile：将内容写入文本文件(如果文件path存在就打开，不存在就新建)</para><para>　GetLocalDrives：获取本地驱动器名列表</para><para>　GetAppCurrentDirectory：获取应用程序当前可执行文件的路径</para><para>　GetFileSize：获取文件大小并以B，KB，GB，TB方式表示[+2 重载]</para><para>　DownLoadFiles:下载文件</para></summary>
    public class FilesHelper
    {
        private const string x0bf0ba3f4e03ef32 = @"\";

        /// <summary>复制指定目录的所有文件</summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,覆盖同名文件,否则不覆盖</param>
        /// <param name="copySubDir">如果为true,包含目录,否则不包含</param>
        public static void CopyFiles(string sourceDir, string targetDir, bool overWrite, bool copySubDir)
        {
            string str;
            string str2;
            int num;
            string[] files = Directory.GetFiles(sourceDir);
            goto Label_0087;
        Label_000F:
            num++;
        Label_0013:
            if (num < files.Length)
            {
                str = files[num];
                str2 = Path.Combine(targetDir, str.Substring(str.LastIndexOf(@"\") + 1));
                if (!File.Exists(str2) || ((uint) overWrite) - ((uint) copySubDir) > uint.MaxValue || ((uint) num) - ((uint) num) > uint.MaxValue)
                    File.Copy(str, str2, overWrite);
                else if (overWrite) goto Label_0034;
                goto Label_000F;
            }
            if ((((uint) num) | 0xff) != 0)
            {
                if (((uint) copySubDir) - ((uint) num) >= 0) return;
                goto Label_0087;
            }
        Label_0034:
            File.SetAttributes(str2, FileAttributes.Normal);
            File.Copy(str, str2, overWrite);
            goto Label_000F;
        Label_0087:
            num = 0;
            goto Label_0013;
        }

        /// <summary>创建指定目录</summary>
        /// <param name="targetDir"></param>
        public static void CreateDirectory(string targetDir)
        {
            DirectoryInfo info = new DirectoryInfo(targetDir);
            if (0x7fffffff != 0) goto Label_001B;
        Label_000E:
            info.Create();
            if (15 != 0) return;
        Label_001B:
            if (!info.Exists) goto Label_000E;
        }

        /// <summary>建立子目录</summary>
        /// <param name="parentDir">目录路径</param>
        /// <param name="subDirName">子目录名称</param>
        public static void CreateDirectory(string parentDir, string subDirName) { CreateDirectory(parentDir + @"\" + subDirName); }

        /// <summary>删除指定目录</summary>
        /// <param name="targetDir">目录路径</param>
        public static void DeleteDirectory(string targetDir)
        {
            DirectoryInfo info = new DirectoryInfo(targetDir);
            do
            {
                if (0 == 0 && !info.Exists) return;
                DeleteDirectoryFiles(targetDir, true);
                info.Delete(true);
            }
            while (0 != 0);
        }

        /// <summary>删除指定目录的所有文件和子目录</summary>
        /// <param name="TargetDir">操作目录</param>
        /// <param name="delSubDir">如果为true,包含对子目录的操作</param>
        public static void DeleteDirectoryFiles(string TargetDir, bool delSubDir)
        {
            DirectoryInfo[] directories;
            int num2;
            string[] files = Directory.GetFiles(TargetDir);
            int index = 0;
            goto Label_009B;
        Label_0042:
            while (num2 < directories.Length)
            {
                DirectoryInfo info2 = directories[num2];
                DeleteDirectoryFiles(info2.FullName, true);
                info2.Delete();
                if (((uint) delSubDir) + ((uint) num2) < 0) goto Label_0054;
                num2++;
            }
            if (2 != 0) return;
            goto Label_0060;
        Label_0054:
            num2 = 0;
            goto Label_0042;
        Label_0060:
            if (2 == 0) goto Label_0042;
            directories = new DirectoryInfo(TargetDir).GetDirectories();
            goto Label_0054;
        Label_009B:
            if (index >= files.Length)
            {
                if (!delSubDir) return;
                if (0 != 0) return;
                goto Label_0060;
            }
            string path = files[index];
            File.SetAttributes(path, FileAttributes.Normal);
            do
            {
                File.Delete(path);
            }
            while (((uint) num2) - ((uint) index) > uint.MaxValue);
            index++;
            goto Label_009B;
        }

        /// <summary>删除指定目录下的指定文件</summary>
        /// <param name="TargetFileDir">指定文件的目录</param>
        public static void DeleteFiles(string TargetFileDir) { File.Delete(TargetFileDir); }

        /// <summary>删除指定目录的所有子目录,不包括对当前目录文件的删除</summary>
        /// <param name="targetDir">目录路径</param>
        public static void DeleteSubDirectory(string targetDir)
        {
            foreach (string str in Directory.GetDirectories(targetDir))
            {
                DeleteDirectory(str);
            }
        }

        /// <summary>检测目录是否存在</summary>
        /// <param name="StrPath">路径</param>
        /// <returns></returns>
        public static bool DirectoryIsExists(string StrPath)
        {
            DirectoryInfo info = new DirectoryInfo(StrPath);
            return info.Exists;
        }

        /// <summary>检测目录是否存在</summary>
        /// <param name="StrPath">路径</param>
        /// <param name="Create">如果不存在，是否创建</param>
        public static void DirectoryIsExists(string StrPath, bool Create)
        {
            DirectoryInfo info = new DirectoryInfo(StrPath);
            while (!info.Exists && ((uint) Create) + ((uint) Create) >= 0)
            {
                if (Create)
                {
                    info.Create();
                    return;
                }
                if (((uint) Create) + ((uint) Create) <= uint.MaxValue) return;
            }
        }

        /// <summary>下载文件</summary>
        /// <param name="FileFullPath">下载文件下载的完整路径及名称</param>
        public static void DownLoadFiles(string FileFullPath)
        {
            FileInfo info;
            int num;
            byte[] buffer;
            long length;
            if (string.IsNullOrEmpty(FileFullPath)) return;
            if (((uint) length) + ((uint) length) >= 0) goto Label_0182;
        Label_0026:
            buffer = new byte[num];
            using (FileStream stream = info.Open(FileMode.Open))
            {
                int num2;
                goto Label_0041;
            Label_0037:
                if (0 != 0) goto Label_004B;
                Thread.Sleep(10);
            Label_0041:
                if (stream.Position < 0) return;
            Label_004B:
                if (HttpContext.Current.Response.IsClientConnected) goto Label_0065;
                return;
            Label_005E:
                if (num2 > 0) goto Label_0072;
                return;
            Label_0065:
                num2 = stream.Read(buffer, 0, num);
                goto Label_005E;
            Label_0072:
                HttpContext.Current.Response.OutputStream.Write(buffer, 0, num2);
                HttpContext.Current.Response.Flush();
                if (((uint) num2) - ((uint) num) >= 0) goto Label_0037;
            }
            return;
        Label_0182:
            if (0 != 0) return;
        Label_00C8:
            if (FileExists(FileFullPath))
            {
                info = new FileInfo(FileFullPath);
                FileFullPath = HttpUtility.UrlEncode(FileFullPath);
                FileFullPath = FileFullPath.Replace("+", "%20");
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                if (0 != 0) goto Label_00C8;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileFullPath);
                length = info.Length;
                HttpContext.Current.Response.AppendHeader("content-length", length.ToString());
                num = 0x19000;
                if (((uint) length) + ((uint) num) <= uint.MaxValue) goto Label_0026;
                goto Label_0182;
            }
        }

        /// <summary>返回文件是否存在</summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename) { return File.Exists(filename); }

        /// <summary>工具方法：上传文件的方法</summary>
        /// <param name="myFileUpload">上传控件的ID</param>
        /// <param name="allowExtensions">允许上传的扩展文件名类型,如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>
        /// <param name="maxLength">允许上传的最大大小，以M为单位</param>
        /// <param name="savePath">保存文件的目录，注意是绝对路径,如：Server.MapPath("~/upload/");</param>
        /// <param name="saveName">保存的文件名，如果是""则以原文件名保存</param>
        public static void FilesUpload(FileUpload myFileUpload, string[] allowExtensions, int maxLength, string savePath, string saveName)
        {
            string str;
            string str2;
            int num;
            bool flag = false;
            if (myFileUpload.HasFile) goto Label_0117;
            goto Label_0043;
        Label_0025:
            throw new Exception("文件格式不符，可以上传的文件格式为：" + str2);
        Label_0043:
            throw new Exception("请选择要上传的文件！");
        Label_0055:
            if (str == allowExtensions[num]) goto Label_0110;
        Label_0063:
            num++;
        Label_0067:
            if (num < allowExtensions.Length)
            {
                str2 = str2 + ((num == allowExtensions.Length - 1) ? allowExtensions[num] : (allowExtensions[num] + ","));
                if (((uint) maxLength) + ((uint) maxLength) >= 0) goto Label_0055;
                goto Label_0110;
            }
            while (flag)
            {
                try
                {
                    string filename = savePath + ((saveName == "") ? myFileUpload.FileName : saveName);
                    myFileUpload.SaveAs(filename);
                    return;
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                if (((uint) num) - ((uint) maxLength) >= 0) goto Label_0025;
            }
            if (((uint) maxLength) + ((uint) num) < 0) goto Label_0163;
            goto Label_0025;
        Label_00D0:
            num = 0;
            goto Label_0067;
        Label_0110:
            flag = true;
            goto Label_01A7;
        Label_0117:
            if (myFileUpload.PostedFile.ContentLength / 0x400 / 0x400 >= maxLength) throw new Exception("只能上传小于2M的文件！");
        Label_0131:
            str = Path.GetExtension(myFileUpload.FileName).ToLower();
            if (((uint) flag) - ((uint) flag) > uint.MaxValue) goto Label_00D0;
            str2 = "";
        Label_0163:
            if (0 != 0) goto Label_0055;
            if (((uint) flag) + ((uint) maxLength) >= 0) goto Label_00D0;
            goto Label_01A7;
            if (3 != 0) goto Label_0131;
            if (0 != 0) goto Label_0043;
            goto Label_0117;
        Label_01A7:
            if (((uint) maxLength) <= uint.MaxValue) goto Label_0063;
        }

        /// <summary>获取应用程序当前可执行文件的路径</summary>
        /// <returns></returns>
        public static string GetAppCurrentDirectory() { return Application.StartupPath; }

        /// <summary>获取指定目录下所有文件夹</summary>
        /// <param name="DirectoryPath">上一级目录</param>
        /// <returns></returns>
        public static ArrayList GetDirectoryArr(string DirectoryPath)
        {
            string[] directories;
            int num;
            DirectoryInfo info;
            ArrayList list = new ArrayList();
            if (((uint) num) + ((uint) num) >= 0)
            {
                directories = Directory.GetDirectories(DirectoryPath);
                num = 0;
                goto Label_0032;
            }
        Label_001E:
            if (0 == 0)
            {
            }
            list.Add(info.Name);
            num++;
        Label_0032:
            if (num < directories.Length)
            {
                info = new DirectoryInfo(directories[num]);
                goto Label_001E;
            }
            return list;
        }

        /// <summary>返回指定路径的文件的扩展名</summary>
        /// <param name="PathFileName">完整路径的文件</param>
        /// <returns></returns>
        public string GetFileExtension(string PathFileName) { return Path.GetExtension(PathFileName); }

        /// <summary>获取文件大小并以B，KB，GB，TB方式表示</summary>
        /// <param name="File">文件(FileInfo类型)</param>
        /// <returns></returns>
        public static string GetFileSize(FileInfo File)
        {
            string str = "";
            long length = File.Length;
            if (length >= 0x40000000)
            {
                if (length / 0x400 * 0x400 * 0x400 * 0x400 >= 0x400)
                {
                    str = string.Format("{0:############0.00} TB", ((double) length) / 1024.0 * 1024.0 * 1024.0 * 1024.0);
                    if (0 == 0) return str;
                }
                return string.Format("{0:####0.00} GB", ((double) length) / 1024.0 * 1024.0 * 1024.0);
            }
            if (length < 0x100000)
            {
                if (((uint) length) > uint.MaxValue || length >= 0x400)
                {
                    str = string.Format("{0:####0.00} KB", ((double) length) / 1024.0);
                    if (0 == 0) return str;
                }
            }
            else
                return string.Format("{0:####0.00} MB", ((double) length) / 1024.0 * 1024.0);
            return string.Format("{0:####0.00} Bytes", length);
        }

        /// <summary>获取文件大小并以B，KB，GB，TB方式表示</summary>
        /// <param name="FilePath">文件的具体路径</param>
        /// <returns></returns>
        public static string GetFileSize(string FilePath)
        {
            string str = "";
            FileInfo info = new FileInfo(FilePath);
            long length = info.Length;
            if (length < 0x40000000)
            {
                if (length >= 0x100000) return string.Format("{0:####0.00} MB", ((double) length) / 1024.0 * 1024.0);
                if (length >= 0x400) return string.Format("{0:####0.00} KB", ((double) length) / 1024.0);
            }
            else if (0 == 0)
            {
                if (length / 0x400 * 0x400 * 0x400 * 0x400 < 0x400)
                {
                    if (((uint) length) - ((uint) length) > uint.MaxValue) return str;
                    return string.Format("{0:####0.00} GB", ((double) length) / 1024.0 * 1024.0 * 1024.0);
                }
                return string.Format("{0:########0.00} TB", ((double) length) / 1024.0 * 1024.0 * 1024.0 * 1024.0);
            }
            return string.Format("{0:####0.00} Bytes", length);
        }

        /// <summary>获取文件最后修改时间</summary>
        /// <param name="FileUrl">文件真实路径</param>
        /// <returns></returns>
        public DateTime GetFileWriteTime(string FileUrl) { return File.GetLastWriteTime(FileUrl); }

        /// <summary>获取本地驱动器名列表</summary>
        /// <returns></returns>
        public static string[] GetLocalDrives() { return Directory.GetLogicalDrives(); }

        /// <summary>判断是否是隐藏文件</summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public bool IsHiddenFile(string path) { return File.GetAttributes(path).ToString().LastIndexOf("Hidden") != -1; }

        /// <summary>判断文件名是否为浏览器可以直接显示的图片文件名</summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsImgFilename(string filename)
        {
            string str;
            filename = filename.Trim();
        Label_00AF:
            if (3 == 0)
            {
                if (0xff == 0) goto Label_006A;
            }
            else if (!filename.EndsWith(".") && filename.IndexOf(".") != -1)
            {
                if (-2 != 0)
                {
                }
                str = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                if (str != "jpg" && 0 == 0 && !(str == "jpeg"))
                {
                Label_0024:
                    if (str != "png")
                    {
                        if (0 == 0)
                        {
                            if (!(str == "bmp")) goto Label_006A;
                            if (0 != 0) goto Label_0024;
                        }
                        if (0 == 0) goto Label_00CC;
                        goto Label_00AF;
                    }
                }
            }
            else
                return false;
            goto Label_00CC;
        Label_006A:
            return str == "gif";
        Label_00CC:
            return true;
        }

        /// <summary>移动指定目录的所有文件</summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,覆盖同名文件,否则不覆盖</param>
        /// <param name="moveSubDir">如果为true,包含目录,否则不包含</param>
        public static void MoveFiles(string sourceDir, string targetDir, bool overWrite, bool moveSubDir)
        {
            string str;
            string str2;
            string str3;
            string str4;
            string[] strArray2;
            int num2;
            string[] files = Directory.GetFiles(sourceDir);
            int index = 0;
            goto Label_00C6;
        Label_0013:
            if (num2 < strArray2.Length)
            {
                str3 = strArray2[num2];
                str4 = Path.Combine(targetDir, str3.Substring(str3.LastIndexOf(@"\") + 1));
                if (((uint) overWrite) <= uint.MaxValue) goto Label_003E;
                goto Label_0111;
            }
            if (((uint) num2) + ((uint) overWrite) >= 0) goto Label_0058;
        Label_003E:
            while (!Directory.Exists(str4))
            {
                Directory.CreateDirectory(str4);
                break;
            }
            MoveFiles(str3, str4, overWrite, true);
            Directory.Delete(str3);
            if (0 == 0)
            {
                num2++;
                goto Label_0013;
            }
        Label_0058:
            if (((uint) moveSubDir) >= 0) return;
            goto Label_0111;
        Label_0072:
            strArray2 = Directory.GetDirectories(sourceDir);
            num2 = 0;
            goto Label_0013;
        Label_00B9:
            File.Move(str, str2);
        Label_00C0:
            index++;
        Label_00C6:
            if (index < files.Length)
            {
                str = files[index];
                str2 = Path.Combine(targetDir, str.Substring(str.LastIndexOf(@"\") + 1));
                if (!File.Exists(str2))
                {
                    if ((((uint) num2) | 15) != 0) goto Label_00B9;
                    goto Label_0072;
                }
            }
            else
            {
                if (!moveSubDir) return;
                if ((((uint) num2) & 0) != 0) goto Label_0125;
                goto Label_0072;
            }
        Label_0111:
            if (!overWrite) goto Label_00C0;
            File.SetAttributes(str2, FileAttributes.Normal);
            File.Delete(str2);
        Label_0125:
            if (((uint) num2) > uint.MaxValue) goto Label_00B9;
            File.Move(str, str2);
            goto Label_00C0;
        }

        /// <summary>以只读方式读取文本文件</summary>
        /// <param name="FilePath">文件路径及文件名</param>
        /// <returns></returns>
        public static string ReadTxtFile(string FilePath)
        {
            string str = "";
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string str2 = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        str2 = str2 + reader.ReadLine() + "\r\n";
                        str = str2;
                    }
                }
            }
            return str;
        }

        /// <summary>重命名文件夹</summary>
        /// <param name="OldFloderName">原路径文件夹名称</param>
        /// <param name="NewFloderName">新路径文件夹名称</param>
        /// <returns></returns>
        public static bool ReNameFloder(string OldFloderName, string NewFloderName)
        {
            try
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath("//") + OldFloderName)) Directory.Move(HttpContext.Current.Server.MapPath("//") + OldFloderName, HttpContext.Current.Server.MapPath("//") + NewFloderName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>将内容写入文本文件(如果文件path存在就打开，不存在就新建)</summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="WriteStr">要写入的内容</param>
        /// <param name="FileModes">写入模式：append 是追加写, CreateNew 是覆盖</param>
        public static void WriteStrToTxtFile(string FilePath, string WriteStr, FileMode FileModes)
        {
            FileStream stream = new FileStream(FilePath, FileModes);
            StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("utf-8"));
            writer.WriteLine(WriteStr);
            writer.Close();
            stream.Close();
        }
    }
}
