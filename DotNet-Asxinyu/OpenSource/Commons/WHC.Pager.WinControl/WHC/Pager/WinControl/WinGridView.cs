﻿namespace WHC.Pager.WinControl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class WinGridView : UserControl
    {
        public DataTable AllToExport;
        private bool bool_0 = false;
        private ContextMenuStrip contextMenuStrip_0;
        private ContextMenuStrip contextMenuStrip1;
        public DataGridView dataGridView1;
        private Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();
        private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();
        private IContainer icontainer_0 = null;
        private ToolStripMenuItem menu_Add;
        private ToolStripMenuItem menu_Buy;
        private ToolStripMenuItem menu_Delete;
        private ToolStripMenuItem menu_Edit;
        private ToolStripMenuItem menu_Export;
        private ToolStripMenuItem menu_Print;
        private ToolStripMenuItem menu_Refresh;
        private object object_0;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private SaveFileDialog saveFileDialog_0 = new SaveFileDialog();
        private string string_0 = "";
        private string string_1 = "";
        private ToolStripSeparator toolStripSeparator1;

        public event EventHandler OnAddNew;

        public event EventHandler OnDeleteSelected;

        public event EventHandler OnEditSelected;

        public event EventHandler OnEndExport;

        public event EventHandler OnPageChanged;

        public event EventHandler OnRefresh;

        public event EventHandler OnStartExport;

        public WinGridView()
        {
            this.InitializeComponent();
            this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            if (LicenseTool.CheckLicense().IsValided)
            {
                this.menu_Buy.Visible = false;
            }
        }

        public void AddColumnAlias(string key, string alias)
        {
            if (!(string.IsNullOrEmpty(key) || string.IsNullOrEmpty(alias)) && !this.dictionary_1.ContainsKey(key))
            {
                this.dictionary_1.Add(key, alias);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this.dataGridView1, new EventArgs());
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[i];
                if ((i % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int num;
            string key = string.Empty;
            this.dataGridView1.AutoGenerateColumns = false;
            for (num = 0; num < this.dataGridView1.Columns.Count; num++)
            {
                DataGridViewColumn column = this.dataGridView1.Columns[num];
                key = column.Name;
                if (this.dictionary_1.ContainsKey(key))
                {
                    column.HeaderText = this.dictionary_1[key];
                }
            }
            object obj2 = "";
            for (num = 0; num < this.dataGridView1.Rows.Count; num++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[num];
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    obj2 = row.Cells[i].Value;
                    if ((obj2 != null) && ((obj2.ToString().IndexOf("1753-01-01") == 0) || (obj2.ToString().IndexOf("1753-1-1") == 0)))
                    {
                        row.Cells[i].Value = "";
                    }
                }
                if ((num % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat("行数据基本信息：\r\n\t", new object[0]);
                    for (int j = 0; j < this.dataGridView1.Rows[e.RowIndex].Cells.Count; j++)
                    {
                        if (this.dataGridView1.Columns[j].Visible)
                        {
                            DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[j];
                            builder.AppendFormat("{0}：{1}\r\n\t", this.dataGridView1.Columns[j].HeaderText, cell.Value);
                        }
                    }
                    this.dataGridView1[i, e.RowIndex].ToolTipText = builder.ToString();
                }
            }
            catch
            {
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                this.dataGridView1[i, e.RowIndex].ToolTipText = string.Empty;
            }
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
            this.dataGridView1 = new DataGridView();
            this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.menu_Add = new ToolStripMenuItem();
            this.menu_Edit = new ToolStripMenuItem();
            this.menu_Delete = new ToolStripMenuItem();
            this.menu_Refresh = new ToolStripMenuItem();
            this.menu_Print = new ToolStripMenuItem();
            this.menu_Export = new ToolStripMenuItem();
            this.menu_Buy = new ToolStripMenuItem();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(540, 0xd4);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowLeave += new DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.DataSourceChanged += new EventHandler(this.dataGridView1_DataSourceChanged);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripSeparator1, this.menu_Add, this.menu_Edit, this.menu_Delete, this.menu_Refresh, this.menu_Print, this.menu_Export, this.menu_Buy });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x161, 0xba);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0x15d, 6);
            this.menu_Add.Name = "menu_Add";
            this.menu_Add.Size = new Size(0x160, 0x16);
            this.menu_Add.Text = "新建(&N)";
            this.menu_Add.Click += new EventHandler(this.menu_Add_Click);
            this.menu_Edit.Name = "menu_Edit";
            this.menu_Edit.Size = new Size(0x160, 0x16);
            this.menu_Edit.Text = "编辑选定项(&E)";
            this.menu_Edit.Click += new EventHandler(this.menu_Edit_Click);
            this.menu_Delete.Name = "menu_Delete";
            this.menu_Delete.Size = new Size(0x160, 0x16);
            this.menu_Delete.Text = "删除选定项(&D)";
            this.menu_Delete.Click += new EventHandler(this.menu_Delete_Click);
            this.menu_Refresh.Name = "menu_Refresh";
            this.menu_Refresh.Size = new Size(0x160, 0x16);
            this.menu_Refresh.Text = "刷新列表(&R)";
            this.menu_Refresh.Click += new EventHandler(this.menu_Refresh_Click);
            this.menu_Print.Name = "menu_Print";
            this.menu_Print.Size = new Size(0x160, 0x16);
            this.menu_Print.Text = "打印列表(&P)";
            this.menu_Print.Click += new EventHandler(this.menu_Print_Click);
            this.menu_Export.Name = "menu_Export";
            this.menu_Export.Size = new Size(0x160, 0x16);
            this.menu_Export.Text = "导出数据(&E)";
            this.menu_Export.Click += new EventHandler(this.menu_Export_Click);
            this.menu_Buy.ForeColor = Color.Red;
            this.menu_Buy.Name = "menu_Buy";
            this.menu_Buy.Size = new Size(0x160, 0x16);
            this.menu_Buy.Text = "未注册版本，购买请访问http://www.iqidi.com（&G)";
            this.menu_Buy.Click += new EventHandler(this.menu_Buy_Click);
            base.AutoScaleMode = AutoScaleMode.Inherit;
            base.Controls.Add(this.dataGridView1);
            this.MinimumSize = new Size(540, 0);
            base.Name = "WinGridView";
            base.Size = new Size(540, 0xd4);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void menu_Add_Click(object sender, EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Buy_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.iqidi.com");
        }

        private void menu_Delete_Click(object sender, EventArgs e)
        {
            if (this.xtdkjpEav != null)
            {
                this.xtdkjpEav(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Edit_Click(object sender, EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this.dataGridView1, new EventArgs());
            }
        }

        private void menu_Export_Click(object sender, EventArgs e)
        {
            this.bool_0 = false;
            this.method_5();
        }

        private void menu_Print_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dataGridView1, this.string_1);
        }

        private void menu_Refresh_Click(object sender, EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this.dataGridView1, new EventArgs());
            }
        }

        private void method_0(object object_1)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();
            if (object_1 != null)
            {
                IEnumerator enumerator;
                DataGridViewColumn column;
                int num = 0;
                if (object_1 is DataView)
                {
                    DataView view = object_1 as DataView;
                    DataTable table = view.Table;
                    if (table == null)
                    {
                        return;
                    }
                    Dictionary<string, string> dictionary = this.method_1(table);
                    using (enumerator = table.Rows.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            foreach (KeyValuePair<string, string> pair in dictionary)
                            {
                                if (pair.Value == "System.Boolean")
                                {
                                    column = new DataGridViewCheckBoxColumn();
                                }
                                else
                                {
                                    column = new DataGridViewTextBoxColumn();
                                }
                                column.Name = pair.Key;
                                column.HeaderText = pair.Key;
                                column.DataPropertyName = pair.Key;
                                if (!((this.dictionary_0.Count <= 0) || this.dictionary_0.ContainsKey(pair.Key)))
                                {
                                    column.Width = 0;
                                    column.Visible = false;
                                    column.DisplayIndex = 0x3e8 + num;
                                }
                                else
                                {
                                    column.DisplayIndex = num++;
                                }
                                this.dataGridView1.Columns.Add(column);
                            }
                        }
                        return;
                    }
                }
                IEnumerable enumerable = object_1 as IEnumerable;
                using (enumerator = enumerable.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        object obj2 = enumerator.Current;
                        foreach (KeyValuePair<string, string> pair in ReflectionUtil.GetPropertyNameTypes(obj2))
                        {
                            if (pair.Value == "System.Boolean")
                            {
                                column = new DataGridViewCheckBoxColumn();
                            }
                            else
                            {
                                column = new DataGridViewTextBoxColumn();
                            }
                            column.Name = pair.Key;
                            column.HeaderText = pair.Key;
                            column.DataPropertyName = pair.Key;
                            if (!((this.dictionary_0.Count <= 0) || this.dictionary_0.ContainsKey(pair.Key)))
                            {
                                column.Width = 0;
                                column.Visible = false;
                                column.DisplayIndex = 0x3e8 + num;
                            }
                            else
                            {
                                column.DisplayIndex = num++;
                            }
                            this.dataGridView1.Columns.Add(column);
                        }
                    }
                }
            }
        }

        private Dictionary<string, string> method_1(DataTable dataTable_0)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (DataColumn column in dataTable_0.Columns)
            {
                if (!dictionary.ContainsKey(column.ColumnName))
                {
                    dictionary.Add(column.ColumnName, column.DataType.FullName);
                }
            }
            return dictionary;
        }

        private int method_2(string string_2)
        {
            int num = -1;
            if (this.dictionary_0.ContainsKey(string_2))
            {
                num = this.dictionary_0[string_2];
            }
            return num;
        }

        private void method_3(object sender, EventArgs e)
        {
            this.bool_0 = true;
            this.method_5();
        }

        private void method_4(object sender, EventArgs e)
        {
            this.bool_0 = false;
            this.method_5();
        }

        private void method_5()
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
                        this.method_6(this.saveFileDialog_0.FileName);
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

        private void method_6(string string_2)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, new EventArgs());
            }
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.method_7);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_8);
            worker.RunWorkerAsync(string_2);
        }

        private void method_7(object sender, DoWorkEventArgs e)
        {
            DataView defaultView = null;
            if ((this.AllToExport != null) && this.bool_0)
            {
                defaultView = this.AllToExport.DefaultView;
            }
            else
            {
                object dataSource = this.dataGridView1.DataSource;
                if (dataSource is DataView)
                {
                    defaultView = (DataView) this.dataGridView1.DataSource;
                }
                else
                {
                    defaultView = ReflectionUtil.CreateTable(dataSource).DefaultView;
                }
            }
            DataTable datatable = defaultView.ToTable();
            string key = string.Empty;
            foreach (DataColumn column in datatable.Columns)
            {
                key = column.Caption;
                if (this.dictionary_1.ContainsKey(key))
                {
                    column.Caption = this.dictionary_1[key];
                    column.ColumnName = this.dictionary_1[key];
                }
            }
            string error = "";
            AsposeExcelTools.DataTableToExcel2(datatable, (string) e.Argument, out error);
        }

        private void method_8(object sender, RunWorkerCompletedEventArgs e)
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

        protected override void OnBindingContextChanged(EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[i];
                if ((i % 2) != 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            base.OnBindingContextChanged(e);
        }

        public ContextMenuStrip AppendedMenu
        {
            get
            {
                return this.contextMenuStrip_0;
            }
            set
            {
                if (value != null)
                {
                    this.contextMenuStrip_0 = value;
                    for (int i = 0; this.contextMenuStrip_0.Items.Count > 0; i++)
                    {
                        this.contextMenuStrip1.Items.Insert(i, this.contextMenuStrip_0.Items[0]);
                    }
                    this.menu_Delete.Visible = this.xtdkjpEav != null;
                    this.menu_Edit.Visible = this.eventHandler_3 != null;
                    this.menu_Refresh.Visible = this.eventHandler_4 != null;
                    this.menu_Add.Visible = this.eventHandler_5 != null;
                }
            }
        }

        public object DataSource
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
                this.method_0(this.object_0);
                this.dataGridView1.DataSource = this.object_0;
            }
        }

        public string DisplayColumns
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                this.dictionary_0 = new Dictionary<string, int>();
                string[] strArray = this.string_0.Split(new char[] { '|', ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str = strArray[i];
                    if (!(string.IsNullOrEmpty(str) || this.dictionary_0.ContainsKey(str)))
                    {
                        this.dictionary_0.Add(str, i);
                    }
                }
            }
        }

        public string PrintTitle
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
    }
}

