namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class DisposableObject : IDisposable
    {
        private DisposeState mUvqAX6rk = DisposeState.None;

        public event EventHandler Disposed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected DisposableObject()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void CheckDisposed()
        {
            if (this.mUvqAX6rk == DisposeState.Disposed)
            {
                throw new ObjectDisposedException(base.GetType().Name);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.Dispose(true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void Dispose(bool disposing)
        {
            if (this.mUvqAX6rk == DisposeState.None)
            {
                this.mUvqAX6rk = DisposeState.Disposing;
                try
                {
                    if (disposing)
                    {
                        this.DisposeManagedResources();
                        this.DisposeUnmanagedResources();
                        this.mUvqAX6rk = DisposeState.Disposed;
                        this.OnDisposed();
                        GC.SuppressFinalize(this);
                    }
                    else
                    {
                        this.DisposeUnmanagedResources();
                        this.mUvqAX6rk = DisposeState.Disposed;
                    }
                }
                catch
                {
                    this.mUvqAX6rk = DisposeState.None;
                    throw;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void DisposeManagedResources()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void DisposeUnmanagedResources()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        ~DisposableObject()
        {
            this.Dispose(false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnDisposed()
        {
            if (this.XPOfx7u7N != null)
            {
                this.XPOfx7u7N(this, EventArgs.Empty);
            }
        }

        public bool IsDisposed
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.mUvqAX6rk == DisposeState.Disposed);
            }
        }

        public bool IsDisposing
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.mUvqAX6rk == DisposeState.Disposing);
            }
        }
    }
}

