namespace WHC.OrderWater.Commons
{
    using IDMXUQqUuLadT6DeMWV;
    using System;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    [HostProtection(SecurityAction.LinkDemand, Resources=HostProtectionResource.ExternalProcessMgmt)]
    public class KeyboardHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendKeys(string keys)
        {
            SendKeys(keys, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendKeys(string keys, bool wait)
        {
            if (wait)
            {
                System.Windows.Forms.SendKeys.SendWait(keys);
            }
            else
            {
                System.Windows.Forms.SendKeys.Send(keys);
            }
        }

        public static bool AltKeyDown
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((Control.ModifierKeys & Keys.Alt) > Keys.None);
            }
        }

        public static bool CapsLock
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((mql1TKqaf14ZFsyqAy0.01FqmBarm(20) & 1) > 0);
            }
        }

        public static bool CtrlKeyDown
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((Control.ModifierKeys & Keys.Control) > Keys.None);
            }
        }

        public static bool NumLock
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((mql1TKqaf14ZFsyqAy0.01FqmBarm(0x90) & 1) > 0);
            }
        }

        public static bool ScrollLock
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((mql1TKqaf14ZFsyqAy0.01FqmBarm(0x91) & 1) > 0);
            }
        }

        public static bool ShiftKeyDown
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((Control.ModifierKeys & Keys.Shift) > Keys.None);
            }
        }
    }
}

