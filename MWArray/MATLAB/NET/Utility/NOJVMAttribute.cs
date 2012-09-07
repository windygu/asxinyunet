namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class NOJVMAttribute : Attribute
    {
        private bool disableJVM;

        public NOJVMAttribute(bool JVMDisable)
        {
            this.disableJVM = JVMDisable;
        }

        public bool JVMDisabled { get { return this.disableJVM; } }
    }
}
