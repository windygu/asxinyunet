/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-18
 * 时间: 11:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms ;

namespace DotNet.Tools.Controls
{
	/// <summary>
	/// WinForm帮助类
	/// </summary>
	public class WinFormHelper
	{
		/// <summary>
		/// 菜单
		/// </summary>
		/// <param name="names"></param>
		/// <param name="texts"></param>
		/// <param name="onclick"></param>
		/// <returns></returns>
		public static ContextMenuStrip GetContextMenuStrip(string[] names,string[] texts,EventHandler[] onclick)
		{
			ContextMenuStrip CellcontextMenuStrip = new ContextMenuStrip () ;
			for (int i = 0; i < names.Length ; i++) {
				ToolStripMenuItem toolStripMenu = new ToolStripMenuItem () ;
				toolStripMenu.Name = names [i ] ;
				toolStripMenu.Size = new System.Drawing.Size(180, 70);
				toolStripMenu.Text = texts[i] ;
				toolStripMenu.Click += new EventHandler(onclick [i ]);
				CellcontextMenuStrip.Items.Add(toolStripMenu ) ;				
			}
			return CellcontextMenuStrip ;
		}
	}
}
