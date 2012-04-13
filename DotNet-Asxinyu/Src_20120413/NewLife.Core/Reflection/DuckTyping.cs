using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NewLife.Collections;

namespace NewLife.Reflection
{
    /// <summary>Ѽ�����͡����ڽ����д���ʱ����ʵ�ֲ���ӿڵ����⡣ʹ��������ģʽ����̬���ɴ����ࡣ</summary>
    static class DuckTyping
    {
        static DictionaryCache<KeyValuePair<Type, Type>, Type> _cache = new DictionaryCache<KeyValuePair<Type, Type>, Type>();
        static CodeDomDuckTypeGenerator _generator = new CodeDomDuckTypeGenerator();

        /// <summary>ת���������</summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static TInterface[] Implement<TInterface>(params object[] objects)
        {
            if (objects == null) throw new ArgumentNullException("objects");

            Type interfaceType = typeof(TInterface);
            ValidateInterfaceType(interfaceType);

            Type[] duckedTypes = new Type[objects.Length];
            for (int i = 0; i < objects.Length; i++)
                duckedTypes[i] = objects[i].GetType();

            Type[] duckTypes = GetDuckTypes(interfaceType, duckedTypes);

            TInterface[] ducks = new TInterface[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                //ducks[i] = (TInterface)Activator.CreateInstance(duckTypes[i], objects[i]);
                ducks[i] = (TInterface)TypeX.CreateInstance(duckTypes[i], objects[i]);
            }

            return ducks;
        }

        /// <summary>ת����������</summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TInterface Implement<TInterface>(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            return (TInterface)Implement(obj, typeof(TInterface));

            //Type interfaceType = typeof(TInterface);
            //Type duckedType = obj.GetType();

            //ValidateInterfaceType(interfaceType);

            //Type duckType = GetDuckType(interfaceType, duckedType);

            //TInterface duck = (TInterface)Activator.CreateInstance(duckType, obj);
            //return duck;
        }

        /// <summary>ת����������</summary>
        /// <param name="obj"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static Object Implement(Object obj, Type interfaceType)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            //Type duckedType = obj.GetType();

            ValidateInterfaceType(interfaceType);

            Type duckType = GetDuckType(interfaceType, obj.GetType());

            //return Activator.CreateInstance(duckType, obj);
            return TypeX.CreateInstance(duckType, obj);
        }

        /// <summary>׼��Ѽ������</summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="duckedTypes"></param>
        public static void PrepareDuckTypes<TInterface>(params Type[] duckedTypes)
        {
            if (duckedTypes == null) throw new ArgumentNullException("types");

            Type interfaceType = typeof(TInterface);
            ValidateInterfaceType(interfaceType);

            GetDuckTypes(interfaceType, duckedTypes);
        }

        static Type GetDuckType(Type interfaceType, Type duckedType)
        {
            return _cache.GetItem(new KeyValuePair<Type, Type>(interfaceType, duckedType), key => CreateDuckTypes(key.Key, new Type[] { key.Value })[0]);
            //return GetDuckTypes(interfaceType, new Type[] { duckedType })[0];

            //KeyValuePair<Type, Type> key = new KeyValuePair<Type, Type>(interfaceType, duckedType);
            //Type type = null;
            //if (_cache.TryGetValue(key, out type)) return type;
            //lock (_cache)
            //{
            //    if (_cache.TryGetValue(key, out type)) return type;

            //    type = CreateDuckTypes(interfaceType, new Type[] { duckedType })[0];
            //    _cache.Add(key, type);

            //    return type;
            //}
        }

        static Type[] GetDuckTypes(Type interfaceType, Type[] duckedTypes)
        {
            if (duckedTypes.Length == 1) return new Type[] { GetDuckType(interfaceType, duckedTypes[0]) };

            lock (_cache)
            {
                // �ҵ�����δ����������
                List<Type> list = new List<Type>();
                for (int i = 0; i < duckedTypes.Length; i++)
                {
                    Type duckedType = duckedTypes[i];

                    if (!_cache.ContainsKey(new KeyValuePair<Type, Type>(interfaceType, duckedType)) && !list.Contains(duckedType))
                    {
                        list.Add(duckedType);
                    }
                }

                // ͳһ����
                if (list.Count > 0)
                {
                    Type[] dts = CreateDuckTypes(interfaceType, list.ToArray());
                    for (int i = 0; i < dts.Length; i++)
                    {
                        _cache.Add(new KeyValuePair<Type, Type>(interfaceType, list[i]), dts[i]);
                    }
                }
            }

            // ����ȫ�����л����ˣ�����ֱ����
            Type[] duckTypes = new Type[duckedTypes.Length];
            for (int i = 0; i < duckedTypes.Length; i++)
            {
                duckTypes[i] = GetDuckType(interfaceType, duckedTypes[i]);
            }

            return duckTypes;
        }

        /// <summary>Core-Creation of the DuckTypes. It asumes that all arguments are validated before the method is called.</summary>
        /// <param name="interfaceType"></param>
        /// <param name="duckedTypes">a distinct list of Types to create the Duck-Types</param>
        /// <returns></returns>
        static Type[] CreateDuckTypes(Type interfaceType, Type[] duckedTypes)
        {
            return _generator.CreateDuckTypes(interfaceType, duckedTypes);
        }

        static void ValidateInterfaceType(Type interfaceType)
        {
            if (!interfaceType.IsInterface) throw new InvalidDataException("T have to be an Interface - Type!");
            //if (!interfaceType.IsPublic) throw new Exception("The Interface has to be public if you want to create a Duck - Type!");
        }
    }
}