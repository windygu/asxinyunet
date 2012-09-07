namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class LOGFILEAttribute : Attribute
    {
        private string fName;

        public LOGFILEAttribute(string fileName)
        {
            string environmentVariable = Environment.GetEnvironmentVariable("MW_LOGFILE");
            if (environmentVariable != null)
                this.fName = environmentVariable;
            else
                this.fName = fileName;
        }

        public string LogfileName { get { return this.fName; } }
    }
}
