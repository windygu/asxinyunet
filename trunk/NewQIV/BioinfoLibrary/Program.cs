using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Wacc wacc = new Wacc();
            wacc.GetOneSequenceFeature("a", new object[] { 'a' });
            wacc.GetOneSequenceFeature("b");
            Console.ReadKey();
        }
    }
}
