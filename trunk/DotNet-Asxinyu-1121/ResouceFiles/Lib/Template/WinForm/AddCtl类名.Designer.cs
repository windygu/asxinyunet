<#@ import namespace="XCode.DataAccessLayer" #><#@ import namespace="XCode.Configuration" #><#@ import namespace="XCode" #>namespace <#=Config.NameSpace#>
{
    partial class AddForm<#=Table.Name#>
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
			<#foreach(IDataColumn Field in Table.Columns) 
			{
            if(Field.PrimaryKey) continue;
            TypeCode code = Type.GetTypeCode(Field.DataType);#>
			<#if(code == TypeCode.DateTime){#>this.txt<#=Field.Alias#> = new System.Windows.Forms.DateTimePicker();
			<#}else{#>this.txt<#=Field.Alias#> = new EntLib.Controls.WinForm.ExtTextBox();
			<#}#>this.lbl<#=Field.Alias#> = new System.Windows.Forms.Label();<#}#>
			this.BaseFormTopPanel.SuspendLayout();
			this.BaseFormGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(89, 17);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(173, 17);
			// 
			// BaseFormTopPanel
			// 

			<#foreach(IDataColumn Field in Table.Columns) 
			{
            if(Field.PrimaryKey) continue;
            TypeCode code = Type.GetTypeCode(Field.DataType);#>
			this.BaseFormTopPanel.Controls.Add(this.txt<#=Field.Alias#>);
			this.BaseFormTopPanel.Controls.Add(this.lbl<#=Field.Alias#>);<#}#>

			this.BaseFormTopPanel.Size = new System.Drawing.Size(475, 257);
			// 
			// BtnSave
			// 
			this.BtnSave.Location = new System.Drawing.Point(257, 17);
			// 
			// BtnSure
			// 
			this.BtnSure.Location = new System.Drawing.Point(332, 17);
			// 
			// BaseFormGroupBox
			// 
			this.BaseFormGroupBox.Location = new System.Drawing.Point(0, 257);
			this.BaseFormGroupBox.Size = new System.Drawing.Size(475, 50);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(402, 17);

			<#Int32 i=0;#>
			<#Int32 tmpBasePos=10;#>
			<#foreach(IDataColumn Field in Table.Columns) 
			{
            if(Field.PrimaryKey) continue;
            TypeCode code = Type.GetTypeCode(Field.DataType);#>

			// 
			// lbl<#=Field.Alias#>
			// 
			<#tmpBasePos=10 + i*27;#>
			<#i=i + 1;#>
			this.lbl<#=Field.Alias#>.AutoSize = true;
			this.lbl<#=Field.Alias#>.Location = new System.Drawing.Point(48, <#=tmpBasePos#>);
			this.lbl<#=Field.Alias#>.Name = "lbl<#=Field.Alias#>";
			this.lbl<#=Field.Alias#>.Size = new System.Drawing.Size(41, 12);
			this.lbl<#=Field.Alias#>.TabIndex = 0;
			this.lbl<#=Field.Alias#>.Text = "<#=Field.Description#>";

			// 
			// txt<#=Field.Alias#> 
			// 
			<#if(code == TypeCode.DateTime){#>
			this.txt<#=Field.Alias#>.Location = new System.Drawing.Point(130, <#=tmpBasePos#>);
			this.txt<#=Field.Alias#>.Name = "dateTimePicker1";
			this.txt<#=Field.Alias#>.Size = new System.Drawing.Size(127, 21);
			this.txt<#=Field.Alias#>.TabIndex = 2;
			<#}else{#>
			<#if(code == TypeCode.String){#>this.txt<#=Field.Alias#>.InputType = EntLib.Controls.WinForm.ExtTextBox.ExtTextBoxType.String;
			<#}else if(code == TypeCode.Int32){#>this.txt<#=Field.Alias#>.InputType = EntLib.Controls.WinForm.ExtTextBox.ExtTextBoxType.Integer;
			<#}else{#>this.txt<#=Field.Alias#>.InputType = EntLib.Controls.WinForm.ExtTextBox.ExtTextBoxType.String;<#}#>
			this.txt<#=Field.Alias#>.Location = new System.Drawing.Point(130, <#=tmpBasePos#>);
			this.txt<#=Field.Alias#>.Name = "txt<#=Field.Alias#>";
			this.txt<#=Field.Alias#>.Size = new System.Drawing.Size(100, 21);
			this.txt<#=Field.Alias#>.TabIndex = 1;
			<#}#>
			<#}#>

			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(475, 307);
			this.MaximizeBox = false;
			this.Name = "AddForm<#=Table.Name#>";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "<#=Table.Description#>";
			this.BaseFormTopPanel.ResumeLayout(false);
			this.BaseFormTopPanel.PerformLayout();
			this.BaseFormGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

        }


        #endregion
		<#foreach(IDataColumn Field in Table.Columns) 
		{ 
			if(Field.PrimaryKey) continue;
			TypeCode code = Type.GetTypeCode(Field.DataType);#>
		<#if(code == TypeCode.DateTime){#>private System.Windows.Forms.DateTimePicker txt<#=Field.Alias#>;
		<#}else{#>private EntLib.Controls.WinForm.ExtTextBox txt<#=Field.Alias#>;
		<#}#>private System.Windows.Forms.Label lbl<#=Field.Alias#>;<#}#>
    }
}
