namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;

    internal class PageCountPrintController : PreviewPrintController
    {
        private int pageCount;

        public static int GetPageCount(PrintDocument document)
        {
            if (document == null) throw new ArgumentNullException("打印前必须先设置好PrintDocument对象.");
            PrintController printController = document.PrintController;
            PageCountPrintController controller2 = new PageCountPrintController();
            document.PrintController = controller2;
            document.Print();
            document.PrintController = printController;
            return controller2.PageCount;
        }

        public override Graphics OnStartPage(PrintDocument document, PrintPageEventArgs e)
        {
            this.pageCount++;
            return base.OnStartPage(document, e);
        }

        public override void OnStartPrint(PrintDocument document, PrintEventArgs e)
        {
            base.OnStartPrint(document, e);
            this.pageCount = 0;
        }

        public int PageCount { get { return this.pageCount; } }
    }
}
