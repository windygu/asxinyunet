namespace YoungRunLab.Forms
{
    partial class AddProductFormuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductFormuleForm));
            this.addProductFormule1 = new YoungRunLab.Controls.AddProductFormule();
            this.SuspendLayout();
            // 
            // addProductFormule1
            // 
            this.addProductFormule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addProductFormule1.Location = new System.Drawing.Point(0, 0);
            this.addProductFormule1.Name = "addProductFormule1";
            this.addProductFormule1.Size = new System.Drawing.Size(204, 265);
            this.addProductFormule1.TabIndex = 0;
            // 
            // AddProductFormuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 265);
            this.Controls.Add(this.addProductFormule1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductFormuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品辅料配方信息";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddProductFormule addProductFormule1;
    }
}