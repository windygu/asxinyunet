namespace YoungRunST.Forms
{
    partial class AddOilTankSTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilTankSTForm));
            this.addOilTankST1 = new YoungRunST.Controls.AddOilTankST();
            this.SuspendLayout();
            // 
            // addOilTankST1
            // 
            this.addOilTankST1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOilTankST1.Location = new System.Drawing.Point(0, 0);
            this.addOilTankST1.Name = "addOilTankST1";
            this.addOilTankST1.Size = new System.Drawing.Size(242, 489);
            this.addOilTankST1.TabIndex = 0;
            // 
            // AddOilTankSTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 489);
            this.Controls.Add(this.addOilTankST1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOilTankSTForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加油罐测量数据";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddOilTankST addOilTankST1;
    }
}