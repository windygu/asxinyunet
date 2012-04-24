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
            //不用实体来操作数据库Demo
            DAL dal = DAL.Create("Common");
            IEntityOperate entity = dal.CreateOperate("Administrator");
            for (int i = 0; i < 1000; i++)
            {
                IEntity model = entity.Create();
                FieldItem[] filds = entity.Fields;
                int fildsCount = filds.Count();
                for (int j = 0; j < fildsCount; j++)
                {
                    if (!filds[j].IsIdentity)
                    {
                        model.SetItem(filds[j].Name, 32);
                    }
                }
            }           
        }
    }
}
