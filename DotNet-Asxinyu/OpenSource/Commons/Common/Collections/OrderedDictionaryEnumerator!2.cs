namespace WHC.OrderWater.Commons.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed class OrderedDictionaryEnumerator<TKey, TValue> : IEnumerator<TValue>, IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
    {
        private int 4bccOhnfl;
        private bool MEWIXKqxt;
        private List<KeyValuePair<TKey, TValue>> TEPULnwMP;

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal OrderedDictionaryEnumerator(List<KeyValuePair<TKey, TValue>> list)
        {
            this.MEWIXKqxt = false;
            this.4bccOhnfl = -1;
            this.TEPULnwMP = list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 01FqmBarm(bool flag1)
        {
            if (!this.MEWIXKqxt)
            {
                if (flag1)
                {
                    if (this.TEPULnwMP != null)
                    {
                        this.TEPULnwMP = null;
                    }
                    GC.SuppressFinalize(this);
                }
                this.MEWIXKqxt = true;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.01FqmBarm(true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private KeyValuePair<TKey, TValue> dT3f0t4t3()
        {
            if ((this.4bccOhnfl < 0) || (this.4bccOhnfl >= this.TEPULnwMP.Count))
            {
                throw new InvalidOperationException();
            }
            return this.TEPULnwMP[this.4bccOhnfl];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        ~OrderedDictionaryEnumerator()
        {
            this.01FqmBarm(false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveNext()
        {
            this.4bccOhnfl++;
            if (this.4bccOhnfl >= this.TEPULnwMP.Count)
            {
                return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Reset()
        {
            this.4bccOhnfl = -1;
        }

        public TValue Current
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3().Value;
            }
        }

        public TKey Key
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3().Key;
            }
        }

        KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3();
            }
        }

        object IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3().Value;
            }
        }

        public TValue Value
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.dT3f0t4t3().Value;
            }
        }
    }
}

