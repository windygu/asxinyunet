using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class ProductExample05
    {
        static void Main ()
        {
            Product prod = new Product (new int[] { 3, 4, 5 });
            prod.Rank = 33;

            foreach (int element in prod)
                Console.WriteLine ("Element=" + element);
        }

        /* Output:
        Element=1
        Element=2
        Element=3
        */
    }
}
