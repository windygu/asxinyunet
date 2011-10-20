namespace EntLib.Controls.WinForm
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public static class DataGridViewExportHelper
    {
        public static DataTable GetDataTable(this DataGridView dv)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < dv.Columns.Count; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = dv.Columns[i].HeaderText.ToString();
                dt.Columns.Add(dc);
            }
            for (int j = 0; j < dv.Rows.Count - 1; j++)
            {
                DataRow dr = dt.NewRow();
                for (int x = 0; x < dv.Columns.Count; x++)
                {
                    dr[x] = dv.Rows[j].Cells[x].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void ToCSV(this DataGridView dgv1) { dgv1.ToCSV("表格数据"); }

        public static void ToCSV(this DataGridView dgv1, string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "表格数据文件(*.csv)|*.csv";
            sfd.FileName = string.Format("{0}.csv", fileName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                ExportHelper.ExportDetails(dgv1.GetDataTable(), ExportHelper.ExportFormat.CSV, fileName, ExportHelper.ApplicationType.WindowsForm);
            }
        }

        public static void ToText(this DataGridView dgv1) { dgv1.ToText("表格数据"); }

        public static void ToText(this DataGridView dgv1, string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FileName = string.Format("{0}.txt", fileName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                ExportHelper.ExportDetails(dgv1.GetDataTable(), ExportHelper.ExportFormat.TXT, fileName, ExportHelper.ApplicationType.WindowsForm);
            }
        }

        public static void ToXLS(this DataGridView dgv1) { dgv1.ToXLS("表格数据"); }

        public static void ToXLS(this DataGridView dgv1, string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "电子表格数据文件(*.xls)|*.xls";
            sfd.FileName = string.Format("{0}.xls", fileName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                ExcelHelper.Export(dgv1.GetDataTable(), "dsgsdg", fileName);
            }
        }
    }
}
