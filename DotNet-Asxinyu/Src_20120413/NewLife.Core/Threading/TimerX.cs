﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace NewLife.Threading
{
    /// <summary>不可重入的定时器。</summary>
    /// <remarks>
    /// 为了避免系统的Timer可重入的问题，差别在于本地调用完成后才开始计算时间间隔。这实际上也是经常用到的。
    /// 
    /// 因为挂载在静态列表上，必须从外部主动调用<see cref="IDisposable.Dispose"/>才能销毁定时器。
    /// 
    /// 该定时器不能放入太多任务，否则适得其反！
    /// </remarks>
    public class TimerX : DisposeBase
    {
        #region 属性
        private WeakAction<Object> _Callback;
        /// <summary>回调</summary>
        public WeakAction<Object> Callback
        {
            get { return _Callback; }
            set { _Callback = value; }
        }

        private Object _State;
        /// <summary>用户数据</summary>
        public Object State
        {
            get { return _State; }
            set { _State = value; }
        }

        private DateTime _NextTime;
        /// <summary>下一次调用时间</summary>
        public DateTime NextTime
        {
            get { return _NextTime; }
            set { _NextTime = value; }
        }

        private Int32 _Timers;
        /// <summary>调用次数</summary>
        public Int32 Timers
        {
            get { return _Timers; }
            set { _Timers = value; }
        }

        private Int32 _Period;
        /// <summary>间隔周期</summary>
        public Int32 Period
        {
            get { return _Period; }
            set { _Period = value; }
        }

        private Boolean _UseThreadPool;
        /// <summary>是否使用线程池。对于耗时短小且比较频繁的操作，不好使用线程池，减少线程切换。</summary>
        public Boolean UseThreadPool { get { return _UseThreadPool; } set { _UseThreadPool = value; } }

        private Boolean _Calling;
        /// <summary>调用中</summary>
        public Boolean Calling
        {
            get { return _Calling; }
            set { _Calling = value; }
        }
        #endregion

        #region 构造
        /// <summary>实例化一个不可重入的定时器</summary>
        /// <param name="callback">委托</param>
        /// <param name="state">用户数据</param>
        /// <param name="dueTime">多久之后开始</param>
        /// <param name="period">间隔周期</param>
        public TimerX(WaitCallback callback, object state, int dueTime, int period) : this(callback, state, dueTime, period, period > 10000) { }

        /// <summary>实例化一个不可重入的定时器</summary>
        /// <param name="callback">委托</param>
        /// <param name="state">用户数据</param>
        /// <param name="dueTime">多久之后开始</param>
        /// <param name="period">间隔周期</param>
        /// <param name="usethreadpool">是否使用线程池。对于耗时短小且比较频繁的操作，不好使用线程池，减少线程切换。</param>
        public TimerX(WaitCallback callback, object state, int dueTime, int period, Boolean usethreadpool)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            if (dueTime < Timeout.Infinite) throw new ArgumentOutOfRangeException("dueTime");
            if (period < Timeout.Infinite) throw new ArgumentOutOfRangeException("period");

            Callback = new WeakAction<object>(callback);
            State = state;
            Period = period;
            UseThreadPool = usethreadpool;

            NextTime = DateTime.Now.AddMilliseconds(dueTime);

            TimerXHelper.Add(this);
        }
        #endregion

        #region 内部助手
        static class TimerXHelper
        {
            static Thread thread;

            static List<TimerX> timers = new List<TimerX>();

            public static void Add(TimerX timer)
            {
                lock (timers)
                {
                    timers.Add(timer);

                    timer.OnDisposed += new EventHandler(delegate(Object sender, EventArgs e)
                    {
                        TimerX tx = sender as TimerX;
                        if (tx == null) return;
                        lock (timers)
                        {
                            if (timers.Contains(tx)) timers.Remove(tx);
                        }
                    });

                    if (thread == null)
                    {
                        thread = new Thread(Process);
                        thread.Name = "TimerX";
                        thread.IsBackground = true;
                        thread.Start();
                    }

                    if (waitForTimer != null && waitForTimer.SafeWaitHandle != null && !waitForTimer.SafeWaitHandle.IsClosed) waitForTimer.Set();
                }
            }

            static AutoResetEvent waitForTimer;
            static Int32 period = 10;

            static void Process(Object state)
            {
                while (true)
                {
                    try
                    {
                        var list = Prepare();

                        // 记录本次循环有几个任务被处理
                        //Int32 count = 0;
                        // 设置一个较大的间隔，内部会根据处理情况调整该值为最合理值
                        period = 60000;
                        foreach (TimerX timer in list)
                        {
                            ProcessItem(timer);
                        }
                    }
                    catch (ThreadAbortException) { break; }
                    catch (ThreadInterruptedException) { break; }
                    catch { }

                    //Thread.Sleep(period);
                    if (waitForTimer == null) waitForTimer = new AutoResetEvent(false);
                    waitForTimer.WaitOne(period, false);
                }
            }

            static List<TimerX> Prepare()
            {
                if (timers == null || timers.Count < 1)
                {
                    // 没有计时器，设置一个较大的休眠时间
                    //period = 60000;

                    // 使用事件量来控制线程
                    if (waitForTimer != null) waitForTimer.Close();

                    waitForTimer = new AutoResetEvent(false);
                    waitForTimer.WaitOne(Timeout.Infinite, false);
                }

                List<TimerX> list = null;
                lock (timers)
                {
                    list = new List<TimerX>(timers);
                }

                return list;
            }

            static void ProcessItem(TimerX timer)
            {
                // 删除过期的
                if (!timer.Callback.IsAlive)
                {
                    lock (timers)
                    {
                        timers.Remove(timer);
                    }
                    return;
                }

                TimeSpan ts = timer.NextTime - DateTime.Now;
                Int32 d = (Int32)ts.TotalMilliseconds;
                if (d > 0)
                {
                    // 缩小间隔，便于快速调用
                    if (d < period) period = d;

                    return;
                }

                try
                {
                    timer.Calling = true;

                    Action<Object> callback = timer.Callback;
                    // 线程池调用
                    if (timer.UseThreadPool)
                        ThreadPoolX.QueueUserWorkItem(delegate() { callback(timer.State); });
                    else
                        callback(timer.State);
                }
                catch (ThreadAbortException) { throw; }
                catch (ThreadInterruptedException) { throw; }
                catch { }
                finally
                {
                    timer.Timers++;
                    timer.Calling = false;
                    timer.NextTime = DateTime.Now.AddMilliseconds(timer.Period);
                    if (timer.Period < period) period = timer.Period;
                }
            }
        }
        #endregion
    }
}