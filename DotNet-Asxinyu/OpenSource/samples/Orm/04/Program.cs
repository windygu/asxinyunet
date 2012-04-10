using System;
using Lephone.Data;
using Lephone.Data.Builder;
using OrmCommon;

namespace Orm4
{
	class Program
	{
		[STAThread]
		static void Main()
		{
            Console.WriteLine("Using transaction:\n");

			Console.WriteLine("Show all items.");
			Show();

			Console.WriteLine("Insert and rollback.");
            try
            {
                InsertAndRollback();
            }
            catch (DataException) { }
			Show();

			Console.WriteLine("Insert and commit.");
            InsertAndCommit();
			Show();

			Console.WriteLine("delete the items.");
			Delete();
			Show();
		}
		
		private static readonly DateTime JoinDate = new DateTime(2011, 5, 19, 17, 59, 23);

		public static void InsertAndRollback()
		{
            DbEntry.UsingTransaction(delegate
            {
                InsertOneRow(SampleData.New("aa", UserRole.Manager, JoinDate, true, null));
                InsertOneRow(SampleData.New("bb", UserRole.Client, JoinDate, false, null));
                // emu the exception
                throw new DataException();
            });
		}

        public static void InsertAndCommit()
        {
            DbEntry.UsingTransaction(delegate
            {
                InsertOneRow(SampleData.New("aa", UserRole.Manager, JoinDate, true, null));
                InsertOneRow(SampleData.New("bb", UserRole.Client, JoinDate, false, null));
            });
        }

        private static void InsertOneRow(SampleData d)
        {
            // this runs in the Transaction
            d.Save();
        }

		public static void Delete()
		{
            var sb = new DeleteStatementBuilder("SampleData");
            sb.Where.Conditions = (CK.K["Id"] > 9);
            DbEntry.Provider.ExecuteNonQuery(sb.ToSqlStatement(DbEntry.Provider.Dialect, null));
		}

		public static void Show()
		{
            foreach (var d in SampleData.Find(null, new OrderBy("Id")))
			{
				Console.WriteLine( d );
			}
			Console.WriteLine();
		}
	}
}
