namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Threading;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWIndexArray : MWArray
    {
        private static readonly MWNumericArray _Empty = new MWNumericArray(MWArrayComponent.Real, 0, 0);
        internal static readonly MWCharArray TypeFieldName = "type";
        internal static readonly MWCharArray SubsFieldName = "subs";
        internal static readonly MWCharArray ArrayIndex = "()";
        internal static readonly MWCharArray CellIndex = "{}";
        internal static readonly MWCharArray ColonIndexer = new MWCharArray(":");
        internal double start;
        internal double step;
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateDoubleScalar_proxy")]
        internal static extern MWSafeHandle mxCreateDoubleScalar([In] double value);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetNzmax_700_proxy")]
        internal static extern int mxGetNzmax([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMXArrayGetIndexArrays_proxy")]
        internal static extern int mclMXArrayGetIndexArrays(out MWSafeHandle hMXArrayRows, out MWSafeHandle hMXArrayCols, [In] MWSafeHandle hMXArray);
        internal MWIndexArray(MWSafeHandle hMXArray) : base(hMXArray)
        {
            base.array_Type = MWArrayType.Index;
        }

        protected MWIndexArray() {  }

        private MWIndexArray(double scalar)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { 1, 1 };
                base.SetMXArray(mxCreateDoubleScalar(scalar), MWArrayType.Index, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        private MWIndexArray(double start, double step)
        {
            this.start = start;
            this.step = step;
            base.array_Type = MWArrayType.Index;
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                try
                {
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        public static implicit operator MWIndexArray(int scalar) { return new MWIndexArray((double) scalar); }

        public static implicit operator MWIndexArray(byte[] array) { return new MWNumericArray(1, array.Length, array); }

        public static implicit operator MWIndexArray(short[] array) { return new MWNumericArray(1, array.Length, array); }

        public static implicit operator MWIndexArray(int[] array) { return new MWNumericArray(1, array.Length, array); }

        public static implicit operator MWIndexArray(long[] array) { return new MWNumericArray(1, array.Length, array); }

        protected MWIndexArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) {  }

        public bool IsSparse
        {
            get
            {
                bool flag;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    flag = 1 == MWArray.mxIsSparse(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return flag;
            }
        }
        public int NonZeroMaxStorage
        {
            get
            {
                int num;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    num = this.IsSparse ? mxGetNzmax(this.MXArrayHandle) : base.NumberOfElements;
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return num;
            }
        }
        public override object Clone()
        {
            object obj2;
            MWIndexArray array = (MWIndexArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                array.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Index);
                obj2 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return obj2;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override string ToString() { return base.ToString(); }

        public override bool Equals(object obj) { return base.Equals((MWIndexArray) obj); }
    }
}
