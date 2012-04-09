namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SortableListView : ListView
    {
        private Bitmap Dr0wrInQN;
        private Bitmap MEWIXKqxt;
        private int mNaPlOfPN = 1;
        private int XHHQ5xBgx = 0;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SortableListView()
        {
            if (this.MEWIXKqxt != null)
            {
                this.MEWIXKqxt.MakeTransparent(Color.Magenta);
            }
            if (this.Dr0wrInQN != null)
            {
                this.Dr0wrInQN.MakeTransparent(Color.Magenta);
            }
            base.BorderStyle = BorderStyle.None;
            this.Dock = DockStyle.Fill;
            base.FullRowSelect = true;
            base.HideSelection = false;
            base.LabelEdit = true;
            base.LabelWrap = false;
            base.View = View.Details;
            base.Sorting = SortOrder.None;
            base.AllowColumnReorder = true;
            base.OwnerDraw = true;
            base.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.yTHMJ858G);
            base.DrawItem += new DrawListViewItemEventHandler(this.dT3f0t4t3);
            base.DrawSubItem += new DrawListViewSubItemEventHandler(this.01FqmBarm);
            base.ColumnClick += new ColumnClickEventHandler(this.TEPULnwMP);
            base.ColumnReordered += new ColumnReorderedEventHandler(this.4bccOhnfl);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 01FqmBarm(object, DrawListViewSubItemEventArgs args1)
        {
            args1.DrawDefault = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 4bccOhnfl(object, ColumnReorderedEventArgs args1)
        {
            if (args1.OldDisplayIndex == this.XHHQ5xBgx)
            {
                this.XHHQ5xBgx = args1.NewDisplayIndex;
                base.ListViewItemSorter = new NxHGl7qwtixtnCysye4(this.XHHQ5xBgx, this.mNaPlOfPN);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AddColumns(params string[] columns)
        {
            base.Columns.Clear();
            foreach (string str in columns)
            {
                base.Columns.Add(str, 120);
            }
            base.ListViewItemSorter = new NxHGl7qwtixtnCysye4(this.XHHQ5xBgx, this.mNaPlOfPN);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void dT3f0t4t3(object, DrawListViewItemEventArgs args1)
        {
            args1.DrawDefault = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TEPULnwMP(object, ColumnClickEventArgs args1)
        {
            if (this.XHHQ5xBgx != args1.Column)
            {
                this.XHHQ5xBgx = args1.Column;
                this.mNaPlOfPN = 1;
            }
            else
            {
                this.mNaPlOfPN *= -1;
            }
            base.ListViewItemSorter = new NxHGl7qwtixtnCysye4(this.XHHQ5xBgx, this.mNaPlOfPN);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void yTHMJ858G(object, DrawListViewColumnHeaderEventArgs args1)
        {
            bool flag = this.XHHQ5xBgx == args1.ColumnIndex;
            if (flag)
            {
                args1.DrawBackground();
                args1.DrawText(TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter);
                if ((flag && (this.MEWIXKqxt != null)) && (this.Dr0wrInQN != null))
                {
                    Point point = new Point(args1.Bounds.Left + ((int) args1.Graphics.MeasureString(args1.Header.Text + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9408), args1.Font).Width), ((args1.Bounds.Top + args1.Bounds.Bottom) - this.MEWIXKqxt.Height) / 2);
                    args1.Graphics.DrawImage((this.mNaPlOfPN > 0) ? this.MEWIXKqxt : this.Dr0wrInQN, point);
                }
                this.Refresh();
            }
            else
            {
                args1.DrawDefault = true;
            }
        }

        public Bitmap ImageAscending
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.MEWIXKqxt;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.MEWIXKqxt = value;
            }
        }

        public Bitmap ImageDescending
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Dr0wrInQN;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.Dr0wrInQN = value;
            }
        }

        private class NxHGl7qwtixtnCysye4 : IComparer
        {
            private int 01FqmBarm;
            private int dT3f0t4t3;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public NxHGl7qwtixtnCysye4(int num2, int num1)
            {
                this.dT3f0t4t3 = num1;
                this.01FqmBarm = num2;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public int Compare(object obj1, object obj2)
            {
                return (Math.Sign(this.dT3f0t4t3) * string.Compare(((ListViewItem) obj1).SubItems[this.01FqmBarm].Text, ((ListViewItem) obj2).SubItems[this.01FqmBarm].Text));
            }
        }
    }
}

