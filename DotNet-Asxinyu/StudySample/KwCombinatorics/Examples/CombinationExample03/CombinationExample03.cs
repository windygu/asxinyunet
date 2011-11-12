using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class CombinationExample03
    {
        static void Main ()
        {
            Combination combo = new Combination (6, 4);

            combo.Rank = 5;
            Console.WriteLine (combo);

            for (int i = 0; i < combo.Picks; ++i)
                Console.WriteLine (combo[i]);

            combo.Rank = -1;
            Console.WriteLine ("Last={0}", combo.Rank);
        }

        /* Output:
        { 0, 1, 4, 5 }
        0
        1
        4
        5
        Last=14
        */
    }
}
