namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class WebPreview
    {
        private Exception 4bccOhnfl;
        private int Dr0wrInQN;
        private int MEWIXKqxt;
        private int mNaPlOfPN;
        private Bitmap TEPULnwMP;
        private bool XHHQ5xBgx;
        private Uri yTHMJ858G;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private WebPreview(Uri uri) : this(uri, 0x7530, 200, 150, true)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private WebPreview(Uri uri, int timeout, int width, int height, bool fullPage)
        {
            this.yTHMJ858G = null;
            this.4bccOhnfl = null;
            this.TEPULnwMP = null;
            this.MEWIXKqxt = 0x7530;
            this.Dr0wrInQN = 200;
            this.mNaPlOfPN = 150;
            this.XHHQ5xBgx = true;
            this.yTHMJ858G = uri;
            this.MEWIXKqxt = timeout;
            this.Dr0wrInQN = width;
            this.mNaPlOfPN = height;
            this.XHHQ5xBgx = fullPage;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal Bitmap 01FqmBarm()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(WebPreview.dT3f0t4t3));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(this);
            if (!thread.Join(this.MEWIXKqxt))
            {
                thread.Abort();
                throw new TimeoutException();
            }
            if (this.4bccOhnfl != null)
            {
                throw this.4bccOhnfl;
            }
            if (this.TEPULnwMP == null)
            {
                throw new ExecutionEngineException();
            }
            return this.TEPULnwMP;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(object obj1)
        {
            WebPreview preview = (WebPreview) obj1;
            try
            {
                preview.TEPULnwMP = new WebPreviewBase(preview.yTHMJ858G, preview.Dr0wrInQN, preview.mNaPlOfPN, preview.XHHQ5xBgx).GetWebPreview();
            }
            catch (Exception exception)
            {
                preview.4bccOhnfl = exception;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap GetWebPreview(Uri uri)
        {
            WebPreview preview = new WebPreview(uri);
            return preview.01FqmBarm();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap GetWebPreview(Uri uri, int timeout, int width, int height, bool fullPage)
        {
            WebPreview preview = new WebPreview(uri, timeout, width, height, fullPage);
            return preview.01FqmBarm();
        }
    }
}

