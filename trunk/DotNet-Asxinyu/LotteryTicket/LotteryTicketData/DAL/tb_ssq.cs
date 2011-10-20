using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//�����������
namespace LotteryTicketData.DAL
{
	/// <summary>
	/// ���ݷ�����tb_ssq��
	/// </summary>
	public class tb_ssq
	{
		public tb_ssq()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Double �ں�)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_ssq");
			strSql.Append(" where �ں�=@�ں� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@�ں�", OleDbType.Double)};
			parameters[0].Value = �ں�;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(LotteryTicketData.Model.tb_ssq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ssq(");
			strSql.Append("��������,�ں�,����1,����2,����3,����4,����5,����6,����)");
			strSql.Append(" values (");
			strSql.Append("@��������,@�ں�,@����1,@����2,@����3,@����4,@����5,@����6,@����)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��������", OleDbType.Date),
					new OleDbParameter("@�ں�", OleDbType.Double),
					new OleDbParameter("@����1", OleDbType.Double),
					new OleDbParameter("@����2", OleDbType.Double),
					new OleDbParameter("@����3", OleDbType.Double),
					new OleDbParameter("@����4", OleDbType.Double),
					new OleDbParameter("@����5", OleDbType.Double),
					new OleDbParameter("@����6", OleDbType.Double),
					new OleDbParameter("@����", OleDbType.Double)};
			parameters[0].Value = model.��������;
			parameters[1].Value = model.�ں�;
			parameters[2].Value = model.����1;
			parameters[3].Value = model.����2;
			parameters[4].Value = model.����3;
			parameters[5].Value = model.����4;
			parameters[6].Value = model.����5;
			parameters[7].Value = model.����6;
			parameters[8].Value = model.����;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LotteryTicketData.Model.tb_ssq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ssq set ");
			strSql.Append("��������=@��������,");
			strSql.Append("�ں�=@�ں�,");
			strSql.Append("����1=@����1,");
			strSql.Append("����2=@����2,");
			strSql.Append("����3=@����3,");
			strSql.Append("����4=@����4,");
			strSql.Append("����5=@����5,");
			strSql.Append("����6=@����6,");
			strSql.Append("����=@����");
			strSql.Append(" where �ں�=@�ں� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��������", OleDbType.Date),
					new OleDbParameter("@�ں�", OleDbType.Double),
					new OleDbParameter("@����1", OleDbType.Double),
					new OleDbParameter("@����2", OleDbType.Double),
					new OleDbParameter("@����3", OleDbType.Double),
					new OleDbParameter("@����4", OleDbType.Double),
					new OleDbParameter("@����5", OleDbType.Double),
					new OleDbParameter("@����6", OleDbType.Double),
					new OleDbParameter("@����", OleDbType.Double)};
			parameters[0].Value = model.��������;
			parameters[1].Value = model.�ں�;
			parameters[2].Value = model.����1;
			parameters[3].Value = model.����2;
			parameters[4].Value = model.����3;
			parameters[5].Value = model.����4;
			parameters[6].Value = model.����5;
			parameters[7].Value = model.����6;
			parameters[8].Value = model.����;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Double �ں�)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ssq ");
			strSql.Append(" where �ں�=@�ں� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@�ں�", OleDbType.Double)};
			parameters[0].Value = �ں�;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModel(Double �ں�)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ��������,�ں�,����1,����2,����3,����4,����5,����6,���� from tb_ssq ");
			strSql.Append(" where �ں�=@�ں� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@�ں�", OleDbType.Double)};
			parameters[0].Value = �ں�;

			LotteryTicketData.Model.tb_ssq model=new LotteryTicketData.Model.tb_ssq();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["��������"].ToString()!="")
				{
					model.��������=DateTime.Parse(ds.Tables[0].Rows[0]["��������"].ToString());
				}
				//model.�ں�=ds.Tables[0].Rows[0]["�ں�"].ToString();
				//model.����1=ds.Tables[0].Rows[0]["����1"].ToString();
				//model.����2=ds.Tables[0].Rows[0]["����2"].ToString();
				//model.����3=ds.Tables[0].Rows[0]["����3"].ToString();
				//model.����4=ds.Tables[0].Rows[0]["����4"].ToString();
				//model.����5=ds.Tables[0].Rows[0]["����5"].ToString();
				//model.����6=ds.Tables[0].Rows[0]["����6"].ToString();
				//model.����=ds.Tables[0].Rows[0]["����"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ��������,�ں�,����1,����2,����3,����4,����5,����6,���� ");
			strSql.Append(" FROM tb_ssq ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Bit),
					new OleDbParameter("@OrderType", OleDbType.Bit),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_ssq";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

