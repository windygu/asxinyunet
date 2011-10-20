namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed class HardwareInfoHelper
    {
        private const uint 2IIBg5mDY = 0x7c084;
        private const uint 4hvKymHGn = 0x80000000;
        private const uint 6ifRb4FX6 = 1;
        private const uint gLqZZCfZs = 0x7c088;
        private const uint HPTtbHDyD = 0x40000000;
        private const uint j67pukdBW = 1;
        private const uint MjoJPKkvO = 0x74080;
        private const uint rtLebCSOJ = 2;
        private const uint VKRc8OILh = 3;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HardwareInfoHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HardDiskInfo a2FPVvZKe(xrwAqaYNYSmKucPIOd od1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl")]
        private static extern int Gd6gd0WLH(IntPtr, uint, IntPtr, uint, ref 2du9TW5HjwFBWoVvtK, uint, ref uint, [Out] IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetComputerName()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCPUId()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCPUName()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiskID()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static HardDiskInfo GetHDInfo(byte driveIndex)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetIPAddress()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMacAddress()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSystemType()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTotalPhysicalMemory()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetUSBDriveLetters()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUserName()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HDVal()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HDVal(string drvID)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HardDiskInfo KIhwg3idw(byte num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("kernel32.dll", EntryPoint="CreateFile", SetLastError=true)]
        private static extern IntPtr lPRM4Nury(string, uint, uint, IntPtr, uint, uint, IntPtr);
        [DllImport("kernel32.dll", EntryPoint="CloseHandle", SetLastError=true)]
        private static extern int QM3fY09LE(IntPtr);
        [DllImport("kernel32.dll", EntryPoint="GetVolumeInformation")]
        private static extern int t00qRSolC(string, string, int, ref int, int, int, string, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void VR7VTyay9(byte[] buffer1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl")]
        private static extern int WO5U9QNDF(IntPtr, uint, ref bH0QsvpTN3jviQsh5y, uint, ref OMoqO9XBTcCMqH1fWF, uint, ref uint, [Out] IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HardDiskInfo Y6nN8uJxd(byte num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct 2du9TW5HjwFBWoVvtK
        {
            public byte t00qRSolC;
            public byte QM3fY09LE;
            public byte lPRM4Nury;
            public byte Gd6gd0WLH;
            public uint WO5U9QNDF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public uint[] Y6nN8uJxd;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct bH0QsvpTN3jviQsh5y
        {
            public uint t00qRSolC;
            public HardwareInfoHelper.EDBwWSi72EJXfZe7RV QM3fY09LE;
            public byte lPRM4Nury;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
            public byte[] Gd6gd0WLH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public uint[] WO5U9QNDF;
            public byte Y6nN8uJxd;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct EDBwWSi72EJXfZe7RV
        {
            public byte t00qRSolC;
            public byte QM3fY09LE;
            public byte lPRM4Nury;
            public byte Gd6gd0WLH;
            public byte WO5U9QNDF;
            public byte Y6nN8uJxd;
            public byte KIhwg3idw;
            public byte a2FPVvZKe;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct HardDiskInfo
        {
            public string ModuleNumber;
            public string Firmware;
            public string SerialNumber;
            public uint Capacity;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct Jm0rjQ77qvY9tnU1je
        {
            public byte t00qRSolC;
            public byte QM3fY09LE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
            public byte[] lPRM4Nury;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
            public uint[] Gd6gd0WLH;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct OMoqO9XBTcCMqH1fWF
        {
            public uint t00qRSolC;
            public HardwareInfoHelper.Jm0rjQ77qvY9tnU1je QM3fY09LE;
            public HardwareInfoHelper.xrwAqaYNYSmKucPIOd lPRM4Nury;
        }

        [StructLayout(LayoutKind.Sequential, Size=0x200, Pack=1)]
        internal struct xrwAqaYNYSmKucPIOd
        {
            public ushort t00qRSolC;
            public ushort QM3fY09LE;
            public ushort lPRM4Nury;
            public ushort Gd6gd0WLH;
            public ushort WO5U9QNDF;
            public ushort Y6nN8uJxd;
            public ushort KIhwg3idw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
            public ushort[] a2FPVvZKe;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=20)]
            public byte[] VR7VTyay9;
            public ushort MjoJPKkvO;
            public ushort 2IIBg5mDY;
            public ushort gLqZZCfZs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
            public byte[] 4hvKymHGn;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=40)]
            public byte[] HPTtbHDyD;
            public ushort j67pukdBW;
            public ushort rtLebCSOJ;
            public ushort 6ifRb4FX6;
            public ushort VKRc8OILh;
            public ushort ERklKEq5q;
            public ushort 9q79xVK9w;
            public ushort Kf2oXqL4k;
            public ushort oMRxB4ibY;
            public ushort u5j3iXQny;
            public ushort acWAbAQaL;
            public uint xCn6a9dnk;
            public ushort OC6GdIaE7;
            public uint nKXrMp1lA;
            public ushort KJiaI9woE;
            public ushort vf17N0FS2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x80)]
            public byte[] 1DE4NO3vw;
        }
    }
}
