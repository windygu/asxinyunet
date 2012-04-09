namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class ShellIcon
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetLargeIcon(string fileName)
        {
            SHFILEINFO structure = new SHFILEINFO();
            kSjhScqKBl45ZjrSQQ9.qCpqRb2bV(fileName, 0, ref structure, (uint) Marshal.SizeOf(structure), 0x100);
            if (structure.hIcon.ToInt32() == 0)
            {
                return null;
            }
            Icon icon = (Icon) Icon.FromHandle(structure.hIcon).Clone();
            kSjhScqKBl45ZjrSQQ9.r4vfcKJvu(structure.hIcon);
            return icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetSmallIcon(string fileName)
        {
            SHFILEINFO structure = new SHFILEINFO();
            kSjhScqKBl45ZjrSQQ9.qCpqRb2bV(fileName, 0, ref structure, (uint) Marshal.SizeOf(structure), 0x101);
            if (structure.hIcon.ToInt32() == 0)
            {
                return null;
            }
            Icon icon = (Icon) Icon.FromHandle(structure.hIcon).Clone();
            kSjhScqKBl45ZjrSQQ9.r4vfcKJvu(structure.hIcon);
            return icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetSmallTypeIcon(string ext)
        {
            SHFILEINFO structure = new SHFILEINFO();
            kSjhScqKBl45ZjrSQQ9.qCpqRb2bV(ext, 0x80, ref structure, (uint) Marshal.SizeOf(structure), 0x111);
            if (structure.hIcon.ToInt32() == 0)
            {
                return null;
            }
            Icon icon = (Icon) Icon.FromHandle(structure.hIcon).Clone();
            kSjhScqKBl45ZjrSQQ9.r4vfcKJvu(structure.hIcon);
            return icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTypeInfo(string ext)
        {
            SHFILEINFO structure = new SHFILEINFO();
            kSjhScqKBl45ZjrSQQ9.qCpqRb2bV(ext, 0x80, ref structure, (uint) Marshal.SizeOf(structure), 0x410);
            return structure.szTypeName;
        }

        private class kSjhScqKBl45ZjrSQQ9
        {
            public const uint 3iAMDA71x = 0x10;
            public const uint 3Z7DfImqg = 1;
            public const uint 6iReL2qUE = 0x100;
            public const uint 6wOQ2MZng = 4;
            public const uint AtIxU4Aqh = 2;
            public const uint B3iijjhhN = 0;
            public const uint CTIK4BcXY = 4;
            public const uint DcoBAxjp6 = 0x10000;
            public const uint FlHcVmgvp = 0x2000;
            public const uint I5KTD7U71 = 0x20000;
            public const uint IqGhetOq2 = 0x4000;
            public const uint Ix04dg12a = 0x800;
            public const uint k1mUM9ocK = 0x200;
            public const uint kSSOA84Ne = 0x80;
            public const uint ldSYSl9dp = 0x4000;
            public const uint m7HRrMhfC = 0x2000;
            public const uint MmgpGXYpX = 2;
            public const uint MnvNdaLNh = 0x100;
            public const uint nBCwVbEfB = 0x1000;
            public const uint niQkSxHZL = 0x8000;
            public const uint OLpFiXMu6 = 0x1000;
            public const uint OMnsP7apO = 0x10;
            public const uint OwQEiVytP = 1;
            public const uint sM967gVJB = 0x20;
            public const uint snJo0QVxt = 0x800;
            public const uint TNKrtqXqb = 0x200;
            public const uint VU21tswKQ = 8;
            public const uint VvGXm18jO = 0x400;
            public const uint yT4VNh4qe = 0x400;
            public const uint ZbmPdT41x = 0x40;

            [DllImport("shell32.dll", EntryPoint="SHGetFileInfo")]
            public static extern IntPtr qCpqRb2bV(string, uint, ref ShellIcon.SHFILEINFO, uint, uint);
            [DllImport("User32.dll", EntryPoint="DestroyIcon")]
            public static extern int r4vfcKJvu(IntPtr);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public string szTypeName;
        }
    }
}

