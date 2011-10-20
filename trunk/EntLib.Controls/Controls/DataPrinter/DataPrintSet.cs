namespace EntLib.Controls.DataPrinter
{
    using EntLib.Controls.WinForm;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using System.Windows.Forms;

    public class DataPrintSet : Form
    {
        private bool _IsDeepCopy;
        public string _printUser;
        private List<string> AvailableColumns;
        private Button bt_Apply;
        private Button bt_Cancel;
        private Button bt_footer_font;
        private Button bt_header_font;
        private Button bt_logochoose;
        private Button bt_OK;
        private Button bt_others_font;
        private Button bt_page_font;
        private Button bt_print_property;
        private Button bt_propertyGrid;
        private Button bt_Remove;
        private Button bt_Save;
        private Button bt_title_main_font;
        private Button bt_title_sub_font;
        private Button bt_watermark_font;
        private CheckBox cbx_auto_datetime;
        private CheckBox cbx_auto_paging;
        private CheckBox cbx_auto_printer;
        private CheckBox cbx_copys;
        private CheckBox cbx_datetime;
        private ComboBox cbx_datetime_format;
        private ComboBox cbx_footer_Halign;
        private ComboBox cbx_footer_Valign;
        private ComboBox cbx_header_Halign;
        private ComboBox cbx_header_Valign;
        private ComboBox cbx_others_Halign;
        private ComboBox cbx_others_Valign;
        private CheckBox cbx_page_enable;
        private ComboBox cbx_page_Halign;
        private ComboBox cbx_page_size;
        private ComboBox cbx_page_Valign;
        private ComboBox cbx_paper_from;
        private CheckBox cbx_print_to_file;
        private CheckBox cbx_printer;
        private ComboBox cbx_printer_select;
        private ComboBox cbx_statistic_column1;
        private ComboBox cbx_statistic_column2;
        private CheckBox cbx_title_main_enable;
        private ComboBox cbx_title_main_Halign;
        private ComboBox cbx_title_main_Valign;
        private CheckBox cbx_title_sub_enable;
        private ComboBox cbx_title_sub_Halign;
        private ComboBox cbx_title_sub_Valign;
        private CheckBox chb_logenable;
        private CheckBox checkBox_fixwidt;
        private CheckBox ckb_footer_enable;
        private CheckBox ckb_header_enable;
        private CheckBox ckb_statistic_page;
        private CheckBox ckb_statistic_total;
        private CheckBox ckb_watermark_enable;
        private CheckedListBox ColumnsList;
        private IContainer components;
        private string copys;
        private string datetime;
        private DateTimePicker dateTimePicker;
        private string DefaultProjectName;
        private int DefaultTabPage;
        private DataGridView DGV;
        private int display_pages;
        private string file;
        public DefaultOptions Footer;
        private GroupBox gb_columnsToPrint;
        private GroupBox gb_dgv;
        private GroupBox gb_footer;
        private GroupBox gb_header;
        private GroupBox gb_others;
        private GroupBox gb_page;
        private GroupBox gb_pages;
        private GroupBox gb_print;
        private GroupBox gb_scope;
        private GroupBox gb_Title_main;
        private GroupBox gb_Title_sub;
        internal GroupBox gboxRowsToPrint;
        private GroupBox groupBox1;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        public DefaultOptions Header;
        private ImageList imageList1;
        private bool IsFirstTimePreview;
        private Label label_msg;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public int layout_style;
        private Label lb_footer_preview;
        private Label lb_header_preview;
        private Label lb_others_preview;
        private Label lb_paper_height;
        private Label lb_paper_width;
        private Label lb_TitleMainPreview;
        private Label lb_TitleSubPreview;
        private Label lb_zoom_size;
        public LogoOptions Logo;
        private TextBox logo_height;
        private TextBox logo_width;
        private TextBox logo_X;
        private TextBox logo_Y;
        private Point MoveEnd;
        private Point MoveStart;
        private EntLib.Controls.DataPrinter.DataPrinter MyDataPrinter;
        private NumericUpDown num_copys;
        private OpenFileDialog openFileDialog1;
        public OtherOptions Others;
        public DefaultOptions Page;
        private int page_count;
        private EntLib.Controls.DataPrinter.DataPrinter PageCountDataPrinter;
        public PageSettings PageSet;
        private PictureBox pb_orientation_landscape;
        private PictureBox pb_orientation_long;
        private PictureBox pb_paging112233;
        private PictureBox pb_paging123123;
        public PrintDocument PD;
        private PictureBox pictureBox_logo;
        private bool Preview_move;
        private PrintPreviewControl previewer;
        private string printer;
        internal int PrintRows;
        private ListBox project_detail_list;
        private ListBox project_list;
        private PropertyGrid propertyGrid1;
        private RadioButton rb_all;
        private RadioButton rb_currentpage;
        private RadioButton rb_orientation_landscape;
        private RadioButton rb_orientation_long;
        private RadioButton rb_scope;
        private RadioButton rb_selected_scope;
        private RadioButton rb_show_on_footer;
        private RadioButton rb_show_on_header;
        internal RadioButton rdo_layout_0;
        internal RadioButton rdo_layout_1;
        internal RadioButton rdo_layout_2;
        internal RadioButton rdoAllRows;
        internal RadioButton rdoSelectedRows;
        private Register reg;
        private const int SB_HORZ = 0;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_VERT = 1;
        internal List<string> SelectedColumns;
        private SplitContainer splitContainer_dgv;
        private SplitContainer splitContainer1;
        public StatisticOptions Statistic;
        private TabControl tab_PrintSet;
        private TextBox tb_button;
        private TextBox tb_footer_text;
        private TextBox tb_header_text;
        private TextBox tb_left;
        private TextBox tb_logopath;
        private TextBox tb_page_text;
        private TextBox tb_printer;
        private TabPage tb_PrintPage;
        private TextBox tb_project_name;
        private TextBox tb_right;
        private TextBox tb_scope_from;
        private TextBox tb_scope_to;
        private TextBox tb_Title_main_text;
        private TextBox tb_Title_sub_text;
        private TextBox tb_top;
        private TextBox tb_watermark_angle;
        private TextBox tb_watermark_text;
        private TextBox tb_watermark_x;
        private TextBox tb_watermark_y;
        public DefaultOptions TitleMain;
        public DefaultOptions TitleSub;
        private ToolStripButton toolStrip_next;
        private ToolStripButton toolStrip_prior;
        private ToolStripButton toolStripButton_1;
        private ToolStripButton toolStripButton_2;
        private ToolStripButton toolStripButton_3;
        private ToolStripButton toolStripButton_first;
        private ToolStripButton toolStripButton_last;
        private ToolStripButton toolStripButton_review;
        private ToolStripSplitButton toolStripButton3;
        private ToolStripLabel toolStripLabel_pages;
        private ToolStripLabel toolStripLabel_XY;
        private ToolStripMenuItem toolStripMenuItem_10;
        private ToolStripMenuItem toolStripMenuItem_100;
        private ToolStripMenuItem toolStripMenuItem_125;
        private ToolStripMenuItem toolStripMenuItem_150;
        private ToolStripMenuItem toolStripMenuItem_200;
        private ToolStripMenuItem toolStripMenuItem_25;
        private ToolStripMenuItem toolStripMenuItem_300;
        private ToolStripMenuItem toolStripMenuItem_50;
        private ToolStripMenuItem toolStripMenuItem_75;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private TabPage tp_Data;
        private TabPage tp_General;
        private TabPage tp_HeaderFooter;
        private TabPage tp_Others;
        private TabPage tp_Preview;
        private TabPage tp_Titles;
        private TrackBar trackBar_zoom;
        private ToolStrip ts_preview_toolbar;
        public WatermarkOptions Watermark;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        public DataPrintSet()
        {
            this.InitializeComponent();
        }

        public DataPrintSet(string PrintUser, DataGridView dgv, params bool[] IsDeepCopy)
        {
            this.reg = new Register();
            this._printUser = "User";
            this.file = Application.StartupPath + @"\PrintConfigure.xml";
            this.DefaultProjectName = string.Empty;
            this.PageSet = new PageSettings();
            this._IsDeepCopy = true;
            this.IsFirstTimePreview = true;
            this.display_pages = 1;
            this.AvailableColumns = new List<string>();
            this.SelectedColumns = new List<string>();
            if (IsDeepCopy.Length > 0 && !IsDeepCopy[0]) this._IsDeepCopy = false;
            this._DataPrintSet(PrintUser, dgv, 0);
        }

        public DataPrintSet(DataGridView dgv, int i, params bool[] IsDeepCopy)
        {
            this.reg = new Register();
            this._printUser = "User";
            this.file = Application.StartupPath + @"\PrintConfigure.xml";
            this.DefaultProjectName = string.Empty;
            this.PageSet = new PageSettings();
            this._IsDeepCopy = true;
            this.IsFirstTimePreview = true;
            this.display_pages = 1;
            this.AvailableColumns = new List<string>();
            this.SelectedColumns = new List<string>();
            if (IsDeepCopy.Length > 0 && !IsDeepCopy[0]) this._IsDeepCopy = false;
            this._DataPrintSet("系统用户", dgv, i);
        }

        public DataPrintSet(string PrintUser, DataGridView dgv, int i, params bool[] IsDeepCopy)
        {
            this.reg = new Register();
            this._printUser = "User";
            this.file = Application.StartupPath + @"\PrintConfigure.xml";
            this.DefaultProjectName = string.Empty;
            this.PageSet = new PageSettings();
            this._IsDeepCopy = true;
            this.IsFirstTimePreview = true;
            this.display_pages = 1;
            this.AvailableColumns = new List<string>();
            this.SelectedColumns = new List<string>();
            if (IsDeepCopy.Length > 0 && !IsDeepCopy[0]) this._IsDeepCopy = false;
            this._DataPrintSet(PrintUser, dgv, i);
        }

        public DataPrintSet(string PrintUser, DataGridView dgv, string ProjectName, int i, params bool[] IsDeepCopy)
        {
            this.reg = new Register();
            this._printUser = "User";
            this.file = Application.StartupPath + @"\PrintConfigure.xml";
            this.DefaultProjectName = string.Empty;
            this.PageSet = new PageSettings();
            this._IsDeepCopy = true;
            this.IsFirstTimePreview = true;
            this.display_pages = 1;
            this.AvailableColumns = new List<string>();
            this.SelectedColumns = new List<string>();
            if (IsDeepCopy.Length > 0 && !IsDeepCopy[0]) this._IsDeepCopy = false;
            if (ProjectName != null) this.DefaultProjectName = ProjectName;
            this._DataPrintSet(PrintUser, dgv, i);
        }

        public void _DataPrintSet(string PrintUser, DataGridView dgv, int i)
        {
            this._printUser = PrintUser;
            this.InitializeComponent();
            if (this._IsDeepCopy)
            {
                this.DGV = CloneDataGridView(dgv);
                this.gb_dgv.Controls.Add(this.DGV);
            }
            else
            {
                this.DGV = dgv;
                this.tp_Data.Hide();
            }
            this.splitContainer_dgv.Panel2Collapsed = true;
            this.propertyGrid1.SelectedObject = this.DGV;
            if (i >= 0 && i <= 6)
                this.DefaultTabPage = i;
            else
                this.DefaultTabPage = 0;
            this.tab_PrintSet.SelectedIndex = this.DefaultTabPage;
        }

        private void bt_Apply_Click(object sender, EventArgs e) { this.bt_Save_Click(sender, e); }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            if (this != null) base.Close();
        }

        private void bt_footer_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.Footer.FontItem;
            dialog.Color = this.Footer.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Footer.FontItem = dialog.Font;
                this.Footer.TextColor = dialog.Color;
                this.lb_footer_preview.Font = this.Footer.FontItem;
                this.lb_footer_preview.ForeColor = this.Footer.TextColor;
            }
        }

        private void bt_header_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.Header.FontItem;
            dialog.Color = this.Header.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Header.FontItem = dialog.Font;
                this.Header.TextColor = dialog.Color;
                this.lb_header_preview.Font = this.Header.FontItem;
                this.lb_header_preview.ForeColor = this.Header.TextColor;
            }
        }

        private void bt_logochoose_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "所有图片(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|所有文件 (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = Application.StartupPath;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK) this.tb_logopath.Text = this.openFileDialog1.FileName;
        }

        internal void bt_OK_Click(object sender, EventArgs e)
        {
            try
            {
                EntLib.Controls.DataPrinter.DataPrinter.TotalPages = this.GetPageCount();
                EntLib.Controls.DataPrinter.DataPrinter.PageNumber = 0;
                if (this.PD != null) this.PD.Dispose();
                this.PD = new PrintDocument();
                this.PD.DefaultPageSettings = this.PageSet;
                this.PD.PrintPage += new PrintPageEventHandler(this.PD_PrintPage);
                this.PD.EndPrint += new PrintEventHandler(this.PD_EndPrint);
                this.PD.DocumentName = EntLib.Controls.DataPrinter.DataPrinter.TotalPages.ToString();
                this.MyDataPrinter = new EntLib.Controls.DataPrinter.DataPrinter(this.DGV, this.PD, this.Statistic, this.Watermark, this.Logo, this.TitleMain, this.TitleSub, this.Header, this.Footer, this.Page, this.Others, this.PageSet, this._printUser, this.SelectedColumns, this.PrintRows, this.layout_style, 0);
                this.PD.Print();
                base.Close();
            }
            catch
            {
                MessageBox.Show("打印出错是,请检查打印机!", "注意");
            }
        }

        private void bt_others_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.Others.FontItem;
            dialog.Color = this.Others.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Others.FontItem = dialog.Font;
                this.Others.TextColor = dialog.Color;
                this.lb_others_preview.Font = this.Others.FontItem;
                this.lb_others_preview.ForeColor = this.Others.TextColor;
            }
        }

        private void bt_print_property_Click(object sender, EventArgs e)
        {
            string printerName = this.PageSet.PrinterSettings.PrinterName;
            if (printerName != null && printerName.Length > 0)
            {
                IntPtr zero = IntPtr.Zero;
                IntPtr pDevModeOutput = IntPtr.Zero;
                IntPtr pDevModeInput = IntPtr.Zero;
                IntPtr pDefault = IntPtr.Zero;
                OpenPrinter(printerName, ref zero, ref pDefault);
                pDevModeOutput = Marshal.AllocHGlobal(DocumentProperties(base.Handle, zero, printerName, ref pDevModeOutput, ref pDevModeInput, 0));
                DocumentProperties(base.Handle, zero, printerName, ref pDevModeOutput, ref pDevModeInput, 4);
                ClosePrinter(zero);
            }
        }

        private void bt_propertyGrid_Click(object sender, EventArgs e)
        {
            if (this.splitContainer_dgv.Panel2Collapsed)
            {
                this.splitContainer_dgv.Panel2Collapsed = false;
                this.bt_propertyGrid.Text = ">> 隐藏(&H)";
            }
            else
            {
                this.splitContainer_dgv.Panel2Collapsed = true;
                this.bt_propertyGrid.Text = "<< 显示(&S)";
            }
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            if (this.project_list.SelectedItems.Count != 0)
            {
                string str = this.project_list.SelectedItem.ToString();
                if (str == XMLConfigure.ReadNode(this.file, "打印项目模板/DefaultProject", "默认方案"))
                    MessageBox.Show("对不起,默认方案不能移除!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else if (MessageBox.Show("真的要删除当前选定的方案吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.project_list.Items.RemoveAt(this.project_list.SelectedIndex);
                    if (this.project_list.Items.Count > 0) this.project_list.SetSelected(0, true);
                    if (!XMLConfigure.DeleteNode(this.file, "打印项目模板/" + str)) MessageBox.Show(string.Format("方案: [{0}] 删除失败!", str), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            string projectName = this.tb_project_name.Text.Trim();
            if (this.SaveProjectXML(projectName))
            {
                if (!this.project_list.Items.Contains(projectName))
                {
                    int index = this.project_list.Items.Add(projectName);
                    this.project_list.SetSelected(index, true);
                }
                MessageBox.Show("方案已保存!", this.Text);
            }
            else
                MessageBox.Show("方案保存出错!", this.Text);
        }

        private void bt_title_main_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.TitleMain.FontItem;
            dialog.Color = this.TitleMain.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.TitleMain.FontItem = dialog.Font;
                this.TitleMain.TextColor = dialog.Color;
                this.lb_TitleMainPreview.Font = this.TitleMain.FontItem;
                this.lb_TitleMainPreview.ForeColor = this.TitleMain.TextColor;
            }
        }

        private void bt_title_sub_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.TitleSub.FontItem;
            dialog.Color = this.TitleSub.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.TitleSub.FontItem = dialog.Font;
                this.TitleSub.TextColor = dialog.Color;
                this.lb_TitleSubPreview.Font = this.TitleSub.FontItem;
                this.lb_TitleSubPreview.ForeColor = this.TitleSub.TextColor;
            }
        }

        private void bt_watermark_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.Watermark.FontItem;
            dialog.Color = this.Watermark.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Watermark.FontItem = dialog.Font;
                this.Watermark.TextColor = dialog.Color;
            }
        }

        private void cbx_auto_datetime_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.AutoDateTime = this.cbx_auto_datetime.Checked;
            this.dateTimePicker.Enabled = !this.cbx_auto_datetime.Checked;
            this.SetOthersPreview();
        }

        private void cbx_auto_paging_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbx_auto_paging.Checked)
                this.pb_paging123123.BringToFront();
            else
                this.pb_paging112233.BringToFront();
            this.PageSet.PrinterSettings.Collate = this.cbx_auto_paging.Checked;
        }

        private void cbx_auto_printer_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.AutoPrinter = this.cbx_auto_printer.Checked;
            this.tb_printer.Enabled = !this.cbx_auto_printer.Checked;
            this.SetOthersPreview();
        }

        private void cbx_copys_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.CopysEnable = this.cbx_copys.Checked;
            if (this.cbx_copys.Checked)
                this.copys = "份数:{2}";
            else
                this.copys = "";
            this.SetOthersPreview();
        }

        private void cbx_datetime_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbx_auto_datetime.Checked) this.dateTimePicker.Enabled = this.cbx_datetime.Checked;
            this.cbx_auto_datetime.Enabled = this.cbx_datetime.Checked;
            this.cbx_datetime_format.Enabled = this.cbx_datetime.Checked;
            this.Others.DateTimeEnable = this.cbx_datetime.Checked;
            if (this.cbx_datetime.Checked)
                this.datetime = "打印日期时间:{1}";
            else
                this.datetime = "";
            this.SetOthersPreview();
        }

        private void cbx_datetime_format_SelectedIndexChanged(object sender, EventArgs e) { this.SetOthersPreview(); }

        private void cbx_footer_Halign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Footer.Halign = this.GetStringAlignment(this.cbx_footer_Halign.Text);
            this.lb_footer_preview.TextAlign = this.GetTextAlignment(this.cbx_footer_Halign.Text, this.cbx_footer_Valign.Text);
        }

        private void cbx_footer_Valign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Footer.Valign = this.GetStringAlignment(this.cbx_footer_Valign.Text);
            this.lb_footer_preview.TextAlign = this.GetTextAlignment(this.cbx_footer_Halign.Text, this.cbx_footer_Valign.Text);
        }

        private void cbx_header_Halign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Header.Halign = this.GetStringAlignment(this.cbx_header_Halign.Text);
            this.lb_header_preview.TextAlign = this.GetTextAlignment(this.cbx_header_Halign.Text, this.cbx_header_Valign.Text);
        }

        private void cbx_header_Valign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Header.Valign = this.GetStringAlignment(this.cbx_header_Valign.Text);
            this.lb_header_preview.TextAlign = this.GetTextAlignment(this.cbx_header_Halign.Text, this.cbx_header_Valign.Text);
        }

        private void cbx_others_Halign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Others.Halign = this.GetStringAlignment(this.cbx_others_Halign.Text);
            this.lb_others_preview.TextAlign = this.GetTextAlignment(this.cbx_others_Halign.Text, this.cbx_others_Valign.Text);
        }

        private void cbx_others_Valign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Others.Valign = this.GetStringAlignment(this.cbx_others_Valign.Text);
            this.lb_others_preview.TextAlign = this.GetTextAlignment(this.cbx_others_Halign.Text, this.cbx_others_Valign.Text);
        }

        private void cbx_page_enable_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_page_text.Enabled = this.cbx_page_enable.Checked;
            this.cbx_page_Halign.Enabled = this.cbx_page_enable.Checked;
            this.cbx_page_Valign.Enabled = this.cbx_page_enable.Checked;
            this.bt_page_font.Enabled = this.cbx_page_enable.Checked;
            this.rb_show_on_header.Enabled = this.cbx_page_enable.Checked;
            this.rb_show_on_footer.Enabled = this.cbx_page_enable.Checked;
            this.Page.Enable = this.cbx_page_enable.Checked;
        }

        private void cbx_page_Halign_SelectedIndexChanged(object sender, EventArgs e) { this.Page.Halign = this.GetStringAlignment(this.cbx_page_Halign.Text); }

        private void cbx_page_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_page_size.SelectedIndex != -1)
            {
                this.PageSet.PaperSize = this.PageSet.PrinterSettings.PaperSizes[this.cbx_page_size.SelectedIndex];
                this.lb_paper_width.Text = decimal.Round(Convert.ToDecimal((double) (((double) this.PageSet.PrinterSettings.PaperSizes[this.cbx_page_size.SelectedIndex].Width) / 3.94)), 0).ToString() + " mm";
                this.lb_paper_height.Text = decimal.Round(Convert.ToDecimal((double) (((double) this.PageSet.PrinterSettings.PaperSizes[this.cbx_page_size.SelectedIndex].Height) / 3.94)), 0).ToString() + " mm";
            }
            else
            {
                this.PageSet.PaperSize = this.PageSet.PrinterSettings.PaperSizes[0];
                this.lb_paper_width.Text = decimal.Round(Convert.ToDecimal((double) (((double) this.PageSet.PrinterSettings.PaperSizes[0].Width) / 3.94)), 0).ToString() + " mm";
                this.lb_paper_height.Text = decimal.Round(Convert.ToDecimal((double) (((double) this.PageSet.PrinterSettings.PaperSizes[0].Height) / 3.94)), 0).ToString() + " mm";
            }
        }

        private void cbx_page_Valign_SelectedIndexChanged(object sender, EventArgs e) { this.Page.Valign = this.GetStringAlignment(this.cbx_page_Valign.Text); }

        private void cbx_paper_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_paper_from.SelectedIndex != -1) this.PageSet.PaperSource = this.PageSet.PrinterSettings.PaperSources[this.cbx_paper_from.SelectedIndex];
        }

        private void cbx_print_to_file_CheckedChanged(object sender, EventArgs e)
        {
            this.cbx_printer_select.Enabled = !this.cbx_print_to_file.Checked;
            this.bt_print_property.Enabled = !this.cbx_print_to_file.Checked;
            this.PageSet.PrinterSettings.PrintToFile = this.cbx_print_to_file.Checked;
        }

        private void cbx_printer_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbx_auto_printer.Checked) this.tb_printer.Enabled = this.cbx_printer.Checked;
            this.cbx_auto_printer.Enabled = this.cbx_printer.Checked;
            this.Others.PrinterEnable = this.cbx_printer.Checked;
            if (this.cbx_printer.Checked)
                this.printer = "打印人:{0}";
            else
                this.printer = "";
            this.SetOthersPreview();
        }

        private void cbx_printer_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_printer_select.SelectedIndex != -1) this.PageSet.PrinterSettings.PrinterName = this.cbx_printer_select.Text;
        }

        private void cbx_statistic_column1_TextChanged(object sender, EventArgs e)
        {
            if (this.cbx_statistic_column1.Text.Trim() == "")
                this.Statistic.StatisticColumn1 = null;
            else
                this.Statistic.StatisticColumn1 = this.cbx_statistic_column1.Text.Trim();
        }

        private void cbx_statistic_column2_TextChanged(object sender, EventArgs e)
        {
            if (this.cbx_statistic_column2.Text.Trim() == "")
                this.Statistic.StatisticColumn2 = null;
            else
                this.Statistic.StatisticColumn2 = this.cbx_statistic_column2.Text.Trim();
        }

        private void cbx_title_main_enabled_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_Title_main_text.Enabled = this.cbx_title_main_enable.Checked;
            this.cbx_title_main_Halign.Enabled = this.cbx_title_main_enable.Checked;
            this.cbx_title_main_Valign.Enabled = this.cbx_title_main_enable.Checked;
            this.bt_title_main_font.Enabled = this.cbx_title_main_enable.Checked;
            this.TitleMain.Enable = this.cbx_title_main_enable.Checked;
        }

        private void cbx_title_main_Halign_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TitleMain.Halign = this.GetStringAlignment(this.cbx_title_main_Halign.Text);
            this.lb_TitleMainPreview.TextAlign = this.GetTextAlignment(this.cbx_title_main_Halign.Text, this.cbx_title_main_Valign.Text);
        }

        private void cbx_title_main_Valign_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TitleMain.Valign = this.GetStringAlignment(this.cbx_title_main_Valign.Text);
            this.lb_TitleMainPreview.TextAlign = this.GetTextAlignment(this.cbx_title_main_Halign.Text, this.cbx_title_main_Valign.Text);
        }

        private void cbx_title_sub_enabled_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_Title_sub_text.Enabled = this.cbx_title_sub_enable.Checked;
            this.cbx_title_sub_Halign.Enabled = this.cbx_title_sub_enable.Checked;
            this.cbx_title_sub_Valign.Enabled = this.cbx_title_sub_enable.Checked;
            this.bt_title_sub_font.Enabled = this.cbx_title_sub_enable.Checked;
            this.TitleSub.Enable = this.cbx_title_sub_enable.Checked;
        }

        private void cbx_title_sub_Halign_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TitleSub.Halign = this.GetStringAlignment(this.cbx_title_sub_Halign.Text);
            this.lb_TitleSubPreview.TextAlign = this.GetTextAlignment(this.cbx_title_sub_Halign.Text, this.cbx_title_sub_Valign.Text);
        }

        private void cbx_title_sub_Valign_SelectedValueChanged(object sender, EventArgs e)
        {
            this.TitleSub.Valign = this.GetStringAlignment(this.cbx_title_sub_Valign.Text);
            this.lb_TitleSubPreview.TextAlign = this.GetTextAlignment(this.cbx_title_sub_Halign.Text, this.cbx_title_sub_Valign.Text);
        }

        private void chb_logenable_CheckedChanged(object sender, EventArgs e)
        {
            this.Logo.Enable = this.chb_logenable.Checked;
            this.tb_logopath.Enabled = this.chb_logenable.Checked;
            this.bt_logochoose.Enabled = this.chb_logenable.Checked;
            this.logo_X.Enabled = this.chb_logenable.Checked;
            this.logo_Y.Enabled = this.chb_logenable.Checked;
            this.logo_width.Enabled = this.chb_logenable.Checked;
            this.logo_height.Enabled = this.chb_logenable.Checked;
        }

        private void checkBox_fixwidt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_fixwidt.Checked)
            {
                if (this.rdo_layout_2.Checked)
                {
                    MessageBox.Show("采用[固定列宽]模式时,不能同时选择[自动适合页宽]模式,系统将自动设置为[默认]布局方式.", "提示");
                    this.rdo_layout_0.Checked = true;
                }
                this.layout_style += 10;
            }
            else
                this.layout_style = this.layout_style % 10;
        }

        private void ckb_footer_enable_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_footer_text.Enabled = this.ckb_footer_enable.Checked;
            this.cbx_footer_Halign.Enabled = this.ckb_footer_enable.Checked;
            this.cbx_footer_Valign.Enabled = this.ckb_footer_enable.Checked;
            this.bt_footer_font.Enabled = this.ckb_footer_enable.Checked;
            this.Footer.Enable = this.ckb_footer_enable.Checked;
        }

        private void ckb_header_enable_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_header_text.Enabled = this.ckb_header_enable.Checked;
            this.cbx_header_Halign.Enabled = this.ckb_header_enable.Checked;
            this.cbx_header_Valign.Enabled = this.ckb_header_enable.Checked;
            this.bt_header_font.Enabled = this.ckb_header_enable.Checked;
            this.Header.Enable = this.ckb_header_enable.Checked;
        }

        private void ckb_statistic_page_CheckedChanged(object sender, EventArgs e) { this.Statistic.PageStatistic = this.ckb_statistic_page.Checked; }

        private void ckb_statistic_total_CheckedChanged(object sender, EventArgs e) { this.Statistic.TotalStatistic = this.ckb_statistic_total.Checked; }

        private void ckb_watermark_enable_CheckedChanged(object sender, EventArgs e)
        {
            this.Watermark.Enable = this.ckb_watermark_enable.Checked;
            this.tb_watermark_angle.Enabled = this.ckb_watermark_enable.Checked;
            this.tb_watermark_text.Enabled = this.ckb_watermark_enable.Checked;
            this.tb_watermark_x.Enabled = this.ckb_watermark_enable.Checked;
            this.tb_watermark_y.Enabled = this.ckb_watermark_enable.Checked;
            this.bt_watermark_font.Enabled = this.ckb_watermark_enable.Checked;
        }

        public static DataGridView CloneDataGridView(DataGridView dgv)
        {
            try
            {
                DataGridView view = new DataGridView();
                view.ColumnHeadersDefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle.Clone();
                DataGridViewCellStyle style = dgv.RowsDefaultCellStyle.Clone();
                style.BackColor = dgv.DefaultCellStyle.BackColor;
                style.ForeColor = dgv.DefaultCellStyle.ForeColor;
                style.Font = dgv.DefaultCellStyle.Font;
                view.RowsDefaultCellStyle = style;
                view.AlternatingRowsDefaultCellStyle = dgv.AlternatingRowsDefaultCellStyle.Clone();
                view.DefaultCellStyle = dgv.DefaultCellStyle.Clone();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    DataGridViewColumn dataGridViewColumn = dgv.Columns[i].Clone() as DataGridViewColumn;
                    dataGridViewColumn.DefaultCellStyle = dgv.Columns[i].DefaultCellStyle.Clone();
                    dataGridViewColumn.DisplayIndex = dgv.Columns[i].DisplayIndex;
                    if (dataGridViewColumn.CellType == null)
                    {
                        dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
                        view.Columns.Add(dataGridViewColumn);
                    }
                    else
                        view.Columns.Add(dataGridViewColumn);
                }
                foreach (DataGridViewRow row in (IEnumerable) dgv.Rows)
                {
                    DataGridViewRow dataGridViewRow = row.Clone() as DataGridViewRow;
                    dataGridViewRow.DefaultCellStyle = row.DefaultCellStyle.Clone();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        dataGridViewRow.Cells[j].Style = row.Cells[j].Style.Clone();
                        dataGridViewRow.Cells[j].Value = row.Cells[j].FormattedValue;
                    }
                    view.Rows.Add(dataGridViewRow);
                }
                return view;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "警告");
            }
            return null;
        }

        private object CloneObject(object o)
        {
            System.Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            object obj2 = type.InvokeMember("", BindingFlags.CreateInstance, null, o, null);
            foreach (PropertyInfo info in properties)
            {
                if (info.CanWrite)
                {
                    object obj3 = info.GetValue(o, null);
                    info.SetValue(obj2, obj3, null);
                }
            }
            return obj2;
        }

        [DllImport("winspool.drv", SetLastError=true)]
        public static extern int ClosePrinter(IntPtr phPrinter);
        private void ColumnsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedColumns = this.GetSelectedColumns();
            foreach (DataGridViewColumn column in this.DGV.Columns)
            {
                if (!this.SelectedColumns.Contains(column.HeaderText))
                    column.Visible = false;
                else
                    column.Visible = true;
            }
        }

        private void DataPrintSet_Load(object sender, EventArgs e) { this.InitPrinter(); }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e) { this.SetOthersPreview(); }

        public object DeserializeBinary(byte[] buf)
        {
            MemoryStream serializationStream = new MemoryStream(buf);
            serializationStream.Position = 0;
            object obj2 = new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        private void DisplayProject()
        {
            this.cbx_title_main_enable.Checked = this.TitleMain.Enable;
            this.tb_Title_main_text.Text = this.TitleMain.Text;
            this.lb_TitleMainPreview.Font = this.TitleMain.FontItem;
            this.lb_TitleMainPreview.ForeColor = this.TitleMain.TextColor;
            this.lb_TitleMainPreview.TextAlign = this.GetTextAlignment(this.TitleMain.Halign.ToString(), this.TitleMain.Valign.ToString());
            this.cbx_title_main_Halign.Text = this.TitleMain.Halign.ToString();
            this.cbx_title_main_Valign.Text = this.TitleMain.Valign.ToString();
            this.cbx_title_sub_enable.Checked = this.TitleSub.Enable;
            this.tb_Title_sub_text.Text = this.TitleSub.Text;
            this.lb_TitleSubPreview.Font = this.TitleSub.FontItem;
            this.lb_TitleSubPreview.ForeColor = this.TitleSub.TextColor;
            this.lb_TitleSubPreview.TextAlign = this.GetTextAlignment(this.TitleSub.Halign.ToString(), this.TitleSub.Valign.ToString());
            this.cbx_title_sub_Halign.Text = this.TitleSub.Halign.ToString();
            this.cbx_title_sub_Valign.Text = this.TitleSub.Valign.ToString();
            this.chb_logenable.Checked = this.Logo.Enable;
            this.tb_logopath.Text = this.Logo.FilePath;
            this.logo_X.Text = this.Logo.Location.X.ToString();
            this.logo_Y.Text = this.Logo.Location.Y.ToString();
            this.logo_width.Text = this.Logo.ImageSize.Width.ToString();
            this.logo_height.Text = this.Logo.ImageSize.Height.ToString();
            try
            {
                this.pictureBox_logo.Image = Image.FromFile(this.Logo.FilePath, false);
            }
            catch
            {
            }
            this.ckb_header_enable.Checked = this.Header.Enable;
            this.tb_header_text.Text = this.Header.Text;
            this.lb_header_preview.Font = this.Header.FontItem;
            this.lb_header_preview.ForeColor = this.Header.TextColor;
            this.lb_header_preview.TextAlign = this.GetTextAlignment(this.Header.Halign.ToString(), this.Header.Valign.ToString());
            this.cbx_header_Halign.Text = this.Header.Halign.ToString();
            this.cbx_header_Valign.Text = this.Header.Valign.ToString();
            this.ckb_footer_enable.Checked = this.Footer.Enable;
            this.tb_footer_text.Text = this.Footer.Text;
            this.lb_footer_preview.Font = this.Footer.FontItem;
            this.lb_footer_preview.ForeColor = this.Footer.TextColor;
            this.lb_footer_preview.TextAlign = this.GetTextAlignment(this.Footer.Halign.ToString(), this.Footer.Valign.ToString());
            this.cbx_footer_Halign.Text = this.Footer.Halign.ToString();
            this.cbx_footer_Valign.Text = this.Footer.Valign.ToString();
            this.cbx_page_enable.Checked = this.Page.Enable;
            this.tb_page_text.Text = this.Page.Text;
            this.cbx_page_Halign.Text = this.Page.Halign.ToString();
            this.cbx_page_Valign.Text = this.Page.Valign.ToString();
            this.rb_show_on_header.Checked = this.Page.ShowOnHeader;
            this.rb_show_on_footer.Checked = !this.Page.ShowOnHeader;
            this.cbx_datetime_format.Text = this.Others.DateTimeFormat;
            this.cbx_printer.Checked = this.Others.PrinterEnable;
            this.cbx_datetime.Checked = this.Others.DateTimeEnable;
            this.cbx_copys.Checked = this.Others.CopysEnable;
            this.tb_printer.Text = this.Others.PrinterText;
            DateTimeConverter converter = new DateTimeConverter();
            this.dateTimePicker.Value = (DateTime) converter.ConvertFromString(this.Others.DateTimeText);
            this.cbx_auto_printer.Checked = this.Others.AutoPrinter;
            this.cbx_auto_datetime.Checked = this.Others.AutoDateTime;
            this.cbx_others_Halign.Text = this.Others.Halign.ToString();
            this.cbx_others_Valign.Text = this.Others.Valign.ToString();
            this.lb_others_preview.ForeColor = this.Others.TextColor;
            this.lb_others_preview.TextAlign = this.GetTextAlignment(this.Others.Halign.ToString(), this.Others.Valign.ToString());
            this.rdo_layout_0.Checked = false;
            this.rdo_layout_1.Checked = false;
            this.rdo_layout_2.Checked = false;
            if (this.layout_style >= 10)
                this.checkBox_fixwidt.Checked = true;
            else
                this.checkBox_fixwidt.Checked = false;
            switch ((this.layout_style % 10))
            {
                case 0:
                    this.rdo_layout_0.Checked = true;
                    break;

                case 1:
                    this.rdo_layout_1.Checked = true;
                    break;

                case 2:
                    this.rdo_layout_2.Checked = true;
                    break;
            }
            this.ckb_watermark_enable.Checked = this.Watermark.Enable;
            this.tb_watermark_x.Text = this.Watermark.Location.X.ToString();
            this.tb_watermark_y.Text = this.Watermark.Location.Y.ToString();
            this.tb_watermark_text.Text = this.Watermark.Text;
            this.tb_watermark_angle.Text = this.Watermark.Angle.ToString();
            this.cbx_printer_select.Text = this.PageSet.PrinterSettings.PrinterName;
            this.cbx_print_to_file.Checked = this.PageSet.PrinterSettings.PrintToFile;
            switch (this.PageSet.PrinterSettings.PrintRange)
            {
                case PrintRange.AllPages:
                    this.rb_all.Checked = true;
                    break;

                case PrintRange.Selection:
                    this.rb_selected_scope.Checked = true;
                    break;

                case PrintRange.SomePages:
                    this.rb_scope.Checked = true;
                    this.tb_scope_from.Text = this.PageSet.PrinterSettings.FromPage.ToString();
                    this.tb_scope_to.Text = this.PageSet.PrinterSettings.ToPage.ToString();
                    break;

                case PrintRange.CurrentPage:
                    this.rb_currentpage.Checked = true;
                    break;

                default:
                    this.rb_all.Checked = true;
                    break;
            }
            this.num_copys.Value = this.PageSet.PrinterSettings.Copies;
            this.cbx_auto_paging.Checked = this.PageSet.PrinterSettings.Collate;
            if (this.PageSet.Landscape)
                this.rb_orientation_landscape.Checked = true;
            else
                this.rb_orientation_long.Checked = true;
            this.cbx_page_size.Text = this.PageSet.PaperSize.PaperName;
            this.cbx_paper_from.Text = this.PageSet.PaperSource.SourceName;
            this.tb_top.Text = this.PageSet.Margins.Top.ToString();
            this.tb_button.Text = this.PageSet.Margins.Bottom.ToString();
            this.tb_left.Text = this.PageSet.Margins.Left.ToString();
            this.tb_right.Text = this.PageSet.Margins.Right.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool flag = this.PageCountDataPrinter.DrawDataGridView(e);
            e.HasMorePages = flag;
        }

        [DllImport("winspool.drv", SetLastError=true)]
        public static extern int DocumentProperties(IntPtr hWnd, IntPtr hPrinter, string pDeviceName, ref IntPtr pDevModeOutput, ref IntPtr pDevModeInput, int fMode);
        private List<string> GetColumnsName(DataGridView dgv)
        {
            this.AvailableColumns.Clear();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible) this.AvailableColumns.Add(column.HeaderText);
            }
            return this.AvailableColumns;
        }

        private int GetPageCount()
        {
            EntLib.Controls.DataPrinter.DataPrinter.PageNumber = 0;
            PrintDocument aPrintDocument = new PrintDocument();
            aPrintDocument.DefaultPageSettings = this.PageSet;
            aPrintDocument.PrintPage += new PrintPageEventHandler(this.Doc_PrintPage);
            aPrintDocument.DocumentName = "DataGridView 打印专家";
            this.PageCountDataPrinter = new EntLib.Controls.DataPrinter.DataPrinter(this.DGV, aPrintDocument, this.Statistic, this.Watermark, this.Logo, this.TitleMain, this.TitleSub, this.Header, this.Footer, this.Page, this.Others, this.PageSet, this._printUser, this.SelectedColumns, this.PrintRows, this.layout_style, 1);
            this.page_count = PageCountPrintController.GetPageCount(aPrintDocument);
            EntLib.Controls.DataPrinter.DataPrinter.PageNumber = 0;
            return this.page_count;
        }

        private Dictionary<string, object> GetProjectDetail()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("主标题.Enable", this.TitleMain.Enable.ToString());
            dictionary.Add("主标题.Text", this.TitleMain.Text.ToString());
            dictionary.Add("主标题.TextColor", this.TitleMain.TextColor.ToString());
            dictionary.Add("主标题.FontItem", this.TitleMain.FontItem.ToString());
            dictionary.Add("主标题.Halign", this.TitleMain.Halign.ToString());
            dictionary.Add("主标题.Valign", this.TitleMain.Valign.ToString());
            dictionary.Add("主标题", "End----------------------------------------------------");
            dictionary.Add("副标题.Enable", this.TitleSub.Enable.ToString());
            dictionary.Add("副标题.Text", this.TitleSub.Text.ToString());
            dictionary.Add("副标题.TextColor", this.TitleSub.TextColor.ToString());
            dictionary.Add("副标题.FontItem", this.TitleSub.FontItem.ToString());
            dictionary.Add("副标题.Halign", this.TitleSub.Halign.ToString());
            dictionary.Add("副标题.Valign", this.TitleSub.Valign.ToString());
            dictionary.Add("副标题", "End----------------------------------------------------");
            dictionary.Add("LOGO图片.Enable", this.Logo.Enable.ToString());
            dictionary.Add("LOGO图片.FilePath", this.Logo.FilePath);
            dictionary.Add("LOGO图片.Location", this.Logo.Location.ToString());
            dictionary.Add("LOGO图片.ImageSize", this.Logo.ImageSize.ToString());
            dictionary.Add("LOGO图片", "End----------------------------------------------------");
            dictionary.Add("页眉.Enable", this.Header.Enable.ToString());
            dictionary.Add("页眉.Text", this.Header.Text.ToString());
            dictionary.Add("页眉.TextColor", this.Header.TextColor.ToString());
            dictionary.Add("页眉.FontItem", this.Header.FontItem.ToString());
            dictionary.Add("页眉.Halign", this.Header.Halign.ToString());
            dictionary.Add("页眉.Valign", this.Header.Valign.ToString());
            dictionary.Add("页眉", "End----------------------------------------------------");
            dictionary.Add("页脚.Enable", this.Footer.Enable.ToString());
            dictionary.Add("页脚.Text", this.Footer.Text.ToString());
            dictionary.Add("页脚.TextColor", this.Footer.TextColor.ToString());
            dictionary.Add("页脚.FontItem", this.Footer.FontItem.ToString());
            dictionary.Add("页脚.Halign", this.Footer.Halign.ToString());
            dictionary.Add("页脚.Valign", this.Footer.Valign.ToString());
            dictionary.Add("页脚", "End----------------------------------------------------");
            dictionary.Add("页码.Enable", this.Page.Enable.ToString());
            dictionary.Add("页码.Text", this.Page.Text.ToString());
            dictionary.Add("页码.TextColor", this.Page.TextColor.ToString());
            dictionary.Add("页码.FontItem", this.Page.FontItem.ToString());
            dictionary.Add("页码.Halign", this.Page.Halign.ToString());
            dictionary.Add("页码.Valign", this.Page.Valign.ToString());
            dictionary.Add("页码.ShowOnHeader", this.Page.ShowOnHeader.ToString());
            dictionary.Add("页码", "End----------------------------------------------------");
            dictionary.Add("其它.PrinterEnable", this.Others.PrinterEnable.ToString());
            dictionary.Add("其它.PrinterText", this.Others.PrinterText.ToString());
            dictionary.Add("其它.AutoPrinter", this.Others.AutoPrinter.ToString());
            dictionary.Add("其它.DateTimeEnable", this.Others.DateTimeEnable.ToString());
            dictionary.Add("其它.DateTimeFormat", this.Others.DateTimeFormat.ToString());
            dictionary.Add("其它.DateTimeText", this.Others.DateTimeText.ToString());
            dictionary.Add("其它.AutoDateTime", this.Others.AutoDateTime.ToString());
            dictionary.Add("其它.CopysEnable", this.Others.CopysEnable.ToString());
            dictionary.Add("其它.TextColor", this.Others.TextColor.ToString());
            dictionary.Add("其它.FontItem", this.Others.FontItem.ToString());
            dictionary.Add("其它.Halign", this.Others.Halign.ToString());
            dictionary.Add("其它.Valign", this.Others.Valign.ToString());
            dictionary.Add("其它.Layout", this.layout_style.ToString());
            dictionary.Add("其它", "End----------------------------------------------------");
            dictionary.Add("水印.Enable", this.Watermark.Enable.ToString());
            dictionary.Add("水印.Text", this.Watermark.Text.ToString());
            dictionary.Add("水印.FontItem", this.Watermark.FontItem.ToString());
            dictionary.Add("水印.TextColor", this.Watermark.TextColor.ToString());
            dictionary.Add("水印.Location", this.Watermark.Location.ToString());
            dictionary.Add("水印.Angle", this.Watermark.Angle.ToString());
            dictionary.Add("水印", "End----------------------------------------------------");
            dictionary.Add("打印机.PrinterName", this.PageSet.PrinterSettings.PrinterName);
            dictionary.Add("打印机.PrintToFile", this.PageSet.PrinterSettings.PrintToFile.ToString());
            switch (this.PageSet.PrinterSettings.PrintRange)
            {
                case PrintRange.AllPages:
                    dictionary.Add("打印机.PrintRange", "All");
                    break;

                case PrintRange.Selection:
                    dictionary.Add("打印机.PrintRange", "User Selection");
                    break;

                case PrintRange.SomePages:
                    dictionary.Add("打印机.PrintRange", string.Format("Scope From {0} to {1})", this.PageSet.PrinterSettings.FromPage, this.PageSet.PrinterSettings.ToPage));
                    break;

                case PrintRange.CurrentPage:
                    dictionary.Add("打印机.PrintRange", "CurrentPage");
                    break;

                default:
                    dictionary.Add("打印机.PrintRange", "All");
                    break;
            }
            dictionary.Add("打印机.Copies", this.PageSet.PrinterSettings.Copies.ToString());
            dictionary.Add("打印机.AutoPaging", this.PageSet.PrinterSettings.Collate.ToString());
            dictionary.Add("打印机", "End----------------------------------------------------");
            dictionary.Add("纸张.Landscape", this.PageSet.Landscape.ToString());
            dictionary.Add("纸张.PaperSize", this.PageSet.PaperSize.PaperName);
            dictionary.Add("纸张.PaperSource", this.PageSet.PaperSource.SourceName);
            dictionary.Add("纸张.Margins", string.Format("Top {0},Bottom {1},Left {2},Right {3}", new object[] { this.PageSet.Margins.Top, this.PageSet.Margins.Bottom, this.PageSet.Margins.Left, this.PageSet.Margins.Right }));
            return dictionary;
        }

        [DllImport("user32.dll")]
        private static extern int GetScrollPos(IntPtr hwnd, int nBar);
        [DllImport("user32", CharSet=CharSet.Auto)]
        private static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);
        public List<string> GetSelectedColumns()
        {
            List<string> list = new List<string>();
            foreach (object obj2 in this.ColumnsList.CheckedItems)
            {
                list.Add(obj2.ToString());
            }
            return list;
        }

        private StringAlignment GetStringAlignment(string value)
        {
            switch (value)
            {
                case "Near":
                    return StringAlignment.Near;

                case "Center":
                    return StringAlignment.Center;

                case "Far":
                    return StringAlignment.Far;
            }
            return StringAlignment.Near;
        }

        private ContentAlignment GetTextAlignment(string value1, string value2)
        {
            switch ((value1 + value2))
            {
                case "NearNear":
                    return ContentAlignment.TopLeft;

                case "NearCenter":
                    return ContentAlignment.TopCenter;

                case "NearFar":
                    return ContentAlignment.TopRight;

                case "CenterNear":
                    return ContentAlignment.MiddleLeft;

                case "CenterCenter":
                    return ContentAlignment.MiddleCenter;

                case "CenterFar":
                    return ContentAlignment.MiddleRight;

                case "FarNear":
                    return ContentAlignment.BottomLeft;

                case "FarCenter":
                    return ContentAlignment.BottomCenter;

                case "FarFar":
                    return ContentAlignment.BottomRight;
            }
            return ContentAlignment.TopLeft;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DataPrintSet));
            this.bt_OK = new Button();
            this.imageList1 = new ImageList(this.components);
            this.bt_Cancel = new Button();
            this.bt_Apply = new Button();
            this.tab_PrintSet = new TabControl();
            this.tp_General = new TabPage();
            this.groupBox2 = new GroupBox();
            this.project_detail_list = new ListBox();
            this.label1 = new Label();
            this.groupBox1 = new GroupBox();
            this.project_list = new ListBox();
            this.bt_Remove = new Button();
            this.tb_project_name = new TextBox();
            this.bt_Save = new Button();
            this.tp_Data = new TabPage();
            this.splitContainer1 = new SplitContainer();
            this.gb_columnsToPrint = new GroupBox();
            this.ColumnsList = new CheckedListBox();
            this.groupBox10 = new GroupBox();
            this.ckb_statistic_total = new CheckBox();
            this.ckb_statistic_page = new CheckBox();
            this.label51 = new Label();
            this.cbx_statistic_column2 = new ComboBox();
            this.cbx_statistic_column1 = new ComboBox();
            this.gboxRowsToPrint = new GroupBox();
            this.rdoSelectedRows = new RadioButton();
            this.rdoAllRows = new RadioButton();
            this.groupBox9 = new GroupBox();
            this.bt_propertyGrid = new Button();
            this.splitContainer_dgv = new SplitContainer();
            this.gb_dgv = new GroupBox();
            this.label_msg = new Label();
            this.groupBox8 = new GroupBox();
            this.propertyGrid1 = new PropertyGrid();
            this.tp_Titles = new TabPage();
            this.groupBox6 = new GroupBox();
            this.pictureBox_logo = new PictureBox();
            this.logo_height = new TextBox();
            this.logo_width = new TextBox();
            this.logo_Y = new TextBox();
            this.logo_X = new TextBox();
            this.chb_logenable = new CheckBox();
            this.label48 = new Label();
            this.label49 = new Label();
            this.label47 = new Label();
            this.label46 = new Label();
            this.label45 = new Label();
            this.label42 = new Label();
            this.label43 = new Label();
            this.bt_logochoose = new Button();
            this.tb_logopath = new TextBox();
            this.label44 = new Label();
            this.groupBox4 = new GroupBox();
            this.lb_TitleSubPreview = new Label();
            this.lb_TitleMainPreview = new Label();
            this.gb_Title_sub = new GroupBox();
            this.cbx_title_sub_enable = new CheckBox();
            this.cbx_title_sub_Valign = new ComboBox();
            this.label6 = new Label();
            this.cbx_title_sub_Halign = new ComboBox();
            this.label7 = new Label();
            this.bt_title_sub_font = new Button();
            this.tb_Title_sub_text = new TextBox();
            this.label9 = new Label();
            this.gb_Title_main = new GroupBox();
            this.cbx_title_main_enable = new CheckBox();
            this.cbx_title_main_Valign = new ComboBox();
            this.label5 = new Label();
            this.cbx_title_main_Halign = new ComboBox();
            this.label4 = new Label();
            this.bt_title_main_font = new Button();
            this.tb_Title_main_text = new TextBox();
            this.label3 = new Label();
            this.tp_HeaderFooter = new TabPage();
            this.gb_pages = new GroupBox();
            this.label40 = new Label();
            this.label39 = new Label();
            this.rb_show_on_footer = new RadioButton();
            this.rb_show_on_header = new RadioButton();
            this.cbx_page_enable = new CheckBox();
            this.cbx_page_Valign = new ComboBox();
            this.label36 = new Label();
            this.cbx_page_Halign = new ComboBox();
            this.label37 = new Label();
            this.bt_page_font = new Button();
            this.tb_page_text = new TextBox();
            this.label38 = new Label();
            this.gb_footer = new GroupBox();
            this.ckb_footer_enable = new CheckBox();
            this.cbx_footer_Valign = new ComboBox();
            this.label8 = new Label();
            this.cbx_footer_Halign = new ComboBox();
            this.label10 = new Label();
            this.bt_footer_font = new Button();
            this.tb_footer_text = new TextBox();
            this.label11 = new Label();
            this.groupBox5 = new GroupBox();
            this.lb_footer_preview = new Label();
            this.lb_header_preview = new Label();
            this.gb_header = new GroupBox();
            this.ckb_header_enable = new CheckBox();
            this.cbx_header_Valign = new ComboBox();
            this.label14 = new Label();
            this.cbx_header_Halign = new ComboBox();
            this.label15 = new Label();
            this.bt_header_font = new Button();
            this.tb_header_text = new TextBox();
            this.label16 = new Label();
            this.tp_Others = new TabPage();
            this.groupBox3 = new GroupBox();
            this.lb_others_preview = new Label();
            this.gb_others = new GroupBox();
            this.bt_others_font = new Button();
            this.cbx_datetime_format = new ComboBox();
            this.cbx_others_Valign = new ComboBox();
            this.label22 = new Label();
            this.label13 = new Label();
            this.label21 = new Label();
            this.cbx_others_Halign = new ComboBox();
            this.label19 = new Label();
            this.label12 = new Label();
            this.cbx_printer = new CheckBox();
            this.dateTimePicker = new DateTimePicker();
            this.tb_printer = new TextBox();
            this.cbx_auto_datetime = new CheckBox();
            this.cbx_auto_printer = new CheckBox();
            this.cbx_copys = new CheckBox();
            this.cbx_datetime = new CheckBox();
            this.groupBox11 = new GroupBox();
            this.tb_watermark_angle = new TextBox();
            this.label56 = new Label();
            this.tb_watermark_y = new TextBox();
            this.tb_watermark_x = new TextBox();
            this.label52 = new Label();
            this.label53 = new Label();
            this.label54 = new Label();
            this.label55 = new Label();
            this.bt_watermark_font = new Button();
            this.tb_watermark_text = new TextBox();
            this.label50 = new Label();
            this.ckb_watermark_enable = new CheckBox();
            this.groupBox7 = new GroupBox();
            this.checkBox_fixwidt = new CheckBox();
            this.rdo_layout_0 = new RadioButton();
            this.rdo_layout_2 = new RadioButton();
            this.rdo_layout_1 = new RadioButton();
            this.tb_PrintPage = new TabPage();
            this.gb_scope = new GroupBox();
            this.label35 = new Label();
            this.label23 = new Label();
            this.tb_scope_to = new TextBox();
            this.tb_scope_from = new TextBox();
            this.rb_scope = new RadioButton();
            this.rb_selected_scope = new RadioButton();
            this.rb_currentpage = new RadioButton();
            this.rb_all = new RadioButton();
            this.gb_page = new GroupBox();
            this.lb_paper_height = new Label();
            this.label34 = new Label();
            this.lb_paper_width = new Label();
            this.label33 = new Label();
            this.pb_orientation_long = new PictureBox();
            this.tb_right = new TextBox();
            this.tb_left = new TextBox();
            this.tb_button = new TextBox();
            this.tb_top = new TextBox();
            this.label32 = new Label();
            this.label31 = new Label();
            this.label30 = new Label();
            this.label29 = new Label();
            this.label28 = new Label();
            this.pb_orientation_landscape = new PictureBox();
            this.rb_orientation_long = new RadioButton();
            this.rb_orientation_landscape = new RadioButton();
            this.label27 = new Label();
            this.cbx_paper_from = new ComboBox();
            this.label26 = new Label();
            this.cbx_page_size = new ComboBox();
            this.label25 = new Label();
            this.pb_paging123123 = new PictureBox();
            this.pb_paging112233 = new PictureBox();
            this.cbx_auto_paging = new CheckBox();
            this.num_copys = new NumericUpDown();
            this.label24 = new Label();
            this.gb_print = new GroupBox();
            this.cbx_print_to_file = new CheckBox();
            this.bt_print_property = new Button();
            this.label20 = new Label();
            this.cbx_printer_select = new ComboBox();
            this.tp_Preview = new TabPage();
            this.trackBar_zoom = new TrackBar();
            this.lb_zoom_size = new Label();
            this.ts_preview_toolbar = new ToolStrip();
            this.toolStripButton_first = new ToolStripButton();
            this.toolStrip_prior = new ToolStripButton();
            this.toolStrip_next = new ToolStripButton();
            this.toolStripButton_last = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripButton3 = new ToolStripSplitButton();
            this.toolStripMenuItem_300 = new ToolStripMenuItem();
            this.toolStripMenuItem_200 = new ToolStripMenuItem();
            this.toolStripMenuItem_150 = new ToolStripMenuItem();
            this.toolStripMenuItem_125 = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripMenuItem_100 = new ToolStripMenuItem();
            this.toolStripSeparator6 = new ToolStripSeparator();
            this.toolStripMenuItem_75 = new ToolStripMenuItem();
            this.toolStripMenuItem_50 = new ToolStripMenuItem();
            this.toolStripMenuItem_25 = new ToolStripMenuItem();
            this.toolStripMenuItem_10 = new ToolStripMenuItem();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.toolStripButton_1 = new ToolStripButton();
            this.toolStripButton_2 = new ToolStripButton();
            this.toolStripButton_3 = new ToolStripButton();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.toolStripButton_review = new ToolStripButton();
            this.toolStripSeparator7 = new ToolStripSeparator();
            this.toolStripLabel_pages = new ToolStripLabel();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.toolStripLabel_XY = new ToolStripLabel();
            this.previewer = new PrintPreviewControl();
            this.label2 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.openFileDialog1 = new OpenFileDialog();
            this.tab_PrintSet.SuspendLayout();
            this.tp_General.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tp_Data.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_columnsToPrint.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gboxRowsToPrint.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.splitContainer_dgv.Panel1.SuspendLayout();
            this.splitContainer_dgv.Panel2.SuspendLayout();
            this.splitContainer_dgv.SuspendLayout();
            this.gb_dgv.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tp_Titles.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((ISupportInitialize) this.pictureBox_logo).BeginInit();
            this.groupBox4.SuspendLayout();
            this.gb_Title_sub.SuspendLayout();
            this.gb_Title_main.SuspendLayout();
            this.tp_HeaderFooter.SuspendLayout();
            this.gb_pages.SuspendLayout();
            this.gb_footer.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gb_header.SuspendLayout();
            this.tp_Others.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_others.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tb_PrintPage.SuspendLayout();
            this.gb_scope.SuspendLayout();
            this.gb_page.SuspendLayout();
            ((ISupportInitialize) this.pb_orientation_long).BeginInit();
            ((ISupportInitialize) this.pb_orientation_landscape).BeginInit();
            ((ISupportInitialize) this.pb_paging123123).BeginInit();
            ((ISupportInitialize) this.pb_paging112233).BeginInit();
            this.num_copys.BeginInit();
            this.gb_print.SuspendLayout();
            this.tp_Preview.SuspendLayout();
            this.trackBar_zoom.BeginInit();
            this.ts_preview_toolbar.SuspendLayout();
            base.SuspendLayout();
            this.bt_OK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.bt_OK.ImageAlign = ContentAlignment.MiddleLeft;
            this.bt_OK.ImageIndex = 11;
            this.bt_OK.ImageList = this.imageList1;
            this.bt_OK.Location = new Point(0x25c, 0x1c0);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new Size(0x4b, 0x18);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "打印(P)";
            this.bt_OK.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.ico");
            this.imageList1.Images.SetKeyName(1, "pagesetting.ico");
            this.imageList1.Images.SetKeyName(2, "pringsetting.ico");
            this.imageList1.Images.SetKeyName(3, "printPreview.ico");
            this.imageList1.Images.SetKeyName(4, "Save.ico");
            this.imageList1.Images.SetKeyName(5, "remove.ico");
            this.imageList1.Images.SetKeyName(6, "Stop.ico");
            this.imageList1.Images.SetKeyName(7, "Tome.ico");
            this.imageList1.Images.SetKeyName(8, "Refresh.ico");
            this.imageList1.Images.SetKeyName(9, "Delete.ico");
            this.imageList1.Images.SetKeyName(10, "Preview.ico");
            this.imageList1.Images.SetKeyName(11, "printer.gif");
            this.imageList1.Images.SetKeyName(12, "CD.ico");
            this.bt_Cancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.bt_Cancel.DialogResult = DialogResult.Cancel;
            this.bt_Cancel.ImageAlign = ContentAlignment.MiddleLeft;
            this.bt_Cancel.ImageIndex = 6;
            this.bt_Cancel.ImageList = this.imageList1;
            this.bt_Cancel.Location = new Point(0x1a0, 0x1c0);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new Size(0x4b, 0x18);
            this.bt_Cancel.TabIndex = 1;
            this.bt_Cancel.Text = "取消(&C)";
            this.bt_Cancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            this.bt_Apply.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.bt_Apply.ImageAlign = ContentAlignment.MiddleLeft;
            this.bt_Apply.ImageIndex = 4;
            this.bt_Apply.ImageList = this.imageList1;
            this.bt_Apply.Location = new Point(0x20b, 0x1c0);
            this.bt_Apply.Name = "bt_Apply";
            this.bt_Apply.Size = new Size(0x4b, 0x18);
            this.bt_Apply.TabIndex = 2;
            this.bt_Apply.Text = "应用(&A)";
            this.bt_Apply.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.bt_Apply.UseVisualStyleBackColor = true;
            this.bt_Apply.Click += new System.EventHandler(this.bt_Apply_Click);
            this.tab_PrintSet.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.tab_PrintSet.Controls.Add(this.tp_General);
            this.tab_PrintSet.Controls.Add(this.tp_Data);
            this.tab_PrintSet.Controls.Add(this.tp_Titles);
            this.tab_PrintSet.Controls.Add(this.tp_HeaderFooter);
            this.tab_PrintSet.Controls.Add(this.tp_Others);
            this.tab_PrintSet.Controls.Add(this.tb_PrintPage);
            this.tab_PrintSet.Controls.Add(this.tp_Preview);
            this.tab_PrintSet.ImageList = this.imageList1;
            this.tab_PrintSet.Location = new Point(4, 3);
            this.tab_PrintSet.Name = "tab_PrintSet";
            this.tab_PrintSet.SelectedIndex = 0;
            this.tab_PrintSet.Size = new Size(0x2ad, 0x1b9);
            this.tab_PrintSet.TabIndex = 3;
            this.tab_PrintSet.Selected += new TabControlEventHandler(this.tab_PrintSet_Selected);
            this.tp_General.Controls.Add(this.groupBox2);
            this.tp_General.Controls.Add(this.label1);
            this.tp_General.Controls.Add(this.groupBox1);
            this.tp_General.ImageIndex = 7;
            this.tp_General.Location = new Point(4, 0x17);
            this.tp_General.Name = "tp_General";
            this.tp_General.Padding = new Padding(3);
            this.tp_General.Size = new Size(0x2a5, 0x19e);
            this.tp_General.TabIndex = 0;
            this.tp_General.Text = "常用";
            this.tp_General.ToolTipText = "常用选项";
            this.tp_General.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.project_detail_list);
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox2.Location = new Point(0xcb, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1d7, 0x198);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "方案详情:";
            this.project_detail_list.Dock = DockStyle.Fill;
            this.project_detail_list.FormattingEnabled = true;
            this.project_detail_list.HorizontalScrollbar = true;
            this.project_detail_list.IntegralHeight = false;
            this.project_detail_list.ItemHeight = 12;
            this.project_detail_list.Location = new Point(3, 0x11);
            this.project_detail_list.Name = "project_detail_list";
            this.project_detail_list.Size = new Size(0x1d1, 0x184);
            this.project_detail_list.TabIndex = 0;
            this.label1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x133);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前方案名称:";
            this.groupBox1.Controls.Add(this.project_list);
            this.groupBox1.Controls.Add(this.bt_Remove);
            this.groupBox1.Controls.Add(this.tb_project_name);
            this.groupBox1.Controls.Add(this.bt_Save);
            this.groupBox1.Dock = DockStyle.Left;
            this.groupBox1.Location = new Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(200, 0x198);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印方案列表:";
            this.project_list.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.project_list.FormattingEnabled = true;
            this.project_list.ItemHeight = 12;
            this.project_list.Location = new Point(3, 0x11);
            this.project_list.Name = "project_list";
            this.project_list.Size = new Size(0xc2, 280);
            this.project_list.Sorted = true;
            this.project_list.TabIndex = 0;
            this.project_list.SelectedValueChanged += new System.EventHandler(this.project_list_SelectedValueChanged);
            this.bt_Remove.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.bt_Remove.ImageAlign = ContentAlignment.MiddleLeft;
            this.bt_Remove.ImageIndex = 9;
            this.bt_Remove.ImageList = this.imageList1;
            this.bt_Remove.Location = new Point(3, 0x179);
            this.bt_Remove.Name = "bt_Remove";
            this.bt_Remove.Size = new Size(0x85, 0x18);
            this.bt_Remove.TabIndex = 4;
            this.bt_Remove.Text = "从列表中删除(&D)";
            this.bt_Remove.TextAlign = ContentAlignment.MiddleLeft;
            this.bt_Remove.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.bt_Remove.UseVisualStyleBackColor = true;
            this.bt_Remove.Click += new System.EventHandler(this.bt_Remove_Click);
            this.tb_project_name.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.tb_project_name.Location = new Point(3, 0x142);
            this.tb_project_name.Name = "tb_project_name";
            this.tb_project_name.Size = new Size(0xbf, 0x15);
            this.tb_project_name.TabIndex = 3;
            this.bt_Save.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.bt_Save.ImageAlign = ContentAlignment.TopLeft;
            this.bt_Save.ImageIndex = 0;
            this.bt_Save.ImageList = this.imageList1;
            this.bt_Save.Location = new Point(3, 0x15d);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new Size(0x91, 0x18);
            this.bt_Save.TabIndex = 4;
            this.bt_Save.Text = "添加或保存到列表(&S)";
            this.bt_Save.TextAlign = ContentAlignment.MiddleLeft;
            this.bt_Save.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            this.tp_Data.Controls.Add(this.splitContainer1);
            this.tp_Data.ImageIndex = 12;
            this.tp_Data.Location = new Point(4, 0x17);
            this.tp_Data.Name = "tp_Data";
            this.tp_Data.Padding = new Padding(3);
            this.tp_Data.Size = new Size(0x2a5, 0x19e);
            this.tp_Data.TabIndex = 8;
            this.tp_Data.Text = "数据";
            this.tp_Data.UseVisualStyleBackColor = true;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.Location = new Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.gb_columnsToPrint);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox10);
            this.splitContainer1.Panel1.Controls.Add(this.gboxRowsToPrint);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox9);
            this.splitContainer1.Panel1MinSize = 0x91;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer_dgv);
            this.splitContainer1.Size = new Size(0x29f, 0x198);
            this.splitContainer1.SplitterDistance = 0x91;
            this.splitContainer1.TabIndex = 0x15;
            this.gb_columnsToPrint.Controls.Add(this.ColumnsList);
            this.gb_columnsToPrint.Dock = DockStyle.Fill;
            this.gb_columnsToPrint.Location = new Point(0, 0x2b);
            this.gb_columnsToPrint.Name = "gb_columnsToPrint";
            this.gb_columnsToPrint.Size = new Size(0x91, 0xb5);
            this.gb_columnsToPrint.TabIndex = 15;
            this.gb_columnsToPrint.TabStop = false;
            this.gb_columnsToPrint.Text = "打印列:";
            this.ColumnsList.CheckOnClick = true;
            this.ColumnsList.Dock = DockStyle.Fill;
            this.ColumnsList.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.ColumnsList.IntegralHeight = false;
            this.ColumnsList.Location = new Point(3, 0x11);
            this.ColumnsList.Name = "ColumnsList";
            this.ColumnsList.Size = new Size(0x8b, 0xa1);
            this.ColumnsList.TabIndex = 14;
            this.ColumnsList.SelectedIndexChanged += new System.EventHandler(this.ColumnsList_SelectedIndexChanged);
            this.groupBox10.Controls.Add(this.ckb_statistic_total);
            this.groupBox10.Controls.Add(this.ckb_statistic_page);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Controls.Add(this.cbx_statistic_column2);
            this.groupBox10.Controls.Add(this.cbx_statistic_column1);
            this.groupBox10.Dock = DockStyle.Bottom;
            this.groupBox10.Location = new Point(0, 0xe0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new Size(0x91, 0x83);
            this.groupBox10.TabIndex = 0x15;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "数据统计:";
            this.ckb_statistic_total.AutoSize = true;
            this.ckb_statistic_total.Location = new Point(6, 40);
            this.ckb_statistic_total.Name = "ckb_statistic_total";
            this.ckb_statistic_total.Size = new Size(0x30, 0x10);
            this.ckb_statistic_total.TabIndex = 3;
            this.ckb_statistic_total.Text = "总计";
            this.ckb_statistic_total.UseVisualStyleBackColor = true;
            this.ckb_statistic_total.CheckedChanged += new System.EventHandler(this.ckb_statistic_total_CheckedChanged);
            this.ckb_statistic_page.AutoSize = true;
            this.ckb_statistic_page.Location = new Point(6, 20);
            this.ckb_statistic_page.Name = "ckb_statistic_page";
            this.ckb_statistic_page.Size = new Size(60, 0x10);
            this.ckb_statistic_page.TabIndex = 3;
            this.ckb_statistic_page.Text = "页小计";
            this.ckb_statistic_page.UseVisualStyleBackColor = true;
            this.ckb_statistic_page.CheckedChanged += new System.EventHandler(this.ckb_statistic_page_CheckedChanged);
            this.label51.AutoSize = true;
            this.label51.Location = new Point(6, 0x3d);
            this.label51.Name = "label51";
            this.label51.Size = new Size(0x6b, 12);
            this.label51.TabIndex = 2;
            this.label51.Text = "统计列:(最多两列)";
            this.cbx_statistic_column2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.cbx_statistic_column2.FormattingEnabled = true;
            this.cbx_statistic_column2.Location = new Point(6, 0x69);
            this.cbx_statistic_column2.Name = "cbx_statistic_column2";
            this.cbx_statistic_column2.Size = new Size(0x85, 20);
            this.cbx_statistic_column2.TabIndex = 1;
            this.cbx_statistic_column2.TextChanged += new System.EventHandler(this.cbx_statistic_column2_TextChanged);
            this.cbx_statistic_column1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.cbx_statistic_column1.FormattingEnabled = true;
            this.cbx_statistic_column1.Location = new Point(6, 80);
            this.cbx_statistic_column1.Name = "cbx_statistic_column1";
            this.cbx_statistic_column1.Size = new Size(0x85, 20);
            this.cbx_statistic_column1.TabIndex = 1;
            this.cbx_statistic_column1.TextChanged += new System.EventHandler(this.cbx_statistic_column1_TextChanged);
            this.gboxRowsToPrint.Controls.Add(this.rdoSelectedRows);
            this.gboxRowsToPrint.Controls.Add(this.rdoAllRows);
            this.gboxRowsToPrint.Dock = DockStyle.Top;
            this.gboxRowsToPrint.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.gboxRowsToPrint.Location = new Point(0, 0);
            this.gboxRowsToPrint.Name = "gboxRowsToPrint";
            this.gboxRowsToPrint.Size = new Size(0x91, 0x2b);
            this.gboxRowsToPrint.TabIndex = 0x13;
            this.gboxRowsToPrint.TabStop = false;
            this.gboxRowsToPrint.Text = "打印行:";
            this.rdoSelectedRows.AutoSize = true;
            this.rdoSelectedRows.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdoSelectedRows.Location = new Point(0x4e, 0x13);
            this.rdoSelectedRows.Name = "rdoSelectedRows";
            this.rdoSelectedRows.Size = new Size(0x3b, 0x10);
            this.rdoSelectedRows.TabIndex = 1;
            this.rdoSelectedRows.TabStop = true;
            this.rdoSelectedRows.Text = "选中的";
            this.rdoSelectedRows.UseVisualStyleBackColor = true;
            this.rdoAllRows.AutoSize = true;
            this.rdoAllRows.Checked = true;
            this.rdoAllRows.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdoAllRows.Location = new Point(12, 0x13);
            this.rdoAllRows.Name = "rdoAllRows";
            this.rdoAllRows.Size = new Size(0x3b, 0x10);
            this.rdoAllRows.TabIndex = 0;
            this.rdoAllRows.TabStop = true;
            this.rdoAllRows.Text = "所有的";
            this.rdoAllRows.UseVisualStyleBackColor = true;
            this.rdoAllRows.CheckedChanged += new System.EventHandler(this.rdoAllRows_CheckedChanged);
            this.groupBox9.Controls.Add(this.bt_propertyGrid);
            this.groupBox9.Dock = DockStyle.Bottom;
            this.groupBox9.Location = new Point(0, 0x163);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(0x91, 0x35);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "表格高级属性:";
            this.bt_propertyGrid.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.bt_propertyGrid.Location = new Point(9, 20);
            this.bt_propertyGrid.Name = "bt_propertyGrid";
            this.bt_propertyGrid.Size = new Size(0x7e, 0x17);
            this.bt_propertyGrid.TabIndex = 0;
            this.bt_propertyGrid.Text = "<< 显示(&S)";
            this.bt_propertyGrid.UseVisualStyleBackColor = true;
            this.bt_propertyGrid.Click += new System.EventHandler(this.bt_propertyGrid_Click);
            this.splitContainer_dgv.Dock = DockStyle.Fill;
            this.splitContainer_dgv.FixedPanel = FixedPanel.Panel2;
            this.splitContainer_dgv.Location = new Point(0, 0);
            this.splitContainer_dgv.Name = "splitContainer_dgv";
            this.splitContainer_dgv.Panel1.Controls.Add(this.gb_dgv);
            this.splitContainer_dgv.Panel2.Controls.Add(this.groupBox8);
            this.splitContainer_dgv.Size = new Size(0x20a, 0x198);
            this.splitContainer_dgv.SplitterDistance = 0x133;
            this.splitContainer_dgv.TabIndex = 0;
            this.gb_dgv.Controls.Add(this.label_msg);
            this.gb_dgv.Dock = DockStyle.Fill;
            this.gb_dgv.Location = new Point(0, 0);
            this.gb_dgv.Name = "gb_dgv";
            this.gb_dgv.Size = new Size(0x133, 0x198);
            this.gb_dgv.TabIndex = 20;
            this.gb_dgv.TabStop = false;
            this.gb_dgv.Text = "数据显示与编辑:(固定列宽和行选择在下表中操作)";
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new Point(0x44, 0xb5);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new Size(0x89, 12);
            this.label_msg.TabIndex = 0;
            this.label_msg.Text = "注意:请在原表格上设置!";
            this.groupBox8.Controls.Add(this.propertyGrid1);
            this.groupBox8.Dock = DockStyle.Fill;
            this.groupBox8.Location = new Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new Size(0xd3, 0x198);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "高级属性设置:";
            this.propertyGrid1.Dock = DockStyle.Fill;
            this.propertyGrid1.Location = new Point(3, 0x11);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new Size(0xcd, 0x184);
            this.propertyGrid1.TabIndex = 0;
            this.tp_Titles.Controls.Add(this.groupBox6);
            this.tp_Titles.Controls.Add(this.groupBox4);
            this.tp_Titles.Controls.Add(this.gb_Title_sub);
            this.tp_Titles.Controls.Add(this.gb_Title_main);
            this.tp_Titles.ImageIndex = 3;
            this.tp_Titles.Location = new Point(4, 0x17);
            this.tp_Titles.Name = "tp_Titles";
            this.tp_Titles.Padding = new Padding(3);
            this.tp_Titles.Size = new Size(0x2a5, 0x19e);
            this.tp_Titles.TabIndex = 1;
            this.tp_Titles.Text = "标题";
            this.tp_Titles.ToolTipText = "标题选项";
            this.tp_Titles.UseVisualStyleBackColor = true;
            this.groupBox6.Controls.Add(this.pictureBox_logo);
            this.groupBox6.Controls.Add(this.logo_height);
            this.groupBox6.Controls.Add(this.logo_width);
            this.groupBox6.Controls.Add(this.logo_Y);
            this.groupBox6.Controls.Add(this.logo_X);
            this.groupBox6.Controls.Add(this.chb_logenable);
            this.groupBox6.Controls.Add(this.label48);
            this.groupBox6.Controls.Add(this.label49);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Controls.Add(this.label46);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.label43);
            this.groupBox6.Controls.Add(this.bt_logochoose);
            this.groupBox6.Controls.Add(this.tb_logopath);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.Dock = DockStyle.Top;
            this.groupBox6.Location = new Point(3, 0xa7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x29f, 0x79);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "LOGO图片:";
            this.pictureBox_logo.Location = new Point(0x1ac, 0x31);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new Size(0xeb, 0x41);
            this.pictureBox_logo.TabIndex = 11;
            this.pictureBox_logo.TabStop = false;
            this.logo_height.Enabled = false;
            this.logo_height.Location = new Point(0x13c, 0x4b);
            this.logo_height.Name = "logo_height";
            this.logo_height.Size = new Size(100, 0x15);
            this.logo_height.TabIndex = 10;
            this.logo_height.TextChanged += new System.EventHandler(this.logo_height_TextChanged);
            this.logo_width.Enabled = false;
            this.logo_width.Location = new Point(0x13c, 0x31);
            this.logo_width.Name = "logo_width";
            this.logo_width.Size = new Size(100, 0x15);
            this.logo_width.TabIndex = 10;
            this.logo_width.TextChanged += new System.EventHandler(this.logo_w_TextChanged);
            this.logo_Y.Enabled = false;
            this.logo_Y.Location = new Point(0x73, 0x4b);
            this.logo_Y.Name = "logo_Y";
            this.logo_Y.Size = new Size(100, 0x15);
            this.logo_Y.TabIndex = 10;
            this.logo_Y.TextChanged += new System.EventHandler(this.logo_Y_TextChanged);
            this.logo_X.Enabled = false;
            this.logo_X.Location = new Point(0x73, 0x31);
            this.logo_X.Name = "logo_X";
            this.logo_X.Size = new Size(100, 0x15);
            this.logo_X.TabIndex = 10;
            this.logo_X.TextChanged += new System.EventHandler(this.logo_X_TextChanged);
            this.chb_logenable.AutoSize = true;
            this.chb_logenable.Location = new Point(0x3f, 0);
            this.chb_logenable.Name = "chb_logenable";
            this.chb_logenable.Size = new Size(15, 14);
            this.chb_logenable.TabIndex = 9;
            this.chb_logenable.UseVisualStyleBackColor = true;
            this.chb_logenable.CheckedChanged += new System.EventHandler(this.chb_logenable_CheckedChanged);
            this.label48.AutoSize = true;
            this.label48.Location = new Point(0x117, 0x4e);
            this.label48.Name = "label48";
            this.label48.Size = new Size(0x23, 12);
            this.label48.TabIndex = 7;
            this.label48.Text = "高度:";
            this.label49.AutoSize = true;
            this.label49.Location = new Point(8, 0x66);
            this.label49.Name = "label49";
            this.label49.Size = new Size(0x185, 12);
            this.label49.TabIndex = 7;
            this.label49.Text = "单位:mm  0表示采用默认值(水平左边距,垂直同主标题,按图片原始大小)";
            this.label47.AutoSize = true;
            this.label47.Location = new Point(0x31, 0x4e);
            this.label47.Name = "label47";
            this.label47.Size = new Size(0x3b, 12);
            this.label47.TabIndex = 7;
            this.label47.Text = "垂直方向:";
            this.label46.AutoSize = true;
            this.label46.Location = new Point(0x117, 0x35);
            this.label46.Name = "label46";
            this.label46.Size = new Size(0x23, 12);
            this.label46.TabIndex = 7;
            this.label46.Text = "宽度:";
            this.label45.AutoSize = true;
            this.label45.Location = new Point(0x31, 0x35);
            this.label45.Name = "label45";
            this.label45.Size = new Size(0x3b, 12);
            this.label45.TabIndex = 7;
            this.label45.Text = "水平方向:";
            this.label42.AutoSize = true;
            this.label42.Location = new Point(0xee, 0x35);
            this.label42.Name = "label42";
            this.label42.Size = new Size(0x23, 12);
            this.label42.TabIndex = 7;
            this.label42.Text = "大小:";
            this.label43.AutoSize = true;
            this.label43.Location = new Point(8, 0x35);
            this.label43.Name = "label43";
            this.label43.Size = new Size(0x23, 12);
            this.label43.TabIndex = 7;
            this.label43.Text = "位置:";
            this.bt_logochoose.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_logochoose.Enabled = false;
            this.bt_logochoose.Location = new Point(0x24c, 20);
            this.bt_logochoose.Name = "bt_logochoose";
            this.bt_logochoose.Size = new Size(0x4b, 0x17);
            this.bt_logochoose.TabIndex = 4;
            this.bt_logochoose.Text = "浏览...";
            this.bt_logochoose.UseVisualStyleBackColor = true;
            this.bt_logochoose.Click += new System.EventHandler(this.bt_logochoose_Click);
            this.tb_logopath.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_logopath.Enabled = false;
            this.tb_logopath.Location = new Point(0x43, 0x15);
            this.tb_logopath.MaxLength = 0x100;
            this.tb_logopath.Name = "tb_logopath";
            this.tb_logopath.Size = new Size(0x205, 0x15);
            this.tb_logopath.TabIndex = 1;
            this.tb_logopath.TextChanged += new System.EventHandler(this.tb_logopath_TextChanged);
            this.label44.AutoSize = true;
            this.label44.Location = new Point(8, 0x18);
            this.label44.Name = "label44";
            this.label44.Size = new Size(0x3b, 12);
            this.label44.TabIndex = 0;
            this.label44.Text = "图片路径:";
            this.groupBox4.Controls.Add(this.lb_TitleSubPreview);
            this.groupBox4.Controls.Add(this.lb_TitleMainPreview);
            this.groupBox4.Dock = DockStyle.Bottom;
            this.groupBox4.Location = new Point(3, 0x123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x29f, 120);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "预览:";
            this.lb_TitleSubPreview.BorderStyle = BorderStyle.FixedSingle;
            this.lb_TitleSubPreview.Dock = DockStyle.Bottom;
            this.lb_TitleSubPreview.Location = new Point(3, 0x48);
            this.lb_TitleSubPreview.Name = "lb_TitleSubPreview";
            this.lb_TitleSubPreview.Size = new Size(0x299, 0x2d);
            this.lb_TitleSubPreview.TabIndex = 4;
            this.lb_TitleSubPreview.Text = "副标题预览文本";
            this.lb_TitleSubPreview.TextAlign = ContentAlignment.MiddleCenter;
            this.lb_TitleMainPreview.BorderStyle = BorderStyle.FixedSingle;
            this.lb_TitleMainPreview.Dock = DockStyle.Top;
            this.lb_TitleMainPreview.Location = new Point(3, 0x11);
            this.lb_TitleMainPreview.Name = "lb_TitleMainPreview";
            this.lb_TitleMainPreview.Size = new Size(0x299, 0x3e);
            this.lb_TitleMainPreview.TabIndex = 3;
            this.lb_TitleMainPreview.Text = "主标题预览文本";
            this.lb_TitleMainPreview.TextAlign = ContentAlignment.MiddleCenter;
            this.gb_Title_sub.Controls.Add(this.cbx_title_sub_enable);
            this.gb_Title_sub.Controls.Add(this.cbx_title_sub_Valign);
            this.gb_Title_sub.Controls.Add(this.label6);
            this.gb_Title_sub.Controls.Add(this.cbx_title_sub_Halign);
            this.gb_Title_sub.Controls.Add(this.label7);
            this.gb_Title_sub.Controls.Add(this.bt_title_sub_font);
            this.gb_Title_sub.Controls.Add(this.tb_Title_sub_text);
            this.gb_Title_sub.Controls.Add(this.label9);
            this.gb_Title_sub.Dock = DockStyle.Top;
            this.gb_Title_sub.Location = new Point(3, 0x55);
            this.gb_Title_sub.Name = "gb_Title_sub";
            this.gb_Title_sub.Size = new Size(0x29f, 0x52);
            this.gb_Title_sub.TabIndex = 1;
            this.gb_Title_sub.TabStop = false;
            this.gb_Title_sub.Text = "副标题:";
            this.cbx_title_sub_enable.AutoSize = true;
            this.cbx_title_sub_enable.Location = new Point(0x33, 0);
            this.cbx_title_sub_enable.Name = "cbx_title_sub_enable";
            this.cbx_title_sub_enable.Size = new Size(15, 14);
            this.cbx_title_sub_enable.TabIndex = 9;
            this.cbx_title_sub_enable.UseVisualStyleBackColor = true;
            this.cbx_title_sub_enable.CheckedChanged += new System.EventHandler(this.cbx_title_sub_enabled_CheckedChanged);
            this.cbx_title_sub_Valign.Enabled = false;
            this.cbx_title_sub_Valign.FormattingEnabled = true;
            this.cbx_title_sub_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_title_sub_Valign.Location = new Point(0x147, 0x31);
            this.cbx_title_sub_Valign.Name = "cbx_title_sub_Valign";
            this.cbx_title_sub_Valign.Size = new Size(0x79, 20);
            this.cbx_title_sub_Valign.TabIndex = 8;
            this.cbx_title_sub_Valign.Text = "Center";
            this.cbx_title_sub_Valign.SelectedValueChanged += new System.EventHandler(this.cbx_title_sub_Valign_SelectedValueChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0xee, 0x35);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "垂直对齐方式:";
            this.cbx_title_sub_Halign.Enabled = false;
            this.cbx_title_sub_Halign.FormattingEnabled = true;
            this.cbx_title_sub_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_title_sub_Halign.Location = new Point(0x61, 0x31);
            this.cbx_title_sub_Halign.Name = "cbx_title_sub_Halign";
            this.cbx_title_sub_Halign.Size = new Size(0x79, 20);
            this.cbx_title_sub_Halign.TabIndex = 8;
            this.cbx_title_sub_Halign.Text = "Center";
            this.cbx_title_sub_Halign.SelectedValueChanged += new System.EventHandler(this.cbx_title_sub_Halign_SelectedValueChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(8, 0x35);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "水平对齐方式:";
            this.bt_title_sub_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_title_sub_font.Enabled = false;
            this.bt_title_sub_font.Location = new Point(0x24c, 0x30);
            this.bt_title_sub_font.Name = "bt_title_sub_font";
            this.bt_title_sub_font.Size = new Size(0x4b, 0x17);
            this.bt_title_sub_font.TabIndex = 4;
            this.bt_title_sub_font.Text = "字体...";
            this.bt_title_sub_font.UseVisualStyleBackColor = true;
            this.bt_title_sub_font.Click += new System.EventHandler(this.bt_title_sub_font_Click);
            this.tb_Title_sub_text.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_Title_sub_text.Enabled = false;
            this.tb_Title_sub_text.Location = new Point(0x31, 0x15);
            this.tb_Title_sub_text.MaxLength = 0x100;
            this.tb_Title_sub_text.Name = "tb_Title_sub_text";
            this.tb_Title_sub_text.Size = new Size(0x266, 0x15);
            this.tb_Title_sub_text.TabIndex = 1;
            this.tb_Title_sub_text.TextChanged += new System.EventHandler(this.tb_Title_sub_text_TextChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(8, 0x18);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x23, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "文本:";
            this.gb_Title_main.Controls.Add(this.cbx_title_main_enable);
            this.gb_Title_main.Controls.Add(this.cbx_title_main_Valign);
            this.gb_Title_main.Controls.Add(this.label5);
            this.gb_Title_main.Controls.Add(this.cbx_title_main_Halign);
            this.gb_Title_main.Controls.Add(this.label4);
            this.gb_Title_main.Controls.Add(this.bt_title_main_font);
            this.gb_Title_main.Controls.Add(this.tb_Title_main_text);
            this.gb_Title_main.Controls.Add(this.label3);
            this.gb_Title_main.Dock = DockStyle.Top;
            this.gb_Title_main.Location = new Point(3, 3);
            this.gb_Title_main.Name = "gb_Title_main";
            this.gb_Title_main.Size = new Size(0x29f, 0x52);
            this.gb_Title_main.TabIndex = 0;
            this.gb_Title_main.TabStop = false;
            this.gb_Title_main.Text = "主标题:";
            this.cbx_title_main_enable.AutoSize = true;
            this.cbx_title_main_enable.Checked = true;
            this.cbx_title_main_enable.CheckState = CheckState.Checked;
            this.cbx_title_main_enable.Location = new Point(0x33, 0);
            this.cbx_title_main_enable.Name = "cbx_title_main_enable";
            this.cbx_title_main_enable.Size = new Size(15, 14);
            this.cbx_title_main_enable.TabIndex = 9;
            this.cbx_title_main_enable.UseVisualStyleBackColor = true;
            this.cbx_title_main_enable.CheckedChanged += new System.EventHandler(this.cbx_title_main_enabled_CheckedChanged);
            this.cbx_title_main_Valign.FormattingEnabled = true;
            this.cbx_title_main_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_title_main_Valign.Location = new Point(0x147, 0x31);
            this.cbx_title_main_Valign.Name = "cbx_title_main_Valign";
            this.cbx_title_main_Valign.Size = new Size(0x79, 20);
            this.cbx_title_main_Valign.TabIndex = 8;
            this.cbx_title_main_Valign.Text = "Center";
            this.cbx_title_main_Valign.SelectedValueChanged += new System.EventHandler(this.cbx_title_main_Valign_SelectedValueChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xee, 0x35);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "垂直对齐方式:";
            this.cbx_title_main_Halign.FormattingEnabled = true;
            this.cbx_title_main_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_title_main_Halign.Location = new Point(0x61, 0x31);
            this.cbx_title_main_Halign.Name = "cbx_title_main_Halign";
            this.cbx_title_main_Halign.Size = new Size(0x79, 20);
            this.cbx_title_main_Halign.TabIndex = 8;
            this.cbx_title_main_Halign.Text = "Center";
            this.cbx_title_main_Halign.SelectedValueChanged += new System.EventHandler(this.cbx_title_main_Halign_SelectedValueChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(8, 0x35);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "水平对齐方式:";
            this.bt_title_main_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_title_main_font.Location = new Point(0x24c, 0x30);
            this.bt_title_main_font.Name = "bt_title_main_font";
            this.bt_title_main_font.Size = new Size(0x4b, 0x17);
            this.bt_title_main_font.TabIndex = 4;
            this.bt_title_main_font.Text = "字体...";
            this.bt_title_main_font.UseVisualStyleBackColor = true;
            this.bt_title_main_font.Click += new System.EventHandler(this.bt_title_main_font_Click);
            this.tb_Title_main_text.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_Title_main_text.Location = new Point(0x31, 0x15);
            this.tb_Title_main_text.MaxLength = 0x100;
            this.tb_Title_main_text.Name = "tb_Title_main_text";
            this.tb_Title_main_text.Size = new Size(0x266, 0x15);
            this.tb_Title_main_text.TabIndex = 1;
            this.tb_Title_main_text.TextChanged += new System.EventHandler(this.tb_Title_main_text_TextChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 0x18);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "文本:";
            this.tp_HeaderFooter.Controls.Add(this.gb_pages);
            this.tp_HeaderFooter.Controls.Add(this.gb_footer);
            this.tp_HeaderFooter.Controls.Add(this.groupBox5);
            this.tp_HeaderFooter.Controls.Add(this.gb_header);
            this.tp_HeaderFooter.ImageIndex = 2;
            this.tp_HeaderFooter.Location = new Point(4, 0x17);
            this.tp_HeaderFooter.Name = "tp_HeaderFooter";
            this.tp_HeaderFooter.Padding = new Padding(3);
            this.tp_HeaderFooter.Size = new Size(0x2a5, 0x19e);
            this.tp_HeaderFooter.TabIndex = 2;
            this.tp_HeaderFooter.Text = "页眉页脚";
            this.tp_HeaderFooter.UseVisualStyleBackColor = true;
            this.gb_pages.Controls.Add(this.label40);
            this.gb_pages.Controls.Add(this.label39);
            this.gb_pages.Controls.Add(this.rb_show_on_footer);
            this.gb_pages.Controls.Add(this.rb_show_on_header);
            this.gb_pages.Controls.Add(this.cbx_page_enable);
            this.gb_pages.Controls.Add(this.cbx_page_Valign);
            this.gb_pages.Controls.Add(this.label36);
            this.gb_pages.Controls.Add(this.cbx_page_Halign);
            this.gb_pages.Controls.Add(this.label37);
            this.gb_pages.Controls.Add(this.bt_page_font);
            this.gb_pages.Controls.Add(this.tb_page_text);
            this.gb_pages.Controls.Add(this.label38);
            this.gb_pages.Dock = DockStyle.Top;
            this.gb_pages.Location = new Point(3, 0xcb);
            this.gb_pages.Name = "gb_pages";
            this.gb_pages.Size = new Size(0x29f, 100);
            this.gb_pages.TabIndex = 11;
            this.gb_pages.TabStop = false;
            this.gb_pages.Text = "页码:";
            this.label40.AutoSize = true;
            this.label40.Location = new Point(0x105, 0x18);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x119, 12);
            this.label40.TabIndex = 11;
            this.label40.Text = "请使用 {0} 代替实际的页码,使用 {1} 表示总页数.";
            this.label39.AutoSize = true;
            this.label39.Location = new Point(0x105, 0x33);
            this.label39.Name = "label39";
            this.label39.Size = new Size(0x23, 12);
            this.label39.TabIndex = 11;
            this.label39.Text = "位置:";
            this.rb_show_on_footer.AutoSize = true;
            this.rb_show_on_footer.Location = new Point(0x146, 0x47);
            this.rb_show_on_footer.Name = "rb_show_on_footer";
            this.rb_show_on_footer.Size = new Size(0x5f, 0x10);
            this.rb_show_on_footer.TabIndex = 10;
            this.rb_show_on_footer.Text = "在页脚上显示";
            this.rb_show_on_footer.UseVisualStyleBackColor = true;
            this.rb_show_on_header.AutoSize = true;
            this.rb_show_on_header.Checked = true;
            this.rb_show_on_header.Location = new Point(0x146, 0x31);
            this.rb_show_on_header.Name = "rb_show_on_header";
            this.rb_show_on_header.Size = new Size(0x5f, 0x10);
            this.rb_show_on_header.TabIndex = 10;
            this.rb_show_on_header.TabStop = true;
            this.rb_show_on_header.Text = "在页眉上显示";
            this.rb_show_on_header.UseVisualStyleBackColor = true;
            this.rb_show_on_header.CheckedChanged += new System.EventHandler(this.rb_show_on_header_CheckedChanged);
            this.cbx_page_enable.AutoSize = true;
            this.cbx_page_enable.Location = new Point(0x27, 0);
            this.cbx_page_enable.Name = "cbx_page_enable";
            this.cbx_page_enable.Size = new Size(15, 14);
            this.cbx_page_enable.TabIndex = 9;
            this.cbx_page_enable.UseVisualStyleBackColor = true;
            this.cbx_page_enable.CheckedChanged += new System.EventHandler(this.cbx_page_enable_CheckedChanged);
            this.cbx_page_Valign.Enabled = false;
            this.cbx_page_Valign.FormattingEnabled = true;
            this.cbx_page_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_page_Valign.Location = new Point(0x79, 0x4a);
            this.cbx_page_Valign.Name = "cbx_page_Valign";
            this.cbx_page_Valign.Size = new Size(0x79, 20);
            this.cbx_page_Valign.TabIndex = 8;
            this.cbx_page_Valign.Text = "Far";
            this.cbx_page_Valign.SelectedIndexChanged += new System.EventHandler(this.cbx_page_Valign_SelectedIndexChanged);
            this.label36.AutoSize = true;
            this.label36.Location = new Point(8, 0x4f);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x53, 12);
            this.label36.TabIndex = 7;
            this.label36.Text = "垂直对齐方式:";
            this.cbx_page_Halign.Enabled = false;
            this.cbx_page_Halign.FormattingEnabled = true;
            this.cbx_page_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_page_Halign.Location = new Point(0x79, 0x30);
            this.cbx_page_Halign.Name = "cbx_page_Halign";
            this.cbx_page_Halign.Size = new Size(0x79, 20);
            this.cbx_page_Halign.TabIndex = 8;
            this.cbx_page_Halign.Text = "Near";
            this.cbx_page_Halign.SelectedIndexChanged += new System.EventHandler(this.cbx_page_Halign_SelectedIndexChanged);
            this.label37.AutoSize = true;
            this.label37.Location = new Point(8, 0x35);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x53, 12);
            this.label37.TabIndex = 7;
            this.label37.Text = "水平对齐方式:";
            this.bt_page_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_page_font.Enabled = false;
            this.bt_page_font.Location = new Point(0x24c, 0x30);
            this.bt_page_font.Name = "bt_page_font";
            this.bt_page_font.Size = new Size(0x4b, 0x17);
            this.bt_page_font.TabIndex = 4;
            this.bt_page_font.Text = "字体...";
            this.bt_page_font.UseVisualStyleBackColor = true;
            this.bt_page_font.Click += new System.EventHandler(this.tb_page_font_Click);
            this.tb_page_text.Enabled = false;
            this.tb_page_text.Location = new Point(0x31, 0x15);
            this.tb_page_text.MaxLength = 0x100;
            this.tb_page_text.Name = "tb_page_text";
            this.tb_page_text.Size = new Size(0xc1, 0x15);
            this.tb_page_text.TabIndex = 1;
            this.tb_page_text.Text = "当前第 {0} 页,总共 {1} 页";
            this.tb_page_text.TextChanged += new System.EventHandler(this.tb_page_text_TextChanged);
            this.label38.AutoSize = true;
            this.label38.Location = new Point(8, 0x18);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x23, 12);
            this.label38.TabIndex = 0;
            this.label38.Text = "文本:";
            this.gb_footer.Controls.Add(this.ckb_footer_enable);
            this.gb_footer.Controls.Add(this.cbx_footer_Valign);
            this.gb_footer.Controls.Add(this.label8);
            this.gb_footer.Controls.Add(this.cbx_footer_Halign);
            this.gb_footer.Controls.Add(this.label10);
            this.gb_footer.Controls.Add(this.bt_footer_font);
            this.gb_footer.Controls.Add(this.tb_footer_text);
            this.gb_footer.Controls.Add(this.label11);
            this.gb_footer.Dock = DockStyle.Top;
            this.gb_footer.Location = new Point(3, 0x67);
            this.gb_footer.Name = "gb_footer";
            this.gb_footer.Size = new Size(0x29f, 100);
            this.gb_footer.TabIndex = 9;
            this.gb_footer.TabStop = false;
            this.gb_footer.Text = "页脚:";
            this.ckb_footer_enable.AutoSize = true;
            this.ckb_footer_enable.Location = new Point(0x27, 0);
            this.ckb_footer_enable.Name = "ckb_footer_enable";
            this.ckb_footer_enable.Size = new Size(15, 14);
            this.ckb_footer_enable.TabIndex = 9;
            this.ckb_footer_enable.UseVisualStyleBackColor = true;
            this.ckb_footer_enable.CheckedChanged += new System.EventHandler(this.ckb_footer_enable_CheckedChanged);
            this.cbx_footer_Valign.Enabled = false;
            this.cbx_footer_Valign.FormattingEnabled = true;
            this.cbx_footer_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_footer_Valign.Location = new Point(0x79, 0x4a);
            this.cbx_footer_Valign.Name = "cbx_footer_Valign";
            this.cbx_footer_Valign.Size = new Size(0x79, 20);
            this.cbx_footer_Valign.TabIndex = 8;
            this.cbx_footer_Valign.Text = "Far";
            this.cbx_footer_Valign.SelectedIndexChanged += new System.EventHandler(this.cbx_footer_Valign_SelectedIndexChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(8, 0x4f);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "垂直对齐方式:";
            this.cbx_footer_Halign.Enabled = false;
            this.cbx_footer_Halign.FormattingEnabled = true;
            this.cbx_footer_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_footer_Halign.Location = new Point(0x79, 0x30);
            this.cbx_footer_Halign.Name = "cbx_footer_Halign";
            this.cbx_footer_Halign.Size = new Size(0x79, 20);
            this.cbx_footer_Halign.TabIndex = 8;
            this.cbx_footer_Halign.Text = "Near";
            this.cbx_footer_Halign.SelectedIndexChanged += new System.EventHandler(this.cbx_footer_Halign_SelectedIndexChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(8, 0x35);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x53, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "水平对齐方式:";
            this.bt_footer_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_footer_font.Enabled = false;
            this.bt_footer_font.Location = new Point(0x24c, 0x30);
            this.bt_footer_font.Name = "bt_footer_font";
            this.bt_footer_font.Size = new Size(0x4b, 0x17);
            this.bt_footer_font.TabIndex = 4;
            this.bt_footer_font.Text = "字体...";
            this.bt_footer_font.UseVisualStyleBackColor = true;
            this.bt_footer_font.Click += new System.EventHandler(this.bt_footer_font_Click);
            this.tb_footer_text.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_footer_text.Enabled = false;
            this.tb_footer_text.Location = new Point(0x31, 0x15);
            this.tb_footer_text.MaxLength = 0x100;
            this.tb_footer_text.Name = "tb_footer_text";
            this.tb_footer_text.Size = new Size(0x266, 0x15);
            this.tb_footer_text.TabIndex = 1;
            this.tb_footer_text.TextChanged += new System.EventHandler(this.tb_footer_text_TextChanged);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(8, 0x18);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x23, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "文本:";
            this.groupBox5.Controls.Add(this.lb_footer_preview);
            this.groupBox5.Controls.Add(this.lb_header_preview);
            this.groupBox5.Dock = DockStyle.Bottom;
            this.groupBox5.Location = new Point(3, 0x142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x29f, 0x59);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "预览:";
            this.lb_footer_preview.BorderStyle = BorderStyle.FixedSingle;
            this.lb_footer_preview.Dock = DockStyle.Bottom;
            this.lb_footer_preview.Location = new Point(3, 0x38);
            this.lb_footer_preview.Name = "lb_footer_preview";
            this.lb_footer_preview.Size = new Size(0x299, 30);
            this.lb_footer_preview.TabIndex = 4;
            this.lb_footer_preview.Text = "页脚预览文本";
            this.lb_footer_preview.TextAlign = ContentAlignment.TopRight;
            this.lb_header_preview.BorderStyle = BorderStyle.FixedSingle;
            this.lb_header_preview.Dock = DockStyle.Top;
            this.lb_header_preview.Location = new Point(3, 0x11);
            this.lb_header_preview.Name = "lb_header_preview";
            this.lb_header_preview.Size = new Size(0x299, 30);
            this.lb_header_preview.TabIndex = 3;
            this.lb_header_preview.Text = "页眉预览文本";
            this.lb_header_preview.TextAlign = ContentAlignment.BottomLeft;
            this.gb_header.Controls.Add(this.ckb_header_enable);
            this.gb_header.Controls.Add(this.cbx_header_Valign);
            this.gb_header.Controls.Add(this.label14);
            this.gb_header.Controls.Add(this.cbx_header_Halign);
            this.gb_header.Controls.Add(this.label15);
            this.gb_header.Controls.Add(this.bt_header_font);
            this.gb_header.Controls.Add(this.tb_header_text);
            this.gb_header.Controls.Add(this.label16);
            this.gb_header.Dock = DockStyle.Top;
            this.gb_header.Location = new Point(3, 3);
            this.gb_header.Name = "gb_header";
            this.gb_header.Size = new Size(0x29f, 100);
            this.gb_header.TabIndex = 8;
            this.gb_header.TabStop = false;
            this.gb_header.Text = "页眉:";
            this.ckb_header_enable.AutoSize = true;
            this.ckb_header_enable.Location = new Point(0x27, 0);
            this.ckb_header_enable.Name = "ckb_header_enable";
            this.ckb_header_enable.Size = new Size(15, 14);
            this.ckb_header_enable.TabIndex = 9;
            this.ckb_header_enable.UseVisualStyleBackColor = true;
            this.ckb_header_enable.CheckedChanged += new System.EventHandler(this.ckb_header_enable_CheckedChanged);
            this.cbx_header_Valign.Enabled = false;
            this.cbx_header_Valign.FormattingEnabled = true;
            this.cbx_header_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_header_Valign.Location = new Point(0x79, 0x4a);
            this.cbx_header_Valign.Name = "cbx_header_Valign";
            this.cbx_header_Valign.Size = new Size(0x79, 20);
            this.cbx_header_Valign.TabIndex = 8;
            this.cbx_header_Valign.Text = "Near";
            this.cbx_header_Valign.SelectedIndexChanged += new System.EventHandler(this.cbx_header_Valign_SelectedIndexChanged);
            this.label14.AutoSize = true;
            this.label14.Location = new Point(8, 0x4f);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x53, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "垂直对齐方式:";
            this.cbx_header_Halign.Enabled = false;
            this.cbx_header_Halign.FormattingEnabled = true;
            this.cbx_header_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_header_Halign.Location = new Point(0x79, 0x30);
            this.cbx_header_Halign.Name = "cbx_header_Halign";
            this.cbx_header_Halign.Size = new Size(0x79, 20);
            this.cbx_header_Halign.TabIndex = 8;
            this.cbx_header_Halign.Text = "Far";
            this.cbx_header_Halign.SelectedIndexChanged += new System.EventHandler(this.cbx_header_Halign_SelectedIndexChanged);
            this.label15.AutoSize = true;
            this.label15.Location = new Point(8, 0x35);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x53, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "水平对齐方式:";
            this.bt_header_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_header_font.Enabled = false;
            this.bt_header_font.Location = new Point(0x24c, 0x30);
            this.bt_header_font.Name = "bt_header_font";
            this.bt_header_font.Size = new Size(0x4b, 0x17);
            this.bt_header_font.TabIndex = 4;
            this.bt_header_font.Text = "字体...";
            this.bt_header_font.UseVisualStyleBackColor = true;
            this.bt_header_font.Click += new System.EventHandler(this.bt_header_font_Click);
            this.tb_header_text.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_header_text.Enabled = false;
            this.tb_header_text.Location = new Point(0x31, 0x15);
            this.tb_header_text.MaxLength = 0x100;
            this.tb_header_text.Name = "tb_header_text";
            this.tb_header_text.Size = new Size(0x266, 0x15);
            this.tb_header_text.TabIndex = 1;
            this.tb_header_text.TextChanged += new System.EventHandler(this.tb_header_text_TextChanged);
            this.label16.AutoSize = true;
            this.label16.Location = new Point(8, 0x18);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x23, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "文本:";
            this.tp_Others.Controls.Add(this.groupBox3);
            this.tp_Others.Controls.Add(this.gb_others);
            this.tp_Others.Controls.Add(this.groupBox11);
            this.tp_Others.Controls.Add(this.groupBox7);
            this.tp_Others.ImageIndex = 5;
            this.tp_Others.Location = new Point(4, 0x17);
            this.tp_Others.Name = "tp_Others";
            this.tp_Others.Padding = new Padding(3);
            this.tp_Others.Size = new Size(0x2a5, 0x19e);
            this.tp_Others.TabIndex = 3;
            this.tp_Others.Text = "其它";
            this.tp_Others.ToolTipText = "其它选项";
            this.tp_Others.UseVisualStyleBackColor = true;
            this.groupBox3.Controls.Add(this.lb_others_preview);
            this.groupBox3.Dock = DockStyle.Bottom;
            this.groupBox3.Location = new Point(3, 0x15c);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x29f, 0x3f);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "预览:";
            this.lb_others_preview.BorderStyle = BorderStyle.FixedSingle;
            this.lb_others_preview.Dock = DockStyle.Fill;
            this.lb_others_preview.Location = new Point(3, 0x11);
            this.lb_others_preview.Name = "lb_others_preview";
            this.lb_others_preview.Size = new Size(0x299, 0x2b);
            this.lb_others_preview.TabIndex = 3;
            this.lb_others_preview.Text = "预览文本";
            this.lb_others_preview.TextAlign = ContentAlignment.MiddleCenter;
            this.gb_others.Controls.Add(this.bt_others_font);
            this.gb_others.Controls.Add(this.cbx_datetime_format);
            this.gb_others.Controls.Add(this.cbx_others_Valign);
            this.gb_others.Controls.Add(this.label22);
            this.gb_others.Controls.Add(this.label13);
            this.gb_others.Controls.Add(this.label21);
            this.gb_others.Controls.Add(this.cbx_others_Halign);
            this.gb_others.Controls.Add(this.label19);
            this.gb_others.Controls.Add(this.label12);
            this.gb_others.Controls.Add(this.cbx_printer);
            this.gb_others.Controls.Add(this.dateTimePicker);
            this.gb_others.Controls.Add(this.tb_printer);
            this.gb_others.Controls.Add(this.cbx_auto_datetime);
            this.gb_others.Controls.Add(this.cbx_auto_printer);
            this.gb_others.Controls.Add(this.cbx_copys);
            this.gb_others.Controls.Add(this.cbx_datetime);
            this.gb_others.Dock = DockStyle.Top;
            this.gb_others.Location = new Point(3, 0xa4);
            this.gb_others.Name = "gb_others";
            this.gb_others.Size = new Size(0x29f, 0x9e);
            this.gb_others.TabIndex = 0x12;
            this.gb_others.TabStop = false;
            this.gb_others.Text = "杂项,其对齐方式和字体:";
            this.bt_others_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_others_font.Location = new Point(590, 0x7e);
            this.bt_others_font.Name = "bt_others_font";
            this.bt_others_font.Size = new Size(0x4b, 0x17);
            this.bt_others_font.TabIndex = 9;
            this.bt_others_font.Text = "字体...";
            this.bt_others_font.UseVisualStyleBackColor = true;
            this.bt_others_font.Click += new System.EventHandler(this.bt_others_font_Click);
            this.cbx_datetime_format.Enabled = false;
            this.cbx_datetime_format.FormattingEnabled = true;
            this.cbx_datetime_format.Items.AddRange(new object[] { "yyyy-MM-dd hh:mm:ss", "yyyy-MM-dd", "hh:mm:ss" });
            this.cbx_datetime_format.Location = new Point(0xd4, 0x4d);
            this.cbx_datetime_format.Name = "cbx_datetime_format";
            this.cbx_datetime_format.Size = new Size(0xa5, 20);
            this.cbx_datetime_format.TabIndex = 0x11;
            this.cbx_datetime_format.Text = "yyyy-MM-dd hh:mm:ss";
            this.cbx_datetime_format.SelectedIndexChanged += new System.EventHandler(this.cbx_datetime_format_SelectedIndexChanged);
            this.cbx_others_Valign.FormattingEnabled = true;
            this.cbx_others_Valign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_others_Valign.Location = new Point(0x152, 0x7e);
            this.cbx_others_Valign.Name = "cbx_others_Valign";
            this.cbx_others_Valign.Size = new Size(0x79, 20);
            this.cbx_others_Valign.TabIndex = 12;
            this.cbx_others_Valign.Text = "Center";
            this.cbx_others_Valign.SelectedIndexChanged += new System.EventHandler(this.cbx_others_Valign_SelectedIndexChanged);
            this.label22.AutoSize = true;
            this.label22.Location = new Point(0x7a, 0x33);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x3b, 12);
            this.label22.TabIndex = 0x10;
            this.label22.Text = "显示文本:";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(14, 0x83);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x53, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "水平对齐方式:";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(0x7a, 0x15);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x3b, 12);
            this.label21.TabIndex = 0x10;
            this.label21.Text = "显示文本:";
            this.cbx_others_Halign.FormattingEnabled = true;
            this.cbx_others_Halign.Items.AddRange(new object[] { "Near", "Center", "Far" });
            this.cbx_others_Halign.Location = new Point(0x66, 0x7e);
            this.cbx_others_Halign.Name = "cbx_others_Halign";
            this.cbx_others_Halign.Size = new Size(0x79, 20);
            this.cbx_others_Halign.TabIndex = 13;
            this.cbx_others_Halign.Text = "Center";
            this.cbx_others_Halign.SelectedIndexChanged += new System.EventHandler(this.cbx_others_Halign_SelectedIndexChanged);
            this.label19.AutoSize = true;
            this.label19.Location = new Point(0x7a, 80);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x53, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "日期时间格式:";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(250, 0x83);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x53, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "垂直对齐方式:";
            this.cbx_printer.AutoSize = true;
            this.cbx_printer.Location = new Point(0x10, 20);
            this.cbx_printer.Name = "cbx_printer";
            this.cbx_printer.Size = new Size(90, 0x10);
            this.cbx_printer.TabIndex = 0;
            this.cbx_printer.Text = "打印用户名:";
            this.cbx_printer.UseVisualStyleBackColor = true;
            this.cbx_printer.CheckedChanged += new System.EventHandler(this.cbx_printer_CheckedChanged);
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new Point(0xd3, 0x2f);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new Size(0xa6, 0x15);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.tb_printer.Enabled = false;
            this.tb_printer.Location = new Point(0xd3, 0x12);
            this.tb_printer.Name = "tb_printer";
            this.tb_printer.Size = new Size(0xa6, 0x15);
            this.tb_printer.TabIndex = 1;
            this.tb_printer.TextChanged += new System.EventHandler(this.tb_printer_TextChanged);
            this.cbx_auto_datetime.AutoSize = true;
            this.cbx_auto_datetime.Enabled = false;
            this.cbx_auto_datetime.Location = new Point(0x185, 50);
            this.cbx_auto_datetime.Name = "cbx_auto_datetime";
            this.cbx_auto_datetime.Size = new Size(120, 0x10);
            this.cbx_auto_datetime.TabIndex = 5;
            this.cbx_auto_datetime.Text = "自动获取日期时间";
            this.cbx_auto_datetime.UseVisualStyleBackColor = true;
            this.cbx_auto_datetime.CheckedChanged += new System.EventHandler(this.cbx_auto_datetime_CheckedChanged);
            this.cbx_auto_printer.AutoSize = true;
            this.cbx_auto_printer.Enabled = false;
            this.cbx_auto_printer.Location = new Point(0x185, 20);
            this.cbx_auto_printer.Name = "cbx_auto_printer";
            this.cbx_auto_printer.Size = new Size(0x48, 0x10);
            this.cbx_auto_printer.TabIndex = 2;
            this.cbx_auto_printer.Text = "自动获取";
            this.cbx_auto_printer.UseVisualStyleBackColor = true;
            this.cbx_auto_printer.CheckedChanged += new System.EventHandler(this.cbx_auto_printer_CheckedChanged);
            this.cbx_copys.AutoSize = true;
            this.cbx_copys.Location = new Point(0x10, 100);
            this.cbx_copys.Name = "cbx_copys";
            this.cbx_copys.Size = new Size(0x48, 0x10);
            this.cbx_copys.TabIndex = 3;
            this.cbx_copys.Text = "打印份数";
            this.cbx_copys.UseVisualStyleBackColor = true;
            this.cbx_copys.CheckedChanged += new System.EventHandler(this.cbx_copys_CheckedChanged);
            this.cbx_datetime.AutoSize = true;
            this.cbx_datetime.Location = new Point(0x10, 50);
            this.cbx_datetime.Name = "cbx_datetime";
            this.cbx_datetime.Size = new Size(0x66, 0x10);
            this.cbx_datetime.TabIndex = 3;
            this.cbx_datetime.Text = "打印日期时间:";
            this.cbx_datetime.UseVisualStyleBackColor = true;
            this.cbx_datetime.CheckedChanged += new System.EventHandler(this.cbx_datetime_CheckedChanged);
            this.groupBox11.Controls.Add(this.tb_watermark_angle);
            this.groupBox11.Controls.Add(this.label56);
            this.groupBox11.Controls.Add(this.tb_watermark_y);
            this.groupBox11.Controls.Add(this.tb_watermark_x);
            this.groupBox11.Controls.Add(this.label52);
            this.groupBox11.Controls.Add(this.label53);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Controls.Add(this.label55);
            this.groupBox11.Controls.Add(this.bt_watermark_font);
            this.groupBox11.Controls.Add(this.tb_watermark_text);
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.ckb_watermark_enable);
            this.groupBox11.Dock = DockStyle.Top;
            this.groupBox11.Location = new Point(3, 0x45);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new Size(0x29f, 0x5f);
            this.groupBox11.TabIndex = 0x16;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "水印:";
            this.tb_watermark_angle.Enabled = false;
            this.tb_watermark_angle.Location = new Point(0x141, 0x2e);
            this.tb_watermark_angle.MaxLength = 0x100;
            this.tb_watermark_angle.Name = "tb_watermark_angle";
            this.tb_watermark_angle.Size = new Size(0x33, 0x15);
            this.tb_watermark_angle.TabIndex = 0x1d;
            this.tb_watermark_angle.TextChanged += new System.EventHandler(this.tb_watermark_angle_TextChanged);
            this.label56.AutoSize = true;
            this.label56.Location = new Point(0x106, 50);
            this.label56.Name = "label56";
            this.label56.Size = new Size(0x3b, 12);
            this.label56.TabIndex = 0x1c;
            this.label56.Text = "旋转角度:";
            this.tb_watermark_y.Enabled = false;
            this.tb_watermark_y.Location = new Point(0x79, 0x2e);
            this.tb_watermark_y.Name = "tb_watermark_y";
            this.tb_watermark_y.Size = new Size(100, 0x15);
            this.tb_watermark_y.TabIndex = 0x1a;
            this.tb_watermark_y.TextChanged += new System.EventHandler(this.tb_watermark_y_TextChanged);
            this.tb_watermark_x.Enabled = false;
            this.tb_watermark_x.Location = new Point(0x79, 20);
            this.tb_watermark_x.Name = "tb_watermark_x";
            this.tb_watermark_x.Size = new Size(100, 0x15);
            this.tb_watermark_x.TabIndex = 0x1b;
            this.tb_watermark_x.TextChanged += new System.EventHandler(this.tb_watermark_x_TextChanged);
            this.label52.AutoSize = true;
            this.label52.Location = new Point(14, 0x49);
            this.label52.Name = "label52";
            this.label52.Size = new Size(0xd1, 12);
            this.label52.TabIndex = 0x19;
            this.label52.Text = "单位:mm  0表示居中打印在纸张正中央";
            this.label53.AutoSize = true;
            this.label53.Location = new Point(0x37, 50);
            this.label53.Name = "label53";
            this.label53.Size = new Size(0x3b, 12);
            this.label53.TabIndex = 0x16;
            this.label53.Text = "垂直方向:";
            this.label54.AutoSize = true;
            this.label54.Location = new Point(0x37, 0x18);
            this.label54.Name = "label54";
            this.label54.Size = new Size(0x3b, 12);
            this.label54.TabIndex = 0x17;
            this.label54.Text = "水平方向:";
            this.label55.AutoSize = true;
            this.label55.Location = new Point(14, 0x18);
            this.label55.Name = "label55";
            this.label55.Size = new Size(0x23, 12);
            this.label55.TabIndex = 0x18;
            this.label55.Text = "位置:";
            this.bt_watermark_font.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_watermark_font.Enabled = false;
            this.bt_watermark_font.Location = new Point(590, 0x12);
            this.bt_watermark_font.Name = "bt_watermark_font";
            this.bt_watermark_font.Size = new Size(0x4b, 0x17);
            this.bt_watermark_font.TabIndex = 0x15;
            this.bt_watermark_font.Text = "字体...";
            this.bt_watermark_font.UseVisualStyleBackColor = true;
            this.bt_watermark_font.Click += new System.EventHandler(this.bt_watermark_font_Click);
            this.tb_watermark_text.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.tb_watermark_text.Enabled = false;
            this.tb_watermark_text.Location = new Point(0x141, 20);
            this.tb_watermark_text.MaxLength = 0x100;
            this.tb_watermark_text.Name = "tb_watermark_text";
            this.tb_watermark_text.Size = new Size(0x107, 0x15);
            this.tb_watermark_text.TabIndex = 20;
            this.tb_watermark_text.TextChanged += new System.EventHandler(this.tb_watermark_text_TextChanged);
            this.label50.AutoSize = true;
            this.label50.Location = new Point(0x106, 0x17);
            this.label50.Name = "label50";
            this.label50.Size = new Size(0x23, 12);
            this.label50.TabIndex = 0x13;
            this.label50.Text = "文本:";
            this.ckb_watermark_enable.AutoSize = true;
            this.ckb_watermark_enable.Location = new Point(0x27, 0);
            this.ckb_watermark_enable.Name = "ckb_watermark_enable";
            this.ckb_watermark_enable.Size = new Size(15, 14);
            this.ckb_watermark_enable.TabIndex = 0x12;
            this.ckb_watermark_enable.UseVisualStyleBackColor = true;
            this.ckb_watermark_enable.CheckedChanged += new System.EventHandler(this.ckb_watermark_enable_CheckedChanged);
            this.groupBox7.Controls.Add(this.checkBox_fixwidt);
            this.groupBox7.Controls.Add(this.rdo_layout_0);
            this.groupBox7.Controls.Add(this.rdo_layout_2);
            this.groupBox7.Controls.Add(this.rdo_layout_1);
            this.groupBox7.Dock = DockStyle.Top;
            this.groupBox7.Location = new Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x29f, 0x42);
            this.groupBox7.TabIndex = 0x15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "表格布局方式:";
            this.checkBox_fixwidt.AutoSize = true;
            this.checkBox_fixwidt.Location = new Point(0x9d, 0x2a);
            this.checkBox_fixwidt.Name = "checkBox_fixwidt";
            this.checkBox_fixwidt.Size = new Size(0xfc, 0x10);
            this.checkBox_fixwidt.TabIndex = 1;
            this.checkBox_fixwidt.Text = "固定列宽(请到\"打印数据\"标签中设置列宽)";
            this.checkBox_fixwidt.UseVisualStyleBackColor = true;
            this.checkBox_fixwidt.CheckedChanged += new System.EventHandler(this.checkBox_fixwidt_CheckedChanged);
            this.rdo_layout_0.AutoSize = true;
            this.rdo_layout_0.Checked = true;
            this.rdo_layout_0.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdo_layout_0.Location = new Point(0x10, 20);
            this.rdo_layout_0.Name = "rdo_layout_0";
            this.rdo_layout_0.Size = new Size(0x6b, 0x10);
            this.rdo_layout_0.TabIndex = 0;
            this.rdo_layout_0.TabStop = true;
            this.rdo_layout_0.Text = "左对齐(0,默认)";
            this.rdo_layout_0.UseVisualStyleBackColor = true;
            this.rdo_layout_0.CheckedChanged += new System.EventHandler(this.rdo_layout_CheckedChanged);
            this.rdo_layout_2.AutoSize = true;
            this.rdo_layout_2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdo_layout_2.Location = new Point(0x9d, 0x15);
            this.rdo_layout_2.Name = "rdo_layout_2";
            this.rdo_layout_2.Size = new Size(0x113, 0x10);
            this.rdo_layout_2.TabIndex = 0;
            this.rdo_layout_2.Text = "自动适应页宽(2,只对表宽小于页宽的情况有效)";
            this.rdo_layout_2.UseVisualStyleBackColor = true;
            this.rdo_layout_2.CheckedChanged += new System.EventHandler(this.rdo_layout_CheckedChanged);
            this.rdo_layout_1.AutoSize = true;
            this.rdo_layout_1.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdo_layout_1.Location = new Point(0x10, 0x29);
            this.rdo_layout_1.Name = "rdo_layout_1";
            this.rdo_layout_1.Size = new Size(0x59, 0x10);
            this.rdo_layout_1.TabIndex = 0;
            this.rdo_layout_1.Text = "居中对齐(1)";
            this.rdo_layout_1.UseVisualStyleBackColor = true;
            this.rdo_layout_1.CheckedChanged += new System.EventHandler(this.rdo_layout_CheckedChanged);
            this.tb_PrintPage.Controls.Add(this.gb_scope);
            this.tb_PrintPage.Controls.Add(this.gb_page);
            this.tb_PrintPage.Controls.Add(this.gb_print);
            this.tb_PrintPage.ImageIndex = 1;
            this.tb_PrintPage.Location = new Point(4, 0x17);
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.Padding = new Padding(3);
            this.tb_PrintPage.Size = new Size(0x2a5, 0x19e);
            this.tb_PrintPage.TabIndex = 4;
            this.tb_PrintPage.Text = "页面和打印机";
            this.tb_PrintPage.ToolTipText = "页面和打印机选项";
            this.tb_PrintPage.UseVisualStyleBackColor = true;
            this.gb_scope.Controls.Add(this.label35);
            this.gb_scope.Controls.Add(this.label23);
            this.gb_scope.Controls.Add(this.tb_scope_to);
            this.gb_scope.Controls.Add(this.tb_scope_from);
            this.gb_scope.Controls.Add(this.rb_scope);
            this.gb_scope.Controls.Add(this.rb_selected_scope);
            this.gb_scope.Controls.Add(this.rb_currentpage);
            this.gb_scope.Controls.Add(this.rb_all);
            this.gb_scope.Dock = DockStyle.Top;
            this.gb_scope.Location = new Point(3, 0x106);
            this.gb_scope.Name = "gb_scope";
            this.gb_scope.Size = new Size(0x29f, 0x5e);
            this.gb_scope.TabIndex = 2;
            this.gb_scope.TabStop = false;
            this.gb_scope.Text = "打印范围:";
            this.label35.AutoSize = true;
            this.label35.Location = new Point(0x4e, 0x2d);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x11, 12);
            this.label35.TabIndex = 2;
            this.label35.Text = "从";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(0xa4, 0x2e);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x11, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "到";
            this.tb_scope_to.Enabled = false;
            this.tb_scope_to.Location = new Point(0xba, 0x2a);
            this.tb_scope_to.Name = "tb_scope_to";
            this.tb_scope_to.Size = new Size(60, 0x15);
            this.tb_scope_to.TabIndex = 1;
            this.tb_scope_to.TextChanged += new System.EventHandler(this.tb_scope_to_TextChanged);
            this.tb_scope_from.Enabled = false;
            this.tb_scope_from.Location = new Point(0x62, 0x29);
            this.tb_scope_from.Name = "tb_scope_from";
            this.tb_scope_from.Size = new Size(60, 0x15);
            this.tb_scope_from.TabIndex = 1;
            this.tb_scope_from.TextChanged += new System.EventHandler(this.tb_scope_from_TextChanged);
            this.rb_scope.AutoSize = true;
            this.rb_scope.Location = new Point(12, 0x2a);
            this.rb_scope.Name = "rb_scope";
            this.rb_scope.Size = new Size(0x2f, 0x10);
            this.rb_scope.TabIndex = 0;
            this.rb_scope.Text = "范围";
            this.rb_scope.UseVisualStyleBackColor = true;
            this.rb_scope.CheckedChanged += new System.EventHandler(this.print_scope_CheckedChanged);
            this.rb_selected_scope.AutoSize = true;
            this.rb_selected_scope.Location = new Point(12, 0x40);
            this.rb_selected_scope.Name = "rb_selected_scope";
            this.rb_selected_scope.Size = new Size(0x47, 0x10);
            this.rb_selected_scope.TabIndex = 0;
            this.rb_selected_scope.Text = "选择的页";
            this.rb_selected_scope.UseVisualStyleBackColor = true;
            this.rb_selected_scope.CheckedChanged += new System.EventHandler(this.print_scope_CheckedChanged);
            this.rb_currentpage.AutoSize = true;
            this.rb_currentpage.Location = new Point(0x4e, 20);
            this.rb_currentpage.Name = "rb_currentpage";
            this.rb_currentpage.Size = new Size(0x3b, 0x10);
            this.rb_currentpage.TabIndex = 0;
            this.rb_currentpage.Text = "当前页";
            this.rb_currentpage.UseVisualStyleBackColor = true;
            this.rb_currentpage.CheckedChanged += new System.EventHandler(this.print_scope_CheckedChanged);
            this.rb_all.AutoSize = true;
            this.rb_all.Checked = true;
            this.rb_all.Location = new Point(12, 20);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new Size(0x3b, 0x10);
            this.rb_all.TabIndex = 0;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "所有页";
            this.rb_all.UseVisualStyleBackColor = true;
            this.rb_all.CheckedChanged += new System.EventHandler(this.print_scope_CheckedChanged);
            this.gb_page.Controls.Add(this.lb_paper_height);
            this.gb_page.Controls.Add(this.label34);
            this.gb_page.Controls.Add(this.lb_paper_width);
            this.gb_page.Controls.Add(this.label33);
            this.gb_page.Controls.Add(this.pb_orientation_long);
            this.gb_page.Controls.Add(this.tb_right);
            this.gb_page.Controls.Add(this.tb_left);
            this.gb_page.Controls.Add(this.tb_button);
            this.gb_page.Controls.Add(this.tb_top);
            this.gb_page.Controls.Add(this.label32);
            this.gb_page.Controls.Add(this.label31);
            this.gb_page.Controls.Add(this.label30);
            this.gb_page.Controls.Add(this.label29);
            this.gb_page.Controls.Add(this.label28);
            this.gb_page.Controls.Add(this.pb_orientation_landscape);
            this.gb_page.Controls.Add(this.rb_orientation_long);
            this.gb_page.Controls.Add(this.rb_orientation_landscape);
            this.gb_page.Controls.Add(this.label27);
            this.gb_page.Controls.Add(this.cbx_paper_from);
            this.gb_page.Controls.Add(this.label26);
            this.gb_page.Controls.Add(this.cbx_page_size);
            this.gb_page.Controls.Add(this.label25);
            this.gb_page.Controls.Add(this.pb_paging123123);
            this.gb_page.Controls.Add(this.pb_paging112233);
            this.gb_page.Controls.Add(this.cbx_auto_paging);
            this.gb_page.Controls.Add(this.num_copys);
            this.gb_page.Controls.Add(this.label24);
            this.gb_page.Dock = DockStyle.Top;
            this.gb_page.Location = new Point(3, 0x33);
            this.gb_page.Name = "gb_page";
            this.gb_page.Size = new Size(0x29f, 0xd3);
            this.gb_page.TabIndex = 1;
            this.gb_page.TabStop = false;
            this.gb_page.Text = "页码:";
            this.lb_paper_height.AutoSize = true;
            this.lb_paper_height.Location = new Point(0x1de, 0x45);
            this.lb_paper_height.Name = "lb_paper_height";
            this.lb_paper_height.Size = new Size(0x11, 12);
            this.lb_paper_height.TabIndex = 13;
            this.lb_paper_height.Text = "--";
            this.label34.AutoSize = true;
            this.label34.Location = new Point(0x18b, 0x45);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x23, 12);
            this.label34.TabIndex = 13;
            this.label34.Text = "页高:";
            this.lb_paper_width.AutoSize = true;
            this.lb_paper_width.Location = new Point(0x1de, 0x2c);
            this.lb_paper_width.Name = "lb_paper_width";
            this.lb_paper_width.Size = new Size(0x11, 12);
            this.lb_paper_width.TabIndex = 13;
            this.lb_paper_width.Text = "--";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(0x18b, 0x2c);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x23, 12);
            this.label33.TabIndex = 13;
            this.label33.Text = "页宽:";
            this.pb_orientation_long.BorderStyle = BorderStyle.FixedSingle;
            this.pb_orientation_long.Image = (Image) resources.GetObject("pb_orientation_long.Image");
            this.pb_orientation_long.Location = new Point(0xc1, 0x37);
            this.pb_orientation_long.Name = "pb_orientation_long";
            this.pb_orientation_long.Size = new Size(0x34, 0x25);
            this.pb_orientation_long.TabIndex = 3;
            this.pb_orientation_long.TabStop = false;
            this.tb_right.Location = new Point(0x22c, 0xb3);
            this.tb_right.Name = "tb_right";
            this.tb_right.Size = new Size(0x43, 0x15);
            this.tb_right.TabIndex = 12;
            this.tb_right.Text = "20";
            this.tb_right.TextChanged += new System.EventHandler(this.tb_right_TextChanged);
            this.tb_left.Location = new Point(0x18d, 0xb3);
            this.tb_left.Name = "tb_left";
            this.tb_left.Size = new Size(0x43, 0x15);
            this.tb_left.TabIndex = 12;
            this.tb_left.Text = "20";
            this.tb_left.TextChanged += new System.EventHandler(this.tb_left_TextChanged);
            this.tb_button.Location = new Point(0x22c, 0x98);
            this.tb_button.Name = "tb_button";
            this.tb_button.Size = new Size(0x43, 0x15);
            this.tb_button.TabIndex = 12;
            this.tb_button.Text = "20";
            this.tb_button.TextChanged += new System.EventHandler(this.tb_button_TextChanged);
            this.tb_top.Location = new Point(0x18d, 0x98);
            this.tb_top.Name = "tb_top";
            this.tb_top.Size = new Size(0x43, 0x15);
            this.tb_top.TabIndex = 12;
            this.tb_top.Text = "20";
            this.tb_top.TextChanged += new System.EventHandler(this.tb_top_TextChanged);
            this.label32.AutoSize = true;
            this.label32.Location = new Point(0x204, 0xb6);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x17, 12);
            this.label32.TabIndex = 11;
            this.label32.Text = "右:";
            this.label31.AutoSize = true;
            this.label31.Location = new Point(0x16a, 0xb6);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x17, 12);
            this.label31.TabIndex = 11;
            this.label31.Text = "左:";
            this.label30.AutoSize = true;
            this.label30.Location = new Point(0x204, 0x9b);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x17, 12);
            this.label30.TabIndex = 11;
            this.label30.Text = "下:";
            this.label29.AutoSize = true;
            this.label29.Location = new Point(0x16a, 0x9b);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x17, 12);
            this.label29.TabIndex = 11;
            this.label29.Text = "上:";
            this.label28.AutoSize = true;
            this.label28.Location = new Point(290, 0x80);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x65, 12);
            this.label28.TabIndex = 10;
            this.label28.Text = "页边距(单位 mm):";
            this.pb_orientation_landscape.BorderStyle = BorderStyle.FixedSingle;
            this.pb_orientation_landscape.Image = (Image) resources.GetObject("pb_orientation_landscape.Image");
            this.pb_orientation_landscape.Location = new Point(0xc5, 0x33);
            this.pb_orientation_landscape.Name = "pb_orientation_landscape";
            this.pb_orientation_landscape.Size = new Size(0x34, 0x25);
            this.pb_orientation_landscape.TabIndex = 3;
            this.pb_orientation_landscape.TabStop = false;
            this.rb_orientation_long.AutoSize = true;
            this.rb_orientation_long.Checked = true;
            this.rb_orientation_long.Location = new Point(0xc1, 0x7e);
            this.rb_orientation_long.Name = "rb_orientation_long";
            this.rb_orientation_long.Size = new Size(0x2f, 0x10);
            this.rb_orientation_long.TabIndex = 9;
            this.rb_orientation_long.TabStop = true;
            this.rb_orientation_long.Text = "纵向";
            this.rb_orientation_long.UseVisualStyleBackColor = true;
            this.rb_orientation_long.CheckedChanged += new System.EventHandler(this.rb_orientation_long_CheckedChanged);
            this.rb_orientation_landscape.AutoSize = true;
            this.rb_orientation_landscape.Location = new Point(0xc1, 0x65);
            this.rb_orientation_landscape.Name = "rb_orientation_landscape";
            this.rb_orientation_landscape.Size = new Size(0x2f, 0x10);
            this.rb_orientation_landscape.TabIndex = 9;
            this.rb_orientation_landscape.Text = "横向";
            this.rb_orientation_landscape.UseVisualStyleBackColor = true;
            this.rb_orientation_landscape.CheckedChanged += new System.EventHandler(this.rb_orientation_landscape_CheckedChanged);
            this.label27.AutoSize = true;
            this.label27.Location = new Point(0xac, 0x13);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x3b, 12);
            this.label27.TabIndex = 8;
            this.label27.Text = "纸张方向:";
            this.cbx_paper_from.FormattingEnabled = true;
            this.cbx_paper_from.Location = new Point(0x18d, 100);
            this.cbx_paper_from.Name = "cbx_paper_from";
            this.cbx_paper_from.Size = new Size(0xe2, 20);
            this.cbx_paper_from.TabIndex = 7;
            this.cbx_paper_from.SelectedIndexChanged += new System.EventHandler(this.cbx_paper_from_SelectedIndexChanged);
            this.label26.AutoSize = true;
            this.label26.Location = new Point(290, 0x68);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x3b, 12);
            this.label26.TabIndex = 6;
            this.label26.Text = "纸张来源:";
            this.cbx_page_size.DropDownHeight = 240;
            this.cbx_page_size.FormattingEnabled = true;
            this.cbx_page_size.IntegralHeight = false;
            this.cbx_page_size.Location = new Point(0x18d, 14);
            this.cbx_page_size.Name = "cbx_page_size";
            this.cbx_page_size.Size = new Size(0xe2, 20);
            this.cbx_page_size.TabIndex = 5;
            this.cbx_page_size.SelectedIndexChanged += new System.EventHandler(this.cbx_page_size_SelectedIndexChanged);
            this.label25.AutoSize = true;
            this.label25.Location = new Point(290, 0x13);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x3b, 12);
            this.label25.TabIndex = 4;
            this.label25.Text = "纸张大小:";
            this.pb_paging123123.BorderStyle = BorderStyle.FixedSingle;
            this.pb_paging123123.Image = (Image) resources.GetObject("pb_paging123123.Image");
            this.pb_paging123123.Location = new Point(0x33, 50);
            this.pb_paging123123.Name = "pb_paging123123";
            this.pb_paging123123.Size = new Size(0x68, 0x3f);
            this.pb_paging123123.TabIndex = 3;
            this.pb_paging123123.TabStop = false;
            this.pb_paging112233.BorderStyle = BorderStyle.FixedSingle;
            this.pb_paging112233.Image = (Image) resources.GetObject("pb_paging112233.Image");
            this.pb_paging112233.Location = new Point(0x2f, 0x36);
            this.pb_paging112233.Name = "pb_paging112233";
            this.pb_paging112233.Size = new Size(0x68, 0x3f);
            this.pb_paging112233.TabIndex = 3;
            this.pb_paging112233.TabStop = false;
            this.cbx_auto_paging.AutoSize = true;
            this.cbx_auto_paging.Checked = true;
            this.cbx_auto_paging.CheckState = CheckState.Checked;
            this.cbx_auto_paging.Location = new Point(0x2f, 0x7f);
            this.cbx_auto_paging.Name = "cbx_auto_paging";
            this.cbx_auto_paging.Size = new Size(0x60, 0x10);
            this.cbx_auto_paging.TabIndex = 2;
            this.cbx_auto_paging.Text = "自动排列页序";
            this.cbx_auto_paging.UseVisualStyleBackColor = true;
            this.cbx_auto_paging.CheckedChanged += new System.EventHandler(this.cbx_auto_paging_CheckedChanged);
            this.num_copys.Location = new Point(0x33, 15);
            int[] CS$0$0013 = new int[4];
            CS$0$0013[0] = 1;
            this.num_copys.Minimum = new decimal(CS$0$0013);
            this.num_copys.Name = "num_copys";
            this.num_copys.Size = new Size(0x3e, 0x15);
            this.num_copys.TabIndex = 1;
            int[] CS$0$0014 = new int[4];
            CS$0$0014[0] = 1;
            this.num_copys.Value = new decimal(CS$0$0014);
            this.num_copys.ValueChanged += new System.EventHandler(this.num_copys_ValueChanged);
            this.label24.AutoSize = true;
            this.label24.Location = new Point(10, 0x13);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x23, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "份数:";
            this.gb_print.Controls.Add(this.cbx_print_to_file);
            this.gb_print.Controls.Add(this.bt_print_property);
            this.gb_print.Controls.Add(this.label20);
            this.gb_print.Controls.Add(this.cbx_printer_select);
            this.gb_print.Dock = DockStyle.Top;
            this.gb_print.Location = new Point(3, 3);
            this.gb_print.Name = "gb_print";
            this.gb_print.Size = new Size(0x29f, 0x30);
            this.gb_print.TabIndex = 0;
            this.gb_print.TabStop = false;
            this.gb_print.Text = "打印:";
            this.cbx_print_to_file.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.cbx_print_to_file.AutoSize = true;
            this.cbx_print_to_file.Location = new Point(0x243, 0x13);
            this.cbx_print_to_file.Name = "cbx_print_to_file";
            this.cbx_print_to_file.Size = new Size(0x54, 0x10);
            this.cbx_print_to_file.TabIndex = 3;
            this.cbx_print_to_file.Text = "打印到文件";
            this.cbx_print_to_file.UseVisualStyleBackColor = true;
            this.cbx_print_to_file.CheckedChanged += new System.EventHandler(this.cbx_print_to_file_CheckedChanged);
            this.bt_print_property.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.bt_print_property.Location = new Point(0x1d9, 15);
            this.bt_print_property.Name = "bt_print_property";
            this.bt_print_property.Size = new Size(0x52, 0x17);
            this.bt_print_property.TabIndex = 2;
            this.bt_print_property.Text = "属性(&P)...";
            this.bt_print_property.UseVisualStyleBackColor = true;
            this.bt_print_property.Click += new System.EventHandler(this.bt_print_property_Click);
            this.label20.AutoSize = true;
            this.label20.Location = new Point(6, 20);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x2f, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "打印机:";
            this.cbx_printer_select.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.cbx_printer_select.FormattingEnabled = true;
            this.cbx_printer_select.Location = new Point(0x3b, 0x11);
            this.cbx_printer_select.Name = "cbx_printer_select";
            this.cbx_printer_select.Size = new Size(0x198, 20);
            this.cbx_printer_select.TabIndex = 0;
            this.cbx_printer_select.SelectedIndexChanged += new System.EventHandler(this.cbx_printer_select_SelectedIndexChanged);
            this.tp_Preview.Controls.Add(this.trackBar_zoom);
            this.tp_Preview.Controls.Add(this.lb_zoom_size);
            this.tp_Preview.Controls.Add(this.ts_preview_toolbar);
            this.tp_Preview.Controls.Add(this.previewer);
            this.tp_Preview.ImageIndex = 10;
            this.tp_Preview.Location = new Point(4, 0x17);
            this.tp_Preview.Name = "tp_Preview";
            this.tp_Preview.Padding = new Padding(3);
            this.tp_Preview.Size = new Size(0x2a5, 0x19e);
            this.tp_Preview.TabIndex = 6;
            this.tp_Preview.Text = "预览";
            this.tp_Preview.ToolTipText = "预览";
            this.tp_Preview.UseVisualStyleBackColor = true;
            this.trackBar_zoom.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.trackBar_zoom.AutoSize = false;
            this.trackBar_zoom.LargeChange = 1;
            this.trackBar_zoom.Location = new Point(0x192, 2);
            this.trackBar_zoom.Maximum = 120;
            this.trackBar_zoom.Minimum = 10;
            this.trackBar_zoom.Name = "trackBar_zoom";
            this.trackBar_zoom.Size = new Size(0xb5, 20);
            this.trackBar_zoom.TabIndex = 2;
            this.trackBar_zoom.TickStyle = TickStyle.None;
            this.trackBar_zoom.Value = 100;
            this.trackBar_zoom.Scroll += new System.EventHandler(this.trackBar_zoom_Scroll);
            this.lb_zoom_size.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.lb_zoom_size.BackColor = SystemColors.ButtonFace;
            this.lb_zoom_size.Location = new Point(580, -1);
            this.lb_zoom_size.Name = "lb_zoom_size";
            this.lb_zoom_size.Size = new Size(0x65, 0x18);
            this.lb_zoom_size.TabIndex = 3;
            this.lb_zoom_size.Text = "缩放比例:100%";
            this.lb_zoom_size.TextAlign = ContentAlignment.MiddleCenter;
            this.ts_preview_toolbar.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.ts_preview_toolbar.AutoSize = false;
            this.ts_preview_toolbar.BackColor = SystemColors.Control;
            this.ts_preview_toolbar.Dock = DockStyle.None;
            this.ts_preview_toolbar.GripStyle = ToolStripGripStyle.Hidden;
            this.ts_preview_toolbar.Items.AddRange(new ToolStripItem[] { this.toolStripButton_first, this.toolStrip_prior, this.toolStrip_next, this.toolStripButton_last, this.toolStripSeparator1, this.toolStripButton3, this.toolStripSeparator4, this.toolStripButton_1, this.toolStripButton_2, this.toolStripButton_3, this.toolStripSeparator5, this.toolStripButton_review, this.toolStripSeparator7, this.toolStripLabel_pages, this.toolStripSeparator3, this.toolStripLabel_XY });
            this.ts_preview_toolbar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ts_preview_toolbar.Location = new Point(0, 0);
            this.ts_preview_toolbar.Name = "ts_preview_toolbar";
            this.ts_preview_toolbar.RenderMode = ToolStripRenderMode.System;
            this.ts_preview_toolbar.Size = new Size(0x2a9, 0x19);
            this.ts_preview_toolbar.TabIndex = 1;
            this.ts_preview_toolbar.Text = "toolStrip1";
            this.toolStripButton_first.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_first.Image = (Image) resources.GetObject("toolStripButton_first.Image");
            this.toolStripButton_first.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_first.Name = "toolStripButton_first";
            this.toolStripButton_first.Size = new Size(0x17, 0x16);
            this.toolStripButton_first.Text = "第一页";
            this.toolStripButton_first.Click += new System.EventHandler(this.toolStripButton_first_Click);
            this.toolStrip_prior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStrip_prior.Image = (Image) resources.GetObject("toolStrip_prior.Image");
            this.toolStrip_prior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_prior.Name = "toolStrip_prior";
            this.toolStrip_prior.Size = new Size(0x17, 0x16);
            this.toolStrip_prior.Text = "前一页";
            this.toolStrip_prior.Click += new System.EventHandler(this.toolStrip_prior_Click);
            this.toolStrip_next.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStrip_next.Image = (Image) resources.GetObject("toolStrip_next.Image");
            this.toolStrip_next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_next.Name = "toolStrip_next";
            this.toolStrip_next.Size = new Size(0x17, 0x16);
            this.toolStrip_next.Text = "下一页";
            this.toolStrip_next.Click += new System.EventHandler(this.toolStrip_next_Click);
            this.toolStripButton_last.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_last.Image = (Image) resources.GetObject("toolStripButton_last.Image");
            this.toolStripButton_last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_last.Name = "toolStripButton_last";
            this.toolStripButton_last.Size = new Size(0x17, 0x16);
            this.toolStripButton_last.Text = "最后一页";
            this.toolStripButton_last.Click += new System.EventHandler(this.toolStripButton_last_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 0x19);
            this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.DropDownItems.AddRange(new ToolStripItem[] { this.toolStripMenuItem_300, this.toolStripMenuItem_200, this.toolStripMenuItem_150, this.toolStripMenuItem_125, this.toolStripSeparator2, this.toolStripMenuItem_100, this.toolStripSeparator6, this.toolStripMenuItem_75, this.toolStripMenuItem_50, this.toolStripMenuItem_25, this.toolStripMenuItem_10 });
            this.toolStripButton3.Image = (Image) resources.GetObject("toolStripButton3.Image");
            this.toolStripButton3.ImageTransparentColor = SystemColors.InactiveBorder;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(0x20, 0x16);
            this.toolStripButton3.Text = "缩放 100%";
            this.toolStripButton3.ButtonClick += new System.EventHandler(this.toolStripButton3_ButtonClick);
            this.toolStripMenuItem_300.Name = "toolStripMenuItem_300";
            this.toolStripMenuItem_300.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_300.Text = "300%";
            this.toolStripMenuItem_300.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_200.Name = "toolStripMenuItem_200";
            this.toolStripMenuItem_200.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_200.Text = "200%";
            this.toolStripMenuItem_200.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_150.Name = "toolStripMenuItem_150";
            this.toolStripMenuItem_150.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_150.Text = "150%";
            this.toolStripMenuItem_150.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_125.Name = "toolStripMenuItem_125";
            this.toolStripMenuItem_125.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_125.Text = "125%";
            this.toolStripMenuItem_125.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0x5b, 6);
            this.toolStripMenuItem_100.Name = "toolStripMenuItem_100";
            this.toolStripMenuItem_100.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_100.Text = "100%";
            this.toolStripMenuItem_100.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new Size(0x5b, 6);
            this.toolStripMenuItem_75.Name = "toolStripMenuItem_75";
            this.toolStripMenuItem_75.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_75.Text = "75%";
            this.toolStripMenuItem_75.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_50.Name = "toolStripMenuItem_50";
            this.toolStripMenuItem_50.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_50.Text = "50%";
            this.toolStripMenuItem_50.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_25.Name = "toolStripMenuItem_25";
            this.toolStripMenuItem_25.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_25.Text = "25%";
            this.toolStripMenuItem_25.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripMenuItem_10.Name = "toolStripMenuItem_10";
            this.toolStripMenuItem_10.Size = new Size(0x5e, 0x16);
            this.toolStripMenuItem_10.Text = "10%";
            this.toolStripMenuItem_10.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(6, 0x19);
            this.toolStripButton_1.Checked = true;
            this.toolStripButton_1.CheckOnClick = true;
            this.toolStripButton_1.CheckState = CheckState.Checked;
            this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_1.Image = (Image) resources.GetObject("toolStripButton_1.Image");
            this.toolStripButton_1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_1.Name = "toolStripButton_1";
            this.toolStripButton_1.Size = new Size(0x17, 0x16);
            this.toolStripButton_1.Text = "显示1页";
            this.toolStripButton_1.Click += new System.EventHandler(this.toolStripButton_1_Click);
            this.toolStripButton_2.CheckOnClick = true;
            this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_2.Image = (Image) resources.GetObject("toolStripButton_2.Image");
            this.toolStripButton_2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_2.Name = "toolStripButton_2";
            this.toolStripButton_2.Size = new Size(0x17, 0x16);
            this.toolStripButton_2.Text = "显示2页";
            this.toolStripButton_2.Click += new System.EventHandler(this.toolStripButton_2_Click);
            this.toolStripButton_3.CheckOnClick = true;
            this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_3.Image = (Image) resources.GetObject("toolStripButton_3.Image");
            this.toolStripButton_3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_3.Name = "toolStripButton_3";
            this.toolStripButton_3.Size = new Size(0x17, 0x16);
            this.toolStripButton_3.Text = "显示6页";
            this.toolStripButton_3.Click += new System.EventHandler(this.toolStripButton_3_Click);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(6, 0x19);
            this.toolStripButton_review.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_review.Image = (Image) resources.GetObject("toolStripButton_review.Image");
            this.toolStripButton_review.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_review.Name = "toolStripButton_review";
            this.toolStripButton_review.Size = new Size(0x17, 0x16);
            this.toolStripButton_review.Text = "重新预览(修改设置以后需重新预览)";
            this.toolStripButton_review.Click += new System.EventHandler(this.toolStripButton_review_Click);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new Size(6, 0x19);
            this.toolStripLabel_pages.Name = "toolStripLabel_pages";
            this.toolStripLabel_pages.Size = new Size(0x11, 0x16);
            this.toolStripLabel_pages.Text = "页";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(6, 0x19);
            this.toolStripLabel_XY.Name = "toolStripLabel_XY";
            this.toolStripLabel_XY.Size = new Size(0x23, 0x16);
            this.toolStripLabel_XY.Text = "(0,0)";
            this.toolStripLabel_XY.ToolTipText = "坐标";
            this.previewer.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.previewer.AutoZoom = false;
            this.previewer.Cursor = Cursors.SizeAll;
            this.previewer.Location = new Point(0, 0x19);
            this.previewer.Name = "previewer";
            this.previewer.Size = new Size(0x2a5, 0x182);
            this.previewer.TabIndex = 0;
            this.previewer.Zoom = 1.0;
            this.previewer.Click += new System.EventHandler(this.previewer_Click);
            this.previewer.MouseDown += new MouseEventHandler(this.previewer_MouseDown);
            this.previewer.MouseMove += new MouseEventHandler(this.previewer_MouseMove);
            this.previewer.MouseUp += new MouseEventHandler(this.previewer_MouseUp);
            this.label2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x1c6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xd7, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "请选择或新建一个方案以实现快速打印.";
            this.label17.BorderStyle = BorderStyle.FixedSingle;
            this.label17.Dock = DockStyle.Bottom;
            this.label17.Location = new Point(3, 0x4d);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x271, 0x2d);
            this.label17.TabIndex = 4;
            this.label17.Text = "页脚预览文本";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label18.BorderStyle = BorderStyle.FixedSingle;
            this.label18.Dock = DockStyle.Top;
            this.label18.Location = new Point(3, 0x11);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x271, 0x3e);
            this.label18.TabIndex = 3;
            this.label18.Text = "页眉预览文本";
            this.label18.TextAlign = ContentAlignment.BottomLeft;
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.FileName = "logo";
            this.openFileDialog1.Filter = "所有文件(*.*)|";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "请选择一张合适的图片作为要打印的LOGO";
            base.AcceptButton = this.bt_OK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.bt_Cancel;
            base.ClientSize = new Size(0x2b4, 0x1e6);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.tab_PrintSet);
            base.Controls.Add(this.bt_Apply);
            base.Controls.Add(this.bt_Cancel);
            base.Controls.Add(this.bt_OK);
            this.Cursor = Cursors.Default;
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            this.MinimumSize = new Size(700, 520);
            base.Name = "DataPrintSet";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DataGridView 打印专家(2.5.6) - Powered by Lucker";
            base.Load += new System.EventHandler(this.DataPrintSet_Load);
            this.tab_PrintSet.ResumeLayout(false);
            this.tp_General.ResumeLayout(false);
            this.tp_General.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tp_Data.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gb_columnsToPrint.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gboxRowsToPrint.ResumeLayout(false);
            this.gboxRowsToPrint.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.splitContainer_dgv.Panel1.ResumeLayout(false);
            this.splitContainer_dgv.Panel2.ResumeLayout(false);
            this.splitContainer_dgv.ResumeLayout(false);
            this.gb_dgv.ResumeLayout(false);
            this.gb_dgv.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tp_Titles.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((ISupportInitialize) this.pictureBox_logo).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.gb_Title_sub.ResumeLayout(false);
            this.gb_Title_sub.PerformLayout();
            this.gb_Title_main.ResumeLayout(false);
            this.gb_Title_main.PerformLayout();
            this.tp_HeaderFooter.ResumeLayout(false);
            this.gb_pages.ResumeLayout(false);
            this.gb_pages.PerformLayout();
            this.gb_footer.ResumeLayout(false);
            this.gb_footer.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.gb_header.ResumeLayout(false);
            this.gb_header.PerformLayout();
            this.tp_Others.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gb_others.ResumeLayout(false);
            this.gb_others.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tb_PrintPage.ResumeLayout(false);
            this.gb_scope.ResumeLayout(false);
            this.gb_scope.PerformLayout();
            this.gb_page.ResumeLayout(false);
            this.gb_page.PerformLayout();
            ((ISupportInitialize) this.pb_orientation_long).EndInit();
            ((ISupportInitialize) this.pb_orientation_landscape).EndInit();
            ((ISupportInitialize) this.pb_paging123123).EndInit();
            ((ISupportInitialize) this.pb_paging112233).EndInit();
            this.num_copys.EndInit();
            this.gb_print.ResumeLayout(false);
            this.gb_print.PerformLayout();
            this.tp_Preview.ResumeLayout(false);
            this.trackBar_zoom.EndInit();
            this.ts_preview_toolbar.ResumeLayout(false);
            this.ts_preview_toolbar.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        internal void InitPrinter()
        {
            string defaultProjectName;
            this.SetColumnsList(this.GetColumnsName(this.DGV));
            this.SelectedColumns = this.GetSelectedColumns();
            if (this._IsDeepCopy)
            {
                this.label_msg.Visible = false;
                this.SetDataGridViewPropertys(this.DGV);
            }
            else
                this.label_msg.Visible = true;
            string[] items = XMLConfigure.ReadNodes(this.file, "打印项目模板");
            if (items.Length == 0)
                this.project_list.Items.Add("默认方案");
            else
                this.project_list.Items.AddRange(items);
            if (string.IsNullOrEmpty(this.DefaultProjectName))
                defaultProjectName = XMLConfigure.ReadNode(this.file, "打印项目模板/DefaultProject", "默认方案");
            else
                defaultProjectName = this.DefaultProjectName;
            int index = this.project_list.Items.IndexOf(defaultProjectName);
            if (index < 0)
            {
                MessageBox.Show("指定的项目模板名为不存在:" + defaultProjectName + "\r\n将使用默认方案名.", this.Text);
                index = 0;
            }
            this.project_list.SetSelected(index, true);
            if (this.DefaultTabPage == 6) this.OnFirstPreview();
        }

        internal void LoadProject(string ProjectName)
        {
            if (!this.project_list.Items.Contains(ProjectName))
                MessageBox.Show("方案名[" + ProjectName + "]不存在!", this.Text);
            else
            {
                this.TitleMain.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Enable", "true", true, RegistryValueKind.String));
                this.TitleMain.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Text", "主标题", true, RegistryValueKind.String);
                this.TitleMain.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.FontItem", this.SerializeBinary(new Font("宋体", 18f)), true, RegistryValueKind.Binary));
                this.TitleMain.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.TitleMain.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Halign", this.SerializeBinary(StringAlignment.Center), true, RegistryValueKind.Binary));
                this.TitleMain.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Valign", this.SerializeBinary(StringAlignment.Center), true, RegistryValueKind.Binary));
                this.TitleSub.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Enable", "false", true, RegistryValueKind.String));
                this.TitleSub.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Text", "副标题", true, RegistryValueKind.String);
                this.TitleSub.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.FontItem", this.SerializeBinary(new Font("宋体", 10f)), true, RegistryValueKind.Binary));
                this.TitleSub.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.TitleSub.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Halign", this.SerializeBinary(StringAlignment.Center), true, RegistryValueKind.Binary));
                this.TitleSub.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Valign", this.SerializeBinary(StringAlignment.Center), true, RegistryValueKind.Binary));
                this.Logo.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Enable", "false", true, RegistryValueKind.String));
                this.Logo.FilePath = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.FilePath", Application.StartupPath + @"\logo.jpg", true, RegistryValueKind.String);
                this.Logo.Location = (Point) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Location", this.SerializeBinary(new Point(0, 0)), true, RegistryValueKind.Binary));
                this.Logo.ImageSize = (Size) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Size", this.SerializeBinary(new Size(0, 0)), true, RegistryValueKind.Binary));
                this.Header.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Enable", "false", true, RegistryValueKind.String));
                this.Header.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Text", "页眉文本", true, RegistryValueKind.String);
                this.Header.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.FontItem", this.SerializeBinary(new Font("宋体", 9f)), true, RegistryValueKind.Binary));
                this.Header.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.Header.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Halign", this.SerializeBinary(StringAlignment.Far), true, RegistryValueKind.Binary));
                this.Header.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Valign", this.SerializeBinary(StringAlignment.Near), true, RegistryValueKind.Binary));
                this.Footer.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Enable", "false", true, RegistryValueKind.String));
                this.Footer.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Text", "页脚文本", true, RegistryValueKind.String);
                this.Footer.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.FontItem", this.SerializeBinary(new Font("宋体", 9f)), true, RegistryValueKind.Binary));
                this.Footer.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.Footer.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Halign", this.SerializeBinary(StringAlignment.Near), true, RegistryValueKind.Binary));
                this.Footer.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Valign", this.SerializeBinary(StringAlignment.Far), true, RegistryValueKind.Binary));
                this.Page.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Enable", "true", true, RegistryValueKind.String));
                this.Page.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Text", "第 {0} 页,共 {1} 页", true, RegistryValueKind.String);
                this.Page.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.FontItem", this.SerializeBinary(new Font("宋体", 9f)), true, RegistryValueKind.Binary));
                this.Page.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.Page.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Halign", this.SerializeBinary(StringAlignment.Far), true, RegistryValueKind.Binary));
                this.Page.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Valign", this.SerializeBinary(StringAlignment.Far), true, RegistryValueKind.Binary));
                this.Page.ShowOnHeader = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.ShowOnHeader", "true", true, RegistryValueKind.String));
                this.Others.PrinterEnable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.PrinterEnable", "true", true, RegistryValueKind.String));
                this.Others.DateTimeEnable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeEnable", "true", true, RegistryValueKind.String));
                this.Others.CopysEnable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.CopysEnable", "false", true, RegistryValueKind.String));
                this.Others.AutoPrinter = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.AutoPrinter", "false", true, RegistryValueKind.String));
                this.Others.AutoDateTime = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.AutoDateTime", "true", true, RegistryValueKind.String));
                this.Others.PrinterText = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.PrinterText", "用户", true, RegistryValueKind.String);
                this.Others.DateTimeText = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeText", "2000-01-01 01:01:01", true, RegistryValueKind.String);
                this.Others.DateTimeFormat = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeFormat", "Date and Time", true, RegistryValueKind.String);
                this.Others.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.FontItem", this.SerializeBinary(new Font("宋体", 9f)), true, RegistryValueKind.Binary));
                this.Others.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.Others.Halign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Halign", this.SerializeBinary(StringAlignment.Center), true, RegistryValueKind.Binary));
                this.Others.Valign = (StringAlignment) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Valign", this.SerializeBinary(StringAlignment.Far), true, RegistryValueKind.Binary));
                this.layout_style = Convert.ToInt32(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Layout", 0, true, RegistryValueKind.String));
                this.Watermark.Enable = Convert.ToBoolean(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Enable", "false", true, RegistryValueKind.String));
                this.Watermark.Text = (string) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Text", "水印文本", true, RegistryValueKind.String);
                this.Watermark.FontItem = (Font) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.FontItem", this.SerializeBinary(new Font("宋体", 28f)), true, RegistryValueKind.Binary));
                this.Watermark.TextColor = (System.Drawing.Color) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.TextColor", this.SerializeBinary(System.Drawing.Color.Black), true, RegistryValueKind.Binary));
                this.Watermark.Location = (Point) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Location", this.SerializeBinary(new Point(0, 0)), true, RegistryValueKind.Binary));
                this.Watermark.Angle = Convert.ToInt32(this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Angle", "0", true, RegistryValueKind.String));
                this.PageSet = (PageSettings) this.DeserializeBinary((byte[]) this.reg.ReadReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "PageSet", this.SerializeBinary(this.PageSet), true, RegistryValueKind.Binary));
                if (this.PageSet.Margins.Top == this.PageSet.Margins.Bottom && this.PageSet.Margins.Left == this.PageSet.Margins.Right && this.PageSet.Margins.Right == 100 && this.PageSet.Margins.Top == 100) this.PageSet.Margins.Top = this.PageSet.Margins.Bottom = this.PageSet.Margins.Left = this.PageSet.Margins.Right = 20;
            }
        }

        internal void LoadProjectXML(string ProjectName)
        {
            if (!this.project_list.Items.Contains(ProjectName))
                MessageBox.Show("方案名[" + ProjectName + "]不存在!", this.Text);
            else
            {
                string str = "打印项目模板/" + ProjectName + "/";
                this.TitleMain.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "TitleMain.Enable", "true"));
                this.TitleMain.Text = XMLConfigure.ReadNode(this.file, str + "TitleMain.Text", "主标题");
                this.TitleMain.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "TitleMain.FontItem", new Font("宋体", 18f));
                this.TitleMain.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "TitleMain.TextColor", System.Drawing.Color.Black);
                this.TitleMain.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "TitleMain.Halign", StringAlignment.Center);
                this.TitleMain.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "TitleMain.Valign", StringAlignment.Center);
                this.TitleSub.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "TitleSub.Enable", "true"));
                this.TitleSub.Text = XMLConfigure.ReadNode(this.file, str + "TitleSub.Text", "副标题");
                this.TitleSub.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "TitleSub.FontItem", new Font("宋体", 10f));
                this.TitleSub.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "TitleSub.TextColor", System.Drawing.Color.Black);
                this.TitleSub.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "TitleSub.Halign", StringAlignment.Center);
                this.TitleSub.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "TitleSub.Valign", StringAlignment.Center);
                this.Logo.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Logo.Enable", "false"));
                this.Logo.FilePath = XMLConfigure.ReadNode(this.file, str + "Logo.FilePath", Application.StartupPath + @"\logo.jpg");
                this.Logo.Location = (Point) XMLConfigure.ReadNode(this.file, str + "Logo.Location", new Point(0, 0));
                this.Logo.ImageSize = (Size) XMLConfigure.ReadNode(this.file, str + "Logo.Size", new Size(0, 0));
                this.Header.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Header.Enable", "false"));
                this.Header.Text = XMLConfigure.ReadNode(this.file, str + "Header.Text", "页眉文本");
                this.Header.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "Header.FontItem", new Font("宋体", 9f));
                this.Header.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "Header.TextColor", System.Drawing.Color.Black);
                this.Header.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Header.Halign", StringAlignment.Far);
                this.Header.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Header.Valign", StringAlignment.Near);
                this.Footer.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Footer.Enable", "false"));
                this.Footer.Text = XMLConfigure.ReadNode(this.file, str + "Footer.Text", "页脚文本");
                this.Footer.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "Footer.FontItem", new Font("宋体", 9f));
                this.Footer.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "Footer.TextColor", System.Drawing.Color.Black);
                this.Footer.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Footer.Halign", StringAlignment.Near);
                this.Footer.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Footer.Valign", StringAlignment.Far);
                this.Page.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Page.Enable", "true"));
                this.Page.Text = XMLConfigure.ReadNode(this.file, str + "Page.Text", "第 {0} 页,共 {1} 页");
                this.Page.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "Page.FontItem", new Font("宋体", 9f));
                this.Page.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "Page.TextColor", System.Drawing.Color.Black);
                this.Page.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Page.Halign", StringAlignment.Far);
                this.Page.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Page.Valign", StringAlignment.Far);
                this.Page.ShowOnHeader = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Page.ShowOnHeader", "true"));
                this.Others.PrinterEnable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Others.PrinterEnable", "true"));
                this.Others.DateTimeEnable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Others.DateTimeEnable", "true"));
                this.Others.CopysEnable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Others.CopysEnable", "false"));
                this.Others.AutoPrinter = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Others.AutoPrinter", "false"));
                this.Others.AutoDateTime = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Others.AutoDateTime", "true"));
                this.Others.PrinterText = XMLConfigure.ReadNode(this.file, str + "Others.PrinterText", "用户");
                this.Others.DateTimeText = XMLConfigure.ReadNode(this.file, str + "Others.DateTimeText", "2000-01-01 01:01:01");
                this.Others.DateTimeFormat = XMLConfigure.ReadNode(this.file, str + "Others.DateTimeFormat", "Date and Time");
                this.Others.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "Others.FontItem", new Font("宋体", 9f));
                this.Others.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "Others.TextColor", System.Drawing.Color.Black);
                this.Others.Halign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Others.Halign", StringAlignment.Center);
                this.Others.Valign = (StringAlignment) XMLConfigure.ReadNode(this.file, str + "Others.Valign", StringAlignment.Far);
                this.layout_style = Convert.ToInt32(XMLConfigure.ReadNode(this.file, str + "Others.Layout", 0));
                this.Watermark.Enable = Convert.ToBoolean(XMLConfigure.ReadNode(this.file, str + "Watermark.Enable", "false"));
                this.Watermark.Text = XMLConfigure.ReadNode(this.file, str + "Watermark.Text", "水印文本");
                this.Watermark.FontItem = (Font) XMLConfigure.ReadNode(this.file, str + "Watermark.FontItem", new Font("宋体", 28f));
                this.Watermark.TextColor = (System.Drawing.Color) XMLConfigure.ReadNode(this.file, str + "Watermark.TextColor", System.Drawing.Color.Black);
                this.Watermark.Location = (Point) XMLConfigure.ReadNode(this.file, str + "Watermark.Location", new Point(0, 0));
                this.Watermark.Angle = Convert.ToInt32(XMLConfigure.ReadNode(this.file, str + "Watermark.Angle", "0"));
                this.PageSet = (PageSettings) XMLConfigure.ReadNode(this.file, str + "PageSet", this.PageSet);
                if (this.PageSet.Margins.Top == this.PageSet.Margins.Bottom && this.PageSet.Margins.Left == this.PageSet.Margins.Right && this.PageSet.Margins.Right == 100 && this.PageSet.Margins.Top == 100) this.PageSet.Margins.Top = this.PageSet.Margins.Bottom = this.PageSet.Margins.Left = this.PageSet.Margins.Right = 20;
            }
        }

        private void logo_height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Logo.ImageSize.Height = int.Parse(this.logo_height.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void logo_w_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Logo.ImageSize.Width = int.Parse(this.logo_width.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void logo_X_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Logo.Location.X = int.Parse(this.logo_X.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void logo_Y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Logo.Location.Y = int.Parse(this.logo_Y.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void num_copys_ValueChanged(object sender, EventArgs e) { this.PageSet.PrinterSettings.Copies = (short) this.num_copys.Value; }

        private void OnFirstPreview()
        {
            if (this.IsFirstTimePreview)
            {
                try
                {
                    EntLib.Controls.DataPrinter.DataPrinter.TotalPages = this.GetPageCount();
                    EntLib.Controls.DataPrinter.DataPrinter.PageNumber = 0;
                    if (this.PD != null) this.PD.Dispose();
                    this.PD = new PrintDocument();
                    this.PD.DefaultPageSettings = this.PageSet;
                    this.PD.PrintPage += new PrintPageEventHandler(this.PD_PrintPage);
                    this.PD.EndPrint += new PrintEventHandler(this.PD_EndPrint);
                    this.PD.DocumentName = EntLib.Controls.DataPrinter.DataPrinter.TotalPages.ToString();
                    this.MyDataPrinter = new EntLib.Controls.DataPrinter.DataPrinter(this.DGV, this.PD, this.Statistic, this.Watermark, this.Logo, this.TitleMain, this.TitleSub, this.Header, this.Footer, this.Page, this.Others, this.PageSet, this._printUser, this.SelectedColumns, this.PrintRows, this.layout_style, 1);
                    this.previewer.Document = this.PD;
                    this.IsFirstTimePreview = false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("打印出错,请检查打印机!\r\n" + exception.Message, "Alarm");
                }
            }
        }

        [DllImport("winspool.drv", SetLastError=true)]
        public static extern int OpenPrinter(string pPrinterName, ref IntPtr hPrinter, ref IntPtr pDefault);
        private void PD_EndPrint(object sender, PrintEventArgs e)
        {
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,总 ", EntLib.Controls.DataPrinter.DataPrinter.PageNumber.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
            this.page_count = EntLib.Controls.DataPrinter.DataPrinter.PageNumber;
            EntLib.Controls.DataPrinter.DataPrinter.PageNumber = 0;
        }

        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            Thread.Sleep(100);
            if (this.MyDataPrinter == null) throw new Exception("DataPrinter 尚未实例化!");
            bool flag = this.MyDataPrinter.DrawDataGridView(e);
            e.HasMorePages = flag;
        }

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, int nBar, int wParam, int lParam);
        private void previewer_Click(object sender, EventArgs e) { this.trackBar_zoom.Focus(); }

        private void previewer_MouseDown(object sender, MouseEventArgs e)
        {
            this.Preview_move = true;
            this.MoveStart = e.Location;
        }

        private void previewer_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolStripLabel_XY.Text = string.Format("({0},{1})mm", Math.Round((double) (((float) e.X) / 3.94f), 0), Math.Round((double) (((double) e.Y) / 3.94), 0));
            if (this.Preview_move)
            {
                int num;
                int num2;
                int num3;
                int num4;
                this.MoveEnd = e.Location;
                int num5 = -(this.MoveEnd.X - this.MoveStart.X);
                int num6 = -(this.MoveEnd.Y - this.MoveStart.Y);
                this.MoveStart = e.Location;
                GetScrollRange(this.previewer.Handle, 0, out num, out num2);
                GetScrollRange(this.previewer.Handle, 1, out num3, out num4);
                int scrollPos = GetScrollPos(this.previewer.Handle, 0);
                int num8 = GetScrollPos(this.previewer.Handle, 1);
                num2 -= this.previewer.ClientSize.Width;
                num4 -= this.previewer.ClientSize.Height;
                int nPos = scrollPos + num5;
                if (nPos >= num && nPos <= num2)
                {
                    SetScrollPos(this.previewer.Handle, 0, nPos, true);
                    PostMessage(this.previewer.Handle, 0x114, 4 + 0x10000 * nPos, 0);
                }
                int num10 = num8 + num6;
                if (num10 >= num3 && num10 <= num4)
                {
                    SetScrollPos(this.previewer.Handle, 1, num10, true);
                    PostMessage(this.previewer.Handle, 0x115, 4 + 0x10000 * num10, 0);
                }
            }
        }

        private void previewer_MouseUp(object sender, MouseEventArgs e) { this.Preview_move = false; }

        private void print_scope_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton) sender;
            switch (button.Text)
            {
                case "所有页":
                    this.PageSet.PrinterSettings.PrintRange = PrintRange.AllPages;
                    return;

                case "范围":
                    this.PageSet.PrinterSettings.PrintRange = PrintRange.SomePages;
                    this.tb_scope_from.Enabled = this.rb_scope.Checked;
                    this.tb_scope_from.Text = "1";
                    this.tb_scope_to.Enabled = this.rb_scope.Checked;
                    if (this.tb_scope_to.Enabled) this.tb_scope_to.Text = this.GetPageCount().ToString();
                    this.tb_scope_from.Focus();
                    return;

                case "选择的页":
                    this.PageSet.PrinterSettings.PrintRange = PrintRange.Selection;
                    return;

                case "当前页":
                    this.PageSet.PrinterSettings.PrintRange = PrintRange.CurrentPage;
                    return;
            }
            this.PageSet.PrinterSettings.PrintRange = PrintRange.AllPages;
        }

        [DllImport("winspool.drv")]
        public static extern int PrinterProperties(IntPtr hwnd, IntPtr hPrinter);
        private void project_list_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.project_list.SelectedItem != null)
            {
                new Dictionary<string, object>();
                this.tb_project_name.Text = this.project_list.SelectedItem.ToString();
                this.project_detail_list.Items.Clear();
                this.LoadProjectXML(this.tb_project_name.Text);
                this.DisplayProject();
                foreach (KeyValuePair<string, object> pair in this.GetProjectDetail())
                {
                    this.project_detail_list.Items.Add(string.Format("{0}: {1}", pair.Key, pair.Value.ToString()));
                }
            }
        }

        private void rb_orientation_landscape_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_orientation_landscape.Checked)
            {
                this.pb_orientation_landscape.BringToFront();
                this.PageSet.Landscape = true;
            }
        }

        private void rb_orientation_long_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_orientation_long.Checked)
            {
                this.pb_orientation_long.BringToFront();
                this.PageSet.Landscape = false;
            }
        }

        private void rb_show_on_header_CheckedChanged(object sender, EventArgs e) { this.Page.ShowOnHeader = this.rb_show_on_header.Checked; }

        private void rdo_layout_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdo_layout_0.Checked)
                this.layout_style = 0;
            else if (this.rdo_layout_1.Checked)
                this.layout_style = 1;
            else if (this.rdo_layout_2.Checked)
            {
                if (this.checkBox_fixwidt.Checked)
                {
                    MessageBox.Show("采用[固定列宽]模式时,不能同时选择[自动适合页宽]模式,系统将自动设置为[默认]布局方式.", "提示");
                    this.rdo_layout_0.Checked = true;
                }
                else
                    this.layout_style = 2;
            }
            if (this.checkBox_fixwidt.Checked)
                this.layout_style += 10;
            else
                this.layout_style = this.layout_style % 10;
        }

        private void rdoAllRows_CheckedChanged(object sender, EventArgs e) { this.PrintRows = this.rdoAllRows.Checked ? 0 : 1; }

        private bool SaveProject(string ProjectName)
        {
            try
            {
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Enable", this.TitleMain.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Text", this.TitleMain.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.FontItem", this.SerializeBinary(this.TitleMain.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.TextColor", this.SerializeBinary(this.TitleMain.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Halign", this.SerializeBinary(this.TitleMain.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleMain.Valign", this.SerializeBinary(this.TitleMain.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Enable", this.TitleSub.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Text", this.TitleSub.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.FontItem", this.SerializeBinary(this.TitleSub.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.TextColor", this.SerializeBinary(this.TitleSub.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Halign", this.SerializeBinary(this.TitleSub.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "TitleSub.Valign", this.SerializeBinary(this.TitleSub.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Enable", this.Logo.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.FilePath", this.Logo.FilePath, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Location", this.SerializeBinary(this.Logo.Location), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Logo.Size", this.SerializeBinary(this.Logo.ImageSize), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Enable", this.Header.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Text", this.Header.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.FontItem", this.SerializeBinary(this.Header.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.TextColor", this.SerializeBinary(this.Header.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Halign", this.SerializeBinary(this.Header.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Header.Valign", this.SerializeBinary(this.Header.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Enable", this.Footer.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Text", this.Footer.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.FontItem", this.SerializeBinary(this.Footer.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.TextColor", this.SerializeBinary(this.Footer.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Halign", this.SerializeBinary(this.Footer.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Footer.Valign", this.SerializeBinary(this.Footer.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Enable", this.Page.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Text", this.Page.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.FontItem", this.SerializeBinary(this.Page.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.TextColor", this.SerializeBinary(this.Page.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Halign", this.SerializeBinary(this.Page.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.Valign", this.SerializeBinary(this.Page.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Page.ShowOnHeader", this.Page.ShowOnHeader.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.AutoDateTime", this.Others.AutoDateTime.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.AutoPrinter", this.Others.AutoPrinter.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.PrinterEnable", this.Others.PrinterEnable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeEnablee", this.Others.DateTimeEnable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.CopysEnable", this.Others.CopysEnable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeFormat", this.Others.DateTimeFormat, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.DateTimeText", this.Others.DateTimeText, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.PrinterText", this.Others.PrinterText, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.FontItem", this.SerializeBinary(this.Others.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.TextColor", this.SerializeBinary(this.Others.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Halign", this.SerializeBinary(this.Others.Halign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Valign", this.SerializeBinary(this.Others.Valign), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Others.Layout", this.layout_style, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Enable", this.Watermark.Enable.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Text", this.Watermark.Text, RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.FontItem", this.SerializeBinary(this.Watermark.FontItem), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.TextColor", this.SerializeBinary(this.Watermark.TextColor), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.FontItem", this.SerializeBinary(this.Watermark.Location), RegistryValueKind.Binary);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "Watermark.Angle", this.Watermark.Angle.ToString(), RegistryValueKind.String);
                this.reg.WriteReg(@"Software\LuckerSoft\DataPrinter\Projects\" + ProjectName, "PageSet", this.SerializeBinary(this.PageSet), RegistryValueKind.Binary);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool SaveProjectXML(string ProjectName)
        {
            string str = "打印项目模板/" + ProjectName + "/";
            try
            {
                XMLConfigure.WriteNode(this.file, str + "TitleMain.Enable", this.TitleMain.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "TitleMain.Text", this.TitleMain.Text);
                XMLConfigure.WriteNode(this.file, str + "TitleMain.FontItem", this.TitleMain.FontItem);
                XMLConfigure.WriteNode(this.file, str + "TitleMain.TextColor", this.TitleMain.TextColor);
                XMLConfigure.WriteNode(this.file, str + "TitleMain.Halign", this.TitleMain.Halign);
                XMLConfigure.WriteNode(this.file, str + "TitleMain.Valign", this.TitleMain.Valign);
                XMLConfigure.WriteNode(this.file, str + "TitleSub.Enable", this.TitleSub.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "TitleSub.Text", this.TitleSub.Text);
                XMLConfigure.WriteNode(this.file, str + "TitleSub.FontItem", this.TitleSub.FontItem);
                XMLConfigure.WriteNode(this.file, str + "TitleSub.TextColor", this.TitleSub.TextColor);
                XMLConfigure.WriteNode(this.file, str + "TitleSub.Halign", this.TitleSub.Halign);
                XMLConfigure.WriteNode(this.file, str + "TitleSub.Valign", this.TitleSub.Valign);
                XMLConfigure.WriteNode(this.file, str + "Logo.Enable", this.Logo.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Logo.FilePath", this.Logo.FilePath);
                XMLConfigure.WriteNode(this.file, str + "Logo.Location", this.Logo.Location);
                XMLConfigure.WriteNode(this.file, str + "Logo.Size", this.Logo.ImageSize);
                XMLConfigure.WriteNode(this.file, str + "Header.Enable", this.Header.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Header.Text", this.Header.Text);
                XMLConfigure.WriteNode(this.file, str + "Header.FontItem", this.Header.FontItem);
                XMLConfigure.WriteNode(this.file, str + "Header.TextColor", this.Header.TextColor);
                XMLConfigure.WriteNode(this.file, str + "Header.Halign", this.Header.Halign);
                XMLConfigure.WriteNode(this.file, str + "Header.Valign", this.Header.Valign);
                XMLConfigure.WriteNode(this.file, str + "Footer.Enable", this.Footer.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Footer.Text", this.Footer.Text);
                XMLConfigure.WriteNode(this.file, str + "Footer.FontItem", this.Footer.FontItem);
                XMLConfigure.WriteNode(this.file, str + "Footer.TextColor", this.Footer.TextColor);
                XMLConfigure.WriteNode(this.file, str + "Footer.Halign", this.Footer.Halign);
                XMLConfigure.WriteNode(this.file, str + "Footer.Valign", this.Footer.Valign);
                XMLConfigure.WriteNode(this.file, str + "Page.Enable", this.Page.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Page.Text", this.Page.Text);
                XMLConfigure.WriteNode(this.file, str + "Page.FontItem", this.Page.FontItem);
                XMLConfigure.WriteNode(this.file, str + "Page.TextColor", this.Page.TextColor);
                XMLConfigure.WriteNode(this.file, str + "Page.Halign", this.Page.Halign);
                XMLConfigure.WriteNode(this.file, str + "Page.Valign", this.Page.Valign);
                XMLConfigure.WriteNode(this.file, str + "Page.ShowOnHeader", this.Page.ShowOnHeader.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.AutoDateTime", this.Others.AutoDateTime.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.AutoPrinter", this.Others.AutoPrinter.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.PrinterEnable", this.Others.PrinterEnable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.DateTimeEnable", this.Others.DateTimeEnable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.CopysEnable", this.Others.CopysEnable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Others.DateTimeFormat", this.Others.DateTimeFormat);
                XMLConfigure.WriteNode(this.file, str + "Others.DateTimeText", this.Others.DateTimeText);
                XMLConfigure.WriteNode(this.file, str + "Others.PrinterText", this.Others.PrinterText);
                XMLConfigure.WriteNode(this.file, str + "Others.FontItem", this.Others.FontItem);
                XMLConfigure.WriteNode(this.file, str + "Others.TextColor", this.Others.TextColor);
                XMLConfigure.WriteNode(this.file, str + "Others.Halign", this.Others.Halign);
                XMLConfigure.WriteNode(this.file, str + "Others.Valign", this.Others.Valign);
                XMLConfigure.WriteNode(this.file, str + "Others.Layout", this.layout_style);
                XMLConfigure.WriteNode(this.file, str + "Watermark.Enable", this.Watermark.Enable.ToString());
                XMLConfigure.WriteNode(this.file, str + "Watermark.Text", this.Watermark.Text);
                XMLConfigure.WriteNode(this.file, str + "Watermark.FontItem", this.Watermark.FontItem);
                XMLConfigure.WriteNode(this.file, str + "Watermark.TextColor", this.Watermark.TextColor);
                XMLConfigure.WriteNode(this.file, str + "Watermark.Location", this.Watermark.Location);
                XMLConfigure.WriteNode(this.file, str + "Watermark.Angle", this.Watermark.Angle.ToString());
                XMLConfigure.WriteNode(this.file, str + "PageSet", this.PageSet);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public byte[] SerializeBinary(object request)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, request);
            return serializationStream.GetBuffer();
        }

        private void SetColumnsList(List<string> availableFields)
        {
            foreach (string str in availableFields)
            {
                this.ColumnsList.Items.Add(str, true);
            }
            this.cbx_statistic_column1.Items.AddRange(availableFields.ToArray());
            this.cbx_statistic_column2.Items.AddRange(availableFields.ToArray());
        }

        private void SetDataGridViewPropertys(DataGridView dgv)
        {
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BorderStyle = BorderStyle.Fixed3D;
            this.DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = DockStyle.Fill;
            this.DGV.RowHeadersWidth = 0x19;
            this.DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.RowTemplate.Height = 0x17;
            this.DGV.AllowUserToAddRows = false;
            this.DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private string SetDateTimeFormat()
        {
            string str;
            DateTime now = this.dateTimePicker.Value;
            if (this.cbx_auto_datetime.Checked) now = DateTime.Now;
            string text = this.cbx_datetime_format.Text;
            string str3 = text;
            switch (str3)
            {
                case null:
                    break;

                case "yyyy-MM-dd hh:mm:ss":
                    str = string.Format("{0:yyyy-MM-dd hh:mm:ss}", now);
                    goto Label_00A1;

                default:
                    if (str3 == "yyyy-MM-dd")
                        str = string.Format("{0:yyyy-MM-dd}", now);
                    else
                    {
                        if (!(str3 == "hh:mm:ss")) break;
                        str = string.Format("{0:hh:mm:ss}", now);
                    }
                    goto Label_00A1;
            }
            str = string.Format("{0:yyyy-MM-dd hh:mm:ss}", now);
        Label_00A1:
            this.Others.DateTimeFormat = this.dateTimePicker.CustomFormat = text;
            return str;
        }

        private void SetOthersPreview()
        {
            string text;
            this.cbx_others_Halign.Enabled = this.cbx_others_Valign.Enabled = this.bt_others_font.Enabled = this.cbx_printer.Checked || this.cbx_datetime.Checked || this.cbx_copys.Checked;
            if (this.cbx_auto_printer.Checked)
                text = this._printUser;
            else
                text = this.tb_printer.Text;
            this.Others.DateTimeText = this.SetDateTimeFormat();
            this.lb_others_preview.Text = string.Format(this.printer + "  " + this.datetime + "  " + this.copys, text, this.Others.DateTimeText, 1).Trim();
        }

        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hwnd, int nBar, int nPos, bool bRedraw);
        private void tab_PrintSet_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case null:
                    return;

                case "tp_General":
                    new Dictionary<string, object>();
                    this.project_detail_list.Items.Clear();
                    foreach (KeyValuePair<string, object> pair in this.GetProjectDetail())
                    {
                        this.project_detail_list.Items.Add(string.Format("{0}: {1}", pair.Key, pair.Value.ToString()));
                    }
                    return;

                case "tb_PrintPage":
                    if (this.cbx_printer_select.Items.Count == 0)
                    {
                        string printerName = this.PageSet.PrinterSettings.PrinterName;
                        this.cbx_printer_select.Text = printerName;
                        foreach (string str2 in PrinterSettings.InstalledPrinters)
                        {
                            this.cbx_printer_select.Items.Add(str2);
                        }
                    }
                    if (this.cbx_page_size.Items.Count == 0)
                    {
                        foreach (PaperSize size in this.PageSet.PrinterSettings.PaperSizes)
                        {
                            if (size.PaperName.Length > 0) this.cbx_page_size.Items.Add(size.PaperName);
                        }
                        if (this.cbx_page_size.Items.Count > 0) this.cbx_page_size.Text = this.PageSet.PaperSize.PaperName;
                    }
                    if (this.cbx_paper_from.Items.Count == 0)
                    {
                        foreach (PaperSource source in this.PageSet.PrinterSettings.PaperSources)
                        {
                            this.cbx_paper_from.Items.Add(source.SourceName);
                        }
                        if (this.cbx_paper_from.Items.Count > 0) this.cbx_paper_from.Text = this.cbx_paper_from.Items[0].ToString();
                    }
                    return;

                case "tp_Preview":
                    this.OnFirstPreview();
                    break;
            }
        }

        private void tb_button_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.Margins.Bottom = Convert.ToInt32(this.tb_button.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_button.Text = "20";
                this.PageSet.Margins.Bottom = 20;
            }
        }

        private void tb_footer_text_TextChanged(object sender, EventArgs e)
        {
            this.lb_footer_preview.Text = this.tb_footer_text.Text;
            this.Footer.Text = this.tb_footer_text.Text;
        }

        private void tb_header_text_TextChanged(object sender, EventArgs e)
        {
            this.lb_header_preview.Text = this.tb_header_text.Text;
            this.Header.Text = this.tb_header_text.Text;
        }

        private void tb_left_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.Margins.Left = Convert.ToInt32(this.tb_left.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_left.Text = "20";
                this.PageSet.Margins.Left = 20;
            }
        }

        private void tb_logopath_TextChanged(object sender, EventArgs e)
        {
            this.Logo.FilePath = this.tb_logopath.Text;
            try
            {
                this.pictureBox_logo.Image = Image.FromFile(this.tb_logopath.Text);
            }
            catch
            {
            }
        }

        private void tb_page_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.Page.FontItem;
            dialog.Color = this.Page.TextColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Page.FontItem = dialog.Font;
                this.Page.TextColor = dialog.Color;
            }
        }

        private void tb_page_text_TextChanged(object sender, EventArgs e) { this.Page.Text = this.tb_page_text.Text; }

        private void tb_printer_TextChanged(object sender, EventArgs e)
        {
            this.Others.PrinterText = this.tb_printer.Text;
            this.SetOthersPreview();
        }

        private void tb_right_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.Margins.Right = Convert.ToInt32(this.tb_right.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_right.Text = "20";
                this.PageSet.Margins.Right = 20;
            }
        }

        private void tb_scope_from_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.PrinterSettings.FromPage = Convert.ToInt32(this.tb_scope_from.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_scope_from.Text = "1";
                this.PageSet.PrinterSettings.FromPage = 1;
            }
        }

        private void tb_scope_to_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.PrinterSettings.ToPage = Convert.ToInt32(this.tb_scope_to.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_scope_to.Text = "1";
                this.PageSet.PrinterSettings.ToPage = 1;
            }
        }

        private void tb_Title_main_text_TextChanged(object sender, EventArgs e)
        {
            this.lb_TitleMainPreview.Text = this.tb_Title_main_text.Text;
            this.TitleMain.Text = this.tb_Title_main_text.Text;
        }

        private void tb_Title_sub_text_TextChanged(object sender, EventArgs e)
        {
            this.lb_TitleSubPreview.Text = this.tb_Title_sub_text.Text;
            this.TitleSub.Text = this.tb_Title_sub_text.Text;
        }

        private void tb_top_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.PageSet.Margins.Top = Convert.ToInt32(this.tb_top.Text.Trim());
            }
            catch (FormatException)
            {
                this.tb_top.Text = "20";
                this.PageSet.Margins.Top = 20;
            }
        }

        private void tb_watermark_angle_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(this.tb_watermark_angle.Text.Trim(), out num) && num > -360 && num < 360)
                this.Watermark.Angle = num;
            else
                MessageBox.Show("请输入0到360之间的角度数字!", this.Text);
        }

        private void tb_watermark_text_TextChanged(object sender, EventArgs e) { this.Watermark.Text = this.tb_watermark_text.Text.Trim(); }

        private void tb_watermark_x_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Watermark.Location.X = int.Parse(this.tb_watermark_x.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void tb_watermark_y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Watermark.Location.Y = int.Parse(this.tb_watermark_y.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入有效的数字!\r\n" + exception.Message, this.Text);
            }
        }

        private void toolStrip_next_Click(object sender, EventArgs e)
        {
            if (this.previewer.StartPage < this.page_count - 1)
            {
                if (this.previewer.StartPage + this.display_pages <= this.page_count - 1)
                    this.previewer.StartPage += this.display_pages;
                else
                    this.previewer.StartPage = this.page_count - 1;
            }
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,共 ", this.page_count.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
        }

        private void toolStrip_prior_Click(object sender, EventArgs e)
        {
            if (this.previewer.StartPage > 0)
            {
                if (this.previewer.StartPage >= this.display_pages)
                    this.previewer.StartPage -= this.display_pages;
                else
                    this.previewer.StartPage = 0;
            }
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,共 ", this.page_count.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
        }

        private void toolStripButton_1_Click(object sender, EventArgs e)
        {
            int num = this.trackBar_zoom.Value * this.previewer.Columns;
            if (num >= 10 && num <= 100)
                this.trackBar_zoom.Value = num;
            else
            {
                if (num < 10) this.trackBar_zoom.Value = 10;
                if (num > 100) this.trackBar_zoom.Value = 100;
            }
            int num2 = this.trackBar_zoom.Value;
            this.previewer.Zoom = ((double) num2) / 100.0;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
            this.previewer.Rows = 1;
            this.previewer.Columns = 1;
            this.toolStripButton_2.Checked = false;
            this.toolStripButton_3.Checked = false;
            this.display_pages = 1;
        }

        private void toolStripButton_2_Click(object sender, EventArgs e)
        {
            int num = this.trackBar_zoom.Value;
            if (this.previewer.Columns == 1) num = this.trackBar_zoom.Value / 2;
            if (this.previewer.Columns == 3) num = this.trackBar_zoom.Value * 2;
            if (num >= 10 && num <= 100)
                this.trackBar_zoom.Value = num;
            else
            {
                if (num < 10) this.trackBar_zoom.Value = 10;
                if (num > 100) this.trackBar_zoom.Value = 100;
            }
            int num2 = this.trackBar_zoom.Value;
            this.previewer.Zoom = ((double) num2) / 100.0;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
            this.previewer.Rows = 1;
            this.previewer.Columns = 2;
            this.toolStripButton_1.Checked = false;
            this.toolStripButton_3.Checked = false;
            this.display_pages = 2;
        }

        private void toolStripButton_3_Click(object sender, EventArgs e)
        {
            int num = this.trackBar_zoom.Value / (3 - this.previewer.Columns + 1);
            if (num >= 10 && num <= 100)
                this.trackBar_zoom.Value = num;
            else
            {
                if (num < 10) this.trackBar_zoom.Value = 10;
                if (num > 100) this.trackBar_zoom.Value = 100;
            }
            int num2 = this.trackBar_zoom.Value;
            this.previewer.Zoom = ((double) num2) / 100.0;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
            this.previewer.Rows = 2;
            this.previewer.Columns = 3;
            this.toolStripButton_2.Checked = false;
            this.toolStripButton_1.Checked = false;
            this.display_pages = 6;
        }

        private void toolStripButton_first_Click(object sender, EventArgs e)
        {
            this.previewer.StartPage = 0;
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,共 ", this.page_count.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
        }

        private void toolStripButton_last_Click(object sender, EventArgs e)
        {
            try
            {
                this.previewer.StartPage = this.page_count - 1;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.Message, this.Text);
            }
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,共 ", this.page_count.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
        }

        private void toolStripButton_review_Click(object sender, EventArgs e)
        {
            EntLib.Controls.DataPrinter.DataPrinter.TotalPages = this.GetPageCount();
            if (this.PD != null) this.PD.Dispose();
            this.PD = new PrintDocument();
            this.PD.DefaultPageSettings = this.PageSet;
            this.PD.PrintPage += new PrintPageEventHandler(this.PD_PrintPage);
            this.PD.EndPrint += new PrintEventHandler(this.PD_EndPrint);
            this.PD.DocumentName = EntLib.Controls.DataPrinter.DataPrinter.TotalPages.ToString();
            this.MyDataPrinter = new EntLib.Controls.DataPrinter.DataPrinter(this.DGV, this.PD, this.Statistic, this.Watermark, this.Logo, this.TitleMain, this.TitleSub, this.Header, this.Footer, this.Page, this.Others, this.PageSet, this._printUser, this.SelectedColumns, this.PrintRows, this.layout_style, 1);
            this.previewer.InvalidatePreview();
            string[] strArray = new string[] { "第 ", (this.previewer.StartPage + 1).ToString(), " 页,共 ", this.page_count.ToString(), " 页" };
            this.toolStripLabel_pages.Text = string.Concat(strArray);
        }

        private void toolStripButton3_ButtonClick(object sender, EventArgs e)
        {
            this.previewer.Zoom = 1.0;
            this.trackBar_zoom.Value = 100;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem) sender;
            int num = int.Parse(item.Name.Substring(item.Name.LastIndexOf('_') + 1));
            this.previewer.Zoom = ((double) num) / 100.0;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
        }

        private void trackBar_zoom_Scroll(object sender, EventArgs e)
        {
            int num = this.trackBar_zoom.Value;
            if (num > 100) num = (num - 100) * 10 + 100;
            this.previewer.Zoom = ((double) num) / 100.0;
            this.lb_zoom_size.Text = "缩放比例:" + ((this.previewer.Zoom * 100.0)).ToString() + "%";
        }
    }
}
