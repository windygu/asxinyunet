namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class DisposableObject : IDisposable
    {
        private DisposeState mUvqAX6rk;
        private EventHandler XPOfx7u7N;

        public event EventHandler Disposed
        {
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.Synchronized)] add
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.Synchronized)] remove
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected DisposableObject()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void CheckDisposed()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void Dispose(bool disposing)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void DisposeManagedResources()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void DisposeUnmanagedResources()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Finalize()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnDisposed()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public bool IsDisposed
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public bool IsDisposing
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
