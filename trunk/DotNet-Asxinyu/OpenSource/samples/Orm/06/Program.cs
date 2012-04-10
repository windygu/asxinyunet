using System;
using System.Collections;
using Lephone.Data;
using OrmCommon;

namespace Orm6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Using Join table with two way(Only for Select):\n");

            Console.WriteLine("1st:");
            Show(DbEntry.From<JoinTable1>().Where(p => p.Id > 1).OrderBy(p => p.Id).Select());

            Console.WriteLine("2nd:");
            Show(DbEntry.From<JoinTable2>().Where(p => p.Age > 40).OrderBy(p => p.Id).Select());
        }

        private static void Show(ICollection ic)
        {
            foreach (object o in ic)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
        }
    }
}
