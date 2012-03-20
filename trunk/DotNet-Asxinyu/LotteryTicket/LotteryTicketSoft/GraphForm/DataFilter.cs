using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using LotTick;
using System.Windows.Forms;
using DotNet.WinForm.Controls ;
using System.Threading.Tasks;

namespace LotteryTicketSoft.GraphForm
{
    /// <summary>
    /// 过滤控件，过滤会有相关设置，和保存，做到一个界面，方便
    /// TODO:数据显示，分页
    /// </summary>
    public partial class DataFilter : UserControl
    {
        public DataFilter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 所有的规则，用来过滤
        /// </summary>
        public RuleInfo[] AllRules { get; set; }
        private LotTickData[] data { get; set; }
        /// <summary>
        /// 返回一个本控件的窗体
        /// </summary>
        public static FormModel CreateForm(RuleInfo[] rules)
        {
            DataFilter dm = new DataFilter();
            dm.AllRules = rules;           
            dm.Dock = DockStyle.Fill;
            FormModel tf = new FormModel();
            tf.Size = new Size(dm.Width + 15, dm.Size.Height + 40);
            tf.Controls.Add(dm);//将控件添加到窗体中            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            return tf;           
        }        
        //过滤计算
        private void btnOK_Click(object sender, EventArgs e)
        {
            data = FilterData(AllRules ); //获取过滤后的数据
        }

        private static LotTickData[] FilterData(RuleInfo[] rules)
        {          
            Dictionary<int, string> dic;
            LotTickData[] result = TwoColorBall.FilteByRuleList(rules, out dic);
            //过滤结果写入数据库，并刷新
            foreach (var item in dic)
            {
                tb_Rules temp = tb_Rules.FindById(item.Key);
                temp.FilterInfo = item.Value;
                temp.Update();
            }
            return result;           
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        private void formPager_PageIndexChanged(object sender, EventArgs e)
        {
            if (data == null)
                return;
            else
            {

            }
        }
    }
}
