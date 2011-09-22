/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-02 15:13:30
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace CustomerEntity
{
	/// <summary>
	/// 公司用户基本信息
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("公司用户基本信息")]
	[BindTable("tb_userinfo", Description = "公司用户基本信息", ConnName = "CustomerEntity")]
	public partial class tb_userinfo : Entity<tb_userinfo>
	{
		#region 属性
		private String _UserName;
		/// <summary>
		/// 用户名
		/// </summary>
		[Description("用户名")]
		[DataObjectField(true, false, false, 30)]
		[BindColumn("UserName", Description = "用户名", DefaultValue = "", Order = 1)]
		public String UserName
		{
			get { return _UserName; }
			set { if (OnPropertyChange("UserName", value)) _UserName = value; }
		}

		private String _CompanyName;
		/// <summary>
		/// 公司名称
		/// </summary>
		[Description("公司名称")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("CompanyName", Description = "公司名称", DefaultValue = "", Order = 2)]
		public String CompanyName
		{
			get { return _CompanyName; }
			set { if (OnPropertyChange("CompanyName", value)) _CompanyName = value; }
		}

		private String _UserType;
		/// <summary>
		/// 用户类型
		/// </summary>
		[Description("用户类型")]
		[DataObjectField(false, false, false, 15)]
		[BindColumn("UserType", Description = "用户类型", DefaultValue = "", Order = 3)]
		public String UserType
		{
			get { return _UserType; }
			set { if (OnPropertyChange("UserType", value)) _UserType = value; }
		}

		private String _CategoryName;
		/// <summary>
		/// 子类目名称
		/// </summary>
		[Description("子类目名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("CategoryName", Description = "子类目名称", DefaultValue = "", Order = 4)]
		public String CategoryName
		{
			get { return _CategoryName; }
			set { if (OnPropertyChange("CategoryName", value)) _CategoryName = value; }
		}

		private String _SubIndustryName;
		/// <summary>
		/// 子行业名称
		/// </summary>
		[Description("子行业名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("SubIndustryName", Description = "子行业名称", DefaultValue = "", Order = 5)]
		public String SubIndustryName
		{
			get { return _SubIndustryName; }
			set { if (OnPropertyChange("SubIndustryName", value)) _SubIndustryName = value; }
		}

		private String _IndustryName;
		/// <summary>
		/// 行业名称
		/// </summary>
		[Description("行业名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("IndustryName", Description = "行业名称", DefaultValue = "", Order = 6)]
		public String IndustryName
		{
			get { return _IndustryName; }
			set { if (OnPropertyChange("IndustryName", value)) _IndustryName = value; }
		}

		private String _RootClassName;
		/// <summary>
		/// 根类别名称
		/// </summary>
		[Description("根类别名称")]
		[DataObjectField(false, false, false, 10)]
		[BindColumn("RootClassName", Description = "根类别名称", DefaultValue = "", Order = 7)]
		public String RootClassName
		{
			get { return _RootClassName; }
			set { if (OnPropertyChange("RootClassName", value)) _RootClassName = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 信息来源
		/// </summary>
		[Description("信息来源")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("InfoOrigin", Description = "信息来源", DefaultValue = "", Order = 8)]
		public String InfoOrigin
		{
			get { return _InfoOrigin; }
			set { if (OnPropertyChange("InfoOrigin", value)) _InfoOrigin = value; }
		}

		private Int32 _CollectionMark;
		/// <summary>
		/// 采集标志
		/// </summary>
		[Description("采集标志")]
		[DataObjectField(false, false, false, 10)]
		[BindColumn("CollectionMark", Description = "采集标志", DefaultValue = "", Order = 9)]
		public Int32 CollectionMark
		{
			get { return _CollectionMark; }
			set { if (OnPropertyChange("CollectionMark", value)) _CollectionMark = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, false, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 10)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 11)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChange("Remark", value)) _Remark = value; }
		}
		#endregion

		#region 获取/设置 字段值
		/// <summary>
		/// 获取/设置 字段值。
		/// 一个索引，基类使用反射实现。
		/// 派生实体类可重写该索引，以避免反射带来的性能损耗
		/// </summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		public override Object this[String name]
		{
			get
			{
				switch (name)
				{
					case "UserName" : return _UserName;
					case "CompanyName" : return _CompanyName;
					case "UserType" : return _UserType;
					case "CategoryName" : return _CategoryName;
					case "SubIndustryName" : return _SubIndustryName;
					case "IndustryName" : return _IndustryName;
					case "RootClassName" : return _RootClassName;
					case "InfoOrigin" : return _InfoOrigin;
					case "CollectionMark" : return _CollectionMark;
					case "UpdateTime" : return _UpdateTime;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "CompanyName" : _CompanyName = Convert.ToString(value); break;
					case "UserType" : _UserType = Convert.ToString(value); break;
					case "CategoryName" : _CategoryName = Convert.ToString(value); break;
					case "SubIndustryName" : _SubIndustryName = Convert.ToString(value); break;
					case "IndustryName" : _IndustryName = Convert.ToString(value); break;
					case "RootClassName" : _RootClassName = Convert.ToString(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					case "CollectionMark" : _CollectionMark = Convert.ToInt32(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得公司用户基本信息字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 用户名
			///</summary>
			public const String UserName = "UserName";

			///<summary>
			/// 公司名称
			///</summary>
			public const String CompanyName = "CompanyName";

			///<summary>
			/// 用户类型
			///</summary>
			public const String UserType = "UserType";

			///<summary>
			/// 子类目名称
			///</summary>
			public const String CategoryName = "CategoryName";

			///<summary>
			/// 子行业名称
			///</summary>
			public const String SubIndustryName = "SubIndustryName";

			///<summary>
			/// 行业名称
			///</summary>
			public const String IndustryName = "IndustryName";

			///<summary>
			/// 根类别名称
			///</summary>
			public const String RootClassName = "RootClassName";

			///<summary>
			/// 信息来源
			///</summary>
			public const String InfoOrigin = "InfoOrigin";

			///<summary>
			/// 采集标志
			///</summary>
			public const String CollectionMark = "CollectionMark";

			///<summary>
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}