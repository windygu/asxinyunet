using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.Tools;
using DotNet.Core;
using DotNet.WinForm.Controls;

namespace AsxinyuPlateForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 数据转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertDB.CreateForm().Show();
        }
    }
}
