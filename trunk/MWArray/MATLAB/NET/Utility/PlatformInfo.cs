namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    internal class PlatformInfo
    {
        public static string getArchDir()
        {
            if (Is32BitProcess()) return "win32";
            if (!Is64BitProcess()) throw new Exception("Unsupported Windows platform");
            return "win64";
        }

        public static bool Is32BitProcess() { return IntPtr.Size == 4; }

        public static bool Is64BitProcess() { return IntPtr.Size == 8; }
    }
}
