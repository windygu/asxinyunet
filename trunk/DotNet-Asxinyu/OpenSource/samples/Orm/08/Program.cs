
#region usings

using System;
using System.Collections;
using Lephone.Data;
using OrmCommon;

#endregion

namespace Orm8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Using PagedSelector:\n");
            var ps = DbEntry
                .From<SampleData>()
                .Where(Condition.Empty)
                .OrderBy("Id")
                .PageSize(2)
                .GetPagedSelector();

            Show("1st page:", ps.GetCurrentPage(0));

            Show("2nd page:", ps.GetCurrentPage(1));

            Show("3rd page:", ps.GetCurrentPage(2));

            Show("last page:", ps.GetCurrentPage(4));
        }

        private static void Show(string showString, ICollection ic)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(showString);
            int i = 0;
            foreach (object o in ic)
            {
                Console.Write("({0})", ++i);
                if (o == null)
                {
                    Console.WriteLine("<NULL>");
                }
                else
                {
                    Console.WriteLine(o);
                }
            }
            Console.WriteLine();
        }
    }
}
