using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.WinForm.Controls;

namespace DotNet.Tools
{
    public partial class StringToConst : UserControl
    {
        public StringToConst()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 创建窗体
        /// </summary>        
        public static FormModel CreateForm()
        {
            return DotNet.WinForm.WinFormHelper.GetControlForm(new StringToConst (), "字符串转换为常量");
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //转换函数，默认以,分割，常量名称首字母大写，字符值小写
            string[] str = txtOriginText.Text.Trim().Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (var t in str )
            {
                string item = t.ToLower();
                if (item!="")
                {
                    
                    sb.AppendLine("		/// <summary>");
                    sb.AppendLine("		/// ");
                    sb.AppendLine("		/// <summary>");
                    sb.AppendLine(string.Format("		public const string {0} = \"{1}\" ;", item.Substring(0, 1).ToUpper() +
                        item.Substring(1, item.Length - 1), item));
                    sb.AppendLine("		 ");
                }
            }
            txtNewText.Text = sb.ToString();
        }
    }
}
