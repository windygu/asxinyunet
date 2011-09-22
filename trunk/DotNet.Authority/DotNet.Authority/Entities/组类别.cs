/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-21 21:42:28
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace DotNet.Authority
{
	/// <summary>
	/// 组类别
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("组类别")]
	[BindTable("tb_grouplist", Description = "组类别", ConnName = "AuthorityConn")]
	public partial class tb_grouplist : Entity<tb_grouplist>
	{
		#region 属性
		private String _GroupName;
		/// <summary>
		/// 组名称
		/// </summary>
		[Description("组名称")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn("GroupName", Description = "组名称", DefaultValue = "", Order = 1)]
		public String GroupName
		{
			get { return _GroupName; }
			set { if (OnPropertyChange("GroupName", value)) _GroupName = value; }
		}

		private String _GroupIntro;
		/// <summary>
		/// 组介绍
		/// </summary>
		[Description("组介绍")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("GroupIntro", Description = "组介绍", DefaultValue = "", Order = 2)]
		public String GroupIntro
		{
			get { return _GroupIntro; }
			set { if (OnPropertyChange("GroupIntro", value)) _GroupIntro = value; }
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
					case "GroupName" : return _GroupName;
					case "GroupIntro" : return _GroupIntro;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "GroupName" : _GroupName = Convert.ToString(value); break;
					case "GroupIntro" : _GroupIntro = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得组类别字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 组名称
			///</summary>
			public const String GroupName = "GroupName";

			///<summary>
			/// 组介绍
			///</summary>
			public const String GroupIntro = "GroupIntro";
		}
		#endregion
	}
}