using System;
using Lephone.Data;
using Lephone.Data.Model.Inserter;
using OrmCommon;

namespace Orm5
{
	public class ItemOutputer : IProcessor
	{
		public bool Process(object obj)
		{
			Console.WriteLine( obj );
			return true;
		}
	}

	class Program
	{
		[STAThread]
		static void Main()
		{
            Console.WriteLine("Process large results:\n");
		    var ctx = ModelContext.GetInstance(typeof(SampleData));
            ctx.Operator.DataLoad(new ItemOutputer(), typeof(SampleData), null, null, new OrderBy("Id"), null, false, false);
		}
	}
}
