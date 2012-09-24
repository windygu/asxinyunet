using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Bioinfo.Entites;

namespace BioInfo.Forcast
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestKDH();
            //EntityHelper.InitialDb();
            //SvmHelper.Test("train.txt", "test.txt");
            Console.WriteLine(Setting.FindById(1).Value);
            Console.ReadLine();
        }

        #region KDH特征提取测试
        static void TestKDH()
        {
            using (StreamReader sr = new StreamReader("example.txt"))
            {
                string text = sr.ReadToEnd();
                var t= Gpcrgly.SvmTest(text);
            }
        }
        #endregion
    }
}
