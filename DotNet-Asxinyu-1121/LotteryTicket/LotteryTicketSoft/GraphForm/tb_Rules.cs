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


        private System.Windows.Forms.ComboBox combIndexSelectorNameTP ;
		private System.Windows.Forms.Label    lblIndexSelectorNameTP ;

		private System.Windows.Forms.ComboBox combCompareRuleNameTP ;
		private System.Windows.Forms.Label    lblCompareRuleNameTP ;
private System.Windows.Forms.TextBox txtFloorLimit ;
		private System.Windows.Forms.Label    lblFloorLimit ;
private System.Windows.Forms.TextBox txtCeilLimit ;
		private System.Windows.Forms.Label    lblCeilLimit ;
private System.Windows.Forms.TextBox txtCompListStr ;
		private System.Windows.Forms.Label    lblCompListStr ;
private System.Windows.Forms.TextBox txtDataRows ;
		private System.Windows.Forms.Label    lblDataRows ;
private System.Windows.Forms.DateTimePicker dtUpdateTime ;
		private System.Windows.Forms.Label    lblUpdateTime ;
private System.Windows.Forms.TextBox txtRemark ;
		private System.Windows.Forms.Label    lblRemark ;
   private System.Windows.Forms.ErrorProvider errorProvider1 ;
		private System.Windows.Forms.Button btnOK ;
        private EntityFormPager FormPager;
        private System.Windows.Forms.Button btnCancle;
		#endregion
		
		#region 组件设计器生成的代码
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRules));
            this.lblIndexSelectorNameTP = new System.Windows.Forms.Label();
            this.lblCompareRuleNameTP = new System.Windows.Forms.Label();
            this.lblFloorLimit = new System.Windows.Forms.Label();
            this.lblCeilLimit = new System.Windows.Forms.Label();
            this.lblCompListStr = new System.Windows.Forms.Label();
            this.lblDataRows = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.combIndexSelectorNameTP = new System.Windows.Forms.ComboBox();
            this.combCompareRuleNameTP = new System.Windows.Forms.ComboBox();
            this.txtFloorLimit = new System.Windows.Forms.TextBox();
            this.txtCeilLimit = new System.Windows.Forms.TextBox();
            this.txtCompListStr = new System.Windows.Forms.TextBox();
            this.txtDataRows = new System.Windows.Forms.TextBox();
            this.dtUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIndexSelectorNameTP
            // 
            this.lblIndexSelectorNameTP.AutoSize = true;
            this.lblIndexSelectorNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIndexSelectorNameTP.Location = new System.Drawing.Point(3, 11);
            this.lblIndexSelectorNameTP.Name = "lblIndexSelectorNameTP";
            this.lblIndexSelectorNameTP.Size = new System.Drawing.Size(63, 14);
            this.lblIndexSelectorNameTP.TabIndex = 200;
            this.lblIndexSelectorNameTP.Text = "指标函数";
            // 
            // lblCompareRuleNameTP
            // 
            this.lblCompareRuleNameTP.AutoSize = true;
            this.lblCompareRuleNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompareRuleNameTP.Location = new System.Drawing.Point(3, 42);
            this.lblCompareRuleNameTP.Name = "lblCompareRuleNameTP";
            this.lblCompareRuleNameTP.Size = new System.Drawing.Size(63, 14);
            this.lblCompareRuleNameTP.TabIndex = 200;
            this.lblCompareRuleNameTP.Text = "对比类型";
            // 
            // lblFloorLimit
            // 
            this.lblFloorLimit.AutoSize = true;
            this.lblFloorLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloorLimit.Location = new System.Drawing.Point(31, 74);
            this.lblFloorLimit.Name = "lblFloorLimit";
            this.lblFloorLimit.Size = new System.Drawing.Size(35, 14);
            this.lblFloorLimit.TabIndex = 200;
            this.lblFloorLimit.Text = "下限";
            // 
            // lblCeilLimit
            // 
            this.lblCeilLimit.AutoSize = true;
            this.lblCeilLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCeilLimit.Location = new System.Drawing.Point(31, 105);
            this.lblCeilLimit.Name = "lblCeilLimit";
            this.lblCeilLimit.Size = new System.Drawing.Size(35, 14);
            this.lblCeilLimit.TabIndex = 200;
            this.lblCeilLimit.Text = "上限";
            // 
            // lblCompListStr
            // 
            this.lblCompListStr.AutoSize = true;
            this.lblCompListStr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompListStr.Location = new System.Drawing.Point(3, 137);
            this.lblCompListStr.Name = "lblCompListStr";
            this.lblCompListStr.Size = new System.Drawing.Size(63, 14);
            this.lblCompListStr.TabIndex = 200;
            this.lblCompListStr.Text = "对比序列";
            // 
            // lblDataRows
            // 
            this.lblDataRows.AutoSize = true;
            this.lblDataRows.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDataRows.Location = new System.Drawing.Point(3, 168);
            this.lblDataRows.Name = "lblDataRows";
            this.lblDataRows.Size = new System.Drawing.Size(63, 14);
            this.lblDataRows.TabIndex = 200;
            this.lblDataRows.Text = "验证行数";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateTime.Location = new System.Drawing.Point(3, 200);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(63, 14);
            this.lblUpdateTime.TabIndex = 200;
            this.lblUpdateTime.Text = "更新时间";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(31, 231);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(35, 14);
            this.lblRemark.TabIndex = 200;
            this.lblRemark.Text = "备注";
            // 
            // combIndexSelectorNameTP
            // 
            this.combIndexSelectorNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combIndexSelectorNameTP.FormattingEnabled = true;
            this.combIndexSelectorNameTP.Location = new System.Drawing.Point(69, 7);
            this.combIndexSelectorNameTP.Name = "combIndexSelectorNameTP";
            this.combIndexSelectorNameTP.Size = new System.Drawing.Size(209, 22);
            this.combIndexSelectorNameTP.TabIndex = 2;
            // 
            // combCompareRuleNameTP
            // 
            this.combCompareRuleNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combCompareRuleNameTP.FormattingEnabled = true;
            this.combCompareRuleNameTP.Location = new System.Drawing.Point(69, 39);
            this.combCompareRuleNameTP.Name = "combCompareRuleNameTP";
            this.combCompareRuleNameTP.Size = new System.Drawing.Size(209, 22);
            this.combCompareRuleNameTP.TabIndex = 4;
            // 
            // txtFloorLimit
            // 
            this.txtFloorLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFloorLimit.Location = new System.Drawing.Point(69, 70);
            this.txtFloorLimit.Name = "txtFloorLimit";
            this.txtFloorLimit.Size = new System.Drawing.Size(209, 23);
            this.txtFloorLimit.TabIndex = 6;
            this.txtFloorLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtCeilLimit
            // 
            this.txtCeilLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCeilLimit.Location = new System.Drawing.Point(69, 102);
            this.txtCeilLimit.Name = "txtCeilLimit";
            this.txtCeilLimit.Size = new System.Drawing.Size(209, 23);
            this.txtCeilLimit.TabIndex = 8;
            this.txtCeilLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtCompListStr
            // 
            this.txtCompListStr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompListStr.Location = new System.Drawing.Point(69, 133);
            this.txtCompListStr.Name = "txtCompListStr";
            this.txtCompListStr.Size = new System.Drawing.Size(209, 23);
            this.txtCompListStr.TabIndex = 10;
            // 
            // txtDataRows
            // 
            this.txtDataRows.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDataRows.Location = new System.Drawing.Point(69, 165);
            this.txtDataRows.Name = "txtDataRows";
            this.txtDataRows.Size = new System.Drawing.Size(209, 23);
            this.txtDataRows.TabIndex = 12;
            this.txtDataRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // dtUpdateTime
            // 
            this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtUpdateTime.Location = new System.Drawing.Point(69, 196);
            this.dtUpdateTime.Name = "dtUpdateTime";
            this.dtUpdateTime.Size = new System.Drawing.Size(209, 23);
            this.dtUpdateTime.TabIndex = 14;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(69, 228);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(209, 23);
            this.txtRemark.TabIndex = 16;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(92, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 31);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(185, 257);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(91, 31);
            this.btnCancle.TabIndex = 20;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.FormPager.Location = new System.Drawing.Point(76, 335);
            this.FormPager.Name = "FormPager";
            this.FormPager.RecordCount = 0;
            this.FormPager.Size = new System.Drawing.Size(238, 29);
            this.FormPager.TabIndex = 100;
            this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
            // 
            // AddRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIndexSelectorNameTP);
            this.Controls.Add(this.lblCompareRuleNameTP);
            this.Controls.Add(this.lblFloorLimit);
            this.Controls.Add(this.lblCeilLimit);
            this.Controls.Add(this.lblCompListStr);
            this.Controls.Add(this.lblDataRows);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.combIndexSelectorNameTP);
            this.Controls.Add(this.combCompareRuleNameTP);
            this.Controls.Add(this.txtFloorLimit);
            this.Controls.Add(this.txtCeilLimit);
            this.Controls.Add(this.txtCompListStr);
            this.Controls.Add(this.txtDataRows);
            this.Controls.Add(this.dtUpdateTime);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.FormPager);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AddRules";
            this.Size = new System.Drawing.Size(287, 292);
            this.Load += new System.EventHandler(this.AddAddRulesLoad);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
		/// <param name="showMode">窗体的显示模式,必须指定</param>
		/// <param name="searchCondtion">指定显示的实体条件</param>
		public void InitializeSettings(DataControlParams controlParams)
		{
			this.FormPager.PageSize = 1;
            this.CutShowMode = controlParams.AddFormShowMode;
            this.CutSearchCondition = controlParams.AddFormSearchString; ;
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
            combIndexSelectorNameTP.Items.AddRange(LotTicketHelper.GetAllIndexFuncNames().ToArray());
            combCompareRuleNameTP.Items.AddRange(LotTicketHelper.GetAllEnumNames<CompareType>().ToArray());
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
		public tb_Rules CutModel{ get ;set ;}

        /// <summary>
        /// 当前实体窗体的显示模式,默认为连续显示
        /// </summary>
        public FormShowMode CutShowMode { get; set; }
		#endregion

		#region 验证事件
		bool ValidateControls()
		{			
			if(combIndexSelectorNameTP.Text.Trim()=="")//指标函数
			{
				errorProvider1.SetError(combIndexSelectorNameTP,"必填项目");
				return false ;
			} 
			if(txtDataRows.Text.Trim()=="")//验证行数
			{
				errorProvider1.SetError(txtDataRows,"必填项目");
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
					if(combIndexSelectorNameTP.Text.Trim()!="") model.IndexSelectorNameTP = combIndexSelectorNameTP.Text.Trim() ;//指标函数
					if(combCompareRuleNameTP.Text.Trim()!="") model.CompareRuleNameTP = combCompareRuleNameTP.Text.Trim() ;//对比类型
					if(txtFloorLimit.Text.Trim()!="")	model.FloorLimit =Convert.ToInt16(txtFloorLimit.Text.Trim()) ;//下限
					if(txtCeilLimit.Text.Trim()!="")	model.CeilLimit =Convert.ToInt16(txtCeilLimit.Text.Trim()) ;//上限
					if(txtCompListStr.Text.Trim()!="")  model.CompListStr = txtCompListStr.Text.Trim()  ;//对比序列
					if(txtDataRows.Text.Trim()!="")	model.DataRows =Convert.ToInt16(txtDataRows.Text.Trim()) ;//验证行数
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
				combIndexSelectorNameTP.Enabled = true ; //指标函数	
				combCompareRuleNameTP.Enabled = true ; //对比类型	
				txtFloorLimit.ReadOnly = false ;//下限
				txtFloorLimit.Text = string.Empty  ; 
				txtCeilLimit.ReadOnly = false ;//上限
				txtCeilLimit.Text = string.Empty  ; 
				txtCompListStr.ReadOnly = false ;//对比序列
				txtCompListStr.Text = string.Empty  ; 
				txtDataRows.ReadOnly = false ;//验证行数
				txtDataRows.Text = string.Empty  ; 
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
                combIndexSelectorNameTP.Enabled = true ;//指标函数
				combCompareRuleNameTP.Enabled = true ;//对比类型
				txtFloorLimit.ReadOnly = false ;//下限
				txtCeilLimit.ReadOnly = false ;//上限
				txtCompListStr.ReadOnly = false ;//对比序列
				txtDataRows.ReadOnly = false ;//验证行数
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
            combIndexSelectorNameTP.Enabled = false ;//指标函数
			combCompareRuleNameTP.Enabled = false ;//对比类型
			txtFloorLimit.ReadOnly = true  ;//下限
			txtCeilLimit.ReadOnly = true  ;//上限
			txtCompListStr.ReadOnly = true  ;//对比序列
			txtDataRows.ReadOnly = true  ;//验证行数
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
			combIndexSelectorNameTP.DataBindings.Clear () ;//指标函数
			combIndexSelectorNameTP.DataBindings.Add ("Text",CutModel,"IndexSelectorNameTP") ;
			combCompareRuleNameTP.DataBindings.Clear () ;//对比类型
			combCompareRuleNameTP.DataBindings.Add ("Text",CutModel,"CompareRuleNameTP") ;
			txtFloorLimit.DataBindings.Clear();//下限
			txtFloorLimit.DataBindings.Add ("Text",CutModel,"FloorLimit");
			txtCeilLimit.DataBindings.Clear();//上限
			txtCeilLimit.DataBindings.Add ("Text",CutModel,"CeilLimit");
			txtCompListStr.DataBindings.Clear();//对比序列
			txtCompListStr.DataBindings.Add ("Text",CutModel,"CompListStr");
			txtDataRows.DataBindings.Clear();//验证行数
			txtDataRows.DataBindings.Add ("Text",CutModel,"DataRows");
			dtUpdateTime.DataBindings.Clear () ;//更新时间
			dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}