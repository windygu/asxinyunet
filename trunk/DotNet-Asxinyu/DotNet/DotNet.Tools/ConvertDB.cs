using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.WinForm.Controls ;
using DotNet.Core.Commons;

namespace DotNet.Tools
{
    public partial class ConvertDB : UserControl
    {
        public ConvertDB()
        {
            InitializeComponent();
        }

        public static FormModel CreateForm()
        {
            return DotNet.WinForm.WinFormHelper.GetControlForm(new ConvertDB(), "数据库数据转换");
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            string[] origin = txtOrigin.Text.Trim().Split("-");
            string[] des = txtDes.Text.Trim().Split("-");
            List<String> tables = new List<string>();
            string[] temp = txtAllTables.Text.Trim().Split(";");
            foreach (var item in temp)
            {
                if (item != "")
                {
                    tables.Add(item);
                }
            }
            try
            {
                int res = DbHelper.CopyDbData(origin[1], origin[0], des[1], des[0], true, tables);
                MessageBox.Show("成功导出");
            }
            catch (Exception err)
            {
                MessageBox.Show("导出失败:" + err.Message);
            }
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
             string[] origin = txtOrigin.Text.Trim().Split("-");
             List<string> tableNames = DbHelper.GetAllTableByConn(origin[1], origin[0]);
             string text = "";
             foreach (var item in tableNames )
             {
                 text += (item + ";");
             }
             txtAllTables.Text = text;
        }
    }
}
