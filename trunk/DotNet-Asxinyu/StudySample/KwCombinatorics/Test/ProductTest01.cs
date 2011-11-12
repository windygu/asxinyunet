using Kw.Combinatorics;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kw.CombinatoricsTest
{
    [TestClass]
    public class ProductTest01
    {
        #region Test Constructors

        [TestMethod]
        public void Test_Interfaces ()
        {
            Product prod = new Product (new int[] { 2, 3, 4 });

            Assert.IsNotNull (prod as ICloneable);
            Assert.IsNotNull (prod as IComparable);
            Assert.IsNotNull (prod as System.Collections.IEnumerable);
            Assert.IsNotNull (prod as IComparable<Product>);
            Assert.IsNotNull (prod as IEquatable<Product>);
            Assert.IsNotNull (prod as IEnumerable<int>);
        }

        [TestMethod]
        public void Test_Ctor0 ()
        {
            Product p0 = new Product ();
            Assert.AreEqual (0, p0.Height);
            Assert.AreEqual (0, p0.Width);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Ctor1_ArgumentOutOfRangeException ()
        {
            Product p0 = new Product (new int[] { 2, -4, 3 });
        }

        [TestMethod]
        public void Test_Ctor1 ()
        {
            int[,] expected2by3 = new int[,] { {0, 0}, { 0, 1 }, { 0, 2 }, { 1, 0 }, {1, 1}, {1, 2} };

            Product p0 = new Product (new int[] { 5, 0, 3 });

            Assert.AreEqual (0, p0.Height);
            Assert.AreEqual (3, p0.Width);
            Assert.AreEqual (5, p0.Size (0));
            Assert.AreEqual (0, p0.Size (1));
            Assert.AreEqual (3, p0.Size (2));

            int actualIterations = 0;
            foreach (Product px in p0.Rows)
            {
                ++actualIterations;
            }
            Assert.AreEqual (0, actualIterations);

            Product p3 = new Product (new int[] { 2, 4, 3 });
            Assert.AreEqual (2 * 4 * 3, p3.Height);

            Product p4 = new Product (new int[0]);
            Assert.AreEqual (0, p4.Height);
            Assert.AreEqual (0, p4.Width);
        }

        #endregion

        #region Properties

        [TestMethod]
        public void Test_Rank_Empty ()
        {
            Product p0 = new Product (new int[] { 5, 0, 3 });

            Assert.AreEqual (0, p0.Rank);

            p0.Rank = p0.Rank + 1;

            Assert.AreEqual (0, p0.Rank);
        }

        [TestMethod]
        public void Test_Rank ()
        {
            Product p2 = new Product (new int[] { 3, 4 });

            long expectedRank = 5;
            p2.Rank = expectedRank;
            long actualRank = p2.Rank;
            Assert.AreEqual (expectedRank, actualRank);

            expectedRank = p2.Height - 1;
            p2.Rank = -1;
            actualRank = p2.Rank;
            Assert.AreEqual (expectedRank, actualRank);
        }


        [TestMethod]
        public void Test_Rows_Empty ()
        {
            Product p2 = new Product (new int[] { 2, 0, 3 });

            int actualCount = 0;
            foreach (Product px in p2.Rows)
            {
                ++actualCount;
            }

            Assert.AreEqual (0, actualCount);
        }

        [TestMethod]
        public void Test_Rows ()
        {
            Product p2 = new Product (new int[] { 2, 3 });

            int[][] expected = new[]
            {
                new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 },
                new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 1, 2 },
                new int[] { 9, 9 }
            };

            int actualCount = 0;

            foreach (Product px in p2.Rows)
            {
                Assert.AreEqual (actualCount / 3, px[0]);
                Assert.AreEqual (actualCount % 3, px[1]);
                ++actualCount;
            }
            Assert.AreEqual (6, actualCount);
        }

        [TestMethod]
        public void Test_Index ()
        {
            Product p3 = new Product (new int[] { 4, 3, 2 });
            p3.Rank = 23;

            Assert.AreEqual (3, p3[0]);
            Assert.AreEqual (2, p3[1]);
            Assert.AreEqual (1, p3[2]);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_Clone ()
        {
            Product p0 = new Product ();
            Product p1 = (Product) p0.Clone ();
            Assert.AreEqual (p0.Rank, p1.Rank);
        }

        [TestMethod]
        public void Test_CompareTo_OBJECT ()
        {
            var objectSortedList = new System.Collections.SortedList ();

            Product prod1 = new Product (new int[] { 3, 4, 5 });
            Product prod2 = new Product (prod1);
            Product prod3 = new Product (prod1);

            prod1.Rank = 10;
            prod2.Rank = 30;
            prod3.Rank = 20;

            objectSortedList.Add (prod1, 10);
            objectSortedList.Add (prod2, 30);
            objectSortedList.Add (prod3, 20);

            int expectedValue = 10;
            foreach (System.Collections.DictionaryEntry item in objectSortedList)
            {
                int actualIndex = (int) item.Value;
                Assert.AreEqual (expectedValue, actualIndex);
                expectedValue += 10;
            }

            Assert.AreEqual (40, expectedValue);
        }

        [TestMethod]
        public void Test_CompareTo ()
        {
            Product p0 = null;
            Product p16 = new Product (new int[] { 2, 3, 4 }); p16.Rank = 16;
            Product p17 = new Product (new int[] { 2, 3, 4 }); p17.Rank = 17;

            int actual1 = p16.CompareTo (p0);
            Assert.IsTrue (actual1 > 0);

            int actual2 = p16.CompareTo (p17);
            Assert.IsTrue (actual2 < 0);
        }


        [TestMethod]
        public void Test_Equals_OBJECT ()
        {
            Product p0 = null;
            Product p16a = new Product (new int[] { 2, 3, 4 }); p16a.Rank = 16;
            Product p16b = new Product (new int[] { 2, 3, 4 }); p16b.Rank = 16;
            Product p17 = new Product (new int[] { 2, 3, 4 }); p17.Rank = 17;
            Product q4 = new Product (new int[] { 1, 2, 3, 4 });

            object j0 = (object) p0;
            object j16b = (object) p16b;
            object j17 = (object) p17;
            object j4 = (object) q4;

            Assert.IsFalse (p16a.Equals (j0));
            Assert.IsTrue (p16a.Equals (j16b));
            Assert.IsFalse (p16a.Equals (j17));
            Assert.IsFalse (p16a.Equals (j4));
        }

        [TestMethod]
        public void Test_Equals ()
        {
            Product p0 = null;
            Product p16a = new Product (new int[] { 2, 3, 4 }); p16a.Rank = 16;
            Product p16b = new Product (new int[] { 2, 3, 4 }); p16b.Rank = 16;
            Product p17 = new Product (new int[] { 2, 3, 4 }); p17.Rank = 17;
            Product q = new Product (new int[] { 1, 2, 3, 4 });

            Assert.IsFalse (p16a.Equals (p0));
            Assert.IsTrue (p16a.Equals (p16b));
            Assert.IsFalse (p16a.Equals (p17));
            Assert.IsFalse (p16a.Equals (q));
        }


        [TestMethod]
        public void Test_Equals_Other_Type ()
        {
            Product p234 = new Product (new int[] { 2, 3, 4 });
            string s = "Roxy";

            // Comparing to different type returns false.
            Assert.IsFalse (p234.Equals (s));
        }


        [TestMethod]
        public void Test_GetEnumerator_OBJECT ()
        {
            Product prod = new Product (new int[] { 2, 3, 4});
            prod.Rank = 6;

            System.Collections.IEnumerator nu = ((System.Collections.IEnumerable) prod).GetEnumerator ();

            int expected = 0;
            while (nu.MoveNext ())
            {
                int actual = (int) nu.Current;
                Assert.AreEqual (expected, actual);
                ++expected;
            }

            Assert.AreEqual (prod.Width, expected);
        }

        [TestMethod]
        public void Test_GetEnumerator ()
        {
            Product prod = new Product (new int[] { 3, 4, 5 });

            prod.Rank = 33;
            int[] expectedValues = new int[] { 1, 2, 3 };

            int index = 0;
            foreach (int actualValue in prod)
            {
                Assert.AreEqual (expectedValues[index], actualValue);
                index++;
            }

            Assert.AreEqual (expectedValues.Length, index);
        }


        [TestMethod]
        public void Test_GetHashCode ()
        {
            Product p0 = new Product ();
            int hash = p0.GetHashCode ();
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void Test_Permute_ArgumentException ()
        {
            Product p0 = new Product (new int[] { 2, 3 });
            object[][] source = new object[][] { new string[] { "A", "B" } };
            List<object> j = Product.Permute (p0, source);
        }


        [TestMethod]
        [ExpectedException (typeof (ArgumentOutOfRangeException))]
        public void Test_Permute_ArgumentOutOfRangeException ()
        {
            Product p0 = new Product (new int[] { 3 });
            p0.Rank = 2;
            object[][] source = new object[][] { new string[] { "A", "B" } };
            List<object> j = Product.Permute (p0, source);
        }

        [TestMethod]
        public void Test_Permute ()
        {
            string[] set1 = new string[] { "A", "B", "C" };
            string[] set2 = new string[] { "X", "Y" };
            object[][] ja = new object[][] { set1, set2 };
            string[] expected = new string[] { "AX", "AY", "BX", "BY", "CX", "CY" };

            int actualCount = 0;
            foreach (Product px in new Product (new int[] { set1.Length, set2.Length }).Rows)
            {
                string actual = "";
                foreach (object j in Product.Permute (px, ja))
                    actual += j;
                Assert.AreEqual (expected[actualCount], actual);
                ++actualCount;
            }
            Assert.AreEqual (expected.Length, actualCount);
        }


        [TestMethod]
        public void Test_ToString ()
        {
            Product p3 = new Product (new int[] { 4, 3, 2 });
            p3.Rank = 23;
            string str = p3.ToString ();
            Assert.AreEqual ("{ 3, 2, 1 }", str);
        }

        #endregion

        #region Test Static Methods

        [TestMethod]
        public void Test_Comparisons ()
        {
            int[] dims1 = new int[] { 2, 3 };

            Product p0 = null;
            Product q0 = null;
            Product p1 = new Product (dims1);   p1.Rank = 1;
            Product p11 = new Product (dims1);  p11.Rank = 1;
            Product p2 = new Product (dims1);   p2.Rank = 2;
            Product q4 = new Product (new int[] { 2, 3, 4, 5 }); q4.Rank = 42;

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

        #endregion
    }
}
