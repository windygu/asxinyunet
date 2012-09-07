namespace MathWorks.MATLAB.NET.Utility
{
    using System;

    [Serializable]
    public class MWException : ApplicationException
    {
        private bool disposed;
        private string[] mwStack;

        public MWException(string msg, string[] stack) : base(msg)
        {
            this.mwStack = stack;
        }

        internal void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing && this.mwStack != null)
                {
                    Array.Clear(this.mwStack, 0, this.mwStack.Length);
                    this.mwStack = null;
                }
                this.disposed = true;
            }
        }

        ~MWException() { this.Dispose(false); }

        public override string StackTrace
        {
            get
            {
                string str = "... Matlab M-code Stack Trace ...\n";
                foreach (string str2 in this.mwStack)
                {
                    str = (str + "    at\n") + str2 + "\n";
                }
                return (str + "\n... .Application Stack Trace ...\n" + base.StackTrace);
            }
        }
    }
}
