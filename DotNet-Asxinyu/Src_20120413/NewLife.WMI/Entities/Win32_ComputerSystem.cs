using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>DomainRoleType</summary>>
    public enum DomainRoleType : ushort
    {
        /// <summary>Standalone Workstation</summary>>
        StandaloneWorkstation = 0,
        /// <summary>Member Workstation</summary>>
        MemberWorkstation = 1,
        /// <summary>Standalone Server</summary>>
        StandaloneServer = 2,
        /// <summary>Member Server</summary>>
        MemberServer = 3,
        /// <summary>Backup Domain Controller</summary>>
        BackupDomainController = 4,
        /// <summary>Primary Domain Controller</summary>>
        PrimaryDomainController = 5
    }

    /// <summary>Win32_ComputerSystem Class</summary>>
    public class Win32_ComputerSystem : WMIBase
    {
        private string _bootupState;
        private string _caption;
        private string _creationClassName;
        private string _description;
        private string _dNSHostName;
        private string _domain;
        private DomainRoleType _domainRole;
        private bool _infraredSupported;
        private DateTime _installDate;
        private string _manufacturer;
        private string _model;
        private string _name;
        private int _numberOfProcessors;
        private string _primaryOwnerName;
        private string[] _roles;
        private string _systemType;
        private UInt64 _totalPhysicalMemory;
        private string _userName;
        private string _workgroup;
        private ManagementObject _mo;

        public Win32_ComputerSystem(ManagementObject managementObject)
        {
            this._mo = managementObject;
            this.Win32_ComputerSystem_Init();
        }

        private void Win32_ComputerSystem_Init()
        {
            this._bootupState = base.GetPropStr(_mo, "BootupState");
            this._caption = base.GetPropStr(_mo, "Caption");
            this._creationClassName = base.GetPropStr(_mo, "CreationClassName");
            this._description = base.GetPropStr(_mo, "Description");
            this._dNSHostName = base.GetPropStr(_mo, "DNSHostName");
            this._domain = base.GetPropStr(_mo, "Domain");
            this._domainRole = (DomainRoleType)base.GetPropUShort(_mo, "DomainRole");
            this._infraredSupported = base.GetPropBool(_mo, "InfraredSupported");
            this._installDate = base.GetPropDateTime(_mo, "InstallDate");
            this._manufacturer = base.GetPropStr(_mo, "Manufacturer");
            this._model = base.GetPropStr(_mo, "Model");
            this._name = base.GetPropStr(_mo, "Name");
            this._numberOfProcessors = base.GetPropInt(_mo, "NumberOfProcessors");
            this._primaryOwnerName = base.GetPropStr(_mo, "PrimaryOwnerName");
            this._roles = base.GetPropStrs(_mo, "Roles");
            this._systemType = base.GetPropStr(_mo, "SystemType");
            this._totalPhysicalMemory = base.GetPropUInt64(_mo, "TotalPhysicalMemory");
            this._userName = base.GetPropStr(_mo, "UserName");
            this._workgroup = base.GetPropStr(_mo,"Workgroup");
        }

        /// <summary>System is started. Fail-safe boot bypasses the user startup files¡ªalso called SafeBoot</summary>>
        /// <remarks>"Normal boot"/"Fail-safe boot"/"Fail-safe with network boot"</remarks>
        public string BootupState
        {
            get { return this._bootupState; }
        }

        /// <summary>Short description of the object¡ªa one-line string</summary>>
        public string Caption
        {
            get { return this._caption; }
        }

        /// <summary>Name of the first concrete class in the inheritance chain of an instance</summary>>
        public string CreationClassName
        {
            get { return this._creationClassName; }
        }

        /// <summary>Description of the object</summary>>
        public string Description
        {
            get { return this._description; }
        }

        /// <summary>Name of local computer according to the domain name server (DNS)</summary>>
        public string DNSHostName
        {
            get { return this._dNSHostName; }
        }

        /// <summary>Name of the domain to which a computer belongs</summary>>
        /// <remarks>If the computer is not part of a domain, then the name of the workgroup is returned</remarks>
        public string Domain
        {
            get { return this._domain; }
        }

        /// <summary>Role of a computer in an assigned domain workgroup. A domain workgroup is a collection of computers on the same network</summary>>
        /// <remarks>For example, a DomainRole property may show that a computer is a member workstation</remarks>
        public DomainRoleType DomainRole
        {
            get { return this._domainRole; }
        }

        /// <summary>If True, an infrared (IR) port exists on a computer system</summary>>
        public bool InfraredSupported
        {
            get { return this._infraredSupported; }
        }

        /// <summary>Object is installed</summary>>
        /// <remarks>An object does not need a value to indicate that it is installed</remarks>
        public DateTime InstallDate
        {
            get { return this._installDate; }
        }

        /// <summary>Name of a computer manufacturer</summary>>
        /// <remarks>Example: Adventure Works</remarks>
        public string Manufacturer
        {
            get { return this._manufacturer; }
        }

        /// <summary>Product name that a manufacturer gives to a computer</summary>>
        public string Model
        {
            get { return this._model; }
        }

        /// <summary>Key of a CIM_System instance in an enterprise environment</summary>>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>Number of processors currently available on a system</summary>>
        public int NumberOfProcessors
        {
            get { return this._numberOfProcessors; }
        }

        /// <summary>Name of the primary system owner</summary>>
        public string PrimaryOwnerName
        {
            get { return this._primaryOwnerName; }
        }

        /// <summary>List that specifies the roles of a system in the information technology environment</summary>>
        public string[] Roles
        {
            get { return this._roles; }
        }

        /// <summary>System running on the Windows computer</summary>>
        /// <remarks>"X86-based PC"/MIPS-based PC"/"Alpha-based PC"/"Power PC"/"SH-x PC"/"StrongARM PC"/"64-bit Intel PC"/"64-bit Alpha PC"/"Unknown"/"X86-Nec98 PC"</remarks>
        public string SystemType
        {
            get { return this._systemType; }
        }

        /// <summary>Total size of physical memory</summary>>
        /// <remarks>Qualifiers: Units(Bytes)</remarks>
        public UInt64 TotalPhysicalMemory
        {
            get { return this._totalPhysicalMemory; }
        }

        /// <summary>Name of a user that is logged on currently</summary>>
        public string UserName
        {
            get { return this._userName; }
        }

        /// <summary>Name of the workgroup for this computer</summary>>
        public string Workgroup
        {
            get { return this._workgroup; }
        }
    }
}
