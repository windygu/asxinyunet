/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-10-12
 * 时间: 9:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DotNet.Tools.Controls ;
using XCode ;
using XCode.DataAccessLayer ;
using YoungRunControl.Controls ;
using YoungRunEntity;

namespace YoungRunTest
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
		
		void Button1Click(object sender, EventArgs e)
		{
            TestForm tf = GetControlForm<AddBtTestData>(FormShowMode.AddOne, "", "");
            tf.Show();
        }

        /// <summary>
        /// 根据控件得到窗体,可以进行快速测试，不用每一个都写窗体
        /// </summary>
        public static TestForm GetControlForm<T>(FormShowMode formShowMode,
            string searcgCondtion, string fixCondition) where T : UserControl, IEntityControl,new()
        {            
            T EntityControl= new T();
            EntityControl.Dock = System.Windows.Forms.DockStyle.Fill;
            EntityControl.Location = new System.Drawing.Point(0, 0);
            EntityControl.Name = "EntityControl";           
            EntityControl.TabIndex = 0;
EntityControl.InitializeSettings(formShowMode, searcgCondtion, fixCondition);
            TestForm tf = new TestForm();
            tf.Size = new Size(EntityControl.Width + 10, EntityControl.Size.Height + 35);
            tf.Controls.Add(EntityControl);//将控件添加到窗体中
            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            return tf;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
	}
}