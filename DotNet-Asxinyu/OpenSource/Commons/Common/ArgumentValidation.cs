namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class ArgumentValidation
    {
        private const string 3xodQsKC6 = "无效的类型，期待的类型必须为'{0}'。";
        private const string eMSUYugy4 = "{0}不是{1}的一个有效值";
        private const string EPgfA8o8U = "参数'{0}'的名称不能为空引用或空字符串。";
        private const string hudMECjTG = "数值必须大于0字节.";
        private const string XxQqQ66mW = "参数 '{0}'的值不能为空字符串。";

        [MethodImpl(MethodImplOptions.NoInlining)]
        private ArgumentValidation()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckEnumeration(Type enumType, object variable, string variableName)
        {
            CheckForNullReference(variable, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd078));
            CheckForNullReference(enumType, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd08c));
            CheckForNullReference(variableName, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd0a0));
            if (!Enum.IsDefined(enumType, variable))
            {
                throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd0bc), variable.ToString(), enumType.FullName, variableName));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckExpectedType(object variable, Type type)
        {
            CheckForNullReference(variable, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd02c));
            CheckForNullReference(type, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd040));
            if (!type.IsAssignableFrom(variable.GetType()))
            {
                throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd04c), type.FullName));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckForEmptyString(string variable, string variableName)
        {
            CheckForNullReference(variable, variableName);
            CheckForNullReference(variableName, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf5a));
            if (variable.Length == 0)
            {
                throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf76), variableName));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckForInvalidNullNameReference(string name, string messageName)
        {
            if ((name == null) || (name.Length == 0))
            {
                throw new InvalidOperationException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcfba), messageName));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckForNullReference(object variable, string variableName)
        {
            if (variableName == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf9e));
            }
            if (null == variable)
            {
                throw new ArgumentNullException(variableName);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CheckForZeroBytes(byte[] bytes, string variableName)
        {
            CheckForNullReference(bytes, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcfea));
            CheckForNullReference(variableName, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcff8));
            if (bytes.Length == 0)
            {
                throw new ArgumentException(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd014), variableName));
            }
        }
    }
}

