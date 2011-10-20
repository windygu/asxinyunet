namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DGVCellDrawingEventArgs : EventArgs
    {
        public DataGridViewCellStyle CellStyle;
        public int column;
        public RectangleF DrawingBounds;
        public Graphics g;
        public bool Handled;
        public int row;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DGVCellDrawingEventArgs(Graphics g, RectangleF bounds, DataGridViewCellStyle style, int row, int column)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }
    }
}
