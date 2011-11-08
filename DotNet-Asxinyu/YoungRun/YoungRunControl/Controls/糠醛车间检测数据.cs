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

		
			public class AddKqTestData: UserControl
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
				
						private System.Windows.Forms.ComboBox combRawNameTP ;
					private System.Windows.Forms.Label    lblRawNameTP ;
				
						private System.Windows.Forms.ComboBox combJQIsHaveKQTP ;
					private System.Windows.Forms.Label    lblJQIsHaveKQTP ;
				private System.Windows.Forms.TextBox txtAV ;
					private System.Windows.Forms.Label    lblAV ;
				
						private System.Windows.Forms.ComboBox combCYIsHaveKQTP ;
					private System.Windows.Forms.Label    lblCYIsHaveKQTP ;
				
						private System.Windows.Forms.ComboBox combT8WIsHaveKQTP ;
					private System.Windows.Forms.Label    lblT8WIsHaveKQTP ;
				private System.Windows.Forms.TextBox txtASTM ;
					private System.Windows.Forms.Label    lblASTM ;
				private System.Windows.Forms.DateTimePicker dtGetSampleTime ;
					private System.Windows.Forms.Label    lblGetSampleTime ;
				
						private System.Windows.Forms.ComboBox combGetSampPersonTP ;
					private System.Windows.Forms.Label    lblGetSampPersonTP ;
				
						private System.Windows.Forms.ComboBox combTestPersonTP ;
					private System.Windows.Forms.Label    lblTestPersonTP ;
				
						private System.Windows.Forms.ComboBox combGetSampLocationTP ;
					private System.Windows.Forms.Label    lblGetSampLocationTP ;
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
					System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddKqTestData));
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
					
						this.lblID = new System.Windows.Forms.Label() ;
						this.lblID.AutoSize = true;
						this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblID.Name = "lblID";
						this.lblID.Size = new System.Drawing.Size(10,16);
						this.lblID.TabIndex = 200 ;
						this.lblID.Text = "数据编号";
						this.Controls.Add(this.lblID) ;
					
						this.lblRawNameTP = new System.Windows.Forms.Label() ;
						this.lblRawNameTP.AutoSize = true;
						this.lblRawNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblRawNameTP.Name = "lblRawNameTP";
						this.lblRawNameTP.Size = new System.Drawing.Size(10,16);
						this.lblRawNameTP.TabIndex = 200 ;
						this.lblRawNameTP.Text = "原料名称";
						this.Controls.Add(this.lblRawNameTP) ;
					
						this.lblJQIsHaveKQTP = new System.Windows.Forms.Label() ;
						this.lblJQIsHaveKQTP.AutoSize = true;
						this.lblJQIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblJQIsHaveKQTP.Name = "lblJQIsHaveKQTP";
						this.lblJQIsHaveKQTP.Size = new System.Drawing.Size(10,16);
						this.lblJQIsHaveKQTP.TabIndex = 200 ;
						this.lblJQIsHaveKQTP.Text = "精油含醛";
						this.Controls.Add(this.lblJQIsHaveKQTP) ;
					
						this.lblAV = new System.Windows.Forms.Label() ;
						this.lblAV.AutoSize = true;
						this.lblAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblAV.Name = "lblAV";
						this.lblAV.Size = new System.Drawing.Size(10,16);
						this.lblAV.TabIndex = 200 ;
						this.lblAV.Text = "酸值";
						this.Controls.Add(this.lblAV) ;
					
						this.lblCYIsHaveKQTP = new System.Windows.Forms.Label() ;
						this.lblCYIsHaveKQTP.AutoSize = true;
						this.lblCYIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblCYIsHaveKQTP.Name = "lblCYIsHaveKQTP";
						this.lblCYIsHaveKQTP.Size = new System.Drawing.Size(10,16);
						this.lblCYIsHaveKQTP.TabIndex = 200 ;
						this.lblCYIsHaveKQTP.Text = "抽油含醛";
						this.Controls.Add(this.lblCYIsHaveKQTP) ;
					
						this.lblT8WIsHaveKQTP = new System.Windows.Forms.Label() ;
						this.lblT8WIsHaveKQTP.AutoSize = true;
						this.lblT8WIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblT8WIsHaveKQTP.Name = "lblT8WIsHaveKQTP";
						this.lblT8WIsHaveKQTP.Size = new System.Drawing.Size(10,16);
						this.lblT8WIsHaveKQTP.TabIndex = 200 ;
						this.lblT8WIsHaveKQTP.Text = "塔8水含醛";
						this.Controls.Add(this.lblT8WIsHaveKQTP) ;
					
						this.lblASTM = new System.Windows.Forms.Label() ;
						this.lblASTM.AutoSize = true;
						this.lblASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblASTM.Name = "lblASTM";
						this.lblASTM.Size = new System.Drawing.Size(10,16);
						this.lblASTM.TabIndex = 200 ;
						this.lblASTM.Text = "色度";
						this.Controls.Add(this.lblASTM) ;
					
						this.lblGetSampleTime = new System.Windows.Forms.Label() ;
						this.lblGetSampleTime.AutoSize = true;
						this.lblGetSampleTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblGetSampleTime.Name = "lblGetSampleTime";
						this.lblGetSampleTime.Size = new System.Drawing.Size(10,16);
						this.lblGetSampleTime.TabIndex = 200 ;
						this.lblGetSampleTime.Text = "采样时间";
						this.Controls.Add(this.lblGetSampleTime) ;
					
						this.lblGetSampPersonTP = new System.Windows.Forms.Label() ;
						this.lblGetSampPersonTP.AutoSize = true;
						this.lblGetSampPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblGetSampPersonTP.Name = "lblGetSampPersonTP";
						this.lblGetSampPersonTP.Size = new System.Drawing.Size(10,16);
						this.lblGetSampPersonTP.TabIndex = 200 ;
						this.lblGetSampPersonTP.Text = "采样人";
						this.Controls.Add(this.lblGetSampPersonTP) ;
					
						this.lblTestPersonTP = new System.Windows.Forms.Label() ;
						this.lblTestPersonTP.AutoSize = true;
						this.lblTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestPersonTP.Name = "lblTestPersonTP";
						this.lblTestPersonTP.Size = new System.Drawing.Size(10,16);
						this.lblTestPersonTP.TabIndex = 200 ;
						this.lblTestPersonTP.Text = "检测人";
						this.Controls.Add(this.lblTestPersonTP) ;
					
						this.lblGetSampLocationTP = new System.Windows.Forms.Label() ;
						this.lblGetSampLocationTP.AutoSize = true;
						this.lblGetSampLocationTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblGetSampLocationTP.Name = "lblGetSampLocationTP";
						this.lblGetSampLocationTP.Size = new System.Drawing.Size(10,16);
						this.lblGetSampLocationTP.TabIndex = 200 ;
						this.lblGetSampLocationTP.Text = "采样地点";
						this.Controls.Add(this.lblGetSampLocationTP) ;
					
						this.lblUpdateTime = new System.Windows.Forms.Label() ;
						this.lblUpdateTime.AutoSize = true;
						this.lblUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblUpdateTime.Name = "lblUpdateTime";
						this.lblUpdateTime.Size = new System.Drawing.Size(10,16);
						this.lblUpdateTime.TabIndex = 200 ;
						this.lblUpdateTime.Text = "更新时间";
						this.Controls.Add(this.lblUpdateTime) ;
					
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
						
						this.lblRawNameTP.Location = new System.Drawing.Point(6, 37);
						
						this.combRawNameTP = new System.Windows.Forms.ComboBox() ;
						this.combRawNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combRawNameTP.FormattingEnabled = true;
						this.combRawNameTP.Location = new System.Drawing.Point(158, 37);
						this.combRawNameTP.Name = "combRawNameTP";
						this.combRawNameTP.Size = new System.Drawing.Size(150,22);
						this.combRawNameTP.TabIndex = 2 ;
						this.Controls.Add(this.combRawNameTP) ;
						
						this.lblJQIsHaveKQTP.Location = new System.Drawing.Point(6, 64);
						
						this.combJQIsHaveKQTP = new System.Windows.Forms.ComboBox() ;
						this.combJQIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combJQIsHaveKQTP.FormattingEnabled = true;
						this.combJQIsHaveKQTP.Location = new System.Drawing.Point(158, 64);
						this.combJQIsHaveKQTP.Name = "combJQIsHaveKQTP";
						this.combJQIsHaveKQTP.Size = new System.Drawing.Size(150,22);
						this.combJQIsHaveKQTP.TabIndex = 4 ;
						this.Controls.Add(this.combJQIsHaveKQTP) ;
						
						this.lblAV.Location = new System.Drawing.Point(6, 91);
						
						this.txtAV = new System.Windows.Forms.TextBox() ;
						this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtAV.Location = new System.Drawing.Point(158, 91);
						this.txtAV.Name = "txtAV";
						this.txtAV.Size = new System.Drawing.Size(150,22);
						this.txtAV.TabIndex = 6 ;
						this.Controls.Add(this.txtAV) ;
						this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblCYIsHaveKQTP.Location = new System.Drawing.Point(6, 118);
						
						this.combCYIsHaveKQTP = new System.Windows.Forms.ComboBox() ;
						this.combCYIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combCYIsHaveKQTP.FormattingEnabled = true;
						this.combCYIsHaveKQTP.Location = new System.Drawing.Point(158, 118);
						this.combCYIsHaveKQTP.Name = "combCYIsHaveKQTP";
						this.combCYIsHaveKQTP.Size = new System.Drawing.Size(150,22);
						this.combCYIsHaveKQTP.TabIndex = 8 ;
						this.Controls.Add(this.combCYIsHaveKQTP) ;
						
						this.lblT8WIsHaveKQTP.Location = new System.Drawing.Point(6, 145);
						
						this.combT8WIsHaveKQTP = new System.Windows.Forms.ComboBox() ;
						this.combT8WIsHaveKQTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combT8WIsHaveKQTP.FormattingEnabled = true;
						this.combT8WIsHaveKQTP.Location = new System.Drawing.Point(158, 145);
						this.combT8WIsHaveKQTP.Name = "combT8WIsHaveKQTP";
						this.combT8WIsHaveKQTP.Size = new System.Drawing.Size(150,22);
						this.combT8WIsHaveKQTP.TabIndex = 10 ;
						this.Controls.Add(this.combT8WIsHaveKQTP) ;
						
						this.lblASTM.Location = new System.Drawing.Point(6, 172);
						
						this.txtASTM = new System.Windows.Forms.TextBox() ;
						this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtASTM.Location = new System.Drawing.Point(158, 172);
						this.txtASTM.Name = "txtASTM";
						this.txtASTM.Size = new System.Drawing.Size(150,22);
						this.txtASTM.TabIndex = 12 ;
						this.Controls.Add(this.txtASTM) ;
						
						this.lblGetSampleTime.Location = new System.Drawing.Point(6, 199);
						
						this.dtGetSampleTime = new System.Windows.Forms.DateTimePicker() ;
						this.dtGetSampleTime.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.dtGetSampleTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.dtGetSampleTime.Location = new System.Drawing.Point(158, 199);
						this.dtGetSampleTime.Name = "dtGetSampleTime";
						this.dtGetSampleTime.Size = new System.Drawing.Size(150,22);
						this.dtGetSampleTime.TabIndex = 14 ;
						this.Controls.Add(this.dtGetSampleTime) ;
						
						this.lblGetSampPersonTP.Location = new System.Drawing.Point(6, 226);
						
						this.combGetSampPersonTP = new System.Windows.Forms.ComboBox() ;
						this.combGetSampPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combGetSampPersonTP.FormattingEnabled = true;
						this.combGetSampPersonTP.Location = new System.Drawing.Point(158, 226);
						this.combGetSampPersonTP.Name = "combGetSampPersonTP";
						this.combGetSampPersonTP.Size = new System.Drawing.Size(150,22);
						this.combGetSampPersonTP.TabIndex = 16 ;
						this.Controls.Add(this.combGetSampPersonTP) ;
						
						this.lblTestPersonTP.Location = new System.Drawing.Point(6, 253);
						
						this.combTestPersonTP = new System.Windows.Forms.ComboBox() ;
						this.combTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combTestPersonTP.FormattingEnabled = true;
						this.combTestPersonTP.Location = new System.Drawing.Point(158, 253);
						this.combTestPersonTP.Name = "combTestPersonTP";
						this.combTestPersonTP.Size = new System.Drawing.Size(150,22);
						this.combTestPersonTP.TabIndex = 18 ;
						this.Controls.Add(this.combTestPersonTP) ;
						
						this.lblGetSampLocationTP.Location = new System.Drawing.Point(6, 280);
						
						this.combGetSampLocationTP = new System.Windows.Forms.ComboBox() ;
						this.combGetSampLocationTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combGetSampLocationTP.FormattingEnabled = true;
						this.combGetSampLocationTP.Location = new System.Drawing.Point(158, 280);
						this.combGetSampLocationTP.Name = "combGetSampLocationTP";
						this.combGetSampLocationTP.Size = new System.Drawing.Size(150,22);
						this.combGetSampLocationTP.TabIndex = 20 ;
						this.Controls.Add(this.combGetSampLocationTP) ;
						
						this.lblUpdateTime.Location = new System.Drawing.Point(6, 307);
						
						this.dtUpdateTime = new System.Windows.Forms.DateTimePicker() ;
						this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.dtUpdateTime.Location = new System.Drawing.Point(158, 307);
						this.dtUpdateTime.Name = "dtUpdateTime";
						this.dtUpdateTime.Size = new System.Drawing.Size(150,22);
						this.dtUpdateTime.TabIndex = 22 ;
						this.Controls.Add(this.dtUpdateTime) ;
						
						this.lblRemark.Location = new System.Drawing.Point(6, 334);
						
						this.txtRemark = new System.Windows.Forms.TextBox() ;
						this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtRemark.Location = new System.Drawing.Point(158, 334);
						this.txtRemark.Name = "txtRemark";
						this.txtRemark.Size = new System.Drawing.Size(150,22);
						this.txtRemark.TabIndex = 24 ;
						this.Controls.Add(this.txtRemark) ;
						
					#region 添加按钮
					this.btnOK = new System.Windows.Forms.Button();
					this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnOK.Location = new System.Drawing.Point(26, 381);
					this.btnOK.Name = "btnOK";
					this.btnOK.Size = new System.Drawing.Size(78, 27);
					this.btnOK.TabIndex = 26;
					this.btnOK.Text = "保存";
					this.btnOK.UseVisualStyleBackColor = true;
					this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
					this.Controls.Add(this.btnOK);
					this.btnCancle = new System.Windows.Forms.Button();
					this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnCancle.Location = new System.Drawing.Point(106, 381);
					this.btnCancle.Name = "btnCancle";
					this.btnCancle.Size = new System.Drawing.Size(78, 27);
					this.btnCancle.TabIndex = 28;
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
					this.FormPager.Location = new System.Drawing.Point(10, 411);
					this.FormPager.Name = "FormPager";
					this.FormPager.RecordCount = 0;
					this.FormPager.Size = new System.Drawing.Size(256, 29);
					this.FormPager.TabIndex = 100;
					this.Controls.Add(this.FormPager);
					this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
					#endregion
					#region 窗体
					this.Name = "AddKqTestData";
					this.Size = new System.Drawing.Size(350, 500);
					this.Load += new System.EventHandler(this.AddAddKqTestDataLoad);
					this.SuspendLayout();
					((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
					this.ResumeLayout(false);
					this.PerformLayout();
					#endregion
				}
				#endregion
			#endregion

			#region 构造函数 及初始化
			public AddKqTestData()
			{
				InitializeComponent();
			}
			//控件加载事件,完成数据绑定和相关基本设置
			void AddAddKqTestDataLoad(object sender, EventArgs e)
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
					FormPager.RecordCount = tb_KqTestData.FindCount(CutSearchCondition,"","",0,0) ;
				}
			}
			/// <summary>
			/// 获取或者设置当前实体
			/// </summary>
			public tb_KqTestData CutModel
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
				
						if(combRawNameTP.Text.Trim()==""){
							errorProvider1.SetError(combRawNameTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combJQIsHaveKQTP.Text.Trim()==""){
							errorProvider1.SetError(combJQIsHaveKQTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combCYIsHaveKQTP.Text.Trim()==""){
							errorProvider1.SetError(combCYIsHaveKQTP,"必填项目");
							return false ;
						} 
				return true ;
				
					if(txtASTM.Text.Trim()==""){
							errorProvider1.SetError(txtASTM,"必填项目");
							return false ;
					}					
				
				return true ;
				
						if(combGetSampPersonTP.Text.Trim()==""){
							errorProvider1.SetError(combGetSampPersonTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combTestPersonTP.Text.Trim()==""){
							errorProvider1.SetError(combTestPersonTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combGetSampLocationTP.Text.Trim()==""){
							errorProvider1.SetError(combGetSampLocationTP,"必填项目");
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
				tb_KqTestData model = new tb_KqTestData();//定义当前实体
				
					if(txtID.Text.Trim()!=""){
						model.ID = txtID.Text.Trim() ;}
				if(combRawNameTP.Text.Trim()!=""){
					model.RawNameTP = combRawNameTP.Text.Trim() ;}
				if(combJQIsHaveKQTP.Text.Trim()!=""){
					model.JQIsHaveKQTP = combJQIsHaveKQTP.Text.Trim() ;}if(txtAV.Text.Trim()!=""){
						model.AV =Convert.ToDouble(txtAV.Text.Trim()) ;}
					
				if(combCYIsHaveKQTP.Text.Trim()!=""){
					model.CYIsHaveKQTP = combCYIsHaveKQTP.Text.Trim() ;}
				if(combT8WIsHaveKQTP.Text.Trim()!=""){
					model.T8WIsHaveKQTP = combT8WIsHaveKQTP.Text.Trim() ;}
					if(txtASTM.Text.Trim()!=""){
						model.ASTM = txtASTM.Text.Trim() ;}{
						model.GetSampleTime = dtGetSampleTime.Value ;}
				if(combGetSampPersonTP.Text.Trim()!=""){
					model.GetSampPersonTP = combGetSampPersonTP.Text.Trim() ;}
				if(combTestPersonTP.Text.Trim()!=""){
					model.TestPersonTP = combTestPersonTP.Text.Trim() ;}
				if(combGetSampLocationTP.Text.Trim()!=""){
					model.GetSampLocationTP = combGetSampLocationTP.Text.Trim() ;}{
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
			List <tb_KqTestData> modelList ;
			void GetData()
			{				
				//判断不为空，才能绑定				
				modelList = tb_KqTestData.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
							combRawNameTP.Enabled = true ;
							combJQIsHaveKQTP.Enabled = true ;txtAV.ReadOnly = false ;
							txtAV.Text = string.Empty  ; 
							combCYIsHaveKQTP.Enabled = true ;
							combT8WIsHaveKQTP.Enabled = true ;txtASTM.ReadOnly = false ;
							txtASTM.Text = string.Empty  ; 
							combGetSampPersonTP.Enabled = true ;
							combTestPersonTP.Enabled = true ;
							combGetSampLocationTP.Enabled = true ;txtRemark.ReadOnly = false ;
							txtRemark.Text = string.Empty  ; 
				}
			}
			private void SetControlEdit()
			{
				if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
					btnOK .Enabled = true ;
					btnOK.Text =" 保存";
					//控件除主键外都可读
				txtID.ReadOnly = true;combRawNameTP.Enabled = true ;combJQIsHaveKQTP.Enabled = true ;
					txtAV.ReadOnly = false ;combCYIsHaveKQTP.Enabled = true ;combT8WIsHaveKQTP.Enabled = true ;
					txtASTM.ReadOnly = false ;dtGetSampleTime.Enabled = true ;
				combGetSampPersonTP.Enabled = true ;combTestPersonTP.Enabled = true ;combGetSampLocationTP.Enabled = true ;dtUpdateTime.Enabled = true ;
				
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
							combRawNameTP.Enabled = false ;
							
							combJQIsHaveKQTP.Enabled = false ;
							txtAV.ReadOnly = true ;
							combCYIsHaveKQTP.Enabled = false ;
							
							combT8WIsHaveKQTP.Enabled = false ;
							txtASTM.ReadOnly = true ;
							dtGetSampleTime.Enabled = false ;
							
							combGetSampPersonTP.Enabled = false ;
							
							combTestPersonTP.Enabled = false ;
							
							combGetSampLocationTP.Enabled = false ;
							
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
				  
				  txtID.DataBindings.Clear();
						   txtID.DataBindings.Add ("Text",CutModel,"ID");
				  combRawNameTP.DataBindings.Clear () ;
													combRawNameTP.DataBindings.Add ("Text",CutModel,"RawNameTP") ;
				
				  combJQIsHaveKQTP.DataBindings.Clear () ;
													combJQIsHaveKQTP.DataBindings.Add ("Text",CutModel,"JQIsHaveKQTP") ;
				
				  txtAV.DataBindings.Clear();
						   txtAV.DataBindings.Add ("Text",CutModel,"AV");
				  combCYIsHaveKQTP.DataBindings.Clear () ;
													combCYIsHaveKQTP.DataBindings.Add ("Text",CutModel,"CYIsHaveKQTP") ;
				
				  combT8WIsHaveKQTP.DataBindings.Clear () ;
													combT8WIsHaveKQTP.DataBindings.Add ("Text",CutModel,"T8WIsHaveKQTP") ;
				
				  txtASTM.DataBindings.Clear();
						   txtASTM.DataBindings.Add ("Text",CutModel,"ASTM");
				  dtGetSampleTime.DataBindings.Clear () ;
													dtGetSampleTime.DataBindings.Add ("Value",CutModel,"GetSampleTime") ;
				
				  combGetSampPersonTP.DataBindings.Clear () ;
													combGetSampPersonTP.DataBindings.Add ("Text",CutModel,"GetSampPersonTP") ;
				
				  combTestPersonTP.DataBindings.Clear () ;
													combTestPersonTP.DataBindings.Add ("Text",CutModel,"TestPersonTP") ;
				
				  combGetSampLocationTP.DataBindings.Clear () ;
													combGetSampLocationTP.DataBindings.Add ("Text",CutModel,"GetSampLocationTP") ;
				
				  dtUpdateTime.DataBindings.Clear () ;
													dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
				
				  txtRemark.DataBindings.Clear();
						   txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
			}
			#endregion
		  }
	}