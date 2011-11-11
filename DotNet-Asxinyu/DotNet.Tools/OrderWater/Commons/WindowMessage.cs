﻿namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;

    public class WindowMessage
    {
        public const int BM_GETSTATE = 0xf2;
        public const int BS_AUTOCHECKBOX = 3;
        public const int BS_AUTORADIOBUTTON = 9;
        public const int BS_CHECKBOX = 2;
        public const int BS_DEFPUSHBUTTON = 1;
        public const int BS_GROUPBOX = 7;
        public const int BS_RADIOBUTTON = 4;
        public const int BST_CHECKED = 1;
        public const int BST_UNCHECKED = 0;
        public const int CB_ERR = -1;
        public const int CB_GETCOUNT = 0x146;
        public const int CB_GETCURSEL = 0x147;
        public const int CB_GETLBTEXT = 0x148;
        public const int CB_SELECTSTRING = 0x14d;
        public const int CB_SETCURSEL = 0x14e;
        public const int CBN_CLOSEUP = 8;
        public const int CBN_DBLCLK = 2;
        public const int CBN_DROPDOWN = 7;
        public const int CBN_EDITCHANGE = 5;
        public const int CBN_EDITUPDATE = 6;
        public const int CBN_KILLFOCUS = 4;
        public const int CBN_SELCHANGE = 1;
        public const int CBN_SELENDCANCEL = 10;
        public const int CBN_SELENDOK = 9;
        public const int CBN_SETFOCUS = 3;
        public const int CBS_AUTOHSCROLL = 0x40;
        public const int CBS_DISABLENOSCROLL = 0x800;
        public const int CBS_DROPDOWN = 2;
        public const int CBS_DROPDOWNLIST = 3;
        public const int CBS_HASSTRINGS = 0x200;
        public const int CBS_NOINTEGRALHEIGHT = 0x400;
        public const int CBS_OEMCONVERT = 0x80;
        public const int CBS_OWNERDRAWFIXED = 0x10;
        public const int CBS_OWNERDRAWVARIABLE = 0x20;
        public const int CBS_SIMPLE = 1;
        public const int CBS_SORT = 0x100;
        public const int CURSOR_SHOWING = 1;
        public const int EM_GETPASSWORDCHAR = 210;
        public const int EM_SETPASSWORDCHAR = 0xcc;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_ID = -12;
        public const int GWL_STYLE = -16;
        public const int HDM_FIRST = 0x1200;
        public const int HDM_GETITEMCOUNT = 0x1200;
        public const int HDM_GETITEMRECT = 0x1207;
        public static IntPtr HWND_TOP;
        public static IntPtr HWND_TOPMOST;
        public const int ID_DOCKBAR_AUTOHIDE = 0x3ea5;
        public const int ID_DOCKBAR_CLOSE = 0x3ea7;
        public const int ID_DOCKBAR_DOCK = 0x3ea8;
        public const int ID_DOCKBAR_UNDOCK = 0x3ea6;
        public const int IDOK = 11;
        public const int LB_ADDSTRING = 0x180;
        public const int LB_DELETESTRING = 0x182;
        public const int LB_GETCOUNT = 0x18b;
        public const int LB_GETCURSEL = 0x188;
        public const int LB_GETITEMHEIGHT = 0x1a1;
        public const int LB_GETITEMRECT = 0x198;
        public const int LB_GETTEXT = 0x189;
        public const int LB_GETTEXTLEN = 0x18a;
        public const int LB_SETCURSEL = 390;
        public const int LB_SETSEL = 0x185;
        public const int LB_SETTOPINDEX = 0x197;
        public const int LBS_EXTENDEDSEL = 0x800;
        public const int LBS_MULTIPLESEL = 8;
        public const int LBS_OWNERDRAWVARIABLE = 0x20;
        public const int LVIF_IMAGE = 2;
        public const int LVIF_INDENT = 0x10;
        public const int LVIF_NORECOMPUTE = 0x800;
        public const int LVIF_PARAM = 4;
        public const int LVIF_STATE = 8;
        public const int LVIF_TEXT = 1;
        public const int LVIR_BOUNDS = 0;
        public const int LVIS_ACTIVATING = 0x20;
        public const int LVIS_CUT = 4;
        public const int LVIS_DROPHILITED = 8;
        public const int LVIS_FOCUSED = 1;
        public const int LVIS_GLOW = 0x10;
        public const int LVIS_SELECTED = 2;
        public const int LVM_ENSUREVISIBLE = 0x1013;
        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETEDITCONTROL = 0x1018;
        public const int LVM_GETHEADER = 0x101f;
        public const int LVM_GETITEM = 0x104b;
        public const int LVM_GETITEMCOUNT = 0x1004;
        public const int LVM_GETITEMSTATE = 0x102c;
        public const int LVM_GETITEMTEXTW = 0x1073;
        public const int LVM_GETNEXTITEM = 0x100c;
        public const int LVM_GETSUBITEMRECT = 0x1038;
        public const int LVM_SETITEMSTATE = 0x102b;
        public const int LVM_SETITEMTEXT = 0x1074;
        public const int LVNI_ABOVE = 0x100;
        public const int LVNI_ALL = 0;
        public const int LVNI_BELOW = 0x200;
        public const int LVNI_CUT = 4;
        public const int LVNI_DROPHILITED = 8;
        public const int LVNI_FOCUSED = 1;
        public const int LVNI_SELECTED = 2;
        public const int LVNI_TOLEFT = 0x400;
        public const int LVNI_TORIGHT = 0x800;
        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RELEASE = 0x8000;
        public const int MEM_RESERVE = 0x2000;
        public const uint MF_BYPOSITION = 0x400;
        public const int PAGE_READWRITE = 4;
        public const int PROCESS_ALL_ACCESS = 0x1f0fff;
        public const int PROCESS_VM_OPERATION = 8;
        public const int PROCESS_VM_READ = 0x10;
        public const int PROCESS_VM_WRITE = 0x20;
        public const int PSM_GETCURRENTPAGEHWND = 0x476;
        public const int PSM_SETCURSEL = 0x465;
        public const int SC_CLOSE = 0xf060;
        public const int SC_MAXIMIZE = 0xf030;
        public const int SC_MINIMIZE = 0xf020;
        public const int SWP_NOACTIVATE = 0x10;
        public const int SWP_NOMOVE = 2;
        public const int SWP_SHOWWINDOW = 0x40;
        public const int TB_BUTTONCOUNT = 0x418;
        public const int TB_GETBUTTON = 0x417;
        public const int TB_GETBUTTONTEXT = 0x42d;
        public const int TB_GETITEMRECT = 0x41d;
        public const int TB_GETRECT = 0x433;
        public const int TB_GETSTYLE = 0x439;
        public const int TB_ISBUTTONCHECKED = 0x40a;
        public const int TB_ISBUTTONHIDDEN = 0x40c;
        public const int TBSTATE_CHECKED = 1;
        public const int TBSTYLE_BUTTON = 0;
        public const int TBSTYLE_CHECK = 2;
        public const int TBSTYLE_DROPDOWN = 8;
        public const int TBSTYLE_SEP = 1;
        public static int TCM_FIRST;
        public static int TCM_SETCURSEL;
        public const int TV_FIRST = 0x1100;
        public const int TVE_COLLAPSE = 1;
        public const int TVE_EXPAND = 2;
        public const int TVGN_CARET = 9;
        public const int TVGN_CHILD = 4;
        public const int TVGN_DROPHILITE = 8;
        public const int TVGN_NEXT = 1;
        public const int TVGN_PARENT = 3;
        public const int TVGN_ROOT = 0;
        public const int TVIF_HANDLE = 0x10;
        public const int TVIF_STATE = 8;
        public const int TVIF_TEXT = 1;
        public const int TVIS_SELECTED = 2;
        public const int TVIS_STATEIMAGEMASK = 0xf000;
        public const int TVM_EXPAND = 0x1102;
        public const int TVM_GETITEM = 0x113e;
        public const int TVM_GETITEMRECT = 0x1104;
        public const int TVM_GETITEMSTATE = 0x1127;
        public const int TVM_GETNEXTITEM = 0x110a;
        public const int TVM_SELECTITEM = 0x110b;
        public const int TVM_SETIMAGELIST = 0x1109;
        public const int TVM_SETITEM = 0x110d;
        public const int TVSIL_NORMAL = 0;
        public const int TVSIL_STATE = 2;
        public const int WM_ACTIVATE = 6;
        public const int WM_CLOSE = 0x10;
        public const int WM_COMMAND = 0x111;
        public const int WM_GETTEXT = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_SETTEXT = 12;
        public const int WM_SYSCOMMAND = 0x112;
        public const int WM_USER = 0x400;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static WindowMessage()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WindowMessage()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }
    }
}