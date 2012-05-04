using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XTemplate;

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
            Dictionary<String, Object> data = new Dictionary<String, Object>(); 
            data["name"] = "参数测试";
            string content =Template.ProcessTemplate("模版文件.txt", data);
        }
    }
}
