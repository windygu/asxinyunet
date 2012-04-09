namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using tpgDkGqZn20HfF3nSQN;

    [StructLayout(LayoutKind.Sequential)]
    public struct CMYK
    {
        private double VZJq3SjrW;
        private double JkKfoMY5A;
        private double AWbNwkBdU;
        private double wKyWxGToc;
        public double Cyan
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
        public double Cyan100
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.VZJq3SjrW * 100.0);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.VZJq3SjrW = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value / 100.0);
            }
        }
        public double Magenta
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
        public double Magenta100
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
        public double Yellow
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
        public double Yellow100
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
        public double Key
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.wKyWxGToc;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.wKyWxGToc = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value);
            }
        }
        public double Key100
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.wKyWxGToc * 100.0);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.wKyWxGToc = qNZKolqcUaJXxWIDdpK.VZJq3SjrW(value / 100.0);
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public CMYK(double cyan, double magenta, double yellow, double key)
        {
            this = new CMYK();
            this.Cyan = cyan;
            this.Magenta = magenta;
            this.Yellow = yellow;
            this.Key = key;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public CMYK(int cyan, int magenta, int yellow, int key)
        {
            this = new CMYK();
            this.Cyan100 = cyan;
            this.Magenta100 = magenta;
            this.Yellow100 = yellow;
            this.Key100 = key;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public CMYK(Color color)
        {
            this = RGB.ToCMYK(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator CMYK(Color color)
        {
            return RGB.ToCMYK(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator Color(CMYK color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator RGB(CMYK color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static implicit operator HSB(CMYK color)
        {
            return color.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator ==(CMYK left, CMYK right)
        {
            return ((((left.Cyan == right.Cyan) && (left.Magenta == right.Magenta)) && (left.Yellow == right.Yellow)) && (left.Key == right.Key));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool operator !=(CMYK left, CMYK right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string ToString()
        {
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf59e), new object[] { qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Cyan100), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Magenta100), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Yellow100), qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(this.Key100) });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ToColor(CMYK cmyk)
        {
            int red = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(255.0 - (255.0 * cmyk.Cyan));
            int green = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(255.0 - (255.0 * cmyk.Magenta));
            int blue = qNZKolqcUaJXxWIDdpK.NMPUAbUfQ(255.0 - (255.0 * cmyk.Yellow));
            return Color.FromArgb(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ToColor(double cyan, double magenta, double yellow, double key)
        {
            return ToColor(new CMYK(cyan, magenta, yellow, key));
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

