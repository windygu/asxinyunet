namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class Reflect<T> where T: class
    {
        private static Hashtable PZaqo38KQ;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Reflect()
        {
            Reflect<T>.PZaqo38KQ = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T Create(string sName, string sFilePath)
        {
            return Reflect<T>.Create(sName, sFilePath, true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T Create(string sName, string sFilePath, bool bCache)
        {
            string key = sFilePath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0) + sName;
            T local = default(T);
            if (bCache)
            {
                local = (T) Reflect<T>.ObjCache[key];
                if (!Reflect<T>.ObjCache.ContainsKey(key))
                {
                    local = (T) Reflect<T>.CreateAssembly(sFilePath).CreateInstance(key);
                    Reflect<T>.ObjCache.Add(key, local);
                }
                return local;
            }
            return (T) Reflect<T>.CreateAssembly(sFilePath).CreateInstance(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly CreateAssembly(string sFilePath)
        {
            Assembly assembly = (Assembly) Reflect<T>.ObjCache[sFilePath];
            if (assembly == null)
            {
                assembly = Assembly.Load(sFilePath);
                if (!Reflect<T>.ObjCache.ContainsKey(sFilePath))
                {
                    Reflect<T>.ObjCache.Add(sFilePath, assembly);
                }
            }
            return assembly;
        }

        public static Hashtable ObjCache
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (Reflect<T>.PZaqo38KQ == null)
                {
                    Reflect<T>.PZaqo38KQ = new Hashtable();
                }
                return Reflect<T>.PZaqo38KQ;
            }
        }
    }
}

