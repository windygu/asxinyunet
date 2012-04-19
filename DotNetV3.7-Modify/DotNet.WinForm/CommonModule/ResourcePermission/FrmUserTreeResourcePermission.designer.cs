namespace DotNet.WinForm
{
    partial class FrmUserTreeResourcePermission
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserTreeResourcePermission));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tvTargetTreeResource = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcUser = new System.Windows.Forms.TabControl();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.tcTargetTreeResource = new System.Windows.Forms.TabControl();
            this.tpTargetTreeResource = new System.Windows.Forms.TabPage();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClearPermission = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcUser.SuspendLayout();
            this.tpUser.SuspendLayout();
            this.tcTargetTreeResource.SuspendLayout();
            this.tpTargetTreeResource.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "icon_messenger1.gif");
            this.imageList.Images.SetKeyName(16, "icon_messenger0.gif");
            this.imageList.Images.SetKeyName(17, "icon_messenger2.gif");
            this.imageList.Images.SetKeyName(18, "icon_messenger3.gif");
            this.imageList.Images.SetKeyName(19, "icon_messenger4.gif");
            this.imageList.Images.SetKeyName(20, "icon_messenger5.gif");
            this.imageList.Images.SetKeyName(21, "icon_messenger6.gif");
            // 
            // tvTargetTreeResource
            // 
            this.tvTargetTreeResource.AllowDrop = true;
            this.tvTargetTreeResource.CheckBoxes = true;
            this.tvTargetTreeResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTargetTreeResource.Enabled = false;
            this.tvTargetTreeResource.HotTracking = true;
            this.tvTargetTreeResource.ImageIndex = 0;
            this.tvTargetTreeResource.ImageList = this.imageList;
            this.tvTargetTreeResource.Location = new System.Drawing.Point(3, 3);
            this.tvTargetTreeResource.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tvTargetTreeResource.Name = "tvTargetTreeResource";
            this.tvTargetTreeResource.SelectedImageIndex = 0;
            this.tvTargetTreeResource.Size = new System.Drawing.Size(394, 390);
            this.tvTargetTreeResource.TabIndex = 1;
            this.tvTargetTreeResource.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvTargetTreeResource_AfterCheck);
            this.tvTargetTreeResource.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTargetTreeResource_NodeMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcUser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcTargetTreeResource);
            this.splitContainer1.Size = new System.Drawing.Size(665, 422);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 11;
            // 
            // tcUser
            // 
            this.tcUser.Controls.Add(this.tpUser);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(253, 422);
            this.tcUser.TabIndex = 9;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.lstUser);
            this.tpUser.Location = new System.Drawing.Point(4, 22);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(245, 396);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "用户";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // lstUser
            // 
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 12;
            this.lstUser.Location = new System.Drawing.Point(3, 3);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(239, 390);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
            // 
            // tcTargetTreeResource
            // 
            this.tcTargetTreeResource.Controls.Add(this.tpTargetTreeResource);
            this.tcTargetTreeResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTargetTreeResource.Location = new System.Drawing.Point(0, 0);
            this.tcTargetTreeResource.Name = "tcTargetTreeResource";
            this.tcTargetTreeResource.SelectedIndex = 0;
            this.tcTargetTreeResource.Size = new System.Drawing.Size(408, 422);
            this.tcTargetTreeResource.TabIndex = 9;
            // 
            // tpTargetTreeResource
            // 
            this.tpTargetTreeResource.Controls.Add(this.tvTargetTreeResource);
            this.tpTargetTreeResource.Location = new System.Drawing.Point(4, 22);
            this.tpTargetTreeResource.Name = "tpTargetTreeResource";
            this.tpTargetTreeResource.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetTreeResource.Size = new System.Drawing.Size(400, 396);
            this.tpTargetTreeResource.TabIndex = 0;
            this.tpTargetTreeResource.Text = "目标资源";
            this.tpTargetTreeResource.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Enabled = false;
            this.btnPaste.Location = new System.Drawing.Point(564, 23);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(102, 23);
            this.btnPaste.TabIndex = 29;
            this.btnPaste.Text = "粘贴权限";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(459, 23);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 28;
            this.btnCopy.Text = "复制权限";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPermission.Enabled = false;
            this.btnClearPermission.Location = new System.Drawing.Point(353, 23);
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(102, 23);
            this.btnClearPermission.TabIndex = 33;
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.UseVisualStyleBackColor = true;
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // FrmUserTreeResourcePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 487);
            this.Controls.Add(this.btnClearPermission);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmUserTreeResourcePermission";
            this.Text = "用户权限批量设置";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcUser.ResumeLayout(false);
            this.tpUser.ResumeLayout(false);
            this.tcTargetTreeResource.ResumeLayout(false);
            this.tpTargetTreeResource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvTargetTreeResource;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tcTargetTreeResource;
        private System.Windows.Forms.TabPage tpTargetTreeResource;
        private System.Windows.Forms.TabControl tcUser;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClearPermission;

    }
}