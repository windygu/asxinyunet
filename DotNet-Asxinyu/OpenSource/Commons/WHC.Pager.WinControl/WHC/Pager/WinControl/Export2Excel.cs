namespace WHC.Pager.WinControl
{
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
        private Application application_0;
        private int int_0;
        private List<DataView> list_0;
        private Sheets sheets_0;
        private string[,] string_0;
        private Style style_0;
        private Style style_1;
        private Workbook workbook_0;
        private Worksheet worksheet_0;

        public event ProgressHandler OnProgressHandler;

        public void ExportToExcel(List<DataView> dvList, string path, string sheetName)
        {
            Exception exception;
            try
            {
                int num;
                int num2;
                this.list_0 = dvList;
                this.application_0 = new ApplicationClass();
                if (File.Exists(path))
                {
                    this.workbook_0 = this.application_0.get_Workbooks().Open(path, 0, false, 5, "", "", false, (XlPlatform) 2, "", true, false, 0, true, false, false);
                    this.sheets_0 = this.workbook_0.get_Sheets();
                    num = -1;
                    for (num2 = 1; num2 <= this.sheets_0.get_Count(); num2++)
                    {
                        this.worksheet_0 = (Worksheet) this.sheets_0.get_Item(num2);
                        if (this.worksheet_0.get_Name().ToString().Equals(sheetName))
                        {
                            num = num2;
                            Range range = this.worksheet_0.get_Cells();
                            range.Select();
                            range.get_CurrentRegion().Select();
                            range.ClearContents();
                        }
                    }
                    if (num == -1)
                    {
                        ((Worksheet) this.workbook_0.get_Sheets().Add(Type.Missing, (Worksheet) this.sheets_0.get_Item(this.sheets_0.get_Count()), Type.Missing, Type.Missing)).set_Name(sheetName);
                    }
                }
                else
                {
                    this.workbook_0 = this.application_0.get_Workbooks().Add((XlWBATemplate) (-4167));
                    this.sheets_0 = this.workbook_0.get_Sheets();
                    this.worksheet_0 = (Worksheet) this.sheets_0.get_Item(1);
                    this.worksheet_0.set_Name(sheetName);
                }
                this.sheets_0 = this.workbook_0.get_Sheets();
                num = -1;
                for (num2 = 1; num2 <= this.sheets_0.get_Count(); num2++)
                {
                    this.worksheet_0 = (Worksheet) this.sheets_0.get_Item(num2);
                    if (this.worksheet_0.get_Name().ToString().Equals(sheetName))
                    {
                        num = num2;
                    }
                }
                this.worksheet_0 = (Worksheet) this.sheets_0.get_Item(num);
                this.method_0();
                this.method_1();
                this.method_4();
                try
                {
                    this.method_7(this.sheets_0);
                    this.method_7(this.worksheet_0);
                    this.workbook_0.Close(true, path, Type.Missing);
                    this.method_7(this.workbook_0);
                    this.application_0.set_UserControl(false);
                    this.application_0.Quit();
                    this.method_7(this.application_0);
                    this.method_6();
                    ProgressEventArgs e = new ProgressEventArgs(100);
                    this.OnProgressChange(e);
                }
                catch (COMException)
                {
                    MessageBox.Show("用户手动关闭了Excel程序，导出操作不成功");
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    MessageBox.Show("错误 " + exception.Message);
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                MessageBox.Show("错误 " + exception.Message);
            }
        }

        public void ExportToExcel(DataView dv, string path, string sheetName)
        {
            List<DataView> dvList = new List<DataView> {
                dv
            };
            this.ExportToExcel(dvList, path, sheetName);
        }

        private void method_0()
        {
            try
            {
                this.style_1 = this.workbook_0.get_Styles().get__Default("styleColumnHeadings");
            }
            catch
            {
                this.style_1 = this.workbook_0.get_Styles().Add("styleColumnHeadings", Type.Missing);
                this.style_1.get_Font().set_Name("Arial");
                this.style_1.get_Font().set_Size(14);
                this.style_1.get_Font().set_Color(0xffffff);
                this.style_1.get_Interior().set_Color(0);
                this.style_1.get_Interior().set_Pattern((XlPattern) 1);
            }
            try
            {
                this.style_0 = this.workbook_0.get_Styles().get__Default("styleRows");
            }
            catch
            {
                this.style_0 = this.workbook_0.get_Styles().Add("styleRows", Type.Missing);
                this.style_0.get_Font().set_Name("Arial");
                this.style_0.get_Font().set_Size(10);
                this.style_0.get_Font().set_Color(0);
                this.style_0.get_Interior().set_Color(0xc0c0c0);
                this.style_0.get_Interior().set_Pattern((XlPattern) 1);
            }
        }

        private void method_1()
        {
            this.int_0 = 0;
            int num = 1;
            int num2 = 1;
            int num3 = 1;
            int num4 = 0;
            foreach (DataView view in this.list_0)
            {
                num4 += view.Count + 1;
            }
            foreach (DataView view in this.list_0)
            {
                int num5 = 0;
                while (num5 < view.Table.Columns.Count)
                {
                    this.method_2(this.worksheet_0, num, num2++, view.Table.Columns[num5].ToString(), this.style_1.get_Name());
                    num5++;
                }
                num++;
                num2 = 1;
                num3++;
                for (num5 = 0; num5 < view.Table.Rows.Count; num5++)
                {
                    for (int i = 0; i < view.Table.Columns.Count; i++)
                    {
                        this.method_2(this.worksheet_0, num, num2++, view[num5][i].ToString(), this.style_0.get_Name());
                    }
                    this.int_0 = (100 * num3) / num4;
                    ProgressEventArgs e = new ProgressEventArgs(this.int_0);
                    this.OnProgressChange(e);
                    num2 = 1;
                    num++;
                    num3++;
                }
                num += 2;
            }
        }

        private void method_2(Worksheet worksheet_1, int int_1, int int_2, object object_0, string string_1)
        {
            Range range = (Range) worksheet_1.get_Cells().get__Default(int_1, int_2);
            range.Select();
            range.set_NumberFormat("@");
            range.set_Value2(object_0.ToString());
            range.set_Style(string_1);
            range.get_Columns().get_EntireColumn().AutoFit();
            range.get_Borders().set_Weight((XlBorderWeight) 2);
            range.get_Borders().set_LineStyle((XlLineStyle) 1);
            range.get_Borders().set_ColorIndex((XlColorIndex) (-4105));
        }

        private void method_3()
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
                    shapeArray[i] = this.worksheet_0.get_Shapes().AddTextEffect(0, "DRAFT", "Arial Black", num, 0, 0, num2 * (i * 3), num3);
                    shapeArray[i].set_Rotation(45f);
                    shapeArray[i].get_Fill().set_Visible(0);
                    shapeArray[i].get_Fill().set_Transparency(0f);
                    shapeArray[i].get_Line().set_Weight(1.75f);
                    shapeArray[i].get_Line().set_DashStyle(1);
                    shapeArray[i].get_Line().set_Transparency(0f);
                    shapeArray[i].get_Line().set_Visible(-1);
                    shapeArray[i].get_Line().get_ForeColor().set_RGB(0);
                    shapeArray[i].get_Line().get_BackColor().set_RGB(0xffffff);
                }
            }
            catch (Exception)
            {
            }
        }

        private void method_4()
        {
            Range range = this.worksheet_0.get_Cells();
            range.Select();
            range.get_CurrentRegion().Select();
        }

        private void method_5()
        {
            int num = 3;
            int num2 = 2;
            this.int_0 = 0;
            for (int i = 0; i <= this.string_0.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= this.string_0.GetUpperBound(1); j++)
                {
                    this.int_0 = (100 / this.string_0.Length) * i;
                    ProgressEventArgs e = new ProgressEventArgs(this.int_0);
                    this.OnProgressChange(e);
                    Range range = (Range) this.worksheet_0.get_Cells().get__Default(num, num2++);
                    range.Select();
                    range.set_NumberFormat("@");
                    range.set_Value2(this.string_0[i, j].ToString());
                    range.get_Rows().get_EntireRow().AutoFit();
                }
                num2 = 2;
                num++;
            }
        }

        private void method_6()
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower().Equals("excel"))
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误 " + exception.Message);
            }
        }

        private void method_7(object object_0)
        {
            try
            {
                Marshal.ReleaseComObject(object_0);
            }
            catch
            {
            }
            finally
            {
                object_0 = null;
            }
        }

        public virtual void OnProgressChange(ProgressEventArgs e)
        {
            if (this.progressHandler_0 != null)
            {
                this.progressHandler_0(this, e);
            }
        }

        public void UseTemplate(string path, string templatePath, string[,] myTemplateValues)
        {
            try
            {
                this.string_0 = myTemplateValues;
                this.application_0 = new ApplicationClass();
                this.workbook_0 = this.application_0.get_Workbooks().Open(templatePath, 0, false, 5, "", "", false, (XlPlatform) 2, "", true, false, 0, true, false, false);
                this.sheets_0 = this.workbook_0.get_Sheets();
                this.worksheet_0 = (Worksheet) this.sheets_0.get_Item(1);
                this.worksheet_0.set_Name("ATemplate");
                this.method_5();
                this.method_4();
                try
                {
                    this.method_7(this.sheets_0);
                    this.method_7(this.worksheet_0);
                    this.workbook_0.Close(true, path, Type.Missing);
                    this.method_7(this.workbook_0);
                    this.application_0.set_UserControl(false);
                    this.application_0.Quit();
                    this.method_7(this.application_0);
                    this.method_6();
                    ProgressEventArgs e = new ProgressEventArgs(100);
                    this.OnProgressChange(e);
                }
                catch (COMException)
                {
                    Console.WriteLine("用户手动关闭了Excel程序，导出操作不成功");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误 " + exception.Message);
            }
        }

        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
    }
}

