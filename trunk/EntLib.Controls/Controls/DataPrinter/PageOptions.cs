namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [StructLayout(LayoutKind.Sequential)]
    public struct PageOptions
    {
        public string Printer;
        public bool PrintToFile;
        public string Scope;
        public int Copys;
        public Orientation PrinterOrientation;
        public string PaperSize;
        public string PagerFrom;
        public string Margin;
    }
}
