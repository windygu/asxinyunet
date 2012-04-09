namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class MyFileSystemWatcher : FileSystemWatcher, IDisposable
    {
        private int a2FPVvZKe;
        [CompilerGenerated]
        private bool HPTtbHDyD;
        private Dictionary<string, DateTime> KIhwg3idw;
        private TimeSpan VR7VTyay9;

        public event FileSystemEventHandler Changed;

        public event FileSystemEventHandler Created;

        public event FileSystemEventHandler Deleted;

        public event RenamedEventHandler Renamed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyFileSystemWatcher()
        {
            this.t00qRSolC();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyFileSystemWatcher(string Path) : base(Path)
        {
            this.t00qRSolC();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyFileSystemWatcher(string Path, string Filter) : base(Path, Filter)
        {
            this.t00qRSolC();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            base.Dispose();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Gd6gd0WLH(object, FileSystemEventArgs args1)
        {
            if (!this.QM3fY09LE(args1.FullPath))
            {
                this.OnCreated(args1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lPRM4Nury(object, FileSystemEventArgs args1)
        {
            if (!this.QM3fY09LE(args1.FullPath))
            {
                this.OnChanged(args1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnChanged(FileSystemEventArgs e)
        {
            if (this.MjoJPKkvO != null)
            {
                this.MjoJPKkvO(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnCreated(FileSystemEventArgs e)
        {
            if (this.2IIBg5mDY != null)
            {
                this.2IIBg5mDY(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnDeleted(FileSystemEventArgs e)
        {
            if (this.gLqZZCfZs != null)
            {
                this.gLqZZCfZs(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual void OnRenamed(RenamedEventArgs e)
        {
            if (this.4hvKymHGn != null)
            {
                this.4hvKymHGn(this, e);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool QM3fY09LE(string text1)
        {
            bool flag = false;
            if (!this.FilterRecentEvents)
            {
                return flag;
            }
            if (this.KIhwg3idw.ContainsKey(text1))
            {
                DateTime time = this.KIhwg3idw[text1];
                DateTime now = DateTime.Now;
                TimeSpan span = (TimeSpan) (now - time);
                flag = span < this.VR7VTyay9;
                this.KIhwg3idw[text1] = now;
                return flag;
            }
            this.KIhwg3idw.Add(text1, DateTime.Now);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void t00qRSolC()
        {
            this.Interval = 100;
            this.FilterRecentEvents = true;
            this.KIhwg3idw = new Dictionary<string, DateTime>();
            base.Created += new FileSystemEventHandler(this.Gd6gd0WLH);
            base.Changed += new FileSystemEventHandler(this.lPRM4Nury);
            base.Deleted += new FileSystemEventHandler(this.WO5U9QNDF);
            base.Renamed += new RenamedEventHandler(this.Y6nN8uJxd);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WO5U9QNDF(object, FileSystemEventArgs args1)
        {
            if (!this.QM3fY09LE(args1.FullPath))
            {
                this.OnDeleted(args1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Y6nN8uJxd(object, RenamedEventArgs args1)
        {
            if (!this.QM3fY09LE(args1.OldFullPath))
            {
                this.OnRenamed(args1);
            }
        }

        public bool FilterRecentEvents
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.HPTtbHDyD;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.HPTtbHDyD = value;
            }
        }

        public int Interval
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.a2FPVvZKe;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.a2FPVvZKe = value;
                this.VR7VTyay9 = new TimeSpan(0, 0, 0, 0, value);
            }
        }
    }
}

