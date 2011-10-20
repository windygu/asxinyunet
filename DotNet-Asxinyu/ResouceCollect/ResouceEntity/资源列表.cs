/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-18 12:20:40
 * 版权：YoungRun
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace ResouceEntity
{
	/// <summary>
	/// 资源列表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("资源列表")]
	[BindTable("tb_resoucepageslist", Description = "资源列表", ConnName = "ResouceCollector")]
	public partial class tb_resoucepageslist : Entity<tb_resoucepageslist>
	{
		#region 属性
		private String _PageURL;
		/// <summary>
		/// 网址
		/// </summary>
		[Description("网址")]
		[DataObjectField(true, false, false, 100)]
		[BindColumn("PageURL", Description = "网址", DefaultValue = "", Order = 1)]
		public String PageURL
		{
			get { return _PageURL; }
			set { if (OnPropertyChange("PageURL", value)) _PageURL = value; }
		}

		private String _PageTitle;
		/// <summary>
		/// 页面标题
		/// </summary>
		[Description("页面标题")]
		[DataObjectField(false, false, false, 200)]
		[BindColumn("PageTitle", Description = "页面标题", DefaultValue = "", Order = 2)]
		public String PageTitle
		{
			get { return _PageTitle; }
			set { if (OnPropertyChange("PageTitle", value)) _PageTitle = value; }
		}

		private String _ClassName;
		/// <summary>
		/// 一级大类名称
		/// </summary>
		[Description("一级大类名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("ClassName", Description = "一级大类名称", DefaultValue = "", Order = 3)]
		public String ClassName
		{
			get { return _ClassName; }
			set { if (OnPropertyChange("ClassName", value)) _ClassName = value; }
		}

		private String _SubClassName;
		/// <summary>
		/// 子类名称
		/// </summary>
		[Description("子类名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("SubClassName", Description = "子类名称", DefaultValue = "", Order = 4)]
		public String SubClassName
		{
			get { return _SubClassName; }
			set { if (OnPropertyChange("SubClassName", value)) _SubClassName = value; }
		}

		private String _ResouceType;
		/// <summary>
		/// 资源类型
		/// </summary>
		[Description("资源类型")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("ResouceType", Description = "资源类型", DefaultValue = "", Order = 5)]
		public String ResouceType
		{
			get { return _ResouceType; }
			set { if (OnPropertyChange("ResouceType", value)) _ResouceType = value; }
		}

		private UInt32 _CollectionMark;
		/// <summary>
		/// 采集标志
		/// </summary>
		[Description("采集标志")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("CollectionMark", Description = "采集标志", DefaultValue = "", Order = 6)]
		public UInt32 CollectionMark
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
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 7)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 资料来源
		/// </summary>
		[Description("资料来源")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("InfoOrigin", Description = "资料来源", DefaultValue = "", Order = 8)]
		public String InfoOrigin
		{
			get { return _InfoOrigin; }
			set { if (OnPropertyChange("InfoOrigin", value)) _InfoOrigin = value; }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 9)]
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
					case "PageURL" : return _PageURL;
					case "PageTitle" : return _PageTitle;
					case "ClassName" : return _ClassName;
					case "SubClassName" : return _SubClassName;
					case "ResouceType" : return _ResouceType;
					case "CollectionMark" : return _CollectionMark;
					case "UpdateTime" : return _UpdateTime;
					case "InfoOrigin" : return _InfoOrigin;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "PageURL" : _PageURL = Convert.ToString(value); break;
					case "PageTitle" : _PageTitle = Convert.ToString(value); break;
					case "ClassName" : _ClassName = Convert.ToString(value); break;
					case "SubClassName" : _SubClassName = Convert.ToString(value); break;
					case "ResouceType" : _ResouceType = Convert.ToString(value); break;
					case "CollectionMark" : _CollectionMark = Convert.ToUInt32(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得资源列表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 网址
			///</summary>
			public const String PageURL = "PageURL";

			///<summary>
			/// 页面标题
			///</summary>
			public const String PageTitle = "PageTitle";

			///<summary>
			/// 一级大类名称
			///</summary>
			public const String ClassName = "ClassName";

			///<summary>
			/// 子类名称
			///</summary>
			public const String SubClassName = "SubClassName";

			///<summary>
			/// 资源类型
			///</summary>
			public const String ResouceType = "ResouceType";

			///<summary>
			/// 采集标志
			///</summary>
			public const String CollectionMark = "CollectionMark";

			///<summary>
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 资料来源
			///</summary>
			public const String InfoOrigin = "InfoOrigin";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}