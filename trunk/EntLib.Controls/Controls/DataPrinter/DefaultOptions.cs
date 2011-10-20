namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DefaultOptions
    {
        public bool Enable;
        public string Text;
        public Font FontItem;
        public StringAlignment Valign;
        public StringAlignment Halign;
        public Color TextColor;
        public Color BackColor;
        public bool ShowOnHeader;
    }
}
