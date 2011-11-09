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

		
			public class AddDicType: UserControl
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
				
						private System.Windows.Forms.ComboBox combTypeName ;
					private System.Windows.Forms.Label    lblTypeName ;
				private System.Windows.Forms.TextBox txtValue ;
					private System.Windows.Forms.Label    lblValue ;
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
            this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.combTypeName = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
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
            this.FormPager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FormPager.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormPager.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FormPager.Location = new System.Drawing.Point(10, 168);
            this.FormPager.Name = "FormPager";
            this.FormPager.RecordCount = 0;
            this.FormPager.Size = new System.Drawing.Size(256, 29);
            this.FormPager.TabIndex = 100;
            this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.Location = new System.Drawing.Point(6, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 14);
            this.lblID.TabIndex = 200;
            this.lblID.Text = "编号";
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTypeName.Location = new System.Drawing.Point(6, 37);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(63, 14);
            this.lblTypeName.TabIndex = 200;
            this.lblTypeName.Text = "类型名称";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValue.Location = new System.Drawing.Point(6, 64);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(49, 14);
            this.lblValue.TabIndex = 200;
            this.lblValue.Text = "数据值";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(6, 91);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(35, 14);
            this.lblRemark.TabIndex = 200;
            this.lblRemark.Text = "备注";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(158, 10);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(150, 23);
            this.txtID.TabIndex = 0;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // combTypeName
            // 
            this.combTypeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combTypeName.FormattingEnabled = true;
            this.combTypeName.Location = new System.Drawing.Point(158, 37);
            this.combTypeName.Name = "combTypeName";
            this.combTypeName.Size = new System.Drawing.Size(150, 22);
            this.combTypeName.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtValue.Location = new System.Drawing.Point(158, 64);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(150, 23);
            this.txtValue.TabIndex = 4;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(158, 91);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 23);
            this.txtRemark.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(26, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 27);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(106, 138);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(78, 27);
            this.btnCancle.TabIndex = 10;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddDicType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.combTypeName);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.FormPager);
            this.Name = "AddDicType";
            this.Size = new System.Drawing.Size(350, 211);
            this.Load += new System.EventHandler(this.AddAddDicTypeLoad);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

				}
				#endregion
			#endregion

			#region 构造函数 及初始化
			public AddDicType()
			{
				InitializeComponent();
			}
			//控件加载事件,完成数据绑定和相关基本设置
			void AddAddDicTypeLoad(object sender, EventArgs e)
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
					FormPager.RecordCount = tb_DicType.FindCount(CutSearchCondition,"","",0,0) ;
				}
			}
			/// <summary>
			/// 获取或者设置当前实体
			/// </summary>
			public tb_DicType CutModel
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
					if(txtID.Text.Trim()==""){
							errorProvider1.SetError(txtID,"必填项目");
							return false ;
					}					
				
				return true ;
				
						if(combTypeName.Text.Trim()==""){
							errorProvider1.SetError(combTypeName,"必填项目");
							return false ;
						} 
				return true ;
				
					if(txtValue.Text.Trim()==""){
							errorProvider1.SetError(txtValue,"必填项目");
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
				tb_DicType model = new tb_DicType();//定义当前实体
				if(txtID.Text.Trim()!=""){
						model.ID =Convert.ToUInt32(txtID.Text.Trim()) ;}
					
				if(combTypeName.Text.Trim()!=""){
					model.TypeName = combTypeName.Text.Trim() ;}
					if(txtValue.Text.Trim()!=""){
						model.Value = txtValue.Text.Trim() ;}
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
			List <tb_DicType> modelList ;
			void GetData()
			{				
				//判断不为空，才能绑定				
				modelList = tb_DicType.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
					txtID.ReadOnly = false ;
							txtID.Text = string.Empty  ; 
							combTypeName.Enabled = true ;txtValue.ReadOnly = false ;
							txtValue.Text = string.Empty  ; txtRemark.ReadOnly = false ;
							txtRemark.Text = string.Empty  ; 
				}
			}
			private void SetControlEdit()
			{
				if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
					btnOK .Enabled = true ;
					btnOK.Text =" 保存";
					//控件除主键外都可读
				txtID.ReadOnly = true;combTypeName.Enabled = true ;
					txtValue.ReadOnly = false ;
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
				txtID.ReadOnly = true ;
							combTypeName.Enabled = false ;
							txtValue.ReadOnly = true ;txtRemark.ReadOnly = true ;
			}
			#endregion

			#region 绑定数据
			 /// <summary>
			/// 加载子窗口:if(Field.PrimaryKey) continue;
			/// </summary>
			private void BandingData()
			{
				  
				  txtID.DataBindings.Clear();
						   txtID.DataBindings.Add ("Text",CutModel,"ID");
				  combTypeName.DataBindings.Clear () ;
													combTypeName.DataBindings.Add ("Text",CutModel,"TypeName") ;
				
				  txtValue.DataBindings.Clear();
						   txtValue.DataBindings.Add ("Text",CutModel,"Value");
				  txtRemark.DataBindings.Clear();
						   txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
			}
			#endregion
		  }
	}