namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class CSVHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable CSVToDataTableByOledb(string csvPath)
        {
            DataTable dataTable = new DataTable(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8b2c));
            if (!File.Exists(csvPath))
            {
                throw new FileNotFoundException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8b36));
            }
            FileInfo info = new FileInfo(csvPath);
            using (OleDbConnection connection = new OleDbConnection(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8b50) + info.DirectoryName + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8bae)))
            {
                new OleDbDataAdapter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8bea) + info.Name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c0c), connection).Fill(dataTable);
            }
            return dataTable;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable CSVToDataTableByStreamReader(string csvPath)
        {
            DataTable table = new DataTable(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c12));
            int length = 0;
            bool flag = true;
            string str = null;
            using (StreamReader reader = new StreamReader(csvPath, DirectoryUtil.GetEncoding(csvPath)))
            {
                while (!string.IsNullOrEmpty(str = reader.ReadLine()))
                {
                    int num2;
                    string[] strArray = str.Split(new char[] { ',' });
                    if (flag)
                    {
                        flag = false;
                        length = strArray.Length;
                        num2 = 0;
                        while (num2 < strArray.Length)
                        {
                            DataColumn column = new DataColumn(strArray[num2]);
                            table.Columns.Add(column);
                            num2++;
                        }
                    }
                    else
                    {
                        DataRow row = table.NewRow();
                        for (num2 = 0; num2 < length; num2++)
                        {
                            row[num2] = strArray[num2];
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DataTableToCSV(DataTable dt, string csvPath)
        {
            if (null != dt)
            {
                StringBuilder builder = new StringBuilder();
                StringBuilder builder2 = new StringBuilder();
                foreach (DataColumn column in dt.Columns)
                {
                    builder2.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c1c));
                    builder2.Append(column.ColumnName);
                }
                builder.AppendLine(builder2.ToString().Substring(1));
                foreach (DataRow row in dt.Rows)
                {
                    builder2 = new StringBuilder();
                    foreach (DataColumn column in dt.Columns)
                    {
                        builder2.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c22));
                        builder2.Append(row[column.ColumnName].ToString().Replace(',', ' '));
                    }
                    builder.AppendLine(builder2.ToString().Substring(1));
                }
                File.WriteAllText(csvPath, builder.ToString(), Encoding.Default);
            }
        }
    }
}

