﻿/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * 软件GUI工具
 */
using System;
using DotNet.Tools.Controls ;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LotteryTicket ;
using LotteryTicketSoft.GraphForm ;

namespace LotteryTicketSoft
{
	/// <summary>
	/// 主程序
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{			
			InitializeComponent();				
		}	
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}

        private void 常规参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModel tf = WinFormHelper.GetControlForm<AddRules >(FormShowMode.ContinueAdd, "", "");
            tf.Show();
        }
	}
}
