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
    public class MWStructArray : MWArray, IEquatable<MWStructArray>
    {
        private static readonly MWStructArray _Empty = new MWStructArray();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxAddField_proxy")]
        internal static extern int mxAddField([In] MWSafeHandle hMXArray, [In] string fieldName);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclCreateSharedCopy_proxy")]
        internal static extern IntPtr mclCreateSharedCopy([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCalcSingleSubscript_700_proxy")]
        internal static extern int mxCalcSingleSubscript([In] MWSafeHandle hMXArray, [In] int numSubscripts, [In] int[] subscripts);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxCreateStructArray_700_proxy")]
        internal static extern MWSafeHandle mxCreateStructArray([In] int numDimensions, [In] int[] dimensions, [In] int numFields, [In] string[] fieldNames);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetField_700_proxy")]
        internal static extern IntPtr mxGetField([In] MWSafeHandle hMXArray, [In] int index, [In] string fieldName);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetFieldNameByNumber_proxy")]
        internal static extern IntPtr mxGetFieldNameByNumber([In] MWSafeHandle hMXArray, [In] int fieldNumber);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetFieldNumber_proxy")]
        internal static extern int mxGetFieldNumber([In] MWSafeHandle hMXArray, [In] string fieldName);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxGetNumberOfFields_proxy")]
        internal static extern int mxGetNumberOfFields([In] MWSafeHandle hMXArray);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxRemoveField_proxy")]
        internal static extern void mxRemoveField([In] MWSafeHandle hMXArray, [In] int fieldNumber);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxSetField_700_proxy")]
        internal static extern void mxSetField([In] MWSafeHandle hMXArray, [In] int index, [In] string fieldName, [In] MWSafeHandle fieldValue);
        public MWStructArray()
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[2];
                base.SetMXArray(mxCreateStructArray(0, null, 0, null), MWArrayType.Structure, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWStructArray(int rows, int columns, string[] fieldNames)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int[] dimensions = new int[] { rows, columns };
                base.SetMXArray(mxCreateStructArray(dimensions.Length, dimensions, fieldNames.Length, fieldNames), MWArrayType.Structure, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWStructArray(int[] dimensions, string[] fieldNames)
        {
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateStructArray(dimensions.Length, dimensions, fieldNames.Length, fieldNames), MWArrayType.Structure, dimensions.Length, dimensions);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWStructArray(params MWArray[] fieldDefs)
        {
            int length = fieldDefs.Length;
            if (length % 2 != 0) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorNotNameValuePair"), "fieldDefs");
            length /= 2;
            string[] fieldNames = new string[length];
            MWArray[] arrayArray = new MWArray[length];
            for (int i = 0; i < length; i++)
            {
                int index = i * 2;
                fieldNames[i] = ((MWCharArray) fieldDefs[index]).ToString();
                arrayArray[i] = fieldDefs[index + 1];
            }
            try
            {
                Monitor.Enter(MWArray.mxSync);
                base.SetMXArray(mxCreateStructArray(1, new int[] { 1 }, fieldNames.Length, fieldNames), MWArrayType.Structure, 1, new int[] { 1 });
                for (int j = 0; j < length; j++)
                {
                    this.SetField(fieldNames[j], arrayArray[j]);
                }
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        internal MWStructArray(MWSafeHandle hMXArray) : base(hMXArray)
        {
            base.array_Type = MWArrayType.Structure;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public MWArray this[string fieldName, int[] indices]
        {
            get
            {
                MWArray empty;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    int[] subscripts = new int[indices.Length];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        subscripts[i] = indices[i] - 1;
                    }
                    int index = mxCalcSingleSubscript(this.MXArrayHandle, subscripts.Length, subscripts);
                    if (index >= MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                    MWSafeHandle hMXArray = new MWSafeHandle(mxGetField(this.MXArrayHandle, index, fieldName), false);
                    if (!hMXArray.IsInvalid)
                    {
                        MWSafeHandle handle2 = new MWSafeHandle(mclCreateSharedCopy(hMXArray), true);
                        return MWArray.GetTypedArray(handle2);
                    }
                    if (!this.IsField(fieldName)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorFieldNotFound"));
                    if (1 == indices.Length)
                    {
                        if (indices[0] < 0 || indices[0] > MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                    }
                    else
                    {
                        int[] dimensions = this.Dimensions;
                        if (dimensions.Length != indices.Length) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                        for (int j = 0; j < indices.Length; j++)
                        {
                            if (indices[j] > dimensions[j]) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                        }
                    }
                    empty = MWNumericArray.Empty;
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return empty;
            }
            set
            {
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    int[] subscripts = new int[indices.Length];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        subscripts[i] = indices[i] - 1;
                    }
                    int index = mxCalcSingleSubscript(this.MXArrayHandle, subscripts.Length, subscripts);
                    if (index >= MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                    new MWSafeHandle(mxGetField(this.MXArrayHandle, index, fieldName), true);
                    MWSafeHandle fieldValue = new MWSafeHandle(mclCreateSharedCopy(value.MXArrayHandle), false);
                    mxSetField(this.MXArrayHandle, index, fieldName, fieldValue);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
            }
        }
        public MWArray this[string fieldName] { get { return this.GetField(fieldName); } set { this.SetField(fieldName, value); } }
        protected MWStructArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) {  }

        public static MWStructArray Empty { get { return (MWStructArray) _Empty.Clone(); } }
        public string[] FieldNames
        {
            get
            {
                string[] strArray2;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    int num = mxGetNumberOfFields(this.MXArrayHandle);
                    string[] strArray = new string[num];
                    for (int i = 0; i < num; i++)
                    {
                        IntPtr ptr = mxGetFieldNameByNumber(this.MXArrayHandle, i);
                        strArray[i] = Marshal.PtrToStringAnsi(ptr);
                    }
                    strArray2 = strArray;
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return strArray2;
            }
        }
        public int NumberOfFields
        {
            get
            {
                int num;
                base.CheckDisposed();
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    num = mxGetNumberOfFields(this.MXArrayHandle);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return num;
            }
        }
        public override string ToString() { return base.ToString(); }

        public override object Clone()
        {
            object obj2;
            MWStructArray array = (MWStructArray) base.MemberwiseClone();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                array.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Structure);
                obj2 = array;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return obj2;
        }

        public override bool Equals(object obj) { return (obj is MWStructArray) && this.Equals(obj as MWStructArray); }

        public bool Equals(MWStructArray other) { return base.Equals(other); }

        public override int GetHashCode() { return base.GetHashCode(); }

        public MWArray GetField(string fieldName, int index)
        {
            MWArray empty;
            base.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                if (index >= MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                MWSafeHandle hMXArray = new MWSafeHandle(mxGetField(this.MXArrayHandle, index, fieldName), false);
                if (!hMXArray.IsInvalid)
                {
                    MWSafeHandle handle2 = new MWSafeHandle(mclCreateSharedCopy(hMXArray), true);
                    return MWArray.GetTypedArray(handle2);
                }
                if (!this.IsField(fieldName)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorFieldNotFound"));
                if (index < 0 || index > MWArray.mxGetNumberOfElements(this.MXArrayHandle)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                empty = MWNumericArray.Empty;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return empty;
        }

        public MWArray GetField(string fieldName) { return this.GetField(fieldName, 0); }

        public bool IsField(string fieldName)
        {
            bool flag;
            base.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                flag = -1 != mxGetFieldNumber(this.MXArrayHandle, fieldName);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return flag;
        }

        public MWStructArray RemoveField(string fieldName)
        {
            MWStructArray array;
            base.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                int fieldNumber = mxGetFieldNumber(this.MXArrayHandle, fieldName);
                if (-1 == fieldNumber) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorFieldNotFound"), fieldName);
                int num2 = MWArray.mxGetNumberOfElements(this.MXArrayHandle);
                for (int i = 0; i < num2; i++)
                {
                    new MWSafeHandle(mxGetField(this.MXArrayHandle, i, fieldName), true);
                }
                mxRemoveField(this.MXArrayHandle, fieldNumber);
                array = this;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
            return array;
        }

        public void SetField(string fieldName, MWArray fieldValue)
        {
            base.CheckDisposed();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                if (!this.IsField(fieldName) && -1 == mxAddField(this.MXArrayHandle, fieldName)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorBadFieldName"), fieldName);
                new MWSafeHandle(mxGetField(this.MXArrayHandle, 0, fieldName), true);
                MWSafeHandle handle = new MWSafeHandle(mclCreateSharedCopy(fieldValue.MXArrayHandle), false);
                mxSetField(this.MXArrayHandle, 0, fieldName, handle);
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
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
                int num2 = dimensions.Length + 1;
                int[] lengths = new int[num2];
                int[] indices = new int[num2];
                int num3 = lengths[num2 - 2] = dimensions[0];
                int num4 = lengths[num2 - 1] = dimensions[1];
                int num5 = lengths[0] = this.FieldNames.Length;
                for (int i = 2; i < num2 - 1; i++)
                {
                    lengths[num2 - (i + 1)] = dimensions[i];
                }
                Array array = Array.CreateInstance(typeof(object), lengths);
                for (int j = 0; j < num5; j++)
                {
                    for (int k = 0; k < numberOfElements; k += num3 * num4)
                    {
                        for (int m = 0; m < num3; m++)
                        {
                            for (int n = 0; n < num4; n++)
                            {
                                array.SetValue(this.GetField(this.FieldNames[j], n * num3 + m + k).ToArray(), indices);
                                indices = base.GetNextSubscript(lengths, indices, 0);
                            }
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

        internal override object ConvertToType(Type t)
        {
            if (t == typeof(MWArray) || t == typeof(MWStructArray)) return this;
            if (t == typeof(Hashtable) && base.IsScalar()) return this.GetHashtable();
            if (t.IsValueType && !t.IsPrimitive && base.IsScalar()) return this.GetNetScalarStruct(t);
            if (t.IsArray && t.GetArrayRank() == 2 && !t.GetElementType().IsPrimitive && base.NumberofDimensions == 2) return this.GetNetStructMatrix(t);
            if (t.IsArray && t.GetArrayRank() == 1 && !t.GetElementType().IsPrimitive && base.IsVector()) return this.GetNetStructVector(t);
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWStructArray to " + t.FullName;
            throw new ArgumentException(message, new ApplicationException(str2));
        }

        private object GetHashtable()
        {
            Hashtable hashtable = new Hashtable();
            foreach (string str in this.FieldNames)
            {
                MWArray field = this.GetField(str);
                if (field.IsStructArray)
                    hashtable[str] = field.ConvertToType(typeof(Hashtable));
                else if (field.IsCellArray)
                    hashtable[str] = field.ConvertToType(typeof(Array));
                else
                    hashtable[str] = field.ToArray();
            }
            return hashtable;
        }

        private object GetNetScalarStruct(Type t)
        {
            FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            this.ValidateConversion(t, fields);
            object obj2 = Activator.CreateInstance(t);
            foreach (FieldInfo info in fields)
            {
                info.SetValue(obj2, this[info.Name].ConvertToType(info.FieldType));
            }
            return obj2;
        }

        private object GetNetStructMatrix(Type t)
        {
            FieldInfo[] fields = t.GetElementType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            this.ValidateConversion(t.GetElementType(), fields);
            int[] dimensions = this.Dimensions;
            int[] columnMajorIndices = MWArray.GetColumnMajorIndices(dimensions[0], dimensions[1]);
            Array array = Array.CreateInstance(t.GetElementType(), dimensions[0], dimensions[1]);
            int index = 0;
            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    object obj2 = Activator.CreateInstance(t.GetElementType());
                    foreach (FieldInfo info in fields)
                    {
                        info.SetValue(obj2, this[info.Name, new int[] { columnMajorIndices[index] }].ConvertToType(info.FieldType));
                    }
                    array.SetValue(obj2, i, j);
                    index++;
                }
            }
            return array;
        }

        private object GetNetStructVector(Type t)
        {
            FieldInfo[] fields = t.GetElementType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            this.ValidateConversion(t.GetElementType(), fields);
            int numberOfElements = base.NumberOfElements;
            Array array = Array.CreateInstance(t.GetElementType(), numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                object obj2 = Activator.CreateInstance(t.GetElementType());
                foreach (FieldInfo info in fields)
                {
                    info.SetValue(obj2, this[info.Name, new int[] { i + 1 }].ConvertToType(info.FieldType));
                }
                array.SetValue(obj2, i);
            }
            return array;
        }

        private void ValidateConversion(Type t, FieldInfo[] netFields)
        {
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWStructArray to " + t.FullName + ".\n";
            string[] fieldNames = this.FieldNames;
            if (fieldNames.Length != netFields.Length) throw new ArgumentException(message, new ApplicationException(str2 + "Provided type does not have the same number of fields as the returned MATLAB struct."));
            int length = fieldNames.Length;
            string[] array = new string[length];
            int num2 = 0;
            foreach (FieldInfo info in netFields)
            {
                array[num2++] = info.Name;
            }
            Array.Sort<string>(fieldNames);
            Array.Sort<string>(array);
            for (int i = 0; i < length; i++)
            {
                if (fieldNames[i] != array[i]) throw new ArgumentException(message, new ApplicationException(str2 + "Provided type does not have the same fields as the returned MATLAB struct."));
            }
        }
    }
}
