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
                        new string[] { "Edit", "Delete" }, new string[] { "修改", "保存数据","过滤数据" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
            LotteryTicket.Rule rule = new LotteryTicket.Rule(IndexCalculate.Index_Ac值, CompareType.Equal, 2, 3,
                new int[] { 1, 2, 3, 4, 5 });
            LotteryTicket.Rule[] rules = new LotteryTicket.Rule[1];
            rules[0] = rule;
            RulesToDgv(rules, dataGridView1);
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
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("出错:" + err.Message);
            }
        }
        #endregion

        #region 将Rule数组转换为DataTable显示,并可编辑
        /// <summary>
        /// 将规则类数组转换为DataGridView，便于编辑
        /// </summary>
        public static void RulesToDgv(LotteryTicket.Rule[] rules, DataGridView dgv)
        {
            DataGridViewTextBoxColumn tb = new DataGridViewTextBoxColumn();
            tb.Name = "序号";
            tb.ValueType = typeof(int);
            tb.Width = 80;
            dgv.Columns.Add(tb);

            DataGridViewComboBoxColumn comb = new DataGridViewComboBoxColumn();
            comb.Name = "指标函数";
            comb.Width = 180;
            comb.ValueType = typeof(string);
            comb.DataSource = LotTicketHelper.GetAllIndexNames().Where(n => n.Contains("Index_")).ToList();
            dgv.Columns.Add(comb);

            DataGridViewComboBoxColumn comb2 = new DataGridViewComboBoxColumn();
            comb2.Name = "对比类型";
            comb2.Width = 160;
            comb2.ValueType = typeof(string);
            comb2.DataSource = LotTicketHelper.GetAllEnumNames<CompareType>();
            dgv.Columns.Add(comb2);

            DataGridViewTextBoxColumn tb2 = new DataGridViewTextBoxColumn();
            tb2.Name = "下限";
            tb2.Width = 80;
            tb2.ValueType = typeof(int);
            dgv.Columns.Add(tb2);

            DataGridViewTextBoxColumn tb3 = new DataGridViewTextBoxColumn();
            tb3.Name = "上限";
            tb3.Width = 80;
            tb3.ValueType = typeof(int);
            dgv.Columns.Add(tb3);

            DataGridViewTextBoxColumn tb4 = new DataGridViewTextBoxColumn();
            tb4.Name = "列表范围";
            tb4.Width = 200;
            tb4.ValueType = typeof(string);
            dgv.Columns.Add(tb4);

            dgv.Rows.Add(rules.Length);
            for (int i = 0; i < rules.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = i + 1;
                dgv.Rows[i].Cells[1].Value = rules[i].IndexSelectorName;
                dgv.Rows[i].Cells[2].Value = rules[i].CompareRuleName;
                dgv.Rows[i].Cells[3].Value = rules[i].FloorLimit;
                dgv.Rows[i].Cells[4].Value = rules[i].CeilLimit;
                dgv.Rows[i].Cells[5].Value = rules[i].CompListStr;
            }
        }
        #endregion
    }
}