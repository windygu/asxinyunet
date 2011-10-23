using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ProteidCalculate;
using System.Threading;
using Excel;
using DotNet.Tools ;

namespace ProtendCalculateForm
{
    public partial class CalcuteForm : Form
    {
     
        #region 变量与初始化
        static string appInfo = "南昌大学*生物信息学研究团队"; //南昌大学*生物信息学研究团队
        static string develpInfo = "软件开发:asxinyu@126.com";
        double[][] res ;
        private delegate void CrossControl();
        ArrayList al;
        public CalcuteForm()
        {
            InitializeComponent();

            //Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void CalcuteForm_Load(object sender, EventArgs e)
        {
            txtInput.MaxLength = int.MaxValue;//设置最大字符数字
            toolAppInfo.Text = appInfo;
            toolDevelopInfo.Text = develpInfo;
            al = new ArrayList();
        }
        #endregion
                
        #region 按钮事件
        //手动单个特征值
        private void btnOK_Click(object sender, EventArgs e)
        {
//        	test() ;
            if ((!rdbWave.Checked )&&(!rdbNormal.Checked ))
            {
                MessageBox.Show("没有指定算法类型", "错误");
                return;
            }
            if (txtInput.Text.Trim().Length <5)
            {
                MessageBox.Show("没有输入或输入格式错误", "错误");
                return;
            }
            toolCalcuteInfo.Text = "请稍候,正在计算";
            this.Cursor = Cursors.WaitCursor;
            Thread th = new Thread(this.btnOkThread );
            th.Start();            
        }
        private void test()
        {
        	string path=@"d:\我的文档\桌面\enpred-svm.xls";
        	double[] res = ProteidCharacter.KdTreeTest (path ,txtInput.Text,txtWaveName.Text.Trim ());
        //	dgvResult.DataSource = ConverterAlgorithm.ConvertToDataTable <double >(res) ;
        }
        //计算特征值多线程
        private void btnOkThread()
        {
            CrossControl cc = delegate()
            {
                string str = txtInput.Text.Trim();
                //string[] str = ProteidCharacter.SplitStringsByEnter(txtInput.Text.Trim());
                if (rdbWave.Checked )
                {
                    res = ProteidCharacter.GetAllSeqCharacter (str,txtWaveName.Text.Trim ());
                }
                else  //(rdbNormal.Checked)
                {
                    res = ProteidCharacter.GetAllWaccAndACFvalue(str, Convert.ToInt32(txtGetLength.Text.Trim()), txtCentrlElement.Text.Trim().ToUpper ()[0]);        
                }
//                System.Data.DataTable dtt =ConverterAlgorithm.ConvertToDataTable <double>(res);
//                dgvResult.DataSource = dtt;
                this.Cursor = Cursors.Arrow;
                toolCalcuteInfo.Text = "计算完成,共有" + res.GetLength(0) + "条序列特征值";
            };            
            this.Invoke(cc) ;
            statusStrip4.Invoke(cc);
            dgvResult.Invoke(cc);
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            dgvResult.DataSource = null;
            toolCalcuteInfo.Text = "";
        }


        //选择文件夹
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrow.ShowDialog()== DialogResult.OK )
            {
                txtFolderPath.Text = folderBrow.SelectedPath ;
                if (txtFolderPath.Text.Trim ().Length >1)
                {
//                    al = DotNet.Tools.FileLib.GetAllFilesByFolder(txtFolderPath.Text.Trim(), "*.txt",true);
                }
                textBox4.Text = "";
                foreach (object item in al )
                {
                    if (item!=null )
                    {                       
                        textBox4.Text += (item.ToString() + "\r\n");
                    }
                }
            }
        }

        //重置
        private void btnResetAll_Click(object sender, EventArgs e)
        {
            txtFolderPath.Text = "";
            txtResult.Text = "";
            textBox4.Text = "";
            al.Clear();
            toolCalcuteInfo.Text = "";
        }
       
