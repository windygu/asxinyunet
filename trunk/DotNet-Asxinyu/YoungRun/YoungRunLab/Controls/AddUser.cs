using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity;
using DotNet.Tools.Controls;

namespace YoungRunLab.Controls
{
	public partial class AddUser : UserControl
	{
		public AddUser()
		{
			InitializeComponent();
			combDepart.SelectedIndex = 0;
			IsFlag = false ;
		}
		bool IsFlag ;
		private void btn_Click(object sender, EventArgs e)
		{
			if (txtUserID.Text =="" || txtPwd.Text  =="")
			{
				return;
			}
			tb_user userModel = new tb_user();
			userModel.UserName = txtUserID.Text.Trim();
			userModel.PassWord = txtPwd.Text.Trim().GetHashCode().ToString ();
			userModel.Name = txtName.Text.Trim();
			userModel.Remark = txtRemark.Text.Trim();
			userModel.Tel = txtLink.Text.Trim();
			userModel.DepartMent = combDepart.Text.Trim();
			userModel.Insert();
			IsFlag = true ;
			MessageBox.Show ("添加成功") ;
			AddUserLoad(sender, e);
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;
			else
				this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close () ;
		}
		
		void AddUserLoad(object sender, EventArgs e)
		{
            WinFormHelper.ResetFormControls(sender, e, this);
		}
	}
}
