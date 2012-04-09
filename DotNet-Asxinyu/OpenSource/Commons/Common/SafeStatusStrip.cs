namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SafeStatusStrip : StatusStrip
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SafeSetText(ToolStripLabel toolStripLabel, string text)
        {
            hxpIAeoYP8k3f901Da da2 = null;
            if (base.InvokeRequired)
            {
                if (da2 == null)
                {
                    da2 = new hxpIAeoYP8k3f901Da(this.t00qRSolC);
                }
                hxpIAeoYP8k3f901Da method = da2;
                try
                {
                    base.Invoke(method, new object[] { toolStripLabel, text });
                }
                catch
                {
                }
            }
            else
            {
                foreach (ToolStripItem item in base.Items)
                {
                    if (item == toolStripLabel)
                    {
                        item.Text = text;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
        private void t00qRSolC(ToolStripLabel label1, string text1)
        {
            foreach (ToolStripItem item in base.Items)
            {
                if (item == label1)
                {
                    item.Text = text1;
                }
            }
        }

        private delegate void hxpIAeoYP8k3f901Da(ToolStripLabel, string);
    }
}

