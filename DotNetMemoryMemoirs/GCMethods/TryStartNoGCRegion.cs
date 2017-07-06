using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.GCMethods
{
	class TryStartNoGCRegion : IDemo
	{
		public void Run(string[] args)
		{
			throw new NotImplementedException();
		}

		//static void TestTryStartNoGCRegion(long sizeInBytes, bool preventGC, bool overAllocate = false)
		//{
		//	Console.WriteLine("Prevent GC: {0}, Over Allocate: {1}", preventGC, overAllocate);
		//	try
		//	{
		//		bool succeeded = false;

		//		if (preventGC)
		//		{
		//			succeeded = GC.TryStartNoGCRegion(sizeInBytes); //, disallowFullBlockingGC: true);
		//			Console.WriteLine("TryStartNoGCRegion: Size={0:N0} MB ({1:N0} K or {2:N0} bytes) {3}",
		//				sizeInBytes / 1024.0 / 1024.0, sizeInBytes / 1024.0, sizeInBytes,
		//				succeeded ? "SUCCEEDED" : "FAILED");
		//		}

		//		// TryStartNoGCRegion() causes a GC Collection, so call this once it's completed
		//		var gcBefore = new GCInfo();
		//		if (!preventGC || succeeded)
		//		{
		//			long allocated = 0;
		//			var numRuns = 5;
		//			var sizePerRun = sizeInBytes / numRuns;
		//			if (overAllocate)
		//				numRuns += 5;

		//			var lastGC = new GCInfo();
		//			for (int i = 0; i < numRuns; i++)
		//			{
		//				var test = new byte[sizePerRun];
		//				allocated += (test.Length);

		//				var currentGC = new GCInfo();
		//				var totalMemory = GC.GetTotalMemory(forceFullCollection: false);
		//				var gcOccured = (currentGC.Gen0 > lastGC.Gen0 || currentGC.Gen1 > lastGC.Gen1 || currentGC.Gen2 > lastGC.Gen2);
		//				Console.WriteLine("Allocated: {0,6:N2} MB, Mode: {1,12}, Gen0: {2}, Gen1: {3}, Gen2: {4}, {5}",
		//					allocated / 1024.0 / 1024.0,
		//					GCSettings.LatencyMode,
		//					currentGC.Gen0 - gcBefore.Gen0,
		//					currentGC.Gen1 - gcBefore.Gen1,
		//					currentGC.Gen2 - gcBefore.Gen2,
		//					gcOccured ? "**" : "");
		//				lastGC = currentGC;
		//			}
		//			if (GCSettings.LatencyMode == GCLatencyMode.NoGCRegion)
		//				GC.EndNoGCRegion();
		//		}
		//	}
		//	catch (ArgumentOutOfRangeException argEx)
		//	{
		//		// totalSize exceeds the ephemeral segment size.
		//		Console.WriteLine("{0:N0} MB ({1:N0} K or {2:N0} bytes) - {3}",
		//			sizeInBytes / 1024.0 / 1024.0, sizeInBytes / 1024.0, sizeInBytes, argEx.Message);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("{0:N0} MB ({1:N0} K or {2:N0} bytes) - {3} {4}",
		//			sizeInBytes / 1024.0 / 1024.0, sizeInBytes / 1024.0, sizeInBytes, ex.GetType().Name, ex.Message);
		//	}

		//	Console.WriteLine();
		//}
	}
}
