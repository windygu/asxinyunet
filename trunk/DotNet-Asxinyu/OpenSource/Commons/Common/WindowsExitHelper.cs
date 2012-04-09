namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class WindowsExitHelper
    {
        internal const int 13OCE0e89 = 1;
        private const uint 15v87c56Y = 0xf170;
        internal const int 533PxePZv = 8;
        private const uint DI7310vOl = 0x112;
        internal const string FDjLaMMWZ = "SeShutdownPrivilege";
        internal const int H6LN3Tw3t = 0x10;
        internal const int i2VFt44Cv = 8;
        internal const int kjkSQKOOP = 0x20;
        internal const int M3MBKcV3M = 0;
        internal const int moKQgaVV3 = 4;
        private static readonly IntPtr Qexvs1dd4 = new IntPtr(0xffff);
        internal const int uGJxrnLpK = 2;
        internal const int Um5wSC5ZO = 2;

        [DllImport("advapi32.dll", EntryPoint="AdjustTokenPrivileges", SetLastError=true, ExactSpelling=true)]
        internal static extern bool 3xodQsKC6(IntPtr, bool, ref DQO6LYqC78gluKYlNDR, int, IntPtr, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CloseMonitor()
        {
            SendMessage(Qexvs1dd4, 0x112, 0xf170, 2);
        }

        [DllImport("user32.dll", EntryPoint="ExitWindowsEx", SetLastError=true, ExactSpelling=true)]
        internal static extern bool eMSUYugy4(int, int);
        [DllImport("advapi32.dll", EntryPoint="OpenProcessToken", SetLastError=true, ExactSpelling=true)]
        internal static extern bool EPgfA8o8U(IntPtr, int, ref IntPtr);
        [DllImport("advapi32.dll", EntryPoint="LookupPrivilegeValue", SetLastError=true)]
        internal static extern bool hudMECjTG(string, string, ref long);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogoOff()
        {
            y3vHWmTuH(4);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void PowerOff()
        {
            y3vHWmTuH(12);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Reboot()
        {
            y3vHWmTuH(6);
        }

        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);
        [DllImport("kernel32.dll", EntryPoint="GetCurrentProcess", ExactSpelling=true)]
        internal static extern IntPtr XxQqQ66mW();
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void y3vHWmTuH(int num1)
        {
            DQO6LYqC78gluKYlNDR lndr;
            IntPtr ptr = XxQqQ66mW();
            IntPtr zero = IntPtr.Zero;
            bool flag = EPgfA8o8U(ptr, 40, ref zero);
            lndr.XxQqQ66mW = 1;
            lndr.EPgfA8o8U = 0L;
            lndr.hudMECjTG = 2;
            flag = hudMECjTG(null, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb79c), ref lndr.EPgfA8o8U);
            flag = 3xodQsKC6(zero, false, ref lndr, 0, IntPtr.Zero, IntPtr.Zero);
            flag = eMSUYugy4(num1, 0);
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct DQO6LYqC78gluKYlNDR
        {
            public int XxQqQ66mW;
            public long EPgfA8o8U;
            public int hudMECjTG;
        }
    }
}

