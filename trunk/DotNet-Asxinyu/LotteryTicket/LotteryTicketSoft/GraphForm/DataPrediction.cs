using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.WinForm.Controls;
using DotNet.WinForm;
using LotTick;

namespace LotteryTicketSoft.GraphForm
{
    public partial class DataPrediction : DotNet.WinForm.Controls.DataManage 
    {     
        /// <summary>
        /// 创建数据管理窗体
        /// </summary>
        /// <param name="controlParams">控件参数</param>
        /// <returns>数据管理控件的窗体</returns>
        public static FormModel CreateForm2(DataControlParams controlParams)
        {
            DataPrediction dm = new DataPrediction();
            dm.InitializeSettings(controlParams);
            dm.Name = "dm";
            dm.Dock = DockStyle.Fill;
            FormModel tf = new FormModel();
            tf.Size = new Size(dm.Width + 15, dm.Size.Height + 40);
            tf.Controls.Add(dm);//将控件添加到窗体中            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            return tf;
        }
        private TwoColorBall twoColorBall;
        /// <summary>
        /// 配置右键菜单
        /// </summary>
        public override void InitialDgvMenu()
        {
            //配置菜单,这一功能提供让在基类中实现,提供基本的增删查改等常规菜单代码
            if (ControlParams.IsHaveMenu)
            {
                //dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                //        new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
                //        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });

                dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                        new string[] { "Edit", "Delete", "Validate", "CrossValidate", "Filter" }, new string[] {
                            "修改", "删除", "验证", "交叉验证", "过滤" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click,
                        toolStripStatics_Click,toolStripCrossValidate_Click,toolStripFilter_Click});
            }             
        }

        #region 右键菜单事件
        #region 获取规则列表
        public RuleInfo[] GetRuleList()
        {
            List<RuleInfo> rules = new List<RuleInfo>();
            //RuleInfo[] rules = new RuleInfo[dgv.Rows.Count];
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                //先得到一个tb_Rules对象,直接从数据库读取,因为是实时更新
                tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
                //再根据ruleMode判断规则类别，调用相应的方法进行计算   
                if (ruleMode.Enable)//可用才添加
                {
                    CompareParams ruleParams = new CompareParams(ruleMode.RuleCompareParams);//参数
                    rules.Add(new RuleInfo(ruleMode.IndexSelectorNameTP, ruleMode.CompareRuleNameTP,
                        ruleParams, ruleMode.Id, 0, ruleMode.NeedRows));
                }
            }
            return rules.ToArray();
        }
        #endregion

        #region 交叉验证
        private void toolStripCrossValidate_Click(object sender, EventArgs e)
        {
            bool[][] result = twoColorBall.ValidateRuleList(GetRuleList());
            //结果显示
            int count = 0;
            for (int i = 0; i < result[0].Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (!result[j][i]) flag = true;
                }
                if (!flag)
                    count++;
            }
            double t = ((double)count) / (double)result[0].Length;
            this.stausInfoShow1.SetToolInfo2("交叉验证概率(%):" + (t * 100).ToString("F4"));
        }
        #endregion

        #region 右键预测与过滤
        //右键预测验证频率
        private void toolStripStatics_Click(object sender, EventArgs e)
        {
            //验证
            bool[][] result = twoColorBall.ValidateRuleList(GetRuleList());
            //对结果进行统计
            double[] res = result.Select(n => ((double)n.Where(k => k).Count() / (double)n.Count())).ToArray();
            for (int i = 0; i < res.Length; i++) dgv.Rows[i].Cells[6].Value = res[i].ToString("F4");
            //bool[][] reverse = new bool[result[0].Length][];
            //for (int i = 0; i < reverse.GetLength (0); i++)
            //{
            //    reverse[i] = new bool[result.GetLength(0)];
            //    for (int j = 0; j < reverse[i].Length ; j++)
            //    {
            //        reverse[i][j] = result[j][i];
            //    }
            //}
            //int[] Temp = reverse.Select (n => n.Where(k => k).Count()).ToArray();
        }
        //右键过滤
        private void toolStripFilter_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dic;
            LotTickData[] result = twoColorBall.FilteByRuleList(GetRuleList(), out dic);
            //过滤结果写入数据库，并刷新
            foreach (var item in dic)
            {
                tb_Rules temp = tb_Rules.FindById(item.Key);
                temp.FilterInfo = item.Value;
                temp.Update();
            }
            GetData();
        }
        #endregion
        #endregion
    }
}