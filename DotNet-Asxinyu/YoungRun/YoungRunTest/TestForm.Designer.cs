namespace YoungRunTest
{
    partial class TestForm
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
            this.addBtTestData1 = new YoungRunControl.Controls.AddBtTestData();
            this.SuspendLayout();
            // 
            // addBtTestData1
            // 
            this.addBtTestData1.CutModel = null;
            this.addBtTestData1.CutSearchCondition = null;
            this.addBtTestData1.CutShowMode = DotNet.Tools.Controls.FormShowMode.ContinueAdd;
            this.addBtTestData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtTestData1.FixedSqlCondition = null;
            this.addBtTestData1.Location = new System.Drawing.Point(0, 0);
            this.addBtTestData1.Name = "addBtTestData1";
            this.addBtTestData1.Size = new System.Drawing.Size(398, 321);
            this.addBtTestData1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 321);
            this.Controls.Add(this.addBtTestData1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private YoungRunControl.Controls.AddBtTestData addBtTestData1;
    }
}