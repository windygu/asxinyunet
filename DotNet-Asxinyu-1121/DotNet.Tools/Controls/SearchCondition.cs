using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XCode ;
using XCode.Configuration;

namespace DotNet.Tools.Controls
{
	public partial class SearchCondition : UserControl
	{
		#region 初始化
		public SearchCondition()
		{
			InitializeComponent();
			txtConditions.Text = "";
			_curCondtions = string.Empty ;
			IsAotoMode = false ;
			CutIndexStatus = 0 ;
			dtDatime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			dtDatime.Visible = false ;
		}
		public SearchCondition(string[] names)
		{
			InitializeComponent();
			combColumName.Items.Clear();
			combColumName.Items.AddRange(names);
		}
		bool IsSetConditon ;//是否设置过条件，否则将按照默认条件进行处理
		#endregion
		
		#region 属性
		/// <summary>
		/// 设置列名称
		/// </summary>
		public string[] ColumnsName
		{
			set
			{
				combColumName.Items.Clear();
				combColumName.Items.AddRange(value );
				combColumType.Items.Clear();
				combColumType.Items.AddRange(new string[] { "=", "like", ">", "<", ">=", "<=" });
			}
		}
		/// <summary>
		/// 获取当前的条件字符串
		/// </summary>
		public string CurConditions
		{
			get {return GetConditions ();}
			set {_curCondtions = value ;
				txtConditions.Text = value ;}
		}
		string _curCondtions ;
		/// <summary>
		/// 实体的字段描述信息
		/// </summary>
		string[][] EntityDescript;
		Type[] DataType;
		/// <summary>
		/// 设置实体名称
		/// </summary>
		public Type EntityName
		{
			set {
				//初始化
				IsAotoMode = true;
				IEntityOperate Entity = EntityFactory.CreateOperate(value);
				IEntity EnItem = EntityFactory.Create(value );
				EntityDescript = new string[3][];
				EntityDescript [0] = new string [Entity.Fields.Length] ;
				EntityDescript [1] = new string [Entity.Fields.Length] ;
				EntityDescript [2] = new string [Entity.Fields.Length] ;
				DataType = new Type[Entity.Fields.Length];
				for (int i = 0; i < DataType.Length ; i++)
				{
					EntityDescript[0][i] = Entity.Fields[i ].Field.Description ;//第一行是描述
					EntityDescript[1][i] = Entity.Fields[i].Field.Name; //第二行为英文字段名
					EntityDescript[2][i] = EntityDescript[0][i] +"("+EntityDescript[1][i]+")"; //第二行为英文字段名
					DataType [i ] = Entity.Fields[i].Field.DataType ;
				}
				combColumName.Items.Clear();
				combColumName.Items.AddRange(EntityDescript[2]);
				combColumName.SelectedIndex = -1;
				combColumName.SelectedIndex = 1 ;
				CombSelectedIndex(combColumName.SelectedIndex ) ;
			}
		}
		
		public string CutEntityName
		{
			set {
				//初始化
				IsAotoMode = true;
				IEntityOperate Entity = EntityFactory.CreateOperate(value);
				IEntity EnItem = EntityFactory.Create(value );
				EntityDescript = new string[3][];
				EntityDescript [0] = new string [Entity.Fields.Length] ;
				EntityDescript [1] = new string [Entity.Fields.Length] ;
				EntityDescript [2] = new string [Entity.Fields.Length] ;
				DataType = new Type[Entity.Fields.Length];
				for (int i = 0; i < DataType.Length ; i++)
				{
					EntityDescript[0][i] = Entity.Fields[i ].Field.Description ;//第一行是描述
					EntityDescript[1][i] = Entity.Fields[i].Field.Name; //第二行为英文字段名
					EntityDescript[2][i] = EntityDescript[0][i] +"("+EntityDescript[1][i]+")"; //第二行为英文字段名
					DataType [i ] = Entity.Fields[i].Field.DataType ;
				}
				combColumName.Items.Clear();
				combColumName.Items.AddRange(EntityDescript[2]);
				combColumName.SelectedIndex = -1;
				combColumName.SelectedIndex = 1 ;
				CombSelectedIndex(combColumName.SelectedIndex ) ;
			}
		}
		/// <summary>
		/// 开启智能模式,只需要实体名称即可
		/// </summary>
		public bool IsAotoMode
		{
			get;
			set;
		}

		int CutIndexStatus;//字段类型的标识
		static string[] typeOfValue = { "=", ">", "<", ">=", "<=" } ;
		static string[] typeOfString = {"=", "Like"} ;
		#endregion
		
