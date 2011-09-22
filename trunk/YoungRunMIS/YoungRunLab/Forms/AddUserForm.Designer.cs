namespace YoungRunLab.Forms
{
    partial class AddUserForm
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
            this.addUser1 = new YoungRunLab.Controls.AddUser();
            this.SuspendLayout();
            // 
            // addUser1
            // 
            this.addUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addUser1.Location = new System.Drawing.Point(0, 0);
            this.addUser1.Name = "addUser1";
            this.addUser1.Size = new System.Drawing.Size(360, 166);
            this.addUser1.TabIndex = 0;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 166);
            this.Controls.Add(this.addUser1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddUser addUser1;
    }
}