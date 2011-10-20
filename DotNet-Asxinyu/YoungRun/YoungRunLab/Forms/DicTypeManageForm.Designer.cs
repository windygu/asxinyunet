namespace YoungRunLab.Forms
{
    partial class DicTypeManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicTypeManageForm));
            this.dicTypeManage1 = new YoungRunLab.Controls.DicTypeManage();
            this.SuspendLayout();
            // 
            // dicTypeManage1
            // 
            this.dicTypeManage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dicTypeManage1.Location = new System.Drawing.Point(0, 0);
            this.dicTypeManage1.Name = "dicTypeManage1";
            this.dicTypeManage1.Size = new System.Drawing.Size(555, 323);
            this.dicTypeManage1.TabIndex = 0;
            // 
            // DicTypeManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 323);
            this.Controls.Add(this.dicTypeManage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DicTypeManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字典数据管理";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DicTypeManage dicTypeManage1;

    }
}