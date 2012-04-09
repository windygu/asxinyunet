namespace WHC.OrderWater.Commons
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text;

    public sealed class SmartDataReader
    {
        private IDataReader lWvfFeZUE;
        private DateTime mi5qIK3te = Convert.ToDateTime(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6302));

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SmartDataReader(IDataReader reader)
        {
            this.lWvfFeZUE = reader;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetBoolean(string column)
        {
            return this.GetBoolean(column, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetBoolean(string column, bool defaultIfNull)
        {
            bool flag2;
            string str = this.lWvfFeZUE[column].ToString();
            try
            {
                flag2 = Convert.ToInt32(str) > 0;
            }
            catch
            {
            }
            return flag2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool? GetBooleanNullable(string column)
        {
            bool? nullable2;
            string str = this.lWvfFeZUE[column].ToString();
            try
            {
                nullable2 = new bool?(Convert.ToInt32(str) > 0);
            }
            catch
            {
            }
            return nullable2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] GetBytes(string column)
        {
            return this.GetBytes(column, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] GetBytes(string column, string defaultIfNull)
        {
            string s = this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : this.lWvfFeZUE[column].ToString();
            return Encoding.UTF8.GetBytes(s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTime GetDateTime(string column)
        {
            return this.GetDateTime(column, this.mi5qIK3te);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTime GetDateTime(string column, DateTime defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : Convert.ToDateTime(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTime? GetDateTimeNullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new DateTime?(Convert.ToDateTime(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public decimal GetDecimal(string column)
        {
            return this.GetDecimal(column, 0M);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public decimal GetDecimal(string column, decimal defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : decimal.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public decimal? GetDecimalNullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new decimal?(decimal.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public double GetDouble(string column)
        {
            return this.GetDouble(column, 0.0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public double GetDouble(string column, double defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : double.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public double? GetDoubleNullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new double?(double.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float GetFloat(string column)
        {
            return this.GetFloat(column, 0f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float GetFloat(string column, float defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : float.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float? GetFloatNullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new float?(float.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Guid GetGuid(string column)
        {
            return this.GetGuid(column, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Guid GetGuid(string column, string defaultIfNull)
        {
            string g = this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : this.lWvfFeZUE[column].ToString();
            Guid empty = Guid.Empty;
            if (g != null)
            {
                empty = new Guid(g);
            }
            return empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Guid? GetGuidNullable(string column)
        {
            string g = this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : this.lWvfFeZUE[column].ToString();
            Guid? nullable = null;
            if (g != null)
            {
                nullable = new Guid(g);
            }
            return nullable;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public short GetInt16(string column)
        {
            return this.GetInt16(column, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public short GetInt16(string column, short defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : short.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public short? GetInt16Nullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new short?(short.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetInt32(string column)
        {
            return this.GetInt32(column, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetInt32(string column, int defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : int.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int? GetInt32Nullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new int?(int.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float GetSingle(string column)
        {
            return this.GetSingle(column, 0f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float GetSingle(string column, float defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : float.Parse(this.lWvfFeZUE[column].ToString()));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public float? GetSingleNullable(string column)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? null : new float?(float.Parse(this.lWvfFeZUE[column].ToString())));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetString(string column)
        {
            return this.GetString(column, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetString(string column, string defaultIfNull)
        {
            return (this.lWvfFeZUE.IsDBNull(this.lWvfFeZUE.GetOrdinal(column)) ? defaultIfNull : this.lWvfFeZUE[column].ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool Read()
        {
            return this.lWvfFeZUE.Read();
        }
    }
}

