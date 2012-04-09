namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CallCtrlWithThreadSafety
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetChecked<TObject>(TObject objCtrl, bool isChecked, Form winf) where TObject: CheckBox
        {
            if (objCtrl.InvokeRequired)
            {
                yrQPLRH4GtvFcIsA63 method = new yrQPLRH4GtvFcIsA63(CallCtrlWithThreadSafety.SetChecked<CheckBox>);
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetEnable<TObject>(TObject objCtrl, bool enable, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                xIsDT4kN0TkpGA0Ao0 method = new xIsDT4kN0TkpGA0Ao0(CallCtrlWithThreadSafety.SetEnable<Control>);
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetFocus<TObject>(TObject objCtrl, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                Djtgax3cpTfOn4BA0c method = new Djtgax3cpTfOn4BA0c(CallCtrlWithThreadSafety.SetFocus<Control>);
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetText<TObject>(TObject objCtrl, string text, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                XwVH58WGeKTNx45cOM method = new XwVH58WGeKTNx45cOM(CallCtrlWithThreadSafety.SetText<Control>);
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetText2<TObject>(TObject objCtrl, string text, Form winf) where TObject: ToolStripStatusLabel
        {
            if (objCtrl.Owner.InvokeRequired)
            {
                Q9ZERfJHedtrZW7dcm method = new Q9ZERfJHedtrZW7dcm(CallCtrlWithThreadSafety.SetText2<ToolStripStatusLabel>);
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetVisible<TObject>(TObject objCtrl, bool isVisible, Form winf) where TObject: Control
        {
            if (objCtrl.InvokeRequired)
            {
                yrQPLRH4GtvFcIsA63 method = new yrQPLRH4GtvFcIsA63(CallCtrlWithThreadSafety.SetChecked<CheckBox>);
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

        private delegate void Djtgax3cpTfOn4BA0c(Control, Form);

        private delegate void Q9ZERfJHedtrZW7dcm(ToolStripStatusLabel, string, Form);

        private delegate void xIsDT4kN0TkpGA0Ao0(Control, bool, Form);

        private delegate void XwVH58WGeKTNx45cOM(Control, string, Form);

        private delegate void yrQPLRH4GtvFcIsA63(CheckBox, bool, Form);
    }
}

