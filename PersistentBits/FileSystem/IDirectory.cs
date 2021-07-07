using System.Collections.Generic;

namespace Bridgefield.PersistentBits.FileSystem
{
    public interface IDirectory : IFileSystemEntry
    {
        IEnumerable<IFile> Files { get; }
        IFile CreateFile(string fileName);
    }
}