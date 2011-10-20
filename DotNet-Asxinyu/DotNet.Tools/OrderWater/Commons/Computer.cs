namespace WHC.OrderWater.Commons
{
    using Microsoft.Win32;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Computer
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Computer()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetComputerName()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCpuID()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetCpuUsage()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiskID()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMacAddress()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSystemType()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTotalPhysicalMemory()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUserName()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        internal sealed class aC5CTBqbArLbDaaCFog : Computer.CpuUsage
        {
            private const int k1mUM9ocK = 3;
            private double m7HRrMhfC;
            private const int MnvNdaLNh = 2;
            private long nBCwVbEfB;
            private const int r4vfcKJvu = 0;
            private long snJo0QVxt;
            private const int yT4VNh4qe = 0;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public aC5CTBqbArLbDaaCFog()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [DllImport("ntdll", EntryPoint="NtQuerySystemInformation")]
            private static extern int qCpqRb2bV(int, byte[], int, IntPtr);
            [MethodImpl(MethodImplOptions.NoInlining)]
            public override int Query()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public abstract class CpuUsage
        {
            private static Computer.CpuUsage qCpqRb2bV;

            [MethodImpl(MethodImplOptions.NoInlining)]
            static CpuUsage()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            protected CpuUsage()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public static Computer.CpuUsage Create()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            public abstract int Query();
        }

        internal sealed class gjX3vAqlRwFkwyyDtUa : Computer.CpuUsage
        {
            private RegistryKey qCpqRb2bV;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public gjX3vAqlRwFkwyyDtUa()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            protected override void Finalize()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public override int Query()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
