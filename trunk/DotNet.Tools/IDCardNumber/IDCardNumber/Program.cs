using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Maticsoft.DBUtility;
using System.Data.SQLite ;
using System.Data ;

namespace DotNet.Tools.IDCardNumber
{
    class Program
    {
        static void Main(string[] args)
        {            
            DbHelperMySQL.connectionString = "Server=localhost;Database=areacode;Uid=root;Pwd=111;oldsyntax=true;charset='utf8'";//192.168.1.5
            ConvertToSqliteDB () ;
            
            Console.WriteLine("所有完成");
            Console.ReadLine();
        }
        
        public static void ConvertToSqliteDB()
        {
        	Model.areacodetable model = new DotNet.Tools.IDCardNumber.Model.areacodetable () ;
            BLL.areacodetable bll = new DotNet.Tools.IDCardNumber.BLL.areacodetable();//D:\我的文档\桌面\Sqlite System.Environment.CurrentDirectory
            DataTable dt = bll.GetAllList().Tables[0];
            string code = "" ;
            string path = @"Data Source ="+System.Environment.CurrentDirectory+@"\AreaCodeDB.db3" ;
            SQLiteConnection conn  = new SQLiteConnection (path );
            conn.Open () ;
            SQLiteCommand cmd = conn.CreateCommand () ;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
            	code = dt.Rows[i]["AreaCode"].ToString().Trim();
            	model = bll.GetModel(code);
                cmd.CommandText = @"insert into `tb_AreaCode` (`FullName`,`ShortName`,`AreaCode`,`UpdateTime`) VALUES " +
                    " ('" + model.FullName + "','" + model.ShortName + "','" + model.AreaCode + "','" + model.UpdateTime + "')";
                //cmd.CommandText="select * from tb_AreaCode" ;
            	cmd.ExecuteNonQuery () ;
            	Console.WriteLine (model.AreaCode.ToString () ) ;
            }
            conn.Close () ;
            Console.WriteLine ("OK!") ;
        }
    }
}
