namespace MathWorks.MATLAB.NET.Arrays.native
{
    using System;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWArray : ICloneable
    {
        internal static ResourceManager resourceManager;
        private int[] dims;
        private int numOfElem;
        private int maxValidIndex;
        private object[] flatArray;
        internal MWArrayType array_Type;
        private int[] axisWtArr;
        static MWArray()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string str = executingAssembly.GetManifestResourceNames()[0];
            resourceManager = new ResourceManager(str.TrimEnd("resources".ToCharArray()).TrimEnd(".".ToCharArray()), executingAssembly);
        }

        internal MWArray()
        {
            this.dims = new int[2];
            this.flatArray = new object[0];
            this.axisWtArr = new int[0];
            this.numOfElem = 0;
            this.MaxValidIndex = 0;
        }

        internal MWArray(int rows, int cols) : this(new int[] { rows, cols }) {  }

        internal MWArray(int[] inDims)
        {
            this.setDims(inDims);
            this.setNumOfElem(inDims);
            this.createAxisWeightArray();
            this.initNativeArray(this.numOfElem);
        }

        public MWArrayType ArrayType { get { return this.array_Type; } }
        public int[] Dimensions { get { return (int[]) this.dims.Clone(); } }
        public bool IsCellArray { get { return this.array_Type == MWArrayType.Cell; } }
        public bool IsCharArray { get { return this.array_Type == MWArrayType.Character; } }
        public bool IsLogicalArray { get { return this.array_Type == MWArrayType.Logical; } }
        public bool IsNumericArray { get { return this.array_Type == MWArrayType.Numeric; } }
        public bool IsStructArray { get { return this.array_Type == MWArrayType.Structure; } }
        public bool IsEmpty { get { return this.NumberOfElements == 0; } }
        public int NumberofDimensions { get { return this.dims.Length; } }
        public int NumberOfElements { get { return this.numOfElem; } protected set { this.numOfElem = value; } }
        private int MaxValidIndex { get { return this.maxValidIndex; } set { this.maxValidIndex = value; } }
        public override bool Equals(object obj)
        {
            MWArray array = (MWArray) obj;
            return object.Equals(array.Dimensions, this.Dimensions) && object.Equals(array.flatArray, this.flatArray);
        }

        public override int GetHashCode()
        {
            int num = 0x11;
            if (!this.IsEmpty)
            {
                foreach (int num2 in this.dims)
                {
                    num = num * 7 + num2;
                }
                if (this.flatArray.Length > 0)
                {
                    foreach (object obj2 in this.flatArray)
                    {
                        num = (obj2 == null) ? num : (num * 7 + obj2.GetHashCode());
                    }
                }
            }
            if (num >= 0) return num;
            return num * -1;
        }

        public override string ToString()
        {
            if (this.IsEmpty) return "[]";
            string str = this.getDimsStr();
            string str2 = "";
            switch (this.array_Type)
            {
                case MWArrayType.Cell:
                    str2 = " cell";
                    break;

                case MWArrayType.Structure:
                    str2 = " struct";
                    break;
            }
            return (str + str2 + " array");
        }

        public virtual object Clone()
        {
            MWArray target = (MWArray) base.MemberwiseClone();
            this.deepCopy(target);
            return target;
        }

        protected void setDims(int[] inDims)
        {
            string message = resourceManager.GetString("MWErrorOneBasedIndexing");
            if (inDims.Length > 1)
            {
                this.dims = new int[inDims.Length];
                for (int i = 0; i < inDims.Length; i++)
                {
                    if (inDims[i] < 0) throw new ArgumentException(message);
                    this.dims[i] = inDims[i];
                }
            }
            else if (inDims.Length == 1)
            {
                if (inDims[0] < 0) throw new ArgumentException(message);
                this.dims = new int[] { 1, inDims[0] };
            }
            else
                this.dims = new int[2];
        }

        internal object get(int index)
        {
            string message = resourceManager.GetString("MWErrorInvalidDimensions");
            if (index < 1 || index > this.MaxValidIndex) throw new ArgumentException(message);
            return this.flatArray[index - 1];
        }

        protected object get(int[] index)
        {
            if (index.Length == 1) return this.get(index[0]);
            int num = this.getOneBasedIndexForArray(index);
            return this.get(num);
        }

        protected void set(int index, object val)
        {
            string message = resourceManager.GetString("MWErrorInvalidDimensions");
            if (index < 1 || index > this.MaxValidIndex) throw new ArgumentException(message);
            if (val is ICloneable)
                this.flatArray[index - 1] = ((ICloneable) val).Clone();
            else
                this.flatArray[index - 1] = val;
        }

        protected void set(int[] index, object val)
        {
            if (index.Length == 1)
                this.set(index[0], val);
            else
            {
                int num = this.getOneBasedIndexForArray(index);
                this.set(num, val);
            }
        }

        protected void setNumOfElem(int[] inDims)
        {
            if (inDims.Length == 0)
                this.numOfElem = 0;
            else
            {
                int num = 1;
                foreach (int num2 in inDims)
                {
                    num *= num2;
                }
                this.numOfElem = num;
            }
        }

        protected void createAxisWeightArray()
        {
            this.axisWtArr = new int[this.dims.Length];
            if (this.dims.Length >= 2)
            {
                this.axisWtArr[0] = this.dims[1];
                this.axisWtArr[1] = this.dims[0];
            }
            if (this.dims.Length >= 3) this.axisWtArr[2] = this.axisWtArr[0] * this.axisWtArr[1];
            for (int i = 3; i < this.dims.Length; i++)
            {
                this.axisWtArr[i] = this.axisWtArr[i - 1] * this.dims[i - 1];
            }
        }

        protected void initNativeArray(int num)
        {
            this.flatArray = new object[num];
            this.MaxValidIndex = num;
        }

        protected int getOneBasedIndexForArray(int[] index)
        {
            string message = resourceManager.GetString("MWErrorInvalidDimensions");
            if (index.Length != this.dims.Length) throw new ArgumentException(message);
            for (int i = 0; i < index.Length; i++)
            {
                if (index[i] < 1 || index[i] > this.dims[i]) throw new ArgumentException(message);
            }
            int num2 = this.getPageBasedIndex(index[0], index[1]);
            if (index.Length > 2)
            {
                for (int j = index.Length - 1; j > 1; j--)
                {
                    num2 += (index[j] - 1) * this.axisWtArr[j];
                }
            }
            return num2;
        }

        protected void setFlatArr(object[] newArr)
        {
            this.flatArray = newArr;
            this.MaxValidIndex = this.flatArray.Length;
        }

        protected string getDimsStr()
        {
            string str = "";
            for (int i = 0; i < this.dims.Length; i++)
            {
                str = str + this.dims[i];
                if (i != this.dims.Length - 1) str = str + "x";
            }
            return str;
        }

        protected void deepCopy(MWArray target)
        {
            target.dims = (int[]) this.dims.Clone();
            target.axisWtArr = (int[]) this.axisWtArr.Clone();
            target.flatArray = (object[]) this.flatArray.Clone();
        }

        protected void resizeFlatArray(int newSize) { Array.Resize<object>(ref this.flatArray, newSize); }

        private int getPageBasedIndex(int r, int c)
        {
            r--;
            c--;
            return c * this.dims[0] + r + 1;
        }
    }
}
