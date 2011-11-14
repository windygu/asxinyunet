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
	/// 资源链接表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("资源链接表")]
	[BindTable("tb_resoucelink", Description = "资源链接表", ConnName = "ResouceCollector")]
	public partial class tb_resoucelink : Entity<tb_resoucelink>
	{
		#region 属性
		private String _ResouceMD5;
		/// <summary>
		/// 资源MD5值
		/// </summary>
		[Description("资源MD5值")]
		[DataObjectField(true, false, false, 50)]
		[BindColumn("ResouceMD5", Description = "资源MD5值", DefaultValue = "", Order = 1)]
		public String ResouceMD5
		{
			get { return _ResouceMD5; }
			set { if (OnPropertyChange("ResouceMD5", value)) _ResouceMD5 = value; }
		}

		private String _ResouceName;
		/// <summary>
		/// 资源网址
		/// </summary>
		[Description("资源网址")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn("ResouceName", Description = "资源网址", DefaultValue = "", Order = 2)]
		public String ResouceName
		{
			get { return _ResouceName; }
			set { if (OnPropertyChange("ResouceName", value)) _ResouceName = value; }
		}

		private String _ResouceLink;
		/// <summary>
		/// 下载链接
		/// </summary>
		[Description("下载链接")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("ResouceLink", Description = "下载链接", DefaultValue = "", Order = 3)]
		public String ResouceLink
		{
			get { return _ResouceLink; }
			set { if (OnPropertyChange("ResouceLink", value)) _ResouceLink = value; }
		}

		private String _ClassName;
		/// <summary>
		/// 一级大类名称
		/// </summary>
		[Description("一级大类名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("ClassName", Description = "一级大类名称", DefaultValue = "", Order = 4)]
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
		[BindColumn("SubClassName", Description = "子类名称", DefaultValue = "", Order = 5)]
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
		[DataObjectField(false, false, true, 10)]
		[BindColumn("ResouceType", Description = "资源类型", DefaultValue = "", Order = 6)]
		public String ResouceType
		{
			get { return _ResouceType; }
			set { if (OnPropertyChange("ResouceType", value)) _ResouceType = value; }
		}

		private String _FromURL;
		/// <summary>
		/// 来源网址
		/// </summary>
		[Description("来源网址")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn("FromURL", Description = "来源网址", DefaultValue = "", Order = 7)]
		public String FromURL
		{
			get { return _FromURL; }
			set { if (OnPropertyChange("FromURL", value)) _FromURL = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 8)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 来源
		/// </summary>
		[Description("来源")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("InfoOrigin", Description = "来源", DefaultValue = "", Order = 9)]
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
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 10)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChange("Remark", value)) _Remark = value; }
		}

		private UInt32 _IsDownload;
		/// <summary>
		/// 时候下载
		/// </summary>
		[Description("时候下载")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("IsDownload", Description = "时候下载", DefaultValue = "0", Order = 11)]
		public UInt32 IsDownload
		{
			get { return _IsDownload; }
			set { if (OnPropertyChange("IsDownload", value)) _IsDownload = value; }
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
					case "ResouceMD5" : return _ResouceMD5;
					case "ResouceName" : return _ResouceName;
					case "ResouceLink" : return _ResouceLink;
					case "ClassName" : return _ClassName;
					case "SubClassName" : return _SubClassName;
					case "ResouceType" : return _ResouceType;
					case "FromURL" : return _FromURL;
					case "UpdateTime" : return _UpdateTime;
					case "InfoOrigin" : return _InfoOrigin;
					case "Remark" : return _Remark;
					case "IsDownload" : return _IsDownload;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ResouceMD5" : _ResouceMD5 = Convert.ToString(value); break;
					case "ResouceName" : _ResouceName = Convert.ToString(value); break;
					case "ResouceLink" : _ResouceLink = Convert.ToString(value); break;
					case "ClassName" : _ClassName = Convert.ToString(value); break;
					case "SubClassName" : _SubClassName = Convert.ToString(value); break;
					case "ResouceType" : _ResouceType = Convert.ToString(value); break;
					case "FromURL" : _FromURL = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					case "IsDownload" : _IsDownload = Convert.ToUInt32(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得资源链接表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 资源MD5值
			///</summary>
			public const String ResouceMD5 = "ResouceMD5";

			///<summary>
			/// 资源网址
			///</summary>
			public const String ResouceName = "ResouceName";

			///<summary>
			/// 下载链接
			///</summary>
			public const String ResouceLink = "ResouceLink";

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
			/// 来源网址
			///</summary>
			public const String FromURL = "FromURL";

			///<summary>
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 来源
			///</summary>
			public const String InfoOrigin = "InfoOrigin";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";

			///<summary>
			/// 时候下载
			///</summary>
			public const String IsDownload = "IsDownload";
		}
		#endregion
	}
}