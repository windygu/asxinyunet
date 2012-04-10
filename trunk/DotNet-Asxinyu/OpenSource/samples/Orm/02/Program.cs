using System;
using System.Collections;
using Lephone.Data;
using OrmCommon;

namespace Orm2
{
	class Program
	{
		[STAThread]
		static void Main()
		{
            Console.WriteLine("Using class inherits from System.Object:\n");

			Console.WriteLine("Show last items in database:");
			Show();

			Console.WriteLine("Insert a new item into database:");
			var u = new User("angel", "go to hell", new DateTime(2006, 2, 27, 15, 10, 23));
            DbEntry.Insert(u);
			Show();

			Console.WriteLine("Update this item to database:");
			u.Password = "back to the future";
			u.JoinDate = new DateTime(2006, 6, 10, 9, 5, 32);
            DbEntry.Update(u);
			Show();

			Console.WriteLine("Delete this item from database:");
            DbEntry.Delete(u);
			Show();
		}

		public static void Show()
		{
			IList il = DbEntry.From<User>().Where(Condition.Empty).OrderBy(p => p.JoinDate).Select();
			foreach ( User u in il )
			{
				Console.WriteLine( u );
			}
			Console.WriteLine();
		}
	}
}
