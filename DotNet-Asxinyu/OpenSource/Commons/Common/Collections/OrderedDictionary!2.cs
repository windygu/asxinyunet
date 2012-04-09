namespace WHC.OrderWater.Commons.Collections
{
    using 1YyIjYqRnHRBNetelZO;
    using m5TdGJjRN17735qK1v;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class OrderedDictionary<TKey, TValue> : ICloneable, ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, ICloneable<OrderedDictionary<TKey, TValue>>, IEnumerable, IEnumerable<TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<KeyValuePair<TKey, TValue>> lWvfFeZUE;
        private Dictionary<TKey, TValue> mi5qIK3te;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary()
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>();
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>(dictionary);
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary(IEqualityComparer<TKey> comparer)
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>(comparer);
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary(int capacity)
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>(capacity);
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>(dictionary, comparer);
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            this.mi5qIK3te = new Dictionary<TKey, TValue>(capacity, comparer);
            this.lWvfFeZUE = new List<KeyValuePair<TKey, TValue>>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void Add(TKey key, TValue value)
        {
            this.mi5qIK3te.Add(key, value);
            this.lWvfFeZUE.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void Clear()
        {
            this.mi5qIK3te.Clear();
            this.lWvfFeZUE.Clear();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OrderedDictionary<TKey, TValue> Clone()
        {
            return new OrderedDictionary<TKey, TValue>(this);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool Contains(TKey key)
        {
            return this.ContainsKey(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool ContainsKey(TKey key)
        {
            return this.mi5qIK3te.ContainsKey(key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool ContainsValue(TValue value)
        {
            return this.mi5qIK3te.ContainsValue(value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this.mi5qIK3te.CopyTo(array, arrayIndex);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual OrderedDictionaryEnumerator<TKey, TValue> GetEnumerator()
        {
            return new OrderedDictionaryEnumerator<TKey, TValue>(this.lWvfFeZUE);
        }

        [MethodImpl(MethodImplOptions.NoInlining), SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.mi5qIK3te.GetObjectData(info, context);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int IndexOf(TKey key)
        {
            for (int i = 0; i < this.lWvfFeZUE.Count; i++)
            {
                KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[i];
                if (pair.Key.Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int IndexOf(TValue value)
        {
            for (int i = 0; i < this.lWvfFeZUE.Count; i++)
            {
                KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[i];
                if (pair.Value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Insert(int index, TKey key, TValue value)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x62b2));
            }
            this.mi5qIK3te.Add(key, value);
            this.lWvfFeZUE.Insert(index, new KeyValuePair<TKey, TValue>(key, value));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void OnDeserialization(object sender)
        {
            this.mi5qIK3te.OnDeserialization(sender);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool Remove(TKey key)
        {
            bool flag = this.mi5qIK3te.Remove(key);
            this.lWvfFeZUE.RemoveAt(this.IndexOf(key));
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x62c0));
            }
            KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[index];
            this.mi5qIK3te.Remove(pair.Key);
            this.lWvfFeZUE.RemoveAt(index);
        }

        [MethodImpl(MethodImplOptions.NoInlining), HostProtection(SecurityAction.LinkDemand, Synchronization=true)]
        public static OrderedDictionary<TKey, TValue> Synchronized(OrderedDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x62ea));
            }
            return new EOp8G6IROnGsmPRfkA<TKey, TValue>(dictionary);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            this.Add(keyValuePair.Key, keyValuePair.Value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            if (this.ContainsKey(item.Key))
            {
                TValue local = this[item.Key];
                if (local.Equals(item.Value))
                {
                    return true;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (this.ContainsKey(item.Key))
            {
                TValue local = this[item.Key];
                if (local.Equals(item.Value))
                {
                    return this.mi5qIK3te.Remove(item.Key);
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return new OrderedDictionaryEnumerator<TKey, TValue>(this.lWvfFeZUE);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return new OrderedDictionaryEnumerator<TKey, TValue>(this.lWvfFeZUE);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new OrderedDictionaryEnumerator<TKey, TValue>(this.lWvfFeZUE);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            return this.mi5qIK3te.TryGetValue(key, out value);
        }

        public virtual IEqualityComparer<TKey> Comparer
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.mi5qIK3te.Comparer;
            }
        }

        public virtual int Count
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.lWvfFeZUE.Count;
            }
        }

        public virtual bool IsSynchronized
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.mi5qIK3te.IsSynchronized;
            }
        }

        public virtual TValue this[int index]
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if ((index < 0) || (index >= this.Count))
                {
                    throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x62ce));
                }
                KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[index];
                return pair.Value;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if ((index < 0) || (index >= this.Count))
                {
                    throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x62dc));
                }
                KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[index];
                TKey key = pair.Key;
                if (this.mi5qIK3te.ContainsKey(key))
                {
                    this.mi5qIK3te[key] = value;
                    this.lWvfFeZUE[index] = new KeyValuePair<TKey, TValue>(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public virtual TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (this.mi5qIK3te.ContainsKey(key))
                {
                    return this.mi5qIK3te[key];
                }
                return default(TValue);
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.mi5qIK3te.ContainsKey(key))
                {
                    this.mi5qIK3te[key] = value;
                    this.lWvfFeZUE[this.IndexOf(key)] = new KeyValuePair<TKey, TValue>(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public virtual ICollection<TKey> Keys
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                List<TKey> list = new List<TKey>();
                for (int i = 0; i < this.lWvfFeZUE.Count; i++)
                {
                    KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[i];
                    list.Add(pair.Key);
                }
                return list;
            }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return false;
            }
        }

        public virtual ICollection<TValue> Values
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                List<TValue> list = new List<TValue>();
                for (int i = 0; i < this.lWvfFeZUE.Count; i++)
                {
                    KeyValuePair<TKey, TValue> pair = this.lWvfFeZUE[i];
                    list.Add(pair.Value);
                }
                return (ICollection<TValue>) list;
            }
        }
    }
}

