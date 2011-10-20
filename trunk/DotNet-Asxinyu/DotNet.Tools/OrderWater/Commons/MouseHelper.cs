namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    [HostProtection(SecurityAction.LinkDemand, Resources=4)]
    public class MouseHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public MouseHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int GetDoubleClickTime();
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseClick()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseClick(Point location)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseMove(Point location)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseRightClick(Point location)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32.dll", EntryPoint="mouse_event")]
        private static extern void qCpqRb2bV(4blYw6qeBkMRHVdX49O, int, int, uint, UIntPtr);
        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        public static bool MousePresent
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static bool WheelExists
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static int WheelScrollLines
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [Flags]
        private enum 4blYw6qeBkMRHVdX49O : uint
        {
        }
    }
}
