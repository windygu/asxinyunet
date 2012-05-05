using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    public enum AdapterType : short
    {
        /// <summary>Ethernet 802.3</summary>>
        Ethernet8023 = 0,
        /// <summary>Token Ring 802.5</summary>>
        TokenRing8025 = 1,
        /// <summary>Fiber Distributed Data Interface</summary>>
        FDDI = 2,
        /// <summary>Wide Area Network</summary>>
        WAN = 3,
        /// <summary>LocalTalk</summary>>
        LocalTalk = 4,
        /// <summary>Ethernet using DIX header format</summary>>
        EthernetUsingDIXHeaderFormat = 5,
        /// <summary>ARCNET</summary>>
        ARCNET = 6,
        /// <summary>ARCNET (878.2)</summary>>
        ARCNET8782 = 7,
        /// <summary>ATM</summary>>
        ATM = 8,
        /// <summary>Wireless</summary>>
        Wireless = 9,
        /// <summary>Infrared Wireless</summary>>
        InfraredWireless = 10,
        /// <summary>Bpc</summary>>
        Bpc = 11,
        /// <summary>CoWan</summary>>
        CoWan = 12,
        /// <summary>1394</summary>>
        _1394 = 13
    }

    public enum NetConnectionStatusType : short
    {
        /// <summary>Disconnected</summary>>
        Disconnected = 0,
        /// <summary>Connecting</summary>>
        Connecting = 1,
        /// <summary>Connected</summary>>
        Connected = 2,
        /// <summary>Disconnecting</summary>>
        Disconnecting = 3,
        /// <summary>Hardware not present</summary>>
        HardwareNotPresent = 4,
        /// <summary>Hardware disabled</summary>>
        HardwareDisabled = 5,
        /// <summary>Hardware malfunction</summary>>
        HardwareMalfunction = 6,
        /// <summary>Media disconnected</summary>>
        MediaDisconnected = 7,
        /// <summary>Authenticating</summary>>
        Authenticating = 8,
        /// <summary>Authentication succeeded</summary>>
        AuthenticationSucceeded = 9,
        /// <summary>Authentication failed</summary>>
        AuthenticationFailed = 10,
        /// <summary>Invalid address</summary>>
        InvalidAddress = 11,
        /// <summary>Credentials required</summary>>
        CredentialsRequired = 12
    }

    /// <summary>Win32_NetworkAdapter Class</summary>>
    /// <remarks>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/win32_networkadapterconfiguration.asp</remarks>
    public class Win32_NetworkAdapter : WMIBase
    {
        private string _adapterType;
        private AdapterType _adapterTypeID;
        private string _caption;
        private string _description;
        private string _deviceID;
        private int _index;
        private bool _installed;
        private string _mACAddress;
        private string _manufacturer;
        private string _name;
        private string _netConnectionID;
        private NetConnectionStatusType _netConnectionStatus;
        private string[] _networkAddresses;
        private string _permanentAddress;
        private string _pNPDeviceID;
        private string _productName;
        private string _serviceName;
        private Int64 _speed;
        private string _status;
        private ManagementObject _mo;

        public Win32_NetworkAdapter(ManagementObject managementObject)
        {
            this._mo = managementObject;
            this.Win32_NetworkAdapter_Init();
        }

        private void Win32_NetworkAdapter_Init()
        {
            this._adapterType = GetPropStr(_mo, "AdapterType");
            this._adapterTypeID = (AdapterType)GetPropShort(_mo, "AdapterTypeID");
            this._caption = GetPropStr(_mo, "Captioin");
            this._description = GetPropStr(_mo, "Description");
            this._deviceID = GetPropStr(_mo, "DeviceID");
            this._index = GetPropInt(_mo, "Index");
            this._installed = GetPropBool(_mo, "Installed");
            this._mACAddress = GetPropStr(_mo, "MACAddress");
            this._manufacturer = GetPropStr(_mo, "Manufacturer");
            this._name = GetPropStr(_mo, "Name");
            this._netConnectionID = GetPropStr(_mo, "NetConnectionID");
            this._netConnectionStatus = (NetConnectionStatusType)GetPropShort(_mo, "NetConnectionStatus");
            this._networkAddresses = GetPropStrs(_mo, "NetworkAddresses");
            this._permanentAddress = GetPropStr(_mo, "PermanentAddress");
            this._pNPDeviceID = GetPropStr(_mo, "PNPDeviceID");
            this._productName = GetPropStr(_mo, "ProductName");
            this._serviceName = GetPropStr(_mo, "ServiceName");
            this._speed = GetPropInt64(_mo, "Speed");
            this._status = GetPropStr(_mo, "Status");
        }

        /// <summary>Network medium in use</summary>>
        public string AdapterType
        {
            get { return this._adapterType; }
        }

        /// <summary>Network medium in use</summary>>
        public AdapterType AdapterTypeID
        {
            get { return this._adapterTypeID; }
        }

        /// <summary>Short description of the object¡ªa one-line string</summary>>
        public string Caption
        {
            get { return this._caption; }
        }

        /// <summary>Description of the object</summary>>
        public string Description
        {
            get { return this._description; }
        }

        /// <summary>Unique identifier of the network adapter from other devices on the system</summary>>
        public string DeviceID
        {
            get { return this._deviceID; }
        }

        /// <summary>Index number of the network adapter, stored in the system registry</summary>>
        public int Index
        {
            get { return this._index; }
        }

        /// <summary>If True, the network adapter is installed in the system</summary>>
        public bool Installed
        {
            get { return this._installed; }
        }

        /// <summary>Media access control address for this network adapter</summary>>
        public string MACAddress
        {
            get { return WMILib.GetMACAddress(this._mACAddress); }
        }

        /// <summary>MACAddress Init Value</summary>>
        public string MACAddressInit
        {
            get { return this._mACAddress; }
        }

        /// <summary>Name of the network adapter's manufacturer</summary>>
        /// <remarks>Example: "3COM"</remarks>
        public string Manufacturer
        {
            get { return this._manufacturer; }
        }

        /// <summary>Label by which the object is known</summary>>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>Name of the network connection as it appears in the Network Connections Control Panel program</summary>>
        public string NetConnectionID
        {
            get { return this._netConnectionID; }
        }

        /// <summary>State of the network adapter's connection to the network</summary>>
        public NetConnectionStatusType NetConnectionStatus
        {
            get { return this._netConnectionStatus; }
        }

        /// <summary>Array of network addresses for an adapter</summary>>
        public string[] NetworkAddresses
        {
            get { return this._networkAddresses; }
        }

        /// <summary>Network address hard-coded into an adapter</summary>>
        public string PermanentAddress
        {
            get { return this._permanentAddress; }
        }

        /// <summary>Windows Plug and Play device identifier of the logical device</summary>>
        /// <remarks>Example: "*PNP030b"</remarks>
        public string PNPDeviceID
        {
            get { return this._pNPDeviceID; }
        }

        /// <summary>Product name of the network adapter</summary>>
        /// <remarks>Example: "Fast EtherLink XL"</remarks>
        public string ProductName
        {
            get { return this._productName; }
        }

        /// <summary>Service name of the network adapter</summary>>
        /// <remarks>Example: "Elnkii"</remarks>
        public string ServiceName
        {
            get { return this._serviceName; }
        }

        /// <summary>Estimate of the current bandwidth in bits per second</summary>>
        public Int64 Speed
        {
            get { return this._speed; }
        }

        /// <summary>Current status of the object. Various operational and non-operational statuses can be defined</summary>>
        /// <remarks>Values are:"OK"/"Error"/"Degraded"/"Unknown"/"Pred Fail"/"Starting"/"Stopping"/"Service"</remarks>
        public string Status
        {
            get { return this._status; }
        }
    }
}
