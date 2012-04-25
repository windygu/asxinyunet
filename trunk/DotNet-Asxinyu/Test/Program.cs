using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode;
using XCode.DataAccessLayer;
using NewLife.Security;
using XCode.Configuration;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CopyDataBase("Common", "Common3");
        }
        #region 拷贝数据库
        /// <summary>
        /// 拷贝数据库，只需要数据库连接字符串和源数据库即可
        /// </summary>
        /// <param name="originConn">源数据库连接字符串</param>
        /// <param name="desConn">目的数据库连接字符串</param>
        public static void CopyDataBase(string originConn, string desConn)
        {
            //思路：通过源数据库获取架构信息，然后反向工程
            //然后批量导出数据
            DAL dal = DAL.Create(originConn);
            List<IDataTable> tableList = dal.Tables;//获取源数据库的架构信息
            tableList.RemoveAll(t => t.IsView);//过滤掉视图
            //首先拷贝数据库架构            
            DAL desDal = DAL.Create(desConn);//要在配置文件中启用数据库架构才行 
            //desDal.Db.CreateMetaData().SetTables(tableList.ToArray ());               
            //然后依次拷贝每个表中的数据
            foreach (var item in tableList)
            {
                //首先根据表名称获取当前表的实体操作接口
                IEntityOperate Factory = dal.CreateOperate(item.Name);               
                IEntityList modelList = Factory.FindAll();
                Factory.ConnName = desConn;
                modelList.Insert(true);
            }
        }
        #endregion
    }
}
