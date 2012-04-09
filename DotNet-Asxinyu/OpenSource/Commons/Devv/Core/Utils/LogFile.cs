namespace Devv.Core.Utils
{
    using System;
    using System.IO;
    using System.Text;

    [Serializable]
    public class LogFile
    {
        private string _FilePath;
        private bool _Timestamp;
        private string _Title;
        private StringBuilder LogBuilder;
        private const string SEPARATOR = "------------------------------------------------------------";
        private DateTime StartedAt;

        public LogFile()
        {
            this.Init(string.Empty, string.Empty);
        }

        public LogFile(string path)
        {
            this.Init(path, string.Empty);
        }

        public LogFile(string path, string title)
        {
            this.Init(path, title);
        }

        public void Append()
        {
            this.Append(string.Empty);
        }

        public void Append(string text)
        {
            this.Append(text, this.Timestamp);
        }

        public void Append(string text, bool appendTimestamp)
        {
            if (!string.IsNullOrEmpty(text) & appendTimestamp)
            {
                this.LogBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                this.LogBuilder.Append(": ");
            }
            this.LogBuilder.Append(text);
            this.LogBuilder.Append(Environment.NewLine);
        }

        public void AppendError(Exception ex)
        {
            this.Append("ERROR: " + ex.Message);
        }

        public void AppendSeparator()
        {
            this.Append("------------------------------------------------------------");
        }

        public void Clear()
        {
            this.StartedAt = DateTime.Now;
            this.LogBuilder = new StringBuilder();
        }

        public void Init(string newPath, string newTitle)
        {
            this.Clear();
            this.FilePath = newPath;
            this.Title = newTitle;
        }

        public void Save()
        {
            this.Save(true);
        }

        public void Save(bool appendDate)
        {
            string str3 = string.Empty;
            string str2 = string.Empty;
            string contents = this.Contents;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.FilePath);
            if (appendDate)
            {
                fileNameWithoutExtension = fileNameWithoutExtension + "." + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            }
            fileNameWithoutExtension = Path.GetDirectoryName(this.FilePath) + @"\" + fileNameWithoutExtension + Path.GetExtension(this.FilePath);
            if (!this.Timestamp)
            {
                str3 = ((str3 + "START: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()) + Environment.NewLine) + "------------------------------------------------------------" + Environment.NewLine;
                str2 = str2 + "------------------------------------------------------------" + Environment.NewLine;
                str2 = ((str2 + "END: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()) + Environment.NewLine) + "------------------------------------------------------------" + Environment.NewLine;
                contents = str3 + contents + str2;
            }
            IOUtil.WriteFile(fileNameWithoutExtension, contents, true);
        }

        public override string ToString()
        {
            return this.Contents;
        }

        public string Contents
        {
            get
            {
                return this.LogBuilder.ToString();
            }
        }

        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
            }
        }

        public bool Timestamp
        {
            get
            {
                return this._Timestamp;
            }
            set
            {
                this._Timestamp = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
