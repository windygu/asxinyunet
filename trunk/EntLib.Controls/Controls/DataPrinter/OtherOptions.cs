namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OtherOptions
    {
        public bool PrinterEnable;
        public bool DateTimeEnable;
        public bool CopysEnable;
        public string PrinterText;
        public string DateTimeText;
        public string DateTimeFormat;
        public bool AutoPrinter;
        public bool AutoDateTime;
        public Font FontItem;
        public StringAlignment Valign;
        public StringAlignment Halign;
        public Color TextColor;
        public Color BackColor;
    }
}
