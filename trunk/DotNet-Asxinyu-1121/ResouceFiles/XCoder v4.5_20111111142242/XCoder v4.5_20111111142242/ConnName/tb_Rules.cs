/*
 * 由SharpDevelop创建。
 * 用户：asxinyu
 * 日期: 2011-10-8
 * 时间: 17:17
 *
 * 目标：添加按钮事件、绑定实体
 * 2011-11-23 根据数据管理窗口的统一需求,增加参数类,来传递参数。更加灵活和完整。 
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
using LotteryTicket;
using DotNet.Tools.Controls ;

namespace LotteryTicketSoft.GraphForm
{	
	public class AddRules: UserControl,IEntityControl 
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
		private System.Windows.Forms.TextBox txtId ;
		private System.Windows.Forms.Label    lblId ;
private System.Windows.Forms.TextBox txtSchemeId ;
		private System.Windows.Forms.Label    lblSchemeId ;

		private System.Windows.Forms.ComboBox combIndexSelectorNameTP ;
		private System.Windows.Forms.Label    lblIndexSelectorNameTP ;

		private System.Windows.Forms.ComboBox combCompareRuleNameTP ;
		private System.Windows.Forms.Label    lblCompareRuleNameTP ;
private System.Windows.Forms.TextBox txtRuleCompareParams ;
		private System.Windows.Forms.Label    lblRuleCompareParams ;
private System.Windows.Forms.TextBox txtDataRows ;
		private System.Windows.Forms.Label    lblDataRows ;
private System.Windows.Forms.TextBox txtCorrectRate ;
		private System.Windows.Forms.Label    lblCorrectRate ;
private System.Windows.Forms.TextBox txtFilterInfo ;
		private System.Windows.Forms.Label    lblFilterInfo ;
private System.Windows.Forms.TextBox txtEnable ;
		private System.Windows.Forms.Label    lblEnable ;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRules));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
			
			this.lblId = new System.Windows.Forms.Label() ;
			this.lblId.AutoSize = true;
			this.lblId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(10,16);
			this.lblId.TabIndex = 200 ;
			this.lblId.Text = "序号";
			this.Controls.Add(this.lblId) ;
		
			this.lblSchemeId = new System.Windows.Forms.Label() ;
			this.lblSchemeId.AutoSize = true;
			this.lblSchemeId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblSchemeId.Name = "lblSchemeId";
			this.lblSchemeId.Size = new System.Drawing.Size(10,16);
			this.lblSchemeId.TabIndex = 200 ;
			this.lblSchemeId.Text = "方案编号";
			this.Controls.Add(this.lblSchemeId) ;
		
			this.lblIndexSelectorNameTP = new System.Windows.Forms.Label() ;
			this.lblIndexSelectorNameTP.AutoSize = true;
			this.lblIndexSelectorNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblIndexSelectorNameTP.Name = "lblIndexSelectorNameTP";
			this.lblIndexSelectorNameTP.Size = new System.Drawing.Size(10,16);
			this.lblIndexSelectorNameTP.TabIndex = 200 ;
			this.lblIndexSelectorNameTP.Text = "指标函数";
			this.Controls.Add(this.lblIndexSelectorNameTP) ;
		
			this.lblCompareRuleNameTP = new System.Windows.Forms.Label() ;
			this.lblCompareRuleNameTP.AutoSize = true;
			this.lblCompareRuleNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCompareRuleNameTP.Name = "lblCompareRuleNameTP";
			this.lblCompareRuleNameTP.Size = new System.Drawing.Size(10,16);
			this.lblCompareRuleNameTP.TabIndex = 200 ;
			this.lblCompareRuleNameTP.Text = "对比类型";
			this.Controls.Add(this.lblCompareRuleNameTP) ;
		
			this.lblRuleCompareParams = new System.Windows.Forms.Label() ;
			this.lblRuleCompareParams.AutoSize = true;
			this.lblRuleCompareParams.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblRuleCompareParams.Name = "lblRuleCompareParams";
			this.lblRuleCompareParams.Size = new System.Drawing.Size(10,16);
			this.lblRuleCompareParams.TabIndex = 200 ;
			this.lblRuleCompareParams.Text = "比较参数";
			this.Controls.Add(this.lblRuleCompareParams) ;
		
			this.lblDataRows = new System.Windows.Forms.Label() ;
			this.lblDataRows.AutoSize = true;
			this.lblDataRows.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDataRows.Name = "lblDataRows";
			this.lblDataRows.Size = new System.Drawing.Size(10,16);
			this.lblDataRows.TabIndex = 200 ;
			this.lblDataRows.Text = "行数";
			this.Controls.Add(this.lblDataRows) ;
		
			this.lblCorrectRate = new System.Windows.Forms.Label() ;
			this.lblCorrectRate.AutoSize = true;
			this.lblCorrectRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCorrectRate.Name = "lblCorrectRate";
			this.lblCorrectRate.Size = new System.Drawing.Size(10,16);
			this.lblCorrectRate.TabIndex = 200 ;
			this.lblCorrectRate.Text = "正确率";
			this.Controls.Add(this.lblCorrectRate) ;
		
			this.lblFilterInfo = new System.Windows.Forms.Label() ;
			this.lblFilterInfo.AutoSize = true;
			this.lblFilterInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblFilterInfo.Name = "lblFilterInfo";
			this.lblFilterInfo.Size = new System.Drawing.Size(10,16);
			this.lblFilterInfo.TabIndex = 200 ;
			this.lblFilterInfo.Text = "过滤信息";
			this.Controls.Add(this.lblFilterInfo) ;
		
			this.lblEnable = new System.Windows.Forms.Label() ;
			this.lblEnable.AutoSize = true;
			this.lblEnable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblEnable.Name = "lblEnable";
			this.lblEnable.Size = new System.Drawing.Size(10,16);
			this.lblEnable.TabIndex = 200 ;
			this.lblEnable.Text = "有效";
			this.Controls.Add(this.lblEnable) ;
		
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
		
			this.lblId.Location = new System.Drawing.Point(6, 10);
			this.txtId = new System.Windows.Forms.TextBox() ;
			this.txtId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtId.Location = new System.Drawing.Point(158, 10);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(150,22);
			this.txtId.TabIndex = 0 ;
			this.Controls.Add(this.txtId) ;
			this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblSchemeId.Location = new System.Drawing.Point(6, 37);	
			this.txtSchemeId = new System.Windows.Forms.TextBox() ;
			this.txtSchemeId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtSchemeId.Location = new System.Drawing.Point(158, 37);
			this.txtSchemeId.Name = "txtSchemeId";
			this.txtSchemeId.Size = new System.Drawing.Size(150,22);
			this.txtSchemeId.TabIndex = 2 ;
			this.Controls.Add(this.txtSchemeId) ;
			this.lblIndexSelectorNameTP.Location = new System.Drawing.Point(6, 64);
			
			this.combIndexSelectorNameTP = new System.Windows.Forms.ComboBox() ;
			this.combIndexSelectorNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combIndexSelectorNameTP.FormattingEnabled = true;
			this.combIndexSelectorNameTP.Location = new System.Drawing.Point(158, 64);
			this.combIndexSelectorNameTP.Name = "combIndexSelectorNameTP";
			this.combIndexSelectorNameTP.Size = new System.Drawing.Size(150,22);
			this.combIndexSelectorNameTP.TabIndex = 4 ;
			this.Controls.Add(this.combIndexSelectorNameTP) ;
			
			this.lblCompareRuleNameTP.Location = new System.Drawing.Point(6, 91);
			
			this.combCompareRuleNameTP = new System.Windows.Forms.ComboBox() ;
			this.combCompareRuleNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combCompareRuleNameTP.FormattingEnabled = true;
			this.combCompareRuleNameTP.Location = new System.Drawing.Point(158, 91);
			this.combCompareRuleNameTP.Name = "combCompareRuleNameTP";
			this.combCompareRuleNameTP.Size = new System.Drawing.Size(150,22);
			this.combCompareRuleNameTP.TabIndex = 6 ;
			this.Controls.Add(this.combCompareRuleNameTP) ;
			
			this.lblRuleCompareParams.Location = new System.Drawing.Point(6, 118);	
			this.txtRuleCompareParams = new System.Windows.Forms.TextBox() ;
			this.txtRuleCompareParams.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRuleCompareParams.Location = new System.Drawing.Point(158, 118);
			this.txtRuleCompareParams.Name = "txtRuleCompareParams";
			this.txtRuleCompareParams.Size = new System.Drawing.Size(150,22);
			this.txtRuleCompareParams.TabIndex = 8 ;
			this.Controls.Add(this.txtRuleCompareParams) ;
			this.lblDataRows.Location = new System.Drawing.Point(6, 145);
			this.txtDataRows = new System.Windows.Forms.TextBox() ;
			this.txtDataRows.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDataRows.Location = new System.Drawing.Point(158, 145);
			this.txtDataRows.Name = "txtDataRows";
			this.txtDataRows.Size = new System.Drawing.Size(150,22);
			this.txtDataRows.TabIndex = 10 ;
			this.Controls.Add(this.txtDataRows) ;
			this.txtDataRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblCorrectRate.Location = new System.Drawing.Point(6, 172);
			this.txtCorrectRate = new System.Windows.Forms.TextBox() ;
			this.txtCorrectRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtCorrectRate.Location = new System.Drawing.Point(158, 172);
			this.txtCorrectRate.Name = "txtCorrectRate";
			this.txtCorrectRate.Size = new System.Drawing.Size(150,22);
			this.txtCorrectRate.TabIndex = 12 ;
			this.Controls.Add(this.txtCorrectRate) ;
			this.txtCorrectRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblFilterInfo.Location = new System.Drawing.Point(6, 199);	
			this.txtFilterInfo = new System.Windows.Forms.TextBox() ;
			this.txtFilterInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtFilterInfo.Location = new System.Drawing.Point(158, 199);
			this.txtFilterInfo.Name = "txtFilterInfo";
			this.txtFilterInfo.Size = new System.Drawing.Size(150,22);
			this.txtFilterInfo.TabIndex = 14 ;
			this.Controls.Add(this.txtFilterInfo) ;
			this.lblEnable.Location = new System.Drawing.Point(6, 226);
			this.txtEnable = new System.Windows.Forms.TextBox() ;
			this.txtEnable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtEnable.Location = new System.Drawing.Point(158, 226);
			this.txtEnable.Name = "txtEnable";
			this.txtEnable.Size = new System.Drawing.Size(150,22);
			this.txtEnable.TabIndex = 16 ;
			this.Controls.Add(this.txtEnable) ;
			this.txtEnable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblUpdateTime.Location = new System.Drawing.Point(6, 253);	
			this.dtUpdateTime = new System.Windows.Forms.DateTimePicker() ;
			this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtUpdateTime.Location = new System.Drawing.Point(158, 253);
			this.dtUpdateTime.Name = "dtUpdateTime";
			this.dtUpdateTime.Size = new System.Drawing.Size(150,22);
			this.dtUpdateTime.TabIndex = 18 ;
			this.Controls.Add(this.dtUpdateTime) ;
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
			this.Name = "AddRules";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.AddAddRulesLoad);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public AddRules()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddRulesLoad(object sender, EventArgs e){}
		/// <summary>
		/// 初始化设置
		/// </summary>
		public void InitializeSettings(DataControlParams controlParams)
		{
			this.FormPager.PageSize = 1;
            this.CutShowMode = controlParams.AddFormShowMode;
            this.CutSearchCondition = controlParams.AddFormSearchString; 
            if (CutShowMode == FormShowMode.AddOne || CutShowMode == FormShowMode.ContinueAdd)
            {
                CustomerSettings();
                SetAllTextControls(ControlStatus.Edit);
            }
            else
            {
                //此记录数可以在加载时固定起来,不用每次都计算
                FormPager.RecordCount = tb_Rules.FindCount(CutSearchCondition, "", "", 0, 0);
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
		/// 获取或者设置当前的查询条件
		/// </summary>
		public string CutSearchCondition { get; set; }
		
		/// <summary>
		/// 获取或者设置当前实体
		/// </summary>
		public tb_Rules CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{
			if(txtId.Text.Trim()=="")//序号
			{
				errorProvider1.SetError(txtId,"必填项目");
				return false ;
			}
			if(txtSchemeId.Text.Trim()=="")//方案编号
			{
				errorProvider1.SetError(txtSchemeId,"必填项目");
				return false ;
			}
			if(combIndexSelectorNameTP.Text.Trim()=="")//指标函数
			{
				errorProvider1.SetError(combIndexSelectorNameTP,"必填项目");
				return false ;
			} 
			if(txtDataRows.Text.Trim()=="")//行数
			{
				errorProvider1.SetError(txtDataRows,"必填项目");
				return false ;
			}
			if(txtEnable.Text.Trim()=="")//有效
			{
				errorProvider1.SetError(txtEnable,"必填项目");
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
					tb_Rules model = new tb_Rules();//定义当前实体 
					if(txtId.Text.Trim()!="")	model.Id =Convert.ToInt32(txtId.Text.Trim()) ;//序号
					if(txtSchemeId.Text.Trim()!="")  model.SchemeId = txtSchemeId.Text.Trim()  ;//方案编号
					if(combIndexSelectorNameTP.Text.Trim()!="") model.IndexSelectorNameTP = combIndexSelectorNameTP.Text.Trim() ;//指标函数
					if(combCompareRuleNameTP.Text.Trim()!="") model.CompareRuleNameTP = combCompareRuleNameTP.Text.Trim() ;//对比类型
					if(txtRuleCompareParams.Text.Trim()!="")  model.RuleCompareParams = txtRuleCompareParams.Text.Trim()  ;//比较参数
					if(txtDataRows.Text.Trim()!="")	model.DataRows =Convert.ToInt32(txtDataRows.Text.Trim()) ;//行数
					if(txtCorrectRate.Text.Trim()!="")	model.CorrectRate =Convert.ToDouble(txtCorrectRate.Text.Trim()) ;//正确率
					if(txtFilterInfo.Text.Trim()!="")  model.FilterInfo = txtFilterInfo.Text.Trim()  ;//过滤信息
					if(txtEnable.Text.Trim()!="")	model.Enable =Convert.ToBoolean(txtEnable.Text.Trim()) ;//有效
					model.UpdateTime = dtUpdateTime.Value ;//更新时间
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
		List <tb_Rules> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = tb_Rules.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				txtId.ReadOnly = false ;//序号
				txtId.Text = string.Empty  ; 
				txtSchemeId.ReadOnly = false ;//方案编号
				txtSchemeId.Text = string.Empty  ; 
				combIndexSelectorNameTP.Enabled = true ; //指标函数	
				combCompareRuleNameTP.Enabled = true ; //对比类型	
				txtRuleCompareParams.ReadOnly = false ;//比较参数
				txtRuleCompareParams.Text = string.Empty  ; 
				txtDataRows.ReadOnly = false ;//行数
				txtDataRows.Text = string.Empty  ; 
				txtCorrectRate.ReadOnly = false ;//正确率
				txtCorrectRate.Text = string.Empty  ; 
				txtFilterInfo.ReadOnly = false ;//过滤信息
				txtFilterInfo.Text = string.Empty  ; 
				txtEnable.ReadOnly = false ;//有效
				txtEnable.Text = string.Empty  ; 
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
				txtId.ReadOnly = true;//序号txtSchemeId.ReadOnly = false ;//方案编号
				combIndexSelectorNameTP.Enabled = true ;//指标函数
				combCompareRuleNameTP.Enabled = true ;//对比类型
				txtRuleCompareParams.ReadOnly = false ;//比较参数
				txtDataRows.ReadOnly = false ;//行数
				txtCorrectRate.ReadOnly = false ;//正确率
				txtFilterInfo.ReadOnly = false ;//过滤信息
				txtEnable.ReadOnly = false ;//有效
				dtUpdateTime.Enabled = true ;//更新时间
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
			txtId.ReadOnly = true  ;//序号
			txtSchemeId.ReadOnly = true  ;//方案编号
			combIndexSelectorNameTP.Enabled = false ;//指标函数
			combCompareRuleNameTP.Enabled = false ;//对比类型
			txtRuleCompareParams.ReadOnly = true  ;//比较参数
			txtDataRows.ReadOnly = true  ;//行数
			txtCorrectRate.ReadOnly = true  ;//正确率
			txtFilterInfo.ReadOnly = true  ;//过滤信息
			txtEnable.ReadOnly = true  ;//有效
			dtUpdateTime.Enabled = false   ;//更新时间
			txtRemark.ReadOnly = true  ;//备注
		}
		#endregion

		#region 绑定数据
		 /// <summary>
		/// 加载子窗口:if(Field.PrimaryKey) continue;
		/// </summary>
		private void BandingData()
		{
			txtId.DataBindings.Clear();//序号
			txtId.DataBindings.Add ("Text",CutModel,"Id");
			txtSchemeId.DataBindings.Clear();//方案编号
			txtSchemeId.DataBindings.Add ("Text",CutModel,"SchemeId");
			combIndexSelectorNameTP.DataBindings.Clear () ;//指标函数
			combIndexSelectorNameTP.DataBindings.Add ("Text",CutModel,"IndexSelectorNameTP") ;
			combCompareRuleNameTP.DataBindings.Clear () ;//对比类型
			combCompareRuleNameTP.DataBindings.Add ("Text",CutModel,"CompareRuleNameTP") ;
			txtRuleCompareParams.DataBindings.Clear();//比较参数
			txtRuleCompareParams.DataBindings.Add ("Text",CutModel,"RuleCompareParams");
			txtDataRows.DataBindings.Clear();//行数
			txtDataRows.DataBindings.Add ("Text",CutModel,"DataRows");
			txtCorrectRate.DataBindings.Clear();//正确率
			txtCorrectRate.DataBindings.Add ("Text",CutModel,"CorrectRate");
			txtFilterInfo.DataBindings.Clear();//过滤信息
			txtFilterInfo.DataBindings.Add ("Text",CutModel,"FilterInfo");
			txtEnable.DataBindings.Clear();//有效
			txtEnable.DataBindings.Add ("Text",CutModel,"Enable");
			dtUpdateTime.DataBindings.Clear () ;//更新时间
			dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}