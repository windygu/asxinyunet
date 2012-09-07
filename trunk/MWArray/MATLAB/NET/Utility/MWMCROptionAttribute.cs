namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true, Inherited=false)]
    public class MWMCROptionAttribute : Attribute
    {
        private string option;

        public MWMCROptionAttribute(string OptVal)
        {
            this.option = OptVal;
        }

        public string MWMCROption { get { return this.option; } }
    }
}
