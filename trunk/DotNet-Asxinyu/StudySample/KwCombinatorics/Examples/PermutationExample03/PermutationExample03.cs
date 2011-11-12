using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class PermutationExample03
    {
        static void Main ()
        {
            Permutation perm = new Permutation (6);

            perm.Rank = 9;
            Console.WriteLine (perm);

            ++perm.Rank;
            for (int m = 0; m < perm.Width; ++m)
                Console.WriteLine (perm[m]);

            perm.Rank = -1;
            Console.WriteLine ("Last={0}", perm.Rank);
        }

        /* Output:
        { 0, 1, 3, 4, 5, 2 }
        0
        1
        3
        5
        2
        4
        Last=719
        */
    }
}
