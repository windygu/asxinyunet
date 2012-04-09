namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

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
        private static HardDiskInfo a2FPVvZKe(xrwAqaYNYSmKucPIOd od1)
        {
            HardDiskInfo info = new HardDiskInfo();
            VR7VTyay9(od1.HPTtbHDyD);
            info.ModuleNumber = Encoding.ASCII.GetString(od1.HPTtbHDyD).Trim();
            VR7VTyay9(od1.4hvKymHGn);
            info.Firmware = Encoding.ASCII.GetString(od1.4hvKymHGn).Trim();
            VR7VTyay9(od1.VR7VTyay9);
            info.SerialNumber = Encoding.ASCII.GetString(od1.VR7VTyay9).Trim();
            info.Capacity = (od1.nKXrMp1lA / 2) / 0x400;
            return info;
        }

        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl")]
        private static extern int Gd6gd0WLH(IntPtr, uint, IntPtr, uint, ref 2du9TW5HjwFBWoVvtK, uint, ref uint, [Out] IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCPUId()
        {
            string str = "";
            try
            {
                ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4f24)).GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    return obj2.Properties[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4f46)].Value.ToString();
                }
                return str;
            }
            catch
            {
                str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4f60);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCPUName()
        {
            string str = (string) Registry.LocalMachine.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4f84)).GetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4fe4));
            return str.TrimStart(new char[0]);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiskID()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4eec)).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2.Properties[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4f0e)].Value.ToString();
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static HardDiskInfo GetHDInfo(byte driveIndex)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    throw new NotSupportedException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5264));

                case PlatformID.Win32Windows:
                    return Y6nN8uJxd(driveIndex);

                case PlatformID.Win32NT:
                    return KIhwg3idw(driveIndex);

                case PlatformID.WinCE:
                    throw new NotSupportedException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5298));
            }
            throw new NotSupportedException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x52ca));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetIPAddress()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5158)).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool) obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x519e)])
                {
                    Array array = (Array) obj2.Properties[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x51b4)].Value;
                    str = array.GetValue(0).ToString();
                    break;
                }
            }
            instances = null;
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMacAddress()
        {
            ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x50e4)).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool) obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x512a)])
                {
                    return obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5140)].ToString();
                }
            }
            return "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSystemType()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x51ca)).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x51f6)].ToString();
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTotalPhysicalMemory()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x520e)).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x523a)].ToString();
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetUSBDriveLetters()
        {
            List<string> list = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x500e));
            foreach (ManagementObject obj2 in searcher.Get())
            {
                foreach (ManagementObject obj3 in obj2.GetRelated(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5080)))
                {
                    foreach (ManagementObject obj4 in obj3.GetRelated(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x50aa)))
                    {
                        list.Add(obj4[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x50d0)].ToString());
                    }
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HDVal()
        {
            return HDVal(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4ee6));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HDVal(string drvID)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            string str = null;
            string str2 = null;
            int num4 = t00qRSolC(drvID + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4ede), str, 0x100, ref num, num2, num3, str2, 0x100);
            return num.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HardDiskInfo KIhwg3idw(byte num1)
        {
            2du9TW5HjwFBWoVvtK structure = new 2du9TW5HjwFBWoVvtK();
            bH0QsvpTN3jviQsh5y qshy = new bH0QsvpTN3jviQsh5y();
            OMoqO9XBTcCMqH1fWF fwf = new OMoqO9XBTcCMqH1fWF();
            uint num = 0;
            IntPtr ptr = lPRM4Nury(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x54ae), num1), 0xc0000000, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x54da));
            }
            if (0 == Gd6gd0WLH(ptr, 0x74080, IntPtr.Zero, 0, ref structure, (uint) Marshal.SizeOf(structure), ref num, IntPtr.Zero))
            {
                QM3fY09LE(ptr);
                throw new Exception(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5500), num1 + 1));
            }
            if (0 == (structure.WO5U9QNDF & 1))
            {
                QM3fY09LE(ptr);
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5536));
            }
            if (0 != (num1 & 1))
            {
                qshy.QM3fY09LE.Y6nN8uJxd = 0xb0;
            }
            else
            {
                qshy.QM3fY09LE.Y6nN8uJxd = 160;
            }
            if (0L != (structure.WO5U9QNDF & (((int) 0x10) >> num1)))
            {
                QM3fY09LE(ptr);
                throw new Exception(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x558e), num1 + 1));
            }
            qshy.QM3fY09LE.KIhwg3idw = 0xec;
            qshy.lPRM4Nury = num1;
            qshy.QM3fY09LE.QM3fY09LE = 1;
            qshy.QM3fY09LE.lPRM4Nury = 1;
            qshy.t00qRSolC = 0x200;
            if (0 == WO5U9QNDF(ptr, 0x7c088, ref qshy, (uint) Marshal.SizeOf(qshy), ref fwf, (uint) Marshal.SizeOf(fwf), ref num, IntPtr.Zero))
            {
                QM3fY09LE(ptr);
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x55f4));
            }
            QM3fY09LE(ptr);
            return a2FPVvZKe(fwf.lPRM4Nury);
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
            for (int i = 0; i < buffer1.Length; i += 2)
            {
                byte num = buffer1[i];
                buffer1[i] = buffer1[i + 1];
                buffer1[i + 1] = num;
            }
        }

        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl")]
        private static extern int WO5U9QNDF(IntPtr, uint, ref bH0QsvpTN3jviQsh5y, uint, ref OMoqO9XBTcCMqH1fWF, uint, ref uint, [Out] IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static HardDiskInfo Y6nN8uJxd(byte num1)
        {
            2du9TW5HjwFBWoVvtK structure = new 2du9TW5HjwFBWoVvtK();
            bH0QsvpTN3jviQsh5y qshy = new bH0QsvpTN3jviQsh5y();
            OMoqO9XBTcCMqH1fWF fwf = new OMoqO9XBTcCMqH1fWF();
            uint num = 0;
            IntPtr ptr = lPRM4Nury(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x52f0), 0, 0, IntPtr.Zero, 1, 0, IntPtr.Zero);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x530c));
            }
            if (0 == Gd6gd0WLH(ptr, 0x74080, IntPtr.Zero, 0, ref structure, (uint) Marshal.SizeOf(structure), ref num, IntPtr.Zero))
            {
                QM3fY09LE(ptr);
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5342));
            }
            if (0 == (structure.WO5U9QNDF & 1))
            {
                QM3fY09LE(ptr);
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5392));
            }
            if (0 != (num1 & 1))
            {
                qshy.QM3fY09LE.Y6nN8uJxd = 0xb0;
            }
            else
            {
                qshy.QM3fY09LE.Y6nN8uJxd = 160;
            }
            if (0L != (structure.WO5U9QNDF & (((int) 0x10) >> num1)))
            {
                QM3fY09LE(ptr);
                throw new Exception(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x53ea), num1 + 1));
            }
            qshy.QM3fY09LE.KIhwg3idw = 0xec;
            qshy.lPRM4Nury = num1;
            qshy.QM3fY09LE.QM3fY09LE = 1;
            qshy.QM3fY09LE.lPRM4Nury = 1;
            qshy.t00qRSolC = 0x200;
            if (0 == WO5U9QNDF(ptr, 0x7c088, ref qshy, (uint) Marshal.SizeOf(qshy), ref fwf, (uint) Marshal.SizeOf(fwf), ref num, IntPtr.Zero))
            {
                QM3fY09LE(ptr);
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x544e));
            }
            QM3fY09LE(ptr);
            return a2FPVvZKe(fwf.lPRM4Nury);
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

