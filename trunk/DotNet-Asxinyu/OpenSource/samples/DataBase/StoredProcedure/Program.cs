
#region usings

using System;
using System.Windows.Forms;

#endregion

namespace DataBaseStoredProcedure
{
	public class Program
	{
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			MessageBox.Show("Please ensure you\'re import data to Sql Server by run SampleTable.sql already.");
			Application.Run(new MainForm());
		}
	}
}
