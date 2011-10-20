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
        private TimerExecution wKyWxGToc;

        public event TimerExecution Execute
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
        public TimerHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TimerHelper(long interval, bool start)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TimerHelper(long interval, int startDelay)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Pause()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start(int delayBeforeStart)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Stop()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Tick(object obj)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public long Interval
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

        public TimerState State
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public delegate void TimerExecution();
    }
}
