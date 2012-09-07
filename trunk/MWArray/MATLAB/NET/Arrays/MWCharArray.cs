namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Threading;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWCharArray : MWArray, IEquatable<MWCharArray>
    {
        private static readonly MWCharArray _Empty = new MWCharArray();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxArrayToString_proxy")]
        private static extern IntPtr mxArrayToString([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateCharArray_700_proxy")]
        private static extern MWSafeHandle mxCreateCharArray([In] int numberOfDimensions, [In] int[] dimensions);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetChars_proxy")]
        private static extern IntPtr mxGetChars([In] MWSafeHandle hMXArray);
        public MWCharArray()
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[2];
                base.SetMXArray(mxCreateCharArray(dimensions.Length, dimensions), MWArrayType.Character, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(params int[] dimensions)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateCharArray(dimensions.Length, dimensions), MWArrayType.Character, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(string value)
        {
            IntPtr zero = IntPtr.Zero;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                zero = Marshal.StringToHGlobalAnsi(value);
                base.SetMXArray(MWArray.mxCreateString(zero), MWArrayType.Character);
            }
            finally
            {
                if (IntPtr.Zero != zero) Marshal.FreeCoTaskMem(zero);
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(char value)
        {
            IntPtr zero = IntPtr.Zero;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                zero = Marshal.StringToHGlobalAnsi(value.ToString());
                base.SetMXArray(MWArray.mxCreateString(zero), MWArrayType.Character);
            }
            finally
            {
                if (IntPtr.Zero != zero) Marshal.FreeCoTaskMem(zero);
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(char[] value)
        {
            IntPtr zero = IntPtr.Zero;
            try
            {
                Monitor.Enter(MWArray.mxSync);
                zero = Marshal.StringToHGlobalAnsi(new string(value));
                base.SetMXArray(MWArray.mxCreateString(zero), MWArrayType.Character);
            }
            finally
            {
                if (IntPtr.Zero != zero) Marshal.FreeCoTaskMem(zero);
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(string[] strings)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = null;
                if (strings == null)
                    dimensions = new int[1];
                else
                {
                    int num = 0;
                    foreach (string str in strings)
                    {
                        num = Math.Max(str.Length, num);
                    }
                    dimensions = new int[] { strings.Length, num };
                }
                int num2 = dimensions[0];
                int totalWidth = dimensions[1];
                base.SetMXArray(mxCreateCharArray(dimensions.Length, dimensions), MWArrayType.Character, dimensions.Length, dimensions);
                int length = num2 * totalWidth;
                char[] destination = new char[length];
                for (int i = 0; i < num2; i++)
                {
                    string str2 = strings[i].PadRight(totalWidth);
                    for (int j = 0; j < totalWidth; j++)
                    {
                        str2.CopyTo(j, destination, j * num2 + i, 1);
                    }
                }
                IntPtr ptr = MWArray.mxGetData(this.MXArrayHandle);
                if (ptr != IntPtr.Zero) Marshal.Copy(destination, 0, ptr, length);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWCharArray(Array stringArray)
        {
            int length = 0;
            int rank = stringArray.Rank;
            int[] dimensions = null;
            char[] destination = null;
            if (stringArray != null && typeof(char) == stringArray.GetType().GetElementType())
                this.MWCharArrayFromNetCharArray(stringArray);
            else
            {
                if (stringArray == null || typeof(string) != stringArray.GetType().GetElementType()) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorArrayStringType"), "stringArray");
                int num3 = 0;
                string current = null;
                dimensions = new int[rank + 1];
                IEnumerator enumerator = stringArray.GetEnumerator();
                for (int i = 0; i < stringArray.LongLength; i++)
                {
                    enumerator.MoveNext();
                    current = (string) enumerator.Current;
                    num3 = Math.Max(current.Length, num3);
                }
                int num5 = dimensions[0] = stringArray.GetLength(rank - 1);
                int totalWidth = dimensions[1] = num3;
                for (int j = 0; j < rank - 1; j++)
                {
                    dimensions[rank - j] = stringArray.GetLength(j);
                }
                length = stringArray.Length * num3;
                destination = new char[length];
                enumerator.Reset();
                for (int k = 0; k < length; k += num5 * totalWidth)
                {
                    for (int m = 0; m < num5; m++)
                    {
                        enumerator.MoveNext();
                        current = (string) enumerator.Current;
                        current = current.PadRight(totalWidth);
                        for (int n = 0; n < totalWidth; n++)
                        {
                            current.CopyTo(n, destination, n * num5 + m + k, 1);
                        }
                    }
                }
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    base.SetMXArray(mxCreateCharArray(dimensions.Length, dimensions), MWArrayType.Character, dimensions.Length, dimensions);
                    IntPtr ptr = MWArray.mxGetData(this.MXArrayHandle);
                    if (ptr != IntPtr.Zero) Marshal.Copy(destination, 0, ptr, length);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
            }
        }

        internal MWCharArray(MWSafeHandle hMXArray) : base(hMXArray)
        {
            base.array_Type = MWArrayType.Character;
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

        public MWCharArray this[int[] indices] { get { return (MWCharArray) MWArray.GetTypedArray(base.ArrayIndexer(this, indices)); } set { base.ArrayIndexer(value, this, indices); } }
        public static explicit operator char(MWCharArray scalar)
        {
            char ch;
            scalar.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                IntPtr source = mxGetChars(scalar.MXArrayHandle);
                char[] destination = new char[1];
                Marshal.Copy(source, destination, 0, 1);
                ch = destination[0];
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return ch;
        }

        public static implicit operator MWCharArray(string value) { return new MWCharArray(value); }

        protected MWCharArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) {  }

        public static MWCharArray Empty { get { return (MWCharArray) _Empty.Clone(); } }
        private unsafe void MWCharArrayFromNetCharArray(Array charArray)
        {
            int rank = charArray.Rank;
            int[] dimensions = new int[rank];
            char[] chArray = null;
            for (int i = 0; i < rank; i++)
            {
                dimensions[i] = charArray.GetLength(i);
            }
            int[] numArray2 = MWArray.NetDimensionToMATLABDimension(dimensions);
            if (rank == 1)
                chArray = (char[]) charArray;
            else
            {
                int length = charArray.Length;
                int num4 = numArray2[0];
                int num5 = numArray2[1];
                int num6 = num4 * num5;
                chArray = new char[length];
                GCHandle handle = GCHandle.Alloc(charArray, GCHandleType.Pinned);
                GCHandle handle2 = GCHandle.Alloc(chArray, GCHandleType.Pinned);
                try
                {
                    char* chPtr = (char*) handle.AddrOfPinnedObject();
                    char* chPtr2 = (char*) handle2.AddrOfPinnedObject();
                    for (int j = 0; j < length; j += num6)
                    {
                        for (int k = 0; k < num4; k++)
                        {
                            for (int m = 0; m < num5; m++)
                            {
                                chPtr++;
                                chPtr2[m * num4 + k + j] = chPtr[0];
                            }
                        }
                    }
                }
                finally
                {
                    handle.Free();
                    handle2.Free();
                }
            }
            lock (MWArray.mxSync)
            {
                base.SetMXArray(mxCreateCharArray(numArray2.Length, numArray2), MWArrayType.Character, numArray2.Length, numArray2);
                IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
                if (destination != IntPtr.Zero) Marshal.Copy(chArray, 0, destination, charArray.Length);
            }
        }

        public override Array ToArray()
        {
            Array array2;
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
                IntPtr source = MWArray.mxGetData(this.MXArrayHandle);
                Array array = Array.CreateInstance(typeof(char), lengths);
                char[] destination = new char[numberOfElements];
                if (IntPtr.Zero != source) Marshal.Copy(source, destination, 0, numberOfElements);
                for (int j = 0; j < numberOfElements; j += num3 * num4)
                {
                    for (int k = 0; k < num3; k++)
                    {
                        for (int m = 0; m < num4; m++)
                        {
                            char ch = destination[m * num3 + k + j];
                            array.SetValue(ch, indices);
                            indices = base.GetNextSubscript(lengths, indices, 0);
                        }
                    }
                }
                array2 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array2;
        }

        internal string CharArrayToString(Array src)
        {
            if (src.Rank == 1) return new string((char[]) src);
            if (src.Rank != 2 || src.GetUpperBound(0) != 0) throw new ArgumentException("Not a valid conversion");
            int length = src.Length;
            return new string(MWArray.ConvertMatrixToVector<char>((char[,]) src));
        }

        internal unsafe Array CharArrayToStringArray(Array src)
        {
            int dimension = src.Rank - 1;
            int[] lengths = new int[dimension];
            int[] indices = new int[dimension];
            int length = src.GetLength(dimension);
            for (int i = 0; i < dimension; i++)
            {
                lengths[i] = src.GetLength(i);
            }
            Array array = Array.CreateInstance(typeof(string), lengths);
            GCHandle handle = GCHandle.Alloc(src, GCHandleType.Pinned);
            try
            {
                char* chPtr = (char*) handle.AddrOfPinnedObject();
                int num4 = src.Length;
                for (int j = 0; j < num4; j += length)
                {
                    string str = new string(chPtr, j, length);
                    array.SetValue(str, indices);
                    indices = base.GetNextSubscript(lengths, indices, 0);
                }
            }
            finally
            {
                handle.Free();
            }
            return array;
        }

        internal override object ConvertToType(Type t)
        {
            if (t == typeof(MWArray) || t == typeof(MWCharArray)) return this;
            Array src = this.ToArray();
            if (t == typeof(string)) return this.CharArrayToString(src);
            if (t.IsArray && t.GetElementType() == typeof(string) && t.GetArrayRank() == base.NumberofDimensions - 1) return this.CharArrayToStringArray(src);
            if (t == typeof(char) && base.IsScalar()) return (char) this;
            if (t.IsArray && t.GetArrayRank() == 1 && base.IsVector()) return MWArray.ConvertMatrixToVector<char>((char[,]) src);
            if (t.IsArray && t.GetArrayRank() == base.NumberofDimensions) return src;
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWCharArray" + MWArray.RankToString(base.NumberofDimensions) + " to " + t.FullName;
            throw new ArgumentException(message, new ApplicationException(str2));
        }

        public override string ToString() { return base.ToString(); }

        public override object Clone()
        {
            object obj2;
            MWCharArray array = (MWCharArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                array.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Character);
                obj2 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return obj2;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj) { return (obj is MWCharArray) && this.Equals(obj as MWCharArray); }

        private bool Equals(MWCharArray other) { return base.Equals(other); }

        bool IEquatable<MWCharArray>.Equals(MWCharArray other) { return this.Equals(other); }
    }
}
