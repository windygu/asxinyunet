namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using ZyoQdINMBnLxyxRAC1;

    public static class DelegateHelper
    {
        private static WaitCallback r4vfcKJvu = new WaitCallback(DelegateHelper.qCpqRb2bV);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItemStatus AbortDelegate(WorkItem target)
        {
            return AbortableThreadPool.Cancel(target, true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItem InvokeDelegate(Delegate target)
        {
            return AbortableThreadPool.QueueUserWorkItem(r4vfcKJvu, new UhWypy8rh2xvfrAlX5(target, null));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItem InvokeDelegate(Delegate target, params object[] args)
        {
            return AbortableThreadPool.QueueUserWorkItem(r4vfcKJvu, new UhWypy8rh2xvfrAlX5(target, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void qCpqRb2bV(object obj1)
        {
            UhWypy8rh2xvfrAlX5 lx = (UhWypy8rh2xvfrAlX5) obj1;
            lx.mUvqAX6rk.DynamicInvoke(lx.XPOfx7u7N);
        }
    }
}

