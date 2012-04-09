namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using tpgDkGqZn20HfF3nSQN;

    [StructLayout(LayoutKind.Sequential)]
    public struct HSB
    {
        private double VZJq3SjrW;
        private double JkKfoMY5A;
        private double AWbNwkBdU;
        public double Hue
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.VZJq3SjrW;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.VZJq3SjrW = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value);
            }
        }
        public double Hue360
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.VZJq3SjrW * 360.0);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.VZJq3SjrW = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value / 360.0);
            }
        }
        public double Saturation
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.JkKfoMY5A;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.JkKfoMY5A = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value);
            }
        }
        public double Saturation100
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.JkKfoMY5A * 100.0);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.JkKfoMY5A = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value / 100.0);
            }
        }
        public double Brightness
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AWbNwkBdU;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.AWbNwkBdU = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value);
            }
        }
        public double Brightness100
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.AWbNwkBdU * 100.0);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.AWbNwkBdU = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value / 100.0);
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public HSB(double hue, double saturation, double brightness)
        {
            this = new HSB();
            this.Hue = hue;
            this.Saturation = saturation;
            this.Brightness = brightness;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HSB(int hue, int saturation, int brightness)
        {
            this = new HSB();
            this.Hue360 = hue;
            this.Saturation100 = saturation;
            this.Brightness100 = brightness;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public HSB(Color color)
        {
            this = RGB.ToHSB(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator HSB(Color color)
        {
            return RGB.ToHSB(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator Color(HSB color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator RGB(HSB color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator CMYK(HSB color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator ==(HSB left, HSB right)
        {
            return (((left.Hue == right.Hue) && (left.Saturation == right.Saturation)) && (left.Brightness == right.Brightness));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator !=(HSB left, HSB right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string ToString()
        {
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf546), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Hue360), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Saturation100), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Brightness100));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ToColor(HSB hsb)
        {
            int num;
            int red = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(hsb.Brightness * 255.0);
            int blue = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(((1.0 - hsb.Saturation) * (hsb.Brightness / 1.0)) * 255.0);
            double num4 = ((double) (red - blue)) / 255.0;
            if ((hsb.Hue >= 0.0) && (hsb.Hue <= 0.16666666666666666))
            {
                num = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((((hsb.Hue - 0.0) * num4) * 1530.0) + blue);
                return Color.FromArgb(red, num, blue);
            }
            if (hsb.Hue <= 0.33333333333333331)
            {
                return Color.FromArgb(qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((-((hsb.Hue - 0.16666666666666666) * num4) * 1530.0) + red), red, blue);
            }
            if (hsb.Hue <= 0.5)
            {
                num = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((((hsb.Hue - 0.33333333333333331) * num4) * 1530.0) + blue);
                return Color.FromArgb(blue, red, num);
            }
            if (hsb.Hue <= 0.66666666666666663)
            {
                num = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((-((hsb.Hue - 0.5) * num4) * 1530.0) + red);
                return Color.FromArgb(blue, num, red);
            }
            if (hsb.Hue <= 0.83333333333333337)
            {
                return Color.FromArgb(qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((((hsb.Hue - 0.66666666666666663) * num4) * 1530.0) + blue), blue, red);
            }
            if (hsb.Hue <= 1.0)
            {
                num = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ((-((hsb.Hue - 0.83333333333333337) * num4) * 1530.0) + red);
                return Color.FromArgb(red, blue, num);
            }
            return Color.FromArgb(0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ToColor(double hue, double saturation, double brightness)
        {
            return ToColor(new HSB(hue, saturation, brightness));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Color ToColor()
        {
            return ToColor(this);
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

