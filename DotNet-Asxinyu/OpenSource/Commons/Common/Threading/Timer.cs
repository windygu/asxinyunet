namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Timer
    {
        [CompilerGenerated]
        private int 37jAJ3Bnt;
        private readonly Timer 408MSTia8;
        private volatile bool GPY6Re0PF;
        private volatile bool JiYUNJcCW;
        [CompilerGenerated]
        private bool PQMwwy6pB;

        public event EventHandler Elapsed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Timer(int period) : this(period, false)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Timer(int period, bool runOnStart)
        {
            this.Period = period;
            this.RunOnStart = runOnStart;
            this.408MSTia8 = new Timer(new TimerCallback(this.mUvqAX6rk), null, -1, -1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mUvqAX6rk(object)
        {
            Timer timer;
            lock ((timer = this.408MSTia8))
            {
                if (!(this.GPY6Re0PF && !this.JiYUNJcCW))
                {
                    return;
                }
                this.408MSTia8.Change(-1, -1);
                this.JiYUNJcCW = true;
            }
            try
            {
                if (this.XPOfx7u7N != null)
                {
                    this.XPOfx7u7N(this, new EventArgs());
                }
            }
            catch
            {
            }
            finally
            {
                lock ((timer = this.408MSTia8))
                {
                    this.JiYUNJcCW = false;
                    if (this.GPY6Re0PF)
                    {
                        this.408MSTia8.Change(this.Period, -1);
                    }
                    Monitor.Pulse(this.408MSTia8);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start()
        {
            this.GPY6Re0PF = true;
            this.408MSTia8.Change(this.RunOnStart ? 0 : this.Period, -1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Stop()
        {
            lock (this.408MSTia8)
            {
                this.GPY6Re0PF = false;
                this.408MSTia8.Change(-1, -1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WaitToStop()
        {
            lock (this.408MSTia8)
            {
                while (this.JiYUNJcCW)
                {
                    Monitor.Wait(this.408MSTia8);
                }
            }
        }

        public int Period
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.37jAJ3Bnt;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.37jAJ3Bnt = value;
            }
        }

        public bool RunOnStart
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.PQMwwy6pB;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.PQMwwy6pB = value;
            }
        }
    }
}

