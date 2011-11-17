/*
 * KwCombinatorics v1.3.0
 * Copywrite 2011 - Kasey Osborn (kasewick@gmail.com)
 * Ms-PL - Use and redistribute freely
 */

using System;
using System.Globalization;
using System.Collections.Generic;

namespace LotteryTicket
{
    /// <summary>
    /// Represents a permutation as a sequence of unique integers.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the <see cref="Width"/> property to get the width (also known as order) of
    /// the <see cref="Permutation"/>.
    /// Use the <see cref="Rank"/> property to calculate a lexicographically ordered
    /// sequence for the supplied value.
    /// Use the <see cref="GetEnumerator">default enumerator</see>
    /// to enumerate over all elements of the permutation.
    /// Use <see cref="Rows"/>
    /// to enumerate over all possible permutations in lexicographical order.
    /// Use <see cref="AllWidths"/> to enumerate over all sequence widths from (1..Width).
    /// Use the <see cref="Permute">Permute</see>
    /// method to rearrange a supplied array based on the current sequence.
    /// Use the <see cref="P:Kw.Combinatorics.Permutation.Item(System.Int32)">indexer</see>
    /// to get an element of the sequence.
    /// </para>
    /// <para>
    /// For more information, see:<br />
    /// <br />
    /// <em>http://en.wikipedia.org/wiki/Permutation</em>
    /// </para>
    /// </remarks>
    /// <example>
    ///  Examples (by width, by rank):<br />
    ///    Width 0: {}<br />
    ///    Width 1: {0}<br />
    ///    Width 2: {0,1}, {1,0}<br />
    ///    Width 3: {0,1,2} {0,2,1} {1,0,2} {1,2,0} {2,0,1} {2,1,0}<br />
    ///    Width 4: {0,1,2,3} {0,1,3,2} {0,2,1,3} {0,2,3,1} {0,3,1,2} ... {3,2,1,0}<br />
    ///    ...
    /// </example>
    public class Permutation :
        ICloneable,
        IComparable,
        System.Collections.IEnumerable,
        IComparable<Permutation>,
        IEquatable<Permutation>,
        IEnumerable<int>
    {
        private int[] data;
        private long rank;

        /* Note: using unsigned long type won't buy anything. */
        internal static long[] factorial = new long[]
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000
        };

        #region Constructors

        /// <summary>Make an empty permutation.</summary>
        public Permutation ()
        {
            data = new int[0];
            rank = 0;
        }


        /// <summary>Make a copy of a <see cref="Permutation"/>.</summary>
        /// <param name="source">Instance to copy.</param>
        public Permutation (Permutation source)
        {
            data = new int[source.data.Length];
            source.data.CopyTo (data, 0);

            rank = source.rank;
        }


        /// <summary>Make a new instance with the supplied width.</summary>
        /// <param name="newWidth"></param>
        /// <example>
        /// <code source="Examples\PermutationExample03\PermutationExample03.cs" lang="cs" />
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">When <em>newWidth</em>
        /// is negative or greater than 20.</exception>
        public Permutation (int newWidth)
        {
            if (newWidth < 0)
                throw new ArgumentOutOfRangeException ("newWidth", "Value is less than zero.");

            if (newWidth > MaxWidth)
                throw new ArgumentOutOfRangeException ("newWidth", "Value is greater than maximum allowed.");

            data = new int[newWidth];
            for (int i = 0; i < newWidth; ++i)
                data[i] = i;

            rank = 0;
        }


