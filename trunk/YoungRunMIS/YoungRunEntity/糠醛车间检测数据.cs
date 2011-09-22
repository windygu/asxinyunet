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
	/// 糠醛车间检测数据
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("糠醛车间检测数据")]
	[BindTable("tb_kqtestdata", Description = "糠醛车间检测数据", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
	public partial class tb_kqtestdata
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

		private String _RawName;
		/// <summary>
		/// 原料名称
		/// </summary>
		[Description("原料名称")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(2, "RawName", "原料名称", "", "varchar(20)", 0, 0, false)]
		public String RawName
		{
			get { return _RawName; }
			set { if (OnPropertyChanging("RawName", value)) { _RawName = value; OnPropertyChanged("RawName"); } }
		}

		private SByte _JQIsHaveKQ;
		/// <summary>
		/// 精油含醛
		/// </summary>
		[Description("精油含醛")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(3, "JQIsHaveKQ", "精油含醛", "", "tinyint(1)", 3, 0, false)]
		public SByte JQIsHaveKQ
		{
			get { return _JQIsHaveKQ; }
			set { if (OnPropertyChanging("JQIsHaveKQ", value)) { _JQIsHaveKQ = value; OnPropertyChanged("JQIsHaveKQ"); } }
		}

		private Double _AV;
		/// <summary>
		/// 酸值
		/// </summary>
		[Description("酸值")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(4, "AV", "酸值", "", "double", 22, 0, false)]
		public Double AV
		{
			get { return _AV; }
			set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
		}

		private SByte _CYIsHaveKQ;
		/// <summary>
		/// 抽油含醛
		/// </summary>
		[Description("抽油含醛")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(5, "CYIsHaveKQ", "抽油含醛", "", "tinyint(1)", 3, 0, false)]
		public SByte CYIsHaveKQ
		{
			get { return _CYIsHaveKQ; }
			set { if (OnPropertyChanging("CYIsHaveKQ", value)) { _CYIsHaveKQ = value; OnPropertyChanged("CYIsHaveKQ"); } }
		}

		private SByte _T8WIsHaveKQ;
		/// <summary>
		/// 塔8水含醛
		/// </summary>
		[Description("塔8水含醛")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(6, "T8WIsHaveKQ", "塔8水含醛", "", "tinyint(1)", 3, 0, false)]
		public SByte T8WIsHaveKQ
		{
			get { return _T8WIsHaveKQ; }
			set { if (OnPropertyChanging("T8WIsHaveKQ", value)) { _T8WIsHaveKQ = value; OnPropertyChanged("T8WIsHaveKQ"); } }
		}

		private String _ASTM;
		/// <summary>
		/// 色度
		/// </summary>
		[Description("色度")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(7, "ASTM", "色度", "", "varchar(10)", 0, 0, false)]
		public String ASTM
		{
			get { return _ASTM; }
			set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
		}

		private DateTime _GetSampleTime;
		/// <summary>
		/// 采样时间
		/// </summary>
		[Description("采样时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(8, "GetSampleTime", "采样时间", "", "datetime", 0, 0, false)]
		public DateTime GetSampleTime
		{
			get { return _GetSampleTime; }
			set { if (OnPropertyChanging("GetSampleTime", value)) { _GetSampleTime = value; OnPropertyChanged("GetSampleTime"); } }
		}

		private String _GetSampPerson;
		/// <summary>
		/// 采样人
		/// </summary>
		[Description("采样人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(9, "GetSampPerson", "采样人", "", "varchar(20)", 0, 0, false)]
		public String GetSampPerson
		{
			get { return _GetSampPerson; }
			set { if (OnPropertyChanging("GetSampPerson", value)) { _GetSampPerson = value; OnPropertyChanged("GetSampPerson"); } }
		}

		private String _TestPerson;
		/// <summary>
		/// 检测人
		/// </summary>
		[Description("检测人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(10, "TestPerson", "检测人", "", "varchar(20)", 0, 0, false)]
		public String TestPerson
		{
			get { return _TestPerson; }
			set { if (OnPropertyChanging("TestPerson", value)) { _TestPerson = value; OnPropertyChanged("TestPerson"); } }
		}

		private String _GetSampLocation;
		/// <summary>
		/// 采样地点
		/// </summary>
		[Description("采样地点")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(11, "GetSampLocation", "采样地点", "", "varchar(10)", 0, 0, false)]
		public String GetSampLocation
		{
			get { return _GetSampLocation; }
			set { if (OnPropertyChanging("GetSampLocation", value)) { _GetSampLocation = value; OnPropertyChanged("GetSampLocation"); } }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(12, "UpdateTime", "更新时间", "", "datetime", 0, 0, false)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(13, "Remark", "备注", "", "varchar(100)", 0, 0, false)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
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
					case "RawName" : return _RawName;
					case "JQIsHaveKQ" : return _JQIsHaveKQ;
					case "AV" : return _AV;
					case "CYIsHaveKQ" : return _CYIsHaveKQ;
					case "T8WIsHaveKQ" : return _T8WIsHaveKQ;
					case "ASTM" : return _ASTM;
					case "GetSampleTime" : return _GetSampleTime;
					case "GetSampPerson" : return _GetSampPerson;
					case "TestPerson" : return _TestPerson;
					case "GetSampLocation" : return _GetSampLocation;
					case "UpdateTime" : return _UpdateTime;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ID" : _ID = Convert.ToString(value); break;
					case "RawName" : _RawName = Convert.ToString(value); break;
					case "JQIsHaveKQ" : _JQIsHaveKQ = Convert.ToSByte(value); break;
					case "AV" : _AV = Convert.ToDouble(value); break;
					case "CYIsHaveKQ" : _CYIsHaveKQ = Convert.ToSByte(value); break;
					case "T8WIsHaveKQ" : _T8WIsHaveKQ = Convert.ToSByte(value); break;
					case "ASTM" : _ASTM = Convert.ToString(value); break;
					case "GetSampleTime" : _GetSampleTime = Convert.ToDateTime(value); break;
					case "GetSampPerson" : _GetSampPerson = Convert.ToString(value); break;
					case "TestPerson" : _TestPerson = Convert.ToString(value); break;
					case "GetSampLocation" : _GetSampLocation = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得糠醛车间检测数据字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
		public class _
		{
			///<summary>
			/// 数据编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 原料名称
			///</summary>
			public const String RawName = "RawName";

			///<summary>
			/// 精油含醛
			///</summary>
			public const String JQIsHaveKQ = "JQIsHaveKQ";

			///<summary>
			/// 酸值
			///</summary>
			public const String AV = "AV";

			///<summary>
			/// 抽油含醛
			///</summary>
			public const String CYIsHaveKQ = "CYIsHaveKQ";

			///<summary>
			/// 塔8水含醛
			///</summary>
			public const String T8WIsHaveKQ = "T8WIsHaveKQ";

			///<summary>
			/// 色度
			///</summary>
			public const String ASTM = "ASTM";

			///<summary>
			/// 采样时间
			///</summary>
			public const String GetSampleTime = "GetSampleTime";

			///<summary>
			/// 采样人
			///</summary>
			public const String GetSampPerson = "GetSampPerson";

			///<summary>
			/// 检测人
			///</summary>
			public const String TestPerson = "TestPerson";

			///<summary>
			/// 采样地点
			///</summary>
			public const String GetSampLocation = "GetSampLocation";

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