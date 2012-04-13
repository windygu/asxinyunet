namespace WHC.Pager.WinControl
{
    using System;

    public class ProgressEventArgs : EventArgs
    {
        private int int_0 = 0;

        public ProgressEventArgs(int prgValue)
        {
            this.int_0 = prgValue;
        }

        public int ProgressValue
        {
            get
            {
                return this.int_0;
            }
        }
    }
}

