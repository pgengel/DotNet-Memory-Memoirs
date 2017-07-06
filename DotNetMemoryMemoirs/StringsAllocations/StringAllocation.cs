using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.StringsAllocations
{
	class StringAllocation : IDemo
	{
		private static readonly HttpClient _httpClient = new HttpClient();

		public void Run(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("String allocation");
			Console.ResetColor();
			Console.WriteLine("PID: {0}", Process.GetCurrentProcess().Id);
			Console.WriteLine("Attach the profiler, take a snapshot at each step, inspect string duplicates.");
			Console.WriteLine();

			Console.WriteLine("Hit enter to allocate some strings.");
			Console.ReadLine();
			AllocateSomeStrings();

			Console.WriteLine("Hit enter to allocate some string duplicates.");
			Console.ReadLine();
			AllocateSomeStringDuplicates();

			Console.WriteLine("Hit enter to allocate interned string literals.");
			Console.ReadLine();
			LiteralInterning();
		}

		static void AllocateSomeStrings()
		{
			var a = new string('-', 25);

			var b = "Hello, World!";

			//var c = _httpClient.GetStringAsync("AllocateSomeStringsMethod").Result;
		}

		static void AllocateSomeStringDuplicates()
		{
			var a = "AllocateSomeDuplicateStringsMethod";
			var stringList = new List<string>();
			for (int i = 0; i < 100; i++)
			{
				stringList.Add(a + "AppendAnotherString");
			}
		}

		static void AllocateSomeStringDuplicatesWithInterning()
		{
			//This will check that the string already exists and not make a duplicate
			var dummy = string.Intern("AllocateSomeStringDuplicatesWithInterning");

			var url = string.Intern("AllocateSomeStringDuplicatesWithInterning");

			var stringList = new List<string>();
			for (int i = 0; i < 100; i++)
			{
				stringList.Add(string.Intern(url));
			}
		}

		static void LiteralInterning()
		{
			var hello = "Hello";
			var helloWorld1 = "Hello, World";
			var helloWorld2 = "Hello, World";
			var helloWorld3 = hello + ", World";

			Console.WriteLine("['{0}', '{1}'] ==? {2}, ReferenceEquals? {3}",
				helloWorld1,
				helloWorld2,
				helloWorld1 == helloWorld2,
				ReferenceEquals(helloWorld1, helloWorld2));

			Console.WriteLine("['{0}', '{1}'] ==? {2}, ReferenceEquals? {3}",
				helloWorld1,
				helloWorld3,
				helloWorld1 == helloWorld3,
				ReferenceEquals(helloWorld1, helloWorld3));

			Console.WriteLine("'{0}'.IsInterned: {1}", hello, string.IsInterned(hello) != null);
			Console.WriteLine("'{0}'.IsInterned: {1}", helloWorld1, string.IsInterned(helloWorld1) != null);
			Console.WriteLine("'{0}'.IsInterned: {1}", helloWorld2, string.IsInterned(helloWorld2) != null);
			Console.WriteLine("'{0}'.IsInterned: {1}", helloWorld3, string.IsInterned(helloWorld3) != null);
		}
	}
}
