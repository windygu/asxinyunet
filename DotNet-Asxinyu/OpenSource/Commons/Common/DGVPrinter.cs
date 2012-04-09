namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DGVPrinter
    {
        protected Form _Owner = null;
        protected double _PrintPreviewZoom = 1.0;
        private bool 04wTsKkSX = true;
        private Icon 07N3j5YeU = null;
        private StringFormatFlags 1Cqq7tqiuM;
        private StringFormatFlags 26UqoJ1Xxm;
        private bool? 336DbCjRp;
        private float 34HpWeeU0 = 0f;
        private Dictionary<string, float> 3cVqIafF2m = new Dictionary<string, float>();
        private Font 5pZqCGemiE;
        private string 5W8jYOoDo;
        private Alignment 6faqm4rlQq = Alignment.NotSet;
        private int 6LimNvZOW = 0;
        private PrintDocument 75daGZAWD = null;
        private string 7LiK8PCsv;
        private bool 7ZrqZhFRnP = false;
        private RowHeightSetting 80OqFTwLw0 = RowHeightSetting.StringHeight;
        private string 8E1qt7jpMO = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e8);
        private int 8rutm6l7j = 0;
        private List<float> 9FsdvYE4a;
        private StringFormat AQvqs30m6F = null;
        private StringFormat BByq65w1Ta = null;
        private List<float> biUquaqsUY = new List<float>();
        private Dictionary<string, DataGridViewCellStyle> BOZqQPvOqM = new Dictionary<string, DataGridViewCellStyle>();
        private bool? cFdOXL6At = false;
        private DataGridView d2pr5bVa4 = null;
        private StringFormat DcdqqlFROG;
        private bool DilqxLRVDu = false;
        private IList EEBiQuLFj;
        private bool EfGqYq81bI = false;
        private float eO5kbmjJk = 0f;
        private float Fa3obbY2h = 0f;
        private bool fnl0TVqqT = false;
        private bool FOkqGlEuqr = true;
        private bool gb0lGUnpS = true;
        private Font GptnlCn3M;
        private int HNnsZfJ0m = -1;
        private Font hVXqU2siKA;
        private int ihBQ0ACfB = 0;
        public IList<ImbeddedImage> ImbeddedImageList = new List<ImbeddedImage>();
        private string ioMqvwgrOp = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ce);
        private string J4Yq4Dwnik;
        private StringAlignment j6Oq26NH8t;
        private bool j8sqEQfoV2 = false;
        private string KBkRKA3eR;
        private float m4yxPvh4u = 0f;
        private Color mdVqyR24PH;
        private int mGD230j4m = -1;
        private StringFormat nN6VZx4g9;
        private int NxK7eyg5N = 0;
        private PrintDialogSettingsClass nYmHyZ4wE = new PrintDialogSettingsClass();
        private float o0BbFNjPW = 0f;
        private string Okeqhfl2yV = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1da);
        private float OLTqPjMAUB;
        private string owGqAxI40f = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1fc);
        private StringFormat OZeqcOpmt9;
        private int poy6Mo6l8 = -1;
        private string PqYJx2gIB;
        private PrintRange Q6lFpSScP;
        private IList<R96ZuxPqos5c833Rkw> QQEhM8iDN;
        private bool QwX9SSw33 = true;
        private Dictionary<string, DataGridViewCellStyle> QXyqicgH6P = new Dictionary<string, DataGridViewCellStyle>();
        private Color R9qqBO1GrN;
        private int RjFgWuhVM = 0;
        private IList rq9ANDTh8;
        private List<float> rRTeiCv5I;
        private float RXfLctP0L = 0f;
        private float sHmqfL4JDR;
        private int sKlqW1wUbt;
        private StringAlignment SnKqgU7J12;
        private float uGG5ENOCq;
        private bool UHWqXcis5U = false;
        private DataGridViewCellStyle uwoqrOjZJc;
        private Font Vh8zqTUfK;
        private const int ViDvSiHoy = 0x7fffffff;
        private bool VR6SykaOj = false;
        private Color wSNq1kcSpL;
        private StringFormat XdEqaynPuF = null;
        private bool xFLqMoMcZY = false;
        private Color xiC82G90C;
        private float xIfunpCEn = 0f;
        private StringFormat XWsqwnArUc;
        private int yfEIHqSlO = 0;

        public event CellOwnerDrawEventHandler OwnerDraw;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DGVPrinter()
        {
            this.75daGZAWD = new PrintDocument();
            this.75daGZAWD.PrintPage += new PrintPageEventHandler(this.fNM4OoxBb);
            this.75daGZAWD.BeginPrint += new PrintEventHandler(this.csmMiy6Il);
            this.PrintMargins = new Margins(60, 60, 40, 40);
            this.5pZqCGemiE = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x202), 8f, FontStyle.Regular, GraphicsUnit.Point);
            this.wSNq1kcSpL = Color.Black;
            this.GptnlCn3M = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(530), 18f, FontStyle.Bold, GraphicsUnit.Point);
            this.xiC82G90C = Color.Black;
            this.Vh8zqTUfK = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x222), 12f, FontStyle.Bold, GraphicsUnit.Point);
            this.mdVqyR24PH = Color.Black;
            this.hVXqU2siKA = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x232), 10f, FontStyle.Bold, GraphicsUnit.Point);
            this.R9qqBO1GrN = Color.Black;
            this.uGG5ENOCq = 0f;
            this.sHmqfL4JDR = 0f;
            this.OLTqPjMAUB = 0f;
            this.HZSBafg3p(ref this.nN6VZx4g9, null, StringAlignment.Center, StringAlignment.Center, StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap, StringTrimming.Word);
            this.HZSBafg3p(ref this.DcdqqlFROG, null, StringAlignment.Center, StringAlignment.Center, StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap, StringTrimming.Word);
            this.HZSBafg3p(ref this.XWsqwnArUc, null, StringAlignment.Center, StringAlignment.Center, StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap, StringTrimming.Word);
            this.HZSBafg3p(ref this.OZeqcOpmt9, null, StringAlignment.Far, StringAlignment.Center, StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap, StringTrimming.Word);
            this.AQvqs30m6F = null;
            this.XdEqaynPuF = null;
            this.BByq65w1Ta = null;
            this.Owner = null;
            this.PrintPreviewZoom = 1.0;
            this.j6Oq26NH8t = StringAlignment.Near;
            this.1Cqq7tqiuM = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            this.SnKqgU7J12 = StringAlignment.Near;
            this.26UqoJ1Xxm = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int 4N3ft2esL()
        {
            double num = this.75daGZAWD.DefaultPageSettings.Bounds.Height + (3f * this.75daGZAWD.DefaultPageSettings.HardMarginX);
            return (int) (num * this.PrintPreviewZoom);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool 9T4CVGCEj(Graphics graphics1)
        {
            float num2;
            float num3;
            bool flag = false;
            bool flag2 = false;
            float top = this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW.Top;
            this.6LimNvZOW++;
            if ((this.6LimNvZOW >= this.NxK7eyg5N) && (this.6LimNvZOW <= this.poy6Mo6l8))
            {
                flag2 = true;
            }
            this.Fa3obbY2h = (this.RjFgWuhVM - this.34HpWeeU0) - this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW.Bottom;
            while (!flag2)
            {
                top = this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW.Top + this.eO5kbmjJk;
                bool flag3 = false;
                this.mGD230j4m = this.HNnsZfJ0m + 1;
                num2 = (this.HNnsZfJ0m < this.9FsdvYE4a.Count) ? this.9FsdvYE4a[this.mGD230j4m] : 0f;
                do
                {
                    num3 = ((this.9FsdvYE4a[this.mGD230j4m] - this.xIfunpCEn) > (this.Fa3obbY2h - top)) ? (this.Fa3obbY2h - top) : (this.9FsdvYE4a[this.mGD230j4m] - this.xIfunpCEn);
                    top += num3;
                    if ((this.xIfunpCEn + num3) >= num2)
                    {
                        this.xIfunpCEn = 0f;
                        this.HNnsZfJ0m++;
                        this.mGD230j4m++;
                    }
                    else
                    {
                        this.xIfunpCEn += num3;
                        flag3 = true;
                    }
                    num2 = (this.mGD230j4m < this.9FsdvYE4a.Count) ? this.9FsdvYE4a[this.mGD230j4m] : 0f;
                    if (((0f == this.xIfunpCEn) && this.QwX9SSw33) && ((top + num2) >= this.Fa3obbY2h))
                    {
                        flag3 = true;
                    }
                    if ((0f == this.xIfunpCEn) && (top >= this.Fa3obbY2h))
                    {
                        flag3 = true;
                    }
                    if ((0f == this.xIfunpCEn) && (this.HNnsZfJ0m >= (this.rq9ANDTh8.Count - 1)))
                    {
                        flag3 = true;
                    }
                }
                while (!flag3);
                this.6LimNvZOW++;
                if ((this.6LimNvZOW >= this.NxK7eyg5N) && (this.6LimNvZOW <= this.poy6Mo6l8))
                {
                    flag2 = true;
                }
                if (!(0f == this.xIfunpCEn))
                {
                    flag = true;
                }
                else if ((this.HNnsZfJ0m >= (this.rq9ANDTh8.Count - 1)) || (this.6LimNvZOW > this.poy6Mo6l8))
                {
                    flag = this.OWxGaovaE();
                    this.HNnsZfJ0m = -1;
                    this.6LimNvZOW = 0;
                    return flag;
                }
            }
            top = this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW.Top;
            if (this.PrintHeader)
            {
                List<ImbeddedImage> list = new List<ImbeddedImage>();
                foreach (ImbeddedImage image in this.ImbeddedImageList)
                {
                    if (image.ImageLocation == Location.Header)
                    {
                        list.Add(image);
                    }
                }
                Extensions.DrawImbeddedImage<ImbeddedImage>(list, graphics1, this.ihBQ0ACfB, this.RjFgWuhVM, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
                if (this.EfGqYq81bI && this.FOkqGlEuqr)
                {
                    string str = this.Okeqhfl2yV + this.6LimNvZOW.ToString(CultureInfo.CurrentCulture);
                    if (this.j8sqEQfoV2)
                    {
                        str = str + this.ioMqvwgrOp + this.sKlqW1wUbt.ToString();
                    }
                    if (1 < this.QQEhM8iDN.Count)
                    {
                        str = str + this.8E1qt7jpMO + ((this.8rutm6l7j + 1)).ToString(CultureInfo.CurrentCulture);
                    }
                    this.sA31flgxM(graphics1, ref top, str, this.5pZqCGemiE, this.wSNq1kcSpL, this.OZeqcOpmt9, this.UHWqXcis5U, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
                    if (!this.7ZrqZhFRnP)
                    {
                        top -= this.o0BbFNjPW;
                    }
                }
                if (!string.IsNullOrEmpty(this.PqYJx2gIB))
                {
                    this.sA31flgxM(graphics1, ref top, this.PqYJx2gIB, this.GptnlCn3M, this.xiC82G90C, this.nN6VZx4g9, this.VR6SykaOj, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
                }
                top += this.uGG5ENOCq;
                if (!string.IsNullOrEmpty(this.5W8jYOoDo))
                {
                    this.sA31flgxM(graphics1, ref top, this.5W8jYOoDo, this.Vh8zqTUfK, this.mdVqyR24PH, this.DcdqqlFROG, this.fnl0TVqqT, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
                }
                top += this.sHmqfL4JDR;
            }
            if (this.PrintColumnHeaders.Value)
            {
                this.CbmYvZ8sP(graphics1, ref top, this.QQEhM8iDN[this.8rutm6l7j]);
            }
            List<ImbeddedImage> list2 = new List<ImbeddedImage>();
            foreach (ImbeddedImage image in this.ImbeddedImageList)
            {
                if (image.ImageLocation == Location.Header)
                {
                    list2.Add(image);
                }
            }
            Extensions.DrawImbeddedImage<ImbeddedImage>(list2, graphics1, this.ihBQ0ACfB, this.RjFgWuhVM, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
            bool flag4 = true;
            this.mGD230j4m = this.HNnsZfJ0m + 1;
            if (this.mGD230j4m >= this.rq9ANDTh8.Count)
            {
                return false;
            }
            num2 = (this.HNnsZfJ0m < this.9FsdvYE4a.Count) ? this.9FsdvYE4a[this.mGD230j4m] : 0f;
            do
            {
                num3 = this.p2IZt4XSy(graphics1, top, (DataGridViewRow) this.rq9ANDTh8[this.mGD230j4m], this.QQEhM8iDN[this.8rutm6l7j], this.xIfunpCEn);
                top += num3;
                if ((this.xIfunpCEn + num3) >= num2)
                {
                    this.xIfunpCEn = 0f;
                    this.HNnsZfJ0m++;
                    this.mGD230j4m++;
                }
                else
                {
                    this.xIfunpCEn += num3;
                    flag4 = false;
                }
                num2 = (this.mGD230j4m < this.9FsdvYE4a.Count) ? this.9FsdvYE4a[this.mGD230j4m] : 0f;
                if (((0f == this.xIfunpCEn) && this.QwX9SSw33) && ((top + num2) >= this.Fa3obbY2h))
                {
                    flag4 = false;
                }
                if ((0f == this.xIfunpCEn) && (top >= this.Fa3obbY2h))
                {
                    flag4 = false;
                }
                if ((0f == this.xIfunpCEn) && (this.HNnsZfJ0m >= (this.rq9ANDTh8.Count - 1)))
                {
                    flag4 = false;
                }
            }
            while (flag4);
            if (this.PrintFooter)
            {
                List<ImbeddedImage> list3 = new List<ImbeddedImage>();
                foreach (ImbeddedImage image in this.ImbeddedImageList)
                {
                    if (image.ImageLocation == Location.Header)
                    {
                        list3.Add(image);
                    }
                }
                Extensions.DrawImbeddedImage<ImbeddedImage>(list3, graphics1, this.ihBQ0ACfB, this.RjFgWuhVM, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
                this.txycF6EdQ(graphics1, ref top, this.QQEhM8iDN[this.8rutm6l7j].JiYUNJcCW);
            }
            if (!(0f == this.xIfunpCEn))
            {
                flag = true;
            }
            if ((this.6LimNvZOW >= this.poy6Mo6l8) || (this.HNnsZfJ0m >= (this.rq9ANDTh8.Count - 1)))
            {
                flag = this.OWxGaovaE();
                this.HNnsZfJ0m = -1;
                this.6LimNvZOW = 0;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int BkDXNWfc2()
        {
            int num = 1;
            float num2 = 0f;
            float num3 = (((this.RjFgWuhVM - this.eO5kbmjJk) - this.34HpWeeU0) - this.PrintMargins.Top) - this.PrintMargins.Bottom;
            if (this.poy6Mo6l8 < 0x7fffffff)
            {
                return this.poy6Mo6l8;
            }
            for (int i = 0; i < this.9FsdvYE4a.Count; i++)
            {
                if ((num2 + this.9FsdvYE4a[i]) > num3)
                {
                    num++;
                    num2 = 0f;
                }
                num2 += this.9FsdvYE4a[i];
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void C1aPmhGbi(Graphics, R96ZuxPqos5c833Rkw rkw1)
        {
            int num;
            float num4;
            float num2 = this.m4yxPvh4u;
            float num3 = 0f;
            for (num = 0; num < rkw1.408MSTia8.Count; num++)
            {
                if (rkw1.408MSTia8[num] >= 0f)
                {
                    num2 += rkw1.408MSTia8[num];
                }
            }
            for (num = 0; num < rkw1.XPOfx7u7N.Count; num++)
            {
                if (rkw1.408MSTia8[num] < 0f)
                {
                    num3 += rkw1.XPOfx7u7N[num];
                }
            }
            if (this.DilqxLRVDu && (0f < num3))
            {
                num4 = (this.ihBQ0ACfB - num2) / num3;
            }
            else
            {
                num4 = 1f;
            }
            rkw1.GPY6Re0PF = this.m4yxPvh4u;
            for (num = 0; num < rkw1.XPOfx7u7N.Count; num++)
            {
                if (rkw1.408MSTia8[num] >= 0f)
                {
                    rkw1.XPOfx7u7N[num] = rkw1.408MSTia8[num];
                }
                else
                {
                    rkw1.XPOfx7u7N[num] *= num4;
                }
                rkw1.GPY6Re0PF += rkw1.XPOfx7u7N[num];
            }
            if (Alignment.Left == this.6faqm4rlQq)
            {
                rkw1.JiYUNJcCW.Right = (this.yfEIHqSlO - rkw1.JiYUNJcCW.Left) - ((int) rkw1.GPY6Re0PF);
                if (0 > rkw1.JiYUNJcCW.Right)
                {
                    rkw1.JiYUNJcCW.Right = 0;
                }
            }
            else if (Alignment.Right == this.6faqm4rlQq)
            {
                rkw1.JiYUNJcCW.Left = (this.yfEIHqSlO - rkw1.JiYUNJcCW.Right) - ((int) rkw1.GPY6Re0PF);
                if (0 > rkw1.JiYUNJcCW.Left)
                {
                    rkw1.JiYUNJcCW.Left = 0;
                }
            }
            else if (Alignment.Center == this.6faqm4rlQq)
            {
                rkw1.JiYUNJcCW.Left = (this.yfEIHqSlO - ((int) rkw1.GPY6Re0PF)) / 2;
                if (0 > rkw1.JiYUNJcCW.Left)
                {
                    rkw1.JiYUNJcCW.Left = 0;
                }
                rkw1.JiYUNJcCW.Right = rkw1.JiYUNJcCW.Left;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CbmYvZ8sP(Graphics graphics1, ref float singleRef1, R96ZuxPqos5c833Rkw rkw1)
        {
            float x = rkw1.JiYUNJcCW.Left + this.m4yxPvh4u;
            Pen pen = new Pen(this.d2pr5bVa4.GridColor, 1f);
            for (int i = 0; i < rkw1.mUvqAX6rk.Count; i++)
            {
                DataGridViewColumn column = (DataGridViewColumn) rkw1.mUvqAX6rk[i];
                float width = (rkw1.XPOfx7u7N[i] > (this.ihBQ0ACfB - this.m4yxPvh4u)) ? (this.ihBQ0ACfB - this.m4yxPvh4u) : rkw1.XPOfx7u7N[i];
                DataGridViewCellStyle inheritedStyle = column.HeaderCell.InheritedStyle;
                if (this.ColumnHeaderStyles.ContainsKey(column.Name))
                {
                    inheritedStyle = this.ColumnHeaderStyles[column.Name];
                }
                RectangleF rect = new RectangleF(x, singleRef1, width, this.RXfLctP0L);
                graphics1.FillRectangle(new SolidBrush(inheritedStyle.BackColor), rect);
                graphics1.DrawString(column.HeaderText, inheritedStyle.Font, new SolidBrush(inheritedStyle.ForeColor), rect, this.AQvqs30m6F);
                if (this.d2pr5bVa4.ColumnHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                {
                    graphics1.DrawRectangle(pen, x, singleRef1, width, this.RXfLctP0L);
                }
                x += rkw1.XPOfx7u7N[i];
            }
            singleRef1 += this.RXfLctP0L + ((this.d2pr5bVa4.ColumnHeadersBorderStyle != DataGridViewHeaderBorderStyle.None) ? pen.Width : 0f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void csmMiy6Il(object, PrintEventArgs)
        {
            this.8rutm6l7j = 0;
            this.HNnsZfJ0m = -1;
            this.6LimNvZOW = 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void DCfwTCNw5(Graphics graphics1)
        {
            int num;
            DataGridViewColumn column;
            StringFormat format;
            SizeF size;
            this.9FsdvYE4a = new List<float>(this.rq9ANDTh8.Count);
            this.rRTeiCv5I = new List<float>(this.EEBiQuLFj.Count);
            this.eO5kbmjJk = 0f;
            this.34HpWeeU0 = 0f;
            Font font = this.d2pr5bVa4.ColumnHeadersDefaultCellStyle.Font;
            if (null == font)
            {
                font = this.d2pr5bVa4.DefaultCellStyle.Font;
            }
            for (num = 0; num < this.EEBiQuLFj.Count; num++)
            {
                column = (DataGridViewColumn) this.EEBiQuLFj[num];
                format = null;
                DataGridViewCellStyle inheritedStyle = null;
                if (this.ColumnHeaderStyles.ContainsKey(column.Name))
                {
                    inheritedStyle = this.QXyqicgH6P[column.Name];
                    this.HZSBafg3p(ref format, inheritedStyle, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                }
                else if (column.HasDefaultCellStyle)
                {
                    inheritedStyle = column.HeaderCell.InheritedStyle;
                    this.HZSBafg3p(ref format, inheritedStyle, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                }
                else
                {
                    format = this.AQvqs30m6F;
                    inheritedStyle = this.d2pr5bVa4.DefaultCellStyle;
                }
                float width = 0f;
                if (0f <= this.biUquaqsUY[num])
                {
                    width = this.biUquaqsUY[num];
                }
                else
                {
                    width = this.ihBQ0ACfB;
                }
                size = graphics1.MeasureString(column.HeaderText, inheritedStyle.Font, new SizeF(width, 2.147484E+09f), this.AQvqs30m6F);
                this.rRTeiCv5I.Add(size.Width);
                this.RXfLctP0L = (this.RXfLctP0L < size.Height) ? size.Height : this.RXfLctP0L;
            }
            if (this.FOkqGlEuqr)
            {
                this.o0BbFNjPW = graphics1.MeasureString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x55a), this.5pZqCGemiE, this.ihBQ0ACfB, this.OZeqcOpmt9).Height;
            }
            if (this.PrintHeader)
            {
                if (!(!this.EfGqYq81bI || this.7ZrqZhFRnP))
                {
                    this.eO5kbmjJk += this.o0BbFNjPW;
                }
                if (!string.IsNullOrEmpty(this.PqYJx2gIB))
                {
                    this.eO5kbmjJk += graphics1.MeasureString(this.PqYJx2gIB, this.GptnlCn3M, this.ihBQ0ACfB, this.nN6VZx4g9).Height;
                }
                if (!string.IsNullOrEmpty(this.5W8jYOoDo))
                {
                    this.eO5kbmjJk += graphics1.MeasureString(this.5W8jYOoDo, this.Vh8zqTUfK, this.ihBQ0ACfB, this.DcdqqlFROG).Height;
                }
                if (this.PrintColumnHeaders.Value)
                {
                    this.eO5kbmjJk += this.RXfLctP0L;
                }
                this.eO5kbmjJk += this.uGG5ENOCq + this.sHmqfL4JDR;
            }
            if (this.PrintFooter)
            {
                if (!string.IsNullOrEmpty(this.J4Yq4Dwnik))
                {
                    this.34HpWeeU0 += graphics1.MeasureString(this.J4Yq4Dwnik, this.hVXqU2siKA, this.ihBQ0ACfB, this.XWsqwnArUc).Height;
                }
                if (!(this.EfGqYq81bI || !this.7ZrqZhFRnP))
                {
                    this.34HpWeeU0 += this.o0BbFNjPW;
                }
                this.34HpWeeU0 += this.OLTqPjMAUB;
            }
            num = 0;
            while (num < this.rq9ANDTh8.Count)
            {
                DataGridViewRow row = (DataGridViewRow) this.rq9ANDTh8[num];
                this.9FsdvYE4a.Add(0f);
                if (this.PrintRowHeaders.Value)
                {
                    string text = string.IsNullOrEmpty(row.HeaderCell.EditedFormattedValue.ToString()) ? this.owGqAxI40f : row.HeaderCell.EditedFormattedValue.ToString();
                    SizeF ef2 = graphics1.MeasureString(text, font);
                    this.m4yxPvh4u = (this.m4yxPvh4u < ef2.Width) ? ef2.Width : this.m4yxPvh4u;
                }
                for (int i = 0; i < this.EEBiQuLFj.Count; i++)
                {
                    float num6;
                    column = (DataGridViewColumn) this.EEBiQuLFj[i];
                    string str2 = row.Cells[column.Index].EditedFormattedValue.ToString();
                    format = null;
                    DataGridViewCellStyle defaultCellStyle = null;
                    if (this.ColumnStyles.ContainsKey(column.Name))
                    {
                        defaultCellStyle = this.BOZqQPvOqM[column.Name];
                        this.HZSBafg3p(ref format, defaultCellStyle, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                    }
                    else if (column.HasDefaultCellStyle || row.Cells[column.Index].HasStyle)
                    {
                        defaultCellStyle = row.Cells[column.Index].InheritedStyle;
                        this.HZSBafg3p(ref format, defaultCellStyle, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                    }
                    else
                    {
                        format = this.BByq65w1Ta;
                        defaultCellStyle = this.d2pr5bVa4.DefaultCellStyle;
                    }
                    if (RowHeightSetting.CellHeight == this.RowHeight)
                    {
                        size = (SizeF) row.Cells[column.Index].Size;
                    }
                    else
                    {
                        size = graphics1.MeasureString(str2, defaultCellStyle.Font);
                    }
                    if ((0f <= this.biUquaqsUY[i]) || (size.Width > this.ihBQ0ACfB))
                    {
                        int num4;
                        int num5;
                        if (0f <= this.biUquaqsUY[i])
                        {
                            this.rRTeiCv5I[i] = this.biUquaqsUY[i];
                        }
                        else if (size.Width > this.ihBQ0ACfB)
                        {
                            this.rRTeiCv5I[i] = this.ihBQ0ACfB;
                        }
                        num6 = (graphics1.MeasureString(str2, defaultCellStyle.Font, new SizeF((this.rRTeiCv5I[i] - defaultCellStyle.Padding.Left) - defaultCellStyle.Padding.Right, 2.147484E+09f), format, out num4, out num5).Height + defaultCellStyle.Padding.Top) + defaultCellStyle.Padding.Bottom;
                        this.9FsdvYE4a[num] = (this.9FsdvYE4a[num] < num6) ? num6 : this.9FsdvYE4a[num];
                    }
                    else
                    {
                        float num7 = (size.Width + defaultCellStyle.Padding.Left) + defaultCellStyle.Padding.Right;
                        num6 = (size.Height + defaultCellStyle.Padding.Top) + defaultCellStyle.Padding.Bottom;
                        this.rRTeiCv5I[i] = (this.rRTeiCv5I[i] < num7) ? num7 : this.rRTeiCv5I[i];
                        this.9FsdvYE4a[num] = (this.9FsdvYE4a[num] < num6) ? num6 : this.9FsdvYE4a[num];
                    }
                }
                num++;
            }
            this.QQEhM8iDN = new List<R96ZuxPqos5c833Rkw>();
            this.QQEhM8iDN.Add(new R96ZuxPqos5c833Rkw(this.PrintMargins, this.EEBiQuLFj.Count));
            int num8 = 0;
            this.QQEhM8iDN[num8].GPY6Re0PF = this.m4yxPvh4u;
            for (num = 0; num < this.EEBiQuLFj.Count; num++)
            {
                float num9 = (this.biUquaqsUY[num] >= 0f) ? this.biUquaqsUY[num] : this.rRTeiCv5I[num];
                if ((this.ihBQ0ACfB < (this.QQEhM8iDN[num8].GPY6Re0PF + num9)) && (num != 0))
                {
                    this.QQEhM8iDN.Add(new R96ZuxPqos5c833Rkw(this.PrintMargins, this.EEBiQuLFj.Count));
                    num8++;
                    this.QQEhM8iDN[num8].GPY6Re0PF = this.m4yxPvh4u;
                }
                this.QQEhM8iDN[num8].mUvqAX6rk.Add(this.EEBiQuLFj[num]);
                this.QQEhM8iDN[num8].XPOfx7u7N.Add(this.rRTeiCv5I[num]);
                this.QQEhM8iDN[num8].408MSTia8.Add(this.biUquaqsUY[num]);
                R96ZuxPqos5c833Rkw local1 = this.QQEhM8iDN[num8];
                local1.GPY6Re0PF += num9;
            }
            for (num = 0; num < this.QQEhM8iDN.Count; num++)
            {
                this.C1aPmhGbi(graphics1, this.QQEhM8iDN[num]);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DialogResult DisplayPrintDialog()
        {
            PrintDialog dialog = new PrintDialog {
                UseEXDialog = this.nYmHyZ4wE.UseEXDialog,
                AllowSelection = this.nYmHyZ4wE.AllowSelection,
                AllowSomePages = this.nYmHyZ4wE.AllowSomePages,
                AllowCurrentPage = this.nYmHyZ4wE.AllowCurrentPage,
                AllowPrintToFile = this.nYmHyZ4wE.AllowPrintToFile,
                ShowHelp = this.nYmHyZ4wE.ShowHelp,
                ShowNetwork = this.nYmHyZ4wE.ShowNetwork,
                Document = this.75daGZAWD
            };
            if (!string.IsNullOrEmpty(this.7LiK8PCsv))
            {
                this.75daGZAWD.PrinterSettings.PrinterName = this.7LiK8PCsv;
            }
            this.75daGZAWD.DefaultPageSettings.Landscape = dialog.PrinterSettings.DefaultPageSettings.Landscape;
            this.75daGZAWD.DefaultPageSettings.PaperSize = new PaperSize(dialog.PrinterSettings.DefaultPageSettings.PaperSize.PaperName, dialog.PrinterSettings.DefaultPageSettings.PaperSize.Width, dialog.PrinterSettings.DefaultPageSettings.PaperSize.Height);
            return dialog.ShowDialog();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool EmbeddedPrint(DataGridView dgv, Graphics g, Rectangle area)
        {
            if ((dgv == null) || (null == g))
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4ba));
            }
            this.d2pr5bVa4 = dgv;
            Margins printMargins = this.PrintMargins;
            this.PrintMargins.Top = area.Top;
            this.PrintMargins.Bottom = 0;
            this.PrintMargins.Left = area.Left;
            this.PrintMargins.Right = 0;
            this.RjFgWuhVM = area.Height + area.Top;
            this.ihBQ0ACfB = area.Width;
            this.yfEIHqSlO = area.Width + area.Left;
            this.NxK7eyg5N = 0;
            this.poy6Mo6l8 = 0x7fffffff;
            this.PrintHeader = false;
            this.PrintFooter = false;
            if (null == this.BByq65w1Ta)
            {
                this.HZSBafg3p(ref this.BByq65w1Ta, dgv.DefaultCellStyle, this.SnKqgU7J12, StringAlignment.Near, this.26UqoJ1Xxm, StringTrimming.Word);
            }
            this.rq9ANDTh8 = new List<object>(dgv.Rows.Count);
            foreach (DataGridViewRow row in (IEnumerable) dgv.Rows)
            {
                if (row.Visible)
                {
                    this.rq9ANDTh8.Add(row);
                }
            }
            this.EEBiQuLFj = new List<object>(dgv.Columns.Count);
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    this.EEBiQuLFj.Add(column);
                }
            }
            SortedList list = new SortedList(this.EEBiQuLFj.Count);
            foreach (DataGridViewColumn column in this.EEBiQuLFj)
            {
                list.Add(column.DisplayIndex, column);
            }
            this.EEBiQuLFj.Clear();
            foreach (object obj2 in list.Values)
            {
                this.EEBiQuLFj.Add(obj2);
            }
            foreach (DataGridViewColumn column in this.EEBiQuLFj)
            {
                if (this.3cVqIafF2m.ContainsKey(column.Name))
                {
                    this.biUquaqsUY.Add(this.3cVqIafF2m[column.Name]);
                }
                else
                {
                    this.biUquaqsUY.Add(-1f);
                }
            }
            this.DCfwTCNw5(g);
            this.sKlqW1wUbt = this.BkDXNWfc2();
            this.8rutm6l7j = 0;
            this.HNnsZfJ0m = -1;
            this.6LimNvZOW = 0;
            return this.9T4CVGCEj(g);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void fNM4OoxBb(object, PrintPageEventArgs args1)
        {
            args1.HasMorePages = this.9T4CVGCEj(args1.Graphics);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public StringFormat GetCellFormat(DataGridView grid)
        {
            if ((grid != null) && (null == this.BByq65w1Ta))
            {
                this.HZSBafg3p(ref this.BByq65w1Ta, grid.Rows[0].Cells[0].InheritedStyle, this.SnKqgU7J12, StringAlignment.Near, this.26UqoJ1Xxm, StringTrimming.Word);
            }
            if (null == this.BByq65w1Ta)
            {
                this.BByq65w1Ta = new StringFormat(this.26UqoJ1Xxm);
            }
            return this.BByq65w1Ta;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public StringFormat GetColumnHeaderCellFormat(DataGridView grid)
        {
            if ((grid != null) && (null == this.AQvqs30m6F))
            {
                this.HZSBafg3p(ref this.AQvqs30m6F, grid.Columns[0].HeaderCell.InheritedStyle, this.j6Oq26NH8t, StringAlignment.Near, this.1Cqq7tqiuM, StringTrimming.Word);
            }
            if (null == this.AQvqs30m6F)
            {
                this.AQvqs30m6F = new StringFormat(this.1Cqq7tqiuM);
            }
            return this.AQvqs30m6F;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public StringFormat GetRowHeaderCellFormat(DataGridView grid)
        {
            if ((grid != null) && (null == this.XdEqaynPuF))
            {
                this.HZSBafg3p(ref this.XdEqaynPuF, grid.Rows[0].HeaderCell.InheritedStyle, this.j6Oq26NH8t, StringAlignment.Near, this.1Cqq7tqiuM, StringTrimming.Word);
            }
            if (null == this.XdEqaynPuF)
            {
                this.XdEqaynPuF = new StringFormat(this.1Cqq7tqiuM);
            }
            return this.XdEqaynPuF;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void hobU1pUwB()
        {
            int num3;
            DataGridViewRow current;
            if (!this.PrintColumnHeaders.HasValue)
            {
                this.PrintColumnHeaders = new bool?(this.d2pr5bVa4.Columns[0].HeaderCell.Visible);
            }
            if (!this.PrintRowHeaders.HasValue)
            {
                this.PrintRowHeaders = new bool?(this.d2pr5bVa4.RowHeadersVisible);
            }
            if (null == this.RowHeaderCellStyle)
            {
                this.RowHeaderCellStyle = this.d2pr5bVa4.Rows[0].HeaderCell.InheritedStyle;
            }
            if (null == this.AQvqs30m6F)
            {
                this.HZSBafg3p(ref this.AQvqs30m6F, this.d2pr5bVa4.Columns[0].HeaderCell.InheritedStyle, this.j6Oq26NH8t, StringAlignment.Near, this.1Cqq7tqiuM, StringTrimming.Word);
            }
            if (null == this.XdEqaynPuF)
            {
                this.HZSBafg3p(ref this.XdEqaynPuF, this.RowHeaderCellStyle, this.j6Oq26NH8t, StringAlignment.Near, this.1Cqq7tqiuM, StringTrimming.Word);
            }
            if (null == this.BByq65w1Ta)
            {
                this.HZSBafg3p(ref this.BByq65w1Ta, this.d2pr5bVa4.DefaultCellStyle, this.SnKqgU7J12, StringAlignment.Near, this.26UqoJ1Xxm, StringTrimming.Word);
            }
            int num = (int) Math.Round((double) this.75daGZAWD.DefaultPageSettings.HardMarginX);
            int num2 = (int) Math.Round((double) this.75daGZAWD.DefaultPageSettings.HardMarginY);
            if (this.75daGZAWD.DefaultPageSettings.Landscape)
            {
                num3 = (int) Math.Round((double) this.75daGZAWD.DefaultPageSettings.PrintableArea.Height);
            }
            else
            {
                num3 = (int) Math.Round((double) this.75daGZAWD.DefaultPageSettings.PrintableArea.Width);
            }
            this.RjFgWuhVM = this.75daGZAWD.DefaultPageSettings.Bounds.Height;
            this.yfEIHqSlO = this.75daGZAWD.DefaultPageSettings.Bounds.Width;
            this.PrintMargins = this.75daGZAWD.DefaultPageSettings.Margins;
            this.PrintMargins.Right = (num > this.PrintMargins.Right) ? num : this.PrintMargins.Right;
            this.PrintMargins.Left = (num > this.PrintMargins.Left) ? num : this.PrintMargins.Left;
            this.PrintMargins.Top = (num2 > this.PrintMargins.Top) ? num2 : this.PrintMargins.Top;
            this.PrintMargins.Bottom = (num2 > this.PrintMargins.Bottom) ? num2 : this.PrintMargins.Bottom;
            this.ihBQ0ACfB = (this.yfEIHqSlO - this.PrintMargins.Left) - this.PrintMargins.Right;
            this.ihBQ0ACfB = (this.ihBQ0ACfB > num3) ? num3 : this.ihBQ0ACfB;
            this.Q6lFpSScP = this.75daGZAWD.PrinterSettings.PrintRange;
            if (PrintRange.SomePages == this.Q6lFpSScP)
            {
                this.NxK7eyg5N = this.75daGZAWD.PrinterSettings.FromPage;
                this.poy6Mo6l8 = this.75daGZAWD.PrinterSettings.ToPage;
            }
            else
            {
                this.NxK7eyg5N = 0;
                this.poy6Mo6l8 = 0x7fffffff;
            }
            if (PrintRange.Selection == this.Q6lFpSScP)
            {
                SortedList list;
                IEnumerator enumerator2;
                if (0 != this.d2pr5bVa4.SelectedRows.Count)
                {
                    list = new SortedList(this.d2pr5bVa4.SelectedRows.Count);
                    using (enumerator2 = this.d2pr5bVa4.SelectedRows.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            current = (DataGridViewRow) enumerator2.Current;
                            list.Add(current.Index, current);
                        }
                    }
                    IEnumerator enumerator = list.Values.GetEnumerator();
                    this.rq9ANDTh8 = new List<object>(list.Count);
                    foreach (object obj2 in list.Values)
                    {
                        this.rq9ANDTh8.Add(obj2);
                    }
                    this.EEBiQuLFj = new List<object>(this.d2pr5bVa4.Columns.Count);
                    foreach (DataGridViewColumn column in this.d2pr5bVa4.Columns)
                    {
                        if (column.Visible)
                        {
                            this.EEBiQuLFj.Add(column);
                        }
                    }
                }
                else
                {
                    SortedList list2;
                    if (0 != this.d2pr5bVa4.SelectedColumns.Count)
                    {
                        this.rq9ANDTh8 = this.d2pr5bVa4.Rows;
                        list2 = new SortedList(this.d2pr5bVa4.SelectedColumns.Count);
                        using (enumerator2 = this.d2pr5bVa4.SelectedColumns.GetEnumerator())
                        {
                            while (enumerator2.MoveNext())
                            {
                                current = (DataGridViewRow) enumerator2.Current;
                                list2.Add(current.Index, current);
                            }
                        }
                        this.EEBiQuLFj = new List<object>(list2.Count);
                        foreach (object obj2 in list2.Values)
                        {
                            this.EEBiQuLFj.Add(obj2);
                        }
                    }
                    else
                    {
                        list = new SortedList(this.d2pr5bVa4.SelectedCells.Count);
                        list2 = new SortedList(this.d2pr5bVa4.SelectedCells.Count);
                        foreach (DataGridViewCell cell in this.d2pr5bVa4.SelectedCells)
                        {
                            int columnIndex = cell.ColumnIndex;
                            int rowIndex = cell.RowIndex;
                            if (!list.Contains(rowIndex))
                            {
                                list.Add(rowIndex, this.d2pr5bVa4.Rows[rowIndex]);
                            }
                            if (!list2.Contains(columnIndex))
                            {
                                list2.Add(columnIndex, this.d2pr5bVa4.Columns[columnIndex]);
                            }
                        }
                        this.rq9ANDTh8 = new List<object>(list.Count);
                        foreach (object obj2 in list.Values)
                        {
                            this.rq9ANDTh8.Add(obj2);
                        }
                        this.EEBiQuLFj = new List<object>(list2.Count);
                        foreach (object obj2 in list2.Values)
                        {
                            this.EEBiQuLFj.Add(obj2);
                        }
                    }
                }
            }
            else if (PrintRange.CurrentPage == this.Q6lFpSScP)
            {
                this.rq9ANDTh8 = new List<object>(this.d2pr5bVa4.DisplayedRowCount(true));
                this.EEBiQuLFj = new List<object>(this.d2pr5bVa4.Columns.Count);
                for (int i = this.d2pr5bVa4.FirstDisplayedScrollingRowIndex; i < (this.d2pr5bVa4.FirstDisplayedScrollingRowIndex + this.d2pr5bVa4.DisplayedRowCount(true)); i++)
                {
                    current = this.d2pr5bVa4.Rows[i];
                    if (current.Visible)
                    {
                        this.rq9ANDTh8.Add(current);
                    }
                }
                this.EEBiQuLFj = new List<object>(this.d2pr5bVa4.Columns.Count);
                foreach (DataGridViewColumn column in this.d2pr5bVa4.Columns)
                {
                    if (column.Visible)
                    {
                        this.EEBiQuLFj.Add(column);
                    }
                }
            }
            else
            {
                this.rq9ANDTh8 = new List<object>(this.d2pr5bVa4.Rows.Count);
                foreach (DataGridViewRow row in (IEnumerable) this.d2pr5bVa4.Rows)
                {
                    if (!(!row.Visible || row.IsNewRow))
                    {
                        this.rq9ANDTh8.Add(row);
                    }
                }
                this.EEBiQuLFj = new List<object>(this.d2pr5bVa4.Columns.Count);
                foreach (DataGridViewColumn column in this.d2pr5bVa4.Columns)
                {
                    if (column.Visible)
                    {
                        this.EEBiQuLFj.Add(column);
                    }
                }
            }
            int num7 = 1;
            if (RightToLeft.Yes == this.d2pr5bVa4.RightToLeft)
            {
                num7 = -1;
            }
            SortedList list3 = new SortedList(this.EEBiQuLFj.Count);
            foreach (DataGridViewColumn column in this.EEBiQuLFj)
            {
                list3.Add(num7 * column.DisplayIndex, column);
            }
            this.EEBiQuLFj.Clear();
            foreach (object obj2 in list3.Values)
            {
                this.EEBiQuLFj.Add(obj2);
            }
            foreach (DataGridViewColumn column in this.EEBiQuLFj)
            {
                if (this.3cVqIafF2m.ContainsKey(column.Name))
                {
                    this.biUquaqsUY.Add(this.3cVqIafF2m[column.Name]);
                }
                else
                {
                    this.biUquaqsUY.Add(-1f);
                }
            }
            this.DCfwTCNw5(this.75daGZAWD.PrinterSettings.CreateMeasurementGraphics());
            this.sKlqW1wUbt = this.BkDXNWfc2();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void HZSBafg3p(ref StringFormat formatRef1, DataGridViewCellStyle style1, StringAlignment alignment1, StringAlignment alignment2, StringFormatFlags flags1, StringTrimming trimming1)
        {
            if (null == formatRef1)
            {
                formatRef1 = new StringFormat();
            }
            formatRef1.Alignment = alignment1;
            formatRef1.LineAlignment = alignment2;
            formatRef1.FormatFlags = flags1;
            formatRef1.Trimming = trimming1;
            if ((this.d2pr5bVa4 != null) && (RightToLeft.Yes == this.d2pr5bVa4.RightToLeft))
            {
                formatRef1.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            if (null != style1)
            {
                DataGridViewContentAlignment alignment = style1.Alignment;
                if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x506)))
                {
                    formatRef1.Alignment = StringAlignment.Center;
                }
                else if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x516)))
                {
                    formatRef1.Alignment = StringAlignment.Near;
                }
                else if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x522)))
                {
                    formatRef1.Alignment = StringAlignment.Far;
                }
                if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x530)))
                {
                    formatRef1.LineAlignment = StringAlignment.Near;
                }
                else if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x53a)))
                {
                    formatRef1.LineAlignment = StringAlignment.Center;
                }
                else if (alignment.ToString().Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x54a)))
                {
                    formatRef1.LineAlignment = StringAlignment.Far;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void JEsELMkMC(Graphics graphics1, DataGridViewImageCell cell1, RectangleF ef1)
        {
            Image image = (Image) cell1.Value;
            Rectangle srcRect = new Rectangle();
            int num = 0;
            int num2 = 0;
            if ((DataGridViewImageCellLayout.Normal == cell1.ImageLayout) || (DataGridViewImageCellLayout.NotSet == cell1.ImageLayout))
            {
                num = image.Width - ((int) ef1.Width);
                num2 = image.Height - ((int) ef1.Height);
                if (0 > num)
                {
                    ef1.Width = srcRect.Width = image.Width;
                }
                else
                {
                    srcRect.Width = (int) ef1.Width;
                }
                if (0 > num2)
                {
                    ef1.Height = srcRect.Height = image.Height;
                }
                else
                {
                    srcRect.Height = (int) ef1.Height;
                }
            }
            else if (DataGridViewImageCellLayout.Stretch == cell1.ImageLayout)
            {
                srcRect.Width = image.Width;
                srcRect.Height = image.Height;
                num = 0;
                num2 = 0;
            }
            else
            {
                float num5;
                srcRect.Width = image.Width;
                srcRect.Height = image.Height;
                float num3 = ef1.Height / ((float) srcRect.Height);
                float num4 = ef1.Width / ((float) srcRect.Width);
                if (num3 > num4)
                {
                    num5 = num4;
                    num = 0;
                    num2 = (int) ((srcRect.Height * num5) - ef1.Height);
                }
                else
                {
                    num5 = num3;
                    num2 = 0;
                    num = (int) ((srcRect.Width * num5) - ef1.Width);
                }
                ef1.Width = srcRect.Width * num5;
                ef1.Height = srcRect.Height * num5;
            }
            switch (cell1.InheritedStyle.Alignment)
            {
                case DataGridViewContentAlignment.NotSet:
                    if (0 <= num2)
                    {
                        srcRect.Y = num2 / 2;
                    }
                    else
                    {
                        ef1.Y -= num2 / 2;
                    }
                    if (0 > num)
                    {
                        ef1.X -= num / 2;
                    }
                    else
                    {
                        srcRect.X = num / 2;
                    }
                    goto Label_058A;

                case DataGridViewContentAlignment.TopLeft:
                    srcRect.Y = 0;
                    srcRect.X = 0;
                    goto Label_058A;

                case DataGridViewContentAlignment.TopCenter:
                    srcRect.Y = 0;
                    if (0 <= num)
                    {
                        srcRect.X = num / 2;
                    }
                    else
                    {
                        ef1.X -= num / 2;
                    }
                    goto Label_058A;

                case (DataGridViewContentAlignment.TopCenter | DataGridViewContentAlignment.TopLeft):
                    goto Label_058A;

                case DataGridViewContentAlignment.TopRight:
                    srcRect.Y = 0;
                    if (0 <= num)
                    {
                        srcRect.X = num;
                    }
                    else
                    {
                        ef1.X -= num;
                    }
                    goto Label_058A;

                case DataGridViewContentAlignment.MiddleLeft:
                    if (0 > num2)
                    {
                        ef1.Y -= num2 / 2;
                    }
                    else
                    {
                        srcRect.Y = num2 / 2;
                    }
                    srcRect.X = 0;
                    goto Label_058A;

                case DataGridViewContentAlignment.MiddleCenter:
                    if (0 > num2)
                    {
                        ef1.Y -= num2 / 2;
                    }
                    else
                    {
                        srcRect.Y = num2 / 2;
                    }
                    if (0 > num)
                    {
                        ef1.X -= num / 2;
                    }
                    else
                    {
                        srcRect.X = num / 2;
                    }
                    goto Label_058A;

                case DataGridViewContentAlignment.MiddleRight:
                    if (0 > num2)
                    {
                        ef1.Y -= num2 / 2;
                    }
                    else
                    {
                        srcRect.Y = num2 / 2;
                    }
                    if (0 > num)
                    {
                        ef1.X -= num;
                    }
                    else
                    {
                        srcRect.X = num;
                    }
                    goto Label_058A;

                case DataGridViewContentAlignment.BottomLeft:
                    if (0 > num2)
                    {
                        ef1.Y -= num2;
                    }
                    else
                    {
                        srcRect.Y = num2;
                    }
                    srcRect.X = 0;
                    goto Label_058A;

                case DataGridViewContentAlignment.BottomCenter:
                    if (0 > num2)
                    {
                        ef1.Y -= num2;
                    }
                    else
                    {
                        srcRect.Y = num2;
                    }
                    if (0 > num)
                    {
                        ef1.X -= num / 2;
                    }
                    else
                    {
                        srcRect.X = num / 2;
                    }
                    break;

                case DataGridViewContentAlignment.BottomRight:
                    if (0 > num2)
                    {
                        ef1.Y -= num2;
                    }
                    else
                    {
                        srcRect.Y = num2;
                    }
                    if (0 > num)
                    {
                        ef1.X -= num;
                    }
                    else
                    {
                        srcRect.X = num;
                    }
                    goto Label_058A;
            }
        Label_058A:
            graphics1.DrawImage(image, ef1, srcRect, GraphicsUnit.Pixel);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool KFdW4lWfd(Graphics graphics1, DataGridViewCell cell1, RectangleF ef1, DataGridViewCellStyle style1)
        {
            DGVCellDrawingEventArgs e = new DGVCellDrawingEventArgs(graphics1, ef1, style1, cell1.RowIndex, cell1.ColumnIndex);
            this.OnCellOwnerDraw(e);
            return e.Handled;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnCellOwnerDraw(DGVCellDrawingEventArgs e)
        {
            if (null != this.DmPNDor7y)
            {
                this.DmPNDor7y(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool OWxGaovaE()
        {
            this.8rutm6l7j++;
            return (this.8rutm6l7j < this.QQEhM8iDN.Count);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private float p2IZt4XSy(Graphics graphics1, float single1, DataGridViewRow row1, R96ZuxPqos5c833Rkw rkw1, float single2)
        {
            float left = rkw1.JiYUNJcCW.Left;
            float y = single1;
            Pen pen = new Pen(this.d2pr5bVa4.GridColor, 1f);
            float width = (rkw1.GPY6Re0PF > this.ihBQ0ACfB) ? ((float) this.ihBQ0ACfB) : rkw1.GPY6Re0PF;
            float height = ((this.9FsdvYE4a[this.mGD230j4m] - single2) > (this.Fa3obbY2h - y)) ? (this.Fa3obbY2h - y) : (this.9FsdvYE4a[this.mGD230j4m] - single2);
            DataGridViewCellStyle inheritedStyle = row1.InheritedStyle;
            RectangleF rect = new RectangleF(left, y, width, height);
            graphics1.FillRectangle(new SolidBrush(inheritedStyle.BackColor), rect);
            if (this.PrintRowHeaders.Value)
            {
                RectangleF ef2 = new RectangleF(left, y, this.m4yxPvh4u, height);
                graphics1.FillRectangle(new SolidBrush(this.RowHeaderCellStyle.BackColor), ef2);
                string s = string.IsNullOrEmpty(row1.HeaderCell.EditedFormattedValue.ToString()) ? this.owGqAxI40f : row1.HeaderCell.EditedFormattedValue.ToString();
                graphics1.DrawString(s, this.RowHeaderCellStyle.Font, new SolidBrush(this.RowHeaderCellStyle.ForeColor), ef2, this.XdEqaynPuF);
                if (this.d2pr5bVa4.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                {
                    graphics1.DrawRectangle(pen, left, y, this.m4yxPvh4u, height);
                }
                left += this.m4yxPvh4u;
            }
            for (int i = 0; i < rkw1.mUvqAX6rk.Count; i++)
            {
                DataGridViewColumn column = (DataGridViewColumn) rkw1.mUvqAX6rk[i];
                string str2 = row1.Cells[column.Index].EditedFormattedValue.ToString();
                float num6 = (rkw1.XPOfx7u7N[i] > (this.ihBQ0ACfB - this.m4yxPvh4u)) ? (this.ihBQ0ACfB - this.m4yxPvh4u) : rkw1.XPOfx7u7N[i];
                if (num6 > 0f)
                {
                    StringFormat format = null;
                    Font font = null;
                    DataGridViewCellStyle style2 = null;
                    if (this.ColumnStyles.ContainsKey(column.Name))
                    {
                        style2 = this.BOZqQPvOqM[column.Name];
                        this.HZSBafg3p(ref format, style2, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                        font = style2.Font;
                    }
                    else if (column.HasDefaultCellStyle || row1.Cells[column.Index].HasStyle)
                    {
                        style2 = row1.Cells[column.Index].InheritedStyle;
                        this.HZSBafg3p(ref format, style2, this.BByq65w1Ta.Alignment, this.BByq65w1Ta.LineAlignment, this.BByq65w1Ta.FormatFlags, this.BByq65w1Ta.Trimming);
                        font = style2.Font;
                    }
                    else
                    {
                        format = this.BByq65w1Ta;
                        style2 = row1.Cells[column.Index].InheritedStyle;
                    }
                    RectangleF ef3 = new RectangleF(left, y, num6, height);
                    if (!this.KFdW4lWfd(graphics1, row1.Cells[column.Index], ef3, style2))
                    {
                        RectangleF clipBounds = graphics1.ClipBounds;
                        graphics1.FillRectangle(new SolidBrush(style2.BackColor), ef3);
                        ef3 = new RectangleF(left + style2.Padding.Left, y + style2.Padding.Top, (num6 - style2.Padding.Right) - style2.Padding.Left, (height - style2.Padding.Bottom) - style2.Padding.Top);
                        graphics1.SetClip(ef3);
                        RectangleF layoutRectangle = new RectangleF(ef3.X, ef3.Y - single2, num6, this.9FsdvYE4a[this.mGD230j4m]);
                        if (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x566) == column.CellType.Name)
                        {
                            this.JEsELMkMC(graphics1, (DataGridViewImageCell) row1.Cells[column.Index], layoutRectangle);
                        }
                        else
                        {
                            graphics1.DrawString(str2, style2.Font, new SolidBrush(style2.ForeColor), layoutRectangle, format);
                        }
                        graphics1.SetClip(clipBounds);
                        if (this.d2pr5bVa4.CellBorderStyle != DataGridViewCellBorderStyle.None)
                        {
                            graphics1.DrawRectangle(pen, left, y, num6, height);
                        }
                    }
                }
                left += rkw1.XPOfx7u7N[i];
            }
            return height;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintDataGridView(DataGridView dgv)
        {
            if (null == dgv)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x242));
            }
            if (!(typeof(DataGridView) == dgv.GetType()))
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x28e));
            }
            this.d2pr5bVa4 = dgv;
            if (DialogResult.OK == this.DisplayPrintDialog())
            {
                this.hobU1pUwB();
                this.75daGZAWD.Print();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintNoDisplay(DataGridView dgv)
        {
            if (null == dgv)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x37e));
            }
            if (!(typeof(DataGridView) == dgv.GetType()))
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(970));
            }
            this.d2pr5bVa4 = dgv;
            this.hobU1pUwB();
            this.75daGZAWD.Print();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintPreviewDataGridView(DataGridView dgv)
        {
            if (null == dgv)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2e0));
            }
            if (!(typeof(DataGridView) == dgv.GetType()))
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x32c));
            }
            this.d2pr5bVa4 = dgv;
            if (DialogResult.OK == this.DisplayPrintDialog())
            {
                this.PrintPreviewNoDisplay(dgv);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PrintPreviewNoDisplay(DataGridView dgv)
        {
            if (null == dgv)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x41c));
            }
            if (!(typeof(DataGridView) == dgv.GetType()))
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x468));
            }
            this.d2pr5bVa4 = dgv;
            this.hobU1pUwB();
            PrintPreviewDialog dialog = new PrintPreviewDialog {
                Document = this.75daGZAWD,
                UseAntiAlias = true,
                Owner = this.Owner
            };
            dialog.PrintPreviewControl.Zoom = this.PrintPreviewZoom;
            dialog.Width = this.PZaqo38KQ();
            dialog.Height = this.4N3ft2esL();
            if (null != this.07N3j5YeU)
            {
                dialog.Icon = this.07N3j5YeU;
            }
            dialog.ShowDialog();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int PZaqo38KQ()
        {
            double num = this.75daGZAWD.DefaultPageSettings.Bounds.Width + (3f * this.75daGZAWD.DefaultPageSettings.HardMarginY);
            return (int) (num * this.PrintPreviewZoom);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void sA31flgxM(Graphics graphics1, ref float singleRef1, string text1, Font font1, Color color1, StringFormat format1, bool, Margins margins1)
        {
            SizeF ef = graphics1.MeasureString(text1, font1, this.ihBQ0ACfB, format1);
            RectangleF layoutRectangle = new RectangleF((float) margins1.Left, singleRef1, (float) this.ihBQ0ACfB, ef.Height);
            graphics1.DrawString(text1, font1, new SolidBrush(color1), layoutRectangle, format1);
            singleRef1 += ef.Height;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void txycF6EdQ(Graphics graphics1, ref float singleRef1, Margins margins1)
        {
            singleRef1 = (this.RjFgWuhVM - this.34HpWeeU0) - margins1.Bottom;
            singleRef1 += this.OLTqPjMAUB;
            this.sA31flgxM(graphics1, ref singleRef1, this.J4Yq4Dwnik, this.hVXqU2siKA, this.R9qqBO1GrN, this.XWsqwnArUc, this.xFLqMoMcZY, margins1);
            if (!this.EfGqYq81bI && this.FOkqGlEuqr)
            {
                string str = this.Okeqhfl2yV + this.6LimNvZOW.ToString(CultureInfo.CurrentCulture);
                if (this.j8sqEQfoV2)
                {
                    str = str + this.ioMqvwgrOp + this.sKlqW1wUbt.ToString();
                }
                if (1 < this.QQEhM8iDN.Count)
                {
                    str = str + this.8E1qt7jpMO + ((this.8rutm6l7j + 1)).ToString(CultureInfo.CurrentCulture);
                }
                if (!this.7ZrqZhFRnP)
                {
                    singleRef1 -= this.o0BbFNjPW;
                }
                this.sA31flgxM(graphics1, ref singleRef1, str, this.5pZqCGemiE, this.wSNq1kcSpL, this.OZeqcOpmt9, this.UHWqXcis5U, margins1);
            }
        }

        public StringAlignment CellAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.SnKqgU7J12;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.SnKqgU7J12 = value;
            }
        }

        public StringFormatFlags CellFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.26UqoJ1Xxm;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.26UqoJ1Xxm = value;
            }
        }

        public Dictionary<string, DataGridViewCellStyle> ColumnHeaderStyles
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.QXyqicgH6P;
            }
        }

        public Dictionary<string, DataGridViewCellStyle> ColumnStyles
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.BOZqQPvOqM;
            }
        }

        public Dictionary<string, float> ColumnWidths
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.3cVqIafF2m;
            }
        }

        public string DocName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.KBkRKA3eR;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.75daGZAWD.DocumentName = value;
                this.KBkRKA3eR = value;
            }
        }

        public string Footer
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.J4Yq4Dwnik;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.J4Yq4Dwnik = value;
            }
        }

        public StringAlignment FooterAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.XWsqwnArUc.Alignment;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.XWsqwnArUc.Alignment = value;
                this.xFLqMoMcZY = true;
            }
        }

        public Color FooterColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.R9qqBO1GrN;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.R9qqBO1GrN = value;
            }
        }

        public Font FooterFont
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.hVXqU2siKA;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.hVXqU2siKA = value;
            }
        }

        public StringFormat FooterFormat
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.XWsqwnArUc;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.XWsqwnArUc = value;
                this.xFLqMoMcZY = true;
            }
        }

        public StringFormatFlags FooterFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.XWsqwnArUc.FormatFlags;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.XWsqwnArUc.FormatFlags = value;
                this.xFLqMoMcZY = true;
            }
        }

        public float FooterSpacing
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.OLTqPjMAUB;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.OLTqPjMAUB = value;
            }
        }

        public StringAlignment HeaderCellAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.j6Oq26NH8t;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.j6Oq26NH8t = value;
            }
        }

        public StringFormatFlags HeaderCellFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.1Cqq7tqiuM;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.1Cqq7tqiuM = value;
            }
        }

        public bool KeepRowsTogether
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.QwX9SSw33;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.QwX9SSw33 = value;
            }
        }

        public Form Owner
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this._Owner;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this._Owner = value;
            }
        }

        public StringAlignment PageNumberAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.OZeqcOpmt9.Alignment;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.OZeqcOpmt9.Alignment = value;
                this.UHWqXcis5U = true;
            }
        }

        public Color PageNumberColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.wSNq1kcSpL;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.wSNq1kcSpL = value;
            }
        }

        public Font PageNumberFont
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.5pZqCGemiE;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.5pZqCGemiE = value;
            }
        }

        public StringFormat PageNumberFormat
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.OZeqcOpmt9;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.OZeqcOpmt9 = value;
                this.UHWqXcis5U = true;
            }
        }

        public StringFormatFlags PageNumberFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.OZeqcOpmt9.FormatFlags;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.OZeqcOpmt9.FormatFlags = value;
                this.UHWqXcis5U = true;
            }
        }

        public bool PageNumberInHeader
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.EfGqYq81bI;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.EfGqYq81bI = value;
            }
        }

        public bool PageNumberOnSeparateLine
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.7ZrqZhFRnP;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.7ZrqZhFRnP = value;
            }
        }

        public bool PageNumbers
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.FOkqGlEuqr;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.FOkqGlEuqr = value;
            }
        }

        public string PageSeparator
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.ioMqvwgrOp;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.ioMqvwgrOp = value;
            }
        }

        public System.Drawing.Printing.PageSettings PageSettings
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.75daGZAWD.DefaultPageSettings;
            }
        }

        public string PageText
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Okeqhfl2yV;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.Okeqhfl2yV = value;
            }
        }

        public string PartText
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.8E1qt7jpMO;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.8E1qt7jpMO = value;
            }
        }

        public bool PorportionalColumns
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.DilqxLRVDu;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.DilqxLRVDu = value;
            }
        }

        public Icon PreviewDialogIcon
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.07N3j5YeU;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.07N3j5YeU = value;
            }
        }

        public bool? PrintColumnHeaders
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.336DbCjRp;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.336DbCjRp = value;
            }
        }

        public PrintDialogSettingsClass PrintDialogSettings
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.nYmHyZ4wE;
            }
        }

        public PrintDocument printDocument
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.75daGZAWD;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.75daGZAWD = value;
            }
        }

        public string PrinterName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.7LiK8PCsv;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.7LiK8PCsv = value;
            }
        }

        public bool PrintFooter
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.gb0lGUnpS;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.gb0lGUnpS = value;
            }
        }

        public bool PrintHeader
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.04wTsKkSX;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.04wTsKkSX = value;
            }
        }

        public Margins PrintMargins
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.PageSettings.Margins;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.PageSettings.Margins = value;
            }
        }

        public double PrintPreviewZoom
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this._PrintPreviewZoom;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this._PrintPreviewZoom = value;
            }
        }

        public bool? PrintRowHeaders
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.cFdOXL6At;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.cFdOXL6At = value;
            }
        }

        public PrinterSettings PrintSettings
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.75daGZAWD.PrinterSettings;
            }
        }

        public string RowHeaderCellDefaultText
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.owGqAxI40f;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.owGqAxI40f = value;
            }
        }

        public DataGridViewCellStyle RowHeaderCellStyle
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.uwoqrOjZJc;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.uwoqrOjZJc = value;
            }
        }

        public RowHeightSetting RowHeight
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.80OqFTwLw0;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.80OqFTwLw0 = value;
            }
        }

        public bool ShowTotalPageNumber
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.j8sqEQfoV2;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.j8sqEQfoV2 = value;
            }
        }

        public string SubTitle
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.5W8jYOoDo;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.5W8jYOoDo = value;
            }
        }

        public StringAlignment SubTitleAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.DcdqqlFROG.Alignment;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.DcdqqlFROG.Alignment = value;
                this.fnl0TVqqT = true;
            }
        }

        public Color SubTitleColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.mdVqyR24PH;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.mdVqyR24PH = value;
            }
        }

        public Font SubTitleFont
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Vh8zqTUfK;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.Vh8zqTUfK = value;
            }
        }

        public StringFormat SubTitleFormat
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.DcdqqlFROG;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.DcdqqlFROG = value;
                this.fnl0TVqqT = true;
            }
        }

        public StringFormatFlags SubTitleFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.DcdqqlFROG.FormatFlags;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.DcdqqlFROG.FormatFlags = value;
                this.fnl0TVqqT = true;
            }
        }

        public float SubTitleSpacing
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.sHmqfL4JDR;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.sHmqfL4JDR = value;
            }
        }

        public Alignment TableAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.6faqm4rlQq;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.6faqm4rlQq = value;
            }
        }

        public string Title
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.PqYJx2gIB;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.PqYJx2gIB = value;
                if (this.KBkRKA3eR == null)
                {
                    this.75daGZAWD.DocumentName = value;
                }
            }
        }

        public StringAlignment TitleAlignment
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.nN6VZx4g9.Alignment;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.nN6VZx4g9.Alignment = value;
                this.VR6SykaOj = true;
            }
        }

        public Color TitleColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.xiC82G90C;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.xiC82G90C = value;
            }
        }

        public Font TitleFont
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.GptnlCn3M;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.GptnlCn3M = value;
            }
        }

        public StringFormat TitleFormat
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.nN6VZx4g9;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.nN6VZx4g9 = value;
                this.VR6SykaOj = true;
            }
        }

        public StringFormatFlags TitleFormatFlags
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.nN6VZx4g9.FormatFlags;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.nN6VZx4g9.FormatFlags = value;
                this.VR6SykaOj = true;
            }
        }

        public float TitleSpacing
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.uGG5ENOCq;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.uGG5ENOCq = value;
            }
        }

        public enum Alignment
        {
            NotSet,
            Left,
            Right,
            Center
        }

        public class ImbeddedImage
        {
            [CompilerGenerated]
            private int 37jAJ3Bnt;
            [CompilerGenerated]
            private DGVPrinter.Alignment 408MSTia8;
            [CompilerGenerated]
            private DGVPrinter.Location GPY6Re0PF;
            [CompilerGenerated]
            private int JiYUNJcCW;
            [CompilerGenerated]
            private Image XPOfx7u7N;

            [MethodImpl(MethodImplOptions.NoInlining)]
            internal Point mUvqAX6rk(int num3, int num1, Margins margins1)
            {
                int y = 0;
                int x = 0;
                switch (this.ImageLocation)
                {
                    case DGVPrinter.Location.Header:
                        y = margins1.Top;
                        break;

                    case DGVPrinter.Location.Footer:
                        y = (num1 - this.theImage.Height) - margins1.Bottom;
                        break;

                    case DGVPrinter.Location.Absolute:
                        return new Point(this.ImageX, this.ImageY);

                    default:
                        throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x594), this.ImageLocation));
                }
                switch (this.ImageAlignment)
                {
                    case DGVPrinter.Alignment.NotSet:
                        x = this.ImageX;
                        break;

                    case DGVPrinter.Alignment.Left:
                        x = margins1.Left;
                        break;

                    case DGVPrinter.Alignment.Right:
                        x = (num3 - this.theImage.Width) + margins1.Left;
                        break;

                    case DGVPrinter.Alignment.Center:
                        x = ((num3 / 2) - (this.theImage.Width / 2)) + margins1.Left;
                        break;

                    default:
                        throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5ba), this.ImageAlignment));
                }
                return new Point(x, y);
            }

            public DGVPrinter.Alignment ImageAlignment
            {
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                get
                {
                    return this.408MSTia8;
                }
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                set
                {
                    this.408MSTia8 = value;
                }
            }

            public DGVPrinter.Location ImageLocation
            {
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                get
                {
                    return this.GPY6Re0PF;
                }
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                set
                {
                    this.GPY6Re0PF = value;
                }
            }

            public int ImageX
            {
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                get
                {
                    return this.JiYUNJcCW;
                }
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                set
                {
                    this.JiYUNJcCW = value;
                }
            }

            public int ImageY
            {
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                get
                {
                    return this.37jAJ3Bnt;
                }
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                set
                {
                    this.37jAJ3Bnt = value;
                }
            }

            public Image theImage
            {
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                get
                {
                    return this.XPOfx7u7N;
                }
                [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
                set
                {
                    this.XPOfx7u7N = value;
                }
            }
        }

        public enum Location
        {
            Header,
            Footer,
            Absolute
        }

        public class PrintDialogSettingsClass
        {
            public bool AllowCurrentPage = true;
            public bool AllowPrintToFile = false;
            public bool AllowSelection = true;
            public bool AllowSomePages = true;
            public bool ShowHelp = true;
            public bool ShowNetwork = true;
            public bool UseEXDialog = true;
        }

        private class R96ZuxPqos5c833Rkw
        {
            public List<float> 408MSTia8;
            public float GPY6Re0PF;
            public Margins JiYUNJcCW;
            public IList mUvqAX6rk;
            public List<float> XPOfx7u7N;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public R96ZuxPqos5c833Rkw(Margins margins1, int num1)
            {
                this.mUvqAX6rk = new List<object>(num1);
                this.XPOfx7u7N = new List<float>(num1);
                this.408MSTia8 = new List<float>(num1);
                this.GPY6Re0PF = 0f;
                this.JiYUNJcCW = (Margins) margins1.Clone();
            }
        }

        public enum RowHeightSetting
        {
            StringHeight,
            CellHeight
        }
    }
}

