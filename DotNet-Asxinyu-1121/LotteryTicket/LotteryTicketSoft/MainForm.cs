/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * 软件GUI工具
 */
using System;
using DotNet.Tools.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LotTick;
using LotteryTicketSoft.GraphForm;
using DotNet.Tools.Controls;

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
            DotNet.Tools.Controls.DataManageForm dt = new DotNet.Tools.Controls.DataManageForm();
            dt.InitializeSettings(CP );
            dt.StartPosition = FormStartPosition.CenterParent;
            dt.MdiParent = this;
            dt.Show();  
        }

        private void 更新最近ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwoColorBall.UpdateRecent();
        }

        private void 更新所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            TwoColorBall.UpdateAll();
        }
    }
}
