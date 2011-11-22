/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-09-30 11:54:03
 * 版权：版权所有 (C) 新生命开发团队 2011
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection ;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.Tools.Controls ;
using XCode ;
using NewLife ;
using NewLife.Reflection;

namespace DotNet.Tools.Controls
{
	public partial class DataManage: UserControl
	{
		#region 初始化,属性及字段
		public DataManage()
		{
			InitializeComponent();
		}
		List<IEntity> btList; //实体列表
		string cutSql ;//当前查询字符串
		string _formAssemblyName ;//添加窗体所在的程序集名称
		/// <summary>
		/// 添加窗体所在程序的名称
		/// </summary>
		public string FormAssemblyName
		{
			set {_formAssemblyName = value ;}
			get {return _formAssemblyName ;}
		}
		string _formName ; //添加窗体的名称,反射添加窗体
		/// <summary>
		/// 添加窗体的名称
		/// </summary>
		public string FormName
		{
			set {_formName = value ;}
			get {return _formName ;}
		}
		bool isHaveMenu ;//是否开启菜单
		/// <summary>
		/// 是否使得添加按钮可用
		/// </summary>
		public bool IsEnableAddBtn
		{
			get ;set ;
		}
		/// <summary>
		/// 是否开启右键菜单
		/// </summary>
		public bool IsHaveMenu
		{
			get {return isHaveMenu ;}
			set
			{
				if (value )
				{
					dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
						new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
						new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
					winPage.PageSize = 50;
				}
				isHaveMenu = value ;}
		}
		//窗体加载事件
		void DataManageLoad(object sender, EventArgs e)
		{
			if (!DesignMode ){
				cutSql = string.Empty ; //当前查询字符串
			}
		}
		Type _entityType;
		/// <summary>
		/// 实体类型
		/// </summary>
		public Type EntityType
		{
			set
			{
				if (value !=null ) {
					_entityOper = EntityFactory.CreateOperate(value);
				_entityType = value;
				string maininfo = EntityOper.Table.Description;
//				stausInfoShow1.SetAllToolInfo(maininfo, "YoungRun.NET管理系统",
//				                              "当前系统时间：" + DateTime.Today.ToShortDateString());
				}				
			}
			get
			{
				return _entityType;
			}
		}
		IEntityOperate _entityOper;
		public IEntityOperate EntityOper
		{
			set {
				if (value !=null ) {
					_entityOper = value;
				} }
			get { return _entityOper; }
		}
		/// <summary>
		/// 初始化配置
		/// </summary>
		/// <param name="entityType">实体类型</param>
		/// <param name="formAssemblyName">窗体程序集名称</param>
		/// <param name="formName">窗体名称</param>
		/// <param name="IsHaveDgvMenu">是否显示菜单</param>
		/// <param name="IsHaveSelectSum">是否开启动态求和功能</param>
		/// <param name="pageSize">分页数</param>
		public void InitializeSettings(Type entityType,string formAssemblyName = "",string formName="",
		                               bool IsHaveDgvMenu = false,bool IsHaveSelectSum =false ,int pageSize = 20,
		                               string firStatus="数据管理模块",string secStatus="",string thirdStatus="开发:asxinyu@qq.com")
		{
			if (formAssemblyName !="" && formName !="") {
				IsEnableAddBtn = true ;
				this.FormAssemblyName = formAssemblyName ;
				this.FormName = formName ;
			}
			else
			{
				IsEnableAddBtn = false ;
			}
			if (IsHaveSelectSum ) {
				this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);	
				this.stausInfoShow1.SetToolInfo1 (firStatus );
				this.stausInfoShow1.SetToolInfo3 (thirdStatus );
			}
			else
			{
				this.stausInfoShow1.SetToolInfo1 (firStatus );
				this.stausInfoShow1.SetToolInfo2 (secStatus ); 
				this.stausInfoShow1.SetToolInfo3 (thirdStatus );
			}
			this.EntityType = entityType ;
			this.IsHaveMenu = IsHaveDgvMenu ;
			this.winPage.PageSize = pageSize ;
		}
		#endregion

		#region 菜单事件
		//IListSource ls=btList as IListSource ;
		//dgv.DataSource = ls.GetList(); ;// btList ;
		//Type type = typeof(EntityList<>).MakeGenericType(_entityType);
		//IList list = TypeX.CreateInstance(type) as System.Collections.IList;	
		//获取数据并绑定到dgv    列的 SortMode 不能设置为 Automatic。
		//List<IEntity> btlist;
		//IEntityList btList; //实体列表
		void GetData()
		{
			// winPage.RecordCount = EntityOper.FindCount(cutSql, "", "", 0, 0);
            btList =EntityOper.FindAll(cutSql, "", "", (winPage.PageIndex - 1) * winPage.PageSize,
			                            winPage.PageSize).ToList ();
			dgv.DataSource = btList;
			ArrayList list = new ArrayList();
			for (int i = 0; i < btList.Count; i++)
			{
				list.Add(btList[i]);
			}
			dgv.DataSource = list;
		}
		
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			if (isHaveMenu && dgv.CurrentCell !=null ) {
				dgv.BeginEdit(false);
			}
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
			if (!isHaveMenu) {
				return ;
			}
			try
			{
				if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
				    == DialogResult.Yes)
				{
					int count = dgv.SelectedCells.Count;
					List<int> index = new List<int>();
					for (int i = 0; i < count; i++)
					{
						int RowIndex = dgv.SelectedCells[i].RowIndex;
						if (!index.Contains(RowIndex))
						{
							btList[RowIndex].Delete();
						}
					}
				}
				else
					return;
			}
			catch (Exception err)
			{
				MessageBox.Show("删除出错:" + err.Message);
			}
			ToolFindClick(sender, e);
		}
		#endregion
		
		#region 添加 查找 退出
		//添加
		void ToolAddClick(object sender, EventArgs e)
		{
			if (IsEnableAddBtn ) {
                Assembly assembly = Assembly.LoadFrom(FormAssemblyName);
                Type T = assembly.GetType(FormName);
                Form controller = (Form)Activator.CreateInstance(T, null);
                //IEntityControl T ;
                //FormModel controller = WinFormHelper.GetControlForm <>();
				if (controller.ShowDialog ()== DialogResult.OK )
				{
					GetData () ;
				}
			}
		}
		void ToolFindClick(object sender, EventArgs e)
		{
			GetData () ;
		}
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		#endregion
		
		#region 搜索 分页
		//搜索事件
		void BtnSearchClick(object sender, EventArgs e)
		{
			GetData () ;
		}
		//设置查询条件
		void ToolExportToExcelClick(object sender, EventArgs e)
		{
			SearchConditionForm sf = new SearchConditionForm () ;
			sf.CutEntityName = EntityOper.TableName ;
			sf.CurConditions = cutSql ;
			if (sf.ShowDialog ()== DialogResult.OK ) {
				cutSql = sf.CurConditions ;
				//在此更新所有记录信息
				winPage.RecordCount = EntityOper.FindCount(cutSql, "", "", 0, 0);
				GetData () ;
			}
		}
		//数据分页事件
		private void winPage_PageIndexChanged(object sender, EventArgs e)
		{
			GetData();
		}
		#endregion	

		#region 求和操作
		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			stausInfoShow1.SetToolInfo2("和值:" + WinFormHelper.GetDynamicSecletedInfo(dgv)[0].ToString());
		}
		#endregion		
	}
}