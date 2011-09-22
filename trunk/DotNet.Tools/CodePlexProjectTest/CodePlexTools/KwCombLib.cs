/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-18
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Kw.Combinatorics ;
using System.Security.Cryptography ;

namespace CodePlexTools
{
	/// <summary>
	///KwCombinatorics library项目，用于排列组合的生成
	/// </summary>
	public class KwCombLib
	{
		public static void GetCombin()
		{
			Combination com = new Combination(33,6) ;
			
			var res = com.Rows ;
			foreach (var s in res )
			{
				foreach (var element in s ) {
					Console.Write (element.ToString () +"  ") ;
				}
				Console.WriteLine () ;
			}
			Console.WriteLine (com.Rank .ToString ());
			
//			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider ("asdasdfa") ;
//			byte[] res = new byte[6] ;
//			rng.GetBytes (res ) ;
//			foreach (var element in res) {
//				Console.WriteLine( (element%34).ToString ()) ;
//			}
		}
	}
	
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
                new Fruit ("1"),
                new Furniture ("2"),
                new Furniture ("3"),
                new Fruit ("4"),
                new Fruit ("5")
            };
            KwCombLib.GetCombin () ;
//            var  res1 =  new Combination (allThings.Length, 3).Rows ;
//            foreach (Combination combo in res1)
//            {
//            	var res2 = Combination.Permute (combo, allThings) ;
//            	foreach (var someThings in res2)
//            		Console.Write (someThings + " ");
//            	Console.Write (combo.ToString ()) ;
//            	Console.WriteLine ();
//            }
            Console.ReadKey () ;
        }
    }
}