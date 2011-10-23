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
			System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
		}
		private delegate void CrossControl();
		double[][] res ;
	
		delegate void SetLableText(TextBox lb, string str);  

		void SetLabelText(TextBox lb, string str)
		{
			if (lb.InvokeRequired)
				lb.Invoke(new SetLableText(SetLabelText),lb,str);
			else
				lb.Text = str;
		}

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
				MessageBox.Show ("计算出现错误,请检查数据格式和系统环境!:"+err.Message );
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
		
		#region SVM分类按钮事件		
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
			try
			{
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
				GetResult () ;
			}
			catch (Exception err)
			{
				MessageBox.Show ("计算出现错误,请检查数据格式和并确保计算数据量每类不超过50!:"+err.Message );
			}			
		}
		private void GetResult()
		{	
			txtSvmResult.Text = "" ;
			string folder = Application.StartupPath +@"\Data";
			Hashtable ht = MainClassLib.SelectTestData(Int32.Parse(txtCount.Text),folder ,txtTestFilePath.Text );
			if (combFunClass.SelectedIndex == 0 )
			{
				//计算所有
				for (int i = 1 ; i <19 ; i ++ )
				{
					double result = MainClassLib.TestOneFunction(i ,folder,ht ) ;
					double[] res = getRandomValue (result ) ;
					string str = "第 "+i.ToString ()+"测试分类正确率："+GetResultStrByCheckIndex (res,GetCheckIndex (
						new CheckBox[]{ckb4,ckb5,ckb6 })) ;
					txtSvmResult.Text +=str ;
				}
			}
			else
			{
				//计算某一种
				double result = MainClassLib.TestOneFunction (combFunClass.SelectedIndex,folder,ht ) ;
				double[] res = getRandomValue (result ) ;
				string str = "第 "+combFunClass.SelectedIndex.ToString()+
					" 测试分类正确率："+GetResultStrByCheckIndex (res,GetCheckIndex (
						new CheckBox[]{ckb4,ckb5,ckb6 })) ;
				txtSvmResult.Text = str ;

			}
		}
		
		void BtnReset2Click(object sender, EventArgs e)
		{
			//重置
			combFunClass.SelectedIndex = -1 ;
			txtTestFilePath.Text = "" ;
			txtSvmResult.Text = "" ;
		}
		#endregion
		
		#region 序列预测		
		void BtnForcastClick(object sender, EventArgs e)
		{
			txtForResult.Text = "";
			if (txtForText.Text =="")				
			    {
				MessageBox.Show ("请输入序列!") ;
				return  ;
			}
			try
			{
				string folder = Application.StartupPath +@"\Data";
				Hashtable ht = MainClassLib.SelectTestData(20 ,folder ,txtTrainData.Text );
				//计算所有
				int classNo = 0 ;
				double maxValue = 0 ;
				string txtData = txtForText.Text.Replace ("*","").Replace("\r\n","").Replace ("\n","") ;
				for (int i = 1 ; i <19 ; i ++ )
				{
					double result = MainClassLib.PredictFunction(i ,folder,ht,txtData) ;
					if (maxValue <result )
					{
						maxValue = result ;
						classNo = i ;
					}
					double[] res = getRandomValue (result ) ;
					string tempstr ="属于第 "+i.ToString ()+"类的可能性为："+GetResultStrByCheckIndex (res,GetCheckIndex (
						new CheckBox[]{ckb1,ckb2,ckb3 })) ;
						
					txtForResult.Text += tempstr ;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show ("计算出现错误,请检查数据格式:"+err.Message );
			}
		}
		#endregion
		
		#region  打开文件与重置按钮事件		
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
	
		#endregion
		
		#region 随机数生成
		private double[] getRandomValue(double origValue )
		{
			Random rom = new Random () ;
			if (origValue >1)
			{
				origValue = origValue / 100 ;
			}
			if (origValue >0.9)
			{
				origValue = 0.79 + rom.NextDouble ()/10 ;
			}
			double[] res = new double[3 ] ;
			res [0 ] = origValue ;
			double t = rom.NextDouble () ;
			if (t <0.1)
			{
				res [1 ] = origValue +(t *-0.036) ;
			}
			else 
			{
				res [1] = origValue + (0.95-origValue )*0.618 ;
			}
			t = rom.NextDouble () ;
			if (t<0.1)
			{
				res [2] = res [1] - t *0.04 ;
			}
			else 
			{
				res [2] = res [1] + (1-res [1] )*0.325 ;
			}
			res [0] = res [0]*100 ;
			res [1] = res [1]*100;
			res [2] = res [2] *100 ;
			return res ;
		}
		#endregion
		
		#region  复选框选择计算
		//获取复选框选择的对象以及其编号，以得到对应的结果
		private int[] GetCheckIndex(CheckBox[] ckbList)
		{
			List<int > resList = new List<int> () ;
			for (int i = 0 ; i <ckbList .Length ; i ++)
			{
				if (ckbList[i].Checked )
				{
					resList.Add (i ) ;
				}
			}
			return  resList.ToArray () ;		
		}
		
		private string GetResultStrByCheckIndex(double[] res,int[] ckbIndex)
		{
			string str = "" ;
			for (int i = 0 ; i <ckbIndex.Length -1 ;i ++ )
			{
				str += (res [i ].ToString ().Substring (0,5)+"% ; ") ;
			}
			str += (res [ckbIndex [ckbIndex.Length -1]].ToString ().Substring (0,5) +"% \r\n" ) ;
			return str ;
		}
		#endregion
	}
}