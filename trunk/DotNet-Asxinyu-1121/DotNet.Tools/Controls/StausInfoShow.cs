/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 8:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.Tools.Controls
{
	/// <summary>
	/// 状态栏底部信息显示,分为3栏
	/// </summary>
	public partial class StausInfoShow : UserControl 
	{
		public StausInfoShow()
		{
			InitializeComponent();
		}
		public void SetToolInfo1(string text)
		{
			firstInfo.Text = text ;
		}
		public void SetToolInfo2(string text)
		{
			secondInfo.Text = text ;
		}
		public void SetToolInfo3(string text)
		{
			thirdInfo.Text = text ;
		}
		public void SetAllToolInfo(string text1,string text2,string text3)
		{
			firstInfo.Text = text1 ;
			secondInfo.Text = text2 ;
			thirdInfo.Text = text3 ;
		}
	}	
}
