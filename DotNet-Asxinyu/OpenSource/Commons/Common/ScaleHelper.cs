namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class ScaleHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static RectangleF GetAlignedRectangle(RectangleF currentRect, RectangleF targetRect, ContentAlignment alignment)
        {
            RectangleF ef = new RectangleF(targetRect.Location, currentRect.Size);
            ContentAlignment alignment2 = alignment;
            if (alignment2 <= ContentAlignment.MiddleCenter)
            {
                switch (alignment2)
                {
                    case ContentAlignment.TopCenter:
                        ef.X = (targetRect.Width - currentRect.Width) / 2f;
                        return ef;

                    case (ContentAlignment.TopCenter | ContentAlignment.TopLeft):
                        return ef;

                    case ContentAlignment.TopRight:
                        ef.X = targetRect.Width - currentRect.Width;
                        return ef;

                    case ContentAlignment.MiddleLeft:
                        ef.Y = (targetRect.Height - currentRect.Height) / 2f;
                        return ef;

                    case ContentAlignment.MiddleCenter:
                        ef.Y = (targetRect.Height - currentRect.Height) / 2f;
                        ef.X = (targetRect.Width - currentRect.Width) / 2f;
                        return ef;
                }
                return ef;
            }
            if (alignment2 <= ContentAlignment.BottomLeft)
            {
                switch (alignment2)
                {
                    case ContentAlignment.MiddleRight:
                        ef.Y = (targetRect.Height - currentRect.Height) / 2f;
                        ef.X = targetRect.Width - currentRect.Width;
                        return ef;

                    case ContentAlignment.BottomLeft:
                        ef.Y = targetRect.Height - currentRect.Height;
                        return ef;
                }
                return ef;
            }
            switch (alignment2)
            {
                case ContentAlignment.BottomCenter:
                    ef.Y = targetRect.Height - currentRect.Height;
                    ef.X = (targetRect.Width - currentRect.Width) / 2f;
                    return ef;

                case ContentAlignment.BottomRight:
                    ef.Y = targetRect.Height - currentRect.Height;
                    ef.X = targetRect.Width - currentRect.Width;
                    return ef;
            }
            return ef;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static RectangleF GetScaledRectangle(RectangleF currentRect, RectangleF targetRect, bool crop, ContentAlignment alignment)
        {
            SizeF size = GetScaledSize(currentRect.Size, targetRect.Size, crop);
            RectangleF ef2 = new RectangleF((PointF) new Point(0, 0), size);
            return GetAlignedRectangle(ef2, targetRect, alignment);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static SizeF GetScaledSize(SizeF currentSize, SizeF targetSize, bool crop)
        {
            float num = targetSize.Width / currentSize.Width;
            float num2 = targetSize.Height / currentSize.Height;
            float num3 = crop ? Math.Max(num, num2) : Math.Min(num, num2);
            return new SizeF(currentSize.Width * num3, currentSize.Height * num3);
        }
    }
}

