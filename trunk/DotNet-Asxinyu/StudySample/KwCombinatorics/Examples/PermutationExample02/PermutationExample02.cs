using Kw.Combinatorics;
using System;

namespace Kw.CombinatoricsExamples
{
    class PermutationExample02
    {
        static void Main ()
        {
            string[] textList = new string[] { "one", "two", "three" };

            foreach (Permutation px in new Permutation (textList.Length).AllWidths)
            {
                foreach (string numberText in Permutation.Permute (px, textList))
                    Console.Write ("{0} ", numberText);
                Console.WriteLine ();
            }
        }

        /* Output:
        one
        one two
        two one
        one two three
        one three two
        two one three
        two three one
        three one two
        three two one
        */
    }
}
