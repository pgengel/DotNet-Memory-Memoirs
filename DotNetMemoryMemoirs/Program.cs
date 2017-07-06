﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMemoryMemoirs.DisposePattern;
using DotNetMemoryMemoirs.GCMethods;
using DotNetMemoryMemoirs.LargeObjects;
using DotNetMemoryMemoirs.StringsAllocations;

namespace DotNetMemoryMemoirs
{
	class Program
	{
		static void Main(string[] args)
		{
			var demosToRun = new List<IDemo>();

			Console.Write("Which demo would you like to run? (enter a number) ");
			var demoNumber = Console.ReadLine().TrimEnd('\r', 'n');

			switch (demoNumber.ToLowerInvariant())
			{
				case "1":
					//demosToRun.Add(new StringAllocation());
					//demosToRun.Add(new GCCollection());
					//demosToRun.Add(new WeakReferences.WeakReferences());
					//demosToRun.Add(new DisposeObject());
					demosToRun.Add(new LoaderUnOptimised());
					//demosToRun.Add(new LoaderOptimised());

					break;
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Unknown demo. Try restarting the application.");
					Console.ResetColor();
					Console.ReadLine();
					break;
			}

			foreach (var demo in demosToRun)
			{
				GC.Collect();
				Console.Clear();

				demo.Run(args);

				Console.WriteLine();
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("Press <enter> to continue.");
				Console.ResetColor();
				Console.ReadLine();
			}
		}
	}
}
