namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public sealed class WorkItem
    {
        private object 4N3ft2esL;
        private ExecutionContext csmMiy6Il;
        private WaitCallback PZaqo38KQ;

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal WorkItem(WaitCallback callback, object state, ExecutionContext context)
        {
            this.PZaqo38KQ = callback;
            this.4N3ft2esL = state;
            this.csmMiy6Il = context;
        }

        public WaitCallback Callback
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.PZaqo38KQ;
            }
        }

        public ExecutionContext Context
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.csmMiy6Il;
            }
        }

        public object State
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.4N3ft2esL;
            }
        }
    }
}

