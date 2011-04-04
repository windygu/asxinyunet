using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using LotteryTicketData.Model;
namespace LotteryTicketData.BLL
{
	/// <summary>
	/// 业务逻辑类tb_ssq 的摘要说明。
	/// </summary>
	public class tb_ssq
	{
		private readonly LotteryTicketData.DAL.tb_ssq dal=new LotteryTicketData.DAL.tb_ssq();
		public tb_ssq()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Double 期号)
		{
			return dal.Exists(期号);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LotteryTicketData.Model.tb_ssq model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LotteryTicketData.Model.tb_ssq model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Double 期号)
		{
			
			dal.Delete(期号);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModel(Double 期号)
		{
			
			return dal.GetModel(期号);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModelByCache(Double 期号)
		{
			
			string CacheKey = "tb_ssqModel-" + 期号;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(期号);
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LotteryTicketData.Model.tb_ssq> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
					if(dt.Rows[n]["开奖日期"].ToString()!="")
					{
						model.开奖日期=DateTime.Parse(dt.Rows[n]["开奖日期"].ToString());
					}
					//model.期号=dt.Rows[n]["期号"].ToString();
					//model.号码1=dt.Rows[n]["号码1"].ToString();
					//model.号码2=dt.Rows[n]["号码2"].ToString();
					//model.号码3=dt.Rows[n]["号码3"].ToString();
					//model.号码4=dt.Rows[n]["号码4"].ToString();
					//model.号码5=dt.Rows[n]["号码5"].ToString();
					//model.号码6=dt.Rows[n]["号码6"].ToString();
					//model.红球=dt.Rows[n]["红球"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

