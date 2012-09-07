namespace MathWorks.MATLAB.NET.Utility
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;

    [SecurityPermission(SecurityAction.Demand, UnmanagedCode=true)]
    internal sealed class MWSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal long unmanagedBytesAllocated_;

        internal MWSafeHandle() : base(true)
        {
            base.SetHandle(IntPtr.Zero);
        }

        internal MWSafeHandle(IntPtr hMXArray) : base(true)
        {
            base.SetHandle(hMXArray);
        }

        internal MWSafeHandle(IntPtr hMXArray, bool ownsHandle) : base(ownsHandle)
        {
            base.SetHandle(hMXArray);
        }

        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="mxDestroyArray_proxy")]
        private static extern void mxDestroyArray([In] IntPtr pMXArray);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            if (MWMCR.MCRAppInitialized && IntPtr.Zero != base.handle)
            {
                mxDestroyArray(base.handle);
                base.handle = IntPtr.Zero;
                if (this.unmanagedBytesAllocated_ > 0) GC.RemoveMemoryPressure(this.unmanagedBytesAllocated_);
            }
            return true;
        }

        public long UnmanagedBytesAllocated
        {
            set
            {
                this.unmanagedBytesAllocated_ = value;
                GC.AddMemoryPressure(value);
            }
        }
    }
}
