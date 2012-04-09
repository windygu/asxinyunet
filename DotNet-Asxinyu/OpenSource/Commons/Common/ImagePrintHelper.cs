namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ImagePrintHelper
    {
        public bool AllowPrintCenter;
        public bool AllowPrintEnlarge;
        public bool AllowPrintRotate;
        public bool AllowPrintShrink;
        private PrintDialog k1mUM9ocK;
        private PrintDocument MnvNdaLNh;
        private Image r4vfcKJvu;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ImagePrintHelper(Image image) : this(image, "")
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ImagePrintHelper(Image image, string documentname)
        {
            this.MnvNdaLNh = new PrintDocument();
            this.k1mUM9ocK = new PrintDialog();
            this.AllowPrintCenter = true;
            this.AllowPrintRotate = true;
            this.AllowPrintEnlarge = true;
            this.AllowPrintShrink = true;
            this.r4vfcKJvu = (Image) image.Clone();
            this.k1mUM9ocK.UseEXDialog = true;
            this.MnvNdaLNh.DocumentName = documentname;
            this.MnvNdaLNh.PrintPage += new PrintPageEventHandler(this.qCpqRb2bV);
            this.k1mUM9ocK.Document = this.MnvNdaLNh;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public PrinterSettings PrintWithDialog()
        {
            if (this.k1mUM9ocK.ShowDialog() == DialogResult.OK)
            {
                this.MnvNdaLNh.Print();
                return this.k1mUM9ocK.PrinterSettings;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void qCpqRb2bV(object, PrintPageEventArgs args1)
        {
            ContentAlignment topRight = this.AllowPrintCenter ? ContentAlignment.MiddleCenter : ContentAlignment.TopLeft;
            RectangleF printableArea = args1.PageSettings.PrintableArea;
            GraphicsUnit pixel = GraphicsUnit.Pixel;
            RectangleF bounds = this.r4vfcKJvu.GetBounds(ref pixel);
            if (this.AllowPrintRotate && (((printableArea.Width > printableArea.Height) && (bounds.Width < bounds.Height)) || ((printableArea.Width < printableArea.Height) && (bounds.Width > bounds.Height))))
            {
                this.r4vfcKJvu.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bounds = this.r4vfcKJvu.GetBounds(ref pixel);
                if (topRight.Equals(ContentAlignment.TopLeft))
                {
                    topRight = ContentAlignment.TopRight;
                }
            }
            RectangleF currentRect = new RectangleF(0f, 0f, bounds.Width, bounds.Height);
            if (this.AllowPrintEnlarge || this.AllowPrintShrink)
            {
                SizeF ef4 = ScaleHelper.GetScaledSize(bounds.Size, printableArea.Size, false);
                if ((this.AllowPrintShrink && (ef4.Width < currentRect.Width)) || (this.AllowPrintEnlarge && (ef4.Width > currentRect.Width)))
                {
                    currentRect.Size = ef4;
                }
            }
            currentRect = ScaleHelper.GetAlignedRectangle(currentRect, new RectangleF(0f, 0f, printableArea.Width, printableArea.Height), topRight);
            args1.Graphics.DrawImage(this.r4vfcKJvu, currentRect, bounds, GraphicsUnit.Pixel);
        }
    }
}

