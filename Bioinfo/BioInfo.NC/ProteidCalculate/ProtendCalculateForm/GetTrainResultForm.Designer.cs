namespace ProtendCalculateForm
{
    partial class GetTrainResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combName = new System.Windows.Forms.ComboBox();
            this.gpbFolder = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.btnAllOK = new System.Windows.Forms.Button();
            this.folderBrow = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.gpbFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combName);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 76);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择特征提取算法";
            // 
            // combName
            // 
            this.combName.FormattingEnabled = true;
            this.combName.Items.AddRange(new object[] {
            "Ace-Pred",
            "DLMLA",
            "PMeS",
            "PredSulSite",
            "WSM-Plam"});
            this.combName.Location = new System.Drawing.Point(97, 32);
            this.combName.Name = "combName";
            this.combName.Size = new System.Drawing.Size(179, 22);
            this.combName.TabIndex = 0;
            // 
            // gpbFolder
            // 
            this.gpbFolder.Controls.Add(this.button1);
            this.gpbFolder.Controls.Add(this.txtFolderPath);
            this.gpbFolder.Controls.Add(this.label11);
            this.gpbFolder.Controls.Add(this.btnResetAll);
            this.gpbFolder.Controls.Add(this.btnAllOK);
            this.gpbFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbFolder.Location = new System.Drawing.Point(12, 98);
            this.gpbFolder.Name = "gpbFolder";
            this.gpbFolder.Size = new System.Drawing.Size(418, 122);
            this.gpbFolder.TabIndex = 14;
            this.gpbFolder.TabStop = false;
            this.gpbFolder.Text = "设置批量处理的数据源";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(78, 28);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(269, 23);
            this.txtFolderPath.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "选择数据:";
            // 
            // btnResetAll
            // 
            this.btnResetAll.Location = new System.Drawing.Point(229, 77);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(79, 25);
            this.btnResetAll.TabIndex = 2;
            this.btnResetAll.Text = "重置";
            this.btnResetAll.UseVisualStyleBackColor = true;
            // 
            // btnAllOK
            // 
            this.btnAllOK.Location = new System.Drawing.Point(116, 77);
            this.btnAllOK.Name = "btnAllOK";
            this.btnAllOK.Size = new System.Drawing.Size(79, 25);
            this.btnAllOK.TabIndex = 1;
            this.btnAllOK.Text = "计算";
            this.btnAllOK.UseVisualStyleBackColor = true;
            this.btnAllOK.Click += new System.EventHandler(this.btnAllOK_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // GetTrainResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 229);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbFolder);
            this.Name = "GetTrainResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算训练集特征值";
            this.groupBox2.ResumeLayout(false);
            this.gpbFolder.ResumeLayout(false);
            this.gpbFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpbFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.Button btnAllOK;
        private System.Windows.Forms.ComboBox combName;
        private System.Windows.Forms.FolderBrowserDialog folderBrow;
        private System.Windows.Forms.OpenFileDialog OpenFile;
    }
}