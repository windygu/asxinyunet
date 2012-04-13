﻿using System;
using System.Threading;
using System.Web;
using NewLife.Collections;

namespace NewLife.Log
{
    /// <summary>写日志事件参数</summary>
    public class WriteLogEventArgs : EventArgs
    {
        #region 属性
        private String _Message;
        /// <summary>日志信息</summary>
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private Exception _Exception;
        /// <summary>异常</summary>
        public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }
        #endregion

        #region 扩展属性
        private DateTime _Time;
        /// <summary>时间</summary>
        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        private Int32 _ThreadID;
        /// <summary>线程编号</summary>
        public Int32 ThreadID
        {
            get { return _ThreadID; }
            set { _ThreadID = value; }
        }

        private Boolean _IsPoolThread;
        /// <summary>是否线程池线程</summary>
        public Boolean IsPoolThread
        {
            get { return _IsPoolThread; }
            set { _IsPoolThread = value; }
        }

        private Boolean _IsWeb;
        /// <summary>是否Web线程</summary>
        public Boolean IsWeb { get { return _IsWeb; } set { _IsWeb = value; } }

        private String _ThreadName;
        /// <summary>线程名</summary>
        public String ThreadName
        {
            get { return _ThreadName; }
            set { _ThreadName = value; }
        }
        #endregion

        #region 构造
        /// <summary>实例化一个日志事件参数</summary>
        internal WriteLogEventArgs() { }

        /// <summary>构造函数</summary>
        /// <param name="message">日志</param>
        public WriteLogEventArgs(String message) : this(message, null) { }

        /// <summary>构造函数</summary>
        /// <param name="message">日志</param>
        /// <param name="exception">异常</param>
        public WriteLogEventArgs(String message, Exception exception)
        {
            Message = message;
            Exception = exception;

            Init();
        }
        #endregion

        #region 方法
        void Init()
        {
            Time = DateTime.Now;
            var thread = Thread.CurrentThread;
            ThreadID = thread.ManagedThreadId;
            IsPoolThread = thread.IsThreadPoolThread;
            ThreadName = thread.Name;
            IsWeb = HttpContext.Current != null;
        }

        /// <summary>已重载。</summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Exception != null) Message += Exception.ToString();
            return String.Format("{0:HH:mm:ss.fff} {1} {2} {3} {4}", Time, ThreadID, IsPoolThread ? (IsWeb ? 'W' : 'Y') : 'N', String.IsNullOrEmpty(ThreadName) ? "-" : ThreadName, Message);
        }
        #endregion

        #region 对象池
        //private static WriteLogEventArgsPool pool = new WriteLogEventArgsPool() { Max = 100, Stock = new LockStack<WriteLogEventArgs>() };

        //internal static WriteLogEventArgs Create(String message, Exception exception)
        //{
        //    var e = pool.Pop();
        //    e.Message = message;
        //    e.Exception = exception;
        //    e.Init();
        //    return e;
        //}

        ///// <summary>归还</summary>
        ///// <param name="e"></param>
        //internal static void Push(WriteLogEventArgs e)
        //{
        //    if (e != null) pool.Push(e);
        //}

        ///// <summary>日志事件参数池。避免大量写日志时的零碎对象造成GC压力。</summary>
        //class WriteLogEventArgsPool : ObjectPool<WriteLogEventArgs> { }
        #endregion
    }
}