        //计算
        private void btnAllOK_Click(object sender, EventArgs e)
        {            
            if (txtFolderPath.Text =="" )
            {
                MessageBox.Show("没有指定文件夹","错误");
                return;
            }
            if ((!rdbWaveP.Checked)&&(!rdbQZ .Checked ) )
            {
                MessageBox.Show("没有指定算法类型", "错误");
                return;
            }
            toolCalcuteInfo.Text = "请稍后,正在计算";
            Thread th = new Thread(this.CalcuteData) ;
            th.Start();
        }
      
        /// <summary>
        /// 根据文件路径和算法类型，计算结果，直接保存到对应文件夹下
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private void GetTextResultByFileName(string fileName)
        {                      
            StreamReader sr = new StreamReader(fileName.ToString());
            string text = sr.ReadToEnd();
            double[][] res;
            int flag = 2;
            if (rdbWaveP.Checked)
            {
                flag = 0;
            }
            if (rdbQZ.Checked)
            {
                flag = 1;
            }
            if (flag == 0)
            {
                res = ProteidCharacter.GetAllSeqCharacter(text, txtWaveName.Text.Trim());
            }
            else
            {
                res = ProteidCharacter.GetAllWaccAndACFvalue(text,
                    Convert.ToInt32(txtGetLength.Text.Trim()), txtCentrlElement.Text.Trim()[0]) ;
            }
            string newName = fileName.Remove(fileName.Length - 4, 4) + "-Result.xls";
//            ConverterAlgorithm.ConvertToExcel <double>  (res, newName,"测试结果");
            sr.Close();
            CrossControl c1 = delegate()
            {
            	txtResult.Text = (("正在计算文件:" + fileName + ";")+"计算完成.\r\n") + txtResult.Text ;
            	//this.Cursor = Cursors.Arrow ;
            };
            txtResult.Invoke(c1);
        }

        private void CalcuteData()
        {
        	for (int i = 0; i < al.Count; i++)
        	{
        		GetTextResultByFileName(al[i].ToString());
        	}
        	CrossControl c1 = delegate()
        	{
        		txtResult.Text = ("---------------所有计算完成--------------\r\n\r\n") + txtResult.Text;
        		toolCalcuteInfo.Text = "计算完成";
        	};
        	this.Invoke(c1);
        }
        #endregion

        #region 其他公共方法
        /// <summary>
        /// 将当前特征值计算结果导入到Excel
        /// </summary>
        private void ExportDataToExcel_Click(object sender, EventArgs e)
        {
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
//            if(ConverterAlgorithm.ConvertToExcel (dgvResult, saveFile.FileName,"计算结果"))
//            {
//                MessageBox.Show("导出成功");
//            }
//            else
//                MessageBox.Show("导出失败", "错误");
        }

       
        #endregion

