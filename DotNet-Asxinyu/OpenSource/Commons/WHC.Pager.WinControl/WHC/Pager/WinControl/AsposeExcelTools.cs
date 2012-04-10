namespace WHC.Pager.WinControl
{
    using Aspose.Cells;
    using System;
    using System.Collections;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;

    public class AsposeExcelTools
    {
        public static bool DataSetToExcel(DataSet dataset, string filepath, out string error)
        {
            if (DataTableToExcel(dataset.Tables[0], filepath, out error))
            {
                return true;
            }
            error = "DataTableToExcel: " + error;
            return false;
        }

        public static bool DataTableInsertToExcel(DataTable datatable, ArrayList colNameList, string fromfile, out string error, int beginRow, int beginColumn)
        {
            error = "";
            if (datatable == null)
            {
                error = "DataTableToExcel:datatable 为空";
                return false;
            }
            Workbook workbook = new Workbook();
            workbook.Open(fromfile);
            Aspose.Cells.Cells cells = workbook.get_Worksheets().get_Item(0).get_Cells();
            int num = 0;
            foreach (DataRow row in datatable.Rows)
            {
                num++;
                try
                {
                    cells.InsertRow(beginRow);
                    for (int i = 0; i < colNameList.Count; i++)
                    {
                        string str = colNameList[i].ToString();
                        int num3 = 0;
                        while (num3 < datatable.Columns.Count)
                        {
                            if (str == datatable.Columns[num3].ColumnName)
                            {
                                goto Label_00C4;
                            }
                            num3++;
                        }
                        continue;
                    Label_00C4:
                        object obj1 = row[datatable.Columns[num3].ColumnName];
                        cells.get_Item(beginRow, beginColumn + i).PutValue(row[datatable.Columns[num3].ColumnName]);
                    }
                    continue;
                }
                catch (Exception exception)
                {
                    error = error + " DataTableInsertToExcel: " + exception.Message;
                    continue;
                }
            }
            workbook.Save(fromfile);
            return true;
        }

        public static bool DataTableToExcel(DataTable datatable, string filepath, out string error)
        {
            Exception exception;
            error = "";
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.get_Worksheets().get_Item(0);
                Aspose.Cells.Cells cells = worksheet.get_Cells();
                int num = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    num++;
                    try
                    {
                        for (int i = 0; i < datatable.Columns.Count; i++)
                        {
                            if (row[i].GetType().ToString() == "System.Drawing.Bitmap")
                            {
                                Image image = (Image) row[i];
                                MemoryStream stream = new MemoryStream();
                                image.Save(stream, ImageFormat.Jpeg);
                                worksheet.get_Pictures().Add(num, i, stream);
                            }
                            else
                            {
                                cells.get_Item(num, i).PutValue(row[i]);
                            }
                        }
                        continue;
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        error = error + " DataTableToExcel: " + exception.Message;
                        continue;
                    }
                }
                workbook.Save(filepath);
                return true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                error = error + " DataTableToExcel: " + exception.Message;
                return false;
            }
        }

        public static bool DataTableToExcel2(DataTable datatable, string filepath, out string error)
        {
            error = "";
            Workbook workbook = new Workbook();
            try
            {
                if (datatable == null)
                {
                    error = "DataTableToExcel:datatable 为空";
                    return false;
                }
                Style style = workbook.get_Styles().get_Item(workbook.get_Styles().Add());
                style.set_HorizontalAlignment(1);
                style.set_ForegroundColor(Color.FromArgb(0x99, 0xcc, 0));
                style.set_Pattern(1);
                style.get_Font().set_IsBold(true);
                int num = 0;
                int num2 = 0;
                while (num2 < datatable.Columns.Count)
                {
                    DataColumn column = datatable.Columns[num2];
                    string str = column.Caption ?? column.ColumnName;
                    workbook.get_Worksheets().get_Item(0).get_Cells().get_Item(num, num2).PutValue(str);
                    workbook.get_Worksheets().get_Item(0).get_Cells().get_Item(num, num2).set_Style(style);
                    num2++;
                }
                num++;
                foreach (DataRow row in datatable.Rows)
                {
                    for (num2 = 0; num2 < datatable.Columns.Count; num2++)
                    {
                        workbook.get_Worksheets().get_Item(0).get_Cells().get_Item(num, num2).PutValue(row[num2].ToString());
                    }
                    num++;
                }
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    workbook.get_Worksheets().get_Item(0).AutoFitColumn(i, 0, 150);
                }
                workbook.get_Worksheets().get_Item(0).FreezePanes(1, 0, 1, datatable.Columns.Count);
                workbook.Save(filepath);
                return true;
            }
            catch (Exception exception)
            {
                error = error + " DataTableToExcel: " + exception.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataSet(string filepath, out DataSet dataset, out string error)
        {
            DataTable datatable = new DataTable();
            dataset = new DataSet();
            if (ExcelFileToDataTable(filepath, out datatable, out error))
            {
                dataset.Tables.Add(datatable);
                return true;
            }
            error = "ExcelFileToDataSet: " + error;
            return false;
        }

        public static bool ExcelFileToDataTable(string filepath, out DataTable datatable, out string error)
        {
            error = "";
            datatable = null;
            try
            {
                if (!File.Exists(filepath))
                {
                    error = "文件不存在";
                    datatable = null;
                    return false;
                }
                Workbook workbook = new Workbook();
                workbook.Open(filepath);
                Worksheet worksheet = workbook.get_Worksheets().get_Item(0);
                datatable = worksheet.get_Cells().ExportDataTable(0, 0, worksheet.get_Cells().get_MaxRow() + 1, worksheet.get_Cells().get_MaxColumn() + 1);
                Pictures pictures = worksheet.get_Pictures();
                if (pictures.Count > 0)
                {
                    string str = "";
                    if (!smethod_0(pictures, datatable, out datatable, out str))
                    {
                        error = error + str;
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataTable(string filepath, out DataTable datatable, int iFirstRow, int iFirstCol, int rowNum, int colNum, out string error)
        {
            error = "";
            datatable = null;
            try
            {
                if (!File.Exists(filepath))
                {
                    error = "文件不存在";
                    datatable = null;
                    return false;
                }
                Workbook workbook = new Workbook();
                workbook.Open(filepath);
                Worksheet worksheet = workbook.get_Worksheets().get_Item(0);
                datatable = worksheet.get_Cells().ExportDataTable(iFirstRow, iFirstCol, rowNum + 1, colNum + 1);
                return true;
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        public static bool ExcelFileToDataTables(string filepath, out DataTable[] datatables, out string error)
        {
            error = "";
            datatables = null;
            int count = 0;
            try
            {
                if (!File.Exists(filepath))
                {
                    error = "文件不存在";
                    datatables = null;
                    return false;
                }
                Workbook workbook = new Workbook();
                workbook.Open(filepath);
                count = workbook.get_Worksheets().Count;
                datatables = new DataTable[count];
                for (int i = 0; i < count; i++)
                {
                    Worksheet worksheet = workbook.get_Worksheets().get_Item(i);
                    datatables[i] = worksheet.get_Cells().ExportDataTable(0, 0, worksheet.get_Cells().get_MaxRow() + 1, worksheet.get_Cells().get_MaxColumn() + 1);
                    Pictures pictures = worksheet.get_Pictures();
                    if (pictures.Count > 0)
                    {
                        string str = "";
                        if (!smethod_0(pictures, datatables[i], out datatables[i], out str))
                        {
                            error = error + str;
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        public static bool ExcelFileToLists(string filepath, out IList[] lists, out string error)
        {
            Pictures[] picturesArray;
            error = "";
            lists = null;
            DataTable datatable = new DataTable();
            new ArrayList();
            if (ExcelFileToDataTable(filepath, out datatable, out error) && GetPicturesFromExcelFile(filepath, out picturesArray, out error))
            {
                int num2;
                lists = new ArrayList[datatable.Rows.Count];
                int index = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    lists[index] = new ArrayList(datatable.Columns.Count);
                    num2 = 0;
                    while (num2 <= (datatable.Columns.Count - 1))
                    {
                        lists[index].Add(row[num2]);
                        num2++;
                    }
                    index++;
                }
                for (num2 = 0; num2 < picturesArray.Length; num2++)
                {
                    foreach (Picture picture in picturesArray[num2])
                    {
                        try
                        {
                            if ((picture.get_UpperLeftRow() <= datatable.Rows.Count) && (picture.get_UpperLeftColumn() <= datatable.Columns.Count))
                            {
                                lists[picture.get_UpperLeftRow()][picture.get_UpperLeftColumn()] = picture.get_Data();
                            }
                            continue;
                        }
                        catch (Exception exception)
                        {
                            error = error + exception.Message;
                            continue;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static bool GetPicturesFromExcelFile(string filepath, out Pictures[] pictures, out string error)
        {
            error = "";
            pictures = null;
            try
            {
                if (!File.Exists(filepath))
                {
                    error = "文件不存在";
                    pictures = null;
                    return false;
                }
                Workbook workbook = new Workbook();
                workbook.Open(filepath);
                pictures = new Pictures[workbook.get_Worksheets().Count];
                for (int i = 0; i < workbook.get_Worksheets().Count; i++)
                {
                    pictures[i] = workbook.get_Worksheets().get_Item(i).get_Pictures();
                }
                return true;
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        public static bool ListsToExcelFile(string filepath, IList[] lists, out string error)
        {
            error = "";
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.get_Worksheets().get_Item(0);
            Aspose.Cells.Cells cells = worksheet.get_Cells();
            int num = 0;
            worksheet.get_Pictures().Clear();
            cells.Clear();
            IList[] listArray = lists;
            int index = 0;
        Label_003A:
            if (index < listArray.Length)
            {
                IList list = listArray[index];
                int num3 = 0;
                while (true)
                {
                    if (num3 <= (list.Count - 1))
                    {
                        try
                        {
                            Console.WriteLine(num3.ToString() + "  " + list[num3].GetType());
                            if (list[num3].GetType().ToString() == "System.Drawing.Bitmap")
                            {
                                Image image = (Image) list[num3];
                                MemoryStream stream = new MemoryStream();
                                image.Save(stream, ImageFormat.Jpeg);
                                worksheet.get_Pictures().Add(num, num3, stream);
                            }
                            else
                            {
                                cells.get_Item(num, num3).PutValue(list[num3]);
                            }
                        }
                        catch (Exception exception)
                        {
                            error = error + exception.Message;
                        }
                    }
                    else
                    {
                        num++;
                        index++;
                        goto Label_003A;
                    }
                    num3++;
                }
            }
            workbook.Save(filepath);
            return true;
        }

        private static bool smethod_0(Pictures pictures_0, DataTable dataTable_0, out DataTable dataTable_1, out string string_0)
        {
            string_0 = "";
            dataTable_1 = dataTable_0;
            DataRow[] rowArray = dataTable_1.Select();
            foreach (Picture picture in pictures_0)
            {
                try
                {
                    Console.WriteLine(picture.GetType().ToString());
                    MemoryStream stream = new MemoryStream();
                    stream.Write(picture.get_Data(), 0, picture.get_Data().Length);
                    Image image = Image.FromStream(stream);
                    rowArray[picture.get_UpperLeftRow()][picture.get_UpperLeftColumn()] = image;
                    continue;
                }
                catch (Exception exception)
                {
                    string_0 = string_0 + " InsertPicturesIntoDataTable: " + exception.Message;
                    continue;
                }
            }
            return true;
        }
    }
}

