using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class PermutationExample05
    {
        static void Main ()
        {
            Permutation perm = new Permutation (4, 2);

            foreach (int element in perm)
                Console.WriteLine ("Element=" + element);
        }

        /* Output:
        Element=0
        Element=2
        Element=1
        Element=3
        */
    }
}
