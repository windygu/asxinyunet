/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-29
 * 时间: 10:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic ;
using System.Windows.Forms;
using DotNet.Tools.Controls ;
using YoungRunEntity ;
using NewLife;
using XCode.DataAccessLayer;

namespace YoungRunST.Controls
{
	/// <summary>
	///添加油罐信息
	/// </summary>
	public partial class AddOilTankInfo : UserControl
	{
		public AddOilTankInfo()
		{
			InitializeComponent();
			IsFlag = false ;          
		}
		bool IsFlag ;
        public List<tb_oiltankinfo> ModelList { get; set; }
        public tb_oiltankinfo Model { get; set; }
        void BandDate()
        {
            combOilTankID.DataBindings.Clear();
            combOilTankID.DataBindings.Add("Text", Model, tb_oiltankinfo._.TankId );
            txtHeight.DataBindings.Clear();
            txtHeight.DataBindings.Add("Text", Model, tb_oiltankinfo._.Height);
        }
		void TxtHeightKeyPress(object sender, KeyPressEventArgs e)
		{
			WinFormHelper.SetControlOnlyValue(sender, e);			
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{			 
			//TODO:增加了储存种类字段
			tb_oiltankinfo model = new tb_oiltankinfo () ;
			if (combOilTankID.Text .Trim ()!="") {
				model.TankId = combOilTankID.Text .Trim () ;				
			}
			else 
			{
				return ;
			}
			if (txtHeight.Text .Trim ()!="") {
				model.Height =Convert.ToDouble(txtHeight.Text .Trim ()) ;				
			}
			else 
			{
				return ;
			}
			if (txtVolume.Text .Trim ()!="") {
				model.Volume =Convert.ToDouble ( txtVolume.Text .Trim ()) ;				
			}
			else 
			{
				return ;
			}
			if (txtPerCmVolume .Text .Trim ()!="") {
				model.PerCmVolume = Convert.ToDouble (txtPerCmVolume.Text .Trim ()) ;				
			}
			else 
			{
				return ;
			}
			if (txtProductName.Text .Trim ()!="") {
				model.ProductName = txtProductName.Text .Trim () ;				
			}
			else 
			{
				return ;
			}
			if (txtAlarmHeight.Text.Trim ()!="") {
				model.AlarmHeight  = Convert.ToDouble (txtAlarmHeight.Text.Trim ()) ;				
			}
			else 
			{
				return ;
			}
			if (combStrogeType.Text.Trim ()!="") {
				model.StrogeType = combStrogeType.Text.Trim () ;
			}
			else
			{
				return ;
			}
			if (txtPurpose.Text.Trim ()!="") {
				model.Purpose = txtPurpose.Text.Trim () ;
			}
			model.UpdateTime = DateTime.Now ;
			model.Remark = txtRemark.Text  ;
			model.D20 = 0.91 ;            
			if (model.Insert () > 0)
            {
                MessageBox.Show("添加成功");
                IsFlag = true;
                AddOilTankInfoLoad(sender, e);
            }
            else
            {
                MessageBox.Show("添加失败");
            }                        
		}
		
		void AddOilTankInfoLoad(object sender, EventArgs e)
		{
			if (!DesignMode ) {
                WinFormHelper.ResetFormControls(sender, e, this);
                combOilTankID.Items.Clear();
                combStrogeType.Items.Clear();
                combOilTankID.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.TankId));
                combStrogeType.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.TankType));
			}
		}
		
		void BtnCancleClick(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;
			else
				this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close();
		}

        private void combStrogeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combStrogeType.Text.Trim () !="")
            {
                tb_dictype cutType = tb_dictype.Find(tb_dictype._.Value, combStrogeType.Text.Trim());
                List<tb_dictype> list = tb_dictype.FindAll(tb_dictype._.TypeName, cutType.Remark);
                txtProductName.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    txtProductName.Items.Add(list[i].Value);
                }
            }
         
        }       
	}
}