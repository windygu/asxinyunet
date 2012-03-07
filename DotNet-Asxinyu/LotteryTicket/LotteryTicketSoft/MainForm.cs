/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * 软件GUI工具
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LotTick;
using NewLife.Configuration;
using DotNet.WinForm.Controls;
using DotNet.WinForm;
using System.Threading.Tasks;

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
            CheckForIllegalCrossThreadCalls = false;//运行其他线程访问主线程定义的控件
        }
        static string LabAssemblyName = "LotteryTicketSoft.exe";

        void MainFormLoad(object sender, EventArgs e)
        {
            //加载主要的配置信息
            this.Text = Config.GetConfig<string>("SoftName") + Config.GetConfig<string>("Version") ;
            StausShow.SetToolInfo1(Config.GetConfig<string>("SoftName"));
            StausShow.SetToolInfo3(Config.GetConfig<string>("CustomerCompanyName"));            
        }       
        private void 验证过滤管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterNumbers();
        }
        //过滤操作
        private void FilterNumbers()
        {
            string[] remove = new string[] { tb_Rules._.Remark.Description };
            Dictionary<string, string[]> bandingSource = new Dictionary<string, string[]>();
            bandingSource.Add(tb_Rules._.IndexSelectorNameTP, LotTickHelper.GetAllIndexFuncNames());
            bandingSource.Add(tb_Rules._.CompareRuleNameTP, LotTickHelper.GetAllEnumNames<ECompareType>());
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_Rules), remove, bandingSource,
               "LotteryTicketSoft.GraphForm.AddRules");
            CP.IsEnablePaging = false;            
            FormModel frm = LotteryTicketSoft.GraphForm.DataPrediction.CreateForm2(CP);
            frm.MdiParent = this;
            frm.Show();
        }

        private void 指标信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] remove = new string[] {tb_Rules._.Remark.Description };
            Dictionary<string ,string[]> bandingSource = new Dictionary<string,string[]> ();
            bandingSource.Add ( tb_Rules._.IndexSelectorNameTP,LotTickHelper.GetAllIndexFuncNames());
            bandingSource.Add ( tb_Rules._.CompareRuleNameTP,LotTickHelper.GetAllEnumNames<ECompareType>());
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_IndexInfo ),remove,bandingSource ,
               "LotteryTicketSoft.GraphForm.AddIndexInfo");
            CP.IsEnablePaging = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP) ;
            frm.MdiParent = this ;
            frm.Show ();
        }

        /// <summary>
        /// 异步调用，更新数据
        /// </summary>        
        private void 更新最近ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = Task.Factory.StartNew(()=>
            {
                TwoColorBall.UpdateRecent();
                MessageBox.Show("近期数据更新成功","任务提示");//可以考虑其他地方显示该信息
            });
        }

        private void 更新所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                TwoColorBall.UpdateAll();
                MessageBox.Show("所有数据更新成功", "任务提示");
            });          
        }

        private void 指标信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DotNet.WinForm.Controls.ConfigSetting.CreateForm("test.xml").Show();
        }
    }
}
