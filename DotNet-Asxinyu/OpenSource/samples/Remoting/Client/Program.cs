using System;
using Common;
using Lephone.Core;

namespace Client
{
	class Program
	{
		[STAThread]
		static void Main()
		{
            var dl = RemotingHelper.GetObject<IDataLayer>();
            Show(dl, "Show all:");

            SampleData ti = SampleData.New("tom", UserRole.Client, DateTime.Now, false);
            dl.SaveTestItem(ref ti);
            Show(dl, "Insert:");

            ti.Name = "mike";
            dl.SaveTestItem(ref ti);
            Show(dl, "Update:");

            dl.DeleteTestItem(ti);
            Show(dl, "Delete:");

            Console.ReadLine();
        }

        private static void Show(IDataLayer dl, string s)
        {
            Console.WriteLine(s);
            foreach (SampleData ti in dl.GetTestItems(null))
            {
                Console.WriteLine(ti);
            }
            Console.WriteLine();
        }
    }
}
