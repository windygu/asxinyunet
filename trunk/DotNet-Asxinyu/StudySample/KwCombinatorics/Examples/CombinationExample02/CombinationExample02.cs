using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class CombinationExample02
    {
        static void Main ()
        {
            string[] fruit = new string[] { "apple", "banana", "cherry", "durian" };

            foreach (Combination combo in new Combination (fruit.Length).AllPicks)
            {
                foreach (string item in Combination.Permute (combo, fruit))
                    Console.Write (item + " ");
                Console.WriteLine ();
            }
        }

        /* Output:
        apple
        banana
        cherry
        durian
        apple banana
        apple cherry
        apple durian
        banana cherry
        banana durian
        cherry durian
        apple banana cherry
        apple banana durian
        apple cherry durian
        banana cherry durian
        apple banana cherry durian
        */
    }
}
