/*
 * KwCombinatorics v1.3.0
 * Copywrite 2011 - Kasey Osborn (kasewick@gmail.com)
 * Ms-PL - Use and redistribute freely
 */

using System;
using System.Globalization;
using System.Collections.Generic;

[assembly: CLSCompliant (true)]
namespace LotteryTicket
{
    /// <summary>
    /// 排列组合生成类
    /// </summary>   
    public class Combination :ICloneable, IComparable, System.Collections.IEnumerable, IComparable<Combination>,
        IEquatable<Combination>,IEnumerable<int>
    {
        private int[] data;     /* 所有元素，长度为‘n' */
        private int choices;    /* 组合的宽度(长度)，为 'k' */
        private long rank;      /* 行号 */

        #region 构造函数
        /// <summary>空的构造函数，参数置0</summary>
        public Combination ()
        {
            data = new int[0];
            choices = 0;
            rank = 0;
            Height = 0;
        }

        /// <summary>复制一个Combination对象</summary>
        /// <param name="source">Combination对象</param>
        public Combination (Combination source)
        {
            data = new int[source.data.Length];
            source.data.CopyTo (data, 0);
            choices = source.choices;
            rank = source.rank;
            Height = source.Height;
        }
        
        /// <summary>由给定的宽度来构造对象</summary>
        /// <param name="newChoices">组合的宽度</param>
        public Combination (int newChoices)
        {
            if (newChoices < 0)
                throw new ArgumentOutOfRangeException ("newChoices", "值小于0");
            choices = newChoices;
            Height = CalculateHeight (newChoices, newChoices);
            rank = 0;
            data = new int[newChoices];
            for (int j = 0; j < Picks; ++j)
                data[j] = j;
        }

        /// <summary>由给定元素来构造对象</summary>
        /// <param name="newChoices">组合的宽度</param>
        /// <param name="dataElement">元素数组</param>
        public Combination(int newChoices,int[] dataElement)
        {
            if (newChoices < 0)
                throw new ArgumentOutOfRangeException("newChoices", "Value is less than zero.");
            choices = newChoices;
            Height = CalculateHeight(newChoices, newChoices);
            rank = 0;
            data = dataElement;
        }

        /// <summary>
        /// 根据给定的宽度和元素来构造对象
        /// </summary>
        /// <param name="newChoices">组合的宽度</param>
        /// <param name="newPicks">可选择的元素最大值,默认从0开始</param>
        public Combination (int newChoices, int newPicks)
        {
            if (newChoices < 0)
                throw new ArgumentOutOfRangeException ("newChoices", "Value is less than zero.");
            if (newPicks < 0)
                throw new ArgumentOutOfRangeException ("newPicks", "Value is less than zero.");
            if (newPicks > newChoices)
                throw new ArgumentOutOfRangeException ("newPicks", "Value is greater than choices.");
            choices = newChoices;
            Height = CalculateHeight (newChoices, newPicks);
            rank = 0;
            data = new int[newPicks];
            for (int j = 0; j < newPicks; ++j)
                data[j] = j;
        }

        /// <summary>
        /// 根据给定的宽度和元素来构造对象
        /// </summary>
        /// <param name="newChoices">组合的宽度</param>
        /// <param name="newPicks">可选择的元素最大值,默认从0开始</param>
        public Combination(int newChoices, int[] dataElement)
        {
            if (newChoices < 0)
                throw new ArgumentOutOfRangeException("newChoices", "Value is less than zero.");
            if (dataElement.Length  > newChoices)
                throw new ArgumentOutOfRangeException("newPicks", "Value is greater than choices.");
            choices = newChoices;
            Height = CalculateHeight(newChoices, newPicks);
            rank = 0;
            data = new int[newPicks];
            for (int j = 0; j < newPicks; ++j)
                data[j] = j;
        }
     
        /// <summary>
        /// Make a new combination of the given rank based on the given picks
        /// from the given number of choices.
        /// </summary>
        /// <remarks>
        /// Rank may be any integer value.  If the supplied Rank is out of range
        /// of (0..Height-1), it will be normalized.  For example, a value of -1 will
        /// produce the last <see cref="Combination"/> in the ordered sequence.
        /// </remarks>
        /// <param name="newChoices">Width of the combination.</param>
        /// <param name="newPicks">Possible values for the choices.</param>
        /// <param name="newRank">Initial row index of ordered combinations.</param>
        /// <exception cref="ArgumentOutOfRangeException">When negative value
        /// supplied; when picks greater than choices.</exception>
        /// <exception cref="OverflowException">When too many choices.</exception>
        public Combination (int newChoices, int newPicks, long newRank)
        {
            if (newChoices < 0)
                throw new ArgumentOutOfRangeException ("newChoices", "Value is less than zero.");

            if (newPicks < 0)
                throw new ArgumentOutOfRangeException ("newPicks", "Value is less than zero.");

            if (newPicks > newChoices)
                throw new ArgumentOutOfRangeException ("newPicks", "Value is greater than choices.");

            data = new int[newPicks];
            choices = newChoices;
            Height = CalculateHeight (newChoices, newPicks);
            setRank (newRank);
        }

        #endregion

        #region Properties

        /// <summary>Enumerate forward over all sequences for
        /// pick sizes from (1..Picks) of a <see cref="Combination"/>.</summary>
        /// <example>
        /// <code source="Examples\CombinationExample02\CombinationExample02.cs" lang="cs" />
        /// </example>
        /// <seealso cref="Permute"/>
        public IEnumerable<Combination> AllPicks
        {
            get
            {
                for (int k = 1; k <= Picks; ++k)
                    foreach (Combination result in new Combination (Choices, k).Rows)
                        yield return result;
            }
        }

        /// <summary>The number of choices available for the pick-combination.
        /// Often referred to as 'N'.</summary>
        public int Choices
        { get { return choices; } }


        /// <summary>Width of the pick-combination.
        /// Often referred to as 'K'.</summary>
        public int Picks
        { get { return data.Length; } }


        /// <summary>Number of distinct pick-combination sequences for the supplied Choices
        /// and Picks.</summary>
        public long Height
        { get; private set; }


        /// <summary>Settable row index of the ordered combination table.</summary>
        /// <remarks>Any value out of range will be normalized to (0..Height-1).
        /// </remarks>
        /// <example>
        /// <code source="Examples\CombinationExample03\CombinationExample03.cs" lang="cs" />
        /// </example>
        public long Rank
        {
            get { return rank; }
            set { setRank (value); }
        }


        /* Here is the heavy lifting. */
        private void setRank (long newRank)
        {
            if (Height == 0)
                newRank = 0;
            else
            {
                newRank = newRank % Height;
                if (newRank < 0)
                    newRank += Height;
            }

            long diminishingRank = Height - newRank - 1;
            int combinaticAtom = choices;

            for (int k = Picks; k > 0; --k)
            {
                for (; ; )
                {
                    --combinaticAtom;
                    int trialCount = (int) CalculateHeight (combinaticAtom, k);
                    if (trialCount <= diminishingRank)
                    {
                        diminishingRank -= trialCount;
                        data[Picks - k] = choices - 1 - combinaticAtom;
                        break;
                    }
                }
            }

            rank = newRank;
        }


        /// <summary>Enumerate over the rows of a <see cref="Combination"/> in lexicographical
        /// order.</summary>
        /// <example>
        /// <code source="Examples\CombinationExample01\CombinationExample01.cs" lang="cs" />
        /// </example>
        /// <remarks>If the supplied beginning combination is not at row 0, the enumeration
        /// will wrap around so that <see cref="Height"/> items are always produced.
        /// </remarks>
        public IEnumerable<Combination> Rows
        {
            get
            {
                if (Height > 0)
                {
                    long startRank = rank;
                    for (Combination current = new Combination (this); ; )
                    {
                        yield return current;
                        current.setRank (current.rank + 1);
                        if (current.rank == startRank)
                            break;
                    }
                }
            }
        }


        /// <summary>Get a element of the pick-combination at the specified location.</summary>
        /// <param name="index">Zero-based index value.</param>
        /// <returns>Pick element determined by index.</returns>
        /// <example>
        /// <code source="Examples\CombinationExample03\CombinationExample03.cs" lang="cs" />
        /// </example>
        /// <exception cref="IndexOutOfRangeException">When <em>index</em> not in
        /// range (0..Width-1).</exception>
        public int this[int index]
        { get { return data[index]; } }

        #endregion

        #region Member Methods

        /// <summary>Make a copy of this combination.</summary>
        /// <remarks>Implements the deprecated IClone interface.</remarks>
        /// <returns>Copy of the pick-combination.</returns>
        public object Clone ()
        { return new Combination (this); }


        /// <summary>Compare two pick-combinations.</summary>
        /// <param name="value">Target of the comparison.</param>
        /// <returns>Comparison difference sign of the pick-combinations.</returns>
        public int CompareTo (object value)
        { return CompareTo (value as Combination); }


        /// <summary>Compare two pick-combinations.</summary>
        /// <returns>Comparison difference sign of the pick-combinations.</returns>
        /// <param name="value">A pick-combination.</param>
        public int CompareTo (Combination value)
        {
            if ((object) value == null)
                return 1;

            int result = this.Picks - value.Picks;
            if (result == 0)
            {
                result = this.Choices - value.Choices;
                if (result == 0)
                {
                    long rankDiff = this.Rank - value.Rank;

                    if (rankDiff == 0)
                        result = 0;
                    else
                        result = rankDiff < 0 ? -1 : 1;
                }
            }

            return result;
        }

        /// <summary>Indicate whether two pick-combinations have the same value.</summary>
        /// <param name="value">A combination to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this object;
        /// otherwise, <b>false</b>.</returns>
        public override bool Equals (object value)
        { return Equals (value as Combination); }


        /// <summary>Indicate whether two pick-combinations have the same value.</summary>
        /// <param name="value">A combination to compare against.</param>
        /// <returns><b>true</b> if the parameter is the same as this
        /// <see>Combination</see>; otherwise, <b>false</b>.</returns>
        public bool Equals (Combination value)
        {
            return (object) value != null
                && value.Rank == Rank && value.Choices == Choices && value.Picks == Picks;
        }


        /// <summary>Get an object-based enumerator of the elements.</summary>
        /// <returns>object-based elemental enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        { return this.GetEnumerator (); }


        /// <summary>Enumerate over all elements of a pick-combination.</summary>
        /// <returns>An <c>IEnumerator&lt;int&gt;</c> for this row.</returns>
        /// <example>
        /// <code source="Examples\CombinationExample05\CombinationExample05.cs" lang="cs" />
        /// </example>
        public IEnumerator<int> GetEnumerator ()
        {
            for (int index = 0; index < data.Length; index++)
                yield return data[index];
        }


        /// <summary>Returns the hash oode for this pick-combination.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode ()
        { return unchecked ((int) Rank); }


        /// <summary>Apply a sequence to rearrange the supplied list or array.</summary>
        /// <typeparam name="T">Type of items to rearrange.</typeparam>
        /// <param name="arrangement">New arrangement for items.</param>
        /// <param name="source">List of items to rearrange.</param>
        /// <returns>List of rearranged items.</returns>
        /// <example>
        /// <code source="Examples\CombinationExample04\CombinationExample04.cs" lang="cs" />
        /// </example>
        /// <exception cref="ArgumentException">When length of
        /// <em>source</em> is less than <see cref="Picks"/>.</exception>
        public static List<T> Permute<T> (Combination arrangement, IList<T> source)
        {
            if (source.Count < arrangement.Picks)
                throw new ArgumentException ("source", "Not enough supplied values.");

            List<T> result = new List<T> (arrangement.Picks);

            for (int i = 0; i < arrangement.Picks; ++i)
                result.Add (source[arrangement.data[i]]);

            return result;
        }


        /// <summary>Provide a readable form of the sequence.</summary>
        /// <remarks>Result is enclosed in braces and separated by commas.</remarks>
        /// <returns>A <c>string</c> that represents the sequence.</returns>
        /// <example>
        /// <code source="Examples\CombinationExample03\CombinationExample03.cs" lang="cs" />
        /// </example>
        public override string ToString ()
        {
            string result = "{ ";
            for (int k = 0; k < Picks; ++k)
            {
                if (k > 0)
                    result += ", ";
                result += data[k].ToString (CultureInfo.InvariantCulture);
            }
            return result + " }";
        }

        #endregion

        #region Static Methods

        /// <summary>Indicate whether two pick-combinations are equal.</summary>
        /// <param name="param1">A pick-combination sequence.</param>
        /// <param name="param2">A pick-combination sequence.</param>
        /// <returns><b>true</b> if supplied sequences are equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator == (Combination param1, Combination param2)
        {
            if ((object) param1 == null)
                return (object) param2 == null;
            else
                return param1.Equals (param2);
        }

        /// <summary>Indicate whether two pick-combinations are not equal.</summary>
        /// <param name="param1">A pick-combination sequence.</param>
        /// <param name="param2">A pick-combination sequence.</param>
        /// <returns><b>true</b> if supplied sequences are not equal;
        /// otherwise, <b>false</b>.</returns>
        public static bool operator != (Combination param1, Combination param2)
        { return !(param1 == param2); }


        /// <summary>Indicate whether the left pick-combination is less than
        /// the right pick-combination.</summary>
        /// <param name="param1">A pick-combination sequence.</param>
        /// <param name="param2">A pick-combination sequence.</param>
        /// <returns><b>true</b> if the left sequence is less than
        /// the right sequence; otherwise, <b>false</b>.</returns>
        public static bool operator < (Combination param1, Combination param2)
        {
            if ((object) param1 == null)
                return (object) param2 != null;
            else
                return param1.CompareTo (param2) < 0;
        }

        /// <summary>Indicate whether the left pick-combination is greater than
        /// or equal to the right pick-combination.</summary>
        /// <param name="param1">A pick-combination sequence.</param>
        /// <param name="param2">A pick-combination sequence.</param>
        /// <returns><b>true</b> if the left sequence is greater than or equal to
        /// the right sequence; otherwise, <b>false</b>.</returns>
        public static bool operator >= (Combination param1, Combination param2)
        { return !(param1 < param2); }


        /// <summary>Indicate whether the left pick-combination is greater than
        /// the right pick-combination.</summary>
        /// <param name="param1">A combination sequence.</param>
        /// <param name="param2">A combination sequence.</param>
        /// <returns><b>true</b> if the left sequence is greater than
        /// the right sequence; otherwise, <b>false</b>.</returns>
        public static bool operator > (Combination param1, Combination param2)
        {
            if ((object) param1 == null)
                return false;
            else
                return param1.CompareTo (param2) > 0;
        }

        /// <summary>Indicate whether the left pick-combination is less than or equal to
        /// the right pick-combination.</summary>
        /// <param name="param1">A pick-combination sequence.</param>
        /// <param name="param2">A pick-combination sequence.</param>
        /// <returns><b>true</b> if the left sequence is less than or equal to
        /// the right sequence; otherwise, <b>false</b>.</returns>
        public static bool operator <= (Combination param1, Combination param2)
        { return !(param1 > param2); }


        /// <summary>Get the height a pick-combination.</summary>
        /// <param name="n">Number of choices.</param>
        /// <param name="k">Number of picks.</param>
        /// <returns>Height of a pick-combination of the given parameters.</returns>
        /// <exception cref="OverflowException">When too many choices.</exception>
        /// <exclude />
        static public long CalculateHeight (int n, int k)
        {
            if (k > n || k <= 0)
                return 0;

            /* Formula is n!/(k!(n-k)!)
             * When n>20, n! overflows.  So do this voodoo instead:
             */
            int x = k > n - k ? k : n - k;
            int y = n - x;
            int b = y;

            long v1 = 1;
            for (int i = x + 1; i <= n; ++i)
            {
                if (i > y * 2 || i % 2 != 0)
                    v1 = checked (v1 * i);
                else
                {
                    v1 = checked (v1 * 2);
                    --b;
                }
            }

            return v1 / Permutation.Factorial (b);
        }

        #endregion
    }
}
