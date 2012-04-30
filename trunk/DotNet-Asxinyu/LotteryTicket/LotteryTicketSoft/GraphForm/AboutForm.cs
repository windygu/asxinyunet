using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LottAnalysis.GraphForm
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        public static AboutForm af;
        /// <summary>
        /// 得到关于窗体
        /// </summary>        
        public static AboutForm CreateForm()
        {
            if (af == null)
                af = new AboutForm();
            return af;
        }
    }
}
