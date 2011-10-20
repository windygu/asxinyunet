using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.Tools.Controls;
using YoungRunEntity;

namespace YoungRunLab.Controls
{
    public partial class AddProductFormule : UserControl
    {
        public AddProductFormule()
        {
            InitializeComponent();         
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }

        private void txtBtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            WinFormHelper.SetControlOnlyZS(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (combProductName.Text !="")
            {
                tb_productformule model = new tb_productformule();
                model.ProductName = combProductName.Text.Trim();
                if (txtBtCount.Text.Trim ()!="")
                {
                    model.BtCount = Convert.ToDouble(txtBtCount.Text.Trim());
                }
                if (txtT501Count .Text.Trim ()!="")
                {
                    model.T501Count = Convert.ToDouble(txtT501Count.Text.Trim());
                }
                if (txtT602Count.Text.Trim ()!="")
                {
                    model.T602Count = Convert.ToDouble(txtT602Count.Text.Trim());
                }
                if (txtYJCount.Text.Trim ()!="")
                {
                    model.YJCount = Convert.ToDouble(txtYJCount.Text.Trim());
                }
                model.UpdateTime = dtUpdateTime.Value;
                model.Remark = txtRemark.Text;                
                model.Insert();
                this.ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void AddProductFormule_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                combProductName.Items.Clear();
                combProductName.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.ProductName));
                dtUpdateTime.Value = YoungRunHelper.GetDBServerTime();
            }
        }
    }
}
