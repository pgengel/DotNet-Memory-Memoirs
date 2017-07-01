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
			GCCollection myGcCol = new GCCollection();

			// Determine the maximum number of generations the system
			// garbage collector currently supports.
			Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

			myGcCol.MakeSomeGarbage();

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGcCol));

			// Determine the best available approximation of the number 
			// of bytes currently allocated in managed memory.
			Console.WriteLine("he number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));

			// Perform a collection of generation 0 only.
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
			GC.Collect(0, GCCollectionMode.Optimized, false);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));
			GC.Collect(0, GCCollectionMode.Default, true);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));
			GC.Collect(0, GCCollectionMode.Forced, true);
			Console.WriteLine("The number of times garbage collection has occurred for gen0: {0}", GC.CollectionCount(0));


			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGcCol));

			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

			// Perform a collection of all generations up to and including 2.
			GC.Collect(2);

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGcCol));
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
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
