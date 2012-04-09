namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SafeToolStripLabel : ToolStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
        private string qCpqRb2bV()
        {
            return base.Text;
        }

        [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
        private void r4vfcKJvu(string text1)
        {
            base.Text = text1;
        }

        public override string Text
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                mVLnlfqonIX5Wgo7p5B wgopb2 = null;
                if ((base.Parent != null) && base.Parent.InvokeRequired)
                {
                    if (wgopb2 == null)
                    {
                        wgopb2 = new mVLnlfqonIX5Wgo7p5B(this.qCpqRb2bV);
                    }
                    mVLnlfqonIX5Wgo7p5B method = wgopb2;
                    string str = string.Empty;
                    try
                    {
                        str = (string) base.Parent.Invoke(method, null);
                    }
                    catch
                    {
                    }
                    return str;
                }
                return base.Text;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                xDkQ1MqNbm1pHGHjgHf hf2 = null;
                if ((base.Parent != null) && base.Parent.InvokeRequired)
                {
                    if (hf2 == null)
                    {
                        hf2 = new xDkQ1MqNbm1pHGHjgHf(this.r4vfcKJvu);
                    }
                    xDkQ1MqNbm1pHGHjgHf method = hf2;
                    try
                    {
                        base.Parent.Invoke(method, new object[] { value });
                    }
                    catch
                    {
                    }
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        private delegate string mVLnlfqonIX5Wgo7p5B();

        private delegate void xDkQ1MqNbm1pHGHjgHf(string);
    }
}

