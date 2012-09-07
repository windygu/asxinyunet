namespace MathWorks.MATLAB.NET.Utility
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    internal class MWMarshal
    {
        public static void MarshalManagedColumnMajorToUnmanagedColumnMajor(Array managedSrc, IntPtr dest)
        {
            if (dest != IntPtr.Zero)
            {
                long num = managedSrc.Length * SizeOfType(managedSrc.GetType().GetElementType());
                GCHandle handle = GCHandle.Alloc(managedSrc, GCHandleType.Pinned);
                IntPtr source = handle.AddrOfPinnedObject();
                try
                {
                    memcpy(source, dest, (IntPtr) num);
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public static unsafe void MarshalManagedColumnMajorToUnmanagedColumnMajor(Array managedSrc, double* destPtr)
        {
            if (destPtr != null)
            {
                Type elementType = managedSrc.GetType().GetElementType();
                int length = managedSrc.Length;
                GCHandle handle = GCHandle.Alloc(managedSrc, GCHandleType.Pinned);
                IntPtr source = handle.AddrOfPinnedObject();
                try
                {
                    if (elementType == typeof(byte))
                    {
                        byte* numPtr = (byte*) source;
                        for (int i = 0; i < length; i++)
                        {
                            destPtr += 8;
                            numPtr++;
                            destPtr[0] = numPtr[0];
                        }
                    }
                    else if (elementType == typeof(short))
                    {
                        short* numPtr2 = (short*) source;
                        for (int j = 0; j < length; j++)
                        {
                            destPtr += 8;
                            numPtr2++;
                            destPtr[0] = numPtr2[0];
                        }
                    }
                    else if (elementType == typeof(int))
                    {
                        int* numPtr3 = (int*) source;
                        for (int k = 0; k < length; k++)
                        {
                            destPtr += 8;
                            numPtr3++;
                            destPtr[0] = numPtr3[0];
                        }
                    }
                    else if (elementType == typeof(long))
                    {
                        long* numPtr4 = (long*) source;
                        for (int m = 0; m < length; m++)
                        {
                            destPtr += 8;
                            numPtr4++;
                            destPtr[0] = numPtr4[0];
                        }
                    }
                    else if (elementType == typeof(float))
                    {
                        float* numPtr5 = (float*) source;
                        for (int n = 0; n < length; n++)
                        {
                            destPtr += 8;
                            numPtr5 += 4;
                            destPtr[0] = numPtr5[0];
                        }
                    }
                    else if (elementType == typeof(double)) memcpy(source, (IntPtr) destPtr, (IntPtr) (length * 8));
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public static void MarshalManagedFlatArrayToUnmanaged(Array flatArray, IntPtr dest)
        {
            if (dest != IntPtr.Zero)
            {
                Type elementType = flatArray.GetType().GetElementType();
                if (elementType == typeof(byte))
                    Marshal.Copy((byte[]) flatArray, 0, dest, flatArray.Length);
                else if (elementType == typeof(short))
                    Marshal.Copy((short[]) flatArray, 0, dest, flatArray.Length);
                else if (elementType == typeof(int))
                    Marshal.Copy((int[]) flatArray, 0, dest, flatArray.Length);
                else if (elementType == typeof(long))
                    Marshal.Copy((long[]) flatArray, 0, dest, flatArray.Length);
                else if (elementType == typeof(float))
                    Marshal.Copy((float[]) flatArray, 0, dest, flatArray.Length);
                else if (elementType == typeof(double)) Marshal.Copy((double[]) flatArray, 0, dest, flatArray.Length);
            }
        }

        public static unsafe void MarshalManagedRowMajorToUnmanagedColumnMajor(Array managedSrc, IntPtr dest)
        {
            if (dest != IntPtr.Zero)
            {
                Type elementType = managedSrc.GetType().GetElementType();
                int length = managedSrc.Length;
                int num2 = managedSrc.GetLength(managedSrc.Rank - 2);
                int num3 = managedSrc.GetLength(managedSrc.Rank - 1);
                int num4 = num2 * num3;
                GCHandle handle = GCHandle.Alloc(managedSrc, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                try
                {
                    if (elementType == typeof(byte))
                    {
                        byte* numPtr = (byte*) ptr;
                        byte* numPtr2 = (byte*) dest;
                        for (int i = 0; i < length; i += num4)
                        {
                            for (int j = 0; j < num2; j++)
                            {
                                for (int k = 0; k < num3; k++)
                                {
                                    numPtr++;
                                    numPtr2[k * num2 + j + i] = numPtr[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(short))
                    {
                        short* numPtr3 = (short*) ptr;
                        short* numPtr4 = (short*) dest;
                        for (int m = 0; m < length; m += num4)
                        {
                            for (int n = 0; n < num2; n++)
                            {
                                for (int num10 = 0; num10 < num3; num10++)
                                {
                                    numPtr3++;
                                    numPtr4[num10 * num2 + n + m] = numPtr3[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(int))
                    {
                        int* numPtr5 = (int*) ptr;
                        int* numPtr6 = (int*) dest;
                        for (int num11 = 0; num11 < length; num11 += num4)
                        {
                            for (int num12 = 0; num12 < num2; num12++)
                            {
                                for (int num13 = 0; num13 < num3; num13++)
                                {
                                    numPtr5++;
                                    numPtr6[num13 * num2 + num12 + num11] = numPtr5[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(long))
                    {
                        long* numPtr7 = (long*) ptr;
                        long* numPtr8 = (long*) dest;
                        for (int num14 = 0; num14 < length; num14 += num4)
                        {
                            for (int num15 = 0; num15 < num2; num15++)
                            {
                                for (int num16 = 0; num16 < num3; num16++)
                                {
                                    numPtr7++;
                                    numPtr8[num16 * num2 + num15 + num14] = numPtr7[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(float))
                    {
                        float* numPtr9 = (float*) ptr;
                        float* numPtr10 = (float*) dest;
                        for (int num17 = 0; num17 < length; num17 += num4)
                        {
                            for (int num18 = 0; num18 < num2; num18++)
                            {
                                for (int num19 = 0; num19 < num3; num19++)
                                {
                                    numPtr9 += 4;
                                    numPtr10[(num19 * num2 + num18 + num17) * 4] = numPtr9[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(double))
                    {
                        double* numPtr11 = (double*) ptr;
                        double* numPtr12 = (double*) dest;
                        for (int num20 = 0; num20 < length; num20 += num4)
                        {
                            for (int num21 = 0; num21 < num2; num21++)
                            {
                                for (int num22 = 0; num22 < num3; num22++)
                                {
                                    numPtr11 += 8;
                                    numPtr12[(num22 * num2 + num21 + num20) * 8] = numPtr11[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public static unsafe void MarshalManagedRowMajorToUnmanagedColumnMajor(Array managedSrc, double* destPtr)
        {
            if (destPtr != null)
            {
                Type elementType = managedSrc.GetType().GetElementType();
                int length = managedSrc.Length;
                int num2 = managedSrc.GetLength(managedSrc.Rank - 2);
                int num3 = managedSrc.GetLength(managedSrc.Rank - 1);
                int num4 = num2 * num3;
                GCHandle handle = GCHandle.Alloc(managedSrc, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                try
                {
                    if (elementType == typeof(byte))
                    {
                        byte* numPtr = (byte*) ptr;
                        for (int i = 0; i < length; i += num4)
                        {
                            for (int j = 0; j < num2; j++)
                            {
                                for (int k = 0; k < num3; k++)
                                {
                                    numPtr++;
                                    destPtr[(k * num2 + j + i) * 8] = numPtr[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(short))
                    {
                        short* numPtr2 = (short*) ptr;
                        for (int m = 0; m < length; m += num4)
                        {
                            for (int n = 0; n < num2; n++)
                            {
                                for (int num10 = 0; num10 < num3; num10++)
                                {
                                    numPtr2++;
                                    destPtr[(num10 * num2 + n + m) * 8] = numPtr2[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(int))
                    {
                        int* numPtr3 = (int*) ptr;
                        for (int num11 = 0; num11 < length; num11 += num4)
                        {
                            for (int num12 = 0; num12 < num2; num12++)
                            {
                                for (int num13 = 0; num13 < num3; num13++)
                                {
                                    numPtr3++;
                                    destPtr[(num13 * num2 + num12 + num11) * 8] = numPtr3[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(long))
                    {
                        long* numPtr4 = (long*) ptr;
                        for (int num14 = 0; num14 < length; num14 += num4)
                        {
                            for (int num15 = 0; num15 < num2; num15++)
                            {
                                for (int num16 = 0; num16 < num3; num16++)
                                {
                                    numPtr4++;
                                    destPtr[(num16 * num2 + num15 + num14) * 8] = numPtr4[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(float))
                    {
                        float* numPtr5 = (float*) ptr;
                        for (int num17 = 0; num17 < length; num17 += num4)
                        {
                            for (int num18 = 0; num18 < num2; num18++)
                            {
                                for (int num19 = 0; num19 < num3; num19++)
                                {
                                    numPtr5 += 4;
                                    destPtr[(num19 * num2 + num18 + num17) * 8] = numPtr5[0];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(double))
                    {
                        double* numPtr6 = (double*) ptr;
                        for (int num20 = 0; num20 < length; num20 += num4)
                        {
                            for (int num21 = 0; num21 < num2; num21++)
                            {
                                for (int num22 = 0; num22 < num3; num22++)
                                {
                                    numPtr6 += 8;
                                    destPtr[(num22 * num2 + num21 + num20) * 8] = numPtr6[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public static unsafe void MarshalUnmanagedColumnMajorToManagedRowMajor(IntPtr src, Array dest)
        {
            if (src != IntPtr.Zero)
            {
                Type elementType = dest.GetType().GetElementType();
                int length = dest.Length;
                int num2 = dest.GetLength(dest.Rank - 2);
                int num3 = dest.GetLength(dest.Rank - 1);
                int num4 = num2 * num3;
                GCHandle handle = GCHandle.Alloc(dest, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                try
                {
                    if (elementType == typeof(byte))
                    {
                        byte* numPtr = (byte*) ptr.ToPointer();
                        byte* numPtr2 = (byte*) src;
                        for (int i = 0; i < length; i += num4)
                        {
                            for (int j = 0; j < num2; j++)
                            {
                                for (int k = 0; k < num3; k++)
                                {
                                    numPtr++;
                                    numPtr[0] = numPtr2[k * num2 + j + i];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(short))
                    {
                        short* numPtr3 = (short*) ptr.ToPointer();
                        short* numPtr4 = (short*) src;
                        for (int m = 0; m < length; m += num4)
                        {
                            for (int n = 0; n < num2; n++)
                            {
                                for (int num10 = 0; num10 < num3; num10++)
                                {
                                    numPtr3++;
                                    numPtr3[0] = numPtr4[num10 * num2 + n + m];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(int))
                    {
                        int* numPtr5 = (int*) ptr.ToPointer();
                        int* numPtr6 = (int*) src;
                        for (int num11 = 0; num11 < length; num11 += num4)
                        {
                            for (int num12 = 0; num12 < num2; num12++)
                            {
                                for (int num13 = 0; num13 < num3; num13++)
                                {
                                    numPtr5++;
                                    numPtr5[0] = numPtr6[num13 * num2 + num12 + num11];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(long))
                    {
                        long* numPtr7 = (long*) ptr.ToPointer();
                        long* numPtr8 = (long*) src;
                        for (int num14 = 0; num14 < length; num14 += num4)
                        {
                            for (int num15 = 0; num15 < num2; num15++)
                            {
                                for (int num16 = 0; num16 < num3; num16++)
                                {
                                    numPtr7++;
                                    numPtr7[0] = numPtr8[num16 * num2 + num15 + num14];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(float))
                    {
                        float* numPtr9 = (float*) ptr.ToPointer();
                        float* numPtr10 = (float*) src;
                        for (int num17 = 0; num17 < length; num17 += num4)
                        {
                            for (int num18 = 0; num18 < num2; num18++)
                            {
                                for (int num19 = 0; num19 < num3; num19++)
                                {
                                    numPtr9 += 4;
                                    numPtr9[0] = numPtr10[(num19 * num2 + num18 + num17) * 4];
                                }
                            }
                        }
                    }
                    else if (elementType == typeof(double))
                    {
                        double* numPtr11 = (double*) ptr.ToPointer();
                        double* numPtr12 = (double*) src;
                        for (int num20 = 0; num20 < length; num20 += num4)
                        {
                            for (int num21 = 0; num21 < num2; num21++)
                            {
                                for (int num22 = 0; num22 < num3; num22++)
                                {
                                    numPtr11 += 8;
                                    numPtr11[0] = numPtr12[(num22 * num2 + num21 + num20) * 8];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public static void MarshalUnmanagedToManagedFlatArray(IntPtr src, Array flatArray)
        {
            if (src != IntPtr.Zero)
            {
                Type elementType = flatArray.GetType().GetElementType();
                if (elementType == typeof(byte))
                    Marshal.Copy(src, (byte[]) flatArray, 0, flatArray.Length);
                else if (elementType == typeof(short))
                    Marshal.Copy(src, (short[]) flatArray, 0, flatArray.Length);
                else if (elementType == typeof(int))
                    Marshal.Copy(src, (int[]) flatArray, 0, flatArray.Length);
                else if (elementType == typeof(long))
                    Marshal.Copy(src, (long[]) flatArray, 0, flatArray.Length);
                else if (elementType == typeof(float))
                    Marshal.Copy(src, (float[]) flatArray, 0, flatArray.Length);
                else if (elementType == typeof(double)) Marshal.Copy(src, (double[]) flatArray, 0, flatArray.Length);
            }
        }

        [SuppressUnmanagedCodeSecurity, DllImport("mclmcrrt7_17.dll", EntryPoint="memcpy_proxy")]
        private static extern int memcpy(IntPtr source, IntPtr destination, IntPtr size);
        private static int SizeOfType(Type t)
        {
            if (t == typeof(byte)) return 1;
            if (t == typeof(short)) return 2;
            if (t == typeof(int)) return 4;
            if (t == typeof(long)) return 8;
            if (t == typeof(float)) return 4;
            if (t == typeof(double)) return 8;
            if (t == typeof(char)) return 2;
            return -1;
        }
    }
}
