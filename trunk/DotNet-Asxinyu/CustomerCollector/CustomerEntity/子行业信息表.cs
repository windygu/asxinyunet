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
	/// 子行业信息表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("子行业信息表")]
	[BindTable("tb_subindustrylist", Description = "子行业信息表", ConnName = "CustomerEntity")]
	public partial class tb_subindustrylist : Entity<tb_subindustrylist>
	{
		#region 属性
		private UInt32 _ID;
		/// <summary>
		/// 编号
		/// </summary>
		[Description("编号")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn("ID", Description = "编号", DefaultValue = "", Order = 1)]
		public UInt32 ID
		{
			get { return _ID; }
			set { if (OnPropertyChange("ID", value)) _ID = value; }
		}

		private String _IndustryName;
		/// <summary>
		/// 子行业名称
		/// </summary>
		[Description("子行业名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("IndustryName", Description = "子行业名称", DefaultValue = "", Order = 2)]
		public String IndustryName
		{
			get { return _IndustryName; }
			set { if (OnPropertyChange("IndustryName", value)) _IndustryName = value; }
		}

		private String _IndustryWebSite;
		/// <summary>
		/// 网址
		/// </summary>
		[Description("网址")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("IndustryWebSite", Description = "网址", DefaultValue = "", Order = 3)]
		public String IndustryWebSite
		{
			get { return _IndustryWebSite; }
			set { if (OnPropertyChange("IndustryWebSite", value)) _IndustryWebSite = value; }
		}

		private String _FatherIndustryName;
		/// <summary>
		/// 父类行业名称
		/// </summary>
		[Description("父类行业名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("FatherIndustryName", Description = "父类行业名称", DefaultValue = "", Order = 4)]
		public String FatherIndustryName
		{
			get { return _FatherIndustryName; }
			set { if (OnPropertyChange("FatherIndustryName", value)) _FatherIndustryName = value; }
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

		private String _KeyWords;
		/// <summary>
		/// 关键词
		/// </summary>
		[Description("关键词")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("KeyWords", Description = "关键词", DefaultValue = "", Order = 6)]
		public String KeyWords
		{
			get { return _KeyWords; }
			set { if (OnPropertyChange("KeyWords", value)) _KeyWords = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 资料来源
		/// </summary>
		[Description("资料来源")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("InfoOrigin", Description = "资料来源", DefaultValue = "", Order = 7)]
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
		[BindColumn("CollectionMark", Description = "采集标志", DefaultValue = "", Order = 8)]
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
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 9)]
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
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 10)]
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
					case "ID" : return _ID;
					case "IndustryName" : return _IndustryName;
					case "IndustryWebSite" : return _IndustryWebSite;
					case "FatherIndustryName" : return _FatherIndustryName;
					case "RootClassName" : return _RootClassName;
					case "KeyWords" : return _KeyWords;
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
					case "ID" : _ID = Convert.ToUInt32(value); break;
					case "IndustryName" : _IndustryName = Convert.ToString(value); break;
					case "IndustryWebSite" : _IndustryWebSite = Convert.ToString(value); break;
					case "FatherIndustryName" : _FatherIndustryName = Convert.ToString(value); break;
					case "RootClassName" : _RootClassName = Convert.ToString(value); break;
					case "KeyWords" : _KeyWords = Convert.ToString(value); break;
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
		/// 取得子行业信息表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 子行业名称
			///</summary>
			public const String IndustryName = "IndustryName";

			///<summary>
			/// 网址
			///</summary>
			public const String IndustryWebSite = "IndustryWebSite";

			///<summary>
			/// 父类行业名称
			///</summary>
			public const String FatherIndustryName = "FatherIndustryName";

			///<summary>
			/// 根类别名称
			///</summary>
			public const String RootClassName = "RootClassName";

			///<summary>
			/// 关键词
			///</summary>
			public const String KeyWords = "KeyWords";

			///<summary>
			/// 资料来源
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