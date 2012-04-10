using System;
using System.Threading;
using OrmCommon;

namespace OrmC
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("It shows system time columns:");

            var t1 = new SystemTime {Name = "tom"};
            t1.Save();

            var t2 = SystemTime.FindById(t1.Id);
            Console.WriteLine("1) => {0}", t2);

            Thread.Sleep(2000);
            t1.Save();

            var t3 = SystemTime.FindById(t1.Id);
            Console.WriteLine("2) => {0}", t3);
        }
    }
}
