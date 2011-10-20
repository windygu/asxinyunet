using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity;

namespace YoungRunLab.Controls
{
	public partial class AddDicKey : UserControl
	{
		public AddDicKey()
		{
			InitializeComponent();
			IsFlag = false ;
			if (!DesignMode ) {
				combTypeName.Items.AddRange (YoungRunHelper.GetEnumFields<YoungRunDicType >()) ;
			}
		}
		bool IsFlag ;
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (combTypeName.Text !=""&& txtValue.Text !="")
			{
				tb_dictype model = new tb_dictype();
				string str = combTypeName .Text.Trim () ;
				int fir = str.IndexOf ('(')+1 ;
				int last = str.IndexOf (')') ;
				model.TypeName = str.Substring (fir,last-fir) ;
				model.Value = txtValue.Text.Trim();
				model.Remark = txtRemark.Text.Trim();
				model.Insert();
				IsFlag = true ;
				MessageBox.Show ("添加成功") ;
				AddDicKey_Load(sender, e);
			}
		}

		private void AddDicKey_Load(object sender, EventArgs e)
		{
			combTypeName.Text = "";
			txtValue.Text = "";
			txtRemark.Text = "";
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;
			else
				this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close();
		}
	}
}