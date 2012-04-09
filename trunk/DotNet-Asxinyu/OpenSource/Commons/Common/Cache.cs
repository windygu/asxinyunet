namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class Cache
    {
        private static volatile Cache lWvfFeZUE = null;
        private SortedDictionary<string, object> mi5qIK3te = new SortedDictionary<string, object>();
        private static object OBHMaLtRG = new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private Cache()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Add(string key, object value)
        {
            this.mi5qIK3te.Add(key, value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Remove(string key)
        {
            this.mi5qIK3te.Remove(key);
        }

        public static Cache Instance
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (lWvfFeZUE == null)
                {
                    lock (OBHMaLtRG)
                    {
                        if (lWvfFeZUE == null)
                        {
                            lWvfFeZUE = new Cache();
                        }
                    }
                }
                return lWvfFeZUE;
            }
        }

        public object this[string index]
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (this.mi5qIK3te.ContainsKey(index))
                {
                    return this.mi5qIK3te[index];
                }
                return null;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.mi5qIK3te[index] = value;
            }
        }
    }
}

