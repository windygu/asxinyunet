using System;
using Lephone.Core.Text;
using Lephone.Extra;

namespace DataBaseEnum
{
	public enum DotNetEnum
	{
		Debug,
		Release,
		[ShowString("In Design")] InDesign
	}

	public class Enums
	{
		public static readonly DbEnum Headship = new DbEnum(0);
		public static readonly DbEnum Container = new DbEnum(1);
		public static readonly DbEnum Level = new DbEnum(2);
		public static readonly DbEnum Status = new DbEnum(typeof(DotNetEnum));
	}

	class Program
	{
		[STAThread]
		static void Main()
		{
			Console.WriteLine("Enum Headship:");
			Show( Enums.Headship );

			Console.WriteLine("Enum Container:");
			Show( Enums.Container );

			Console.WriteLine("Enum Level:");
			Show( Enums.Level );

			Console.WriteLine("Enum Mode:");
			Show( Enums.Status );

			Console.WriteLine( "Enum Container String:\n{0} = {1}\n", 1, Enums.Container[1] );
		}

		public static void Show(DbEnum de)
		{
			string[] ss = de.GetNames();
			foreach ( string s in ss )
			{
				Console.WriteLine( "{0} = {1}", s, de[s] );
			}
			Console.WriteLine();
		}
	}
}
