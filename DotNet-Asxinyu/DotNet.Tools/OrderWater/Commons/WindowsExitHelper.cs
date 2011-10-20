namespace WHC.OrderWater.Commons
{
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
        private static readonly IntPtr Qexvs1dd4;
        internal const int uGJxrnLpK = 2;
        internal const int Um5wSC5ZO = 2;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static WindowsExitHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WindowsExitHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("advapi32.dll", EntryPoint="AdjustTokenPrivileges", SetLastError=true, ExactSpelling=true)]
        internal static extern bool 3xodQsKC6(IntPtr, bool, ref DQO6LYqC78gluKYlNDR, int, IntPtr, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CloseMonitor()
        {
            // Translated Error! Expression stack is empty at offset 0006.
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
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void PowerOff()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Reboot()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);
        [DllImport("kernel32.dll", EntryPoint="GetCurrentProcess", ExactSpelling=true)]
        internal static extern IntPtr XxQqQ66mW();
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void y3vHWmTuH(int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
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
