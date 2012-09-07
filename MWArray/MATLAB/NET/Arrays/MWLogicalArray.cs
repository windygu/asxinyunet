namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Threading;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWLogicalArray : MWIndexArray, IEquatable<MWLogicalArray>
    {
        private static readonly MWLogicalArray _Empty = new MWLogicalArray();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateLogicalArray_700_proxy")]
        private static extern MWSafeHandle mxCreateLogicalArray([In] int numberOfDimensions, [In] int[] dimensions);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateLogicalScalar_proxy")]
        internal static extern MWSafeHandle mxCreateLogicalScalar([In] byte logical);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateLogicalMatrix_700_proxy")]
        internal static extern MWSafeHandle mxCreateLogicalMatrix([In] int numRows, [In] int numCols);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsLogicalScalarTrue_proxy")]
        internal static extern byte mxIsLogicalScalarTrue([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetLogicalSparse_proxy")]
        internal static extern int mclGetLogicalSparse(out IntPtr pMXArray, [In] IntPtr rowIndexSize, [In] IntPtr[] rowindex, [In] IntPtr colIndexSize, [In] IntPtr[] columnindex, [In] IntPtr dataSize, [In] byte[] logicalData, [In] IntPtr rows, [In] IntPtr columns, [In] IntPtr nonZeroMax);
        public MWLogicalArray()
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[2];
                base.SetMXArray(mxCreateLogicalMatrix(0, 0), MWArrayType.Logical, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWLogicalArray(int row, int column)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { row, column };
                base.SetMXArray(mxCreateLogicalMatrix(row, column), MWArrayType.Logical, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWLogicalArray(params int[] dimensions)
        {
            if (dimensions == null) throw new ArgumentNullException("dimensions");
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateLogicalArray(dimensions.Length, dimensions), MWArrayType.Logical, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWLogicalArray(bool logicalValue)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { 1, 1 };
                base.SetMXArray(logicalValue ? mxCreateLogicalScalar(1) : mxCreateLogicalScalar(0), MWArrayType.Logical, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWLogicalArray(int rows, int columns, bool[] boolArray)
        {
            this.CreateLogicalArray(rows, columns, boolArray, false);
        }

        public MWLogicalArray(int rows, int columns, bool[] boolArray, bool columnMajorOrder)
        {
            this.CreateLogicalArray(rows, columns, boolArray, columnMajorOrder);
        }

        public MWLogicalArray(Array boolArray)
        {
            if (boolArray == null || typeof(bool) != boolArray.GetType().GetElementType()) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorDataArrayType"), "boolArray");
            try
            {
                int rank = boolArray.Rank;
                int[] dimensions = new int[Math.Max(rank, 2)];
                int length = boolArray.Length;
                int num3 = dimensions[0] = (1 < rank) ? boolArray.GetLength(rank - 2) : 1;
                int num4 = dimensions[1] = boolArray.GetLength(rank - 1);
                for (int i = 0; i < rank - 2; i++)
                {
                    dimensions[rank - i - 1] = boolArray.GetLength(i);
                }
                byte[] source = new byte[length];
                IEnumerator enumerator = boolArray.GetEnumerator();
                for (int j = 0; j < length; j += num3 * num4)
                {
                    for (int k = 0; k < num3; k++)
                    {
                        for (int m = 0; m < num4; m++)
                        {
                            enumerator.MoveNext();
                            source[m * num3 + k + j] = ((bool) enumerator.Current) ? ((byte) 1) : ((byte) 0);
                        }
                    }
                }
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateLogicalArray(dimensions.Length, dimensions), MWArrayType.Logical, dimensions.Length, dimensions);
                IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
                Marshal.Copy(source, 0, destination, length);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        internal MWLogicalArray(MWSafeHandle hMXArray) : base(hMXArray)
        {
            base.array_Type = MWArrayType.Logical;
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

        public MWLogicalArray this[int[] indices]
        {
            get
            {
                MWLogicalArray typedArray;
                RuntimeHelpers.PrepareConstrainedRegions();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    typedArray = (MWLogicalArray) MWArray.GetTypedArray(base.ArrayIndexer(this, indices));
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return typedArray;
            }
            set
            {
                if (MWArrayType.Logical != value.array_Type) throw new InvalidCastException(MWArray.resourceManager.GetString("MWErrorDataArrayType"));
                RuntimeHelpers.PrepareConstrainedRegions();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    base.ArrayIndexer(value, this, indices);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
            }
        }
        public static implicit operator bool(MWLogicalArray logicalArray)
        {
            bool flag;
            logicalArray.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                flag = 1 == mxIsLogicalScalarTrue(logicalArray.MXArrayHandle);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return flag;
        }

        public static implicit operator MWLogicalArray(bool scalar) { return new MWLogicalArray(scalar); }

        protected MWLogicalArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) {  }

        public static MWLogicalArray Empty { get { return (MWLogicalArray) _Empty.Clone(); } }
        public bool IsScalar
        {
            get
            {
                bool flag;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    flag = 1 == mxIsLogicalScalarTrue(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return flag;
            }
        }
        public static MWLogicalArray MakeSparse(int rows, int columns, int nonZeroMax)
        {
            bool[] dataArray = new bool[1];
            return MakeSparse(rows, columns, new int[] { 1 }, new int[] { 1 }, dataArray, nonZeroMax);
        }

        public static MWLogicalArray MakeSparse(int[] rowIndex, int[] columnIndex, bool[] dataArray)
        {
            MWLogicalArray array;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int length = rowIndex.Length;
                if (length != columnIndex.Length) throw new Exception(MWArray.resourceManager.GetString("MWErrorInvalidIndices"));
                int num2 = 0;
                int num3 = 0;
                for (int i = 0; i < length; i++)
                {
                    num2 = Math.Max(num2, rowIndex[i]);
                    num3 = Math.Max(num3, columnIndex[i]);
                }
                array = MakeSparse(num2, num3, rowIndex, columnIndex, dataArray);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array;
        }

        public static MWLogicalArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, bool[] dataArray) { return MakeSparse(rows, columns, rowIndex, columnIndex, dataArray, dataArray.Length); }

        public static MWLogicalArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, bool[] dataArray, int nonZeroMax)
        {
            MWLogicalArray array;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                IntPtr zero = IntPtr.Zero;
                int length = 0;
                byte[] logicalData = null;
                if (dataArray != null)
                {
                    length = dataArray.Length;
                    logicalData = new byte[length];
                }
                IntPtr[] rowindex = new IntPtr[rowIndex.Length];
                IntPtr[] columnindex = new IntPtr[columnIndex.Length];
                for (int i = 0; i < rowIndex.Length; i++)
                {
                    rowindex[i] = (IntPtr) rowIndex[i];
                    columnindex[i] = (IntPtr) columnIndex[i];
                }
                for (int j = 0; j < length; j++)
                {
                    logicalData[j] = dataArray[j] ? ((byte) 1) : ((byte) 0);
                }
                if (mclGetLogicalSparse(out zero, (IntPtr) rowIndex.Length, rowindex, (IntPtr) columnIndex.Length, columnindex, (IntPtr) dataArray.Length, logicalData, (IntPtr) rows, (IntPtr) columns, (IntPtr) nonZeroMax) == 0)
                {
                    MWSafeHandle handle;
                    if (MWArray.mclArrayHandle2mxArray(out handle, zero) != 0) throw new Exception(MWArray.resourceManager.GetString("MWErrorInvalidArray"));
                    return new MWLogicalArray(handle);
                }
                array = null;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array;
        }

        public override string ToString() { return base.ToString(); }

        public override bool Equals(object obj) { return (obj is MWLogicalArray) && this.Equals(obj as MWLogicalArray); }

        private bool Equals(MWLogicalArray other) { return base.Equals(other); }

        bool IEquatable<MWLogicalArray>.Equals(MWLogicalArray other) { return this.Equals(other); }

        public override object Clone()
        {
            object obj2;
            MWLogicalArray array = (MWLogicalArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                array.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Logical);
                obj2 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return obj2;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public bool[] ToVector()
        {
            base.CheckDisposed();
            IntPtr zero = IntPtr.Zero;
            double numberOfElements = base.NumberOfElements;
            bool[] flagArray = new bool[(int) numberOfElements];
            byte[] destination = new byte[(int) numberOfElements];
            try
            {
                Monitor.Enter(MWArray.mxSync);
                zero = MWArray.mxGetData(this.MXArrayHandle);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            Marshal.Copy(zero, destination, 0, (int) numberOfElements);
            for (int i = 0; i < destination.Length; i++)
            {
                flagArray[i] = destination[i] != 0;
            }
            return flagArray;
        }

        public override Array ToArray()
        {
            Array array5;
            base.CheckDisposed();
            int[] dimensions = this.Dimensions;
            IntPtr source = MWArray.mxGetData(this.MXArrayHandle);
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                if (MWArray.mxIsSparse(this.MXArrayHandle) != 0)
                {
                    MWSafeHandle handle;
                    MWSafeHandle handle2;
                    int[,] numArray2 = null;
                    int[,] numArray3 = null;
                    int num = 0;
                    int num2 = 0;
                    if (MWIndexArray.mclMXArrayGetIndexArrays(out handle, out handle2, this.MXArrayHandle) != 0) throw new Exception(MWArray.resourceManager.GetString("MWErrorInvalidIndex"));
                    MWNumericArray array = new MWNumericArray(handle);
                    MWNumericArray array2 = new MWNumericArray(handle2);
                    int num3 = array.NumberOfElements;
                    if (MWNumericType.UInt64 != array.NumericType)
                    {
                        numArray2 = (int[,]) array.ToArray(MWArrayComponent.Real, true);
                        numArray3 = (int[,]) array2.ToArray(MWArrayComponent.Real, true);
                        for (int m = 0; m < num3; m++)
                        {
                            num = Math.Max(num, numArray2[0, m]);
                            num2 = Math.Max(num2, numArray3[0, m]);
                        }
                    }
                    else
                    {
                        long[,] numArray4 = (long[,]) array.ToArray(MWArrayComponent.Real, true);
                        long[,] numArray5 = (long[,]) array2.ToArray(MWArrayComponent.Real, true);
                        numArray2 = new int[numArray4.GetLength(0), numArray4.GetLength(1)];
                        numArray3 = new int[numArray5.GetLength(0), numArray5.GetLength(1)];
                        for (int n = 0; n < num3; n++)
                        {
                            int num16;
                            int num17;
                            numArray2[0, n] = num16 = (int) numArray4[0, n];
                            num = Math.Max(num, num16);
                            numArray3[0, n] = num17 = (int) numArray5[0, n];
                            num2 = Math.Max(num2, num17);
                        }
                    }
                    int num6 = num * num2;
                    byte[] buffer = new byte[num6];
                    if (IntPtr.Zero != source) Marshal.Copy(source, buffer, 0, num3);
                    Array array3 = Array.CreateInstance(typeof(bool), num, num2);
                    for (int k = 0; k < num3; k++)
                    {
                        bool flag = 1 == buffer[k];
                        array3.SetValue(flag, (int) (numArray2[0, k] - 1), (int) (numArray3[0, k] - 1));
                    }
                    return array3;
                }
                int numberOfElements = base.NumberOfElements;
                int length = dimensions.Length;
                int[] lengths = new int[length];
                int[] indices = new int[length];
                int num10 = dimensions[0];
                int num11 = lengths[length - 1] = dimensions[1];
                lengths[length - 2] = num10;
                for (int i = 2; i < length; i++)
                {
                    lengths[length - (i + 1)] = dimensions[i];
                }
                Array array4 = Array.CreateInstance(typeof(bool), lengths);
                byte[] destination = new byte[numberOfElements];
                if (IntPtr.Zero != source) Marshal.Copy(source, destination, 0, numberOfElements);
                for (int j = 0; j < numberOfElements; j += num10 * num11)
                {
                    for (int num14 = 0; num14 < num10; num14++)
                    {
                        for (int num15 = 0; num15 < num11; num15++)
                        {
                            bool flag2 = 1 == destination[num15 * num10 + num14 + j];
                            array4.SetValue(flag2, indices);
                            indices = base.GetNextSubscript(lengths, indices, 0);
                        }
                    }
                }
                array5 = array4;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array5;
        }

        private void CreateLogicalArray(int rows, int columns, bool[] boolArray, bool columnMajorData)
        {
            try
            {
                int length = rows * columns;
                if (boolArray == null || length != boolArray.Length) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorDataArraySize"), "boolArray");
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { rows, columns };
                base.SetMXArray(mxCreateLogicalArray(dimensions.Length, dimensions), MWArrayType.Logical, dimensions.Length, dimensions);
                byte[] source = new byte[length];
                if (columnMajorData)
                {
                    for (int i = 0; i < length; i++)
                    {
                        source[i] = boolArray[i] ? ((byte) 1) : ((byte) 0);
                    }
                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        for (int k = 0; k < columns; k++)
                        {
                            source[k * rows + j] = boolArray[j * columns + k] ? ((byte) 1) : ((byte) 0);
                        }
                    }
                }
                IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
                Marshal.Copy(source, 0, destination, length);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        internal override object ConvertToType(Type t)
        {
            if (t == typeof(MWArray) || t == typeof(MWLogicalArray)) return this;
            if (t == typeof(bool) && base.IsScalar()) return (bool) this;
            if (t.IsArray && t.GetArrayRank() == base.NumberofDimensions) return this.ToArray();
            if (t.IsArray && t.GetArrayRank() == 1 && base.IsVector()) return this.ToVector();
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWLogicalArray" + MWArray.RankToString(base.NumberofDimensions) + " to " + t.FullName;
            throw new ArgumentException(message, new ApplicationException(str2));
        }
    }
}
