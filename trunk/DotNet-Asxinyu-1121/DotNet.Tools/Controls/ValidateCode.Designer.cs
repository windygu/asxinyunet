namespace DotNet.Tools.Controls 
{
    partial class ValidateCode
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.SuspendLayout();
            // 
            // picCode
            // 
            this.picCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCode.Location = new System.Drawing.Point(0, 0);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(52, 22);
            this.picCode.TabIndex = 0;
            this.picCode.TabStop = false;
            this.toolTip1.SetToolTip(this.picCode, "点击重新生成验证码");
            this.picCode.Click += new System.EventHandler(this.picCode_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示：";
            // 
            // ValidateCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picCode);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ValidateCode";
            this.Size = new System.Drawing.Size(52, 22);
            this.Load += new System.EventHandler(this.ValidateCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
