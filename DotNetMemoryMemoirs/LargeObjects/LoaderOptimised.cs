using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.LargeObjects
{
	class LoaderOptimised : IDemo
	{
		public void Run(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Loading beers!");
			Console.ResetColor();
			Console.WriteLine("Attach the memory profiler, and load beers a number of times.");

			for (var i = 0; i < 3; i++)
			{
				LoadLargeObject.LoadLargeObjectOptimized();

				Console.WriteLine("Collect a snapshot, press enter to run GC.");
				Console.ReadLine();
}

			Console.WriteLine("Now look at the snapshots in the profiler...");
			Console.WriteLine("* GC is almost invisible");
			Console.WriteLine("* Less allocations happening");
			Console.WriteLine("* Compare two snapshots: almost no traffic");
			Console.WriteLine("* Less work for GC, less pauses!");

			Console.WriteLine("Collect a snapshot, press enter to run compact the large object heap (LOH).");
			Console.ReadLine();

			Console.WriteLine("Memory used before collection:{0:N0}", GC.GetTotalMemory(false));

			GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
			GC.Collect();
			Console.WriteLine("Memory used after full collection:{0:N0}", GC.GetTotalMemory(true));

		}
	}
}
