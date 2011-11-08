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

		
			public class AddOilData: UserControl
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
				
						private System.Windows.Forms.ComboBox combOilNameTP ;
					private System.Windows.Forms.Label    lblOilNameTP ;
				private System.Windows.Forms.TextBox txtV40 ;
					private System.Windows.Forms.Label    lblV40 ;
				private System.Windows.Forms.TextBox txtV100 ;
					private System.Windows.Forms.Label    lblV100 ;
				private System.Windows.Forms.TextBox txtVI ;
					private System.Windows.Forms.Label    lblVI ;
				private System.Windows.Forms.TextBox txtPP ;
					private System.Windows.Forms.Label    lblPP ;
				private System.Windows.Forms.TextBox txtFP ;
					private System.Windows.Forms.Label    lblFP ;
				private System.Windows.Forms.TextBox txtAV ;
					private System.Windows.Forms.Label    lblAV ;
				private System.Windows.Forms.TextBox txtWC ;
					private System.Windows.Forms.Label    lblWC ;
				private System.Windows.Forms.TextBox txtASTM ;
					private System.Windows.Forms.Label    lblASTM ;
				private System.Windows.Forms.TextBox txtD20 ;
					private System.Windows.Forms.Label    lblD20 ;
				private System.Windows.Forms.TextBox txtMI ;
					private System.Windows.Forms.Label    lblMI ;
				private System.Windows.Forms.TextBox txtCR ;
					private System.Windows.Forms.Label    lblCR ;
				private System.Windows.Forms.TextBox txtWAA ;
					private System.Windows.Forms.Label    lblWAA ;
				private System.Windows.Forms.TextBox txtV ;
					private System.Windows.Forms.Label    lblV ;
				private System.Windows.Forms.TextBox txtDistillation ;
					private System.Windows.Forms.Label    lblDistillation ;
				private System.Windows.Forms.TextBox txtXZQD ;
					private System.Windows.Forms.Label    lblXZQD ;
				private System.Windows.Forms.TextBox txtOther ;
					private System.Windows.Forms.Label    lblOther ;
				
						private System.Windows.Forms.ComboBox combTestPersonTP ;
					private System.Windows.Forms.Label    lblTestPersonTP ;
				
						private System.Windows.Forms.ComboBox combRecordType ;
					private System.Windows.Forms.Label    lblRecordType ;
				private System.Windows.Forms.DateTimePicker dtTestDateTime ;
					private System.Windows.Forms.Label    lblTestDateTime ;
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
					System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilData));
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
					
						this.lblOilNameTP = new System.Windows.Forms.Label() ;
						this.lblOilNameTP.AutoSize = true;
						this.lblOilNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblOilNameTP.Name = "lblOilNameTP";
						this.lblOilNameTP.Size = new System.Drawing.Size(10,16);
						this.lblOilNameTP.TabIndex = 200 ;
						this.lblOilNameTP.Text = "油品名称";
						this.Controls.Add(this.lblOilNameTP) ;
					
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
					
						this.lblPP = new System.Windows.Forms.Label() ;
						this.lblPP.AutoSize = true;
						this.lblPP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblPP.Name = "lblPP";
						this.lblPP.Size = new System.Drawing.Size(10,16);
						this.lblPP.TabIndex = 200 ;
						this.lblPP.Text = "倾点";
						this.Controls.Add(this.lblPP) ;
					
						this.lblFP = new System.Windows.Forms.Label() ;
						this.lblFP.AutoSize = true;
						this.lblFP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblFP.Name = "lblFP";
						this.lblFP.Size = new System.Drawing.Size(10,16);
						this.lblFP.TabIndex = 200 ;
						this.lblFP.Text = "闪点";
						this.Controls.Add(this.lblFP) ;
					
						this.lblAV = new System.Windows.Forms.Label() ;
						this.lblAV.AutoSize = true;
						this.lblAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblAV.Name = "lblAV";
						this.lblAV.Size = new System.Drawing.Size(10,16);
						this.lblAV.TabIndex = 200 ;
						this.lblAV.Text = "酸值";
						this.Controls.Add(this.lblAV) ;
					
						this.lblWC = new System.Windows.Forms.Label() ;
						this.lblWC.AutoSize = true;
						this.lblWC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblWC.Name = "lblWC";
						this.lblWC.Size = new System.Drawing.Size(10,16);
						this.lblWC.TabIndex = 200 ;
						this.lblWC.Text = "水分";
						this.Controls.Add(this.lblWC) ;
					
						this.lblASTM = new System.Windows.Forms.Label() ;
						this.lblASTM.AutoSize = true;
						this.lblASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblASTM.Name = "lblASTM";
						this.lblASTM.Size = new System.Drawing.Size(10,16);
						this.lblASTM.TabIndex = 200 ;
						this.lblASTM.Text = "色度";
						this.Controls.Add(this.lblASTM) ;
					
						this.lblD20 = new System.Windows.Forms.Label() ;
						this.lblD20.AutoSize = true;
						this.lblD20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblD20.Name = "lblD20";
						this.lblD20.Size = new System.Drawing.Size(10,16);
						this.lblD20.TabIndex = 200 ;
						this.lblD20.Text = "密度";
						this.Controls.Add(this.lblD20) ;
					
						this.lblMI = new System.Windows.Forms.Label() ;
						this.lblMI.AutoSize = true;
						this.lblMI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblMI.Name = "lblMI";
						this.lblMI.Size = new System.Drawing.Size(10,16);
						this.lblMI.TabIndex = 200 ;
						this.lblMI.Text = "机械杂质";
						this.Controls.Add(this.lblMI) ;
					
						this.lblCR = new System.Windows.Forms.Label() ;
						this.lblCR.AutoSize = true;
						this.lblCR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblCR.Name = "lblCR";
						this.lblCR.Size = new System.Drawing.Size(10,16);
						this.lblCR.TabIndex = 200 ;
						this.lblCR.Text = "残炭";
						this.Controls.Add(this.lblCR) ;
					
						this.lblWAA = new System.Windows.Forms.Label() ;
						this.lblWAA.AutoSize = true;
						this.lblWAA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblWAA.Name = "lblWAA";
						this.lblWAA.Size = new System.Drawing.Size(10,16);
						this.lblWAA.TabIndex = 200 ;
						this.lblWAA.Text = "水溶性酸碱";
						this.Controls.Add(this.lblWAA) ;
					
						this.lblV = new System.Windows.Forms.Label() ;
						this.lblV.AutoSize = true;
						this.lblV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblV.Name = "lblV";
						this.lblV.Size = new System.Drawing.Size(10,16);
						this.lblV.TabIndex = 200 ;
						this.lblV.Text = "低温运动粘度";
						this.Controls.Add(this.lblV) ;
					
						this.lblDistillation = new System.Windows.Forms.Label() ;
						this.lblDistillation.AutoSize = true;
						this.lblDistillation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblDistillation.Name = "lblDistillation";
						this.lblDistillation.Size = new System.Drawing.Size(10,16);
						this.lblDistillation.TabIndex = 200 ;
						this.lblDistillation.Text = "馏程";
						this.Controls.Add(this.lblDistillation) ;
					
						this.lblXZQD = new System.Windows.Forms.Label() ;
						this.lblXZQD.AutoSize = true;
						this.lblXZQD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblXZQD.Name = "lblXZQD";
						this.lblXZQD.Size = new System.Drawing.Size(10,16);
						this.lblXZQD.TabIndex = 200 ;
						this.lblXZQD.Text = "旋转氧弹";
						this.Controls.Add(this.lblXZQD) ;
					
						this.lblOther = new System.Windows.Forms.Label() ;
						this.lblOther.AutoSize = true;
						this.lblOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblOther.Name = "lblOther";
						this.lblOther.Size = new System.Drawing.Size(10,16);
						this.lblOther.TabIndex = 200 ;
						this.lblOther.Text = "其他指标";
						this.Controls.Add(this.lblOther) ;
					
						this.lblTestPersonTP = new System.Windows.Forms.Label() ;
						this.lblTestPersonTP.AutoSize = true;
						this.lblTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestPersonTP.Name = "lblTestPersonTP";
						this.lblTestPersonTP.Size = new System.Drawing.Size(10,16);
						this.lblTestPersonTP.TabIndex = 200 ;
						this.lblTestPersonTP.Text = "检测人";
						this.Controls.Add(this.lblTestPersonTP) ;
					
						this.lblRecordType = new System.Windows.Forms.Label() ;
						this.lblRecordType.AutoSize = true;
						this.lblRecordType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblRecordType.Name = "lblRecordType";
						this.lblRecordType.Size = new System.Drawing.Size(10,16);
						this.lblRecordType.TabIndex = 200 ;
						this.lblRecordType.Text = "记录类型";
						this.Controls.Add(this.lblRecordType) ;
					
						this.lblTestDateTime = new System.Windows.Forms.Label() ;
						this.lblTestDateTime.AutoSize = true;
						this.lblTestDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.lblTestDateTime.Name = "lblTestDateTime";
						this.lblTestDateTime.Size = new System.Drawing.Size(10,16);
						this.lblTestDateTime.TabIndex = 200 ;
						this.lblTestDateTime.Text = "测试时间";
						this.Controls.Add(this.lblTestDateTime) ;
					
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
						
						this.lblOilNameTP.Location = new System.Drawing.Point(6, 37);
						
						this.combOilNameTP = new System.Windows.Forms.ComboBox() ;
						this.combOilNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combOilNameTP.FormattingEnabled = true;
						this.combOilNameTP.Location = new System.Drawing.Point(158, 37);
						this.combOilNameTP.Name = "combOilNameTP";
						this.combOilNameTP.Size = new System.Drawing.Size(150,22);
						this.combOilNameTP.TabIndex = 2 ;
						this.Controls.Add(this.combOilNameTP) ;
						
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
						
						this.lblPP.Location = new System.Drawing.Point(6, 145);
						
						this.txtPP = new System.Windows.Forms.TextBox() ;
						this.txtPP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtPP.Location = new System.Drawing.Point(158, 145);
						this.txtPP.Name = "txtPP";
						this.txtPP.Size = new System.Drawing.Size(150,22);
						this.txtPP.TabIndex = 10 ;
						this.Controls.Add(this.txtPP) ;
						this.txtPP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblFP.Location = new System.Drawing.Point(6, 172);
						
						this.txtFP = new System.Windows.Forms.TextBox() ;
						this.txtFP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtFP.Location = new System.Drawing.Point(158, 172);
						this.txtFP.Name = "txtFP";
						this.txtFP.Size = new System.Drawing.Size(150,22);
						this.txtFP.TabIndex = 12 ;
						this.Controls.Add(this.txtFP) ;
						this.txtFP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblAV.Location = new System.Drawing.Point(6, 199);
						
						this.txtAV = new System.Windows.Forms.TextBox() ;
						this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtAV.Location = new System.Drawing.Point(158, 199);
						this.txtAV.Name = "txtAV";
						this.txtAV.Size = new System.Drawing.Size(150,22);
						this.txtAV.TabIndex = 14 ;
						this.Controls.Add(this.txtAV) ;
						this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblWC.Location = new System.Drawing.Point(6, 226);
						
						this.txtWC = new System.Windows.Forms.TextBox() ;
						this.txtWC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtWC.Location = new System.Drawing.Point(158, 226);
						this.txtWC.Name = "txtWC";
						this.txtWC.Size = new System.Drawing.Size(150,22);
						this.txtWC.TabIndex = 16 ;
						this.Controls.Add(this.txtWC) ;
						this.txtWC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblASTM.Location = new System.Drawing.Point(6, 253);
						
						this.txtASTM = new System.Windows.Forms.TextBox() ;
						this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtASTM.Location = new System.Drawing.Point(158, 253);
						this.txtASTM.Name = "txtASTM";
						this.txtASTM.Size = new System.Drawing.Size(150,22);
						this.txtASTM.TabIndex = 18 ;
						this.Controls.Add(this.txtASTM) ;
						
						this.lblD20.Location = new System.Drawing.Point(6, 280);
						
						this.txtD20 = new System.Windows.Forms.TextBox() ;
						this.txtD20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtD20.Location = new System.Drawing.Point(158, 280);
						this.txtD20.Name = "txtD20";
						this.txtD20.Size = new System.Drawing.Size(150,22);
						this.txtD20.TabIndex = 20 ;
						this.Controls.Add(this.txtD20) ;
						this.txtD20.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblMI.Location = new System.Drawing.Point(6, 307);
						
						this.txtMI = new System.Windows.Forms.TextBox() ;
						this.txtMI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtMI.Location = new System.Drawing.Point(158, 307);
						this.txtMI.Name = "txtMI";
						this.txtMI.Size = new System.Drawing.Size(150,22);
						this.txtMI.TabIndex = 22 ;
						this.Controls.Add(this.txtMI) ;
						this.txtMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblCR.Location = new System.Drawing.Point(6, 334);
						
						this.txtCR = new System.Windows.Forms.TextBox() ;
						this.txtCR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtCR.Location = new System.Drawing.Point(158, 334);
						this.txtCR.Name = "txtCR";
						this.txtCR.Size = new System.Drawing.Size(150,22);
						this.txtCR.TabIndex = 24 ;
						this.Controls.Add(this.txtCR) ;
						this.txtCR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
						
						this.lblWAA.Location = new System.Drawing.Point(6, 361);
						
						this.txtWAA = new System.Windows.Forms.TextBox() ;
						this.txtWAA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtWAA.Location = new System.Drawing.Point(158, 361);
						this.txtWAA.Name = "txtWAA";
						this.txtWAA.Size = new System.Drawing.Size(150,22);
						this.txtWAA.TabIndex = 26 ;
						this.Controls.Add(this.txtWAA) ;
						
						this.lblV.Location = new System.Drawing.Point(6, 388);
						
						this.txtV = new System.Windows.Forms.TextBox() ;
						this.txtV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtV.Location = new System.Drawing.Point(158, 388);
						this.txtV.Name = "txtV";
						this.txtV.Size = new System.Drawing.Size(150,22);
						this.txtV.TabIndex = 28 ;
						this.Controls.Add(this.txtV) ;
						
						this.lblDistillation.Location = new System.Drawing.Point(6, 415);
						
						this.txtDistillation = new System.Windows.Forms.TextBox() ;
						this.txtDistillation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtDistillation.Location = new System.Drawing.Point(158, 415);
						this.txtDistillation.Name = "txtDistillation";
						this.txtDistillation.Size = new System.Drawing.Size(150,22);
						this.txtDistillation.TabIndex = 30 ;
						this.Controls.Add(this.txtDistillation) ;
						
						this.lblXZQD.Location = new System.Drawing.Point(6, 442);
						
						this.txtXZQD = new System.Windows.Forms.TextBox() ;
						this.txtXZQD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtXZQD.Location = new System.Drawing.Point(158, 442);
						this.txtXZQD.Name = "txtXZQD";
						this.txtXZQD.Size = new System.Drawing.Size(150,22);
						this.txtXZQD.TabIndex = 32 ;
						this.Controls.Add(this.txtXZQD) ;
						
						this.lblOther.Location = new System.Drawing.Point(6, 469);
						
						this.txtOther = new System.Windows.Forms.TextBox() ;
						this.txtOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtOther.Location = new System.Drawing.Point(158, 469);
						this.txtOther.Name = "txtOther";
						this.txtOther.Size = new System.Drawing.Size(150,22);
						this.txtOther.TabIndex = 34 ;
						this.Controls.Add(this.txtOther) ;
						
						this.lblTestPersonTP.Location = new System.Drawing.Point(6, 496);
						
						this.combTestPersonTP = new System.Windows.Forms.ComboBox() ;
						this.combTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combTestPersonTP.FormattingEnabled = true;
						this.combTestPersonTP.Location = new System.Drawing.Point(158, 496);
						this.combTestPersonTP.Name = "combTestPersonTP";
						this.combTestPersonTP.Size = new System.Drawing.Size(150,22);
						this.combTestPersonTP.TabIndex = 36 ;
						this.Controls.Add(this.combTestPersonTP) ;
						
						this.lblRecordType.Location = new System.Drawing.Point(6, 523);
						
						this.combRecordType = new System.Windows.Forms.ComboBox() ;
						this.combRecordType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.combRecordType.FormattingEnabled = true;
						this.combRecordType.Location = new System.Drawing.Point(158, 523);
						this.combRecordType.Name = "combRecordType";
						this.combRecordType.Size = new System.Drawing.Size(150,22);
						this.combRecordType.TabIndex = 38 ;
						this.Controls.Add(this.combRecordType) ;
						
						this.lblTestDateTime.Location = new System.Drawing.Point(6, 550);
						
						this.dtTestDateTime = new System.Windows.Forms.DateTimePicker() ;
						this.dtTestDateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
						this.dtTestDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.dtTestDateTime.Location = new System.Drawing.Point(158, 550);
						this.dtTestDateTime.Name = "dtTestDateTime";
						this.dtTestDateTime.Size = new System.Drawing.Size(150,22);
						this.dtTestDateTime.TabIndex = 40 ;
						this.Controls.Add(this.dtTestDateTime) ;
						
						this.lblRemark.Location = new System.Drawing.Point(6, 577);
						
						this.txtRemark = new System.Windows.Forms.TextBox() ;
						this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
						this.txtRemark.Location = new System.Drawing.Point(158, 577);
						this.txtRemark.Name = "txtRemark";
						this.txtRemark.Size = new System.Drawing.Size(150,22);
						this.txtRemark.TabIndex = 42 ;
						this.Controls.Add(this.txtRemark) ;
						
					#region 添加按钮
					this.btnOK = new System.Windows.Forms.Button();
					this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnOK.Location = new System.Drawing.Point(26, 624);
					this.btnOK.Name = "btnOK";
					this.btnOK.Size = new System.Drawing.Size(78, 27);
					this.btnOK.TabIndex = 44;
					this.btnOK.Text = "保存";
					this.btnOK.UseVisualStyleBackColor = true;
					this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
					this.Controls.Add(this.btnOK);
					this.btnCancle = new System.Windows.Forms.Button();
					this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
					this.btnCancle.Location = new System.Drawing.Point(106, 624);
					this.btnCancle.Name = "btnCancle";
					this.btnCancle.Size = new System.Drawing.Size(78, 27);
					this.btnCancle.TabIndex = 46;
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
					this.FormPager.Location = new System.Drawing.Point(10, 654);
					this.FormPager.Name = "FormPager";
					this.FormPager.RecordCount = 0;
					this.FormPager.Size = new System.Drawing.Size(256, 29);
					this.FormPager.TabIndex = 100;
					this.Controls.Add(this.FormPager);
					this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
					#endregion
					#region 窗体
					this.Name = "AddOilData";
					this.Size = new System.Drawing.Size(350, 500);
					this.Load += new System.EventHandler(this.AddAddOilDataLoad);
					this.SuspendLayout();
					((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
					this.ResumeLayout(false);
					this.PerformLayout();
					#endregion
				}
				#endregion
			#endregion

			#region 构造函数 及初始化
			public AddOilData()
			{
				InitializeComponent();
			}
			//控件加载事件,完成数据绑定和相关基本设置
			void AddAddOilDataLoad(object sender, EventArgs e)
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
					FormPager.RecordCount = tb_OilData.FindCount(CutSearchCondition,"","",0,0) ;
				}
			}
			/// <summary>
			/// 获取或者设置当前实体
			/// </summary>
			public tb_OilData CutModel
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
				
						if(combOilNameTP.Text.Trim()==""){
							errorProvider1.SetError(combOilNameTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combTestPersonTP.Text.Trim()==""){
							errorProvider1.SetError(combTestPersonTP,"必填项目");
							return false ;
						} 
				return true ;
				
						if(combRecordType.Text.Trim()==""){
							errorProvider1.SetError(combRecordType,"必填项目");
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
				tb_OilData model = new tb_OilData();//定义当前实体
				
					if(txtID.Text.Trim()!=""){
						model.ID = txtID.Text.Trim() ;}
				if(combOilNameTP.Text.Trim()!=""){
					model.OilNameTP = combOilNameTP.Text.Trim() ;}if(txtV40.Text.Trim()!=""){
						model.V40 =Convert.ToDouble(txtV40.Text.Trim()) ;}
					if(txtV100.Text.Trim()!=""){
						model.V100 =Convert.ToDouble(txtV100.Text.Trim()) ;}
					if(txtVI.Text.Trim()!=""){
						model.VI =Convert.ToInt32(txtVI.Text.Trim()) ;}
					if(txtPP.Text.Trim()!=""){
						model.PP =Convert.ToInt32(txtPP.Text.Trim()) ;}
					if(txtFP.Text.Trim()!=""){
						model.FP =Convert.ToInt32(txtFP.Text.Trim()) ;}
					if(txtAV.Text.Trim()!=""){
						model.AV =Convert.ToDouble(txtAV.Text.Trim()) ;}
					if(txtWC.Text.Trim()!=""){
						model.WC =Convert.ToDouble(txtWC.Text.Trim()) ;}
					
					if(txtASTM.Text.Trim()!=""){
						model.ASTM = txtASTM.Text.Trim() ;}if(txtD20.Text.Trim()!=""){
						model.D20 =Convert.ToDouble(txtD20.Text.Trim()) ;}
					if(txtMI.Text.Trim()!=""){
						model.MI =Convert.ToDouble(txtMI.Text.Trim()) ;}
					if(txtCR.Text.Trim()!=""){
						model.CR =Convert.ToDouble(txtCR.Text.Trim()) ;}
					
					if(txtWAA.Text.Trim()!=""){
						model.WAA = txtWAA.Text.Trim() ;}
					if(txtV.Text.Trim()!=""){
						model.V = txtV.Text.Trim() ;}
					if(txtDistillation.Text.Trim()!=""){
						model.Distillation = txtDistillation.Text.Trim() ;}
					if(txtXZQD.Text.Trim()!=""){
						model.XZQD = txtXZQD.Text.Trim() ;}
					if(txtOther.Text.Trim()!=""){
						model.Other = txtOther.Text.Trim() ;}
				if(combTestPersonTP.Text.Trim()!=""){
					model.TestPersonTP = combTestPersonTP.Text.Trim() ;}
				if(combRecordType.Text.Trim()!=""){
					model.RecordType = combRecordType.Text.Trim() ;}{
						model.TestDateTime = dtTestDateTime.Value ;}
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
			List <tb_OilData> modelList ;
			void GetData()
			{				
				//判断不为空，才能绑定				
				modelList = tb_OilData.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex-1)*FormPager.PageSize ,FormPager.PageSize);
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
							combOilNameTP.Enabled = true ;txtV40.ReadOnly = false ;
							txtV40.Text = string.Empty  ; txtV100.ReadOnly = false ;
							txtV100.Text = string.Empty  ; txtVI.ReadOnly = false ;
							txtVI.Text = string.Empty  ; txtPP.ReadOnly = false ;
							txtPP.Text = string.Empty  ; txtFP.ReadOnly = false ;
							txtFP.Text = string.Empty  ; txtAV.ReadOnly = false ;
							txtAV.Text = string.Empty  ; txtWC.ReadOnly = false ;
							txtWC.Text = string.Empty  ; txtASTM.ReadOnly = false ;
							txtASTM.Text = string.Empty  ; txtD20.ReadOnly = false ;
							txtD20.Text = string.Empty  ; txtMI.ReadOnly = false ;
							txtMI.Text = string.Empty  ; txtCR.ReadOnly = false ;
							txtCR.Text = string.Empty  ; txtWAA.ReadOnly = false ;
							txtWAA.Text = string.Empty  ; txtV.ReadOnly = false ;
							txtV.Text = string.Empty  ; txtDistillation.ReadOnly = false ;
							txtDistillation.Text = string.Empty  ; txtXZQD.ReadOnly = false ;
							txtXZQD.Text = string.Empty  ; txtOther.ReadOnly = false ;
							txtOther.Text = string.Empty  ; 
							combTestPersonTP.Enabled = true ;
							combRecordType.Enabled = true ;txtRemark.ReadOnly = false ;
							txtRemark.Text = string.Empty  ; 
				}
			}
			private void SetControlEdit()
			{
				if (CutShowMode== FormShowMode.ContinueDisplay || CutShowMode== FormShowMode.DisplayCurrent ) {
					btnOK .Enabled = true ;
					btnOK.Text =" 保存";
					//控件除主键外都可读
				txtID.ReadOnly = true;combOilNameTP.Enabled = true ;
					txtV40.ReadOnly = false ;
					txtV100.ReadOnly = false ;
					txtVI.ReadOnly = false ;
					txtPP.ReadOnly = false ;
					txtFP.ReadOnly = false ;
					txtAV.ReadOnly = false ;
					txtWC.ReadOnly = false ;
					txtASTM.ReadOnly = false ;
					txtD20.ReadOnly = false ;
					txtMI.ReadOnly = false ;
					txtCR.ReadOnly = false ;
					txtWAA.ReadOnly = false ;
					txtV.ReadOnly = false ;
					txtDistillation.ReadOnly = false ;
					txtXZQD.ReadOnly = false ;
					txtOther.ReadOnly = false ;combTestPersonTP.Enabled = true ;combRecordType.Enabled = true ;dtTestDateTime.Enabled = true ;
				
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
							combOilNameTP.Enabled = false ;
							txtV40.ReadOnly = true ;txtV100.ReadOnly = true ;txtVI.ReadOnly = true ;txtPP.ReadOnly = true ;txtFP.ReadOnly = true ;txtAV.ReadOnly = true ;txtWC.ReadOnly = true ;txtASTM.ReadOnly = true ;txtD20.ReadOnly = true ;txtMI.ReadOnly = true ;txtCR.ReadOnly = true ;txtWAA.ReadOnly = true ;txtV.ReadOnly = true ;txtDistillation.ReadOnly = true ;txtXZQD.ReadOnly = true ;txtOther.ReadOnly = true ;
							combTestPersonTP.Enabled = false ;
							
							combRecordType.Enabled = false ;
							
							dtTestDateTime.Enabled = false ;
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
				  combOilNameTP.DataBindings.Clear () ;
													combOilNameTP.DataBindings.Add ("Text",CutModel,"OilNameTP") ;
				
				  txtV40.DataBindings.Clear();
						   txtV40.DataBindings.Add ("Text",CutModel,"V40");
				  txtV100.DataBindings.Clear();
						   txtV100.DataBindings.Add ("Text",CutModel,"V100");
				  txtVI.DataBindings.Clear();
						   txtVI.DataBindings.Add ("Text",CutModel,"VI");
				  txtPP.DataBindings.Clear();
						   txtPP.DataBindings.Add ("Text",CutModel,"PP");
				  txtFP.DataBindings.Clear();
						   txtFP.DataBindings.Add ("Text",CutModel,"FP");
				  txtAV.DataBindings.Clear();
						   txtAV.DataBindings.Add ("Text",CutModel,"AV");
				  txtWC.DataBindings.Clear();
						   txtWC.DataBindings.Add ("Text",CutModel,"WC");
				  txtASTM.DataBindings.Clear();
						   txtASTM.DataBindings.Add ("Text",CutModel,"ASTM");
				  txtD20.DataBindings.Clear();
						   txtD20.DataBindings.Add ("Text",CutModel,"D20");
				  txtMI.DataBindings.Clear();
						   txtMI.DataBindings.Add ("Text",CutModel,"MI");
				  txtCR.DataBindings.Clear();
						   txtCR.DataBindings.Add ("Text",CutModel,"CR");
				  txtWAA.DataBindings.Clear();
						   txtWAA.DataBindings.Add ("Text",CutModel,"WAA");
				  txtV.DataBindings.Clear();
						   txtV.DataBindings.Add ("Text",CutModel,"V");
				  txtDistillation.DataBindings.Clear();
						   txtDistillation.DataBindings.Add ("Text",CutModel,"Distillation");
				  txtXZQD.DataBindings.Clear();
						   txtXZQD.DataBindings.Add ("Text",CutModel,"XZQD");
				  txtOther.DataBindings.Clear();
						   txtOther.DataBindings.Add ("Text",CutModel,"Other");
				  combTestPersonTP.DataBindings.Clear () ;
													combTestPersonTP.DataBindings.Add ("Text",CutModel,"TestPersonTP") ;
				
				  combRecordType.DataBindings.Clear () ;
													combRecordType.DataBindings.Add ("Text",CutModel,"RecordType") ;
				
				  dtTestDateTime.DataBindings.Clear () ;
													dtTestDateTime.DataBindings.Add ("Value",CutModel,"TestDateTime") ;
				
				  txtRemark.DataBindings.Clear();
						   txtRemark.DataBindings.Add ("Text",CutModel,"Remark");
			}
			#endregion
		  }
	}