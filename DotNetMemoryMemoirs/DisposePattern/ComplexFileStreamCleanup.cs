using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryMemoirs.DisposePattern
{
	class ComplexFileStreamCleanup
	{
		private FileStream _fileStream;
		private IntPtr _handle = Marshal.AllocHGlobal(4);
		// some fields that require cleanup
		private bool disposed = false; // to detect redundant calls

		public ComplexFileStreamCleanup(FileStream fileStream)
		{
			// allocate resources
			_fileStream = fileStream;
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// dispose-only, i.e. non-finalizable logic
					_fileStream.Dispose();
				}

				// shared cleanup logic
				disposed = true;
				Marshal.FreeHGlobal(_handle);
			}
		}

		~ComplexFileStreamCleanup()
		{
			// finalizers run non-deterministically. 
			// You should not access any finalizable objects 
			// your type may have a reference to, because they may 
			// have already been finalized.
			// NullReferenceException!
			Dispose(false);
		}

		//This method will be called
		public void Dispose()
		{
			Dispose(true);

			// Requests that the common language runtime not
			// call the finalizer for the specified object.
			GC.SuppressFinalize(this);
		}
	}
}
