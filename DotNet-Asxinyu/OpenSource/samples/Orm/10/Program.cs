using System;
using OrmCommon;
using Lephone.Data;

namespace OrmA
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Cache Sample");
            Console.WriteLine("====================================");
            var d = SampleData.FindById(1);

            Console.WriteLine(d);
            Console.WriteLine();

            d.Name = "test cache";
            d.Save();

            d = SampleData.FindById(1);
            Console.WriteLine(d);
            Console.WriteLine();

            d.Name = "( 1)liang lifeng";
            d.Save();


            try
            {
                DbEntry.UsingTransaction(delegate()
                {
                    // emulate exception of transaction
                    int m = 0;
                    int n = 1 / m;
                });
            }
            catch { }

            d = SampleData.FindById(1);
            Console.WriteLine(d);
            Console.WriteLine();
        }
    }
}
