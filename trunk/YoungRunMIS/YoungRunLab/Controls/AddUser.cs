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
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
            combDepart.SelectedIndex = 0;
        }

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
            userModel.Save();
            this.ParentForm.DialogResult = DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }
    }
}
