/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-02 15:13:27
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;

namespace CustomerEntity
{
	/// <summary>
	/// 公司基本信息及联系信息
	/// </summary>
	public partial class tb_companyinfo : Entity<tb_companyinfo>
	{
		#region 对象操作
		//基类Entity中包含三个对象操作：Insert、Update、Delete
		//你可以重载它们，以改变它们的行为
		//如：
		/*
		/// <summary>
		/// 已重载。把该对象插入到数据库。这里可以做数据插入前的检查
		/// </summary>
		/// <returns>影响的行数</returns>
		public override Int32 Insert()
		{
			return base.Insert();
		}
		 * */
		#endregion
		
		#region 扩展属性
		// 本类与哪些类有关联，可以在这里放置一个属性，使用延迟加载的方式获取关联对象

		/*
		private Category _Category;
		/// <summary>该商品所对应的类别</summary>
        [XmlIgnore]
		public Category Category
		{
			get
			{
				if (_Category == null && CategoryID > 0 && !Dirtys.ContainsKey("Category"))
				{
					_Category = Category.FindByKey(CategoryID);
					Dirtys.Add("Category", true);
				}
				return _Category;
			}
			set { _Category = value; }
		}
		 * */
		#endregion

		#region 扩展查询
		/// <summary>
		/// 根据主键查询一个公司基本信息及联系信息实体对象用于表单编辑
		/// </summary>
		///<param name="__CompanyName">公司名称</param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static tb_companyinfo FindByKeyForEdit(String __CompanyName)
		{
			tb_companyinfo entity=Find(new String[]{_.CompanyName}, new Object[]{__CompanyName});
			if (entity == null)
			{
				entity = new tb_companyinfo();
			}
			return entity;
		}     
		#endregion

		#region 高级查询
		/// <summary>
		/// 查询满足条件的记录集，分页、排序
		/// </summary>
		/// <param name="key">关键字</param>
		/// <param name="orderClause">排序，不带Order By</param>
		/// <param name="startRowIndex">开始行，0表示第一行</param>
		/// <param name="maximumRows">最大返回行数，0表示所有行</param>
		/// <returns>实体集</returns>
		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public static EntityList<tb_companyinfo> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		{
		    return FindAll(SearchWhere(key), orderClause, null, startRowIndex, maximumRows);
		}

		/// <summary>
		/// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
		/// </summary>
		/// <param name="key">关键字</param>
		/// <param name="orderClause">排序，不带Order By</param>
		/// <param name="startRowIndex">开始行，0表示第一行</param>
		/// <param name="maximumRows">最大返回行数，0表示所有行</param>
		/// <returns>记录数</returns>
		public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		{
		    return FindCount(SearchWhere(key), null, null, 0, 0);
		}

		/// <summary>
		/// 构造搜索条件
		/// </summary>
		/// <param name="key">关键字</param>
		/// <returns></returns>
		private static String SearchWhere(String key)
		{
			if (String.IsNullOrEmpty(key)) return null;
			key = key.Replace("'", "''");
			String[] keys = key.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < keys.Length; i++)
			{
				if (sb.Length > 0) sb.Append(" And ");

				if (keys.Length > 1) sb.Append("(");
				Int32 n = 0;
				foreach (FieldItem item in Meta.Fields)
				{
					if (item.Property.PropertyType != typeof(String)) continue;
					// 只要前五项
					if (++n > 5) break;

					if (n > 1) sb.Append(" Or ");
					sb.AppendFormat("{0} like '%{1}%'", Meta.FormatKeyWord(item.Name), keys[i]);
				}
				if (keys.Length > 1) sb.Append(")");
			}

			return sb.ToString();
		}
		#endregion

		#region 扩展操作
		#endregion

		#region 业务
		#endregion
	}
}