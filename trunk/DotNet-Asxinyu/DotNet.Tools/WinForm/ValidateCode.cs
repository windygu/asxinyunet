namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ValidateCode), "Resources.Icon.ValidateCode.ico"), Description("WinForm下的验证码控件"), DefaultProperty("CodeType")]
    public class ValidateCode : UserControl
    {
        private int _BlackPen = 50;
        private int _CodeLength = 4;
        private string _CodeText;
        private CodeTypeEnum _CodeType = CodeTypeEnum.数字;
        private string _TooltipText = "点击重新生成验证码";
        private IContainer components;
        private PictureBox picCode;
        private ToolTip toolTip1;

        public ValidateCode()
        {
            this.InitializeComponent();
        }

        private void CreateImage()
        {
            this.GetRanCode();
            Bitmap bitmap = null;
            try
            {
                int num = 20;
                if (bitmap != null) bitmap = null;
                int width = this._CodeLength * ((this._CodeType == CodeTypeEnum.数字和字母 || this._CodeType == CodeTypeEnum.字母) ? 0x10 : 14);
                int num2 = 0x18;
                bitmap = new Bitmap(width, num2);
                base.Width = bitmap.Width;
                base.Height = bitmap.Height;
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.AliceBlue);
                graphics.DrawRectangle(new Pen(Color.Black, 0f), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Random random = new Random();
                Pen pen = new Pen(Color.LightGray, 0f);
                for (int i = 0; i < this._BlackPen; i++)
                {
                    int x = random.Next(0, bitmap.Width);
                    int y = random.Next(0, bitmap.Height);
                    graphics.DrawRectangle(pen, x, y, 1, 1);
                }
                if (!string.IsNullOrEmpty(this._CodeText) && this._CodeText.Length > 0)
                {
                    char[] array = this._CodeText.ToCharArray();
                    StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    Color[] array2 = new Color[] { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                    string[] array3 = new string[] { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
                    int[] array4 = new int[] { 10, 12, 14, 0x10 };
                    int x2 = 9;
                    if (this._CodeType == CodeTypeEnum.数字和字母 || this._CodeType == CodeTypeEnum.字母) x2 = 11;
                    for (int j = 0; j < array.Length; j++)
                    {
                        int num3 = random.Next(7);
                        int num4 = random.Next(5);
                        int num5 = random.Next(4);
                        Font font = new Font(array3[num4], (float) array4[num5], FontStyle.Bold);
                        Brush brush = new SolidBrush(array2[num3]);
                        Point point = new Point(x2, num2 / 2);
                        float num6 = random.Next(-num, num);
                        graphics.TranslateTransform((float) point.X, (float) point.Y);
                        graphics.RotateTransform(num6);
                        graphics.DrawString(array[j].ToString(), font, brush, 1f, 1f, stringFormat);
                        graphics.RotateTransform(-num6);
                        graphics.TranslateTransform(2f, -((float) point.Y));
                    }
                }
            }
            catch (Exception)
            {
            }
            this.picCode.Image = bitmap;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void GetRanCode()
        {
            string text = "";
            string text2 = "123456789";
            try
            {
                if (this._CodeType == CodeTypeEnum.数字)
                    text2 = "123456789";
                else if (this._CodeType == CodeTypeEnum.字母)
                    text2 = "abcdefghijklmnopqrstuvwxyz";
                else if (this._CodeType == CodeTypeEnum.数字和字母) text2 = "123456789abcdefghijklmnopqrstuvwxyz";
                Random random = new Random();
                for (int i = 0; i < this._CodeLength; i++)
                {
                    text = text + text2.Substring(random.Next(0, text2.Length), 1);
                }
            }
            catch (Exception)
            {
            }
            this._CodeText = text.ToUpper();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.picCode = new PictureBox();
            this.toolTip1 = new ToolTip(this.components);
            ((ISupportInitialize) this.picCode).BeginInit();
            base.SuspendLayout();
            this.picCode.Dock = DockStyle.Fill;
            this.picCode.Location = new Point(0, 0);
            this.picCode.Name = "picCode";
            this.picCode.Size = new Size(0x34, 0x16);
            this.picCode.TabIndex = 0;
            this.picCode.TabStop = false;
            this.toolTip1.SetToolTip(this.picCode, "点击重新生成验证码");
            this.picCode.Click += new System.EventHandler(this.picCode_Click);
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.picCode);
            this.Cursor = Cursors.Hand;
            base.Name = "ValidateCode";
            base.Size = new Size(0x34, 0x16);
            base.Load += new System.EventHandler(this.ValidateCode_Load);
            ((ISupportInitialize) this.picCode).EndInit();
            base.ResumeLayout(false);
        }

        private void picCode_Click(object sender, EventArgs e) { this.CreateImage(); }

        private void ValidateCode_Load(object sender, EventArgs e)
        {
            this.CodeText = "";
            this.toolTip1.SetToolTip(this.picCode, this.CodeToolTipText);
            this.CreateImage();
        }

        [DefaultValue(50), Description("背景噪点数"), Category("自定义属性")]
        public int CodeBlackPen
        {
            get { return this._BlackPen; }
            set
            {
                this._BlackPen = value;
                if (this._BlackPen < 0) this._BlackPen = 50;
            }
        }

        [Category("自定义属性"), Description("随机码的长度"), DefaultValue(4)]
        public int CodeLength
        {
            get { return this._CodeLength; }
            set
            {
                this._CodeLength = value;
                if (this._CodeLength <= 1) this._CodeLength = 4;
            }
        }

        [Category("自定义属性"), DefaultValue(""), Description("验证码内容")]
        public string CodeText { get { return this._CodeText; } set { this._CodeText = value; } }

        [Description("重新生成验证码提示内容"), DefaultValue("点击重新生成验证码"), Category("自定义属性")]
        public string CodeToolTipText { get { return this._TooltipText; } set { this._TooltipText = value; } }

        [Category("自定义属性"), DefaultValue(1), Description("验证码类型：数字、字母、数字+字母")]
        public CodeTypeEnum CodeType
        {
            get { return this._CodeType; }
            set
            {
                this._CodeType = value;
                if (this._CodeType == CodeTypeEnum.数字)
                    this._CodeType = CodeTypeEnum.数字;
                else if (this._CodeType == CodeTypeEnum.字母)
                    this._CodeType = CodeTypeEnum.字母;
                else if (this._CodeType == CodeTypeEnum.数字和字母) this._CodeType = CodeTypeEnum.数字和字母;
            }
        }

        public enum CodeTypeEnum
        {
            数字 = 1,
            数字和字母 = 3,
            字母 = 2
        }
    }
}
