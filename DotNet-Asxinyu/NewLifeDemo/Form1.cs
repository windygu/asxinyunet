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
            Administrator user = new Administrator();
            user.Name = "admin";
            user.Password = NewLife.Security.DataHelper.Hash("admin");
            user.DisplayName = "管理员";
            user.RoleID = 1;
            user.IsEnable = true;
            user.Insert();
        
        }
    }
}
