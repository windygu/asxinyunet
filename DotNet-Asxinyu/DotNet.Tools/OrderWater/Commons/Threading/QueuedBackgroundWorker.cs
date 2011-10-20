namespace WHC.OrderWater.Commons.Threading
{
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
        private int CbmYvZ8sP;
        private Dictionary<object, bool> d2pr5bVa4;
        private QueuedWorkerDoWorkEventHandler EEBiQuLFj;
        private bool JEsELMkMC;
        private bool KFdW4lWfd;
        private Thread[] p2IZt4XSy;
        private int QQEhM8iDN;
        private RunQueuedWorkerCompletedEventHandler rq9ANDTh8;
        private readonly object sA31flgxM;
        private WHC.OrderWater.Commons.Threading.ProcessingMode txycF6EdQ;
        private bool ViDvSiHoy;

        [Category("Behavior"), Browsable(true), Description("Occurs when RunWorkerAsync is called.")]
        public event QueuedWorkerDoWorkEventHandler DoWork
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

        [Category("Behavior"), Description("Occurs when the background operation of an item has completed."), Browsable(true)]
        public event RunQueuedWorkerCompletedEventHandler RunWorkerCompleted
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
        public QueuedBackgroundWorker()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 4N3ft2esL(object obj1, int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void BkDXNWfc2()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void C1aPmhGbi(object obj1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync(int priority)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CancelAsync(object argument)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private alyY2aDyB8vs4ocQSq<AsyncOperation, int> csmMiy6Il()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void DCfwTCNw5()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void fNM4OoxBb()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ApartmentState GetApartmentState()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void hobU1pUwB()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void HZSBafg3p(int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnDoWork(QueuedWorkerDoWorkEventArgs e)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnRunWorkerCompleted(QueuedWorkerCompletedEventArgs e)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool OWxGaovaE()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool PZaqo38KQ()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync(object argument)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RunWorkerAsync(object argument, int priority)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetApartmentState(ApartmentState state)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [Description("Gets or sets a value indicating whether or not the worker thread is a background thread."), Category("Behavior"), Browsable(true)]
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

        [DefaultValue(5), Category("Behaviour"), Browsable(true)]
        public int PriorityQueues
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

        [DefaultValue(typeof(WHC.OrderWater.Commons.Threading.ProcessingMode), "FIFO"), Browsable(true), Category("Behaviour")]
        public WHC.OrderWater.Commons.Threading.ProcessingMode ProcessingMode
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

        [Description("Determines whether the QueuedBackgroundWorker started working."), Category("Behavior"), Browsable(false)]
        public bool Started
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [Category("Behaviour"), DefaultValue(5), Browsable(true)]
        public int Threads
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
    }
}
