namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class EnumHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription(Type t, object v)
        {
            try
            {
                DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) t.GetField(qCpqRb2bV(t, v)).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return ((customAttributes.Length > 0) ? customAttributes[0].Description : qCpqRb2bV(t, v));
            }
            catch
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd448);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T GetInstance<T>(string member)
        {
            return ConvertHelper.ConvertTo<T>(Enum.Parse(typeof(T), member, true));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, object> GetMemberKeyValue<T>()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string[] memberNames = GetMemberNames<T>();
            foreach (string str in memberNames)
            {
                dictionary.Add(str, GetMemberValue<T>(str));
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMemberName<T>(object member)
        {
            Type underlyingType = GetUnderlyingType(typeof(T));
            object obj2 = ConvertHelper.ConvertTo(member, underlyingType);
            return Enum.GetName(typeof(T), obj2);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetMemberNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetMemberValue<T>(string memberName)
        {
            Type underlyingType = GetUnderlyingType(typeof(T));
            return ConvertHelper.ConvertTo(GetInstance<T>(memberName), underlyingType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Array GetMemberValues<T>()
        {
            return Enum.GetValues(typeof(T));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static SortedList GetStatus(Type t)
        {
            SortedList list = new SortedList();
            Array values = Enum.GetValues(t);
            for (int i = 0; i < values.Length; i++)
            {
                string str = values.GetValue(i).ToString();
                int v = (int) Enum.Parse(t, str);
                string description = GetDescription(t, v);
                list.Add(v, description);
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Type GetUnderlyingType(Type enumType)
        {
            return Enum.GetUnderlyingType(enumType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDefined<T>(string member)
        {
            return Enum.IsDefined(typeof(T), member);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string qCpqRb2bV(Type type1, object obj1)
        {
            try
            {
                return Enum.GetName(type1, obj1);
            }
            catch
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd45a);
            }
        }
    }
}

