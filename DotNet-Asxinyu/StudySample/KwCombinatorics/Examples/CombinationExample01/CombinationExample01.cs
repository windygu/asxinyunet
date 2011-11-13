using Kw.Combinatorics;
using System;
using System.Collections.Generic;

namespace Kw.CombinatoricsExamples
{
    class CombinationExample01
    {
        static void Main ()
        {            
            string[] fruit = new string[] { "apple", "banana", "cherry", "durian" };
            //Combination combo = new Combination(fruit.Length,2);
            
            //    foreach (string item in Combination.Permute(combo, fruit))
            //        Console.Write(item + " ");
            //    Console.WriteLine();

                foreach (Combination combom in new Combination(4, 3).Rows)
                {
                    foreach (string item in Combination.Permute(combom, fruit))
                        Console.Write(item + " ");
                    Console.WriteLine();
                }

                    //Console.WriteLine(combo);
            Console.ReadKey();
        }

        /* Output:
        { 0, 1, 2 }
        { 0, 1, 3 }
        { 0, 2, 3 }
        { 1, 2, 3 }
        */
    }
}
