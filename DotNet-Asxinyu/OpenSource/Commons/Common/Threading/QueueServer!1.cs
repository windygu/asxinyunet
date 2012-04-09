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

        public event Action<T> ProcessItem;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public QueueServer()
        {
            this.408MSTia8 = null;
            this.GPY6Re0PF = new Queue<T>();
            this.JiYUNJcCW = false;
            this.37jAJ3Bnt = false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearItems()
        {
            lock (this.GPY6Re0PF)
            {
                this.GPY6Re0PF.Clear();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!this.37jAJ3Bnt)
                {
                    this.ClearItems();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void EnqueueItem(T item)
        {
            lock (this.GPY6Re0PF)
            {
                this.GPY6Re0PF.Enqueue(item);
            }
            if (!((this.408MSTia8 != null) && this.408MSTia8.IsAlive))
            {
                this.mUvqAX6rk();
                this.408MSTia8.Start();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mUvqAX6rk()
        {
            this.408MSTia8 = new Thread(new ThreadStart(this.XPOfx7u7N));
            this.408MSTia8.IsBackground = this.JiYUNJcCW;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnProcessItem(T item)
        {
            if (this.PQMwwy6pB != null)
            {
                this.PQMwwy6pB(item);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XPOfx7u7N()
        {
            T item = default(T);
            while (true)
            {
                lock (this.GPY6Re0PF)
                {
                    if (this.GPY6Re0PF.Count > 0)
                    {
                        item = this.GPY6Re0PF.Dequeue();
                    }
                    else
                    {
                        return;
                    }
                }
                try
                {
                    this.OnProcessItem(item);
                }
                catch
                {
                }
            }
        }

        public bool IsBackground
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.JiYUNJcCW;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.JiYUNJcCW = true;
                if ((this.408MSTia8 != null) && this.408MSTia8.IsAlive)
                {
                    this.408MSTia8.IsBackground = this.JiYUNJcCW;
                }
            }
        }

        public T[] Items
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                lock (this.GPY6Re0PF)
                {
                    return this.GPY6Re0PF.ToArray();
                }
            }
        }

        public int QueueCount
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                lock (this.GPY6Re0PF)
                {
                    return this.GPY6Re0PF.Count;
                }
            }
        }
    }
}

