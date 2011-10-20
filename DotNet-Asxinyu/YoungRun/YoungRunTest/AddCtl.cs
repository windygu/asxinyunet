/*
 * 由SharpDevelop创建。
 * 用户： asxinyu
 * 日期: 2011-10-8
 * 时间: 17:17
 *
 * 目标：添加按钮事件、绑定实体
 *
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

namespace YoungRunMISTest
{

	
	public class AddBttestdata: UserControl
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
		private System.Windows.Forms.TextBox txtProductName ;
		private System.Windows.Forms.Label    lblProductName ;
		private System.Windows.Forms.TextBox txtV40 ;
		private System.Windows.Forms.Label    lblV40 ;
		private System.Windows.Forms.TextBox txtV100 ;
		private System.Windows.Forms.Label    lblV100 ;
		private System.Windows.Forms.TextBox txtVI ;
		private System.Windows.Forms.Label    lblVI ;
		private System.Windows.Forms.TextBox txtAV ;
		private System.Windows.Forms.Label    lblAV ;
		private System.Windows.Forms.TextBox txtASTM ;
		private System.Windows.Forms.Label    lblASTM ;
		private System.Windows.Forms.DateTimePicker dtGetSampleTime ;
		private System.Windows.Forms.Label    lblGetSampleTime ;
		private System.Windows.Forms.TextBox txtGetSamLocation ;
		private System.Windows.Forms.Label    lblGetSamLocation ;
		private System.Windows.Forms.TextBox txtGetSampPerson ;
		private System.Windows.Forms.Label    lblGetSampPerson ;
		private System.Windows.Forms.TextBox txtTestPerson ;
		private System.Windows.Forms.Label    lblTestPerson ;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBttestdata));
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
			
			this.lblProductName = new System.Windows.Forms.Label() ;
			this.lblProductName.AutoSize = true;
			this.lblProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(10,16);
			this.lblProductName.TabIndex = 200 ;
			this.lblProductName.Text = "产品名称";
			this.Controls.Add(this.lblProductName) ;
			
			this.lblV40 = new System.Windows.Forms.Label() ;
			this.lblV40.AutoSize = true;
			this.lblV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblV40.Name = "lblV40";
			this.lblV40.Size = new System.Drawing.Size(10,16);
			this.lblV40.TabIndex = 200 ;
			this.lblV40.Text = "V40";
			this.Controls.Add(this.lblV40) ;
			
			this.lblV100 = new System.Windows.Forms.Label() ;
			this.lblV100.AutoSize = true;
			this.lblV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblV100.Name = "lblV100";
			this.lblV100.Size = new System.Drawing.Size(10,16);
			this.lblV100.TabIndex = 200 ;
			this.lblV100.Text = "V100";
			this.Controls.Add(this.lblV100) ;
			
			this.lblVI = new System.Windows.Forms.Label() ;
			this.lblVI.AutoSize = true;
			this.lblVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblVI.Name = "lblVI";
			this.lblVI.Size = new System.Drawing.Size(10,16);
			this.lblVI.TabIndex = 200 ;
			this.lblVI.Text = "粘度指数";
			this.Controls.Add(this.lblVI) ;
			
			this.lblAV = new System.Windows.Forms.Label() ;
			this.lblAV.AutoSize = true;
			this.lblAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblAV.Name = "lblAV";
			this.lblAV.Size = new System.Drawing.Size(10,16);
			this.lblAV.TabIndex = 200 ;
			this.lblAV.Text = "酸值";
			this.Controls.Add(this.lblAV) ;
			
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
			
			this.lblGetSamLocation = new System.Windows.Forms.Label() ;
			this.lblGetSamLocation.AutoSize = true;
			this.lblGetSamLocation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblGetSamLocation.Name = "lblGetSamLocation";
			this.lblGetSamLocation.Size = new System.Drawing.Size(10,16);
			this.lblGetSamLocation.TabIndex = 200 ;
			this.lblGetSamLocation.Text = "采样地点";
			this.Controls.Add(this.lblGetSamLocation) ;
			
			this.lblGetSampPerson = new System.Windows.Forms.Label() ;
			this.lblGetSampPerson.AutoSize = true;
			this.lblGetSampPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblGetSampPerson.Name = "lblGetSampPerson";
			this.lblGetSampPerson.Size = new System.Drawing.Size(10,16);
			this.lblGetSampPerson.TabIndex = 200 ;
			this.lblGetSampPerson.Text = "采样人";
			this.Controls.Add(this.lblGetSampPerson) ;
			
			this.lblTestPerson = new System.Windows.Forms.Label() ;
			this.lblTestPerson.AutoSize = true;
			this.lblTestPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTestPerson.Name = "lblTestPerson";
			this.lblTestPerson.Size = new System.Drawing.Size(10,16);
			this.lblTestPerson.TabIndex = 200 ;
			this.lblTestPerson.Text = "检测人";
			this.Controls.Add(this.lblTestPerson) ;
			
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
			
			this.lblProductName.Location = new System.Drawing.Point(6, 37);
			
			this.txtProductName = new System.Windows.Forms.TextBox() ;
			this.txtProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtProductName.Location = new System.Drawing.Point(158, 37);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(150,22);
			this.txtProductName.TabIndex = 2 ;
			this.Controls.Add(this.txtProductName) ;
			
			this.lblV40.Location = new System.Drawing.Point(6, 64);
			
			this.txtV40 = new System.Windows.Forms.TextBox() ;
			this.txtV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtV40.Location = new System.Drawing.Point(158, 64);
			this.txtV40.Name = "txtV40";
			this.txtV40.Size = new System.Drawing.Size(150,22);
			this.txtV40.TabIndex = 4 ;
			this.Controls.Add(this.txtV40) ;
			this.txtV40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblV100.Location = new System.Drawing.Point(6, 91);
			
			this.txtV100 = new System.Windows.Forms.TextBox() ;
			this.txtV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtV100.Location = new System.Drawing.Point(158, 91);
			this.txtV100.Name = "txtV100";
			this.txtV100.Size = new System.Drawing.Size(150,22);
			this.txtV100.TabIndex = 6 ;
			this.Controls.Add(this.txtV100) ;
			this.txtV100.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblVI.Location = new System.Drawing.Point(6, 118);
			
			this.txtVI = new System.Windows.Forms.TextBox() ;
			this.txtVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtVI.Location = new System.Drawing.Point(158, 118);
			this.txtVI.Name = "txtVI";
			this.txtVI.Size = new System.Drawing.Size(150,22);
			this.txtVI.TabIndex = 8 ;
			this.Controls.Add(this.txtVI) ;
			this.txtVI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblAV.Location = new System.Drawing.Point(6, 145);
			
			this.txtAV = new System.Windows.Forms.TextBox() ;
			this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtAV.Location = new System.Drawing.Point(158, 145);
			this.txtAV.Name = "txtAV";
			this.txtAV.Size = new System.Drawing.Size(150,22);
			this.txtAV.TabIndex = 10 ;
			this.Controls.Add(this.txtAV) ;
			this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
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
			
			this.lblGetSamLocation.Location = new System.Drawing.Point(6, 226);
			
			this.txtGetSamLocation = new System.Windows.Forms.TextBox() ;
			this.txtGetSamLocation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtGetSamLocation.Location = new System.Drawing.Point(158, 226);
			this.txtGetSamLocation.Name = "txtGetSamLocation";
			this.txtGetSamLocation.Size = new System.Drawing.Size(150,22);
			this.txtGetSamLocation.TabIndex = 16 ;
			this.Controls.Add(this.txtGetSamLocation) ;
			
			this.lblGetSampPerson.Location = new System.Drawing.Point(6, 253);
			
			this.txtGetSampPerson = new System.Windows.Forms.TextBox() ;
			this.txtGetSampPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtGetSampPerson.Location = new System.Drawing.Point(158, 253);
			this.txtGetSampPerson.Name = "txtGetSampPerson";
			this.txtGetSampPerson.Size = new System.Drawing.Size(150,22);
			this.txtGetSampPerson.TabIndex = 18 ;
			this.Controls.Add(this.txtGetSampPerson) ;
			
			this.lblTestPerson.Location = new System.Drawing.Point(6, 280);
			
			this.txtTestPerson = new System.Windows.Forms.TextBox() ;
			this.txtTestPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtTestPerson.Location = new System.Drawing.Point(158, 280);
			this.txtTestPerson.Name = "txtTestPerson";
			this.txtTestPerson.Size = new System.Drawing.Size(150,22);
			this.txtTestPerson.TabIndex = 20 ;
			this.Controls.Add(this.txtTestPerson) ;
			
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
			this.Name = "AddBttestdata";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.AddAddBttestdataLoad);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion

		#region 构造函数 及初始化
		public AddBttestdata()
		{
			InitializeComponent();
		}
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddBttestdataLoad(object sender, EventArgs e)
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
				FormPager.RecordCount = tb_bttestdata.FindCount(CutSearchCondition,"","",0,0) ;
			}
		}
		/// <summary>
		/// 获取或者设置当前实体列表
		/// </summary>
		//	public List<tb_bttestdata> CurrEntityList  //
		//	{
		//		get ;set ;
		//	}
		public tb_bttestdata CutModel
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
					tb_bttestdata model = new tb_bttestdata();//定义当前实体
					
					if(txtID.Text.Trim()!=""){
						model.ID = txtID.Text.Trim() ;}
					if(txtProductName.Text.Trim()!=""){
						model.ProductName = txtProductName.Text.Trim() ;}if(txtV40.Text.Trim()!=""){
						model.V40 =Convert.ToDouble(txtV40.Text.Trim()) ;}
					if(txtV100.Text.Trim()!=""){
						model.V100 =Convert.ToDouble(txtV100.Text.Trim()) ;}
					if(txtVI.Text.Trim()!=""){
						model.VI =Convert.ToInt32(txtVI.Text.Trim()) ;}
					if(txtAV.Text.Trim()!=""){
						model.AV =Convert.ToDouble(txtAV.Text.Trim()) ;}
					
					if(txtASTM.Text.Trim()!=""){
						model.ASTM = txtASTM.Text.Trim() ;}{
						model.GetSampleTime = dtGetSampleTime.Value ;}
					if(txtGetSamLocation.Text.Trim()!=""){
						model.GetSamLocation = txtGetSamLocation.Text.Trim() ;}
					if(txtGetSampPerson.Text.Trim()!=""){
						model.GetSampPerson = txtGetSampPerson.Text.Trim() ;}
					if(txtTestPerson.Text.Trim()!=""){
						model.TestPerson = txtTestPerson.Text.Trim() ;}{
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
		List <tb_bttestdata> modelList ;
		void GetData()
		{
			//判断不为空，才能绑定
			modelList = tb_bttestdata.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				txtID.Text = string.Empty  ; txtProductName.ReadOnly = false ;
				txtProductName.Text = string.Empty  ; txtV40.ReadOnly = false ;
				txtV40.Text = string.Empty  ; txtV100.ReadOnly = false ;
				txtV100.Text = string.Empty  ; txtVI.ReadOnly = false ;
				txtVI.Text = string.Empty  ; txtAV.ReadOnly = false ;
				txtAV.Text = string.Empty  ; txtASTM.ReadOnly = false ;
				txtASTM.Text = string.Empty  ; txtGetSamLocation.ReadOnly = false ;
				txtGetSamLocation.Text = string.Empty  ; txtGetSampPerson.ReadOnly = false ;
				txtGetSampPerson.Text = string.Empty  ; txtTestPerson.ReadOnly = false ;
				txtTestPerson.Text = string.Empty  ; txtRemark.ReadOnly = false ;
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
				txtProductName.ReadOnly = false ;
				txtV40.ReadOnly = false ;
				txtV100.ReadOnly = false ;
				txtVI.ReadOnly = false ;
				txtAV.ReadOnly = false ;
				txtASTM.ReadOnly = false ;dtGetSampleTime.Enabled = true ;
				
				txtGetSamLocation.ReadOnly = false ;
				txtGetSampPerson.ReadOnly = false ;
				txtTestPerson.ReadOnly = false ;dtUpdateTime.Enabled = true ;
				
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
			txtID.ReadOnly = true ;txtProductName.ReadOnly = true ;txtV40.ReadOnly = true ;txtV100.ReadOnly = true ;txtVI.ReadOnly = true ;txtAV.ReadOnly = true ;txtASTM.ReadOnly = true ;
			dtGetSampleTime.Enabled = false ;
			txtGetSamLocation.ReadOnly = true ;txtGetSampPerson.ReadOnly = true ;txtTestPerson.ReadOnly = true ;
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
			txtProductName.DataBindings.Clear();
			txtProductName.DataBindings.Add ("Text",CutModel,"ProductName");
			txtV40.DataBindings.Clear();
			txtV40.DataBindings.Add ("Text",CutModel,"V40");
			txtV100.DataBindings.Clear();
			txtV100.DataBindings.Add ("Text",CutModel,"V100");
			txtVI.DataBindings.Clear();
			txtVI.DataBindings.Add ("Text",CutModel,"VI");
			txtAV.DataBindings.Clear();
			txtAV.DataBindings.Add ("Text",CutModel,"AV");
			txtASTM.DataBindings.Clear();
			txtASTM.DataBindings.Add ("Text",CutModel,"ASTM");
			dtGetSampleTime.DataBindings.Clear () ;
			dtGetSampleTime.DataBindings.Add ("Value",CutModel,"GetSampleTime") ;
			
			txtGetSamLocation.DataBindings.Clear();
			txtGetSamLocation.DataBindings.Add ("Text",CutModel,"GetSamLocation");
			txtGetSampPerson.DataBindings.Clear();
			txtGetSampPerson.DataBindings.Add ("Text",CutModel,"GetSampPerson");
			txtTestPerson.DataBindings.Clear();
			txtTestPerson.DataBindings.Add ("Text",CutModel,"TestPerson");
			dtUpdateTime.DataBindings.Clear () ;
			dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
			
			txtRemark.DataBindings.Clear();
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
	}
}