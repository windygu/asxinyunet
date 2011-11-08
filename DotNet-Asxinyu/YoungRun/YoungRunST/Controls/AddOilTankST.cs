/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-29
 * 时间: 11:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data ;
using System.Collections.Generic;
using YoungRunEntity;
using XCode.DataAccessLayer;
using DotNet.Tools.Controls ;

namespace YoungRunST.Controls
{
	/// <summary>
	/// 灌区测量数据输入
	/// </summary>
	public partial class AddOilTankST : UserControl
	{
		public AddOilTankST()
		{			
			InitializeComponent();
            tankList = new List<TankLiqLevel>();
            IsFlag = false;
            dtGetTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dgv.Columns[0].ReadOnly = true ;//第一列不可编辑
		}
        List<TankLiqLevel> tankList;

        public List<TankLiqLevel> TankList
        {
            get { return tankList; }           
        }
        bool IsFlag;
		void AddOilTankSTLoad(object sender, EventArgs e)
		{
			if (!DesignMode ) {
				string[] TankId = YoungRunHelper.GetDicValueList (YoungRunDicType.TankId ) ;
				for (int i = 0; i < TankId.Length ; i++) {
					dgv.Rows.Add (TankId [i],"") ;
				}
				dtGetTime.Value = YoungRunHelper.GetDBServerTime () ;				
			}			
		}
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            tankList.Clear();
            for (int i = 0; i < dgv.Rows.Count ; i++)
            {
            	if (dgv.Rows[i].Cells[1].Value.ToString ()!="") {
            		tankList.Add(new TankLiqLevel(dgv.Rows [i ].Cells [0].Value.ToString ().Trim (),
            		                              Convert.ToDouble(dgv.Rows[i].Cells[1].Value.ToString ()))) ;
            	}
            	else
            	{
            		MessageBox.Show ("必须输入所有罐的液位高度,空罐请输入0") ;
            		return ;
            	}
            }
            SaveData () ;
            IsFlag = true;
        }
        //保存数据
        public void SaveData()
        {
            for (int i = 0; i < tankList.Count ; i++)
            {
                // 先查找油罐信息
                tb_oiltankinfo tankInfo = tb_oiltankinfo.FindByKey(tankList[i].TankId);
                tb_oiltankst tankST = new tb_oiltankst();
                tankST.TankIdTP  = tankInfo.TankId;
                tankST.ProductNameTP = tankInfo.ProductNameTP ;
                tankST.LiquidLevel = tankList[i].LiquidLevel;
                tankST.CurVolume = tankList[i].LiquidLevel * 100 * tankInfo.PerCmVolume;//体积
                tankST.CurWeigth = tankInfo.D20 * tankST.CurVolume ;
                tankST.D20 = tankInfo.D20;
                tankST.RecordTime = dtGetTime.Value ;//测量时间
                tankST.UpdateTime = DateTime.Now;//更新时间
                tankST.Remark = tankInfo.Remark;
                tankST.Insert();               
            }
            MessageBox.Show("添加成功");
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (IsFlag)
                this.ParentForm.DialogResult = DialogResult.OK;
            else
                this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }
		
        void DgvEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        	//控制只能输入数据
        	if (this.dgv.CurrentCell.ColumnIndex == 1)
        	{
        		e.Control.KeyPress += new KeyPressEventHandler(WinFormHelper.SetControlOnlyZS) ;
        	}
		}
	}

    public class TankLiqLevel
    {
        public string TankId;
        public double LiquidLevel;
        public TankLiqLevel(string tankID, double liqLevel)
        {
            this.TankId = tankID;
            this.LiquidLevel = liqLevel;
        }
    }
}
