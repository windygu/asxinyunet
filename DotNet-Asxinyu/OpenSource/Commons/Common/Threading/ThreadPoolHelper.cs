namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class ThreadPoolHelper
    {
        private static List<WaitHandle> EPgfA8o8U;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool QueueUserWorkItem(WaitCallbackNew callback)
        {
            op6bfJqTKw59owE9bOa state = new op6bfJqTKw59owE9bOa();
            state.EPgfA8o8U(callback);
            state.eMSUYugy4(new AutoResetEvent(false));
            if (EPgfA8o8U == null)
            {
                EPgfA8o8U = new List<WaitHandle>();
            }
            EPgfA8o8U.Add(state.3xodQsKC6());
            return ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolHelper.XxQqQ66mW), state);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool QueueUserWorkItems(params WaitCallbackNew[] proc)
        {
            bool flag = true;
            foreach (WaitCallbackNew new2 in proc)
            {
                flag &= QueueUserWorkItem(new2);
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool WaitAll()
        {
            return WaitHandle.WaitAll(EPgfA8o8U.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int WaitAny()
        {
            return WaitHandle.WaitAny(EPgfA8o8U.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void XxQqQ66mW(object obj1)
        {
            op6bfJqTKw59owE9bOa oa = obj1 as op6bfJqTKw59owE9bOa;
            oa.XxQqQ66mW()();
            (oa.3xodQsKC6() as AutoResetEvent).Set();
        }

        private class op6bfJqTKw59owE9bOa
        {
            private WaitHandle 533PxePZv;
            private ThreadPoolHelper.WaitCallbackNew Um5wSC5ZO;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public WaitHandle 3xodQsKC6()
            {
                return this.533PxePZv;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void eMSUYugy4(WaitHandle handle1)
            {
                this.533PxePZv = handle1;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void EPgfA8o8U(ThreadPoolHelper.WaitCallbackNew new1)
            {
                this.Um5wSC5ZO = new1;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public ThreadPoolHelper.WaitCallbackNew XxQqQ66mW()
            {
                return this.Um5wSC5ZO;
            }
        }

        public delegate void WaitCallbackNew();
    }
}

