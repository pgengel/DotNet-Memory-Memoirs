using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.DisposePattern
{
	class DisposablePattern : IDisposable
	{
		private FileStream _fileStream;
		private IntPtr _handle = Marshal.AllocHGlobal(4);

		public DisposablePattern(FileStream fileStream)
		{
			_fileStream = fileStream;
		}

		/// <summary>
		/// Dispose managed resources
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// When finalizing (GC), destroy unmanaged resources
		/// </summary>
		~DisposablePattern()
		{
			Dispose(false);
		}

		/// <summary>
		/// Actual dispose
		/// </summary>
		/// <param name="destroyManaged">Should dispose managed objects?</param>
		private void Dispose(bool destroyManaged)
		{
			if (destroyManaged)
			{
				_fileStream.Dispose();
			}

			Marshal.FreeHGlobal(_handle);
		}
	}

	class Clock: IDisposable
	{
		public void OnTick(object state)
		{
			Console.WriteLine(DateTime.UtcNow);
		}

		public void Dispose()
		{
		}
	}
}
