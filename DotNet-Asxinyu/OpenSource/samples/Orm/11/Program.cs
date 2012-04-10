using System;
using OrmCommon;

namespace OrmB
{
    class Program
    {
        static void Main()
        {
            var dt = new DateAndTime {StartDate = new Date(2008, 7, 22), StartTime = new Time(12, 30, 50)};
            dt.Save();
            Console.WriteLine("DateAndTime saved with id = {0}", dt.Id);

            var n = DateAndTime.FindById(dt.Id);
            // looks like a .net bug: in Console.WriteLine, n.StartDate are different with n.StartDate.ToString()...
            Console.WriteLine("DateAndTime read as StartDate = {0}, StartTime = {1}", n.StartDate.ToString(), n.StartTime.ToString());

            n.Delete();
        }
    }
}
