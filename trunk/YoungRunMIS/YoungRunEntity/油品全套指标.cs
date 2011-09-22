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
	/// 油品全套指标
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("油品全套指标")]
	[BindTable("tb_oildata", Description = "油品全套指标", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
	public partial class tb_oildata
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

		private String _OilName;
		/// <summary>
		/// 油品名称
		/// </summary>
		[Description("油品名称")]
		[DataObjectField(true, false, false, 30)]
		[BindColumn(2, "OilName", "油品名称", "", "varchar(30)", 0, 0, false)]
		public String OilName
		{
			get { return _OilName; }
			set { if (OnPropertyChanging("OilName", value)) { _OilName = value; OnPropertyChanged("OilName"); } }
		}

		private Double _V40;
		/// <summary>
		/// V40
		/// </summary>
		[Description("V40")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(3, "V40", "V40", "", "double", 22, 0, false)]
		public Double V40
		{
			get { return _V40; }
			set { if (OnPropertyChanging("V40", value)) { _V40 = value; OnPropertyChanged("V40"); } }
		}

		private Double _V100;
		/// <summary>
		/// V100
		/// </summary>
		[Description("V100")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(4, "V100", "V100", "", "double", 22, 0, false)]
		public Double V100
		{
			get { return _V100; }
			set { if (OnPropertyChanging("V100", value)) { _V100 = value; OnPropertyChanged("V100"); } }
		}

		private Int32 _VI;
		/// <summary>
		/// 粘度指数
		/// </summary>
		[Description("粘度指数")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(5, "VI", "粘度指数", "", "int(10)", 10, 0, false)]
		public Int32 VI
		{
			get { return _VI; }
			set { if (OnPropertyChanging("VI", value)) { _VI = value; OnPropertyChanged("VI"); } }
		}

		private Int32 _PP;
		/// <summary>
		/// 倾点
		/// </summary>
		[Description("倾点")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(6, "PP", "倾点", "", "int(10)", 10, 0, false)]
		public Int32 PP
		{
			get { return _PP; }
			set { if (OnPropertyChanging("PP", value)) { _PP = value; OnPropertyChanged("PP"); } }
		}

		private Int32 _FP;
		/// <summary>
		/// 闪点
		/// </summary>
		[Description("闪点")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(7, "FP", "闪点", "", "int(10)", 10, 0, false)]
		public Int32 FP
		{
			get { return _FP; }
			set { if (OnPropertyChanging("FP", value)) { _FP = value; OnPropertyChanged("FP"); } }
		}

		private Double _AV;
		/// <summary>
		/// 酸值
		/// </summary>
		[Description("酸值")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(8, "AV", "酸值", "", "double", 22, 0, false)]
		public Double AV
		{
			get { return _AV; }
			set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
		}

		private Double _WC;
		/// <summary>
		/// 水分
		/// </summary>
		[Description("水分")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(9, "WC", "水分", "", "double", 22, 0, false)]
		public Double WC
		{
			get { return _WC; }
			set { if (OnPropertyChanging("WC", value)) { _WC = value; OnPropertyChanged("WC"); } }
		}

		private String _ASTM;
		/// <summary>
		/// 色度
		/// </summary>
		[Description("色度")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(10, "ASTM", "色度", "", "varchar(10)", 0, 0, false)]
		public String ASTM
		{
			get { return _ASTM; }
			set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
		}

		private Double _D20;
		/// <summary>
		/// 密度
		/// </summary>
		[Description("密度")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(11, "D20", "密度", "", "double", 22, 0, false)]
		public Double D20
		{
			get { return _D20; }
			set { if (OnPropertyChanging("D20", value)) { _D20 = value; OnPropertyChanged("D20"); } }
		}

		private Double _MI;
		/// <summary>
		/// 机械杂质
		/// </summary>
		[Description("机械杂质")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(12, "MI", "机械杂质", "", "double", 22, 0, false)]
		public Double MI
		{
			get { return _MI; }
			set { if (OnPropertyChanging("MI", value)) { _MI = value; OnPropertyChanged("MI"); } }
		}

		private Double _CR;
		/// <summary>
		/// 残炭
		/// </summary>
		[Description("残炭")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(13, "CR", "残炭", "", "double", 22, 0, false)]
		public Double CR
		{
			get { return _CR; }
			set { if (OnPropertyChanging("CR", value)) { _CR = value; OnPropertyChanged("CR"); } }
		}

		private String _WAA;
		/// <summary>
		/// 水溶性酸碱
		/// </summary>
		[Description("水溶性酸碱")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(14, "WAA", "水溶性酸碱", "", "varchar(15)", 0, 0, false)]
		public String WAA
		{
			get { return _WAA; }
			set { if (OnPropertyChanging("WAA", value)) { _WAA = value; OnPropertyChanged("WAA"); } }
		}

		private String _V;
		/// <summary>
		/// 低温运动粘度
		/// </summary>
		[Description("低温运动粘度")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(15, "V", "低温运动粘度", "", "varchar(50)", 0, 0, false)]
		public String V
		{
			get { return _V; }
			set { if (OnPropertyChanging("V", value)) { _V = value; OnPropertyChanged("V"); } }
		}

		private String _Distillation;
		/// <summary>
		/// 馏程
		/// </summary>
		[Description("馏程")]
		[DataObjectField(false, false, true, 60)]
		[BindColumn(16, "Distillation", "馏程", "", "varchar(60)", 0, 0, false)]
		public String Distillation
		{
			get { return _Distillation; }
			set { if (OnPropertyChanging("Distillation", value)) { _Distillation = value; OnPropertyChanged("Distillation"); } }
		}

		private String _XZQD;
		/// <summary>
		/// 旋转氧弹
		/// </summary>
		[Description("旋转氧弹")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(17, "XZQD", "旋转氧弹", "", "varchar(20)", 0, 0, false)]
		public String XZQD
		{
			get { return _XZQD; }
			set { if (OnPropertyChanging("XZQD", value)) { _XZQD = value; OnPropertyChanged("XZQD"); } }
		}

		private String _Other;
		/// <summary>
		/// 其他指标
		/// </summary>
		[Description("其他指标")]
		[DataObjectField(false, false, true, 60)]
		[BindColumn(18, "Other", "其他指标", "", "varchar(60)", 0, 0, false)]
		public String Other
		{
			get { return _Other; }
			set { if (OnPropertyChanging("Other", value)) { _Other = value; OnPropertyChanged("Other"); } }
		}

		private String _TestPerson;
		/// <summary>
		/// 检测人
		/// </summary>
		[Description("检测人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(19, "TestPerson", "检测人", "", "varchar(20)", 0, 0, false)]
		public String TestPerson
		{
			get { return _TestPerson; }
			set { if (OnPropertyChanging("TestPerson", value)) { _TestPerson = value; OnPropertyChanged("TestPerson"); } }
		}

		private DateTime _TestDateTime;
		/// <summary>
		/// 测试时间
		/// </summary>
		[Description("测试时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(20, "TestDateTime", "测试时间", "", "datetime", 0, 0, false)]
		public DateTime TestDateTime
		{
			get { return _TestDateTime; }
			set { if (OnPropertyChanging("TestDateTime", value)) { _TestDateTime = value; OnPropertyChanged("TestDateTime"); } }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn(21, "Remark", "备注", "", "text", 0, 0, false)]
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
					case "OilName" : return _OilName;
					case "V40" : return _V40;
					case "V100" : return _V100;
					case "VI" : return _VI;
					case "PP" : return _PP;
					case "FP" : return _FP;
					case "AV" : return _AV;
					case "WC" : return _WC;
					case "ASTM" : return _ASTM;
					case "D20" : return _D20;
					case "MI" : return _MI;
					case "CR" : return _CR;
					case "WAA" : return _WAA;
					case "V" : return _V;
					case "Distillation" : return _Distillation;
					case "XZQD" : return _XZQD;
					case "Other" : return _Other;
					case "TestPerson" : return _TestPerson;
					case "TestDateTime" : return _TestDateTime;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ID" : _ID = Convert.ToString(value); break;
					case "OilName" : _OilName = Convert.ToString(value); break;
					case "V40" : _V40 = Convert.ToDouble(value); break;
					case "V100" : _V100 = Convert.ToDouble(value); break;
					case "VI" : _VI = Convert.ToInt32(value); break;
					case "PP" : _PP = Convert.ToInt32(value); break;
					case "FP" : _FP = Convert.ToInt32(value); break;
					case "AV" : _AV = Convert.ToDouble(value); break;
					case "WC" : _WC = Convert.ToDouble(value); break;
					case "ASTM" : _ASTM = Convert.ToString(value); break;
					case "D20" : _D20 = Convert.ToDouble(value); break;
					case "MI" : _MI = Convert.ToDouble(value); break;
					case "CR" : _CR = Convert.ToDouble(value); break;
					case "WAA" : _WAA = Convert.ToString(value); break;
					case "V" : _V = Convert.ToString(value); break;
					case "Distillation" : _Distillation = Convert.ToString(value); break;
					case "XZQD" : _XZQD = Convert.ToString(value); break;
					case "Other" : _Other = Convert.ToString(value); break;
					case "TestPerson" : _TestPerson = Convert.ToString(value); break;
					case "TestDateTime" : _TestDateTime = Convert.ToDateTime(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得油品全套指标字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
		public class _
		{
			///<summary>
			/// 数据编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 油品名称
			///</summary>
			public const String OilName = "OilName";

			///<summary>
			/// V40
			///</summary>
			public const String V40 = "V40";

			///<summary>
			/// V100
			///</summary>
			public const String V100 = "V100";

			///<summary>
			/// 粘度指数
			///</summary>
			public const String VI = "VI";

			///<summary>
			/// 倾点
			///</summary>
			public const String PP = "PP";

			///<summary>
			/// 闪点
			///</summary>
			public const String FP = "FP";

			///<summary>
			/// 酸值
			///</summary>
			public const String AV = "AV";

			///<summary>
			/// 水分
			///</summary>
			public const String WC = "WC";

			///<summary>
			/// 色度
			///</summary>
			public const String ASTM = "ASTM";

			///<summary>
			/// 密度
			///</summary>
			public const String D20 = "D20";

			///<summary>
			/// 机械杂质
			///</summary>
			public const String MI = "MI";

			///<summary>
			/// 残炭
			///</summary>
			public const String CR = "CR";

			///<summary>
			/// 水溶性酸碱
			///</summary>
			public const String WAA = "WAA";

			///<summary>
			/// 低温运动粘度
			///</summary>
			public const String V = "V";

			///<summary>
			/// 馏程
			///</summary>
			public const String Distillation = "Distillation";

			///<summary>
			/// 旋转氧弹
			///</summary>
			public const String XZQD = "XZQD";

			///<summary>
			/// 其他指标
			///</summary>
			public const String Other = "Other";

			///<summary>
			/// 检测人
			///</summary>
			public const String TestPerson = "TestPerson";

			///<summary>
			/// 测试时间
			///</summary>
			public const String TestDateTime = "TestDateTime";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}