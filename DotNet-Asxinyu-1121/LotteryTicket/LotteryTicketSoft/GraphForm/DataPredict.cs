/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 9:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DotNet.Tools;
using LotteryTicket;
using System.Linq;
using System.Data;
using DotNet.Tools.Controls;

namespace LotteryTicketSoft.GraphForm
{
    /// <summary>
    /// 数据预测窗体
    /// </summary>
    public partial class DataPredict : Form
    {
        public DataPredict()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void DataPredict_Load(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                        new string[] { "Edit", "Delete" }, new string[] { "修改", "保存数据","过滤数据","计算当期规则","计算所有" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
            LotteryTicket.Rule rule = new LotteryTicket.Rule(IndexCalculate.Index_Ac值, CompareType.Equal, 2, 3,
                new int[] { 1, 2, 3, 4, 5 });
            LotteryTicket.Rule[] rules = new LotteryTicket.Rule[1];
            rules[0] = rule;
            LotTicketHelper.RulesToDgv(rules, dataGridView1);
        }
   
        #region  菜单事件
        private void toolStripMenuEdit_Click(object sender, EventArgs e)
        {
            flag = true;
            dataGridView1.BeginEdit(false);
        }
        private void toolStripMenuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag )
                {
                    flag = false;
                    //将规则数组保存到二进制序列中
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("出错:" + err.Message);
            }
        }
        #endregion    
    }
}