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

namespace LotteryTicketSoft.GraphForm
{
    /// <summary>
    /// 过滤控件，过滤会有相关设置，和保存，做到一个界面，方便
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
            
        }
    }
}
