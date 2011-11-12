using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class ProductExample03
    {
        static void Main ()
        {
            Product prod = new Product (new int[] { 7, 6, 5 });

            prod.Rank = 43;
            Console.WriteLine (prod);

            for (int i = 0; i < prod.Width; ++i)
                Console.WriteLine (prod[i]);

            prod.Rank = -1;
            Console.WriteLine ("Last={0}", prod.Rank);
        }

        /* Output:
        { 1, 2, 3 }
        1
        2
        3
        Last=209
        */
    }
}
