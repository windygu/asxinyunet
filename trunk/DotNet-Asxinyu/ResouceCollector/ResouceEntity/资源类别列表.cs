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
	/// 资源类别列表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("资源类别列表")]
	[BindTable("tb_typelist", Description = "资源类别列表", ConnName = "ResouceCollector")]
	public partial class tb_typelist : Entity<tb_typelist>
	{
		#region 属性
		private String _URL;
		/// <summary>
		/// 网址
		/// </summary>
		[Description("网址")]
		[DataObjectField(true, false, false, 100)]
		[BindColumn("URL", Description = "网址", DefaultValue = "", Order = 1)]
		public String URL
		{
			get { return _URL; }
			set { if (OnPropertyChange("URL", value)) _URL = value; }
		}

		private String _TypeName;
		/// <summary>
		/// 大类名称
		/// </summary>
		[Description("大类名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("TypeName", Description = "大类名称", DefaultValue = "", Order = 2)]
		public String TypeName
		{
			get { return _TypeName; }
			set { if (OnPropertyChange("TypeName", value)) _TypeName = value; }
		}

		private String _SubClassName;
		/// <summary>
		/// 子类名称
		/// </summary>
		[Description("子类名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("SubClassName", Description = "子类名称", DefaultValue = "", Order = 3)]
		public String SubClassName
		{
			get { return _SubClassName; }
			set { if (OnPropertyChange("SubClassName", value)) _SubClassName = value; }
		}

		private String _ResType;
		/// <summary>
		/// 资源类型
		/// </summary>
		[Description("资源类型")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("ResType", Description = "资源类型", DefaultValue = "", Order = 4)]
		public String ResType
		{
			get { return _ResType; }
			set { if (OnPropertyChange("ResType", value)) _ResType = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 5)]
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
		[DataObjectField(false, false, true, 100)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 6)]
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
					case "URL" : return _URL;
					case "TypeName" : return _TypeName;
					case "SubClassName" : return _SubClassName;
					case "ResType" : return _ResType;
					case "UpdateTime" : return _UpdateTime;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "URL" : _URL = Convert.ToString(value); break;
					case "TypeName" : _TypeName = Convert.ToString(value); break;
					case "SubClassName" : _SubClassName = Convert.ToString(value); break;
					case "ResType" : _ResType = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得资源类别列表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 网址
			///</summary>
			public const String URL = "URL";

			///<summary>
			/// 大类名称
			///</summary>
			public const String TypeName = "TypeName";

			///<summary>
			/// 子类名称
			///</summary>
			public const String SubClassName = "SubClassName";

			///<summary>
			/// 资源类型
			///</summary>
			public const String ResType = "ResType";

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