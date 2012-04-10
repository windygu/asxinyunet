
#region usings

using System;
using System.Collections;

using Lephone.Data;

using OrmCommon;

#endregion

namespace Orm7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Using multi key:\n");

            Console.WriteLine("Origin table:");
            Show();

            var t1 = new MKey("aa", 17, true);
            var t2 = new MKey("aa", 20, false);

            Console.WriteLine("Insert two items:");
            DbEntry.Insert(t1);
            DbEntry.Insert(t2);
            Show();

            Console.WriteLine("Update 2nd item:");
            t2.Gender = true;
            DbEntry.Update(t2);
            Show();

            Console.WriteLine("Delete the items:");
            DbEntry.Delete(t1);
            DbEntry.Delete(t2);
            Show();
        }

        private static void Show()
        {
            IList dic = DbEntry.From<MKey>().Where(Condition.Empty).OrderBy(p => p.Age).Select();
            foreach (object o in dic)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
        }
    }
}
