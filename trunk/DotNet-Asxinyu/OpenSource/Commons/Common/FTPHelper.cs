namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class FTPHelper
    {
        private int 1LIZtmuRJ;
        private bool 9bP2Oyj5m;
        private long AKae6LN2M;
        private string IQOmGIxnI;
        private FileStream JCWn4nf54;
        private IPEndPoint kfCNb6LIy;
        private IPEndPoint MhlXt0Q8q;
        public string pass;
        private string PD3B8iBEN;
        public int port;
        private Socket pXI80WIXh;
        public string server;
        public int timeout;
        private string UgFA6EwT8;
        public string user;
        private Socket voVjcfCWT;
        private Socket WisrNfbCq;
        private long XpA9mrlCE;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FTPHelper()
        {
            this.server = null;
            this.user = null;
            this.pass = null;
            this.port = 0x15;
            this.9bP2Oyj5m = true;
            this.pXI80WIXh = null;
            this.MhlXt0Q8q = null;
            this.voVjcfCWT = null;
            this.WisrNfbCq = null;
            this.kfCNb6LIy = null;
            this.JCWn4nf54 = null;
            this.IQOmGIxnI = "";
            this.AKae6LN2M = 0L;
            this.timeout = 0x2710;
            this.PD3B8iBEN = "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FTPHelper(string server, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = 0x15;
            this.9bP2Oyj5m = true;
            this.pXI80WIXh = null;
            this.MhlXt0Q8q = null;
            this.voVjcfCWT = null;
            this.WisrNfbCq = null;
            this.kfCNb6LIy = null;
            this.JCWn4nf54 = null;
            this.IQOmGIxnI = "";
            this.AKae6LN2M = 0L;
            this.timeout = 0x2710;
            this.PD3B8iBEN = "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FTPHelper(string server, int port, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.9bP2Oyj5m = true;
            this.pXI80WIXh = null;
            this.MhlXt0Q8q = null;
            this.voVjcfCWT = null;
            this.WisrNfbCq = null;
            this.kfCNb6LIy = null;
            this.JCWn4nf54 = null;
            this.IQOmGIxnI = "";
            this.AKae6LN2M = 0L;
            this.timeout = 0x2710;
            this.PD3B8iBEN = "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 9vUWP8ynB()
        {
            if (this.WisrNfbCq != null)
            {
                if (this.WisrNfbCq.Connected)
                {
                    this.WisrNfbCq.Close();
                }
                this.WisrNfbCq = null;
            }
            this.kfCNb6LIy = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ChangeDir(string path)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72ea) + path);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 250)
            {
                throw new Exception(this.UgFA6EwT8);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Connect()
        {
            if (this.server == null)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7114));
            }
            if (this.user == null)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7146));
            }
            if ((this.pXI80WIXh == null) || !this.pXI80WIXh.Connected)
            {
                this.pXI80WIXh = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.MhlXt0Q8q = new IPEndPoint(Dns.GetHostByName(this.server).AddressList[0], this.port);
                try
                {
                    this.pXI80WIXh.Connect(this.MhlXt0Q8q);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                this.T4DKb6wAk();
                if (this.1LIZtmuRJ != 220)
                {
                    this.mi5qIK3te();
                }
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x717c) + this.user);
                this.T4DKb6wAk();
                int num = this.1LIZtmuRJ;
                if ((num != 230) && (num == 0x14b))
                {
                    if (this.pass == null)
                    {
                        this.Disconnect();
                        throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x718a));
                    }
                    this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x71c0) + this.pass);
                    this.T4DKb6wAk();
                    if (this.1LIZtmuRJ != 230)
                    {
                        this.mi5qIK3te();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Connect(string server, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.Connect();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Connect(string server, int port, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.Connect();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Disconnect()
        {
            this.9vUWP8ynB();
            if (this.pXI80WIXh != null)
            {
                if (this.pXI80WIXh.Connected)
                {
                    this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7108));
                    this.pXI80WIXh.Close();
                }
                this.pXI80WIXh = null;
            }
            if (this.JCWn4nf54 != null)
            {
                this.JCWn4nf54.Close();
            }
            this.MhlXt0Q8q = null;
            this.JCWn4nf54 = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public long DoDownload()
        {
            long num;
            byte[] buffer = new byte[0x200];
            try
            {
                num = this.WisrNfbCq.Receive(buffer, buffer.Length, SocketFlags.None);
                if (num <= 0L)
                {
                    this.9vUWP8ynB();
                    this.JCWn4nf54.Close();
                    this.JCWn4nf54 = null;
                    this.T4DKb6wAk();
                    switch (this.1LIZtmuRJ)
                    {
                        case 0xe2:
                        case 250:
                            this.lWvfFeZUE(false);
                            return num;
                    }
                    throw new Exception(this.UgFA6EwT8);
                }
                this.JCWn4nf54.Write(buffer, 0, (int) num);
                this.AKae6LN2M += num;
            }
            catch (Exception exception)
            {
                this.9vUWP8ynB();
                this.JCWn4nf54.Close();
                this.JCWn4nf54 = null;
                this.T4DKb6wAk();
                this.lWvfFeZUE(false);
                throw exception;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public long DoUpload()
        {
            long num;
            byte[] buffer = new byte[0x200];
            try
            {
                num = this.JCWn4nf54.Read(buffer, 0, buffer.Length);
                this.AKae6LN2M += num;
                this.WisrNfbCq.Send(buffer, (int) num, SocketFlags.None);
                if (num > 0L)
                {
                    return num;
                }
                this.JCWn4nf54.Close();
                this.JCWn4nf54 = null;
                this.9vUWP8ynB();
                this.T4DKb6wAk();
                switch (this.1LIZtmuRJ)
                {
                    case 0xe2:
                    case 250:
                        break;

                    default:
                        throw new Exception(this.UgFA6EwT8);
                }
                this.lWvfFeZUE(false);
            }
            catch (Exception exception)
            {
                this.JCWn4nf54.Close();
                this.JCWn4nf54 = null;
                this.9vUWP8ynB();
                this.T4DKb6wAk();
                this.lWvfFeZUE(false);
                throw exception;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string fcNUBE6Y4()
        {
            string str = "";
            int index = this.IQOmGIxnI.IndexOf('\n');
            if (index < 0)
            {
                while (index < 0)
                {
                    this.jSdinGKD3();
                    index = this.IQOmGIxnI.IndexOf('\n');
                }
            }
            str = this.IQOmGIxnI.Substring(0, index);
            this.IQOmGIxnI = this.IQOmGIxnI.Substring(index + 1);
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private DateTime Fu3HlvBwR(string text1)
        {
            if (text1.Length < 14)
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7214));
            }
            int year = Convert.ToInt16(text1.Substring(0, 4));
            int month = Convert.ToInt16(text1.Substring(4, 2));
            int day = Convert.ToInt16(text1.Substring(6, 2));
            int hour = Convert.ToInt16(text1.Substring(8, 2));
            int minute = Convert.ToInt16(text1.Substring(10, 2));
            return new DateTime(year, month, day, hour, minute, Convert.ToInt16(text1.Substring(12, 2)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTime GetFileDate(string fileName)
        {
            return this.Fu3HlvBwR(this.GetFileDateRaw(fileName));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFileDateRaw(string fileName)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7206) + fileName);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 0xd5)
            {
                throw new Exception(this.UgFA6EwT8);
            }
            return this.UgFA6EwT8.Substring(4);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public long GetFileSize(string filename)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7338) + filename);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 0xd5)
            {
                throw new Exception(this.UgFA6EwT8);
            }
            return long.Parse(this.UgFA6EwT8.Substring(4));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetWorkingDirectory()
        {
            string str;
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7294));
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 0x101)
            {
                throw new Exception(this.UgFA6EwT8);
            }
            try
            {
                str = this.UgFA6EwT8.Substring(this.UgFA6EwT8.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x729e), 0) + 1);
                str = str.Substring(0, str.LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72a4))).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72aa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72b2));
            }
            catch (Exception exception)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72b8) + exception.Message);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void jSdinGKD3()
        {
            byte[] buffer = new byte[0x200];
            int num2 = 0;
            while (this.pXI80WIXh.Available < 1)
            {
                Thread.Sleep(50);
                num2 += 50;
                if (num2 > this.timeout)
                {
                    this.Disconnect();
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e2a));
                }
            }
            while (this.pXI80WIXh.Available > 0)
            {
                long num = this.pXI80WIXh.Receive(buffer, 0x200, SocketFlags.None);
                this.IQOmGIxnI = this.IQOmGIxnI + Encoding.ASCII.GetString(buffer, 0, (int) num);
                Thread.Sleep(50);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ArrayList List()
        {
            byte[] buffer = new byte[0x200];
            string str = "";
            long num = 0L;
            int num2 = 0;
            ArrayList list = new ArrayList();
            this.Connect();
            this.YFqw2yc0N();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x71ce));
            this.T4DKb6wAk();
            switch (this.1LIZtmuRJ)
            {
                case 0x7d:
                case 150:
                    this.WgtPdL4t3();
                    while (this.WisrNfbCq.Available < 1)
                    {
                        Thread.Sleep(50);
                        num2 += 50;
                        if (num2 > (this.timeout / 10))
                        {
                            break;
                        }
                    }
                    break;

                default:
                    this.9vUWP8ynB();
                    throw new Exception(this.UgFA6EwT8);
            }
            while (this.WisrNfbCq.Available > 0)
            {
                num = this.WisrNfbCq.Receive(buffer, buffer.Length, SocketFlags.None);
                str = str + Encoding.ASCII.GetString(buffer, 0, (int) num);
                Thread.Sleep(50);
            }
            this.9vUWP8ynB();
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 0xe2)
            {
                throw new Exception(this.UgFA6EwT8);
            }
            foreach (string str2 in str.Split(new char[] { '\n' }))
            {
                if (!((str2.Length <= 0) || Regex.Match(str2, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x71da)).Success))
                {
                    list.Add(str2.Substring(0, str2.Length - 1));
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ArrayList ListDirectories()
        {
            ArrayList list = new ArrayList();
            foreach (string str in this.List())
            {
                if ((str.Length > 0) && ((str[0] == 'd') || (str.ToUpper().IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x71f8)) >= 0)))
                {
                    list.Add(str);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ArrayList ListFiles()
        {
            ArrayList list = new ArrayList();
            foreach (string str in this.List())
            {
                if ((str.Length > 0) && ((str[0] != 'd') && (str.ToUpper().IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x71ea)) < 0)))
                {
                    list.Add(str);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lWvfFeZUE(bool flag1)
        {
            if (flag1)
            {
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e02));
            }
            else
            {
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e12));
            }
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 200)
            {
                this.mi5qIK3te();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MakeDir(string dir)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x72f6) + dir);
            this.T4DKb6wAk();
            switch (this.1LIZtmuRJ)
            {
                case 250:
                case 0x101:
                    return;
            }
            throw new Exception(this.UgFA6EwT8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te()
        {
            this.Disconnect();
            throw new Exception(this.UgFA6EwT8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OBHMaLtRG(string text1)
        {
            byte[] bytes = Encoding.ASCII.GetBytes((text1 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e22)).ToCharArray());
            this.pXI80WIXh.Send(bytes, bytes.Length, SocketFlags.None);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenDownload(string filename)
        {
            this.OpenDownload(filename, filename, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenDownload(string filename, bool resume)
        {
            this.OpenDownload(filename, filename, resume);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenDownload(string filename, string localfilename)
        {
            this.OpenDownload(filename, localfilename, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenDownload(string remote_filename, string local_filename, bool resume)
        {
            Exception exception;
            this.Connect();
            this.lWvfFeZUE(true);
            this.AKae6LN2M = 0L;
            try
            {
                this.XpA9mrlCE = this.GetFileSize(remote_filename);
            }
            catch
            {
                this.XpA9mrlCE = 0L;
            }
            if (resume && File.Exists(local_filename))
            {
                try
                {
                    this.JCWn4nf54 = new FileStream(local_filename, FileMode.Open);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    this.JCWn4nf54 = null;
                    throw new Exception(exception.Message);
                }
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7362) + this.JCWn4nf54.Length);
                this.T4DKb6wAk();
                if (this.1LIZtmuRJ != 350)
                {
                    throw new Exception(this.UgFA6EwT8);
                }
                this.JCWn4nf54.Seek(this.JCWn4nf54.Length, SeekOrigin.Begin);
                this.AKae6LN2M = this.JCWn4nf54.Length;
            }
            else
            {
                try
                {
                    this.JCWn4nf54 = new FileStream(local_filename, FileMode.Create);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    this.JCWn4nf54 = null;
                    throw new Exception(exception.Message);
                }
            }
            this.YFqw2yc0N();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7370) + remote_filename);
            this.T4DKb6wAk();
            switch (this.1LIZtmuRJ)
            {
                case 0x7d:
                case 150:
                    this.WgtPdL4t3();
                    return;
            }
            this.JCWn4nf54.Close();
            this.JCWn4nf54 = null;
            throw new Exception(this.UgFA6EwT8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenUpload(string filename)
        {
            this.OpenUpload(filename, filename, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenUpload(string filename, bool resume)
        {
            this.OpenUpload(filename, filename, resume);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenUpload(string filename, string remotefilename)
        {
            this.OpenUpload(filename, remotefilename, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void OpenUpload(string filename, string remote_filename, bool resume)
        {
            this.Connect();
            this.lWvfFeZUE(true);
            this.YFqw2yc0N();
            this.AKae6LN2M = 0L;
            try
            {
                this.JCWn4nf54 = new FileStream(filename, FileMode.Open);
            }
            catch (Exception exception)
            {
                this.JCWn4nf54 = null;
                throw new Exception(exception.Message);
            }
            this.XpA9mrlCE = this.JCWn4nf54.Length;
            if (resume)
            {
                long fileSize = this.GetFileSize(remote_filename);
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7346) + fileSize);
                this.T4DKb6wAk();
                if (this.1LIZtmuRJ == 350)
                {
                    this.JCWn4nf54.Seek(fileSize, SeekOrigin.Begin);
                }
            }
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7354) + remote_filename);
            this.T4DKb6wAk();
            switch (this.1LIZtmuRJ)
            {
                case 0x7d:
                case 150:
                    this.WgtPdL4t3();
                    return;
            }
            this.JCWn4nf54.Close();
            this.JCWn4nf54 = null;
            throw new Exception(this.UgFA6EwT8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RemoveDir(string dir)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7302) + dir);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 250)
            {
                throw new Exception(this.UgFA6EwT8);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RemoveFile(string filename)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x730e) + filename);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 250)
            {
                throw new Exception(this.UgFA6EwT8);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void RenameFile(string oldfilename, string newfilename)
        {
            this.Connect();
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x731c) + oldfilename);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 350)
            {
                throw new Exception(this.UgFA6EwT8);
            }
            this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x732a) + newfilename);
            this.T4DKb6wAk();
            if (this.1LIZtmuRJ != 250)
            {
                throw new Exception(this.UgFA6EwT8);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void T4DKb6wAk()
        {
            this.PD3B8iBEN = "";
            while (true)
            {
                string input = this.fcNUBE6Y4();
                if (Regex.Match(input, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e7c)).Success)
                {
                    this.UgFA6EwT8 = input;
                    this.1LIZtmuRJ = int.Parse(input.Substring(0, 3));
                    return;
                }
                this.PD3B8iBEN = this.PD3B8iBEN + Regex.Replace(input, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6e90), "") + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6ea4);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WgtPdL4t3()
        {
            if (this.WisrNfbCq == null)
            {
                try
                {
                    this.WisrNfbCq = this.voVjcfCWT.Accept();
                    this.voVjcfCWT.Close();
                    this.voVjcfCWT = null;
                    if (this.WisrNfbCq == null)
                    {
                        throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7098) + Convert.ToString(Marshal.GetLastWin32Error()));
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x70ba) + exception.Message);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void YFqw2yc0N()
        {
            Exception exception;
            if (this.9bP2Oyj5m)
            {
                string[] strArray;
                this.Connect();
                this.OBHMaLtRG(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6eaa));
                this.T4DKb6wAk();
                if (this.1LIZtmuRJ != 0xe3)
                {
                    this.mi5qIK3te();
                }
                try
                {
                    int startIndex = this.UgFA6EwT8.IndexOf('(') + 1;
                    int length = this.UgFA6EwT8.IndexOf(')') - startIndex;
                    strArray = this.UgFA6EwT8.Substring(startIndex, length).Split(new char[] { ',' });
                }
                catch (Exception)
                {
                    this.Disconnect();
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6eb6) + this.UgFA6EwT8);
                }
                if (strArray.Length < 6)
                {
                    this.Disconnect();
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6eec) + this.UgFA6EwT8);
                }
                string hostName = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6f22), new object[] { strArray[0], strArray[1], strArray[2], strArray[3] });
                int port = (int.Parse(strArray[4]) << 8) + int.Parse(strArray[5]);
                try
                {
                    this.9vUWP8ynB();
                    this.WisrNfbCq = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.kfCNb6LIy = new IPEndPoint(Dns.GetHostByName(hostName).AddressList[0], port);
                    this.WisrNfbCq.Connect(this.kfCNb6LIy);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6f44) + exception.Message);
                }
            }
            else
            {
                this.Connect();
                try
                {
                    this.9vUWP8ynB();
                    this.voVjcfCWT = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    string str2 = this.pXI80WIXh.LocalEndPoint.ToString();
                    int index = str2.IndexOf(':');
                    if (index < 0)
                    {
                        throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6f92) + str2);
                    }
                    string ipString = str2.Substring(0, index);
                    IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(ipString), 0);
                    this.voVjcfCWT.Bind(localEP);
                    str2 = this.voVjcfCWT.LocalEndPoint.ToString();
                    index = str2.IndexOf(':');
                    if (index < 0)
                    {
                        throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6fdc) + str2);
                    }
                    int num5 = int.Parse(str2.Substring(index + 1));
                    this.voVjcfCWT.Listen(1);
                    string str4 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7026), ipString.Replace('.', ','), num5 / 0x100, num5 % 0x100);
                    this.OBHMaLtRG(str4);
                    this.T4DKb6wAk();
                    if (this.1LIZtmuRJ != 200)
                    {
                        this.mi5qIK3te();
                    }
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x704a) + exception.Message);
                }
            }
        }

        public long BytesTotal
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AKae6LN2M;
            }
        }

        public long FileSize
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.XpA9mrlCE;
            }
        }

        public bool IsConnected
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return ((this.pXI80WIXh != null) && this.pXI80WIXh.Connected);
            }
        }

        public string Messages
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                string str = this.PD3B8iBEN;
                this.PD3B8iBEN = "";
                return str;
            }
        }

        public bool MessagesAvailable
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return (this.PD3B8iBEN.Length > 0);
            }
        }

        public bool PassiveMode
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.9bP2Oyj5m;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.9bP2Oyj5m = value;
            }
        }

        public string ResponseString
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.UgFA6EwT8;
            }
        }
    }
}

