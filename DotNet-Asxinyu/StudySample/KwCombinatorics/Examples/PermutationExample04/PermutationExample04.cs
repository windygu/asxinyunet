using Kw.Combinatorics;
using System;
using System.Collections.Generic;

namespace Kw.CombinatoricsExamples
{
    public class Furniture
    {
        private string name;
        public Furniture (string newName) { name = newName; }
        public override string ToString () { return name; }
    }

    public class Fruit
    {
        private string name;
        public Fruit (string newName) { name = newName; }
        public override string ToString () { return name; }
    }

    class PermutationExample04
    {
        static void Main ()
        {
            var allThings = new List<object>
            {
                new Fruit ("apple"),
                new Furniture ("bench"),
                new Furniture ("chair")
            };

            foreach (Permutation permu in new Permutation (allThings.Count).Rows)
            {
                foreach (var mixedThings in Permutation.Permute (permu, allThings))
                    Console.Write ("{0} ", mixedThings);
                Console.WriteLine ();
            }
        }

        /* Output:
        apple bench chair
        apple chair bench
        bench apple chair
        bench chair apple
        chair apple bench
        chair bench apple
        */
    }
}
