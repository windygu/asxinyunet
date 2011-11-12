using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class ProductExample01
    {
        static void Main ()
        {
            foreach (Product prod in new Product (new int[] { 2, 3, 2 }).Rows)
                Console.WriteLine (prod);
        }

        /* Output:
        { 0, 0, 0 }
        { 0, 0, 1 }
        { 0, 1, 0 }
        { 0, 1, 1 }
        { 0, 2, 0 }
        { 0, 2, 1 }
        { 1, 0, 0 }
        { 1, 0, 1 }
        { 1, 1, 0 }
        { 1, 1, 1 }
        { 1, 2, 0 }
        { 1, 2, 1 }
        */
    }
}
