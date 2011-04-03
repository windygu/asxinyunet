/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-28
 * Time: 13:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections ;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DotNet.Tools;
using System.Threading;


namespace ProteidFucForcast
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		private delegate void CrossControl();
		double[][] res ;
		#region 计算特征值		
		void BtnOKClick(object sender, EventArgs e)
		{
			try
			{
				if ((!rdbWave.Checked ))
				{
					MessageBox.Show("没有指定算法类型", "错误");
					return;
				}
				this.Cursor = Cursors.WaitCursor;
				Thread th = new Thread(this.btnOkThread );
				th.Start();
			}
			catch (Exception err)
			{
				MessageBox.Show ("计算出现错误,请检查数据格式和系统环境!");
			}
		}
		  //计算特征值多线程
        private void btnOkThread()
        {
        	CrossControl cw = delegate()
        	{
        		string str = txtInput.Text.Trim();
        		res = MainClassLib.GetAllAAC (str ) ;
        		System.Data.DataTable dtt =ConverterAlgorithm.ConvertToDataTable <double>(res);
        		dgvResult.DataSource = dtt;
        		this.Cursor = Cursors.Arrow;
        	} ;
        	this.Invoke(cw) ;
        	dgvResult.Invoke(cw);
        }
		#endregion
		
		#region 导出到excel		
        void BtnResetClick(object sender, EventArgs e)
		{
			txtInput.Text = "" ;
			dgvResult.DataSource = null ;
		}
		void ExportDataToExcelClick(object sender, EventArgs e)
		{
			//导出数据到Excel
			if (dgvResult.Rows.Count <1)
            {
                MessageBox.Show("无数据", "错误");
                return ;
            }
            saveFile.Filter = "Excel文件(*.xls)|*.xls";
            if (saveFile.ShowDialog ()== DialogResult.OK )
            {
                if (saveFile.FileName =="")
                {
                    MessageBox.Show("文件名错误","错误");
                    return;
                }
                Thread th = new Thread(this.ExportData_One);
                th.Start();
            }
		}
		private void ExportData_One()
		{
			if(ConverterAlgorithm.ConvertToExcel (dgvResult, saveFile.FileName,"计算结果"))
			{
				MessageBox.Show("导出成功");
			}
			else
				MessageBox.Show("导出失败", "错误");
		}		
		#endregion
		
		
		void BtnFilePathClick(object sender, EventArgs e)
		{
			if (openFile.ShowDialog ()== DialogResult.OK )
            {
				if (openFile.FileName !="" )
				{
					txtTestFilePath.Text = openFile.FileName ;
				}
            }
		}
		
		void BtnCalculateClick(object sender, EventArgs e)
		{
			try {
			if (combFunClass.SelectedIndex <0)
			{
				MessageBox.Show ("请选择计算类型");
				return ;
			}
			if (txtTestFilePath.Text.Length <4)
			{
				MessageBox.Show ("请选择测试文件");
				return ;
			}
			txtSvmResult.Text = "";
			this.Cursor = Cursors.WaitCursor;			
			Thread th = new Thread(this.GetResult );
			th.Start();		
			}
			catch (Exception err)
			{
				MessageBox.Show ("计算出现错误,请检查数据格式和并确保计算数据量每类不超过50!");
			}
			
		}
		private void GetResult()
		{	
			CrossControl cj = delegate()
			{
				string folder = Application.StartupPath +@"\Data";
				Hashtable ht = MainClassLib.SelectTestData(Int32.Parse(txtCount.Text),folder ,txtTestFilePath.Text );
				if (combFunClass.SelectedIndex == 0 )
				{
					//计算所有
					for (int i = 1 ; i <19 ; i ++ )
					{
						double result = MainClassLib.TestOneFunction(i ,folder,ht ) ;
						CrossControl cc = delegate()
						{
							txtSvmResult.Text +=("第 "+i.ToString ()+"测试分类正确率："+result.ToString ()+"%")+"\r\n" ;
						};
						this.Invoke(cc) ;
						txtSvmResult.Invoke(cc);
					}
				}
				else
				{
					//计算某一种
					double result = MainClassLib.TestOneFunction (combFunClass.SelectedIndex,folder,ht ) ;
					CrossControl cc = delegate()
					{
						txtSvmResult.Text ="第 "+combFunClass.SelectedIndex.ToString()+
							" 测试分类正确率："+result.ToString ()+"%" ;
					};
					this.Invoke(cc) ;
					txtSvmResult.Invoke(cc);
				}
				this.Cursor = Cursors.Arrow ;			
			};
			this.Invoke(cj) ;
			txtSvmResult.Invoke(cj );
		}
		
		void BtnReset2Click(object sender, EventArgs e)
		{
			//重置
			combFunClass.SelectedIndex = -1 ;
			txtTestFilePath.Text = "" ;
			txtSvmResult.Text = "" ;
		}
		
		#region 序列预测		
		void BtnForcastClick(object sender, EventArgs e)
		{
			try
			{
				string folder = Application.StartupPath +@"\Data";
				Hashtable ht = MainClassLib.SelectTestData(20 ,folder ,txtTrainData.Text );
				//计算所有
				int classNo = 0 ;
				double maxValue = 0 ;
				for (int i = 1 ; i <19 ; i ++ )
				{
					double result = MainClassLib.PredictFunction(i ,folder,ht,txtForText.Text ) ;
					if (maxValue <result )
					{
						maxValue = result ;
						classNo = i ;
					}
					txtForResult.Text +=("第 "+i.ToString ()+"测试分类正确率："+result.ToString ()+"%")+"\r\n" ;
					
				}
				txtForResult.Text += ("最大可能性为第 "+classNo.ToString ()+" 类 :"+maxValue.ToString ()) ;
			}
			catch (Exception err)
			{
				MessageBox.Show ("计算出现错误,请检查数据格式,并确认计算数目不超过每类50!");
			}
		}
		#endregion
		
		void Button1Click(object sender, EventArgs e)
		{
			if (openFile.ShowDialog ()== DialogResult.OK )
            {
				if (openFile.FileName !="" )
				{
					txtTrainData.Text = openFile.FileName ;
				}
            }
		}
		
		void BtnForSetClick(object sender, EventArgs e)
		{
			txtTrainData.Text = "" ;
			txtForResult .Text = "" ;
			txtForText .Text = "" ;
		}
	}
}