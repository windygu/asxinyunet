namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class IDCardHelper
    {
        private static DataTable 01FqmBarm = new DataTable();
        private static string[] dT3f0t4t3 = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9592), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9598), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x959e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95a4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95aa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95b0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95b6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95bc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95c2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95c8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95ce) };
        private static int[] yTHMJ858G = new int[] { 
            7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 
            2, 1
         };

        [MethodImpl(MethodImplOptions.NoInlining)]
        static IDCardHelper()
        {
            01FqmBarm.Columns.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95d4));
            01FqmBarm.Columns.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95e0));
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95ee), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x95fc) });
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9602), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x960c) });
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9612), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x961c) });
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9622), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9632) });
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9638), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x964c) });
            01FqmBarm.Rows.Add(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9652), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9666) });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable CreateIDType()
        {
            return 01FqmBarm;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetArea(string id)
        {
            return id.Substring(0, 6);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetBirthday(string id)
        {
            string str = string.Empty;
            if (id.Length == 15)
            {
                str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9770) + id.Substring(6, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9778) + id.Substring(8, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x977e) + id.Substring(10, 2);
            }
            else
            {
                if (id.Length != 0x12)
                {
                    throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9790));
                }
                str = id.Substring(6, 4) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9784) + id.Substring(10, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x978a) + id.Substring(12, 2);
            }
            return Convert.ToDateTime(str);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCity(string id)
        {
            return (id.Substring(0, 4) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x973a));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetProvince(string id)
        {
            return (id.Substring(0, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x972e));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSexName(string id)
        {
            int num = 0;
            if (id.Length == 15)
            {
                num = Convert.ToInt32(id.Substring(14, 1));
            }
            else
            {
                if (id.Length != 0x12)
                {
                    throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9742));
                }
                num = Convert.ToInt32(id.Substring(0x10, 1));
            }
            return (((num % 2) == 0) ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x976a) : kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9764));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string IdCard15To18(string idcard)
        {
            if ((idcard == null) || (idcard.Length != 15))
            {
                return idcard;
            }
            string str = string.Empty;
            int index = 0;
            int num2 = 0;
            str = idcard.Substring(0, 6) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9726) + idcard.Substring(6, 9);
            for (int i = 0; i < 0x11; i++)
            {
                num2 = int.Parse(str.Substring(i, 1));
                index += num2 * yTHMJ858G[i];
            }
            index = index % 11;
            return (str + dT3f0t4t3[index]);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void InitIdType(ComboBox cb)
        {
            cb.DataSource = 01FqmBarm;
            cb.DisplayMember = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x966c);
            cb.ValueMember = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9678);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Validate(string idcard)
        {
            if ((idcard.Length != 0x12) && (idcard.Length != 15))
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9686);
            }
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x96ac));
            if (!regex.Match(idcard).Success)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x96cc);
            }
            if (idcard.Length == 15)
            {
                idcard = IdCard15To18(idcard);
            }
            else if (idcard.Length == 0x12)
            {
                int index = 0;
                int num2 = 0;
                for (int i = 0; i < 0x11; i++)
                {
                    num2 = int.Parse(idcard.Substring(i, 1));
                    index += num2 * yTHMJ858G[i];
                }
                index = index % 11;
                if (idcard.Substring(0x11, 1) != dT3f0t4t3[index])
                {
                    return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x96ec) + dT3f0t4t3[index] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9708));
                }
            }
            try
            {
                DateTime.Parse(idcard.Substring(6, 4) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x970e) + idcard.Substring(10, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9714) + idcard.Substring(12, 2));
            }
            catch
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x971a);
            }
            return string.Empty;
        }
    }
}

