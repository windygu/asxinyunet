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
    //白土车间检测数据
    public partial class AddBtTestData : UserControl
    {
        public AddBtTestData()
        {
            InitializeComponent();
        }

        #region 限制文本框只输入数字
        private void txtV40_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '.');
            if (!e.Handled) (sender as TextBox).Tag = (sender as TextBox).Text;//记录最后一次正确输入  
        }

        private void txtV40_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, @"^(?!0\d)\d+(\.\d*)?$"))
            {
                int index = (sender as TextBox).SelectionStart;
                (sender as TextBox).Text = (sender as TextBox).Tag as string;
                (sender as TextBox).SelectionStart = index;
            }
        }
        #endregion

        private void AddBtTestData_Load(object sender, EventArgs e)
        {
            //初始化，输入数据编号

        }

        //提交数据
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDataID.Text =="" || combProductName .Text =="" )
            {
                return;
            }
            tb_bttestdata model = new tb_bttestdata();
            model.ID = txtDataID.Text.Trim();
            model.ASTM = txtASTM.Text.Trim();
            model.AV = Convert.ToDouble(txtAV.Text.Trim());
            model.GetSamLocation = combGetLoacation.Text.Trim();
            model.GetSampleTime = dtGetTime.Value;
            model.UpdateTime = dtTestTime.Value;
            model.GetSampPerson = combGetPerson.Text.Trim();
            model.ProductName = combProductName.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            model.TestPerson = combTestPerson.Text.Trim();
            model.V40 =Convert.ToDouble ( txtV40.Text.Trim());
            model.V100 =Convert.ToDouble (txtV100.Text.Trim());
            model.VI = LabHelper.CalcuteVI(model.V40, model.V100);
            model.Save();
            this.ParentForm.DialogResult = DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }
    }
}
