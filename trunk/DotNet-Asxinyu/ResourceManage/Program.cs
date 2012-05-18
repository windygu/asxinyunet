using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ResourceManage
{
    static class Program
    {     
        static void Main()
        {
            //string fileName = @"D:\DevelopMent\大蚂蚁客户端.exe";
            //FileInfo fi = new FileInfo(fileName);
            //Console.WriteLine(fi.Extension);

            bool status = true;
            while (status)
            {
                Console.Write("请输入文件夹路径：");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    ResourceHelper.ScanFolder(path);
                }
                else
                {
                    status = false;
                }
            }
            Console.ReadKey();
        }
    }
}