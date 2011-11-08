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

		
			public class AddTestTask: UserControl
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
				private System.Windows.Forms.TextBox txtTestTitle ;
					private System.Windows.Forms.Label    lblTestTitle ;
				
						private System.Windows.Forms.ComboBox combTestType ;
					private System.Windows.Forms.Label    lblTestType ;
				private System.Windows.Forms.TextBox txtTestProcedure ;
					private System.Windows.Forms.Label    lblTestProcedure ;
				private System.Windows.Forms.TextBox txtTestResult ;
					private System.Windows.Forms.Label    lblTestResult ;
				private System.Windows.Forms.TextBox txtSummary ;
					private System.Windows.Forms.Label    lblSummary ;
				private System.Windows.Forms.DateTimePicker dtStartTime ;
					private System.Windows.Forms.Label    lblStartTime ;
				private System.Windows.Forms.TextBox txtInvolvedPerson ;
					private System.Windows.Forms.Label    lblInvolvedPerson ;
				private System.Windows.Forms.DateTimePicker dtFinishTime ;
					private System.Windows.Forms.Label    lblFinishTime ;
				private System.Windows.Forms.TextBox txtReportID ;
					private System.Windows.Forms.Label    lblReportID ;
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
					System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTestTask));
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
					
						this.lblID = new System.Windows.Forms.Label() ;
						this.lblID.AutoSize = true;
						this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblID.Name = "lblID";
						this.lblID.Size = new System.Drawing.Size(10,16);
						this.lblID.TabIndex = 200 ;
						this.lblID.Text = "实验编号";
						this.Controls.Add(this.lblID) ;
					
						this.lblTestTitle = new System.Windows.Forms.Label() ;
						this.lblTestTitle.AutoSize = true;
						this.lblTestTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestTitle.Name = "lblTestTitle";
						this.lblTestTitle.Size = new System.Drawing.Size(10,16);
						this.lblTestTitle.TabIndex = 200 ;
						this.lblTestTitle.Text = "实验名称";
						this.Controls.Add(this.lblTestTitle) ;
					
						this.lblTestType = new System.Windows.Forms.Label() ;
						this.lblTestType.AutoSize = true;
						this.lblTestType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestType.Name = "lblTestType";
						this.lblTestType.Size = new System.Drawing.Size(10,16);
						this.lblTestType.TabIndex = 200 ;
						this.lblTestType.Text = "实验类型";
						this.Controls.Add(this.lblTestType) ;
					
						this.lblTestProcedure = new System.Windows.Forms.Label() ;
						this.lblTestProcedure.AutoSize = true;
						this.lblTestProcedure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestProcedure.Name = "lblTestProcedure";
						this.lblTestProcedure.Size = new System.Drawing.Size(10,16);
						this.lblTestProcedure.TabIndex = 200 ;
						this.lblTestProcedure.Text = "实验过程";
						this.Controls.Add(this.lblTestProcedure) ;
					
						this.lblTestResult = new System.Windows.Forms.Label() ;
						this.lblTestResult.AutoSize = true;
						this.lblTestResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestResult.Name = "lblTestResult";
						this.lblTestResult.Size = new System.Drawing.Size(10,16);
						this.lblTestResult.TabIndex = 200 ;
						this.lblTestResult.Text = "实验结果";
						this.Controls.Add(this.lblTestResult) ;
					
						this.lblSummary = new System.Windows.Forms.Label() ;
						this.lblSummary.AutoSize = true;
						this.lblSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblSummary.Name = "lblSummary";
						this.lblSummary.Size = new System.Drawing.Size(10,16);
						this.lblSummary.TabIndex = 200 ;
						this.lblSummary.Text = "总结";
						this.Controls.Add(this.lblSummary) ;
					
						this.lblStartTime = new System.Windows.Forms.Label() ;
						this.lblStartTime.AutoSize = true;
						this.lblStartTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblStartTime.Name = "lblStartTime";
						this.lblStartTime.Size = new System.Drawing.Size(10,16);
						this.lblStartTime.TabIndex = 200 ;
						this.lblStartTime.Text = "开始时间";
						this.Controls.Add(this.lblStartTime) ;
					
						this.lblInvolvedPerson = new System.Windows.Forms.Label() ;
						this.lblInvolvedPerson.AutoSize = true;
						this.lblInvolvedPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblInvolvedPerson.Name = "lblInvolvedPerson";
						this.lblInvolvedPerson.Size = new System.Drawing.Size(10,16);
						this.lblInvolvedPerson.TabIndex = 200 ;
						this.lblInvolvedPerson.Text = "参与人员";
						this.Controls.Add(this.lblInvolvedPerson) ;
					
						this.lblFinishTime = new System.Windows.Forms.Label() ;
						this.lblFinishTime.AutoSize = true;
						this.lblFinishTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblFinishTime.Name = "lblFinishTime";
						this.lblFinishTime.Size = new System.Drawing.Size(10,16);
						this.lblFinishTime.TabIndex = 200 ;
						this.lblFinishTime.Text = "结束时间";
						this.Controls.Add(this.lblFinishTime) ;
					
						this.lblReportID = new System.Windows.Forms.Label() ;
						this.lblReportID.AutoSize = true;
						this.lblReportID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblReportID.Name = "lblReportID";
						this.lblReportID.Size = new System.Drawing.Size(10,16);
						this.lblReportID.TabIndex = 200 ;
						this.lblReportID.Text = "报告编号";
						this.Controls.Add(this.lblReportID) ;
					
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
						
						this.lblTestTitle.Location = new System.Drawing.Point(6, 37);
						
						this.txtTestTitle = new System.Windows.Forms.TextBox() ;
						this.txtTestTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtTestTitle.Location = new System.Drawing.Point(158, 37);
						this.txtTestTitle.Name = "txtTestTitle";
						this.txtTestTitle.Size = new System.Drawing.Size(150,22);
						this.txtTestTitle.TabIndex = 2 ;
						this.Controls.Add(this.txtTestTitle) ;
						
						this.lblTestType.Location = new System.Drawing.Point(6, 64);
						
						this.combTestType = new System.Windows.Forms.ComboBox() ;
						this.combTestType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combTestType.FormattingEnabled = true;
						this.combTestType.Location = new System.Drawing.Point(158, 64);
						this.combTestType.Name = "combTestType";
						this.combTestType.Size = new System.Drawing.Size(150,22);
						this.combTestType.TabIndex = 4 ;
						this.Controls.Add(this.combTestType) ;
						
						this.lblTestProcedure.Location = new System.Drawing.Point(6, 91);
						
						this.txtTestProcedure = new System.Windows.Forms.TextBox() ;
						this.txtTestProcedure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtTestProcedure.Location = new System.Drawing.Point(158, 91);
						this.txtTestProcedure.Name = "txtTestProcedure";
						this.txtTestProcedure.Size = new System.Drawing.Size(150,22);
						this.txtTestProcedure.TabIndex = 6 ;
						this.Controls.Add(this.txtTestProcedure) ;
						
						this.lblTestResult.Location = new System.Drawing.Point(6, 118);
						
						this.txtTestResult = new System.Windows.Forms.TextBox() ;
						this.txtTestResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtTestResult.Location = new System.Drawing.Point(158, 118);
						this.txtTestResult.Name = "txtTestResult";
						this.txtTestResult.Size = new System.Drawing.Size(150,22);
						this.txtTestResult.TabIndex = 8 ;
						this.Controls.Add(this.txtTestResult) ;
						
						this.lblSummary.Location = new System.Drawing.Point(6, 145);
						
						this.txtSummary = new System.Windows.Forms.TextBox() ;
						this.txtSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtSummary.Location = new System.Drawing.Point(158, 145);
						this.txtSummary.Name = "txtSummary";
						this.txtSummary.Size = new System.Drawing.Size(150,22);
						this.txtSummary.TabIndex = 10 ;
						this.Controls.Add(this.txtSummary) ;
						
						this.lblStartTime.Location = new System.Drawing.Point(6, 172);
						
						this.dtStartTime = new System.Windows.Forms.DateTimePicker() ;
						this.dtStartTime.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.dtStartTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.dtStartTime.Location = new System.Drawing.Point(158, 172);
						this.dtStartTime.Name = "dtStartTime";
						this.dtStartTime.Size = new System.Drawing.Size(150,22);
						this.dtStartTime.TabIndex = 12 ;
						this.Controls.Add(this.dtStartTime) ;
						
						this.lblInvolvedPerson.Location = new System.Drawing.Point(6, 199);
						
						this.txtInvolvedPerson = new System.Windows.Forms.TextBox() ;
						this.txtInvolvedPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtInvolvedPerson.Location = new System.Drawing.Point(158, 199);
						this.txtInvolvedPerson.Name = "txtInvolvedPerson";
						this.txtInvolvedPerson.Size = new System.Drawing.Size(150,22);
						this.txtInvolvedPerson.TabIndex = 14 ;
						this.Controls.Add(this.txtInvolvedPerson) ;
						
						this.lblFinishTime.Location = new System.Drawing.Point(6, 226);
						
						this.dtFinishTime = new System.Windows.Forms.DateTimePicker() ;
						this.dtFinishTime.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.dtFinishTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.dtFinishTime.Location = new System.Drawing.Point(158, 226);
						this.dtFinishTime.Name = "dtFinishTime";
						this.dtFinishTime.Size = new System.Drawing.Size(150,22);
						this.dtFinishTime.TabIndex = 16 ;
						this.Controls.Add(this.dtFinishTime) ;
						
						this.lblReportID.Location = new System.Drawing.Point(6, 253);
						
						this.txtReportID = new System.Windows.Forms.TextBox() ;
						this.txtReportID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtReportID.Location = new System.Drawing.Point(158, 253);
						this.txtReportID.Name = "txtReportID";
						this.txtReportID.Size = new System.Drawing.Size(150,22);
						this.txtReportID.TabIndex = 18 ;
						this.Controls.Add(this.txtReportID) ;
						
						this.lblRemark.Location = new System.Drawing.Point(6, 280);
						
						this.txtRemark = new System.Windows.Forms.TextBox() ;
						this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtRemark.Location = new System.Drawing.Point(158, 280);
						this.txtRemark.Name = "txtRemark";
						this.txtRemark.Size = new System.Drawing.Size(150,22);
						this.txtRemark.TabIndex = 20 ;
						this.Controls.Add(this.txtRemark) ;
						
					#region 添加按钮
					this.btnOK = new System.Windows.Forms.Button();
					this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnOK.Location = new System.Drawing.Point(26, 327);
					this.btnOK.Name = "btnOK";
					this.btnOK.Size = new System.Drawing.Size(78, 27);
					this.btnOK.TabIndex = 22;
					this.btnOK.Text = "保存";
					this.btnOK.UseVisualStyleBackColor = true;
					this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
					this.Controls.Add(this.btnOK);
					this.btnCancle = new System.Windows.Forms.Button();
					this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnCancle.Location = new System.Drawing.Point(106, 327);
					this.btnCancle.Name = "btnCancle";
					this.btnCancle.Size = new System.Drawing.Size(78, 27);
					this.btnCancle.TabIndex = 24;
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
					this.FormPager.Location = new System.Drawing.Point(10, 357);
					this.FormPager.Name = "FormPager";
					this.FormPager.RecordCount = 0;
					this.FormPager.Size = new System.Drawing.Size(256, 29);
					this.FormPager.TabIndex = 100;
					this.Controls.Add(this.FormPager);
					this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
					#endregion
					#region 窗体
					this.Name = "AddTestTask";
					this.Size = new System.Drawing.Size(350, 500);
					this.Load += new System.EventHandler(this.AddAddTestTaskLoad);
					this.SuspendLayout();
					((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
					this.ResumeLayout(false);
					this.PerformLayout();
					#endregion
				}
				#endregion
			#endregion

			#region 构造函数 及初始化
			public AddTestTask()
			{
				InitializeComponent();
			}
			//控件加载事件,完成数据绑定和相关基本设置
			void AddAddTestTaskLoad(object sender, EventArgs e)
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
					FormPager.RecordCount = tb_TestTask.FindCount(CutSearchCondition,"","",0,0) ;
				}
			}
			/// <summary>
			/// 获取或者设置当前实体
			/// </summary>
			public tb_TestTask CutModel
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
				
					if(txtTestTitle.Text.Trim()==""){
							errorProvider1.SetError(txtTestTitle,"必填项目");
							return false ;
					}					
				
				return true ;
				
						if(combTestType.Text.Trim()==""){
							errorProvider1.SetError(combTestType,"必填项目");
							return false ;
						} 
				return true ;
				
					if(txtTestProcedure.Text.Trim()==""){
							errorProvider1.SetError(txtTestProcedure,"必填项目");
							return false ;
					}					
				
				return true ;
				
					if(txtTestResult.Text.Trim()==""){
							errorProvider1.SetError(txtTestResult,"必填项目");
							return false ;
					}					
				
				return true ;
				
					if(txtSummary.Text.Trim()==""){
							errorProvider1.SetError(txtSummary,"必填项目");
							return false ;
					}					
				
				return true ;
				
					if(txtInvolvedPerson.Text.Trim()==""){
							errorProvider1.SetError(txtInvolvedPerson,"必填项目");
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
				tb_TestTask model = new tb_TestTask();//定义当前实体
				
					if(txtID.Text.Trim()!=""){
						model.ID = txtID.Text.Trim() ;}
					if(txtTestTitle.Text.Trim()!=""){
						model.TestTitle = txtTestTitle.Text.Trim() ;}
				if(combTestType.Text.Trim()!=""){
					model.TestType = combTestType.Text.Trim() ;}
					if(txtTestProcedure.Text.Trim()!=""){
						model.TestProcedure = txtTestProcedure.Text.Trim() ;}
					if(txtTestResult.Text.Trim()!=""){
						model.TestResult = txtTestResult.Text.Trim() ;}
					if(txtSummary.Text.Trim()!=""){
						model.Summary = txtSummary.Text.Trim() ;}{
						model.StartTime = dtStartTime.Value ;}
					if(txtInvolvedPerson.Text.Trim()!=""){
						model.InvolvedPerson = txtInvolvedPerson.Text.Trim() ;}{
						model.FinishTime = dtFinishTime.Value ;}
					if(txtReportID.Text.Trim()!=""){
						model.ReportID = txtReportID.Text.Trim() ;}
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
			List <tb_TestTask> modelList ;
			void GetData()
			{				
				//判断不为空，才能绑定				
				modelList = tb_TestTask.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
							txtID.Text = string.Empty  ; txtTestTitle.ReadOnly = false ;
							txtTestTitle.Text = string.Empty  ; 
							combTestType.Enabled = true ;txtTestProcedure.ReadOnly = false ;
							txtTestProcedure.Text = string.Empty  ; txtTestResult.ReadOnly = false ;
							txtTestResult.Text = string.Empty  ; txtSummary.ReadOnly = false ;
							txtSummary.Text = string.Empty  ; txtInvolvedPerson.ReadOnly = false ;
							txtInvolvedPerson.Text = string.Empty  ; txtReportID.ReadOnly = false ;
							txtReportID.Text = string.Empty  ; txtRemark.ReadOnly = false ;
							txtRemark.Text = string.Empty  ; 
				}
			}
			private void SetControlEdit()
			{
				if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
					btnOK .Enabled = true ;
					btnOK.Text =" 保存";
					//控件除主键外都可读
				txtID.ReadOnly = true;
					txtTestTitle.ReadOnly = false ;combTestType.Enabled = true ;
					txtTestProcedure.ReadOnly = false ;
					txtTestResult.ReadOnly = false ;
					txtSummary.ReadOnly = false ;dtStartTime.Enabled = true ;
				
					txtInvolvedPerson.ReadOnly = false ;dtFinishTime.Enabled = true ;
				
					txtReportID.ReadOnly = false ;
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
				txtID.ReadOnly = true ;txtTestTitle.ReadOnly = true ;
							combTestType.Enabled = false ;
							txtTestProcedure.ReadOnly = true ;txtTestResult.ReadOnly = true ;txtSummary.ReadOnly = true ;
							dtStartTime.Enabled = false ;
							txtInvolvedPerson.ReadOnly = true ;
							dtFinishTime.Enabled = false ;
							txtReportID.ReadOnly = true ;txtRemark.ReadOnly = true ;
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
				  txtTestTitle.DataBindings.Clear();
						   txtTestTitle.DataBindings.Add ("Text",CutModel,"TestTitle");
				  combTestType.DataBindings.Clear () ;
													combTestType.DataBindings.Add ("Text",CutModel,"TestType") ;
				
				  txtTestProcedure.DataBindings.Clear();
						   txtTestProcedure.DataBindings.Add ("Text",CutModel,"TestProcedure");
				  txtTestResult.DataBindings.Clear();
						   txtTestResult.DataBindings.Add ("Text",CutModel,"TestResult");
				  txtSummary.DataBindings.Clear();
						   txtSummary.DataBindings.Add ("Text",CutModel,"Summary");
				  dtStartTime.DataBindings.Clear () ;
													dtStartTime.DataBindings.Add ("Value",CutModel,"StartTime") ;
				
				  txtInvolvedPerson.DataBindings.Clear();
						   txtInvolvedPerson.DataBindings.Add ("Text",CutModel,"InvolvedPerson");
				  dtFinishTime.DataBindings.Clear () ;
													dtFinishTime.DataBindings.Add ("Value",CutModel,"FinishTime") ;
				
				  txtReportID.DataBindings.Clear();
						   txtReportID.DataBindings.Add ("Text",CutModel,"ReportID");
				  txtRemark.DataBindings.Clear();
						   txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
			}
			#endregion
		  }
	}