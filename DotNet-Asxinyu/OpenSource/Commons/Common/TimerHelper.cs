namespace WHC.OrderWater.Commons
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [Serializable]
    public class TimerHelper : Component
    {
        private TimerState AWbNwkBdU;
        private long JkKfoMY5A;
        private Timer VZJq3SjrW;

        public event TimerExecution Execute;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TimerHelper()
        {
            this.JkKfoMY5A = 100L;
            this.AWbNwkBdU = TimerState.Stopped;
            this.VZJq3SjrW = new Timer(new TimerCallback(this.Tick), null, -1L, this.JkKfoMY5A);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TimerHelper(long interval, bool start)
        {
            this.JkKfoMY5A = interval;
            this.AWbNwkBdU = !start ? TimerState.Stopped : TimerState.Running;
            this.VZJq3SjrW = new Timer(new TimerCallback(this.Tick), null, 0L, interval);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TimerHelper(long interval, int startDelay)
        {
            this.JkKfoMY5A = interval;
            this.AWbNwkBdU = (startDelay == -1) ? TimerState.Stopped : TimerState.Running;
            this.VZJq3SjrW = new Timer(new TimerCallback(this.Tick), null, (long) startDelay, interval);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Pause()
        {
            this.AWbNwkBdU = TimerState.Paused;
            this.VZJq3SjrW.Change(-1L, this.JkKfoMY5A);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start()
        {
            this.AWbNwkBdU = TimerState.Running;
            this.VZJq3SjrW.Change(0L, this.JkKfoMY5A);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start(int delayBeforeStart)
        {
            this.AWbNwkBdU = TimerState.Running;
            this.VZJq3SjrW.Change((long) delayBeforeStart, this.JkKfoMY5A);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Stop()
        {
            this.AWbNwkBdU = TimerState.Stopped;
            this.VZJq3SjrW.Change(-1L, this.JkKfoMY5A);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Tick(object obj)
        {
            if ((this.AWbNwkBdU == TimerState.Running) && (this.wKyWxGToc != null))
            {
                lock (this)
                {
                    this.wKyWxGToc();
                }
            }
        }

        public long Interval
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.JkKfoMY5A;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.VZJq3SjrW.Change((this.AWbNwkBdU == TimerState.Running) ? value : -1L, value);
            }
        }

        public TimerState State
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AWbNwkBdU;
            }
        }

        public delegate void TimerExecution();
    }
}