		#region 重置和提交条件
		private void btnReset_Click(object sender, EventArgs e)
		{
			txtValue.Text = string.Empty;
			combColumName.Text =string.Empty ;
			combColumType.Text =string.Empty ;			
		}
		//提交条件
		private void btnGetCondition_Click(object sender, EventArgs e)
		{
			//提交得到条件
			if (CutIndexStatus ==2) {
				if (combColumName.Text !="" && combColumType.Text.Trim () !="" )
				{
					txtConditions.Text = ParseCondition() + ";" + txtConditions.Text.Trim();
					IsSetConditon = true ;
				}
			}
			else
			{
				if (combColumName.Text !="" && combColumType.Text.Trim () !="" && txtValue.Text .Trim ()!="")
				{
					txtConditions.Text = ParseCondition() + ";" + txtConditions.Text.Trim();
					IsSetConditon = true ;
				}
			}
		}
		#endregion

		#region 解析获取条件
		//解析条件
		string ParseCondition()
		{
			if (IsAotoMode)
			{
				//根据当前选择字段的类型和选择的条件操作符来判定
				//日期型和字符串都需要加引号,根据CutIndexStatus来确定当前的类型，避免重复判断
				if (CutIndexStatus == 1 ) //数值
				{
					return EntityDescript[1][combColumName.SelectedIndex] + combColumType.Text.Trim()
						+ txtValue.Text.Trim();
				}
				else if ( CutIndexStatus == 3)//字符串
				{
					if (combColumType.Text.Trim() == "=")
					{
						return EntityDescript[1][combColumName.SelectedIndex] + " " + combColumType.Text.Trim()
							+ " '" + txtValue.Text.Trim() + "' ";
					}
					else //Like查询
					{
						return EntityDescript[1][combColumName.SelectedIndex] + " " + combColumType.Text.Trim()
							+ " '%" + txtValue.Text.Trim() + "%' ";
					}
				}
				else //日期
				{
					return EntityDescript[1][combColumName.SelectedIndex] + " " + combColumType.Text.Trim()
						+ " '" + dtDatime.Value.ToString () + "' ";
				}
			}
			else
			{
				string str = combColumName.Text.Trim();
				int fir = str.IndexOf('(') + 1;
				int last = str.IndexOf(')');
				return str.Substring(fir, last - fir) + " " + combColumType.Text.Trim() + " " +
					txtValue.Text.Trim();
			}
		}

		private string GetConditions()
		{
			if (IsSetConditon ) {
				string[] sqlStr = txtConditions.Text.Trim().Split(';');
				bool flag = false;
				string sql = "";
				for (int i = 0; i < sqlStr.Length; i++)
				{
					if (sqlStr[i].Trim() != "")
					{
						if (flag)
						{
							sql += (" and " + sqlStr[i]);
						}
						else
						{
							sql += sqlStr[i];
							flag = true;
						}
					}
				}
				return sql;
			}
			else
			{
				return _curCondtions ;
			}
		}
		#endregion

		#region 按钮事件
		private void btnOK_Click(object sender, EventArgs e)
		{
			IsSetConditon = true ;
			this.ParentForm.DialogResult = DialogResult.OK;
			this.ParentForm.Close () ;
		}
		private void btnCancle_Click(object sender, EventArgs e)
		{
			this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close () ;
		}
		void BtnResetConditonClick(object sender, EventArgs e)
		{
			txtConditions.Text = string.Empty ;
			IsSetConditon = true ;
		}

		private void combColumName_SelectedIndexChanged(object sender, EventArgs e)
		{
			//1为数值型，2为日期型，3为字符串
			//根据选择的项目的顺序来填充类型列表框
			if (IsAotoMode  )
			{
				int index = combColumName.SelectedIndex;
				CombSelectedIndex (index ) ;
			}
		}
		
		void CombSelectedIndex(int index)
		{
			
			if((DataType[index] == typeof(Int32 ))||(DataType[index] == typeof(int))||
			   (DataType[index] == typeof(Int16))||(DataType[index] == typeof(Int64))||
			   (DataType[index] == typeof(double))||(DataType[index] == typeof(float))||
			   (DataType[index] == typeof(byte))||(DataType[index] == typeof(decimal))||
			   (DataType[index] == typeof(Single)))
			{
				//数值型
				if (CutIndexStatus ==3 || CutIndexStatus == 0)
				{
					txtValue .Visible = true ;
					dtDatime.Visible =false ;
					combColumType.Items.Clear();
					combColumType.Items.AddRange(typeOfValue );
				}
				CutIndexStatus = 1;
			}
			else if ((DataType[index] == typeof(DateTime)))
			{
				//文本框不可见，Dt可见
				txtValue.Visible = false ;
				dtDatime.Visible = true ;
				if (CutIndexStatus == 3||CutIndexStatus == 0) //是字符串类型，才需要改
				{
					combColumType.Items.Clear();
					combColumType.Items.AddRange (typeOfValue);
				}
				CutIndexStatus = 2;
			}
			else//剩余的为字符型
			{
				if (CutIndexStatus != 3 ||CutIndexStatus == 0)
				{
					txtValue .Visible = true ;
					dtDatime.Visible =false ;
					combColumType.Items.Clear();
					combColumType.Items.AddRange(typeOfString );
				}
				CutIndexStatus = 3;
			}
		}
		#endregion
	}
}