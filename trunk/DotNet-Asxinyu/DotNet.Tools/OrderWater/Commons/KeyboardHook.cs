namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public static class KeyboardHook
    {
        private static bool a2FPVvZKe;
        public static bool Alt;
        public static bool Control;
        private static IntPtr Gd6gd0WLH;
        public static KeyboardHookHandler KeyDown;
        private static Dictionary<Keys, KeyPressed> KIhwg3idw;
        public static bool Shift;
        public static bool Win;
        private static Hooks.HookProc WO5U9QNDF;
        private static Dictionary<Keys, KeyPressed> Y6nN8uJxd;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static KeyboardHook()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Add(Keys key, KeyPressed callback)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AddKeyDown(Keys key, KeyPressed callback)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AddKeyUp(Keys key, KeyPressed callback)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Disable()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Enable()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string KeyToString(Keys key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool lPRM4Nury(Keys keys1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool QM3fY09LE(Keys keys1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Remove(Keys key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool RemoveDown(Keys key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool RemoveUp(Keys key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IntPtr t00qRSolC(int num1, IntPtr ptr1, IntPtr ptr2)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public delegate bool KeyboardHookHandler(Keys key);

        public delegate bool KeyPressed();
    }
}
