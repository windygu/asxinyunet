namespace YoungRunST.Forms
{
    partial class AddOilTankInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilTankInfoForm));
            this.addOilTankInfo1 = new YoungRunST.Controls.AddOilTankInfo();
            this.SuspendLayout();
            // 
            // addOilTankInfo1
            // 
            this.addOilTankInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOilTankInfo1.Location = new System.Drawing.Point(0, 0);
            this.addOilTankInfo1.Model = null;
            this.addOilTankInfo1.ModelList = null;
            this.addOilTankInfo1.Name = "addOilTankInfo1";
            this.addOilTankInfo1.Size = new System.Drawing.Size(223, 310);
            this.addOilTankInfo1.TabIndex = 0;
            // 
            // AddOilTankInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 310);
            this.Controls.Add(this.addOilTankInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOilTankInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加油罐信息";
            this.ResumeLayout(false);

        }
        private YoungRunST.Controls.AddOilTankInfo addOilTankInfo1;

        #endregion

    }
}