        //WACC分开计算
        private void btnOK2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text .Trim ().Length <1)
            {
                MessageBox.Show("请输入中心元素","错误");
                return;
            }
            if (textBox5.Text.Trim ().Length <1)
            {                
                MessageBox.Show("请输入截取位数","错误");
                return;
            }
            if (txtInput2.Text.Trim ().Length <1)
            {
                MessageBox.Show("测试序列格式错误或序列不足", "错误");
                return;
            }
            Thread th = new Thread(this.WaccCacluteDisp );
            th.Start ();
        }
        private void WaccCacluteDisp()
        {
            CrossControl WaccControl = delegate()
            {
                this.Cursor = Cursors.WaitCursor;
                string[] str = ProteidCharacter.SplitStringsByEnter(txtInput2.Text.Trim());//分割
                
                //先对表格进行初始化
                System.Data.DataTable dtpos = new System.Data.DataTable();
                string[] colName = {"序列编号","位置","提取序列" };
                for (int i = 0; i < 3; i++)
                {
                    DataColumn dc = new DataColumn(colName[i ], Type.GetType("System.String"));
                    dtpos.Columns.Add(dc);
                }
                //Wacc
                System.Data.DataTable dtWacc = new System.Data.DataTable();
                for (int i = 0; i < 20 ; i++)
                {
                    DataColumn dc = new DataColumn((i + 1).ToString(), Type.GetType("System.Double"));
                    dtWacc.Columns.Add(dc);
                }
                //ACF
                System.Data.DataTable dtACF = new System.Data.DataTable();
                int num = Convert.ToInt32(textBox5.Text.Trim()) ;
                for (int i = 0; i < num*2+1 ; i++)
                {
                    DataColumn dc = new DataColumn((i + 1).ToString(), Type.GetType("System.Double"));
                    dtACF .Columns.Add(dc);
                }
                //开始计算
                int[] pos ;//位置
                string[] tempStr;
                double[] t1, t2;
                char desChar = textBox6.Text.Trim ().ToUpper ()[0] ;//转换为大写
                for (int i = 0; i < str.Length ; i++)
                {
                    //先提取序列
                    tempStr = ProteidCharacter.GetCentrlString(str[i], num, desChar,out pos );
                    //添加到table                    
                    //对截取序列进行计算，WACC 与自相关值
                    for (int j = 0; j < tempStr.Length; j++)
                    {
                        //计算Wacc
                        t1 = ProteidCharacter.WACC_OneSeqence(tempStr[j]);
                        t2 = ProteidCharacter.AutoCorrFunction(tempStr[j], num * 2 + 1);
                        //添加到datable

                        DataRow dr = dtpos.NewRow() ;
                        dr[0] = (i + 1).ToString();
                        dr[1] = pos[j].ToString ();
                        dr[2] = tempStr[j];
                        dtpos.Rows.Add(dr);

                        DataRow dr1 = dtWacc.NewRow();
                        for (int k = 0; k < t1.Length ; k++)
                        {
                            
                            dr1[k] = t1[k];
                        }
                        dtWacc.Rows.Add(dr1);

                        DataRow dr2 = dtACF.NewRow();
                        for (int k = 0; k < t2.Length ; k++)
                        {
                            
                            dr2[k] = t2[k];
                        }
                        dtACF.Rows.Add(dr2);
                    }
                }
                //绑定数据
                dgvTextDisp.DataSource = dtpos;
                dgvQZ.DataSource = dtWacc;
                dgvACF.DataSource = dtACF;
                this.Cursor = Cursors.Arrow;
            };
            dgvTextDisp.Invoke(WaccControl);
            dgvQZ.Invoke(WaccControl);
            dgvACF.Invoke(WaccControl);
            
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            dgvTextDisp.DataSource = null;
            dgvQZ.DataSource = null;
            dgvACF.DataSource = null;
            txtInput2.Text = "";
            toolCalcuteInfo.Text = "";
        }

        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            if (dgvTextDisp.Rows.Count < 1)
            {
                MessageBox.Show("无数据", "错误");
                return;
            }           
            Thread th = new Thread(this.ExportData_Two);
            th.Start();
        }

        private void ExportData_Two()
        {
            try
            {
                CrossControl c2 = delegate()
                {
                    saveFile.Filter = "Excel文件(*.xls)|*.xls";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        if (saveFile.FileName == "")
                        {
                            MessageBox.Show("文件名错误", "错误");
                            return;
                        }

                    }
                    this.Cursor = Cursors.WaitCursor;
                    string fileName = saveFile.FileName.Substring(0, saveFile.FileName.Length - 4);
//                    ConverterAlgorithm.ConvertToExcel(dgvTextDisp, fileName + "-截取字符串.xls", "计算结果");
//                    ConverterAlgorithm.ConvertToExcel(dgvQZ, fileName + "-WACC.xls", "计算结果");
//                    ConverterAlgorithm.ConvertToExcel(dgvACF, fileName + "-ACF.xls", "计算结果");
                    MessageBox.Show("导出成功");
                    this.Cursor = Cursors.Arrow;

                };
                this.Invoke(c2);
            }
            catch
            {
                MessageBox.Show("导出失败", "错误");
            }
            finally
            {
                
            }
        }
    }
}