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
	public class AddUser: UserControl
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
		private System.Windows.Forms.TextBox txtUserName ;
		private System.Windows.Forms.Label    lblUserName ;
private System.Windows.Forms.TextBox txtPassWord ;
		private System.Windows.Forms.Label    lblPassWord ;
private System.Windows.Forms.TextBox txtDepartMent ;
		private System.Windows.Forms.Label    lblDepartMent ;
private System.Windows.Forms.TextBox txtName ;
		private System.Windows.Forms.Label    lblName ;
private System.Windows.Forms.TextBox txtTel ;
		private System.Windows.Forms.Label    lblTel ;
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.lblDepartMent = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtDepartMent = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
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
            this.FormPager.Location = new System.Drawing.Point(10, 222);
            this.FormPager.Name = "FormPager";
            this.FormPager.RecordCount = 0;
            this.FormPager.Size = new System.Drawing.Size(238, 29);
            this.FormPager.TabIndex = 100;
            this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(6, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(49, 14);
            this.lblUserName.TabIndex = 200;
            this.lblUserName.Text = "用户名";
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassWord.Location = new System.Drawing.Point(6, 37);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(35, 14);
            this.lblPassWord.TabIndex = 200;
            this.lblPassWord.Text = "密码";
            // 
            // lblDepartMent
            // 
            this.lblDepartMent.AutoSize = true;
            this.lblDepartMent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepartMent.Location = new System.Drawing.Point(6, 64);
            this.lblDepartMent.Name = "lblDepartMent";
            this.lblDepartMent.Size = new System.Drawing.Size(35, 14);
            this.lblDepartMent.TabIndex = 200;
            this.lblDepartMent.Text = "部门";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(6, 91);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 14);
            this.lblName.TabIndex = 200;
            this.lblName.Text = "姓名";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTel.Location = new System.Drawing.Point(6, 118);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(63, 14);
            this.lblTel.TabIndex = 200;
            this.lblTel.Text = "联系电话";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(6, 145);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(35, 14);
            this.lblRemark.TabIndex = 200;
            this.lblRemark.Text = "备注";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(158, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.Location = new System.Drawing.Point(158, 37);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(150, 23);
            this.txtPassWord.TabIndex = 2;
            // 
            // txtDepartMent
            // 
            this.txtDepartMent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDepartMent.Location = new System.Drawing.Point(158, 64);
            this.txtDepartMent.Name = "txtDepartMent";
            this.txtDepartMent.Size = new System.Drawing.Size(150, 23);
            this.txtDepartMent.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(158, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 23);
            this.txtName.TabIndex = 6;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(158, 118);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(150, 23);
            this.txtTel.TabIndex = 8;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(158, 145);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 23);
            this.txtRemark.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(26, 192);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 27);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(106, 192);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(78, 27);
            this.btnCancle.TabIndex = 14;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.lblDepartMent);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtDepartMent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.FormPager);
            this.Name = "AddUser";
            this.Size = new System.Drawing.Size(350, 500);
            this.Load += new System.EventHandler(this.AddAddUserLoad);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public AddUser()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void AddAddUserLoad(object sender, EventArgs e){}
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
				FormPager.RecordCount = tb_User.FindCount(CutSearchCondition,"","",0,0) ;
			}
		}
		/// <summary>
		/// 获取或者设置当前实体
		/// </summary>
		public tb_User CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{
			if(txtUserName.Text.Trim()=="")//用户名
			{
				errorProvider1.SetError(txtUserName,"必填项目");
				return false ;
			}
			if(txtPassWord.Text.Trim()=="")//密码
			{
				errorProvider1.SetError(txtPassWord,"必填项目");
				return false ;
			}
			if(txtDepartMent.Text.Trim()=="")//部门
			{
				errorProvider1.SetError(txtDepartMent,"必填项目");
				return false ;
			}
			if(txtName.Text.Trim()=="")//姓名
			{
				errorProvider1.SetError(txtName,"必填项目");
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
					tb_User model = new tb_User();//定义当前实体 
					if(txtUserName.Text.Trim()!="")  model.UserName = txtUserName.Text.Trim()  ;//用户名
					if(txtPassWord.Text.Trim()!="")  model.PassWord = txtPassWord.Text.Trim()  ;//密码
					if(txtDepartMent.Text.Trim()!="")  model.DepartMent = txtDepartMent.Text.Trim()  ;//部门
					if(txtName.Text.Trim()!="")  model.Name = txtName.Text.Trim()  ;//姓名
					if(txtTel.Text.Trim()!="")  model.Tel = txtTel.Text.Trim()  ;//联系电话
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
		List <tb_User> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = tb_User.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				txtUserName.ReadOnly = false ;//用户名
				txtUserName.Text = string.Empty  ; 
				txtPassWord.ReadOnly = false ;//密码
				txtPassWord.Text = string.Empty  ; 
				txtDepartMent.ReadOnly = false ;//部门
				txtDepartMent.Text = string.Empty  ; 
				txtName.ReadOnly = false ;//姓名
				txtName.Text = string.Empty  ; 
				txtTel.ReadOnly = false ;//联系电话
				txtTel.Text = string.Empty  ; 
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
				txtUserName.ReadOnly = true;//用户名txtPassWord.ReadOnly = false ;//密码
				txtDepartMent.ReadOnly = false ;//部门
				txtName.ReadOnly = false ;//姓名
				txtTel.ReadOnly = false ;//联系电话
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
			txtUserName.ReadOnly = true  ;//用户名
			txtPassWord.ReadOnly = true  ;//密码
			txtDepartMent.ReadOnly = true  ;//部门
			txtName.ReadOnly = true  ;//姓名
			txtTel.ReadOnly = true  ;//联系电话
			txtRemark.ReadOnly = true  ;//备注
		}
		#endregion

		#region 绑定数据
		 /// <summary>
		/// 加载子窗口:if(Field.PrimaryKey) continue;
		/// </summary>
		private void BandingData()
		{
			txtUserName.DataBindings.Clear();//用户名
			txtUserName.DataBindings.Add ("Text",CutModel,"UserName");
			txtPassWord.DataBindings.Clear();//密码
			txtPassWord.DataBindings.Add ("Text",CutModel,"PassWord");
			txtDepartMent.DataBindings.Clear();//部门
			txtDepartMent.DataBindings.Add ("Text",CutModel,"DepartMent");
			txtName.DataBindings.Clear();//姓名
			txtName.DataBindings.Add ("Text",CutModel,"Name");
			txtTel.DataBindings.Clear();//联系电话
			txtTel.DataBindings.Add ("Text",CutModel,"Tel");
			txtRemark.DataBindings.Clear();//备注
			txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
		}
		#endregion
   }
}