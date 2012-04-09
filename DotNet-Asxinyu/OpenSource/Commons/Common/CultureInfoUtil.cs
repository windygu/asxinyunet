namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class CultureInfoUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void InitializeCulture()
        {
            string str = LoadLanguage();
            if (!string.IsNullOrEmpty(str))
            {
                CultureInfo info = new CultureInfo(str);
                Thread.CurrentThread.CurrentCulture = info;
                Thread.CurrentThread.CurrentUICulture = info;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string LoadLanguage()
        {
            string str = RegistryHelper.GetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb764));
            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (Thread.CurrentThread.CurrentCulture.Name.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb778), StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb780);
            }
            return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb78e);
        }

        public static RegionInfo CurrentRegion
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return RegionInfo.CurrentRegion;
            }
        }
    }
}

