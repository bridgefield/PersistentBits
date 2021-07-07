using MonadicBits;

namespace Bridgefield.PersistentBits.FileSystem
{
    public interface IFileSystem
    {
        Maybe<IDirectory> OpenDirectory(string path);
        IDirectory CreateDirectory(string path);
    }
}