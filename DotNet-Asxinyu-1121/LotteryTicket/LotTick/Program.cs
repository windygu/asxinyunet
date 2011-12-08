using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoColorBall t = new TwoColorBall(22);            ;
            Console.WriteLine(t.GetAllPageNumbers());
            Console.ReadKey();
        }
    }
}
