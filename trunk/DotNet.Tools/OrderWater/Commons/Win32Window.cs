namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Win32Window
    {
        private static Image 0yQ5ybAio;
        private const int 1mh0TXZQa = 0xcc0020;
        private const int 2eBmaaCFr = -20;
        private ArrayList blUn6y2xl;
        private IntPtr dJegCBcyq;
        private const int jq8Lfw0ig = 0x40000;
        private static ArrayList P7pIhD2Vg;
        private string QRBG1yjB9;
        private static ArrayList yLIZbM3fo;
        private const int ymCCHXmhs = 0x80;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Win32Window()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Win32Window(IntPtr window)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="EnumThreadWindows")]
        private static extern bool 3iAMDA71x(int, LYRsUSqQqi9qe1Xnvd9, int);
        [DllImport("user32.dll", EntryPoint="GetLastActivePopup")]
        private static extern IntPtr 3Z7DfImqg(IntPtr);
        [DllImport("user32.dll", EntryPoint="GetWindowPlacement")]
        private static extern bool 6iReL2qUE(IntPtr, ref WindowPlacement);
        [DllImport("user32.dll", EntryPoint="EnumChildWindows")]
        private static extern bool 6wOQ2MZng(IntPtr, LYRsUSqQqi9qe1Xnvd9, int);
        [DllImport("gdi32.dll", EntryPoint="BitBlt")]
        private static extern ulong 7xeaNdd2e(IntPtr, int, int, int, int, IntPtr, int, int, int);
        [DllImport("user32.dll", EntryPoint="IsWindowVisible")]
        private static extern int AtIxU4Aqh(IntPtr);
        [DllImport("user32.dll", EntryPoint="GetForegroundWindow")]
        private static extern IntPtr B3iijjhhN();
        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool b54SF8YsE(IntPtr ptr1, int)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void BringWindowToTop()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClickWindow(string button, int x, int y, bool doubleklick)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClickWindow_Post(string button, int x, int y, bool doubleklick)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="GetWindowTextLength")]
        private static extern int CTIK4BcXY(IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int d9sA58YFS(int num2, int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="GetParent")]
        private static extern IntPtr DcoBAxjp6(IntPtr);
        [DllImport("user32.dll", EntryPoint="GetWindowInfo")]
        private static extern bool elXueYN4t(IntPtr, ref CEm4YmquknjjbT4q04N);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Win32Window FindChild(string className, string windowName)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Win32Window FindWindow(string className, string windowName)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="GetWindowRect")]
        private static extern bool FlHcVmgvp(IntPtr, ref Rect);
        [DllImport("user32.dll ")]
        public static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder className, int maxCount);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ArrayList GetThreadWindows(int threadId)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetWindowLong(int index)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
        private static extern IntPtr I5KTD7U71();
        [DllImport("user32.dll", EntryPoint="PostMessage")]
        private static extern int IqGhetOq2(IntPtr, int, int, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsChild(Win32Window parent, Win32Window window)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="IsZoomed")]
        private static extern bool Ix04dg12a(IntPtr);
        [DllImport("user32.dll", EntryPoint="BringWindowToTop")]
        private static extern bool k1mUM9ocK(IntPtr);
        [DllImport("user32.dll", EntryPoint="GetWindowThreadProcessId")]
        private static extern int kSSOA84Ne(IntPtr, IntPtr);
        [DllImport("user32.dll", EntryPoint="GetClientRect")]
        private static extern bool ldSYSl9dp(IntPtr, ref Rect);
        [DllImport("user32", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
        private static extern int m7HRrMhfC(IntPtr, int, int, string);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MakeToolWindow()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="GetWindowText")]
        private static extern int MmgpGXYpX(IntPtr, [In, Out] StringBuilder, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool MnvNdaLNh(IntPtr ptr1, int)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="SendMessage")]
        private static extern int nBCwVbEfB(IntPtr, int, int, int);
        [DllImport("User32.dll", EntryPoint="PostMessage")]
        private static extern int niQkSxHZL(IntPtr, int, IntPtr, string);
        [DllImport("user32.dll", EntryPoint="GetWindowDC")]
        private static extern IntPtr OLpFiXMu6(IntPtr);
        [DllImport("user32.dll", EntryPoint="SetWindowLong")]
        private static extern int OMnsP7apO(IntPtr, int, int);
        [DllImport("user32.dll", EntryPoint="GetWindowLong")]
        private static extern int OwQEiVytP(IntPtr, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public int PostMessage(int message, int wparam, int lparam)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool qCpqRb2bV(IntPtr ptr1, int)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool r4vfcKJvu(IntPtr ptr1, int)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SendMessage(int message, int wparam, int lparam)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SendMessage(int wMsg, int wParam, string lpstring)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SetWindowLong(int index, int value)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr window, [MarshalAs(UnmanagedType.LPTStr)] string text);
        [DllImport("user32.dll", EntryPoint="EnumWindows")]
        private static extern bool sM967gVJB(LYRsUSqQqi9qe1Xnvd9, int);
        [DllImport("user32.dll", EntryPoint="FindWindow")]
        private static extern IntPtr snJo0QVxt(string, string);
        [DllImport("user32.dll", EntryPoint="IsChild")]
        private static extern bool TNKrtqXqb(IntPtr, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string ToString()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("User32.dll", EntryPoint="PrintWindow")]
        private static extern bool uH4954kfm(IntPtr, IntPtr, uint);
        [DllImport("user32.dll", EntryPoint="GetWindowClassNameLength")]
        private static extern int VU21tswKQ(IntPtr);
        [DllImport("user32.dll", EntryPoint="IsIconic")]
        private static extern bool VvGXm18jO(IntPtr);
        [DllImport("user32.dll", EntryPoint="FindWindowEx")]
        private static extern IntPtr yT4VNh4qe(IntPtr, IntPtr, string, string);
        [DllImport("user32.dll", EntryPoint="GetWindowThreadProcessId")]
        private static extern int ZbmPdT41x(IntPtr, ref int);

        public static ArrayList ApplicationWindows
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public ArrayList Children
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public string ClassName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static Image DesktopAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static Win32Window DesktopWindow
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static Win32Window ForegroundWindow
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public bool IsNull
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public Win32Window LastActivePopup
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public bool Maximized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public bool Minimized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public string Name
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public Win32Window Parent
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public int ProcessId
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public string Text
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public int ThreadId
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static ArrayList TopLevelWindows
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public bool Visible
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public IntPtr Window
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public Image WindowAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public Image WindowClientAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public WindowPlacement WindowPlacement
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CEm4YmquknjjbT4q04N
        {
            public int qCpqRb2bV;
            public Rectangle r4vfcKJvu;
            public Rectangle MnvNdaLNh;
            public int k1mUM9ocK;
            public int yT4VNh4qe;
            public int snJo0QVxt;
            public uint nBCwVbEfB;
            public uint m7HRrMhfC;
            public short IqGhetOq2;
            public short niQkSxHZL;
        }

        private delegate bool LYRsUSqQqi9qe1Xnvd9(IntPtr, int);
    }
}
