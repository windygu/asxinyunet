namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    internal class DataPrinter
    {
        private int BottomMargin;
        private List<float> ColumnsWidth;
        private static int CurrentRow;
        private float CurrentY;
        private bool IsFixColumnWidth;
        private int Layout;
        private int LeftMargin;
        private string logo = (Application.StartupPath + @"\xhaj_logo.png");
        private int mColumnPoint;
        private List<int[]> mColumnPoints;
        private List<float> mColumnPointsWidth;
        private int PageHeight;
        public static int PageNumber;
        private int PageWidth;
        private const float Pix = 3.94f;
        private RectangleF PrintableArea;
        private int PrintedRows;
        public string Printer;
        private int registerState;
        private int RightMargin;
        private float RowHeaderHeight;
        private List<float> RowsHeight;
        private List<string> SelectedColumns = new List<string>();
        private StatisticOptions Statistic;
        private DataGridView TheDataGridView;
        private float TheDataGridViewWidth;
        private DefaultOptions TheFooter;
        private DefaultOptions TheHeader;
        private LogoOptions TheLogo;
        private DefaultOptions TheMainTitle;
        private OtherOptions TheOthers;
        private DefaultOptions ThePage;
        private PageSettings ThePageSet = new PageSettings();
        private PrintDocument ThePrintDocument;
        private int ThePrintRows;
        private DefaultOptions TheSubTitle;
        private int TopMargin;
        public static int TotalPages = 0;
        private const string VersionDeclare = "本文件由未被授权的专业打印组件\"DataGridView 打印专家\"打印(联系我们:luckeryin@163.com)";
        private WatermarkOptions Watermark;
        private int Xstart;

        public DataPrinter(DataGridView aDataGridView, PrintDocument aPrintDocument, StatisticOptions statistic, WatermarkOptions watermark, LogoOptions aLogo, DefaultOptions aMainTitle, DefaultOptions aSubTitle, DefaultOptions aHeader, DefaultOptions aFooter, DefaultOptions aPage, OtherOptions aOthers, PageSettings aPageSet, string _printer, List<string> selectedcolumns, int PrintRows, int layout, int RegisterState)
        {
            this.Printer = _printer;
            this.TheDataGridView = aDataGridView;
            this.ThePrintDocument = aPrintDocument;
            this.Statistic = statistic;
            this.Watermark = watermark;
            this.TheLogo = aLogo;
            this.TheMainTitle = aMainTitle;
            this.TheSubTitle = aSubTitle;
            this.TheHeader = aHeader;
            this.TheFooter = aFooter;
            this.ThePage = aPage;
            this.TheOthers = aOthers;
            this.ThePageSet = aPageSet;
            PageNumber = 0;
            this.RowsHeight = new List<float>();
            this.ColumnsWidth = new List<float>();
            this.mColumnPoints = new List<int[]>();
            this.mColumnPointsWidth = new List<float>();
            this.ThePrintDocument.DefaultPageSettings = this.ThePageSet;
            this.PrintableArea = this.ThePrintDocument.DefaultPageSettings.PrintableArea;
            if (!this.ThePrintDocument.DefaultPageSettings.Landscape)
            {
                this.PageWidth = this.ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                this.PageHeight = this.ThePrintDocument.DefaultPageSettings.PaperSize.Height;
            }
            else
            {
                this.PageHeight = this.ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                this.PageWidth = this.ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                float width = 0f;
                width = this.PrintableArea.Width;
                this.PrintableArea.Width = this.PrintableArea.Height;
                this.PrintableArea.Height = width;
            }
            this.LeftMargin = Convert.ToInt32(Math.Round((double) (this.ThePrintDocument.DefaultPageSettings.Margins.Left * 3.94f), 0));
            this.TopMargin = Convert.ToInt32(Math.Round((double) (this.ThePrintDocument.DefaultPageSettings.Margins.Top * 3.94f), 0));
            this.RightMargin = Convert.ToInt32(Math.Round((double) (this.ThePrintDocument.DefaultPageSettings.Margins.Right * 3.94f), 0)) + 40;
            this.BottomMargin = Convert.ToInt32(Math.Round((double) (this.ThePrintDocument.DefaultPageSettings.Margins.Bottom * 3.94f), 0)) + 40;
            CurrentRow = 0;
            this.SelectedColumns = selectedcolumns;
            if (layout >= 10) this.IsFixColumnWidth = true;
            this.Layout = layout % 10;
            if (this.SelectedColumns.Count != 0) this.ThePrintRows = PrintRows;
        }

        private void Calculate(PrintPageEventArgs e)
        {
            int num6;
            if (PageNumber != 1) return;
            SizeF ef = new SizeF();
            this.TheDataGridViewWidth = 0f;
            for (int i = 0; i < this.TheDataGridView.Columns.Count; i++)
            {
                Font font = this.TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
                if (font == null) font = this.TheDataGridView.DefaultCellStyle.Font;
                ef = e.Graphics.MeasureString(this.TheDataGridView.Columns[i].HeaderText, font);
                float width = ef.Width + 10f;
                this.RowHeaderHeight = ef.Height + 8f;
                for (int j = 0; j < this.TheDataGridView.Rows.Count; j++)
                {
                    string str4;
                    if (this.ThePrintRows == 1 && !this.TheDataGridView.Rows[j].Selected)
                    {
                        this.RowsHeight.Add(0f);
                        continue;
                    }
                    if (this.Statistic.StatisticColumn1 == this.TheDataGridView.Columns[i].HeaderText)
                    {
                        string s = (this.TheDataGridView[i, j].Value == null) ? "" : this.TheDataGridView[i, j].Value.ToString();
                        decimal result = 0M;
                        if (decimal.TryParse(s, out result)) this.Statistic.TotalSum1 += result;
                    }
                    if (this.Statistic.StatisticColumn2 == this.TheDataGridView.Columns[i].HeaderText)
                    {
                        string str2 = (this.TheDataGridView[i, j].Value == null) ? "" : this.TheDataGridView[i, j].Value.ToString();
                        decimal num5 = 0M;
                        if (decimal.TryParse(str2, out num5)) this.Statistic.TotalSum2 += num5;
                    }
                    font = this.TheDataGridView.Rows[j].DefaultCellStyle.Font;
                    if (font == null) font = this.TheDataGridView.DefaultCellStyle.Font;
                    this.RowsHeight.Add((ef.Height + 8f >= this.TheDataGridView.Rows[j].Height) ? (ef.Height + 8f) : ((float) (this.TheDataGridView.Rows[j].Height - 2)));
                    if ((str4 = this.TheDataGridView.Columns[i].GetType().Name) != null && !(str4 == "DataGridViewTextBoxColumn") && !(str4 == "DataGridViewLinkColumn"))
                    {
                        if (str4 == "DataGridViewComboBoxColumn") goto Label_02FE;
                        if (str4 == "DataGridViewImageColumn") goto Label_0347;
                    }
                    ef = e.Graphics.MeasureString(this.TheDataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), font);
                    goto Label_038C;
                Label_02FE:
                    ef = e.Graphics.MeasureString(this.TheDataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), font);
                    ef.Width += 12f;
                    goto Label_038C;
                Label_0347:
                    ef = (SizeF) ((Image) this.TheDataGridView.Rows[j].Cells[i].FormattedValue).Size;
                    ef.Width -= 10f;
                Label_038C:
                    if (ef.Width > width) width = ef.Width + 10f;
                }
                if (this.IsFixColumnWidth) width = this.TheDataGridView.Columns[i].Width;
                if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[i].HeaderText)) this.TheDataGridViewWidth += width;
                this.ColumnsWidth.Add(width);
            }
            int num7 = 0;
            for (num6 = 0; num6 < this.TheDataGridView.Columns.Count; num6++)
            {
                if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[num6].HeaderText))
                {
                    num7 = num6;
                    break;
                }
            }
            int num8 = 0;
            for (num6 = this.TheDataGridView.Columns.Count - 1; num6 >= 0; num6--)
            {
                if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[num6].HeaderText))
                {
                    num8 = num6 + 1;
                    break;
                }
            }
            float theDataGridViewWidth = this.TheDataGridViewWidth;
            float item = this.PageWidth - this.LeftMargin - this.RightMargin;
            if (this.TheDataGridViewWidth > item)
            {
                theDataGridViewWidth = 0f;
                for (num6 = 0; num6 < this.TheDataGridView.Columns.Count; num6++)
                {
                    if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[num6].HeaderText))
                    {
                        theDataGridViewWidth += this.ColumnsWidth[num6];
                        if (theDataGridViewWidth > item)
                        {
                            theDataGridViewWidth -= this.ColumnsWidth[num6];
                            this.mColumnPoints.Add(new int[] { num7, num8 });
                            this.mColumnPointsWidth.Add(theDataGridViewWidth);
                            num7 = num6;
                            theDataGridViewWidth = this.ColumnsWidth[num6];
                        }
                    }
                    num8 = num6 + 1;
                }
                this.mColumnPoints.Add(new int[] { num7, num8 });
                this.mColumnPointsWidth.Add(theDataGridViewWidth);
            }
            else
            {
                this.mColumnPoints.Add(new int[] { num7, num8 });
                float num11 = item - this.TheDataGridViewWidth;
                switch (this.Layout)
                {
                    case 1:
                        this.mColumnPointsWidth.Add(theDataGridViewWidth);
                        this.Xstart = Convert.ToInt32((float) (num11 / 2f));
                        goto Label_06E4;

                    case 2:
                    {
                        float num12 = num11 / ((float) this.SelectedColumns.Count);
                        for (int k = 0; k < this.ColumnsWidth.Count; k++)
                        {
                            if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[k].HeaderText))
                            {
                                List<float> list;
                                int num15;
                                (list = this.ColumnsWidth)[num15 = k] = list[num15] + num12;
                            }
                        }
                        this.mColumnPointsWidth.Add(item);
                        goto Label_06E4;
                    }
                    default:
                        this.mColumnPointsWidth.Add(theDataGridViewWidth);
                        this.Xstart = 0;
                        goto Label_06E4;
                }
            }
        Label_06E4:
            this.mColumnPoint = 0;
        }

        private void DrawColumnHeader(PrintPageEventArgs e)
        {
            float x = this.LeftMargin + this.Xstart;
            Color foreColor = this.TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
            if (foreColor.IsEmpty) foreColor = this.TheDataGridView.DefaultCellStyle.ForeColor;
            SolidBrush brush = new SolidBrush(foreColor);
            Color backColor = this.TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            if (backColor.IsEmpty) backColor = this.TheDataGridView.DefaultCellStyle.BackColor;
            SolidBrush brush2 = new SolidBrush(backColor);
            Pen pen = new Pen(this.TheDataGridView.GridColor, 1f);
            Font font = this.TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
            if (font == null) font = this.TheDataGridView.DefaultCellStyle.Font;
            RectangleF rect = new RectangleF(x, this.CurrentY, this.mColumnPointsWidth[this.mColumnPoint], this.RowHeaderHeight);
            e.Graphics.FillRectangle(brush2, rect);
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.Word;
            format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            for (int i = (int) this.mColumnPoints[this.mColumnPoint].GetValue(0); i < ((int) this.mColumnPoints[this.mColumnPoint].GetValue(1)); i++)
            {
                bool flag = false;
                if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[i].HeaderText)) flag = true;
                if (flag)
                {
                    float width = this.ColumnsWidth[i];
                    if (this.TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                        format.Alignment = StringAlignment.Far;
                    else if (this.TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                        format.Alignment = StringAlignment.Center;
                    else
                        format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;
                    RectangleF layoutRectangle = new RectangleF(x, this.CurrentY, width, this.RowHeaderHeight);
                    e.Graphics.DrawString(this.TheDataGridView.Columns[i].HeaderText, font, brush, layoutRectangle, format);
                    if (this.TheDataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None) e.Graphics.DrawRectangle(pen, x, this.CurrentY, width, this.RowHeaderHeight);
                    x += width;
                }
            }
            this.CurrentY += this.RowHeaderHeight;
        }

        public bool DrawDataGridView(PrintPageEventArgs e)
        {
            try
            {
                PageNumber++;
                this.Calculate(e);
                this.DrawHeader(e);
                this.DrawFooter(e);
                this.DrawPageNumber(e);
                this.CurrentY = this.TopMargin + 5;
                this.DrawLogo(e);
                this.DrawMainTitle(e);
                this.DrawSubTitle(e);
                this.DrawOthers(e);
                this.DrawColumnHeader(e);
                bool flag = this.DrawRows(e);
                this.DrawWatermark(e);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show("打印失败: " + exception.Message.ToString() + "\r\n" + exception.StackTrace, Application.ProductName + " - 出错了", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        private void DrawFooter(PrintPageEventArgs e)
        {
            string s = "";
            this.CurrentY = this.PageHeight - this.BottomMargin + 5;
            if (this.registerState != 1)
            {
                if (this.TheFooter.Enable)
                    s = this.TheFooter.Text + "\r\n本文件由未被授权的专业打印组件\"DataGridView 打印专家\"打印(联系我们:luckeryin@163.com)";
                else
                    s = "本文件由未被授权的专业打印组件\"DataGridView 打印专家\"打印(联系我们:luckeryin@163.com)";
            }
            else
            {
                if (!this.TheFooter.Enable) return;
                s = this.TheFooter.Text;
            }
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.Word;
            format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            format.Alignment = this.TheFooter.Valign;
            format.LineAlignment = this.TheFooter.Halign;
            Font fontItem = this.TheFooter.FontItem;
            RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), this.PrintableArea.Y + this.PrintableArea.Height - this.CurrentY);
            e.Graphics.DrawString(s, fontItem, new SolidBrush(this.TheFooter.TextColor), layoutRectangle, format);
        }

        private void DrawHeader(PrintPageEventArgs e)
        {
            if (this.TheHeader.Enable)
            {
                this.CurrentY = this.PrintableArea.Y;
                string text = this.TheHeader.Text;
                StringFormat format = new StringFormat();
                format.Trimming = StringTrimming.Word;
                format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                format.Alignment = this.TheHeader.Valign;
                format.LineAlignment = this.TheHeader.Halign;
                Font fontItem = this.TheHeader.FontItem;
                RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), this.TopMargin - this.PrintableArea.Y - 5f);
                e.Graphics.DrawString(text, fontItem, new SolidBrush(this.TheHeader.TextColor), layoutRectangle, format);
                this.CurrentY += layoutRectangle.Height + 2f;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(this.LeftMargin, (int) this.CurrentY), new Point(this.PageWidth - this.RightMargin, (int) this.CurrentY));
            }
        }

        private void DrawLogo(PrintPageEventArgs e)
        {
            if (this.TheLogo.Enable && PageNumber <= 1)
            {
                if (this.TheLogo.ImageSize.Width == 0 && this.TheLogo.ImageSize.Height == 0)
                    e.Graphics.DrawImage(Image.FromFile(this.TheLogo.FilePath, true), (this.TheLogo.Location.X == 0) ? this.LeftMargin : ((int) (this.TheLogo.Location.X * 3.94f)), (this.TheLogo.Location.Y == 0) ? ((int) this.CurrentY) : ((int) (this.TheLogo.Location.Y * 3.94f)));
                else
                    e.Graphics.DrawImage(Image.FromFile(this.TheLogo.FilePath, true), (this.TheLogo.Location.X == 0) ? this.LeftMargin : ((int) (this.TheLogo.Location.X * 3.94f)), (this.TheLogo.Location.Y == 0) ? ((int) this.CurrentY) : ((int) (this.TheLogo.Location.Y * 3.94f)), (int) (this.TheLogo.ImageSize.Width * 3.94f), (int) (this.TheLogo.ImageSize.Height * 3.94f));
            }
        }

        private void DrawMainTitle(PrintPageEventArgs e)
        {
            if (this.TheMainTitle.Enable && PageNumber <= 1)
            {
                string text = this.TheMainTitle.Text;
                StringFormat format = new StringFormat();
                format.Trimming = StringTrimming.Word;
                format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                format.Alignment = this.TheMainTitle.Valign;
                format.LineAlignment = this.TheMainTitle.Halign;
                Font fontItem = this.TheMainTitle.FontItem;
                RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), e.Graphics.MeasureString(this.TheMainTitle.Text, this.TheMainTitle.FontItem).Height * 1.5f);
                e.Graphics.DrawString(text, fontItem, new SolidBrush(this.TheMainTitle.TextColor), layoutRectangle, format);
                this.CurrentY += layoutRectangle.Height;
            }
        }

        private void DrawOthers(PrintPageEventArgs e)
        {
            string s = this.SetOthersPreview();
            if (s.Trim().Length != 0 && PageNumber <= 1)
            {
                StringFormat format = new StringFormat();
                format.Trimming = StringTrimming.Word;
                format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                format.Alignment = this.TheOthers.Valign;
                format.LineAlignment = this.TheOthers.Halign;
                Font fontItem = this.TheOthers.FontItem;
                RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), e.Graphics.MeasureString(this.TheOthers.PrinterText, this.TheOthers.FontItem).Height * 1.5f);
                e.Graphics.DrawString(s, fontItem, new SolidBrush(this.TheOthers.TextColor), layoutRectangle, format);
                this.CurrentY += layoutRectangle.Height + 5f;
            }
        }

        private void DrawPageNumber(PrintPageEventArgs e)
        {
            if (this.ThePage.Enable)
            {
                string str;
                try
                {
                    str = string.Format(this.ThePage.Text, PageNumber, TotalPages);
                }
                catch (FormatException)
                {
                    throw new FormatException("Page number format set error!");
                }
                StringFormat format = new StringFormat();
                format.Trimming = StringTrimming.Word;
                format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                format.Alignment = this.ThePage.Valign;
                format.LineAlignment = this.ThePage.Halign;
                Font fontItem = this.ThePage.FontItem;
                if (this.ThePage.ShowOnHeader)
                {
                    this.CurrentY = this.PrintableArea.Y;
                    RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), this.TopMargin - this.PrintableArea.Y - 5f);
                    e.Graphics.DrawString(str, fontItem, new SolidBrush(this.ThePage.TextColor), layoutRectangle, format);
                }
                else
                {
                    this.CurrentY = this.PageHeight - this.BottomMargin + 5;
                    RectangleF ef2 = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), this.PrintableArea.Y + this.PrintableArea.Height - this.CurrentY);
                    e.Graphics.DrawString(str, fontItem, new SolidBrush(this.ThePage.TextColor), ef2, format);
                }
            }
        }

        private bool DrawRows(PrintPageEventArgs e)
        {
            Pen pen = new Pen(this.TheDataGridView.GridColor, 1f);
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.Word;
            format.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            float num3 = 0f;
            if (!string.IsNullOrEmpty(this.Statistic.StatisticColumn1)) num3 += this.TheDataGridView.RowTemplate.Height;
            if (!string.IsNullOrEmpty(this.Statistic.StatisticColumn2)) num3 += this.TheDataGridView.RowTemplate.Height;
            while (CurrentRow < this.TheDataGridView.Rows.Count)
            {
                if (this.TheDataGridView.Rows[CurrentRow].Visible)
                {
                    if (this.ThePrintRows == 1 && !this.TheDataGridView.Rows[CurrentRow].Selected)
                        CurrentRow++;
                    else
                    {
                        SolidBrush brush;
                        SolidBrush brush2;
                        if (this.TheDataGridView.Rows[CurrentRow].DefaultCellStyle.Font == null) Font font = this.TheDataGridView.DefaultCellStyle.Font;
                        Color foreColor = this.TheDataGridView.Rows[CurrentRow].DefaultCellStyle.ForeColor;
                        if (foreColor.IsEmpty) foreColor = this.TheDataGridView.DefaultCellStyle.ForeColor;
                        new SolidBrush(foreColor);
                        Color backColor = this.TheDataGridView.Rows[CurrentRow].DefaultCellStyle.BackColor;
                        if (backColor.IsEmpty)
                        {
                            brush = new SolidBrush(this.TheDataGridView.DefaultCellStyle.BackColor);
                            brush2 = new SolidBrush(this.TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                        }
                        else
                        {
                            brush = new SolidBrush(backColor);
                            brush2 = new SolidBrush(backColor);
                        }
                        float x = this.LeftMargin + this.Xstart;
                        RectangleF rect = new RectangleF(x, this.CurrentY, this.mColumnPointsWidth[this.mColumnPoint], this.RowsHeight[CurrentRow]);
                        if (CurrentRow % 2 == 0)
                            e.Graphics.FillRectangle(brush, rect);
                        else
                            e.Graphics.FillRectangle(brush2, rect);
                        for (int i = (int) this.mColumnPoints[this.mColumnPoint].GetValue(0); i < ((int) this.mColumnPoints[this.mColumnPoint].GetValue(1)); i++)
                        {
                            bool flag = false;
                            if (this.SelectedColumns.Contains(this.TheDataGridView.Columns[i].HeaderText)) flag = true;
                            if (flag)
                            {
                                if (this.TheDataGridView.Columns[i].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                                    format.Alignment = StringAlignment.Far;
                                else if (this.TheDataGridView.Columns[i].DefaultCellStyle.Alignment.ToString().Contains("Center"))
                                    format.Alignment = StringAlignment.Center;
                                else
                                    format.Alignment = StringAlignment.Near;
                                format.LineAlignment = StringAlignment.Center;
                                float width = this.ColumnsWidth[i];
                                RectangleF layoutRectangle = new RectangleF(x, this.CurrentY, width, this.RowsHeight[CurrentRow]);
                                string name = this.TheDataGridView.Columns[i].GetType().Name;
                                DataGridViewCell cell = this.TheDataGridView.Rows[CurrentRow].Cells[i];
                                Button button = new Button();
                                CheckBox box = new CheckBox();
                                ComboBox box2 = new ComboBox();
                                string s = "";
                                if (cell.EditedFormattedValue != null) s = cell.EditedFormattedValue.ToString();
                                if (this.Statistic.StatisticColumn1 == cell.OwningColumn.HeaderText)
                                {
                                    decimal result = 0M;
                                    if (decimal.TryParse(s, out result)) this.Statistic.PageSum1 += result;
                                }
                                else if (this.Statistic.StatisticColumn2 == cell.OwningColumn.HeaderText)
                                {
                                    decimal num6 = 0M;
                                    if (decimal.TryParse(s, out num6)) this.Statistic.PageSum2 += num6;
                                }
                                if (name == "DataGridViewTextBoxColumn" || name == "DataGridViewLinkColumn")
                                    e.Graphics.DrawString(s, cell.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), layoutRectangle, format);
                                else if (name == "DataGridViewButtonColumn")
                                {
                                    button.Text = s;
                                    button.Size = new Size((int) layoutRectangle.Width, (int) layoutRectangle.Height);
                                    Bitmap bitmap = new Bitmap(button.Width, button.Height);
                                    button.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                    e.Graphics.DrawImage(bitmap, layoutRectangle);
                                }
                                else if (name == "DataGridViewCheckBoxColumn")
                                {
                                    box.Size = new Size(13, 13);
                                    box.Checked = cell.Value != null && (bool) cell.Value;
                                    Bitmap bitmap2 = new Bitmap((int) layoutRectangle.Width, (int) layoutRectangle.Height);
                                    box.DrawToBitmap(bitmap2, new Rectangle((bitmap2.Width - box.Width) / 2, (bitmap2.Height - box.Height) / 2, box.Width, box.Height));
                                    e.Graphics.DrawImage(bitmap2, layoutRectangle);
                                }
                                else if (name == "DataGridViewComboBoxColumn")
                                {
                                    box2.Size = new Size((int) layoutRectangle.Width, (int) layoutRectangle.Height);
                                    Bitmap bitmap3 = new Bitmap(box2.Width, box2.Height);
                                    box2.DrawToBitmap(bitmap3, new Rectangle(0, 0, bitmap3.Width, bitmap3.Height));
                                    e.Graphics.DrawImage(bitmap3, layoutRectangle);
                                    e.Graphics.DrawString(s, cell.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), layoutRectangle, format);
                                }
                                else if (name == "DataGridViewImageColumn")
                                {
                                    RectangleF ef3 = layoutRectangle;
                                    Size size = ((Image) cell.FormattedValue).Size;
                                    int num7 = ((int) x) + ((int) ((ef3.Width - size.Width) / 2f));
                                    int num8 = ((int) this.CurrentY) + ((int) ((ef3.Height - size.Height) / 2f));
                                    int num9 = ((Image) cell.FormattedValue).Width;
                                    int height = ((Image) cell.FormattedValue).Height;
                                    e.Graphics.DrawImage((Image) cell.FormattedValue, new Rectangle((num7 >= ((int) x)) ? num7 : ((int) x), (num8 >= ((int) this.CurrentY)) ? num8 : ((int) this.CurrentY), (num9 <= ((int) layoutRectangle.Width)) ? num9 : ((int) layoutRectangle.Width), (height <= ((int) layoutRectangle.Height)) ? height : ((int) layoutRectangle.Height)));
                                }
                                else
                                    e.Graphics.DrawString(s, cell.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), layoutRectangle, format);
                                if (this.TheDataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None) e.Graphics.DrawRectangle(pen, x, this.CurrentY, width, this.RowsHeight[CurrentRow]);
                                x += width;
                            }
                        }
                        this.CurrentY += this.RowsHeight[CurrentRow];
                        CurrentRow++;
                        this.PrintedRows++;
                        this.Statistic.PageRowCount++;
                        this.Statistic.TotalRowCount++;
                        if ((this.Statistic.PageStatistic || this.Statistic.TotalStatistic) && (((int) (this.CurrentY + num3)) <= this.PageHeight - this.BottomMargin && ((int) (this.CurrentY + num3)) > this.PageHeight - this.BottomMargin - this.RowsHeight[CurrentRow - 1]) || this.PrintedRows >= ((this.ThePrintRows == 1) ? this.TheDataGridView.SelectedRows.Count : this.TheDataGridView.Rows.Count))
                        {
                            format.LineAlignment = StringAlignment.Far;
                            format.Alignment = StringAlignment.Near;
                            if (this.Statistic.StatisticColumn1 != null)
                            {
                                e.Graphics.DrawString(this.Statistic.StatisticColumn1 + " 统计:  " + (!this.Statistic.PageStatistic ? "" : ("本页小计:" + this.Statistic.PageSum1.ToString())) + (!this.Statistic.TotalStatistic ? "" : ("   总计:" + this.Statistic.TotalSum1.ToString())), this.TheDataGridView.DefaultCellStyle.Font, new SolidBrush(this.TheDataGridView.DefaultCellStyle.ForeColor), new RectangleF((float) (this.LeftMargin + this.Xstart), this.CurrentY, (float) (this.PageWidth - this.LeftMargin - this.RightMargin), (float) this.TheDataGridView.RowTemplate.Height), format);
                                this.CurrentY += this.TheDataGridView.RowTemplate.Height;
                            }
                            format.LineAlignment = StringAlignment.Center;
                            format.Alignment = StringAlignment.Near;
                            if (this.Statistic.StatisticColumn2 != null)
                            {
                                e.Graphics.DrawString(this.Statistic.StatisticColumn2 + " 统计:  " + (!this.Statistic.PageStatistic ? "" : ("本页小计:" + this.Statistic.PageSum2.ToString())) + (!this.Statistic.TotalStatistic ? "" : ("   总计:" + this.Statistic.TotalSum2.ToString())), this.TheDataGridView.DefaultCellStyle.Font, new SolidBrush(this.TheDataGridView.DefaultCellStyle.ForeColor), new RectangleF((float) (this.LeftMargin + this.Xstart), this.CurrentY, (float) (this.PageWidth - this.LeftMargin - this.RightMargin), (float) this.TheDataGridView.RowTemplate.Height), format);
                                this.CurrentY += this.TheDataGridView.RowTemplate.Height;
                            }
                        }
                        if (((int) this.CurrentY) > this.PageHeight - this.BottomMargin - this.RowsHeight[CurrentRow])
                        {
                            this.Statistic.PageRowCount = 0;
                            this.Statistic.PageSum1 = 0M;
                            this.Statistic.PageSum2 = 0M;
                            return true;
                        }
                    }
                }
            }
            CurrentRow = 0;
            this.mColumnPoint++;
            if (this.mColumnPoint == this.mColumnPoints.Count)
            {
                this.mColumnPoint = 0;
                return false;
            }
            return true;
        }

        public void DrawStatistic(PrintPageEventArgs e) {  }

        private void DrawSubTitle(PrintPageEventArgs e)
        {
            if (this.TheSubTitle.Enable && PageNumber <= 1)
            {
                string text = this.TheSubTitle.Text;
                StringFormat format = new StringFormat();
                format.Trimming = StringTrimming.Word;
                format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                format.Alignment = this.TheSubTitle.Valign;
                format.LineAlignment = this.TheSubTitle.Halign;
                Font fontItem = this.TheSubTitle.FontItem;
                RectangleF layoutRectangle = new RectangleF((float) this.LeftMargin, this.CurrentY, (float) (this.PageWidth - this.RightMargin - this.LeftMargin), e.Graphics.MeasureString(this.TheSubTitle.Text, this.TheSubTitle.FontItem).Height * 1.5f);
                e.Graphics.DrawString(text, fontItem, new SolidBrush(this.TheSubTitle.TextColor), layoutRectangle, format);
                this.CurrentY += layoutRectangle.Height;
            }
        }

        private void DrawWatermark(PrintPageEventArgs e)
        {
            if (this.Watermark.Enable)
            {
                SizeF ef = e.Graphics.MeasureString(this.Watermark.Text, this.Watermark.FontItem);
                Bitmap image = new Bitmap((int) this.PrintableArea.Width, (int) this.PrintableArea.Height);
                Rectangle rectangle = new Rectangle(0, 0, (int) this.PrintableArea.Width, (int) this.PrintableArea.Height);
                PointF tf = new PointF((float) (rectangle.Width / 2), (float) (rectangle.Height / 2));
                float x = 0f;
                float y = 0f;
                x = tf.X - image.Width / 2;
                y = tf.Y - image.Height / 2;
                RectangleF ef2 = new RectangleF(x, y, (float) image.Width, (float) image.Height);
                PointF tf2 = new PointF(ef2.X + ef2.Width / 2f, ef2.Y + ef2.Height / 2f);
                Graphics graphics = Graphics.FromImage(image);
                graphics.TranslateTransform(tf2.X, tf2.Y);
                graphics.RotateTransform(-((float) this.Watermark.Angle));
                Point point = new Point();
                if (this.Watermark.Location.X == 0 && this.Watermark.Location.Y == 0)
                    point = new Point(-((int) (ef.Width / 2f)), -((int) (ef.Height / 2f)));
                else
                {
                    graphics.TranslateTransform(-tf2.X, -tf2.Y);
                    point.X = (int) (this.Watermark.Location.X * 3.94f);
                    point.Y = (int) (this.Watermark.Location.Y * 3.94f);
                }
                graphics.DrawString(this.Watermark.Text, this.Watermark.FontItem, new SolidBrush(this.Watermark.TextColor), (PointF) point);
                e.Graphics.DrawImage(image, new Point(0, 0));
            }
        }

        private Rectangle GetRealMarginBounds(PrintPageEventArgs e, bool preview)
        {
            if (preview) return e.MarginBounds;
            float hardMarginX = e.PageSettings.HardMarginX;
            float hardMarginY = e.PageSettings.HardMarginY;
            Rectangle marginBounds = e.MarginBounds;
            float dpiX = e.Graphics.DpiX;
            float dpiY = e.Graphics.DpiY;
            marginBounds.Offset((int) (-hardMarginX * 100f / dpiX), (int) (-hardMarginY * 100f / dpiY));
            return marginBounds;
        }

        private Rectangle GetRealPageBounds(PrintPageEventArgs e, bool preview)
        {
            if (preview) return e.PageBounds;
            RectangleF visibleClipBounds = e.Graphics.VisibleClipBounds;
            PointF[] pts = new PointF[] { new PointF(visibleClipBounds.Size.Width, visibleClipBounds.Height) };
            e.Graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, pts);
            float dpiX = e.Graphics.DpiX;
            float dpiY = e.Graphics.DpiY;
            return new Rectangle(0, 0, (int) (pts[0].X * 100f / dpiX), (int) (pts[0].Y * 100f / dpiY));
        }

        private string SetDateTimeFormat()
        {
            DateTime now;
            if (this.TheOthers.AutoDateTime)
                now = DateTime.Now;
            else
                now = DateTime.Parse(this.TheOthers.DateTimeText);
            switch (this.TheOthers.DateTimeFormat)
            {
                case "yyyy-MM-dd hh:mm:ss":
                    return string.Format("{0:yyyy-MM-dd hh:mm:ss}", now);

                case "yyyy-MM-dd":
                    return string.Format("{0:yyyy-MM-dd}", now);

                case "hh:mm:ss":
                    return string.Format("{0:hh:mm:ss}", now);
            }
            return string.Format("{0:yyyy-MM-dd hh:mm:ss}", now);
        }

        private string SetOthersPreview()
        {
            string str;
            string str3;
            string str5;
            string printer = "";
            if (this.TheOthers.PrinterEnable)
            {
                str = "打印人:{0}";
                if (this.TheOthers.AutoPrinter)
                    printer = this.Printer;
                else
                    printer = this.TheOthers.PrinterText;
            }
            else
                str = "";
            string str4 = "";
            if (this.TheOthers.DateTimeEnable)
            {
                str3 = "打印日期时间:{1}";
                str4 = this.SetDateTimeFormat();
            }
            else
                str3 = "";
            string str6 = "";
            if (this.TheOthers.CopysEnable)
            {
                str5 = "份数:{2}";
                str6 = this.ThePageSet.PrinterSettings.Copies.ToString();
            }
            else
                str5 = "";
            return string.Format(str + "  " + str3 + "  " + str5, printer, str4, str6).Trim();
        }
    }
}
