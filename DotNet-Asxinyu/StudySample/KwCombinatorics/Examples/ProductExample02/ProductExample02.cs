using Kw.Combinatorics;
using System;
using System.Collections.Generic;

namespace Kw.CombinatoricsExamples
{
    class ProductExample02
    {
        static void Main ()
        {
            string[] first = new string[] { "Alice", "Bob", "Carol", "David" };
            string[] last = new string[] { "Smith", "Jones" };
            string[][] nameRows = new string[][] { first, last };

            foreach (Product prod in new Product (new int[] { first.Length, last.Length }).Rows)
            {
                List<string> nameProduct = Product.Permute (prod, nameRows);

                foreach (string fullName in nameProduct)
                    Console.Write ("{0} ", fullName);
                Console.WriteLine ();
            }
        }

        /* Output:
        Alice Smith
        Alice Jones
        Bob Smith
        Bob Jones
        Carol Smith
        Carol Jones
        David Smith
        David Jones
        */
    }
}
