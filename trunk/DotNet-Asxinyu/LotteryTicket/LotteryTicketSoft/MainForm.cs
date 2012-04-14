﻿/*
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
using LotteryTicketSoft.GraphForm;
using System.Drawing;
using System.Linq;
using XCode;
using System.Collections;

namespace LotteryTicketSoft
{
    /// <summary>
    /// 主程序
    /// </summary>
    public partial class MainForm : Form
    {
        #region 初始信息
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//运行其他线程访问主线程定义的控件
        }
        static string LabAssemblyName = "LotteryTicketSoft.exe";

        void MainFormLoad(object sender, EventArgs e)
        {
            //加载主要的配置信息
            this.Text = Config.GetConfig<string>("SoftName") + Config.GetConfig<string>("Version");
            StausShow.SetToolInfo1(Config.GetConfig<string>("SoftName"));
            StausShow.SetToolInfo3(Config.GetConfig<string>("CustomerCompanyName"));
        }
        #endregion

        #region 核心功能区
      
        private void 指标信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] remove = new string[] { tb_Rules._.Remark.Description };
            Dictionary<string, string[]> bandingSource = new Dictionary<string, string[]>();
            bandingSource.Add(tb_Rules._.IndexSelectorNameTP, LotTickHelper.GetAllIndexFuncNames());
            bandingSource.Add(tb_Rules._.CompareRuleNameTP, LotTickHelper.GetAllEnumNames<ECompareType>());
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_IndexInfo), remove, bandingSource,
               "LotteryTicketSoft.GraphForm.AddIndexInfo");
            CP.IsEnablePaging = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }
        private void 历史数据预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_Ssq), null, null);
            CP.IsEnablePaging = true;
            CP.IsEnableAddBtn = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region 过滤管理事件
        private static DataManage _filterDM;
        //过滤管理窗体
        public static DataManage FilterDM
        {
            get
            {
                if (_filterDM == null)
                    _filterDM = new DataManage();
                _filterDM.Disposed += new EventHandler(dm_Disposed);//单例模式解决无法访问的问题
                return _filterDM;
            }
            set { _filterDM = value; }
        }
        public static void dm_Disposed(object sender, EventArgs e)
        {
            _filterDM = null;
        }
        private void 验证过滤管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = GetFilterControlParams();//得到参数
            SetFilterDM(CP);//设置控件,
            FormModel fm = WinFormHelper.GetControlForm(FilterDM, "");//
            fm.MdiParent = this;
            fm.Show();
        }
        /// <summary>
        /// 设置控件的菜单及相关属性
        /// </summary>
        /// <param name="CP"></param>
        private void SetFilterDM(DataControlParams CP)
        {
            //增加菜单的相关代码
            string[] menuNames = { "CrossValidate", "Filter", "Remove", "SaveProject" };
            string[] dispTexts = { "交叉验证", "过滤", "移除记录", "保存方案" };
            EventHandler[] eventNames ={ FilterDmHelper.toolStripCrossValidate_Click,
                        FilterDmHelper.toolStripFilter_Click,
                        FilterDmHelper.toolStripRemove_Click,
                        FilterDmHelper.toolStripSaveProject_Click}; //保存方案
            //默认的集成不能完成，需要修改生成的主窗体
            FilterDM.InitializeSettings(CP);
            FilterDM.Name = "dm";
            FilterDM.Dock = DockStyle.Fill;
            FilterDM.AppendedMenu = WinFormHelper.GetContextMenuStrip(menuNames, dispTexts, eventNames);
        }
        /// <summary>
        /// 获取窗体中数据管理控件的配置信息
        /// </summary>        
        private static DataControlParams GetFilterControlParams()
        {
            string[] remove = new string[] { tb_Rules._.Remark.Description };
            Dictionary<string, string[]> bandingSource = new Dictionary<string, string[]>();
            bandingSource.Add(tb_Rules._.IndexSelectorNameTP, LotTickHelper.GetAllIndexFuncNames());
            bandingSource.Add(tb_Rules._.CompareRuleNameTP, LotTickHelper.GetAllEnumNames<ECompareType>());
            DataControlParams CP = new DataControlParams(LabAssemblyName, typeof(tb_Rules), remove, bandingSource,
               "LotteryTicketSoft.GraphForm.AddRules");
            CP.IsEnablePaging = false;
            //TODO:需要把菜单、名称、都包括进去，省略SetFilterDM方法，直接初始化得到窗体
            return CP;
        }
        #endregion

        #region 其他功能--数据更新，关于
        /// <summary>
        /// 异步调用，更新数据
        /// </summary>        
        private void 更新最近ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = Task.Factory.StartNew(() =>
            {
                TwoColorBall.UpdateRecent();
                MessageBox.Show("近期数据更新成功", "任务提示");//可以考虑其他地方显示该信息
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
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm.CreateForm().ShowDialog();
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm tf = new TestForm();
            tf.Show();
        }
        #endregion       
    }
}