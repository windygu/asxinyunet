
#region usings

using System;
using System.Windows.Forms;

#endregion

namespace DataBaseEntry
{
	public class Program
	{
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new MainForm());
		}
	}
}
