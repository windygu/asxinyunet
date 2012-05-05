using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XTemplate.Templating ;
using DotNet.WinForm.Controls;
using System.IO;

namespace DotNet.Tools
{
    public partial class DotWMITemplate : UserControl
    {
        public DotWMITemplate()
        {
            InitializeComponent();
        }
        private void btnGeneration_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> data = GetData();
            data.Add("NameSpace", txtNameSpace.Text);
            data.Add("ClassName", txtClassName.Text);           
            //将元数据添加到data中去,字段名称作为key，字段类型为 value
            //需要读入模板内容
            string tempContent = File.ReadAllText("WMI模板.cs");
            string content = Template.ProcessTemplate(tempContent, data);
            String dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, txtOutputFolder.Text.Trim (),
                txtClassName.Text .Trim ()+".cs");
            StreamWriter fs = File.CreateText(dir );
            fs.Write(content);
            fs.Close();
        }
        /// <summary>
        /// 获取元数据，注意要进行类型转换,value
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetData()
        {
            Dictionary<String, Object> data = new Dictionary<String, Object>();
            string[] text = txtOriginText.Text.Trim().Replace("\r\n","").Split(';'); //分割符为;号
            foreach (var item in text )
            {
                string[] element = item.Trim ().Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                if (element .Length ==2)
                {
                    data.Add(element[1].Trim(), GetNewType (element[0].Trim()));
                }
            }        
             
            return data;
        }
        /// <summary>
        /// 类型转换
        /// </summary>
        string GetNewType(string oldType)
        {
            switch (oldType )
            {
                case "uint16": return "UInt16";
                case "string": return "string";
                case "uint32": return "UInt32";
                case "boolean": return "bool";
                case "datetime": return "DateTime";
                case "uint64": return "UInt64";             
                default: return oldType;                    
            }
        }
        /// <summary>
        /// 创建窗体
        /// </summary>        
        public static FormModel CreateForm()
        {
           return DotNet.WinForm.WinFormHelper.GetControlForm(new DotWMITemplate (), "WMI封装模板");
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOriginText.Text = string.Empty;
        }
    }
}
