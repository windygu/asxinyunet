/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * 软件GUI工具
 */
using System;
using System.Windows.Forms;
using DotNet.Tools.Controls;
using LotTick;
using NewLife.Configuration;
using DotNet.WinForm.Controls;

namespace LotteryTicketSoft
{
    /// <summary>
    /// 主程序
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        static string LabAssemblyName = "LotteryTicketSoft.exe";


        void MainFormLoad(object sender, EventArgs e)
        {
            this.Text = Config.GetConfig<string>("SoftName") + Config.GetConfig<string>("Version") ;
            StausShow.SetToolInfo1(Config.GetConfig<string>("SoftName"));
            StausShow.SetToolInfo3(Config.GetConfig<string>("CustomerCompanyName"));            
        }

        private void 常规参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void 数据更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //加载验证过滤管理窗体
        public static LotteryTicketSoft.GraphForm.DataManageForm DynamicLoadForm(DataControlParams dcp)
        {
            LotteryTicketSoft.GraphForm.DataManageForm dt = new LotteryTicketSoft.GraphForm.DataManageForm();
            dt.InitializeSettings(dcp);
            dt.StartPosition = FormStartPosition.CenterParent;
            return dt;
        }
        //public static LotteryTicketSoft.GraphForm.DataManageForm DynamicLoadForm(LotTickData[] data)
        //{
        //    LotteryTicketSoft.GraphForm.DataManageForm dt = new LotteryTicketSoft.GraphForm.DataManageForm();
        //    dt.InitializeSettings(dcp);
        //    dt.StartPosition = FormStartPosition.CenterParent;
        //    return dt;
        //}
        private void 验证过滤管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_Rules),
                "LotteryTicketSoft.GraphForm.AddRules");
            CP.IsEnablePaging = false;
            LotteryTicketSoft.GraphForm.DataManageForm dt = DynamicLoadForm(CP);
            dt.MdiParent = this;
            dt.Show();  
        }

        private void 指标信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_IndexInfo ),
               "LotteryTicketSoft.GraphForm.AddIndexInfo");
            CP.IsEnablePaging = false;
            DataManage.CreateForm(CP).ShowDialog();
        }

        private void 更新最近ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwoColorBall.UpdateRecent();
        }

        private void 更新所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            TwoColorBall.UpdateAll();
        }

        private void 指标信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DotNet.WinForm.Controls.ConfigSetting.CreateForm("test.xml").Show();
        }
    }
}
