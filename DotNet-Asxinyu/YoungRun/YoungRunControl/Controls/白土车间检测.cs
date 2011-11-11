/*
* 由SharpDevelop创建。
* 用户： asxinyu
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
using DotNet.Tools.Controls;

namespace YoungRunControl.Controls
{
    public partial class AddBtTestData : UserControl
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
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;

        private System.Windows.Forms.ComboBox combProductNameTP;
        private System.Windows.Forms.Label lblProductNameTP;
        private System.Windows.Forms.TextBox txtV40;
        private System.Windows.Forms.Label lblV40;
        private System.Windows.Forms.TextBox txtV100;
        private System.Windows.Forms.Label lblV100;
        private System.Windows.Forms.TextBox txtVI;
        private System.Windows.Forms.Label lblVI;
        private System.Windows.Forms.TextBox txtAV;
        private System.Windows.Forms.Label lblAV;
        private System.Windows.Forms.TextBox txtASTM;
        private System.Windows.Forms.Label lblASTM;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.DateTimePicker dtGetSampleTime;
        private System.Windows.Forms.Label lblGetSampleTime;

        private System.Windows.Forms.ComboBox combGetSamLocationTP;
        private System.Windows.Forms.Label lblGetSamLocationTP;

        private System.Windows.Forms.ComboBox combGetSampPersonTP;
        private System.Windows.Forms.Label lblGetSampPersonTP;

        private System.Windows.Forms.ComboBox combTestPersonTP;
        private System.Windows.Forms.Label lblTestPersonTP;
        private System.Windows.Forms.DateTimePicker dtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private GroupBox groupBox1;
        private DotNet.Tools.Controls.EntityFormPager FormPager;
        #endregion

        #region 组件设计器生成的代码
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBtTestData));
            this.lblID = new System.Windows.Forms.Label();
            this.lblProductNameTP = new System.Windows.Forms.Label();
            this.lblV40 = new System.Windows.Forms.Label();
            this.lblV100 = new System.Windows.Forms.Label();
            this.lblVI = new System.Windows.Forms.Label();
            this.lblAV = new System.Windows.Forms.Label();
            this.lblASTM = new System.Windows.Forms.Label();
            this.lblOthers = new System.Windows.Forms.Label();
            this.lblGetSampleTime = new System.Windows.Forms.Label();
            this.lblGetSamLocationTP = new System.Windows.Forms.Label();
            this.lblGetSampPersonTP = new System.Windows.Forms.Label();
            this.lblTestPersonTP = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.combProductNameTP = new System.Windows.Forms.ComboBox();
            this.txtV40 = new System.Windows.Forms.TextBox();
            this.txtV100 = new System.Windows.Forms.TextBox();
            this.txtVI = new System.Windows.Forms.TextBox();
            this.txtAV = new System.Windows.Forms.TextBox();
            this.txtASTM = new System.Windows.Forms.TextBox();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.dtGetSampleTime = new System.Windows.Forms.DateTimePicker();
            this.combGetSamLocationTP = new System.Windows.Forms.ComboBox();
            this.combGetSampPersonTP = new System.Windows.Forms.ComboBox();
            this.combTestPersonTP = new System.Windows.Forms.ComboBox();
            this.dtUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FormPager = new DotNet.Tools.Controls.EntityFormPager();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.Location = new System.Drawing.Point(8, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(63, 14);
            this.lblID.TabIndex = 200;
            this.lblID.Text = "数据编号";
            // 
            // lblProductNameTP
            // 
            this.lblProductNameTP.AutoSize = true;
            this.lblProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProductNameTP.Location = new System.Drawing.Point(8, 38);
            this.lblProductNameTP.Name = "lblProductNameTP";
            this.lblProductNameTP.Size = new System.Drawing.Size(63, 14);
            this.lblProductNameTP.TabIndex = 200;
            this.lblProductNameTP.Text = "产品名称";
            // 
            // lblV40
            // 
            this.lblV40.AutoSize = true;
            this.lblV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblV40.Location = new System.Drawing.Point(40, 25);
            this.lblV40.Name = "lblV40";
            this.lblV40.Size = new System.Drawing.Size(28, 14);
            this.lblV40.TabIndex = 200;
            this.lblV40.Text = "V40";
            // 
            // lblV100
            // 
            this.lblV100.AutoSize = true;
            this.lblV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblV100.Location = new System.Drawing.Point(33, 52);
            this.lblV100.Name = "lblV100";
            this.lblV100.Size = new System.Drawing.Size(35, 14);
            this.lblV100.TabIndex = 200;
            this.lblV100.Text = "V100";
            // 
            // lblVI
            // 
            this.lblVI.AutoSize = true;
            this.lblVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVI.Location = new System.Drawing.Point(5, 79);
            this.lblVI.Name = "lblVI";
            this.lblVI.Size = new System.Drawing.Size(63, 14);
            this.lblVI.TabIndex = 200;
            this.lblVI.Text = "粘度指数";
            // 
            // lblAV
            // 
            this.lblAV.AutoSize = true;
            this.lblAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAV.Location = new System.Drawing.Point(240, 25);
            this.lblAV.Name = "lblAV";
            this.lblAV.Size = new System.Drawing.Size(35, 14);
            this.lblAV.TabIndex = 200;
            this.lblAV.Text = "酸值";
            // 
            // lblASTM
            // 
            this.lblASTM.AutoSize = true;
            this.lblASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblASTM.Location = new System.Drawing.Point(240, 52);
            this.lblASTM.Name = "lblASTM";
            this.lblASTM.Size = new System.Drawing.Size(35, 14);
            this.lblASTM.TabIndex = 200;
            this.lblASTM.Text = "色度";
            // 
            // lblOthers
            // 
            this.lblOthers.AutoSize = true;
            this.lblOthers.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOthers.Location = new System.Drawing.Point(240, 79);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(35, 14);
            this.lblOthers.TabIndex = 200;
            this.lblOthers.Text = "其他";
            // 
            // lblGetSampleTime
            // 
            this.lblGetSampleTime.AutoSize = true;
            this.lblGetSampleTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGetSampleTime.Location = new System.Drawing.Point(10, 180);
            this.lblGetSampleTime.Name = "lblGetSampleTime";
            this.lblGetSampleTime.Size = new System.Drawing.Size(63, 14);
            this.lblGetSampleTime.TabIndex = 200;
            this.lblGetSampleTime.Text = "采样时间";
            // 
            // lblGetSamLocationTP
            // 
            this.lblGetSamLocationTP.AutoSize = true;
            this.lblGetSamLocationTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGetSamLocationTP.Location = new System.Drawing.Point(219, 9);
            this.lblGetSamLocationTP.Name = "lblGetSamLocationTP";
            this.lblGetSamLocationTP.Size = new System.Drawing.Size(63, 14);
            this.lblGetSamLocationTP.TabIndex = 200;
            this.lblGetSamLocationTP.Text = "采样地点";
            // 
            // lblGetSampPersonTP
            // 
            this.lblGetSampPersonTP.AutoSize = true;
            this.lblGetSampPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGetSampPersonTP.Location = new System.Drawing.Point(233, 36);
            this.lblGetSampPersonTP.Name = "lblGetSampPersonTP";
            this.lblGetSampPersonTP.Size = new System.Drawing.Size(49, 14);
            this.lblGetSampPersonTP.TabIndex = 200;
            this.lblGetSampPersonTP.Text = "采样人";
            // 
            // lblTestPersonTP
            // 
            this.lblTestPersonTP.AutoSize = true;
            this.lblTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTestPersonTP.Location = new System.Drawing.Point(25, 212);
            this.lblTestPersonTP.Name = "lblTestPersonTP";
            this.lblTestPersonTP.Size = new System.Drawing.Size(49, 14);
            this.lblTestPersonTP.TabIndex = 200;
            this.lblTestPersonTP.Text = "检测人";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateTime.Location = new System.Drawing.Point(11, 239);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(63, 14);
            this.lblUpdateTime.TabIndex = 200;
            this.lblUpdateTime.Text = "更新时间";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(39, 266);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(35, 14);
            this.lblRemark.TabIndex = 200;
            this.lblRemark.Text = "备注";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(75, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(138, 23);
            this.txtID.TabIndex = 0;
            // 
            // combProductNameTP
            // 
            this.combProductNameTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combProductNameTP.FormattingEnabled = true;
            this.combProductNameTP.Location = new System.Drawing.Point(75, 34);
            this.combProductNameTP.Name = "combProductNameTP";
            this.combProductNameTP.Size = new System.Drawing.Size(138, 22);
            this.combProductNameTP.TabIndex = 1;
            // 
            // txtV40
            // 
            this.txtV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV40.Location = new System.Drawing.Point(69, 21);
            this.txtV40.Name = "txtV40";
            this.txtV40.Size = new System.Drawing.Size(138, 23);
            this.txtV40.TabIndex = 5;
            this.txtV40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtV100
            // 
            this.txtV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV100.Location = new System.Drawing.Point(69, 48);
            this.txtV100.Name = "txtV100";
            this.txtV100.Size = new System.Drawing.Size(138, 23);
            this.txtV100.TabIndex = 6;
            this.txtV100.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtVI
            // 
            this.txtVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVI.Location = new System.Drawing.Point(69, 75);
            this.txtVI.Name = "txtVI";
            this.txtVI.Size = new System.Drawing.Size(138, 23);
            this.txtVI.TabIndex = 8;
            this.txtVI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtAV
            // 
            this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAV.Location = new System.Drawing.Point(278, 21);
            this.txtAV.Name = "txtAV";
            this.txtAV.Size = new System.Drawing.Size(109, 23);
            this.txtAV.TabIndex = 10;
            this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForOnlyData);
            // 
            // txtASTM
            // 
            this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtASTM.Location = new System.Drawing.Point(278, 48);
            this.txtASTM.Name = "txtASTM";
            this.txtASTM.Size = new System.Drawing.Size(109, 23);
            this.txtASTM.TabIndex = 12;
            // 
            // txtOthers
            // 
            this.txtOthers.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOthers.Location = new System.Drawing.Point(278, 75);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(109, 23);
            this.txtOthers.TabIndex = 14;
            // 
            // dtGetSampleTime
            // 
            this.dtGetSampleTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtGetSampleTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtGetSampleTime.Location = new System.Drawing.Point(75, 176);
            this.dtGetSampleTime.Name = "dtGetSampleTime";
            this.dtGetSampleTime.Size = new System.Drawing.Size(318, 23);
            this.dtGetSampleTime.TabIndex = 16;
            // 
            // combGetSamLocationTP
            // 
            this.combGetSamLocationTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combGetSamLocationTP.FormattingEnabled = true;
            this.combGetSamLocationTP.Location = new System.Drawing.Point(284, 5);
            this.combGetSamLocationTP.Name = "combGetSamLocationTP";
            this.combGetSamLocationTP.Size = new System.Drawing.Size(109, 22);
            this.combGetSamLocationTP.TabIndex = 2;
            // 
            // combGetSampPersonTP
            // 
            this.combGetSampPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combGetSampPersonTP.FormattingEnabled = true;
            this.combGetSampPersonTP.Location = new System.Drawing.Point(284, 32);
            this.combGetSampPersonTP.Name = "combGetSampPersonTP";
            this.combGetSampPersonTP.Size = new System.Drawing.Size(109, 22);
            this.combGetSampPersonTP.TabIndex = 3;
            // 
            // combTestPersonTP
            // 
            this.combTestPersonTP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combTestPersonTP.FormattingEnabled = true;
            this.combTestPersonTP.Location = new System.Drawing.Point(76, 208);
            this.combTestPersonTP.Name = "combTestPersonTP";
            this.combTestPersonTP.Size = new System.Drawing.Size(318, 22);
            this.combTestPersonTP.TabIndex = 22;
            // 
            // dtUpdateTime
            // 
            this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtUpdateTime.Location = new System.Drawing.Point(76, 235);
            this.dtUpdateTime.Name = "dtUpdateTime";
            this.dtUpdateTime.Size = new System.Drawing.Size(318, 23);
            this.dtUpdateTime.TabIndex = 24;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(76, 262);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(318, 23);
            this.txtRemark.TabIndex = 26;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(249, 291);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(58, 27);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(328, 291);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(65, 27);
            this.btnCancle.TabIndex = 30;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblV40);
            this.groupBox1.Controls.Add(this.txtOthers);
            this.groupBox1.Controls.Add(this.txtASTM);
            this.groupBox1.Controls.Add(this.txtAV);
            this.groupBox1.Controls.Add(this.lblV100);
            this.groupBox1.Controls.Add(this.txtVI);
            this.groupBox1.Controls.Add(this.lblVI);
            this.groupBox1.Controls.Add(this.txtV100);
            this.groupBox1.Controls.Add(this.lblAV);
            this.groupBox1.Controls.Add(this.txtV40);
            this.groupBox1.Controls.Add(this.lblASTM);
            this.groupBox1.Controls.Add(this.lblOthers);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实测数据";
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
            this.FormPager.Location = new System.Drawing.Point(3, 291);
            this.FormPager.Name = "FormPager";
            this.FormPager.RecordCount = 0;
            this.FormPager.Size = new System.Drawing.Size(238, 29);
            this.FormPager.TabIndex = 100;
            this.FormPager.PageIndexChanged += new DotNet.Tools.Controls.EntityFormPager.EventHandler(this.FormPager_PageIndexChanged);
            // 
            // AddBtTestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblProductNameTP);
            this.Controls.Add(this.lblGetSampleTime);
            this.Controls.Add(this.lblGetSamLocationTP);
            this.Controls.Add(this.lblGetSampPersonTP);
            this.Controls.Add(this.lblTestPersonTP);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.combProductNameTP);
            this.Controls.Add(this.dtGetSampleTime);
            this.Controls.Add(this.combGetSamLocationTP);
            this.Controls.Add(this.combGetSampPersonTP);
            this.Controls.Add(this.combTestPersonTP);
            this.Controls.Add(this.dtUpdateTime);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.FormPager);
            this.Name = "AddBtTestData";
            this.Size = new System.Drawing.Size(402, 326);
            this.Load += new System.EventHandler(this.AddAddBtTestDataLoad);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #endregion

        #region 构造函数 及初始化
        public AddBtTestData()
        {
            InitializeComponent(); 
            if (!DesignMode )
            {
                CustomerSettings();  
            } 
        }
        /// <summary>
        /// 其他控件的特殊设置
        /// </summary>
        private void CustomerSettings()
        {
            //控件的特殊设置，如格式，显示,控件的绑定
            if (!DesignMode)
            {
                //日期控件的显示格式
                dtGetSampleTime.Format = DateTimePickerFormat.Custom;
                dtGetSampleTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtUpdateTime.Format = DateTimePickerFormat.Custom;
                dtUpdateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                //绑定数据
                combGetSamLocationTP.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.BtGetSampleLocate));
                combGetSampPersonTP.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.BtGetSamplePerson));
                combTestPersonTP.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.LabTestPersons));
            }
        }   
        //控件加载事件,完成数据绑定和相关基本设置
        void AddAddBtTestDataLoad(object sender, EventArgs e) { }
        /// <summary>
        /// 初始化设置
        /// </summary>
        /// <param name="showMode">窗体的显示模式,必须指定</param>
        /// <param name="searcgCondtion">指定显示的实体条件</param>
        /// <param name="fixCondition">固定的显示条件</param>
        public void InitializeSettings(FormShowMode showMode, string searcgCondtion = "", string fixCondition = "")
        {
            this.FormPager.PageSize = 1;
            this.CutShowMode = showMode;
            this.CutSearchCondition = searcgCondtion;
            this.FixedSqlCondition = fixCondition;
            if (showMode == FormShowMode.AddOne || showMode == FormShowMode.ContinueAdd) { SetAllTextControls(ControlStatus.ReSet); }
            else
            {
                SetAllTextControls(ControlStatus.ReadOnly);//只读
                GetData();
                BandingData();//绑定数据
            }
            //TODO:问题，只读显示一条记录时,需要传入当前的Model实体类进行绑定
        }
        #endregion

        #region 相关字段与属性
        /// <summary>
        /// 固定的查询条件
        /// </summary>
        public string FixedSqlCondition { get; set; }
        string _curSeachCondition;
        /// <summary>
        /// 获取或者设置当前的查询条件
        /// </summary>
        public string CutSearchCondition
        {
            get { return _curSeachCondition; }
            set
            {
                _curSeachCondition = "";
                if (FixedSqlCondition != null && FixedSqlCondition != "")
                {
                    if (value != null && value != "")
                    {
                        _curSeachCondition += (FixedSqlCondition + " and " + value);
                    }
                    else
                        _curSeachCondition = FixedSqlCondition;
                }
                else
                {
                    if (value != null) { _curSeachCondition = value; }
                    else _curSeachCondition = "";
                }
                //此记录数可以在加载时固定起来,不用每次都计算
                FormPager.RecordCount = tb_BtTestData.FindCount(CutSearchCondition, "", "", 0, 0);
            }
        }
        /// <summary>
        /// 获取或者设置当前实体
        /// </summary>
        public tb_BtTestData CutModel { get; set; }
        /// <summary>
        /// 当前实体窗体的显示模式,默认为连续显示
        /// </summary>
        public FormShowMode CutShowMode { get; set; }
        #endregion

        #region 验证事件
        bool ValidateControls()
        {
            if (txtID.Text.Trim() == "")//数据编号
            {
                errorProvider1.SetError(txtID, "必填项目");
                return false;
            }
            if (combProductNameTP.Text.Trim() == "")//产品名称
            {
                errorProvider1.SetError(combProductNameTP, "必填项目");
                return false;
            }
            if (combTestPersonTP.Text.Trim() == "")//检测人
            {
                errorProvider1.SetError(combTestPersonTP, "必填项目");
                return false;
            }
            return true;
        }
        #endregion

        #region 按钮事件
        void btnOK_Click(object sender, EventArgs e)
        {
            //TODO:有问题，需要根据当前的状态来更新和保存数据
            //当前实体状态不是只读并且通过验证后才能进行操作
            if (btnOK.Text.Contains("修改")) SetAllTextControls(ControlStatus.Edit);
            else
            {
                if (((CutShowMode != FormShowMode.ReadOnlyForAll) || (CutShowMode != FormShowMode.ReadOnlyForOne)) && ValidateControls())
                {
                    tb_BtTestData model = new tb_BtTestData();//定义当前实体 
                    if (txtID.Text.Trim() != "") model.ID = txtID.Text.Trim();//数据编号
                    if (combProductNameTP.Text.Trim() != "") model.ProductNameTP = combProductNameTP.Text.Trim();//产品名称
                    if (txtV40.Text.Trim() != "") model.V40 = Convert.ToDouble(txtV40.Text.Trim());//V40
                    if (txtV100.Text.Trim() != "") model.V100 = Convert.ToDouble(txtV100.Text.Trim());//V100
                    if (txtVI.Text.Trim() != "") model.VI = Convert.ToInt32(txtVI.Text.Trim());//粘度指数
                    if (txtAV.Text.Trim() != "") model.AV = Convert.ToDouble(txtAV.Text.Trim());//酸值
                    if (txtASTM.Text.Trim() != "") model.ASTM = txtASTM.Text.Trim();//色度
                    if (txtOthers.Text.Trim() != "") model.Others = txtOthers.Text.Trim();//其他
                    model.GetSampleTime = dtGetSampleTime.Value;//采样时间
                    if (combGetSamLocationTP.Text.Trim() != "") model.GetSamLocationTP = combGetSamLocationTP.Text.Trim();//采样地点
                    if (combGetSampPersonTP.Text.Trim() != "") model.GetSampPersonTP = combGetSampPersonTP.Text.Trim();//采样人
                    if (combTestPersonTP.Text.Trim() != "") model.TestPersonTP = combTestPersonTP.Text.Trim();//检测人
                    model.UpdateTime = dtUpdateTime.Value;//更新时间
                    if (txtRemark.Text.Trim() != "") model.Remark = txtRemark.Text.Trim();//备注
                    if (CutShowMode == FormShowMode.AddOne)
                    {
                        model.Insert();//添加
                        MessageBox.Show("添加成功");
                        this.ParentForm.DialogResult = DialogResult.OK;
                    }
                    else if (CutShowMode == FormShowMode.ContinueAdd)
                    {
                        model.Insert();//添加
                        MessageBox.Show("添加成功");
                        SetAllTextControls(ControlStatus.ReSet);
                    }
                    else if (CutShowMode == FormShowMode.ContinueDisplay || CutShowMode == FormShowMode.DisplayCurrent)
                    {
                        model.Update();//修改更新
                        this.btnOK.Text = "修改";
                        SetAllTextControls(ControlStatus.ReadOnly);
                    }
                }
            }
        }

        void btnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
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
        private void FormPager_PageIndexChanged(object sender, EventArgs e) { GetData(); }
        List<tb_BtTestData> modelList;//当前实体列表
        void GetData()
        {
            //判断不为空，才能绑定				
            modelList = tb_BtTestData.FindAll(CutSearchCondition, "", "", (FormPager.PageIndex - 1) * FormPager.PageSize, FormPager.PageSize);
            if (modelList != null)
            {
                CutModel = modelList[0];//绑定实体					
                BandingData();//绑定数据
            }
        }
        #endregion

        #region 根据状态设置控件
        //设置文本控件的可用性
        private void SetAllTextControls(ControlStatus ctr)
        {
            if (CutShowMode == FormShowMode.AddOne || CutShowMode == FormShowMode.ContinueAdd || CutShowMode == FormShowMode.DisplayCurrent || CutShowMode == FormShowMode.ReadOnlyForOne)
                FormPager.Visible = false;
            else FormPager.Visible = true;
            switch (ctr)
            {
                case ControlStatus.ReSet:
                    SetControlReSet();
                    return;
                case ControlStatus.Edit:
                    SetControlEdit();
                    return;
                case ControlStatus.ReadOnly:
                    SetControlReadOnly();
                    return;
            }

        }
        private void SetControlReSet()
        {
            //只可能是添加新记录
            if (CutShowMode == FormShowMode.AddOne || CutShowMode == FormShowMode.ContinueAdd)
            {
                btnOK.Enabled = true;
                btnOK.Text = "保存";
                //设置控件清空，并且可用
                txtID.ReadOnly = false;//数据编号
                txtID.Text = string.Empty;
                combProductNameTP.Enabled = true; //产品名称	
                txtV40.ReadOnly = false;//V40
                txtV40.Text = string.Empty;
                txtV100.ReadOnly = false;//V100
                txtV100.Text = string.Empty;
                txtVI.ReadOnly = false;//粘度指数
                txtVI.Text = string.Empty;
                txtAV.ReadOnly = false;//酸值
                txtAV.Text = string.Empty;
                txtASTM.ReadOnly = false;//色度
                txtASTM.Text = string.Empty;
                txtOthers.ReadOnly = false;//其他
                txtOthers.Text = string.Empty;
                combGetSamLocationTP.Enabled = true; //采样地点	
                combGetSampPersonTP.Enabled = true; //采样人	
                combTestPersonTP.Enabled = true; //检测人	
                txtRemark.ReadOnly = false;//备注
                txtRemark.Text = string.Empty;
            }
        }
        private void SetControlEdit()
        {
            if (CutShowMode == FormShowMode.ContinueDisplay || CutShowMode == FormShowMode.DisplayCurrent)
            {
                btnOK.Enabled = true;
                btnOK.Text = " 保存";
                //控件除主键外都可读
                txtID.ReadOnly = true;//数据编号combProductNameTP.Enabled = true ;//产品名称
                txtV40.ReadOnly = false;//V40
                txtV100.ReadOnly = false;//V100
                txtVI.ReadOnly = false;//粘度指数
                txtAV.ReadOnly = false;//酸值
                txtASTM.ReadOnly = false;//色度
                txtOthers.ReadOnly = false;//其他
                dtGetSampleTime.Enabled = true;//采样时间
                combGetSamLocationTP.Enabled = true;//采样地点
                combGetSampPersonTP.Enabled = true;//采样人
                combTestPersonTP.Enabled = true;//检测人
                dtUpdateTime.Enabled = true;//更新时间
                txtRemark.ReadOnly = false;//备注
            }
        }
        private void SetControlReadOnly()
        {
            //直接设置为只读
            if (CutShowMode == FormShowMode.ContinueDisplay || CutShowMode == FormShowMode.DisplayCurrent)
            {
                btnOK.Enabled = true;
                btnOK.Text = "修改";
            }
            if (CutShowMode == FormShowMode.ReadOnlyForOne || CutShowMode == FormShowMode.ReadOnlyForAll)
            {
                btnOK.Enabled = false;
            }
            txtID.ReadOnly = true;//数据编号
            combProductNameTP.Enabled = false;//产品名称
            txtV40.ReadOnly = true;//V40
            txtV100.ReadOnly = true;//V100
            txtVI.ReadOnly = true;//粘度指数
            txtAV.ReadOnly = true;//酸值
            txtASTM.ReadOnly = true;//色度
            txtOthers.ReadOnly = true;//其他
            dtGetSampleTime.Enabled = false;//采样时间
            combGetSamLocationTP.Enabled = false;//采样地点
            combGetSampPersonTP.Enabled = false;//采样人
            combTestPersonTP.Enabled = false;//检测人
            dtUpdateTime.Enabled = false;//更新时间
            txtRemark.ReadOnly = true;//备注
        }
        #endregion

        #region 绑定数据

        /// <summary>
        /// 加载子窗口:if(Field.PrimaryKey) continue;
        /// </summary>
        private void BandingData()
        {
            txtID.DataBindings.Clear();//数据编号
            txtID.DataBindings.Add("Text", CutModel, "ID");
            combProductNameTP.DataBindings.Clear();//产品名称
            combProductNameTP.DataBindings.Add("Text", CutModel, "ProductNameTP");
            txtV40.DataBindings.Clear();//V40
            txtV40.DataBindings.Add("Text", CutModel, "V40");
            txtV100.DataBindings.Clear();//V100
            txtV100.DataBindings.Add("Text", CutModel, "V100");
            txtVI.DataBindings.Clear();//粘度指数
            txtVI.DataBindings.Add("Text", CutModel, "VI");
            txtAV.DataBindings.Clear();//酸值
            txtAV.DataBindings.Add("Text", CutModel, "AV");
            txtASTM.DataBindings.Clear();//色度
            txtASTM.DataBindings.Add("Text", CutModel, "ASTM");
            txtOthers.DataBindings.Clear();//其他
            txtOthers.DataBindings.Add("Text", CutModel, "Others");
            dtGetSampleTime.DataBindings.Clear();//采样时间
            dtGetSampleTime.DataBindings.Add("Value", CutModel, "GetSampleTime");
            combGetSamLocationTP.DataBindings.Clear();//采样地点
            combGetSamLocationTP.DataBindings.Add("Text", CutModel, "GetSamLocationTP");
            combGetSampPersonTP.DataBindings.Clear();//采样人
            combGetSampPersonTP.DataBindings.Add("Text", CutModel, "GetSampPersonTP");
            combTestPersonTP.DataBindings.Clear();//检测人
            combTestPersonTP.DataBindings.Add("Text", CutModel, "TestPersonTP");
            dtUpdateTime.DataBindings.Clear();//更新时间
            dtUpdateTime.DataBindings.Add("Value", CutModel, "UpdateTime");
            txtRemark.DataBindings.Clear();//备注
            txtRemark.DataBindings.Add("Text", CutModel, "Remark");
        }
        #endregion
    }
}