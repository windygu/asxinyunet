using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class Demo1
    {
        //http://www.cnblogs.com/lifepoem/archive/2011/10/25/2223765.html
        //字符串入门基本操作
        static string[] names = { "dbh-董斌辉", "cys", "dbh李少云", "qr" };
        public static void Test1()
        {   
            IEnumerable<string> find = names.Where(n => n.Contains("dbh"));
            foreach (var item in find )
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
        }
        public static void Test2()
        {
            IEnumerable<string> find = from n in names where n.Contains("dbh") select n;
            foreach (var item in find)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
        }
        public static void Test3()
        {
            string[] namesT = { "Toma", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> find = namesT.Where(n => n.Contains("a"))
                .OrderBy(n => n.Length).Select(n => n.ToUpper());
            foreach (var item in find) Console.WriteLine(item.ToString());
            Console.WriteLine();
        }
        public static void Test4()
        {
            List<int> arr = new List<int>() {1,2,3,4,5,6,7,8,9 };
            IEnumerable<int> find = arr.Where(n => n >= 5).OrderBy(n => n).Select(n => n * n);
            foreach (var item in find )
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Demo1.Test4();            
            Console.ReadKey();
        }
    }
}
