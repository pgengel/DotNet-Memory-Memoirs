using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.DisposePattern
{
	class DisposeObject : IDemo
	{

		public void Run(string[] args)
		{
			File.WriteAllText("disposeobjectsdemo.txt", "Hello.");

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("DisposableFileStream objects");
			Console.ResetColor();

			Console.WriteLine("Help the garbage collector to clean up objects!");
			Console.WriteLine("DisposableFileStream does just that.");

			DontDispose();
			RunDispose();
			TimerDispose();
		}

		private static void DontDispose()
		{
			Console.WriteLine("Let's generate 10.000 objects and not dispose them. Let's show what happens when not disposing... (see DisposableFileStream)");

			var disposables = new List<DisposableFileStream>();
			for (int i = 0; i < 10000; i++)
			{
				disposables.Add(
					new DisposableFileStream(new FileStream("disposeobjectsdemo.txt", FileMode.OpenOrCreate, FileAccess.Read)));
			}

			Console.WriteLine("Collect a snapshot, then press enter to run GC.");
			Console.ReadLine();
			disposables.Clear();
			GC.Collect(0);

			Console.WriteLine("Collect a snapshot, and see if there are any DisposableFileStream in memory.");
			Console.WriteLine("All objects are in the finalizer queue... We need another GC! (enter)");
			Console.ReadLine();
			GC.Collect(0);
			GC.Collect(1);

			Console.WriteLine("Collect a snapshot, objects are now really gone.");
			Console.ReadLine();
			GC.Collect(0);
			GC.Collect(1);
		}

		private static void RunDispose()
		{
			Console.WriteLine("Let's generate 10.000 objects and this time, dispose them.");

			var disposables = new List<DisposableFileStream>();
			for (int i = 0; i < 10000; i++)
			{
				disposables.Add(
					new DisposableFileStream(new FileStream("disposeobjectsdemo.txt", FileMode.OpenOrCreate, FileAccess.Read)));
			}

			Console.WriteLine("Collect a snapshot, then press enter to dispose all objects and run GC.");
			Console.ReadLine();

			foreach (var disposable in disposables)
			{
				disposable.Dispose();
			}
			disposables.Clear();
			GC.Collect(0);

			Console.WriteLine("Collect a snapshot, and see if there are any DisposableFileStream in memory. They should be gone now.");
			GC.Collect(0);
		}

		//Show using in the IL viewer
		private static void TimerDispose()
		{
			Console.WriteLine("Releasing root objects. press enter");
			Console.ReadLine();
			string helloWorld = "Running TimerDispose";

			Console.WriteLine(helloWorld);

			Timer timer;
			using (Clock clock = new Clock())
			{
				timer = new Timer(clock.OnTick,
					null,
					TimeSpan.FromSeconds(1),
					TimeSpan.FromSeconds(1));
			}

			Console.WriteLine("Take a snapshot and look for Timer object. Press <enter> to quit");
			Console.ReadLine();
		}
	}
	
}
