using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNet.Tools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void wMI代码生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DotWMITemplate.CreateForm().Show();
        }

        private void stringBuilder转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuildor.CreateForm().Show();
        }
    }
}
