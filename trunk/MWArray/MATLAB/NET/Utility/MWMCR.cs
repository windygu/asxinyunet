namespace MathWorks.MATLAB.NET.Utility
{
    using MathWorks.MATLAB.NET.Arrays;
    using MathWorks.MATLAB.NET.Arrays.native;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;

    public class MWMCR : IDisposable
    {
        private static CallBackDelegate _ErrDelegate = new CallBackDelegate(MWMCR.writeToErr);
        private static CallBackDelegate _OutDelegate = new CallBackDelegate(MWMCR.writeToOut);
        private static MathWorks.MATLAB.NET.Arrays.MWArray[] argsOut;
        private static bool callOncePerAppDomain = false;
        private bool disposed;
        private static GCHandle gchErr;
        private static GCHandle gchOut;
        private static int maxArgsIn = 10;
        private static int maxArgsOut = 5;
        public static bool MCRAppInitialized = false;
        private IntPtr mcrInstance;
        private static Queue mcrInstances = new Queue();
        private static ResourceManager mcrResourceManager = null;
        private static IntPtr[] plhs = new IntPtr[maxArgsOut];
        private static IntPtr[] prhs = new IntPtr[maxArgsIn];

        static MWMCR()
        {
            mcrResourceManager = MWResources.getResourceManager();
            gchOut = GCHandle.Alloc(_OutDelegate);
            gchErr = GCHandle.Alloc(_ErrDelegate);
            if (!AppDomain.CurrentDomain.IsDefaultAppDomain()) AppDomain.CurrentDomain.DomainUnload += new EventHandler(MWMCR.unloadAppDomain);
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                if (!MCRAppInitialized)
                {
                    if (!mclmcrInitialize2(1)) throw new Exception("Trouble initializing libraries required by Builder NE.\n");
                    if (!mclIsMCRInitialized())
                    {
                        ArrayList list = new ArrayList();
                        string[] startupOptions = new string[0];
                        Assembly entryAssembly = Assembly.GetEntryAssembly();
                        if (entryAssembly != null)
                        {
                            NOJVMAttribute customAttribute = (NOJVMAttribute) Attribute.GetCustomAttribute(entryAssembly, typeof(NOJVMAttribute));
                            if (customAttribute != null && customAttribute.JVMDisabled) list.Add("-nojvm");
                            LOGFILEAttribute attribute2 = (LOGFILEAttribute) Attribute.GetCustomAttribute(entryAssembly, typeof(LOGFILEAttribute));
                            if (attribute2 != null)
                            {
                                list.Add("-logfile");
                                list.Add(attribute2.LogfileName);
                            }
                            MWMCROptionAttribute[] customAttributes = (MWMCROptionAttribute[]) Attribute.GetCustomAttributes(entryAssembly, typeof(MWMCROptionAttribute));
                            if (customAttributes.Length != 0)
                            {
                                foreach (MWMCROptionAttribute attribute3 in customAttributes)
                                {
                                    list.Add(attribute3.MWMCROption);
                                }
                            }
                            startupOptions = (string[]) list.ToArray(typeof(string));
                        }
                        InitializeApplication(startupOptions);
                    }
                    MCRAppInitialized = true;
                }
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
        }

        public MWMCR(string componentName, string componentPath, bool isLibrary)
        {
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                string path = componentPath + @"\" + componentName + ".ctf";
                if (componentName == null || componentPath == null || !File.Exists(path)) throw new FileNotFoundException(mcrResourceManager.GetString("MWErrorCTFFileNotFound"), path);
                IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_OutDelegate);
                IntPtr errorHandler = Marshal.GetFunctionPointerForDelegate(_ErrDelegate);
                int targetType = mclGetMCCTargetType(isLibrary ? ((byte) 1) : ((byte) 0));
                if (!mclInitializeComponentInstanceNonEmbeddedStandalone(out this.mcrInstance, componentPath, componentName, targetType, errorHandler, functionPointerForDelegate)) throw new ApplicationException(mcrResourceManager.GetString("MWErrorMCRInitialize") + "\n" + LastErrorMessage);
                mcrInstances.Enqueue(this);
            }
            catch (Exception exception)
            {
                throw new Exception(mcrResourceManager.GetString("MWErrorMCRInitialize"), exception);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            this.setBuilderUserData();
        }

        public MWMCR(string componentId, string componentPath, Stream embeddedCtfStream, bool isLibrary)
        {
            GCHandle handle;
            if (embeddedCtfStream == null) throw new ApplicationException(mcrResourceManager.GetString("MWErrorCTFNotEmbedded"));
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_OutDelegate);
                IntPtr errorHandler = Marshal.GetFunctionPointerForDelegate(_ErrDelegate);
                mclGetMCCTargetType(isLibrary ? ((byte) 1) : ((byte) 0));
                MWCTFStreamReader reader = new MWCTFStreamReader(embeddedCtfStream);
                handle = GCHandle.Alloc(reader);
                bool flag = mclInitializeComponentInstanceWithCallbk(out this.mcrInstance, errorHandler, functionPointerForDelegate, reader.CtfStreamReadFcn, embeddedCtfStream.Length);
                mcrInstances.Enqueue(this);
                if (!flag) throw new ApplicationException(mcrResourceManager.GetString("MWErrorMCRInitialize") + "\n" + LastErrorMessage);
            }
            catch (Exception exception)
            {
                throw new Exception(mcrResourceManager.GetString("MWErrorMCRInitialize"), exception);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            this.setBuilderUserData();
            try
            {
                handle.Free();
            }
            catch
            {
            }
        }

        private string combineErrorMessages(string mlError, string[] mlStack)
        {
            string str = mlError + "\n\n";
            if (mlStack == null) return str;
            str = str + "... Matlab M-code Stack Trace ...\n";
            foreach (string str2 in mlStack)
            {
                str = (str + "    at\n") + str2 + "\n";
            }
            return (str + "\n");
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                    this.disposed = true;
                    if (MCRAppInitialized && IntPtr.Zero != this.mcrInstance)
                    {
                        if (!mclTerminateInstance(ref this.mcrInstance)) throw new Exception(mcrResourceManager.GetString("MWErrorMCRTermination") + "\n" + LastErrorMessage);
                        this.mcrInstance = IntPtr.Zero;
                    }
                }
                finally
                {
                    Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                }
            }
        }

        public MathWorks.MATLAB.NET.Arrays.MWArray EvaluateFunction(string functionName, params MathWorks.MATLAB.NET.Arrays.MWArray[] argsIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray array;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                int numArgsIn = (argsIn == null) ? 0 : argsIn.Length;
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = this.EvaluateFunction(functionName, 1, numArgsIn, argsIn);
                array = (arrayArray != null) ? arrayArray[0] : null;
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return array;
        }

        public object EvaluateFunction(string functionName, params object[] argsIn)
        {
            object obj3;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = this.UnpackArgArray(argsIn);
                int numArgsIn = (arrayArray == null) ? 0 : arrayArray.Length;
                MathWorks.MATLAB.NET.Arrays.MWArray array = this.EvaluateFunction(functionName, 1, numArgsIn, arrayArray)[0];
                object obj2 = null;
                if (array != null) obj2 = this.marshalMWArrayToObject(array);
                obj3 = obj2;
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return obj3;
        }

        public MathWorks.MATLAB.NET.Arrays.MWArray[] EvaluateFunction(int numArgsOut, string functionName, params MathWorks.MATLAB.NET.Arrays.MWArray[] argsIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                int numArgsIn = (argsIn != null) ? argsIn.Length : 0;
                arrayArray = this.EvaluateFunction(functionName, numArgsOut, numArgsIn, argsIn);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return arrayArray;
        }

        public object[] EvaluateFunction(int numArgsOut, string functionName, params object[] argsIn)
        {
            object[] objArray2;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = this.UnpackArgArray(argsIn);
                int numArgsIn = (arrayArray == null) ? 0 : arrayArray.Length;
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray2 = this.EvaluateFunction(functionName, numArgsOut, numArgsIn, arrayArray);
                object[] objArray = new object[numArgsOut];
                for (int i = 0; i < numArgsOut; i++)
                {
                    objArray[i] = this.marshalMWArrayToObject(arrayArray2[i]);
                }
                objArray2 = objArray;
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return objArray2;
        }

        public MathWorks.MATLAB.NET.Arrays.MWArray[] EvaluateFunction(string functionName, int numArgsOut, MathWorks.MATLAB.NET.Arrays.MWArray[] argsIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                int numArgsIn = (argsIn != null) ? argsIn.Length : 0;
                arrayArray = this.EvaluateFunction(functionName, numArgsOut, numArgsIn, argsIn);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return arrayArray;
        }

        private MathWorks.MATLAB.NET.Arrays.MWArray[] EvaluateFunction(string functionName, int numArgsOut, int numArgsIn, MathWorks.MATLAB.NET.Arrays.MWArray[] argsIn)
        {
            MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray;
            if (numArgsOut < 0)
            {
                string message = mcrResourceManager.GetString("MWErrorNegativeArg");
                throw new ArgumentOutOfRangeException("numArgsOut", message);
            }
            if (numArgsIn < 0)
            {
                string str2 = mcrResourceManager.GetString("MWErrorNegativeArg");
                throw new ArgumentOutOfRangeException("numArgsIn", str2);
            }
            if (argsIn == null)
            {
                if (numArgsIn != 0)
                {
                    string str3 = mcrResourceManager.GetString("MWErrorEvalFunctionArg");
                    throw new ArgumentOutOfRangeException("argsIn", str3);
                }
            }
            else
            {
                MathWorks.MATLAB.NET.Arrays.MWArray.formattedOutputString = new StringBuilder(0x400);
                if (numArgsIn > argsIn.Length)
                {
                    string str4 = mcrResourceManager.GetString("MWErrorEvalFunctionArg");
                    throw new ArgumentOutOfRangeException("argsIn", str4);
                }
                foreach (MathWorks.MATLAB.NET.Arrays.MWArray array in argsIn)
                {
                    if (array == null) throw new ArgumentNullException(mcrResourceManager.GetString("MWErrorInvalidNullArgument"), new Exception());
                    array.CheckDisposed();
                }
            }
            if (numArgsIn > maxArgsIn)
            {
                maxArgsIn = numArgsIn;
                MWMCR.prhs = new IntPtr[maxArgsIn];
            }
            IntPtr[] ptrArray = new IntPtr[numArgsIn];
            if (numArgsOut > maxArgsOut)
            {
                maxArgsOut = numArgsOut;
                plhs = new IntPtr[maxArgsOut];
            }
            IntPtr zero = IntPtr.Zero;
            int length = 0;
            byte num2 = 1;
            WindowsIdentity current = WindowsIdentity.GetCurrent(true);
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                for (int i = 0; i < numArgsIn; i++)
                {
                    if (argsIn[i].ArrayType == MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray && !callOncePerAppDomain)
                    {
                        callOncePerAppDomain = true;
                        MWCharArray array2 = new MWCharArray("x=System.String('');clear x");
                        IntPtr[] prhs = new IntPtr[] { array2.MXArrayHandle.DangerousGetHandle() };
                        mclFeval(this.mcrInstance, "eval", 0, null, 1, prhs);
                    }
                    MWMCR.prhs[i] = argsIn[i].MXArrayHandle.DangerousGetHandle();
                    if (argsIn[i].ArrayType == MathWorks.MATLAB.NET.Arrays.MWArrayType.NativeObjArray) ptrArray[i] = MWMCR.prhs[i];
                }
                if (current == null)
                    num2 = mclFeval(this.mcrInstance, functionName, numArgsOut, plhs, numArgsIn, MWMCR.prhs);
                else
                    num2 = mclImpersonationFeval(this.mcrInstance, functionName, numArgsOut, plhs, numArgsIn, MWMCR.prhs, current.Token);
                if (num2 != 0)
                {
                    argsOut = new MathWorks.MATLAB.NET.Arrays.MWArray[numArgsOut];
                    for (int j = 0; j < numArgsOut; j++)
                    {
                        argsOut[j] = MathWorks.MATLAB.NET.Arrays.MWArray.GetTypedArray(new MWSafeHandle(plhs[j]));
                    }
                    return argsOut;
                }
                arrayArray = null;
            }
            finally
            {
                foreach (IntPtr ptr2 in ptrArray)
                {
                    if (ptr2 != IntPtr.Zero) mclMxDestroyArray(ptr2, true);
                }
                if (current != null) stopImpersonationOnMCRThread();
                if (num2 == 0)
                {
                    string lastErrorMessage = LastErrorMessage;
                    lastErrorMessage = (string.Empty == lastErrorMessage) ? "segv - SEVERE ERROR" : lastErrorMessage;
                    string mlError = "\n\n... MWMCR::EvaluateFunction error ... \n" + lastErrorMessage + ".";
                    string[] mlStack = null;
                    length = mclGetStackTrace(ref zero);
                    if (length > 0 && zero != IntPtr.Zero)
                    {
                        IntPtr[] destination = new IntPtr[length];
                        Marshal.Copy(zero, destination, 0, length);
                        mlStack = new string[length];
                        for (int k = 0; k < length; k++)
                        {
                            mlStack[k] = Marshal.PtrToStringAnsi(destination[k]);
                        }
                        mclFreeStackTrace(ref zero, length);
                    }
                    throw new Exception(this.combineErrorMessages(mlError, mlStack));
                }
            }
            return arrayArray;
        }

        public void EvaluateFunction(string functionName, int numArgsOut, ref MathWorks.MATLAB.NET.Arrays.MWArray[] argsOut, MathWorks.MATLAB.NET.Arrays.MWArray[] argsIn)
        {
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                int numArgsIn = (argsIn == null) ? 0 : argsIn.Length;
                argsOut = this.EvaluateFunction(functionName, numArgsOut, numArgsIn, argsIn);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
        }

        public void EvaluateFunctionForTypeSafeCall(string functionName, int numArgsOut, ref object[] argsOut, object[] argsIn, params object[] varArgsIn)
        {
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = this.UnpackArgArray(argsIn, varArgsIn);
                int numArgsIn = (arrayArray == null) ? 0 : arrayArray.Length;
                MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray2 = this.EvaluateFunction(functionName, numArgsOut, numArgsIn, arrayArray);
                argsOut = new object[numArgsOut];
                for (int i = 0; i < numArgsOut; i++)
                {
                    argsOut[i] = arrayArray2[i];
                }
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
        }

        ~MWMCR() { this.Dispose(false); }

        public static string GetMCRLogFileName() { return Marshal.PtrToStringAnsi(mclGetLogFileName()); }

        public static bool InitializeApplication(params string[] startupOptions)
        {
            bool flag;
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                if (IsMCRInitialized())
                {
                    string str = "MWMCR.InitializeApplication should be called before initializing a Builder NE component.\n";
                    throw new Exception((((str + "MCR is already initialized with following options:\n") + "JVM enabled : " + IsMCRJVMEnabled()) + "\nLogfile name : " + "\"") + GetMCRLogFileName() + "\"");
                }
                if (mclInitializeApplication(startupOptions, new IntPtr(startupOptions.Length)))
                    flag = true;
                else
                {
                    string str2 = "The MCR instance could not be initialized";
                    string lastErrorMessage = LastErrorMessage;
                    throw new Exception(str2 + "\n" + lastErrorMessage);
                }
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
            return flag;
        }

        public static bool IsMCRInitialized() { return mclIsMCRInitialized(); }

        public static bool IsMCRJVMEnabled() { return mclIsJVMEnabled(); }

        private object marshalMWArrayToObject(MathWorks.MATLAB.NET.Arrays.MWArray in_arg)
        {
            switch (in_arg.ArrayType)
            {
                case MathWorks.MATLAB.NET.Arrays.MWArrayType.Cell:
                {
                    MathWorks.MATLAB.NET.Arrays.MWCellArray array4 = (MathWorks.MATLAB.NET.Arrays.MWCellArray) in_arg;
                    MathWorks.MATLAB.NET.Arrays.native.MWCellArray array5 = new MathWorks.MATLAB.NET.Arrays.native.MWCellArray(array4.Dimensions);
                    for (int i = 1; i <= array4.NumberOfElements; i++)
                    {
                        MathWorks.MATLAB.NET.Arrays.MWArray array6 = array4[new int[] { i }];
                        if (array6 != null)
                        {
                            object obj4 = this.marshalMWArrayToObject(array6);
                            array5[new int[] { i }] = obj4;
                        }
                    }
                    return array5;
                }
                case MathWorks.MATLAB.NET.Arrays.MWArrayType.Structure:
                {
                    MathWorks.MATLAB.NET.Arrays.MWStructArray array = (MathWorks.MATLAB.NET.Arrays.MWStructArray) in_arg;
                    MathWorks.MATLAB.NET.Arrays.native.MWStructArray array2 = new MathWorks.MATLAB.NET.Arrays.native.MWStructArray(array.Dimensions, array.FieldNames);
                    for (int j = 1; j <= array.NumberOfElements; j++)
                    {
                        for (int k = 0; k < array.NumberOfFields; k++)
                        {
                            MathWorks.MATLAB.NET.Arrays.MWArray array3 = array[array.FieldNames[k], new int[] { j }];
                            if (array3 != null)
                            {
                                object obj3 = this.marshalMWArrayToObject(array3);
                                array2[array.FieldNames[k], new int[] { j }] = obj3;
                            }
                        }
                    }
                    return array2;
                }
            }
            return in_arg.ToArray();
        }

        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclFeval_proxy")]
        private static extern byte mclFeval([In] IntPtr pMCR, [In] string functionName, [In] int nlhs, [In] IntPtr[] plhs, [In] int nrhs, [In] IntPtr[] prhs);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclFreeStackTrace_proxy")]
        private static extern bool mclFreeStackTrace(ref IntPtr stack, int nStackDepth);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetDotNetComponentType_proxy")]
        private static extern int mclGetDotNetComponentType();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetLastErrorMessage_proxy")]
        private static extern IntPtr mclGetLastErrorMessage();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetLogFileName_proxy")]
        private static extern IntPtr mclGetLogFileName();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetMCCTargetType_proxy")]
        private static extern int mclGetMCCTargetType(byte isLibrary);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetStackTrace_proxy")]
        private static extern int mclGetStackTrace(ref IntPtr stack);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclGetTempFileName_proxy")]
        private static extern IntPtr mclGetTempFileName([In] string tempFileName);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclImpersonationFeval_proxy")]
        private static extern byte mclImpersonationFeval([In] IntPtr pMCR, [In] string functionName, [In] int nlhs, [In] IntPtr[] plhs, [In] int nrhs, [In] IntPtr[] prhs, IntPtr impersonationToken);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclInitializeApplication_proxy")]
        private static extern bool mclInitializeApplication([In] string[] startupOptions, [In] IntPtr startupOptionsCount);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclInitializeComponentInstanceNonEmbeddedStandalone_proxy")]
        private static extern bool mclInitializeComponentInstanceNonEmbeddedStandalone(out IntPtr pMcrInst, [In] string pathToComponent, [In] string componentName, [In] int targetType, [In] IntPtr errorHandler, [In] IntPtr printHandler);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclInitializeComponentInstanceWithCallbk_proxy")]
        private static extern bool mclInitializeComponentInstanceWithCallbk(out IntPtr pMcrInst, [In] IntPtr errorHandler, [In] IntPtr printHandler, [In] IntPtr readCtfStreamFcn, [In] long ctfStreamSize);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclIsJVMEnabled_proxy")]
        private static extern bool mclIsJVMEnabled();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclIsMCRInitialized_proxy")]
        private static extern bool mclIsMCRInitialized();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclIsNoDisplaySet_proxy")]
        private static extern bool mclIsNoDisplaySet();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclmcrInitialize2_proxy")]
        private static extern bool mclmcrInitialize2(int primaryMode);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclMxDestroyArray_proxy")]
        protected static extern void mclMxDestroyArray([In] IntPtr pMXArray, bool onInterpreterThread);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclTerminateApplication_proxy")]
        private static extern bool mclTerminateApplication();
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclTerminateInstance_proxy")]
        private static extern bool mclTerminateInstance(ref IntPtr pMcrInst);
        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mclWaitForFiguresToDie_proxy")]
        private static extern void mclWaitForFiguresToDie([In] IntPtr hMCRInstance);
        private void setBuilderUserData()
        {
            MathWorks.MATLAB.NET.Arrays.MWArray array = "builder";
            MathWorks.MATLAB.NET.Arrays.MWArray array2 = "net";
            this.EvaluateFunction(0, "setmcruserdata", new MathWorks.MATLAB.NET.Arrays.MWArray[] { array, array2 });
        }

        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="stopImpersonationOnMCRThread_proxy")]
        private static extern void stopImpersonationOnMCRThread();
        public static bool TerminateApplication() { return true; }

        private static void unloadAppDomain(object sender, EventArgs e)
        {
            while (mcrInstances.Count > 0)
            {
                ((MWMCR) mcrInstances.Dequeue()).Dispose();
            }
            gchOut.Free();
            gchErr.Free();
        }

        private MathWorks.MATLAB.NET.Arrays.MWArray[] UnpackArgArray(object[] argArray)
        {
            if (argArray == null) return null;
            int length = argArray.Length;
            object[] objArray = null;
            if (length > 0)
            {
                Type type = argArray[length - 1].GetType();
                if (type.IsArray && !type.GetElementType().IsArray) objArray = argArray[length - 1] as object[];
            }
            int num2 = (objArray != null) ? (length + objArray.Length - 1) : length;
            int num3 = (objArray == null) ? length : (length - 1);
            MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = new MathWorks.MATLAB.NET.Arrays.MWArray[num2];
            int index = 0;
            index = 0;
            while (index < num3)
            {
                arrayArray[index] = MathWorks.MATLAB.NET.Arrays.MWArray.ConvertObjectToMWArray(argArray[index]);
                index++;
            }
            if (objArray != null)
            {
                for (int i = 0; i < objArray.Length; i++)
                {
                    arrayArray[index] = MathWorks.MATLAB.NET.Arrays.MWArray.ConvertObjectToMWArray(objArray[i]);
                    index++;
                }
            }
            return arrayArray;
        }

        private MathWorks.MATLAB.NET.Arrays.MWArray[] UnpackArgArray(object[] argArray, object[] varArgArray)
        {
            int num = argArray.Length + varArgArray.Length;
            MathWorks.MATLAB.NET.Arrays.MWArray[] arrayArray = new MathWorks.MATLAB.NET.Arrays.MWArray[num];
            int num2 = 0;
            foreach (object obj2 in argArray)
            {
                arrayArray[num2++] = MathWorks.MATLAB.NET.Arrays.MWArray.ConvertObjectToMWArray(obj2);
            }
            foreach (object obj3 in varArgArray)
            {
                arrayArray[num2++] = MathWorks.MATLAB.NET.Arrays.MWArray.ConvertObjectToMWArray(obj3);
            }
            return arrayArray;
        }

        public void WaitForFiguresToDie()
        {
            try
            {
                Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                mclWaitForFiguresToDie(this.mcrInstance);
            }
            finally
            {
                Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
            }
        }

        internal static int writeToErr(string s)
        {
            Console.Error.WriteLine(s);
            return s.Length;
        }

        internal static int writeToOut(string s)
        {
            Console.WriteLine(s);
            return s.Length;
        }

        internal static string LastErrorMessage
        {
            get
            {
                string str2;
                try
                {
                    Monitor.Enter(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                    string str = Marshal.PtrToStringAnsi(mclGetLastErrorMessage());
                    str2 = (string.Empty == str) ? "segv - SEVERE ERROR" : str;
                }
                finally
                {
                    Monitor.Exit(MathWorks.MATLAB.NET.Arrays.MWArray.mxSync);
                }
                return str2;
            }
        }

        internal IntPtr MCRInstance { get { return this.mcrInstance; } }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int CallBackDelegate(string data);
    }
}
