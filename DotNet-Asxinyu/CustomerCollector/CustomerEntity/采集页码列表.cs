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
	/// 采集页码列表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("采集页码列表")]
	[BindTable("tb_pagelist", Description = "采集页码列表", ConnName = "CustomerEntity")]
	public partial class tb_pagelist : Entity<tb_pagelist>
	{
		#region 属性
		private String _PageURL;
		/// <summary>
		/// 页码网址
		/// </summary>
		[Description("页码网址")]
		[DataObjectField(true, false, false, 250)]
		[BindColumn("PageURL", Description = "页码网址", DefaultValue = "", Order = 1)]
		public String PageURL
		{
			get { return _PageURL; }
			set { if (OnPropertyChange("PageURL", value)) _PageURL = value; }
		}

		private String _CategoryName;
		/// <summary>
		/// 类目名称
		/// </summary>
		[Description("类目名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("CategoryName", Description = "类目名称", DefaultValue = "", Order = 2)]
		public String CategoryName
		{
			get { return _CategoryName; }
			set { if (OnPropertyChange("CategoryName", value)) _CategoryName = value; }
		}

		private String _SubIndustryName;
		/// <summary>
		/// 父类子行业名称
		/// </summary>
		[Description("父类子行业名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("SubIndustryName", Description = "父类子行业名称", DefaultValue = "", Order = 3)]
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
		[DataObjectField(false, false, false, 30)]
		[BindColumn("IndustryName", Description = "行业名称", DefaultValue = "", Order = 4)]
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
		[BindColumn("RootClassName", Description = "根类别名称", DefaultValue = "", Order = 5)]
		public String RootClassName
		{
			get { return _RootClassName; }
			set { if (OnPropertyChange("RootClassName", value)) _RootClassName = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, false, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 6)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private Int32 _CollectionMark;
		/// <summary>
		/// 采集标志
		/// </summary>
		[Description("采集标志")]
		[DataObjectField(false, false, false, 10)]
		[BindColumn("CollectionMark", Description = "采集标志", DefaultValue = "", Order = 7)]
		public Int32 CollectionMark
		{
			get { return _CollectionMark; }
			set { if (OnPropertyChange("CollectionMark", value)) _CollectionMark = value; }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 8)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChange("Remark", value)) _Remark = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 信息来源
		/// </summary>
		[Description("信息来源")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("InfoOrigin", Description = "信息来源", DefaultValue = "", Order = 9)]
		public String InfoOrigin
		{
			get { return _InfoOrigin; }
			set { if (OnPropertyChange("InfoOrigin", value)) _InfoOrigin = value; }
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
					case "PageURL" : return _PageURL;
					case "CategoryName" : return _CategoryName;
					case "SubIndustryName" : return _SubIndustryName;
					case "IndustryName" : return _IndustryName;
					case "RootClassName" : return _RootClassName;
					case "UpdateTime" : return _UpdateTime;
					case "CollectionMark" : return _CollectionMark;
					case "Remark" : return _Remark;
					case "InfoOrigin" : return _InfoOrigin;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "PageURL" : _PageURL = Convert.ToString(value); break;
					case "CategoryName" : _CategoryName = Convert.ToString(value); break;
					case "SubIndustryName" : _SubIndustryName = Convert.ToString(value); break;
					case "IndustryName" : _IndustryName = Convert.ToString(value); break;
					case "RootClassName" : _RootClassName = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "CollectionMark" : _CollectionMark = Convert.ToInt32(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得采集页码列表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 页码网址
			///</summary>
			public const String PageURL = "PageURL";

			///<summary>
			/// 类目名称
			///</summary>
			public const String CategoryName = "CategoryName";

			///<summary>
			/// 父类子行业名称
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
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 采集标志
			///</summary>
			public const String CollectionMark = "CollectionMark";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";

			///<summary>
			/// 信息来源
			///</summary>
			public const String InfoOrigin = "InfoOrigin";
		}
		#endregion
	}
}