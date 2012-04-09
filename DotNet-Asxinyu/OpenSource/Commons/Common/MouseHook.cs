namespace WHC.OrderWater.Commons
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class MouseHook
    {
        private static Hooks.HookProc 6VVwcY8if = new Hooks.HookProc(MouseHook.VZJq3SjrW);
        private static IntPtr 9kgn4QLpm = IntPtr.Zero;
        public static MouseButtonHandler ButtonDown;
        public static MouseButtonHandler ButtonUp;
        private static bool HMRRScNpR;
        public static MouseMoveHandler Moved;
        public static MouseScrollHandler Scrolled;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool AWbNwkBdU(MouseButtons buttons1)
        {
            if (ButtonUp != null)
            {
                return ButtonUp(buttons1);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Disable()
        {
            if (HMRRScNpR)
            {
                try
                {
                    Hooks.JkKfoMY5A(9kgn4QLpm);
                    HMRRScNpR = false;
                    return true;
                }
                catch
                {
                    HMRRScNpR = true;
                    return false;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Enable()
        {
            if (!HMRRScNpR)
            {
                try
                {
                    using (Process process = Process.GetCurrentProcess())
                    {
                        using (ProcessModule module = process.MainModule)
                        {
                            9kgn4QLpm = Hooks.VZJq3SjrW(14, 6VVwcY8if, Hooks.wKyWxGToc(module.ModuleName), 0);
                        }
                    }
                    HMRRScNpR = true;
                    return true;
                }
                catch
                {
                    HMRRScNpR = false;
                    return false;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool JkKfoMY5A(MouseButtons buttons1)
        {
            if (ButtonDown != null)
            {
                return ButtonDown(buttons1);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool NMPUAbUfQ(int num1)
        {
            if (Scrolled != null)
            {
                return Scrolled(num1);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IntPtr VZJq3SjrW(int num1, IntPtr ptr2, IntPtr ptr1)
        {
            bool flag = true;
            if (num1 >= 0)
            {
                Hooks.msCrLJqi8rxBkCkrInY ny = (Hooks.msCrLJqi8rxBkCkrInY) Marshal.PtrToStructure(ptr1, typeof(Hooks.msCrLJqi8rxBkCkrInY));
                switch (((int) ptr2))
                {
                    case 0x200:
                        flag = wKyWxGToc(new Point(ny.VZJq3SjrW.VZJq3SjrW, ny.VZJq3SjrW.JkKfoMY5A));
                        break;

                    case 0x201:
                        flag = JkKfoMY5A(MouseButtons.Left);
                        break;

                    case 0x202:
                        flag = AWbNwkBdU(MouseButtons.Left);
                        break;

                    case 0x204:
                        flag = JkKfoMY5A(MouseButtons.Right);
                        break;

                    case 0x205:
                        flag = AWbNwkBdU(MouseButtons.Right);
                        break;

                    case 0x207:
                        flag = JkKfoMY5A(MouseButtons.Middle);
                        break;

                    case 520:
                        flag = AWbNwkBdU(MouseButtons.Middle);
                        break;

                    case 0x20a:
                        flag = NMPUAbUfQ((ny.JkKfoMY5A >> 0x10) & 0xffff);
                        break;

                    case 0x20b:
                        if ((ny.JkKfoMY5A >> 0x10) != 1)
                        {
                            if ((ny.JkKfoMY5A >> 0x10) == 2)
                            {
                                flag = JkKfoMY5A(MouseButtons.XButton2);
                            }
                            break;
                        }
                        flag = JkKfoMY5A(MouseButtons.XButton1);
                        break;

                    case 0x20c:
                        if ((ny.JkKfoMY5A >> 0x10) != 1)
                        {
                            if ((ny.JkKfoMY5A >> 0x10) == 2)
                            {
                                flag = AWbNwkBdU(MouseButtons.XButton2);
                            }
                            break;
                        }
                        flag = AWbNwkBdU(MouseButtons.XButton1);
                        break;
                }
            }
            return (flag ? Hooks.AWbNwkBdU(9kgn4QLpm, num1, ptr2, ptr1) : new IntPtr(1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool wKyWxGToc(Point point1)
        {
            if (Moved != null)
            {
                return Moved(point1);
            }
            return true;
        }

        public delegate bool MouseButtonHandler(MouseButtons button);

        public delegate bool MouseMoveHandler(Point point);

        public delegate bool MouseScrollHandler(int delta);
    }
}

