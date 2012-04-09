namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class QueuedWorkerCompletedEventArgs : AsyncCompletedEventArgs
    {
        [CompilerGenerated]
        private object AWbNwkBdU;
        [CompilerGenerated]
        private int wKyWxGToc;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public QueuedWorkerCompletedEventArgs(object argument, object result, int priority, Exception error, bool cancelled) : base(error, cancelled, argument)
        {
            this.VZJq3SjrW(result);
            this.JkKfoMY5A(priority);
        }

        public int Priority
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.wKyWxGToc;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            private set
            {
                this.wKyWxGToc = value;
            }
        }

        public object Result
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.AWbNwkBdU;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            private set
            {
                this.AWbNwkBdU = value;
            }
        }
    }
}

