namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Timers;
    using System.Windows.Forms;

    public class SysTray : IDisposable
    {
        private Icon[] k1mUM9ocK;
        public Icon m_DefaultIcon;
        public NotifyIcon m_notifyIcon = new NotifyIcon();
        private Color MnvNdaLNh = Color.Black;
        private int nBCwVbEfB = 0;
        private Font r4vfcKJvu;
        private int snJo0QVxt = 0;
        private Timer yT4VNh4qe;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SysTray(string text, Icon icon, ContextMenu menu)
        {
            this.m_notifyIcon.Text = text;
            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.Icon = icon;
            this.m_DefaultIcon = icon;
            this.m_notifyIcon.ContextMenu = menu;
            this.r4vfcKJvu = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd5ea), 8f);
            this.yT4VNh4qe = new Timer();
            this.yT4VNh4qe.Interval = 100.0;
            this.yT4VNh4qe.Elapsed += new ElapsedEventHandler(this.qCpqRb2bV);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.m_notifyIcon.Dispose();
            if (this.r4vfcKJvu != null)
            {
                this.r4vfcKJvu.Dispose();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void qCpqRb2bV(object, ElapsedEventArgs)
        {
            if (this.snJo0QVxt < this.k1mUM9ocK.Length)
            {
                this.m_notifyIcon.Icon = this.k1mUM9ocK[this.snJo0QVxt];
                this.snJo0QVxt++;
            }
            else
            {
                this.snJo0QVxt = 0;
                if (this.nBCwVbEfB <= 0)
                {
                    this.yT4VNh4qe.Stop();
                    this.m_notifyIcon.Icon = this.m_DefaultIcon;
                }
                else
                {
                    this.nBCwVbEfB--;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetAnimationClip(Bitmap bitmapStrip)
        {
            try
            {
                this.k1mUM9ocK = new Icon[bitmapStrip.Width / 0x10];
                for (int i = 0; i < this.k1mUM9ocK.Length; i++)
                {
                    Rectangle rect = new Rectangle(i * 0x10, 0, 0x10, 0x10);
                    this.k1mUM9ocK[i] = Icon.FromHandle(bitmapStrip.Clone(rect, bitmapStrip.PixelFormat).GetHicon());
                }
            }
            catch (Exception)
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetAnimationClip(Bitmap[] bitmap)
        {
            try
            {
                this.k1mUM9ocK = new Icon[bitmap.Length];
                for (int i = 0; i < bitmap.Length; i++)
                {
                    this.k1mUM9ocK[i] = Icon.FromHandle(bitmap[i].GetHicon());
                }
            }
            catch (Exception)
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetAnimationClip(Icon[] icons)
        {
            this.k1mUM9ocK = icons;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ShowText(string text)
        {
            this.ShowText(text, this.r4vfcKJvu, this.MnvNdaLNh);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ShowText(string text, Color col)
        {
            this.ShowText(text, this.r4vfcKJvu, col);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ShowText(string text, Font font)
        {
            this.ShowText(text, font, this.MnvNdaLNh);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ShowText(string text, Font font, Color col)
        {
            Bitmap image = new Bitmap(0x10, 0x10);
            Brush brush = new SolidBrush(col);
            Graphics.FromImage(image).DrawString(text, this.r4vfcKJvu, brush, (float) 0f, (float) 0f);
            Icon icon = Icon.FromHandle(image.GetHicon());
            this.m_notifyIcon.Icon = icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void StartAnimation(int interval, int loopCount)
        {
            if (this.k1mUM9ocK == null)
            {
                throw new ApplicationException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd600));
            }
            this.nBCwVbEfB = loopCount;
            this.yT4VNh4qe.Interval = interval;
            this.yT4VNh4qe.Start();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void StopAnimation()
        {
            this.yT4VNh4qe.Stop();
        }
    }
}

