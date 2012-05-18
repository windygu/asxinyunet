using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text;

namespace ResourceManage
{
    /// <summary>
    /// 资源管理帮助类
    /// </summary>
    public class ResourceHelper
    {
        public static void ScanFolder(string folderName)
        {
            //扫描指定目录下的所有文件,并添加到数据库

        }

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>        
        public static string MD5Hash(string fileName)
        {
            if (!File.Exists(fileName)) return string.Empty;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                System.Security.Cryptography.HashAlgorithm md5 = System.Security.Cryptography.MD5.Create();
                return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
            }
        }
    }
}
