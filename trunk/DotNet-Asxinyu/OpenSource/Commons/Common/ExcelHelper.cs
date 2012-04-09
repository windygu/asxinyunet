namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class ExcelHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string connectstring)
        {
            using (OleDbConnection connection = new OleDbConnection(connectstring))
            {
                DataSet dataSet = new DataSet();
                List<string> excelTablesName = GetExcelTablesName(connection);
                foreach (string str in excelTablesName)
                {
                    new OleDbDataAdapter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf890) + str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf8b2), connection).Fill(dataSet, str);
                }
                return dataSet;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string connectstring, string table)
        {
            using (OleDbConnection connection = new OleDbConnection(connectstring))
            {
                DataSet dataSet = new DataSet();
                if (VZJq3SjrW(connection, table))
                {
                    new OleDbDataAdapter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf868) + table + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf88a), connection).Fill(dataSet, table);
                }
                return dataSet;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string excelPath, bool header, ExcelType eType)
        {
            return ExcelToDataSet(GetExcelConnectstring(excelPath, header, eType));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string excelPath, string table, bool header, ExcelType eType)
        {
            return ExcelToDataSet(GetExcelConnectstring(excelPath, header, eType), table);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelConnectstring(string excelPath, bool header, ExcelType eType)
        {
            return GetExcelConnectstring(excelPath, header, eType, IMEXType.ImportMode);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelConnectstring(string excelPath, bool header, ExcelType eType, IMEXType imex)
        {
            if (!DirectoryUtil.IsExistFile(excelPath))
            {
                throw new FileNotFoundException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf6a4));
            }
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf6be);
            if (header)
            {
                str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf6c6);
            }
            if (eType == ExcelType.Excel2003)
            {
                return string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf6d0), excelPath, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf730), str2, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf77e), imex.GetHashCode(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf790) });
            }
            return string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf796), excelPath, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf7f8), str2, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf850), imex.GetHashCode(), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf862) });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(OleDbConnection connection)
        {
            string str = string.Empty;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            DataTable oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if ((oleDbSchemaTable != null) && (oleDbSchemaTable.Rows.Count > 0))
            {
                str = ConvertHelper.ConvertTo<string>(oleDbSchemaTable.Rows[0][2]);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(string connectstring)
        {
            using (OleDbConnection connection = new OleDbConnection(connectstring))
            {
                return GetExcelFirstTableName(connection);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(string excelPath, ExcelType eType)
        {
            return GetExcelFirstTableName(GetExcelConnectstring(excelPath, true, eType));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(OleDbConnection connection)
        {
            List<string> list = new List<string>();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            DataTable oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if ((oleDbSchemaTable != null) && (oleDbSchemaTable.Rows.Count > 0))
            {
                for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
                {
                    list.Add(ConvertHelper.ConvertTo<string>(oleDbSchemaTable.Rows[i][2]));
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(string connectstring)
        {
            using (OleDbConnection connection = new OleDbConnection(connectstring))
            {
                return GetExcelTablesName(connection);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(string excelPath, ExcelType eType)
        {
            return GetExcelTablesName(GetExcelConnectstring(excelPath, true, eType));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool VZJq3SjrW(OleDbConnection connection1, string text1)
        {
            List<string> excelTablesName = GetExcelTablesName(connection1);
            foreach (string str in excelTablesName)
            {
                if (str.ToLower() == text1.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public enum ExcelType
        {
            Excel2003,
            Excel2007
        }

        public enum IMEXType
        {
            ExportMode,
            ImportMode,
            LinkedMode
        }
    }
}

