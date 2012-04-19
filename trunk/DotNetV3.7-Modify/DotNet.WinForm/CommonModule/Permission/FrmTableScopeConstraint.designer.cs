namespace DotNet.WinForm
{
    partial class FrmTableScopeConstraint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableScopeConstraint));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCondition0 = new System.Windows.Forms.ComboBox();
            this.cmbCondition1 = new System.Windows.Forms.ComboBox();
            this.cmbCondition2 = new System.Windows.Forms.ComboBox();
            this.cmbCondition3 = new System.Windows.Forms.ComboBox();
            this.cmbCondition4 = new System.Windows.Forms.ComboBox();
            this.cmbColumn4 = new System.Windows.Forms.ComboBox();
            this.cmbColumn3 = new System.Windows.Forms.ComboBox();
            this.cmbColumn2 = new System.Windows.Forms.ComboBox();
            this.cmbColumn1 = new System.Windows.Forms.ComboBox();
            this.cmbColumn0 = new System.Windows.Forms.ComboBox();
            this.txtValue0 = new System.Windows.Forms.TextBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTestConstraint = new System.Windows.Forms.Button();
            this.txtParameterReference = new System.Windows.Forms.TextBox();
            this.lblParameterReference = new System.Windows.Forms.Label();
            this.lblSetConstraint = new System.Windows.Forms.Label();
            this.cmbValue0 = new System.Windows.Forms.ComboBox();
            this.cmbValue1 = new System.Windows.Forms.ComboBox();
            this.cmbValue2 = new System.Windows.Forms.ComboBox();
            this.cmbValue3 = new System.Windows.Forms.ComboBox();
            this.cmbValue4 = new System.Windows.Forms.ComboBox();
            this.lblConstraint = new System.Windows.Forms.Label();
            this.txtTableConstraint = new System.Windows.Forms.TextBox();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.cmbAnd0 = new System.Windows.Forms.ComboBox();
            this.cmbAnd1 = new System.Windows.Forms.ComboBox();
            this.cmbAnd2 = new System.Windows.Forms.ComboBox();
            this.cmbAnd3 = new System.Windows.Forms.ComboBox();
            this.cmbRightBrackets0 = new System.Windows.Forms.ComboBox();
            this.cmbRightBrackets1 = new System.Windows.Forms.ComboBox();
            this.cmbRightBrackets3 = new System.Windows.Forms.ComboBox();
            this.cmbRightBrackets2 = new System.Windows.Forms.ComboBox();
            this.cmbRightBrackets4 = new System.Windows.Forms.ComboBox();
            this.cmbLeftBrackets4 = new System.Windows.Forms.ComboBox();
            this.cmbLeftBrackets3 = new System.Windows.Forms.ComboBox();
            this.cmbLeftBrackets2 = new System.Windows.Forms.ComboBox();
            this.cmbLeftBrackets1 = new System.Windows.Forms.ComboBox();
            this.cmbLeftBrackets0 = new System.Windows.Forms.ComboBox();
            this.txtUserOrRole = new System.Windows.Forms.TextBox();
            this.lblUserOrRole = new System.Windows.Forms.Label();
            this.btnShowConstraint = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(611, 338);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(532, 338);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCondition0
            // 
            this.cmbCondition0.DisplayMember = "ItemName";
            this.cmbCondition0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition0.FormattingEnabled = true;
            this.cmbCondition0.Location = new System.Drawing.Point(247, 130);
            this.cmbCondition0.Name = "cmbCondition0";
            this.cmbCondition0.Size = new System.Drawing.Size(93, 20);
            this.cmbCondition0.TabIndex = 9;
            this.cmbCondition0.ValueMember = "ItemValue";
            // 
            // cmbCondition1
            // 
            this.cmbCondition1.DisplayMember = "ItemName";
            this.cmbCondition1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition1.FormattingEnabled = true;
            this.cmbCondition1.Location = new System.Drawing.Point(247, 161);
            this.cmbCondition1.Name = "cmbCondition1";
            this.cmbCondition1.Size = new System.Drawing.Size(93, 20);
            this.cmbCondition1.TabIndex = 15;
            this.cmbCondition1.ValueMember = "ItemValue";
            // 
            // cmbCondition2
            // 
            this.cmbCondition2.DisplayMember = "ItemName";
            this.cmbCondition2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition2.FormattingEnabled = true;
            this.cmbCondition2.Location = new System.Drawing.Point(247, 193);
            this.cmbCondition2.Name = "cmbCondition2";
            this.cmbCondition2.Size = new System.Drawing.Size(93, 20);
            this.cmbCondition2.TabIndex = 21;
            this.cmbCondition2.ValueMember = "ItemValue";
            // 
            // cmbCondition3
            // 
            this.cmbCondition3.DisplayMember = "ItemName";
            this.cmbCondition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition3.FormattingEnabled = true;
            this.cmbCondition3.Location = new System.Drawing.Point(247, 223);
            this.cmbCondition3.Name = "cmbCondition3";
            this.cmbCondition3.Size = new System.Drawing.Size(93, 20);
            this.cmbCondition3.TabIndex = 27;
            this.cmbCondition3.ValueMember = "ItemValue";
            // 
            // cmbCondition4
            // 
            this.cmbCondition4.DisplayMember = "ItemName";
            this.cmbCondition4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition4.FormattingEnabled = true;
            this.cmbCondition4.Location = new System.Drawing.Point(247, 255);
            this.cmbCondition4.Name = "cmbCondition4";
            this.cmbCondition4.Size = new System.Drawing.Size(93, 20);
            this.cmbCondition4.TabIndex = 33;
            this.cmbCondition4.ValueMember = "ItemValue";
            // 
            // cmbColumn4
            // 
            this.cmbColumn4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn4.FormattingEnabled = true;
            this.cmbColumn4.Location = new System.Drawing.Point(55, 255);
            this.cmbColumn4.Name = "cmbColumn4";
            this.cmbColumn4.Size = new System.Drawing.Size(187, 20);
            this.cmbColumn4.TabIndex = 32;
            this.cmbColumn4.SelectedIndexChanged += new System.EventHandler(this.cmbColumnSelectedIndexChanged);
            // 
            // cmbColumn3
            // 
            this.cmbColumn3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn3.FormattingEnabled = true;
            this.cmbColumn3.Location = new System.Drawing.Point(55, 223);
            this.cmbColumn3.Name = "cmbColumn3";
            this.cmbColumn3.Size = new System.Drawing.Size(187, 20);
            this.cmbColumn3.TabIndex = 26;
            this.cmbColumn3.SelectedIndexChanged += new System.EventHandler(this.cmbColumnSelectedIndexChanged);
            // 
            // cmbColumn2
            // 
            this.cmbColumn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn2.FormattingEnabled = true;
            this.cmbColumn2.Location = new System.Drawing.Point(55, 193);
            this.cmbColumn2.Name = "cmbColumn2";
            this.cmbColumn2.Size = new System.Drawing.Size(187, 20);
            this.cmbColumn2.TabIndex = 20;
            this.cmbColumn2.SelectedIndexChanged += new System.EventHandler(this.cmbColumnSelectedIndexChanged);
            // 
            // cmbColumn1
            // 
            this.cmbColumn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn1.FormattingEnabled = true;
            this.cmbColumn1.Location = new System.Drawing.Point(55, 161);
            this.cmbColumn1.Name = "cmbColumn1";
            this.cmbColumn1.Size = new System.Drawing.Size(187, 20);
            this.cmbColumn1.TabIndex = 14;
            this.cmbColumn1.SelectedIndexChanged += new System.EventHandler(this.cmbColumnSelectedIndexChanged);
            // 
            // cmbColumn0
            // 
            this.cmbColumn0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn0.FormattingEnabled = true;
            this.cmbColumn0.Location = new System.Drawing.Point(55, 130);
            this.cmbColumn0.Name = "cmbColumn0";
            this.cmbColumn0.Size = new System.Drawing.Size(187, 20);
            this.cmbColumn0.TabIndex = 8;
            this.cmbColumn0.SelectedIndexChanged += new System.EventHandler(this.cmbColumnSelectedIndexChanged);
            // 
            // txtValue0
            // 
            this.txtValue0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue0.Location = new System.Drawing.Point(347, 130);
            this.txtValue0.Name = "txtValue0";
            this.txtValue0.Size = new System.Drawing.Size(221, 21);
            this.txtValue0.TabIndex = 7;
            // 
            // txtValue1
            // 
            this.txtValue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue1.Location = new System.Drawing.Point(347, 161);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(221, 21);
            this.txtValue1.TabIndex = 14;
            // 
            // txtValue2
            // 
            this.txtValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue2.Location = new System.Drawing.Point(347, 193);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(221, 21);
            this.txtValue2.TabIndex = 21;
            // 
            // txtValue3
            // 
            this.txtValue3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue3.Location = new System.Drawing.Point(347, 223);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(221, 21);
            this.txtValue3.TabIndex = 28;
            // 
            // txtValue4
            // 
            this.txtValue4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue4.Location = new System.Drawing.Point(347, 255);
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.Size = new System.Drawing.Size(221, 21);
            this.txtValue4.TabIndex = 35;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(126, 338);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "清除表达式";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTestConstraint
            // 
            this.btnTestConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConstraint.Enabled = false;
            this.btnTestConstraint.Location = new System.Drawing.Point(10, 338);
            this.btnTestConstraint.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConstraint.Name = "btnTestConstraint";
            this.btnTestConstraint.Size = new System.Drawing.Size(111, 23);
            this.btnTestConstraint.TabIndex = 39;
            this.btnTestConstraint.Text = "验证表达式";
            this.btnTestConstraint.UseVisualStyleBackColor = true;
            this.btnTestConstraint.Click += new System.EventHandler(this.btnTestCondition_Click);
            // 
            // txtParameterReference
            // 
            this.txtParameterReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameterReference.Location = new System.Drawing.Point(16, 322);
            this.txtParameterReference.Multiline = true;
            this.txtParameterReference.Name = "txtParameterReference";
            this.txtParameterReference.ReadOnly = true;
            this.txtParameterReference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParameterReference.Size = new System.Drawing.Size(673, 0);
            this.txtParameterReference.TabIndex = 38;
            this.txtParameterReference.Text = resources.GetString("txtParameterReference.Text");
            // 
            // lblParameterReference
            // 
            this.lblParameterReference.AutoSize = true;
            this.lblParameterReference.Location = new System.Drawing.Point(19, 297);
            this.lblParameterReference.Name = "lblParameterReference";
            this.lblParameterReference.Size = new System.Drawing.Size(65, 12);
            this.lblParameterReference.TabIndex = 36;
            this.lblParameterReference.Text = "参数参考：";
            // 
            // lblSetConstraint
            // 
            this.lblSetConstraint.AutoSize = true;
            this.lblSetConstraint.Location = new System.Drawing.Point(15, 106);
            this.lblSetConstraint.Name = "lblSetConstraint";
            this.lblSetConstraint.Size = new System.Drawing.Size(65, 12);
            this.lblSetConstraint.TabIndex = 6;
            this.lblSetConstraint.Text = "设定约束：";
            // 
            // cmbValue0
            // 
            this.cmbValue0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue0.DisplayMember = "ItemName";
            this.cmbValue0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue0.FormattingEnabled = true;
            this.cmbValue0.Location = new System.Drawing.Point(347, 130);
            this.cmbValue0.Name = "cmbValue0";
            this.cmbValue0.Size = new System.Drawing.Size(220, 20);
            this.cmbValue0.TabIndex = 10;
            this.cmbValue0.ValueMember = "ItemValue";
            this.cmbValue0.Visible = false;
            // 
            // cmbValue1
            // 
            this.cmbValue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue1.DisplayMember = "ItemName";
            this.cmbValue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue1.FormattingEnabled = true;
            this.cmbValue1.Location = new System.Drawing.Point(347, 161);
            this.cmbValue1.Name = "cmbValue1";
            this.cmbValue1.Size = new System.Drawing.Size(220, 20);
            this.cmbValue1.TabIndex = 16;
            this.cmbValue1.ValueMember = "ItemValue";
            this.cmbValue1.Visible = false;
            // 
            // cmbValue2
            // 
            this.cmbValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue2.DisplayMember = "ItemName";
            this.cmbValue2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue2.FormattingEnabled = true;
            this.cmbValue2.Location = new System.Drawing.Point(347, 193);
            this.cmbValue2.Name = "cmbValue2";
            this.cmbValue2.Size = new System.Drawing.Size(220, 20);
            this.cmbValue2.TabIndex = 22;
            this.cmbValue2.ValueMember = "ItemValue";
            this.cmbValue2.Visible = false;
            // 
            // cmbValue3
            // 
            this.cmbValue3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue3.DisplayMember = "ItemName";
            this.cmbValue3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue3.FormattingEnabled = true;
            this.cmbValue3.Location = new System.Drawing.Point(347, 223);
            this.cmbValue3.Name = "cmbValue3";
            this.cmbValue3.Size = new System.Drawing.Size(220, 20);
            this.cmbValue3.TabIndex = 28;
            this.cmbValue3.ValueMember = "ItemValue";
            this.cmbValue3.Visible = false;
            // 
            // cmbValue4
            // 
            this.cmbValue4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue4.DisplayMember = "ItemName";
            this.cmbValue4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue4.FormattingEnabled = true;
            this.cmbValue4.Location = new System.Drawing.Point(347, 255);
            this.cmbValue4.Name = "cmbValue4";
            this.cmbValue4.Size = new System.Drawing.Size(220, 20);
            this.cmbValue4.TabIndex = 34;
            this.cmbValue4.ValueMember = "ItemValue";
            this.cmbValue4.Visible = false;
            // 
            // lblConstraint
            // 
            this.lblConstraint.AutoSize = true;
            this.lblConstraint.Location = new System.Drawing.Point(15, 41);
            this.lblConstraint.Name = "lblConstraint";
            this.lblConstraint.Size = new System.Drawing.Size(65, 12);
            this.lblConstraint.TabIndex = 3;
            this.lblConstraint.Text = "约束条件：";
            // 
            // txtTableConstraint
            // 
            this.txtTableConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableConstraint.Location = new System.Drawing.Point(16, 59);
            this.txtTableConstraint.Multiline = true;
            this.txtTableConstraint.Name = "txtTableConstraint";
            this.txtTableConstraint.ReadOnly = true;
            this.txtTableConstraint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTableConstraint.Size = new System.Drawing.Size(673, 36);
            this.txtTableConstraint.TabIndex = 4;
            // 
            // btnShowHide
            // 
            this.btnShowHide.Location = new System.Drawing.Point(90, 292);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(115, 23);
            this.btnShowHide.TabIndex = 37;
            this.btnShowHide.Text = "显示   ▽";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // cmbAnd0
            // 
            this.cmbAnd0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnd0.DisplayMember = "ItemName";
            this.cmbAnd0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnd0.FormattingEnabled = true;
            this.cmbAnd0.Items.AddRange(new object[] {
            "",
            "and",
            "or"});
            this.cmbAnd0.Location = new System.Drawing.Point(618, 130);
            this.cmbAnd0.Name = "cmbAnd0";
            this.cmbAnd0.Size = new System.Drawing.Size(68, 20);
            this.cmbAnd0.TabIndex = 12;
            this.cmbAnd0.ValueMember = "ItemValue";
            // 
            // cmbAnd1
            // 
            this.cmbAnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnd1.DisplayMember = "ItemName";
            this.cmbAnd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnd1.FormattingEnabled = true;
            this.cmbAnd1.Items.AddRange(new object[] {
            "",
            "and",
            "or"});
            this.cmbAnd1.Location = new System.Drawing.Point(618, 161);
            this.cmbAnd1.Name = "cmbAnd1";
            this.cmbAnd1.Size = new System.Drawing.Size(68, 20);
            this.cmbAnd1.TabIndex = 18;
            this.cmbAnd1.ValueMember = "ItemValue";
            // 
            // cmbAnd2
            // 
            this.cmbAnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnd2.DisplayMember = "ItemName";
            this.cmbAnd2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnd2.FormattingEnabled = true;
            this.cmbAnd2.Items.AddRange(new object[] {
            "",
            "and",
            "or"});
            this.cmbAnd2.Location = new System.Drawing.Point(618, 193);
            this.cmbAnd2.Name = "cmbAnd2";
            this.cmbAnd2.Size = new System.Drawing.Size(68, 20);
            this.cmbAnd2.TabIndex = 24;
            this.cmbAnd2.ValueMember = "ItemValue";
            // 
            // cmbAnd3
            // 
            this.cmbAnd3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnd3.DisplayMember = "ItemName";
            this.cmbAnd3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnd3.FormattingEnabled = true;
            this.cmbAnd3.Items.AddRange(new object[] {
            "",
            "and",
            "or"});
            this.cmbAnd3.Location = new System.Drawing.Point(618, 223);
            this.cmbAnd3.Name = "cmbAnd3";
            this.cmbAnd3.Size = new System.Drawing.Size(68, 20);
            this.cmbAnd3.TabIndex = 30;
            this.cmbAnd3.ValueMember = "ItemValue";
            // 
            // cmbRightBrackets0
            // 
            this.cmbRightBrackets0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRightBrackets0.DisplayMember = "ItemName";
            this.cmbRightBrackets0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightBrackets0.FormattingEnabled = true;
            this.cmbRightBrackets0.Items.AddRange(new object[] {
            "",
            ")"});
            this.cmbRightBrackets0.Location = new System.Drawing.Point(574, 130);
            this.cmbRightBrackets0.Name = "cmbRightBrackets0";
            this.cmbRightBrackets0.Size = new System.Drawing.Size(37, 20);
            this.cmbRightBrackets0.TabIndex = 11;
            this.cmbRightBrackets0.ValueMember = "ItemValue";
            // 
            // cmbRightBrackets1
            // 
            this.cmbRightBrackets1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRightBrackets1.DisplayMember = "ItemName";
            this.cmbRightBrackets1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightBrackets1.FormattingEnabled = true;
            this.cmbRightBrackets1.Items.AddRange(new object[] {
            "",
            ")"});
            this.cmbRightBrackets1.Location = new System.Drawing.Point(574, 161);
            this.cmbRightBrackets1.Name = "cmbRightBrackets1";
            this.cmbRightBrackets1.Size = new System.Drawing.Size(37, 20);
            this.cmbRightBrackets1.TabIndex = 17;
            this.cmbRightBrackets1.ValueMember = "ItemValue";
            // 
            // cmbRightBrackets3
            // 
            this.cmbRightBrackets3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRightBrackets3.DisplayMember = "ItemName";
            this.cmbRightBrackets3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightBrackets3.FormattingEnabled = true;
            this.cmbRightBrackets3.Items.AddRange(new object[] {
            "",
            ")"});
            this.cmbRightBrackets3.Location = new System.Drawing.Point(574, 223);
            this.cmbRightBrackets3.Name = "cmbRightBrackets3";
            this.cmbRightBrackets3.Size = new System.Drawing.Size(37, 20);
            this.cmbRightBrackets3.TabIndex = 29;
            this.cmbRightBrackets3.ValueMember = "ItemValue";
            // 
            // cmbRightBrackets2
            // 
            this.cmbRightBrackets2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRightBrackets2.DisplayMember = "ItemName";
            this.cmbRightBrackets2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightBrackets2.FormattingEnabled = true;
            this.cmbRightBrackets2.Items.AddRange(new object[] {
            "",
            ")"});
            this.cmbRightBrackets2.Location = new System.Drawing.Point(574, 193);
            this.cmbRightBrackets2.Name = "cmbRightBrackets2";
            this.cmbRightBrackets2.Size = new System.Drawing.Size(37, 20);
            this.cmbRightBrackets2.TabIndex = 23;
            this.cmbRightBrackets2.ValueMember = "ItemValue";
            // 
            // cmbRightBrackets4
            // 
            this.cmbRightBrackets4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRightBrackets4.DisplayMember = "ItemName";
            this.cmbRightBrackets4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightBrackets4.FormattingEnabled = true;
            this.cmbRightBrackets4.Items.AddRange(new object[] {
            "",
            ")"});
            this.cmbRightBrackets4.Location = new System.Drawing.Point(574, 255);
            this.cmbRightBrackets4.Name = "cmbRightBrackets4";
            this.cmbRightBrackets4.Size = new System.Drawing.Size(37, 20);
            this.cmbRightBrackets4.TabIndex = 35;
            this.cmbRightBrackets4.ValueMember = "ItemValue";
            // 
            // cmbLeftBrackets4
            // 
            this.cmbLeftBrackets4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeftBrackets4.DisplayMember = "ItemName";
            this.cmbLeftBrackets4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftBrackets4.FormattingEnabled = true;
            this.cmbLeftBrackets4.Items.AddRange(new object[] {
            "",
            "("});
            this.cmbLeftBrackets4.Location = new System.Drawing.Point(13, 255);
            this.cmbLeftBrackets4.Name = "cmbLeftBrackets4";
            this.cmbLeftBrackets4.Size = new System.Drawing.Size(37, 20);
            this.cmbLeftBrackets4.TabIndex = 31;
            this.cmbLeftBrackets4.ValueMember = "ItemValue";
            // 
            // cmbLeftBrackets3
            // 
            this.cmbLeftBrackets3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeftBrackets3.DisplayMember = "ItemName";
            this.cmbLeftBrackets3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftBrackets3.FormattingEnabled = true;
            this.cmbLeftBrackets3.Items.AddRange(new object[] {
            "",
            "("});
            this.cmbLeftBrackets3.Location = new System.Drawing.Point(13, 223);
            this.cmbLeftBrackets3.Name = "cmbLeftBrackets3";
            this.cmbLeftBrackets3.Size = new System.Drawing.Size(37, 20);
            this.cmbLeftBrackets3.TabIndex = 25;
            this.cmbLeftBrackets3.ValueMember = "ItemValue";
            // 
            // cmbLeftBrackets2
            // 
            this.cmbLeftBrackets2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeftBrackets2.DisplayMember = "ItemName";
            this.cmbLeftBrackets2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftBrackets2.FormattingEnabled = true;
            this.cmbLeftBrackets2.Items.AddRange(new object[] {
            "",
            "("});
            this.cmbLeftBrackets2.Location = new System.Drawing.Point(13, 193);
            this.cmbLeftBrackets2.Name = "cmbLeftBrackets2";
            this.cmbLeftBrackets2.Size = new System.Drawing.Size(37, 20);
            this.cmbLeftBrackets2.TabIndex = 19;
            this.cmbLeftBrackets2.ValueMember = "ItemValue";
            // 
            // cmbLeftBrackets1
            // 
            this.cmbLeftBrackets1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeftBrackets1.DisplayMember = "ItemName";
            this.cmbLeftBrackets1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftBrackets1.FormattingEnabled = true;
            this.cmbLeftBrackets1.Items.AddRange(new object[] {
            "",
            "("});
            this.cmbLeftBrackets1.Location = new System.Drawing.Point(13, 161);
            this.cmbLeftBrackets1.Name = "cmbLeftBrackets1";
            this.cmbLeftBrackets1.Size = new System.Drawing.Size(37, 20);
            this.cmbLeftBrackets1.TabIndex = 13;
            this.cmbLeftBrackets1.ValueMember = "ItemValue";
            // 
            // cmbLeftBrackets0
            // 
            this.cmbLeftBrackets0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLeftBrackets0.DisplayMember = "ItemName";
            this.cmbLeftBrackets0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftBrackets0.FormattingEnabled = true;
            this.cmbLeftBrackets0.Items.AddRange(new object[] {
            "",
            "("});
            this.cmbLeftBrackets0.Location = new System.Drawing.Point(13, 130);
            this.cmbLeftBrackets0.Name = "cmbLeftBrackets0";
            this.cmbLeftBrackets0.Size = new System.Drawing.Size(37, 20);
            this.cmbLeftBrackets0.TabIndex = 7;
            this.cmbLeftBrackets0.ValueMember = "ItemValue";
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserOrRole.Location = new System.Drawing.Point(113, 11);
            this.txtUserOrRole.MaxLength = 50;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(203, 21);
            this.txtUserOrRole.TabIndex = 1;
            // 
            // lblUserOrRole
            // 
            this.lblUserOrRole.Location = new System.Drawing.Point(15, 14);
            this.lblUserOrRole.Name = "lblUserOrRole";
            this.lblUserOrRole.Size = new System.Drawing.Size(95, 12);
            this.lblUserOrRole.TabIndex = 0;
            this.lblUserOrRole.Text = "用户/角色(&R)：";
            this.lblUserOrRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowConstraint
            // 
            this.btnShowConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowConstraint.Location = new System.Drawing.Point(532, 29);
            this.btnShowConstraint.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowConstraint.Name = "btnShowConstraint";
            this.btnShowConstraint.Size = new System.Drawing.Size(157, 23);
            this.btnShowConstraint.TabIndex = 5;
            this.btnShowConstraint.Text = "查看数据结果集...";
            this.btnShowConstraint.UseVisualStyleBackColor = true;
            this.btnShowConstraint.Click += new System.EventHandler(this.btnShowConstraint_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(347, 14);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "限制";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // FrmTableScopeConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(701, 368);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnShowConstraint);
            this.Controls.Add(this.txtUserOrRole);
            this.Controls.Add(this.lblUserOrRole);
            this.Controls.Add(this.cmbLeftBrackets4);
            this.Controls.Add(this.cmbLeftBrackets3);
            this.Controls.Add(this.cmbLeftBrackets2);
            this.Controls.Add(this.cmbLeftBrackets1);
            this.Controls.Add(this.cmbLeftBrackets0);
            this.Controls.Add(this.cmbRightBrackets4);
            this.Controls.Add(this.cmbRightBrackets3);
            this.Controls.Add(this.cmbRightBrackets2);
            this.Controls.Add(this.cmbRightBrackets1);
            this.Controls.Add(this.cmbRightBrackets0);
            this.Controls.Add(this.cmbAnd3);
            this.Controls.Add(this.cmbAnd2);
            this.Controls.Add(this.cmbAnd1);
            this.Controls.Add(this.cmbAnd0);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.txtTableConstraint);
            this.Controls.Add(this.lblConstraint);
            this.Controls.Add(this.cmbValue4);
            this.Controls.Add(this.cmbValue3);
            this.Controls.Add(this.cmbValue2);
            this.Controls.Add(this.cmbValue1);
            this.Controls.Add(this.cmbValue0);
            this.Controls.Add(this.lblSetConstraint);
            this.Controls.Add(this.lblParameterReference);
            this.Controls.Add(this.txtParameterReference);
            this.Controls.Add(this.btnTestConstraint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtValue4);
            this.Controls.Add(this.txtValue3);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.txtValue0);
            this.Controls.Add(this.cmbColumn4);
            this.Controls.Add(this.cmbColumn3);
            this.Controls.Add(this.cmbColumn2);
            this.Controls.Add(this.cmbColumn1);
            this.Controls.Add(this.cmbColumn0);
            this.Controls.Add(this.cmbCondition4);
            this.Controls.Add(this.cmbCondition3);
            this.Controls.Add(this.cmbCondition2);
            this.Controls.Add(this.cmbCondition1);
            this.Controls.Add(this.cmbCondition0);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmTableScopeConstraint";
            this.Text = "设置约束条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbCondition0;
        private System.Windows.Forms.ComboBox cmbCondition1;
        private System.Windows.Forms.ComboBox cmbCondition2;
        private System.Windows.Forms.ComboBox cmbCondition3;
        private System.Windows.Forms.ComboBox cmbCondition4;
        private System.Windows.Forms.ComboBox cmbColumn4;
        private System.Windows.Forms.ComboBox cmbColumn3;
        private System.Windows.Forms.ComboBox cmbColumn2;
        private System.Windows.Forms.ComboBox cmbColumn1;
        private System.Windows.Forms.ComboBox cmbColumn0;
        private System.Windows.Forms.TextBox txtValue0;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.TextBox txtValue3;
        private System.Windows.Forms.TextBox txtValue4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTestConstraint;
        private System.Windows.Forms.TextBox txtParameterReference;
        private System.Windows.Forms.Label lblParameterReference;
        private System.Windows.Forms.Label lblSetConstraint;
        private System.Windows.Forms.ComboBox cmbValue0;
        private System.Windows.Forms.ComboBox cmbValue1;
        private System.Windows.Forms.ComboBox cmbValue2;
        private System.Windows.Forms.ComboBox cmbValue3;
        private System.Windows.Forms.ComboBox cmbValue4;
        private System.Windows.Forms.Label lblConstraint;
        private System.Windows.Forms.TextBox txtTableConstraint;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.ComboBox cmbAnd0;
        private System.Windows.Forms.ComboBox cmbAnd1;
        private System.Windows.Forms.ComboBox cmbAnd2;
        private System.Windows.Forms.ComboBox cmbAnd3;
        private System.Windows.Forms.ComboBox cmbRightBrackets0;
        private System.Windows.Forms.ComboBox cmbRightBrackets1;
        private System.Windows.Forms.ComboBox cmbRightBrackets3;
        private System.Windows.Forms.ComboBox cmbRightBrackets2;
        private System.Windows.Forms.ComboBox cmbRightBrackets4;
        private System.Windows.Forms.ComboBox cmbLeftBrackets4;
        private System.Windows.Forms.ComboBox cmbLeftBrackets3;
        private System.Windows.Forms.ComboBox cmbLeftBrackets2;
        private System.Windows.Forms.ComboBox cmbLeftBrackets1;
        private System.Windows.Forms.ComboBox cmbLeftBrackets0;
        private System.Windows.Forms.TextBox txtUserOrRole;
        private System.Windows.Forms.Label lblUserOrRole;
        private System.Windows.Forms.Button btnShowConstraint;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}