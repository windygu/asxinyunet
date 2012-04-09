namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;

    public class SearchInfo
    {
        private string 01FqmBarm;
        private bool 4bccOhnfl;
        private object dT3f0t4t3;
        private string TEPULnwMP;
        private WHC.OrderWater.Commons.SqlOperator yTHMJ858G;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchInfo()
        {
            this.4bccOhnfl = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchInfo(string fieldName, object fieldValue, WHC.OrderWater.Commons.SqlOperator sqlOperator) : this(fieldName, fieldValue, sqlOperator, true)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchInfo(string fieldName, object fieldValue, WHC.OrderWater.Commons.SqlOperator sqlOperator, bool excludeIfEmpty) : this(fieldName, fieldValue, sqlOperator, excludeIfEmpty, null)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchInfo(string fieldName, object fieldValue, WHC.OrderWater.Commons.SqlOperator sqlOperator, bool excludeIfEmpty, string groupName)
        {
            this.4bccOhnfl = true;
            this.01FqmBarm = fieldName;
            this.dT3f0t4t3 = fieldValue;
            this.yTHMJ858G = sqlOperator;
            this.4bccOhnfl = excludeIfEmpty;
            this.TEPULnwMP = groupName;
        }

        public bool ExcludeIfEmpty
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.4bccOhnfl;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.4bccOhnfl = value;
            }
        }

        public string FieldName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.01FqmBarm;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.01FqmBarm = value;
            }
        }

        public object FieldValue
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.dT3f0t4t3 = value;
            }
        }

        public string GroupName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.TEPULnwMP;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.TEPULnwMP = value;
            }
        }

        public WHC.OrderWater.Commons.SqlOperator SqlOperator
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.yTHMJ858G;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.yTHMJ858G = value;
            }
        }
    }
}

