using Kw.Combinatorics;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kw.CombinatoricsTest
{
    [TestClass]
    public class PermutationTest01
    {

        #region Test Constructors

        [TestMethod]
        public void Test_Interfaces ()
        {
            Permutation perm = new Permutation (7);

            Assert.IsNotNull (perm as ICloneable);
            Assert.IsNotNull (perm as IComparable);
            Assert.IsNotNull (perm as System.Collections.IEnumerable);
            Assert.IsNotNull (perm as IComparable<Permutation>);
            Assert.IsNotNull (perm as IEquatable<Permutation>);
            Assert.IsNotNull (perm as IEnumerable<int>);
        }

        [TestMethod]
        public void Test_Ctor0 ()
        {
            Permutation target = new Permutation ();
            Assert.AreEqual (0, target.Rank);
            Assert.AreEqual (0, target.Width);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1A_ArgumentOutOfRangeException1 ()
        {
            Permutation target = new Permutation (-1);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1A_ArgumentOutOfRangeException2 ()
        {
            Permutation target = new Permutation (100);
        }

        [TestMethod]
        public void Test_Ctor1A ()
        {
            for (int r = 0; r <= Permutation.MaxWidth; ++r)
            {
                Permutation target = new Permutation (r);
                Assert.AreEqual (r, target.Width);

                for (int i = 0; i < target.Width; ++i)
                    Assert.AreEqual (i, target[i]);
            }
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void Test_Ctor1B_ArgumentException1 ()
        {
            int[] source = new int[] { 0, 2, 1, 1 };
            Permutation p0 = new Permutation (source);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void Test_Ctor1B_ArgumentException2 ()
        {
            int[] source = new int[] { 2, 1, 1 };
            Permutation p0 = new Permutation (source);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1B_ArgumentOutOfRangeException1 ()
        {
            int[] source = new int[] { 2, 0, 3 };
            Permutation p0 = new Permutation (source);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1B_ArgumentOutOfRangeException2 ()
        {
            int[] source = new int[] { -1, 0, 1 };
            Permutation p0 = new Permutation (source);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1B_ArgumentOutOfRangeException3 ()
        {
            int[] source = new int[Permutation.MaxWidth + 1];
            for (int i = 0; i < source.Length; ++i)
                source[i] = i;

            Permutation p0 = new Permutation (source);
        }

        [TestMethod]
        public void Test_Ctor1B ()
        {
            int[] source = new int[] { 2, 1, 0 };
            Permutation p0 = new Permutation (source);

            for (int k = 0; k < source.Length; ++k)
                Assert.AreEqual (source[k], p0[k]);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor2_ArgumentOutOfRangeException1 ()
        {
            Permutation p2 = new Permutation (-1, 0);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor2_ArgumentOutOfRangeException2 ()
        {
            Permutation p2 = new Permutation (21, 0);
        }

        [TestMethod]
        public void Test_Ctor2 ()
        {
            for (int r = 0; r <= Permutation.MaxWidth; ++r)
            {
                Permutation target = new Permutation (r, 0);
                Assert.AreEqual (r, target.Width);

                for (int i = 0; i < target.Width; ++i)
                    Assert.AreEqual (i, target[i]);
            }

            int order = 3;
            Permutation p = new Permutation (order, -1);
            Assert.AreEqual (Permutation.Factorial (order) - 1, p.Rank);
        }

        #endregion

        #region Test Properties

        [TestMethod]
        public void Test_AllWidths ()
        {
            int[][] expected = new int[][]
            {
                new int[] { 0 },
                new int[] { 0, 1 }, new int[] { 1, 0 },
                new int[] { 0, 1, 2 }, new int[] { 0, 2, 1 }, new int[] { 1, 0, 2 },
                new int[] { 1, 2, 0 }, new int[] { 2, 0, 1 }, new int[] { 2, 1, 0 }
            };

            int actualCount = 0;
            foreach (Permutation px in new Permutation (3).AllWidths)
            {
                int[] expectedSet = expected[actualCount];
                int exlen = expectedSet.Length;
                Assert.AreEqual (exlen, px.Width);

                for (int i = 0; i < exlen; ++i)
                    Assert.AreEqual (expectedSet[i], px[i]);

                ++actualCount;
            }
            Assert.AreEqual (expected.Length, actualCount);
        }


        [TestMethod]
        public void Test_Rows_Empty ()
        {
            Permutation source = new Permutation ();

            int actualCount = 0;
            foreach (Permutation p in source.Rows)
                ++actualCount;

            Assert.AreEqual (0, actualCount);
        }

        [TestMethod]
        public void Test_Rows ()
        {
            int order = 3;
            long startRank = 2;
            Permutation source = new Permutation (order, startRank);

            long actualCount = 0;
            long? firstRank = null;
            long? lastRank = null;

            foreach (Permutation p in source.Rows)
            {
                if (!firstRank.HasValue)
                    firstRank = p.Rank;

                ++actualCount;
                lastRank = p.Rank;
            }

            Assert.AreEqual (Permutation.Factorial (order), actualCount);
            Assert.AreEqual (startRank, firstRank);
            Assert.AreEqual (1, lastRank);
        }

        #endregion

        #region Test Methods


        [TestMethod]
        public void Test_Clone ()
        {
            int[] list = new int[] { 2, 0, 1 };
            Permutation source = new Permutation (list);
            Permutation target = (Permutation) source.Clone ();

            Assert.AreEqual (list.Length, target.Width);

            for (int k = 0; k < list.Length; ++k)
                Assert.AreEqual (source[k], target[k]);
        }


        [TestMethod]
        public void Test_CompareTo_OBJECT ()
        {
            var objectSortedList = new System.Collections.SortedList ();
            objectSortedList.Add (new Permutation (8, 2), 0);
            objectSortedList.Add (new Permutation (8, 6), 2);
            objectSortedList.Add (new Permutation (8, 4), 1);

            int expectedIndex = 0;
            foreach (System.Collections.DictionaryEntry item in objectSortedList)
            {
                int actualIndex = (int) item.Value;
                Assert.AreEqual (expectedIndex, actualIndex);
                expectedIndex++;
            }

            Assert.AreEqual (3, expectedIndex);
        }

        [TestMethod]
        public void Test_CompareTo ()
        {
            Permutation p0 = null;
            Permutation p520 = new Permutation (5, 0);
            Permutation p521 = new Permutation (5, 1);

            int actual1 = p520.CompareTo (p0);
            Assert.IsTrue (actual1 > 0);

            int actual2 = p520.CompareTo (p521);
            Assert.IsTrue (actual2 < 0);
        }


        [TestMethod]
        public void Test_GetHashCode ()
        {
            Permutation source = new Permutation (3);
            int hash = source.GetHashCode ();
        }


        [TestMethod]
        public void Test_Equals_OBJECT ()
        {
            Permutation p0 = null;
            Permutation p30a = new Permutation (3);
            Permutation p30b = new Permutation (3);
            Permutation p31 = new Permutation (3, 1);
            Permutation p4 = new Permutation (4);

            object j0 = (object) p0;
            object j30b = (object) p30b;
            object j31 = (object) p31;
            object j4 = (object) p4;

            Assert.IsFalse (p30a.Equals (j0));
            Assert.IsTrue (p30a.Equals (j30b));
            Assert.IsFalse (p30a.Equals (j31));
            Assert.IsFalse (p30a.Equals (j4));
        }


        [TestMethod]
        public void Test_Equals ()
        {
            Permutation p0 = null;
            Permutation p30a = new Permutation (3);
            Permutation p30b = new Permutation (3);
            Permutation p31 = new Permutation (3, 1);
            Permutation p4 = new Permutation (4);

            Assert.IsFalse (p30a.Equals (p0));
            Assert.IsTrue (p30a.Equals (p30b));
            Assert.IsFalse (p30a.Equals (p31));
            Assert.IsFalse (p30a.Equals (p4));
        }

        [TestMethod]
        public void Test_Equals_Other_Type ()
        {
            Combination c54 = new Combination (5, 4, 1);
            string s = "Mazzy";

            // Comparing to different type returns false.
            Assert.IsFalse (c54.Equals (s));
        }


        [TestMethod]
        public void Test_GetEnumerator_OBJECT ()
        {
            Permutation perm = new Permutation (7);

            System.Collections.IEnumerator nu = ((System.Collections.IEnumerable) perm).GetEnumerator ();

            int expected = 0;
            while (nu.MoveNext ())
            {
                int actual = (int) nu.Current;
                Assert.AreEqual (expected, actual);
                ++expected;
            }

            Assert.AreEqual (perm.Width, expected);
        }

        [TestMethod]
        public void Test_GetEnumerator ()
        {
            int order = 6;
            Permutation p0 = new Permutation (order, -1);

            int expectedValue = order;
            foreach (int actualValue in p0)
            {
                expectedValue--;
                Assert.AreEqual (expectedValue, actualValue);
            }

            Assert.AreEqual (0, expectedValue);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void Test_Permute_ArgumentException ()
        {
            Permutation source = new Permutation (4);
            string[] pattern = new string[] { "A", "B", "C" };

            List<string> target = Permutation.Permute (source, pattern);
        }


        [TestMethod]
        public void Test_Permute ()
        {
            Permutation p0 = new Permutation (3);
            string[] pat = new string[] { "A", "B", "C" };

            string[] expected = new string[] { "ABC", "ACB", "BAC", "BCA", "CAB", "CBA" };
            int x = 0;

            foreach (Permutation p in p0.Rows)
            {
                List<string> applied = Permutation.Permute (p, pat);
                string actual = "";

                foreach (object j in applied)
                    actual += (string) j;

                Assert.AreEqual (expected[x], actual);
                ++x;
            }

            Assert.AreEqual (expected.Length, x);
        }


        [TestMethod]
        public void Test_ToString ()
        {
            Permutation target = new Permutation (3);
            string expected = "{ 0, 1, 2 }";
            string actual;
            actual = target.ToString ();
            Assert.AreEqual (expected, actual);
        }

        #endregion

        #region Test Static Methods

        [TestMethod]
        public void Test_Comparison_Ops ()
        {
            Permutation p0 = null;
            Permutation q0 = null;
            Permutation p1 = new Permutation (3, 1);
            Permutation p11 = new Permutation (3, 1);
            Permutation p2 = new Permutation (3, 2);
            Permutation q4 = new Permutation (4, 2);

            Assert.IsTrue (p0 == q0);
            Assert.IsFalse (p0 == p1);
            Assert.IsFalse (p1 == p0);
            Assert.IsTrue (p1 == p11);
            Assert.IsFalse (p1 == p2);

            Assert.IsFalse (p0 != q0);
            Assert.IsTrue (p0 != p1);
            Assert.IsTrue (p1 != p0);
            Assert.IsFalse (p1 != p11);
            Assert.IsTrue (p1 != p2);

            Assert.IsFalse (p0 < q0);
            Assert.IsTrue (p0 < p1);
            Assert.IsFalse (p1 < p0);
            Assert.IsFalse (p1 < p11);
            Assert.IsTrue (p1 < p2);
            Assert.IsFalse (p2 < p1);

            Assert.IsTrue (p0 >= q0);
            Assert.IsFalse (p0 >= p1);
            Assert.IsTrue (p1 >= p0);
            Assert.IsTrue (p1 >= p11);
            Assert.IsFalse (p1 >= p2);
            Assert.IsTrue (p2 >= p1);

            Assert.IsFalse (p0 > q0);
            Assert.IsFalse (p0 > p1);
            Assert.IsTrue (p1 > p0);
            Assert.IsFalse (p1 > p11);
            Assert.IsFalse (p1 > p2);
            Assert.IsTrue (p2 > p1);

            Assert.IsTrue (p0 <= q0);
            Assert.IsTrue (p0 <= p1);
            Assert.IsFalse (p1 <= p0);
            Assert.IsTrue (p1 <= p11);
            Assert.IsTrue (p1 <= p2);
            Assert.IsFalse (p2 <= p1);

            Assert.IsTrue (p2 < q4);
            Assert.IsTrue (p2 != q4);
        }

        [TestMethod]
        public void Test_Factorial ()
        {
            // Exercise the range of a 64-bit integer.
            Assert.AreEqual (1, Permutation.Factorial (0));
            Assert.AreEqual (1, Permutation.Factorial (1));
            Assert.AreEqual (2, Permutation.Factorial (2));
            Assert.AreEqual (6, Permutation.Factorial (3));
            Assert.AreEqual (24, Permutation.Factorial (4));
            Assert.AreEqual (120, Permutation.Factorial (5));
            Assert.AreEqual (720, Permutation.Factorial (6));
            Assert.AreEqual (5040, Permutation.Factorial (7));
            Assert.AreEqual (40320, Permutation.Factorial (8));
            Assert.AreEqual (362880, Permutation.Factorial (9));
            Assert.AreEqual (3628800, Permutation.Factorial (10));
            Assert.AreEqual (39916800, Permutation.Factorial (11));
            Assert.AreEqual (479001600, Permutation.Factorial (12));
            Assert.AreEqual (6227020800, Permutation.Factorial (13));
            Assert.AreEqual (87178291200, Permutation.Factorial (14));
            Assert.AreEqual (1307674368000, Permutation.Factorial (15));
            Assert.AreEqual (20922789888000, Permutation.Factorial (16));
            Assert.AreEqual (355687428096000, Permutation.Factorial (17));
            Assert.AreEqual (6402373705728000, Permutation.Factorial (18));
            Assert.AreEqual (121645100408832000, Permutation.Factorial (19));
            Assert.AreEqual (2432902008176640000, Permutation.Factorial (20));
        }

        #endregion

    }
}
