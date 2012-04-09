namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class KeyboardHook
    {
        private static bool a2FPVvZKe;
        public static bool Alt = false;
        public static bool Control = false;
        private static IntPtr Gd6gd0WLH = IntPtr.Zero;
        public static KeyboardHookHandler KeyDown;
        private static Dictionary<Keys, KeyPressed> KIhwg3idw = new Dictionary<Keys, KeyPressed>();
        public static bool Shift = false;
        public static bool Win = false;
        private static Hooks.HookProc WO5U9QNDF = new Hooks.HookProc(KeyboardHook.t00qRSolC);
        private static Dictionary<Keys, KeyPressed> Y6nN8uJxd = new Dictionary<Keys, KeyPressed>();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Add(Keys key, KeyPressed callback)
        {
            return AddKeyDown(key, callback);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AddKeyDown(Keys key, KeyPressed callback)
        {
            KeyDown = null;
            if (!Y6nN8uJxd.ContainsKey(key))
            {
                Y6nN8uJxd.Add(key, callback);
                return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AddKeyUp(Keys key, KeyPressed callback)
        {
            if (!KIhwg3idw.ContainsKey(key))
            {
                KIhwg3idw.Add(key, callback);
                return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Disable()
        {
            if (a2FPVvZKe)
            {
                try
                {
                    Hooks.JkKfoMY5A(Gd6gd0WLH);
                    a2FPVvZKe = false;
                    return true;
                }
                catch
                {
                    a2FPVvZKe = true;
                    return false;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Enable()
        {
            if (!a2FPVvZKe)
            {
                try
                {
                    using (Process process = Process.GetCurrentProcess())
                    {
                        using (ProcessModule module = process.MainModule)
                        {
                            Gd6gd0WLH = Hooks.VZJq3SjrW(13, WO5U9QNDF, Hooks.wKyWxGToc(module.ModuleName), 0);
                        }
                    }
                    a2FPVvZKe = true;
                    return true;
                }
                catch
                {
                    a2FPVvZKe = false;
                    return false;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string KeyToString(Keys key)
        {
            return ((Control ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e38) : "") + (Alt ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e4a) : "") + (Shift ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e5a) : "") + (Win ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e6e) : "") + key.ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool lPRM4Nury(Keys keys1)
        {
            if (KIhwg3idw.ContainsKey(keys1))
            {
                return KIhwg3idw[keys1]();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool QM3fY09LE(Keys keys1)
        {
            if (KeyDown != null)
            {
                return KeyDown(keys1);
            }
            if (Y6nN8uJxd.ContainsKey(keys1))
            {
                return Y6nN8uJxd[keys1]();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Remove(Keys key)
        {
            return RemoveDown(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool RemoveDown(Keys key)
        {
            return Y6nN8uJxd.Remove(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool RemoveUp(Keys key)
        {
            return KIhwg3idw.Remove(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IntPtr t00qRSolC(int num1, IntPtr ptr1, IntPtr ptr2)
        {
            bool flag = true;
            if (num1 >= 0)
            {
                int num;
                if ((ptr1 == ((IntPtr) 0x100)) || (ptr1 == ((IntPtr) 260)))
                {
                    num = Marshal.ReadInt32(ptr2);
                    if ((num == 0xa2) || (num == 0xa3))
                    {
                        Control = true;
                    }
                    else if ((num == 160) || (num == 0xa1))
                    {
                        Shift = true;
                    }
                    else if ((num == 0xa5) || (num == 0xa4))
                    {
                        Alt = true;
                    }
                    else if ((num == 0x5c) || (num == 0x5b))
                    {
                        Win = true;
                    }
                    else
                    {
                        flag = QM3fY09LE((Keys) num);
                    }
                }
                else if ((ptr1 == ((IntPtr) 0x101)) || (ptr1 == ((IntPtr) 0x105)))
                {
                    num = Marshal.ReadInt32(ptr2);
                    switch (num)
                    {
                        case 0xa2:
                        case 0xa3:
                            Control = false;
                            goto Label_020A;

                        case 160:
                        case 0xa1:
                            Shift = false;
                            goto Label_020A;
                    }
                    if ((num == 0xa5) || (num == 0xa4))
                    {
                        Alt = false;
                    }
                    else if ((num == 0x5c) || (num == 0x5b))
                    {
                        Win = false;
                    }
                    else
                    {
                        flag = lPRM4Nury((Keys) num);
                    }
                }
            }
        Label_020A:
            return (flag ? Hooks.AWbNwkBdU(Gd6gd0WLH, num1, ptr1, ptr2) : new IntPtr(1));
        }

        public delegate bool KeyboardHookHandler(Keys key);

        public delegate bool KeyPressed();
    }
}

