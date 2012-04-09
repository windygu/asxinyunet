namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;

    public static class Extensions
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DrawImbeddedImage<T>(IEnumerable<T> list, Graphics g, int pagewidth, int pageheight, Margins margins)
        {
            foreach (T local in list)
            {
                if (local.GetType() == typeof(DGVPrinter.ImbeddedImage))
                {
                    DGVPrinter.ImbeddedImage image = (DGVPrinter.ImbeddedImage) Convert.ChangeType(local, typeof(DGVPrinter.ImbeddedImage));
                    g.DrawImageUnscaled(image.theImage, image.mUvqAX6rk(pagewidth, pageheight, margins));
                }
            }
        }
    }
}

