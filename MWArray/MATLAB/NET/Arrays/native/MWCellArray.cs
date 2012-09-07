namespace MathWorks.MATLAB.NET.Arrays.native
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWCellArray : MWArray, ICloneable, IEquatable<MWCellArray>
    {
        private static readonly MWCellArray _Empty = new MWCellArray();
        public MWCellArray()
        {
            base.array_Type = MWArrayType.Cell;
        }

        public MWCellArray(int rows, int columns) : base(rows, columns)
        {
            base.array_Type = MWArrayType.Cell;
        }

        public MWCellArray(params int[] dimensions) : base(dimensions)
        {
            base.array_Type = MWArrayType.Cell;
        }

        public object this[int[] indices] { get { return base.get(indices); } set { base.set(indices, value); } }
        public static MWCellArray Empty { get { return (MWCellArray) _Empty.Clone(); } }
        public override object Clone()
        {
            MWCellArray target = (MWCellArray) base.MemberwiseClone();
            base.deepCopy(target);
            return target;
        }

        public override bool Equals(object obj) { return (obj is MWCellArray) && this.Equals(obj as MWCellArray); }

        public bool Equals(MWCellArray other) { return base.Equals(other); }
    }
}
