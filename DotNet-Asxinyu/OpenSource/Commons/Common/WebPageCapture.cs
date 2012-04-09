namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class WebPageCapture : IDisposable
    {
        private WebBrowser 3xodQsKC6;
        [CompilerGenerated]
        private Size eMSUYugy4;
        [CompilerGenerated]
        private System.Drawing.Image Um5wSC5ZO;
        [CompilerGenerated]
        private string y3vHWmTuH;

        public event ImageEventHandler DownloadCompleted;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WebPageCapture() : this(Screen.PrimaryScreen.Bounds.Size)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WebPageCapture(Size browserSize)
        {
            this.3xodQsKC6 = new WebBrowser();
            this.BrowserSize = browserSize;
            this.3xodQsKC6.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.XxQqQ66mW);
            this.3xodQsKC6.ScrollBarsEnabled = false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public WebPageCapture(int width, int height) : this(new Size(width, height))
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.Image.Dispose();
            this.3xodQsKC6.Dispose();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void DownloadPage()
        {
            if (!string.IsNullOrEmpty(this.URL))
            {
                this.DownloadPage(this.URL);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void DownloadPage(string url)
        {
            this.URL = url;
            this.3xodQsKC6.Size = this.BrowserSize;
            this.3xodQsKC6.Navigate(url);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XxQqQ66mW(object, WebBrowserDocumentCompletedEventArgs)
        {
            Rectangle scrollRectangle = this.3xodQsKC6.Document.ActiveElement.ScrollRectangle;
            this.3xodQsKC6.Size = new Size(scrollRectangle.Width, scrollRectangle.Height);
            Bitmap bitmap = new Bitmap(scrollRectangle.Width, scrollRectangle.Height);
            try
            {
                this.3xodQsKC6.DrawToBitmap(bitmap, scrollRectangle);
                this.EPgfA8o8U(bitmap);
            }
            finally
            {
                if (this.hudMECjTG != null)
                {
                    this.hudMECjTG(bitmap);
                }
            }
        }

        public Size BrowserSize
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.eMSUYugy4;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.eMSUYugy4 = value;
            }
        }

        public System.Drawing.Image Image
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.Um5wSC5ZO;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            private set
            {
                this.Um5wSC5ZO = value;
            }
        }

        public string URL
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.y3vHWmTuH;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.y3vHWmTuH = value;
            }
        }

        public delegate void ImageEventHandler(Image image);
    }
}

