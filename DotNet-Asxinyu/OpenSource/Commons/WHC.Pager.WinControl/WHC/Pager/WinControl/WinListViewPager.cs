namespace WHC.Pager.WinControl
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WHC.Pager.Entity;

    public class WinListViewPager : UserControl
    {
        private bool bool_0 = false;
        private Button btnExport;
        private Button btnExportCurrent;
        public ContextMenuStrip contextMenuStrip1;
        private DataTable dataTable_0 = new DataTable();
        private IContainer icontainer_0 = null;
        public ListView listView1;
        private ToolStripMenuItem menu_Delete;
        private ToolStripMenuItem menu_Print;
        private ToolStripMenuItem menu_Refresh;
        private Pager pager;
        private WHC.Pager.Entity.PagerInfo pagerInfo_0 = null;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private SaveFileDialog saveFileDialog_0 = new SaveFileDialog();
        public DataTable TableToExport = new DataTable();
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;

        public event EventHandler OnDeleteSelected;

        public event EventHandler OnEndExport;

        public event EventHandler OnPageChanged;

        public event EventHandler OnRefresh;

        public event EventHandler OnStartExport;

        public WinListViewPager()
        {
            this.InitializeComponent();
            this.pager.PageChanged += new PageChangedEventHandler(this.pager_PageChanged);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.bool_0 = true;
            this.method_0();
        }

        private void btnExportCurrent_Click(object sender, EventArgs e)
        {
            this.bool_0 = false;
            this.method_0();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.icontainer_0 = new Container();
            this.btnExport = new Button();
            this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.menu_Delete = new ToolStripMenuItem();
            this.menu_Refresh = new ToolStripMenuItem();
            this.menu_Print = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.btnExportCurrent = new Button();
            this.listView1 = new ListView();
            this.pager = new Pager();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.btnExport.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnExport.Location = new Point(0x1cf, 0xb9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(0x4a, 0x17);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出全部页";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripSeparator1, this.menu_Delete, this.menu_Refresh, this.menu_Print, this.toolStripSeparator2 });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x9a, 0x52);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(150, 6);
            this.menu_Delete.Name = "menu_Delete";
            this.menu_Delete.Size = new Size(0x99, 0x16);
            this.menu_Delete.Text = "删除选定项(&D)";
            this.menu_Delete.Click += new EventHandler(this.menu_Delete_Click);
            this.menu_Refresh.Name = "menu_Refresh";
            this.menu_Refresh.Size = new Size(0x99, 0x16);
            this.menu_Refresh.Text = "刷新列表(&R)";
            this.menu_Refresh.Click += new EventHandler(this.menu_Refresh_Click);
            this.menu_Print.Name = "menu_Print";
            this.menu_Print.Size = new Size(0x99, 0x16);
            this.menu_Print.Text = "打印列表(&P)";
            this.menu_Print.Click += new EventHandler(this.menu_Print_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(150, 6);
            this.btnExportCurrent.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnExportCurrent.Location = new Point(0x17f, 0xb9);
            this.btnExportCurrent.Name = "btnExportCurrent";
            this.btnExportCurrent.Size = new Size(0x4a, 0x17);
            this.btnExportCurrent.TabIndex = 5;
            this.btnExportCurrent.Text = "导出当前页";
            this.btnExportCurrent.UseVisualStyleBackColor = true;
            this.btnExportCurrent.Click += new EventHandler(this.btnExportCurrent_Click);
            this.listView1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(540, 0xb3);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.pager.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.pager.CurrentPageIndex = 1;
            this.pager.Cursor = Cursors.Hand;
            this.pager.Location = new Point(-49, 0xb9);
            this.pager.Name = "pager";
            this.pager.PageSize = 20;
            this.pager.RecordCount = 0;
            this.pager.Size = new Size(0x1b2, 0x18);
            this.pager.TabIndex = 4;
            base.AutoScaleMode = AutoScaleMode.Inherit;
            base.Controls.Add(this.listView1);
            base.Controls.Add(this.btnExportCurrent);
            base.Controls.Add(this.btnExport);
            base.Controls.Add(this.pager);
            this.MinimumSize = new Size(540, 0);
            base.Name = "WinListViewPager";
            base.Size = new Size(540, 0xd4);
            base.Load += new EventHandler(this.WinListViewPager_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void menu_Delete_Click(object sender, EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this.listView1, new EventArgs());
            }
        }

        private void menu_Print_Click(object sender, EventArgs e)
        {
        }

        private void menu_Refresh_Click(object sender, EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this.listView1, new EventArgs());
            }
        }

        private void method_0()
        {
            this.saveFileDialog_0 = new SaveFileDialog();
            this.saveFileDialog_0.Filter = "Excel (*.xls)|*.xls";
            if (this.saveFileDialog_0.ShowDialog() == DialogResult.OK)
            {
                if (!this.saveFileDialog_0.FileName.Equals(string.Empty))
                {
                    FileInfo info = new FileInfo(this.saveFileDialog_0.FileName);
                    if (info.Extension.ToLower().Equals(".xls"))
                    {
                        this.method_1(this.saveFileDialog_0.FileName);
                    }
                    else
                    {
                        MessageBox.Show("文件格式不正确");
                    }
                }
                else
                {
                    MessageBox.Show("需要指定一个保存的目录");
                }
            }
        }

        private void method_1(string string_0)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, new EventArgs());
            }
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.method_2);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_3);
            worker.RunWorkerAsync(string_0);
        }

        private void method_2(object sender, DoWorkEventArgs e)
        {
            DataTable datatable = this.dataTable_0;
            if ((this.TableToExport != null) && this.bool_0)
            {
                datatable = this.TableToExport;
            }
            string error = "";
            AsposeExcelTools.DataTableToExcel2(datatable, (string) e.Argument, out error);
        }

        private void method_3(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, new EventArgs());
            }
            if (MessageBox.Show("导出操作完成, 您想打开该Excel文件么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Process.Start(this.saveFileDialog_0.FileName);
            }
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, new EventArgs());
            }
        }

        private void WinListViewPager_Load(object sender, EventArgs e)
        {
            if (this.ContextMenuStrip == null)
            {
                this.ContextMenuStrip = new ContextMenuStrip();
            }
            for (int i = 0; i < this.contextMenuStrip1.Items.Count; i++)
            {
                ToolStripItem item = this.contextMenuStrip1.Items[i];
                this.ContextMenuStrip.Items.Add(item);
            }
        }

        public DataTable DataSource
        {
            get
            {
                return this.dataTable_0;
            }
            set
            {
                this.dataTable_0 = value;
                this.listView1.Columns.Clear();
                foreach (DataColumn column in value.Columns)
                {
                    this.listView1.Columns.Add(column.ColumnName, 120);
                }
                this.listView1.Items.Clear();
                foreach (DataRow row in value.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    item.SubItems[0].Text = row[0].ToString();
                    for (int i = 1; i < value.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    this.listView1.Items.Add(item);
                }
                this.pager.InitPageInfo(this.PagerInfo.RecordCount);
            }
        }

        public WHC.Pager.Entity.PagerInfo PagerInfo
        {
            get
            {
                if (this.pagerInfo_0 == null)
                {
                    this.pagerInfo_0 = new WHC.Pager.Entity.PagerInfo();
                    this.pagerInfo_0.RecordCount = this.pager.RecordCount;
                    this.pagerInfo_0.CurrenetPageIndex = this.pager.CurrentPageIndex;
                    this.pagerInfo_0.PageSize = this.pager.PageSize;
                }
                else
                {
                    this.pagerInfo_0.CurrenetPageIndex = this.pager.CurrentPageIndex;
                }
                return this.pagerInfo_0;
            }
        }
    }
}

