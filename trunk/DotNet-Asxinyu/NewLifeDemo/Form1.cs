using System;
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
            //不用实体来操作数据库Demo
            DAL dal = DAL.Create("Common");
            IEntityOperate entity = dal.CreateOperate("Administrator");
            for (int i = 0; i < 1000; i++)
			{
			    IEntity model = entity.Create();
                FieldItem[] filds = entity.Fields ;
                int fildsCount = filds.Count() ;
                for (int j = 0; j <fildsCount ; j++)
                {
                    if (!filds[j].IsIdentity)
                    {
                        model.SetItem(filds[j].Name, 32);
                    }
                }
			}            
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