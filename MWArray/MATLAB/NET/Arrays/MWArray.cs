namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Arrays.native;
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Text;
    using System.Threading;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWArray : ICloneable, ISerializable, IDisposable
    {
        private static bool nativeGCEnabled = true;
        private static long nativeGCBlockSize = 0x989680;
        internal static ResourceManager resourceManager;
        internal static StringBuilder formattedOutputString = null;
        internal static object mxSync = new object[0];
        internal static Dictionary<Type, Type[]> typeMap = new Dictionary<Type, Type[]>();
        private MWSafeHandle _hMXArray;
        internal MathWorks.MATLAB.NET.Arrays.MWArrayType array_Type;
        internal long NumElements;
        internal long ElementSize;
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclmcrInitialize2_proxy")]
        private static extern bool mclmcrInitialize2(int primaryMode);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateString_proxy")]
        internal static extern MWSafeHandle mxCreateString([In] IntPtr pString);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMxDeserialize_proxy")]
        internal static extern MWSafeHandle mxDeserialize([In] IntPtr pSerializedBuffer, [In] int size);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxDuplicateArray_proxy")]
        internal static extern MWSafeHandle mxDuplicateArray([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxFree_proxy")]
        internal static extern void mxFree([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetClassID_proxy")]
        internal static extern int mxGetClassID([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetData_proxy")]
        internal static extern IntPtr mxGetData([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetDimensions_700_proxy")]
        internal static extern IntPtr mxGetDimensions([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetElementSize_proxy")]
        internal static extern int mxGetElementSize([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetM_proxy")]
        internal static extern int mxGetM([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetN_proxy")]
        internal static extern int mxGetN([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetNumberOfDimensions_700_proxy")]
        internal static extern int mxGetNumberOfDimensions([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetNumberOfElements_proxy")]
        internal static extern int mxGetNumberOfElements([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetScalar_proxy")]
        internal static extern double mxGetScalar([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMxIsA_proxy")]
        internal static extern byte mxIsA([In] MWSafeHandle hMXArray, [In] string typeName);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsCell_proxy")]
        internal static extern byte mxIsCell([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsChar_proxy")]
        internal static extern byte mxIsChar([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsEmpty_proxy")]
        internal static extern byte mxIsEmpty([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsLogical_proxy")]
        internal static extern byte mxIsLogical([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsNumeric_proxy")]
        internal static extern byte mxIsNumeric([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsSparse_proxy")]
        internal static extern byte mxIsSparse([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxIsStruct_proxy")]
        internal static extern byte mxIsStruct([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMxSerialize_proxy")]
        internal static extern MWSafeHandle mxSerialize([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="array_handle_get_int_proxy")]
        internal static extern IntPtr array_handle_get_int([In] IntPtr pMXArray, [In] IntPtr numIndices, [In] IntPtr[] indices);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclArrayHandle2mxArray_proxy")]
        internal static extern int mclArrayHandle2mxArray(out MWSafeHandle hMXArray, [In] IntPtr pArrayHandle);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclcppArrayToString_proxy")]
        private static extern int mclcppArrayToString([In] MWSafeHandle hMXArray, out string formattedString);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclIsIdentical_proxy")]
        internal static extern byte mclIsIdentical([In] MWSafeHandle hMXArray1, [In] MWSafeHandle hMXArray2);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclmxArray2ArrayHandle_proxy")]
        internal static extern int mclmxArray2ArrayHandle(out IntPtr pArrayHandle, [In] IntPtr pMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="array_handle_set_proxy")]
        internal static extern int array_handle_set([In] IntPtr pArrayHandle, [In] IntPtr pArrayHandleValue);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="array_handle_set_logical_proxy")]
        private static extern int array_handle_set_logical([In] IntPtr pArrayHandle, [In] MWSafeHandle hMXArray, [In] IntPtr len);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMXArrayGet_proxy")]
        internal static extern int mclMXArrayGet(out MWSafeHandle hMXArraySrcElem, [In] MWSafeHandle hMXArray, [In] IntPtr numIndices, [In] IntPtr[] indices);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMXArraySet_proxy")]
        private static extern int mclMXArraySet([In] MWSafeHandle hMXArrayTrg, [In] MWSafeHandle hMXArraySrcElem, [In] IntPtr numIndices, [In] IntPtr[] indices);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMXArraySetLogical_proxy")]
        private static extern int mclMXArraySetLogical([In] MWSafeHandle hMXArrayTrg, [In] MWSafeHandle hMXArraySrcElem, [In] IntPtr numIndices, [In] IntPtr[] indices);
        [SuppressUnmanagedCodeSecurity, DllImport("libut.dll")]
        private static extern int ut_hash_pointer([Out] int hashCode, [In] MWSafeHandle hMXArray);
        static MWArray()
        {
            try
            {
                PopulateTypeMap();
                Monitor.Enter(mxSync);
                bool mCRAppInitialized = MWMCR.MCRAppInitialized;
                Assembly entryAssembly = Assembly.GetEntryAssembly();
//                NativeGCAttribute attribute = (entryAssembly != null) ? ((NativeGCAttribute) Attribute.GetCustomAttribute(entryAssembly, typeof(NativeGCAttribute))) : null;
//                if (attribute != null && nativeGCEnabled = attribute.GCEnabled && 0 < attribute.GCBlockSize) 
//                	nativeGCBlockSize = (long) (attribute.GCBlockSize * 10000000.0);
              

                NativeGCAttribute nativeGCAttribute = (entryAssembly != null) ? ((NativeGCAttribute)Attribute.GetCustomAttribute(entryAssembly, typeof(NativeGCAttribute))) : null;
				if (nativeGCAttribute != null && (MWArray.nativeGCEnabled = nativeGCAttribute.GCEnabled) && 0 < nativeGCAttribute.GCBlockSize)
				{
					MWArray.nativeGCBlockSize = (long)((double)nativeGCAttribute.GCBlockSize * 10000000.0);
				}
                resourceManager = MWResources.getResourceManager();
                mclmcrInitialize2(1);
                formattedOutputString = new StringBuilder(0x400);
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
        }

        internal MWArray() { this._hMXArray = new MWSafeHandle(); }

        internal MWArray(MWSafeHandle hMXArray)
        {
            this._hMXArray = new MWSafeHandle();
            this.SetMXArray(hMXArray, MathWorks.MATLAB.NET.Arrays.MWArrayType.Array);
        }

        public static void DisposeArray(object _object)
        {
            if (_object != null)
            {
                if (_object is IDisposable)
                    ((IDisposable) _object).Dispose();
                else if (_object is MathWorks.MATLAB.NET.Arrays.MWArray[])
                {
                    MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = (MathWorks.MATLAB.NET.Arrays.MWArray[]) _object;
                    MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray2 = arrayArray;
                    for (int i = 0; i < arrayArray2.Length; i++)
                    {
                        object obj2 = arrayArray2[i];
                        DisposeArray(obj2);
                    }
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                Monitor.Enter(mxSync);
                if (this._hMXArray != null && !this.IsDisposed && MWMCR.MCRAppInitialized) this._hMXArray.Dispose();
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
        }

        public MathWorks.MATLAB.NET.Arrays.MWArray this[int[] indices]
        {
            get
            {
                switch (this.array_Type)
                {
                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Numeric:
                        return ((MWNumericArray) this)[indices];

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Logical:
                        return ((MWLogicalArray) this)[indices];

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Cell:
                        return ((MathWorks.MATLAB.NET.Arrays.MWCellArray) this)[indices];

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray:
                        throw new Exception(resourceManager.GetString("MWErrorNotSupported"));

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Structure:
                        throw new Exception(resourceManager.GetString("MWErrorNotSupported"));
                }
                return GetTypedArray(this.ArrayIndexer(this, indices));
            }
            set
            {
                switch (this.array_Type)
                {
                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Numeric:
                        if (this.array_Type != value.array_Type) throw new InvalidCastException(resourceManager.GetString("MWErrorDataArrayType"));
                        ((MWNumericArray) this)[indices] = (MWNumericArray) value;
                        return;

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Logical:
                        if (this.array_Type != value.array_Type) throw new InvalidCastException(resourceManager.GetString("MWErrorDataArrayType"));
                        ((MWLogicalArray) this)[indices] = (MWLogicalArray) value;
                        return;

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Cell:
                        ((MathWorks.MATLAB.NET.Arrays.MWCellArray) this)[indices] = value;
                        return;

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray:
                        if (this.array_Type != value.array_Type) throw new InvalidCastException(resourceManager.GetString("MWErrorDataArrayType"));
                        ((MWObjectArray) this)[indices] = (MWObjectArray) value;
                        return;

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Structure:
                        throw new Exception(resourceManager.GetString("MWErrorNotSupported"));
                }
                this.ArrayIndexer(value, this, indices);
            }
        }
        public static implicit operator MathWorks.MATLAB.NET.Arrays.MWArray(double scalar) { return new MWNumericArray(scalar); }

        public static implicit operator MathWorks.MATLAB.NET.Arrays.MWArray(string value) { return new MWCharArray(value); }

        internal MWArray(SerializationInfo serializationInfo, StreamingContext context)
        {
            this._hMXArray = new MWSafeHandle();
            IntPtr zero = IntPtr.Zero;
            try
            {
                Monitor.Enter(mxSync);
                byte[] source = (byte[]) serializationInfo.GetValue("serializedState", typeof(byte[]));
                this.array_Type = (MathWorks.MATLAB.NET.Arrays.MWArrayType) serializationInfo.GetValue("array_Type", typeof(MathWorks.MATLAB.NET.Arrays.MWArrayType));
                int length = source.Length;
                zero = Marshal.AllocCoTaskMem(length);
                Marshal.Copy(source, 0, zero, length);
                this.SetMXArray(mxDeserialize(zero, length), this.array_Type);
            }
            finally
            {
                if (IntPtr.Zero != zero) Marshal.FreeCoTaskMem(zero);
                Monitor.Exit(mxSync);
            }
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            MWSafeHandle hMXArray = null;
            IntPtr zero = IntPtr.Zero;
            try
            {
                Monitor.Enter(mxSync);
                hMXArray = mxSerialize(this._hMXArray);
                int length = mxGetNumberOfElements(hMXArray);
                zero = mxGetData(hMXArray);
                byte[] destination = new byte[length];
                Marshal.Copy(zero, destination, 0, length);
                info.AddValue("serializedState", destination);
                info.AddValue("array_Type", this.array_Type);
            }
            finally
            {
                if (hMXArray != null && !hMXArray.IsInvalid) hMXArray.Dispose();
                Monitor.Exit(mxSync);
            }
        }

        public static bool NativeGCEnabled { get { return nativeGCEnabled; } set { nativeGCEnabled = value; } }
        public static long NativeGCBlockSize { get { return nativeGCBlockSize; } }
        public MathWorks.MATLAB.NET.Arrays.MWArrayType ArrayType
        {
            get
            {
                this.CheckDisposed();
                return this.array_Type;
            }
        }
        public virtual int[] Dimensions
        {
            get
            {
                int[] numArray2;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    MWSafeHandle mXArrayHandle = this.MXArrayHandle;
                    int length = mxGetNumberOfDimensions(mXArrayHandle);
                    int[] destination = new int[length];
                    Marshal.Copy(mxGetDimensions(mXArrayHandle), destination, 0, length);
                    numArray2 = destination;
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return numArray2;
            }
        }
        public virtual bool IsDisposed
        {
            get
            {
                if (MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray == this.array_Type) return ((MWObjectArray) this).IsDisposed;
                return this._hMXArray.IsInvalid;
            }
        }
        public virtual bool IsEmpty
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsEmpty(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public bool IsCellArray
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsCell(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public bool IsCharArray
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsChar(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public bool IsLogicalArray
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsLogical(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public bool IsNumericArray
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsNumeric(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public bool IsStructArray
        {
            get
            {
                bool flag;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    flag = 1 == mxIsStruct(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return flag;
            }
        }
        public int NumberofDimensions
        {
            get
            {
                int num;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    num = mxGetNumberOfDimensions(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return num;
            }
        }
        public int NumberOfElements
        {
            get
            {
                int num;
                this.CheckDisposed();
                MWSafeHandle mXArrayHandle = this.MXArrayHandle;
                try
                {
                    Monitor.Enter(mxSync);
                    num = (mxIsSparse(mXArrayHandle) == 0) ? mxGetNumberOfElements(mXArrayHandle) : 0;
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return num;
            }
        }
        internal virtual MWSafeHandle MXArrayHandle
        {
            get
            {
                MWSafeHandle mXArrayHandle = this._hMXArray;
                if (MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray == this.array_Type) mXArrayHandle = ((MWObjectArray) this).MXArrayHandle;
                return mXArrayHandle;
            }
        }
        internal MATLABArrayType MATLABType
        {
            get
            {
                MATLABArrayType type;
                this.CheckDisposed();
                try
                {
                    Monitor.Enter(mxSync);
                    type = (MATLABArrayType) mxGetClassID(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(mxSync);
                }
                return type;
            }
        }
        internal static MathWorks.MATLAB.NET.Arrays.MWArray GetTypedArray(MWSafeHandle hMXArray)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray array2;
            try
            {
                Monitor.Enter(mxSync);
                MathWorks.MATLAB.NET.Arrays.MWArray array = null;
                if (hMXArray.IsInvalid) return MWNumericArray.Empty;
                switch (mxGetClassID(hMXArray))
                {
                    case 0:
                    case 0x10:
                    case 0x11:
                    case 0x12:
                        array = new MathWorks.MATLAB.NET.Arrays.MWArray(hMXArray);
                        break;

                    case 1:
                        array = new MathWorks.MATLAB.NET.Arrays.MWCellArray(hMXArray);
                        break;

                    case 2:
                        array = new MathWorks.MATLAB.NET.Arrays.MWStructArray(hMXArray);
                        break;

                    case 3:
                        array = new MWLogicalArray(hMXArray);
                        break;

                    case 4:
                        array = new MWCharArray(hMXArray);
                        break;

                    case 5:
                        array = new MWIndexArray(hMXArray);
                        break;

                    case 6:
                    case 7:
                    case 9:
                    case 10:
                    case 12:
                    case 14:
                        array = new MWNumericArray(hMXArray);
                        break;

                    case 8:
                    case 11:
                    case 13:
                    case 15:
                    {
                        string message = resourceManager.GetString("MWErrorInvalidReturnType");
                        throw new ArgumentOutOfRangeException("numArgsOut", message);
                    }
                    default:
                        if (mxIsA(hMXArray, "System.Object") != 0 || mxIsA(hMXArray, "int32") != 0) array = new MWObjectArray(hMXArray);
                        break;
                }
                array2 = array;
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return array2;
        }

        internal static bool IsMWArray(object objIn)
        {
            Type type = objIn.GetType();
            if (type != typeof(MathWorks.MATLAB.NET.Arrays.MWArray) && !type.IsSubclassOf(typeof(MathWorks.MATLAB.NET.Arrays.MWArray))) return false;
            return true;
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWArray ConvertObjectToMWArray(object objIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray array = null;
            if (objIn == null) return array;
            if (IsMWArray(objIn)) return (MathWorks.MATLAB.NET.Arrays.MWArray) objIn;
            if (objIn.GetType() == typeof(string)) return new MWCharArray((string) objIn);
            if (objIn.GetType().IsValueType && objIn.GetType().IsPrimitive) return GetMWArrayFromValueType(objIn);
            if (objIn.GetType().IsArray && IsArrayOfSupportedType(objIn))
            {
                string arrType = ArrayElementTypeName(objIn);
                return GetMWArrayFromArrayType((Array) objIn, arrType);
            }
            if (objIn.GetType().IsArray && IsJaggedArrayOfSupportedType((Array) objIn)) return GetMWArrayFromJaggedArrayType((Array) objIn);
            if (objIn.GetType().IsValueType && !objIn.GetType().IsPrimitive) return GetMWStructArrayFromNETStructs((ValueType) objIn);
            if (objIn.GetType().IsArray && objIn.GetType().GetElementType().IsValueType && !objIn.GetType().GetElementType().IsPrimitive) return GetMWStructArrayFromNETStructs((Array) objIn);
            if (objIn.GetType() == typeof(MathWorks.MATLAB.NET.Arrays.native.MWStructArray))
            {
                MathWorks.MATLAB.NET.Arrays.native.MWStructArray array2 = (MathWorks.MATLAB.NET.Arrays.native.MWStructArray) objIn;
                MathWorks.MATLAB.NET.Arrays.MWStructArray array3 = new MathWorks.MATLAB.NET.Arrays.MWStructArray(array2.Dimensions, array2.FieldNames);
                for (int i = 1; i <= array2.NumberOfElements; i++)
                {
                    for (int j = 0; j < array2.NumberOfFields; j++)
                    {
                        object obj2 = array2[array2.FieldNames[j], new int[] { i }];
                        if (obj2 != null)
                        {
                            MathWorks.MATLAB.NET.Arrays.MWArray array4 = ConvertObjectToMWArray(obj2);
                            array3[array2.FieldNames[j], new int[] { i }] = array4;
                        }
                    }
                }
                return array3;
            }
            if (objIn.GetType() == typeof(MathWorks.MATLAB.NET.Arrays.native.MWCellArray))
            {
                MathWorks.MATLAB.NET.Arrays.native.MWCellArray array5 = (MathWorks.MATLAB.NET.Arrays.native.MWCellArray) objIn;
                MathWorks.MATLAB.NET.Arrays.MWCellArray targetArray = new MathWorks.MATLAB.NET.Arrays.MWCellArray(array5.Dimensions);
                for (int k = 1; k <= array5.NumberOfElements; k++)
                {
                    object obj3 = array5.get(k);
                    if (obj3 != null)
                    {
                        MathWorks.MATLAB.NET.Arrays.MWArray valueArray = ConvertObjectToMWArray(obj3);
                        targetArray.ArrayIndexer(valueArray, targetArray, new int[] { k });
                    }
                }
                return targetArray;
            }
            if (objIn.GetType() == typeof(Hashtable) || IsDictionaryOfSupportedType(objIn)) return GetMWStructArrayFromIDictionary((IDictionary) objIn);
            if (objIn.GetType() == typeof(ArrayList)) return GetMWCellArrayFromArrayList((ArrayList) objIn);
            if (!AppDomain.CurrentDomain.IsDefaultAppDomain() && AppDomain.CurrentDomain.IsDefaultAppDomain() || !objIn.GetType().IsSerializable) throw new InvalidDataException("Input data type unsupported by MATLAB Builder NE");
            return new MWObjectArray(objIn);
        }

        private static MathWorks.MATLAB.NET.Arrays.MWArray GetMWArrayFromJaggedArrayType(Array array)
        {
            if (!IsCTSNumericType(JaggedArray.GetElementType(array.GetType()))) throw new InvalidDataException("Input data type unsupported by MATLAB Builder NE");
            return new MWNumericArray(array);
        }

        private static MathWorks.MATLAB.NET.Arrays.MWArray GetMWCellArrayFromArrayList(ArrayList objIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWCellArray array = null;
            int count = objIn.Count;
            if (count == 0) return new MathWorks.MATLAB.NET.Arrays.MWCellArray();
            array = new MathWorks.MATLAB.NET.Arrays.MWCellArray(1, count);
            int num2 = 1;
            foreach (object obj2 in objIn)
            {
                array[new int[] { num2++ }] = ConvertObjectToMWArray(obj2);
            }
            return array;
        }

        private static bool IsDictionaryOfSupportedType(object objIn)
        {
            Type type = objIn.GetType();
            if (type.GetInterface("IDictionary") != null)
            {
                Type[] genericArguments = type.GetGenericArguments();
                if (genericArguments.Length == 2 && genericArguments[0] == typeof(string) && IsSupportedType(genericArguments[1]) || type.IsArray && IsArrayOfSupportedType(objIn)) return true;
            }
            return false;
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWStructArray GetMWStructArrayFromIDictionary(IDictionary objIn)
        {
            if (objIn.Count == 0) throw new InvalidDataException("Cannot convert an empty Hashtable");
            string[] fieldNames = new string[objIn.Count];
            int num = 0;
            foreach (object obj2 in objIn.Keys)
            {
                fieldNames[num++] = (string) obj2;
            }
            MathWorks.MATLAB.NET.Arrays.MWStructArray array = new MathWorks.MATLAB.NET.Arrays.MWStructArray(1, 1, fieldNames);
            num = 0;
            foreach (object obj3 in objIn.Values)
            {
                array[fieldNames[num++]] = ConvertObjectToMWArray(obj3);
            }
            return array;
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWStructArray GetMWStructArrayFromNETStructs(ValueType structIn)
        {
            FieldInfo[] fields = structIn.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (fields.Length == 0) throw new InvalidDataException(string.Format("Type {0} does not contain any declared public fields", structIn.GetType().FullName));
            string[] fieldNames = new string[fields.Length];
            int num = 0;
            foreach (FieldInfo info in fields)
            {
                fieldNames[num++] = info.Name;
            }
            MathWorks.MATLAB.NET.Arrays.MWStructArray array = new MathWorks.MATLAB.NET.Arrays.MWStructArray(1, 1, fieldNames);
            num = 0;
            foreach (FieldInfo info2 in fields)
            {
                array[fieldNames[num++]] = ConvertObjectToMWArray(info2.GetValue(structIn));
            }
            return array;
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWStructArray GetMWStructArrayFromNETStructs(Array structArrIn)
        {
            if (structArrIn.Length == 0) throw new InvalidDataException(string.Format("Cannot convert an empty Array of {0}", structArrIn.GetType().GetElementType().FullName));
            if (structArrIn.Rank > 2) throw new InvalidDataException(string.Format("Cannot convert an Array of {0} with rank more than 2", structArrIn.GetType().GetElementType().FullName));
            FieldInfo[] fields = structArrIn.GetType().GetElementType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (fields.Length == 0) throw new InvalidDataException(string.Format("Type {0} does not contain any declared public fields", structArrIn.GetType().GetElementType().FullName));
            int rows = 0;
            int columns = 0;
            if (structArrIn.Rank == 1)
            {
                rows = 1;
                columns = structArrIn.GetLength(0);
            }
            else
            {
                rows = structArrIn.GetLength(0);
                columns = structArrIn.GetLength(1);
            }
            string[] fieldNames = new string[fields.Length];
            int num3 = 0;
            foreach (FieldInfo info in fields)
            {
                fieldNames[num3++] = info.Name;
            }
            MathWorks.MATLAB.NET.Arrays.MWStructArray array = new MathWorks.MATLAB.NET.Arrays.MWStructArray(rows, columns, fieldNames);
            int[] columnMajorIndices = GetColumnMajorIndices(rows, columns);
            int index = 0;
            foreach (object obj2 in structArrIn)
            {
                foreach (FieldInfo info2 in fields)
                {
                    array[info2.Name, new int[] { columnMajorIndices[index] }] = ConvertObjectToMWArray(info2.GetValue(obj2));
                }
                index++;
            }
            return array;
        }

        internal static int[] GetColumnMajorIndices(int row, int col)
        {
            int[] numArray = new int[row * col];
            int num = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    numArray[num++] = j * row + i + 1;
                }
            }
            return numArray;
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWArray GetMWArrayFromValueType(object objIn)
        {
            switch (objIn.GetType().FullName)
            {
                case "System.Double":
                    return new MWNumericArray((double) objIn);

                case "System.Single":
                    return new MWNumericArray((float) objIn, false);

                case "System.Int64":
                    return new MWNumericArray((long) objIn, false);

                case "System.Int32":
                    return new MWNumericArray((int) objIn, false);

                case "System.Int16":
                    return new MWNumericArray((short) objIn, false);

                case "System.Byte":
                    return new MWNumericArray((byte) objIn, false);

                case "System.Boolean":
                    return new MWLogicalArray((bool) objIn);

                case "System.Char":
                    return new MWCharArray((char) objIn);
            }
            throw new InvalidDataException("Data type unsupported by MATLAB Builder NE");
        }

        internal static MathWorks.MATLAB.NET.Arrays.MWArray GetMWArrayFromArrayType(Array arrIn, string arrType)
        {
            switch (arrType)
            {
                case "System.Double":
                    return new MWNumericArray(arrIn);

                case "System.Single":
                    return new MWNumericArray(arrIn, false, true);

                case "System.Int64":
                    return new MWNumericArray(arrIn, false, true);

                case "System.Int32":
                    return new MWNumericArray(arrIn, false, true);

                case "System.Int16":
                    return new MWNumericArray(arrIn, false, true);

                case "System.Byte":
                    return new MWNumericArray(arrIn, false, true);

                case "System.Boolean":
                    return new MWLogicalArray(arrIn);

                case "System.String":
                    return new MWCharArray(arrIn);

                case "System.Char":
                    return new MWCharArray(arrIn);
            }
            throw new InvalidDataException("Data type unsupported by MATLAB Builder NE for input");
        }

        internal static bool IsArrayOfSupportedType(object objIn)
        {
            Type elementType = objIn.GetType().GetElementType();
            if (elementType.IsArray) return false;
            string fullName = elementType.FullName;
            bool flag = false;
            if (!fullName.Contains("System.Double") && !fullName.Contains("System.Single") && !fullName.Contains("System.Int64") && !fullName.Contains("System.Int32") && !fullName.Contains("System.Int16") && !fullName.Contains("System.Byte") && !fullName.Contains("System.Boolean") && !fullName.Contains("System.String") && !fullName.Contains("System.Char")) return flag;
            return true;
        }

        private static bool IsCTSNumericType(Type t)
        {
            if (t != typeof(byte) && t != typeof(short) && t != typeof(int) && t != typeof(long) && t != typeof(float) && t != typeof(double)) return false;
            return true;
        }

        internal static bool IsJaggedArrayOfSupportedType(Array objIn)
        {
            if (!JaggedArray.IsJagged(objIn)) return false;
            return IsCTSNumericType(JaggedArray.GetElementType(objIn.GetType()));
        }

        internal static bool IsSupportedType(Type t)
        {
            string fullName = t.FullName;
            bool flag = false;
            if (!fullName.Contains("System.Double") && !fullName.Contains("System.Single") && !fullName.Contains("System.Int64") && !fullName.Contains("System.Int32") && !fullName.Contains("System.Int16") && !fullName.Contains("System.Byte") && !fullName.Contains("System.Boolean") && !fullName.Contains("System.String") && !fullName.Contains("System.Char")) return flag;
            return true;
        }

        internal static string ArrayElementTypeName(object objIn)
        {
            string str = "";
            string fullName = objIn.GetType().FullName;
            if (fullName.Contains("System.Double")) return "System.Double";
            if (fullName.Contains("System.Single")) return "System.Single";
            if (fullName.Contains("System.Int64")) return "System.Int64";
            if (fullName.Contains("System.Int32")) return "System.Int32";
            if (fullName.Contains("System.Int16")) return "System.Int16";
            if (fullName.Contains("System.Byte")) return "System.Byte";
            if (fullName.Contains("System.Boolean")) return "System.Boolean";
            if (fullName.Contains("System.String")) return "System.String";
            if (fullName.Contains("System.Char")) str = "System.Char";
            return str;
        }

        internal MWSafeHandle SetMXArray(MWSafeHandle hMXArray, MathWorks.MATLAB.NET.Arrays.MWArrayType arrayType, int numDimensions, int[] dimensions)
        {
            this.SetMXArray(hMXArray, arrayType, numDimensions, dimensions, false);
            return this._hMXArray;
        }

        internal MWSafeHandle SetMXArray(MWSafeHandle hMXArray, MathWorks.MATLAB.NET.Arrays.MWArrayType arrayType, int numDimensions, int[] dimensions, bool isComplex)
        {
            if (hMXArray.IsInvalid) throw new OutOfMemoryException(resourceManager.GetString("MWErrorAllocatingMXArray"));
            this._hMXArray = hMXArray;
            this.array_Type = arrayType;
            this.NumElements = 1;
            foreach (int num in dimensions)
            {
                this.NumElements *= num;
            }
            if (isComplex) this.NumElements *= 2;
            try
            {
                Monitor.Enter(mxSync);
                this.ElementSize = mxGetElementSize(this._hMXArray);
                if (nativeGCEnabled)
                {
                    long num2 = this.ElementSize * this.NumElements;
                    if (0 < num2) this._hMXArray.UnmanagedBytesAllocated = num2;
                }
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return this._hMXArray;
        }

        internal MWSafeHandle SetMXArray(MWSafeHandle hMXArray, MathWorks.MATLAB.NET.Arrays.MWArrayType arrayType)
        {
            if (hMXArray.IsInvalid) throw new OutOfMemoryException(resourceManager.GetString("MWErrorAllocatingMXArray"));
            this._hMXArray = hMXArray;
            this.array_Type = arrayType;
            try
            {
                Monitor.Enter(mxSync);
                this.NumElements = this.NumberOfElements;
                this.ElementSize = mxGetElementSize(this._hMXArray);
                if (nativeGCEnabled)
                {
                    long num = this.ElementSize * this.NumElements;
                    if (0 < num) this._hMXArray.UnmanagedBytesAllocated = num;
                }
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return this._hMXArray;
        }

        internal void CheckDisposed()
        {
            if (this.IsDisposed)
            {
                string message = resourceManager.GetString("MWErrorObjectDisposed");
                throw new ObjectDisposedException("MathWorks.MATLAB.Arrays.MWArray", message);
            }
        }

        internal void DestroyMXArray()
        {
            try
            {
                Monitor.Enter(mxSync);
                if (nativeGCEnabled)
                {
                    long bytesAllocated = this.ElementSize * this.NumElements;
                    if (this._hMXArray != null && !this._hMXArray.IsInvalid && 0 < bytesAllocated)
                    {
                        this._hMXArray.Dispose();
                        GC.RemoveMemoryPressure(bytesAllocated);
                    }
                }
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
        }

        internal MWSafeHandle DetachMXArray()
        {
            MWSafeHandle handle = this._hMXArray;
            this._hMXArray.Dispose();
            return handle;
        }

        internal MWSafeHandle ArrayIndexer(MathWorks.MATLAB.NET.Arrays.MWArray srcArray, params int[] indices)
        {
            MWSafeHandle handle2;
            try
            {
                MWSafeHandle handle;
                Monitor.Enter(mxSync);
                IntPtr[] ptrArray = new IntPtr[indices.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    ptrArray[i] = (IntPtr) indices[i];
                }
                if (mclMXArrayGet(out handle, srcArray._hMXArray, (IntPtr) indices.Length, ptrArray) != 0) throw new Exception(resourceManager.GetString("MWErrorInvalidIndex"));
                handle2 = handle;
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return handle2;
        }

        internal void ArrayIndexer(MathWorks.MATLAB.NET.Arrays.MWArray valueArray, MathWorks.MATLAB.NET.Arrays.MWArray targetArray, params int[] indices)
        {
            IntPtr[] ptrArray = new IntPtr[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                ptrArray[i] = (IntPtr) indices[i];
            }
            try
            {
                Monitor.Enter(mxSync);
                switch (targetArray.ArrayType)
                {
                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Numeric:
                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Character:
                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Cell:
                        if (mclMXArraySet(targetArray._hMXArray, valueArray._hMXArray, (IntPtr) indices.Length, ptrArray) != 0) throw new Exception(resourceManager.GetString("MWErrorInvalidIndex"));
                        return;

                    case MathWorks.MATLAB.NET.Arrays.MWArrayType.Logical:
                        if (mclMXArraySetLogical(targetArray._hMXArray, valueArray._hMXArray, (IntPtr) indices.Length, ptrArray) != 0) throw new Exception(resourceManager.GetString("MWErrorInvalidIndex"));
                        return;
                }
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
        }

        public override bool Equals(object obj)
        {
            bool flag;
            if (obj == null || !(obj is MathWorks.MATLAB.NET.Arrays.MWArray)) return false;
            if (MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray == this.array_Type) return ((MWObjectArray) this).Equals(obj);
            MathWorks.MATLAB.NET.Arrays.MWArray array = (MathWorks.MATLAB.NET.Arrays.MWArray) obj;
            this.CheckDisposed();
            array.CheckDisposed();
            try
            {
                Monitor.Enter(mxSync);
                flag = 1 == mclIsIdentical(this._hMXArray, array._hMXArray);
            }
            catch
            {
                flag = false;
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return flag;
        }

        public override int GetHashCode()
        {
            int num2;
            this.CheckDisposed();
            try
            {
                Monitor.Enter(mxSync);
                int hashCode = 0;
                num2 = ut_hash_pointer(hashCode, this.MXArrayHandle);
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return num2;
        }

        public override string ToString()
        {
            this.CheckDisposed();
            string formattedString = "[]";
            try
            {
                Monitor.Enter(mxSync);
                if (this.IsEmpty) return formattedString;
                char ch = '\n';
                char ch2 = ' ';
                if (mclcppArrayToString(this.MXArrayHandle, out formattedString) != 0) throw new ApplicationException(resourceManager.GetString("MWErrorFormatError"));
                formattedString = formattedString.TrimStart(new char[] { ch });
                formattedString = formattedString.TrimEnd(new char[] { ch });
                if (-1 == formattedString.IndexOf(ch))
                {
                    formattedString = formattedString.TrimStart(new char[] { ch2 });
                    formattedString = formattedString.TrimEnd(new char[] { ch2 });
                }
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return formattedString;
        }

        public virtual object Clone()
        {
            object obj2;
            this.CheckDisposed();
            if (MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray == this.array_Type) return ((MWObjectArray) this).Clone();
            MathWorks.MATLAB.NET.Arrays.MWArray array = (MathWorks.MATLAB.NET.Arrays.MWArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(mxSync);
                this.SetMXArray(mxDuplicateArray(this._hMXArray), MathWorks.MATLAB.NET.Arrays.MWArrayType.Array);
                obj2 = array;
            }
            finally
            {
                Monitor.Exit(mxSync);
            }
            return obj2;
        }

        public virtual Array ToArray() { throw new InvalidDataException("Data type unsupported by MATLAB Builder NE for conversion to array"); }

        internal virtual bool IsValidConversion(Type t) { throw new NotImplementedException(); }

        protected int[] GetNextSubscript(int[] dimensions, int[] subscripts, int index)
        {
            int length = dimensions.Length;
            int num2 = length - (index + 1);
            if (subscripts[num2] < dimensions[num2] - 1)
            {
                subscripts[num2]++;
                return subscripts;
            }
            subscripts[num2] = 0;
            if (num2 != 0) return this.GetNextSubscript(dimensions, subscripts, index + 1);
            return subscripts;
        }

        internal static T[] ConvertMatrixToVector<T>(T[,] src)
        {
            T[] localArray = new T[src.Length];
            int num = 0;
            int length = src.GetLength(0);
            int num3 = src.GetLength(1);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < num3; j++)
                {
                    localArray[num++] = src[i, j];
                }
            }
            return localArray;
        }

        internal static void PopulateTypeMap()
        {
            typeMap.Add(typeof(byte), new Type[] { typeof(byte), typeof(short), typeof(int), typeof(long), typeof(float), typeof(double) });
            typeMap.Add(typeof(short), new Type[] { typeof(short), typeof(int), typeof(long), typeof(float), typeof(double) });
            typeMap.Add(typeof(int), new Type[] { typeof(int), typeof(long), typeof(float), typeof(double) });
            typeMap.Add(typeof(long), new Type[] { typeof(long), typeof(float), typeof(double) });
            typeMap.Add(typeof(float), new Type[] { typeof(float), typeof(double) });
            typeMap.Add(typeof(double), new Type[] { typeof(double) });
        }

        internal virtual object ConvertToType(Type t) { throw new NotImplementedException(); }

        public static object[] ConvertToNativeTypes(MathWorks.MATLAB.NET.Arrays.MWArray[] src, Type[] specifiedTypes)
        {
            int length = src.Length;
            object[] objArray = new object[length];
            lock (mxSync)
            {
                for (int i = 0; i < length; i++)
                {
                    src[i].CheckDisposed();
                    objArray[i] = src[i].ConvertToType(specifiedTypes[i]);
                }
                return objArray;
            }
        }

        internal bool IsScalar() { return this.NumberofDimensions == 2 && this.NumberOfElements == 1; }

        internal bool IsVector()
        {
            if (this.NumberofDimensions != 2) return false;
            if (this.Dimensions[0] != 1) return this.Dimensions[1] == 1;
            return true;
        }

        internal Array AllocateNativeArray(Type t, out int[] nativeArrayDims)
        {
            lock (mxSync)
            {
                int[] dimensions = this.Dimensions;
                int length = dimensions.Length;
                nativeArrayDims = new int[length];
                nativeArrayDims[length - 2] = dimensions[0];
                nativeArrayDims[length - 1] = dimensions[1];
                for (int i = 2; i < length; i++)
                {
                    nativeArrayDims[length - (i + 1)] = dimensions[i];
                }
                return Array.CreateInstance(t, nativeArrayDims);
            }
        }

        internal static int[] NetDimensionToMATLABDimension(int[] dimensions)
        {
            int length = dimensions.Length;
            int[] numArray = new int[Math.Max(length, 2)];
            numArray[0] = (length > 1) ? dimensions[length - 2] : 1;
            numArray[1] = dimensions[length - 1];
            for (int i = 0; i < length - 2; i++)
            {
                numArray[length - i - 1] = dimensions[i];
            }
            return numArray;
        }

        internal static int[] MATLABDimensionToNetDimension(int[] dimensions)
        {
            int length = dimensions.Length;
            int[] numArray = new int[length];
            numArray[length - 2] = dimensions[0];
            numArray[length - 1] = dimensions[1];
            for (int i = 0; i < length - 2; i++)
            {
                numArray[i] = dimensions[length - i - 1];
            }
            return numArray;
        }

        internal static string RankToString(int rank)
        {
            StringBuilder builder = new StringBuilder("[", rank + 1);
            builder.Length = rank + 1;
            for (int i = 1; i < rank; i++)
            {
                builder[i] = ',';
            }
            builder[rank] = ']';
            return builder.ToString();
        }
        internal enum MATLABArrayType
        {
            Unknown,
            Cell,
            Struct,
            Logical,
            Char,
            Index,
            Double,
            Single,
            Int8,
            UInt8,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Function,
            Opaque,
            Object
        }
    }
}
