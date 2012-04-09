namespace WHC.OrderWater.Commons.Collections
{
    using 1YyIjYqRnHRBNetelZO;
    using BufskHL2WXUCwdvSYw;
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
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(int capacity) : base(capacity)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected Dictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Dictionary<TKey, TValue> Clone()
        {
            return new Dictionary<TKey, TValue>(this);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool Contains(TKey key)
        {
            return base.ContainsKey(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            this.CopyTo(array, index);
        }

        [MethodImpl(MethodImplOptions.NoInlining), SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public XmlSchema GetSchema()
        {
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ReadXml(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TKey));
            XmlSerializer serializer2 = new XmlSerializer(typeof(TValue));
            bool isEmptyElement = reader.IsEmptyElement;
            reader.Read();
            if (!isEmptyElement)
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61cc));
                    reader.ReadStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61d8));
                    TKey key = (TKey) serializer.Deserialize(reader);
                    reader.ReadEndElement();
                    reader.ReadStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61e2));
                    TValue local2 = (TValue) serializer2.Deserialize(reader);
                    reader.ReadEndElement();
                    base.Add(key, local2);
                    reader.ReadEndElement();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true)]
        public static Dictionary<TKey, TValue> Synchronized(Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61b4));
            }
            return new Qyoc7xGq7hYlIhNlM3<TKey, TValue>(dictionary);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TKey));
            XmlSerializer serializer2 = new XmlSerializer(typeof(TValue));
            foreach (TKey local in base.Keys)
            {
                writer.WriteStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61f0));
                writer.WriteStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x61fc));
                serializer.Serialize(writer, local);
                writer.WriteEndElement();
                writer.WriteStartElement(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6206));
                TValue o = base[local];
                serializer2.Serialize(writer, o);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
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

