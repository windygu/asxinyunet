/*
 * 由SharpDevelop创建。
 * 用户：asxinyu
 * 日期: 2011-10-8
 * 时间: 17:17
 *
 * 目标：添加按钮事件、绑定实体
 * 2011-11-08 增加注释，完善格式，完成基本功能调试，修改控件显示Bug
 * 2011-10-18 修改各种状态下的显示Bug,基本满足了大致需求
 * 2011-10-16 增加完善数据初始化与数据绑定,修正生成过程的相关错误,并增加初始化函数,增加对于的窗体文件生成
 * 2011-10-14 增加实体分页控件,窗体不同状态的改变
 * 2011-10-13 增加了实体按钮保存功能，并根据不同窗体状态进行返回
 * 2011-10-12 初步模板调试成功,对模板进行重构，减少了大量代码,并增加相关属性和验证方法
 * 2011-10-11 增加按钮，和错误显示控件，开始进行控件的验证
 * 2011-10-09 初步模板调试成功，修改完成，完成初步的控件生成、命名和简单的一列布局模式
 * 2011-10-08 开始设计基本模板，初步成功
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity;
using DotNet.Tools.Controls ;

namespace YoungRunControl
{	
	public class AddReseachSample: UserControl
	{
		#region 自动生成代码
		#region Designer.cs必须代码
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#endregion		
		#region 控件定义
		private System.Windows.Forms.TextBox txtID ;
		private System.Windows.Forms.Label    lblID ;
private System.Windows.Forms.TextBox txtOilName ;
		private System.Windows.Forms.Label    lblOilName ;

		private System.Windows.Forms.ComboBox combProviderTP ;
		private System.Windows.Forms.Label    lblProviderTP ;
private System.Windows.Forms.TextBox txtDataID ;
		private System.Windows.Forms.Label    lblDataID ;

		private System.Windows.Forms.ComboBox combSendPersonTP ;
		private System.Windows.Forms.Label    lblSendPersonTP ;
private System.Windows.Forms.DateTimePicker dtSendDateTime ;
		private System.Windows.Forms.Label    lblSendDateTime ;
private System.Windows.Forms.TextBox txtRemark ;
		private System.Windows.Forms.Label    lblRemark ;
   private System.Windows.Forms.ErrorProvider errorProvider1 ;
		private System.Windows.Forms.Button btnOK ;
		private System.Windows.Forms.Button btnCancle ;
		private DotNet.Tools.Controls.EntityFormPager FormPager;
		#endregion
		
		#region 组件设计器生成的代码
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReseachSample));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
			
			this.lblID = new System.Windows.Forms.Label() ;
			this.lblID.AutoSize = true;
			this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(10,16);
			this.lblID.TabIndex = 200 ;
			this.lblID.Text = "记录编号";
			this.Controls.Add(this.lblID) ;
		
			this.lblOilName = new System.Windows.Forms.Label() ;
			this.lblOilName.AutoSize = true;
			this.lblOilName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblOilName.Name = "lblOilName";
			this.lblOilName.Size = new System.Drawing.Size(10,16);
			this.lblOilName.TabIndex = 200 ;
			this.lblOilName.Text = "油品名称";
			this.Controls.Add(this.lblOilName) ;
		
			this.lblProviderTP = new System.Windows.Forms.Label() ;
			this.lblProviderTP.AutoSize = true;
			this.lblProviderTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblProviderTP.Name = "lblProviderTP";
			this.lblProviderTP.Size = new System.Drawing.Size(10,16);
			this.lblProviderTP.TabIndex = 200 ;
			this.lblProviderTP.Text = "负责人";
			this.Controls.Add(this.lblProviderTP) ;
		
			this.lblDataID = new System.Windows.Forms.Label() ;
			this.lblDataID.AutoSize = true;
			this.lblDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDataID.Name = "lblDataID";
			this.lblDataID.Size = new System.Drawing.Size(10,16);
			this.lblDataID.TabIndex = 200 ;
			this.lblDataID.Text = "数据编号";
			this.Controls.Add(this.lblDataID) ;
		
			this.lblSendPersonTP = new System.Windows.Forms.Label() ;
			this.lblSendPersonTP.AutoSize = true;
			this.lblSendPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblSendPersonTP.Name = "lblSendPersonTP";
			this.lblSendPersonTP.Size = new System.Drawing.Size(10,16);
			this.lblSendPersonTP.TabIndex = 200 ;
			this.lblSendPersonTP.Text = "送样人";
			this.Controls.Add(this.lblSendPersonTP) ;
		
			this.lblSendDateTime = new System.Windows.Forms.Label() ;
			this.lblSendDateTime.AutoSize = true;
			this.lblSendDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblSendDateTime.Name = "lblSendDateTime";
			this.lblSendDateTime.Size = new System.Drawing.Size(10,16);
			this.lblSendDateTime.TabIndex = 200 ;
			this.lblSendDateTime.Text = "送样时间";
			this.Controls.Add(this.lblSendDateTime) ;
		
			this.lblRemark = new System.Windows.Forms.Label() ;
			this.lblRemark.AutoSize = true;
			this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(10,16);
			this.lblRemark.TabIndex = 200 ;
			this.lblRemark.Text = "备注";
			this.Controls.Add(this.lblRemark) ;
		
			this.lblID.Location = new System.Drawing.Point(6, 10);	
			this.txtID = new System.Windows.Forms.TextBox() ;
			this.txtID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtID.Location = new System.Drawing.Point(158, 10);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(150,22);
			this.txtID.TabIndex = 0 ;
			this.Controls.Add(this.txtID) ;
			this.lblOilName.Location = new System.Drawing.Point(6, 37);	
			this.txtOilName = new System.Windows.Forms.TextBox() ;
			this.txtOilName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOilName.Location = new System.Drawing.Point(158, 37);
			this.txtOilName.Name = "txtOilName";
			this.txtOilName.Size = new System.Drawing.Size(150,22);
			this.txtOilName.TabIndex = 2 ;
			this.Controls.Add(this.txtOilName) ;
			this.lblProviderTP.Location = new System.Drawing.Point(6, 64);
			
			this.combProviderTP = new System.Windows.Forms.ComboBox() ;
			this.combProviderTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combProviderTP.FormattingEnabled = true;
			this.combProviderTP.Location = new System.Drawing.Point(158, 64);
			this.combProviderTP.Name = "combProviderTP";
			this.combProviderTP.Size = new System.Drawing.Size(150,22);
			this.combProviderTP.TabIndex = 4 ;
			this.Controls.Add(this.combProviderTP) ;
			
			this.lblDataID.Location = new System.Drawing.Point(6, 91);	
			this.txtDataID = new System.Windows.Forms.TextBox() ;
			this.txtDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDataID.Location = new System.Drawing.Point(158, 91);
			this.txtDataID.Name = "txtDataID";
			this.txtDataID.Size = new System.Drawing.Size(150,22);
			this.txtDataID.TabIndex = 6 ;
			this.Controls.Add(this.txtDataID) ;
			this.lblSendPersonTP.Location = new System.Drawing.Point(6, 118);
			
			this.combSendPersonTP = new System.Windows.Forms.ComboBox() ;
			this.combSendPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combSendPersonTP.FormattingEnabled = true;
			this.combSendPersonTP.Location = new System.Drawing.Point(158, 118);
			this.combSendPersonTP.Name = "combSendPersonTP";
			this.combSendPersonTP.Size = new System.Drawing.Size(150,22);
			this.combSendPersonTP.TabIndex = 8 ;
			this.Controls.Add(this.combSendPersonTP) ;
			
			this.lblSendDateTime.Location = new System.Drawing.Point(6, 145);	
			this.dtSendDateTime = new System.Windows.Forms.DateTimePicker() ;
			this.dtSendDateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtSendDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtSendDateTime.Location = new System.Drawing.Point(158, 145);
			this.dtSendDateTime.Name = "dtSendDateTime";
			this.dtSendDateTime.Size = new System.Drawing.Size(150,22);
			this.dtSendDateTime.TabIndex = 10 ;
			this.Controls.Add(this.dtSendDateTime) ;
			this.lblRemark.Location = new System.Drawing.Point(6, 172);	
			this.txtRemark = new System.Windows.Forms.TextBox() ;
			this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRemark.Location = new System.Drawing.Point(158, 172);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(150,22);
			this.txtRemark.TabIndex = 12 ;
			this.Controls.Add(this.txtRemark) ;
			#region 添加按钮
			this.btnOK = new System.Windows.Forms.Button();
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(26, 219);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "保存";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Controls.Add(this.btnOK);
			this.btnCancle = new System.Windows.Forms.Button();
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(106, 219);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = 16;
			this.btnCancle.Text = "取消";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
			this.Controls.Add(this.btnCancle);
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.errorProvider1.ContainerControl = this;

			this.FormPager.AutoSize = true;
			this.FormPager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FormPager.BackColor = System.Drawing.Color.Transparent;
			this.FormPager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FormPager.BackgroundImage")));
			this.FormPager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.FormPager.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormPager.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.FormPager.Location = new System.Drawing.Point(10, 249);
			this.FormPager.Name = "FormPager";
			this.FormPager.RecordCount = 0;
			this.FormPager.Size = new System.Drawing.Size(256, 29);
			this.FormPager.TabIndex = 100;
			this.Controls.Add(this.FormPager);
			this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
			#endregion
			#region 窗体
			this.Name = "AddReseachSample";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.AddAddReseachSampleLoad);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public AddReseachSample()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddReseachSampleLoad(object sender, EventArgs e){}
		/// <summary>
		/// 初始化设置
		/// </summary>
		/// <param name="showMode">窗体的显示模式,必须指定</param>
		/// <param name="searcgCondtion">指定显示的实体条件</param>
		/// <param name="fixCondition">固定的显示条件</param>
		public void InitializeSettings(FormShowMode showMode,string searcgCondtion = "",string fixCondition="")
		{
			this.FormPager.PageSize = 1;
            this.CutShowMode = showMode;
            this.CutSearchCondition = searcgCondtion;
            this.FixedSqlCondition = fixCondition;
            if (showMode == FormShowMode.AddOne || showMode == FormShowMode.ContinueAdd)
            {
                CustomerSettings();
                SetAllTextControls(ControlStatus.Edit);
            }
            else
            {
                SetAllTextControls(ControlStatus.ReadOnly);//只读
                GetData();
                BandingData();//绑定数据
            }
			//TODO:问题，只读显示一条记录时,需要传入当前的Model实体类进行绑定
		}
		/// <summary>
        /// 其他控件的特殊设置
        /// </summary>
        private void CustomerSettings()
        {
            //控件的特殊设置，如格式，显示,控件的绑定           
        }
		#endregion
				
		#region 相关字段与属性
		/// <summary>
		/// 固定的查询条件
		/// </summary>
		public string FixedSqlCondition {get ;set ;}
		string _curSeachCondition ;
		/// <summary>
		/// 获取或者设置当前的查询条件
		/// </summary>
		public string CutSearchCondition
		{
			get {return _curSeachCondition ;}
			set	{
				_curSeachCondition = "" ;
				if (FixedSqlCondition !=null && FixedSqlCondition !="") {
					if (value !=null && value!="") {
						_curSeachCondition +=(FixedSqlCondition +" and " +value ) ;
					}
					else
						_curSeachCondition = FixedSqlCondition ;
				}
				else{
				if (value !=null) {_curSeachCondition = value ;}
				else _curSeachCondition="" ;}
				//此记录数可以在加载时固定起来,不用每次都计算
				FormPager.RecordCount = tb_ReseachSample.FindCount(CutSearchCondition,"","",0,0) ;
			}
		}
		/// <summary>
		/// 获取或者设置当前实体
		/// </summary>
		public tb_ReseachSample CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{
			if(txtID.Text.Trim()=="")//记录编号
			{
				errorProvider1.SetError(txtID,"必填项目");
				return false ;
			}
			if(txtOilName.Text.Trim()=="")//油品名称
			{
				errorProvider1.SetError(txtOilName,"必填项目");
				return false ;
			}
			if(combProviderTP.Text.Trim()=="")//负责人
			{
				errorProvider1.SetError(combProviderTP,"必填项目");
				return false ;
			} 
			if(txtDataID.Text.Trim()=="")//数据编号
			{
				errorProvider1.SetError(txtDataID,"必填项目");
				return false ;
			}
			if(combSendPersonTP.Text.Trim()=="")//送样人
			{
				errorProvider1.SetError(combSendPersonTP,"必填项目");
				return false ;
			} 
			return true ;
		}
		#endregion

		#region 按钮事件
		void btnOK_Click(object sender, EventArgs e)
		{
			//TODO:有问题，需要根据当前的状态来更新和保存数据
			//当前实体状态不是只读并且通过验证后才能进行操作
			if (btnOK.Text.Contains ("修改")) SetAllTextControls(ControlStatus.Edit );
			else 
			{
				if(((CutShowMode!= FormShowMode.ReadOnlyForAll) || (CutShowMode != FormShowMode.ReadOnlyForOne)) && ValidateControls() )
				{
					tb_ReseachSample model = new tb_ReseachSample();//定义当前实体 
					if(txtID.Text.Trim()!="")  model.ID = txtID.Text.Trim()  ;//记录编号
					if(txtOilName.Text.Trim()!="")  model.OilName = txtOilName.Text.Trim()  ;//油品名称
					if(combProviderTP.Text.Trim()!="") model.ProviderTP = combProviderTP.Text.Trim() ;//负责人
					if(txtDataID.Text.Trim()!="")  model.DataID = txtDataID.Text.Trim()  ;//数据编号
					if(combSendPersonTP.Text.Trim()!="") model.SendPersonTP = combSendPersonTP.Text.Trim() ;//送样人
					model.SendDateTime = dtSendDateTime.Value ;//送样时间
					if(txtRemark.Text.Trim()!="")  model.Remark = txtRemark.Text.Trim()  ;//备注
					if (CutShowMode== FormShowMode.AddOne )
					{
						model.Insert () ;//添加
						MessageBox.Show ("添加成功") ;
						this.ParentForm.DialogResult = DialogResult.OK ;
					}
					else if (CutShowMode== FormShowMode.ContinueAdd )
					{
						model.Insert () ;//添加
						MessageBox.Show ("添加成功") ;
						SetAllTextControls(ControlStatus.ReSet ) ;
					}
					else if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent) 
					{
						model.Update () ;//修改更新
						this.btnOK.Text = "修改" ;
						SetAllTextControls(ControlStatus.ReadOnly );
					}
				}
			}
		}

		void btnCancle_Click(object sender, EventArgs e)
		{
			this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close();
		}
		#endregion

		#region 辅助事件
		void KeyPressForOnlyData(object sender, KeyPressEventArgs e)
		{
			//TODO:目前还有缺陷，需要准确的根据类型来配置。如有时只能输入整数，有时只能输入正数、小数点
			WinFormHelper.SetControlOnlyValue(sender, e);
		}
		//分页事件
		private void FormPager_PageIndexChanged(object sender, EventArgs e)	{GetData ();}
		List <tb_ReseachSample> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = tb_ReseachSample.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
			if (modelList !=null ) {
				CutModel = modelList[0];//绑定实体					
				BandingData();//绑定数据
			}
		}
		#endregion

		#region 根据状态设置控件
		//设置文本控件的可用性
		private void SetAllTextControls(ControlStatus ctr)
		{
			if (CutShowMode== FormShowMode.AddOne || CutShowMode == FormShowMode.ContinueAdd ||CutShowMode== FormShowMode.DisplayCurrent||CutShowMode== FormShowMode.ReadOnlyForOne )
				FormPager.Visible = false ;
			else FormPager.Visible = true ;
			switch (ctr)
			{
				case ControlStatus.ReSet :
					SetControlReSet () ;
				return ;
				case ControlStatus.Edit :
					SetControlEdit () ;
				return ;
				case ControlStatus.ReadOnly :
					SetControlReadOnly () ;
				return ;
			}
			
		}
		private void SetControlReSet()
		{
			//只可能是添加新记录
			if (CutShowMode == FormShowMode.AddOne || CutShowMode== FormShowMode.ContinueAdd )
			{
				btnOK.Enabled = true ;
				btnOK.Text ="保存";
				//设置控件清空，并且可用
				txtID.ReadOnly = false ;//记录编号
				txtID.Text = string.Empty  ; 
				txtOilName.ReadOnly = false ;//油品名称
				txtOilName.Text = string.Empty  ; 
				combProviderTP.Enabled = true ; //负责人	
				txtDataID.ReadOnly = false ;//数据编号
				txtDataID.Text = string.Empty  ; 
				combSendPersonTP.Enabled = true ; //送样人	
				txtRemark.ReadOnly = false ;//备注
				txtRemark.Text = string.Empty  ; 
				}
		}
		private void SetControlEdit()
		{
			if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
				btnOK .Enabled = true ;
				btnOK.Text =" 保存";
				//控件除主键外都可读
				txtID.ReadOnly = true;//记录编号txtOilName.ReadOnly = false ;//油品名称
				combProviderTP.Enabled = true ;//负责人
				txtDataID.ReadOnly = false ;//数据编号
				combSendPersonTP.Enabled = true ;//送样人
				dtSendDateTime.Enabled = true ;//送样时间
				txtRemark.ReadOnly = false ;//备注
				}
		}
		private void SetControlReadOnly()
		{
			//直接设置为只读
			if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ){
				btnOK .Enabled = true ;
				btnOK.Text ="修改";
			}
			if (CutShowMode == FormShowMode.ReadOnlyForOne || CutShowMode== FormShowMode.ReadOnlyForAll ){
				btnOK.Enabled = false ;
			}
			txtID.ReadOnly = true  ;//记录编号
			txtOilName.ReadOnly = true  ;//油品名称
			combProviderTP.Enabled = false ;//负责人
			txtDataID.ReadOnly = true  ;//数据编号
			combSendPersonTP.Enabled = false ;//送样人
			dtSendDateTime.Enabled = false   ;//送样时间
			txtRemark.ReadOnly = true  ;//备注
		}
		#endregion

		#region 绑定数据
		 /// <summary>
		/// 加载子窗口:if(Field.PrimaryKey) continue;
		/// </summary>
		private void BandingData()
		{
			txtID.DataBindings.Clear();//记录编号
			txtID.DataBindings.Add ("Text",CutModel,"ID");
			txtOilName.DataBindings.Clear();//油品名称
			txtOilName.DataBindings.Add ("Text",CutModel,"OilName");
			combProviderTP.DataBindings.Clear () ;//负责人
			combProviderTP.DataBindings.Add ("Text",CutModel,"ProviderTP") ;
			txtDataID.DataBindings.Clear();//数据编号
			txtDataID.DataBindings.Add ("Text",CutModel,"DataID");
			combSendPersonTP.DataBindings.Clear () ;//送样人
			combSendPersonTP.DataBindings.Add ("Text",CutModel,"SendPersonTP") ;
			dtSendDateTime.DataBindings.Clear () ;//送样时间
			dtSendDateTime.DataBindings.Add ("Value",CutModel,"SendDateTime") ;
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}