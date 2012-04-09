namespace WHC.OrderWater.Commons.Threading
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public static class AbortableThreadPool
    {
        private static readonly LinkedList<WorkItem> lWvfFeZUE = new LinkedList<WorkItem>();
        private static readonly Dictionary<WorkItem, Thread> OBHMaLtRG = new Dictionary<WorkItem, Thread>();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItemStatus Cancel(WorkItem item, bool allowAbort)
        {
            if (item == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x83f4));
            }
            lock (lWvfFeZUE)
            {
                LinkedListNode<WorkItem> node = lWvfFeZUE.Find(item);
                if (node != null)
                {
                    lWvfFeZUE.Remove(node);
                    return WorkItemStatus.Queued;
                }
                if (OBHMaLtRG.ContainsKey(item))
                {
                    if (allowAbort)
                    {
                        OBHMaLtRG[item].Abort();
                        OBHMaLtRG.Remove(item);
                        return WorkItemStatus.Aborted;
                    }
                    return WorkItemStatus.Executing;
                }
                return WorkItemStatus.Completed;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItemStatus GetStatus(WorkItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8400));
            }
            lock (lWvfFeZUE)
            {
                if (lWvfFeZUE.Find(item) != null)
                {
                    return WorkItemStatus.Queued;
                }
                if (OBHMaLtRG.ContainsKey(item))
                {
                    return WorkItemStatus.Executing;
                }
                return WorkItemStatus.Completed;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void mi5qIK3te(object)
        {
            LinkedList<WorkItem> list;
            ContextCallback callback = null;
            g3Rj2pqYTqoYh8S391m yhsm = new g3Rj2pqYTqoYh8S391m {
                JkKfoMY5A = null
            };
            try
            {
                lock ((list = lWvfFeZUE))
                {
                    if (lWvfFeZUE.Count > 0)
                    {
                        yhsm.JkKfoMY5A = lWvfFeZUE.First.Value;
                        lWvfFeZUE.RemoveFirst();
                    }
                    if (yhsm.JkKfoMY5A == null)
                    {
                        return;
                    }
                    OBHMaLtRG.Add(yhsm.JkKfoMY5A, Thread.CurrentThread);
                }
                if (callback == null)
                {
                    callback = new ContextCallback(yhsm.VZJq3SjrW);
                }
                ExecutionContext.Run(yhsm.JkKfoMY5A.Context, callback, null);
            }
            finally
            {
                lock ((list = lWvfFeZUE))
                {
                    if (yhsm.JkKfoMY5A != null)
                    {
                        OBHMaLtRG.Remove(yhsm.JkKfoMY5A);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItem QueueUserWorkItem(WaitCallback callback)
        {
            return QueueUserWorkItem(callback, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static WorkItem QueueUserWorkItem(WaitCallback callback, object state)
        {
            WorkItem item = new WorkItem(callback, state, ExecutionContext.Capture());
            lock (lWvfFeZUE)
            {
                lWvfFeZUE.AddLast(item);
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(AbortableThreadPool.mi5qIK3te));
            return item;
        }

        [CompilerGenerated]
        private sealed class g3Rj2pqYTqoYh8S391m
        {
            public WorkItem JkKfoMY5A;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void VZJq3SjrW(object)
            {
                this.JkKfoMY5A.Callback(this.JkKfoMY5A.State);
            }
        }
    }
}

