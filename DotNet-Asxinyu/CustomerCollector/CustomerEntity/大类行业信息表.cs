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
	/// 大类行业信息表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("大类行业信息表")]
	[BindTable("tb_industrylist", Description = "大类行业信息表", ConnName = "CustomerEntity")]
	public partial class tb_industrylist : Entity<tb_industrylist>
	{
		#region 属性
		private UInt32 _ID;
		/// <summary>
		/// 行业编号
		/// </summary>
		[Description("行业编号")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn("ID", Description = "行业编号", DefaultValue = "", Order = 1)]
		public UInt32 ID
		{
			get { return _ID; }
			set { if (OnPropertyChange("ID", value)) _ID = value; }
		}

		private String _IndustryName;
		/// <summary>
		/// 行业名称
		/// </summary>
		[Description("行业名称")]
		[DataObjectField(false, false, false, 30)]
		[BindColumn("IndustryName", Description = "行业名称", DefaultValue = "", Order = 2)]
		public String IndustryName
		{
			get { return _IndustryName; }
			set { if (OnPropertyChange("IndustryName", value)) _IndustryName = value; }
		}

		private String _WebSite;
		/// <summary>
		/// 网址
		/// </summary>
		[Description("网址")]
		[DataObjectField(false, false, false, 65535)]
		[BindColumn("WebSite", Description = "网址", DefaultValue = "", Order = 3)]
		public String WebSite
		{
			get { return _WebSite; }
			set { if (OnPropertyChange("WebSite", value)) _WebSite = value; }
		}

		private String _RootClassName;
		/// <summary>
		/// 根类别
		/// </summary>
		[Description("根类别")]
		[DataObjectField(false, false, false, 10)]
		[BindColumn("RootClassName", Description = "根类别", DefaultValue = "", Order = 4)]
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
		[BindColumn("KeyWords", Description = "关键词", DefaultValue = "", Order = 5)]
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
		[BindColumn("InfoOrigin", Description = "资料来源", DefaultValue = "", Order = 6)]
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
		[BindColumn("CollectionMark", Description = "采集标志", DefaultValue = "", Order = 7)]
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
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 8)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private String _Remark;
		/// <summary>
		///  备注
		/// </summary>
		[Description(" 备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("Remark", Description = " 备注", DefaultValue = "", Order = 9)]
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
					case "WebSite" : return _WebSite;
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
					case "WebSite" : _WebSite = Convert.ToString(value); break;
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
		/// 取得大类行业信息表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 行业编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 行业名称
			///</summary>
			public const String IndustryName = "IndustryName";

			///<summary>
			/// 网址
			///</summary>
			public const String WebSite = "WebSite";

			///<summary>
			/// 根类别
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
			///  备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}