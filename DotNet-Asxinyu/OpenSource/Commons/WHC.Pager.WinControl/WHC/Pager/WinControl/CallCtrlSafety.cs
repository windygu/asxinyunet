namespace WHC.Pager.WinControl
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CallCtrlSafety
    {
        public static void SetChecked<TObject>(TObject objCtrl, bool isChecked, Form winf) where TObject: CheckBox
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate2 method = new Delegate2(CallCtrlSafety.SetChecked<CheckBox>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, isChecked, winf });
                }
            }
            else
            {
                objCtrl.Checked = isChecked;
            }
        }

        public static void SetEnable<TObject>(TObject objCtrl, bool enable, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate4 method = new Delegate4(CallCtrlSafety.SetEnable<Control>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, enable, winf });
                }
            }
            else
            {
                objCtrl.Enabled = enable;
            }
        }

        public static void SetFocus<TObject>(TObject objCtrl, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate3 method = new Delegate3(CallCtrlSafety.SetFocus<Control>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, winf });
                }
            }
            else
            {
                objCtrl.Focus();
            }
        }

        public static void SetText<TObject>(TObject objCtrl, string text, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate5 method = new Delegate5(CallCtrlSafety.SetText<Control>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, text, winf });
                }
            }
            else
            {
                objCtrl.Text = text;
            }
        }

        public static void SetValue<TObject>(TObject objCtrl, int value, Form winf) where TObject: ProgressBar
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate0 method = new Delegate0(CallCtrlSafety.SetValue<ProgressBar>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, value, winf });
                }
            }
            else
            {
                objCtrl.Value = value;
            }
        }

        public static void SetVisible<TObject>(TObject objCtrl, bool isVisible, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                Delegate1 method = new Delegate1(CallCtrlSafety.SetVisible<Control>);
                if (!winf.IsDisposed)
                {
                    winf.Invoke(method, new object[] { objCtrl, isVisible, winf });
                }
            }
            else
            {
                objCtrl.Visible = isVisible;
            }
        }

        private delegate void Delegate0(ProgressBar progressBar_0, int int_0, Form form_0);

        private delegate void Delegate1(Control control_0, bool bool_0, Form form_0);

        private delegate void Delegate2(CheckBox checkBox_0, bool bool_0, Form form_0);

        private delegate void Delegate3(Control control_0, Form form_0);

        private delegate void Delegate4(Control control_0, bool bool_0, Form form_0);

        private delegate void Delegate5(Control control_0, string string_0, Form form_0);
    }
}

