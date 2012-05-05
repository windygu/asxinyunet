using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>Win32_Process</summary>>
    /// <remarks>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/create_method_in_class_win32_process.asp</remarks>
    public class Win32_Process : WMIBase
    {
        private string _caption;
        private string _commandLine;
        private ManagementObject _mo;
        private ManagementClass _mc;

        public Win32_Process(ManagementObject manageObject)
        {
            this._mo = manageObject;
            this.Win32_Process_Init();
        }

        public Win32_Process(ManagementClass managementClass)
        {
            this._mc = managementClass;
        }

        public void Win32_Process_Init()
        {
            this._caption = base.GetPropStr(_mo, "Caption");
            this._commandLine = base.GetPropStr(_mo, "CommandLine");
        }

        /// <summary>Short description of an object???a one-line string.</summary>>
        public string Caption
        {
            get { return this._caption; }
        }

        /// <summary>Command line used to start a specific process, if applicable. This property is new for Windows XP</summary>>
        public string CommandLine
        {
            get { return this._commandLine; }
        }

        /// <summary>Creates a new process</summary>>
        /// <param name="commandLine">Command line to execute</param>
        /// <param name="currentDirectory">Current drive and directory for the child process</param>
        /// <param name="processStartupInformation">The startup configuration of a Windows process</param>
        /// <param name="processId">Global process identifier that can be used to identify a process</param>
        public void Create(string commandLine, string currentDirectory, Win32_ProcessStartup processStartupInformation,ref uint processId)
        {
            object[] methodArgs = { commandLine, currentDirectory, processStartupInformation, processId };
            ManagementOperationObserver observer = new ManagementOperationObserver();

            this._mc.InvokeMethod(observer, "Create", methodArgs);
            processId = Convert.ToUInt32(methodArgs[3]);
        }

        public void Create(string commandLine, string currentDirectory, ref uint processId)
        {
            this.Create(commandLine, currentDirectory, null, ref processId);
        }

        public static void RemoteExec(string computerName, string commandLine, string currentDirectory, ref uint processId)
        {

            WMIProvider wmiProvider = new WMIProvider(computerName);
            ManagementClass mc = wmiProvider.GetManagementClass("Win32_Process");

            object[] methodArgs = { commandLine, currentDirectory, null, processId };
            mc.InvokeMethod("Create", methodArgs);
            processId = Convert.ToUInt32(methodArgs[3]); 
        }
    }
}
