namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class QueueServer<T> : DisposableObject
    {
        private bool 37jAJ3Bnt;
        private Thread 408MSTia8;
        private Queue<T> GPY6Re0PF;
        private bool JiYUNJcCW;
        private Action<T> PQMwwy6pB;

        public event Action<T> ProcessItem
        {
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.Synchronized)] add
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.Synchronized)] remove
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public QueueServer()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearItems()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void EnqueueItem(T item)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mUvqAX6rk()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnProcessItem(T item)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XPOfx7u7N()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public bool IsBackground
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public T[] Items
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public int QueueCount
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
