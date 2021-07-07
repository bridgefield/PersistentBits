namespace Bridgefield.PersistentBits.FileSystem
{
    public interface IFileSystemEntry
    {
        string Path { get; }
        string Name { get; }
    }
}