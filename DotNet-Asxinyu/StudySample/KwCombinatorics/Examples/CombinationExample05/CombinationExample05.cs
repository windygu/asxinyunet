using Kw.Combinatorics;
using System;
using System.Collections.Generic;

namespace Kw.CombinatoricsExamples
{
    class CombinationExample05
    {
        static void Main ()
        {
            int n = 10;
            int k = 7;
            Combination c1 = new Combination (n, k, 110);

            foreach (int element in c1)
                Console.WriteLine ("Element=" + element);
        }

        /* Output:
        Element=1
        Element=3
        Element=5
        Element=6
        Element=7
        Element=8
        Element=9
         */
    }
}
