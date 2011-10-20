﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NewLife.Log;

namespace XCoder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException); 
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                if (XConfig.Current.LastUpdate.Date < DateTime.Now.Date)
                {
                    XConfig.Current.LastUpdate = DateTime.Now;

                    AutoUpdate au = new AutoUpdate();
                    au.LocalVersion = new Version(Engine.FileVersion);
                    au.VerSrc = "http://files.cnblogs.com/nnhy/XCoderVer.xml";
                    au.ProcessAsync();
                }
            }
            catch (Exception ex)
            {
                XTrace.WriteLine(ex.ToString());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            XTrace.WriteLine("" + e.ExceptionObject);
            if (e.IsTerminating)
            {
                XTrace.WriteLine("异常退出！");
                XTrace.WriteMiniDump(null);
                MessageBox.Show("" + e.ExceptionObject, "异常退出", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            XTrace.WriteLine(e.Exception.ToString());
        }
    }
}