namespace WHC.OrderWater.Commons.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, XmlRoot("dictionary")]
    public class Dictionary<TKey, TValue> : Dictionary<TKey, TValue>, ICloneable, ICloneable<Dictionary<TKey, TValue>>, IXmlSerializable
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IDictionary<TKey, TValue> dictionary)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IEqualityComparer<TKey> comparer)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(int capacity)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected Dictionary(SerializationInfo info, StreamingContext context)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary<TKey, TValue> Clone()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool Contains(TKey key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining), SecurityPermission(SecurityAction.LinkDemand, Flags=0x80)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public XmlSchema GetSchema()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ReadXml(XmlReader reader)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true)]
        public static Dictionary<TKey, TValue> Synchronized(Dictionary<TKey, TValue> dictionary)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        object ICloneable.Clone()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WriteXml(XmlWriter writer)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public virtual bool IsSynchronized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
