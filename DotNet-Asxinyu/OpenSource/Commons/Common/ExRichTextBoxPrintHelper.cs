namespace WHC.OrderWater.Commons
{
    using System;
    using System.Diagnostics;
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
            this.i6gI6MWgI = controlToPrint;
        }

        [DllImport("user32.dll", EntryPoint="SendMessage")]
        private static extern int 3xodQsKC6(IntPtr, int, int, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int eMSUYugy4(int num1)
        {
            return (int) (num1 * 14.4);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void EPgfA8o8U(object, PrintPageEventArgs args1)
        {
            this.7C51YoVSm = this.FormatRange(false, args1, this.7C51YoVSm, this.i6gI6MWgI.TextLength);
            if (this.7C51YoVSm < this.i6gI6MWgI.TextLength)
            {
                args1.HasMorePages = true;
            }
            else
            {
                args1.HasMorePages = false;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int FormatRange(bool measureOnly, PrintPageEventArgs e, int charFrom, int charTo)
        {
            Wb2Pbvq6GZbdrUPjLLG jllg;
            Cq8fmMqSaplb0cFE1ux cfeux;
            Cq8fmMqSaplb0cFE1ux cfeux2;
            PPsXNkqdqtWGNgjJ0qn jjqn;
            jllg.XxQqQ66mW = charFrom;
            jllg.EPgfA8o8U = charTo;
            cfeux.EPgfA8o8U = this.eMSUYugy4(e.MarginBounds.Top);
            cfeux.3xodQsKC6 = this.eMSUYugy4(e.MarginBounds.Bottom);
            cfeux.XxQqQ66mW = this.eMSUYugy4(e.MarginBounds.Left);
            cfeux.hudMECjTG = this.eMSUYugy4(e.MarginBounds.Right);
            cfeux2.EPgfA8o8U = this.eMSUYugy4(e.PageBounds.Top);
            cfeux2.3xodQsKC6 = this.eMSUYugy4(e.PageBounds.Bottom);
            cfeux2.XxQqQ66mW = this.eMSUYugy4(e.PageBounds.Left);
            cfeux2.hudMECjTG = this.eMSUYugy4(e.PageBounds.Right);
            IntPtr hdc = e.Graphics.GetHdc();
            jjqn.eMSUYugy4 = jllg;
            jjqn.XxQqQ66mW = hdc;
            jjqn.EPgfA8o8U = hdc;
            jjqn.hudMECjTG = cfeux;
            jjqn.3xodQsKC6 = cfeux2;
            int num = measureOnly ? 0 : 1;
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(jjqn));
            Marshal.StructureToPtr(jjqn, ptr, false);
            int num2 = 3xodQsKC6(this.i6gI6MWgI.Handle, 0x439, num, ptr);
            Marshal.FreeCoTaskMem(ptr);
            e.Graphics.ReleaseHdc(hdc);
            return num2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FormatRangeDone()
        {
            IntPtr ptr = new IntPtr(0);
            3xodQsKC6(this.i6gI6MWgI.Handle, 0x439, 0, ptr);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void hudMECjTG(object, PrintEventArgs)
        {
            this.FormatRangeDone();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(bool preview)
        {
            this.PrintRTF(new PrintDocument(), preview);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(PrintDocument printDocument)
        {
            try
            {
                printDocument.BeginPrint += new PrintEventHandler(this.XxQqQ66mW);
                printDocument.EndPrint += new PrintEventHandler(this.hudMECjTG);
                printDocument.PrintPage += new PrintPageEventHandler(this.EPgfA8o8U);
                printDocument.Print();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintRTF(PrintDocument printDocument, bool preview)
        {
            try
            {
                printDocument.BeginPrint += new PrintEventHandler(this.XxQqQ66mW);
                printDocument.EndPrint += new PrintEventHandler(this.hudMECjTG);
                printDocument.PrintPage += new PrintPageEventHandler(this.EPgfA8o8U);
                CoolPrintPreviewDialog dialog = new CoolPrintPreviewDialog {
                    Document = printDocument
                };
                if (preview)
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
                else
                {
                    printDocument.Print();
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionBold(bool bold)
        {
            return this.y3vHWmTuH(1, bold ? 1 : 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SetSelectionFont(RichTextBox control, string face)
        {
            yI6Pnfq8PnveAWhj0Q7 whjq;
            whjq = new yI6Pnfq8PnveAWhj0Q7 {
                XxQqQ66mW = Marshal.SizeOf(whjq),
                kjkSQKOOP = new char[0x20],
                EPgfA8o8U = 0x20000000
            };
            face.CopyTo(0, whjq.kjkSQKOOP, 0, Math.Min(0x1f, face.Length));
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(whjq));
            Marshal.StructureToPtr(whjq, ptr, false);
            return (3xodQsKC6(control.Handle, 0x444, 1, ptr) == 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionItalic(bool italic)
        {
            return this.y3vHWmTuH(2, italic ? 2 : 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SetSelectionSize(RichTextBox control, int size)
        {
            yI6Pnfq8PnveAWhj0Q7 whjq;
            whjq = new yI6Pnfq8PnveAWhj0Q7 {
                XxQqQ66mW = Marshal.SizeOf(whjq),
                EPgfA8o8U = 0x80000000,
                3xodQsKC6 = size * 20
            };
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(whjq));
            Marshal.StructureToPtr(whjq, ptr, false);
            return (3xodQsKC6(control.Handle, 0x444, 1, ptr) == 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool SetSelectionUnderlined(bool underlined)
        {
            return this.y3vHWmTuH(4, underlined ? 4 : 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XxQqQ66mW(object, PrintEventArgs)
        {
            this.7C51YoVSm = 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool y3vHWmTuH(uint num1, uint num2)
        {
            yI6Pnfq8PnveAWhj0Q7 whjq;
            whjq = new yI6Pnfq8PnveAWhj0Q7 {
                XxQqQ66mW = Marshal.SizeOf(whjq),
                EPgfA8o8U = num1,
                hudMECjTG = num2
            };
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(whjq));
            Marshal.StructureToPtr(whjq, ptr, false);
            return (3xodQsKC6(this.i6gI6MWgI.Handle, 0x444, 1, ptr) == 0);
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

