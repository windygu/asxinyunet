using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>Event Type</summary>>
    public enum EventType : ushort
    {
        /// <summary>Error</summary>>
        Error = 1,
        /// <summary>Warning</summary>>
        Warning = 2,
        /// <summary>Information</summary>>
        Information = 3,
        /// <summary>Security audit success</summary>>
        SecurityAuditSuccess = 4,
        /// <summary>Security audit failure</summary>>
        SecurityAuditFailure = 5
    }

    /// <summary>Win32_NTLogEvent Class</summary>>
    /// <remarks>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/win32_ntlogevent.asp</remarks>
    public class Win32_NTLogEvent :WMIBase
    {
        private ushort _category;
        private string _categoryString;
        private string _computerName;
        private ushort[] _data;
        private ushort _eventCode;
        private uint _eventIdentifier;
        private EventType _eventType;
        private string[] _insertionStrings;
        private string _logfile;
        private string _message;
        private uint _recordNumber;
        private string _sourceName;
        private DateTime _timeGenerated;
        private DateTime _timeWritten;
        private string _eventTypeString;
        private string _user;
        private ManagementObject _mo;

        /// <summary>¹¹Ôìº¯Êý</summary>>
        /// <param name="manageObject"></param>
        public Win32_NTLogEvent(ManagementObject manageObject)
        {
            this._mo = manageObject;
            this.Win32_NTLogEvent_Init();
        }

        private void Win32_NTLogEvent_Init()
        {
            this._category = base.GetPropUShort(_mo, "Category");
            this._categoryString = base.GetPropStr(_mo, "CategoryString");
            this._computerName = base.GetPropStr(_mo, "ComputerName");
            this._data = base.GetPropUShorts(_mo, "Data");
            this._eventCode = base.GetPropUShort(_mo, "EventCode");
            this._eventIdentifier = base.GetPropUInt(_mo, "EventIdentifier");
            this._eventType = (EventType)base.GetPropUShort(_mo, "EventType");
            this._insertionStrings = base.GetPropStrs(_mo, "InsertionStrings");
            this._logfile = base.GetPropStr(_mo, "Logfile");
            this._message = base.GetPropStr(_mo, "Message");
            this._recordNumber = base.GetPropUInt(_mo, "RecordNumber");
            this._sourceName = base.GetPropStr(_mo, "SourceName");
            this._timeGenerated = this.GetDateTime(base.GetPropStr(_mo, "TimeGenerated"));
            this._timeWritten = base.GetDateTime(base.GetPropStr(_mo, "TimeWritten"));
            this._eventTypeString = base.GetPropStr(_mo, "Type");
            this._user = base.GetPropStr(_mo, "User");
        }

        /// <summary>Subcategory for this event. This subcategory is source-specific</summary>>
        public ushort Category
        {
            get { return this._category; }
        }

        /// <summary>ranslation of the subcategory. The translation is source-specific</summary>>
        public string CategoryString
        {
            get { return this._categoryString; }
        }

        /// <summary>Name of the computer that generated this event</summary>>
        public string ComputerName
        {
            get { return this._computerName; }
        }

        /// <summary>List of the binary data that accompanied the report of the Windows NT event</summary>>
        public ushort[] Data
        {
            get { return this._data; }
        }

        /// <summary>Value of the lower 16-bits of the EventIdentifier property</summary>>
        /// <remarks>It is present to match the value displayed in the Windows NT Event Viewer. Note that two events from the same source may have the same value for this property but may have different severity and EventIdentifier values.</remarks>
        public ushort EventCode
        {
            get { return this._eventCode; }
        }

        /// <summary>Identifier of the event</summary>>
        /// <remarks>This is specific to the source that generated the event log entry and is used, together with SourceName, to uniquely identify a Windows NT event type</remarks>
        public uint EventIdentifier
        {
            get { return this._eventIdentifier; }
        }

        /// <summary>EventType</summary>>
        public EventType NTLogEventType
        {
            get { return this._eventType; }
        }

        /// <summary>List of the insertion strings that accompanied the report of the Windows NT event</summary>>
        public string[] InsertionStrings
        {
            get { return this._insertionStrings; }
        }

        /// <summary>Name of Windows NT event log file</summary>>
        /// <remarks>This is used together with RecordNumber to uniquely identify an instance of this class</remarks>
        public string Logfile
        {
            get { return this._logfile; }
        }

        /// <summary>Event message as it appears in the Windows NT event log</summary>>
        /// <remarks>This is a standard message with zero or more insertion strings supplied by the source of the Windows NT event. The insertion strings are inserted into the standard message in a predefined format. If there are no insertion strings or there is a problem inserting the insertion strings, only the standard message will be present in this field</remarks>
        public string Message
        {
            get { return this._message; }
        }

        /// <summary>Identifies the event within the Windows NT event log file</summary>>
        /// <remarks> This is specific to the log file and is used together with the log file name to uniquely identify an instance of this class</remarks>
        public uint RecordNumber
        {
            get { return this._recordNumber; }
        }

        /// <summary>Name of the source (application, service, driver, subsystem) that generated the entry</summary>>
        /// <remarks>It is used, together with EventIdentifier to uniquely identify an Windows NT event type</remarks>
        public string SourceName
        {
            get { return this._sourceName; }
        }

        /// <summary>Source generated the event</summary>>
        public DateTime TimeGenerated
        {
            get { return this._timeGenerated; }
        }

        /// <summary>Event was written to the logfile</summary>>
        public DateTime TimeWritten
        {
            get { return this._timeWritten; }
        }

        /// <summary>Type of event. This is an enumerated string</summary>>
        /// <remarks>It is preferable to use the EventType property rather than the Type property</remarks>
        public string EventTypeString
        {
            get { return this._eventTypeString; }
        }

        /// <summary>User name of the logged-on user when the event occurred</summary>>
        /// <remarks>If the user name cannot be determined, this will be NULL</remarks>
        public string User
        {
            get { return this._user; }
        }
    }
}
