namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct WatermarkOptions
    {
        public bool Enable;
        public string Text;
        public Point Location;
        public int Angle;
        public Font FontItem;
        public Color TextColor;
    }
}
