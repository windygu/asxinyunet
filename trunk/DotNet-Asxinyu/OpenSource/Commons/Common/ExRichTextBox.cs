namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class ExRichTextBox : RichTextBox
    {
        private const string 2vmmTnc0v = @"\cf0\fs17}";
        private float 7bs1C4L14;
        private const int 8uCAFu7G9 = 5;
        private const string cfet2CjTw = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052";
        private float fZ2giAleG;
        private HybridDictionary j5RJt5QvR;
        private const int JkV3bN1e5 = 0x9ec;
        private const int Jp8iM6sr0 = 6;
        private string kSYpyOBWG;
        private const int liwd14CbV = 0x5a0;
        private const string mbW5ICfuE = "UNKNOWN";
        private const string Mix8sALJw = @"\viewkind4\uc1\pard\lang2052\cf1\f0\fs20";
        private const int mNaPlOfPN = 1;
        private const int ObPBQJZIg = 4;
        private const int PJdOHnUDg = 3;
        private const int pNCXMUwUj = 8;
        private const int qL726f2M6 = 7;
        private RtfColor qQ4kDvXcA;
        private HybridDictionary VLQ03a4aV;
        private const int XHHQ5xBgx = 2;
        private RtfColor Z9JEQuyJT;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ExRichTextBox()
        {
            this.kSYpyOBWG = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaee0);
            this.qQ4kDvXcA = RtfColor.Black;
            this.Z9JEQuyJT = RtfColor.White;
            this.j5RJt5QvR = new HybridDictionary();
            this.j5RJt5QvR.Add(RtfColor.Aqua, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaee6));
            this.j5RJt5QvR.Add(RtfColor.Black, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf16));
            this.j5RJt5QvR.Add(RtfColor.Blue, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf3e));
            this.j5RJt5QvR.Add(RtfColor.Fuchsia, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf6a));
            this.j5RJt5QvR.Add(RtfColor.Gray, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf9a));
            this.j5RJt5QvR.Add(RtfColor.Green, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xafce));
            this.j5RJt5QvR.Add(RtfColor.Lime, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaffa));
            this.j5RJt5QvR.Add(RtfColor.Maroon, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb026));
            this.j5RJt5QvR.Add(RtfColor.Navy, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb052));
            this.j5RJt5QvR.Add(RtfColor.Olive, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb07e));
            this.j5RJt5QvR.Add(RtfColor.Purple, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb0ae));
            this.j5RJt5QvR.Add(RtfColor.Red, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb0de));
            this.j5RJt5QvR.Add(RtfColor.Silver, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb10a));
            this.j5RJt5QvR.Add(RtfColor.Teal, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb13e));
            this.j5RJt5QvR.Add(RtfColor.White, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb16e));
            this.j5RJt5QvR.Add(RtfColor.Yellow, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb1a2));
            this.VLQ03a4aV = new HybridDictionary();
            this.VLQ03a4aV.Add(FontFamily.GenericMonospace.Name, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb1d2));
            this.VLQ03a4aV.Add(FontFamily.GenericSansSerif, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb1e6));
            this.VLQ03a4aV.Add(FontFamily.GenericSerif, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb1f8));
            this.VLQ03a4aV.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb20a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb21c));
            using (Graphics graphics = base.CreateGraphics())
            {
                this.7bs1C4L14 = graphics.DpiX;
                this.fZ2giAleG = graphics.DpiY;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ExRichTextBox(RtfColor _textColor) : this()
        {
            this.qQ4kDvXcA = _textColor;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ExRichTextBox(RtfColor _textColor, RtfColor _highlightColor) : this()
        {
            this.qQ4kDvXcA = _textColor;
            this.Z9JEQuyJT = _highlightColor;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string 01FqmBarm(string text1, Font font1)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb29a));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb2ee));
            if (font1.Bold)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb308));
            }
            if (font1.Italic)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb310));
            }
            if (font1.Strikeout)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb318));
            }
            if (font1.Underline)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb32a));
            }
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb334));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb33e));
            builder.Append((int) Math.Round((double) (2f * font1.SizeInPoints)));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb348));
            builder.Append(text1.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb34e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb354)));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb362));
            if (font1.Bold)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb37c));
            }
            if (font1.Italic)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb386));
            }
            if (font1.Strikeout)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb390));
            }
            if (font1.Underline)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3a4));
            }
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3b6));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3c0));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3ce));
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string 4bccOhnfl(Image image1)
        {
            string str;
            StringBuilder builder = null;
            MemoryStream stream = null;
            Graphics graphics = null;
            Metafile image = null;
            try
            {
                builder = new StringBuilder();
                stream = new MemoryStream();
                using (graphics = base.CreateGraphics())
                {
                    IntPtr hdc = graphics.GetHdc();
                    image = new Metafile(stream, hdc);
                    graphics.ReleaseHdc(hdc);
                }
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.DrawImage(image1, new Rectangle(0, 0, image1.Width, image1.Height));
                }
                IntPtr henhmetafile = image.GetHenhmetafile();
                uint num = yTHMJ858G(henhmetafile, 0, null, 8, (bTeaNwqPn6KbYowpJU9) 0);
                byte[] buffer = new byte[num];
                uint num2 = yTHMJ858G(henhmetafile, num, buffer, 8, (bTeaNwqPn6KbYowpJU9) 0);
                for (int i = 0; i < buffer.Length; i++)
                {
                    builder.Append(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4ca), buffer[i]));
                }
                str = builder.ToString();
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
                if (image != null)
                {
                    image.Dispose();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppendRtf(string _rtf)
        {
            base.Select(this.TextLength, 0);
            base.SelectedRtf = _rtf;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppendTextAsRtf(string _text)
        {
            this.AppendTextAsRtf(_text, this.Font);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppendTextAsRtf(string _text, Font _font)
        {
            this.AppendTextAsRtf(_text, _font, this.qQ4kDvXcA);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppendTextAsRtf(string _text, Font _font, RtfColor _textColor)
        {
            this.AppendTextAsRtf(_text, _font, _textColor, this.Z9JEQuyJT);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppendTextAsRtf(string _text, Font _font, RtfColor _textColor, RtfColor _backColor)
        {
            base.Select(this.TextLength, 0);
            this.InsertTextAsRtf(_text, _font, _textColor, _backColor);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string Dr0wrInQN(string text1)
        {
            return text1.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb566), "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string dT3f0t4t3(Image image1)
        {
            StringBuilder builder = new StringBuilder();
            int num = (int) Math.Round((double) ((((float) image1.Width) / this.7bs1C4L14) * 2540f));
            int num2 = (int) Math.Round((double) ((((float) image1.Height) / this.fZ2giAleG) * 2540f));
            int num3 = (int) Math.Round((double) ((((float) image1.Width) / this.7bs1C4L14) * 1440f));
            int num4 = (int) Math.Round((double) ((((float) image1.Height) / this.fZ2giAleG) * 1440f));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb456));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb47c));
            builder.Append(num);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb48a));
            builder.Append(num2);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb498));
            builder.Append(num3);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4ae));
            builder.Append(num4);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4c4));
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertImage(Image _image)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3e6));
            builder.Append(this.TEPULnwMP(this.Font));
            builder.Append(this.dT3f0t4t3(_image));
            builder.Append(this.4bccOhnfl(_image));
            builder.Append(this.kSYpyOBWG);
            base.SelectedRtf = builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertRtf(string _rtf)
        {
            base.SelectedRtf = _rtf;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertTextAsRtf(string _text)
        {
            this.InsertTextAsRtf(_text, this.Font);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertTextAsRtf(string _text, Font _font)
        {
            this.InsertTextAsRtf(_text, _font, this.qQ4kDvXcA);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertTextAsRtf(string _text, Font _font, RtfColor _textColor)
        {
            this.InsertTextAsRtf(_text, _font, _textColor, this.Z9JEQuyJT);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertTextAsRtf(string _text, Font _font, RtfColor _textColor, RtfColor _backColor)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb22a));
            builder.Append(this.TEPULnwMP(_font));
            builder.Append(this.MEWIXKqxt(_textColor, _backColor));
            builder.Append(this.01FqmBarm(_text, _font));
            RichTextBox box = new RichTextBox {
                Font = _font,
                Text = _text
            };
            this.AppendRtf(box.Rtf);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string MEWIXKqxt(RtfColor color1, RtfColor color2)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb538));
            builder.Append(this.j5RJt5QvR[color1]);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb554));
            builder.Append(this.j5RJt5QvR[color2]);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb55a));
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Print(bool preview)
        {
            new ExRichTextBoxPrintHelper(this).PrintRTF(preview);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string TEPULnwMP(Font font1)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4da));
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4f8));
            if (this.VLQ03a4aV.Contains(font1.FontFamily.Name))
            {
                builder.Append(this.VLQ03a4aV[font1.FontFamily.Name]);
            }
            else
            {
                builder.Append(this.VLQ03a4aV[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4fe)]);
            }
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb510));
            builder.Append(font1.Name);
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb52e));
            return builder.ToString();
        }

        [DllImport("gdiplus.dll", EntryPoint="GdipEmfToWmfBits")]
        private static extern uint yTHMJ858G(IntPtr, uint, byte[], int, bTeaNwqPn6KbYowpJU9);

        public RtfColor HiglightColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Z9JEQuyJT;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.Z9JEQuyJT = value;
            }
        }

        public string Rtf
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Dr0wrInQN(base.Rtf);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                base.Rtf = value;
            }
        }

        public RtfColor TextColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.qQ4kDvXcA;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.qQ4kDvXcA = value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        private struct 5VcJK7qBIorWtQEvNwC
        {
            public const string XxQqQ66mW = @"\fnil";
            public const string EPgfA8o8U = @"\froman";
            public const string hudMECjTG = @"\fswiss";
            public const string 3xodQsKC6 = @"\fmodern";
            public const string eMSUYugy4 = @"\fscript";
            public const string y3vHWmTuH = @"\fdecor";
            public const string Um5wSC5ZO = @"\ftech";
            public const string 533PxePZv = @"\fbidi";
        }

        private enum bTeaNwqPn6KbYowpJU9
        {
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        private struct ZVcKdcq2v3Pk4sGdj8c
        {
            public const string XxQqQ66mW = @"\red0\green0\blue0";
            public const string EPgfA8o8U = @"\red128\green0\blue0";
            public const string hudMECjTG = @"\red0\green128\blue0";
            public const string 3xodQsKC6 = @"\red128\green128\blue0";
            public const string eMSUYugy4 = @"\red0\green0\blue128";
            public const string y3vHWmTuH = @"\red128\green0\blue128";
            public const string Um5wSC5ZO = @"\red0\green128\blue128";
            public const string 533PxePZv = @"\red128\green128\blue128";
            public const string kjkSQKOOP = @"\red192\green192\blue192";
            public const string FDjLaMMWZ = @"\red255\green0\blue0";
            public const string M3MBKcV3M = @"\red0\green255\blue0";
            public const string 13OCE0e89 = @"\red255\green255\blue0";
            public const string uGJxrnLpK = @"\red0\green0\blue255";
            public const string moKQgaVV3 = @"\red255\green0\blue255";
            public const string i2VFt44Cv = @"\red0\green255\blue255";
            public const string H6LN3Tw3t = @"\red255\green255\blue255";
        }
    }
}

