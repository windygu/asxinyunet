namespace InfoSecurity.PublicResources
{
    using System;
    using System.Collections;

    public abstract class HardwareInfo
    {
        protected Hashtable PValues;
        protected WMI_ClassNames Win32_Class;

        protected HardwareInfo() {  }

        public virtual string GetAllInfo()
        {
            return SystemInfo.GetWin32_ClassAllProperValues(this.Win32_Class);
        }

        public virtual string[] GetAllProperties()
        {
            string[] strArray = new string[this.PValues.Count];
            int num = 0;
            foreach (DictionaryEntry entry in this.PValues)
            {
                strArray[num++] = entry.Key.ToString();
            }
            return strArray;
        }

        public virtual string GetCaption()
        {
            return this.GetWin32_ClassPropertyValueByName("Caption");
        }

        public virtual string GetDescription()
        {
            return this.GetWin32_ClassPropertyValueByName("Description");
        }

        public virtual string GetName()
        {
            return this.GetWin32_ClassPropertyValueByName("Name");
        }

        public virtual string GetWin32_ClassPropertyValueByName(string propertyName)
        {
            string key = propertyName.ToLower();
            string str2 = null;
            if (this.PValues.ContainsKey(key))
            {
                object obj2 = this.PValues[key];
                if (obj2 != null) str2 = obj2.ToString();
            }
            return str2;
        }
    }
}
