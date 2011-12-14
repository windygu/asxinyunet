﻿using System;
using System.Collections.Generic;
using System.Threading;
using NewLife.Net.Common;
using NewLife.Net.Sockets;
using NewLife.Threading;

namespace NewLife.Net.Tcp
{
    /// <summary>
    /// Tcp会话集合。其中Tcp会话使用弱引用，允许GC及时回收不再使用的会话。
    /// </summary>
    public class TcpSessionCollection : Dictionary<Int32, WeakReference<TcpSession>>
    {
        //private TcpServer _Server;
        ///// <summary>服务器</summary>
        //public TcpServer Server
        //{
        //    get { return _Server; }
        //    set { _Server = value; }
        //}

        private Int32 sessionID = 0;
        /// <summary>
        /// 添加新会话，并设置会话编号
        /// </summary>
        /// <param name="session"></param>
        public void Add(TcpSession session)
        {
            lock (this)
            {
                session.ID = ++sessionID;

                Int32 index = Count + 1;
                if (!ContainsKey(index)) base.Add(index, session);

                TcpSessionCollection collection = this;
                session.Error += delegate(Object sender, NetEventArgs e)
                {
                    if (!collection.ContainsKey(index)) return;
                    lock (collection)
                    {
                        if (!collection.ContainsKey(index)) return;
                        collection.Remove(index);
                    }
                };

                //if (clearThread == null)
                //{
                //    clearThread = new Thread(RemoveNotAlive);
                //    clearThread.Name = "TcpServer会话维护";
                //    clearThread.IsBackground = true;
                //    clearThread.Start();
                //}
                if (clearTimer == null)
                {
                    //clearTimer = new Timer(new TimerCallback(RemoveNotAlive), null, ClearPeriod, ClearPeriod);
                    clearTimer = new TimerX(RemoveNotAlive, null, ClearPeriod, ClearPeriod);
                }
            }

            //// 定时清理会话
            //if (last.AddMinutes(1) < DateTime.Now)
            //{
            //    ThreadPool.QueueUserWorkItem(RemoveNotAlive);
            //    last = DateTime.Now;
            //}
        }

        private Int32 _ClearPeriod = 5000;
        /// <summary>清理周期。单位毫秒，默认5000毫秒。</summary>
        public Int32 ClearPeriod
        {
            get { return _ClearPeriod; }
            set { _ClearPeriod = value; }
        }

        //private DateTime last = DateTime.MinValue;

        /// <summary>
        /// 关闭所有
        /// </summary>
        public void CloseAll()
        {
            if (clearTimer != null) clearTimer.Dispose();

            if (Count < 1) return;

            WeakReference<TcpSession>[] sessions = null;

            lock (this)
            {
                if (Count < 1) return;
                sessions = new WeakReference<TcpSession>[Count];
                Values.CopyTo(sessions, 0);
            }

            foreach (WeakReference<TcpSession> item in sessions)
            {
                if (item == null || !item.IsAlive) continue;
                TcpSession session = item.Target;
                if (session == null || session.Disposed || session.Socket == null) continue;

                item.Target.Close();
            }
        }

        ///// <summary>
        ///// 清理会话线程
        ///// </summary>
        //private Thread clearThread;

        /// <summary>
        /// 清理会话计时器
        /// </summary>
        private TimerX clearTimer;

        ///// <summary>
        ///// 移除不活动的会话
        ///// </summary>
        ///// <param name="state"></param>
        //void RemoveNotAlive(Object state)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            RemoveNotAliveInternal();
        //        }
        //        catch (ThreadAbortException) { break; }
        //        catch (ThreadInterruptedException) { break; }
        //        catch { }

        //        // 每多100个会话，就多1秒
        //        Int32 n = Count / 100;
        //        if (n < 1) n = 1;
        //        Thread.Sleep(10000 + n * 1000);
        //    }
        //}

        void RemoveNotAlive(Object state)
        {
            RemoveNotAliveInternal();
            //Console.WriteLine("{0} {1}", DateTime.Now, Server.ToString());
        }

        /// <summary>
        /// 移除不活动的会话
        /// </summary>
        void RemoveNotAliveInternal()
        {
            if (Count < 1) return;

            lock (this)
            {
                if (Count < 1) return;

                List<Int32> list = new List<Int32>();
                foreach (Int32 index in Keys)
                {
                    WeakReference<TcpSession> item = this[index];
                    if (item == null || !item.IsAlive) list.Add(index);
                    TcpSession session = item.Target;
                    if (session == null || session.Disposed || session.Socket == null) list.Add(index);
                }
                if (list.Count < 1) return;

                foreach (Int32 item in list)
                {
                    if (ContainsKey(item)) Remove(item);
                }
            }
        }
    }
}