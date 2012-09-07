using MathWorks.MATLAB.NET.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;
namespace MathWorks.MATLAB.NET.Arrays
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class MWNumericArray : MWIndexArray, IEquatable<MWNumericArray>
	{
		public static readonly MWNumericArray Inf;
		public static readonly MWNumericArray NaN;
		private static readonly MWNumericArray _Empty;
		private static IDictionary systemTypeToNumericType;
		private static Dictionary<MWNumericType, Type> numericTypeToSystemType;
		public new MWNumericArray this[params int[] indices]
		{
			get
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				MWNumericArray result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (MWNumericArray)MWArray.GetTypedArray(base.ArrayIndexer(this, indices));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
			set
			{
				if (MWArrayType.Numeric != value.array_Type)
				{
					string @string = MWArray.resourceManager.GetString("MWErrorDataArrayType");
					throw new InvalidCastException(@string);
				}
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(MWArray.mxSync);
					base.ArrayIndexer(value, this, indices);
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
			}
		}
		public MWNumericArray this[MWArrayComponent component, params int[] indices]
		{
			get
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				MWNumericArray result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					IntPtr[] array = new IntPtr[indices.Length];
					for (int i = 0; i < indices.Length; i++)
					{
						array[i] = (IntPtr)indices[i];
					}
					MWSafeHandle hMXArray;
					if (component == MWArrayComponent.Real)
					{
						if (MWNumericArray.mclMXArrayGetReal(out hMXArray, this.MXArrayHandle, (IntPtr)indices.Length, array) != 0)
						{
							string @string = MWArray.resourceManager.GetString("MWErrorInvalidIndex");
							throw new Exception(@string);
						}
					}
					else
					{
						if (MWNumericArray.mclMXArrayGetImag(out hMXArray, this.MXArrayHandle, (IntPtr)indices.Length, array) != 0)
						{
							string string2 = MWArray.resourceManager.GetString("MWErrorInvalidIndex");
							throw new Exception(string2);
						}
					}
					result = (MWNumericArray)MWArray.GetTypedArray(hMXArray);
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
			set
			{
				if (MWArrayType.Numeric != value.array_Type)
				{
					string @string = MWArray.resourceManager.GetString("MWErrorDataArrayType");
					throw new InvalidCastException(@string);
				}
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(MWArray.mxSync);
					IntPtr[] array = new IntPtr[indices.Length];
					for (int i = 0; i < indices.Length; i++)
					{
						array[i] = (IntPtr)indices[i];
					}
					if (component == MWArrayComponent.Real)
					{
						if (MWNumericArray.mclMXArraySetReal(this.MXArrayHandle, value.MXArrayHandle, (IntPtr)indices.Length, array) != 0)
						{
							string string2 = MWArray.resourceManager.GetString("MWErrorInvalidArray");
							throw new Exception(string2);
						}
					}
					else
					{
						if (MWNumericArray.mclMXArraySetImag(this.MXArrayHandle, value.MXArrayHandle, (IntPtr)indices.Length, array) != 0)
						{
							string string3 = MWArray.resourceManager.GetString("MWErrorInvalidArray");
							throw new Exception(string3);
						}
					}
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
			}
		}
		public static MWNumericArray Empty
		{
			get
			{
				return (MWNumericArray)MWNumericArray._Empty.Clone();
			}
		}
		public static double FloatingPointAccuracy
		{
			get
			{
				double result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (double)new MWNumericArray(MWNumericArray.mxGetEps());
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		private static MWNumericArray _Inf
		{
			get
			{
				MWNumericArray result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = new MWNumericArray(MWNumericArray.mxGetInf());
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		private static MWNumericArray _NaN
		{
			get
			{
				MWNumericArray result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = new MWNumericArray(MWNumericArray.mxGetNaN());
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public MWNumericType NumericType
		{
			get
			{
				base.CheckDisposed();
				MWNumericType result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (MWNumericType)MWArray.mxGetClassID(this.MXArrayHandle);
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsByte
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsUint8(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsComplex
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsComplex(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsDouble
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsDouble(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsFloat
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsSingle(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsInteger
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsInt32(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsLong
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsInt64(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsInfinity
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					if (1 != MWArray.mxGetNumberOfElements(this.MXArrayHandle))
					{
						string @string = MWArray.resourceManager.GetString("MWErrorNotScalar");
						throw new Exception(@string);
					}
					result = (1 == MWNumericArray.mxIsInf((double)this));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsNaN
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					if (1 != MWArray.mxGetNumberOfElements(this.MXArrayHandle))
					{
						string @string = MWArray.resourceManager.GetString("MWErrorNotScalar");
						throw new Exception(@string);
					}
					result = (1 == MWNumericArray.mxIsNaN((double)this));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		public bool IsShort
		{
			get
			{
				base.CheckDisposed();
				bool result;
				try
				{
					Monitor.Enter(MWArray.mxSync);
					result = (1 == MWNumericArray.mxIsInt16(this.MXArrayHandle));
				}
				finally
				{
					Monitor.Exit(MWArray.mxSync);
				}
				return result;
			}
		}
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxCreateDoubleMatrix_700_proxy")]
		private static extern MWSafeHandle mxCreateDoubleMatrix([In] int row, [In] int column, [In] MWArrayComplexity complexityFlag);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxCreateNumericArray_700_proxy")]
		private static extern MWSafeHandle mxCreateNumericArray([In] int rank, [In] int[] dimensions, [In] MWNumericType elementType, [In] MWArrayComplexity complexityFlag);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxFastZeros_proxy")]
		private static extern MWSafeHandle mxFastZeros([In] MWArrayComplexity complexityFlag, [In] int rows, [In] int columns);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetEps_proxy")]
		private static extern double mxGetEps();
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetImagData_proxy")]
		internal static extern IntPtr mxGetImagData([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetInf_proxy")]
		private static extern double mxGetInf();
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetNaN_proxy")]
		private static extern double mxGetNaN();
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetPi_proxy")]
		internal static extern IntPtr mxGetPi([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxGetPr_proxy")]
		internal static extern IntPtr mxGetPr([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsComplex_proxy")]
		internal static extern byte mxIsComplex([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsFinite_proxy")]
		private static extern byte mxIsFinite([In] double value);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsInf_proxy")]
		private static extern byte mxIsInf([In] double value);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsNaN_proxy")]
		private static extern byte mxIsNaN([In] double value);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsUint8_proxy")]
		internal static extern byte mxIsUint8([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsInt16_proxy")]
		internal static extern byte mxIsInt16([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsInt32_proxy")]
		internal static extern byte mxIsInt32([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsInt64_proxy")]
		internal static extern byte mxIsInt64([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsSingle_proxy")]
		internal static extern byte mxIsSingle([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mxIsDouble_proxy")]
		internal static extern byte mxIsDouble([In] MWSafeHandle hMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "array_handle_imag_proxy")]
		protected static extern IntPtr array_handle_imag([In] IntPtr pMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "array_handle_real_proxy")]
		protected static extern IntPtr array_handle_real([In] IntPtr pMXArray);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mclMXArrayGetReal_proxy")]
		internal static extern int mclMXArrayGetReal(out MWSafeHandle hMXArraySrcElem, [In] MWSafeHandle hMXArraySrcArray, [In] IntPtr numIndices, [In] IntPtr[] indices);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mclMXArrayGetImag_proxy")]
		internal static extern int mclMXArrayGetImag(out MWSafeHandle hMXArraySrcElem, [In] MWSafeHandle hMXArraySrcArray, [In] IntPtr numIndices, [In] IntPtr[] indices);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mclMXArraySetReal_proxy")]
		internal static extern int mclMXArraySetReal([In] MWSafeHandle hMXArrayTrg, [In] MWSafeHandle hMXArraySrcElem, [In] IntPtr numIndices, [In] IntPtr[] indices);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mclMXArraySetImag_proxy")]
		internal static extern int mclMXArraySetImag([In] MWSafeHandle hMXArrayTrg, [In] MWSafeHandle hMXArraySrcElem, [In] IntPtr numIndices, [In] IntPtr[] indices);
		[SuppressUnmanagedCodeSecurity]
		[DllImport("mclmcrrt7_17.dll", EntryPoint = "mclGetNumericSparse_proxy")]
		internal static extern int mclGetNumericSparse(out IntPtr pMXArray, [In] IntPtr rowIndexSize, [In] IntPtr[] rowindex, [In] IntPtr colIndexSize, [In] IntPtr[] columnindex, [In] IntPtr dataSize, [In] double[] realData, [In] double[] imaginaryData, [In] IntPtr rows, [In] IntPtr columns, [In] IntPtr nonZeroMax, [In] MWArray.MATLABArrayType arrayType, [In] MWArrayComplexity complexityFlag);
		static MWNumericArray()
		{
			MWNumericArray.Inf = MWNumericArray._Inf;
			MWNumericArray.NaN = MWNumericArray._NaN;
			MWNumericArray._Empty = new MWNumericArray(MWArrayComponent.Real, 0, 0);
			MWNumericArray.systemTypeToNumericType = null;
			MWNumericArray.numericTypeToSystemType = null;
			MWNumericArray.systemTypeToNumericType = new Hashtable(6);
			MWNumericArray.systemTypeToNumericType.Add(typeof(byte).Name, MWNumericType.UInt8);
			MWNumericArray.systemTypeToNumericType.Add(typeof(short).Name, MWNumericType.Int16);
			MWNumericArray.systemTypeToNumericType.Add(typeof(int).Name, MWNumericType.Int32);
			MWNumericArray.systemTypeToNumericType.Add(typeof(long).Name, MWNumericType.Int64);
			MWNumericArray.systemTypeToNumericType.Add(typeof(float).Name, MWNumericType.Single);
			MWNumericArray.systemTypeToNumericType.Add(typeof(double).Name, MWNumericType.Double);
			MWNumericArray.numericTypeToSystemType = new Dictionary<MWNumericType, Type>();
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.UInt8, typeof(byte));
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.Int16, typeof(short));
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.Int32, typeof(int));
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.Int64, typeof(long));
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.Single, typeof(float));
			MWNumericArray.numericTypeToSystemType.Add(MWNumericType.Double, typeof(double));
		}
		public MWNumericArray()
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[2];
				int[] array2 = array;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array2.Length, array2, MWNumericType.Double, MWArrayComplexity.Real), MWArrayType.Numeric, array2.Length, array2);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(MWNumericType dataType)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[1];
				int[] array2 = array;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array2.Length, array2, dataType, MWArrayComplexity.Real), MWArrayType.Numeric, array2.Length, array2);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(byte scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				double value = (double)scalar;
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(byte scalar, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				if (makeDouble)
				{
					double value = (double)scalar;
					base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
				}
				else
				{
					byte[] source = new byte[]
					{
						scalar
					};
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.UInt8, MWArrayComplexity.Real), MWArrayType.Numeric, array.Length, array);
					IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
					Marshal.Copy(source, 0, destination, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(byte realValue, byte imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				double[] source = new double[]
				{
					(double)realValue
				};
				double[] source2 = new double[]
				{
					(double)imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(byte realValue, byte imaginaryValue, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				MWNumericType elementType = makeDouble ? MWNumericType.Double : MWNumericType.UInt8;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (makeDouble)
				{
					double[] source = new double[]
					{
						(double)realValue
					};
					double[] source2 = new double[]
					{
						(double)imaginaryValue
					};
					Marshal.Copy(source, 0, destination, 1);
					Marshal.Copy(source2, 0, destination2, 1);
				}
				else
				{
					byte[] source3 = new byte[]
					{
						realValue
					};
					byte[] source4 = new byte[]
					{
						imaginaryValue
					};
					Marshal.Copy(source3, 0, destination, 1);
					Marshal.Copy(source4, 0, destination2, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(short scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				double value = (double)scalar;
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(short scalar, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				if (makeDouble)
				{
					double value = (double)scalar;
					base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
				}
				else
				{
					short[] source = new short[]
					{
						scalar
					};
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int16, MWArrayComplexity.Real), MWArrayType.Numeric, array.Length, array);
					IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
					Marshal.Copy(source, 0, destination, 1);
				}
				this.array_Type = MWArrayType.Numeric;
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(short realValue, short imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1
				};
				double[] source = new double[]
				{
					(double)realValue
				};
				double[] source2 = new double[]
				{
					(double)imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(short realValue, short imaginaryValue, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1
				};
				MWNumericType elementType = makeDouble ? MWNumericType.Double : MWNumericType.Int16;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (makeDouble)
				{
					double[] source = new double[]
					{
						(double)realValue
					};
					double[] source2 = new double[]
					{
						(double)imaginaryValue
					};
					Marshal.Copy(source, 0, destination, 1);
					Marshal.Copy(source2, 0, destination2, 1);
				}
				else
				{
					short[] source3 = new short[]
					{
						realValue
					};
					short[] source4 = new short[]
					{
						imaginaryValue
					};
					Marshal.Copy(source3, 0, destination, 1);
					Marshal.Copy(source4, 0, destination2, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				double value = (double)scalar;
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int scalar, bool makeDouble)
		{
			int[] array = new int[]
			{
				1,
				1
			};
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (makeDouble)
				{
					double value = (double)scalar;
					base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
				}
				else
				{
					int[] source = new int[]
					{
						scalar
					};
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int32, MWArrayComplexity.Real), MWArrayType.Numeric, array.Length, array);
					IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
					Marshal.Copy(source, 0, destination, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int realValue, int imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1
				};
				double[] source = new double[]
				{
					(double)realValue
				};
				double[] source2 = new double[]
				{
					(double)imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int realValue, int imaginaryValue, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1
				};
				MWNumericType elementType = makeDouble ? MWNumericType.Double : MWNumericType.Int32;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (makeDouble)
				{
					double[] source = new double[]
					{
						(double)realValue
					};
					double[] source2 = new double[]
					{
						(double)imaginaryValue
					};
					Marshal.Copy(source, 0, destination, 1);
					Marshal.Copy(source2, 0, destination2, 1);
				}
				else
				{
					int[] source3 = new int[]
					{
						realValue
					};
					int[] source4 = new int[]
					{
						imaginaryValue
					};
					Marshal.Copy(source3, 0, destination, 1);
					Marshal.Copy(source4, 0, destination2, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(long scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				double value = (double)scalar;
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(long scalar, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				if (makeDouble)
				{
					double value = (double)scalar;
					base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
				}
				else
				{
					long[] source = new long[]
					{
						scalar
					};
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int64, MWArrayComplexity.Real), MWArrayType.Numeric, array.Length, array);
					IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
					Marshal.Copy(source, 0, destination, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(long realValue, long imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				double[] source = new double[]
				{
					(double)realValue
				};
				double[] source2 = new double[]
				{
					(double)imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(long realValue, long imaginaryValue, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				MWNumericType elementType = makeDouble ? MWNumericType.Double : MWNumericType.Int64;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (makeDouble)
				{
					double[] source = new double[]
					{
						(double)realValue
					};
					double[] source2 = new double[]
					{
						(double)imaginaryValue
					};
					Marshal.Copy(source, 0, destination, 1);
					Marshal.Copy(source2, 0, destination2, 1);
				}
				else
				{
					long[] source3 = new long[]
					{
						realValue
					};
					long[] source4 = new long[]
					{
						imaginaryValue
					};
					Marshal.Copy(source3, 0, destination, 1);
					Marshal.Copy(source4, 0, destination2, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(float scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				double value = (double)scalar;
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(float scalar, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				if (makeDouble)
				{
					double value = (double)scalar;
					base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(value), MWArrayType.Numeric, array.Length, array);
				}
				else
				{
					float[] source = new float[]
					{
						scalar
					};
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Single, MWArrayComplexity.Real), MWArrayType.Numeric, array.Length, array);
					IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
					Marshal.Copy(source, 0, destination, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(float realValue, float imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1
				};
				double[] source = new double[]
				{
					(double)realValue
				};
				double[] source2 = new double[]
				{
					(double)imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(float realValue, float imaginaryValue, bool makeDouble)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				MWNumericType elementType = makeDouble ? MWNumericType.Double : MWNumericType.Single;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (makeDouble)
				{
					double[] source = new double[]
					{
						(double)realValue
					};
					double[] source2 = new double[]
					{
						(double)imaginaryValue
					};
					Marshal.Copy(source, 0, destination, 1);
					Marshal.Copy(source2, 0, destination2, 1);
				}
				else
				{
					float[] source3 = new float[]
					{
						realValue
					};
					float[] source4 = new float[]
					{
						imaginaryValue
					};
					Marshal.Copy(source3, 0, destination, 1);
					Marshal.Copy(source4, 0, destination2, 1);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(double scalar)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				base.SetMXArray(MWIndexArray.mxCreateDoubleScalar(scalar), MWArrayType.Numeric, array.Length, array);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(double realValue, double imaginaryValue)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int[] array = new int[]
				{
					1,
					1
				};
				double[] source = new double[]
				{
					realValue
				};
				double[] source2 = new double[]
				{
					imaginaryValue
				};
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, MWArrayComplexity.Complex), MWArrayType.Numeric, array.Length, array, true);
				IntPtr destination = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr destination2 = MWNumericArray.mxGetImagData(this.MXArrayHandle);
				Marshal.Copy(source, 0, destination, 1);
				Marshal.Copy(source2, 0, destination2, 1);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(params int[] dimensions)
		{
			if (dimensions == null)
			{
				throw new ArgumentNullException("dimensions");
			}
			try
			{
				Monitor.Enter(MWArray.mxSync);
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(dimensions.Length, dimensions, MWNumericType.Double, MWArrayComplexity.Real), MWArrayType.Numeric, dimensions.Length, dimensions);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(MWArrayComplexity complexity, params int[] dimensions)
		{
			if (dimensions == null)
			{
				throw new ArgumentNullException("dimensions");
			}
			try
			{
				Monitor.Enter(MWArray.mxSync);
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(dimensions.Length, dimensions, MWNumericType.Double, complexity), MWArrayType.Numeric, dimensions.Length, dimensions, complexity == MWArrayComplexity.Complex);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(MWArrayComplexity complexity, MWNumericType dataType, params int[] dimensions)
		{
			if (dimensions == null)
			{
				throw new ArgumentNullException("dimensions");
			}
			try
			{
				Monitor.Enter(MWArray.mxSync);
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(dimensions.Length, dimensions, dataType, complexity), MWArrayType.Numeric, dimensions.Length, dimensions, complexity == MWArrayComplexity.Complex);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, byte[] realData) : this(rows, columns, realData, null, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, byte[] realData, bool makeDouble, bool rowMajorData) : this(rows, columns, realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(int rows, int columns, byte[] realData, byte[] imaginaryData) : this(rows, columns, realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, byte[] realData, byte[] imaginaryData, bool makeDouble, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int num = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				if (!makeDouble)
				{
					byte[] array2 = rowMajorData ? new byte[num] : realData;
					byte[] array3 = imaginaryData;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.UInt8, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (rowMajorData)
					{
						array3 = ((imaginaryData != null) ? new byte[num] : null);
						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								array2[j * rows + i] = realData[i * columns + j];
								if (array3 != null)
								{
									array3[j * rows + i] = imaginaryData[i * columns + j];
								}
							}
						}
					}
					IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy(array2, 0, intPtr, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr2)
					{
						Marshal.Copy(array3, 0, intPtr2, num);
					}
				}
				else
				{
					double[] array4 = new double[num];
					double[] array5 = (imaginaryData != null) ? new double[num] : null;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (!rowMajorData)
					{
						for (int k = 0; k < num; k++)
						{
							array4[k] = (double)realData[k];
							if (array5 != null)
							{
								array5[k] = (double)imaginaryData[k];
							}
						}
					}
					else
					{
						for (int l = 0; l < rows; l++)
						{
							for (int m = 0; m < columns; m++)
							{
								array4[m * rows + l] = (double)realData[l * columns + m];
								if (array5 != null)
								{
									array5[m * rows + l] = (double)imaginaryData[l * columns + m];
								}
							}
						}
					}
					IntPtr intPtr3 = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr4 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr3)
					{
						Marshal.Copy(array4, 0, intPtr3, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr4)
					{
						Marshal.Copy(array5, 0, intPtr4, num);
					}
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, short[] realData) : this(rows, columns, realData, null, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, short[] realData, bool makeDouble, bool rowMajorData) : this(rows, columns, realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(int rows, int columns, short[] realData, short[] imaginaryData) : this(rows, columns, realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, short[] realData, short[] imaginaryData, bool makeDouble, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int num = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				if (!makeDouble)
				{
					short[] array2 = rowMajorData ? new short[realData.Length] : realData;
					short[] array3 = imaginaryData;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int16, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (rowMajorData)
					{
						array3 = ((imaginaryData != null) ? new short[realData.Length] : null);
						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								array2[j * rows + i] = realData[i * columns + j];
								if (array3 != null)
								{
									array3[j * rows + i] = imaginaryData[i * columns + j];
								}
							}
						}
					}
					IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy(array2, 0, intPtr, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr2)
					{
						Marshal.Copy(array3, 0, intPtr2, num);
					}
				}
				else
				{
					double[] array4 = new double[num];
					double[] array5 = (imaginaryData != null) ? new double[imaginaryData.Length] : null;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (!rowMajorData)
					{
						for (int k = 0; k < num; k++)
						{
							array4[k] = (double)realData[k];
							if (array5 != null)
							{
								array5[k] = (double)imaginaryData[k];
							}
						}
					}
					else
					{
						for (int l = 0; l < rows; l++)
						{
							for (int m = 0; m < columns; m++)
							{
								array4[m * rows + l] = (double)realData[l * columns + m];
								if (array5 != null)
								{
									array5[m * rows + l] = (double)imaginaryData[l * columns + m];
								}
							}
						}
					}
					IntPtr intPtr3 = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr4 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr3)
					{
						Marshal.Copy(array4, 0, intPtr3, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr4)
					{
						Marshal.Copy(array5, 0, intPtr4, num);
					}
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, int[] realData) : this(rows, columns, realData, null, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, int[] realData, bool makeDouble, bool rowMajorData) : this(rows, columns, realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(int rows, int columns, int[] realData, int[] imaginaryData) : this(rows, columns, realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, int[] realData, int[] imaginaryData, bool makeDouble, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int num = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				if (!makeDouble)
				{
					int[] array2 = rowMajorData ? new int[realData.Length] : realData;
					int[] array3 = imaginaryData;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int32, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (rowMajorData)
					{
						array3 = ((imaginaryData != null) ? new int[realData.Length] : null);
						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								array2[j * rows + i] = realData[i * columns + j];
								if (array3 != null)
								{
									array3[j * rows + i] = imaginaryData[i * columns + j];
								}
							}
						}
					}
					IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy(array2, 0, intPtr, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr2)
					{
						Marshal.Copy(array3, 0, intPtr2, num);
					}
				}
				else
				{
					double[] array4 = new double[num];
					double[] array5 = (imaginaryData != null) ? new double[imaginaryData.Length] : null;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (!rowMajorData)
					{
						for (int k = 0; k < num; k++)
						{
							array4[k] = (double)realData[k];
							if (array5 != null)
							{
								array5[k] = (double)imaginaryData[k];
							}
						}
					}
					else
					{
						for (int l = 0; l < rows; l++)
						{
							for (int m = 0; m < columns; m++)
							{
								array4[m * rows + l] = (double)realData[l * columns + m];
								if (array5 != null)
								{
									array5[m * rows + l] = (double)imaginaryData[l * columns + m];
								}
							}
						}
					}
					IntPtr intPtr3 = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr4 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr3)
					{
						Marshal.Copy(array4, 0, intPtr3, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr4)
					{
						Marshal.Copy(array5, 0, intPtr4, num);
					}
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, long[] realData) : this(rows, columns, realData, null, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, long[] realData, bool makeDouble, bool rowMajorData) : this(rows, columns, realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(int rows, int columns, long[] realData, long[] imaginaryData) : this(rows, columns, realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, long[] realData, long[] imaginaryData, bool makeDouble, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int num = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				if (!makeDouble)
				{
					long[] array2 = rowMajorData ? new long[realData.Length] : realData;
					long[] array3 = imaginaryData;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Int64, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (rowMajorData)
					{
						array3 = ((imaginaryData != null) ? new long[realData.Length] : null);
						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								array2[j * rows + i] = realData[i * columns + j];
								if (array3 != null)
								{
									array3[j * rows + i] = imaginaryData[i * columns + j];
								}
							}
						}
					}
					IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy(array2, 0, intPtr, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr2)
					{
						Marshal.Copy(array3, 0, intPtr2, num);
					}
				}
				else
				{
					double[] array4 = new double[num];
					double[] array5 = (imaginaryData != null) ? new double[imaginaryData.Length] : null;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (!rowMajorData)
					{
						for (int k = 0; k < num; k++)
						{
							array4[k] = (double)realData[k];
							if (array5 != null)
							{
								array5[k] = (double)imaginaryData[k];
							}
						}
					}
					else
					{
						for (int l = 0; l < rows; l++)
						{
							for (int m = 0; m < columns; m++)
							{
								array4[m * rows + l] = (double)realData[l * columns + m];
								if (array5 != null)
								{
									array5[m * rows + l] = (double)imaginaryData[l * columns + m];
								}
							}
						}
					}
					IntPtr intPtr3 = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr4 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr3)
					{
						Marshal.Copy(array4, 0, intPtr3, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr4)
					{
						Marshal.Copy(array5, 0, intPtr4, num);
					}
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, float[] realData) : this(rows, columns, realData, null, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, float[] realData, bool makeDouble, bool rowMajorData) : this(rows, columns, realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(int rows, int columns, float[] realData, float[] imaginaryData) : this(rows, columns, realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(int rows, int columns, float[] realData, float[] imaginaryData, bool makeDouble, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int num = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				if (!makeDouble)
				{
					float[] array2 = rowMajorData ? new float[realData.Length] : realData;
					float[] array3 = imaginaryData;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Single, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (rowMajorData)
					{
						array3 = ((imaginaryData != null) ? new float[realData.Length] : null);
						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								array2[j * rows + i] = realData[i * columns + j];
								if (array3 != null)
								{
									array3[j * rows + i] = imaginaryData[i * columns + j];
								}
							}
						}
					}
					IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy(array2, 0, intPtr, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr2)
					{
						Marshal.Copy(array3, 0, intPtr2, num);
					}
				}
				else
				{
					double[] array4 = new double[num];
					double[] array5 = (imaginaryData != null) ? new double[imaginaryData.Length] : null;
					base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
					if (!rowMajorData)
					{
						for (int k = 0; k < num; k++)
						{
							array4[k] = (double)realData[k];
							if (array5 != null)
							{
								array5[k] = (double)imaginaryData[k];
							}
						}
					}
					else
					{
						for (int l = 0; l < rows; l++)
						{
							for (int m = 0; m < columns; m++)
							{
								array4[m * rows + l] = (double)realData[l * columns + m];
								if (array5 != null)
								{
									array5[m * rows + l] = (double)imaginaryData[l * columns + m];
								}
							}
						}
					}
					IntPtr intPtr3 = MWArray.mxGetData(this.MXArrayHandle);
					IntPtr intPtr4 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
					if (IntPtr.Zero != intPtr3)
					{
						Marshal.Copy(array4, 0, intPtr3, num);
					}
					if (imaginaryData != null && IntPtr.Zero != intPtr4)
					{
						Marshal.Copy(array5, 0, intPtr4, num);
					}
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(int rows, int columns, double[] realData) : this(rows, columns, realData, null, true)
		{
            
		}
		public MWNumericArray(int rows, int columns, double[] realData, bool rowMajorData) : this(rows, columns, realData, null, rowMajorData)
		{

		}
		public MWNumericArray(int rows, int columns, double[] realData, double[] imaginaryData) : this(rows, columns, realData, imaginaryData, true)
		{

		}
		public MWNumericArray(int rows, int columns, double[] realData, double[] imaginaryData, bool rowMajorData)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWNumericArray.validateInput(rows * columns, realData, imaginaryData);
				int[] array = new int[]
				{
					rows,
					columns
				};
				int length = realData.Length;
				MWArrayComplexity mWArrayComplexity = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
				double[] array2 = rowMajorData ? new double[realData.Length] : realData;
				double[] array3 = imaginaryData;
				base.SetMXArray(MWNumericArray.mxCreateNumericArray(array.Length, array, MWNumericType.Double, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
				if (rowMajorData)
				{
					array3 = ((imaginaryData != null) ? new double[realData.Length] : null);
					for (int i = 0; i < rows; i++)
					{
						for (int j = 0; j < columns; j++)
						{
							array2[j * rows + i] = realData[i * columns + j];
							if (array3 != null)
							{
								array3[j * rows + i] = imaginaryData[i * columns + j];
							}
						}
					}
				}
				IntPtr intPtr = MWArray.mxGetData(this.MXArrayHandle);
				IntPtr intPtr2 = (imaginaryData != null) ? MWNumericArray.mxGetImagData(this.MXArrayHandle) : IntPtr.Zero;
				if (IntPtr.Zero != intPtr)
				{
					Marshal.Copy(array2, 0, intPtr, length);
				}
				if (imaginaryData != null && IntPtr.Zero != intPtr2)
				{
					Marshal.Copy(array3, 0, intPtr2, length);
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		public MWNumericArray(Array array)
		{
			if (JaggedArray.IsJagged(array))
			{
				JaggedArray jaggedArray = new JaggedArray(array);
				int[] dimensions = jaggedArray.GetDimensions();
				int[] array2 = MWArray.NetDimensionToMATLABDimension(dimensions);
				Array flatArray = jaggedArray.GetFlatArray();
				object mxSync;
				Monitor.Enter(mxSync = MWArray.mxSync);
				try
				{
					IntPtr dest = IntPtr.Zero;
					MWNumericType elementType = (MWNumericType)MWNumericArray.systemTypeToNumericType[jaggedArray.GetElementType().Name];
					MWSafeHandle hMXArray = MWNumericArray.mxCreateNumericArray(array2.Length, array2, elementType, MWArrayComplexity.Real);
					dest = MWArray.mxGetData(hMXArray);
					MWMarshal.MarshalManagedFlatArrayToUnmanaged(flatArray, dest);
					base.SetMXArray(hMXArray, MWArrayType.Numeric);
					return;
				}
				finally
				{
					Monitor.Exit(mxSync);
				}
			}
			this.FastBuildNumericArray(array, null, true, true);
		}
		public MWNumericArray(Array realData, bool makeDouble, bool rowMajorData) : this(realData, null, makeDouble, rowMajorData)
		{
		}
		public MWNumericArray(Array realData, Array imaginaryData) : this(realData, imaginaryData, true, true)
		{
		}
		public MWNumericArray(Array realData, Array imaginaryData, bool makeDouble, bool rowMajorData)
		{
			this.FastBuildNumericArray(realData, imaginaryData, makeDouble, rowMajorData);
			this.array_Type = MWArrayType.Numeric;
		}
		internal MWNumericArray(MWSafeHandle hMXArray) : base(hMXArray)
		{
			this.array_Type = MWArrayType.Numeric;
		}
		internal MWNumericArray(MWArrayComponent arrayComponent, int rows, int columns)
		{
			try
			{
				Monitor.Enter(MWArray.mxSync);
				MWArrayComplexity mWArrayComplexity = (arrayComponent == MWArrayComponent.Real) ? MWArrayComplexity.Real : MWArrayComplexity.Complex;
				int[] array = new int[]
				{
					rows,
					columns
				};
				base.SetMXArray(MWNumericArray.mxCreateDoubleMatrix(rows, columns, mWArrayComplexity), MWArrayType.Numeric, array.Length, array, mWArrayComplexity == MWArrayComplexity.Complex);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		internal MWNumericArray(double start, double step, double end)
		{
		}
		protected override void Dispose(bool disposing)
		{
			try
			{
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		public static implicit operator MWNumericArray(byte scalar)
		{
			return new MWNumericArray(scalar, false);
		}
		public static implicit operator MWNumericArray(short scalar)
		{
			return new MWNumericArray(scalar, false);
		}
		public static implicit operator MWNumericArray(int scalar)
		{
			return new MWNumericArray(scalar);
		}
		public static implicit operator MWNumericArray(long scalar)
		{
			return new MWNumericArray(scalar, false);
		}
		public static implicit operator MWNumericArray(float scalar)
		{
			return new MWNumericArray(scalar, false);
		}
		public  static implicit operator MWNumericArray(double scalar)
		{
			return new MWNumericArray(scalar);
		}
		public  static implicit operator MWNumericArray(byte[] values)
		{
			return new MWNumericArray(1, values.Length, values, null, false, false);
		}
		public  static implicit operator MWNumericArray(short[] values)
		{
			return new MWNumericArray(1, values.Length, values, null, false, false);
		}
		public  static implicit operator MWNumericArray(int[] values)
		{
			return new MWNumericArray(1, values.Length, values);
		}
		public  static implicit operator MWNumericArray(long[] values)
		{
			return new MWNumericArray(1, values.Length, values, null, false, false);
		}
		public static implicit operator MWNumericArray(float[] values)
		{
			return new MWNumericArray(1, values.Length, values, null, false, false);
		}
		public static implicit operator MWNumericArray(double[] values)
		{
			return new MWNumericArray(1, values.Length, values);
		}
		public static implicit operator MWNumericArray(Array realData)
		{
			return new MWNumericArray(realData, null, false, true);
		}
		public static explicit operator byte(MWNumericArray array)
		{
			array.CheckDisposed();
			byte result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (9 != MWArray.mxGetClassID(array.MXArrayHandle))
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = checked((byte)MWArray.mxGetScalar(array.MXArrayHandle));
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static explicit operator short(MWNumericArray array)
		{
			array.CheckDisposed();
			short result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (10 != MWArray.mxGetClassID(array.MXArrayHandle))
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = checked((short)MWArray.mxGetScalar(array.MXArrayHandle));
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static explicit operator int(MWNumericArray array)
		{
			array.CheckDisposed();
			int result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int num = MWArray.mxGetClassID(array.MXArrayHandle);
				if (12 != num && 6 != num)
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = checked((int)MWArray.mxGetScalar(array.MXArrayHandle));
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static explicit operator long(MWNumericArray array)
		{
			array.CheckDisposed();
			long result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (14 != MWArray.mxGetClassID(array.MXArrayHandle))
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = checked((long)MWArray.mxGetScalar(array.MXArrayHandle));
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static explicit operator float(MWNumericArray array)
		{
			array.CheckDisposed();
			float result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (7 != MWArray.mxGetClassID(array.MXArrayHandle))
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = (float)MWArray.mxGetScalar(array.MXArrayHandle);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static explicit operator double(MWNumericArray array)
		{
			array.CheckDisposed();
			double result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				if (6 != MWArray.mxGetClassID(array.MXArrayHandle))
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(@string);
				}
				result = MWArray.mxGetScalar(array.MXArrayHandle);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public byte ToScalarByte()
		{
			return (byte)this;
		}
		public short ToScalarShort()
		{
			return (short)this;
		}
		public int ToScalarInteger()
		{
			return (int)this;
		}
		public long ToScalarLong()
		{
			return (long)this;
		}
		public float ToScalarFloat()
		{
			return (float)this;
		}
		public double ToScalarDouble()
		{
			return (double)this;
		}
		protected MWNumericArray(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
		{
		}
		private static void validateInput(int specifiedSize, Array realData, Array imaginaryData)
		{
			if (realData == null)
			{
				throw new ArgumentNullException("realData");
			}
			if (realData.LongLength != (long)specifiedSize)
			{
				string @string = MWArray.resourceManager.GetString("MWErrorDataArraySize");
				throw new ArgumentException(@string, "realData");
			}
			MWNumericArray.validateRealAndImaginaryInput(realData, imaginaryData);
		}
		private static void validateInput(Array realData, Array imaginaryData)
		{
			if (realData == null)
			{
				throw new ArgumentNullException("realData");
			}
			Type elementType = realData.GetType().GetElementType();
			if (typeof(double) != elementType && typeof(int) != elementType && typeof(byte) != elementType && typeof(short) != elementType && typeof(long) != elementType && typeof(float) != elementType)
			{
				string @string = MWArray.resourceManager.GetString("MWErrorDataArrayType");
				throw new ArgumentException(@string);
			}
			MWNumericArray.validateRealAndImaginaryInput(realData, imaginaryData);
		}
		private static void validateRealAndImaginaryInput(Array realData, Array imaginaryData)
		{
			if (imaginaryData != null)
			{
				if (realData.GetType().GetElementType() != imaginaryData.GetType().GetElementType())
				{
					string @string = MWArray.resourceManager.GetString("MWErrorDataArrayType");
					throw new ArgumentException(@string, "imaginaryData");
				}
				if (realData.Length != imaginaryData.Length)
				{
					string string2 = MWArray.resourceManager.GetString("MWErrorDataArraySizeMismatch");
					throw new ArgumentException(string2);
				}
				int rank = realData.Rank;
				if (rank != imaginaryData.Rank)
				{
					string string3 = MWArray.resourceManager.GetString("MWErrorDataArrayRankMismatch");
					throw new ArgumentException(string3);
				}
				for (int i = 0; i < rank; i++)
				{
					if (realData.GetLength(i) != imaginaryData.GetLength(i))
					{
						string string4 = MWArray.resourceManager.GetString("MWErrorRealImaginaryDimensionMismatch");
						throw new ArgumentException(string4);
					}
				}
			}
		}
		public static MWNumericArray MakeSparse(int rows, int columns, MWArrayComplexity complexity, int nonZeroMax)
		{
			MWNumericArray result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				IntPtr pArrayHandle;
				if (MWNumericArray.mclGetNumericSparse(out pArrayHandle, (IntPtr)0, null, (IntPtr)0, null, (IntPtr)0, null, null, (IntPtr)rows, (IntPtr)columns, (IntPtr)nonZeroMax, MWArray.MATLABArrayType.Double, complexity) == 0)
				{
					MWSafeHandle hMXArray;
					if (MWArray.mclArrayHandle2mxArray(out hMXArray, pArrayHandle) != 0)
					{
						string @string = MWArray.resourceManager.GetString("MWErrorInvalidArray");
						throw new Exception(@string);
					}
					result = new MWNumericArray(hMXArray);
				}
				else
				{
					result = null;
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static MWNumericArray MakeSparse(int[] rowIndex, int[] columnIndex, double[] realData)
		{
			return MWNumericArray.MakeSparse(rowIndex, columnIndex, realData, null);
		}
		public static MWNumericArray MakeSparse(int[] rowIndex, int[] columnIndex, double[] realData, double[] imaginaryData)
		{
			MWNumericArray result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int num = rowIndex.Length;
				if (num != columnIndex.Length)
				{
					string @string = MWArray.resourceManager.GetString("MWErrorInvalidIndices");
					throw new Exception(@string);
				}
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < num; i++)
				{
					num2 = Math.Max(num2, rowIndex[i]);
					num3 = Math.Max(num3, columnIndex[i]);
				}
				result = MWNumericArray.MakeSparse(num2, num3, rowIndex, columnIndex, realData, imaginaryData);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public static MWNumericArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, double[] realData)
		{
			return MWNumericArray.MakeSparse(rows, columns, rowIndex, columnIndex, realData, null);
		}
		public static MWNumericArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, double[] realData, int nonZeroMax)
		{
			return MWNumericArray.MakeSparse(rows, columns, rowIndex, columnIndex, realData, null, nonZeroMax);
		}
		public static MWNumericArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, double[] realData, double[] imaginaryData)
		{
			return MWNumericArray.MakeSparse(rows, columns, rowIndex, columnIndex, realData, imaginaryData, rowIndex.Length);
		}
		public static MWNumericArray MakeSparse(int rows, int columns, int[] rowIndex, int[] columnIndex, double[] realData, double[] imaginaryData, int nonZeroMax)
		{
			MWNumericArray result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				IntPtr zero = IntPtr.Zero;
				MWArrayComplexity complexityFlag = (imaginaryData == null) ? MWArrayComplexity.Real : MWArrayComplexity.Complex;
				IntPtr[] array = new IntPtr[rowIndex.Length];
				IntPtr[] array2 = new IntPtr[columnIndex.Length];
				for (int i = 0; i < rowIndex.Length; i++)
				{
					array[i] = (IntPtr)rowIndex[i];
					array2[i] = (IntPtr)columnIndex[i];
				}
				if (MWNumericArray.mclGetNumericSparse(out zero, (IntPtr)rowIndex.Length, array, (IntPtr)columnIndex.Length, array2, (IntPtr)realData.Length, realData, imaginaryData, (IntPtr)rows, (IntPtr)columns, (IntPtr)nonZeroMax, MWArray.MATLABArrayType.Double, complexityFlag) == 0)
				{
					MWSafeHandle hMXArray;
					if (MWArray.mclArrayHandle2mxArray(out hMXArray, zero) != 0)
					{
						string @string = MWArray.resourceManager.GetString("MWErrorInvalidArray");
						throw new Exception(@string);
					}
					result = new MWNumericArray(hMXArray);
				}
				else
				{
					result = null;
				}
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		internal Array MarshalToFullArray<T>(int rows, int[,] rowIndices, int cols, int[,] colIndices, int numSparseElements, Array vectorData)
		{
			Array array = Array.CreateInstance(typeof(T), rows, cols);
			for (int i = 0; i < numSparseElements; i++)
			{
				T t = ((T[])vectorData)[i];
				array.SetValue(t, rowIndices[0, i] - 1, colIndices[0, i] - 1);
			}
			return array;
		}
		internal Array ToArray(MWArrayComponent component, bool sparseIndex)
		{
			base.CheckDisposed();
			object mxSync;
			Monitor.Enter(mxSync = MWArray.mxSync);
			Array result;
			try
			{
				IntPtr intPtr = (component == MWArrayComponent.Real) ? MWArray.mxGetData(this.MXArrayHandle) : MWNumericArray.mxGetImagData(this.MXArrayHandle);
				if (intPtr == IntPtr.Zero && component == MWArrayComponent.Imaginary)
				{
					throw new InvalidDataException("No imaginary data elements in the array.");
				}
				if (MWArray.mxIsSparse(this.MXArrayHandle) != 0)
				{
					int num = 0;
					int num2 = 0;
					MWSafeHandle hMXArray;
					MWSafeHandle hMXArray2;
					if (MWIndexArray.mclMXArrayGetIndexArrays(out hMXArray, out hMXArray2, this.MXArrayHandle) != 0)
					{
						string @string = MWArray.resourceManager.GetString("MWErrorInvalidIndex");
						throw new Exception(@string);
					}
					MWNumericArray mWNumericArray = new MWNumericArray(hMXArray);
					MWNumericArray mWNumericArray2 = new MWNumericArray(hMXArray2);
					int numberOfElements = mWNumericArray.NumberOfElements;
					int[,] array;
					int[,] array2;
					if (MWNumericType.UInt64 != mWNumericArray.NumericType)
					{
						array = (int[,])mWNumericArray.ToArray(MWArrayComponent.Real, true);
						array2 = (int[,])mWNumericArray2.ToArray(MWArrayComponent.Real, true);
						for (int i = 0; i < numberOfElements; i++)
						{
							num = Math.Max(num, array[0, i]);
							num2 = Math.Max(num2, array2[0, i]);
						}
					}
					else
					{
						long[,] array3 = (long[,])mWNumericArray.ToArray(MWArrayComponent.Real, true);
						long[,] array4 = (long[,])mWNumericArray2.ToArray(MWArrayComponent.Real, true);
						array = new int[array3.GetLength(0), array3.GetLength(1)];
						array2 = new int[array4.GetLength(0), array4.GetLength(1)];
						for (int j = 0; j < numberOfElements; j++)
						{
							checked
							{
								num = Math.Max(num, array[0, j] = (int)array3[0, j]);
								num2 = Math.Max(num2, array2[0, j] = (int)array4[0, j]);
							}
						}
					}
					switch (this.NumericType)
					{
					case MWNumericType.Double:
					{
						Array array5 = Array.CreateInstance(typeof(double), numberOfElements);
						Marshal.Copy(intPtr, (double[])array5, 0, numberOfElements);
						result = this.MarshalToFullArray<double>(num, array, num2, array2, numberOfElements, array5);
						return result;
					}
					case MWNumericType.Single:
					{
						Array array6 = Array.CreateInstance(typeof(float), numberOfElements);
						Marshal.Copy(intPtr, (float[])array6, 0, numberOfElements);
						result = this.MarshalToFullArray<float>(num, array, num2, array2, numberOfElements, array6);
						return result;
					}
					case MWNumericType.UInt8:
					{
						Array array7 = Array.CreateInstance(typeof(byte), numberOfElements);
						Marshal.Copy(intPtr, (byte[])array7, 0, numberOfElements);
						result = this.MarshalToFullArray<byte>(num, array, num2, array2, numberOfElements, array7);
						return result;
					}
					case MWNumericType.Int16:
					{
						Array array8 = Array.CreateInstance(typeof(short), numberOfElements);
						Marshal.Copy(intPtr, (short[])array8, 0, numberOfElements);
						result = this.MarshalToFullArray<short>(num, array, num2, array2, numberOfElements, array8);
						return result;
					}
					case MWNumericType.Int32:
					{
						Array array9 = Array.CreateInstance(typeof(int), numberOfElements);
						Marshal.Copy(intPtr, (int[])array9, 0, numberOfElements);
						result = this.MarshalToFullArray<int>(num, array, num2, array2, numberOfElements, array9);
						return result;
					}
					case MWNumericType.Int64:
					{
						Array array10 = Array.CreateInstance(typeof(long), numberOfElements);
						Marshal.Copy(intPtr, (long[])array10, 0, numberOfElements);
						result = this.MarshalToFullArray<long>(num, array, num2, array2, numberOfElements, array10);
						return result;
					}
					}
					string string2 = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
					throw new ApplicationException(string2);
				}
				else
				{
					MWNumericType mWNumericType = this.NumericType;
					int[] lengths = MWArray.MATLABDimensionToNetDimension(this.Dimensions);
					if (sparseIndex)
					{
						if (MWNumericType.UInt32 == mWNumericType)
						{
							mWNumericType = MWNumericType.Int32;
						}
						if (MWNumericType.UInt64 == mWNumericType)
						{
							mWNumericType = MWNumericType.Int64;
						}
					}
					Type elementType = MWNumericArray.numericTypeToSystemType[mWNumericType];
					Array array11 = Array.CreateInstance(elementType, lengths);
					MWMarshal.MarshalUnmanagedColumnMajorToManagedRowMajor(intPtr, array11);
					result = array11;
				}
			}
			finally
			{
				Monitor.Exit(mxSync);
			}
			return result;
		}
		public override object Clone()
		{
			base.CheckDisposed();
			MWNumericArray mWNumericArray = (MWNumericArray)base.MemberwiseClone();
			object result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				mWNumericArray.SetMXArray(MWArray.mxDuplicateArray(this.MXArrayHandle), MWArrayType.Numeric);
				result = mWNumericArray;
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public override string ToString()
		{
			return base.ToString();
		}
		public override bool Equals(object obj)
		{
			return obj is MWNumericArray && this.Equals(obj as MWNumericArray);
		}
		private bool Equals(MWNumericArray obj)
		{
			return base.Equals(obj);
		}
		bool IEquatable<MWNumericArray>.Equals(MWNumericArray other)
		{
			return this.Equals(other);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public Array ToVector(MWArrayComponent component)
		{
			base.CheckDisposed();
			Array result;
			try
			{
				Monitor.Enter(MWArray.mxSync);
				int numberOfElements = base.NumberOfElements;
				MWNumericType numericType = this.NumericType;
				IntPtr source = (component == MWArrayComponent.Real) ? MWArray.mxGetData(this.MXArrayHandle) : MWNumericArray.mxGetImagData(this.MXArrayHandle);
				switch (numericType)
				{
				case MWNumericType.Double:
				{
					double[] array = new double[numberOfElements];
					Marshal.Copy(source, array, 0, numberOfElements);
					result = array;
					return result;
				}
				case MWNumericType.Single:
				{
					float[] array2 = new float[numberOfElements];
					Marshal.Copy(source, array2, 0, numberOfElements);
					result = array2;
					return result;
				}
				case MWNumericType.UInt8:
				{
					byte[] array3 = new byte[numberOfElements];
					Marshal.Copy(source, array3, 0, numberOfElements);
					result = array3;
					return result;
				}
				case MWNumericType.Int16:
				{
					short[] array4 = new short[numberOfElements];
					Marshal.Copy(source, array4, 0, numberOfElements);
					result = array4;
					return result;
				}
				case MWNumericType.Int32:
				{
					int[] array5 = new int[numberOfElements];
					Marshal.Copy(source, array5, 0, numberOfElements);
					result = array5;
					return result;
				}
				case MWNumericType.Int64:
				{
					long[] array6 = new long[numberOfElements];
					Marshal.Copy(source, array6, 0, numberOfElements);
					result = array6;
					return result;
				}
				}
				string @string = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
				throw new ApplicationException(@string);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
			return result;
		}
		public override Array ToArray()
		{
			if (this.IsComplex)
			{
				throw new InvalidDataException("Data type unsupported by MATLAB Builder NE for output");
			}
			return this.ToArray(MWArrayComponent.Real);
		}
		public Array ToArray(MWArrayComponent component)
		{
			return this.ToArray(component, false);
		}
		private void BuildNumericArray(Array realData, Array imaginaryData, bool makeDouble, bool rowMajorData)
		{
			if (realData == null)
			{
				throw new ArgumentNullException("realData");
			}
			Type type = realData.GetType().GetElementType();
			if (typeof(double) != type && typeof(int) != type && typeof(byte) != type && typeof(short) != type && typeof(long) != type && typeof(float) != type)
			{
				string @string = MWArray.resourceManager.GetString("MWErrorDataArrayType");
				throw new ArgumentException(@string);
			}
			if (imaginaryData != null)
			{
				if (type != imaginaryData.GetType().GetElementType())
				{
					string string2 = MWArray.resourceManager.GetString("MWErrorDataArrayType");
					throw new ArgumentException(string2, "imaginaryData");
				}
				if (realData.Length != imaginaryData.Length)
				{
					string string3 = MWArray.resourceManager.GetString("MWErrorDataArraySizeMismatch");
					throw new ArgumentException(string3);
				}
			}
			int rank = realData.Rank;
			int num = (imaginaryData == null) ? 0 : imaginaryData.Rank;
			MWArrayComplexity complexityFlag = (num != 0) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
			if (imaginaryData != null && rank != num)
			{
				string string4 = MWArray.resourceManager.GetString("MWErrorDimensionMismatch");
				throw new ArgumentException(string4);
			}
			int[] array = new int[Math.Max(rank, 2)];
			int length = realData.Length;
			int num2 = array[0] = ((1 < rank) ? realData.GetLength(rank - 2) : 1);
			int num3 = array[1] = realData.GetLength(rank - 1);
			for (int i = 0; i < rank - 2; i++)
			{
				array[rank - i - 1] = realData.GetLength(i);
			}
			IEnumerator enumerator = realData.GetEnumerator();
			IEnumerator enumerator2 = (imaginaryData != null) ? imaginaryData.GetEnumerator() : null;
			type = (makeDouble ? typeof(double) : type);
			Array array2 = Array.CreateInstance(type, length);
			Array array3 = (imaginaryData != null) ? Array.CreateInstance(type, length) : null;
			if (!rowMajorData)
			{
				for (int j = 0; j < length; j++)
				{
					enumerator.MoveNext();
					array2.SetValue(enumerator.Current, j);
					if (imaginaryData != null)
					{
						enumerator2.MoveNext();
						array3.SetValue(enumerator2.Current, j);
					}
				}
			}
			else
			{
				for (int k = 0; k < length; k += num2 * num3)
				{
					for (int l = 0; l < num2; l++)
					{
						for (int m = 0; m < num3; m++)
						{
							enumerator.MoveNext();
							array2.SetValue(enumerator.Current, m * num2 + l + k);
							if (imaginaryData != null)
							{
								enumerator2.MoveNext();
								array3.SetValue(enumerator2.Current, m * num2 + l + k);
							}
						}
					}
				}
			}
			try
			{
				Monitor.Enter(MWArray.mxSync);
				IntPtr intPtr = IntPtr.Zero;
				IntPtr intPtr2 = IntPtr.Zero;
				MWNumericType elementType = (MWNumericType)MWNumericArray.systemTypeToNumericType[type.Name];
				MWSafeHandle hMXArray = MWNumericArray.mxCreateNumericArray(array.Length, array, elementType, complexityFlag);
				intPtr = MWArray.mxGetData(hMXArray);
				intPtr2 = ((imaginaryData != null) ? MWNumericArray.mxGetImagData(hMXArray) : IntPtr.Zero);
				switch (elementType)
				{
				case MWNumericType.Double:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((double[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((double[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				case MWNumericType.Single:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((float[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((float[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				case MWNumericType.UInt8:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((byte[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((byte[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				case MWNumericType.Int16:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((short[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((short[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				case MWNumericType.Int32:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((int[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((int[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				case MWNumericType.Int64:
					if (IntPtr.Zero != intPtr)
					{
						Marshal.Copy((long[])array2, 0, intPtr, length);
					}
					if (IntPtr.Zero != intPtr2)
					{
						Marshal.Copy((long[])array3, 0, intPtr2, length);
						goto IL_4D1;
					}
					goto IL_4D1;
				}
				string string5 = MWArray.resourceManager.GetString("MWErrorInvalidArrayDataType");
				throw new ApplicationException(string5);
				IL_4D1:
				base.SetMXArray(hMXArray, MWArrayType.Numeric);
			}
			finally
			{
				Monitor.Exit(MWArray.mxSync);
			}
		}
		private unsafe void FastBuildNumericArray(Array realData, Array imaginaryData, bool makeDouble, bool rowMajorData)
		{
			MWNumericArray.validateInput(realData, imaginaryData);
			int rank = realData.Rank;
			if (rank == 1)
			{
				rowMajorData = false;
			}
			int[] array = new int[rank];
			for (int i = 0; i < rank; i++)
			{
				array[i] = realData.GetLength(i);
			}
			int[] array2 = MWArray.NetDimensionToMATLABDimension(array);
			MWArrayComplexity complexityFlag = (imaginaryData != null) ? MWArrayComplexity.Complex : MWArrayComplexity.Real;
			object mxSync;
			Monitor.Enter(mxSync = MWArray.mxSync);
			try
			{
				Type type = makeDouble ? typeof(double) : realData.GetType().GetElementType();
				MWNumericType elementType = (MWNumericType)MWNumericArray.systemTypeToNumericType[type.Name];
				MWSafeHandle hMXArray = MWNumericArray.mxCreateNumericArray(array2.Length, array2, elementType, complexityFlag);
				IntPtr dest = MWArray.mxGetData(hMXArray);
				if (makeDouble)
				{
					if (rowMajorData)
					{
						MWMarshal.MarshalManagedRowMajorToUnmanagedColumnMajor(realData, (double*)dest.ToPointer());
						if (imaginaryData != null)
						{
							MWMarshal.MarshalManagedRowMajorToUnmanagedColumnMajor(imaginaryData, (double*)MWNumericArray.mxGetImagData(hMXArray).ToPointer());
						}
					}
					else
					{
						MWMarshal.MarshalManagedColumnMajorToUnmanagedColumnMajor(realData, (double*)dest.ToPointer());
						if (imaginaryData != null)
						{
							MWMarshal.MarshalManagedColumnMajorToUnmanagedColumnMajor(imaginaryData, (double*)MWNumericArray.mxGetImagData(hMXArray).ToPointer());
						}
					}
				}
				else
				{
					if (rowMajorData)
					{
						MWMarshal.MarshalManagedRowMajorToUnmanagedColumnMajor(realData, dest);
						if (imaginaryData != null)
						{
							IntPtr dest2 = MWNumericArray.mxGetImagData(hMXArray);
							MWMarshal.MarshalManagedRowMajorToUnmanagedColumnMajor(imaginaryData, dest2);
						}
					}
					else
					{
						MWMarshal.MarshalManagedColumnMajorToUnmanagedColumnMajor(realData, dest);
						if (imaginaryData != null)
						{
							IntPtr dest3 = MWNumericArray.mxGetImagData(hMXArray);
							MWMarshal.MarshalManagedColumnMajorToUnmanagedColumnMajor(imaginaryData, dest3);
						}
					}
				}
				base.SetMXArray(hMXArray, MWArrayType.Numeric);
			}
			finally
			{
				Monitor.Exit(mxSync);
			}
		}
		private object CastToNativeScalar()
		{
			switch (this.NumericType)
			{
			case MWNumericType.Double:
				return (double)this;
			case MWNumericType.Single:
				return (float)this;
			case MWNumericType.UInt8:
				return (byte)this;
			case MWNumericType.Int16:
				return (short)this;
			case MWNumericType.Int32:
				return (int)this;
			case MWNumericType.Int64:
				return (long)this;
			}
			return null;
		}
		internal override object ConvertToType(Type t)
		{
			if (t == typeof(MWArray) || t == typeof(MWNumericArray))
			{
				return this;
			}
			if (this.IsValidConversion(t))
			{
				if (t.IsPrimitive)
				{
					return Convert.ChangeType(this.CastToNativeScalar(), t);
				}
				if (t.IsArray)
				{
					Array array;
					if (JaggedArray.IsJagged(t))
					{
						int length = MWArray.mxGetNumberOfElements(this.MXArrayHandle);
						IntPtr src = MWArray.mxGetData(this.MXArrayHandle);
						array = Array.CreateInstance(JaggedArray.GetElementType(t), length);
						MWMarshal.MarshalUnmanagedToManagedFlatArray(src, array);
						int[] dimensions = MWArray.MATLABDimensionToNetDimension(this.Dimensions);
						return JaggedArray.GetJaggedArrayFromFlatArray(array, dimensions);
					}
					if (t.GetArrayRank() == 1)
					{
						array = this.ToVector(MWArrayComponent.Real);
					}
					else
					{
						array = this.ToArray();
					}
					if (t == MWNumericArray.numericTypeToSystemType[this.NumericType])
					{
						return array;
					}
					int[] array2 = new int[array.Rank];
					for (int i = 0; i < array.Rank; i++)
					{
						array2[i] = array.GetUpperBound(i) + 1;
					}
					Array array3 = Array.CreateInstance(t.GetElementType(), array2);
					Array.Copy(array, array3, array.Length);
					return array3;
				}
			}
			string @string = MWArray.resourceManager.GetString("MWErrorInvalidDataConversion");
			string fullName = MWNumericArray.numericTypeToSystemType[this.NumericType].FullName;
			string message = string.Concat(new string[]
			{
				"Cannot convert from MWNumericArray of type: ",
				fullName,
				MWArray.RankToString(base.NumberofDimensions),
				" to ",
				t.FullName
			});
			throw new ArgumentException(@string, new ApplicationException(message));
		}
		internal override bool IsValidConversion(Type t)
		{
			Type type = MWNumericArray.numericTypeToSystemType[this.NumericType];
			Type[] array = MWArray.typeMap[type];
			if (array == null)
			{
				return false;
			}
			Type elementType = t;
			if (t.IsArray)
			{
				if (!JaggedArray.IsJagged(t))
				{
					int arrayRank = t.GetArrayRank();
					if (arrayRank == base.NumberofDimensions)
					{
						elementType = t.GetElementType();
					}
					else
					{
						if (arrayRank != 1)
						{
							return false;
						}
						if (!base.IsVector())
						{
							return false;
						}
						elementType = t.GetElementType();
					}
				}
				else
				{
					if (JaggedArray.GetRank(t) == base.NumberofDimensions && JaggedArray.GetElementType(t) == type)
					{
						return true;
					}
				}
			}
			else
			{
				if (!base.IsScalar())
				{
					return false;
				}
			}
			return Array.Exists<Type>(array, (Type c) => c == elementType);
		}
	}
}
