namespace YoungRunLab.Forms
{
    partial class AddBtTestDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBtTestDataForm));
            this.addBtTestData1 = new YoungRunLab.Controls.AddBtTestData();
            this.SuspendLayout();
            // 
            // addBtTestData1
            // 
            this.addBtTestData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtTestData1.Location = new System.Drawing.Point(0, 0);
            this.addBtTestData1.Name = "addBtTestData1";
            this.addBtTestData1.Size = new System.Drawing.Size(437, 308);
            this.addBtTestData1.TabIndex = 0;
            // 
            // AddBtTestDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 308);
            this.Controls.Add(this.addBtTestData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBtTestDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "白土车间检测";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddBtTestData addBtTestData1;
    }
}