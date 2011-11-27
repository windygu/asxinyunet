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

namespace <#=Config.NameSpace#>
{	<# string className ="Add"+ Table.Alias.Replace ("tb_","")[0].ToString().ToUpper()+Table.Alias.Replace ("tb_","").Substring (1); #>
	public class <#=className#>: UserControl,IEntityControl 
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
		<# foreach(IDataColumn Field in Table.Columns){
		if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
		private System.Windows.Forms.ComboBox comb<#=Field.Alias#> ;
		<#}else if (Field.DataType == typeof(string)) {#>private System.Windows.Forms.TextBox txt<#=Field.Alias#> ;
		<#}else if (Field.DataType == typeof(DateTime)) {#>private System.Windows.Forms.DateTimePicker dt<#=Field.Alias#> ;
		<#}else {#>private System.Windows.Forms.TextBox txt<#=Field.Alias#> ;
		<#}#>private System.Windows.Forms.Label    lbl<#=Field.Alias#> ;
<#}#>   private System.Windows.Forms.ErrorProvider errorProvider1 ;
		private System.Windows.Forms.Button btnOK ;
		private System.Windows.Forms.Button btnCancle ;
		private DotNet.Tools.Controls.EntityFormPager FormPager;
		#endregion
		
		#region 组件设计器生成的代码
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(<#=className#>));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
			<# int cutX = 6 ;int cutY = 10 ;int W = 150 ;int H = 22 ;int lblW = 10 ;int lblH = 16 ;	int index = 0 ;
			foreach(IDataColumn Field in Table.Columns)	{#>
			this.lbl<#=Field.Alias#> = new System.Windows.Forms.Label() ;
			this.lbl<#=Field.Alias#>.AutoSize = true;
			this.lbl<#=Field.Alias#>.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lbl<#=Field.Alias#>.Name = "lbl<#=Field.Alias#>";
			this.lbl<#=Field.Alias#>.Size = new System.Drawing.Size(<#=lblW#>,<#=lblH#>);
			this.lbl<#=Field.Alias#>.TabIndex = <#=index + 200 #> ;
			this.lbl<#=Field.Alias#>.Text = "<#=Field.Description#>";
			this.Controls.Add(this.lbl<#=Field.Alias#>) ;
		<#}#><#foreach(IDataColumn Field in Table.Columns){
		if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
			this.lbl<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			<#cutX += (W+2) ;#>
			this.comb<#=Field.Alias#> = new System.Windows.Forms.ComboBox() ;
			this.comb<#=Field.Alias#>.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.comb<#=Field.Alias#>.FormattingEnabled = true;
			this.comb<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.comb<#=Field.Alias#>.Name = "comb<#=Field.Alias#>";
			this.comb<#=Field.Alias#>.Size = new System.Drawing.Size(<#=W#>,<#=H#>);
			this.comb<#=Field.Alias#>.TabIndex = <#=index#> ;
			this.Controls.Add(this.comb<#=Field.Alias#>) ;
			<#index += 2 ;cutX -= (W+2) ;cutY += (H+5) ;}
		else if (Field.DataType == typeof(string )){#>
			this.lbl<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);	<#cutX += (W+2) ;#>
			this.txt<#=Field.Alias#> = new System.Windows.Forms.TextBox() ;
			this.txt<#=Field.Alias#>.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txt<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.txt<#=Field.Alias#>.Name = "txt<#=Field.Alias#>";
			this.txt<#=Field.Alias#>.Size = new System.Drawing.Size(<#=W#>,<#=H#>);
			this.txt<#=Field.Alias#>.TabIndex = <#=index#> ;
			this.Controls.Add(this.txt<#=Field.Alias#>) ;<# index += 2 ;cutX -= (W+2) ;cutY += (H+5) ;}
		else if (Field.DataType == typeof(DateTime)){#>
			this.lbl<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);	<#cutX += (W+2);#>
			this.dt<#=Field.Alias#> = new System.Windows.Forms.DateTimePicker() ;
			this.dt<#=Field.Alias#>.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dt<#=Field.Alias#>.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dt<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.dt<#=Field.Alias#>.Name = "dt<#=Field.Alias#>";
			this.dt<#=Field.Alias#>.Size = new System.Drawing.Size(<#=W#>,<#=H#>);
			this.dt<#=Field.Alias#>.TabIndex = <#=index#> ;
			this.Controls.Add(this.dt<#=Field.Alias#>) ;<# index += 2 ;	cutX -= (W+2) ;cutY += (H+5);}else{#>
			this.lbl<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);<#cutX += (W+2) ;#>
			this.txt<#=Field.Alias#> = new System.Windows.Forms.TextBox() ;
			this.txt<#=Field.Alias#>.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txt<#=Field.Alias#>.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.txt<#=Field.Alias#>.Name = "txt<#=Field.Alias#>";
			this.txt<#=Field.Alias#>.Size = new System.Drawing.Size(<#=W#>,<#=H#>);
			this.txt<#=Field.Alias#>.TabIndex = <#=index#> ;
			this.Controls.Add(this.txt<#=Field.Alias#>) ;
			this.txt<#=Field.Alias#>.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
			<# index += 2 ;	cutX -= (W+2) ;cutY += (H+5) ;}}cutX += 20 ;cutY += 20 ;#>
			#region 添加按钮
			this.btnOK = new System.Windows.Forms.Button();
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = <#=index#>;<#index += 2 ;#>
			this.btnOK.Text = "保存";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Controls.Add(this.btnOK);<#cutX += 80;#>
			this.btnCancle = new System.Windows.Forms.Button();
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(<#=cutX#>, <#=cutY#>);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = <#=index#>;<#index += 2 ;#>
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
			this.FormPager.Location = new System.Drawing.Point(10, <#=cutY + 30#>);
			this.FormPager.Name = "FormPager";
			this.FormPager.RecordCount = 0;
			this.FormPager.Size = new System.Drawing.Size(256, 29);
			this.FormPager.TabIndex = 100;
			this.Controls.Add(this.FormPager);
			this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
			#endregion
			#region 窗体
			this.Name = "Add<#=Table.Alias.Replace ("tb_","")[0].ToString().ToUpper()+Table.Alias.Replace ("tb_","").Substring (1)#>";
			this.Size = new System.Drawing.Size(350, 500);
			this.Load += new System.EventHandler(this.Add<#=className#>Load);
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			#endregion
		}
		#endregion
		#endregion
	
		#region 构造函数 及初始化
		public <#=className#>()	{InitializeComponent(); CustomerSettings(); }	
		//控件加载事件,完成数据绑定和相关基本设置
		void Add<#=className#>Load(object sender, EventArgs e){}
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
		public <#=Table.Alias#> CutModel{get ;set ;}
		/// <summary>
		/// 当前实体窗体的显示模式,默认为连续显示
		/// </summary>
		public FormShowMode CutShowMode{get ;set ;}
		#endregion

		#region 验证事件
		bool ValidateControls()
		{<# foreach(IDataColumn Field in Table.Columns){if(!Field.Nullable && Field.DataType != typeof(DateTime)){if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
			if(comb<#=Field.Alias#>.Text.Trim()=="")//<#=Field.Description#>
			{
				errorProvider1.SetError(comb<#=Field.Alias#>,"必填项目");
				return false ;
			} <#}else{#>
			if(txt<#=Field.Alias#>.Text.Trim()=="")//<#=Field.Description#>
			{
				errorProvider1.SetError(txt<#=Field.Alias#>,"必填项目");
				return false ;
			}<#}}}#>
			return true ;
		}
		#endregion

		#region 按钮事件
		void btnOK_Click(object sender, EventArgs e)
		{
			//TODO:有问题，需要根据当前的状态来更新和保存数据
			//当前实体状态不是只读并且通过验证后才能进行操作
			//当comb类别为int时，有bug,需要手动修改加一下数据转换
			if (btnOK.Text.Contains ("修改")) SetAllTextControls(ControlStatus.Edit );
			else 
			{
				if(((CutShowMode!= FormShowMode.ReadOnlyForAll) || (CutShowMode != FormShowMode.ReadOnlyForOne)) && ValidateControls() )
				{
					<#=Table.Alias#> model = new <#=Table.Alias#>();//定义当前实体 <# foreach(IDataColumn Field in Table.Columns){if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
					if(comb<#=Field.Alias#>.Text.Trim()!="") model.<#=Field.Alias#> = comb<#=Field.Alias#>.Text.Trim() ;//<#=Field.Description#><#}else if (Field.DataType == typeof(string)) {#>
					if(txt<#=Field.Alias#>.Text.Trim()!="")  model.<#=Field.Alias#> = txt<#=Field.Alias#>.Text.Trim()  ;//<#=Field.Description#><#}else if (Field.DataType == typeof(DateTime)) {#>
					model.<#=Field.Alias#> = dt<#=Field.Alias#>.Value ;//<#=Field.Description#><#}else {#>
					if(txt<#=Field.Alias#>.Text.Trim()!="")	model.<#=Field.Alias#> =Convert.To<#=Field.DataType.ToString().Replace("System.","")#>(txt<#=Field.Alias#>.Text.Trim()) ;//<#=Field.Description#><#}}#>
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
		List <<#=Table.Alias#>> modelList ;//当前实体列表
		void GetData()
		{				
			//判断不为空，才能绑定				
			modelList = <#=Table.Alias#>.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
				<# foreach(IDataColumn Field in Table.Columns){if(Field.DataType != typeof(DateTime)){if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>comb<#=Field.Alias#>.Enabled = true ; //<#=Field.Description#>	
				<#}else{#>txt<#=Field.Alias#>.ReadOnly = false ;//<#=Field.Description#>
				txt<#=Field.Alias#>.Text = string.Empty  ; 
				<#}}}#>}
		}
		private void SetControlEdit()
		{
			if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
				btnOK .Enabled = true ;
				btnOK.Text =" 保存";
				//控件除主键外都可读<#foreach(IDataColumn Field in Table.Columns) {if(Field.PrimaryKey) {if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
				comb<#=Field.Alias#>.Enabled = false;//<#=Field.Description#><#}else{#>
				txt<#=Field.Alias#>.ReadOnly = true;//<#=Field.Description#><#}continue;}
				TypeCode code = Type.GetTypeCode(Field.DataType);#><#if(code == TypeCode.DateTime){#>dt<#=Field.Alias#>.Enabled = true ;//<#=Field.Description#>
				<#}else if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>comb<#=Field.Alias#>.Enabled = true ;//<#=Field.Description#>
				<#} else {#>txt<#=Field.Alias#>.ReadOnly = false ;//<#=Field.Description#>
				<#}}#>}
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
			}<# foreach(IDataColumn Field in Table.Columns){if(Field.DataType != typeof(DateTime)){if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>
			comb<#=Field.Alias#>.Enabled = false ;//<#=Field.Description#><#}else{#>
			txt<#=Field.Alias#>.ReadOnly = true  ;//<#=Field.Description#><#}} else {#>
			dt<#=Field.Alias#>.Enabled = false   ;//<#=Field.Description#><#}}#>
		}
		#endregion

		#region 绑定数据
		 /// <summary>
		/// 加载子窗口:if(Field.PrimaryKey) continue;
		/// </summary>
		private void BandingData()
		{<#foreach(IDataColumn Field in Table.Columns) {TypeCode code = Type.GetTypeCode(Field.DataType);#>
			<#if(code == TypeCode.DateTime){#>dt<#=Field.Alias#>.DataBindings.Clear () ;//<#=Field.Description#>
			dt<#=Field.Alias#>.DataBindings.Add ("Value",CutModel,"<#=Field.Alias#>") ;<#}else if((Field.Alias.Contains("Type"))||(Field.Alias.Contains("TP"))){#>comb<#=Field.Alias#>.DataBindings.Clear () ;//<#=Field.Description#>
			comb<#=Field.Alias#>.DataBindings.Add ("Text",CutModel,"<#=Field.Alias#>") ;<#} else {#>txt<#=Field.Alias#>.DataBindings.Clear();//<#=Field.Description#>
			txt<#=Field.Alias#>.DataBindings.Add ("Text",CutModel,"<#=Field.Alias#>");<#}}#>
		}
		#endregion
   }
}