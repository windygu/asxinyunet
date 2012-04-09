namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ImeHelper
    {
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        public const int IME_CMODE_FULLSHAPE = 8;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 01FqmBarm(Control control1)
        {
            control1.Enter += new EventHandler(ImeHelper.yTHMJ858G);
            foreach (Control control in control1.Controls)
            {
                01FqmBarm(control);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 4bccOhnfl(object obj1)
        {
            Control control = (Control) obj1;
            TEPULnwMP(control.Handle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(object obj1, PaintEventArgs)
        {
            4bccOhnfl(obj1);
        }

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIme(IntPtr Handel)
        {
            TEPULnwMP(Handel);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIme(Control ctl)
        {
            01FqmBarm(ctl);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIme(Form frm)
        {
            frm.Paint += new PaintEventHandler(ImeHelper.dT3f0t4t3);
            01FqmBarm(frm);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void TEPULnwMP(IntPtr ptr1)
        {
            IntPtr himc = ImmGetContext(ptr1);
            if (ImmGetOpenStatus(himc))
            {
                int lpdw = 0;
                int num2 = 0;
                if (ImmGetConversionStatus(himc, ref lpdw, ref num2) && ((lpdw & 8) > 0))
                {
                    ImmSimulateHotKey(ptr1, 0x11);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void yTHMJ858G(object obj1, EventArgs)
        {
            4bccOhnfl(obj1);
        }
    }
}

