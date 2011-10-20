namespace YoungRunLab.Forms
{
    partial class AddOilDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilDataForm));
            this.addOilData1 = new YoungRunLab.Controls.AddOilData();
            this.SuspendLayout();
            // 
            // addOilData1
            // 
            this.addOilData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOilData1.IsNext = false;
            this.addOilData1.Location = new System.Drawing.Point(0, 0);
            this.addOilData1.Name = "addOilData1";
            this.addOilData1.Size = new System.Drawing.Size(291, 451);
            this.addOilData1.TabIndex = 0;
            // 
            // AddOilDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 451);
            this.Controls.Add(this.addOilData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOilDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加油品全套检测数据";
            this.ResumeLayout(false);

        }
        private YoungRunLab.Controls.AddOilData addOilData1;

        #endregion
    }
}