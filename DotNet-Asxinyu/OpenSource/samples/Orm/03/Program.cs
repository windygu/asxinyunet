using System;
using System.Collections;
using Lephone.Data;
using OrmCommon;

namespace Orm3
{
	class Program
	{
		[STAThread]
		static void Main()
		{
            Console.WriteLine("Using two databases:\n");

			// first database
            foreach (SampleData d in SampleData.Find(null, new OrderBy("Id")))
			{
				Console.WriteLine( d );
			}
			Console.WriteLine();

			// secend database
			IList list = DbEntry.From<BookInfo>().Where(Condition.Empty).OrderBy(p => p.BookName).Select();
			foreach ( BookInfo bi in list )
			{
				Console.WriteLine( bi );
			}
		}
	}
}
