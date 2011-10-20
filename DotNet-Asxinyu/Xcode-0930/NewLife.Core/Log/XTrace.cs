using System;
using NewLife.Configuration;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

//namespace XLog
//{
//    /// <summary>
//    /// ��־�࣬�������ٵ��Թ���
//    /// </summary>
//    public class XTrace : NewLife.Log.XTrace { }
//}

namespace NewLife.Log
{
    /// <summary>
    /// ��־�࣬�������ٵ��Թ���
    /// </summary>
    public class XTrace
    {
        #region д��־
        private static TextFileLog Log = TextFileLog.Create(Config.GetConfig<String>("NewLife.LogPath"));
        /// <summary>
        /// ��־·��
        /// </summary>
        public static String LogPath { get { return Log.LogPath; } }

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        public static void WriteLine(String msg)
        {
            Log.WriteLine(msg);
        }

        /// <summary>
        /// ����쳣��־
        /// </summary>
        /// <param name="ex">�쳣��Ϣ</param>
        public static void WriteException(Exception ex)
        {
            Log.WriteLine(ex.ToString());
        }

        /// <summary>
        /// ����쳣��־
        /// </summary>
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
            Log.DebugStack();
        }

        /// <summary>
        /// ��ջ���ԡ�
        /// </summary>
        /// <param name="maxNum">��󲶻��ջ������</param>
        public static void DebugStack(int maxNum)
        {
            Log.DebugStack(maxNum);
        }

        /// <summary>
        /// д��־�¼����󶨸��¼���XTrace�����ٰ���־д����־�ļ���ȥ��
        /// </summary>
        public static event EventHandler<WriteLogEventArgs> OnWriteLog
        {
            add { Log.OnWriteLog += value; }
            remove { Log.OnWriteLog -= value; }
        }
        //public static event EventHandler<WriteLogEventArgs> OnWriteLog;

        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteLine(String format, params Object[] args)
        {
            Log.WriteLine(format, args);
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
                //String str = ConfigurationManager.AppSettings["NewLife.Debug"];
                //if (String.IsNullOrEmpty(str)) str = ConfigurationManager.AppSettings["Debug"];
                //if (String.IsNullOrEmpty(str)) return false;
                //if (str == "1") return true;
                //if (str == "0") return false;
                //if (str.Equals(Boolean.FalseString, StringComparison.OrdinalIgnoreCase)) return false;
                //if (str.Equals(Boolean.TrueString, StringComparison.OrdinalIgnoreCase)) return true;
                //return false;

                return Config.GetConfig<Boolean>("NewLife.Debug", Config.GetConfig<Boolean>("Debug", false));
            }
            set { _Debug = value; }
        }
        #endregion

        #region Dump
        /// <summary>
        /// д��ǰ�̵߳�MiniDump
        /// </summary>
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

            /// <summary>
            /// MINIDUMP_EXCEPTION_INFORMATION
            /// </summary>
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