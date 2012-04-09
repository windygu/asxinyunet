namespace WHC.OrderWater.Commons.Threading
{
    using 1YyIjYqRnHRBNetelZO;
    using NZRg0RMbccjtWZhYdU;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using WGr7O2wL3Hu8w3rR9j;

    [Description("A background worker with a work queue."), ToolboxBitmap(typeof(QueuedBackgroundWorker)), DefaultEvent("DoWork")]
    public class QueuedBackgroundWorker : Component
    {
        private readonly SendOrPostCallback 75daGZAWD;
        private LinkedList<AsyncOperation>[] 8rutm6l7j;
        private int CbmYvZ8sP = 5;
        private Dictionary<object, bool> d2pr5bVa4;
        private bool JEsELMkMC = false;
        private bool KFdW4lWfd = false;
        private Thread[] p2IZt4XSy;
        private int QQEhM8iDN;
        private readonly object sA31flgxM = new object();
        private WHC.OrderWater.Commons.Threading.ProcessingMode txycF6EdQ;
        private bool ViDvSiHoy = false;

        [Category("Behavior"), Browsable(true), Description("Occurs when RunWorkerAsync is called.")]
        public event QueuedWorkerDoWorkEventHandler DoWork;

        [Category("Behavior"), Description("Occurs when the background operation of an item has completed."), Browsable(true)]
        public event RunQueuedWorkerCompletedEventHandler RunWorkerCompleted;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public QueuedBackgroundWorker()
        {
            this.DCfwTCNw5();
            this.txycF6EdQ = WHC.OrderWater.Commons.Threading.ProcessingMode.FIFO;
            this.QQEhM8iDN = 5;
            this.fNM4OoxBb();
            this.d2pr5bVa4 = new Dictionary<object, bool>();
            this.75daGZAWD = new SendOrPostCallback(this.C1aPmhGbi);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 4N3ft2esL(object obj1, int num1)
        {
            AsyncOperation operation = AsyncOperationManager.CreateOperation(obj1);
            if (this.txycF6EdQ == WHC.OrderWater.Commons.Threading.ProcessingMode.FIFO)
            {
                this.8rutm6l7j[num1].AddLast(operation);
            }
            else
            {
                this.8rutm6l7j[num1].AddFirst(operation);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void BkDXNWfc2()
        {
            while (!this.OWxGaovaE())
            {
                object obj3;
                lock ((obj3 = this.sA31flgxM))
                {
                    if (this.PZaqo38KQ())
                    {
                        Monitor.Wait(this.sA31flgxM);
                    }
                }
                bool flag = true;
                while (flag && !this.OWxGaovaE())
                {
                    AsyncOperation operation = null;
                    object key = null;
                    int priority = 0;
                    lock ((obj3 = this.sA31flgxM))
                    {
                        alyY2aDyB8vs4ocQSq<AsyncOperation, int> sq = this.csmMiy6Il();
                        operation = sq.PZaqo38KQ();
                        priority = sq.PZaqo38KQ();
                        if (operation != null)
                        {
                            key = operation.UserSuppliedState;
                        }
                        if ((key != null) && this.d2pr5bVa4.ContainsKey(key))
                        {
                            key = null;
                        }
                    }
                    if (key != null)
                    {
                        Exception error = null;
                        QueuedWorkerDoWorkEventArgs e = new QueuedWorkerDoWorkEventArgs(key, priority);
                        try
                        {
                            this.OnDoWork(e);
                        }
                        catch (Exception exception2)
                        {
                            error = exception2;
                        }
                        QueuedWorkerCompletedEventArgs arg = new QueuedWorkerCompletedEventArgs(key, e.Result, priority, error, e.Cancel);
                        if (!this.OWxGaovaE())
                        {
                            operation.PostOperationCompleted(this.75daGZAWD, arg);
                        }
                    }
                    else if (operation != null)
                    {
                        operation.OperationCompleted();
                    }
                    lock ((obj3 = this.sA31flgxM))
                    {
                        flag = !this.PZaqo38KQ();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void C1aPmhGbi(object obj1)
        {
            this.OnRunWorkerCompleted((QueuedWorkerCompletedEventArgs) obj1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync()
        {
            lock (this.sA31flgxM)
            {
                this.hobU1pUwB();
                Monitor.Pulse(this.sA31flgxM);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync(int priority)
        {
            if ((priority < 0) || (priority >= this.QQEhM8iDN))
            {
                int num = this.QQEhM8iDN - 1;
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15c) + num.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x19e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ba));
            }
            lock (this.sA31flgxM)
            {
                this.HZSBafg3p(priority);
                Monitor.Pulse(this.sA31flgxM);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync(object argument)
        {
            lock (this.sA31flgxM)
            {
                if (!this.d2pr5bVa4.ContainsKey(argument))
                {
                    this.d2pr5bVa4.Add(argument, false);
                    Monitor.Pulse(this.sA31flgxM);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private alyY2aDyB8vs4ocQSq<AsyncOperation, int> csmMiy6Il()
        {
            AsyncOperation operation = null;
            int num = 0;
            for (int i = this.QQEhM8iDN - 1; i >= 0; i--)
            {
                if (this.8rutm6l7j[i].Count > 0)
                {
                    num = i;
                    operation = this.8rutm6l7j[i].First.Value;
                    this.8rutm6l7j[i].RemoveFirst();
                    break;
                }
            }
            return JkUPaXf5FNNV1WToF0.4N3ft2esL<AsyncOperation, int>(operation, num);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void DCfwTCNw5()
        {
            this.p2IZt4XSy = new Thread[this.CbmYvZ8sP];
            for (int i = 0; i < this.CbmYvZ8sP; i++)
            {
                this.p2IZt4XSy[i] = new Thread(new ThreadStart(this.BkDXNWfc2));
                this.p2IZt4XSy[i].IsBackground = true;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!this.ViDvSiHoy)
            {
                lock (this.sA31flgxM)
                {
                    if (!this.KFdW4lWfd)
                    {
                        this.KFdW4lWfd = true;
                        this.hobU1pUwB();
                        this.d2pr5bVa4.Clear();
                        Monitor.Pulse(this.sA31flgxM);
                    }
                }
                this.ViDvSiHoy = true;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void fNM4OoxBb()
        {
            this.8rutm6l7j = new LinkedList<AsyncOperation>[this.QQEhM8iDN];
            for (int i = 0; i < this.QQEhM8iDN; i++)
            {
                this.8rutm6l7j[i] = new LinkedList<AsyncOperation>();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ApartmentState GetApartmentState()
        {
            return this.p2IZt4XSy[0].GetApartmentState();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void hobU1pUwB()
        {
            for (int i = 0; i < this.QQEhM8iDN; i++)
            {
                this.HZSBafg3p(i);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void HZSBafg3p(int num1)
        {
            while (this.8rutm6l7j[num1].Count > 0)
            {
                this.8rutm6l7j[num1].First.Value.OperationCompleted();
                this.8rutm6l7j[num1].RemoveFirst();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnDoWork(QueuedWorkerDoWorkEventArgs e)
        {
            if (this.EEBiQuLFj != null)
            {
                this.EEBiQuLFj(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnRunWorkerCompleted(QueuedWorkerCompletedEventArgs e)
        {
            if (this.rq9ANDTh8 != null)
            {
                this.rq9ANDTh8(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool OWxGaovaE()
        {
            lock (this.sA31flgxM)
            {
                return this.KFdW4lWfd;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool PZaqo38KQ()
        {
            foreach (LinkedList<AsyncOperation> list in this.8rutm6l7j)
            {
                if (list.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync()
        {
            this.RunWorkerAsync(null, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync(object argument)
        {
            this.RunWorkerAsync(argument, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync(object argument, int priority)
        {
            if ((priority < 0) || (priority >= this.QQEhM8iDN))
            {
                int num2 = this.QQEhM8iDN - 1;
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(6) + num2.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x48), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(100));
            }
            if (!this.JEsELMkMC)
            {
                for (int i = 0; i < this.CbmYvZ8sP; i++)
                {
                    this.p2IZt4XSy[i].Start();
                    while (!this.p2IZt4XSy[i].IsAlive)
                    {
                    }
                }
                this.JEsELMkMC = true;
            }
            lock (this.sA31flgxM)
            {
                this.4N3ft2esL(argument, priority);
                Monitor.Pulse(this.sA31flgxM);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetApartmentState(ApartmentState state)
        {
            for (int i = 0; i < this.CbmYvZ8sP; i++)
            {
                this.p2IZt4XSy[i].SetApartmentState(state);
            }
        }

        [Description("Gets or sets a value indicating whether or not the worker thread is a background thread."), Category("Behavior"), Browsable(true)]
        public bool IsBackground
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.p2IZt4XSy[0].IsBackground;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                for (int i = 0; i < this.CbmYvZ8sP; i++)
                {
                    this.p2IZt4XSy[i].IsBackground = value;
                }
            }
        }

        [DefaultValue(5), Category("Behaviour"), Browsable(true)]
        public int PriorityQueues
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.QQEhM8iDN;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.JEsELMkMC)
                {
                    throw new ThreadStateException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4));
                }
                this.QQEhM8iDN = value;
                this.fNM4OoxBb();
            }
        }

        [DefaultValue(typeof(WHC.OrderWater.Commons.Threading.ProcessingMode), "FIFO"), Browsable(true), Category("Behaviour")]
        public WHC.OrderWater.Commons.Threading.ProcessingMode ProcessingMode
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.txycF6EdQ;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.JEsELMkMC)
                {
                    throw new ThreadStateException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(120));
                }
                this.txycF6EdQ = value;
                this.fNM4OoxBb();
            }
        }

        [Description("Determines whether the QueuedBackgroundWorker started working."), Category("Behavior"), Browsable(false)]
        public bool Started
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.JEsELMkMC;
            }
        }

        [Category("Behaviour"), DefaultValue(5), Browsable(true)]
        public int Threads
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.CbmYvZ8sP;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.JEsELMkMC)
                {
                    throw new ThreadStateException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x110));
                }
                this.CbmYvZ8sP = value;
                this.DCfwTCNw5();
            }
        }
    }
}

