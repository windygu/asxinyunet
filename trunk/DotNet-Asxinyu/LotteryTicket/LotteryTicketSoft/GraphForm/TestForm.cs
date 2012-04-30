using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XCode;
using LotTick;

namespace LottAnalysis.GraphForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            this.winGridViewPager1.OnPageChanged += new EventHandler(Onload ); 
        }
        private void Onload(object sender, EventArgs e)
        {
            this.winGridViewPager1.DataSource = tb_Ssq.FindAll();
        }
    }
}