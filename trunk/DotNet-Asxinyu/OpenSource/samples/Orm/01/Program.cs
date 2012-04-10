using System;
using OrmCommon;

namespace Orm1
{
	public class Program
	{
		[STAThread]
		static void Main()
		{
            Console.WriteLine("Basic usage of DbEntry.Net:\n");

			Console.WriteLine("Show last items in database:");
			Show();

			Console.WriteLine("Insert a new item into database:");
            var d = SampleData.New("angel", UserRole.Worker, new DateTime(2004, 2, 27, 15, 10, 23), true, 5);
			d.Save();
			Show();

			Console.WriteLine("Update this item to database:");
			d.Name = "demon";
			d.Role = UserRole.Client;
			d.JoinDate = new DateTime(2005, 6, 10, 9, 5, 32);
            d.NullInt = null;
			d.Save();
			Show();

			Console.WriteLine("Delete this item from database:");
			d.Delete();
			Show();
		}

		private static void Show()
		{
            SampleData.Find(p => p.Id >= 5, "Id").ForEach(Console.WriteLine);
			Console.WriteLine();
		}
	}
}
