namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LogoOptions
    {
        public bool Enable;
        public string FilePath;
        public Point Location;
        public Size ImageSize;
    }
}
