﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XCode;
using XCode.DataAccessLayer;
using NewLife.Security;
using XCode.Configuration;
using NewLife.CommonEntity;

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
            Log log = Log.FindByKey(2008);
            log.IP = "修改后";
            log.Update();
        }

        private void Demo1()
        {
            //反向工程Demo
            //List<IDataTable> list = EntityFactory.GetTables("Common",true );
            //DAL dal = DAL.Create("Common");
            //dal.CheckTables();
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