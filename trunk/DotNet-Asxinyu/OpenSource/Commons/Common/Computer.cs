namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Management;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Computer
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCpuID()
        {
            string str = string.Empty;
            using (ManagementClass class2 = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb46)))
            {
                ManagementObjectCollection instances = class2.GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    str = obj2.Properties[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb68)].Value.ToString();
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetCpuUsage()
        {
            return CpuUsage.Create().Query();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiskID()
        {
            string str = string.Empty;
            using (ManagementClass class2 = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xebf6)))
            {
                ManagementObjectCollection instances = class2.GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    str = (string) obj2.Properties[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xec18)].Value;
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMacAddress()
        {
            string str = string.Empty;
            using (ManagementClass class2 = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeb82)))
            {
                ManagementObjectCollection instances = class2.GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    if ((bool) obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xebc8)])
                    {
                        return obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xebde)].ToString();
                    }
                }
                return str;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSystemType()
        {
            string str = string.Empty;
            using (ManagementClass class2 = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xec26)))
            {
                ManagementObjectCollection instances = class2.GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    str = obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xec52)].ToString();
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTotalPhysicalMemory()
        {
            string str = string.Empty;
            using (ManagementClass class2 = new ManagementClass(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xec6a)))
            {
                ManagementObjectCollection instances = class2.GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    str = obj2[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xec96)].ToString();
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetUserName()
        {
            return Environment.UserName;
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
                byte[] buffer = new byte[0x20];
                byte[] buffer2 = new byte[0x138];
                byte[] buffer3 = new byte[0x2c];
                if (qCpqRb2bV(3, buffer, buffer.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (qCpqRb2bV(2, buffer2, buffer2.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (qCpqRb2bV(0, buffer3, buffer3.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                this.snJo0QVxt = BitConverter.ToInt64(buffer2, 0);
                this.nBCwVbEfB = BitConverter.ToInt64(buffer, 8);
                this.m7HRrMhfC = buffer3[40];
            }

            [DllImport("ntdll", EntryPoint="NtQuerySystemInformation")]
            private static extern int qCpqRb2bV(int, byte[], int, IntPtr);
            [MethodImpl(MethodImplOptions.NoInlining)]
            public override int Query()
            {
                byte[] buffer = new byte[0x20];
                byte[] buffer2 = new byte[0x138];
                if (qCpqRb2bV(3, buffer, buffer.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (qCpqRb2bV(2, buffer2, buffer2.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                double num = BitConverter.ToInt64(buffer2, 0) - this.snJo0QVxt;
                double num2 = BitConverter.ToInt64(buffer, 8) - this.nBCwVbEfB;
                if (!(num2 == 0.0))
                {
                    num /= num2;
                }
                num = (100.0 - ((num * 100.0) / this.m7HRrMhfC)) + 0.5;
                this.snJo0QVxt = BitConverter.ToInt64(buffer2, 0);
                this.nBCwVbEfB = BitConverter.ToInt64(buffer, 8);
                return (int) num;
            }
        }

        public abstract class CpuUsage
        {
            private static Computer.CpuUsage qCpqRb2bV = null;

            [MethodImpl(MethodImplOptions.NoInlining)]
            protected CpuUsage()
            {
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public static Computer.CpuUsage Create()
            {
                if (qCpqRb2bV == null)
                {
                    if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    {
                        if (Environment.OSVersion.Platform != PlatformID.Win32Windows)
                        {
                            throw new NotSupportedException();
                        }
                        qCpqRb2bV = new Computer.gjX3vAqlRwFkwyyDtUa();
                    }
                    else
                    {
                        qCpqRb2bV = new Computer.aC5CTBqbArLbDaaCFog();
                    }
                }
                return qCpqRb2bV;
            }

            public abstract int Query();
        }

        internal sealed class gjX3vAqlRwFkwyyDtUa : Computer.CpuUsage
        {
            private RegistryKey qCpqRb2bV;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public gjX3vAqlRwFkwyyDtUa()
            {
                try
                {
                    RegistryKey key = Registry.DynData.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xecc0), false);
                    if (key == null)
                    {
                        throw new NotSupportedException();
                    }
                    key.GetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xecea));
                    key.Close();
                    this.qCpqRb2bV = Registry.DynData.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xed0c), false);
                    if (this.qCpqRb2bV == null)
                    {
                        throw new NotSupportedException();
                    }
                }
                catch (NotSupportedException exception)
                {
                    throw exception;
                }
                catch (Exception exception2)
                {
                    throw new NotSupportedException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xed34), exception2);
                }
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            ~gjX3vAqlRwFkwyyDtUa()
            {
                try
                {
                    this.qCpqRb2bV.Close();
                }
                catch
                {
                }
                try
                {
                    RegistryKey key = Registry.DynData.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xee0e), false);
                    key.GetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xee36), false);
                    key.Close();
                }
                catch
                {
                }
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public override int Query()
            {
                int num;
                try
                {
                    num = (int) this.qCpqRb2bV.GetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xed90));
                }
                catch (Exception exception)
                {
                    throw new NotSupportedException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xedb2), exception);
                }
                return num;
            }
        }
    }
}

