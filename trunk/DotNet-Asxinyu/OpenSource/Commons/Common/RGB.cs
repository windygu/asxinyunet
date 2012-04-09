namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using tpgDkGqZn20HfF3nSQN;

    [StructLayout(LayoutKind.Sequential)]
    public struct RGB
    {
        private int VZJq3SjrW;
        private int JkKfoMY5A;
        private int AWbNwkBdU;
        public int Red
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.VZJq3SjrW;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.VZJq3SjrW = qNZKolqcUaJXxWIDdpK.JkKfoMY5A(value);
            }
        }
        public int Green
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.JkKfoMY5A;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.JkKfoMY5A = qNZKolqcUaJXxWIDdpK.JkKfoMY5A(value);
            }
        }
        public int Blue
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AWbNwkBdU;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.AWbNwkBdU = qNZKolqcUaJXxWIDdpK.JkKfoMY5A(value);
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public RGB(int red, int green, int blue)
        {
            this = new RGB();
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public RGB(Color color)
        {
            this = new RGB(color.R, color.G, color.B);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator RGB(Color color)
        {
            return new RGB(color.R, color.G, color.B);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator Color(RGB color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator HSB(RGB color)
        {
            return color.ToHSB();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator CMYK(RGB color)
        {
            return color.ToCMYK();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator ==(RGB left, RGB right)
        {
            return (((left.Red == right.Red) && (left.Green == right.Green)) && (left.Blue == right.Blue));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator !=(RGB left, RGB right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string ToString()
        {
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf504), this.Red, this.Green, this.Blue);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ToColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Color ToColor()
        {
            return ToColor(this.Red, this.Green, this.Blue);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static HSB ToHSB(Color color)
        {
            int r;
            int g;
            double num4;
            HSB hsb = new HSB();
            if (color.R > color.G)
            {
                r = color.R;
                g = color.G;
            }
            else
            {
                r = color.G;
                g = color.R;
            }
            if (color.B > r)
            {
                r = color.B;
            }
            else if (color.B < g)
            {
                g = color.B;
            }
            int num3 = r - g;
            hsb.Brightness = ((double) r) / 255.0;
            if (r == 0)
            {
                hsb.Saturation = 0.0;
            }
            else
            {
                hsb.Saturation = ((double) num3) / ((double) r);
            }
            if (num3 == 0)
            {
                num4 = 0.0;
            }
            else
            {
                num4 = 60.0 / ((double) num3);
            }
            if (r == color.R)
            {
                if (color.G < color.B)
                {
                    hsb.Hue = (360.0 + (num4 * (color.G - color.B))) / 360.0;
                    return hsb;
                }
                hsb.Hue = (num4 * (color.G - color.B)) / 360.0;
                return hsb;
            }
            if (r == color.G)
            {
                hsb.Hue = (120.0 + (num4 * (color.B - color.R))) / 360.0;
                return hsb;
            }
            if (r == color.B)
            {
                hsb.Hue = (240.0 + (num4 * (color.R - color.G))) / 360.0;
                return hsb;
            }
            hsb.Hue = 0.0;
            return hsb;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public unsafe HSB ToHSB()
        {
            return ToHSB(*((Color*) this));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CMYK ToCMYK(Color color)
        {
            CMYK cmyk = new CMYK();
            double cyan = 1.0;
            cmyk.Cyan = ((double) (0xff - color.R)) / 255.0;
            if (cyan > cmyk.Cyan)
            {
                cyan = cmyk.Cyan;
            }
            cmyk.Magenta = ((double) (0xff - color.G)) / 255.0;
            if (cyan > cmyk.Magenta)
            {
                cyan = cmyk.Magenta;
            }
            cmyk.Yellow = ((double) (0xff - color.B)) / 255.0;
            if (cyan > cmyk.Yellow)
            {
                cyan = cmyk.Yellow;
            }
            if (cyan > 0.0)
            {
                cmyk.Key = cyan;
            }
            return cmyk;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public unsafe CMYK ToCMYK()
        {
            return ToCMYK(*((Color*) this));
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

