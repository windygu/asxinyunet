namespace EntLib.Controls.WinForm
{
    using NPOI.HPSF;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.SS.Util;
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Web;

    public class ExcelHelper
    {
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            Sheet sheet = workbook.CreateSheet();
            CellStyle bodyStyle = SetBodyStyle(workbook);
            CellStyle bodyHeaderStyle = SetBodyHeaderStyle(workbook);
            workbook.SummaryInformation = SetSummaryInfo(workbook, strHeaderText);
            CellStyle dateStyle = workbook.CreateCellStyle();
            dateStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(0x3a8).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(0x3a8).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j]) arrColWidth[j] = intTemp;
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                switch (rowIndex)
                {
                    case 0xffff:
                    case 0:
                    {
                        if (rowIndex != 0) sheet = workbook.CreateSheet();
                        Row headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25f;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        CellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.CENTER;
                        Font font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 0x4b0;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        Row headerRow = sheet.CreateRow(1);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = bodyHeaderStyle;
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 0x100);
                        }
                        rowIndex = 2;
                        break;
                    }
                }
                Row dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    Cell newCell = dataRow.CreateCell(column.Ordinal);
                    newCell.CellStyle = bodyStyle;
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String":
                        {
                            newCell.SetCellValue(drValue);
                            continue;
                        }
                        case "System.DateTime":
                        {
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);
                            newCell.CellStyle = dateStyle;
                            continue;
                        }
                        case "System.Boolean":
                        {
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            continue;
                        }
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                        {
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue((double) intV);
                            continue;
                        }
                        case "System.Decimal":
                        case "System.Double":
                        {
                            double doubV = 0.0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            continue;
                        }
                        case "System.DBNull":
                        {
                            newCell.SetCellValue("");
                            continue;
                        }
                    }
                    newCell.SetCellValue("");
                }
                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet.IsPrintGridlines = true;
                sheet.Dispose();
                return ms;
            }
        }

        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
            curContext.Response.End();
        }

        public static DataTable Import(string strFileName)
        {
            HSSFWorkbook hssfworkbook;
            DataTable dt = new DataTable();
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            Sheet sheet = hssfworkbook.GetSheetAt(0);
            sheet.GetRowEnumerator();
            Row headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                Cell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                Row row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null) dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        private static Font SetBodyFont(HSSFWorkbook workbook, bool IsBold)
        {
            Font bodyFont = workbook.CreateFont();
            bodyFont.FontHeightInPoints = 9;
            bodyFont.FontName = "宋体";
            if (IsBold)
            {
                bodyFont.Boldweight = 700;
                return bodyFont;
            }
            bodyFont.Boldweight = 400;
            return bodyFont;
        }

        private static CellStyle SetBodyHeaderStyle(HSSFWorkbook workbook) { return SetBodyStyle(workbook, SetBodyFont(workbook, true)); }

        private static CellStyle SetBodyStyle(HSSFWorkbook workbook) { return SetBodyStyle(workbook, SetBodyFont(workbook, false)); }

        private static CellStyle SetBodyStyle(HSSFWorkbook workbook, Font bodyFont)
        {
            CellStyle bodyStyle = workbook.CreateCellStyle();
            bodyStyle.Alignment = HorizontalAlignment.CENTER;
            bodyStyle.VerticalAlignment = VerticalAlignment.CENTER;
            bodyStyle.ShrinkToFit = true;
            bodyStyle.WrapText = true;
            bodyStyle.SetFont(bodyFont);
            bodyStyle.BorderBottom = CellBorderType.THIN;
            bodyStyle.BorderLeft = CellBorderType.THIN;
            bodyStyle.BorderRight = CellBorderType.THIN;
            bodyStyle.BorderTop = CellBorderType.THIN;
            return bodyStyle;
        }

        private static SummaryInformation SetSummaryInfo(HSSFWorkbook workbook, string strHeaderText)
        {
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "   ";
            workbook.DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = "hfmedical";
            si.ApplicationName = "NPOI测试程序";
            si.LastAuthor = "hfmedical2";
            si.Comments = strHeaderText;
            si.Title = strHeaderText;
            si.Subject = strHeaderText;
            si.CreateDateTime = new DateTime?(DateTime.Now);
            workbook.SummaryInformation = si;
            return si;
        }
    }
}
