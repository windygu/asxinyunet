namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct StatisticOptions
    {
        public bool PageStatistic;
        public bool TotalStatistic;
        public string StatisticColumn1;
        public string StatisticColumn2;
        public int PageRowCount;
        public decimal PageSum1;
        public decimal PageSum2;
        public int TotalRowCount;
        public decimal TotalSum1;
        public decimal TotalSum2;
    }
}
