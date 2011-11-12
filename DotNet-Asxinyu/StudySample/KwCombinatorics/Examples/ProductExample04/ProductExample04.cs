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


    class ProductExample04
    {
        static void Main ()
        {
            List<object> colors = new List<object> { "aqua", "black", "crimson" };

            var things = new List<object>
            {
                new Fruit ("apple"),
                new Furniture ("bench"),
                new Furniture ("chair"),
                new Fruit ("durian"),
                new Fruit ("eggplant")
            };

            List<object>[] lists = new List<object>[] { colors, things };
            int[] counts = new int[] { colors.Count, things.Count };

            foreach (Product prod in new Product (counts).Rows)
            {
                foreach (object coloredThing in Product.Permute (prod, lists))
                    Console.Write ("{0} ", coloredThing);
                Console.WriteLine ();
            }
        }

        /* Output:
        aqua apple
        aqua bench
        aqua chair
        aqua durian
        aqua eggplant
        black apple
        black bench
        black chair
        black durian
        black eggplant
        crimson apple
        crimson bench
        crimson chair
        crimson durian
        crimson eggplant
        */
    }
}
