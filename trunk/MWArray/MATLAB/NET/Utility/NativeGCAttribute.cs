namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class NativeGCAttribute : Attribute
    {
        private int gcBlockSize;
        private bool gcEnabled;

        public NativeGCAttribute(bool enableGCTrigger)
        {
            this.gcEnabled = enableGCTrigger;
        }

        public NativeGCAttribute(bool enableGCTrigger, int GCBlockSize)
        {
            this.gcEnabled = enableGCTrigger;
            this.gcBlockSize = GCBlockSize;
        }

        public int GCBlockSize { get { return this.gcBlockSize; } set { this.gcBlockSize = value; } }

        public bool GCEnabled { get { return this.gcEnabled; } }
    }
}
