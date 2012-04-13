using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using NewLife.Configuration;
using System.Collections.Generic;
using System.Threading;

namespace NewLife.Log
{
    /// <summary>��־�࣬�������ٵ��Թ���</summary>
    public class XTrace
    {
        #region д��־
        private static TextFileLog Log = TextFileLog.Create(Config.GetConfig<String>("NewLife.LogPath"));
        /// <summary>��־·��</summary>
        public static String LogPath { get { return Log.LogPath; } }

        /// <summary>�����־</summary>
        /// <param name="msg">��Ϣ</param>
        public static void WriteLine(String msg)
        {
            Log.WriteLine(msg);
        }

        /// <summary>����쳣��־</summary>
        /// <param name="ex">�쳣��Ϣ</param>
        public static void WriteException(Exception ex)
        {
            Log.WriteException(ex);
        }

        /// <summary>����쳣��־</summary>
        /// <param name="ex">�쳣��Ϣ</param>
        public static void WriteExceptionWhenDebug(Exception ex)
        {
            if (Debug) Log.WriteLine(ex.ToString());
        }

        /// <summary>
        /// ��ջ���ԡ�
        /// �����ջ��Ϣ�����ڵ���ʱ������������ġ�
        /// ����������ɴ�����־�������á�
        /// </summary>
        public static void DebugStack()
        {
            Log.DebugStack(2, Int32.MaxValue);
        }

        /// <summary>��ջ���ԡ�</summary>
        /// <param name="maxNum">��󲶻��ջ������</param>
        public static void DebugStack(int maxNum)
        {
            Log.DebugStack(maxNum);
        }

        /// <summary>��ջ����</summary>
        /// <param name="start">��ʼ��������0��DebugStack��ֱ�ӵ�����</param>
        /// <param name="maxNum">��󲶻��ջ������</param>
        public static void DebugStack(int start, int maxNum)
        {
            Log.DebugStack(start, maxNum);
        }

        /// <summary>д��־�¼����󶨸��¼���XTrace�����ٰ���־д����־�ļ���ȥ��</summary>
        public static event EventHandler<WriteLogEventArgs> OnWriteLog
        {
            add { Log.OnWriteLog += value; }
            remove { Log.OnWriteLog -= value; }
        }
        //public static event EventHandler<WriteLogEventArgs> OnWriteLog;

        /// <summary>д��־</summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteLine(String format, params Object[] args)
        {
            Log.WriteLine(format, args);
        }
        #endregion

        #region ʹ�ÿ���̨���
        private static Int32 init = 0;
        /// <summary>ʹ�ÿ���̨�����־��ֻ�ܵ���һ��</summary>
        /// <param name="useColor"></param>
        public static void UseConsole(Boolean useColor = true)
        {
            if (init > 0 || Interlocked.CompareExchange(ref init, 1, 0) != 0) return;
            if (!Runtime.IsConsole) return;

            if (useColor)
                OnWriteLog += XTrace_OnWriteLog2;
            else
                OnWriteLog += XTrace_OnWriteLog;
        }

        private static void XTrace_OnWriteLog(object sender, WriteLogEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        static Dictionary<Int32, ConsoleColor> dic = new Dictionary<Int32, ConsoleColor>();
        static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Blue };
        private static void XTrace_OnWriteLog2(object sender, WriteLogEventArgs e)
        {
            lock (dic)
            {
                ConsoleColor cc;
                var key = e.ThreadID;
                if (!dic.TryGetValue(key, out cc))
                {
                    //lock (dic)
                    {
                        //if (!dic.TryGetValue(key, out cc))
                        {
                            cc = colors[dic.Count % 7];
                            dic[key] = cc;
                        }
                    }
                }
                var old = Console.ForegroundColor;
                Console.ForegroundColor = cc;
                Console.WriteLine(e.ToString());
                Console.ForegroundColor = old;
            }
        }
        #endregion

        #region ����
        private static Boolean? _Debug;
        /// <summary>�Ƿ���ԡ��������ָ����ֵ����ֻ��ʹ�ô���ָ����ֵ������ÿ�ζ���ȡ���á�</summary>
        public static Boolean Debug
        {
            get
            {
                if (_Debug != null) return _Debug.Value;

                try
                {
                    //return Config.GetConfig<Boolean>("NewLife.Debug", Config.GetConfig<Boolean>("Debug", false));
                    return Config.GetMutilConfig<Boolean>(false, "NewLife.Debug", "Debug");
                }
                catch { return false; }
            }
            set { _Debug = value; }
        }

