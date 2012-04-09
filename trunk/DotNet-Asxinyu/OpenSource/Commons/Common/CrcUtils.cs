namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public sealed class CrcUtils
    {
        private static uint[] MEWIXKqxt = null;
        private static ushort[] TEPULnwMP = null;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 01FqmBarm()
        {
            if (TEPULnwMP == null)
            {
                TEPULnwMP = new ushort[0x100];
                for (ushort i = 0; i < 0x100; i = (ushort) (i + 1))
                {
                    ushort num2 = i;
                    for (int j = 0; j < 8; j++)
                    {
                        if ((num2 % 2) == 0)
                        {
                            num2 = (ushort) (num2 >> 1);
                        }
                        else
                        {
                            num2 = (ushort) ((num2 >> 1) ^ 0x8408);
                        }
                    }
                    TEPULnwMP[i] = num2;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static uint 4bccOhnfl(byte num2, uint num1)
        {
            return (MEWIXKqxt[(int) ((IntPtr) ((num1 & 0xff) ^ num2))] ^ (num1 >> 8));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ushort CRC16(byte[] ABytes)
        {
            01FqmBarm();
            ushort num = 0xffff;
            foreach (byte num2 in ABytes)
            {
                num = yTHMJ858G(num2, num);
            }
            return ~num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ushort CRC16(string AString)
        {
            return CRC16(AString, Encoding.UTF8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ushort CRC16(string AString, Encoding AEncoding)
        {
            return CRC16(AEncoding.GetBytes(AString));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint CRC32(string AString)
        {
            return CRC32(AString, Encoding.UTF8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint CRC32(byte[] ABytes)
        {
            dT3f0t4t3();
            uint maxValue = uint.MaxValue;
            foreach (byte num2 in ABytes)
            {
                maxValue = 4bccOhnfl(num2, maxValue);
            }
            return ~maxValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint CRC32(string AString, Encoding AEncoding)
        {
            return CRC32(AEncoding.GetBytes(AString));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3()
        {
            if (MEWIXKqxt == null)
            {
                MEWIXKqxt = new uint[0x100];
                for (uint i = 0; i < 0x100; i++)
                {
                    uint num2 = i;
                    for (int j = 0; j < 8; j++)
                    {
                        if ((num2 % 2) == 0)
                        {
                            num2 = num2 >> 1;
                        }
                        else
                        {
                            num2 = (num2 >> 1) ^ 0xedb88320;
                        }
                    }
                    MEWIXKqxt[i] = num2;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ushort yTHMJ858G(byte num2, ushort num1)
        {
            return (ushort) (TEPULnwMP[(num1 & 0xff) ^ num2] ^ (num1 >> 8));
        }
    }
}

