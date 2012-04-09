namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DatabaseInfo
    {
        private string 4bccOhnfl;
        private string MEWIXKqxt;
        private string TEPULnwMP;
        private string yTHMJ858G;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DatabaseInfo()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DatabaseInfo(string connectionString)
        {
            this.yTHMJ858G = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x87c6));
            if (this.yTHMJ858G == null)
            {
                this.yTHMJ858G = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x87d2));
            }
            if (this.yTHMJ858G == null)
            {
                this.yTHMJ858G = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x87ec));
            }
            this.4bccOhnfl = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x87fc));
            if (this.4bccOhnfl == null)
            {
                this.4bccOhnfl = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x880a));
            }
            if (this.4bccOhnfl == null)
            {
                this.4bccOhnfl = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x882c));
            }
            this.TEPULnwMP = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8840));
            if (this.TEPULnwMP == null)
            {
                this.TEPULnwMP = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x884c));
            }
            if (this.TEPULnwMP == null)
            {
                this.TEPULnwMP = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x885e));
            }
            this.MEWIXKqxt = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8868));
            if (this.MEWIXKqxt == null)
            {
                this.MEWIXKqxt = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8874));
            }
            if (this.MEWIXKqxt == null)
            {
                this.MEWIXKqxt = this.01FqmBarm(connectionString, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8888));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string 01FqmBarm(string text1, string text2)
        {
            string[] strArray = text1.Split(new char[] { ';' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].ToLower().IndexOf(text2.ToLower()) >= 0)
                {
                    int index = strArray[i].IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8b26));
                    return strArray[i].Substring(index + 1);
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string dT3f0t4t3(string text1)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text1);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        public string ConnectionString
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (!(string.IsNullOrEmpty(this.UserId) || string.IsNullOrEmpty(this.Password)))
                {
                    return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8892), new object[] { this.yTHMJ858G, this.4bccOhnfl, this.TEPULnwMP, this.MEWIXKqxt });
                }
                return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x89c6), this.yTHMJ858G, this.4bccOhnfl);
            }
        }

        public string Database
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.4bccOhnfl;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.4bccOhnfl = value;
            }
        }

        public string EncryptConnectionString
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3(this.ConnectionString);
            }
        }

        public string OleDbConnectionString
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8afa) + this.ConnectionString);
            }
        }

        public string Password
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.MEWIXKqxt;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.MEWIXKqxt = value;
            }
        }

        public string Server
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.yTHMJ858G;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.yTHMJ858G = value;
            }
        }

        public string UserId
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.TEPULnwMP;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.TEPULnwMP = value;
            }
        }
    }
}

