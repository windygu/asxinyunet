/*
 * KwCombinatorics v1.3.0
 * Copywrite 2011 - Kasey Osborn (kasewick@gmail.com)
 * Ms-PL - Use and redistribute freely
 */

using System;
using System.Globalization;
using System.Collections.Generic;


namespace Kw.Combinatorics
{
    /// <summary>
    /// Represents a cartesian product of sets with columns of supplied sizes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the <see cref="Width"/> property to get the width of the row.
    /// Use the <see cref="Rank"/> property to calculate a lexicographically ordered
    /// row for the supplied value.
    /// Use the <see cref="GetEnumerator">default enumerator</see>
    /// to enumerate over all elements of a row.
    /// Use <see cref="Rows"/> to enumerate over all distinct rows in lexicographical order.
    /// Use the <see cref="Permute">Permute</see>
    /// method to rearrange a supplied list based on the current row values.
    /// Use the <see cref="P:Kw.Combinatorics.Product.Item(System.Int32)">indexer</see>
    /// to get an element of the row.
    /// </para>
    /// <para>
    /// For more information, see:<br />
    /// <br />
    /// <em>http://en.wikipedia.org/wiki/Cartesian_product</em>
    /// </para>
    /// </remarks>
    /// <example>
    /// Example of <c>Product (2, 3)</c>:<br />
    /// { 0, 0 }<br />
    /// { 0, 1 }<br />
    /// { 0, 2 }<br />
    /// { 1, 0 }<br />
    /// { 1, 1 }<br />
    /// { 1, 2 }<br />
    /// </example>
    public class Product :
        ICloneable,
        IComparable,
        System.Collections.IEnumerable,
        IComparable<Product>,
        IEquatable<Product>,
        IEnumerable<int>
    {
        private long rank;          /* Current row index. */
        internal int[] sizes;       /* Height of each source. */
        internal long[] factors;    /* Running multiple of sizes. */

        #region Constructors

        /// <summary>Make an empty <see cref="Product"/>.</summary>
        public Product ()
        {
            sizes = new int[0];
            factors = new long[0];

            Height = 0;
            rank = 0;
        }


        /// <summary>Make a copy of a <see cref="Product"/>.</summary>
        /// <param name="source">Instance to copy.</param>
        public Product (Product source)
        {
            sizes = new int[source.sizes.Length];
            factors = new long[source.factors.Length];

            source.sizes.CopyTo (sizes, 0);
            source.factors.CopyTo (factors, 0);
            Height = source.Height;
            rank = source.rank;
        }


        /// <summary>Make a <c>Product</c> given the supplied set lengths.</summary>
        /// <param name="newSizes">Lengths for each set.</param>
        /// <example>
        /// <code source="Examples\ProductExample03\ProductExample03.cs" lang="cs" />
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">When set size less than 0.
        /// </exception>
        public Product (int[] newSizes)
        {
            sizes = new int[newSizes.Length];
            newSizes.CopyTo (sizes, 0);

            factors = new long[sizes.Length];
            Height = newSizes.Length == 0 ? 0 : 1;

            for (int x = sizes.Length - 1; x >= 0; --x)
            {
                if (sizes[x] < 0)
                    throw new ArgumentOutOfRangeException ("newSizes", "Value is less than zero.");

                factors[x] = Height;
                Height *= sizes[x];
            }
        }

        #endregion

        #region Properties

        /// <summary>Number of columns in the row.</summary>
        public int Width
        { get { return sizes.Length; } }


        /// <summary>Number of rows in the table.</summary>
        public long Height
        { get; private set; }


        /// <summary>Get the size of a set.</summary>
        /// <param name="column">Set index.</param>
        /// <returns>Size of the given set.</returns>
        public long Size (int column)
        { return sizes[column]; }


        /// <summary>Settable row index of the ordered product table.</summary>
        /// <remarks>Any value out of range will be normalized to (0...Height-1).</remarks>
        /// <example>
        /// <code source="Examples\ProductExample03\ProductExample03.cs" lang="cs" />
        /// </example>
        public long Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (Height == 0)
                    rank = 0;
                else
                {
                    rank = value % Height;
                    if (rank < 0)
                        rank += Height;
                }
            }
        }


        /// <summary>Enumerate over the rows of a <see cref="Product"/> in lexicographical
        /// order.</summary>
        /// <example>
        /// <code source="Examples\ProductExample01\ProductExample01.cs" lang="cs" />
        /// </example>
        public IEnumerable<Product> Rows
        {
            get
            {
                if (Height > 0)
                {

                    long startRank = rank;
                    for (Product current = new Product (this); ; )
                    {
                        yield return current;
                        current.Rank = current.Rank + 1;
                        if (current.rank == startRank)
                            break;
                    }
                }
            }
        }


        /// <summary>Get an column of the cartesian product.</summary>
        /// <param name="index">Index value.</param>
        /// <returns>Product integer at index.</returns>
        /// <example>
        /// <code source="Examples\ProductExample03\ProductExample03.cs" lang="cs" />
        /// </example>
        /// <exception cref="IndexOutOfRangeException">When supplied index not in
        /// range (0..Width-1).</exception>
        public int this[int index]
        {
            get
            {
                long r = rank;
                if (index > 0)
                    r %= factors[index - 1];

                return (int) (r / factors[index]);
            }
        }

        #endregion

        #region Methods

        /// <summary>Make a copy of this product.</summary>
        /// <remarks>Implements the deprecated IClone interface.</remarks>
        /// <returns>Copy of the row.</returns>
        public object Clone ()
        { return new Product (this); }


        /// <summary>Compare two cartesian product rows.</summary>
        /// <param name="value">Target of the comparison.</param>
        /// <returns>Comparison difference sign of the cartesian product rows.</returns>
        public int CompareTo (object value)
        { return CompareTo (value as Product); }


        /// <summary>Compares two cartesian product rows.</summary>
        /// <returns>Comparison difference sign of the rows.</returns>
        /// <param name="value">A cartesian product row.</param>
        public int CompareTo (Product value)
        {
            if ((object) value == null)
                return 1;

            int result = this.Width - value.Width;

            if (result == 0)
                if (this.Rank > value.Rank)
                    result = 1;
                else if (this.Rank < value.Rank)
                    result = -1;

            return result;
        }


        /// <summary>Indicate whether two cartesian product rows have the same value.
        /// </summary>
        /// <param name="value">A cartesian product row to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this row;
        /// otherwise, <b>false</b>.</returns>
        public override bool Equals (object value)
        { return Equals (value as Product); }


        /// <summary>Indicate whether two cartesian product rows have the same value.
        /// </summary>
        /// <param name="value">A cartesian product row to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this
        /// <see>row</see>; otherwise, <b>false</b>.</returns>
        public bool Equals (Product value)
        { return (object) value != null && value.Rank == Rank && value.Width == Width; }


        /// <summary>Get an object-based enumerator of the elements.</summary>
        /// <returns>object-based elemental enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        { return GetEnumerator (); }


        /// <summary>Enumerate over all elements of a cartesian product.</summary>
        /// <returns>An <c>IEnumerator&lt;int&gt;</c> for this row.</returns>
        /// <example>
        /// <code source="Examples\ProductExample05\ProductExample05.cs" lang="cs" />
        /// </example>
        public IEnumerator<int> GetEnumerator ()
        {
            for (int index = 0; index < Width; index++)
                yield return this[index];
        }


        /// <summary>Returns the hash oode for this row.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode ()
        { return unchecked ((int) rank); }


        /// <summary>Apply a row to select from the supplied lists or arrays.</summary>
        /// <typeparam name="T">Type of items to rearrange.</typeparam>
        /// <param name="arrangement">New arrangement for items.</param>
        /// <param name="source">List of List of Items or arrays to rarrange.</param>
        /// <returns>List of rearranged items.</returns>
        /// <example>
        /// <code source="Examples\ProductExample04\ProductExample04.cs" lang="cs" />
        /// </example>
        /// <exception cref="ArgumentException">When not enough source sets.</exception>
        /// <exception cref="IndexOutOfRangeException">When supplied source set is
        /// short.</exception>
        public static List<T> Permute<T> (Product arrangement, IList<IList<T>> source)
        {
            if (source.Count < arrangement.Width)
                throw new ArgumentException ("source", "Not enough supplied values.");

            List<T> result = new List<T> (arrangement.Width);

            for (int i = 0; i < arrangement.Width; ++i)
                result.Add (source[i][arrangement[i]]);

            return result;
        }


        /// <summary>Provide readable form of the row.</summary>
        /// <remarks>Result is enclosed in braces and separated by commas.</remarks>
        /// <returns>A <c>string</c> that represents the row.</returns>
        /// <example>
        /// <code source="Examples\ProductExample03\ProductExample03.cs" lang="cs" />
        /// </example>
        public override string ToString ()
        {
            string result = "{ ";
            long rank0 = Rank;
            for (int i = 0; i < factors.Length; ++i)
            {
                long v = rank0 / factors[i];
                rank0 %= factors[i];

                if (i > 0)
                    result += ", ";
                result += v.ToString (CultureInfo.InvariantCulture);
            }
            return result + " }";
        }

        #endregion

        #region Static Methods

        /// <summary>Indicate whether two cartesian product rows are equal.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if supplied rows are equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator == (Product param1, Product param2)
        {
            if ((object) param1 == null)
                return (object) param2 == null;
            else
                return param1.Equals (param2);
        }

        /// <summary>Indicate whether two cartesian product rows are not equal.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if supplied rows are not equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator != (Product param1, Product param2)
        { return !(param1 == param2); }


        /// <summary>Indicate whether the left cartesian product row is less than
        /// the right cartesian product row.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if the left cartesian product row is less than
        /// the right cartesian product row otherwise, <b>false</b>.</returns>
        public static bool operator < (Product param1, Product param2)
        {
            if ((object) param1 == null)
                return (object) param2 != null;
            else
                return param1.CompareTo (param2) < 0;
        }

        /// <summary>Indicate whether the left cartesian product row is greater than or
        /// equal to the right cartesian product row.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if the left cartesian product row is greater than or
        /// equal to the right cartesian product row otherwise, <b>false</b>.</returns>
        public static bool operator >= (Product param1, Product param2)
        { return !(param1 < param2); }


        /// <summary>Indicate whether the left cartesian product row is greater than
        /// the right cartesian product row.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if the left cartesian product row is greater than
        /// the right cartesian product row otherwise, <b>false</b>.</returns>
        public static bool operator > (Product param1, Product param2)
        {
            if ((object) param1 == null)
                return false;
            else
                return param1.CompareTo (param2) > 0;
        }

        /// <summary>Indicate whether the left cartesian product row is less than or equal to
        /// the right cartesian product row.</summary>
        /// <param name="param1">A cartesian product row.</param>
        /// <param name="param2">A cartesian product row.</param>
        /// <returns><b>true</b> if the left cartesian product row is less than or equal to
        /// the right cartesian product row otherwise, <b>false</b>.</returns>
        public static bool operator <= (Product param1, Product param2)
        { return !(param1 > param2); }

        #endregion
    }
}
