namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class Win32Window
    {
        private static Image 0yQ5ybAio = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        private const int 1mh0TXZQa = 0xcc0020;
        private const int 2eBmaaCFr = -20;
        private ArrayList blUn6y2xl = null;
        private IntPtr dJegCBcyq;
        private const int jq8Lfw0ig = 0x40000;
        private static ArrayList P7pIhD2Vg = null;
        private string QRBG1yjB9 = null;
        private static ArrayList yLIZbM3fo = null;
        private const int ymCCHXmhs = 0x80;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Win32Window(IntPtr window)
        {
            this.dJegCBcyq = window;
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
            this.blUn6y2xl.Add(new Win32Window(ptr1));
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void BringWindowToTop()
        {
            k1mUM9ocK(this.dJegCBcyq);
            Thread.Sleep(500);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClickWindow(string button, int x, int y, bool doubleklick)
        {
            int num = this.d9sA58YFS(x, y);
            int num2 = 0;
            int num3 = 0;
            if (button == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd682))
            {
                num2 = 0x201;
                num3 = 0x202;
            }
            if (button == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd68e))
            {
                num2 = 0x204;
                num3 = 0x205;
            }
            if (doubleklick)
            {
                nBCwVbEfB(this.dJegCBcyq, num2, 0, num);
                nBCwVbEfB(this.dJegCBcyq, num3, 0, num);
                nBCwVbEfB(this.dJegCBcyq, num2, 0, num);
                nBCwVbEfB(this.dJegCBcyq, num3, 0, num);
            }
            else
            {
                nBCwVbEfB(this.dJegCBcyq, num2, 0, num);
                nBCwVbEfB(this.dJegCBcyq, num3, 0, num);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClickWindow_Post(string button, int x, int y, bool doubleklick)
        {
            int num = this.d9sA58YFS(x, y);
            int num2 = 0;
            int num3 = 0;
            if (button == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd69c))
            {
                num2 = 0x201;
                num3 = 0x202;
            }
            if (button == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6a8))
            {
                num2 = 0x204;
                num3 = 0x205;
            }
            if (doubleklick)
            {
                IqGhetOq2(this.dJegCBcyq, num2, 0, num);
                IqGhetOq2(this.dJegCBcyq, num3, 0, num);
                IqGhetOq2(this.dJegCBcyq, num2, 0, num);
                IqGhetOq2(this.dJegCBcyq, num3, 0, num);
            }
            else
            {
                IqGhetOq2(this.dJegCBcyq, num2, 0, num);
                IqGhetOq2(this.dJegCBcyq, num3, 0, num);
            }
        }

        [DllImport("user32.dll", EntryPoint="GetWindowTextLength")]
        private static extern int CTIK4BcXY(IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int d9sA58YFS(int num2, int num1)
        {
            return ((num1 << 0x10) | (num2 & 0xffff));
        }

        [DllImport("user32.dll", EntryPoint="GetParent")]
        private static extern IntPtr DcoBAxjp6(IntPtr);
        [DllImport("user32.dll", EntryPoint="GetWindowInfo")]
        private static extern bool elXueYN4t(IntPtr, ref CEm4YmquknjjbT4q04N);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Win32Window FindChild(string className, string windowName)
        {
            return new Win32Window(yT4VNh4qe(this.dJegCBcyq, IntPtr.Zero, className, windowName));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Win32Window FindWindow(string className, string windowName)
        {
            return new Win32Window(snJo0QVxt(className, windowName));
        }

        [DllImport("user32.dll", EntryPoint="GetWindowRect")]
        private static extern bool FlHcVmgvp(IntPtr, ref Rect);
        [DllImport("user32.dll ")]
        public static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder className, int maxCount);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ArrayList GetThreadWindows(int threadId)
        {
            P7pIhD2Vg = new ArrayList();
            3iAMDA71x(threadId, new LYRsUSqQqi9qe1Xnvd9(Win32Window.qCpqRb2bV), 0);
            ArrayList list = P7pIhD2Vg;
            P7pIhD2Vg = null;
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetWindowLong(int index)
        {
            return OwQEiVytP(this.dJegCBcyq, index);
        }

        [DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
        private static extern IntPtr I5KTD7U71();
        [DllImport("user32.dll", EntryPoint="PostMessage")]
        private static extern int IqGhetOq2(IntPtr, int, int, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsChild(Win32Window parent, Win32Window window)
        {
            return TNKrtqXqb(parent.dJegCBcyq, window.dJegCBcyq);
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
            int windowLong = this.GetWindowLong(-20);
            this.SetWindowLong(-20, windowLong | 0x80);
        }

        [DllImport("user32.dll", EntryPoint="GetWindowText")]
        private static extern int MmgpGXYpX(IntPtr, [In, Out] StringBuilder, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool MnvNdaLNh(IntPtr ptr1, int)
        {
            P7pIhD2Vg.Add(new Win32Window(ptr1));
            return true;
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
            return IqGhetOq2(this.dJegCBcyq, message, wparam, lparam);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool qCpqRb2bV(IntPtr ptr1, int)
        {
            P7pIhD2Vg.Add(new Win32Window(ptr1));
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool r4vfcKJvu(IntPtr ptr1, int)
        {
            Win32Window window = new Win32Window(ptr1);
            if (window.Parent.dJegCBcyq == IntPtr.Zero)
            {
                if (!window.Visible)
                {
                    return true;
                }
                if (window.Text == string.Empty)
                {
                    return true;
                }
                if (window.ClassName.Substring(0, 8) == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd66e))
                {
                    return true;
                }
                yLIZbM3fo.Add(window);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SendMessage(int message, int wparam, int lparam)
        {
            return nBCwVbEfB(this.dJegCBcyq, message, wparam, lparam);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SendMessage(int wMsg, int wParam, string lpstring)
        {
            return m7HRrMhfC(this.dJegCBcyq, wMsg, wParam, lpstring);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int SetWindowLong(int index, int value)
        {
            return OMnsP7apO(this.dJegCBcyq, index, value);
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
            string text = this.QRBG1yjB9;
            if (text == null)
            {
                text = this.Text;
            }
            return text;
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
                yLIZbM3fo = new ArrayList();
                sM967gVJB(new LYRsUSqQqi9qe1Xnvd9(Win32Window.r4vfcKJvu), 0);
                ArrayList list = yLIZbM3fo;
                yLIZbM3fo = null;
                return list;
            }
        }

        public ArrayList Children
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                this.blUn6y2xl = new ArrayList();
                6wOQ2MZng(this.dJegCBcyq, new LYRsUSqQqi9qe1Xnvd9(this.b54SF8YsE), 0);
                ArrayList list = this.blUn6y2xl;
                this.blUn6y2xl = null;
                return list;
            }
        }

        public string ClassName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                StringBuilder className = new StringBuilder(0x100);
                int length = GetClassName(this.dJegCBcyq, className, 0x100);
                return className.ToString(0, length);
            }
        }

        public static Image DesktopAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                Graphics graphics = Graphics.FromImage(0yQ5ybAio);
                IntPtr hdc = graphics.GetHdc();
                IntPtr ptr2 = OLpFiXMu6(I5KTD7U71());
                7xeaNdd2e(hdc, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, ptr2, 0, 0, 0xcc0020);
                graphics.ReleaseHdc(hdc);
                graphics.Dispose();
                return 0yQ5ybAio;
            }
        }

        public static Win32Window DesktopWindow
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return new Win32Window(I5KTD7U71()) { Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd65c) };
            }
        }

        public static Win32Window ForegroundWindow
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return new Win32Window(B3iijjhhN());
            }
        }

        public bool IsNull
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.dJegCBcyq == IntPtr.Zero);
            }
        }

        public Win32Window LastActivePopup
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                IntPtr window = 3Z7DfImqg(this.dJegCBcyq);
                if (window == this.dJegCBcyq)
                {
                    return new Win32Window(IntPtr.Zero);
                }
                return new Win32Window(window);
            }
        }

        public bool Maximized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return Ix04dg12a(this.dJegCBcyq);
            }
        }

        public bool Minimized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return VvGXm18jO(this.dJegCBcyq);
            }
        }

        public string Name
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.QRBG1yjB9;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.QRBG1yjB9 = value;
            }
        }

        public Win32Window Parent
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return new Win32Window(DcoBAxjp6(this.dJegCBcyq));
            }
        }

        public int ProcessId
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                int num = 0;
                ZbmPdT41x(this.dJegCBcyq, ref num);
                return num;
            }
        }

        public string Text
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                StringBuilder builder = new StringBuilder(CTIK4BcXY(this.dJegCBcyq) + 1);
                MmgpGXYpX(this.dJegCBcyq, builder, builder.Capacity);
                return builder.ToString();
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                SetWindowText(this.dJegCBcyq, value);
            }
        }

        public int ThreadId
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return kSSOA84Ne(this.dJegCBcyq, IntPtr.Zero);
            }
        }

        public static ArrayList TopLevelWindows
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                P7pIhD2Vg = new ArrayList();
                sM967gVJB(new LYRsUSqQqi9qe1Xnvd9(Win32Window.MnvNdaLNh), 0);
                ArrayList list = P7pIhD2Vg;
                P7pIhD2Vg = null;
                return list;
            }
        }

        public bool Visible
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (AtIxU4Aqh(this.dJegCBcyq) != 0);
            }
        }

        public IntPtr Window
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dJegCBcyq;
            }
        }

        public Image WindowAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (this.IsNull)
                {
                    return null;
                }
                this.BringWindowToTop();
                Rect rect = new Rect();
                if (!FlHcVmgvp(this.dJegCBcyq, ref rect))
                {
                    return null;
                }
                CEm4YmquknjjbT4q04N btqn = new CEm4YmquknjjbT4q04N {
                    qCpqRb2bV = Marshal.SizeOf(typeof(CEm4YmquknjjbT4q04N))
                };
                if (!elXueYN4t(this.dJegCBcyq, ref btqn))
                {
                    return null;
                }
                Image image = new Bitmap(rect.Width, rect.Height);
                Graphics graphics = Graphics.FromImage(image);
                IntPtr hdc = graphics.GetHdc();
                IntPtr ptr2 = OLpFiXMu6(this.dJegCBcyq);
                7xeaNdd2e(hdc, 0, 0, rect.Width, rect.Height, ptr2, 0, 0, 0xcc0020);
                graphics.ReleaseHdc(hdc);
                return image;
            }
        }

        public Image WindowClientAsBitmap
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (this.IsNull)
                {
                    return null;
                }
                this.BringWindowToTop();
                Rect rect = new Rect();
                if (!ldSYSl9dp(this.dJegCBcyq, ref rect))
                {
                    return null;
                }
                CEm4YmquknjjbT4q04N btqn = new CEm4YmquknjjbT4q04N {
                    qCpqRb2bV = Marshal.SizeOf(typeof(CEm4YmquknjjbT4q04N))
                };
                if (!elXueYN4t(this.dJegCBcyq, ref btqn))
                {
                    return null;
                }
                int num = btqn.MnvNdaLNh.X - btqn.r4vfcKJvu.X;
                int num2 = btqn.MnvNdaLNh.Y - btqn.r4vfcKJvu.Y;
                Image image = new Bitmap(rect.Width, rect.Height);
                Graphics graphics = Graphics.FromImage(image);
                IntPtr hdc = graphics.GetHdc();
                IntPtr ptr2 = OLpFiXMu6(this.dJegCBcyq);
                7xeaNdd2e(hdc, 0, 0, rect.Width, rect.Height, ptr2, num, num2, 0xcc0020);
                graphics.ReleaseHdc(hdc);
                return image;
            }
        }

        public WindowPlacement WindowPlacement
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                WindowPlacement placement = new WindowPlacement();
                6iReL2qUE(this.dJegCBcyq, ref placement);
                return placement;
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

