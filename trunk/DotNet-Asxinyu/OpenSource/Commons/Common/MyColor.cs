namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyColor
    {
        public WHC.OrderWater.Commons.RGB RGB;
        public WHC.OrderWater.Commons.HSB HSB;
        public WHC.OrderWater.Commons.CMYK CMYK;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyColor(Color color)
        {
            this.RGB = color;
            this.HSB = color;
            this.CMYK = color;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator MyColor(Color color)
        {
            return new MyColor(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator Color(MyColor color)
        {
            return (Color) color.RGB;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator ==(MyColor left, MyColor right)
        {
            return (((left.RGB == right.RGB) && (left.HSB == right.HSB)) && (left.CMYK == right.CMYK));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator !=(MyColor left, MyColor right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RGBUpdate()
        {
            this.HSB = (WHC.OrderWater.Commons.HSB) this.RGB;
            this.CMYK = (WHC.OrderWater.Commons.CMYK) this.RGB;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HSBUpdate()
        {
            this.RGB = (WHC.OrderWater.Commons.RGB) this.HSB;
            this.CMYK = (WHC.OrderWater.Commons.CMYK) this.HSB;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CMYKUpdate()
        {
            this.RGB = (WHC.OrderWater.Commons.RGB) this.CMYK;
            this.HSB = (WHC.OrderWater.Commons.HSB) this.CMYK;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string ToString()
        {
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf4e6), this.RGB, this.HSB, this.CMYK);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

