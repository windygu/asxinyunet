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
    public partial class StringBuildor : UserControl
    {
        public StringBuildor()
        {
            InitializeComponent();
        }
        public static FormModel CreateForm()
        {
            return DotNet.WinForm.WinFormHelper.GetControlForm(new StringBuildor(), "StringBuilder转换器");
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtOriginText.Text !="")
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("StringBuilder sb = new StringBuilder();");
                string[] str = txtOriginText.Text.Split("\r\n");
                foreach (string  item in str )
                {
                    sb.AppendLine(string.Format("sb.AppendLine(\"{0}\");",item));
                }
                txtNewText.Text = sb.ToString();
            }
        }
    }
}
