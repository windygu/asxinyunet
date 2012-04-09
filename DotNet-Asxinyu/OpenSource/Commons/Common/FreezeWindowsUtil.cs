namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class FreezeWindowsUtil : IDisposable
    {
        private uint 01FqmBarm;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FreezeWindowsUtil(IntPtr windowHandle)
        {
            NativeMethods.GetWindowThreadProcessId(windowHandle, out this.01FqmBarm);
            FreezeThreads((int) this.01FqmBarm);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            UnfreezeThreads((int) this.01FqmBarm);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void FreezeThreads(int intPID)
        {
            if ((intPID != 0) && (Process.GetCurrentProcess().Id != intPID))
            {
                Process processById = Process.GetProcessById(intPID);
                if (!string.IsNullOrEmpty(processById.ProcessName) && (processById.ProcessName != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaecc)))
                {
                    foreach (ProcessThread thread in processById.Threads)
                    {
                        IntPtr hThread = NativeMethods.OpenThread(NativeMethods.ThreadAccess.SUSPEND_RESUME, false, (uint) thread.Id);
                        NativeMethods.SuspendThread(hThread);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UnfreezeThreads(int intPID)
        {
            if ((intPID != 0) && (Process.GetCurrentProcess().Id != intPID))
            {
                Process processById = Process.GetProcessById(intPID);
                if (!string.IsNullOrEmpty(processById.ProcessName))
                {
                    foreach (ProcessThread thread in processById.Threads)
                    {
                        IntPtr hThread = NativeMethods.OpenThread(NativeMethods.ThreadAccess.SUSPEND_RESUME, false, (uint) thread.Id);
                        NativeMethods.ResumeThread(hThread);
                    }
                }
            }
        }
    }
}

