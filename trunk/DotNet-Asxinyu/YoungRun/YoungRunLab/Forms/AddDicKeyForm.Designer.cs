namespace YoungRunLab.Forms
{
    partial class AddDicKeyForm
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDicKeyForm));
        	this.addDicKey1 = new YoungRunLab.Controls.AddDicKey();
        	this.SuspendLayout();
        	// 
        	// addDicKey1
        	// 
        	this.addDicKey1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.addDicKey1.Location = new System.Drawing.Point(0, 0);
        	this.addDicKey1.Name = "addDicKey1";
        	this.addDicKey1.Size = new System.Drawing.Size(271, 130);
        	this.addDicKey1.TabIndex = 0;
        	// 
        	// AddDicKeyForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(271, 130);
        	this.Controls.Add(this.addDicKey1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "AddDicKeyForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "添加字典数据";
        	this.ResumeLayout(false);
        }

        #endregion

        private Controls.AddDicKey addDicKey1;
    }
}