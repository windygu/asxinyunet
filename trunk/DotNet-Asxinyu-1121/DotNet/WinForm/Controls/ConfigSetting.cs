﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml; 
using System.IO;
using DotNet.Core.Exceptions;

namespace DotNet.WinForm.Controls
{
    public partial class ConfigSetting : UserControl
    {
        #region 初始化
        public ConfigSetting()
        {
            InitializeComponent();
        }

        string DefaultXmlFileName;
        public ConfigSetting(string DefaultFile)
        {
            this.DefaultXmlFileName = DefaultFile;
            Dictionary<string, string> dic = Load(DefaultFile);//读取文件
            DataGridViewColumnCollection columns = this.dgv.Columns;
            columns.Add("key", "键");
            columns.Add("value", "值");
            foreach (var item in dic)
            {
                DataGridViewRowCollection rows = this.dgv.Rows;
                rows.Add(item.Key, item.Value);
            }
        }
        #endregion

        #region 增加菜单及事件

        #endregion

        #region 读取
        /// <summary>
        /// 读取配置文件的配置信息
        /// </summary>   
        public static Dictionary<string, string> Load(string DefaultFile)
        {
            if (!File.Exists(DefaultFile)) 
                throw new XException(string.Format(ErrorCode.File_NotExist,DefaultFile ));
            NewLife.Xml.XmlReaderX xml = new NewLife.Xml.XmlReaderX();
            using (XmlReader xr = XmlReader.Create(DefaultFile))
            {
                try
                {
                    Object obj = null;
                    xml.Reader = xr;
                    if (xml.ReadObject(typeof(Dictionary<string,string>), ref obj, null) && obj != null)
                    {
                        return obj as Dictionary<string, string>;
                    }
                    throw new XException (ErrorCode.Serializ_ConvertFailed );                    
                }
                catch(Exception err)
                { throw new XException( err.Message ); }
            }
        }
        #endregion

        #region 保存
        public void Save()
        {
            if (File.Exists(DefaultXmlFileName)) File.Delete(DefaultXmlFileName);           
            NewLife.Xml.XmlWriterX xml = new NewLife.Xml.XmlWriterX();
            using (XmlWriter writer = XmlWriter.Create(DefaultXmlFileName))
            {
                xml.Writer = writer;
                xml.WriteObject(ReadFromDgv(), typeof(Dictionary<string ,string >), null);
            }
        }
        public Dictionary<string, string> ReadFromDgv()
        {
            DataGridViewRowCollection rows = this.dgv.Rows;
            DataGridViewColumnCollection column = this.dgv.Columns;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < rows.Count - 1; i++)
            {
                dic.Add(rows[i].Cells[0].Value.ToString(), rows[i].Cells[1].Value.ToString());
            }
            return dic;
        }
        #endregion
    }
}
