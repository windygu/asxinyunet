namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    [Description("WinForm下的分页控件"), DefaultEvent("PageIndexChanged"), ToolboxBitmap(typeof(WinFormPager), "Resources.Icon.Pager.ico"), DefaultProperty("RecordCount")]
    public class WinFormPager : UserControl
    {
        private string _BtnTextFirst = "首页";
        private string _BtnTextLast = "末页";
        private string _BtnTextNext = "下一页";
        private string _BtnTextPrevious = "上一页";
        private DisplayStyleEnum _DisplayStyle = DisplayStyleEnum.图片;
        private string _JumpText = "跳转";
        private int _PageCount;
        private int _PageIndex = 1;
        private int _PageSize = 10;
        private int _RecordCount;
        private TextImageRalitionEnum _TextImageRalition = TextImageRalitionEnum.图片显示在文字前方;
        private Button btnFirst;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnToPageIndex;
        private IContainer components;
        private ImageList imglstPager;
        private Label label1;
        private Label label3;
        private Label lblPager;
        private string PagerText = "总共{0}条记录,当前第{1}页,共{2}页,每页{3}条记录";
        private ToolTip toolTipPager;
        private TextBox txtToPageIndex;

        [Category("自定义事件"), Description("更改页面索引事件")]
        public event EventHandler PageIndexChanged;

        public WinFormPager()
        {
            this.InitializeComponent();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this._PageIndex = 1;
            this.SetPagerText();
            this.SetBtnEnabled();
            this.SetLabelLocation();
            this.CustomEvent(sender, e);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this._PageIndex = this._PageCount;
            this.SetPagerText();
            this.SetBtnEnabled();
            this.SetLabelLocation();
            this.CustomEvent(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int pageIndex = this._PageIndex;
            try
            {
                int num = Convert.ToInt32(pageIndex) + 1;
                if (num >= this._PageCount) num = this._PageCount;
                this._PageIndex = num;
                this.SetPagerText();
                this.SetBtnEnabled();
                this.SetLabelLocation();
                this.CustomEvent(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int pageIndex = this._PageIndex;
            try
            {
                int num = Convert.ToInt32(pageIndex) - 1;
                if (num <= 0) num = 1;
                this._PageIndex = num;
                this.SetPagerText();
                this.SetBtnEnabled();
                this.SetLabelLocation();
                this.CustomEvent(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void btnToPageIndex_Click(object sender, EventArgs e)
        {
            string text = this.txtToPageIndex.Text;
            int num = this._PageIndex;
            if (string.IsNullOrEmpty(text))
                this.txtToPageIndex.Text = "1";
            else
            {
                num = Convert.ToInt32(text);
                if (num > this._PageCount)
                {
                    num = this._PageCount;
                    this.txtToPageIndex.Text = this._PageCount.ToString();
                }
                else
                {
                    this._PageIndex = num;
                    this.SetPagerText();
                    this.SetBtnEnabled();
                    this.SetLabelLocation();
                    this.CustomEvent(sender, e);
                }
            }
        }

        private void CustomEvent(object sender, EventArgs e)
        {
            try
            {
                this.PageIndexChanged(sender, e);
            }
            catch (Exception)
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        protected int GetPageCount(int RecordCounts, int PageSizes)
        {
            int result = 0;
            string text = (Convert.ToDouble(RecordCounts) / Convert.ToDouble(PageSizes)).ToString();
            if (text.IndexOf(".") < 0) return Convert.ToInt32(text);
            string[] array = Regex.Split(text, @"\.", RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(array[1].ToString())) result = Convert.ToInt32(array[0]) + 1;
            return result;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(WinFormPager));
            this.lblPager = new Label();
            this.btnFirst = new Button();
            this.imglstPager = new ImageList(this.components);
            this.btnPrevious = new Button();
            this.btnNext = new Button();
            this.btnLast = new Button();
            this.label3 = new Label();
            this.btnToPageIndex = new Button();
            this.txtToPageIndex = new TextBox();
            this.toolTipPager = new ToolTip(this.components);
            this.label1 = new Label();
            base.SuspendLayout();
            this.lblPager.AutoSize = true;
            this.lblPager.BackColor = Color.Transparent;
            this.lblPager.Location = new Point(4, 7);
            this.lblPager.Name = "lblPager";
            this.lblPager.Size = new Size(0xf5, 12);
            this.lblPager.TabIndex = 0;
            this.lblPager.Text = "总共0条记录,当前第1页,共1页,每页20条记录";
            this.btnFirst.AutoSize = true;
            this.btnFirst.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnFirst.BackColor = Color.Transparent;
            this.btnFirst.Cursor = Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = FlatStyle.Flat;
            this.btnFirst.ForeColor = SystemColors.ControlText;
            this.btnFirst.ImageIndex = 0;
            this.btnFirst.ImageList = this.imglstPager;
            this.btnFirst.Location = new Point(0xf9, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new Size(0x16, 0x16);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.TabStop = false;
            this.btnFirst.TextAlign = ContentAlignment.MiddleLeft;
            this.btnFirst.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.toolTipPager.SetToolTip(this.btnFirst, "转到首页");
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            this.imglstPager.ImageStream = (ImageListStreamer) resources.GetObject("imglstPager.ImageStream");
            this.imglstPager.TransparentColor = Color.Transparent;
            this.imglstPager.Images.SetKeyName(0, "resultset_first.png");
            this.imglstPager.Images.SetKeyName(1, "resultset_previous.png");
            this.imglstPager.Images.SetKeyName(2, "resultset_next.png");
            this.imglstPager.Images.SetKeyName(3, "resultset_last.png");
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnPrevious.BackColor = Color.Transparent;
            this.btnPrevious.Cursor = Cursors.Hand;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = FlatStyle.Flat;
            this.btnPrevious.ForeColor = SystemColors.ControlText;
            this.btnPrevious.ImageIndex = 1;
            this.btnPrevious.ImageList = this.imglstPager;
            this.btnPrevious.Location = new Point(0x115, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new Size(0x16, 0x16);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.toolTipPager.SetToolTip(this.btnPrevious, "转到上一页");
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnNext.BackColor = Color.Transparent;
            this.btnNext.Cursor = Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.ForeColor = SystemColors.ControlText;
            this.btnNext.ImageIndex = 2;
            this.btnNext.ImageList = this.imglstPager;
            this.btnNext.Location = new Point(0x12f, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(0x16, 0x16);
            this.btnNext.TabIndex = 1;
            this.btnNext.TabStop = false;
            this.btnNext.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.toolTipPager.SetToolTip(this.btnNext, "转到下一页");
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnLast.AutoSize = true;
            this.btnLast.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnLast.BackColor = Color.Transparent;
            this.btnLast.Cursor = Cursors.Hand;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = FlatStyle.Flat;
            this.btnLast.ForeColor = SystemColors.ControlText;
            this.btnLast.ImageIndex = 3;
            this.btnLast.ImageList = this.imglstPager;
            this.btnLast.Location = new Point(0x14b, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new Size(0x16, 0x16);
            this.btnLast.TabIndex = 1;
            this.btnLast.TabStop = false;
            this.btnLast.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.toolTipPager.SetToolTip(this.btnLast, "转到最后一页");
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(0x167, 7);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x11, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "第";
            this.btnToPageIndex.AutoSize = true;
            this.btnToPageIndex.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnToPageIndex.BackColor = Color.Transparent;
            this.btnToPageIndex.Cursor = Cursors.Hand;
            this.btnToPageIndex.FlatAppearance.BorderSize = 0;
            this.btnToPageIndex.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnToPageIndex.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnToPageIndex.FlatStyle = FlatStyle.Flat;
            this.btnToPageIndex.Location = new Point(450, 2);
            this.btnToPageIndex.Name = "btnToPageIndex";
            this.btnToPageIndex.Size = new Size(0x27, 0x16);
            this.btnToPageIndex.TabIndex = 3;
            this.btnToPageIndex.TabStop = false;
            this.btnToPageIndex.Text = "跳转";
            this.toolTipPager.SetToolTip(this.btnToPageIndex, "跳转到指定的页");
            this.btnToPageIndex.UseVisualStyleBackColor = false;
            this.btnToPageIndex.Click += new System.EventHandler(this.btnToPageIndex_Click);
            this.txtToPageIndex.ImeMode = ImeMode.Disable;
            this.txtToPageIndex.Location = new Point(0x17a, 3);
            this.txtToPageIndex.Name = "txtToPageIndex";
            this.txtToPageIndex.Size = new Size(50, 0x15);
            this.txtToPageIndex.TabIndex = 2;
            this.txtToPageIndex.TabStop = false;
            this.txtToPageIndex.Text = "1";
            this.txtToPageIndex.TextAlign = HorizontalAlignment.Center;
            this.toolTipPager.SetToolTip(this.txtToPageIndex, "请输入要跳转到的页");
            this.txtToPageIndex.KeyPress += new KeyPressEventHandler(this.txtToPageIndex_KeyPress);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(0x1b2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x11, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "页";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = Resource.PageBg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.Controls.Add(this.btnToPageIndex);
            base.Controls.Add(this.txtToPageIndex);
            base.Controls.Add(this.btnLast);
            base.Controls.Add(this.btnNext);
            base.Controls.Add(this.btnPrevious);
            base.Controls.Add(this.btnFirst);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.lblPager);
            base.ImeMode = ImeMode.Disable;
            base.Name = "WinFormPager";
            base.Size = new Size(0x1ec, 0x1b);
            base.Load += new System.EventHandler(this.Pager_Load);
            base.Paint += new PaintEventHandler(this.Pager_Paint);
            base.MouseMove += new MouseEventHandler(this.WinFormPager_MouseMove);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Pager_Load(object sender, EventArgs e)
        {
            this.SetBtnEnabled();
            this.btnToPageIndex.Text = this._JumpText;
        }

        private void Pager_Paint(object sender, PaintEventArgs e)
        {
            this._PageCount = this.GetPageCount(this._RecordCount, this._PageSize);
            this.SetPagerText();
            this.SetDisplayStyle();
            this.SetLabelLocation();
        }

        protected void SetBtnEnabled()
        {
            if (this._PageIndex == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else if (this._PageIndex > 1 && this._PageIndex < this._PageCount)
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else if (this._PageIndex == this._PageCount)
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }

        private void SetDisplayStyle()
        {
            TextImageRelation textImageRelation = TextImageRelation.ImageBeforeText;
            if (this.TextImageRalitions == TextImageRalitionEnum.图片显示在文字上方)
                textImageRelation = TextImageRelation.ImageAboveText;
            else if (this.TextImageRalitions == TextImageRalitionEnum.图片显示在文字下方)
                textImageRelation = TextImageRelation.TextAboveImage;
            else if (this.TextImageRalitions == TextImageRalitionEnum.图片显示在文字前方)
                textImageRelation = TextImageRelation.ImageBeforeText;
            else if (this.TextImageRalitions == TextImageRalitionEnum.图片显示在文字后方) textImageRelation = TextImageRelation.TextBeforeImage;
            if (this.DisplayStyle == DisplayStyleEnum.图片)
            {
                this.btnFirst.ImageList = this.btnPrevious.ImageList = this.btnNext.ImageList = this.btnLast.ImageList = this.imglstPager;
                this.btnFirst.ImageIndex = 0;
                this.btnPrevious.ImageIndex = 1;
                this.btnNext.ImageIndex = 2;
                this.btnLast.ImageIndex = 3;
                this.btnFirst.Text = this.btnPrevious.Text = this.btnNext.Text = this.btnLast.Text = "";
                this.btnFirst.TextImageRelation = this.btnPrevious.TextImageRelation = this.btnNext.TextImageRelation = this.btnLast.TextImageRelation = TextImageRelation.Overlay;
            }
            else if (this.DisplayStyle == DisplayStyleEnum.文字)
            {
                this.btnFirst.ImageList = this.btnPrevious.ImageList = this.btnNext.ImageList = (ImageList) (this.btnLast.ImageList = null);
                this.btnFirst.Text = string.IsNullOrEmpty(this.BtnTextFirst) ? "首页" : this.BtnTextFirst;
                this.btnPrevious.Text = string.IsNullOrEmpty(this.BtnTextPrevious) ? "上一页" : this.BtnTextPrevious;
                this.btnNext.Text = string.IsNullOrEmpty(this.BtnTextNext) ? "下一页" : this.BtnTextNext;
                this.btnLast.Text = string.IsNullOrEmpty(this.BtnTextLast) ? "末页" : this.BtnTextLast;
                this.btnFirst.TextImageRelation = this.btnPrevious.TextImageRelation = this.btnNext.TextImageRelation = this.btnLast.TextImageRelation = TextImageRelation.Overlay;
            }
            else if (this.DisplayStyle == DisplayStyleEnum.图片及文字)
            {
                this.btnFirst.ImageList = this.btnPrevious.ImageList = this.btnNext.ImageList = this.btnLast.ImageList = this.imglstPager;
                this.btnFirst.ImageIndex = 0;
                this.btnPrevious.ImageIndex = 1;
                this.btnNext.ImageIndex = 2;
                this.btnLast.ImageIndex = 3;
                this.btnFirst.Text = string.IsNullOrEmpty(this.BtnTextFirst) ? "首页" : this.BtnTextFirst;
                this.btnPrevious.Text = string.IsNullOrEmpty(this.BtnTextPrevious) ? "上一页" : this.BtnTextPrevious;
                this.btnNext.Text = string.IsNullOrEmpty(this.BtnTextNext) ? "下一页" : this.BtnTextNext;
                this.btnLast.Text = string.IsNullOrEmpty(this.BtnTextLast) ? "末页" : this.BtnTextLast;
                this.btnFirst.TextImageRelation = this.btnPrevious.TextImageRelation = this.btnNext.TextImageRelation = this.btnLast.TextImageRelation = textImageRelation;
            }
        }

        protected void SetLabelLocation()
        {
            this.btnFirst.Left = this.lblPager.Left + this.lblPager.Width + 10;
            this.btnPrevious.Left = this.btnFirst.Left + this.btnFirst.Width;
            this.btnNext.Left = this.btnPrevious.Left + this.btnPrevious.Width;
            this.btnLast.Left = this.btnNext.Left + this.btnNext.Width;
            this.label3.Left = this.btnLast.Left + this.btnLast.Width + 10;
            this.txtToPageIndex.Left = this.label3.Left + this.label3.Width;
            this.label1.Left = this.txtToPageIndex.Left + this.txtToPageIndex.Width;
            this.btnToPageIndex.Left = this.label1.Left + this.label1.Width;
        }

        private void SetPagerText()
        {
            string[] args = new string[] { this.RecordCount.ToString(), this.PageIndex.ToString(), this.PageCount.ToString(), this.PageSize.ToString() };
            this.lblPager.Text = string.Format(this.PagerText, (object[]) args);
        }

        private void txtToPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                if (e.KeyChar == '\r')
                    this.btnToPageIndex_Click(new object(), new EventArgs());
                else
                    e.Handled = true;
            }
        }

        private void WinFormPager_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button) control;
                    button.BackColor = Color.Transparent;
                    button.FlatAppearance.BorderColor = Color.White;
                    button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                }
            }
        }

        [Description("首页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效"), Category("自定义属性"), DefaultValue("首页")]
        public string BtnTextFirst
        {
            get { return this._BtnTextFirst; }
            set
            {
                this._BtnTextFirst = value;
                this.SetDisplayStyle();
            }
        }

        [Category("自定义属性"), DefaultValue("末页"), Description("末页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        public string BtnTextLast
        {
            get { return this._BtnTextLast; }
            set
            {
                this._BtnTextLast = value;
                this.SetDisplayStyle();
            }
        }

        [Category("自定义属性"), Description("下一页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效"), DefaultValue("下一页")]
        public string BtnTextNext
        {
            get { return this._BtnTextNext; }
            set
            {
                this._BtnTextNext = value;
                this.SetDisplayStyle();
            }
        }

        [Category("自定义属性"), Description("上一页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效"), DefaultValue("上一页")]
        public string BtnTextPrevious
        {
            get { return this._BtnTextPrevious; }
            set
            {
                this._BtnTextPrevious = value;
                this.SetDisplayStyle();
            }
        }

        [DefaultValue(1), Category("自定义属性"), Description("显示类型：图片、文字、图片及文字")]
        public DisplayStyleEnum DisplayStyle
        {
            get { return this._DisplayStyle; }
            set
            {
                this._DisplayStyle = value;
                this.SetDisplayStyle();
            }
        }

        [Category("自定义属性"), DefaultValue("跳转"), Description("跳转按钮文字")]
        public string JumpText
        {
            get { return this._JumpText; }
            set
            {
                this._JumpText = value;
                this.btnToPageIndex.Text = this._JumpText;
            }
        }

        private int PageCount { get { return this._PageCount; } }

        [DefaultValue(1), Description("当前显示的页数"), Category("自定义属性")]
        public int PageIndex { get { return this._PageIndex; } set { this._PageIndex = value; } }

        [Description("每页显示的记录数"), Category("自定义属性"), DefaultValue(10)]
        public int PageSize
        {
            get { return this._PageSize; }
            set
            {
                if (value <= 1) value = 10;
                this._PageSize = value;
                this.SetLabelLocation();
            }
        }

        [Category("自定义属性"), Description("要分页的总记录数")]
        public int RecordCount { get { return this._RecordCount; } set { this._RecordCount = value; } }

        [DefaultValue(3), Category("自定义属性"), Description("图片和文字显示相对位置,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        public TextImageRalitionEnum TextImageRalitions
        {
            get { return this._TextImageRalition; }
            set
            {
                this._TextImageRalition = value;
                this.SetDisplayStyle();
            }
        }

        public enum DisplayStyleEnum
        {
            图片 = 1,
            图片及文字 = 3,
            文字 = 2
        }

        public delegate void EventHandler(object sender, EventArgs e);

        public enum TextImageRalitionEnum
        {
            图片显示在文字后方 = 4,
            图片显示在文字前方 = 3,
            图片显示在文字上方 = 1,
            图片显示在文字下方 = 2
        }
    }
}
