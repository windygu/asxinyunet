namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ExRichTextBoxPrintHelper
    {
        private const int 13OCE0e89 = 2;
        private const uint 15v87c56Y = 0x10;
        private const uint 3HLYeFNgt = 0x10000000;
        private const uint 4IG28w7MJ = 0x20;
        private const uint 4jSAnk1p1 = 0x80000000;
        private const int 533PxePZv = 0x439;
        private int 7C51YoVSm;
        private const uint 8ZAkMmrBR = 0x40000000;
        private const uint ALgWfoD2e = 0x20000000;
        private const uint C63uEPNVE = 0x8000000;
        private const uint DI7310vOl = 8;
        private const uint DJIZKDW6t = 0x40000000;
        private const uint eQ95WeVl5 = 2;
        private const int FDjLaMMWZ = 0x444;
        private const uint gEcmUyKxN = 8;
        private const uint H6LN3Tw3t = 4;
        private const uint H9L6nYuI8 = 1;
        private const uint i2VFt44Cv = 2;
        private RichTextBox i6gI6MWgI;
        private const int kjkSQKOOP = 0x43a;
        private const int M3MBKcV3M = 1;
        private const uint moKQgaVV3 = 1;
        private const uint Qexvs1dd4 = 0x20;
        private const uint STQgBw7ht = 4;
        private const int uGJxrnLpK = 4;
        private const int Um5wSC5ZO = 0x400;
        private const uint Zs5RWH8S2 = 0x10;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ExRichTextBoxPrintHelper(RichTextBox controlToPrint)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="SendMessage")]
        private static extern int 3xodQsKC6(IntPtr, int, int, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int eMSUYugy4(int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void EPgfA8o8U(object, PrintPageEventArgs args1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int FormatRange(bool measureOnly, PrintPageEventArgs e, int charFrom, int charTo)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FormatRangeDone()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void hudMECjTG(object, PrintEventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(bool preview)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(PrintDocument printDocument)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(PrintDocument printDocument, bool preview)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionBold(bool bold)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SetSelectionFont(RichTextBox control, string face)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionItalic(bool italic)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SetSelectionSize(RichTextBox control, int size)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionUnderlined(bool underlined)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XxQqQ66mW(object, PrintEventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool y3vHWmTuH(uint num1, uint num2)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Cq8fmMqSaplb0cFE1ux
        {
            public int XxQqQ66mW;
            public int EPgfA8o8U;
            public int hudMECjTG;
            public int 3xodQsKC6;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PPsXNkqdqtWGNgjJ0qn
        {
            public IntPtr XxQqQ66mW;
            public IntPtr EPgfA8o8U;
            public ExRichTextBoxPrintHelper.Cq8fmMqSaplb0cFE1ux hudMECjTG;
            public ExRichTextBoxPrintHelper.Cq8fmMqSaplb0cFE1ux 3xodQsKC6;
            public ExRichTextBoxPrintHelper.Wb2Pbvq6GZbdrUPjLLG eMSUYugy4;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Wb2Pbvq6GZbdrUPjLLG
        {
            public int XxQqQ66mW;
            public int EPgfA8o8U;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct yI6Pnfq8PnveAWhj0Q7
        {
            public int XxQqQ66mW;
            public uint EPgfA8o8U;
            public uint hudMECjTG;
            public int 3xodQsKC6;
            public int eMSUYugy4;
            public int y3vHWmTuH;
            public byte Um5wSC5ZO;
            public byte 533PxePZv;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x20)]
            public char[] kjkSQKOOP;
        }
    }
}
