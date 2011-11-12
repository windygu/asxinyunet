using Kw.Combinatorics;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kw.CombinatoricsTest
{
    [TestClass]
    public class CombinationTest01
    {
        #region Test Constructors

        [TestMethod]
        public void Test_Interfaces ()
        {
            Combination combo = new Combination (4, 2);

            Assert.IsNotNull (combo as ICloneable);
            Assert.IsNotNull (combo as IComparable);
            Assert.IsNotNull (combo as System.Collections.IEnumerable);
            Assert.IsNotNull (combo as IComparable<Combination>);
            Assert.IsNotNull (combo as IEquatable<Combination>);
            Assert.IsNotNull (combo as IEnumerable<int>);
        }

        [TestMethod]
        public void Test_Ctor0 ()
        {
            Combination c0 = new Combination ();
            Assert.AreEqual (0, c0.Choices);
            Assert.AreEqual (0, c0.Picks);
            Assert.AreEqual (0, c0.Rank);
            Assert.AreEqual (0, c0.Height);

            ++c0.Rank;
            Assert.AreEqual (0, c0.Rank);
            --c0.Rank;
            Assert.AreEqual (0, c0.Rank);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1_ArgumentOutOfRangeException ()
        {
            Combination target = new Combination (-3);
        }


        [TestMethod]
        public void Test_Ctor1 ()
        {
            int n = 3;

            Combination c1 = new Combination (n);
            Assert.AreEqual (n, c1.Choices);
            Assert.AreEqual (n, c1.Picks);
            Assert.AreEqual (0, c1.Rank);
            Assert.AreEqual (1, c1.Height);

            ++c1.Rank;
            Assert.AreEqual (0, c1.Rank);
            --c1.Rank;
            Assert.AreEqual (0, c1.Rank);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor2_ArgumentOutOfRangeException1 ()
        {
            Combination target = new Combination (-2, 3);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor2_ArgumentOutOfRangeException2 ()
        {
            Combination target = new Combination (2, -3);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor2_ArgumentOutOfRangeException3 ()
        {
            Combination target = new Combination (2, 3);
        }

        [TestMethod]
        public void Test_Ctor2 ()
        {
            Combination c22 = new Combination (2, 2);
            Assert.AreEqual (1, c22.Height);

            Combination c30 = new Combination (3, 0);
            Assert.AreEqual (0, c30.Height);

            int actualHeight = 0;
            foreach (Combination cx in c30.Rows)
                ++actualHeight;

            Assert.AreEqual (0, actualHeight);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor3_ArgumentOutOfRangeException1 ()
        {
            Combination target = new Combination (-2, 3, 1);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor3_ArgumentOutOfRangeException2 ()
        {
            Combination target = new Combination (2, 3, 0);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor3_ArgumentOutOfRangeException3 ()
        {
            Combination target = new Combination (2, -1, 0);
        }

        #endregion

        #region Test_Properties

        [TestMethod]
        public void Test_AllPicks ()
        {
            int[][] expected = new int[][]
            { new int[] { 0 }, new int[] { 1 }, new int[] { 2 },
              new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 },
              new int[] { 0, 1, 2 }
            };

            Combination combo = new Combination (3);

            int actualCount = 0;
            foreach (Combination cx in combo.AllPicks)
            {
                for (int i = 0; i < cx.Picks; ++i)
                    Assert.AreEqual (expected[actualCount][i], cx[i]);
                ++actualCount;
            }

            Assert.AreEqual (expected.Length, actualCount);
        }

        [TestMethod]
        public void Test_Rows ()
        {
            int[,] expected = new int[,]
            { { 0, 1, 2 },
              { 0, 1, 3 },
              { 0, 1, 4 },
              { 0, 2, 3 },
              { 0, 2, 4 },
              { 0, 3, 4 },
              { 1, 2, 3 },
              { 1, 2, 4 },
              { 1, 3, 4 },
              { 2, 3, 4 }
            };

            Combination c53 = new Combination (5, 3);

            long actualHeight = 0;
            foreach (Combination cx in c53.Rows)
            {
                Assert.IsTrue (actualHeight < cx.Height);

                for (int k = 0; k < cx.Picks; ++k)
                    Assert.AreEqual (expected[actualHeight, k], cx[k]);

                ++actualHeight;
            }

            Assert.AreEqual (c53.Height, actualHeight);
        }

        [TestMethod]
        public void Test_Properties ()
        {
            int n = 8;
            int k = 3;
            long expectedHeight = Permutation.Factorial (n)
                                / (Permutation.Factorial (k) * Permutation.Factorial (n - k));

            Combination combo = new Combination (n, k);
            Assert.AreEqual (n, combo.Choices);
            Assert.AreEqual (k, combo.Picks);
            Assert.AreEqual (expectedHeight, combo.Height);

            combo.Rank = -1;
            Assert.AreEqual (combo.Height - 1, combo.Rank);
        }

        #endregion

        #region Test_Methods

        [TestMethod]
        public void Test_Clone ()
        {
            Combination combo = new Combination (2);
            object j = combo.Clone ();
            Combination c2 = (Combination) combo;
            Assert.AreEqual (0, c2[0]);
            Assert.AreEqual (1, c2[1]);
        }


        [TestMethod]
        public void Test_CompareTo_OBJECT ()
        {
            var objectSortedList = new System.Collections.SortedList ();
            objectSortedList.Add (new Combination (8, 2), 0);
            objectSortedList.Add (new Combination (8, 6), 2);
            objectSortedList.Add (new Combination (8, 4), 1);

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
            Combination c0 = null;
            Combination c520 = new Combination (5, 2, 0);
            Combination c521 = new Combination (5, 2, 1);

            int actual1 = c520.CompareTo (c0);
            Assert.IsTrue (actual1 > 0);

            int actual2 = c520.CompareTo (c521);
            Assert.IsTrue (actual2 < 0);
        }


        [TestMethod]
        public void Test_Equals_OBJECT ()
        {
            Combination c0 = null;
            Combination c438a = new Combination (4, 3, 8);
            Combination c438b = new Combination (4, 3, 8);
            Combination c439 = new Combination (4, 3, 9);
            Combination c6 = new Combination (8, 6, 4);

            object j0 = (object) c0;
            object j438b = (object) c438b;
            object j439 = (object) c439;
            object j6 = (object) c6;

            Assert.IsFalse (c438a.Equals (j0));
            Assert.IsTrue (c438a.Equals (j438b));
            Assert.IsFalse (c438a.Equals (j439));
            Assert.IsFalse (c438a.Equals (j6));
        }

        [TestMethod]
        public void Test_Equals ()
        {
            Combination c0 = null;
            Combination c438a = new Combination (4, 3, 8);
            Combination c438b = new Combination (4, 3, 8);
            Combination c439 = new Combination (4, 3, 9);
            Combination c6 = new Combination (8, 6, 4);

            Assert.IsFalse (c438a.Equals (c0));
            Assert.IsTrue (c438a.Equals (c438b));
            Assert.IsFalse (c438a.Equals (c439));
            Assert.IsFalse (c438a.Equals (c6));
        }


        [TestMethod]
        public void Test_Equals_Other_Type ()
        {
            Combination c54 = new Combination (5, 4, 1);
            string s = "Zappa";

            // Comparing to different type returns false.
            Assert.IsFalse (c54.Equals (s));
        }


        [TestMethod]
        public void Test_GetEnumerator_OBJECT ()
        {
            Combination combo = new Combination (7, 7);

            System.Collections.IEnumerator nu = ((System.Collections.IEnumerable) combo).GetEnumerator ();

            int expected = 0;
            while (nu.MoveNext ())
            {
                int actual = (int) nu.Current;
                Assert.AreEqual (expected, actual);
                ++expected;
            }

            Assert.AreEqual (combo.Picks, expected);
        }

        [TestMethod]
        public void Test_GetEnumerator ()
        {
            int n = 10;
            int k = 9;
            Combination combo = new Combination (n, k);

            int expectedElement = 0;
            foreach (int actualElement in combo)
            {
                Assert.AreEqual (expectedElement, actualElement);
                ++expectedElement;
            }

            Assert.AreEqual (k, expectedElement);
        }


        [TestMethod]
        public void Test_GetHash ()
        {
            Combination combo = new Combination (5);
            int hash = combo.GetHashCode ();
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void Test_Permute_ArgumentException ()
        {
            string[] letters = new string[] { "A", "B", "C", "D" };
            Combination combo = new Combination (6);
            List<string> item = Combination.Permute (combo, letters);
        }

        [TestMethod]
        public void Test_Permute ()
        {
            string[] expected = new string[] { "ABC", "ABD", "ACD", "BCD" };
            string[] letters = new string[] { "A", "B", "C", "D" };

            int actualCount = 0;
            foreach (Combination combo in new Combination (letters.Length, letters.Length - 1).Rows)
            {
                string a = "";
                foreach (string item in Combination.Permute (combo, letters))
                    a += item;

                Assert.AreEqual (expected[actualCount], a);
                ++actualCount;
            }

            Assert.AreEqual (expected.Length, actualCount);
        }


        [TestMethod]
        public void Test_ToString ()
        {
            Combination combo = new Combination (3);
            Assert.AreEqual ("{ 0, 1, 2 }", combo.ToString ());
        }

        #endregion

        #region Test Static Methods

        [TestMethod]
        public void Test_Comparison_Ops ()
        {
            Combination c0 = null;
            Combination d0 = null;
            Combination c1 = new Combination (6, 3, 7);
            Combination c11 = new Combination (6, 3, 7);
            Combination c2 = new Combination (6, 3, 9);
            Combination c3 = new Combination (9, 2, 15);
            Combination c4 = new Combination (8, 2, 15);

            Assert.IsTrue (c0 == d0);
            Assert.IsFalse (c0 == c1);
            Assert.IsFalse (c1 == c0);
            Assert.IsTrue (c1 == c11);
            Assert.IsFalse (c1 == c2);

            Assert.IsFalse (c0 != d0);
            Assert.IsTrue (c0 != c1);
            Assert.IsTrue (c1 != c0);
            Assert.IsFalse (c1 != c11);
            Assert.IsTrue (c1 != c2);

            Assert.IsFalse (c0 < d0);
            Assert.IsTrue (c0 < c1);
            Assert.IsFalse (c1 < c0);
            Assert.IsFalse (c1 < c11);
            Assert.IsTrue (c1 < c2);
            Assert.IsFalse (c2 < c1);

            Assert.IsTrue (c0 >= d0);
            Assert.IsFalse (c0 >= c1);
            Assert.IsTrue (c1 >= c0);
            Assert.IsTrue (c1 >= c11);
            Assert.IsFalse (c1 >= c2);
            Assert.IsTrue (c2 >= c1);

            Assert.IsFalse (c0 > d0);
            Assert.IsFalse (c0 > c1);
            Assert.IsTrue (c1 > c0);
            Assert.IsFalse (c1 > c11);
            Assert.IsFalse (c1 > c2);
            Assert.IsTrue (c2 > c1);

            Assert.IsTrue (c0 <= d0);
            Assert.IsTrue (c0 <= c1);
            Assert.IsFalse (c1 <= c0);
            Assert.IsTrue (c1 <= c11);
            Assert.IsTrue (c1 <= c2);
            Assert.IsFalse (c2 <= c1);

            Assert.IsTrue (c3 < c1);
            Assert.IsTrue (c3 != c4);
        }

        #endregion
    }
}
