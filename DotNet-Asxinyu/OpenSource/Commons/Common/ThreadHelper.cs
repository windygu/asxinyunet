namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class ThreadHelper
    {
        private static CultureInfo VZJq3SjrW;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Queue(WaitCallback callBack, string threadName, ThreadPriority priority)
        {
            return Queue(callBack, threadName, null, priority);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Queue(WaitCallback callBack, string threadName, object state, ThreadPriority priority)
        {
            01RBQ0qVa86jhX4ZVyl vyl = new 01RBQ0qVa86jhX4ZVyl {
                LqbfxwEBL = callBack,
                ArbNmJ8sV = threadName,
                isIPJZTju = priority
            };
            WaitCallback callback = new WaitCallback(vyl.7dwqV7ssD);
            return ThreadPool.QueueUserWorkItem(callback, state);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetMainThreadUICulture(string cultureName)
        {
            try
            {
                LogHelper.Info(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf252), cultureName));
                CultureInfo info = new CultureInfo(cultureName);
                VZJq3SjrW = info;
                Thread.CurrentThread.CurrentUICulture = info;
            }
            catch (Exception exception)
            {
                LogHelper.Error(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf274), cultureName), exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetThreadName(string name)
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf244) + name.PadRight(10);
                if (VZJq3SjrW != null)
                {
                    Thread.CurrentThread.CurrentUICulture = VZJq3SjrW;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetThreadPriority(ThreadPriority priority)
        {
            if (Thread.CurrentThread.Priority != priority)
            {
                Thread.CurrentThread.Priority = priority;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Sleep(TimeSpan timeOut)
        {
            Thread.Sleep(timeOut);
        }

        [CompilerGenerated]
        private sealed class 01RBQ0qVa86jhX4ZVyl
        {
            public string ArbNmJ8sV;
            public ThreadPriority isIPJZTju;
            public WaitCallback LqbfxwEBL;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void 7dwqV7ssD(object obj1)
            {
                ThreadHelper.SetThreadName(this.ArbNmJ8sV);
                ThreadHelper.SetThreadPriority(this.isIPJZTju);
                this.LqbfxwEBL(obj1);
            }
        }
    }
}

