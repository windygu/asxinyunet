using System;
namespace DotNet.Tools.IDCardNumber.Model
{
	/// <summary>
	/// 实体类areacodetable 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class areacodetable
	{
		public areacodetable()
		{}
		#region Model
		private string _fullname;
		private string _shortname;
		private string _areacode;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShortName
		{
			set{ _shortname=value;}
			get{return _shortname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaCode
		{
			set{ _areacode=value;}
			get{return _areacode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

