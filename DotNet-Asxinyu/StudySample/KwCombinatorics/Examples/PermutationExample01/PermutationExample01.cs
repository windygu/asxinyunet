using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class PermutationExample01
    {
        static void Main ()
        {
            foreach (Permutation perm in new Permutation (3).Rows)
                Console.WriteLine (perm);
        }

        /* Output:
        { 0, 1, 2 }
        { 0, 2, 1 }
        { 1, 0, 2 }
        { 1, 2, 0 }
        { 2, 0, 1 }
        { 2, 1, 0 }
        */
    }
}