        /// <summary>Make a new <see cref="Permutation"/> with the supplied values.</summary>
        /// <param name="source">Array of element integers.</param>
        /// <exception cref="ArgumentOutOfRangeException">When length of
        /// <em>source</em> is greater than 20 or contains invalid data.</exception>
        /// <exception cref="ArgumentException">When <em>source</em> contains
        /// repeated data.</exception>
        public Permutation (int[] source)
        {
            if (source.Length > MaxWidth)
                throw new ArgumentOutOfRangeException ("source", "Too many values.");

            int w = source.Length;
            bool[] isUsed = new bool[w];

            rank = 0;
            data = new int[w];
            source.CopyTo (data, 0);

            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] < 0)
                    throw new ArgumentOutOfRangeException ("source", "Value is less than zero.");

                if (data[i] >= data.Length)
                    throw new ArgumentOutOfRangeException ("source", "Value is greater than maximum allowed.");

                int digit = 0;
                for (int j = 0; j < data[i]; ++j)
                    if (!isUsed[j])
                        ++digit;

                if (isUsed[data[i]])
                    throw new ArgumentException ("source", "Value is repeated.");

                rank += digit * factorial[w - i - 1];
                isUsed[data[i]] = true;
            }
        }


        /// <summary>Make a new <see cref="Permutation"/> with the specified width
        /// and rank.</summary>
        /// <param name="newWidth">Width of new permutation.</param>
        /// <param name="newRank">Rank of new permutation.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <em>newWidth</em>
        /// negative or greater than 20.</exception>
        public Permutation (int newWidth, long newRank)
        {
            if (newWidth < 0)
                throw new ArgumentOutOfRangeException ("newWidth", "Value is less than zero.");

            if (newWidth > MaxWidth)
                throw new ArgumentOutOfRangeException ("newWidth", "Value is greater than maximum allowed.");

            data = new int[newWidth];
            Unrank (Normalize (Width, newRank));
        }

        #endregion

        #region Properties

        /// <summary>Enumerate forward over all sequences for widths from (1..Width) of a
        /// <see cref="Permutation"/>.</summary>
        /// <example>
        /// <code source="Examples\PermutationExample02\PermutationExample02.cs" lang="cs" />
        /// </example>
        /// <seealso cref="Permute"/>
        public IEnumerable<Permutation> AllWidths
        {
            get
            {
                for (int w = 1; w <= Width; ++w)
                    foreach (Permutation px in new Permutation (w).Rows)
                        yield return px;
            }
        }


        /// <summary>Number of distinct sequences in the table.</summary>
        public long Height
        { get { return data.Length == 0? 0 : factorial[data.Length]; } }


        /// <summary>Settable row index of the ordered permutation table.</summary>
        /// <remarks>Any supplied value out of range (0..Height-1) will be normalized into
        /// this range.</remarks>
        /// <example>
        /// <code source="Examples\PermutationExample03\PermutationExample03.cs" lang="cs" />
        /// </example>
        public long Rank
        {
            get { return rank; }
            set { Unrank (Normalize (Width, value)); }
        }


        /* Here is the heavy lifting. */
        private void Unrank (long newRank)
        {
            rank = newRank;
            bool[] isUsed = new bool[data.Length];
            int[] factoradic = new int[data.Length];

            /* Compute the factoradic for the given rank. */
            for (int i = data.Length - 1; i >= 0; --i)
            {
                /* TODO Could this loop be optimized? */
                factoradic[i] = (int) (newRank / factorial[i]);
                newRank -= factoradic[i] * factorial[i];
            }

            /* Build the permutation from the diminishing factoradic. */
            for (int j = data.Length - 1; j >= 0; --j)
                for (int newAtom = 0; ; ++newAtom)
                    if (!isUsed[newAtom])
                        if (factoradic[j] > 0)
                            --factoradic[j];
                        else
                        {
                            data[data.Length - j - 1] = newAtom;
                            isUsed[newAtom] = true;
                            break;
                        }
        }


        /// <summary>Enumerate over the rows of a <see cref="Permutation"/> in lexicographical
        /// order.</summary>
        /// <example>
        /// <code source="Examples\PermutationExample01\PermutationExample01.cs" lang="cs" />
        /// </example>
        /// <remarks>If the supplied beginning permutation is not at row 0, the enumeration
        /// will wrap around so that <see cref="Height"/> items are always produced.
        /// </remarks>
        public IEnumerable<Permutation> Rows
        {
            get
            {
                if (Height > 0)
                {
                    long startRank = Rank;
                    for (Permutation current = new Permutation (this); ; )
                    {
                        yield return current;
                        current.Rank = current.Rank + 1;
                        if (current.Rank == startRank)
                            break;
                    }
                }
            }
        }


        /// <summary>Number of elements in the sequence.  Also known as 'order'.</summary>
        public int Width
        { get { return data.Length; } }


        /// <summary>Get an element of the permutation at the specified location.</summary>
        /// <param name="index">Index value.</param>
        /// <returns>Permutation value at index.</returns>
        /// <example>
        /// <code source="Examples\PermutationExample03\PermutationExample03.cs" lang="cs" />
        /// </example>
        /// <exception cref="IndexOutOfRangeException">When <em>index</em> not in
        /// range (0..Width-1).</exception>
        public int this[int index]
        { get { return data[index]; } }

        #endregion

        #region Methods

        /// <summary>Make a copy of this object.</summary>
        /// <remarks>Support IClone interface.</remarks>
        /// <returns>Copy of the <see cref="Permutation"/>.</returns>
        public object Clone ()
        { return new Permutation (this);}


        /// <summary>Compare two permutations.</summary>
        /// <param name="value">Target of the comparison.</param>
        /// <returns>Comparison difference sign of the permutations.</returns>
        public int CompareTo (object value)
        { return CompareTo (value as Permutation); }


        /// <summary>Compares two permutations.</summary>
        /// <returns>Comparison difference sign of the permutations.</returns>
        /// <param name="value">A permutation.</param>
        public int CompareTo (Permutation value)
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


        /// <summary>Indicate whether two permutations have the same value.</summary>
        /// <param name="value">A permutation to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this object;
        /// otherwise, <b>false</b>.</returns>
        public override bool Equals (object value)
        { return Equals (value as Permutation); }


        /// <summary>Indicate whether two permutations have the same value.</summary>
        /// <param name="value">A permutation to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this
        /// <see>Permutation</see>; otherwise, <b>false</b>.</returns>
        public bool Equals (Permutation value)
        { return (object) value != null && value.Rank == Rank && value.Width == Width; }


        /// <summary>Get an object-based enumerator of the elements.</summary>
        /// <returns>object-based elemental enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        { return GetEnumerator (); }


        /// <summary>Enumerate over all elements of a permutation.</summary>
        /// <returns>An <c>IEnumerator&lt;int&gt;</c> for this permutation.</returns>
        /// <example>
        /// <code source="Examples\PermutationExample05\PermutationExample05.cs" lang="cs" />
        /// </example>
        public IEnumerator<int> GetEnumerator ()
        {
            for (int index = 0; index < Width; index++)
                yield return data[index];
        }


        /// <summary>Returns the hash oode for this permutation.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode ()
        { return unchecked ((int) Rank); }


        /// <summary>Apply a sequence to rearrange the supplied list or array.</summary>
        /// <typeparam name="T">Type of items to rearrange.</typeparam>
        /// <param name="arrangement">New arrangement for items.</param>
        /// <param name="source">list of items to rearrange.</param>
        /// <returns>Rearranged objects.</returns>
        /// <example>
        /// <code source="Examples\PermutationExample04\PermutationExample04.cs" lang="cs" />
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException">When length of
        /// <em>source</em> is less than <see cref="Width"/>.</exception>
        public static List<T> Permute<T> (Permutation arrangement, IList<T> source)
        {
            if (source.Count < arrangement.Width)
                throw new ArgumentException ("source", "Not enough supplied values.");

            List<T> result = new List<T> (arrangement.Width);

            for (int i = 0; i < arrangement.Width; ++i)
                result.Add (source[arrangement.data[i]]);

            return result;
        }


        /// <summary>Provide readable form of the sequence.</summary>
        /// <remarks>Result is enclosed in braces and separated by commas.</remarks>
        /// <returns>A <b>string</b> that represents the sequence.</returns>
        /// <example>
        /// <code source="Examples\PermutationExample03\PermutationExample03.cs" lang="cs" />
        /// </example>
        public override string ToString ()
        {
            string result = "{ ";
            foreach (int datum in data)
            {
                if (result.Length > 2)
                    result += ", ";
                result += datum.ToString (CultureInfo.InvariantCulture);
            }
            return result + " }";
        }

        #endregion

        #region Static Methods

        /// <summary>Indicate whether two permutations are equal.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if supplied permutation permutations are equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator == (Permutation param1, Permutation param2)
        {
            if ((object) param1 == null)
                return (object) param2 == null;
            else
                return param1.Equals (param2);
        }

        /// <summary>Indicate whether two permutations are not equal.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if supplied permutation are not equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator != (Permutation param1, Permutation param2)
        { return !(param1 == param2); }


        /// <summary>Indicate whether the left permutation is less than
        /// the right permutation.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if the left permutation is less than
        /// the right permutation otherwise, <b>false</b>.</returns>
        public static bool operator < (Permutation param1, Permutation param2)
        {
            if ((object) param1 == null)
                return (object) param2 != null;
            else
                return param1.CompareTo (param2) < 0;
        }

        /// <summary>Indicate whether the left permutation is greater than or equal to
        /// the right permutation.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if the left permutation is greater than or equal to
        /// the right permutation otherwise, <b>false</b>.</returns>
        public static bool operator >= (Permutation param1, Permutation param2)
        { return !(param1 < param2); }


        /// <summary>Indicate whether the left permutation is greater than
        /// the right permutation.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if the left permutation is greater than
        /// the right permutation otherwise, <b>false</b>.</returns>
        public static bool operator > (Permutation param1, Permutation param2)
        {
            if ((object) param1 == null)
                return false;
            else
                return param1.CompareTo (param2) > 0;
        }

        /// <summary>Indicate whether the left permutation is less than or equal to
        /// the right permutation.</summary>
        /// <param name="param1">A permutation.</param>
        /// <param name="param2">A permutation.</param>
        /// <returns><b>true</b> if the left permutation is less than or equal to
        /// the right permutation otherwise, <b>false</b>.</returns>
        public static bool operator <= (Permutation param1, Permutation param2)
        { return !(param1 > param2); }


        /// <summary>n!</summary>
        /// <param name="n">n</param>
        /// <returns>n!</returns>
        /// <exception cref="IndexOutOfRangeException">When n > 20.</exception>
        /// <exclude />
        static public long Factorial (int n) { return factorial[n]; }


        /// <summary>Get the maximum number of elements in a <see cref="Permutation"/>.
        /// </summary>
        static public int MaxWidth
        { get { return factorial.Length - 1; } }


        /// <summary>Force supplied rank to range (0..width!-1).</summary>
        /// <param name="width">Order of the hypothetical permutation.</param>
        /// <param name="newRank">Rank of the hypothetical permutation.</param>
        /// <returns>Normalized rank.</returns>
        static private long Normalize (int width, long newRank)
        {
            newRank = newRank % Factorial (width);
            if (newRank < 0)
                newRank += Factorial (width);
            return newRank;
        }

        #endregion
    }
}
