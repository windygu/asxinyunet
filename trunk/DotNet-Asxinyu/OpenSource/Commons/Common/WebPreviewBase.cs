namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using kAwOPFA4msiGtf5Jo4;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class WebPreviewBase : IDisposable
    {
        private System.Uri 01FqmBarm = new System.Uri(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x867e));
        private WebBrowser 4bccOhnfl = new WebBrowser();
        private int dT3f0t4t3 = 0x400;
        private bool TEPULnwMP = false;
        private int yTHMJ858G = 0x300;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WebPreviewBase(System.Uri uri, int thumbW, int thumbH, bool fullpage)
        {
            this.4bccOhnfl.ScriptErrorsSuppressed = false;
            this.4bccOhnfl.ScrollBarsEnabled = false;
            this.4bccOhnfl.Size = new Size(0x400, 0x300);
            this.4bccOhnfl.NewWindow += new System.ComponentModel.CancelEventHandler(this.CancelEventHandler);
            this.dT3f0t4t3 = thumbW;
            this.yTHMJ858G = thumbH;
            this.01FqmBarm = uri;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelEventHandler(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.4bccOhnfl.Dispose();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Bitmap GetWebPreview()
        {
            Bitmap bitmap2;
            int width = this.4bccOhnfl.Width;
            int height = this.4bccOhnfl.Height;
            Size size = this.4bccOhnfl.Size;
            if (this.TEPULnwMP)
            {
                height = this.4bccOhnfl.Document.Body.ScrollRectangle.Height;
                width = this.4bccOhnfl.Document.Body.ScrollRectangle.Width;
            }
            if (width < this.dT3f0t4t3)
            {
                width = this.dT3f0t4t3;
            }
            if (height < size.Height)
            {
                height = size.Height;
            }
            this.4bccOhnfl.Size = new Size(width, height);
            try
            {
                this.InitComobject();
                yGmDTAx2hCKIuH4LPl pl = new yGmDTAx2hCKIuH4LPl();
                Bitmap bitmap = (Bitmap) ImageHelper.ResizeImageToAFixedSize(pl.01FqmBarm(this.4bccOhnfl.ActiveXInstance, new Rectangle(0, 0, width, height)), this.dT3f0t4t3, this.yTHMJ858G, ImageHelper.ScaleMode.W);
                bitmap2 = bitmap;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return bitmap2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void InitComobject()
        {
            try
            {
                this.4bccOhnfl.Navigate(this.01FqmBarm);
                while (this.4bccOhnfl.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                this.4bccOhnfl.Stop();
                if (this.4bccOhnfl.ActiveXInstance == null)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8698));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int ThumbH
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.yTHMJ858G;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.yTHMJ858G = value;
            }
        }

        public int ThumbW
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.dT3f0t4t3 = value;
            }
        }

        public System.Uri Uri
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.01FqmBarm;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.01FqmBarm = value;
            }
        }
    }
}

