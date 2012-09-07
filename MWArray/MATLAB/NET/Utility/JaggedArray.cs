namespace MathWorks.MATLAB.NET.Utility
{
    using System;
    using System.Resources;

    internal class JaggedArray
    {
        private Array array_;
        internal static ResourceManager resourceManager = MathWorks.MATLAB.NET.Arrays.MWResources.getResourceManager();

        public JaggedArray(Array array)
        {
            if (!IsJagged(array) || !IsRectangular(array)) throw new ArgumentException(resourceManager.GetString("MWErrorNotRectangularJaggedArray"));
            this.array_ = array;
        }

        private static Array CreateJaggedArray(Type t, int[] dimensions, int currentDim)
        {
            int length = dimensions.Length;
            int num2 = dimensions[currentDim];
            if (length - currentDim <= 1) return Array.CreateInstance(t, num2);
            Array array = Array.CreateInstance(MakeJaggedArrayType(t, length - currentDim), num2);
            for (int i = 0; i < num2; i++)
            {
                array.SetValue(CreateJaggedArray(t, dimensions, currentDim + 1), i);
            }
            return array;
        }

        private T[] Flatten2D<T>(T[][] src, int[] dimensions)
        {
            T[] localArray = new T[dimensions[0] * dimensions[1]];
            int num = 0;
            for (int i = 0; i < dimensions[1]; i++)
            {
                for (int j = 0; j < dimensions[0]; j++)
                {
                    localArray[num++] = src[j][i];
                }
            }
            return localArray;
        }

        private T[] Flatten3D<T>(T[][][] src, int[] dimensions)
        {
            T[] localArray = new T[dimensions[0] * dimensions[1] * dimensions[2]];
            int num = 0;
            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[2]; j++)
                {
                    for (int k = 0; k < dimensions[1]; k++)
                    {
                        localArray[num++] = src[i][k][j];
                    }
                }
            }
            return localArray;
        }

        private static Array Get2DJaggedArray(Array flatArray, int row, int col)
        {
            Type elementType = flatArray.GetType().GetElementType();
            if (elementType == typeof(byte)) return Unflatten2D<byte>((byte[]) flatArray, row, col);
            if (elementType == typeof(short)) return Unflatten2D<short>((short[]) flatArray, row, col);
            if (elementType == typeof(int)) return Unflatten2D<int>((int[]) flatArray, row, col);
            if (elementType == typeof(long)) return Unflatten2D<long>((long[]) flatArray, row, col);
            if (elementType == typeof(float)) return Unflatten2D<float>((float[]) flatArray, row, col);
            if (elementType == typeof(double)) return Unflatten2D<double>((double[]) flatArray, row, col);
            if (elementType == typeof(char)) return Unflatten2D<char>((char[]) flatArray, row, col);
            if (elementType != typeof(bool)) throw new ArgumentException(resourceManager.GetString("MWErrorUnsupportedArrayType") + elementType.FullName);
            return Unflatten2D<bool>((bool[]) flatArray, row, col);
        }

        private static Array Get3DJaggedArray(Array flatArray, int row, int col, int page, int startingOffset)
        {
            Type elementType = flatArray.GetType().GetElementType();
            if (elementType == typeof(byte)) return Unflatten3D<byte>((byte[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(short)) return Unflatten3D<short>((short[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(int)) return Unflatten3D<int>((int[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(long)) return Unflatten3D<long>((long[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(float)) return Unflatten3D<float>((float[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(double)) return Unflatten3D<double>((double[]) flatArray, row, col, page, startingOffset);
            if (elementType == typeof(char)) return Unflatten3D<char>((char[]) flatArray, row, col, page, startingOffset);
            if (elementType != typeof(bool)) throw new ArgumentException(resourceManager.GetString("MWErrorUnsupportedArrayType") + elementType.FullName);
            return Unflatten3D<bool>((bool[]) flatArray, row, col, page, startingOffset);
        }

        private int GetDimension(int dim)
        {
            if (dim < 0 || dim >= this.GetRank()) throw new IndexOutOfRangeException("Dimension:" + dim + " does not exist in array.");
            Array array = this.array_;
            for (int i = 0; i < dim; i++)
            {
                array = (Array) array.GetValue(0);
            }
            return array.Length;
        }

        public int[] GetDimensions()
        {
            int rank = this.GetRank();
            int[] numArray = new int[rank];
            for (int i = 0; i < rank; i++)
            {
                numArray[i] = this.GetDimension(i);
            }
            return numArray;
        }

        public Type GetElementType()
        {
            Type elementType = this.array_.GetType();
            int rank = this.GetRank();
            for (int i = 0; i < rank; i++)
            {
                elementType = elementType.GetElementType();
            }
            return elementType;
        }

        public static Type GetElementType(Type t)
        {
            int rank = GetRank(t);
            for (int i = 0; i < rank; i++)
            {
                t = t.GetElementType();
            }
            return t;
        }

        public Array GetFlatArray()
        {
            int rank = this.GetRank();
            this.GetElementType();
            switch (rank)
            {
                case 2:
                    return this.GetFlatArrayFrom2D(this);

                case 3:
                    return this.GetFlatArrayFrom3D(this);
            }
            return this.GetFlatArrayFromND(this);
        }

        private Array GetFlatArrayFrom2D(JaggedArray src)
        {
            int[] dimensions = new int[] { src.GetDimension(0), src.GetDimension(1) };
            Type elementType = src.GetElementType();
            if (elementType == typeof(byte)) return this.Flatten2D<byte>((byte[][]) src.ArrayData, dimensions);
            if (elementType == typeof(short)) return this.Flatten2D<short>((short[][]) src.ArrayData, dimensions);
            if (elementType == typeof(int)) return this.Flatten2D<int>((int[][]) src.ArrayData, dimensions);
            if (elementType == typeof(long)) return this.Flatten2D<long>((long[][]) src.ArrayData, dimensions);
            if (elementType == typeof(float)) return this.Flatten2D<float>((float[][]) src.ArrayData, dimensions);
            if (elementType == typeof(double)) return this.Flatten2D<double>((double[][]) src.ArrayData, dimensions);
            if (elementType == typeof(char)) return this.Flatten2D<char>((char[][]) src.ArrayData, dimensions);
            if (elementType != typeof(bool)) throw new ArgumentException(resourceManager.GetString("MWErrorUnsupportedArrayType") + elementType.FullName);
            return this.Flatten2D<bool>((bool[][]) src.ArrayData, dimensions);
        }

        private Array GetFlatArrayFrom3D(JaggedArray src)
        {
            int[] dimensions = new int[] { src.GetDimension(0), src.GetDimension(1), src.GetDimension(2) };
            Type elementType = src.GetElementType();
            if (elementType == typeof(byte)) return this.Flatten3D<byte>((byte[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(short)) return this.Flatten3D<short>((short[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(int)) return this.Flatten3D<int>((int[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(long)) return this.Flatten3D<long>((long[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(float)) return this.Flatten3D<float>((float[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(double)) return this.Flatten3D<double>((double[][][]) src.ArrayData, dimensions);
            if (elementType == typeof(char)) return this.Flatten3D<char>((char[][][]) src.ArrayData, dimensions);
            if (elementType != typeof(bool)) throw new ArgumentException(resourceManager.GetString("MWErrorUnsupportedArrayType") + elementType.FullName);
            return this.Flatten3D<bool>((bool[][][]) src.ArrayData, dimensions);
        }

        private Array GetFlatArrayFromND(JaggedArray src)
        {
            if (src.GetRank() == 3) return this.GetFlatArrayFrom3D(src);
            int dimension = src.GetDimension(0);
            Array array = Array.CreateInstance(src.GetElementType().MakeArrayType(), src.ArrayData.Length);
            for (int i = 0; i < dimension; i++)
            {
                array.SetValue(this.GetFlatArrayFromND(new JaggedArray((Array) src.ArrayData.GetValue(i))), i);
            }
            return Stitch1DArrays(array);
        }

        public static Array GetJaggedArrayFromFlatArray(Array flatArray, int[] dimensions)
        {
            switch (dimensions.Length)
            {
                case 2:
                    return Get2DJaggedArray(flatArray, dimensions[0], dimensions[1]);

                case 3:
                    return Get3DJaggedArray(flatArray, dimensions[1], dimensions[2], dimensions[0], 0);
            }
            return GetNDJaggedArray(flatArray, dimensions, 0, 0, dimensions[1] * dimensions[2] * dimensions[0]);
        }

        private static Array GetNDJaggedArray(Array flatArray, int[] dimensions, int currentDim, int startingOffset, int pageStride)
        {
            int rank = dimensions.Length - currentDim;
            if (rank == 3) return Get3DJaggedArray(flatArray, dimensions[currentDim + 1], dimensions[currentDim + 2], dimensions[currentDim], startingOffset);
            Type elementType = MakeJaggedArrayType(flatArray.GetType().GetElementType(), rank);
            int length = dimensions[currentDim];
            Array array = Array.CreateInstance(elementType, length);
            for (int i = 0; i < length; i++)
            {
                Array array2 = GetNDJaggedArray(flatArray, dimensions, currentDim + 1, startingOffset + i * pageStride, pageStride);
                array.SetValue(array2, i);
            }
            return array;
        }

        public int GetRank() { return GetRank(this.array_); }

        private static int GetRank(Array array)
        {
            if (!array.GetType().GetElementType().IsArray) return 1;
            return 1 + GetRank((Array) array.GetValue(0));
        }

        public static int GetRank(Type t)
        {
            if (!t.IsArray) return 0;
            return 1 + GetRank(t.GetElementType());
        }

        public static bool IsJagged(Array array) { return array.GetType().GetElementType().IsArray; }

        public static bool IsJagged(Type t) { return t.GetElementType().IsArray; }

        private static bool IsRectangular(Array array) { return IsRectangular(array, GetRank(array)); }

        private static bool IsRectangular(Array array, int rank)
        {
            if (rank > 1)
            {
                int length = array.Length;
                int num2 = ((Array) array.GetValue(0)).Length;
                for (int i = 1; i < length; i++)
                {
                    if (((Array) array.GetValue(i)).Length != num2) return false;
                }
                for (int j = 0; j < length; j++)
                {
                    if (!IsRectangular((Array) array.GetValue(j), rank - 1)) return false;
                }
            }
            return true;
        }

        private static Type MakeJaggedArrayType(Type t, int rank)
        {
            if (rank == 2) return t.MakeArrayType();
            return MakeJaggedArrayType(t.MakeArrayType(), rank - 1);
        }

        private static T[] Stitch<T>(T[][] src)
        {
            int num = 0;
            foreach (T[] localArray in src)
            {
                num += localArray.Length;
            }
            T[] array = new T[num];
            int index = 0;
            foreach (T[] localArray3 in src)
            {
                localArray3.CopyTo(array, index);
                index += localArray3.Length;
            }
            return array;
        }

        private static Array Stitch1DArrays(Array src)
        {
            Type type = src.GetType();
            if (type == typeof(byte[][])) return Stitch<byte>((byte[][]) src);
            if (type == typeof(short[][])) return Stitch<byte>((byte[][]) src);
            if (type == typeof(int[][])) return Stitch<int>((int[][]) src);
            if (type == typeof(long[][])) return Stitch<long>((long[][]) src);
            if (type == typeof(float)) return Stitch<float>((float[][]) src);
            if (type == typeof(double)) return Stitch<double>((double[][]) src);
            if (type == typeof(char)) return Stitch<char>((char[][]) src);
            if (type != typeof(bool)) throw new ArgumentException(resourceManager.GetString("MWErrorUnsupportedArrayType") + type.FullName);
            return Stitch<bool>((bool[][]) src);
        }

        private static T[][] Unflatten2D<T>(T[] flatArray, int row, int col)
        {
            T[][] localArray = new T[row][];
            for (int i = 0; i < row; i++)
            {
                localArray[i] = new T[col];
            }
            for (int j = 0; j < row; j++)
            {
                for (int k = 0; k < col; k++)
                {
                    localArray[j][k] = flatArray[k * row + j];
                }
            }
            return localArray;
        }

        private static T[][][] Unflatten3D<T>(T[] flatArray, int row, int col, int page, int startingOffset)
        {
            T[][][] localArray = new T[page][][];
            for (int i = 0; i < page; i++)
            {
                localArray[i] = new T[row][];
                for (int j = 0; j < row; j++)
                {
                    localArray[i][j] = new T[col];
                }
            }
            int num3 = row * col;
            int num4 = 0;
            int index = 0;
            while (index < page)
            {
                for (int k = 0; k < row; k++)
                {
                    for (int m = 0; m < col; m++)
                    {
                        localArray[index][k][m] = flatArray[m * row + k + num4 + startingOffset];
                    }
                }
                index++;
                num4 += num3;
            }
            return localArray;
        }

        public Array ArrayData { get { return this.array_; } }
    }
}
