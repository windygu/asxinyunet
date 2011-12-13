using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNet.Tools.Controls
{
    /// <summary>
    /// 配置信息设置类
    /// </summary>
    public partial class ConfigSetting : UserControl
    {
        public ConfigSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 默认的xml配置文件路径
        /// </summary>
        public string DefaultXmlFileName;

    }
}
