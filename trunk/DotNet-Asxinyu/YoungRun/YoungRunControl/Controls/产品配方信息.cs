	/*
	 * 由SharpDevelop创建。
	 * 用户： asxinyu
	 * 日期: 2011-10-8
	 * 时间: 17:17
	 *
	 * 目标：添加按钮事件、绑定实体
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

	namespace YoungRunControl.Controls
	{

		
			public class AddProductFormule: UserControl
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
				
						private System.Windows.Forms.ComboBox combProductIdTP ;
					private System.Windows.Forms.Label    lblProductIdTP ;
				
						private System.Windows.Forms.ComboBox combProductNameTP ;
					private System.Windows.Forms.Label    lblProductNameTP ;
				private System.Windows.Forms.TextBox txtBtCount ;
					private System.Windows.Forms.Label    lblBtCount ;
				private System.Windows.Forms.TextBox txtT501Count ;
					private System.Windows.Forms.Label    lblT501Count ;
				private System.Windows.Forms.TextBox txtT602Count ;
					private System.Windows.Forms.Label    lblT602Count ;
				private System.Windows.Forms.TextBox txtYJCount ;
					private System.Windows.Forms.Label    lblYJCount ;
				private System.Windows.Forms.DateTimePicker dtUpdateTime ;
					private System.Windows.Forms.Label    lblUpdateTime ;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductFormule));
            this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
            this.lblProductIdTP = new System.Windows.Forms.Label();
            this.lblProductNameTP = new System.Windows.Forms.Label();
            this.lblBtCount = new System.Windows.Forms.Label();
            this.lblT501Count = new System.Windows.Forms.Label();
            this.lblT602Count = new System.Windows.Forms.Label();
            this.lblYJCount = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.combProductIdTP = new System.Windows.Forms.ComboBox();
            this.combProductNameTP = new System.Windows.Forms.ComboBox();
            this.txtBtCount = new System.Windows.Forms.TextBox();
            this.txtT501Count = new System.Windows.Forms.TextBox();
            this.txtT602Count = new System.Windows.Forms.TextBox();
            this.txtYJCount = new System.Windows.Forms.TextBox();
            this.dtUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPager
            // 
            this.FormPager.AutoSize = true;
            this.FormPager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormPager.BackColor = System.Drawing.Color.Transparent;
            this.FormPager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FormPager.BackgroundImage")));
            this.FormPager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FormPager.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormPager.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FormPager.Location = new System.Drawing.Point(10, 276);
            this.FormPager.Name = "FormPager";
            this.FormPager.RecordCount = 0;
            this.FormPager.Size = new System.Drawing.Size(238, 29);
            this.FormPager.TabIndex = 100;
            this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
            // 
            // lblProductIdTP
            // 
            this.lblProductIdTP.AutoSize = true;
            this.lblProductIdTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProductIdTP.Location = new System.Drawing.Point(6, 10);
            this.lblProductIdTP.Name = "lblProductIdTP";
            this.lblProductIdTP.Size = new System.Drawing.Size(63, 14);
            this.lblProductIdTP.TabIndex = 200;
            this.lblProductIdTP.Text = "产品编号";
            // 
            // lblProductNameTP
            // 
            this.lblProductNameTP.AutoSize = true;
            this.lblProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProductNameTP.Location = new System.Drawing.Point(6, 37);
            this.lblProductNameTP.Name = "lblProductNameTP";
            this.lblProductNameTP.Size = new System.Drawing.Size(63, 14);
            this.lblProductNameTP.TabIndex = 200;
            this.lblProductNameTP.Text = "产品名称";
            // 
            // lblBtCount
            // 
            this.lblBtCount.AutoSize = true;
            this.lblBtCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBtCount.Location = new System.Drawing.Point(6, 64);
            this.lblBtCount.Name = "lblBtCount";
            this.lblBtCount.Size = new System.Drawing.Size(63, 14);
            this.lblBtCount.TabIndex = 200;
            this.lblBtCount.Text = "白土用量";
            // 
            // lblT501Count
            // 
            this.lblT501Count.AutoSize = true;
            this.lblT501Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblT501Count.Location = new System.Drawing.Point(6, 91);
            this.lblT501Count.Name = "lblT501Count";
            this.lblT501Count.Size = new System.Drawing.Size(63, 14);
            this.lblT501Count.TabIndex = 200;
            this.lblT501Count.Text = "T501用量";
            // 
            // lblT602Count
            // 
            this.lblT602Count.AutoSize = true;
            this.lblT602Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblT602Count.Location = new System.Drawing.Point(6, 118);
            this.lblT602Count.Name = "lblT602Count";
            this.lblT602Count.Size = new System.Drawing.Size(63, 14);
            this.lblT602Count.TabIndex = 200;
            this.lblT602Count.Text = "T602用量";
            // 
            // lblYJCount
            // 
            this.lblYJCount.AutoSize = true;
            this.lblYJCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYJCount.Location = new System.Drawing.Point(6, 145);
            this.lblYJCount.Name = "lblYJCount";
            this.lblYJCount.Size = new System.Drawing.Size(63, 14);
            this.lblYJCount.TabIndex = 200;
            this.lblYJCount.Text = "液碱用量";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateTime.Location = new System.Drawing.Point(6, 172);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(63, 14);
            this.lblUpdateTime.TabIndex = 200;
            this.lblUpdateTime.Text = "更新时间";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(6, 199);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(35, 14);
            this.lblRemark.TabIndex = 200;
            this.lblRemark.Text = "备注";
            // 
            // combProductIdTP
            // 
            this.combProductIdTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combProductIdTP.FormattingEnabled = true;
            this.combProductIdTP.Location = new System.Drawing.Point(158, 10);
            this.combProductIdTP.Name = "combProductIdTP";
            this.combProductIdTP.Size = new System.Drawing.Size(150, 22);
            this.combProductIdTP.TabIndex = 0;
            // 
            // combProductNameTP
            // 
            this.combProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combProductNameTP.FormattingEnabled = true;
            this.combProductNameTP.Location = new System.Drawing.Point(158, 37);
            this.combProductNameTP.Name = "combProductNameTP";
            this.combProductNameTP.Size = new System.Drawing.Size(150, 22);
            this.combProductNameTP.TabIndex = 2;
            // 
            // txtBtCount
            // 
            this.txtBtCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBtCount.Location = new System.Drawing.Point(158, 64);
            this.txtBtCount.Name = "txtBtCount";
            this.txtBtCount.Size = new System.Drawing.Size(150, 23);
            this.txtBtCount.TabIndex = 4;
            this.txtBtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtT501Count
            // 
            this.txtT501Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtT501Count.Location = new System.Drawing.Point(158, 91);
            this.txtT501Count.Name = "txtT501Count";
            this.txtT501Count.Size = new System.Drawing.Size(150, 23);
            this.txtT501Count.TabIndex = 6;
            this.txtT501Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtT602Count
            // 
            this.txtT602Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtT602Count.Location = new System.Drawing.Point(158, 118);
            this.txtT602Count.Name = "txtT602Count";
            this.txtT602Count.Size = new System.Drawing.Size(150, 23);
            this.txtT602Count.TabIndex = 8;
            this.txtT602Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtYJCount
            // 
            this.txtYJCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYJCount.Location = new System.Drawing.Point(158, 145);
            this.txtYJCount.Name = "txtYJCount";
            this.txtYJCount.Size = new System.Drawing.Size(150, 23);
            this.txtYJCount.TabIndex = 10;
            this.txtYJCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // dtUpdateTime
            // 
            this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtUpdateTime.Location = new System.Drawing.Point(158, 172);
            this.dtUpdateTime.Name = "dtUpdateTime";
            this.dtUpdateTime.Size = new System.Drawing.Size(150, 23);
            this.dtUpdateTime.TabIndex = 12;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(158, 199);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 23);
            this.txtRemark.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(26, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 27);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(106, 246);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(78, 27);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddProductFormule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProductIdTP);
            this.Controls.Add(this.lblProductNameTP);
            this.Controls.Add(this.lblBtCount);
            this.Controls.Add(this.lblT501Count);
            this.Controls.Add(this.lblT602Count);
            this.Controls.Add(this.lblYJCount);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.combProductIdTP);
            this.Controls.Add(this.combProductNameTP);
            this.Controls.Add(this.txtBtCount);
            this.Controls.Add(this.txtT501Count);
            this.Controls.Add(this.txtT602Count);
            this.Controls.Add(this.txtYJCount);
            this.Controls.Add(this.dtUpdateTime);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.FormPager);
            this.Name = "AddProductFormule";
            this.Size = new System.Drawing.Size(350, 500);
            this.Load += new System.EventHandler(this.AddAddProductFormuleLoad);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

				}
				#endregion
			#endregion

			#region 构造函数 及初始化
			public AddProductFormule()
			{
				InitializeComponent();
			}
			//控件加载事件,完成数据绑定和相关基本设置
			void AddAddProductFormuleLoad(object sender, EventArgs e)
			{				
			}
			/// <summary>
			/// 初始化设置
			/// </summary>
			/// <param name="showMode"></param>
			/// <param name="searcgCondtion"></param>
			/// <param name="fixCondition"></param>
			public void InitializeSettings(FormShowMode showMode,string searcgCondtion = "",string fixCondition="")
			{
			    this.FormPager.PageSize = 1 ;
				this.CutShowMode = showMode ;
				this.CutSearchCondition = searcgCondtion ;
				this.FixedSqlCondition = fixCondition ;
				if (showMode== FormShowMode.AddOne || showMode == FormShowMode.ContinueAdd ) {
					SetAllTextControls (ControlStatus.ReSet ) ;
				}
				else{
					SetAllTextControls(ControlStatus.ReadOnly ) ;//只读
					GetData ();
					BandingData () ;//绑定数据
				}
				//TODO:问题，只读显示一条记录时,需要传入当前的Model实体类进行绑定
			}
			#endregion

			#region 相关字段与属性
			/// <summary>
			/// 固定的查询条件
			/// </summary>
			public string FixedSqlCondition
			{
				get ;set ;
			}
			string _curSeachCondition ;
			/// <summary>
			/// 获取或者设置当前的查询条件
			/// </summary>
			public string CutSearchCondition
			{
				get {return _curSeachCondition ;}
				set
				{
					_curSeachCondition = "" ;
					if (FixedSqlCondition !="") {
						if (value !="") {
							_curSeachCondition +=(FixedSqlCondition +" and " +value ) ;
						}
						else
							_curSeachCondition = FixedSqlCondition ;
					}
					else
					{
						_curSeachCondition = value  ;
					}
					//此记录数可以在加载时固定起来,不用每次都计算
					FormPager.RecordCount = tb_ProductFormule.FindCount(CutSearchCondition,"","",0,0) ;
				}
			}
			/// <summary>
			/// 获取或者设置当前实体
			/// </summary>
			public tb_ProductFormule CutModel
			{
				get ;set ;
			}
			/// <summary>
			/// 当前实体窗体的显示模式,默认为连续显示
			/// </summary>
			public FormShowMode CutShowMode
			{
				get ;
				set ;
			}
			#endregion

			#region 验证事件
			bool ValidateControls()
			{
						if(combProductIdTP.Text.Trim()==""){
							errorProvider1.SetError(combProductIdTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combProductNameTP.Text.Trim()==""){
							errorProvider1.SetError(combProductNameTP,"必填项目");
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
					if (btnOK.Text.Contains ("修改")) {
				SetAllTextControls(ControlStatus.Edit );
			}
			else {
				if(((CutShowMode!= FormShowMode.ReadOnlyForAll) || (CutShowMode != FormShowMode.ReadOnlyForOne)) && ValidateControls() )
				{
				tb_ProductFormule model = new tb_ProductFormule();//定义当前实体
				
				if(combProductIdTP.Text.Trim()!=""){
					model.ProductIdTP = combProductIdTP.Text.Trim() ;}
				if(combProductNameTP.Text.Trim()!=""){
					model.ProductNameTP = combProductNameTP.Text.Trim() ;}if(txtBtCount.Text.Trim()!=""){
						model.BtCount =Convert.ToDouble(txtBtCount.Text.Trim()) ;}
					if(txtT501Count.Text.Trim()!=""){
						model.T501Count =Convert.ToDouble(txtT501Count.Text.Trim()) ;}
					if(txtT602Count.Text.Trim()!=""){
						model.T602Count =Convert.ToDouble(txtT602Count.Text.Trim()) ;}
					if(txtYJCount.Text.Trim()!=""){
						model.YJCount =Convert.ToDouble(txtYJCount.Text.Trim()) ;}
					{
						model.UpdateTime = dtUpdateTime.Value ;}
					if(txtRemark.Text.Trim()!=""){
						model.Remark = txtRemark.Text.Trim() ;}
					if (CutShowMode== FormShowMode.AddOne ) {
						model.Insert () ;//添加
						MessageBox.Show ("添加成功") ;
						this.ParentForm.DialogResult = DialogResult.OK ;
					}
					else if (CutShowMode== FormShowMode.ContinueAdd ) {
						model.Insert () ;//添加
						MessageBox.Show ("添加成功") ;
						SetAllTextControls(ControlStatus.ReSet ) ;
					}
					else if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent) {
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
			private void FormPager_PageIndexChanged(object sender, EventArgs e)
			{
			   GetData ();
			}
			List <tb_ProductFormule> modelList ;
			void GetData()
			{				
				//判断不为空，才能绑定				
				modelList = tb_ProductFormule.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
				if (modelList !=null ) {
					CutModel = modelList[0];					
					BandingData();
				}
			}
			#endregion

			#region 根据状态设置控件
			//设置文本控件的可用性
			private void SetAllTextControls(ControlStatus ctr)
			{
		     	if (CutShowMode== FormShowMode.AddOne || CutShowMode == FormShowMode.ContinueAdd ||CutShowMode== FormShowMode.DisplayCurrent||CutShowMode== FormShowMode.ReadOnlyForOne )
				    FormPager.Visible = false ;
			   else
				    FormPager.Visible = true ;
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
					
							combProductIdTP.Enabled = true ;
							combProductNameTP.Enabled = true ;txtBtCount.ReadOnly = false ;
							txtBtCount.Text = string.Empty  ; txtT501Count.ReadOnly = false ;
							txtT501Count.Text = string.Empty  ; txtT602Count.ReadOnly = false ;
							txtT602Count.Text = string.Empty  ; txtYJCount.ReadOnly = false ;
							txtYJCount.Text = string.Empty  ; txtRemark.ReadOnly = false ;
							txtRemark.Text = string.Empty  ; 
				}
			}
			private void SetControlEdit()
			{
				if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
					btnOK .Enabled = true ;
					btnOK.Text =" 保存";
					//控件除主键外都可读
				
				combProductIdTP.Enabled = true;combProductNameTP.Enabled = true ;
					txtBtCount.ReadOnly = false ;
					txtT501Count.ReadOnly = false ;
					txtT602Count.ReadOnly = false ;
					txtYJCount.ReadOnly = false ;dtUpdateTime.Enabled = true ;
				
					txtRemark.ReadOnly = false ;
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
				
							combProductIdTP.Enabled = false ;
							
							combProductNameTP.Enabled = false ;
							txtBtCount.ReadOnly = true ;txtT501Count.ReadOnly = true ;txtT602Count.ReadOnly = true ;txtYJCount.ReadOnly = true ;
							dtUpdateTime.Enabled = false ;
							txtRemark.ReadOnly = true ;
			}
			#endregion

			#region 绑定数据
			 /// <summary>
			/// 加载子窗口:if(Field.PrimaryKey) continue;
			/// </summary>
			private void BandingData()
			{
				  
				  combProductIdTP.DataBindings.Clear () ;
													combProductIdTP.DataBindings.Add ("Text",CutModel,"ProductIdTP") ;
				
				  combProductNameTP.DataBindings.Clear () ;
													combProductNameTP.DataBindings.Add ("Text",CutModel,"ProductNameTP") ;
				
				  txtBtCount.DataBindings.Clear();
						   txtBtCount.DataBindings.Add ("Text",CutModel,"BtCount");
				  txtT501Count.DataBindings.Clear();
						   txtT501Count.DataBindings.Add ("Text",CutModel,"T501Count");
				  txtT602Count.DataBindings.Clear();
						   txtT602Count.DataBindings.Add ("Text",CutModel,"T602Count");
				  txtYJCount.DataBindings.Clear();
						   txtYJCount.DataBindings.Add ("Text",CutModel,"YJCount");
				  dtUpdateTime.DataBindings.Clear () ;
													dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
				
				  txtRemark.DataBindings.Clear();
						   txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
			}
			#endregion
		  }
	}