        private static String _TempPath;
        /// <summary>��ʱĿ¼</summary>
        public static String TempPath
        {
            get
            {
                if (_TempPath != null) return _TempPath;

                TempPath = Config.GetConfig<String>("NewLife.TempPath", "XTemp");
                return _TempPath;
            }
            set
            {
                _TempPath = value;
                if (String.IsNullOrEmpty(_TempPath)) _TempPath = "XTemp";
                if (!Path.IsPathRooted(_TempPath)) _TempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _TempPath);
                _TempPath = Path.GetFullPath(_TempPath);
            }
        }
        #endregion

        #region Dump
        /// <summary>д��ǰ�̵߳�MiniDump</summary>
        /// <param name="dumpFile">�����ָ�������Զ�д����־Ŀ¼</param>
        public static void WriteMiniDump(String dumpFile)
        {
            if (String.IsNullOrEmpty(dumpFile))
            {
                dumpFile = String.Format("{0:yyyyMMdd_HHmmss}.dmp", DateTime.Now);
                if (!String.IsNullOrEmpty(LogPath)) dumpFile = Path.Combine(LogPath, dumpFile);
            }

            MiniDump.TryDump(dumpFile, MiniDump.MiniDumpType.WithFullMemory);
        }

        /// <summary>
        /// ����Ҫʹ����windows 5.1 �Ժ�İ汾��������windows�ܾɣ��Ͱ�Windbg�����dll����������һ�㶼û�����⡣
        /// DbgHelp.dll ��windows�Դ��� dll�ļ� ��
        /// </summary>
        static class MiniDump
        {
            [DllImport("DbgHelp.dll")]
            private static extern Boolean MiniDumpWriteDump(
            IntPtr hProcess,
            Int32 processId,
            IntPtr fileHandle,
            MiniDumpType dumpType,
           ref MinidumpExceptionInfo excepInfo,
            IntPtr userInfo,
            IntPtr extInfo);

            /// <summary>MINIDUMP_EXCEPTION_INFORMATION</summary>
            struct MinidumpExceptionInfo
            {
                public UInt32 ThreadId;
                public IntPtr ExceptionPointers;
                public UInt32 ClientPointers;
            }

            [DllImport("kernel32.dll")]
            private static extern uint GetCurrentThreadId();

            public static Boolean TryDump(String dmpPath, MiniDumpType dmpType)
            {
                //ʹ���ļ��������� .dmp�ļ�
                using (FileStream stream = new FileStream(dmpPath, FileMode.Create))
                {
                    //ȡ�ý�����Ϣ
                    Process process = Process.GetCurrentProcess();

                    // MINIDUMP_EXCEPTION_INFORMATION ��Ϣ�ĳ�ʼ��
                    MinidumpExceptionInfo mei = new MinidumpExceptionInfo();

                    mei.ThreadId = (UInt32)GetCurrentThreadId();
                    mei.ExceptionPointers = Marshal.GetExceptionPointers();
                    mei.ClientPointers = 1;

                    //������õ�Win32 API
                    Boolean res = MiniDumpWriteDump(
                    process.Handle,
                    process.Id,
                    stream.SafeFileHandle.DangerousGetHandle(),
                    dmpType,
                   ref mei,
                    IntPtr.Zero,
                    IntPtr.Zero);

                    //��� stream
                    stream.Flush();
                    stream.Close();

                    return res;
                }
            }

            public enum MiniDumpType
            {
                None = 0x00010000,
                Normal = 0x00000000,
                WithDataSegs = 0x00000001,
                WithFullMemory = 0x00000002,
                WithHandleData = 0x00000004,
                FilterMemory = 0x00000008,
                ScanMemory = 0x00000010,
                WithUnloadedModules = 0x00000020,
                WithIndirectlyReferencedMemory = 0x00000040,
                FilterModulePaths = 0x00000080,
                WithProcessThreadData = 0x00000100,
                WithPrivateReadWriteMemory = 0x00000200,
                WithoutOptionalData = 0x00000400,
                WithFullMemoryInfo = 0x00000800,
                WithThreadInfo = 0x00001000,
                WithCodeSegs = 0x00002000
            }
        }
        #endregion
    }
}