namespace WHC.OrderWater.Commons.Collections
{
    using 1YyIjYqRnHRBNetelZO;
    using F6auBo1j9sfu8vABEf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Xml.Serialization;

    [Serializable, XmlRoot("list")]
    public class List<T> : List<T>, ICloneable, ICloneable<List<T>>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public List()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public List(IEnumerable<T> collection) : base(collection)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public List(int capacity) : base(capacity)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public List<T> Clone()
        {
            return new List<T>(this);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<V> Repeat<V>(V value, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x573c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x574a));
            }
            List<V> list = new List<V>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(value);
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true)]
        public static List<V> Synchronized<V>(List<V> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5730));
            }
            return new heSmNE0Ws0RgeDr4yE<V>(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public virtual bool IsSynchronized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return false;
            }
        }
    }
}

