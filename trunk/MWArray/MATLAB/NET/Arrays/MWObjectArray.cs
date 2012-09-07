namespace MathWorks.MATLAB.NET.Arrays
{
    using MathWorks.MATLAB.NET.Utility;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    [Serializable]
    public class MWObjectArray : MWArray, IEquatable<MWObjectArray>
    {
        private object _object;
        private static Assembly dotnetcliAssembly = Assembly.LoadFrom(getPathToDotnetcli());
        private static MethodInfo GetMxArrayFromObjectPtr;
        private static MethodInfo GetObjectFromMxArrayPtr;
        private static Type SafeNETCliConversions;

        static MWObjectArray()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MWObjectArray.DotnetcliResolveEventHandler);
            SafeNETCliConversions = dotnetcliAssembly.GetType("dotnetcli.DeployedDataConversion");
            GetMxArrayFromObjectPtr = SafeNETCliConversions.GetMethod("GetMxArrayFromObject", BindingFlags.Public | BindingFlags.Static);
            GetObjectFromMxArrayPtr = SafeNETCliConversions.GetMethod("GetObjectFromMxArray", BindingFlags.Public | BindingFlags.Static);
        }

        public MWObjectArray()
        {
            this._object = new object();
            base.array_Type = MWArrayType.NativeObjArray;
        }

        internal MWObjectArray(MWSafeHandle hMXArray)
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Monitor.Enter(MWArray.mxSync);
                IntPtr handle = hMXArray.DangerousGetHandle();
                this._object = GetObjectFromMxArrayPtr.Invoke(null, new object[] { handle });
                base.array_Type = MWArrayType.NativeObjArray;
            }
            finally
            {
                Monitor.Exit(MWArray.mxSync);
            }
        }

        public MWObjectArray(object obj)
        {
            if (obj == null)
            {
                string message = MWArray.resourceManager.GetString("MWErrorInvalidNullArgument");
                throw new ArgumentNullException("obj", message);
            }
            this._object = obj;
            base.array_Type = MWArrayType.NativeObjArray;
        }

        protected MWObjectArray(SerializationInfo serializationInfo, StreamingContext context)
        {
            this._object = new object();
            this._object = serializationInfo.GetValue("nativeObject", this._object.GetType());
            base.array_Type = MWArrayType.NativeObjArray;
        }

        public override object Clone()
        {
            base.CheckDisposed();
            MWObjectArray array = (MWObjectArray) base.MemberwiseClone();
            if (!this._object.GetType().IsValueType)
            {
                ICloneable cloneable = this._object as ICloneable;
                if (cloneable != null) array.Object = cloneable.Clone();
            }
            return array;
        }

        internal override object ConvertToType(Type t)
        {
            if (t == this.Object.GetType() || t.IsAssignableFrom(this.Object.GetType())) return this.Object;
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
            string str2 = "Cannot convert from MWObjectArray containing object of type " + this.Object.GetType().FullName + " to " + t.FullName;
            throw new ArgumentException(message, new ApplicationException(str2));
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
            }
            finally
            {
                this._object = null;
            }
        }

        private static Assembly DotnetcliResolveEventHandler(object sender, ResolveEventArgs args) { return dotnetcliAssembly; }

        public bool Equals(MWObjectArray obj)
        {
            if (obj == null) return false;
            return object.ReferenceEquals(this._object, obj._object);
        }

        public override bool Equals(object obj) { return (obj is MWObjectArray) && this.Equals(obj as MWObjectArray); }

        public override int GetHashCode() { return base.GetHashCode(); }

        private static string getMatlabRootForAssembly()
        {
            string str3 = "mclmcrrt7_17.dll";
            string[] strArray = Environment.GetEnvironmentVariable("path").Split(new char[] { ';' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string path = Path.Combine(strArray[i], str3);
                string str = PlatformInfo.getArchDir();
                if (File.Exists(path) && path.Contains(Path.Combine("runtime", str))) return path.Substring(0, path.LastIndexOf("runtime"));
            }
            return "";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (!(this._object is ISerializable)) throw new InvalidCastException(MWArray.resourceManager.GetString("MWNotSerializeable"));
            info.AddValue("nativeObject", this._object, this._object.GetType());
        }

        private static string getPathToDotnetcli()
        {
            string str3 = getMatlabRootForAssembly();
            if (str3.Length <= 0) throw new Exception("Failed to find mclmcrrt7_17.dll required to load dotnetcli on system path : \n" + Environment.GetEnvironmentVariable("path"));
            string str = PlatformInfo.getArchDir();
            return Path.Combine(Path.Combine(str3, Path.Combine("bin", str)), "dotnetcli.dll");
        }

        public static bool operator ==(MWObjectArray objectArrayA, MWObjectArray objectArrayB)
        {
            if (objectArrayA == null) return objectArrayB == null;
            return objectArrayA.Equals(objectArrayB);
        }

        public static bool operator !=(MWObjectArray objectArrayA, MWObjectArray objectArrayB)
        {
            if (objectArrayA == null) return objectArrayB != null;
            return !objectArrayA.Equals(objectArrayB);
        }

        public override string ToString()
        {
            base.CheckDisposed();
            string str = this._object.ToString();
            char ch = '\n';
            char ch2 = ' ';
            str = str.TrimStart(new char[] { ch }).TrimEnd(new char[] { ch });
            if (-1 == str.IndexOf(ch)) str = str.TrimStart(new char[] { ch2 }).TrimEnd(new char[] { ch2 });
            return str;
        }

        public static MWObjectArray Empty { get { return new MWObjectArray(); } }

        public override bool IsDisposed { get { return null == this._object; } }

        public override bool IsEmpty
        {
            get
            {
                base.CheckDisposed();
                return Empty == this;
            }
        }

        public object this[int[] indices]
        {
            get
            {
                if (2 < indices.Length) throw new ArgumentOutOfRangeException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                foreach (int num in indices)
                {
                    if (1 != num) throw new ArgumentOutOfRangeException(MWArray.resourceManager.GetString("MWErrorInvalidIndex"));
                }
                return this._object;
            }
            set
            {
                if (2 < indices.Length) throw new ArgumentOutOfRangeException(MWArray.resourceManager.GetString("MWErrorInvalidDimensions"));
                foreach (int num in indices)
                {
                    if (1 != num) throw new ArgumentOutOfRangeException(MWArray.resourceManager.GetString("MWErrorInvalidIndex"));
                }
                this._object = value;
            }
        }

        internal override MWSafeHandle MXArrayHandle
        {
            get
            {
                MWSafeHandle handle;
                try
                {
                    Monitor.Enter(MWArray.mxSync);
                    handle = new MWSafeHandle((IntPtr) GetMxArrayFromObjectPtr.Invoke(null, new object[] { this._object }), false);
                }
                finally
                {
                    Monitor.Exit(MWArray.mxSync);
                }
                return handle;
            }
        }

        public object Object { get { return this._object; } set { this._object = value; } }
    }
}
