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
	public class AddIndexInfo: UserControl,IEntityControl 
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
private System.Windows.Forms.TextBox txtIndexName ;
		private System.Windows.Forms.Label    lblIndexName ;
private System.Windows.Forms.TextBox txtClassName ;
		private System.Windows.Forms.Label    lblClassName ;
private System.Windows.Forms.TextBox txtPriorLevel ;
		private System.Windows.Forms.Label    lblPriorLevel ;

		private System.Windows.Forms.ComboBox combSuitableType ;
		private System.Windows.Forms.Label    lblSuitableType ;
private System.Windows.Forms.TextBox txtUseExplain ;
		private System.Windows.Forms.Label    lblUseExplain ;
private System.Windows.Forms.TextBox txtDescription ;
		private System.Windows.Forms.Label    lblDescription ;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIndexInfo));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
			
			this.lblId = new System.Windows.Forms.Label() ;
			this.lblId.AutoSize = true;
			this.lblId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(10,16);
			this.lblId.TabIndex = 200 ;
			this.lblId.Text = "指标编号";
			this.Controls.Add(this.lblId) ;
		
			this.lblIndexName = new System.Windows.Forms.Label() ;
			this.lblIndexName.AutoSize = true;
			this.lblIndexName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblIndexName.Name = "lblIndexName";
			this.lblIndexName.Size = new System.Drawing.Size(10,16);
			this.lblIndexName.TabIndex = 200 ;
			this.lblIndexName.Text = "指标名称";
			this.Controls.Add(this.lblIndexName) ;
		
			this.lblClassName = new System.Windows.Forms.Label() ;
			this.lblClassName.AutoSize = true;
			this.lblClassName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(10,16);
			this.lblClassName.TabIndex = 200 ;
			this.lblClassName.Text = "所属类";
			this.Controls.Add(this.lblClassName) ;
		
			this.lblPriorLevel = new System.Windows.Forms.Label() ;
			this.lblPriorLevel.AutoSize = true;
			this.lblPriorLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblPriorLevel.Name = "lblPriorLevel";
			this.lblPriorLevel.Size = new System.Drawing.Size(10,16);
			this.lblPriorLevel.TabIndex = 200 ;
			this.lblPriorLevel.Text = "优先级";
			this.Controls.Add(this.lblPriorLevel) ;
		
			this.lblSuitableType = new System.Windows.Forms.Label() ;
			this.lblSuitableType.AutoSize = true;
			this.lblSuitableType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblSuitableType.Name = "lblSuitableType";
			this.lblSuitableType.Size = new System.Drawing.Size(10,16);
			this.lblSuitableType.TabIndex = 200 ;
			this.lblSuitableType.Text = "适用类型";
			this.Controls.Add(this.lblSuitableType) ;
		
			this.lblUseExplain = new System.Windows.Forms.Label() ;
			this.lblUseExplain.AutoSize = true;
			this.lblUseExplain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblUseExplain.Name = "lblUseExplain";
			this.lblUseExplain.Size = new System.Drawing.Size(10,16);
			this.lblUseExplain.TabIndex = 200 ;
			this.lblUseExplain.Text = "使用说明";
			this.Controls.Add(this.lblUseExplain) ;
		
			this.lblDescription = new System.Windows.Forms.Label() ;
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(10,16);
			this.lblDescription.TabIndex = 200 ;
			this.lblDescription.Text = "指标描述";
			this.Controls.Add(this.lblDescription) ;
		
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
			
			this.lblIndexName.Location = new System.Drawing.Point(6, 37);	
			this.txtIndexName = new System.Windows.Forms.TextBox() ;
			this.txtIndexName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtIndexName.Location = new System.Drawing.Point(158, 37);
			this.txtIndexName.Name = "txtIndexName";
			this.txtIndexName.Size = new System.Drawing.Size(150,22);
			this.txtIndexName.TabIndex = 2 ;
			this.Controls.Add(this.txtIndexName) ;
			this.lblClassName.Location = new System.Drawing.Point(6, 64);	
			this.txtClassName = new System.Windows.Forms.TextBox() ;
			this.txtClassName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtClassName.Location = new System.Drawing.Point(158, 64);
			this.txtClassName.Name = "txtClassName";
			this.txtClassName.Size = new System.Drawing.Size(150,22);
			this.txtClassName.TabIndex = 4 ;
			this.Controls.Add(this.txtClassName) ;
			this.lblPriorLevel.Location = new System.Drawing.Point(6, 91);
			this.txtPriorLevel = new System.Windows.Forms.TextBox() ;
			this.txtPriorLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtPriorLevel.Location = new System.Drawing.Point(158, 91);
			this.txtPriorLevel.Name = "txtPriorLevel";
			this.txtPriorLevel.Size = new System.Drawing.Size(150,22);
			this.txtPriorLevel.TabIndex = 6 ;
			this.Controls.Add(this.txtPriorLevel) ;
			this.txtPriorLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblSuitableType.Location = new System.Drawing.Point(6, 118);
			
			this.combSuitableType = new System.Windows.Forms.ComboBox() ;
			this.combSuitableType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combSuitableType.FormattingEnabled = true;
			this.combSuitableType.Location = new System.Drawing.Point(158, 118);
			this.combSuitableType.Name = "combSuitableType";
			this.combSuitableType.Size = new System.Drawing.Size(150,22);
			this.combSuitableType.TabIndex = 8 ;
			this.Controls.Add(this.combSuitableType) ;
			
			this.lblUseExplain.Location = new System.Drawing.Point(6, 145);	
			this.txtUseExplain = new System.Windows.Forms.TextBox() ;
			this.txtUseExplain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtUseExplain.Location = new System.Drawing.Point(158, 145);
			this.txtUseExplain.Name = "txtUseExplain";
			this.txtUseExplain.Size = new System.Drawing.Size(150,22);
			this.txtUseExplain.TabIndex = 10 ;
			this.Controls.Add(this.txtUseExplain) ;
			this.lblDescription.Location = new System.Drawing.Point(6, 172);	
			this.txtDescription = new System.Windows.Forms.TextBox() ;
			this.txtDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDescription.Location = new System.Drawing.Point(158, 172);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(150,22);
			this.txtDescription.TabIndex = 12 ;
			this.Controls.Add(this.txtDescription) ;
			this.lblUpdateTime.Location = new System.Drawing.Point(6, 199);	
			this.dtUpdateTime = new System.Windows.Forms.DateTimePicker() ;
			this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtUpdateTime.Location = new System.Drawing.Point(158, 199);
			this.dtUpdateTime.Name = "dtUpdateTime";
			this.dtUpdateTime.Size = new System.Drawing.Size(150,22);
			this.dtUpdateTime.TabIndex = 14 ;
			this.Controls.Add(this.dtUpdateTime) ;
			this.lblRemark.Location = new System.Drawing.Point(6, 226);	
			this.txtRemark = new System.Windows.Forms.TextBox() ;
			this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRemark.Location = new System.Drawing.Point(158, 226);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(150,22);
			this.txtRemark.TabIndex = 16 ;
			this.Controls.Add(this.txtRemark) ;
			#region 添加按钮
			this.btnOK = new System.Windows.Forms.Button();
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(26, 273);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = 18;
			this.btnOK.Text = "保存";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Controls.Add(this.btnOK);
			this.btnCancle = new System.Windows.Forms.Button();
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(106, 273);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = 20;
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
			this.FormPager.Location = new System.Drawing.Point(10, 303);
			this.FormPager.Name = "FormPager";
			this.FormPager.RecordCount = 0;
			this.FormPager.Size = new System.Drawing.Size(256, 29);
			this.FormPager.TabIndex = 100;
			this.Controls.Add(this.FormPager);
			this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
			#endregion
			#region 窗体
			this.Name = "AddIndexInfo";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.AddAddIndexInfoLoad);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public AddIndexInfo()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddIndexInfoLoad(object sender, EventArgs e){}
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
		public tb_IndexInfo CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{
			if(txtId.Text.Trim()=="")//指标编号
			{
				errorProvider1.SetError(txtId,"必填项目");
				return false ;
			}
			if(txtIndexName.Text.Trim()=="")//指标名称
			{
				errorProvider1.SetError(txtIndexName,"必填项目");
				return false ;
			}
			if(txtClassName.Text.Trim()=="")//所属类
			{
				errorProvider1.SetError(txtClassName,"必填项目");
				return false ;
			}
			if(txtPriorLevel.Text.Trim()=="")//优先级
			{
				errorProvider1.SetError(txtPriorLevel,"必填项目");
				return false ;
			}
			if(combSuitableType.Text.Trim()=="")//适用类型
			{
				errorProvider1.SetError(combSuitableType,"必填项目");
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
					tb_IndexInfo model = new tb_IndexInfo();//定义当前实体 
					if(txtId.Text.Trim()!="")	model.Id =Convert.ToInt32(txtId.Text.Trim()) ;//指标编号
					if(txtIndexName.Text.Trim()!="")  model.IndexName = txtIndexName.Text.Trim()  ;//指标名称
					if(txtClassName.Text.Trim()!="")  model.ClassName = txtClassName.Text.Trim()  ;//所属类
					if(txtPriorLevel.Text.Trim()!="")	model.PriorLevel =Convert.ToInt32(txtPriorLevel.Text.Trim()) ;//优先级
					if(combSuitableType.Text.Trim()!="") model.SuitableType = combSuitableType.Text.Trim() ;//适用类型
					if(txtUseExplain.Text.Trim()!="")  model.UseExplain = txtUseExplain.Text.Trim()  ;//使用说明
					if(txtDescription.Text.Trim()!="")  model.Description = txtDescription.Text.Trim()  ;//指标描述
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
		List <tb_IndexInfo> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = tb_IndexInfo.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				txtId.ReadOnly = false ;//指标编号
				txtId.Text = string.Empty  ; 
				txtIndexName.ReadOnly = false ;//指标名称
				txtIndexName.Text = string.Empty  ; 
				txtClassName.ReadOnly = false ;//所属类
				txtClassName.Text = string.Empty  ; 
				txtPriorLevel.ReadOnly = false ;//优先级
				txtPriorLevel.Text = string.Empty  ; 
				combSuitableType.Enabled = true ; //适用类型	
				txtUseExplain.ReadOnly = false ;//使用说明
				txtUseExplain.Text = string.Empty  ; 
				txtDescription.ReadOnly = false ;//指标描述
				txtDescription.Text = string.Empty  ; 
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
				txtId.ReadOnly = true;//指标编号txtIndexName.ReadOnly = false ;//指标名称
				txtClassName.ReadOnly = false ;//所属类
				txtPriorLevel.ReadOnly = false ;//优先级
				combSuitableType.Enabled = true ;//适用类型
				txtUseExplain.ReadOnly = false ;//使用说明
				txtDescription.ReadOnly = false ;//指标描述
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
			txtId.ReadOnly = true  ;//指标编号
			txtIndexName.ReadOnly = true  ;//指标名称
			txtClassName.ReadOnly = true  ;//所属类
			txtPriorLevel.ReadOnly = true  ;//优先级
			combSuitableType.Enabled = false ;//适用类型
			txtUseExplain.ReadOnly = true  ;//使用说明
			txtDescription.ReadOnly = true  ;//指标描述
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
			txtId.DataBindings.Clear();//指标编号
			txtId.DataBindings.Add ("Text",CutModel,"Id");
			txtIndexName.DataBindings.Clear();//指标名称
			txtIndexName.DataBindings.Add ("Text",CutModel,"IndexName");
			txtClassName.DataBindings.Clear();//所属类
			txtClassName.DataBindings.Add ("Text",CutModel,"ClassName");
			txtPriorLevel.DataBindings.Clear();//优先级
			txtPriorLevel.DataBindings.Add ("Text",CutModel,"PriorLevel");
			combSuitableType.DataBindings.Clear () ;//适用类型
			combSuitableType.DataBindings.Add ("Text",CutModel,"SuitableType") ;
			txtUseExplain.DataBindings.Clear();//使用说明
			txtUseExplain.DataBindings.Add ("Text",CutModel,"UseExplain");
			txtDescription.DataBindings.Clear();//指标描述
			txtDescription.DataBindings.Add ("Text",CutModel,"Description");
			dtUpdateTime.DataBindings.Clear () ;//更新时间
			dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}