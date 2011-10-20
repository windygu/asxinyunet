/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-27
 * 时间: 10:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NewLife.Configuration ;
using YoungRunLab.Forms ;
using XCode ;
using YoungRunEntity;
using YoungRunLab.Controls;
using YoungRunST.Controls;
using YoungRunST.Forms;
using DotNet.Tools.Controls;
using XCode.Configuration ;

namespace YoungRunMIS
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
        static string LabAssemblyName = "YoungRunLab.dll";
        static string STAssemblyName = "YoungRunST.dll";

		void MainFormLoad(object sender, EventArgs e)
		{			
			StatusInfo .SetAllToolInfo (Config.GetConfig<string >("CustomerCompanyName"),
			                            Config.GetConfig <string >("DevelopNameInfo"),
			                            Config.GetConfig <string >("TestInfo")) ;
        }

        #region 根据实体类型及程序集名称动态加载窗体
        void DynamicLoadForm(string FormAssemblyName, string FormName, bool IsHaveMenu, Type type,string TitleText)
        {
            DataManageForm dt = new DataManageForm();
            dt.InitializeSettings (type,FormAssemblyName,FormName,IsHaveMenu,true,20,"","","");   
            dt.Text = TitleText;
            dt.MdiParent = this;
            dt.StartPosition = FormStartPosition.CenterParent;
            dt.Show();
        }
        #endregion

        private void 糠醛车间检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddKqTestDataForm", true, typeof(tb_kqtestdata), "糠醛车间检测数据管理");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 白土车间检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddBtTestDataForm", true, typeof(tb_bttestdata), "白土车间检测数据管理");
        }

        private void 灌区采样检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddTankTestForm", true, typeof(tb_oildata), "灌区采样检测数据管理");
        }

        private void 原料进厂检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddYLJCTestForm", true, typeof(tb_oildata), "原料进厂检测数据管理");
        }

        private void 油样检测登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddOilDataForm", true, typeof(tb_oildata), "油样检测数据管理");
        }

        private void 储运灌区信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(STAssemblyName, "YoungRunST.Forms.AddOilTankInfoForm", true, typeof(tb_oiltankinfo ), "油罐信息管理");
        }

        private void 灌区日常测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(STAssemblyName, "YoungRunST.Forms.AddOilTankSTForm", true, typeof(tb_oiltankst ), "灌区日常测量数据管理");
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddUserForm", true, typeof(tb_user), "用户管理");
        }

        private void 系统字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddDicKeyForm", true, typeof(tb_dictype), "数据字典管理");
        }

        private void 产品配方信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicLoadForm(LabAssemblyName, "YoungRunLab.Forms.AddProductFormuleForm", true, typeof(tb_productformule), "产品配方管理");
        }
    }
}
