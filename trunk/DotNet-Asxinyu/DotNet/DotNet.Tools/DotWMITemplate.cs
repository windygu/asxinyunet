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
            //将元数据添加到data中去,字段名称作为key，字段类型为 value
            string content =Template.ProcessTemplate("WMI模板.txt", data);
        }
        private Dictionary<string, object> GetData()
        {
            Dictionary<String, Object> data = new Dictionary<String, Object>();
            string[] text = txtOriginText.Text.Trim().Split(';'); //分割符为;号
            foreach (var item in text )
            {
                string[] element = item.Split(' ');
                if (element .Length ==2)
                {
                    data.Add(element[1].Trim(), element[0].Trim());
                }
            }
            return data;
        }
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
