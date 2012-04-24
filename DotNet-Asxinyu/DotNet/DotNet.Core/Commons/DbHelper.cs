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
        public static void FillDataForDb(string ConnStr,int Count)
        {
            DAL dal = DAL.Create(ConnStr);//根据数据库连接字符串创建数据访问对象
            List<IDataTable> tableList = dal.Tables;//获取数据库的所有表和架构信息
            tableList.RemoveAll(t => t.IsView);//过滤掉视图
            for (int t = 0; t < tableList.Count ; t++)//然后注意循环
            {
                //首先根据表名称获取当前表的实体操作接口
                IEntityOperate entity = dal.CreateOperate(tableList[t].Name );
                for (int i = 0; i < Count ; i++)
                {
                    IEntity model = entity.Create();
                    FieldItem[] filds = entity.Fields;
                    int fildsCount = filds.Count();
                    for (int j = 0; j < fildsCount; j++)
                    {
                        if (!filds[j].IsIdentity)
                        {                            
                            //model.SetItem(filds[j].Name, );
                        }
                    }
                }     
            }
        }
        //public static object GetRandomValue(Type dataType)
        //{
        //    switch (dataType.ToString())
        //    {
        //            case int32
        //        default:
        //            break;
        //    }
        //}
    }
}
