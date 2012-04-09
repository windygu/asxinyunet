namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProgressEventArgs : EventArgs
    {
        private int qCpqRb2bV = 0;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ProgressEventArgs(int prgValue)
        {
            this.qCpqRb2bV = prgValue;
        }

        public int ProgressValue
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.qCpqRb2bV;
            }
        }
    }
}

