using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.DisposePattern
{
	class Disposable : IDisposable
	{
		private FileStream _fileStream;
		private IntPtr _handle = Marshal.AllocHGlobal(4);

		public Disposable(FileStream fileStream)
		{
			_fileStream = fileStream;
		}

		/// <summary>
		/// Dispose managed resources
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			//Objects that implement the IDisposable interface can call this method from the object's 
			//IDisposable.Dispose implementation to prevent the garbage collector from calling Object.Finalize
			//on an object that does not require it. Typically, this is done to prevent the finalizer from releasing 
			//unmanaged resources that have already been freed by the IDisposable.Dispose implementation.
			GC.SuppressFinalize(this); //Requests that the common language runtime not call the finalizer for the specified object.
		}

		/// <summary>
		/// When finalizing (GC), destroy unmanaged resources
		/// </summary>
		~Disposable()
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
