namespace WHC.Pager.WinControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class Pager : UserControl
    {
        private Button btnExport;
        private Button btnExportCurrent;
        private Button btnFirst;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Container container_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private Label lblPageInfo;
        private TextBox txtCurrentPage;

        public event ExportAllEventHandler ExportAll;

        public event ExportCurrentEventHandler ExportCurrent;

        public event PageChangedEventHandler PageChanged;

        public Pager()
        {
            this.container_0 = null;
            this.InitializeComponent();
            this.int_0 = 50;
            this.int_2 = 0;
            this.int_3 = 1;
            this.InitPageInfo();
        }

        public Pager(int recordCount, int pageSize)
        {
            this.container_0 = null;
            this.InitializeComponent();
            this.int_0 = pageSize;
            this.int_2 = recordCount;
            this.int_3 = 1;
            this.InitPageInfo();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.exportAllEventHandler_0 != null)
            {
                this.exportAllEventHandler_0(sender, e);
            }
        }

        private void btnExportCurrent_Click(object sender, EventArgs e)
        {
            if (this.exportCurrentEventHandler_0 != null)
            {
                this.exportCurrentEventHandler_0(sender, e);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.RefreshData(1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.int_1 > 0)
            {
                this.RefreshData(this.int_1);
            }
            else
            {
                this.RefreshData(1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.int_3 < this.int_1)
            {
                this.RefreshData(this.int_3 + 1);
            }
            else if (this.int_1 < 1)
            {
                this.RefreshData(1);
            }
            else
            {
                this.RefreshData(this.int_1);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.int_3 > 1)
            {
                this.RefreshData(this.int_3 - 1);
            }
            else
            {
                this.RefreshData(1);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.container_0 != null))
            {
                this.container_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPageInfo = new Label();
            this.txtCurrentPage = new TextBox();
            this.btnNext = new Button();
            this.btnFirst = new Button();
            this.btnPrevious = new Button();
            this.btnLast = new Button();
            this.btnExport = new Button();
            this.btnExportCurrent = new Button();
            base.SuspendLayout();
            this.lblPageInfo.Location = new Point(0x1c, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new Size(0x108, 0x10);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共 {0} 条记录，每页 {1} 条，共 {2} 页";
            this.lblPageInfo.TextAlign = ContentAlignment.MiddleRight;
            this.txtCurrentPage.Location = new Point(0x16c, 8);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new Size(0x19, 0x15);
            this.txtCurrentPage.TabIndex = 5;
            this.txtCurrentPage.Text = "1";
            this.txtCurrentPage.TextAlign = HorizontalAlignment.Right;
            this.txtCurrentPage.KeyDown += new KeyEventHandler(this.txtCurrentPage_KeyDown);
            this.btnNext.Location = new Point(0x188, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(30, 20);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">";
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            this.btnFirst.Location = new Point(300, 8);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new Size(30, 20);
            this.btnFirst.TabIndex = 7;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new EventHandler(this.btnFirst_Click);
            this.btnPrevious.Location = new Point(0x14c, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new Size(30, 20);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new EventHandler(this.btnPrevious_Click);
            this.btnLast.Location = new Point(0x1a8, 8);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new Size(30, 20);
            this.btnLast.TabIndex = 9;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new EventHandler(this.btnLast_Click);
            this.btnExport.Location = new Point(0x224, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(0x4a, 0x17);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "导出全部页";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            this.btnExportCurrent.Location = new Point(0x1d4, 6);
            this.btnExportCurrent.Name = "btnExportCurrent";
            this.btnExportCurrent.Size = new Size(0x4a, 0x17);
            this.btnExportCurrent.TabIndex = 10;
            this.btnExportCurrent.Text = "导出当前页";
            this.btnExportCurrent.UseVisualStyleBackColor = true;
            this.btnExportCurrent.Click += new EventHandler(this.btnExportCurrent_Click);
            base.Controls.Add(this.btnExport);
            base.Controls.Add(this.btnExportCurrent);
            base.Controls.Add(this.btnLast);
            base.Controls.Add(this.btnPrevious);
            base.Controls.Add(this.btnFirst);
            base.Controls.Add(this.btnNext);
            base.Controls.Add(this.txtCurrentPage);
            base.Controls.Add(this.lblPageInfo);
            this.Cursor = Cursors.Hand;
            base.Name = "Pager";
            base.Size = new Size(0x287, 0x23);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void InitPageInfo()
        {
            if (this.int_0 < 1)
            {
                this.int_0 = 10;
            }
            if (this.int_2 < 0)
            {
                this.int_2 = 0;
            }
            if ((this.int_2 % this.int_0) == 0)
            {
                this.int_1 = this.int_2 / this.int_0;
            }
            else
            {
                this.int_1 = (this.int_2 / this.int_0) + 1;
            }
            if (this.int_3 > this.int_1)
            {
                this.int_3 = this.int_1;
            }
            if (this.int_3 < 1)
            {
                this.int_3 = 1;
            }
            bool flag = this.CurrentPageIndex > 1;
            this.btnPrevious.Enabled = flag;
            flag = this.CurrentPageIndex < this.PageCount;
            this.btnNext.Enabled = flag;
            this.txtCurrentPage.Text = this.int_3.ToString();
            this.lblPageInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", this.int_2, this.int_0, this.int_1);
        }

        public void InitPageInfo(int recordCount)
        {
            this.int_2 = recordCount;
            this.InitPageInfo();
        }

        public void InitPageInfo(int recordCount, int pageSize)
        {
            this.int_2 = recordCount;
            this.int_0 = pageSize;
            this.InitPageInfo();
        }

        protected virtual void OnPageChanged(EventArgs e)
        {
            if (this.pageChangedEventHandler_0 != null)
            {
                this.pageChangedEventHandler_0(this, e);
            }
        }

        public void RefreshData(int page)
        {
            this.int_3 = page;
            EventArgs e = new EventArgs();
            this.OnPageChanged(e);
        }

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                int num;
                try
                {
                    num = Convert.ToInt16(this.txtCurrentPage.Text);
                }
                catch (Exception)
                {
                    num = 1;
                }
                if (num > this.int_1)
                {
                    num = this.int_1;
                }
                if (num < 1)
                {
                    num = 1;
                }
                this.RefreshData(num);
            }
        }

        [Description("当前的页面索引, 开始为1"), Browsable(false), Category("分页"), DefaultValue(0)]
        public int CurrentPageIndex
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        [Description("获取记录总页数"), DefaultValue(0), Category("分页")]
        public int PageCount
        {
            get
            {
                return this.int_1;
            }
        }

        [DefaultValue(50), Description("设置或获取一页中显示的记录数目"), Category("分页")]
        public int PageSize
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        [Category("分页"), Description("设置或获取记录总数")]
        public int RecordCount
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }
    }
}

