namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class PrintDGV
    {
        private static Button 37jAJ3Bnt;
        private static int 3RGFtDsi0;
        private static string 4nXjBHl1y = "";
        private static ArrayList 5gYn6JLpM = new ArrayList();
        private static int 8s1EDI5bT;
        private static PrintDocument 92er6I7D9 = new PrintDocument();
        private static ComboBox A3kPEVyyt;
        private static DataGridView Dk25owt8x;
        private static ArrayList fP4JOlhOm = new ArrayList();
        private static StringFormat GPY6Re0PF;
        private static bool iPnC2QyUu;
        private static List<string> IsYsrU1AV = new List<string>();
        private static ArrayList J33Gvmr8S = new ArrayList();
        private static StringFormat JiYUNJcCW;
        private static List<string> P8KKdK3CK = new List<string>();
        private static CheckBox PQMwwy6pB;
        private static bool Q1Q11vd4S = true;
        private static bool QkXTwgeJi = true;
        private static int qqOZd2BSd;
        private static int S4k2CWq1J;
        private static int sNixL8otw = 0;
        private static int TYCDm64fY;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 408MSTia8(PrintPageEventArgs args1, int num1)
        {
            double count = 0.0;
            if (QkXTwgeJi)
            {
                if (Dk25owt8x.Rows[Dk25owt8x.Rows.Count - 1].IsNewRow)
                {
                    count = Dk25owt8x.Rows.Count - 2;
                }
                else
                {
                    count = Dk25owt8x.Rows.Count - 1;
                }
            }
            else
            {
                count = Dk25owt8x.SelectedRows.Count;
            }
            string s = S4k2CWq1J.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4dc2) + Math.Ceiling((double) (count / ((double) num1))).ToString();
            args1.Graphics.DrawString(s, Dk25owt8x.Font, Brushes.Black, args1.MarginBounds.Left + ((args1.MarginBounds.Width - args1.Graphics.MeasureString(s, Dk25owt8x.Font, args1.MarginBounds.Width).Width) / 2f), (float) ((args1.MarginBounds.Top + args1.MarginBounds.Height) + 0x1f));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void mUvqAX6rk(object, PrintEventArgs)
        {
            try
            {
                GPY6Re0PF = new StringFormat();
                GPY6Re0PF.Alignment = StringAlignment.Near;
                GPY6Re0PF.LineAlignment = StringAlignment.Center;
                GPY6Re0PF.Trimming = StringTrimming.EllipsisCharacter;
                JiYUNJcCW = new StringFormat();
                JiYUNJcCW.LineAlignment = StringAlignment.Center;
                JiYUNJcCW.FormatFlags = StringFormatFlags.NoWrap;
                JiYUNJcCW.Trimming = StringTrimming.EllipsisCharacter;
                5gYn6JLpM.Clear();
                J33Gvmr8S.Clear();
                fP4JOlhOm.Clear();
                8s1EDI5bT = 0;
                TYCDm64fY = 0;
                37jAJ3Bnt = new Button();
                PQMwwy6pB = new CheckBox();
                A3kPEVyyt = new ComboBox();
                qqOZd2BSd = 0;
                foreach (DataGridViewColumn column in Dk25owt8x.Columns)
                {
                    if (column.Visible && IsYsrU1AV.Contains(column.HeaderText))
                    {
                        qqOZd2BSd += column.Width;
                    }
                }
                S4k2CWq1J = 1;
                iPnC2QyUu = true;
                3RGFtDsi0 = 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c64), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Print_DataGridView(DataGridView dgv1)
        {
            try
            {
                try
                {
                    Dk25owt8x = dgv1;
                    P8KKdK3CK.Clear();
                    foreach (DataGridViewColumn column in Dk25owt8x.Columns)
                    {
                        if (column.Visible)
                        {
                            P8KKdK3CK.Add(column.HeaderText);
                        }
                    }
                    PrintOptions options = new PrintOptions(P8KKdK3CK);
                    if (options.ShowDialog() == DialogResult.OK)
                    {
                        4nXjBHl1y = options.PrintTitle;
                        QkXTwgeJi = options.PrintAllRows;
                        Q1Q11vd4S = options.FitToPageWidth;
                        IsYsrU1AV = options.GetSelectedColumns();
                        TYCDm64fY = 0;
                        PrintPreviewDialog dialog = new PrintPreviewDialog {
                            Document = 92er6I7D9
                        };
                        92er6I7D9.BeginPrint += new PrintEventHandler(PrintDGV.mUvqAX6rk);
                        92er6I7D9.PrintPage += new PrintPageEventHandler(PrintDGV.XPOfx7u7N);
                        if (dialog.ShowDialog() != DialogResult.OK)
                        {
                            92er6I7D9.BeginPrint -= new PrintEventHandler(PrintDGV.mUvqAX6rk);
                            92er6I7D9.PrintPage -= new PrintPageEventHandler(PrintDGV.XPOfx7u7N);
                        }
                        else
                        {
                            92er6I7D9.Print();
                            92er6I7D9.BeginPrint -= new PrintEventHandler(PrintDGV.mUvqAX6rk);
                            92er6I7D9.PrintPage -= new PrintPageEventHandler(PrintDGV.XPOfx7u7N);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c56), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            finally
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void XPOfx7u7N(object, PrintPageEventArgs args1)
        {
            int top = args1.MarginBounds.Top;
            int left = args1.MarginBounds.Left;
            try
            {
                if (S4k2CWq1J == 1)
                {
                    foreach (DataGridViewColumn column in Dk25owt8x.Columns)
                    {
                        if (column.Visible && IsYsrU1AV.Contains(column.HeaderText))
                        {
                            int width;
                            if (Q1Q11vd4S)
                            {
                                width = (int) Math.Floor((double) (((((double) column.Width) / ((double) qqOZd2BSd)) * qqOZd2BSd) * (((double) args1.MarginBounds.Width) / ((double) qqOZd2BSd))));
                            }
                            else
                            {
                                width = column.Width;
                            }
                            sNixL8otw = ((int) args1.Graphics.MeasureString(column.HeaderText, column.InheritedStyle.Font, width).Height) + 11;
                            5gYn6JLpM.Add(left);
                            J33Gvmr8S.Add(width);
                            fP4JOlhOm.Add(column.GetType());
                            left += width;
                        }
                    }
                }
                while (3RGFtDsi0 <= (Dk25owt8x.Rows.Count - 1))
                {
                    int num2;
                    DataGridViewRow row = Dk25owt8x.Rows[3RGFtDsi0];
                    if (row.IsNewRow || (!QkXTwgeJi && !row.Selected))
                    {
                        3RGFtDsi0++;
                        continue;
                    }
                    8s1EDI5bT = row.Height;
                    if ((top + 8s1EDI5bT) >= (args1.MarginBounds.Height + args1.MarginBounds.Top))
                    {
                        408MSTia8(args1, TYCDm64fY);
                        iPnC2QyUu = true;
                        S4k2CWq1J++;
                        args1.HasMorePages = true;
                        return;
                    }
                    if (iPnC2QyUu)
                    {
                        args1.Graphics.DrawString(4nXjBHl1y, new Font(Dk25owt8x.Font, FontStyle.Bold), Brushes.Black, (float) args1.MarginBounds.Left, (args1.MarginBounds.Top - args1.Graphics.MeasureString(4nXjBHl1y, new Font(Dk25owt8x.Font, FontStyle.Bold), args1.MarginBounds.Width).Height) - 13f);
                        string s = DateTime.Now.ToLongDateString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c72) + DateTime.Now.ToShortTimeString();
                        args1.Graphics.DrawString(s, new Font(Dk25owt8x.Font, FontStyle.Bold), Brushes.Black, (float) (args1.MarginBounds.Left + (args1.MarginBounds.Width - args1.Graphics.MeasureString(s, new Font(Dk25owt8x.Font, FontStyle.Bold), args1.MarginBounds.Width).Width)), (float) ((args1.MarginBounds.Top - args1.Graphics.MeasureString(4nXjBHl1y, new Font(new Font(Dk25owt8x.Font, FontStyle.Bold), FontStyle.Bold), args1.MarginBounds.Width).Height) - 13f));
                        top = args1.MarginBounds.Top;
                        num2 = 0;
                        foreach (DataGridViewColumn column in Dk25owt8x.Columns)
                        {
                            if (column.Visible && IsYsrU1AV.Contains(column.HeaderText))
                            {
                                args1.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle((int) 5gYn6JLpM[num2], top, (int) J33Gvmr8S[num2], sNixL8otw));
                                args1.Graphics.DrawRectangle(Pens.Black, new Rectangle((int) 5gYn6JLpM[num2], top, (int) J33Gvmr8S[num2], sNixL8otw));
                                args1.Graphics.DrawString(column.HeaderText, column.InheritedStyle.Font, new SolidBrush(column.InheritedStyle.ForeColor), new RectangleF((float) ((int) 5gYn6JLpM[num2]), (float) top, (float) ((int) J33Gvmr8S[num2]), (float) sNixL8otw), GPY6Re0PF);
                                num2++;
                            }
                        }
                        iPnC2QyUu = false;
                        top += sNixL8otw;
                    }
                    num2 = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (!cell.OwningColumn.Visible || !IsYsrU1AV.Contains(cell.OwningColumn.HeaderText))
                        {
                            continue;
                        }
                        if ((((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4c78)) || (((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4cae)))
                        {
                            args1.Graphics.DrawString(cell.Value.ToString(), cell.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), new RectangleF((float) ((int) 5gYn6JLpM[num2]), (float) top, (float) ((int) J33Gvmr8S[num2]), (float) 8s1EDI5bT), GPY6Re0PF);
                        }
                        else
                        {
                            Bitmap bitmap;
                            if (((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4cde))
                            {
                                37jAJ3Bnt.Text = cell.Value.ToString();
                                37jAJ3Bnt.Size = new Size((int) J33Gvmr8S[num2], 8s1EDI5bT);
                                bitmap = new Bitmap(37jAJ3Bnt.Width, 37jAJ3Bnt.Height);
                                37jAJ3Bnt.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                args1.Graphics.DrawImage(bitmap, new Point((int) 5gYn6JLpM[num2], top));
                            }
                            else if (((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4d12))
                            {
                                PQMwwy6pB.Size = new Size(14, 14);
                                PQMwwy6pB.Checked = (bool) cell.Value;
                                bitmap = new Bitmap((int) J33Gvmr8S[num2], 8s1EDI5bT);
                                Graphics.FromImage(bitmap).FillRectangle(Brushes.White, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                PQMwwy6pB.DrawToBitmap(bitmap, new Rectangle((bitmap.Width - PQMwwy6pB.Width) / 2, (bitmap.Height - PQMwwy6pB.Height) / 2, PQMwwy6pB.Width, PQMwwy6pB.Height));
                                args1.Graphics.DrawImage(bitmap, new Point((int) 5gYn6JLpM[num2], top));
                            }
                            else if (((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4d4a))
                            {
                                A3kPEVyyt.Size = new Size((int) J33Gvmr8S[num2], 8s1EDI5bT);
                                bitmap = new Bitmap(A3kPEVyyt.Width, A3kPEVyyt.Height);
                                A3kPEVyyt.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                args1.Graphics.DrawImage(bitmap, new Point((int) 5gYn6JLpM[num2], top));
                                args1.Graphics.DrawString(cell.Value.ToString(), cell.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), new RectangleF((float) (((int) 5gYn6JLpM[num2]) + 1), (float) top, (float) (((int) J33Gvmr8S[num2]) - 0x10), (float) 8s1EDI5bT), JiYUNJcCW);
                            }
                            else if (((Type) fP4JOlhOm[num2]).Name == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4d82))
                            {
                                Rectangle rectangle = new Rectangle((int) 5gYn6JLpM[num2], top, (int) J33Gvmr8S[num2], 8s1EDI5bT);
                                Size size = ((Image) cell.FormattedValue).Size;
                                args1.Graphics.DrawImage((Image) cell.FormattedValue, new Rectangle(((int) 5gYn6JLpM[num2]) + ((rectangle.Width - size.Width) / 2), top + ((rectangle.Height - size.Height) / 2), ((Image) cell.FormattedValue).Width, ((Image) cell.FormattedValue).Height));
                            }
                        }
                        args1.Graphics.DrawRectangle(Pens.Black, new Rectangle((int) 5gYn6JLpM[num2], top, (int) J33Gvmr8S[num2], 8s1EDI5bT));
                        num2++;
                    }
                    top += 8s1EDI5bT;
                    3RGFtDsi0++;
                    if (S4k2CWq1J == 1)
                    {
                        TYCDm64fY++;
                    }
                }
                if (TYCDm64fY != 0)
                {
                    408MSTia8(args1, TYCDm64fY);
                    args1.HasMorePages = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4db4), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

