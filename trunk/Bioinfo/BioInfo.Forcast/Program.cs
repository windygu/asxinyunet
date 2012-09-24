using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BioInfo.Forcast
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestKDH();
            SvmHelper.Test("train.txt", "test.txt");
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
