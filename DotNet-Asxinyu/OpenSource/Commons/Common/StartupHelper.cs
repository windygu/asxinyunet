namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class StartupHelper
    {
        private const int 3xodQsKC6 = 1;
        private static Mutex eMSUYugy4 = null;
        private static RegistryKey y3vHWmTuH = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd136), true);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AppAlreadyRunning(string app)
        {
            try
            {
                eMSUYugy4 = Mutex.OpenExisting(app);
                return true;
            }
            catch (Exception)
            {
                eMSUYugy4 = new Mutex(false, app);
            }
            finally
            {
                Application.ApplicationExit += new EventHandler(StartupHelper.XxQqQ66mW);
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CleanupMutex()
        {
            XxQqQ66mW(null, null);
        }

        [DllImport("User32.dll", EntryPoint="ShowWindowAsync")]
        private static extern bool EPgfA8o8U(IntPtr, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void HandleRunningInstance(Process instance)
        {
            MessageUtil.ShowError(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd11c));
            EPgfA8o8U(instance.MainWindowHandle, 1);
            hudMECjTG(instance.MainWindowHandle);
        }

        [DllImport("User32.dll", EntryPoint="SetForegroundWindow")]
        private static extern bool hudMECjTG(IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void RunAtStartup(string app, bool shouldRun)
        {
            try
            {
                if (shouldRun)
                {
                    y3vHWmTuH.SetValue(app, Environment.CommandLine);
                }
                else
                {
                    y3vHWmTuH.DeleteValue(app, false);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd0dc) + exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process RunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (Process process2 in processesByName)
            {
                if ((process2.Id != currentProcess.Id) && (Assembly.GetExecutingAssembly().Location.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd110), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd116)) == currentProcess.MainModule.FileName))
                {
                    return process2;
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool WillRunAtStartup(string app)
        {
            try
            {
                return object.Equals(y3vHWmTuH.GetValue(app), Environment.CommandLine);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void XxQqQ66mW(object, EventArgs)
        {
            try
            {
                if (eMSUYugy4 != null)
                {
                    eMSUYugy4.ReleaseMutex();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                eMSUYugy4 = null;
            }
        }
    }
}

