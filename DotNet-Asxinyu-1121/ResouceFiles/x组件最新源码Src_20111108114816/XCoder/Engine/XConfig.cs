﻿using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using XCoder;
using System.Xml;

namespace XCoder
{
    public class XConfig
    {
        #region 属性
        private String _ConnName;
        /// <summary>链接名</summary>
        public String ConnName
        {
            get
            {
                if (String.IsNullOrEmpty(_ConnName)) _ConnName = "ConnName";
                return _ConnName;
            }
            set { _ConnName = value; }
        }

        private String _Prefix;
        /// <summary>前缀</summary>
        public String Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        private String _NameSpace;
        /// <summary>命名空间</summary>
        public String NameSpace
        {
            get { return String.IsNullOrEmpty(_NameSpace) ? EntityConnName : _NameSpace; }
            set { _NameSpace = value; }
        }

        private String _TemplateName;
        /// <summary>模板名</summary>
        public String TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private String _OutputPath;
        /// <summary>输出目录</summary>
        public String OutputPath
        {
            get { return String.IsNullOrEmpty(_OutputPath) ? EntityConnName : _OutputPath; }
            set { _OutputPath = value; }
        }

        private String _EntityConnName;
        /// <summary>实体链接名</summary>
        public String EntityConnName
        {
            get { return String.IsNullOrEmpty(_EntityConnName) ? ConnName : _EntityConnName; }
            set { _EntityConnName = value; }
        }

        private String _BaseClass;
        /// <summary>实体基类</summary>
        public String BaseClass
        {
            get
            {
                if (String.IsNullOrEmpty(_BaseClass)) _BaseClass = "Entity";
                return _BaseClass;
            }
            set { _BaseClass = value; }
        }

        private Boolean _RenderGenEntity;
        /// <summary>生成泛型实体类</summary>
        public Boolean RenderGenEntity
        {
            get { return _RenderGenEntity; }
            set { _RenderGenEntity = value; }
        }

        private Boolean _AutoCutPrefix;
        /// <summary>自动去除前缀</summary>
        public Boolean AutoCutPrefix
        {
            get { return _AutoCutPrefix; }
            set { _AutoCutPrefix = value; }
        }

        private Boolean _AutoFixWord;
        /// <summary>自动纠正大小写</summary>
        public Boolean AutoFixWord
        {
            get { return _AutoFixWord; }
            set { _AutoFixWord = value; }
        }

        private Boolean _UseCNFileName;
        /// <summary>使用中文文件名</summary>
        public Boolean UseCNFileName
        {
            get { return _UseCNFileName; }
            set { _UseCNFileName = value; }
        }

        private Boolean _UseHeadTemplate;
        /// <summary>使用头部模版</summary>
        public Boolean UseHeadTemplate
        {
            get { return _UseHeadTemplate; }
            set { _UseHeadTemplate = value; }
        }

        private String _HeadTemplate;
        /// <summary>头部模版</summary>
        public String HeadTemplate
        {
            get { return _HeadTemplate; }
            set { _HeadTemplate = value; }
        }

        private Boolean _Debug;
        /// <summary>调试</summary>
        public Boolean Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }

        private DateTime _LastUpdate;
        /// <summary>最后更新时间</summary>
        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }

        private String _LastBlogTitle;
        /// <summary>最后弹窗的博文地址</summary>
        public String LastBlogTitle
        {
            get { return _LastBlogTitle; }
            set { _LastBlogTitle = value; }
        }

        private Dictionary<String, String> _Items;
        /// <summary> 字典属性</summary>
        public Dictionary<String, String> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        #endregion

        #region 全局
        private static XConfig _Current;
        /// <summary>实例</summary>
        public static XConfig Current
        {
            get { return _Current ?? (_Current = Load()); }
            set { _Current = value; }
        }
        #endregion

        #region 加载/保存
        public static XConfig Load()
        {
            if (!File.Exists(DefaultFile)) return Create();

            //XmlSerializer xml = new XmlSerializer(typeof(XConfig));
            NewLife.Xml.XmlReaderX xml = new NewLife.Xml.XmlReaderX();
            using (XmlReader xr = XmlReader.Create(DefaultFile))
            {
                try
                {
                    Object obj = null;
                    xml.Reader = xr;
                    if (xml.ReadObject(typeof(XConfig), ref obj, null) && obj != null)
                    {
                        return obj as XConfig;
                    }
                    return Create();
                    //return xml.Deserialize(stream) as XConfig;
                }
                catch { return Create(); }
            }
        }

        static XConfig Create()
        {
            XConfig config = new XConfig();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/*");
            sb.AppendLine(" * XCoder v<#=Version#>");
            sb.AppendLine(" * 作者：<#=Environment.UserName + \"/\" + Environment.MachineName#>");
            sb.AppendLine(" * 时间：<#=DateTime.Now.ToString(\"yyyy-MM-dd HH:mm:ss\")#>");
            sb.AppendLine(" * 版权：版权所有 (C) 新生命开发团队 <#=DateTime.Now.ToString(\"yyyy\")#>");
            sb.AppendLine("*/");
            config.HeadTemplate = sb.ToString();


            return config;
        }

        public void Save()
        {
            if (!String.IsNullOrEmpty(HeadTemplate)) HeadTemplate = HeadTemplate.Replace("\n", Environment.NewLine);

            if (File.Exists(DefaultFile)) File.Delete(DefaultFile);

            //XmlSerializer xml = new XmlSerializer(typeof(XConfig));
            NewLife.Xml.XmlWriterX xml = new NewLife.Xml.XmlWriterX();

            using (XmlWriter writer = XmlWriter.Create(DefaultFile))
            {
                xml.Writer = writer;
                xml.WriteObject(this, typeof(XConfig), null);
            }
        }

        static String DefaultFile = "XCoder.xml";
        #endregion
    }
}