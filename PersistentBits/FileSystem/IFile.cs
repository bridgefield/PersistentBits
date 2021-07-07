using System;
using System.IO;
using MonadicBits;

namespace Bridgefield.PersistentBits.FileSystem
{
    public interface IFile : IFileSystemEntry
    {
        bool Exists();
        Maybe<Stream> OpenRead();
        void Write(Action<Stream> writeAction);
    }
}
