using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>共享信息类</summary>>
    public class Win32_Share
    {
        public Win32_Share[] GetWin32_Share(ManagementObject[] mo)
        {
            ArrayList result = new ArrayList();
            foreach (ManagementObject item in mo)
            {
                Win32_Share share = new Win32_Share();
                share._AccessMask = Convert.ToString(item.Properties["AccessMask"].Value);
                share._AllowMaximum = Convert.ToBoolean(item.Properties["AllowMaximum"].Value);
                share._Caption = Convert.ToString(item.Properties["Caption"].Value);
                share._Description = Convert.ToString(item.Properties["Description"].Value);
                share._Name = Convert.ToString(item.Properties["Name"].Value);
                share._Path = Convert.ToString(item.Properties["Path"].Value);
                share._Status = Convert.ToString(item.Properties["Status"].Value);

                result.Add(share);
            }

            return (Win32_Share[])result.ToArray(typeof(Win32_Share));
        }

        private string _AccessMask = string.Empty;
        public string AccessMask
        {
            set { _AccessMask = value; }
            get { return _AccessMask; }
        }

        private bool _AllowMaximum = true;
        public bool AllowMaximum
        {
            set { _AllowMaximum = value; }
            get { return _AllowMaximum; }
        }

        private string _Caption = string.Empty;
        public string Caption
        {
            set { _Caption = value; }
            get { return _Caption; }
        }

        private string _Description = string.Empty;
        public string Descripton
        {
            set { _Description = value; }
            get { return _Description; }
        }

        private string _Name = string.Empty;
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        private string _Path = string.Empty;
        public string Path
        {
            set { _Path = value; }
            get { return _Path; }
        }

        private string _Status = string.Empty;
        public string Status
        {
            set { _Status = value; }
            get { return _Path; }
        }

        private int _Type = -1;
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
    }
}
