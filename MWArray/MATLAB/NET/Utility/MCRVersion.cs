namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class MCRVersion : Attribute
    {
        public readonly string Major;
        public readonly string Minor;
        public readonly string Update;

        public MCRVersion(string major, string minor, string update)
        {
            this.Major = major;
            this.Minor = minor;
            this.Update = update;
        }
    }
}
