using System;
using System.Collections.Generic;
using System.Linq;
using XCode;
using XCode.DataAccessLayer;
using XCode.Configuration;


namespace DotNet.Core.Commons
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DbHelper
    {
        #region 废弃版本
        /// <summary>
        /// 需要插入的数据条数
        /// </summary>
        private static int NeedCount = 5;

        /// <summary>
        /// 随机填充指定数据库连接字符串中的所有表:废弃，最初版本
        /// </summary>
        /// <param name="connStr">数据库连接字符串</param>
        private static void FillDataForDb_2(string connStr)
        {
            DAL dal = DAL.Create(connStr);//根据数据库连接字符串创建数据访问对象
            List<IDataTable> tableList = dal.Tables;//获取数据库的所有表和架构信息
            tableList.RemoveAll(t => t.IsView);//过滤掉视图
            for (int t = 0; t < tableList.Count ; t++)//然后注意循环
            {
                //首先根据表名称获取当前表的实体操作接口
                IEntityOperate entity = dal.CreateOperate(tableList[t].Name );
                for (int i = 0; i < NeedCount; i++)
                {
                    IEntity model = entity.Create();//创建数据实体接口
                    FieldItem[] filds = entity.Fields;//获取所有的字段信息
                    int fildsCount = filds.Count();
                    //依次循环设置每个字段的值
                    for (int j = 0; j < fildsCount; j++)
                    {
                        if (!filds[j].IsIdentity)
                        {
                            model.SetItem(filds[j].Name,GetRandomValue (filds [j]));
                        }
                    }
                    model.Save();                   
                    //
                }
            }
        }
        #endregion

        #region 随机填充数据库
        /// <summary>
        ///  随机填充指定数据库连接字符串中的所有表
        /// </summary>
        /// <param name="connStr">数据库连接字符串</param>
        /// <param name="needCount">填充的记录数目</param>
        public static void FillDataForDb(string connStr, int needCount = 50)
        {
            DAL dal = DAL.Create(connStr);//根据数据库连接字符串创建数据访问对象
            List<IDataTable> tableList = dal.Tables;//获取数据库的所有表和架构信息
            tableList.RemoveAll(t => t.IsView);//过滤掉视图
            foreach (var item in tableList)
            {
                //首先根据表名称获取当前表的实体操作接口
                IEntityOperate entity = dal.CreateOperate(item.Name);
                for (int i = 0; i < needCount; i++)
                {
                    IEntity model = entity.Create();//创建数据实体接口
                    FieldItem[] filds = entity.Fields;//获取所有的字段信息
                    foreach (var fild in entity.Fields)
                    {
                        if (!fild.IsIdentity)
                            model.SetItem(fild.Name, GetRandomValue(fild));
                    }                    
                    model.Save();//保存数据
                }
                Console.WriteLine("数据表{0} 数据插入完成！",item.Name );
            }
        }

        /// <summary>
        /// 根据字段类型和长度获取对应类型的随机数据
        /// </summary>
        /// <param name="fild">字段对象</param>
        /// <returns>对应的随机数据</returns>
        public static object GetRandomValue(FieldItem fild)
        {            
            switch (Type.GetTypeCode(fild.Field.DataType))
            {
                case TypeCode.Boolean: return RandomHelper.GetRandomBool();
                case TypeCode.Byte:return RandomHelper.GetRandomByte();
                case TypeCode.Char:return RandomHelper.GetRandomChar();                
                case TypeCode.DateTime:return RandomHelper.GetRandomDateTime();
                case TypeCode.Decimal:return RandomHelper.GetRandomDouble(0, NeedCount*10.1);
                case TypeCode.Double:return RandomHelper.GetRandomDouble(0, NeedCount*10.1);               
                case TypeCode.Int16:return RandomHelper.GetRandomInt(1,UInt16.MaxValue );                   
                case TypeCode.Int32:return RandomHelper.GetRandomInt(1,NeedCount *50);      
                case TypeCode.Int64:return RandomHelper.GetRandomInt(1,NeedCount*100);                                    
                case TypeCode.SByte:return RandomHelper.GetRandomInt(1,127); 
                case TypeCode.Single:return RandomHelper.GetRandomDouble(0, NeedCount*10.1);
                case TypeCode.String:return RandomHelper.GetRandomString((int )(fild.Length*RandomHelper.GetRandomDouble (0.2,0.7)));
                case TypeCode.UInt16:return RandomHelper.GetRandomInt(1,UInt16.MaxValue );                     
                case TypeCode.UInt32:return RandomHelper.GetRandomInt(1,NeedCount *50);                          
                case TypeCode.UInt64:return RandomHelper.GetRandomInt(1,NeedCount*100);
                default:
                    return string.Empty;
            }
        }
        #endregion

        #region 拷贝数据库
        /// <summary>
        /// 拷贝数据库，只需要数据库连接字符串和源数据库即可
        /// </summary>
        /// <param name="originConn">源数据库连接字符串</param>
        /// <param name="desConn">目的数据库连接字符串</param>
        /// <param name="perCount">每次获取的记录数目，如果默认-1则会自动调用函数计算一个合理值</param>
        public static void CopyDataBase(string originConn,string desConn,int perCount = -1)
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
                int allCount = Factory.FindCount ();
                if (perCount < 0) perCount = GetDataRowsPerConvert (allCount );
                //int pages = (int)Math.Ceiling ((double)((double )allCount/(double )perCount));
                int curPage = 0 ;
                while (curPage *perCount <allCount )//改用while循环分页获取数据
                {
                    Factory.ConnName = originConn;
                    //Factory.AllowInsertIdentity = true;
                    IEntityList modelList = Factory.FindAll("","","",curPage*perCount , perCount);
                    Factory.ConnName = desConn;
                    modelList.Insert(true);
                    curPage++;
                }             
                Console.WriteLine("数据库{0} 数据转移完成！",item.Name );
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

        #region 备份数据库
        public static void BackupDataBase(string connStr, string fileName, bool isOnlyDbSchema = true )
        {
            //思路：利用拷贝数据库功能,将数据库拷贝到Sqlite中，因为这是一个文件，方便
            
        }
        #endregion

        #region 还原数据库

        #endregion
    }
}