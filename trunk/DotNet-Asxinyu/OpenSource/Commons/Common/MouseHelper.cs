namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    [HostProtection(SecurityAction.LinkDemand, Resources=HostProtectionResource.ExternalProcessMgmt)]
    public class MouseHelper
    {
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int GetDoubleClickTime();
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseClick()
        {
            qCpqRb2bV(2, 0, 0, 0, UIntPtr.Zero);
            qCpqRb2bV(4, 0, 0, 0, UIntPtr.Zero);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseClick(Point location)
        {
            MouseMove(location);
            qCpqRb2bV(2, 0, 0, 0, UIntPtr.Zero);
            qCpqRb2bV(4, 0, 0, 0, UIntPtr.Zero);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseMove(Point location)
        {
            SetCursorPos(location.X, location.Y);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MouseRightClick(Point location)
        {
            MouseMove(location);
            qCpqRb2bV(8, 0, 0, 0, UIntPtr.Zero);
            qCpqRb2bV(0x10, 0, 0, 0, UIntPtr.Zero);
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
                return SystemInformation.MousePresent;
            }
        }

        public static bool WheelExists
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (!SystemInformation.MousePresent)
                {
                    throw new InvalidOperationException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd5b6));
                }
                return SystemInformation.MouseWheelPresent;
            }
        }

        public static int WheelScrollLines
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (!WheelExists)
                {
                    throw new InvalidOperationException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd5c8));
                }
                return SystemInformation.MouseWheelScrollLines;
            }
        }

        [Flags]
        private enum 4blYw6qeBkMRHVdX49O : uint
        {
        }
    }
}

