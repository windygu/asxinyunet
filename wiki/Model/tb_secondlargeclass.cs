using System;
namespace GetCustomData.Model
{
	/// <summary>
	/// ʵ����tb_secondlargeclass ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class tb_secondlargeclass
	{
		public tb_secondlargeclass()
		{}
		#region Model
		private string _id;
		private string _typename;
		private string _industryname;
		private string _website;
		private DateTime _updatetime;
		private int _origintype;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OriginType
		{
			set{ _origintype=value;}
			get{return _origintype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

