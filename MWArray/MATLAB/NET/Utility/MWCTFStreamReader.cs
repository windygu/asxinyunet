namespace MathWorks.MATLAB.NET.Utility
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class MWCTFStreamReader
    {
        private ReadCtfStreamDelegate _readCtfStream;
        private BinaryReader ctfStreamReader;
        private IntPtr readCtfStreamFcn;

        public MWCTFStreamReader(Stream embeddedCtfStream)
        {
            embeddedCtfStream.Position = 0;
            this._readCtfStream = new ReadCtfStreamDelegate(this.readCtfStream);
            this.readCtfStreamFcn = Marshal.GetFunctionPointerForDelegate(this._readCtfStream);
            this.ctfStreamReader = new BinaryReader(embeddedCtfStream);
        }

        internal int readCtfStream(IntPtr ctfByte, int readSize)
        {
            int length;
            try
            {
                byte[] source = this.ctfStreamReader.ReadBytes(readSize);
                Marshal.Copy(source, 0, ctfByte, source.Length);
                length = source.Length;
            }
            catch (EndOfStreamException)
            {
                length = -1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return length;
        }

        public IntPtr CtfStreamReadFcn { get { return this.readCtfStreamFcn; } }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int ReadCtfStreamDelegate(IntPtr ctfByte, int size);
    }
}
