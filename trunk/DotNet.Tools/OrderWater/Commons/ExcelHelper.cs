namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Runtime.CompilerServices;

    public class ExcelHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public ExcelHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string connectstring)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string connectstring, string table)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string excelPath, bool header, ExcelType eType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataSet ExcelToDataSet(string excelPath, string table, bool header, ExcelType eType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelConnectstring(string excelPath, bool header, ExcelType eType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelConnectstring(string excelPath, bool header, ExcelType eType, IMEXType imex)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(OleDbConnection connection)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(string connectstring)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExcelFirstTableName(string excelPath, ExcelType eType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(OleDbConnection connection)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(string connectstring)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetExcelTablesName(string excelPath, ExcelType eType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool VZJq3SjrW(OleDbConnection connection1, string)
        {
            // Translated Error! Expression stack is empty at offset 0006.
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
