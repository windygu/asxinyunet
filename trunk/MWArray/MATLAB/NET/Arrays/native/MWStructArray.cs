namespace MathWorks.MATLAB.NET.Arrays.native
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class MWStructArray : MWArray, ICloneable, IEquatable<MWStructArray>
    {
        private static readonly MWStructArray _Empty = new MWStructArray();
        private string[] fieldNames;
        public MWStructArray()
        {
            this.fieldNames = new string[0];
            base.array_Type = MWArrayType.Structure;
        }

        public MWStructArray(int rows, int cols, string[] fNames) : this(new int[] { rows, cols }, fNames) {  }

        public MWStructArray(int[] inDims, string[] fNames) : base(inDims)
        {
            this.fieldNames = (string[]) fNames.Clone();
            base.initNativeArray(this.fieldNames.Length * base.NumberOfElements);
            base.array_Type = MWArrayType.Structure;
        }

        public MWStructArray(params object[] fieldDefs) : base(new int[] { 1, 1 })
        {
            int length = fieldDefs.Length;
            if (length % 2 != 0) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorNotNameValuePair"), "fieldDefs");
            length /= 2;
            this.fieldNames = new string[length];
            base.initNativeArray(this.fieldNames.Length);
            for (int i = 0; i < length; i++)
            {
                int index = i * 2;
                if (fieldDefs[index].GetType() != typeof(string) || ((string) fieldDefs[index]).Length == 0) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorFieldNotString"));
                this.fieldNames[i] = (string) fieldDefs[index];
                base.set((int) (i + 1), fieldDefs[index + 1]);
            }
            base.array_Type = MWArrayType.Structure;
        }

        public object this[string fieldName, int[] indices]
        {
            get
            {
                if (indices.Length == 1) return this.get(fieldName, indices[0]);
                return this.get(fieldName, indices);
            }
            set
            {
                if (indices.Length == 1)
                    this.set(fieldName, indices[0], value);
                else
                    this.set(fieldName, indices, value);
            }
        }
        public object this[string fieldName] { get { return this.GetField(fieldName); } set { this.SetField(fieldName, value); } }
        public static MWStructArray Empty { get { return (MWStructArray) _Empty.Clone(); } }
        public string[] FieldNames { get { return (string[]) this.fieldNames.Clone(); } }
        public int NumberOfFields { get { return this.fieldNames.Length; } }
        public override string ToString()
        {
            if (base.IsEmpty) return "[]";
            string str = base.ToString() + " with ";
            if (this.fieldNames.Length == 0) return (str + "no fields.");
            str = str + "fields:\n";
            foreach (string str2 in this.fieldNames)
            {
                str = str + "\t" + str2;
                if (!str2.Equals(this.fieldNames[this.fieldNames.Length - 1])) str = str + "\n";
            }
            return str;
        }

        public override object Clone()
        {
            MWStructArray target = new MWStructArray(base.Dimensions, this.FieldNames);
            base.deepCopy(target);
            return target;
        }

        public override bool Equals(object obj) { return (obj is MWStructArray) && this.Equals(obj as MWStructArray); }

        public bool Equals(MWStructArray obj)
        {
            MWStructArray array = obj;
            return base.Equals(array) && object.Equals(array.fieldNames, this.fieldNames);
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();
            if (this.fieldNames.Length > 0)
            {
                foreach (string str in this.fieldNames)
                {
                    hashCode = hashCode * 7 + str.GetHashCode();
                }
            }
            if (hashCode >= 0) return hashCode;
            return hashCode * -1;
        }

        public object GetField(string fieldName, int index) { return this.get(fieldName, index); }

        public object GetField(string fieldName) { return this.GetField(fieldName, 1); }

        public void SetField(string fieldName, object fieldValue) { this.set(fieldName, 1, fieldValue); }

        public bool IsField(string fieldName) { return this.fieldIndex(fieldName) != -1; }

        public MWStructArray RemoveField(string fName)
        {
            if (!this.IsField(fName)) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorFieldNotFound"), fName);
            string[] strArray = new string[this.fieldNames.Length - 1];
            int index = 0;
            int num2 = 0;
            while (index < this.fieldNames.Length)
            {
                if (!this.fieldNames[index].Equals(fName))
                {
                    strArray[num2] = this.fieldNames[index];
                    num2++;
                }
                index++;
            }
            object[] newArr = new object[(this.NumberOfFields - 1) * base.NumberOfElements];
            int num3 = 0;
            for (int i = 0; i < base.NumberOfElements; i++)
            {
                foreach (string str2 in this.fieldNames)
                {
                    if (!str2.Equals(fName))
                    {
                        newArr[num3] = this[str2, new int[] { i + 1 }];
                        num3++;
                    }
                }
            }
            base.setFlatArr(newArr);
            this.fieldNames = strArray;
            return this;
        }

        private object get(string fName, int index)
        {
            int num = this.structIndexToOneBasedIndex(fName, index);
            return base.get(num);
        }

        private object get(string fName, int[] idxArr)
        {
            int index = base.getOneBasedIndexForArray(idxArr);
            return this.get(fName, index);
        }

        private void set(string fName, int index, object val)
        {
            if (this.isValidOneBasedIndex(index) && !this.IsField(fName))
            {
                string[] strArray = new string[this.NumberOfFields + 1];
                for (int i = 0; i < this.NumberOfFields; i++)
                {
                    strArray[i] = this.fieldNames[i];
                }
                strArray[this.NumberOfFields] = fName;
                object[] newArr = new object[strArray.Length * base.NumberOfElements];
                int num2 = 0;
                int num3 = 0;
                while (num2 < base.NumberOfElements)
                {
                    foreach (string str in strArray)
                    {
                        if (!str.Equals(fName)) newArr[num3] = this[str, new int[] { num2 + 1 }];
                        num3++;
                    }
                    num2++;
                }
                base.setFlatArr(newArr);
                this.fieldNames = strArray;
            }
            int num4 = this.structIndexToOneBasedIndex(fName, index);
            base.set(num4, val);
        }

        private void set(string fName, int[] idxArr, object val)
        {
            int index = base.getOneBasedIndexForArray(idxArr);
            this.set(fName, index, val);
        }

        private int structIndexToOneBasedIndex(string fName, int index)
        {
            string message = MWArray.resourceManager.GetString("MWErrorInvalidDimensions");
            if (!this.isValidOneBasedIndex(index)) throw new ArgumentException(message);
            int num = this.fieldIndex(fName);
            if (num == -1) throw new ArgumentException(MWArray.resourceManager.GetString("MWErrorBadFieldName"));
            return (index - 1) * this.NumberOfFields + num + 1;
        }

        private int fieldIndex(string fieldName)
        {
            for (int i = 0; i < this.fieldNames.Length; i++)
            {
                if (this.fieldNames[i].Equals(fieldName)) return i;
            }
            return -1;
        }

        private bool isValidOneBasedIndex(int index) { return index >= 1 && index <= base.NumberOfElements; }
    }
}
