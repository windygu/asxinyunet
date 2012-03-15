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
using NewLife.Configuration;
using LotTick;
using System.Threading.Tasks;
using System.Collections;

namespace LotteryTicketSoft.GraphForm
{
    /// <summary>
    /// 集成通用管理窗体，完成更丰富的数据操作功能
    /// </summary>
    public partial class DataPrediction : DotNet.WinForm.Controls.DataManage
    {
        #region 构造函数
        public DataPrediction()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region 创建数据管理窗体
        /// <summary>
        /// 创建数据管理窗体,需要重新写
        /// </summary>
        /// <param name="controlParams">控件参数</param>
        /// <returns>数据管理控件的窗体</returns>
        public static FormModel CreateForm2(DataControlParams controlParams)
        {
            //默认的集成不能完成，需要修改生成的主窗体
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
        #endregion

        #region 配置右键菜单
        private TwoColorBall twoColorBall;
        /// <summary>
        /// 配置右键菜单
        /// </summary>
        public override void InitialDgvMenu()
        {            
            //配置菜单,这一功能提供让在基类中实现,提供基本的增删查改等常规菜单代码
            if (ControlParams.IsHaveMenu)
            {
                string[] menuNames = { "Edit", "Delete", "CrossValidate", "Filter", "Remove", "SaveProject" };
                string[] dispTexts = { "修改记录", "删除记录", "交叉验证", "过滤", "移除记录", "保存方案" };
                EventHandler[] eventNames ={ toolStripMenuEdit_Click,//修改
                                               toolStripMenuDelete_Click,//删除
                        toolStripCrossValidate_Click,//交叉验证
                        toolStripFilter_Click,//过滤
                        toolStripRemove_Click,//移除记录
                        toolStripSaveProject_Click}; //保存方案
                dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(menuNames ,dispTexts ,eventNames );
            }
        }
        #endregion
     
        #region 右键菜单事件
        #region 获取规则列表
        /// <summary>
        /// 获取当前dgv中的规则列表
        /// </summary>
        /// <returns></returns>
        public RuleInfo[] GetRuleList()
        {            
            List<RuleInfo> rules = new List<RuleInfo>();           
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
        #endregion

        #region 交叉验证
        /// <summary>
        /// 交叉验证功能:几个规则同时进行验证，准确率在下方状态显示，也包括了单独的验证
        /// </summary>
        private void toolStripCrossValidate_Click(object sender, EventArgs e)
        {
            if (twoColorBall ==null )
                twoColorBall = new TwoColorBall(Config.GetConfig<int>("CalculateRows"));
            var t = Task.Factory.StartNew (()=>
            {
                bool[][] result = twoColorBall.ValidateRuleList(GetRuleList());
                double[] res = result.Select(n => ((double)n.Where(k => k).Count() / (double)n.Count())).ToArray();
                for (int i = 0; i < res.Length; i++) dgv.Rows[i].Cells[6].Value = res[i].ToString("F4");
                this.stausInfoShow1.SetToolInfo2("交叉验证概率(%):" +
                    (TwoColorBall.CrossValidate(result) * 100).ToString("F4"));
            });
        }
        #endregion

        #region 右键预测与过滤
        //右键过滤
        private void toolStripFilter_Click(object sender, EventArgs e)
        {
            if (twoColorBall == null)
                twoColorBall = new TwoColorBall(Config.GetConfig<int>("CalculateRows"));
            var t = Task.Factory.StartNew(()=>
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
            });           
        }
        #endregion

        #region 移除记录
        private void toolStripRemove_Click(object sender, EventArgs e)
        {
            var t = btList.Find(tb_Rules._.Id, this.dgv[0, this.dgv.CurrentCell.RowIndex].Value );
            //直接在dgv中删除
            this.btList.Remove(t );
            ArrayList list = new ArrayList();
            for (int i = 0; i < btList.Count; i++) list.Add(btList[i]);//需要转换一下才行
            dgv.DataSource = list;
            this.dgv.DataSource = list ;
        }
        #endregion

        #region 保存方案数据
        private void toolStripSaveProject_Click(object sender, EventArgs e)
        {
            //TODO:注意文件名称的处理
            if (SaveFileDialog.ShowDialog ()== DialogResult.OK )
            {
                RuleInfo[] rules = GetRuleList();
                TwoColorBall.SaveProjectData(rules,SaveFileDialog.FileName  , false);
                MessageBox.Show("导出方案成功", "提示");
            }            
        }
        #endregion
        #endregion
    }
}