namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public class PagerHelper
    {
        private int 9vUWP8ynB;
        private string fcNUBE6Y4;
        private bool Fu3HlvBwR;
        private string PD3B8iBEN;
        private string T4DKb6wAk;
        private int WgtPdL4t3;
        private string YFqw2yc0N;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public PagerHelper()
        {
            this.T4DKb6wAk = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x632c);
            this.YFqw2yc0N = string.Empty;
            this.WgtPdL4t3 = 10;
            this.9vUWP8ynB = 1;
            this.Fu3HlvBwR = false;
            this.PD3B8iBEN = string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public PagerHelper(string tableName, string fieldsToReturn, string fieldNameToSort, int pageSize, int pageIndex, bool isDescending, string strwhere)
        {
            this.T4DKb6wAk = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6332);
            this.YFqw2yc0N = string.Empty;
            this.WgtPdL4t3 = 10;
            this.9vUWP8ynB = 1;
            this.Fu3HlvBwR = false;
            this.PD3B8iBEN = string.Empty;
            this.fcNUBE6Y4 = tableName;
            this.T4DKb6wAk = fieldsToReturn;
            this.YFqw2yc0N = fieldNameToSort;
            this.WgtPdL4t3 = pageSize;
            this.9vUWP8ynB = pageIndex;
            this.Fu3HlvBwR = isDescending;
            this.PD3B8iBEN = strwhere;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetPagingSql(DatabaseType dbType, bool isDoCount)
        {
            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    return this.lWvfFeZUE(isDoCount);

                case DatabaseType.Oracle:
                    return this.mi5qIK3te(isDoCount);

                case DatabaseType.Access:
                    return this.OBHMaLtRG(isDoCount);

                case DatabaseType.MySql:
                    return this.jSdinGKD3(isDoCount);
            }
            return "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string jSdinGKD3(bool flag1)
        {
            if (string.IsNullOrEmpty(this.PD3B8iBEN))
            {
                this.PD3B8iBEN = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x679a);
            }
            if (flag1)
            {
                return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x67ac), this.fcNUBE6Y4, this.PD3B8iBEN);
            }
            string str2 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x680c), this.YFqw2yc0N, this.Fu3HlvBwR ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x683c) : kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6832));
            int num = this.WgtPdL4t3 * (this.9vUWP8ynB - 1);
            int num2 = this.WgtPdL4t3 * this.9vUWP8ynB;
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6848), new object[] { this.T4DKb6wAk, this.fcNUBE6Y4, this.PD3B8iBEN, str2, num2, num });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string lWvfFeZUE(bool flag1)
        {
            string str = "";
            if (string.IsNullOrEmpty(this.PD3B8iBEN))
            {
                this.PD3B8iBEN = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6572);
            }
            if (flag1)
            {
                return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6584), this.fcNUBE6Y4, this.PD3B8iBEN);
            }
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.Fu3HlvBwR)
            {
                str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x65e4);
                str3 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6600), this.YFqw2yc0N);
            }
            else
            {
                str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x662c);
                str3 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6648), this.YFqw2yc0N);
            }
            str = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6672), this.WgtPdL4t3, this.T4DKb6wAk, this.fcNUBE6Y4);
            if (this.9vUWP8ynB == 1)
            {
                return (str + string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x66b2), this.PD3B8iBEN) + str3);
            }
            return (str + string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x66cc), new object[] { this.YFqw2yc0N, str2, (this.9vUWP8ynB - 1) * this.WgtPdL4t3, this.fcNUBE6Y4, str3, this.PD3B8iBEN }));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string mi5qIK3te(bool flag1)
        {
            if (string.IsNullOrEmpty(this.PD3B8iBEN))
            {
                this.PD3B8iBEN = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6338);
            }
            if (flag1)
            {
                return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x634a), this.fcNUBE6Y4, this.PD3B8iBEN);
            }
            string str2 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x63a6), this.YFqw2yc0N, this.Fu3HlvBwR ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x63d6) : kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x63cc));
            int num = this.WgtPdL4t3 * (this.9vUWP8ynB - 1);
            int num2 = this.WgtPdL4t3 * this.9vUWP8ynB;
            string str3 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x63e2), new object[] { this.T4DKb6wAk, this.fcNUBE6Y4, this.PD3B8iBEN, str2 });
            return string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6428), num, num2, str3);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string OBHMaLtRG(bool flag1)
        {
            return this.lWvfFeZUE(flag1);
        }

        public string FieldNameToSort
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.YFqw2yc0N;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.YFqw2yc0N = value;
            }
        }

        public string FieldsToReturn
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.T4DKb6wAk;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.T4DKb6wAk = value;
            }
        }

        public bool IsDescending
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Fu3HlvBwR;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.Fu3HlvBwR = value;
            }
        }

        public int PageIndex
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.9vUWP8ynB;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.9vUWP8ynB = value;
            }
        }

        public int PageSize
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.WgtPdL4t3;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.WgtPdL4t3 = value;
            }
        }

        public string StrWhere
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.PD3B8iBEN;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.PD3B8iBEN = value;
            }
        }

        public string TableName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.fcNUBE6Y4;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.fcNUBE6Y4 = value;
            }
        }
    }
}

