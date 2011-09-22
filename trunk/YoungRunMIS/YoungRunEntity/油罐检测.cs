/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-20 15:58:06
 * 版权：YoungRun
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
	/// <summary>
	/// 油罐检测
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("油罐检测")]
	[BindTable("tb_oiltanktest", Description = "油罐检测", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
	public partial class tb_oiltanktest
	{
		#region 属性
		private String _ID;
		/// <summary>
		/// 数据编号
		/// </summary>
		[Description("数据编号")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn(1, "ID", "数据编号", "", "varchar(20)", 0, 0, false)]
		public String ID
		{
			get { return _ID; }
			set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
		}

		private String _TankID;
		/// <summary>
		/// 油罐号
		/// </summary>
		[Description("油罐号")]
		[DataObjectField(false, false, false, 10)]
		[BindColumn(2, "TankID", "油罐号", "", "varchar(10)", 0, 0, false)]
		public String TankID
		{
			get { return _TankID; }
			set { if (OnPropertyChanging("TankID", value)) { _TankID = value; OnPropertyChanged("TankID"); } }
		}

		private String _油品名称;
		/// <summary>
		/// 油品名称
		/// </summary>
		[Description("油品名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(3, "油品名称", "油品名称", "", "varchar(20)", 0, 0, false)]
		public String 油品名称
		{
			get { return _油品名称; }
			set { if (OnPropertyChanging("油品名称", value)) { _油品名称 = value; OnPropertyChanged("油品名称"); } }
		}

		private String _DataID;
		/// <summary>
		/// 数据编号
		/// </summary>
		[Description("数据编号")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(4, "DataID", "数据编号", "", "varchar(20)", 0, 0, false)]
		public String DataID
		{
			get { return _DataID; }
			set { if (OnPropertyChanging("DataID", value)) { _DataID = value; OnPropertyChanged("DataID"); } }
		}

		private String _GetSampPerson;
		/// <summary>
		/// 采样人
		/// </summary>
		[Description("采样人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(5, "GetSampPerson", "采样人", "", "varchar(20)", 0, 0, false)]
		public String GetSampPerson
		{
			get { return _GetSampPerson; }
			set { if (OnPropertyChanging("GetSampPerson", value)) { _GetSampPerson = value; OnPropertyChanged("GetSampPerson"); } }
		}

		private DateTime _GetSampTime;
		/// <summary>
		/// 采样时间
		/// </summary>
		[Description("采样时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(6, "GetSampTime", "采样时间", "", "datetime", 0, 0, false)]
		public DateTime GetSampTime
		{
			get { return _GetSampTime; }
			set { if (OnPropertyChanging("GetSampTime", value)) { _GetSampTime = value; OnPropertyChanged("GetSampTime"); } }
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
					case "TankID" : return _TankID;
					case "油品名称" : return _油品名称;
					case "DataID" : return _DataID;
					case "GetSampPerson" : return _GetSampPerson;
					case "GetSampTime" : return _GetSampTime;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ID" : _ID = Convert.ToString(value); break;
					case "TankID" : _TankID = Convert.ToString(value); break;
					case "油品名称" : _油品名称 = Convert.ToString(value); break;
					case "DataID" : _DataID = Convert.ToString(value); break;
					case "GetSampPerson" : _GetSampPerson = Convert.ToString(value); break;
					case "GetSampTime" : _GetSampTime = Convert.ToDateTime(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得油罐检测字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
		public class _
		{
			///<summary>
			/// 数据编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 油罐号
			///</summary>
			public const String TankID = "TankID";

			///<summary>
			/// 油品名称
			///</summary>
			public const String 油品名称 = "油品名称";

			///<summary>
			/// 数据编号
			///</summary>
			public const String DataID = "DataID";

			///<summary>
			/// 采样人
			///</summary>
			public const String GetSampPerson = "GetSampPerson";

			///<summary>
			/// 采样时间
			///</summary>
			public const String GetSampTime = "GetSampTime";
		}
		#endregion
	}
}