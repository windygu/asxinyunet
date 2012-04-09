namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Export2Excel
    {
        private Workbook 3Z7DfImqg;
        private Application B3iijjhhN;
        private Worksheet CTIK4BcXY;
        private Style DcoBAxjp6;
        private Style I5KTD7U71;
        private Sheets MmgpGXYpX;
        private List<DataView> niQkSxHZL;
        private int OMnsP7apO;
        private string[,] VU21tswKQ;

        public event ProgressHandler OnProgressHandler;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ExportToExcel(List<DataView> dvList, string path, string sheetName)
        {
            Exception exception2;
            try
            {
                int num;
                int num2;
                this.niQkSxHZL = dvList;
                this.B3iijjhhN = new ApplicationClass();
                if (File.Exists(path))
                {
                    this.3Z7DfImqg = this.B3iijjhhN.get_Workbooks().Open(path, 0, false, 5, "", "", false, (XlPlatform) 2, "", true, false, 0, true, false, false);
                    this.MmgpGXYpX = this.3Z7DfImqg.get_Sheets();
                    num = -1;
                    for (num2 = 1; num2 <= this.MmgpGXYpX.get_Count(); num2++)
                    {
                        this.CTIK4BcXY = (Worksheet) this.MmgpGXYpX.get_Item(num2);
                        if (this.CTIK4BcXY.get_Name().ToString().Equals(sheetName))
                        {
                            num = num2;
                            Range range = this.CTIK4BcXY.get_Cells();
                            range.Select();
                            range.get_CurrentRegion().Select();
                            range.ClearContents();
                        }
                    }
                    if (num == -1)
                    {
                        ((Worksheet) this.3Z7DfImqg.get_Sheets().Add(Type.Missing, (Worksheet) this.MmgpGXYpX.get_Item(this.MmgpGXYpX.get_Count()), Type.Missing, Type.Missing)).set_Name(sheetName);
                    }
                }
                else
                {
                    this.3Z7DfImqg = this.B3iijjhhN.get_Workbooks().Add((XlWBATemplate) (-4167));
                    this.MmgpGXYpX = this.3Z7DfImqg.get_Sheets();
                    this.CTIK4BcXY = (Worksheet) this.MmgpGXYpX.get_Item(1);
                    this.CTIK4BcXY.set_Name(sheetName);
                }
                this.MmgpGXYpX = this.3Z7DfImqg.get_Sheets();
                num = -1;
                for (num2 = 1; num2 <= this.MmgpGXYpX.get_Count(); num2++)
                {
                    this.CTIK4BcXY = (Worksheet) this.MmgpGXYpX.get_Item(num2);
                    if (this.CTIK4BcXY.get_Name().ToString().Equals(sheetName))
                    {
                        num = num2;
                    }
                }
                this.CTIK4BcXY = (Worksheet) this.MmgpGXYpX.get_Item(num);
                this.qCpqRb2bV();
                this.r4vfcKJvu();
                this.yT4VNh4qe();
                try
                {
                    this.m7HRrMhfC(this.MmgpGXYpX);
                    this.m7HRrMhfC(this.CTIK4BcXY);
                    this.3Z7DfImqg.Close(true, path, Type.Missing);
                    this.m7HRrMhfC(this.3Z7DfImqg);
                    this.B3iijjhhN.set_UserControl(false);
                    this.B3iijjhhN.Quit();
                    this.m7HRrMhfC(this.B3iijjhhN);
                    this.nBCwVbEfB();
                    ProgressEventArgs e = new ProgressEventArgs(100);
                    this.OnProgressChange(e);
                }
                catch (COMException)
                {
                    MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe93a));
                }
                catch (Exception exception3)
                {
                    exception2 = exception3;
                    MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe9ac) + exception2.Message);
                }
            }
            catch (Exception exception4)
            {
                exception2 = exception4;
                MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe9bc) + exception2.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ExportToExcel(DataView dv, string path, string sheetName)
        {
            List<DataView> list2 = new List<DataView> {
                dv
            };
            List<DataView> dvList = list2;
            this.ExportToExcel(dvList, path, sheetName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void k1mUM9ocK()
        {
            float num = 80f;
            float num2 = 100f;
            float num3 = 100f;
            int[] numArray = new int[2];
            Shape[] shapeArray = new Shape[numArray.Length];
            try
            {
                for (int i = 0; i < numArray.Length; i++)
                {
                    shapeArray[i] = this.CTIK4BcXY.get_Shapes().AddTextEffect(MsoPresetTextEffect.msoTextEffect1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb00), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb0e), num, MsoTriState.msoFalse, MsoTriState.msoFalse, num2 * (i * 3), num3);
                    shapeArray[i].set_Rotation(45f);
                    shapeArray[i].get_Fill().set_Visible(MsoTriState.msoFalse);
                    shapeArray[i].get_Fill().set_Transparency(0f);
                    shapeArray[i].get_Line().set_Weight(1.75f);
                    shapeArray[i].get_Line().set_DashStyle(MsoLineDashStyle.msoLineSolid);
                    shapeArray[i].get_Line().set_Transparency(0f);
                    shapeArray[i].get_Line().set_Visible(MsoTriState.msoTrue);
                    shapeArray[i].get_Line().get_ForeColor().set_RGB(0);
                    shapeArray[i].get_Line().get_BackColor().set_RGB(0xffffff);
                }
            }
            catch (Exception)
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void m7HRrMhfC(object obj1)
        {
            try
            {
                Marshal.ReleaseComObject(obj1);
            }
            catch
            {
            }
            finally
            {
                obj1 = null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MnvNdaLNh(Worksheet worksheet1, int num1, int num2, object obj1, string text1)
        {
            Range range = (Range) worksheet1.get_Cells().get__Default(num1, num2);
            range.Select();
            range.set_Value2(obj1.ToString());
            range.set_Style(text1);
            range.get_Columns().get_EntireColumn().AutoFit();
            range.get_Borders().set_Weight((XlBorderWeight) 2);
            range.get_Borders().set_LineStyle((XlLineStyle) 1);
            range.get_Borders().set_ColorIndex((XlColorIndex) (-4105));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void nBCwVbEfB()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.ToLower().Equals(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb28)))
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb36) + exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void OnProgressChange(ProgressEventArgs e)
        {
            if (this.IqGhetOq2 != null)
            {
                this.IqGhetOq2(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void qCpqRb2bV()
        {
            try
            {
                this.I5KTD7U71 = this.3Z7DfImqg.get_Styles().get__Default(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xea64));
            }
            catch
            {
                this.I5KTD7U71 = this.3Z7DfImqg.get_Styles().Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xea8e), Type.Missing);
                this.I5KTD7U71.get_Font().set_Name(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeab8));
                this.I5KTD7U71.get_Font().set_Size(14);
                this.I5KTD7U71.get_Font().set_Color(0xffffff);
                this.I5KTD7U71.get_Interior().set_Color(0);
                this.I5KTD7U71.get_Interior().set_Pattern((XlPattern) 1);
            }
            try
            {
                this.DcoBAxjp6 = this.3Z7DfImqg.get_Styles().get__Default(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeac6));
            }
            catch
            {
                this.DcoBAxjp6 = this.3Z7DfImqg.get_Styles().Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeadc), Type.Missing);
                this.DcoBAxjp6.get_Font().set_Name(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeaf2));
                this.DcoBAxjp6.get_Font().set_Size(10);
                this.DcoBAxjp6.get_Font().set_Color(0);
                this.DcoBAxjp6.get_Interior().set_Color(0xc0c0c0);
                this.DcoBAxjp6.get_Interior().set_Pattern((XlPattern) 1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void r4vfcKJvu()
        {
            this.OMnsP7apO = 0;
            int num = 1;
            int num2 = 1;
            int num3 = 1;
            int num4 = 0;
            foreach (DataView view in this.niQkSxHZL)
            {
                num4 += view.Count + 1;
            }
            foreach (DataView view in this.niQkSxHZL)
            {
                int num5 = 0;
                while (num5 < view.Table.Columns.Count)
                {
                    this.MnvNdaLNh(this.CTIK4BcXY, num, num2++, view.Table.Columns[num5].ToString(), this.I5KTD7U71.get_Name());
                    num5++;
                }
                num++;
                num2 = 1;
                num3++;
                for (num5 = 0; num5 < view.Table.Rows.Count; num5++)
                {
                    for (int i = 0; i < view.Table.Columns.Count; i++)
                    {
                        this.MnvNdaLNh(this.CTIK4BcXY, num, num2++, view[num5][i].ToString(), this.DcoBAxjp6.get_Name());
                    }
                    this.OMnsP7apO = (100 * num3) / num4;
                    ProgressEventArgs e = new ProgressEventArgs(this.OMnsP7apO);
                    this.OnProgressChange(e);
                    num2 = 1;
                    num++;
                    num3++;
                }
                num += 2;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void snJo0QVxt()
        {
            int num = 3;
            int num2 = 2;
            this.OMnsP7apO = 0;
            for (int i = 0; i <= this.VU21tswKQ.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= this.VU21tswKQ.GetUpperBound(1); j++)
                {
                    this.OMnsP7apO = (100 / this.VU21tswKQ.Length) * i;
                    ProgressEventArgs e = new ProgressEventArgs(this.OMnsP7apO);
                    this.OnProgressChange(e);
                    Range range = (Range) this.CTIK4BcXY.get_Cells().get__Default(num, num2++);
                    range.Select();
                    range.set_Value2(this.VU21tswKQ[i, j].ToString());
                    range.get_Rows().get_EntireRow().AutoFit();
                }
                num2 = 2;
                num++;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void UseTemplate(string path, string templatePath, string[,] myTemplateValues)
        {
            try
            {
                this.VU21tswKQ = myTemplateValues;
                this.B3iijjhhN = new ApplicationClass();
                this.3Z7DfImqg = this.B3iijjhhN.get_Workbooks().Open(templatePath, 0, false, 5, "", "", false, (XlPlatform) 2, "", true, false, 0, true, false, false);
                this.MmgpGXYpX = this.3Z7DfImqg.get_Sheets();
                this.CTIK4BcXY = (Worksheet) this.MmgpGXYpX.get_Item(1);
                this.CTIK4BcXY.set_Name(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe9cc));
                this.snJo0QVxt();
                this.yT4VNh4qe();
                try
                {
                    this.m7HRrMhfC(this.MmgpGXYpX);
                    this.m7HRrMhfC(this.CTIK4BcXY);
                    this.3Z7DfImqg.Close(true, path, Type.Missing);
                    this.m7HRrMhfC(this.3Z7DfImqg);
                    this.B3iijjhhN.set_UserControl(false);
                    this.B3iijjhhN.Quit();
                    this.m7HRrMhfC(this.B3iijjhhN);
                    this.nBCwVbEfB();
                    ProgressEventArgs e = new ProgressEventArgs(100);
                    this.OnProgressChange(e);
                }
                catch (COMException)
                {
                    Console.WriteLine(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe9e2));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xea54) + exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void yT4VNh4qe()
        {
            Range range = this.CTIK4BcXY.get_Cells();
            range.Select();
            range.get_CurrentRegion().Select();
        }

        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
    }
}

