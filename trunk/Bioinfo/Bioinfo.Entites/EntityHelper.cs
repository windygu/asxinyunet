using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using XCode;

namespace Bioinfo.Entites
{

    public class EntityHelper
    {
        public static string GetName()
        {
            //Initial_Setting();
            string s = Setting.FindById(1).Value;
            return s;
        }

        public static List<ListItem> GetCategoryList(int parentId)
        {
            List<ListItem> lc = new List<ListItem>();
            var list = Category.FindAllChildsNoParent (parentId );
            if (list != null && list.Count > 0)
            {
                foreach (Bioinfo.Entites.Category item in list)
                {
                    String spaces = new String('　', item.Deepth);
                    lc.Add(new ListItem(spaces + "|- " + item.Name, item.Id.ToString()));
                }
            }
            return lc;
        }

        #region 废弃代码
        //public static List<ListItem> GetListCollectionById(int parentId, string typeName, string sortName)
        //{
        //    IEntityOperate op = EntityFactory.CreateOperate(typeName);
        //    List<ListItem> lc = new List<ListItem>();
        //    var list = op.FindAll("", sortName + " asc", null, 0, 0);
        //    if (list != null && list.Count > 0)
        //    {
        //        foreach (Bioinfo.Entites.Category item in list)
        //        {
        //            String spaces = new String('　', item.Deepth);
        //            lc.Add(new ListItem(spaces + "|- " + item.Name, item.Id.ToString()));
        //        }
        //    }
        //    return lc;
        //}
        #endregion

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public static void InitialDb()
        {
            Initial_Category();
            Initial_Setting();
        }
        /// <summary>
        /// 设置类别表
        /// </summary>
        static void Initial_Category()
        {
            new Category { ParentId = 0, Name = "新闻类别", Sort = 10 }.Insert();
            new Category { ParentId = 0, Name = "设置类别", Sort = 11 }.Insert();

            new Category { ParentId = 1, Name = "行业新闻", Sort = 20 }.Insert();
            new Category { ParentId = 1, Name = "科研团队", Sort = 21 }.Insert();
            new Category { ParentId = 1, Name = "资源下载", Sort = 23 }.Insert();
            new Category { ParentId = 1, Name = "其他辅助", Sort = 24 }.Insert();

            new Category { ParentId = 2, Name = "前台文本", Sort = 31 }.Insert();
            new Category { ParentId = 2, Name = "预测平台", Sort = 33 }.Insert();
            new Category { ParentId = 2, Name = "系统配置", Sort = 34 }.Insert();
        }   

        static void Initial_Setting()
        {
            new Setting
            {
                CategoryId = 2,
                CodeType = 1,
                Name = "Home_p1",
                Sort = 10,
                Value =
                    "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>"
            }.Insert ();
        }        
    }
}
