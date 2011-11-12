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

    class CombinationExample04
    {
        static void Main ()
        {
            object[] allThings = new object[]
            {
                new Fruit ("apple"),
                new Furniture ("bench"),
                new Furniture ("chair"),
                new Fruit ("durian"),
                new Fruit ("eggplant")
            };

            foreach (Combination combo in new Combination (allThings.Length, 3).Rows)
            {
                foreach (var someThings in Combination.Permute (combo, allThings))
                    Console.Write (someThings + " ");
                Console.WriteLine ();
            }
        }

        /* Output:
        apple bench chair
        apple bench durian
        apple bench eggplant
        apple chair durian
        apple chair eggplant
        apple durian eggplant
        bench chair durian
        bench chair eggplant
        bench durian eggplant
        chair durian eggplant
        */
    }
}
