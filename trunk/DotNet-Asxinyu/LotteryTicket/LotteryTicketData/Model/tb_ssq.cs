using System;
namespace LotteryTicketData.Model
{
	/// <summary>
	/// ʵ����tb_ssq ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class tb_ssq
	{
		public tb_ssq()
		{}
		#region Model
		private DateTime _��������;
		private Double _�ں�;
		private Double _����1;
		private Double _����2;
		private Double _����3;
		private Double _����4;
		private Double _����5;
		private Double _����6;
		private Double _����;
		/// <summary>
		/// 
		/// </summary>
		public DateTime ��������
		{
			set{ _��������=value;}
			get{return _��������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double �ں�
		{
			set{ _�ں�=value;}
			get{return _�ں�;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����1
		{
			set{ _����1=value;}
			get{return _����1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����2
		{
			set{ _����2=value;}
			get{return _����2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����3
		{
			set{ _����3=value;}
			get{return _����3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����4
		{
			set{ _����4=value;}
			get{return _����4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����5
		{
			set{ _����5=value;}
			get{return _����5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����6
		{
			set{ _����6=value;}
			get{return _����6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Double ����
		{
			set{ _����=value;}
			get{return _����;}
		}
		#endregion Model

	}
}

