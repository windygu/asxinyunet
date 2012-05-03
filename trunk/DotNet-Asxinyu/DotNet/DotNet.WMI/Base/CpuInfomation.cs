namespace InfoSecurity.PublicResources
{
    using System;

    public class CpuInfomation : HardwareInfo
    {
        public CpuInfomation()
        {
            base.Win32_Class = WMI_ClassNames.Win32_Processor;
            base.PValues = SystemInfo.GetAllWin32_ClassPropValuesIntoTable(base.Win32_Class);
        }

        public string GetManufacturer()
        {
            return this.GetWin32_ClassPropertyValueByName("Manufacturer");
        }

        public string GetMaxClockSpeed()
        {
            return this.GetWin32_ClassPropertyValueByName("MaxClockSpeed");
        }

        public virtual string GetPNPDeviceID()
        {
            return this.GetWin32_ClassPropertyValueByName("PNPDeviceID");
        }

        public string GetProcessorId()
        {
            return this.GetWin32_ClassPropertyValueByName("ProcessorId");
        }

        public string GetVersion()
        {
            return this.GetWin32_ClassPropertyValueByName("Version");
        }
    }
}
