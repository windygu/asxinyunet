using Kw.Combinatorics;
using System;
using System.Collections.Generic;

namespace Kw.CombinatoricsExamples
{
    class CombinationExample01
    {
        static void Main ()
        {
            foreach (Combination combo in new Combination (4, 3).Rows)
                Console.WriteLine (combo);
        }

        /* Output:
        { 0, 1, 2 }
        { 0, 1, 3 }
        { 0, 2, 3 }
        { 1, 2, 3 }
        */
    }
}
