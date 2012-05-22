#region 
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
using DotNet.WinForm;
using ResourceManage;
using XCode;
using XCode.DataAccessLayer;
using ResouceEntity;
#endregion

namespace AsxinyuPlateForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string AssemblyName = "";
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 数据转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertDB.CreateForm().Show();
        }

        private void 页面管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams("", typeof(tb_resoucepageslist));
            CP.IsEnableAddBtn = false;
            CP.IsEnablePaging = true;
            CP.IsEnableAddBtn = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ed2k链接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams("", typeof(tb_resoucelink));
            CP.IsEnableAddBtn = false;
            CP.IsEnablePaging = true;
            CP.IsEnableAddBtn = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
