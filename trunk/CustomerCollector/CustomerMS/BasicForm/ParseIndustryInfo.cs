using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerCollector;
using CustomerEntity;
using HtmlAgilityPack;
using NewLife;
using XCode;
using NewLife.Reflection;
using XCode.DataAccessLayer;
using CustomerMS.CustomerControl ;


namespace CustomerMS.BasicForm
{
    public partial class ParseIndustryInfo : Form
    {
        public ParseIndustryInfo()
        {
            InitializeComponent();
        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            //解析并添加到数据库            
            AlibabaInfo.GetIndustryList(txtIndustry.Text.Trim());           
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}