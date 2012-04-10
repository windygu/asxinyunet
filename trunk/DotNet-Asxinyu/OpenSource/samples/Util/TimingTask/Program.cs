
#region usings

using System;
using Lephone.Core.TimingTask;
using Lephone.Core.TimingTask.Timings;

#endregion

namespace Util_TimingTask
{
	public class SecendTask : ITask
	{
		public void Run()
		{
			Console.WriteLine( "SecendTask Run." );
		}
	}

	public class FiveSecendTask : ITask
	{
		public void Run()
		{
			Console.WriteLine( "FiveSecendTask Run." );
		}
	}

	public class DayTask : ITask
	{
		public void Run()
		{
			Console.WriteLine( "DayTask Run." );
		}
	}

	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			TimingTask tt1 = new TimingTask( new SecendTask(), new TimeSpanTiming(new TimeSpan(0,0,1)) );
			TimingTask tt5 = new TimingTask( new FiveSecendTask(), new TimeSpanTiming(new TimeSpan(0,0,5)) );
			DateTime dt = DateTime.Now.AddSeconds(8);
			TimingTask ttd = new TimingTask( new DayTask(), new DayTiming(new TimeOfDayStructure(dt.Hour, dt.Minute, dt.Second)) );
			TimingTaskCollection ttc = new TimingTaskCollection( tt1, tt5, ttd );
			TimingTaskController Controller = new TimingTaskController( ttc );
			Controller.Start();
			Console.WriteLine("Press [Enter] to exit.");
			Console.ReadLine();
			Controller.Dispose();
		}
	}
}
