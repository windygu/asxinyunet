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
                    //Console.WriteLine("表:{0}的第{1} 条记录插入完成！",tableList[t].Name ,i);
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
                for (int i = 0; i < NeedCount; i++)
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
    }
}