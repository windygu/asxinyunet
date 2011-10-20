namespace EntLib.Controls.WinForm
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [Designer(typeof(RealBoxDesigner))]
    public class RealBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern bool MessageBeep(uint uType);
        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            int keyValue = m.WParam.ToInt32();
            if (keyValue > 0x2f && keyValue < 0x3a || keyValue == 0x2e || keyValue > 0x22 && keyValue < 0x29 || keyValue == 8) return base.ProcessKeyEventArgs(ref m);
            if (m.Msg == 0x100 && keyValue == 0x2e) return base.ProcessKeyEventArgs(ref m);
            if (m.Msg == 0x102) MessageBeep(0);
            return true;
        }

        internal class RealBoxDesigner : ControlDesigner
        {
            protected override void PostFilterProperties(IDictionary properties) { properties.Remove("Text"); }
        }
    }
}
