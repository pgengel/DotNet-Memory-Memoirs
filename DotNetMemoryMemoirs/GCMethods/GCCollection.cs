using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.GCMethods
{
	class GCCollection : IDemo
	{
		private const long maxGarbage = 1000;
		public void Run(string[] args)
		{
			Console.WriteLine("Press enter to make 'n reference to make some garbage");
			Console.ReadLine();
			GCCollection myGcCol = new GCCollection();

			Console.WriteLine("Determine the maximum number of generations the system");
			Console.WriteLine("garbage collector currently supports.");
			Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

			Console.WriteLine("Press enter to make some garbage");
			Console.ReadLine();
			myGcCol.MakeSomeGarbage();

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Determine Generation object is stored: {0}", GC.GetGeneration(myGcCol));

			// Determine the best available approximation of the number 
			// of bytes currently allocated in managed memory.
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));

			// Perform a collection of generation 0 only.
			Console.WriteLine("Press enter to collect the garbage on gen0");
			Console.ReadLine();
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
			GC.Collect(0, GCCollectionMode.Optimized, false);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));
			GC.Collect(0, GCCollectionMode.Default, true);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));
			GC.Collect(0, GCCollectionMode.Forced, true);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));

			Console.WriteLine("Determine which generation myGCCol object is stored in: {0}", GC.GetGeneration(myGcCol));

			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

			Console.WriteLine("Press enter to collect the garbage on all generations");
			Console.ReadLine();
			GC.Collect(2);

			Console.WriteLine("Determine which generation myGCCol object is stored in: {0}", GC.GetGeneration(myGcCol));
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
			Console.WriteLine("Press enter to finish");
			Console.Read();
		}

		void MakeSomeGarbage()
		{
			Version vt;

			for (int i = 0; i < maxGarbage; i++)
			{
				// Create objects and release them to fill up memory
				// with unused objects.
				vt = new Version();
			}
		}
	}
}
