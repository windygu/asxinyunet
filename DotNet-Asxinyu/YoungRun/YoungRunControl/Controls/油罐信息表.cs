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
	public class AddOilTankInfo: UserControl
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
		private System.Windows.Forms.TextBox txtTankId ;
		private System.Windows.Forms.Label    lblTankId ;
private System.Windows.Forms.TextBox txtHeight ;
		private System.Windows.Forms.Label    lblHeight ;
private System.Windows.Forms.TextBox txtVolume ;
		private System.Windows.Forms.Label    lblVolume ;
private System.Windows.Forms.TextBox txtPerCmVolume ;
		private System.Windows.Forms.Label    lblPerCmVolume ;

		private System.Windows.Forms.ComboBox combProductNameTP ;
		private System.Windows.Forms.Label    lblProductNameTP ;

		private System.Windows.Forms.ComboBox combStrogeType ;
		private System.Windows.Forms.Label    lblStrogeType ;
private System.Windows.Forms.TextBox txtPurpose ;
		private System.Windows.Forms.Label    lblPurpose ;
private System.Windows.Forms.TextBox txtAlarmHeight ;
		private System.Windows.Forms.Label    lblAlarmHeight ;
private System.Windows.Forms.TextBox txtD20 ;
		private System.Windows.Forms.Label    lblD20 ;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilTankInfo));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
			
			this.lblTankId = new System.Windows.Forms.Label() ;
			this.lblTankId.AutoSize = true;
			this.lblTankId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTankId.Name = "lblTankId";
			this.lblTankId.Size = new System.Drawing.Size(10,16);
			this.lblTankId.TabIndex = 200 ;
			this.lblTankId.Text = "罐号";
			this.Controls.Add(this.lblTankId) ;
		
			this.lblHeight = new System.Windows.Forms.Label() ;
			this.lblHeight.AutoSize = true;
			this.lblHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(10,16);
			this.lblHeight.TabIndex = 200 ;
			this.lblHeight.Text = "总高度";
			this.Controls.Add(this.lblHeight) ;
		
			this.lblVolume = new System.Windows.Forms.Label() ;
			this.lblVolume.AutoSize = true;
			this.lblVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblVolume.Name = "lblVolume";
			this.lblVolume.Size = new System.Drawing.Size(10,16);
			this.lblVolume.TabIndex = 200 ;
			this.lblVolume.Text = "体积";
			this.Controls.Add(this.lblVolume) ;
		
			this.lblPerCmVolume = new System.Windows.Forms.Label() ;
			this.lblPerCmVolume.AutoSize = true;
			this.lblPerCmVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblPerCmVolume.Name = "lblPerCmVolume";
			this.lblPerCmVolume.Size = new System.Drawing.Size(10,16);
			this.lblPerCmVolume.TabIndex = 200 ;
			this.lblPerCmVolume.Text = "每1cm容量";
			this.Controls.Add(this.lblPerCmVolume) ;
		
			this.lblProductNameTP = new System.Windows.Forms.Label() ;
			this.lblProductNameTP.AutoSize = true;
			this.lblProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblProductNameTP.Name = "lblProductNameTP";
			this.lblProductNameTP.Size = new System.Drawing.Size(10,16);
			this.lblProductNameTP.TabIndex = 200 ;
			this.lblProductNameTP.Text = "油品名称";
			this.Controls.Add(this.lblProductNameTP) ;
		
			this.lblStrogeType = new System.Windows.Forms.Label() ;
			this.lblStrogeType.AutoSize = true;
			this.lblStrogeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblStrogeType.Name = "lblStrogeType";
			this.lblStrogeType.Size = new System.Drawing.Size(10,16);
			this.lblStrogeType.TabIndex = 200 ;
			this.lblStrogeType.Text = "存储类型";
			this.Controls.Add(this.lblStrogeType) ;
		
			this.lblPurpose = new System.Windows.Forms.Label() ;
			this.lblPurpose.AutoSize = true;
			this.lblPurpose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblPurpose.Name = "lblPurpose";
			this.lblPurpose.Size = new System.Drawing.Size(10,16);
			this.lblPurpose.TabIndex = 200 ;
			this.lblPurpose.Text = "用途";
			this.Controls.Add(this.lblPurpose) ;
		
			this.lblAlarmHeight = new System.Windows.Forms.Label() ;
			this.lblAlarmHeight.AutoSize = true;
			this.lblAlarmHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblAlarmHeight.Name = "lblAlarmHeight";
			this.lblAlarmHeight.Size = new System.Drawing.Size(10,16);
			this.lblAlarmHeight.TabIndex = 200 ;
			this.lblAlarmHeight.Text = "警戒高度";
			this.Controls.Add(this.lblAlarmHeight) ;
		
			this.lblD20 = new System.Windows.Forms.Label() ;
			this.lblD20.AutoSize = true;
			this.lblD20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblD20.Name = "lblD20";
			this.lblD20.Size = new System.Drawing.Size(10,16);
			this.lblD20.TabIndex = 200 ;
			this.lblD20.Text = "密度";
			this.Controls.Add(this.lblD20) ;
		
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
		
			this.lblTankId.Location = new System.Drawing.Point(6, 10);	
			this.txtTankId = new System.Windows.Forms.TextBox() ;
			this.txtTankId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtTankId.Location = new System.Drawing.Point(158, 10);
			this.txtTankId.Name = "txtTankId";
			this.txtTankId.Size = new System.Drawing.Size(150,22);
			this.txtTankId.TabIndex = 0 ;
			this.Controls.Add(this.txtTankId) ;
			this.lblHeight.Location = new System.Drawing.Point(6, 37);
			this.txtHeight = new System.Windows.Forms.TextBox() ;
			this.txtHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtHeight.Location = new System.Drawing.Point(158, 37);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(150,22);
			this.txtHeight.TabIndex = 2 ;
			this.Controls.Add(this.txtHeight) ;
			this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblVolume.Location = new System.Drawing.Point(6, 64);
			this.txtVolume = new System.Windows.Forms.TextBox() ;
			this.txtVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtVolume.Location = new System.Drawing.Point(158, 64);
			this.txtVolume.Name = "txtVolume";
			this.txtVolume.Size = new System.Drawing.Size(150,22);
			this.txtVolume.TabIndex = 4 ;
			this.Controls.Add(this.txtVolume) ;
			this.txtVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblPerCmVolume.Location = new System.Drawing.Point(6, 91);
			this.txtPerCmVolume = new System.Windows.Forms.TextBox() ;
			this.txtPerCmVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtPerCmVolume.Location = new System.Drawing.Point(158, 91);
			this.txtPerCmVolume.Name = "txtPerCmVolume";
			this.txtPerCmVolume.Size = new System.Drawing.Size(150,22);
			this.txtPerCmVolume.TabIndex = 6 ;
			this.Controls.Add(this.txtPerCmVolume) ;
			this.txtPerCmVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblProductNameTP.Location = new System.Drawing.Point(6, 118);
			
			this.combProductNameTP = new System.Windows.Forms.ComboBox() ;
			this.combProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combProductNameTP.FormattingEnabled = true;
			this.combProductNameTP.Location = new System.Drawing.Point(158, 118);
			this.combProductNameTP.Name = "combProductNameTP";
			this.combProductNameTP.Size = new System.Drawing.Size(150,22);
			this.combProductNameTP.TabIndex = 8 ;
			this.Controls.Add(this.combProductNameTP) ;
			
			this.lblStrogeType.Location = new System.Drawing.Point(6, 145);
			
			this.combStrogeType = new System.Windows.Forms.ComboBox() ;
			this.combStrogeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combStrogeType.FormattingEnabled = true;
			this.combStrogeType.Location = new System.Drawing.Point(158, 145);
			this.combStrogeType.Name = "combStrogeType";
			this.combStrogeType.Size = new System.Drawing.Size(150,22);
			this.combStrogeType.TabIndex = 10 ;
			this.Controls.Add(this.combStrogeType) ;
			
			this.lblPurpose.Location = new System.Drawing.Point(6, 172);	
			this.txtPurpose = new System.Windows.Forms.TextBox() ;
			this.txtPurpose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtPurpose.Location = new System.Drawing.Point(158, 172);
			this.txtPurpose.Name = "txtPurpose";
			this.txtPurpose.Size = new System.Drawing.Size(150,22);
			this.txtPurpose.TabIndex = 12 ;
			this.Controls.Add(this.txtPurpose) ;
			this.lblAlarmHeight.Location = new System.Drawing.Point(6, 199);
			this.txtAlarmHeight = new System.Windows.Forms.TextBox() ;
			this.txtAlarmHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtAlarmHeight.Location = new System.Drawing.Point(158, 199);
			this.txtAlarmHeight.Name = "txtAlarmHeight";
			this.txtAlarmHeight.Size = new System.Drawing.Size(150,22);
			this.txtAlarmHeight.TabIndex = 14 ;
			this.Controls.Add(this.txtAlarmHeight) ;
			this.txtAlarmHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
			this.lblD20.Location = new System.Drawing.Point(6, 226);
			this.txtD20 = new System.Windows.Forms.TextBox() ;
			this.txtD20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtD20.Location = new System.Drawing.Point(158, 226);
			this.txtD20.Name = "txtD20";
			this.txtD20.Size = new System.Drawing.Size(150,22);
			this.txtD20.TabIndex = 16 ;
			this.Controls.Add(this.txtD20) ;
			this.txtD20.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			
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
			this.Name = "AddOilTankInfo";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.AddAddOilTankInfoLoad);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public AddOilTankInfo()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddOilTankInfoLoad(object sender, EventArgs e){}
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
				FormPager.RecordCount = tb_OilTankInfo.FindCount(CutSearchCondition,"","",0,0) ;
			}
		}
		/// <summary>
		/// 获取或者设置当前实体
		/// </summary>
		public tb_OilTankInfo CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{
			if(txtTankId.Text.Trim()=="")//罐号
			{
				errorProvider1.SetError(txtTankId,"必填项目");
				return false ;
			}
			if(txtHeight.Text.Trim()=="")//总高度
			{
				errorProvider1.SetError(txtHeight,"必填项目");
				return false ;
			}
			if(txtVolume.Text.Trim()=="")//体积
			{
				errorProvider1.SetError(txtVolume,"必填项目");
				return false ;
			}
			if(txtPerCmVolume.Text.Trim()=="")//每1cm容量
			{
				errorProvider1.SetError(txtPerCmVolume,"必填项目");
				return false ;
			}
			if(combProductNameTP.Text.Trim()=="")//油品名称
			{
				errorProvider1.SetError(combProductNameTP,"必填项目");
				return false ;
			} 
			if(combStrogeType.Text.Trim()=="")//存储类型
			{
				errorProvider1.SetError(combStrogeType,"必填项目");
				return false ;
			} 
			if(txtAlarmHeight.Text.Trim()=="")//警戒高度
			{
				errorProvider1.SetError(txtAlarmHeight,"必填项目");
				return false ;
			}
			if(txtD20.Text.Trim()=="")//密度
			{
				errorProvider1.SetError(txtD20,"必填项目");
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
					tb_OilTankInfo model = new tb_OilTankInfo();//定义当前实体 
					if(txtTankId.Text.Trim()!="")  model.TankId = txtTankId.Text.Trim()  ;//罐号
					if(txtHeight.Text.Trim()!="")	model.Height =Convert.ToDouble(txtHeight.Text.Trim()) ;//总高度
					if(txtVolume.Text.Trim()!="")	model.Volume =Convert.ToDouble(txtVolume.Text.Trim()) ;//体积
					if(txtPerCmVolume.Text.Trim()!="")	model.PerCmVolume =Convert.ToDouble(txtPerCmVolume.Text.Trim()) ;//每1cm容量
					if(combProductNameTP.Text.Trim()!="") model.ProductNameTP = combProductNameTP.Text.Trim() ;//油品名称
					if(combStrogeType.Text.Trim()!="") model.StrogeType = combStrogeType.Text.Trim() ;//存储类型
					if(txtPurpose.Text.Trim()!="")  model.Purpose = txtPurpose.Text.Trim()  ;//用途
					if(txtAlarmHeight.Text.Trim()!="")	model.AlarmHeight =Convert.ToDouble(txtAlarmHeight.Text.Trim()) ;//警戒高度
					if(txtD20.Text.Trim()!="")	model.D20 =Convert.ToDouble(txtD20.Text.Trim()) ;//密度
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
		List <tb_OilTankInfo> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = tb_OilTankInfo.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				txtTankId.ReadOnly = false ;//罐号
				txtTankId.Text = string.Empty  ; 
				txtHeight.ReadOnly = false ;//总高度
				txtHeight.Text = string.Empty  ; 
				txtVolume.ReadOnly = false ;//体积
				txtVolume.Text = string.Empty  ; 
				txtPerCmVolume.ReadOnly = false ;//每1cm容量
				txtPerCmVolume.Text = string.Empty  ; 
				combProductNameTP.Enabled = true ; //油品名称	
				combStrogeType.Enabled = true ; //存储类型	
				txtPurpose.ReadOnly = false ;//用途
				txtPurpose.Text = string.Empty  ; 
				txtAlarmHeight.ReadOnly = false ;//警戒高度
				txtAlarmHeight.Text = string.Empty  ; 
				txtD20.ReadOnly = false ;//密度
				txtD20.Text = string.Empty  ; 
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
				txtTankId.ReadOnly = true;//罐号txtHeight.ReadOnly = false ;//总高度
				txtVolume.ReadOnly = false ;//体积
				txtPerCmVolume.ReadOnly = false ;//每1cm容量
				combProductNameTP.Enabled = true ;//油品名称
				combStrogeType.Enabled = true ;//存储类型
				txtPurpose.ReadOnly = false ;//用途
				txtAlarmHeight.ReadOnly = false ;//警戒高度
				txtD20.ReadOnly = false ;//密度
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
			txtTankId.ReadOnly = true  ;//罐号
			txtHeight.ReadOnly = true  ;//总高度
			txtVolume.ReadOnly = true  ;//体积
			txtPerCmVolume.ReadOnly = true  ;//每1cm容量
			combProductNameTP.Enabled = false ;//油品名称
			combStrogeType.Enabled = false ;//存储类型
			txtPurpose.ReadOnly = true  ;//用途
			txtAlarmHeight.ReadOnly = true  ;//警戒高度
			txtD20.ReadOnly = true  ;//密度
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
			txtTankId.DataBindings.Clear();//罐号
			txtTankId.DataBindings.Add ("Text",CutModel,"TankId");
			txtHeight.DataBindings.Clear();//总高度
			txtHeight.DataBindings.Add ("Text",CutModel,"Height");
			txtVolume.DataBindings.Clear();//体积
			txtVolume.DataBindings.Add ("Text",CutModel,"Volume");
			txtPerCmVolume.DataBindings.Clear();//每1cm容量
			txtPerCmVolume.DataBindings.Add ("Text",CutModel,"PerCmVolume");
			combProductNameTP.DataBindings.Clear () ;//油品名称
			combProductNameTP.DataBindings.Add ("Text",CutModel,"ProductNameTP") ;
			combStrogeType.DataBindings.Clear () ;//存储类型
			combStrogeType.DataBindings.Add ("Text",CutModel,"StrogeType") ;
			txtPurpose.DataBindings.Clear();//用途
			txtPurpose.DataBindings.Add ("Text",CutModel,"Purpose");
			txtAlarmHeight.DataBindings.Clear();//警戒高度
			txtAlarmHeight.DataBindings.Add ("Text",CutModel,"AlarmHeight");
			txtD20.DataBindings.Clear();//密度
			txtD20.DataBindings.Add ("Text",CutModel,"D20");
			dtUpdateTime.DataBindings.Clear () ;//更新时间
			dtUpdateTime.DataBindings.Add ("Value",CutModel,"UpdateTime") ;
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}