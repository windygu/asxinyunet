namespace YoungRunLab.Forms
{
    partial class AddTankTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTankTestForm));
            this.addTankTest1 = new YoungRunLab.Controls.AddTankTest();
            this.SuspendLayout();
            // 
            // addTankTest1
            // 
            this.addTankTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addTankTest1.Location = new System.Drawing.Point(0, 0);
            this.addTankTest1.Name = "addTankTest1";
            this.addTankTest1.Size = new System.Drawing.Size(259, 280);
            this.addTankTest1.TabIndex = 0;
            // 
            // AddTankTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 280);
            this.Controls.Add(this.addTankTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTankTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加油罐检测数据";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddTankTest addTankTest1;
    }
}