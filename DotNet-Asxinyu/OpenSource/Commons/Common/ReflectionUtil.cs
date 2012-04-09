namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Text;

    public sealed class ReflectionUtil
    {
        public static BindingFlags bf = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private ReflectionUtil()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstance(string type)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (assemblies[i].GetType(type) != null)
                {
                    return assemblies[i].CreateInstance(type);
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstance(Type type)
        {
            return CreateInstance(type.FullName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetAttribute(Type attributeType, Assembly assembly)
        {
            if (attributeType == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x68c8));
            }
            if (assembly == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x68e6));
            }
            if (assembly.IsDefined(attributeType, false))
            {
                return assembly.GetCustomAttributes(attributeType, false)[0];
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetAttribute(Type attributeType, MemberInfo type)
        {
            return GetAttribute(attributeType, type, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetAttribute(Type attributeType, MemberInfo type, bool searchParent)
        {
            if (attributeType != null)
            {
                if (type == null)
                {
                    return null;
                }
                if (!attributeType.IsSubclassOf(typeof(Attribute)))
                {
                    return null;
                }
                if (type.IsDefined(attributeType, searchParent))
                {
                    object[] customAttributes = type.GetCustomAttributes(attributeType, searchParent);
                    if (customAttributes.Length > 0)
                    {
                        return customAttributes[0];
                    }
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] GetAttributes(Type attributeType, MemberInfo type)
        {
            return GetAttributes(attributeType, type, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] GetAttributes(Type attributeType, MemberInfo type, bool searchParent)
        {
            if (type != null)
            {
                if (attributeType == null)
                {
                    return null;
                }
                if (!attributeType.IsSubclassOf(typeof(Attribute)))
                {
                    return null;
                }
                if (type.IsDefined(attributeType, false))
                {
                    return type.GetCustomAttributes(attributeType, searchParent);
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription(Enum value)
        {
            return GetDescription(value, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription(MemberInfo member)
        {
            return GetDescription(member, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription(Enum value, params object[] args)
        {
            if (value == 0)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x68aa));
            }
            DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            string format = (customAttributes.Length > 0) ? customAttributes[0].Description : value.ToString();
            if ((args != null) && (args.Length > 0))
            {
                return string.Format(null, format, args);
            }
            return format;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription(MemberInfo member, params object[] args)
        {
            string description;
            if (member == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x68b8));
            }
            if (member.IsDefined(typeof(DescriptionAttribute), false))
            {
                DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = customAttributes[0].Description;
            }
            else
            {
                return string.Empty;
            }
            if ((args != null) && (args.Length > 0))
            {
                return string.Format(null, description, args);
            }
            return description;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetField(object obj, string name)
        {
            return obj.GetType().GetField(name, bf).GetValue(obj);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FieldInfo[] GetFields(object obj)
        {
            return obj.GetType().GetFields(bf);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream GetImageResource(string ResourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetManifestString(Type assemblyType, string charset, string ResName)
        {
            Stream manifestResourceStream = Assembly.GetAssembly(assemblyType).GetManifestResourceStream(assemblyType.Namespace + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x68fa) + ResName.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6900), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6906)));
            if (manifestResourceStream == null)
            {
                return "";
            }
            int length = (int) manifestResourceStream.Length;
            byte[] buffer = new byte[length];
            manifestResourceStream.Read(buffer, 0, length);
            return ((buffer != null) ? Encoding.GetEncoding(charset).GetString(buffer) : "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties(bf);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetProperty(object obj, string name)
        {
            return obj.GetType().GetProperty(name, bf).GetValue(obj, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetStringRes(Type assemblyType, string resName, string resourceHolder)
        {
            Assembly assembly = Assembly.GetAssembly(assemblyType);
            ResourceManager manager = new ResourceManager(resourceHolder, assembly);
            return manager.GetString(resName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object InvokeMethod(object obj, string methodName, object[] args)
        {
            return obj.GetType().InvokeMember(methodName, bf | BindingFlags.InvokeMethod, null, obj, args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap LoadBitmap(Type assemblyType, string resourceHolder, string imageName)
        {
            Assembly assembly = Assembly.GetAssembly(assemblyType);
            ResourceManager manager = new ResourceManager(resourceHolder, assembly);
            return (Bitmap) manager.GetObject(imageName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetField(object obj, string name, object value)
        {
            obj.GetType().GetField(name, bf).SetValue(obj, value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetProperty(object obj, string name, object value)
        {
            PropertyInfo property = obj.GetType().GetProperty(name, bf);
            value = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(obj, value, null);
        }
    }
}

