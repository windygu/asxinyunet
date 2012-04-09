namespace WHC.OrderWater.Commons
{
    using log4net;
    using System;
    using System.Runtime.CompilerServices;

    public class LogHelper
    {
        private static readonly ILog mUvqAX6rk = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Debug(object ex)
        {
            mUvqAX6rk.Debug(ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Debug(object message, Exception ex)
        {
            mUvqAX6rk.Debug(message, ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(object ex)
        {
            mUvqAX6rk.Error(ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(object message, Exception ex)
        {
            mUvqAX6rk.Error(message, ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Info(object ex)
        {
            mUvqAX6rk.Info(ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Info(object message, Exception ex)
        {
            mUvqAX6rk.Info(message, ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Warn(object ex)
        {
            mUvqAX6rk.Warn(ex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Warn(object message, Exception ex)
        {
            mUvqAX6rk.Warn(message, ex);
        }
    }
}

