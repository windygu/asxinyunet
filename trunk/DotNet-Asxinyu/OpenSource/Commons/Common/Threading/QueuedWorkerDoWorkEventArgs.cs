namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class QueuedWorkerDoWorkEventArgs : DoWorkEventArgs
    {
        [CompilerGenerated]
        private int JkKfoMY5A;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public QueuedWorkerDoWorkEventArgs(object argument, int priority) : base(argument)
        {
            this.VZJq3SjrW(priority);
        }

        public int Priority
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.JkKfoMY5A;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            private set
            {
                this.JkKfoMY5A = value;
            }
        }
    }
}

