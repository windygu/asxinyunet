using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>StatusCode Type</summary>>
    public enum StatusCodeType : int
    {
        /// <summary>None</summary>>
        None = -1,
        /// <summary>Success</summary>>
        Success = 0,
        /// <summary>Buffer Too Small</summary>>
        BufferTooSmall = 11001,
        /// <summary>Destination Net Unreachable</summary>>
        DestinationNetUnreachable = 11002,
        /// <summary>Destination Host Unreachable</summary>>
        DestinationHostUnreachable = 11003,
        /// <summary>Destination Protocol Unreachable</summary>>
        DestinationProtocolUnreachable = 11004,
        /// <summary>Destination Port Unreachable</summary>>
        DestinationPortUnreachable = 11005,
        /// <summary>No Resources</summary>>
        NoResources = 11006,
        /// <summary>Bad Option</summary>>
        BadOption = 11007,
        /// <summary>Hardware Error</summary>>
        HardwareError = 11008,
        /// <summary>Packet Too Big</summary>>
        PacketTooBig = 11009,
        /// <summary>Request Timed Out</summary>>
        RequestTimedOut = 11010,
        /// <summary>Bad Request</summary>>
        BadRequest = 11011,
        /// <summary>Bad Route</summary>>
        BadRoute = 11012,
        /// <summary>TimeToLive Expired Transit</summary>>
        TimeToLiveExpiredTransit = 11013,
        /// <summary>TimeToLive Expired Reassembly</summary>>
        TimeToLiveExpiredReassembly = 11014,
        /// <summary>Parameter Problem</summary>>
        ParameterProblem = 11015,
        /// <summary>Source Quench</summary>>
        SourceQuench = 11016,
        /// <summary>Option Too Big</summary>>
        OptionTooBig = 11017,
        /// <summary>Bad Destination</summary>>
        BadDestination = 11018,
        /// <summary>Negotiating IPSEC</summary>>
        NegotiatingIPSEC = 11032,
        /// <summary>General Failure</summary>>
        GeneralFailure = 11050
    }

    /// <summary>Win32_PingStatus Class</summary>>
    /// <remarks>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/win32_pingstatus.asp</remarks>
    public class Win32_PingStatus : WMIBase
    {
        private string _address;
        private uint _bufferSize = 32;
        private string _protocolAddress;
        private uint _replySize;
        private uint _responseTime;
        private StatusCodeType _statusCode;
        private uint _timeout = 1000;
        private ManagementObject _mo;
        private string _computerName;

        public Win32_PingStatus(ManagementObject manageObject)
        {
            this._mo = manageObject;
            this.Win32_PingStatus_Init();
        }

        private void Win32_PingStatus_Init()
        {
            this._address = base.GetPropStr(_mo, "Address");
            this._bufferSize = base.GetPropUInt(_mo, "BufferSize");
            this._protocolAddress = base.GetPropStr(_mo, "ProtocolAddress");
            this._replySize = base.GetPropUInt(_mo, "ReplySize");
            this._responseTime = base.GetPropUInt(_mo, "ResponseTime");
            this._statusCode = (StatusCodeType)base.GetPropInt(_mo, "StatusCode", -1);
            this._timeout = base.GetPropUInt(_mo, "Timeout");
        }

        /// <summary>Value of the address requested</summary>>
        /// <remarks>The form of the value can be either the hostname ('wxyz1234') or IP address </remarks>
        public string Address
        {
            get { return this._address; }
        }

        /// <summary>Buffer size sent with the ping command. The default value is 32.</summary>>
        public uint BufferSize
        {
            get { return this._bufferSize; }
        }

        /// <summary>Address that the destination used to reply</summary>>
        /// <remarks>The default is ""</remarks>
        public string ProtocolAddress
        {
            get { return this._protocolAddress; }
        }

        /// <summary>Represents the size of the buffer returned</summary>>
        public uint ReplySize
        {
            get { return this._replySize; }
        }

        /// <summary>Time elapsed to handle the request</summary>>
        public uint ResponseTime
        {
            get { return this._responseTime; }
        }

        /// <summary>Ping command status codes</summary>>
        public StatusCodeType StatusCode
        {
            get { return this._statusCode; }
        }

        /// <summary>Time-out value in milliseconds</summary>>
        /// <remarks>If a response is not received in this time, no response is assumed. The default is 1000 milliseconds</remarks>
        public uint Timeout
        {
            get { return this._timeout; }
        }

        public string computerName
        {
            get { return this._computerName; }
            set { this._computerName = value; }
        }
    }
}
