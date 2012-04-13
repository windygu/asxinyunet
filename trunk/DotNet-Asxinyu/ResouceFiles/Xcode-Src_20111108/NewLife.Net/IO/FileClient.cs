﻿using System;
using System.IO;
using NewLife.Net.Sockets;
using NewLife.Net.Tcp;

namespace NewLife.Net.IO
{
    /// <summary>
    /// 文件客户端
    /// </summary>
    public class FileClient
    {
        #region 属性
        private SocketClient _Client;
        /// <summary>客户端连接</summary>
        public SocketClient Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 连接文件服务器
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public void Connect(String hostname, Int32 port)
        {
            if (Client == null) Client = new TcpClientX();
            Client.Connect(hostname, port);
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SendFile(String fileName)
        {
            SendFile(fileName, null);
        }

        void SendFile(String fileName, String root)
        {
            FileFormat entity = new FileFormat(fileName, root);
            MemoryStream format = new MemoryStream();
            entity.Write(format);
            format.Position = 0;
            Client.Send(format);
            Client.Send(entity.Stream);
        }

        /// <summary>
        /// 发送目录
        /// </summary>
        /// <param name="directoryName"></param>
        public void SendDirectory(String directoryName)
        {
            foreach (String item in Directory.GetFiles(directoryName, "*.*", SearchOption.AllDirectories))
            {
                SendFile(item, directoryName);
            }
        }
        #endregion
    }
}
