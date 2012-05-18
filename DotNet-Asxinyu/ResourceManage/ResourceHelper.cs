using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

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
            ArrayList resArray = new ArrayList();
            string[] files = Directory.GetFiles(folderName, "*");
            //将当前文件信息添加到数据库
            foreach (var item in files )
            {
                if (File.Exists(item))
                    GetFileInfo(item);//添加到数据库
            }
            Console.WriteLine("文件夹扫描完成:{0}",folderName );
            string[] folders = Directory.GetDirectories(folderName);
            //遍历所有文件夹
            foreach (var item in folders) ScanFolder(item);            
        }

        public static void GetFileInfo(string fileName)
        {
            ResourceInfo model = new ResourceInfo();            
            model.Md5 = MD5Hash(fileName);
            if (ResourceInfo.FindAllByName(ResourceInfo._.Md5, model.Md5, "", 0, 0).Count > 0)
            {
                model.PublishingCompany = "暂无";
                FileInfo fi = new FileInfo(fileName);
                model.Keywords = fi.Name;
                model.Author = "暂无";
                model.BigCategory = "暂无分类";
                model.SmallCategory = "暂无分类";
                model.Source = "网络";
                model.ContentIntroduce = "暂无介绍";
                model.Format = fi.Extension.Replace(".", "");
                model.ISBN = string.Empty;
                model.PublishingDate = DateTime.Now;
                model.Remark = string.Empty;
                model.ResourceName = fi.Name;
                model.ResourceScore = 7;
                model.Size = (int)(fi.Length / 1024);//Kb
                model.StorageLocation = fileName.Substring(1, fileName.Length - 1);//只存储相对位置，把盘符去掉               
                model.Insert();
            }
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
