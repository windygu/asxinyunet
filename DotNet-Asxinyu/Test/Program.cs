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
            //CopyDataBase("Common", "CommonSqlite");
            //CopyDataBase("CommonSqlite", "Common3");
            CopyDataBase("Common3", "CommonSqlite");
        }
        #region 拷贝数据库
        /// <summary>
        /// 拷贝数据库，只需要数据库连接字符串和源数据库即可
        /// </summary>
        /// <param name="originConn">源数据库连接字符串</param>
        /// <param name="desConn">目的数据库连接字符串</param>
        /// <param name="perCount">每次获取的记录数目，如果默认-1则会自动调用函数计算一个合理值</param>
        public static void CopyDataBase(string originConn, string desConn, int perCount = -1)
        {
            //思路：通过源数据库获取架构信息，然后反向工程,然后导出数据            
            DAL dal = DAL.Create(originConn);
            List<IDataTable> tableList = dal.Tables;//获取源数据库的架构信息
            tableList.RemoveAll(t => t.IsView);//过滤掉视图
            //首先拷贝数据库架构            
            DAL desDal = DAL.Create(desConn);//要在配置文件中启用数据库架构才行 
            desDal.Db.CreateMetaData().SetTables(tableList.ToArray());
            //然后依次拷贝每个表中的数据
            foreach (var item in tableList)
            {
                //首先根据表名称获取当前表的实体操作接口
                IEntityOperate Factory = dal.CreateOperate(item.Name);
                //分页获取数据，并更新到新的数据库，通过更改数据库连接来完成
                int allCount = Factory.FindCount();
                if (perCount < 0) perCount = GetDataRowsPerConvert(allCount);
                //int pages = (int)Math.Ceiling ((double)((double )allCount/(double )perCount));
                int curPage = 0;
                while (curPage * perCount < allCount)//改用while循环分页获取数据
                {
                    Factory.ConnName = originConn;
                    IEntityList modelList = Factory.FindAll("", "", "", curPage * perCount, perCount);
                    Factory.ConnName = desConn;
                    modelList.Insert(true);
                    curPage++;
                }
                //for (int i = 0; i < pages ; i++)
                //{
                //    Factory.ConnName = originConn;
                //    IEntityList modelList = Factory.FindAll("","","",i * perCount, perCount);
                //    Factory.ConnName = desConn;
                //    modelList.Insert(true);
                //}
                Console.WriteLine("数据库{0} 数据转移完成！", item.Name);
            }
        }

        /// <summary>
        /// 根据数据表的记录总数来设置一个合理的每次转换数目。数据量大，一次性导出导入不合理
        /// </summary>
        /// <param name="allCount">数据表记录总数</param>
        /// <returns>每次转换的记录数</returns>
        private static int GetDataRowsPerConvert(int allCount)
        {
            if (allCount < 1000) return 200;
            else if (allCount < 5000) return 500;
            else if (allCount < 50000) return 1000;
            else return 1500;
        }
        #endregion
    }
}
