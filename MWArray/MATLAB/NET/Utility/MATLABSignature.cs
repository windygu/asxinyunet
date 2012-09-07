namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class MATLABSignature : Attribute
    {
        public readonly bool HasVarArgIn;
        public readonly int Inputs;
        public readonly string Name;
        public readonly int Outputs;

        public MATLABSignature(string name, int inputs, int outputs, int hasvarargin)
        {
            this.Name = name;
            this.Inputs = inputs;
            this.Outputs = outputs;
            this.HasVarArgIn = Convert.ToBoolean(hasvarargin);
        }
    }
}
