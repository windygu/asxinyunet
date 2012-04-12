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
    public partial class MainForm
    {
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
            //增加菜单的相关代码
            string[] menuNames = { "CrossValidate", "Filter", "Remove", "SaveProject" };
            string[] dispTexts = { "交叉验证", "过滤", "移除记录", "保存方案" };
            EventHandler[] eventNames ={ toolStripCrossValidate_Click,//交叉验证
                        toolStripFilter_Click,//过滤
                        toolStripRemove_Click,//移除记录
                        toolStripSaveProject_Click}; //保存方案
            //默认的集成不能完成，需要修改生成的主窗体
            DataManage dm = new DataManage();
            dm.InitializeSettings(CP);
            dm.Name = "dm";
            dm.Dock = DockStyle.Fill;
            FormModel tf = new FormModel();
            tf.Size = new Size(dm.Width + 15, dm.Size.Height + 40);
            tf.Controls.Add(dm);//将控件添加到窗体中            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //增加
            dm.AppendedMenu = WinFormHelper.GetContextMenuStrip(menuNames, dispTexts, eventNames);

            tf.MdiParent = this;
            tf.Show();
            //FormModel frm = LotteryTicketSoft.GraphForm.DataPrediction.CreateForm2(CP);
            //frm.MdiParent = this;
            //frm.Show();
        }

    }
}