namespace EntLib.Controls.WinForm
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    public class ExportHelper
    {
        private static void CreateStylesheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds, ExportFormat FormatType)
        {
            try
            {
                string ns = "http://www.w3.org/1999/XSL/Transform";
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("xsl", "stylesheet", ns);
                writer.WriteAttributeString("version", "1.0");
                writer.WriteStartElement("xsl:output");
                writer.WriteAttributeString("method", "text");
                writer.WriteAttributeString("version", "4.0");
                writer.WriteEndElement();
                writer.WriteStartElement("xsl:template");
                writer.WriteAttributeString("match", "/");
                for (int i = 0; i < sHeaders.Length; i++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", "'" + sHeaders[i] + "'");
                    writer.WriteEndElement();
                    writer.WriteString("\"");
                    if (i != sFileds.Length - 1) writer.WriteString((FormatType == ExportFormat.CSV) ? "," : "    ");
                }
                writer.WriteStartElement("xsl:for-each");
                writer.WriteAttributeString("select", "Export/Values");
                writer.WriteString("\r\n");
                for (int i = 0; i < sFileds.Length; i++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", sFileds[i]);
                    writer.WriteEndElement();
                    writer.WriteString("\"");
                    if (i != sFileds.Length - 1) writer.WriteString((FormatType == ExportFormat.CSV) ? "," : "    ");
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private static void Export_with_XSLT_Web(DataSet dsExport, string[] sHeaders, string[] sFileds, ExportFormat FormatType, string FileName)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = string.Format("text/{0}", FormatType.ToString().ToLower());
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.{1}", FileName, FormatType.ToString().ToLower()));
                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Default);
                CreateStylesheet(writer, sHeaders, sFileds, FormatType);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                XmlDataDocument xmlDoc = new XmlDataDocument(dsExport);
                XslCompiledTransform xslTran = new XslCompiledTransform();
                xslTran.Load(new XmlTextReader(stream));
                StringWriter sw = new StringWriter();
                xslTran.Transform((IXPathNavigable) xmlDoc, null, (TextWriter) sw);
                HttpContext.Current.Response.Write(sw.ToString());
                sw.Close();
                writer.Close();
                stream.Close();
                HttpContext.Current.Response.End();
            }
            catch (ThreadAbortException Ex)
            {
                string message = Ex.Message;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private static void Export_with_XSLT_Windows(DataSet dsExport, string[] sHeaders, string[] sFileds, ExportFormat FormatType, string FileName)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                CreateStylesheet(writer, sHeaders, sFileds, FormatType);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                XmlDataDocument xmlDoc = new XmlDataDocument(dsExport);
                XslCompiledTransform xslTran = new XslCompiledTransform();
                xslTran.Load(new XmlTextReader(stream));
                StringWriter sw = new StringWriter();
                xslTran.Transform((IXPathNavigable) xmlDoc, null, (TextWriter) sw);
                StreamWriter strwriter = new StreamWriter(FileName, false, Encoding.Default);
                strwriter.WriteLine(sw.ToString());
                strwriter.Close();
                sw.Close();
                writer.Close();
                stream.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void ExportDetails(DataTable dt, string fileName, ApplicationType ApplicationType) { ExportDetails(dt, ExportFormat.CSV, fileName, ApplicationType); }

        public static void ExportDetails(DataTable DetailsTable, ExportFormat FormatType, string FileName, ApplicationType ApplicationType)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0) throw new Exception("There are no details to export.");
                DataSet dsExport = new DataSet("Export");
                DataTable dtExport = DetailsTable.Copy();
                dtExport.TableName = "Values";
                dsExport.Tables.Add(dtExport);
                string[] sHeaders = new string[dtExport.Columns.Count];
                string[] sFileds = new string[dtExport.Columns.Count];
                for (int i = 0; i < dtExport.Columns.Count; i++)
                {
                    sHeaders[i] = dtExport.Columns[i].ColumnName;
                    sFileds[i] = ReplaceSpecialChars(dtExport.Columns[i].ColumnName);
                }
                if (ApplicationType == ExportHelper.ApplicationType.Web)
                    Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                else if (ApplicationType == ExportHelper.ApplicationType.WindowsForm) Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ExportDetails(DataTableCollection DetailsTables, ExportFormat FormatType, string FileName, ApplicationType ApplicationType)
        {
            try
            {
                foreach (DataTable DetailsTable in DetailsTables)
                {
                    if (DetailsTable.Rows.Count == 0) throw new Exception("There are no details to export.");
                    string NewFileName = (FileName.Substring(0, FileName.LastIndexOf(".")) + " - " + DetailsTable.TableName) + FileName.Substring(FileName.LastIndexOf("."));
                    DataSet dsExport = new DataSet("Export");
                    DataTable dtExport = DetailsTable.Copy();
                    dtExport.TableName = "Values";
                    dsExport.Tables.Add(dtExport);
                    string[] sHeaders = new string[dtExport.Columns.Count];
                    string[] sFileds = new string[dtExport.Columns.Count];
                    for (int i = 0; i < dtExport.Columns.Count; i++)
                    {
                        sHeaders[i] = dtExport.Columns[i].ColumnName;
                        sFileds[i] = ReplaceSpecialChars(dtExport.Columns[i].ColumnName);
                    }
                    if (ApplicationType == ExportHelper.ApplicationType.Web)
                        Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                    else if (ApplicationType == ExportHelper.ApplicationType.WindowsForm) Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void ExportDetails(DataTable DetailsTable, int[] ColumnList, ExportFormat FormatType, string FileName, ApplicationType ApplicationType)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0) throw new Exception("There are no details to export");
                DataSet dsExport = new DataSet("Export");
                DataTable dtExport = DetailsTable.Copy();
                dtExport.TableName = "Values";
                dsExport.Tables.Add(dtExport);
                if (ColumnList.Length > dtExport.Columns.Count) throw new Exception("ExportColumn List should not exceed Total Columns");
                string[] sHeaders = new string[ColumnList.Length];
                string[] sFileds = new string[ColumnList.Length];
                for (int i = 0; i < ColumnList.Length; i++)
                {
                    if (ColumnList[i] < 0 || ColumnList[i] >= dtExport.Columns.Count) throw new Exception("ExportColumn Number should not exceed Total Columns Range");
                    sHeaders[i] = dtExport.Columns[ColumnList[i]].ColumnName;
                    sFileds[i] = ReplaceSpecialChars(dtExport.Columns[ColumnList[i]].ColumnName);
                }
                if (ApplicationType == ExportHelper.ApplicationType.Web)
                    Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                else if (ApplicationType == ExportHelper.ApplicationType.WindowsForm) Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void ExportDetails(DataTable DetailsTable, int[] ColumnList, string[] sHeaders, ExportFormat FormatType, string FileName, ApplicationType ApplicationType)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0) throw new Exception("There are no details to export");
                DataSet dsExport = new DataSet("Export");
                DataTable dtExport = DetailsTable.Copy();
                dtExport.TableName = "Values";
                dsExport.Tables.Add(dtExport);
                if (ColumnList.Length != sHeaders.Length) throw new Exception("ExportColumn List and Headers List should be of same length");
                if (ColumnList.Length > dtExport.Columns.Count || sHeaders.Length > dtExport.Columns.Count) throw new Exception("ExportColumn List should not exceed Total Columns");
                string[] sFileds = new string[ColumnList.Length];
                for (int i = 0; i < ColumnList.Length; i++)
                {
                    if (ColumnList[i] < 0 || ColumnList[i] >= dtExport.Columns.Count) throw new Exception("ExportColumn Number should not exceed Total Columns Range");
                    sFileds[i] = ReplaceSpecialChars(dtExport.Columns[ColumnList[i]].ColumnName);
                }
                if (ApplicationType == ExportHelper.ApplicationType.Web)
                    Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                else if (ApplicationType == ExportHelper.ApplicationType.WindowsForm) Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void ExportDetails(DataTable DetailsTable, string[] columnNameList, string[] sHeaders, ExportFormat FormatType, string FileName, ApplicationType ApplicationType)
        {
            List<int> columnIndexList = new List<int>();
            DataColumnCollection dcc = DetailsTable.Columns;
            foreach (string s in columnNameList)
            {
                columnIndexList.Add(GetColumnIndexByColumnName(dcc, s));
            }
            ExportDetails(DetailsTable, columnIndexList.ToArray(), sHeaders, FormatType, FileName, ApplicationType);
        }

        public static int GetColumnIndexByColumnName(DataColumnCollection dcc, string columnName)
        {
            for (int i = 0; i < dcc.Count; i++)
            {
                if (dcc[i].ColumnName.ToLower() == columnName.ToLower()) return i;
            }
            return -1;
        }

        public static string ReplaceSpecialChars(string input)
        {
            input = input.Replace(" ", "_x0020_").Replace("%", "_x0025_").Replace("#", "_x0023_").Replace("&", "_x0026_").Replace("/", "_x002F_");
            return input;
        }

        public enum ApplicationType
        {
            WindowsForm,
            Web
        }

        public enum ExportFormat
        {
            XLS,
            CSV,
            DOC,
            TXT,
            Pdf
        }
    }
}
