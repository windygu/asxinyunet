namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class ThreadSafeObjectProvider<T> : DisposableObject where T: class
    {
        private bool EPgfA8o8U;
        private T XxQqQ66mW;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ThreadSafeObjectProvider() : this(false)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ThreadSafeObjectProvider(bool nonPublic)
        {
            this.EPgfA8o8U = nonPublic;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateInstance(params object[] args)
        {
            if (this.XxQqQ66mW == null)
            {
                this.XxQqQ66mW = (T) Activator.CreateInstance(typeof(T), args);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateInstance(bool nonPublic)
        {
            if ((this.XxQqQ66mW == null) && nonPublic)
            {
                this.XxQqQ66mW = (T) Activator.CreateInstance(typeof(T), nonPublic);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateInstance(BindingFlags bindingAttr)
        {
            if (this.XxQqQ66mW == null)
            {
                this.XxQqQ66mW = (T) Activator.CreateInstance(typeof(T), bindingAttr, null, null, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateInstance(BindingFlags bindingAttr, params object[] args)
        {
            if (this.XxQqQ66mW == null)
            {
                this.XxQqQ66mW = (T) Activator.CreateInstance(typeof(T), bindingAttr, null, args, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void DisposeManagedResources()
        {
            this.XxQqQ66mW = default(T);
            base.DisposeManagedResources();
        }

        public bool Created
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.XxQqQ66mW != null);
            }
        }

        public T Instance
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (this.XxQqQ66mW == null)
                {
                    if (this.EPgfA8o8U)
                    {
                        this.CreateInstance(true);
                    }
                    else
                    {
                        this.XxQqQ66mW = Activator.CreateInstance<T>();
                    }
                }
                return this.XxQqQ66mW;
            }
        }
    }
}

