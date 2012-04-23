using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XCode;
using NewLife.CommonEntity;
using XCode.DataAccessLayer;
using NewLife.Security;


namespace NewLifeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tb_Ssq ssq = new tb_Ssq();
            ssq.期号 = 20120325;
            ssq.开奖日期 = new DateTime(2012, 3, 25);
            ssq.号码1 = 1;
            ssq.号码2 = 5;
            ssq.号码3 = 8;
            ssq.号码4 = 15;
            ssq.号码5 = 24;
            ssq.号码6 = 30;
            ssq.蓝球 = 9;
            ssq.Insert();

            //List<IDataTable> list = new List<IDataTable>();
            //list.Add (Administrator.Meta.Table.DataTable);
            //list.Add(Area.Meta.Table.DataTable);
            //list.Add(Category.Meta.Table.DataTable);
            //DAL dal = DAL.Create("Common");
            //dal.CheckTables(list);
            //Administrator user = new Administrator();
            //user.Name = "admin";
            //user.Password = DataHelper.Hash("admin");
            //user.DisplayName = "超级管理员";
            //user.RoleID = 1;
            //user.IsEnable = true;
            //user.Insert();
        }
    }
}