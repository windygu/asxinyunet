namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class Hooks
    {
        internal const int 6VVwcY8if = 0x101;
        internal const int 9kgn4QLpm = 0x100;
        internal const int 9pmF8RcXA = 520;
        internal const int a5b15FwhK = 0x202;
        internal const int HMRRScNpR = 0x102;
        internal const int HTsh0ufjK = 2;
        internal const int iVdeWS4CI = 260;
        internal const int IXfTquIBq = 0x20a;
        internal const int jBG69JC6b = 0x201;
        internal const int mSZOSPyGF = 0x204;
        internal const int NMPUAbUfQ = 5;
        internal const int Oyq2CULH4 = 0x20c;
        internal const int qsTB3Q7Nn = 0x200;
        internal const int QZP3BOG4h = 0x20b;
        internal const int So5jevQyM = 0x105;
        internal const int WTlMIkOug = 1;
        internal const int yfHxpghuZ = 0x205;
        internal const int Zka9gcBgJ = 0x207;

        [DllImport("user32.dll", EntryPoint="CallNextHookEx", CharSet=CharSet.Auto, SetLastError=true)]
        internal static extern IntPtr AWbNwkBdU(IntPtr, int, IntPtr, IntPtr);
        [DllImport("user32.dll", EntryPoint="UnhookWindowsHookEx", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        internal static extern bool JkKfoMY5A(IntPtr);
        [DllImport("user32.dll", EntryPoint="SetWindowsHookEx", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        internal static extern IntPtr VZJq3SjrW(int, HookProc, IntPtr, int);
        [DllImport("kernel32.dll", EntryPoint="GetModuleHandle", CharSet=CharSet.Auto, SetLastError=true)]
        internal static extern IntPtr wKyWxGToc(string);

        internal enum apS8f2q5E7dlOinKrQC
        {
        }

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        internal struct msCrLJqi8rxBkCkrInY
        {
            public Hooks.YNYQKFqpNJi6yngFVe9 VZJq3SjrW;
            public int JkKfoMY5A;
            public int AWbNwkBdU;
            public int wKyWxGToc;
            public IntPtr NMPUAbUfQ;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct YNYQKFqpNJi6yngFVe9
        {
            public int VZJq3SjrW;
            public int JkKfoMY5A;
        }
    }
}

