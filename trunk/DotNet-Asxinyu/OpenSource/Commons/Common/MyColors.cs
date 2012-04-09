namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class MyColors
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ColorToDecimal(Color color)
        {
            return HexToDecimal(ColorToHex(color));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ColorToHex(Color color)
        {
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf60a), color.R, color.G, color.B);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color DecimalToColor(int dec)
        {
            return Color.FromArgb(dec & 0xff, (dec & 0xff00) / 0x100, dec / 0x10000);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DecimalToHex(int dec)
        {
            return dec.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf638));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color GetPixelColor(Point point)
        {
            Bitmap image = new Bitmap(1, 1);
            Graphics.FromImage(image).CopyFromScreen(point, new Point(0, 0), new Size(1, 1));
            return image.GetPixel(0, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color HexToColor(string hex)
        {
            if (hex.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf632)))
            {
                hex = hex.Substring(1);
            }
            string str = string.Empty;
            if (hex.Length == 8)
            {
                str = hex.Substring(0, 2);
                hex = hex.Substring(2);
            }
            string str2 = hex.Substring(0, 2);
            string str3 = hex.Substring(2, 2);
            string str4 = hex.Substring(4, 2);
            if (string.IsNullOrEmpty(str))
            {
                return Color.FromArgb(HexToDecimal(str2), HexToDecimal(str3), HexToDecimal(str4));
            }
            return Color.FromArgb(HexToDecimal(str), HexToDecimal(str2), HexToDecimal(str3), HexToDecimal(str4));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int HexToDecimal(string hex)
        {
            return Convert.ToInt32(hex, 0x10);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ModifyBrightness(Color c, double brightness)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Brightness *= brightness;
            return hsb.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ModifyHue(Color c, double Hue)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Hue *= Hue;
            return hsb.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ModifySaturation(Color c, double Saturation)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Saturation *= Saturation;
            return hsb.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color ParseColor(string color)
        {
            if (color.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf5fe)))
            {
                return HexToColor(color);
            }
            if (color.Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf604)))
            {
                string[] strArray = color.Split(new char[] { ',' });
                List<int> list = new List<int>();
                foreach (string str in strArray)
                {
                    list.Add(Convert.ToInt32(str));
                }
                int[] numArray = list.ToArray();
                if (numArray.Length == 3)
                {
                    return Color.FromArgb(numArray[0], numArray[1], numArray[2]);
                }
                if (numArray.Length == 4)
                {
                    return Color.FromArgb(numArray[0], numArray[1], numArray[2], numArray[3]);
                }
            }
            return Color.FromName(color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color RandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(0x100), random.Next(0x100), random.Next(0x100));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color SetBrightness(Color c, double brightness)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Brightness = brightness;
            return hsb.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color SetHue(Color c, double Hue)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Hue = Hue;
            return hsb.ToColor();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color SetSaturation(Color c, double Saturation)
        {
            HSB hsb = RGB.ToHSB(c);
            hsb.Saturation = Saturation;
            return hsb.ToColor();
        }
    }
}

