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
        public ImeHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 01FqmBarm(Control control1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 4bccOhnfl(object obj1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(object obj1, PaintEventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
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
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIme(Control ctl)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIme(Form frm)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void TEPULnwMP(IntPtr ptr1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void yTHMJ858G(object obj1, EventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }
    }
}
