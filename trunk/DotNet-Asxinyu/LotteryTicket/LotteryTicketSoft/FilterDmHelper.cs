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
    /// 验证过滤菜单辅助方法
    /// </summary>
    public class FilterDmHelper
    {     
        #region 交叉验证
        public static  RuleInfo[] GetRuleList(object sender, EventArgs e)
        {
            List<RuleInfo> rules = new List<RuleInfo>();
            DataGridView dgv = MainForm.FilterDM .dgv ;
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                //先得到一个tb_Rules对象,直接从数据库读取,因为是实时更新
                tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
                //再根据ruleMode判断规则类别，调用相应的方法进行计算
                if (ruleMode.Enable)//可用才添加
                {
                    CompareParams ruleParams = new CompareParams(ruleMode.RuleCompareParams);//参数
                    rules.Add(new RuleInfo(ruleMode.IndexSelectorNameTP, ruleMode.CompareRuleNameTP,
                        ruleParams, ruleMode.Id, Config.GetConfig<int>("CalculateRows"), ruleMode.NeedRows));
                }
            }
            return rules.ToArray();
        }

        /// <summary>
        /// 交叉验证功能:几个规则同时进行验证，准确率在下方状态显示，也包括了单独的验证
        /// </summary>
        public static void toolStripCrossValidate_Click(object sender, EventArgs e)
        {
            TwoColorBall twoColorBall = new TwoColorBall(Config.GetConfig<int>("CalculateRows"));
            var t = Task.Factory.StartNew(() =>
            {
                bool[][] result = twoColorBall.ValidateRuleList(GetRuleList(sender, e));
                double[] res = result.Select(n => ((double)n.Where(k => k).Count() / (double)n.Count())).ToArray();
                for (int i = 0; i < res.Length; i++) MainForm.FilterDM.dgv.Rows[i].Cells[6].Value = res[i].ToString("F4");
                MainForm.FilterDM.stausInfoShow1.SetToolInfo2("交叉验证概率(%):" +
                    (TwoColorBall.CrossValidate(result) * 100).ToString("F4"));
            });
        }
        #endregion

        #region 右键预测与过滤
        //右键过滤
        public static void toolStripFilter_Click(object sender, EventArgs e)
        {
            TwoColorBall twoColorBall = new TwoColorBall(Config.GetConfig<int>("CalculateRows"));
            DataFilter.CreateForm(GetRuleList(sender, e)).ShowDialog();
            MainForm.FilterDM.GetData();
        }
        #endregion

        #region 移除记录
        public static void toolStripRemove_Click(object sender, EventArgs e)
        {
            DataGridView dgv = MainForm.FilterDM.dgv;
            IEntityList btList = MainForm.FilterDM.btList;
            var t = btList.Find(tb_Rules._.Id, dgv[0, dgv.CurrentCell.RowIndex].Value);
            //直接在dgv中删除
            btList.Remove(t);
            ArrayList list = new ArrayList();
            for (int i = 0; i < btList.Count; i++) list.Add(btList[i]);//需要转换一下才行
            dgv.DataSource = list;
        }
        #endregion

        #region 保存方案数据
        public static void toolStripSaveProject_Click(object sender, EventArgs e)
        {
            //TODO:注意文件名称的处理
            //if (((DataManage)sender).SaveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    RuleInfo[] rules = GetRuleList();
            //    TwoColorBall.SaveProjectData(rules, SaveFileDialog.FileName, false);
            //    MessageBox.Show("导出方案成功", "提示");
            //}
        }
        #endregion        
    }
}