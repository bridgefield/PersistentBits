using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bridgefield.PersistentBits.FileSystem;
using MonadicBits;

namespace Bridgefield.PersistentBits
{
    public static class OS
    {
        public static IFileSystem FileSystem() => new OsFileSystem();

        private sealed class OsDirectory : IDirectory
        {
            public string Path { get; }
            public string Name => System.IO.Path.GetFileName(Path);
            public IEnumerable<IFile> Files => Directory.EnumerateFiles(Path).Select(p => new OsFile(p));
            public OsDirectory(string path) => Path = path;

            public IFile CreateFile(string fileName)
                => new OsFile(System.IO.Path.Combine(Path, fileName));
        }

        private sealed class OsFileSystem : IFileSystem
        {
            public Maybe<IDirectory> OpenDirectory(string path)
                => new DirectoryInfo(path)
                    .JustWhen(d => d.Exists)
                    .Map<IDirectory>(d => new OsDirectory(d.FullName));

            public IDirectory CreateDirectory(string path)
            {
                Directory.CreateDirectory(path);
                return new OsDirectory(path);
            }
        }

        private sealed class OsFile : IFile
        {
            public string Path { get; }
            public string Name => System.IO.Path.GetFileName(Path);

            public OsFile(string path) => Path = path;

            public bool Exists() => File.Exists(Path);

            public Maybe<Stream> OpenRead() =>
                Path.JustWhen(File.Exists).Map<Stream>(File.OpenRead);

            public void Write(Action<Stream> writeAction) => writeAction(File.OpenWrite(Path));
        }
    }
}