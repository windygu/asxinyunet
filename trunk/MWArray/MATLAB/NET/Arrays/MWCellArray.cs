namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Text;
    using System.Threading;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWCellArray : MWArray, IEquatable<MWCellArray>
    {
        private static readonly MWCellArray _Empty = new MWCellArray();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCalcSingleSubscript_700_proxy")]
        private static extern int mxCalcSingleSubscript([In] MWSafeHandle hMXArray, [In] int numSubscripts, [In] int[] subscripts);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateCellArray_700_proxy")]
        private static extern MWSafeHandle mxCreateCellArray([In] int numDimensions, [In] int[] dimensions);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetCell_700_proxy")]
        private static extern MWSafeHandle mxGetCell([In] MWSafeHandle hMXArray, [In] int index);
        public MWCellArray()
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[2];
                base.SetMXArray(mxCreateCellArray(dimensions.Length, dimensions), MWArrayType.Cell, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCellArray(int rows, int columns)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { rows, columns };
                base.SetMXArray(mxCreateCellArray(dimensions.Length, dimensions), MWArrayType.Cell, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCellArray(params int[] dimensions)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateCellArray(dimensions.Length, dimensions), MWArrayType.Cell, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCellArray(MWNumericArray dimensions)
        {
            double[] numArray = (double[]) dimensions.ToVector(MWArrayComponent.Real);
            int[] numArray2 = new int[numArray.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray2[i] = (int) numArray[i];
            }
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateCellArray(numArray2.Length, numArray2), MWArrayType.Cell, numArray2.Length, numArray2);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCellArray(MWCharArray strings)
        {
            if (2 != strings.NumberofDimensions) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorNotAMatrix"), "strings");
            int[] dimensions = strings.Dimensions;
            int num = dimensions[0];
            int capacity = dimensions[1];
            try
            {
                Monitor.Enter(MWArray.mxSync);
                StringBuilder builder = new StringBuilder(capacity);
                int[] numArray2 = new int[] { num, 1 };
                base.SetMXArray(mxCreateCellArray(numArray2.Length, numArray2), MWArrayType.Cell);
                for (int i = 1; i <= num; i++)
                {
                    for (int j = 1; j <= capacity; j++)
                    {
                        builder.Insert(j - 1, (char) strings[new int[] { i, j }]);
                    }
                    this[new int[] { i, 1 }] = new MWCharArray(builder.ToString());
                    builder.Remove(0, capacity);
                }
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        internal MWCellArray(MWSafeHandle hMXArray) : base(hMXArray)
        {
            base.array_Type = MWArrayType.Cell;
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

        public MWArray this[int[] indices]
        {
            get
            {
                MWArray typedArray;
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    MWSafeHandle hMXArray = base.ArrayIndexer(this, indices);
                    if (hMXArray.IsInvalid)
                    {
                        if (1 == indices.Length)
                        {
                            if (indices[0] < 0 || indices[0] > MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                        }
                        else
                        {
                            int[] dimensions = this.Dimensions;
                            if (dimensions.Length != indices.Length) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                            for (int i = 0; i < indices.Length; i++)
                            {
                                if (indices[i] > dimensions[i]) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                            }
                        }
                        return MWNumericArray.Empty;
                    }
                    typedArray = MWArray.GetTypedArray(hMXArray);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return typedArray;
            }
            set { base.ArrayIndexer(value, this, indices); }
        }
        protected MWCellArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) {  }

        public static MWCellArray Empty { get { return (MWCellArray) _Empty.Clone(); } }
        public override string ToString() { return base.ToString(); }

        public override object Clone()
        {
            MWCellArray array = (MWCellArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                array.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Cell);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array;
        }

        public override bool Equals(object obj) { return (obj is MWCellArray) && this.Equals(obj as MWCellArray); }

        private bool Equals(MWCellArray other) { return base.Equals(other); }

        bool IEquatable<MWCellArray>.Equals(MWCellArray other) { return this.Equals(other); }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override Array ToArray()
        {
            Array array3;
            base.CheckDisposed();
            int[] dimensions = this.Dimensions;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int numberOfElements = base.NumberOfElements;
                int length = dimensions.Length;
                int[] lengths = new int[length];
                int[] indices = new int[length];
                int num3 = dimensions[0];
                int num4 = lengths[length - 1] = dimensions[1];
                lengths[length - 2] = num3;
                for (int i = 2; i < length; i++)
                {
                    lengths[length - (i + 1)] = dimensions[i];
                }
                Array array = Array.CreateInstance(typeof(object), lengths);
                for (int j = 0; j < numberOfElements; j += num3 * num4)
                {
                    for (int k = 0; k < num3; k++)
                    {
                        for (int m = 0; m < num4; m++)
                        {
                            array.SetValue(this[new int[] { m * num3 + k + j + 1 }].ToArray(), indices);
                            indices = base.GetNextSubscript(lengths, indices, 0);
                        }
                    }
                }
                array3 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array3;
        }

        internal override object ConvertToType(Type t)
        {
            if (t == typeof(MWArray) || t == typeof(MWCellArray)) return this;
            if (t == typeof(ArrayList) && base.IsVector())
            {
                ArrayList list = new ArrayList();
                int numberOfElements = base.NumberOfElements;
                for (int i = 1; i <= numberOfElements; i++)
                {
                    MWArray array = this[new int[] { i }];
                    if (array.IsStructArray)
                        list.Add(array);
                    else if (array.IsCellArray)
                        list.Add(this.ConvertToType(typeof(Array)));
                    else
                        list.Add(array.ToArray());
                }
                return list;
            }
            if (t == typeof(Array))
            {
                int[] numArray;
                Array array2 = base.AllocateNativeArray(typeof(object), out numArray);
                int num3 = base.NumberOfElements;
                int[] indices = new int[base.NumberofDimensions];
                int num4 = this.Dimensions[0];
                int num5 = this.Dimensions[1];
                for (int j = 0; j < num3; j += num4 * num5)
                {
                    for (int k = 0; k < num4; k++)
                    {
                        for (int m = 0; m < num5; m++)
                        {
                            MWArray array3 = this[new int[] { m * num4 + k + j + 1 }];
                            if (!array3.IsStructArray)
                            {
                                if (array3.IsCellArray)
                                    this.ConvertToType(typeof(Array));
                                else
                                    array3.ToArray();
                            }
                            array2.SetValue(array3, indices);
                            indices = base.GetNextSubscript(numArray, indices, 0);
                        }
                    }
                }
                return array2;
            }
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWCellArray to " + t.FullName;
            throw new ArgumentException(message, new ApplicationException(str2));
        }
    }
}
