using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.DisposePattern
{
	class DisposableFileStream : IDisposable
	{
		private FileStream _fileStream;
		private IntPtr _handle = Marshal.AllocHGlobal(4);

		public DisposableFileStream(FileStream fileStream)
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
		/// In non-garbage collected languages, as soon as the object's lifetime ends,
		/// either through the completion of the local block of execution or when an exception is thrown, 
		/// the destructor kicks in and the resources are automatically released. While garbage collection 
		/// simplifies the management of the object lifecycle, it does prevent an object from knowing when 
		/// it will be collected, which means that it is difficult to ensure that the resources held by that 
		/// object are released early. Before the memory associated with an object is reclaimed by the GC, 
		/// the Finalize method (if it is present) is invoked. This method is not tied to the lifetime of the object, 
		/// so the timing of when (or even if) Finalize is called is undefined. This is what is meant by saying that
		/// the GC performs non-deterministic finalization.
		/// </summary>
		~DisposableFileStream()
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
