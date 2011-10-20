using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using LotteryTicketData.Model;
namespace LotteryTicketData.BLL
{
	/// <summary>
	/// ҵ���߼���tb_ssq ��ժҪ˵����
	/// </summary>
	public class tb_ssq
	{
		private readonly LotteryTicketData.DAL.tb_ssq dal=new LotteryTicketData.DAL.tb_ssq();
		public tb_ssq()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Double �ں�)
		{
			return dal.Exists(�ں�);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(LotteryTicketData.Model.tb_ssq model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LotteryTicketData.Model.tb_ssq model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Double �ں�)
		{
			
			dal.Delete(�ں�);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModel(Double �ں�)
		{
			
			return dal.GetModel(�ں�);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModelByCache(Double �ں�)
		{
			
			string CacheKey = "tb_ssqModel-" + �ں�;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(�ں�);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LotteryTicketData.Model.tb_ssq)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LotteryTicketData.Model.tb_ssq> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LotteryTicketData.Model.tb_ssq> DataTableToList(DataTable dt)
		{
			List<LotteryTicketData.Model.tb_ssq> modelList = new List<LotteryTicketData.Model.tb_ssq>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LotteryTicketData.Model.tb_ssq model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LotteryTicketData.Model.tb_ssq();
					if(dt.Rows[n]["��������"].ToString()!="")
					{
						model.��������=DateTime.Parse(dt.Rows[n]["��������"].ToString());
					}
					//model.�ں�=dt.Rows[n]["�ں�"].ToString();
					//model.����1=dt.Rows[n]["����1"].ToString();
					//model.����2=dt.Rows[n]["����2"].ToString();
					//model.����3=dt.Rows[n]["����3"].ToString();
					//model.����4=dt.Rows[n]["����4"].ToString();
					//model.����5=dt.Rows[n]["����5"].ToString();
					//model.����6=dt.Rows[n]["����6"].ToString();
					//model.����=dt.Rows[n]["����"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

