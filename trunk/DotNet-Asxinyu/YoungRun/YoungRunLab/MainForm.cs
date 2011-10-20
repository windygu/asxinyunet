/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-13
 * 时间: 16:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DotNet.Authority.Forms;
using DotNet.Tools.Controls;
using YoungRunEntity ;
using NewLife.Configuration ;
using YoungRunLab.Forms ;

namespace YoungRunLab
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();			
		}

        private void button1_Click(object sender, EventArgs e)
        {
            AuthMainForm auth = new AuthMainForm();
            auth.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
//        	string[] str = Config.GetConfigByPrefix("LogOn") ;
//        	MessageBox.Show(Config.GetConfig <string>("LogOnTo")) ;
//        	Config.
//            string[] str = new string[] {"用户名","密码","备注" };
//            SearchConditionForm sf = new SearchConditionForm(str );
//            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                MessageBox.Show(sf.GetConditions());
//                sf.Close();
//            }
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			stausInfoShow1.SetAllToolInfo ("技术部-化验室","宁波永润石化科技有限公司",
			                               "当前系统日期:"+DateTime.Now.ToLongDateString ());
		}
		
		void 糠醛车间检测ToolStripMenuItemClick(object sender, EventArgs e)
		{
			KqTestDataManageForm kqm = new KqTestDataManageForm () ;
			kqm.MdiParent = this ;
			kqm.Show () ;
		}
		
		void 白土车间检测ToolStripMenuItemClick(object sender, EventArgs e)
		{
			BtTestDataManageForm kqm = new BtTestDataManageForm () ;
			kqm.MdiParent = this ;
			kqm.Show () ;
		}
		
		void 油样检测登记ToolStripMenuItemClick(object sender, EventArgs e)
		{
			OilSampleTestManageForm kqm = new OilSampleTestManageForm () ;
			kqm.MdiParent = this ;
			kqm.Show () ;
		}
		
		void 检测数据管理ToolStripMenuItemClick(object sender, EventArgs e)
		{
			OilDataManageForm kqm = new OilDataManageForm () ;
			kqm.MdiParent = this ;
			kqm.Show () ;
		}
		
		void 退出ToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close () ;
		}

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	;
        }

        private void 字典管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
		
		void 油罐检测ToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void 原料进厂检测ToolStripMenuItemClick(object sender, EventArgs e)
		{
		
		}
	}
}